# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.Synopsis
    Gets the latest production release version of the specified NuGet package.

.Description
    Gets the NuGet package version of latest production release and compares the
    version to the version set in the specified project file. If they match, this
    script will fail and indicate that the version needs to be updated.

.Parameter packageName
    Specifies the package name of the package. For example, 'microsoft.kiota.abstractions'
    is a valid package name.

.Parameter projectPath
    Specifies the path to the project file.

.Parameter nugetConfigPath
    Specifies the path to the NuGet configuration for the Central Feed Service.
#>

Param(
    [parameter(Mandatory = $true)]
    [string]$packageName,

    [parameter(Mandatory = $true)]
    [string]$projectPath,

    [parameter(Mandatory = $true)]
    [string]$nugetConfigPath
)

[xml]$xmlDoc = Get-Content $projectPath

# Assumption: VersionPrefix is set in the first property group.
$versionPrefixString = $xmlDoc.Project.PropertyGroup[0].VersionPrefix
if($xmlDoc.Project.PropertyGroup[0].VersionSuffix){
    $versionPrefixString = $versionPrefixString + "-"  + $xmlDoc.Project.PropertyGroup[0].VersionSuffix
}


# System.Version, get the version prefix.
$currentProjectVersion = [System.Management.Automation.SemanticVersion]"$versionPrefixString"

Try {
    $searchResultJson = dotnet package search $packageName --configfile $nugetConfigPath --exact-match --prerelease --format json
    if ($LASTEXITCODE -ne 0) {
        throw "dotnet package search exited with code $LASTEXITCODE"
    }

    $searchResult = $searchResultJson | ConvertFrom-Json
    $matchingPackages = $searchResult.searchResult | ForEach-Object { $_.packages } | Where-Object { $_.id -ieq $packageName }
}
Catch {
    Write-Host $_
    Exit 1
}

if (-not $matchingPackages) {
    Write-Host "No package exists. You will probably be publishing $packageName for the first time."
    Exit # exit gracefully
}

$currentPublishedVersion = ($matchingPackages | ForEach-Object { [System.Management.Automation.SemanticVersion]$_.version } | Sort-Object)[-1]

# Validate that the version number has been updated.
if ($currentProjectVersion -le $currentPublishedVersion) {

    Write-Error "The current published version number, $currentPublishedVersion, and the version number `
               in the csproj file, $currentProjectVersion, match. You must increment the version"
}
else {
    Write-Host "Validated that the version has been updated from $currentPublishedVersion to $currentProjectVersion" -ForegroundColor Green
}
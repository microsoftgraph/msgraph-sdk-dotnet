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
#>

Param(
    [parameter(Mandatory = $true)]
    [string]$packageName,

    [parameter(Mandatory = $true)]
    [string]$projectPath
)

[xml]$xmlDoc = Get-Content $projectPath

# Assumption: VersionPrefix is set in the first property group.
$versionPrefixString = $xmlDoc.Project.PropertyGroup[0].VersionPrefix
if($xmlDoc.Project.PropertyGroup[0].VersionSuffix){
    $versionPrefixString = $versionPrefixString + "-"  + $xmlDoc.Project.PropertyGroup[0].VersionSuffix
}


# System.Version, get the version prefix.
$currentProjectVersion = [System.Management.Automation.SemanticVersion]"$versionPrefixString"

# API is case-sensitive
$packageName = $packageName.ToLower()
$url = "https://azuresearch-usnc.nuget.org/query?q=packageid:$packageName&prerelease=true&semVerLevel=2.0.0"

# Call the NuGet API for the package and get the current published version.
Try {
    $nugetIndex = Invoke-RestMethod -Uri $url -Method Get
}
Catch {
    if ($_.ErrorDetails.Message && $_.ErrorDetails.Message.Contains("The specified blob does not exist.")) {
        Write-Host "No package exists. You will probably be publishing $packageName for the first time."
        Exit # exit gracefully
    }
    
    Write-Host $_
    Exit 1
}

$currentPublishedVersion = [System.Management.Automation.SemanticVersion]$nugetIndex.data[0].version

# Validate that the version number has been updated.
if ($currentProjectVersion -le $currentPublishedVersion) {

    Write-Error "The current published version number, $currentPublishedVersion, and the version number `
               in the csproj file, $currentProjectVersion, match. You must increment the version"
}
else {
    Write-Host "Validated that the version has been updated from $currentPublishedVersion to $currentProjectVersion" -ForegroundColor Green
}
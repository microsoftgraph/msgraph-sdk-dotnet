# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.Synopsis
    Increment the minor version string in the csproj if the major,
    minor, or patch version hasn't been manually updated.
.Description
    Assumptions:
        Targets Microsoft.Graph.csproj
        This script assumes it is run from the repo root.
        VersionPrefix is set in the first property group in the csproj.
        Major or patch update versions are manually set by dev.
        Minor version is typically auto-incremented.

#>

$fullFileName = Join-Path $PWD.ToString() "src" "Microsoft.Graph" "Microsoft.Graph.csproj"

# Read .csproj file as UTF-8
$xmlDoc = New-Object -TypeName XML
$utf8Encoding = (New-Object System.Text.UTF8Encoding($false))
$streamReader = New-Object System.IO.StreamReader($fullFileName, $utf8Encoding, $false)
$xmlDoc.Load($streamReader)
$streamReader.Close()

# Assumption: VersionPrefix is set in the first property group.
$versionPrefixString = $xmlDoc.Project.PropertyGroup[0].VersionPrefix

# System.Version, get the version prefix.
$currentProjectVersion = [version]"$versionPrefixString"

# Get the current version in SDK.
$majorVersion = $currentProjectVersion.Major.ToString()
$minorVersion = $currentProjectVersion.Minor.ToString()
$patchVersion = $currentProjectVersion.Build.ToString()

# Get the current version of the latest public NuGet package.
$url = "https://api.nuget.org/v3/registration5-gz-semver2/microsoft.graph/index.json"
$nugetIndex = Invoke-RestMethod -Uri $url -Method Get
$currentPublishedVersion = $nugetIndex.items[$nugetIndex.items.Count-1].upper
$publishedMajorVersion = $currentPublishedVersion.Split(".")[0]
$publishedMinorVersion = $currentPublishedVersion.Split(".")[1]
$publishedPatchVersion = $currentPublishedVersion.Split(".")[2]

# Do not update the minor version if the version has been manually updated.
if ($majorVersion -ne $publishedMajorVersion -or `
        $minorVersion -ne $publishedMinorVersion -or `
        $patchVersion -ne $publishedPatchVersion) {
    Write-Host "The version has been manually incremented. We will not auto-increment minor version."
    Exit 0;
}

# Increment minor version and set patchVersion to zero.
$minorVersion = ($currentProjectVersion.Minor + 1).ToString()
$patchVersion = "0"

$updatedVersionPrefixString = "{0}.{1}.{2}" -f $majorVersion, $minorVersion, $patchVersion
$xmlDoc.Project.PropertyGroup[0].VersionPrefix = $updatedVersionPrefixString

$xmlDoc.Save($fullFileName)

Write-Host "Version incremented from $versionPrefixString to $updatedVersionPrefixString"

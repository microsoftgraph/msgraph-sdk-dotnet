# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.Synopsis
    Gets the latest commit SHA for the repository.
.Description
    Uses the GitHub API and the owner name, the repository name, and the branch name
    to get the latest commit SHA and set its value to an environment variable named
    LATEST_COMMIT_SHA in an Azure DevOps release environment.
.Parameter owner
    Specifies the owner of the repo.
.Parameter repo
    Specifies the name of the repository.
.Parameter branchName
    Specifies the target branch name. The default value is 'master'.
#>

Param(
    [string]$owner,
    [string]$repo,
    [string]$branchName = "master"
)

if ([string]::IsNullOrEmpty($owner)) {
    Write-Error "owner cannot be empty."
    EXIT 1
}

if ([string]::IsNullOrEmpty($repo)) {
    Write-Error "repo cannot be empty."
    EXIT 1
}

Write-Host "Getting the latest commit SHA for $($branchName):" -ForegroundColor Magenta

$latestCommitUrl = "https://api.github.com/repos/$($owner)/$($repo)/commits/$($branchName)"

Write-Host "Getting latest commit with '$($latestCommitUrl)'" -ForegroundColor Blue
$latestCommitData = Invoke-RestMethod -Uri $latestCommitUrl -Method Get

if ($latestCommitData.Count -eq 0) {
    Write-Host "Unable to get latest commit with '$($latestCommitUrl)'" -ForegroundColor Red
    EXIT 1;
}

if ([string]::IsNullOrEmpty($latestCommitData.sha)) {
    Write-Host "SHA is not present in the latest commit that is fetched" -ForegroundColor Red
    Write-Host "Latest Commit Data:" -ForegroundColor Cyan
    Write-Host -Object $latestCommitData -ForegroundColor Cyan
    EXIT 1;
}

Write-Host "Latest Commit SHA is '$($latestCommitData.sha)'" -ForegroundColor Green

Write-Host "##vso[task.setvariable variable=LATEST_COMMIT_SHA]$($latestCommitData.sha)"

Write-Host "Updated the LATEST_COMMIT_SHA environment variable with the latest commit SHA." -ForegroundColor Green
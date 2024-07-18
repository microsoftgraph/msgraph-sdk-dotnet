param (
	[string]
	$relativePath = "./kiota-dom-export.txt",
    [string]
    $initialCommitSha = "",
    [string]
    $finalCommitSha = ""
)
$relativePath = Get-ChildItem -Recurse -Filter "kiota-lock.json" | Select-Object -First 1
if ($null -ne $relativePath) {
    if ($initialCommitSha -eq "" -or $finalCommitSha -eq "") {
        $result = git format-patch -1 HEAD --minimal -U0 -w $relativePath
    } else {
        $result = git format-patch $initialCommitSha..$finalCommitSha --minimal -U0 -w $relativePath
    }

    if (Test-Path $result) {
        "isFilePresent=true" | Out-File -FilePath $env:GITHUB_ENV -Append
        "patchFilePath=$result" | Out-File -FilePath $env:GITHUB_ENV -Append
        exit 0
    }
}
"isFilePresent=false" | Out-File -FilePath $env:GITHUB_ENV -Append
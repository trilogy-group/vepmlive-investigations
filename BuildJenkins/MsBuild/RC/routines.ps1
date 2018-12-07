function SetAssemblyFileVersion($assemblyInfoFile, $version) {
    $regexp = "AssemblyFileVersion\(\""(\d+)\.(\d+)\.(\d+)\.(\d+)\""\)"
    $replacement = "AssemblyFileVersion(""$version"")"
    (Get-Content $assemblyInfoFile) | ForEach-Object { $_ -replace $regexp, $replacement } | Set-Content $assemblyInfoFile
}

function SetBuildVersion($buildVersionFile, $version) {
    $regexp = "Version(""@BuildVersion@"")"
    $replacement = "Version(""$version"")"
    (Get-Content $buildVersionFile) | ForEach-Object { $_ -replace $regexp, $replacement } | Set-Content $buildVersionFile
}

function RunMsBuild(
    [string]$solutionFile,
    [string]$ToolsVersion = "/tv:14.0",
    [string]$MsBuildArguments = '/p:visualstudioversion=14.0',
    [string]$SDKPath = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.2 Tools",
    [string]$RuleSetsPath = "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Team Tools\Static Analysis Tools\Rule Sets")
{
    $msbuild = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
    Write-Host "Launching build of $solutionFile"
    & $msbuild `
        $solutionFile `
        /p:Configuration="Release" `
        /p:Platform="Any CPU" `
        /m:4 `
        /p:CodeAnalysisRuleSetDirectories="$RuleSetsPath" `
        /p:TargetFrameworkSDKToolsDirectory="$SDKPath" `
        $ToolsVersion `
        $MsBuildArguments

    if ($LastExitCode) {
        throw "Msbuild failed with exit code $LastExitCode"
    }
}
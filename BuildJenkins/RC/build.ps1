param(
    [string] $version = $(throw "Must specify version. e.g., -version 7.0.0.1"),
    [string] $rootDir,
    [string] $outputDir
)
$ErrorActionPreference = "Stop"

# Define directories
$scriptDir = split-path -parent $MyInvocation.MyCommand.Definition
if ($rootDir -eq '') {
	$rootDir = (Get-Item $scriptDir).Parent.Parent.FullName
}
if (!$outputDir) {
    $outputDir = Join-Path $rootDir "output/EPMLive"
}

# Load routines
. $scriptDir/routines.ps1

# Creating empty output directory
Remove-Item -Path $outputDir -Recurse -ErrorAction:SilentlyContinue
New-Item -Path $outputDir -ItemType Directory -Force > $null

Set-Location -Path $rootDir

Write-Host "Write build number"
"[assembly:System.Reflection.AssemblyFileVersion(""$version"")]" > CommonAssemblyInfo.cs

Write-Host "Execute builds"
Write-Host "Executing tl_buildInstaller.ps1"
& .\BuildTeamCity\tl_buildInstaller.ps1 -SkipInstallShield
Write-Host "Executing tl_buildCode.ps1"
& .\BuildTeamCity\tl_buildCode.ps1 -TestsOnly -CleanBuild $false
$buildRoot = Join-Path $rootDir "BuildTeamCity"
Set-Location -Path $buildRoot
# Execute ps1 for EPM Live (generates config.json and other required wsp or dll files)
Write-Host "Executing tl_buildSilentInstaller.ps1"
& .\tl_buildSilentInstaller.ps1

Write-Host "Copy Silent installer to output dir"
$installerDir = Join-Path $buildRoot "SilentInstaller"
Copy-Item -Path (Join-Path $installerDir "*") -Destination $outputDir -Recurse

Write-Host "Make GUI installer"
$epmLiveInstallerRoot = Join-Path $rootDir "EPMLiveInstaller"
SetBuildVersion (Join-Path $epmLiveInstallerRoot "NewsGator.Install.Common/BuildVersion.cs") $version
SetAssemblyFileVersion (Join-Path $epmLiveInstallerRoot "NewsGator.Install.Common/Version.cs") $version
SetAssemblyFileVersion (Join-Path $epmLiveInstallerRoot "NewsGator.Install.Resources/Version.cs") $version

$epmLiveInstallLauncherRoot = Join-Path $epmLiveInstallerRoot "EPMLive.Install.Launcher"
SetAssemblyFileVersion (Join-Path $epmLiveInstallLauncherRoot "Properties/AssemblyInfo.cs") $version
$epmLiveInstallerSln = Join-Path $epmLiveInstallerRoot "EPMLive.Installer.sln"
$msbuild = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
Write-Host "Launch & $msbuild /p:Configuration="Release" /p:Platform="Any CPU" /m:4 $epmLiveInstallerSln"
& $msbuild /p:Configuration="Release" /p:Platform="Any CPU" /m:4 $epmLiveInstallerSln
if ($LastExitCode) {
    throw "Msbuild failed with exit code $LastExitCode"
}
$epmLiveInstallerBin = Join-Path $epmLiveInstallLauncherRoot "bin/Release"

Write-Host "Copy GUI installer to output dir"
Copy-Item -Path (Join-Path $epmLiveInstallerBin "*") -Destination $outputDir -Recurse -Exclude "*.pdb"

Write-Host "Done. Installer is located at $outputDir"
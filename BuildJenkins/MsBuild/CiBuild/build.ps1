param(
    [string] $version = $(throw "Must specify version. e.g., -version 7.0.0.1"),
    [string] $rootDir
)
$ErrorActionPreference = "Stop"

$TempFileLocation = "$env:windir\Temp","$env:TEMP"
$SoftwareDistributionLocation = "$env:windir\SoftwareDistribution\Download"

$TempFile = Get-ChildItem $TempFileLocation -Recurse
$TempFileCount = ($TempFile).count

if($TempFileCount -eq "0") { 
Write-Host "There are no files in the folder $TempFileLocation" -ForegroundColor Green
}
Else {
$TempFile | Remove-Item -Confirm:$false -Recurse -Force -WarningAction SilentlyContinue -ErrorAction SilentlyContinue
Write-Host "Cleared $TempFileCount files in the folder $TempFileLocation" -ForegroundColor Green
}

$SoftwareDistribution = Get-ChildItem $SoftwareDistributionLocation -Recurse
$SoftwareDistributionCount = ($SoftwareDistribution).Count
if($SoftwareDistributionCount -eq "0"){
Write-Host " There are no files in the folder $SoftwareDistributionLocation" -ForegroundColor Green
}
Else
{
$SoftwareDistribution | Remove-Item -Confirm:$false -Recurse -Force -WarningAction SilentlyContinue -ErrorAction SilentlyContinue
Write-Host "Cleared $SoftwareDistributionCount files in the folder $SoftwareDistributionLocation" -ForegroundColor Green
}

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

Write-Host "Executing tl_buildCode.ps1"
& .\BuildTeamCity\tl_buildCode.ps1 -ConfigurationToBuild Debug


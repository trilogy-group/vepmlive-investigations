function PublishArtifact($artifactPath) {
    Write-Host ("`n`nPublishing Artifact") -ForegroundColor Yellow
    Write-Host "##teamcity[publishArtifacts '$artifactPath']"
}

$ScriptDir = split-path -parent $MyInvocation.MyCommand.Definition
$ScriptDir = (get-item $ScriptDir).parent.FullName 
$coverageFile = $(get-ChildItem -Path "$ScriptDir\TestResults" -Recurse -Include *coverage)[0]
$xmlCoverageFile = "$ScriptDir\TestResults\vstest.coveragexml"
$reportPath = "$ScriptDir\CoverageReports"
$artifactsDir = "$ScriptDir\Artifacts"

New-Item -ItemType Directory -Force -Path $reportPath
New-Item -ItemType Directory -Force -Path $artifactsDir

Add-Type -path "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\PrivateAssemblies\Microsoft.VisualStudio.Coverage.Analysis.dll"

[string[]] $executablePaths = @($coverageFile)
[string[]] $symbolPaths = @()

$info = [Microsoft.VisualStudio.Coverage.Analysis.CoverageInfo]::CreateFromFile($coverageFile, $executablePaths, $symbolPaths);
$data = $info.BuildDataSet()

$data.WriteXml($xmlCoverageFile)

$RepGenPath = "$ScriptDir\packages\ReportGenerator.2.5.2\tools\ReportGenerator.exe"

&$RepGenPath -reports:$xmlCoverageFile -targetdir:$reportPath -reportTypes:"HtmlSummary;XMLSummary"



function CreateCoverageArtifactsPackage() {
    Write-Host ("`n`Packing Coverage Artifacts") -ForegroundColor Yellow

    Rename-Item -Path "$reportPath\summary.htm" -NewName "$reportPath\index.html" -ErrorAction SilentlyContinue -Force

    [System.Reflection.Assembly]::LoadWithPartialName("System.IO.Compression.FileSystem") | Out-Null 
    [System.IO.Compression.Zipfile]::CreateFromDirectory("$reportPath","$artifactsDir\coverage.zip") | Out-Null
}

CreateCoverageArtifactsPackage

$xmlFile = Join-Path $reportPath "summary.xml"
[xml]$cn = Get-Content $xmlFile

$CodeCoverageAbsLTotal= $cn.CoverageReport.Summary.Coverablelines
$CodeCoverageAbsLCovered = $cn.CoverageReport.Summary.Coveredlines

"##teamcity[buildStatisticValue key='CodeCoverageAbsLTotal' value='$CodeCoverageAbsLTotal']"
"##teamcity[buildStatisticValue key='CodeCoverageAbsLCovered' value='$CodeCoverageAbsLCovered']"
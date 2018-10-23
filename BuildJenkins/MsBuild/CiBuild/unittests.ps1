Param(
	[string] $sourcesRoot = $null
)

$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
. $scriptDir\funcs.ps1
. $scriptDir\assembliesToCover.ps1

if ($sourcesRoot -eq '') {
	$sourcesRoot = (Get-Item $scriptDir).Parent.Parent.Parent.FullName
}
$testResultDir = Join-Path $sourcesRoot "TestResults"

$vstestConsolePath = "C:\Program Files (x86)\Microsoft Visual Studio\2017\TestAgent\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
$codeCoveragePath = "C:\Program Files (x86)\Microsoft Visual Studio\2017\TestAgent\Team Tools\Dynamic Code Coverage Tools\amd64\CodeCoverage.exe"
$reportGeneratorPath = "C:\ReportGenerator\ReportGenerator.exe"

$asmsToSendToVsTest = New-Object System.Collections.Generic.HashSet[object]

Write-Host 'Collecting test assemblies...'
$assmsToRun = (CollectTestAssemblies)
Write-Host $assmsToRun.Count "assemblies found:"
foreach ($testAsm in $assmsToRun) {
    $asmsToSendToVsTest.Add($testAsm) > $null
    Write-Host $testAsm
}

Write-Host 'Listing assemblies to cover'
$assembliesToCover = (GetAssembliesToCover)
Write-Host $assembliesToCover.Count "assemblies"
foreach ($asmToCover in $assembliesToCover) {
    $asmToCover = Join-Path $sourcesRoot $asmToCover
    if(![System.IO.File]::Exists($asmToCover)){
        throw "Cannot find assembly $asmToCover"
    }
    $asmsToSendToVsTest.Add($asmToCover) > $null
    Write-Host $asmToCover
}

Write-Host 'Clearing test results directory'
Remove-Item -Path $testResultDir -Recurse -ErrorAction:SilentlyContinue
New-Item -ItemType Directory -Force -Path $testResultDir > $null

Write-Host 'Executing unit tests and collecting coverage'
.$vstestConsolePath /Logger:trx /Platform:x64 /InIsolation /EnableCodeCoverage /Parallel $asmsToSendToVsTest

Write-Host 'Converting .coverage to .coveragexml'
$coverageFile = (Get-ChildItem -File (Join-Path $sourcesRoot *.coverage) -Recurse | Select-Object -first 1).FullName
$coverageXmlFile = Join-Path $testResultDir "coverage.xml"
Write-Host "Coverage file (input): $coverageFile"
Write-Host "CoverageXml file (output): $coverageXmlFile"
.$codeCoveragePath analyze /output:$coverageXmlFile $coverageFile

Write-Host 'Generating coverage report'
.$reportGeneratorPath `
    -reports:"$coverageXmlFile"  `
    -targetdir:(Join-Path $testResultDir CoverageReport) `
    -reportTypes:"HtmlSummary;XMLSummary" `
    -assemblyfilters:"-*tests*;-moq;-*autofixture*;-*newtonsoft*;-*.test*;-*tests;-*.Test.Commons;-*.TestCommons;-*.aut.*;-*.resources" `
    -classfilters:"-Moq.*"

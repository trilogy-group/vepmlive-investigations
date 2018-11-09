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

Write-Host 'Clearing test results directory'
Remove-Item -Path $testResultDir -Recurse -ErrorAction:SilentlyContinue
New-Item -ItemType Directory -Force -Path $testResultDir > $null


Write-Host 'Listing assemblies to cover'
$assembliesToCover = (GetAssembliesToCover)
Write-Host $assembliesToCover.Count "assemblies"

Write-Host 'Collecting test assemblies...'
$assmsToRun = (CollectTestAssemblies)

$asmsToSendToVsTest = ""
foreach ($asmToCover in $assembliesToCover) {
    $asmToCover = Join-Path $sourcesRoot $asmToCover
    if(![System.IO.File]::Exists($asmToCover)){
        throw "Cannot find assembly $asmToCover"
    }
    $asmsToSendToVsTest = $asmsToSendToVsTest + '"' + $asmToCover + '" '
}

Write-Host $assmsToRun.Count "assemblies found:"
for ($i=0; $i -lt $assmsToRun.Count; $i++) {
	$asmsToSendToVsTest = $asmsToSendToVsTest + '"' + $assmsToRun[$i] + '" '
}

$testResultFile = Join-Path $testResultDir "JUnitLikeResultsOutputFile1.xml"
Write-Host 'Executing unit tests and collecting coverage'
$setupProcess = Start-Process -PassThru -Wait -NoNewWindow -FilePath $vstestConsolePath -ArgumentList "/logger:JUnitLogger;TestResultsFile=$testResultFile /Platform:x64 /InIsolation /EnableCodeCoverage /Parallel $asmsToSendToVsTest"


Write-Host 'Converting .coverage to .coveragexml'
$coverageFiles = (Get-ChildItem -File (Join-Path $sourcesRoot *.coverage) -Recurse)
$coverageFile = ''
foreach ($coverageItem in $coverageFiles)
{
  $coverageFile = $coverageFile + '"' + $coverageItem.FullName + '" '
}
$coverageFile.trimend(',')


<#
$trxFile = (Get-ChildItem -File (Join-Path $sourcesRoot *.trx) -Recurse | Select-Object -first 1).FullName
Write-Host "Trx File: $trxFile"
$convertedFile = Join-Path $testResultDir "JUnitLikeResultsOutputFile1.xml"
Write-Host "Converting trx to xml: $convertedFile"
$setupProcess = Start-Process -PassThru -Wait -NoNewWindow -FilePath 'C:/Program Files/Saxonica/SaxonPE9.8N/bin/transform.exe' -ArgumentList "-s:$trxFile -xsl:C:\Msxml\mstest-to-junit_withOutput.xsl -o:$convertedFile"
If($setupProcess.Exitcode -ne 0) {      Throw "Errorlevel $($setupProcess.ExitCode)" } 


$trxFile = (Get-ChildItem -File (Join-Path $sourcesRoot *.trx) -Recurse | Select-Object -first 1).FullName
Write-Host "Trx File: $trxFile"
Write-Host "Converting trx to html"
$setupProcess = Start-Process -PassThru -Wait -NoNewWindow -FilePath 'C:/trx2html/trx2html.exe' -ArgumentList $trxFile
If($setupProcess.Exitcode -ne 0) {      Throw "Errorlevel $($setupProcess.ExitCode)" } 
$generatedFile = $trxFile + '.htm'
Rename-Item  $generatedFile -newname 'TestResultsReport.htm'
#>

$coverageXmlFile = Join-Path $testResultDir "vstest.coveragexml" 
Write-Host "Coverage file (input): $coverageFile"
Write-Host "CoverageXml file (output): $coverageXmlFile"
$setupProcess = Start-Process -PassThru -Wait -NoNewWindow -FilePath $codeCoveragePath  -ArgumentList "analyze /output:$coverageXmlFile $coverageFile"
If($setupProcess.Exitcode -ne 0) {      Throw "Errorlevel $($setupProcess.ExitCode)" } 



Write-Host 'Generating coverage report'
.$reportGeneratorPath `
    -reports:"$coverageXmlFile"  `
    -targetdir:(Join-Path $testResultDir CoverageReport) `
    -reportTypes:"HtmlSummary;XMLSummary" `
    -assemblyfilters:"-*tests*;-*moq*;-*autofixture*;-*newtonsoft*;-*.test*;-*tests;-*.Test.Commons;-*.TestCommons;-*.aut.*;-*.resources;-*NUnit*" `
    -classfilters:"-Moq.*;*nunit*"


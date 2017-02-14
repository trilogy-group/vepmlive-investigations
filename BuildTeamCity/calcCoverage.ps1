$ScriptDir = split-path -parent $MyInvocation.MyCommand.Definition
$ScriptDir = (get-item $ScriptDir).parent.FullName

$openCoverPath = (Resolve-Path "$ScriptDir\packages\OpenCover.*\tools\OpenCover.Console.exe").ToString()
$vsConsolePath = "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
$a = New-Object -ComObject Scripting.FileSystemObject
$f = $a.GetFile($vsConsolePath)
$vsConsolePath = $f.ShortPath

$targetFiles= (@(Get-ChildItem "$ScriptDir" -Include *.Tests.dll -Recurse -File |
    Where-Object {(
        $_.DirectoryName -inotmatch '\\obj\\' -and
        $_.DirectoryName -ilike "*\Debug"
    )}
) | Select -ExpandProperty FullName) -join " "

Write-Host $targetFiles

&$openCoverPath  -register:user -target:$vsConsolePath "-targetargs:$targetFiles" "-filter:+[*]* -[*.tests]* -[*.Tests]* -[*.TestFakes]*" -excludebyfile:"*\*Designer.cs" -output:$ScriptDir\opencovertests.xml -mergebyhash

function PublishArtifact($artifactPath) {
    Write-Host ("`n`nPublishing Artifact") -ForegroundColor Yellow
    Write-Host "##teamcity[publishArtifacts '$artifactPath']"
}

#$ScriptDir = split-path -parent $MyInvocation.MyCommand.Definition
#$ScriptDir = (get-item $ScriptDir).parent.FullName 
#$coverageFile = $(get-ChildItem -Path "$ScriptDir\TestResults" -Recurse -Include *coverage)[0]
$xmlCoverageFile = "$ScriptDir\opencovertests.xml"
$reportPath = "$ScriptDir\CoverageReports"
$artifactsDir = "$ScriptDir\Artifacts"

New-Item -ItemType Directory -Force -Path $reportPath
New-Item -ItemType Directory -Force -Path $artifactsDir

#Add-Type -path "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\PrivateAssemblies\Microsoft.VisualStudio.Coverage.Analysis.dll"

#[string[]] $executablePaths = @($coverageFile)
#[string[]] $symbolPaths = @()

#$info = [Microsoft.VisualStudio.Coverage.Analysis.CoverageInfo]::CreateFromFile($coverageFile, $executablePaths, $symbolPaths);
#$data = $info.BuildDataSet()

#$data.WriteXml($xmlCoverageFile)

$RepGenPath = (Resolve-Path "$ScriptDir\packages\ReportGenerator.*\tools\ReportGenerator.exe").ToString()

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
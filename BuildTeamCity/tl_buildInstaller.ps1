# Build script for EPMLive
# 2016.02.24 - Made changes to work with the build post-removal of circular dependencies

# ### Define user adjustable parameters

param (
    # MSBuild - which configuration to build
    [string]$ConfigurationToBuild = "Release",
    # MSBuild - for which platform to make builds
    [string]$PlatformToBuild = "Any CPU",
    # Tools Version to pass to MSBuild
    [string]$ToolsVersion = "/tv:14.0",
    # user-specific additional command line parameters to pass to MSBuild
    [string]$MsBuildArguments = "/p:visualstudioversion=14.0",
    # should build cleanup be performed before making build
    [string]$CleanBuild = $true
);

$projectsToBePackaged = @("EPMLiveCore","EPMLiveDashboards","EPMLiveIntegrationService",
                            "EPMLivePS","EPMLiveReporting","EPMLiveSynch",
                            "EPMLiveTimeSheets","EPMLiveWebParts","EPMLiveWorkPlanner",
							"WorkEnginePPM",
                            "AdminSite","BillingSite")

$projectsToBeBuildAsEXE = @(
                            "EPMLiveTimerService", "EPK_QueueMgr"
                            )
$projectsToBeBuildAsDLL = @(
                            "PortfolioEngineCore","UplandIntegrations",
                            "EPMLiveIntegration", "UserNameChecker"
                            )

$projectTypeIdTobeReplaced = "C1CDDADD-2546-481F-9697-4EA41081F2FC"
$projectTypeIdTobeReplacedWith = "BB1F664B-9266-4fd6-B973-E1E44974B511"

# Define script directory
$ScriptDir = split-path -parent $MyInvocation.MyCommand.Definition

$env:EnableNuGetPackageRestore = "true"

# ### Includes 

# look-up of dependent libs
. $ScriptDir\RefsLocate.ps1

$SourcesDirectory = "$ScriptDir\..\"


# ### Logging helpers

function Log-Section($sectionName) {
	Write-Host "============================================================"
	Write-Host "`t $sectionName"
	Write-Host "============================================================"
}

function Log-SubSection($subsectionName) {
	Write-Host "------------------------------------------------------------"
	Write-Host "`t $subsectionName"
	Write-Host "------------------------------------------------------------"
}

function Log-Message($msg) {
	Write-Host $msg
}

function ZipFiles( $zipfilename, $sourcedir )
{
   Log-SubSection "Zipping $sourcedir to $zipfilename"
   
   If(Test-path $zipfilename) {Remove-item $zipfilename}
   $compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
   Add-Type -Assembly System.IO.Compression.FileSystem
   [System.IO.Compression.ZipFile]::CreateFromDirectory($sourcedir,  $zipfilename, $compressionLevel,  $true)
}

# additional parameters to msbuild
if (Test-Path env:\DF_MSBUILD_BUILD_STATS_OPTS) {
	$DfMsBuildArgs = Get-Childitem env:DF_MSBUILD_BUILD_STATS_OPTS | % { $_.Value }
}


$MSBuildExec = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"


$BuildDirectory = "$ScriptDir\..\..\"

$NewReleaseNumber = "6.0.0.0"
# additional parameters to msbuild
if (Test-Path env:\build_number) {
	$NewReleaseNumber = $env:build_number
}


# Directory for outputs
$OutputDirectory = Join-Path $BuildDirectory "output"
# Initialize Binaries Directory
$BinariesDirectory = Join-Path $OutputDirectory "binaries"
# Initialize merged binaries folder
# This directory holds "Single-Folder" build output of all projects
# This is used as a repository to look up dependent DLLs for projects when  
# packaging libs for each project in a separate folder.
# Initialize Libraries Directory
$LibrariesDirectory = "$OutputDirectory\libraries"
# Initialize intermediates directory (PDB)
$IntermediatesDirectory = "$OutputDirectory\intermediate"
# Initialize logs directory
$LogsDirectory = "$BuildDirectory\logs"
if (!(Test-Path -Path $LogsDirectory )){
    New-Item $LogsDirectory -type Directory
}

$projAbsPath = Join-Path $SourcesDirectory "EPMLive.sln"
$projDir = Split-Path $projAbsPath -parent
$projName = [System.IO.Path]::GetFileNameWithoutExtension($projAbsPath) 

$loggerArgs = "LogFile=$LogsDirectory\${projName}.log;Verbosity=normal;Encoding=Unicode"
$outDir = Join-Path $BinariesDirectory $projName
$langversion = "Default"


Log-Section "Creating Output Folders . . ."

if (!(Test-Path -Path $LibrariesDirectory)){
    New-Item $LibrariesDirectory -ItemType Directory
}
if (!(Test-Path -Path $IntermediatesDirectory)){
    New-Item $IntermediatesDirectory -ItemType Directory
}
if (!(Test-Path -Path $BinariesDirectory)){
    New-Item $BinariesDirectory -ItemType Directory
}

#Log-Section "Removing Backup directory that is checked into SCM"
#Remove-Item C:\opt\dfinstaller\Source\Backup -recurse

Log-Section "Packaging Projects . . ."
foreach($projectToBePackaged in $projectsToBePackaged){
    
    $projectPath = Get-ChildItem -Path ($SourcesDirectory + "\*") -Include ($projectToBePackaged + ".csproj") -Recurse

    #Log-SubSection "Patching Project Type GUID '$projectToBePackaged'...."
    
    #(Get-Content $projectPath).Replace($projectTypeIdTobeReplaced,$projectTypeIdTobeReplacedWith) | Set-Content $projectPath

    Log-SubSection "Packaging '$projectToBePackaged'..."
	Log-SubSection "projectPath: '$projectPath'...."
    
   & $MSBuildExec $projectPath `
   /t:Package `
   /p:OutputPath="$BinariesDirectory" `
   /p:PreBuildEvent= `
   /p:PostBuildEvent= `
   /p:WarningLevel=0 `
   /p:Configuration="$ConfigurationToBuild" `
   /p:Platform="$PlatformToBuild" `
    /p:langversion="$langversion" `
   /p:GenerateSerializationAssemblies="Off" `
   /p:ReferencePath="C:\Program Files (x86)\Microsoft SDKs\Project 2013\REDIST" `
    /fl /flp:"$loggerArgs" `
    /m:4 `
    $ToolsVersion `
	$DfMsBuildArgs `
 	$MsBuildArguments  
    if ($LastExitCode -ne 0) {
        throw "Project build failed with exit code: $LastExitCode."
    }
}

Log-Section "Building Windows Services Projects . . ."
foreach($projectToBeBuildAsEXE in $projectsToBeBuildAsEXE){
    
    $projectPath = Get-ChildItem -Path ($SourcesDirectory + "\*") -Include ($projectToBeBuildAsEXE + ".csproj") -Recurse

    Log-SubSection "Building '$projectToBeBuildAsEXE'..."
	Log-SubSection "projectPath: '$projectPath'...."
    
   & $MSBuildExec $projectPath `
   /t:build `
   /p:OutputPath="$BinariesDirectory" `
   /p:PreBuildEvent= `
   /p:PostBuildEvent= `
   /p:Configuration="$ConfigurationToBuild" `
   /p:Platform="x64" `
    /p:langversion="$langversion" `
   /p:GenerateSerializationAssemblies="Off" `
   /p:ReferencePath="C:\Program Files (x86)\Microsoft SDKs\Project 2013\REDIST" `
    /fl /flp:"$loggerArgs" `
    /m:4 `
    $ToolsVersion `
	$DfMsBuildArgs `
 	$MsBuildArguments  
    if ($LastExitCode -ne 0) {
        throw "Project build failed with exit code: $LastExitCode."
    }
}

Log-Section "Building DLL Services Projects . . ."
foreach($projectToBeBuildAsDLL in $projectsToBeBuildAsDLL){
    
    $projectPath = Get-ChildItem -Path ($SourcesDirectory + "\*") -Include ($projectToBeBuildAsDLL + ".csproj") -Recurse

    Log-SubSection "Building '$projectToBeBuildAsDLL'..."
	Log-SubSection "projectPath: '$projectPath'...."
    
   & $MSBuildExec $projectPath `
   /t:build `
   /p:OutputPath="$BinariesDirectory" `
   /p:PreBuildEvent= `
   /p:PostBuildEvent= `
   /p:Configuration="$ConfigurationToBuild" `
   /p:Platform="$PlatformToBuild" `
   /p:langversion="$langversion" `
   /p:GenerateSerializationAssemblies="Off" `
   /p:ReferencePath="C:\Program Files (x86)\Microsoft SDKs\Project 2013\REDIST" `
    /fl /flp:"$loggerArgs" `
    /m:4 `
    $ToolsVersion `
	$DfMsBuildArgs `
 	$MsBuildArguments  
    if ($LastExitCode -ne 0) {
        throw "Project build failed with exit code: $LastExitCode."
    }
}


Log-Section "Copying Files..."

Get-ChildItem -Path ($SourcesDirectory + "\*")  -Include "*.pdb"  -Recurse | Copy-Item -Destination $IntermediatesDirectory -Force
Get-ChildItem -Path ($SourcesDirectory + "\*")  -Include "*.dll"  -Recurse | Copy-Item -Destination $LibrariesDirectory -Force

# Extend the script to copy the Dll, wsp, .exe file to InstallShield build dependencies folder in order to run final installer
$ProductOutput = Join-Path $OutputDirectory "ProductOutput"

if (Test-Path $ProductOutput) {
	Remove-Item -Recurse -Force $ProductOutput
}
New-Item -ItemType directory -Force -Path $ProductOutput

#Copy the template file from EPM Live Solution to Output\Template folder which will then be picked up by InstallShield build definition
$TemplateFolder = Join-Path $ProductOutput "Template"

if (Test-Path $TemplateFolder) {
	Remove-Item -Recurse -Force $TemplateFolder
}
New-Item -ItemType directory -Force -Path $TemplateFolder
#Copy Template file
Get-ChildItem -Path ($SourcesDirectory + "\Template\*")  -Include "*.wsp"  -Recurse | Copy-Item -Destination $TemplateFolder -Force

#Move file over to ProductOut directory to be consumed by Installshield
Get-ChildItem -Path ($BinariesDirectory + "\*")  -Include "*.wsp"  | Copy-Item -Destination $ProductOutput -Force 
#Rename EPMLive*.wsp -> WorkEngine*.wsp
Get-ChildItem -Path ($ProductOutput + "\*")  -Include "*.wsp" | Get-ChildItem -Filter “*EPMLive*” | Rename-Item -NewName {$_.name -replace ‘EPMLive’,’WorkEngine’ }
#Rename WorkEnginePPM.wsp -> WorkEnginePfE.wsp
Get-ChildItem -Path ($ProductOutput + "\*")  -Include "WorkEnginePPM.wsp" | Rename-Item -NewName {$_.name -replace ‘WorkEnginePPM’,’WorkEnginePfE’ }
Get-ChildItem -Path ($BinariesDirectory + "\*")  -Include "PortfolioEngineCore.dll"  -Recurse | Copy-Item -Destination $ProductOutput -Force
Get-ChildItem -Path ($LibrariesDirectory + "\*")  -Include "UplandIntegrations.dll"  -Recurse | Copy-Item -Destination $ProductOutput -Force

#Copy EPMLiveTimerService to output folder and Rename EPMLiveTimerService.exe -> TimerService.exe
Get-ChildItem -Path ($BinariesDirectory + "\*")  -Include "EPMLiveTimerService.exe" | Copy-Item -Destination $ProductOutput -Force  
Get-ChildItem -Path ($ProductOutput + "\*")  -Include "EPMLiveTimerService.exe" | Rename-Item -NewName {$_.name -replace ‘EPMLiveTimerService’,’TimerService’ }


Log-Section "Zipping"
Rename-Item -Path "$BinariesDirectory\_PublishedWebsites\EPMLiveIntegrationService" -NewName "api"
ZipFiles "$SourcesDirectory\InstallShield\Build Dependencies\api.zip"  "$BinariesDirectory\_PublishedWebsites\api"

Log-Section "Install Shield"

$BuildDependenciesFolder = Join-Path $SourcesDirectory "InstallShield\Build Dependencies"

Copy-Item $LibrariesDirectory\RestSharp.dll $BuildDependenciesFolder -Force  
Copy-Item $LibrariesDirectory\Newtonsoft.Json.dll $BuildDependenciesFolder -Force  
Copy-Item $SourcesDirectory\packages\DocumentFormat.OpenXml.2.5\lib\DocumentFormat.OpenXml.dll $BuildDependenciesFolder -Force  
Copy-Item $BinariesDirectory\WE_QueueMgr.exe $BuildDependenciesFolder\ServerFiles -Force  
Copy-Item $BinariesDirectory\WE_QueueMgr.exe $BuildDependenciesFolder -Force  
Copy-Item $BinariesDirectory\UserNameChecker.dll $BuildDependenciesFolder -Force  
Copy-Item $BinariesDirectory\EPMLiveIntegration.dll $BuildDependenciesFolder -Force

exit
#Run Installshield project to generate product .exe
& "C:\Program Files (x86)\InstallShield\2015\System\IsCmdBld.exe" -p "$SourcesDirectory\InstallShield\WorkEngine5\WorkEngine5.ism" -y $NewReleaseNumber -a "Product Configuration 1" -r "PrimaryRelease" -l PATH_TO_BUILDDDEPENDENC_FILES="$BuildDependenciesFolder" -l PATH_TO_PRODUCTOUTPUT_FILES="$ProductOutput"
Rename-Item -Path "$SourcesDirectory\InstallShield\WorkEngine5\Product Configuration 1\PrimaryRelease\DiskImages\DISK1\Setup.exe" -NewName "WorkEngine$NewReleaseNumber.exe"
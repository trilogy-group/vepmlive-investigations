# Build script for EPMLive

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
    #Skip InstallShield
	[switch]$SkipInstallShield
);
function exec
{
    param
    (
        [ScriptBlock] $ScriptBlock,
        [string] $StderrPrefix = "",
        [int[]] $AllowedExitCodes = @(0)
    )
 
    $backupErrorActionPreference = $script:ErrorActionPreference
 
    $script:ErrorActionPreference = "Continue"
    try
    {
        & $ScriptBlock 2>&1 | ForEach-Object -Process `
            {
                if ($_ -is [System.Management.Automation.ErrorRecord])
                {
                    "$StderrPrefix$_"
                }
                else
                {
                    "$_"
                }
            }
        if ($AllowedExitCodes -notcontains $LASTEXITCODE)
        {
            throw "Execution failed with exit code $LASTEXITCODE"
        }
    }
    finally
    {
        $script:ErrorActionPreference = $backupErrorActionPreference
    }
}

$projectsToBePackaged = @(
							"EPMLiveCore","EPMLiveDashboards","EPMLiveIntegrationService",
                            "EPMLivePS","EPMLiveReporting","EPMLiveSynch",
                            "EPMLiveTimeSheets","EPMLiveWebParts","EPMLiveWorkPlanner",
							"WorkEnginePPM",
                            "AdminSite","BillingSite",
							"EPMLiveTimerJobs"
							
                            )

$projectsToBeBuildAsEXE = @(
                            "EPMLiveTimerService", "EPK_QueueMgr", "EPMLive.SSRSConfigInjector"
                            )

$projectsToBeBuildAsDLL = @(
                            "PortfolioEngineCore","UplandIntegrations",
                            "EPMLiveIntegration", "UserNameChecker", "EPMLive.SSRSCustomAuthentication"
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

function ZipFiles2( $zipfilename, $sourcedir )
{
   Log-SubSection "Zipping $sourcedir to $zipfilename"
   
   If(Test-path $zipfilename) {Remove-item $zipfilename}
   $compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
   Add-Type -Assembly System.IO.Compression.FileSystem
   [System.IO.Compression.ZipFile]::CreateFromDirectory($sourcedir,  $zipfilename, $compressionLevel,  $false)
}

# additional parameters to msbuild
if (Test-Path env:\DF_MSBUILD_BUILD_STATS_OPTS) {
	$DfMsBuildArgs = Get-Childitem env:DF_MSBUILD_BUILD_STATS_OPTS | % { $_.Value }
}


$MSBuildExec = "c:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
$VSExec = "c:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.com"
$signtool = "C:\Program Files (x86)\Microsoft SDKs\ClickOnce\SignTool\signtool.exe"
$sdkPath = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.2 Tools"
#$BuildDirectory = "$ScriptDir\..\..\"

$NewReleaseNumber = "6.0.0.0"
# additional parameters to msbuild
if (Test-Path env:\build_number) {
	$NewReleaseNumber = $env:build_number
}


# Directory for outputs
$OutputDirectory = Join-Path $SourcesDirectory "output"
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
$LogsDirectory = "$SourcesDirectory\logs"
if (!(Test-Path -Path $LogsDirectory )){
    New-Item $LogsDirectory -type Directory
}

$projAbsPath = Join-Path $SourcesDirectory "EPMLive.sln"
$projDir = Split-Path $projAbsPath -parent
$projName = [System.IO.Path]::GetFileNameWithoutExtension($projAbsPath) 


#Log-Section "Downloading Nuget . . ."
$nugetPath = $SourcesDirectory + "\.nuget\nuget.exe"
#& $nugetPath update -self
Invoke-WebRequest -Uri http://nuget.org/nuget.exe -OutFile $nugetPath

Log-Section "Restoring missing packages . . ."
& $nugetPath restore "$SourcesDirectory"
& $nugetPath restore "$SourcesDirectory\Saas\EPMLive.Saas"
& $nugetPath restore "$SourcesDirectory\Saas\EPMLiveAccountManagement"
& $nugetPath restore "$SourcesDirectory\ProjectPublisher2016"
& $nugetPath restore "$SourcesDirectory\EPMLiveCore"

$loggerArgs = "LogFile=$LogsDirectory\${projName}.log;Verbosity=normal;Encoding=Unicode"
$outDir = Join-Path $BinariesDirectory $projName
$langversion = "Default"
$referencePath = "C:\Program Files\Reference Assemblies\Microsoft\VSTO40\v4.0.Framework; C:\Program Files (x86)\Microsoft SDKs\Project 2013\REDIST; C:\Program Files (x86)\Microsoft Visual Studio 14.0\Visual Studio Tools for Office\PIA\Office15; C:\Program Files (x86)\Microsoft Visual Studio 14.0\Visual Studio Tools for Office\PIA\Common"
$referencePath = $referencePath -replace "\s","%20" 
$referencePath = $referencePath -replace ";","%3B"


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
   /p:ReferencePath=$referencePath `
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
   /p:ReferencePath=$referencePath `
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
   /p:ReferencePath=$referencePath `
    /fl /flp:"$loggerArgs" `
    /m:4 `
    $ToolsVersion `
	$DfMsBuildArgs `
 	$MsBuildArguments  
    if ($LastExitCode -ne 0) {
        throw "Project build failed with exit code: $LastExitCode."
    }
}

Log-Section "Building WiX Projects . . ."

$platforms = @("x64", "x86")

$wixProject = "ProjectPublisher2016.sln"
$platformIndex = 0;
foreach ($platform in $platforms)
{
	$projectPath = Get-ChildItem -Path ($SourcesDirectory + "\*") -Include ("$wixProject") -Recurse
		
	Log-SubSection "projectPath: '$projectPath'...."
	
	Log-SubSection "Building $wixProject Release|$platform..."
	
   & $MSBuildExec $projectPath `
   /t:build `
   /p:Configuration="Release" `
   /p:Platform="$platform" `
   /p:langversion="$langversion" `
   /p:ReferencePath=$referencePath `
	/fl /flp:"$loggerArgs" `
	/m:4 `
	$ToolsVersion `
	$DfMsBuildArgs `
	$MsBuildArguments  
	if ($LastExitCode -ne 0) {
		throw "Project build failed with exit code: $LastExitCode."
	}
		

	Try
	{
		
		
			exec {&$signtool sign /n "EPM Live, Inc." `
				"$SourcesDirectory\ProjectPublisher2016\PublisherSetup2016WiX\bin\$platform\Release\PublisherSetup2016.msi"}
			
			exec {&$signtool timestamp /t http://timestamp.digicert.com `
				"$SourcesDirectory\ProjectPublisher2016\PublisherSetup2016WiX\bin\$platform\Release\PublisherSetup2016.msi"}
			
		
			exec {&$signtool sign /n "EPM Live, Inc." `
				"$SourcesDirectory\ProjectPublisher2016\PublisherSetupBootstrapper\bin\$platformP\Release\ProjectPublisher2016.exe"}
			
			exec {&$signtool timestamp /t http://timestamp.digicert.com `
				"$SourcesDirectory\ProjectPublisher2016\PublisherSetupBootstrapper\bin\$platform\Release\ProjectPublisher2016.exe"}
		
		
	}
	Catch
	{
		$ErrorMessage = $_.Exception.Message
		Write-Warning "Failed to sign $wixProject ($platform): $ErrorMessage" -WarningAction SilentlyContinue
	}
	
	Move-Item "$SourcesDirectory\ProjectPublisher2016\PublisherSetup2016WiX\bin\$platform\Release\PublisherSetup2016.msi" -Destination "$SourcesDirectory\ProjectPublisher2016\PublisherSetupBootstrapper\bin$platformPath\Release\PublisherSetup2016$platform.msi" -Force
	Move-Item "$SourcesDirectory\ProjectPublisher2016\PublisherSetupBootstrapper\bin\$platform\Release\ProjectPublisher2016.exe" -Destination "$SourcesDirectory\ProjectPublisher2016\PublisherSetupBootstrapper\bin$platformPath\Release\setup.exe" -Force
	

	$platformIndex++;

}



Log-Section "Copying Files..."

#Get-ChildItem -Path ($SourcesDirectory + "\*")  -Include "*.pdb"  -Recurse | Copy-Item -Destination $IntermediatesDirectory -Force
Get-ChildItem -Path ($BinariesDirectory + "\*")  -Include "UplandIntegrations.dll"  -Recurse | Copy-Item -Destination $LibrariesDirectory -Force
Get-ChildItem -Path ($SourcesDirectory + "\Libraries\*")  -Include "RestSharp.dll"  -Recurse | Copy-Item -Destination $LibrariesDirectory -Force
Get-ChildItem -Path ($SourcesDirectory + "\packages\Newtonsoft.Json.6.0.8\lib\net45\*")  -Include "Newtonsoft.Json.dll"  -Recurse | Copy-Item -Destination $LibrariesDirectory -Force

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
Get-ChildItem -Path ($BinariesDirectory + "\*")  -Include "EPMLiveTimerService.exe.config" | Copy-Item -Destination $ProductOutput -Force  
Get-ChildItem -Path ($ProductOutput + "\*")  -Include "EPMLiveTimerService.exe.config" | Rename-Item -NewName {$_.name -replace ‘EPMLiveTimerService’,’TimerService’ }


Log-Section "Zipping"
if (Test-Path "$BinariesDirectory\_PublishedWebsites\api") {
	Remove-Item -Recurse -Force "$BinariesDirectory\_PublishedWebsites\api"
}
Rename-Item -Path "$BinariesDirectory\_PublishedWebsites\EPMLiveIntegrationService" -NewName "api"
ZipFiles "$SourcesDirectory\InstallShield\Build Dependencies\api.zip"  "$BinariesDirectory\_PublishedWebsites\api"
ZipFiles2 "$SourcesDirectory\InstallShield\Build Dependencies\PublisherSetup2016x64_$NewReleaseNumber.zip"  "$SourcesDirectory\ProjectPublisher2016\PublisherSetupBootstrapper\bin\x64\Release\"
ZipFiles2 "$SourcesDirectory\InstallShield\Build Dependencies\PublisherSetup2016x86_$NewReleaseNumber.zip"  "$SourcesDirectory\ProjectPublisher2016\PublisherSetupBootstrapper\bin\Release\"

Log-Section "Install Shield"

$BuildDependenciesFolder = Join-Path $SourcesDirectory "InstallShield\Build Dependencies"

Copy-Item $LibrariesDirectory\RestSharp.dll $BuildDependenciesFolder -Force  
Copy-Item $LibrariesDirectory\Newtonsoft.Json.dll $BuildDependenciesFolder -Force  
Copy-Item $SourcesDirectory\packages\DocumentFormat.OpenXml.2.5\lib\DocumentFormat.OpenXml.dll $BuildDependenciesFolder -Force  
Copy-Item $BinariesDirectory\WE_QueueMgr.exe $BuildDependenciesFolder\ServerFiles -Force  
Copy-Item $BinariesDirectory\WE_QueueMgr.exe $BuildDependenciesFolder -Force  
Copy-Item $BinariesDirectory\UserNameChecker.dll $BuildDependenciesFolder -Force  
Copy-Item $BinariesDirectory\EPMLiveIntegration.dll $BuildDependenciesFolder -Force

New-Item $BuildDependenciesFolder\PS -type directory -Force
Copy-Item $SourcesDirectory\EPMLiveCore\EPMLiveCore\Resources\*.sql $BuildDependenciesFolder\PS -Force  

if (!$SkipInstallShield)
{
#Run Installshield project to generate product .exe
& "C:\Program Files (x86)\InstallShield\2015\System\IsCmdBld.exe" -p "$SourcesDirectory\InstallShield\WorkEngine5\WorkEngine5.ism" -y $NewReleaseNumber -a "Product Configuration 1" -r "PrimaryRelease" -l PATH_TO_BUILDDDEPENDENC_FILES="$BuildDependenciesFolder" -l PATH_TO_PRODUCTOUTPUT_FILES="$ProductOutput"
Rename-Item -Path "$SourcesDirectory\InstallShield\WorkEngine5\Product Configuration 1\PrimaryRelease\DiskImages\DISK1\Setup.exe" -NewName "WorkEngine$NewReleaseNumber.exe"
}

Stop-Process -Name MSBuild -Force -ErrorAction SilentlyContinue  


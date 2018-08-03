# Build script for EPMLive

# ### Define user adjustable parameters

param ( 
    # MSBuild - which configuration to build
    [string]$ConfigurationToBuild = "Debug",
    # MSBuild - for which platform to make builds
    [string]$PlatformToBuild = "Any CPU",
    # Tools Version to pass to MSBuild
    [string]$ToolsVersion = "/tv:14.0",
    # user-specific additional command line parameters to pass to MSBuild
    [string]$MsBuildArguments = "/p:visualstudioversion=14.0",
    # should build cleanup be performed before making build
    [string]$CleanBuild = $true,
	  # build test projects only
	  [switch]$TestsOnly
);

$projectsToBePackaged = @("EPMLiveCore", "EPMLiveDashboards","EPMLiveIntegrationService",
                            "EPMLivePS","EPMLiveReporting","EPMLiveSynch",
                            "EPMLiveTimeSheets","EPMLiveWebParts","EPMLiveWorkPlanner","WorkEnginePPM", "AdminSite", "BillingSite" )
 
$projectsToBeBuildAsEXE = @("EPMLiveTimerService", "EPK_QueueMgr", "EPMLive.SSRSConfigInjector")
$projectsToBeBuildAsDLL = @("PortfolioEngineCore","UplandIntegrations","EPMLiveIntegration", "UserNameChecker", "EPMLive.SSRSCustomAuthentication")

$projectTypeIdTobeReplaced = "C1CDDADD-2546-481F-9697-4EA41081F2FC"
$projectTypeIdTobeReplacedWith = "BB1F664B-9266-4fd6-B973-E1E44974B511"

# Define script directory
$ScriptDir = split-path -parent $MyInvocation.MyCommand.Definition

$env:EnableNuGetPackageRestore = "true"

# ### Includes 

# look-up of dependent libs
. $ScriptDir\RefsLocate.ps1


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


#$BuildDirectory = "$ScriptDir\..\..\"

# additional parameters to msbuild
if (Test-Path env:\DF_MSBUILD_BUILD_STATS_OPTS) {
	$DfMsBuildArgs = Get-Childitem env:DF_MSBUILD_BUILD_STATS_OPTS | % { $_.Value }
}
# msbuild executable location
# $MSBuildExec = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
$MSBuildExec = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
$sdkPath = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.2 Tools"
# VSTest executable
$VSTestExec = "C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
# Initialize Sources Directory
$SourcesDirectory = "$ScriptDir\..\"
# Initialize logs directory
$LogsDirectory = "$SourcesDirectory\logs"
if (!(Test-Path -Path $LogsDirectory )){
    New-Item $LogsDirectory -type Directory
}
$loggerArgs = "LogFile=$LogsDirectory\${projName}.log;Verbosity=normal;Encoding=Unicode"
$langversion = "Default"
$referencePath = "C:\Program Files\Reference Assemblies\Microsoft\VSTO40\v4.0.Framework; C:\Program Files (x86)\Microsoft SDKs\Project 2013\REDIST; C:\Program Files (x86)\Microsoft Visual Studio 14.0\Visual Studio Tools for Office\PIA\Office15; C:\Program Files (x86)\Microsoft Visual Studio 14.0\Visual Studio Tools for Office\PIA\Common"
$referencePath = $referencePath -replace "\s","%20" 
$referencePath = $referencePath -replace ";","%3B"

$projAbsPath = Join-Path $SourcesDirectory "EPMLive.sln"
$projPublisherAbsPath = Join-Path $SourcesDirectory "\ProjectPublisher2016\ProjectPublisher2016.sln"
$projSSRSPath = Join-Path $SourcesDirectory "\EPMLiveNativeSSRSComponents\EPMLiveNativeSSRSComponents.sln"
$projAUTPath = Join-Path $SourcesDirectory "EPMLive.AUT.Tests.sln"

$projDir = Split-Path $projAbsPath -parent
$projName = [System.IO.Path]::GetFileNameWithoutExtension($projAbsPath) 
$OutputDirectory = Join-Path $SourcesDirectory "output"
$BinariesDirectory = Join-Path $OutputDirectory "binaries"
$LibrariesDirectory = "$OutputDirectory\libraries"
$IntermediatesDirectory = "$OutputDirectory\intermediate"

### Build preparation steps

Log-Section "Build configuration"
Log-Message "`t Configuration: '$ConfigurationToBuild'"
Log-Message "`t Platform: '$PlatformToBuild'"
Log-Message "`t OutDir: '$BinariesDirectory'"
Log-Message "`t DF MSBuild arguments: '$DfMsBuildArgs'"
Log-Message "`t Additional MSBuild arguments: '$MsBuildArguments'"
Log-Message ""

#  clean previous build outputs
If ($CleanBuild -eq $true) {
	Log-Section "Cleaning build outputs..."
	
	if (Test-Path $OutputDirectory) {
	    Remove-Item -Recurse -Force $OutputDirectory
	}
	New-Item -ItemType directory -Force -Path $OutputDirectory

	# Run MSBuild
	 
    
	Log-SubSection "Cleaning '$projName'..."
	    
	& $MSBuildExec "$projAbsPath"  `
	    /t:Clean `
	    /p:SkipInvalidConfigurations=true `
	    /p:Configuration="$ConfigurationToBuild" `
	    /p:Platform="$PlatformToBuild" `
        /m:4 `
        /p:WarningLevel=0 `
        $ToolsVersion `
	    $DfMsBuildArgs `
	    $MsBuildArguments
	if ($LastExitCode -ne 0) {
		throw "Project clean-up failed with exit code: $LastExitCode."
	}

    Log-SubSection "Cleaning Project Publisher"
	    
	& $MSBuildExec "$projPublisherAbsPath"  `
	    /t:Clean `
	    /p:SkipInvalidConfigurations=true `
	    /p:Configuration="$ConfigurationToBuild" `
	    /p:Platform="$PlatformToBuild" `
        /m:4 `
        /p:WarningLevel=0 `
        $ToolsVersion `
	    $DfMsBuildArgs `
	    $MsBuildArguments
	if ($LastExitCode -ne 0) {
		throw "Project clean-up failed with exit code: $LastExitCode."
	}
		
	Log-SubSection "Cleaning SSRS Injector"
	    
	& $MSBuildExec "$projSSRSPath"  `
	    /t:Clean `
	    /p:SkipInvalidConfigurations=true `
	    /p:Configuration="$ConfigurationToBuild" `
	    /p:Platform="$PlatformToBuild" `
        /m:4 `
        /p:WarningLevel=0 `
        $ToolsVersion `
	    $DfMsBuildArgs `
	    $MsBuildArguments
	if ($LastExitCode -ne 0) {
		throw "Project clean-up failed with exit code: $LastExitCode."
	}
	
	Log-SubSection "Cleaning AUT"
	    
	& $MSBuildExec "$projAUTPath"  `
	    /t:Clean `
	    /p:SkipInvalidConfigurations=true `
	    /p:Configuration="$ConfigurationToBuild" `
	    /p:Platform="$PlatformToBuild" `
        /m:4 `
        /p:WarningLevel=0 `
        $ToolsVersion `
	    $DfMsBuildArgs `
	    $MsBuildArguments
	if ($LastExitCode -ne 0) {
		throw "Project clean-up failed with exit code: $LastExitCode."
	}
}

Log-Section "Downloading Nuget . . ."

$nugetPath = $SourcesDirectory + "\nuget.exe"
$NUVersion = '3.5.0'
Invoke-WebRequest "https://dist.nuget.org/win-x86-commandline/v$NUVersion/nuget.exe" -OutFile $nugetPath

Log-Section "Restoring missing packages . . ."
& $nugetPath `
restore `
$projAbsPath

& $nugetPath `
restore `
$projAUTPath

if ($TestsOnly)
{
	$projectsToBeBuildAsDLL = @("EPMLiveCore.Tests","EPMLiveReporting.Tests","EPMLiveTimerService.Tests", "EPMLiveTimesheets.Tests", "EPMLiveWebParts.Tests", "EPMLiveWorkPlanner.Tests", "PortfolioEngineCore.Tests", "WorkEnginePPM.Tests", "ProjectPublisher2016.Tests", "EPMLiveCore.AUT.Tests",
	"EPMLiveSynch.Tests")

	# Directory for outputs
	$OutputDirectory = Join-Path $SourcesDirectory "Test-Output"
	if (!(Test-Path -Path $OutputDirectory)){
		New-Item $OutputDirectory -ItemType Directory
	}
	foreach($projectToBeBuildAsDLL in $projectsToBeBuildAsDLL){
    
    $projectPath = Get-ChildItem -Path ($SourcesDirectory + "\*") -Include ($projectToBeBuildAsDLL + ".csproj") -Recurse


    Log-SubSection "Building '$projectToBeBuildAsDLL'..."
	Log-SubSection "projectPath: '$projectPath'...."
	
	& $MSBuildExec $projectPath `
	/t:Build `
	/p:OutputPath="$OutputDirectory" `
    /p:PreBuildEvent= `
    /p:PostBuildEvent= `
    /p:Configuration="Debug" `
    /p:Platform="$PlatformToBuild" `
	/p:langversion="$langversion" `
    /p:WarningLevel=0 `
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
}
else
{



# ### Make build the same way SolutionPackager does

Log-Section "Starting build..."




$outDir = Join-Path $BinariesDirectory $projName

Log-SubSection "Building '$projName'..."
    
# Run MSBuild
& $MSBuildExec $projAbsPath `
    /p:PreBuildEvent= `
    /p:PostBuildEvent= `
    /p:Configuration="$ConfigurationToBuild" `
    /p:Platform="$PlatformToBuild" `
	/p:langversion="$langversion" `
    /p:WarningLevel=0 `
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

Log-SubSection "Building Project Publisher"
$sGenToolPath = "$sdkPath\"

if ($PlatformToBuild -eq "x64")
{
	$sGenToolPath = "$sdkPath\x64\"
}
Write-Host "SGEN: $sGenToolPath"
$sGenToolPath = $sGenToolPath -replace "\s","%20" 

# Run MSBuild
& $MSBuildExec $projPublisherAbsPath `
    /p:PreBuildEvent= `
    /p:PostBuildEvent= `
    /p:Configuration="$ConfigurationToBuild" `
    /p:Platform="$PlatformToBuild" `
	/p:langversion="$langversion" `
    /p:WarningLevel=0 `
    /p:ReferencePath=$referencePath `
	/p:SGenToolPath="$sGenToolPath" `
    /fl /flp:"$loggerArgs" `
    /m:4 `
    $ToolsVersion `
	$DfMsBuildArgs `
	$MsBuildArguments  
if ($LastExitCode -ne 0) {
    throw "Project build failed with exit code: $LastExitCode."
}


Log-SubSection "Building SSRS Injector"
    
# Run MSBuild
& $MSBuildExec $projSSRSPath `
    /p:PreBuildEvent= `
    /p:PostBuildEvent= `
    /p:Configuration="$ConfigurationToBuild" `
    /p:Platform="$PlatformToBuild" `
	/p:langversion="$langversion" `
    /p:WarningLevel=0 `
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


Log-SubSection "Building AUT"
    
# Run MSBuild
& $MSBuildExec $projAUTPath `
    /p:PreBuildEvent= `
    /p:PostBuildEvent= `
    /p:Configuration="$ConfigurationToBuild" `
    /p:Platform="$PlatformToBuild" `
	/p:langversion="$langversion" `
    /p:WarningLevel=0 `
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


Stop-Process -Name MSBuild -Force -ErrorAction SilentlyContinue  


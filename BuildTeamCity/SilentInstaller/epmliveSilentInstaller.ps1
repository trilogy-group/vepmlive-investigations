
Param(  
    [string] $webAppName = ("http://" + $env:COMPUTERNAME),
    #[string] $webAppName = "http://qaepmlive6",
    [string] $dbService = "epmDB.epmldev.com",
    [string] $dbName = "epmlive",
    [string] $appPool = "SharePoint - qaepmlive680",
	[string] $comUserName = "epmldev\farmadmin",
    [string] $inPassword = "Pass@word1",
	[string] $version = "6.1.0.0",
	[string] $upgradeSitesFile = "",
	[string] $upgradeSite = "",
	[switch] $deploySolutions,
	[switch] $deployTimer,
	[switch] $deployPFE,
	[switch] $createDB,
	[switch] $upgradeSites
	
	
)
$config = Get-Content "config.json" | Out-String | ConvertFrom-Json
. ".\routines.ps1"
$ScriptDir = split-path -parent $MyInvocation.MyCommand.Definition

if (!(Test-ADCredential $comUserName $inPassword))
{
    Write-Host "Wrong credentials"
    return
}

#### STOP SERVICES ####
foreach ($component in $config.Components | Where-Object {$_.installAsService -ne $null})
{
	if (Get-Service -Name $component.installAsService.name -ErrorAction SilentlyContinue)
	{
		Write-Host ("Stop service:" + $component.installAsService.name)
		Set-Service -Name $component.installAsService.name -StartupType Disabled
		Stop-Service -Name $component.installAsService.name
		
		WaitUntilServices $component.installAsService.name "Stopped"
		Write-Host("Killing " + $component.installAsService.processname)
		Stop-Process -processname $component.installAsService.processname -ErrorAction SilentlyContinue -Force -Confirm:$false
	}
	else
	{
		Write-Host ("Service " + $component.installAsService.name + " not found, skipping stop")
	}
}

## UNREGISTER COM
foreach ($component in $config.Components | Where-Object {($_.registerCOMplus -ne $null) -or ($_.registerCOM -ne $null)})
{
    $folderName = Join-Path $ScriptDir "Files" | Join-Path -ChildPath $component.name
	$destination = ClarifyPath $component.destination
    foreach ($file in $component.files)
    {
		if (![string]::IsNullOrEmpty($component.registerCOM) )
		{
			unregister-File (Join-Path $destination $file)
		}

		if (![string]::IsNullOrEmpty($component.registerCOMplus))
		{
			Unregister-COMPlus $component.registerCOMplus.Name
		}
	}
}
	
#### COPY FILES #####


[System.Reflection.Assembly]::Load("System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a") | Out-Null


foreach ($component in $config.Components)
{
    $folderName = Join-Path $ScriptDir "Files" | Join-Path -ChildPath $component.name
	
	if ($component.destination.Equals("GAC"))
	{
		foreach ($file in $component.files)
		{
			$fullName = Join-Path $folderName $file
			Write-Host ("Add to GAC: $fullName")
			$publish = New-Object System.EnterpriseServices.Internal.Publish            
			$publish.GacInstall($fullName)
		}
		
		continue;
	}
	
    $destination = ClarifyPath $component.destination
    
    #Write-Host "Destination $destination"
	if(!(Test-Path -Path $destination )){
		Write-Host ("Create folder $destination")
		New-Item $destination -type directory -Force
	}
    foreach ($file in $component.files)
    {
		
        $fullName = Join-Path $folderName $file
        Write-Host ("Copying file $file")
		Copy-Item $fullName $destination -Force 

        if (![string]::IsNullOrEmpty($component.unzip))
        {
			Write-Host ("Unzip file $file") 
            $outDir = ClarifyPath $component.unzip
            Unzip $fullName $outDir  
        }
	
		if (![string]::IsNullOrEmpty($component.registerCOM))
		{
			Register-File (Join-Path $destination $file)
		}

		if (![string]::IsNullOrEmpty($component.registerCOMplus))
		{
			Register-COMPlus (Join-Path $destination $file) $component.registerCOMplus.ID $component.registerCOMplus.Name $comUserName $inPassword
		}
		
		
    }
}
 
#### Install WSP ####
if ($deploySolutions)
{
    RestartSPTimerV4

    foreach ($component in $config.Components)
    {
        $folderName = Join-Path $ScriptDir "Files" | Join-Path -ChildPath $component.name
        
        if (![string]::IsNullOrEmpty($component.deployWSP))
        {
            if ($component.deployWSP.Equals("web"))
            {
                foreach ($file in $component.files)
                {
                    
                    Write-Host "Remove WSP: $file"
                    RemoveWSP $file -webAppName $webAppName
                }
            }

            if ($component.deployWSP.Equals("farm"))
            {
                foreach ($file in $component.files)
                {
                    
                    Write-Host "Remove WSP: $file"
                    RemoveWSP $file 
                }
            }
        }
    }

    RestartSPTimerV4

	
    start-sleep -s 60

    foreach ($component in $config.Components)
    {
        $folderName = Join-Path $ScriptDir "Files" | Join-Path -ChildPath $component.name
    
        if (![string]::IsNullOrEmpty($component.deployWSP))
        {
            if ($component.deployWSP.Equals("web"))
            {
                foreach ($file in $component.files)
                {
                    $fullName = Join-Path $folderName $file
                    Write-Host "Deploy WSP: $fullName"
                    DeployWSP $file $fullName $webAppName
                }
            }

            if ($component.deployWSP.Equals("farm"))
            {
                foreach ($file in $component.files)
                {
                    $fullName = Join-Path $folderName $file
                    Write-Host "Deploy WSP: $fullName"
                    DeployWSP $file $fullName
                }
            }
        }
    }

    RestartSPTimerV4
	Write-Host 'Upgrading DB'
	$dbUpgrader = Join-Path $ScriptDir 'DBUpgrader\EPMLiveDBUpgrader.exe'
	& $dbUpgrader -W $webAppName
	if ($LastExitCode -ne 0) {
		throw "DB upgrader failed with exit code: $LastExitCode."
	}
	
	
	
}
 
#### Create Database ####
if($createDB)
{
    Import-Module WebAdministration
    $webApp = (Get-ChildItem -Path IIS:\AppPools\ | Where-Object {$_.name -eq $appPool});
    $username = $webApp.processModel.userName
    #Select-Object name, @{e={$_.processModel.password};l="password"}, @{e={$_.processModel.username};l="username"}, @{e={$_.processModel.identityType};l="identityType"}

    Invoke-Sqlcmd -Query ("CREATE DATABASE " + $dbName) -ServerInstance $dbService -Database "master"

    Invoke-Sqlcmd -Query ("create user [" + $username + "] from login [" + $username + "]") -ServerInstance $dbService -Database $dbName

    $query = "EXEC sp_addrolemember @rolename='db_owner', @membername='${username}'"

    Invoke-Sqlcmd -Query $query -ServerInstance $dbService -Database $dbName #-Variable "mname='${username}'"

    foreach ($component in $config.Components | Where-Object {$_.runSQL -eq "true"})
    {
        $folderName = Join-Path $ScriptDir "Files" | Join-Path -ChildPath $component.name
    
        foreach ($file in $component.files)
        {
            $fullName = $fullName = Join-Path $folderName $file
            Write-Host "Run SQL: $fullName"
            Invoke-Sqlcmd -InputFile $fullName -ServerInstance $dbService -Database $dbName 
        }
    }

    #string sError = "";
    $cn = "Server=" + $dbService + ";Database=" + $dbName + ";integrated security=true"
    $sError = ""

    $w = Get-SPWebApplication $webAppName

    [System.Reflection.Assembly]::Load("EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5") | Out-Null
    [EPMLiveCore.CoreFunctions]::setConnectionString($w.Id, $cn, [ref] $sError)
}

#### DEPLOY AND START SERVICES ####

foreach ($component in $config.Components | Where-Object {$_.installAsService -ne $null})
{
	if (($deployPFE -and $component.installAsService.key -eq "PFE" ) -or ($deployTimer -and $component.installAsService.key -eq "Timer" ))
	{
		foreach ($file in $component.files)
		{
			$destination = ClarifyPath $component.destination
			$destFileName =  Join-Path $destination $file
			Write-Host "Install as service: $destFileName"
			if (![string]::IsNullOrEmpty($component.installAsService.dependency))
			{
			Install-Service-With-Dependency `
				-serviceName $component.installAsService.name `
				-displayName $component.installAsService.displayname `
				-description $component.installAsService.description `
				-path $destFileName `
				-UserName $comUserName `
				-Password $inPassword `
				-Dependency $component.installAsService.dependency
			}
			else
			{
			Install-Service `
				-serviceName $component.installAsService.name `
				-displayName $component.installAsService.displayname `
				-description $component.installAsService.description `
				-path $destFileName `
				-UserName $comUserName `
				-Password $inPassword 
			}
		}
		if (Get-Service -Name $component.installAsService.name -ErrorAction SilentlyContinue)
		{
			Start-Service -Name $component.installAsService.name
			WaitUntilServices $component.installAsService.name "Running"
		}
	}
	
}

if ($deploySolutions -and $deployTimer)
{
	$siteUpgrader = Join-Path $ScriptDir 'SiteUpgrader\EPMLiveTimeJobSchedulerConsole.exe'
	if ([string]::IsNullOrWhiteSpace($upgradeSitesFile) -ne $true)
	{
		Write-Host "Upgrading Site(s) from $upgradeSitesFile"
		& $siteUpgrader -P $upgradeSitesFile 
		if ($LastExitCode -ne 0) {
			throw "Site upgrader failed with exit code: $LastExitCode."
		}
	}
	elseif ([string]::IsNullOrWhiteSpace($upgradeSite) -ne $true)
	{
		Write-Host "Upgrading Site $upgradeSite"
		& $siteUpgrader -S $upgradeSite 
		if ($LastExitCode -ne 0) {
			throw "Site upgrader failed with exit code: $LastExitCode."
		}
	}
	elseif ($upgradeSites)
	{
		Write-Host 'Upgrading Site(s) from SitesList.xml'
		$defaultSitesFile = Join-Path $ScriptDir 'SitesList.xml'
		& $siteUpgrader -P $defaultSitesFile 
		if ($LastExitCode -ne 0) {
			throw "Site upgrader failed with exit code: $LastExitCode."
		}
	}
}

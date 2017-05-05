Param(  
    #[string] $webAppName = ("http://" + $env:COMPUTERNAME)
    [string] $webAppName = "http://qaepmlive6",
    [string] $dbService = "epmDB.epmldev.com",
    [string] $dbName = "epmlive",
    [string] $appPool = "SharePoint - qaepmlive680",
    [string] $inUserName = "farmadmin@epmldev",
    [string] $inPassword = "Pass@word1"
)

. ".\routines.ps1"

if (!(Test-ADCredential $UserName $Password))
{
    Write-Host "Wrong credentials"
    return
}

#### STOP SERVICES ####
if ($true)
{
    foreach ($component in $config.Components | Where-Object {$_.installAsService -ne $null})
    {
        Write-Host ("Stop service:" + $component.installAsService.name)
        Stop-Service $component.installAsService.name
    }
}

#### COPY FILES #####

[System.Reflection.Assembly]::Load("System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a") | Out-Null

$config = Get-Content "config.json" | Out-String | ConvertFrom-Json
foreach ($component in $config.Components)
{
    $folderName = "Files\"+$component.name
    
    if ($component.destination.Equals("GAC"))
    {
        foreach ($file in $component.files)
        {
            $fullName = Resolve-Path ($folderName + "\" + $file) 
            Write-Host "Add to GAC: $fullName"
            $publish = New-Object System.EnterpriseServices.Internal.Publish            
            $publish.GacInstall($fullName)
        }
        continue
    }

    $destination = ClarifyPath $component.destination
    
    Write-Host $destination
    New-Item $destination -type directory -Force
    foreach ($file in $component.files)
    {
        $fullName = Resolve-Path ($folderName + "\" + $file) 
        Copy-Item $fullName $destination -Force

        if (![string]::IsNullOrEmpty($component.unzip))
        {
            $outDir = ClarifyPath $component.unzip
            Unzip $fullName $outDir
        }

        if (![string]::IsNullOrEmpty($component.registerCOM))
        {
            Register-File (Join-Path $destination $file)
        }

        if (![string]::IsNullOrEmpty($component.registerCOMplus))
        {
            Register-COMPlus (Join-Path $destination $file) $component.registerCOMplus.ID $component.registerCOMplus.Name $inUserName $inPassword
        }
    }
}

#### Install WSP ####
if ($false)
{
    RestartSPTimerV4

    foreach ($component in $config.Components)
    {
        $folderName = "Files\"+$component.name
    
        if (![string]::IsNullOrEmpty($component.deployWSP))
        {
            if ($component.deployWSP.Equals("web"))
            {
                foreach ($file in $component.files)
                {
                    $fullName = Resolve-Path ($folderName + "\" + $file) 
                    Write-Host "Remove WSP: $fullName"
                    RemoveWSP $file $fullName $webAppName
                }
            }

            if ($component.deployWSP.Equals("farm"))
            {
                foreach ($file in $component.files)
                {
                    $fullName = Resolve-Path ($folderName + "\" + $file) 
                    Write-Host "Remove WSP: $fullName"
                    RemoveWSP $file $fullName
                }
            }
        }
    }

    RestartSPTimerV4

    start-sleep -s 60

    foreach ($component in $config.Components)
    {
        $folderName = "Files\"+$component.name
    
        if (![string]::IsNullOrEmpty($component.deployWSP))
        {
            if ($component.deployWSP.Equals("web"))
            {
                foreach ($file in $component.files)
                {
                    $fullName = Resolve-Path ($folderName + "\" + $file) 
                    Write-Host "Deploy WSP: $fullName"
                    DeployWSP $file $fullName $webAppName
                }
            }

            if ($component.deployWSP.Equals("farm"))
            {
                foreach ($file in $component.files)
                {
                    $fullName = Resolve-Path ($folderName + "\" + $file) 
                    Write-Host "Deploy WSP: $fullName"
                    DeployWSP $file $fullName
                }
            }
        }
    }


    RestartSPTimerV4
}

#### Create Database ####
if($false)
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
        $folderName = "Files\"+$component.name
    
        foreach ($file in $component.files)
        {
            $fullName = Resolve-Path ($folderName + "\" + $file)
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

#### INSTALL SERVICES ####
if ($true)
{
    foreach ($component in $config.Components | Where-Object {$_.installAsService -ne $null})
    {
        foreach ($file in $component.files)
        {
            $destination = ClarifyPath $component.destination
            $destFileName =  Join-Path $destination $file
            Write-Host "Install as service: $destFileName"
            Install-Service `
                -serviceName $component.installAsService.name `
                -displayName $component.installAsService.displayname `
                -description $component.installAsService.description `
                -path $destFileName `
                -UserName $inUserName `
                -Password $inPassword
            #Invoke-Sqlcmd -InputFile $fullName -ServerInstance $dbService -Database $dbName 
        }
    }

}
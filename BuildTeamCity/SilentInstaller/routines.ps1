Add-PSSnapin "Microsoft.SharePoint.PowerShell"

function Unzip
{
    param([string]$zipfile, [string]$outpath)

    & .\7za.exe "x" "$zipfile" "-o$outpath" "-y"
}

function ClarifyPath
{
    param([string] $path)

    $newpath = $path.Replace("[ProgramFilesFolder]", ${env:programFiles(x86)} + "\")
    $newpath = $newpath.Replace("[ProgramFiles64Folder]", $env:programFiles + "\")
    $newpath = $newpath.Replace("[CommonFilesFolder]", ${env:CommonProgramFiles(x86)} + "\")
    $newpath = $newpath.Replace("[CommonFiles64Folder]", $env:CommonProgramFiles + "\")

    return $newpath
}

function WaitUntilServices($searchString, $status)
{
    # Get all services where DisplayName matches $searchString and loop through each of them.
    foreach($service in (Get-Service $searchString))
    {
        # Wait for the service to reach the $status or a maximum of 30 seconds
        $service.WaitForStatus($status, '00:00:30')
    }
}

function RestartSPTimerV4()
{
    Restart-Service SPTimerV4
    WaitUntilServices "SPTimerV4" "Running"

    Restart-Service SPAdminV4
    WaitUntilServices "SPAdminV4" "Running"
}


function RemoveWSP()
{
    param([string] $name, [string] $path, [string] $webAppName)
    
    $sln = get-spsolution -identity $name

    if ($sln)
    {
        if (![string]::IsNullOrEmpty($webAppName))
        {
            uninstall-spsolution -identity $name -confirm:$false -webapplication:$webAppName
        }
        else
        {
            uninstall-spsolution -identity $name -confirm:$false
        }    
 
        echo "Started solution retraction..."
 
        while($sln.JobExists)
        {
            echo " > Uninstall in progress..."
            start-sleep -s 5
        }
 
        remove-spsolution -identity $name -confirm:$false -Force
    }
}

function DeployWSP()
{
    param([string] $name, [string] $path, [string] $webAppName)
    
    $sln = add-spsolution $path -Confirm:$false
 
    if (![string]::IsNullOrEmpty($webAppName))
    {
        install-spsolution -identity $name -gacdeployment  -CompatibilityLevel 15 -WebApplication $webAppName -Force
    }
    else
    {
        install-spsolution -identity $name -gacdeployment  -CompatibilityLevel 15 -Force
    }
 
    while($sln.JobExists)
    {
        echo " > Deployment in progress..."
 
        start-sleep -s 5
    }
}

function Test-ADCredential {
    Param
    (
        [string]$UserName,
        [string]$Password
    )
    if (!($UserName) -or !($Password)) {
        Write-Warning 'Test-ADCredential: Please specify both user name and password'
    } else {
        Add-Type -AssemblyName System.DirectoryServices.AccountManagement
        $DS = New-Object System.DirectoryServices.AccountManagement.PrincipalContext('domain')
        $DS.ValidateCredentials($UserName, $Password)
    }
}

function Install-Service()
{
    Param
    (
        [string]$serviceName,
        [string]$displayName,
        [string]$description,
        [string]$path,
        [string]$UserName,
        [string]$Password
    )

    Write-Host "Delete service: $serviceName"
    (Get-WmiObject Win32_Service -filter "name='$serviceName'").Delete()

    $passwordSec = $Password | ConvertTo-SecureString -asPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential($UserName,$passwordSec)

    Write-Host "Install service: $serviceName"
    New-Service -Name $serviceName -DisplayName "$displayName" -Description "$description" -BinaryPathName "$path" -StartupType Automatic -Credential $credential -Confirm:$false
    Write-Host "Start service: $serviceName"
    Start-Service $serviceName
}

function Register-File 
{
	param (
		[ValidateScript({ Test-Path -Path $_ -PathType 'Leaf' })]
		[string]$FilePath
	)
	process {
		try {
			$Result = Start-Process -FilePath 'regsvr32.exe' -Args "/s $FilePath" -Wait -NoNewWindow -PassThru
		} catch {
			Write-Error $_.Exception.Message
			$false
		}
	}
}

function Register-COMPlus
{
	param (
		[ValidateScript({ Test-Path -Path $_ -PathType 'Leaf' })]
		[string]$FilePath,
        [string]$id,
        [string]$appName,
        [string]$UserName,
        [string]$Password
	)
    Write-Host "Install COM+ Application: $appName"
    $comAdmin = New-Object -com ("COMAdmin.COMAdminCatalog.1")
    $applications = $comAdmin.GetCollection("Applications") 
    $applications.Populate() 

    $app = $applications.add()
    $app.Value("ID") = $id
    $app.Value("Name") = $appName
    $app.Value("Activation") = 1
    $app.Value("ApplicationAccessChecksEnabled") = 0
    $app.Value("Description") = " "
    $app.Value("Identity") = $UserName
    $app.Value("Password") = $Password
    $app.Value("RunForever") = $True

    $applications.SaveChanges()

    $comAdmin.InstallComponent($appName, $FilePath, "", "")
    $comAdmin.StartApplication($appName)
}
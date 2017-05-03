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
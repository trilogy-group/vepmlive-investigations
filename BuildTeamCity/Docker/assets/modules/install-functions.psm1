Import-Module "$PSScriptRoot\download-functions.psm1"

function InstallSoftware {
    [CmdletBinding()]
    param(
        [string] $filePath,
        [string] $installArgs,
        [ValidateSet('Default', 'Exe', 'Msi')]
        [string] $installationType = 'Default'
    )
    $installerPath = $filePath
    #Detect installation type
    if ($installationType -eq 'Default') {
        $extension = [System.IO.Path]::GetExtension($filePath)
        if ($extension -eq '.msi') {
            $installationType = 'Msi'
        }
    }

    if ($installationType -eq 'Msi') {
        $installerPath = 'msiexec.exe'
        $installArgs = "/i `"$filePath`" " + $installArgs
    }

    $proc = Start-Process -FilePath $installerPath -ArgumentList $installArgs -Wait -PassThru
    if ($proc.ExitCode -ne 0) {
        Log "Installation completed with code $($proc.ExitCode). Arguments: $installArgs"
    }
}

function InstallFromWeb {   
    [CmdletBinding()]
    param(
        [string] $url,
        [string] $filePath,
        [string] $installArgs,
        [ValidateSet('WebClient', 'WebRequest', 'Bits', 'NewMethod')]
        [string] $downloadType = 'WebClient',
        [ValidateSet('Default', 'Exe', 'Msi')]
        [string] $installationType = 'Default'
    )
    DownloadFromWeb $url $filePath $downloadType
    $fileName = [System.IO.Path]::GetFileName($filePath)
    Log "Installing $fileName ..."
    InstallSoftware $filePath $installArgs $installationType
    Log "Removing $filePath ..."
    Remove-Item $filePath
}
function InstallFromS3 {   
    [CmdletBinding()]
    param(
        [string] $key, 
        [string] $filePath, 
        [string] $installArgs,
        [ValidateSet('Default', 'Exe', 'Msi')]
        [string] $installationType = 'Default',
        [string] $bucket = 'aurea-docker', 
        [string] $accessKey = $env:AWS_ACCESS_KEY_ID, 
        [string] $secretKey = $env:AWS_SECRET_ACCESS_KEY, 
        [string] $region = $env:AWS_DEFAULT_REGION
    )
    DownloadFromS3 $key $filePath $bucket $accessKey $secretKey $region
    $fileName = [System.IO.Path]::GetFileName($filePath)
    Log "Installing $fileName ..."
    InstallSoftware $filePath $installArgs $installationType
    Log "Removing $filePath ..."
    Remove-Item $filePath
}

Export-ModuleMember InstallSoftware, InstallFromWeb, InstallFromS3

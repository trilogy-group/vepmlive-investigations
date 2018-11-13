$ErrorActionPreference = "Stop"

$needToInstall = $true
$needToUninstall = $false
$requiredChromeVersion = "66.0.3359.170"

Write-Host "Checking if Google Chrome is already installed"
Write-Host "Required version is $requiredChromeVersion"
$chrome = Get-WmiObject -class Win32_Product -Filter "Name='Google Chrome'"
if ($chrome) {
    # Remove current version if it's not the required one
    $needToUninstall = $chrome.Version -ne $requiredChromeVersion
    $needToInstall = $needToUninstall
    Write-Host "Google Chrome of version $($chrome.Version) is installed"
}

if ($needToUninstall) {
    Write-Host "Uninstalling current version of Chrome"
    $chrome.Uninstall()
}

if ($needToInstall) {
    Write-Host "Installing Google Chrome $requiredChromeVersion"
    $ProgressPreference = "SilentlyContinue"
    Write-Host "Downloading installation package"
    Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Deployment+Packages/GoogleChrome/66.0.3359.170/googlechromestandaloneenterprise64.msi -OutFile googlechromestandaloneenterprise64.msi
    Write-Host "Installing"
    $setupProcess = Start-Process -PassThru -Wait -FilePath "googlechromestandaloneenterprise64.msi" -ArgumentList "/q"
    Remove-Item googlechromestandaloneenterprise64.msi
    if ($setupProcess.ExitCode -ne 0) { 
        throw "Google Chrome installation failed with code $($setupProcess.ExitCode)" 
    }

    Write-Host "Disabling Google Update"
    Set-Service gupdate -StartupType Disabled
    Set-Service gupdatem -StartupType Disabled
    Stop-Process -Name GoogleUpdate -Force -ErrorAction:SilentlyContinue
    $chromeUpdateFolder = "${env:ProgramFiles(x86)}\Google\Update"
    Rename-Item "$chromeUpdateFolder\GoogleUpdate.exe" "$chromeUpdateFolder\GoogleUpdate.exe.bak"
} else {
    Write-Host "Required version is already installed, no actions performed"
}
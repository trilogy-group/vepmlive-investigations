Param(
	[string]$username = '%epmlive.qa.farmadmin.username%',
	[string]$password = '%epmlive.qa.farmadmin.password%',
	[string]$webAppName = '%epmlive.qa.webAppName%',
	[string]$siteCollectionToUpgrade = '%epmlive.qa.UpgradeSiteCollection%',
	[string]$buildNumber = '%build.number%'
)
Add-Type -assembly "system.io.compression.filesystem"
Remove-Item (Join-Path "C:\SilentInstaller" $buildNumber) -Force -Recurse -ErrorAction SilentlyContinue
Write-Host 'Removed old folder'
[io.compression.zipfile]::ExtractToDirectory("C:\SilentInstaller\SilentInstaller.zip", "C:\SilentInstaller\$buildNumber")
Write-Host 'Extracted new folder'
Copy-Item "C:\SilentInstaller\routines.ps1" (Join-Path "C:\SilentInstaller" $buildNumber "routines.ps1")
Copy-Item "C:\SilentInstaller\epmliveSilentInstaller.ps1" (Join-Path "C:\SilentInstaller" $buildNumber "epmliveSilentInstaller.ps1")

CD "C:\SilentInstaller\$buildNumber"
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force
Write-Host "Prepared to run -comUserName $username -inPassword $password"
.\epmliveSilentInstaller.ps1 -deployTimer -deployPFE -deploySolutions -webAppName $webAppName -upgradeSite $siteCollectionToUpgrade -comUserName $username -inPassword $password


Param(
	[string]$username = '%epmlive.qa.farmadmin.username%',
	[string]$password = '%epmlive.qa.farmadmin.password%',
	[string]$webAppName = '%epmlive.qa.webAppName%',
	[string]$buildNumber = '%build.number%',
	[switch]$deploySolutions
)

Write-Host "Current User: $env:UserName"
Add-Type -assembly "system.io.compression.filesystem"
Remove-Item (Join-Path "C:\SilentInstaller" $buildNumber) -Force -Recurse -ErrorAction SilentlyContinue
Write-Host 'Removed old folder'
[io.compression.zipfile]::ExtractToDirectory("C:\SilentInstaller\SilentInstaller.zip", "C:\SilentInstaller\$buildNumber")
Write-Host 'Extracted new folder'
Move-Item "C:\SilentInstaller\routines.ps1" (Join-Path "C:\SilentInstaller" $buildNumber | Join-Path -ChildPath "routines.ps1") -Force
Move-Item "C:\SilentInstaller\epmliveSilentInstaller.ps1" (Join-Path "C:\SilentInstaller" $buildNumber | Join-Path -ChildPath "epmliveSilentInstaller.ps1") -Force
Copy-Item "C:\SilentInstaller\SitesList.xml" (Join-Path "C:\SilentInstaller" $buildNumber | Join-Path -ChildPath "SitesList.xml") -Force

CD "C:\SilentInstaller\$buildNumber"
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force
Write-Host "Prepared to run -comUserName $username -inPassword $password"
if ($deploySolutions)
{
	.\epmliveSilentInstaller.ps1 -deployTimer -deployPFE -deploySolutions -webAppName $webAppName -upgradeSites -comUserName $username -inPassword $password
}
else
{
	.\epmliveSilentInstaller.ps1 -comUserName $username -inPassword $password
}

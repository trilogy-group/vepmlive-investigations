Param(
	[string]$serverIP = '%epmlive.qa.ip%',
	[string]$username = '%epmlive.qa.farmadmin.username%',
	[string]$password = '%epmlive.qa.farmadmin.password%',
	[string]$webAppName = '%epmlive.qa.webAppName%',
	[string]$siteCollectionToUpgrade = '%epmlive.qa.UpgradeSiteCollection%',
	[string]$buildNumber = '%build.number%'
)
Write-Host "Connecting to $serverIP, $webAppName, $siteCollectionToUpgrade, $buildNumber"
Set-Item WSMan:\localhost\Client\TrustedHosts -Value $serverIP  -Force
$passwd = convertto-securestring -AsPlainText -Force -String $password
$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $passwd
$session = New-PSSession -ComputerName $serverIP -Credential $cred
Invoke-Command -Session $session {Write-Host 'Connected remotely'}
Invoke-Command -Session $session {Remove-Item C:\SilentInstaller\SilentInstaller.zip -ErrorAction SilentlyContinue}
Invoke-Command -Session $session {Write-Host 'Deleted old installer'}
copy-item -path SilentInstaller.zip -Destination C:\SilentInstaller\. -ToSession $session
Invoke-Command -Session $session {Write-Host 'Copied new installer'}
Invoke-Command -Session $session {Add-Type -assembly "system.io.compression.filesystem"}
Invoke-Command -Session $session {Remove-Item "C:\SilentInstaller\$buildNumber" -Force -Recurse -ErrorAction SilentlyContinue}
Invoke-Command -Session $session {Write-Host 'Removed old folder'}
Invoke-Command -Session $session {[io.compression.zipfile]::ExtractToDirectory("C:\SilentInstaller\SilentInstaller.zip", "C:\SilentInstaller\$buildNumber")}
Invoke-Command -Session $session {Write-Host 'Extracted new folder'}
Invoke-Command -Session $session {CD "C:\SilentInstaller\$buildNumber"}
Invoke-Command -Session $session {Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force}
Invoke-Command -Session $session {Write-Host "Prepared to run -comUserName $username -inPassword $password"}
Invoke-Command -Session $session {.\epmliveSilentInstaller.ps1 -deployTimer -deployPFE -deploySolutions -webAppName $webAppName -upgradeSite $siteCollectionToUpgrade -comUserName $username -inPassword $password }
Invoke-Command -Session $session {Write-Host 'Run complete'}
Remove-PSSession $session

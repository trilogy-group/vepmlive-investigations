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
Invoke-Command -Session $session {Remove-Item C:\SilentInstaller\deploy.ps1 -ErrorAction SilentlyContinue}
Invoke-Command -Session $session {Write-Host 'Deleted old installer'}
copy-item -path SilentInstaller.zip -Destination C:\SilentInstaller\. -ToSession $session
copy-item -path BuildTeamcity\deploy.ps1 -Destination C:\SilentInstaller\. -ToSession $session
Invoke-Command -Session $session {Write-Host 'Copied new installer'}
$scriptBlock = $ExecutionContext.InvokeCommand.NewScriptBlock("C:\SilentInstaller\deploy.ps1 $username $password $webAppName $siteCollectionToUpgrade $buildNumber")
Invoke-Command -Session $session -ScriptBlock $scriptBlock
Invoke-Command -Session $session {Write-Host 'Run complete'}
Remove-PSSession $session

Param(
	[string]$serverIP = '%epmlive.qa.ip%',
	[string]$username = '%epmlive.qa.farmadmin.username%',
	[string]$password = '%epmlive.qa.farmadmin.password%',
	[string]$webAppName = '%epmlive.qa.webAppName%',
	[string]$siteCollectionToUpgrade = '%epmlive.qa.UpgradeSiteCollection%',
	[string]$buildNumber = '%build.number%'
)

Write-Host 'Configuring PS Remote locally'
winrm quickconfig -quiet
enable-psremoting -force -Confirm:$false

Write-Host 'Configuring WSMAN locally'
Set-Item wsman:\localhost\Client\TrustedHosts -value * -Force

$passwd = convertto-securestring -AsPlainText -Force -String $password
$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $passwd

Write-Host "Connecting to $serverIP, $webAppName, $siteCollectionToUpgrade, $buildNumber"
$session = New-PSSession -ComputerName $serverIP -Credential $cred
Invoke-Command -Session $session -ScriptBlock { Register-PSSessionConfiguration -Name 'EPMRemoteDeploy' -RunAsCredential $username -Force }

Write-Host "Configuring WSMAN remotely: $serverIP"
$scriptBlock = $ExecutionContext.InvokeCommand.NewScriptBlock("Set-Item wsman:\localhost\Client\TrustedHosts -value * -Force");
Invoke-Command -Session $session -ScriptBlock $scriptBlock

Invoke-Command -Session $session {Remove-Item C:\SilentInstaller\SilentInstaller.zip -ErrorAction SilentlyContinue}
Invoke-Command -Session $session {Remove-Item C:\SilentInstaller\deploy.ps1 -ErrorAction SilentlyContinue}
Invoke-Command -Session $session {Remove-Item C:\SilentInstaller\routines.ps1 -ErrorAction SilentlyContinue}
Invoke-Command -Session $session {Remove-Item C:\SilentInstaller\epmliveSilentInstaller.ps1 -ErrorAction SilentlyContinue}
Write-Host 'Deleted old installer files'

copy-item -path SilentInstaller.zip -Destination C:\SilentInstaller\. -ToSession $session
copy-item -path BuildTeamcity\deploy.ps1 -Destination C:\SilentInstaller\. -ToSession $session
copy-item -path BuildTeamcity\SilentInstaller\routines.ps1 -Destination C:\SilentInstaller\. -ToSession $session
copy-item -path BuildTeamcity\SilentInstaller\epmliveSilentInstaller.ps1 -Destination C:\SilentInstaller\. -ToSession $session
Write-Host 'Copied new installer'

$scriptBlock = $ExecutionContext.InvokeCommand.NewScriptBlock("C:\SilentInstaller\deploy.ps1 $username $password $webAppName $siteCollectionToUpgrade $buildNumber")
Invoke-Command -Session $session -ScriptBlock $scriptBlock -ConfigurationName 'EPMRemoteDeploy'

Remove-PSSession $session
Write-Host 'Run complete'


Param(
	[string]$username = '%epmlive.qa.farmadmin.username%',
	[string]$password = '%epmlive.qa.farmadmin.password%',
	[string]$webAppName = '%epmlive.qa.webAppName%',
	[string]$siteCollectionToUpgrade = '%epmlive.qa.UpgradeSiteCollection%',
	[string]$buildNumber = '%build.number%',
	[string[]]$serverIPs = '%epmlive.qa.ip%'
)

Write-Host 'Configuring PS Remote locally'
winrm quickconfig -quiet
enable-psremoting -force -Confirm:$false

Write-Host 'Configuring WSMAN locally'
Set-Item wsman:\localhost\Client\TrustedHosts -value * -Force

$passwd = convertto-securestring -AsPlainText -Force -String $password
$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $passwd

$serverIndex = 0;
foreach ($serverIP in $serverIPs)
{
		
	Write-Host "Connecting to $serverIP, $webAppName, $siteCollectionToUpgrade, $buildNumber"
	$session = New-PSSession -ComputerName $serverIP -Credential $cred 

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

	Remove-PSSession $session
	Write-Host 'Session Disconnected' 

	if ($serverIndex -eq 0)
	{
		#Needs to pre-run on server:
		#New-PSSessionConfigurationFile -Path ./ipam.pssc
		#Register-PSSessionConfiguration -Name Microsoft.ipam -Path .\ipam.pssc -RunAsCredential $cred
		$scriptBlock = $ExecutionContext.InvokeCommand.NewScriptBlock("
		Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force
		C:\SilentInstaller\deploy.ps1 $username $password $webAppName $siteCollectionToUpgrade $buildNumber -deploySolutions
		")
		Invoke-Command -ComputerName $serverIP -Credential $cred -ScriptBlock $scriptBlock -ConfigurationName Microsoft.ipam
	}
	else
	{
		$scriptBlock = $ExecutionContext.InvokeCommand.NewScriptBlock("
		Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force
		C:\SilentInstaller\deploy.ps1 $username $password $webAppName $siteCollectionToUpgrade $buildNumber
		")
		Invoke-Command -ComputerName $serverIP -Credential $cred -ScriptBlock $scriptBlock
	}
	Write-Host 'Run complete $serverIP'
	$serverIndex = $serverIndex + 1;
}



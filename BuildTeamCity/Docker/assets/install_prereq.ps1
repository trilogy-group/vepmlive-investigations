$agentDir = $env:AGENT_DIR
[string] $logsDir = "$PSScriptRoot\logs"

Import-Module "$PSScriptRoot\modules\common-functions.psm1"
Import-Module "$PSScriptRoot\modules\download-functions.psm1"
Import-Module "$PSScriptRoot\modules\install-functions.psm1"

function InstallDocker () {
    # Docker
    $dockerUrl = $env:DOCKER_INSTALLER_URL
    if ([string]::IsNullOrEmpty($dockerUrl)) {
        return
    }

    Log 'Installing docker ...'
    $filePath = "$PSScriptRoot\docker.zip"
    DownloadFromWeb $dockerUrl $filePath
    Expand-Archive -Path $filePath -DestinationPath 'C:\'
    Log "Removing $filePath ..."
    Remove-Item $filePath

    Log 'Adding docker to PATH...'
    $envPath = [environment]::GetEnvironmentVariable('Path', 'Machine')
    $envPath += ';c:\docker'
    [Environment]::SetEnvironmentVariable('Path', $envPath, "Machine")

    # Docker-compose
    $dockerComposeUrl = $env:DOCKER_COMPOSE_INSTALLER_URL
    if ([string]::IsNullOrEmpty($dockerComposeUrl)) {
        return
    }
    Log 'Installing docker-compose ...'
    $filePath = 'c:\docker\docker-compose.exe'
    DownloadFromWeb $dockerComposeUrl $filePath
}

function InstallTcBuildAgent() {
    [string] $serverUrl = $env:SERVER_URL

    Log 'Downloading TeamCity agent...'
    $path = "$PSScriptRoot\buildAgent.zip"
    DownloadFromWeb "$serverUrl/update/buildAgent.zip" $path

    Log 'Extracting TeamCity agent...'
    Expand-Archive -Path $path -DestinationPath $agentDir

    Remove-Item $path -Force

    Log 'Configuring TeamCity agent...'
    $configPath = "$agentDir\conf\buildAgent.properties"
    Copy-Item $agentDir\conf\buildAgent.dist.properties $configPath

    Log 'Configuring TeamCity agent wrapper...'
    $configPath = "$agentDir\launcher\conf\wrapper.conf"
    $config = Get-Content $configPath -Raw -Encoding UTF8
    $config = $config.Replace('wrapper.java.command=java', 'wrapper.java.command=../jre/bin/java')
    Set-Content -Path $configPath -Value $config -Encoding UTF8
}

function InstallJRE () {
    Log 'Installing JRE for Teamcity Build Agent ...'
    InstallFromWeb $env:JRE_INSTALLER_URL "$PSScriptRoot\java_installer.exe" "/s /L $logsDir\tc_jre_install.log INSTALLDIR=$agentDir\jre STATIC=1 REBOOT=0 SPONSORS=0 AUTO_UPDATE=0"
    [string] $path = [System.Environment]::GetEnvironmentVariable('Path', 'Machine')
    $pathItems = $path.Split(';') | Where-Object { $_ -notlike '*javapath'}
    $path = [string]::Join(';', $pathItems)
    [System.Environment]::SetEnvironmentVariable('Path', $path, 'Machine')
}

mkdir $logsDir -Force | Out-Null

Log 'Installing 7-zip...'
InstallFromWeb $env:ZIP7_INSTALLER_URL "$PSScriptRoot\7zip.msi" "/quiet /qn /norestart /l* `"$logsDir\7zip_install.log`""

Log 'Installing GIT ...'
InstallFromWeb $env:GIT_INSTALLER_URL "$PSScriptRoot\git_installer.exe" "/VERYSILENT /SUPPRESSMSGBOXES /NORESTART /NOCANCEL /SP- /LOG=`"$logsDir\tc_git_install.log`""

#InstallDocker

InstallTcBuildAgent

InstallJRE

Log 'Installing AWS tools for Powershell ...'
InstallFromWeb $env:AWSTOOLS_INSTALLER_URL "$PSScriptRoot\AWSToolsAndSDKForNet.msi" "/quiet /qn /norestart /l* $logsDir\awstools_install.log ADDLOCAL=AWSPowerShell"

Log 'Installation completed'
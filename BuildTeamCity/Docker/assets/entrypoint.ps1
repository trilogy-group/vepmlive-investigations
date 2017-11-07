Import-Module "$PSScriptRoot\modules\common-functions.psm1"
$agentDir = $env:AGENT_DIR

function ConfigureTcBuildAgent() {
    [string] $serverUrl = $env:SERVER_URL
    [string] $agentName = $env:AGENT_NAME
    
    Log 'Configuring TeamCity agent...'
    $configPath = "$agentDir\conf\buildAgent.properties"
    $config = Get-Content $configPath -Raw -Encoding UTF8
    $config = $config.Replace('serverUrl=http://localhost:8111/', "serverUrl=$serverUrl/").Replace('name=', "name=$agentName")
    Set-Content -Path $configPath -Value $config -Encoding UTF8

    Log 'Configuring TeamCity agent''s properties ...'
    if (![string]::IsNullOrEmpty($env:AGENT_PROPERTIES)) {
        $props = ConvertFrom-Json $env:AGENT_PROPERTIES
        foreach ($prop in $props) {
            Add-Content -Path $configPath -Value $prop -Encoding UTF8
        }
    }
}

function RunStartupScripts () {
    if (!(Test-Path "$PSScriptRoot\startup")) {
        return
    }
    $scripts = Get-ChildItem -Path startup -File -Filter '*.ps1'
    if ($scripts.Length -le 0) {
        return
    }
    Log 'Executing startup scripts...'
    foreach ($startupScript in $scripts) {
        $scriptName = $startupScript.Name
        $scriptPath = $startupScript.FullName
        Log "Executing script $scriptName ..."
        & $scriptPath
    }
}

function GetProcess ([string] $specification) {
    $wmiProcess = Get-WmiObject Win32_Process -Filter $specification
    if ($wmiProcess -eq $null) {
        return $null
    }
    $proc = Get-Process -Id $wmiProcess.ProcessId -ErrorAction SilentlyContinue
    if ($proc -eq $null) {
        Log "Process with Id=$($wmiProcess.ProcessId) not found"
    }
    return $proc
}

function MonitorAgentProcess () {
    #Wrapper process specification
    [string] $processSpecification = "Name = 'java.exe' and CommandLine like '%jetbrains.buildServer.agent.Launcher%'"
    
    [int] $waitCount = $env:TC_AGENT_WAIT_COUNT
    [int] $waitInterval = ([System.TimeSpan] $env:TC_AGENT_WAIT_INTERVAL).TotalSeconds

    [int] $remainingAttemptsCount = $waitCount
    do {
        Log "Finding main process..."
        $proc = GetProcess $processSpecification
    
        #Process was found
        if ($proc -ne $null) {
            #Reset remaining attempts count
            $remainingAttemptsCount = $waitCount
            
            Log "Main process was found. Waiting for process $($proc.Id)..."
            #Wait in loop until process exited.
            #WaitForExit returns true when process exited and returns false when timeout is elapsed.
            while (!($proc.WaitForExit(60000))) {
            }
            Log "Process $($proc.Id) exited."
        }
        else {
            #Decrease number of remaining attempts.
            $remainingAttemptsCount--
            Log "Main process not found."
        }

        Log "$remainingAttemptsCount atempts left..."
        if ($remainingAttemptsCount -gt 0) {
            Log "Waiting $waitInterval seconds for retry..."    
            Start-Sleep -Seconds $waitInterval
        }
    }
    while ($remainingAttemptsCount -gt 0)
    Log 'Stopping retrying...'
}

if (!(Test-Path '.\config.done')) {
    ConfigureTcBuildAgent 
    Get-Date | Set-Content '.\config.done'
    Log 'TeamCity agent configuration completed'
}

#Run additional scripts which can be added by children images
RunStartupScripts

Log 'Starting TeamCity agent ...'
& "$agentDir\bin\agent.bat" start
Log 'TeamCity agent started successfully'

MonitorAgentProcess
Log 'Exiting agent...'

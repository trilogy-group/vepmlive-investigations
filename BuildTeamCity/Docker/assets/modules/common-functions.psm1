$datetimeformat = "dd-MMM-yyyy HH:mm:ss"

function Log ($message)
{
    $now = Get-Date -format $datetimeformat 
    Write-Host "$now - $message"
}

Export-ModuleMember -Function Log

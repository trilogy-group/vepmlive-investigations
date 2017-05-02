$config = Get-Content "config.json" | Out-String | ConvertFrom-Json

Remove-Item "SilentInstaller" -Force -Recurse
New-Item "SilentInstaller" -type directory -Force

$outputFolder = "..\output"
$outputFolder2 = "..\InstallShield\Build Dependencies"

foreach ($component in $config.Components)
{
    $folderName = "SilentInstaller\"+$component.name
    New-Item $folderName -type directory -Force

    foreach ($file in $component.files)
    {
        #& robocopy $outputFolder $folderName $file
        Get-ChildItem -Path $outputFolder -Filter $file -Recurse | `
            Where-Object { $_.PSIsContainer -eq $False } | `
            ForEach-Object {Copy-Item -Path $_.Fullname -Destination $folderName -Force}
        
        Get-ChildItem -Path $outputFolder2 -Filter $file -Recurse | `
            Where-Object { $_.PSIsContainer -eq $False } | `
            ForEach-Object {Copy-Item -Path $_.Fullname -Destination $folderName -Force}
    }    
}
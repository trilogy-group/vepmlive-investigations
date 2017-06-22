$config = Get-Content "config.json" | Out-String | ConvertFrom-Json

New-Item "SilentInstaller" -type directory -Force
Remove-Item "SilentInstaller\Files" -Force -Recurse
New-Item "SilentInstaller\Files" -type directory -Force

$outputFolder = "..\output"
$outputFolder2 = "..\InstallShield\Build Dependencies"

function ZipFiles( $zipfilename, $sourcedir )
{
   If(Test-path $zipfilename) {Remove-item $zipfilename}
   $compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
   Add-Type -Assembly System.IO.Compression.FileSystem
   [System.IO.Compression.ZipFile]::CreateFromDirectory($sourcedir,  $zipfilename, $compressionLevel,  $false)
}

foreach ($component in $config.Components)
{
    $folderName = "SilentInstaller\Files\"+$component.name
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

Copy-Item -Path "config.json" -Destination "SilentInstaller\config.json" -Force

ZipFiles "SilentInstaller.zip" "SilentInstaller"
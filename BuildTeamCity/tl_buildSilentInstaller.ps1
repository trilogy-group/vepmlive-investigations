$config = Get-Content "config.json" | Out-String | ConvertFrom-Json

$ScriptDir = split-path -parent $MyInvocation.MyCommand.Definition
$SourcesDirectory = "$ScriptDir\..\"
$outputFolder = Join-Path $SourcesDirectory "output"
$outputFolder2 = Join-Path $SourcesDirectory "InstallShield\Build Dependencies"
$silentInstallerFolder = Join-Path $ScriptDir "SilentInstaller"
$filesFolderName = Join-Path $scriptDir "SilentInstaller\Files" 

New-Item $silentInstallerFolder -type directory -Force
If(Test-path $filesFolderName) {Remove-Item $filesFolderName -Force -Recurse}
New-Item $filesFolderName -type directory -Force

function ZipFiles( $zipfilename, $sourcedir )
{
   If(Test-path $zipfilename) {Remove-item $zipfilename}
   $compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
   Add-Type -Assembly System.IO.Compression.FileSystem
   [System.IO.Compression.ZipFile]::CreateFromDirectory($sourcedir,  $zipfilename, $compressionLevel,  $false)
}

foreach ($component in $config.Components)
{
    
	$folderName = Join-Path $filesFolderName $component.name
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
$configFile = Join-Path $scriptDir "config.json"
$configDest = Join-Path $scriptDir "SilentInstaller\config.json"
Copy-Item -Path  $configFile -Destination $configDest -Force


$outputZipPath = Join-Path $ScriptDir "SilentInstaller.zip"
ZipFiles $outputZipPath $silentInstallerFolder

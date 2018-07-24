param([string]$branch = "branch", [string]$build = "build")
$ver = [RegEx]::Match($branch,'((?:\d+\.\d+(\.\d+)?))');
$ver2 = [RegEx]::Match($ver, '((\d+\.\d+\.\d+)(?:\.\d+)?)').Groups[2];
$rel = ''+$ver2+'.'+$build;

iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'));
choco install -y curl;
cd vepmlive-epmlive2013release/BuildTeamCity; 
powershell curl.exe -X GET -O https://nexus.devfactory.com/repository/versata-epmlive-releases/$rel/SilentInstaller.zip;
#powershell curl.exe -X GET -O https://nexus.devfactory.com/repository/versata-epmlive-releases/6.4.0.6/SilentInstaller.zip; 
powershell Compress-Archive -LiteralPath ./SilentInstaller.zip -DestinationPath ./si.zip
& 'C:\Program Files\nodejs\node.exe' C:\ts-client\bin\ts-cli start-job C:\vepmlive-epmlive2013release\BuildTeamCity\si.zip $rel
#& 'C:\Program Files\nodejs\node.exe' C:\ts-client\bin\ts-cli start-job C:\vepmlive-epmlive2013release\BuildTeamCity\si.zip 6.4.0.6_$build

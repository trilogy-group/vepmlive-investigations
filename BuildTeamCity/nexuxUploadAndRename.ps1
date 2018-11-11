param([string]$branch = "branch", [string]$build = "build")
$ver = [RegEx]::Match($branch,'((?:\d+\.\d+(\.\d+)?))');
$ver2 = [RegEx]::Match($ver, '((\d+\.\d+\.\d+)(?:\.\d+)?)').Groups[2];
$rel = ''+$ver2+'.'+$build;

cp.exe c:\workspace\BuildTeamCity\SilentInstaller.zip c:\workspace\BuildTeamCity\epmlive_SI_$rel.zip

(Get-Content c:\workspace\BuildTeamCity\rcBuildDeployment.ps1).replace('$rel', $rel) | Set-Content c:\workspace\BuildTeamCity\rcBuildDeployment_real.ps1


# %teamcity.tool.curl%\curl\curl.exe -X PUT -v -H "Content-Type: application/x-dosexec"  --upload-file "InstallShield\Build Dependencies\PublisherSetup2016x64_%build.number%.zip" -u %nexus.tc.username%:%nexus.tc.password% https://nexus.devfactory.com/repository/versata-epmlive-releases/%build.number%/
# %teamcity.tool.curl%\curl\curl.exe -X PUT -v -H "Content-Type: application/x-dosexec"  --upload-file "InstallShield\Build Dependencies\PublisherSetup2016x86_%build.number%.zip" -u %nexus.tc.username%:%nexus.tc.password% https://nexus.devfactory.com/repository/versata-epmlive-releases/%build.number%/
# %teamcity.tool.curl%\curl\curl.exe -X PUT -v -H "Content-Type: application/x-dosexec"  --upload-file "BuildTeamCity\SilentInstaller.zip" -u %nexus.tc.username%:%nexus.tc.password% https://nexus.devfactory.com/repository/versata-epmlive-releases/%build.number%/
$pw = '{~jmGj2Mj_eWA`';
curl.exe -X PUT -v --upload-file "c:\workspace\BuildTeamCity\SilentInstaller.zip" -u service.tc.nexus:$pw https://nexus.devfactory.com/repository/versata-epmlive-releases/$rel/
curl.exe -X PUT -v --upload-file "c:\workspace\InstallShield\Build Dependencies\PublisherSetup2016x64_$build.zip" -u service.tc.nexus:$pw https://nexus.devfactory.com/repository/versata-epmlive-releases/$rel/
curl.exe -X PUT -v --upload-file "c:\workspace\InstallShield\Build Dependencies\PublisherSetup2016x86_$build.zip" -u service.tc.nexus:$pw https://nexus.devfactory.com/repository/versata-epmlive-releases/$rel/

Write-Host "Upload to Nexus finished. Release: $rel"

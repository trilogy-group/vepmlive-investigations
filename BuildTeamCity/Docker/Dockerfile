#FROM microsoft/windowsservercore
#FROM microsoft/dotnet-framework:3.5-windowsservercore-10.0.14393.1593
#FROM microsoft/dotnet-framework:3.5-windowsservercore-10.0.14393.1480
#FROM microsoft/windowsservercore:10.0.14393.1715
FROM microsoft/dotnet-framework:3.5-windowsservercore-10.0.14393.1715



LABEL \
    com.trilogy.company="Aurea" \
    com.trilogy.team="MS.DockerProduction" \
    com.trilogy.product="eng.docker" \
    com.trilogy.service="tc-agent" \
    com.trilogy.stage="prod" \
    com.trilogy.maintainer.email="alexey.rokhin@aurea.com" \
    com.trilogy.maintainer.skype="AlexeyRokhin"

ARG SERVER_URL='http://10.137.22.36'
ARG ZIP7_INSTALLER_URL='http://www.7-zip.org/a/7z1604-x64.msi'
ARG GIT_INSTALLER_URL='https://github.com/git-for-windows/git/releases/download/v2.13.3.windows.1/Git-2.13.3-64-bit.exe'
ARG JRE_INSTALLER_URL='http://files.msassist.com/Java/jre-8u151-windows-x64.exe'
ARG DOCKER_INSTALLER_URL='https://get.docker.com/builds/Windows/x86_64/docker-17.03.1-ce.zip'
ARG DOCKER_COMPOSE_INSTALLER_URL='https://github.com/docker/compose/releases/download/1.14.0/docker-compose-Windows-x86_64.exe'
ARG AWSTOOLS_INSTALLER_URL='http://sdk-for-net.amazonwebservices.com/latest/AWSToolsAndSDKForNet.msi'

ENV \
    SERVER_URL=$SERVER_URL \
    AGENT_DIR='C:\BuildAgent' \
    AGENT_NAME= \
    AGENT_PROPERTIES='[]' \
    TEAMCITY_AGENT_MEM_OPTS='-Xmx384m' \
    TC_AGENT_WAIT_COUNT=20 \
    TC_AGENT_WAIT_INTERVAL='00:00:15'

COPY /assets /assets/

WORKDIR /assets

RUN powershell .\install_prereq.ps1

SHELL ["powershell"]


# Install required features
RUN Install-WindowsFeature NET-Framework-45-Core ; \
Install-WindowsFeature NET-Framework-45-ASPNET ; \
Install-WindowsFeature Web-Asp-Net45 ; \
New-Item -ItemType Directory C:\Sources

# Download and install build tools 
RUN Invoke-WebRequest "https://download.microsoft.com/download/E/E/D/EEDF18A8-4AED-4CE0-BEBE-70A83094FC5A/BuildTools_Full.exe" -OutFile "C:\Sources\BuildTools_Full.exe" -UseBasicParsing ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\BuildTools_Full.exe" -ArgumentList /Silent, /Full ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
setx PATH '%PATH%;C:\Program Files (x86)\MSBuild\14.0\Bin\' ; \
Remove-Item "C:\Sources\BuildTools_Full.exe" 

#Download Net 4.6.2 dev pack
RUN Invoke-WebRequest 'https://download.microsoft.com/download/E/F/D/EFD52638-B804-4865-BB57-47F4B9C80269/NDP462-DevPack-KB3151934-ENU.exe' -OutFile "C:\Sources\devpack.exe" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\devpack.exe" -ArgumentList /quiet ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\devpack.exe" 

#Download and install inclusion list fix
RUN Invoke-WebRequest "https://download.microsoft.com/download/7/A/F/7AFA5695-2B52-44AA-9A2D-FC431C231EDC/vstor_redist.exe" -OutFile "C:\Sources\vstor_redist.exe" -UseBasicParsing ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\vstor_redist.exe" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\vstor_redist.exe" 

#Download Web Deploy 3.6
RUN Invoke-WebRequest 'https://download.microsoft.com/download/0/1/D/01DC28EA-638C-4A22-A57B-4CEF97755C6C/WebDeploy_amd64_en-US.msi' -OutFile "C:\Sources\WebDeploy_amd64_en-US.msi" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\WebDeploy_amd64_en-US.msi" -ArgumentList /quiet ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\WebDeploy_amd64_en-US.msi" 

#Install VS2017 test tools and intellitrace
#Invoke-WebRequest "https://aka.ms/vs/15/release/vs_enterprise.exe" -OutFile "C:\Installer\vs_enterprise.exe" -UseBasicParsing ; \
#& "C:\Installer\vs_enterprise.exe" --add Microsoft.VisualStudio.Workload.NetWeb --add Microsoft.VisualStudio.Workload.Office --add Microsoft.VisualStudio.Component.TestTools.Core --includeOptional --nocache --quiet --wait --norestart --noUpdateInstaller | Out-Default
RUN New-Item -ItemType directory -Path 'C:\Installer' ; \
Invoke-WebRequest "https://download.visualstudio.microsoft.com/download/pr/100256481/ff220073505d38011e8af5b1ad85c6ef/vs_Enterprise.exe" -OutFile "C:\Installer\vs_enterprise.exe" -UseBasicParsing ; \
& "C:\Installer\vs_enterprise.exe" --add Microsoft.VisualStudio.Component.TestTools.Core --add Microsoft.VisualStudio.Component.IntelliTrace.FrontEnd --includeOptional --nocache --quiet --wait --norestart --noUpdateInstaller | Out-Default

# Download SharePoint assemblies
RUN Invoke-WebRequest 'https://onedrive.live.com/download?cid=FDD9E9CD6B4F4283"&"resid=FDD9E9CD6B4F4283%21185"&"authkey=AP1qb04dhVTd9cM' -OutFile "$env:TEMP\SharePointShare.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files\Reference Assemblies\SharePoint' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "SharePointShare.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip , 'C:\Program Files\Reference Assemblies\SharePoint') ; \
Remove-Item "$env:TEMP\SharePointShare.zip"

# Set SharePoint references in registry
RUN New-Item -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint16.0' -Force | Out-Null ; \
New-ItemProperty -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint16.0' -Name '(Default)' -Value 'C:\Program Files\Reference Assemblies\SharePoint\' | Out-Null ; \
New-Item -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint' -Force | Out-Null ; \
New-ItemProperty -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint' -Name '(Default)' -Value 'C:\Program Files\Reference Assemblies\SharePoint\' | Out-Null

# Download build targets and signing tools
RUN Invoke-WebRequest 'https://onedrive.live.com/download?cid=FDD9E9CD6B4F4283"&"resid=FDD9E9CD6B4F4283%21381"&"authkey=ANwkOxHVbU2Zmfo' -OutFile "$env:TEMP\v14.0.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "v14.0.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0') ; \
Remove-Item "$env:TEMP\v14.0.zip" 

# Install Certificate to Certificate Store
RUN $PlainTextPass = '1kjS4dF3D5dt' ; \
$pfxpass = $PlainTextPass |ConvertTo-SecureString -AsPlainText -Force ; \
Import-PfxCertificate -FilePath 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\EPMLive.pfx' -CertStoreLocation 'Cert:\CurrentUser\My' -Password $pfxpass

# Install Certificate to Container
RUN & 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\SN.exe' 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\EPMLive.pfx' 1kjS4dF3D5dt

# Download Project Server REDIST
RUN Invoke-WebRequest 'https://onedrive.live.com/download?cid=FDD9E9CD6B4F4283"&"resid=FDD9E9CD6B4F4283%21386"&"authkey=ADFdd2oKKcGmH0I' -OutFile "$env:TEMP\ProjectRedist.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files (x86)\Microsoft SDKs\Project 2013\REDIST' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "ProjectRedist.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip , 'C:\Program Files (x86)\Microsoft SDKs\Project 2013\REDIST') ; \
Remove-Item "$env:TEMP\ProjectRedist.zip"

# Download Office Interop
RUN Invoke-WebRequest 'https://onedrive.live.com/download?cid=FDD9E9CD6B4F4283"&"resid=FDD9E9CD6B4F4283%21385"&"authkey=AAFq8Ltxt87Qnho' -OutFile "$env:TEMP\PIA.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files (x86)\Microsoft Visual Studio 14.0\Visual Studio Tools for Office' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "PIA.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip , 'C:\Program Files (x86)\Microsoft Visual Studio 14.0\Visual Studio Tools for Office') ; \
Remove-Item "$env:TEMP\PIA.zip"

#Download VSTO
RUN Invoke-WebRequest 'https://onedrive.live.com/download?cid=FDD9E9CD6B4F4283"&"resid=FDD9E9CD6B4F4283%21387"&"authkey=AAwjivgSoOWmWIM' -OutFile "$env:TEMP\VSTO.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files\Reference Assemblies\Microsoft\VSTO40\v4.0.Framework' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "VSTO.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Program Files\Reference Assemblies\Microsoft\VSTO40\v4.0.Framework') ; \
Remove-Item "$env:TEMP\VSTO.zip" 

#Download Visual Studio GAC
RUN Invoke-WebRequest 'https://onedrive.live.com/download?cid=FDD9E9CD6B4F4283"&"resid=FDD9E9CD6B4F4283%21202"&"authkey=ANF3UOR2p-UXriw' -OutFile "$env:TEMP\SharePointGAC.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files\Reference Assemblies\GAC' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "SharePointGAC.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Program Files\Reference Assemblies\GAC') ; \
Remove-Item "$env:TEMP\SharePointGAC.zip" 

#Install GAC Assemblies
RUN [System.Reflection.Assembly]::Load('System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a')  ; \
$publish = New-Object System.EnterpriseServices.Internal.Publish ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.SharePoint.Designers.Models.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.SharePoint.Designers.Models.Features.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.SharePoint.Designers.Models.Packages.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.SharePoint.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.Tools.Office.BuildTasks.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.Tools.Office.Runtime.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.Tools.Office.Runtime.Internal.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.Tools.Office.ContainerControl.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.Tools.Office.Designer.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.Tools.Office.Project.Excel.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.Tools.Office.Project.Word.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\DocumentFormat.OpenXml.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.IdentityModel.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.IdentityModel.Extensions.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Project.Schema.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Project.Server.Administration.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Project.Server.Library.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Project.Server.PWA.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Project.Shared.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Project.Server.Events.Receivers.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.ReportViewer.Common.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.ReportViewer.WebForms.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.QualityTools.Testing.Fakes.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Build.Utilities.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Tools.Common.v4.0.Utilities.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.Tools.Applications.BuildTasks.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Interop.MSProject.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\ModelingSDK\Microsoft.VisualStudio.Modeling.Sdk.14.0.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\ModelingSDK\Microsoft.VisualStudio.Modeling.Sdk.Diagrams.14.0.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\ModelingSDK\Microsoft.VisualStudio.Modeling.SDK.Integration.14.0.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\ModelingSDK\Microsoft.VisualStudio.Modeling.SDK.Integration.Shell.14.0.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\ModelingSDK\Microsoft.VisualStudio.Modeling.SDK.Integration.Shell.14.0.Resources.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\ModelingSDK\Microsoft.VisualStudio.Modeling.Sdk.Shell.14.0.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.VisualStudio.SharePoint.Tasks.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Sharepoint.Tools.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.SharePoint.Library.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.BusinessData.dll') ; \
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.SharePoint.Flighting.Dll') 


EXPOSE 9090

ENTRYPOINT powershell .\entrypoint.ps1

HEALTHCHECK NONE

#CMD while ($true) { Start-Sleep -Seconds 3600 }


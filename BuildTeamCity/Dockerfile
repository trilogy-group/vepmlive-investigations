FROM microsoft/windowsservercore
MAINTAINER essam.elsayed@versata.com

# docker push samasama/epmlbuild:1.0

SHELL ["powershell"]

# Install required features
RUN Install-WindowsFeature NET-Framework-45-Core ; \
Install-WindowsFeature NET-Framework-45-ASPNET ; \
Install-WindowsFeature Web-Asp-Net45
	
#Download Net 4.6.2 dev pack
RUN Invoke-WebRequest 'https://download.microsoft.com/download/E/F/D/EFD52638-B804-4865-BB57-47F4B9C80269/NDP462-DevPack-KB3151934-ENU.exe' -OutFile "$env:TEMP\devpack.exe" -UseBasicParsing  ; \
Start-Process -Wait -FilePath "$env:TEMP\devpack.exe -ArgumentList /quiet ; \
Remove-Item "$env:TEMP\devpack.exe" 

# Download and install build tools 
RUN Invoke-WebRequest "https://download.microsoft.com/download/E/E/D/EEDF18A8-4AED-4CE0-BEBE-70A83094FC5A/BuildTools_Full.exe" -OutFile "$env:TEMP\BuildTools_Full.exe" -UseBasicParsing ; \
Start-Process -Wait -FilePath "$env:TEMP\BuildTools_Full.exe" -ArgumentList /Silent, /Full ; \
setx PATH '%PATH%;C:\Program Files (x86)\MSBuild\14.0\Bin\' ; \
Remove-Item "$env:TEMP\BuildTools_Full.exe"

#Inclusion list fix
RUN Invoke-WebRequest "https://download.microsoft.com/download/7/A/F/7AFA5695-2B52-44AA-9A2D-FC431C231EDC/vstor_redist.exe" -OutFile "$env:TEMP\vstor_redist.exe" -UseBasicParsing ; \
Start-Process -Wait -FilePath "$env:TEMP\vstor_redist.exe" -ArgumentList /q ; \
Remove-Item "$env:TEMP\vstor_redist.exe" 

# Set SharePoint references in registry
RUN New-Item -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint16.0' -Force | Out-Null ; \
New-ItemProperty -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint16.0' -Name '(Default)' -Value 'C:\Program Files\Reference Assemblies\SharePoint\' | Out-Null ; \
New-Item -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint' -Force | Out-Null ; \
New-ItemProperty -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint' -Name '(Default)' -Value 'C:\Program Files\Reference Assemblies\SharePoint\' | Out-Null

# Download SharePoint assemblies
RUN Invoke-WebRequest 'https://onedrive.live.com/download?cid=FDD9E9CD6B4F4283"&"resid=FDD9E9CD6B4F4283%21185"&"authkey=AP1qb04dhVTd9cM' -OutFile "$env:TEMP\SharePointShare.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files\Reference Assemblies\SharePoint' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "SharePointShare.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip , 'C:\Program Files\Reference Assemblies\SharePoint') ; \
Remove-Item "$env:TEMP\SharePointShare.zip"

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
Remove-Item "$env:TEMP\SharePointGAC.zip" ; \
Write-Host 'Done!!'

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
$publish.GacInstall('C:\Program Files\Reference Assemblies\GAC\Microsoft.Office.Sharepoint.Tools.dll')


#Download Web Deploy 3.6
RUN Invoke-WebRequest 'https://download.microsoft.com/download/0/1/D/01DC28EA-638C-4A22-A57B-4CEF97755C6C/WebDeploy_amd64_en-US.msi' -OutFile "$env:TEMP\WebDeploy_amd64_en-US.msi" -UseBasicParsing  ; \
Start-Process -Wait -FilePath "$env:TEMP\WebDeploy_amd64_en-US.msi -ArgumentList /quiet ; \
Remove-Item "$env:TEMP\WebDeploy_amd64_en-US.msi" 


#CMD powershell C:\Build\vepmlive-epmlive2013release\BuildTeamCity\tl_buildCode.ps1; C:\Build\vepmlive-epmlive2013release\BuildTeamCity\tl_buildInstaller.ps1 -SkipInstallShield; C:\Build\vepmlive-epmlive2013release\BuildTeamCity\tl_buildSilentInstaller.ps1
CMD while ($true) { Start-Sleep -Seconds 3600 }

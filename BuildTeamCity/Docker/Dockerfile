FROM microsoft/windowsservercore

LABEL \
    com.trilogy.company="Aurea" \
    com.trilogy.team="MS.DockerProduction" \
    com.trilogy.product="eng.docker" \
    com.trilogy.service="jenkins-agent" \
    com.trilogy.stage="prod" \
    com.trilogy.maintainer.email="rustem.zinnatullin@versata.com" \
    com.trilogy.maintainer.skype="live:cool_rus_killer"

SHELL ["powershell"]

# Download and install build tools 
RUN New-Item -ItemType Directory C:\Sources ; \
Invoke-WebRequest "https://download.microsoft.com/download/E/E/D/EEDF18A8-4AED-4CE0-BEBE-70A83094FC5A/BuildTools_Full.exe" -OutFile "C:\Sources\BuildTools_Full.exe" -UseBasicParsing ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\BuildTools_Full.exe" -ArgumentList /Silent, /Full ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\BuildTools_Full.exe" 

# Install required features
RUN Install-WindowsFeature NET-Framework-45-Core ; \
Install-WindowsFeature NET-Framework-45-ASPNET ; \
Install-WindowsFeature Web-Asp-Net45

#Download WindowsKit 8.0
RUN Invoke-WebRequest 'http://download.microsoft.com/download/F/1/3/F1300C9C-A120-4341-90DF-8A52509B23AC/standalonesdk/sdksetup.exe' -OutFile "C:\Sources\sdksetup.exe" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\sdksetup.exe" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\sdksetup.exe" 

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

# Download and Install VS2017 TestAgent components
RUN Invoke-WebRequest https://aka.ms/vs/15/release/vs_testagent.exe -OutFile c:\vs_testagent.exe
SHELL ["cmd", "/S", "/C"]
RUN c:\vs_testagent.exe --quiet --wait --norestart --nocache --all || IF "%ERRORLEVEL%"=="3010" EXIT 0
RUN del c:\vs_testagent.exe
SHELL ["powershell"]

# Download SharePoint assemblies
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/SharePointShare.zip -OutFile "$env:TEMP\SharePointShare.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files\Reference Assemblies\SharePoint' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "SharePointShare.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip , 'C:\Program Files\Reference Assemblies\SharePoint') ; \
Remove-Item "$env:TEMP\SharePointShare.zip"

# Set SharePoint references in registry
RUN New-Item -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint15' -Force | Out-Null ; \
New-ItemProperty -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint15' -Name '(Default)' -Value 'C:\Program Files (x86)\Reference Assemblies\Microsoft\SharePoint15\' | Out-Null ; \
New-Item -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint14' -Force | Out-Null ; \
New-ItemProperty -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint14' -Name '(Default)' -Value 'C:\Program Files (x86)\Reference Assemblies\Microsoft\SharePoint14\' | Out-Null ; \
New-Item -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint' -Force | Out-Null ; \
New-ItemProperty -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\SharePoint' -Name '(Default)' -Value 'C:\Program Files (x86)\Reference Assemblies\Microsoft\SharePoint15\' | Out-Null

# Download build targets and signing tools
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/v14.0.zip -OutFile "$env:TEMP\v14.0.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "v14.0.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0') ; \
Remove-Item "$env:TEMP\v14.0.zip"  

# Install Certificate to Certificate Store
RUN $PlainTextPass = '1kjS4dF3D5dt' ; \
$pfxpass = $PlainTextPass |ConvertTo-SecureString -AsPlainText -Force ; \
Import-PfxCertificate -FilePath 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\EPMLive.pfx' -CertStoreLocation 'Cert:\CurrentUser\My' -Password $pfxpass ; \
Import-Certificate -FilePath 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\CACert.cer' -CertStoreLocation 'Cert:\LocalMachine\Root'

# Install Certificate to Container
RUN & 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\SN.exe' 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\EPMLive.pfx' 1kjS4dF3D5dt

# Download Project Server REDIST
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/ProjectRedist.zip -OutFile "$env:TEMP\ProjectRedist.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files (x86)\Microsoft SDKs\Project 2013\REDIST' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "ProjectRedist.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip , 'C:\Program Files (x86)\Microsoft SDKs\Project 2013\REDIST') ; \
Remove-Item "$env:TEMP\ProjectRedist.zip"

# Download Office Interop
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/Visual+Studio+Tools+for+Office.zip -OutFile "$env:TEMP\PIA.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files (x86)\Microsoft Visual Studio 14.0\Visual Studio Tools for Office' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "PIA.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip , 'C:\Program Files (x86)\Microsoft Visual Studio 14.0\Visual Studio Tools for Office') ; \
Remove-Item "$env:TEMP\PIA.zip"

#Download VSTO
RUN Invoke-WebRequest 'https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/v4.0.Framework.zip' -OutFile "$env:TEMP\VSTO.zip" -UseBasicParsing  ; \
New-Item -ItemType directory -Path 'C:\Program Files\Reference Assemblies\Microsoft\VSTO40\v4.0.Framework' ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "VSTO.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Program Files\Reference Assemblies\Microsoft\VSTO40\v4.0.Framework') ; \
Remove-Item "$env:TEMP\VSTO.zip" 

#Download SDK Tools 
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/SDKTools.zip -OutFile "$env:TEMP\SDKTools.zip" -UseBasicParsing  ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "SDKTools.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Program Files (x86)\Microsoft SDKs') ; \
Remove-Item "$env:TEMP\SDKTools.zip" 

#Download AjaxMinSetup.msi
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/AjaxMinSetup.msi -OutFile "C:\Sources\AjaxMinSetup.msi" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\AjaxMinSetup.msi" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\AjaxMinSetup.msi" 

#Download NDP46-TargetingPack-KB3045566.exe
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/NDP46-TargetingPack-KB3045566.exe -OutFile "C:\Sources\NDP46-TargetingPack-KB3045566.exe" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\NDP46-TargetingPack-KB3045566.exe" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\NDP46-TargetingPack-KB3045566.exe" 

#Download silverlight_4_sdk.exe
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/silverlight_4_sdk.exe -OutFile "C:\Sources\silverlight_4_sdk.exe" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\silverlight_4_sdk.exe" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\silverlight_4_sdk.exe" 

#Download Silverlight_4_Toolkit_April_2010.msi
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/Silverlight_4_Toolkit_April_2010.msi -OutFile "C:\Sources\Silverlight_4_Toolkit_April_2010.msi" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\Silverlight_4_Toolkit_April_2010.msi" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\Silverlight_4_Toolkit_April_2010.msi" 

#Download PivotViewer.en-us.msi
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/PivotViewer.en-us.msi -OutFile "C:\Sources\PivotViewer.en-us.msi" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\PivotViewer.en-us.msi" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\PivotViewer.en-us.msi" 

#Download Silverlight_x64.exe
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/Silverlight_x64.exe -OutFile "C:\Sources\Silverlight_x64.exe" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\Silverlight_x64.exe" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\Silverlight_x64.exe" 

#Download sdksetup.exe
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/sdksetup.exe -OutFile "C:\Sources\sdksetup.exe" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\sdksetup.exe" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\sdksetup.exe" 

#Download .NET 3.5
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/microsoft-windows-netfx3-ondemand-package.cab -OutFile "C:\Sources\microsoft-windows-netfx3-ondemand-package.cab" -UseBasicParsing  ; \
Install-WindowsFeature -Name NET-Framework-Features -Source C:\sources -Verbose ; \
Remove-Item "C:\Sources\microsoft-windows-netfx3-ondemand-package.cab" 

#Download SPDisposeCheck.msi
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/SPDisposeCheck.msi -OutFile "C:\Sources\SPDisposeCheck.msi" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\SPDisposeCheck.msi" -ArgumentList /qn ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\SPDisposeCheck.msi" 

#Download CATNETx32.msi
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/CATNETx32.msi -OutFile "C:\Sources\CATNETx32.msi" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\CATNETx32.msi" -ArgumentList /qn ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\CATNETx32.msi" 

#Download NDP461-DevPack-KB3105179-ENU.exe
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/NDP461-DevPack-KB3105179-ENU.exe -OutFile "C:\Sources\NDP461-DevPack-KB3105179-ENU.exe" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\NDP461-DevPack-KB3105179-ENU.exe" -ArgumentList /quiet, /norestart ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\NDP461-DevPack-KB3105179-ENU.exe" 

#Download silverlight_5_sdk.exe
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/silverlight_5_sdk.exe -OutFile "C:\Sources\silverlight_5_sdk.exe" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\silverlight_5_sdk.exe" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\silverlight_5_sdk.exe" 

#Download Silverlight_5_Toolkit_December_2011.msi
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/Silverlight_5_Toolkit_December_2011.msi -OutFile "C:\Sources\Silverlight_5_Toolkit_December_2011.msi" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\Silverlight_5_Toolkit_December_2011.msi" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\Silverlight_5_Toolkit_December_2011.msi" 

#Download NAnt
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/NAnt.zip -OutFile "$env:TEMP\NAnt.zip" -UseBasicParsing  ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "NAnt.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Program Files') ; \
Remove-Item "$env:TEMP\NAnt.zip" ; \
setx NAntHome 'C:\Program Files\NAnt\bin' ; \
setx DisableOutOfProcTaskHost 'true' 

#Download SP2010 assemblies and register in GAC
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/SP2010Assemblies.zip -OutFile "$env:TEMP\SP2010.zip" -UseBasicParsing ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "SP2010.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Sources') ; \
Remove-Item "$env:TEMP\SP2010.zip" ; \
CD C:\Sources\SP2010Assemblies ; \
.\collect.ps1 -Install

RUN CD C:\Sources\SP2010Assemblies\Files ; \
Get-ChildItem -File *.dll | Foreach {./gacutil.exe /i $_.fullname}

#Download SP2013
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/SP2013Assemblies.zip -OutFile "$env:TEMP\SP2013.zip" -UseBasicParsing  ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "SP2013.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Sources') ; \
Remove-Item "$env:TEMP\SP2013.zip" ; \
CD C:\Sources\SP2013Assemblies ; \
.\collect.ps1 -Install 

RUN CD C:\Sources\SP2013Assemblies\Files ; \
Get-ChildItem -File *.dll | Foreach {./gacutil.exe /i $_.fullname}

#Download Net 4.6.2 dev pack
RUN Invoke-WebRequest 'https://download.microsoft.com/download/E/F/D/EFD52638-B804-4865-BB57-47F4B9C80269/NDP462-DevPack-KB3151934-ENU.exe' -OutFile "C:\Sources\devpack.exe" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\devpack.exe" -ArgumentList /quiet ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\devpack.exe" 

# Register VS Test reference assemblies in GAC
RUN [System.Reflection.Assembly]::Load('System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a')  ; \
    $publish = New-Object System.EnterpriseServices.Internal.Publish ; \
    Get-ChildItem -File 'C:\Program Files (x86)\Microsoft Visual Studio\2017\TestAgent\Common7\IDE\ReferenceAssemblies\*.dll' -Recurse | Foreach { $publish.GacInstall($_.fullname) }

# Adding Microsoft.QualityTools.Testing.Fakes.ImportAfter.targets
RUN $fakesTargetsFileName = 'Microsoft.QualityTools.Testing.Fakes.ImportAfter.targets'; \
    $fakesTargetsFolder = 'C:\Program Files (x86)\MSBuild\14.0\Microsoft.Common.Targets\ImportAfter'; \
    $fakesTargetsFullFileName = Join-Path $fakesTargetsFolder $fakesTargetsFileName; \
    $fakesTargetsDownloadUrl = 'https://s3.amazonaws.com/skyvera-build-repo/Social+Deployment+Packages/Microsoft.QualityTools.Testing.Fakes.ImportAfter.targets'; \
    New-Item $fakesTargetsFolder -ItemType Directory > $null; \
    Invoke-WebRequest $fakesTargetsDownloadUrl -OutFile $fakesTargetsFullFileName;

# Install Open JDK
RUN [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; \
    Invoke-WebRequest https://github.com/ojdkbuild/ojdkbuild/releases/download/1.8.0.151-1/java-1.8.0-openjdk-1.8.0.151-1.b12.ojdkbuild.windows.x86_64.zip -OutFile openjdk.zip; \
    Expand-Archive openjdk.zip -DestinationPath $Env:ProgramFiles\Java; \
    Get-ChildItem -Path $Env:ProgramFiles\Java -Filter "java-*-openjdk*" | ForEach-Object {$_ | Rename-Item -NewName "OpenJDK" }; \
    Remove-Item -Force $Env:ProgramFiles\Java\OpenJDK\src.zip; \
    Remove-Item -Force openjdk.zip

# Install Git
RUN [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; \
    Invoke-WebRequest 'https://github.com/git-for-windows/git/releases/download/v2.17.1.windows.2/MinGit-2.17.1.2-64-bit.zip' -OutFile MinGit.zip; \
    Expand-Archive MinGit.zip -DestinationPath c:\MinGit; \
    Remove-Item -Force MinGit.zip

# Install ReportGenerator
RUN [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; \
    Invoke-WebRequest https://github.com/danielpalme/ReportGenerator/releases/download/v3.1.2.0/ReportGenerator_3.1.2.0.zip -OutFile ReportGenerator.zip; \
    Expand-Archive ReportGenerator.zip -DestinationPath c:\ReportGenerator; \
    Remove-Item -Force ReportGenerator.zip


# Download and install additional assemblies to GAC
RUN Invoke-WebRequest https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/SharePointGAC.zip -OutFile "$env:TEMP\SharePointGAC.zip" -UseBasicParsing  ; \
    New-Item -ItemType directory -Path 'C:\Program Files\Reference Assemblies\GAC' > $null; \
    Add-Type -assembly 'system.io.compression.filesystem' ; \
    $sourceZip =  Join-Path $env:TEMP "SharePointGAC.zip" ; \
    [io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\Program Files\Reference Assemblies\GAC') ; \
    [io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\temp\SharePointGAC') ; \
    Remove-Item "$env:TEMP\SharePointGAC.zip" ; \
    [System.Reflection.Assembly]::Load('System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a')  ; \
    $publish = New-Object System.EnterpriseServices.Internal.Publish ; \
    Get-ChildItem -File C:\temp\SharePointGAC\*.dll -Recurse | Foreach { $publish.GacInstall($_.fullname) } ; \
    Remove-Item C:\temp\SharePointGAC -Recurse


#Download NodeJS
RUN Invoke-WebRequest 'https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/node-v8.9.3-x64.msi' -OutFile "C:\Sources\NodeJS.msi" -UseBasicParsing  ; \
$setupProcess = Start-Process -PassThru -Wait -FilePath "C:\Sources\NodeJS.msi" -ArgumentList /q ; \
If($setupProcess.Exitcode -ne 0) {      Throw \"Errorlevel $($setupProcess.ExitCode)\" } ; \
Remove-Item "C:\Sources\NodeJS.msi" 


#Download TS-Client
RUN Invoke-WebRequest 'https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Windows/ts-cli.zip' -OutFile "$env:TEMP\TSClient.zip" -UseBasicParsing  ; \
Add-Type -assembly 'system.io.compression.filesystem' ; \
$sourceZip =  Join-Path $env:TEMP "TSClient.zip" ; \
[io.compression.zipfile]::ExtractToDirectory($sourceZip, 'C:\ts-client') ; \
Remove-Item "$env:TEMP\TSClient.zip" ; \
CD C:\ts-client ; \
npm install --production ; \
setx TS_USER 'epm.live.ci.service' ; \ 
setx TS_USERNAME 'epm.live.ci.service' ; \ 
setx TS_PASSWORD 'nhf7Kpacdp2fPteq' ; \ 
setx TS_API_KEY 'hm8qCcRjzp3ZWW3mPvXRf7gHsvkSBRAs47VHWvuD' ; \ 
setx TS_PRODUCT_ID '167' ; \ 
setx TS_REPO_ID '233' 


    
 
# Jenkins home
ENV JENKINS_HOME c:\\jenkins
RUN mkdir $env:JENKINS_HOME
WORKDIR $JENKINS_HOME

# PATH
RUN $path = $env:path + ';C:\Program Files (x86)\MSBuild\14.0\Bin\;c:\Program Files\Java\OpenJDK\bin\;c:\MinGit\cmd\'; Set-ItemProperty -Path 'HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Environment\' -Name Path -Value $path

COPY entrypoint.ps1 c:/entrypoint.ps1

ENTRYPOINT c:/entrypoint.ps1

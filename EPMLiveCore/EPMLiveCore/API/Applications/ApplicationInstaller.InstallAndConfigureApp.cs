using System;
using System.Diagnostics;
using System.Xml;
using EPMLiveCore.Infrastructure;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private void InstallAndConfigureApp()
        {
            var docFiles = new XmlDocument();
            docFiles.LoadXml("<Files/>");

            try
            {
                if (oAppList != null)
                {
                    var ndApp = appDef.ApplicationXml.FirstChild.SelectSingleNode("Application");

                    iProcessLI(ndApp);

                    addMessage(ErrorLevels.NoError, "Install Version", appDef.Version, 0);

                    Install(docFiles);                    

                    var processReports = false;

                    try
                    {
                        bool.TryParse(ndApp.Attributes["ProcessReports"].Value, out processReports);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }

                    _currentPercentSpan = 10;
                    _currentBasePercent = 90;

                    if (processReports)
                    {
                        ProcessReports(docFiles);
                    }

                    if (!bVerifyOnly)
                    {
                        CacheStore.Current.RemoveSafely(oWeb.Url, new CacheStoreCategory(oWeb).Navigation);
                        try
                        {
                            oListItem["InstallXML"] = appDef.ApplicationXml.OuterXml;
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                        }

                        oListItem.Update();
                    }
                }
                else
                {
                    if (!bVerifyOnly)
                    {
                        addMessage(ErrorLevels.Error, "Installing Application", "Unable to find Installed Applications List", 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                addMessage(ErrorLevels.Error, "Installing Application", "Exception: " + ex.Message, 0);
            }

            if (oListItem != null)
            {
                oListItem["InstalledFiles"] = docFiles.InnerXml;
            }
        }

        private void ProcessReports(XmlDocument docFiles)
        {
            if (bVerifyOnly)
            {
                addMessage(ErrorLevels.NoError, "Processing Reports", string.Empty, 0);
            }
            else
            {
                try
                {
                    Reporting.ProcessReportDataSources(oWeb, docFiles.OuterXml);

                    addMessage(ErrorLevels.NoError, "Processing Reports", string.Empty, 0);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    addMessage(ErrorLevels.Error, "Processing Reports", "Error: " + ex.Message, 0);
                }
            }
        }

        private void Install(XmlDocument docFiles)
        {
            if (!oWeb.IsRootWeb && !bIsInstalledElsewhere && !bVerifyOnly)
            {
                InstallOnRootWeb();
            }

            if (!bIsInstalledElsewhere)
            {
                _currentPercentSpan = 10;
                _currentBasePercent = 0;
                iInstallSolutions();
            }

            _currentPercentSpan = 10;
            _currentBasePercent = 10;
            InstallFeatures();

            _currentPercentSpan = 40;
            _currentBasePercent = 20;
            InstallLists();

            _currentPercentSpan = 10;
            _currentBasePercent = 60;
            InstallProperties();

            _currentPercentSpan = 10;
            _currentBasePercent = 70;
            docFiles.LoadXml(InstallFiles().OuterXml);

            if (appDef.Community != string.Empty && !bVerifyOnly)
            {
                try
                {
                    iCommunity = Applications.CreateCommunity(appDef.Community, oWeb);

                    oListItem["LinkedCommunity"] = iCommunity;

                    addMessage(ErrorLevels.NoError, "Creating Community", appDef.Community, 0);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    addMessage(ErrorLevels.Error, "Creating Community", "Error: " + ex.Message, 0);
                }
            }

            _currentPercentSpan = 10;
            _currentBasePercent = 80;
            iInstallQuickLaunch(docFiles);
        }
    }
}
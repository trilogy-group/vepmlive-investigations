using System;
using System.Collections;
using System.Diagnostics;
using System.Web.UI.WebControls.WebParts;
using EPMLiveCore.ApplicationStore;
using EPMLiveCore.WebPartsHelper;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using SPWebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private const string TempViewStorage = "TempViewStorage";

        private void InstallListsViewsWebPartsInstall(SPView spView, bool installGrid, AppStore appStore, int parentMessageId)
        {
            if (spView == null)
            {
                throw new ArgumentNullException(nameof(spView));
            }
            var fileView = oWeb.GetFile(spView.Url);

            if (fileView.Exists)
            {
                var fileUrl = $"{appDef.fullurl}/Lists/{spView.ParentList.Title}/{spView.Title}.txt";

                var hasViewFile = false;
                try
                {
                    byte[] fileBytes = appStore.GetFile(fileUrl);
                    if (fileBytes != null)
                    {
                        var folder = oWeb.GetFolder(TempViewStorage);

                        if (!folder.Exists)
                        {
                            folder = oWeb.Folders.Add(TempViewStorage);
                        }

                        if (!bVerifyOnly)
                        {
                            folder.Files.Add($"{spView.Title}.aspx", fileBytes);
                        }

                        hasViewFile = true;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }

                if (bVerifyOnly)
                {
                    if (hasViewFile || installGrid)
                    {
                        addMessage(0, spView.Title, string.Empty, parentMessageId);
                    }
                }
                else
                {
                    InstallListsViewsWebPartsInstall(spView.Title, installGrid, parentMessageId, fileView, hasViewFile);
                }
            }
        }

        private void InstallListsViewsWebPartsInstall(string viewTitle, bool installGrid, int arentMessageId, SPFile fileView, bool hasViewFile)
        {
            if (fileView == null)
            {
                throw new ArgumentNullException(nameof(fileView));
            }

            using (var viewWebManager = fileView.GetLimitedWebPartManager(PersonalizationScope.Shared))
            {
                if (hasViewFile)
                {
                    SPFile tempFile = null;
                    try
                    {
                        tempFile = oWeb.GetFile($"TempViewStorage/{viewTitle}.aspx");
                        var tempFileContents = tempFile.GetContents();
                        fileView.UpdateContentsAndSave(tempFileContents);

                        var tempFileWebManager = tempFile.GetLimitedWebPartManager(PersonalizationScope.Shared);

                        var arrWebParts = new ArrayList();

                        foreach (SPWebPart webPart in viewWebManager.WebParts)
                        {
                            if (webPart is XsltListViewWebPart)
                            {
                                webPart.Hidden = true;
                                viewWebManager.SaveChanges(webPart);
                            }

                            if (webPart.GetType().ToString() != "Microsoft.SharePoint.WebPartPages.ErrorWebPart" && !(webPart is XsltListViewWebPart))
                            {
                                arrWebParts.Add(webPart);
                            }
                        }

                        foreach (SPWebPart webPart in arrWebParts)
                        {
                            viewWebManager.DeleteWebPart(webPart);
                        }

                        foreach (SPWebPart webPart in tempFileWebManager.WebParts)
                        {
                            if (webPart.GetType().ToString() != "Microsoft.SharePoint.WebPartPages.ErrorWebPart" && !(webPart is XsltListViewWebPart))
                            {
                                viewWebManager.AddWebPart(webPart, webPart.ZoneID, webPart.ZoneIndex);
                            }
                        }

                        ApplicationInstallerHelpers.ConnectWebPartConsumersToReportFilter(viewWebManager);

                        addMessage(0, viewTitle, string.Empty, arentMessageId);
                    }
                    catch (Exception ex)
                    {
                        addMessage(ErrorLevels.Error, viewTitle, "Error: " + ex.Message, arentMessageId);
                        Trace.WriteLine(ex.ToString());
                    }
                    finally
                    {
                        tempFile?.Delete();
                        viewWebManager.Web.Dispose();
                    }
                }
                else
                {
                    InstallListsViewsWebPartsInstall(viewTitle, installGrid, arentMessageId, viewWebManager);
                }
            }
        }

        private void InstallListsViewsWebPartsInstall(string viewTitle, bool bInstallGrid, int parentMessageId, SPLimitedWebPartManager viewWebManager)
        {
            if (viewWebManager == null)
            {
                throw new ArgumentNullException(nameof(viewWebManager));
            }
            var hasGrid = false;

            try
            {
                if (bInstallGrid)
                {
                    foreach (var webPart in viewWebManager.WebParts)
                    {
                        if (webPart.GetType().ToString() == "EPMLiveWebParts.GridListView")
                        {
                            hasGrid = true;
                            break;
                        }
                    }

                    if (!hasGrid)
                    {
                        var webPart = WebPartsReflector.CreateGridListViewWebPart();
                        viewWebManager.AddWebPart(webPart, "Main", 0);
                    }
                }
                addMessage(0, viewTitle, string.Empty, parentMessageId);
            }
            catch (Exception ex)
            {
                addMessage(ErrorLevels.Error, viewTitle, "Error: " + ex.Message, parentMessageId);
                Trace.WriteLine(ex.ToString());
            }
            finally
            {
                viewWebManager.Web.Dispose();
            }
        }
    }
}
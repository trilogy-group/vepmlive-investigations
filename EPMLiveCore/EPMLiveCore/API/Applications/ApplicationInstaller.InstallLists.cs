using System;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Xml;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private void InstallLists()
        {
            var ndLists = appDef.ApplicationXml.FirstChild.SelectSingleNode("Lists");
            if (ndLists != null)
            {
                var parentMessageId = 0;

                if (bVerifyOnly)
                {
                    parentMessageId = addMessage(0, "Checking Lists", string.Empty, 0);
                }
                else
                {
                    parentMessageId = addMessage(0, "Installing Lists", string.Empty, 0);
                }

                var listNdLists = ndLists.SelectNodes("List");
                float max = listNdLists.Count;
                float counter = 0;

                foreach (XmlNode ndList in listNdLists)
                {
                    try
                    {
                        var sListName = ndList.Attributes["Name"].Value;

                        var bCanUpgrade = false;
                        bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndList, "CanUpgrade"), out bCanUpgrade);

                        var bAddReporting = false;
                        bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndList, "Reporting"), out bAddReporting);

                        var bDoesListExist = DoesListExist(sListName);

                        if (bDoesListExist)
                        {
                            var attrNoDelete = ndList.Attributes["NoDelete"];
                            if (attrNoDelete == null)
                            {
                                attrNoDelete = ndList.OwnerDocument.CreateAttribute("NoDelete");
                                attrNoDelete.Value = "True";
                                ndList.Attributes.Append(attrNoDelete);
                            }
                            else
                            {
                                attrNoDelete.Value = "True";
                            }
                        }

                        if (bDoesListExist && bCanUpgrade || !bDoesListExist)
                        {
                            InstallLists(parentMessageId, ndList, sListName, bCanUpgrade, bAddReporting, bDoesListExist);
                        }
                        else
                        {
                            addMessage(ErrorLevels.Error, sListName, "List exists and cannot upgrade", parentMessageId);
                        }
                    }
                    catch (Exception ex)
                    {
                        addMessage(ErrorLevels.Error, ndList.Attributes["Name"].Value, "Error: " + ex.Message, parentMessageId);
                        Trace.WriteLine(ex.ToString());
                    }

                    counter++;
                    var percent = counter / max;
                    updateLIPercent(percent);
                }
            }
        }

        private void InstallLists(int parentMessageId, XmlNode ndList, string sListName, bool bCanUpgrade, bool bAddReporting, bool bDoesListExist)
        {
            SPList oList = null;
            var listParentMessageId = 0;
            var bListAdded = false;
            if (bDoesListExist && bCanUpgrade)
            {
                listParentMessageId = addMessage(ErrorLevels.NoError, sListName, "List exists and will upgrade", parentMessageId);
            }
            else
            {
                try
                {
                    var error = string.Empty;
                    if (!bVerifyOnly)
                    {
                        oList = iInstallListsAddList(ndList, out error);
                        bListAdded = true;
                    }
                    if (string.IsNullOrWhiteSpace(error))
                    {
                        listParentMessageId = addMessage(ErrorLevels.NoError, sListName, string.Empty, parentMessageId);
                    }
                    else
                    {
                        listParentMessageId = addMessage(ErrorLevels.Error, sListName, error, parentMessageId);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }

            oList = oWeb.Lists.TryGetList(sListName);

            if (oList != null)
            {
                InstallListsFields(oList, ndList, listParentMessageId);
            }

            iInstallListsLookups(oList, ndList, listParentMessageId);
            InstallListsViews(oList, ndList, listParentMessageId);
            iInstallListsViewsWebparts(oList, ndList, listParentMessageId, bListAdded);
            iInstallListsWorkflows(oList, ndList, listParentMessageId, bListAdded);
            iInstallListsEvents(oList, ndList, listParentMessageId, bListAdded);
            iInstallListsItems(oList, ndList, listParentMessageId, bListAdded);

            if (bAddReporting)
            {
                AddReport(oList, listParentMessageId);
            }
        }

        private void AddReport(SPList oList, int listParentMessageId)
        {
            if (bVerifyOnly)
            {
                addMessage(ErrorLevels.NoError, "Add to Reporting Database", string.Empty, listParentMessageId);
            }
            else
            {
                try
                {
                    var reportingV2Enabled = false;
                    try
                    {
                        reportingV2Enabled = Convert.ToBoolean(CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "reportingV2"));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }

                    var reportBiz = new ReportBiz(oList.ParentWeb.Site.ID, oList.ParentWeb.ID, reportingV2Enabled);
                    var report = reportBiz.GetListBiz(oList.ID);

                    if (string.IsNullOrEmpty(report.ListName))
                    {
                        reportBiz.CreateListBiz(oList.ID);
                        addMessage(ErrorLevels.NoError, "Add to Reporting Database", string.Empty, listParentMessageId);
                    }
                }
                catch (Exception ex)
                {
                    addMessage(ErrorLevels.Error, "Add to Reporting Database", ex.Message, listParentMessageId);
                    Trace.WriteLine(ex.ToString());
                }
            }
        }
    }
}
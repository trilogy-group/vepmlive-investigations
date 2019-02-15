using System;
using System.Collections;
using System.Diagnostics;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private void iInstallQuickLaunch(XmlNode docFiles)
        {
            var appNod = appDef.ApplicationXml.FirstChild.SelectSingleNode("Application");

            if (appNod != null)
            {
                var ndQuickLaunch = appNod.SelectSingleNode("QuickLaunch");
                var ndTopNav = appNod.SelectSingleNode("TopNav");

                if (ndQuickLaunch != null || ndTopNav != null)
                {
                    var NavParentMessageId = 0;

                    if (bVerifyOnly)
                    {
                        NavParentMessageId = addMessage(0, "Checking Navigation", string.Empty, 0);
                    }
                    else
                    {
                        NavParentMessageId = addMessage(0, "Installing Navigation", string.Empty, 0);
                    }

                    float max = 0;
                    XmlNodeList ndTopNavItems = null;
                    XmlNodeList ndQuickLaunchItems = null;
                    try
                    {
                        ndQuickLaunchItems = ndQuickLaunch.SelectNodes("Item");
                        max += ndQuickLaunchItems.Count;
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }
                    try
                    {
                        ndTopNavItems = ndTopNav.SelectNodes("Item");
                        max += ndTopNavItems.Count;
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }

                    float counter = 0;

                    var arrTopNavNavNodes = new ArrayList();
                    var arrQuickLaunchNavNodes = new ArrayList();

                    if (ndQuickLaunch != null)
                    {
                        var ParentMessageId = addMessage(0, "QuickLaunch", string.Empty, NavParentMessageId);

                        counter = iInstallNavigationItem(oWeb.Navigation.QuickLaunch, ndQuickLaunchItems, ParentMessageId, docFiles, counter, max,
                            "QuickLaunch", null, ref arrQuickLaunchNavNodes);
                    }

                    if (ndTopNav != null)
                    {
                        var ParentMessageId = addMessage(0, "TopNav", string.Empty, NavParentMessageId);

                        counter = iInstallNavigationItem(oWeb.Navigation.TopNavigationBar, ndTopNavItems, ParentMessageId, docFiles, counter, max,
                            "TopNav", null, ref arrTopNavNavNodes);
                    }
                    //}

                    if (!bVerifyOnly)
                    {
                        if (iCommunity != 0)
                        {
                            var oLiCommunity = oAppList.GetItemById(iCommunity);

                            var arrCurQuickLaunch = new ArrayList();
                            var arrCurTopNav = new ArrayList();
                            try
                            {
                                arrCurQuickLaunch = new ArrayList(oLiCommunity["QuickLaunch"].ToString().Split(','));
                            }
                            catch (Exception ex)
                            {
                                Trace.WriteLine(ex.ToString());
                            }
                            try
                            {
                                arrCurTopNav = new ArrayList(oLiCommunity["TopNav"].ToString().Split(','));
                            }
                            catch (Exception ex)
                            {
                                Trace.WriteLine(ex.ToString());
                            }

                            arrCurQuickLaunch.AddRange(arrQuickLaunchNavNodes);
                            arrCurTopNav.AddRange(arrTopNavNavNodes);


                            oLiCommunity["QuickLaunch"] = string.Join(",", (string[])arrCurQuickLaunch.ToArray(typeof(string)));
                            oLiCommunity["TopNav"] = string.Join(",", (string[])arrCurTopNav.ToArray(typeof(string)));
                            oLiCommunity.Update();

                            Applications.CreateQuickLaunchXML(oLiCommunity.ID, oWeb);
                            Applications.CreateTopNavXML(oLiCommunity.ID, oWeb);
                        }
                        else
                        {
                            oListItem["QuickLaunch"] = string.Join(",", (string[])arrQuickLaunchNavNodes.ToArray(typeof(string)));
                            oListItem["TopNav"] = string.Join(",", (string[])arrTopNavNavNodes.ToArray(typeof(string)));
                            oListItem.Update();

                            Applications.CreateQuickLaunchXML(oListItem.ID, oWeb);
                            Applications.CreateTopNavXML(oListItem.ID, oWeb);
                        }
                    }
                }
            }
        }

       private string iInstallPropertiesGet(string sPropertyName, bool bLockWeb)
        {
            if (bLockWeb)
            {
                return CoreFunctions.getLockConfigSetting(oWeb, sPropertyName, false);
            }
            return CoreFunctions.getConfigSetting(oWeb, sPropertyName);
        }

        private void iInstallPropertiesSet(string sPropertyName, string sPropertyValue, bool bLockWeb)
        {
            if (bLockWeb)
            {
                var lWeb = CoreFunctions.getLockedWeb(oWeb);
                using (var tWeb = oWeb.Site.OpenWeb(lWeb))
                {
                    CoreFunctions.setConfigSetting(tWeb, sPropertyName, sPropertyValue);
                }
            }
            else
            {
                CoreFunctions.setConfigSetting(oWeb, sPropertyName, sPropertyValue);
            }
        }

        private bool DoesListExist(string name)
        {
            var list = oWeb.Lists.TryGetList(name);
            return list != null;
        }

        private SPList iInstallListsAddList(XmlNode ndList, out string error)
        {
            error = string.Empty;
            SPList list = null;
            try
            {
                var sFileName = ApplicationInstallerHelpers.getAttribute(ndList, "FileName");
                var sTemplate = ApplicationInstallerHelpers.getAttribute(ndList, "Template");
                var sListName = ApplicationInstallerHelpers.getAttribute(ndList, "Name");
                var sDescription = ApplicationInstallerHelpers.getAttribute(ndList, "Description");
                var lists = (SPDocumentLibrary)oWeb.Site.GetCatalog(SPListTemplateType.ListTemplateCatalog);

                if (sFileName != string.Empty)
                {
                    foreach (SPListTemplate template in oWeb.Site.GetCustomListTemplates(oWeb))
                    {
                        if (template.InternalName == sFileName)
                        {
                            var gList = oWeb.Lists.Add(sListName, sDescription, template);
                            list = oWeb.Lists[gList];
                            break;
                        }
                    }
                }
                else if (sTemplate != string.Empty)
                {
                    var gList = oWeb.Lists.Add(sListName, sDescription, ApplicationInstallerHelpers.GetTemplateType(sTemplate));
                    list = oWeb.Lists[gList];
                }
                else
                {
                    error = "List FileName or Template property not found";
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                error = "Error: " + ex.Message;
            }

            return list;
        }

        private void iInstallListsItems(SPList list, XmlNode ndList, int ParentMessageId, bool added)
        {
            var ndItems = ndList.SelectSingleNode("Items");

            if (ndItems != null)
            {
                if (bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Items", string.Empty, ParentMessageId);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Installing Items", string.Empty, ParentMessageId);
                }

                foreach (XmlNode ndItem in ndItems.SelectNodes("Item"))
                {
                    oWeb.AllowUnsafeUpdates = true;

                    var sTitle = string.Empty;
                    try
                    {
                        sTitle = ndItem.SelectSingleNode("Field[@Name='Title']").InnerText;
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }
                    if (sTitle == string.Empty)
                    {
                        try
                        {
                            sTitle = ndItem.FirstChild.InnerText;
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                        }
                    }

                    if (sTitle != string.Empty)
                    {
                        if (bVerifyOnly)
                        {
                            addMessage(0, sTitle, string.Empty, ParentMessageId);
                        }
                        else
                        {
                            try
                            {
                                var li = list.Items.Add();

                                foreach (XmlNode ndField in ndItem.SelectNodes("Field"))
                                {
                                    li[ndField.Attributes["Name"].Value] = ndField.InnerText;
                                }

                                li.Update();

                                addMessage(0, sTitle, string.Empty, ParentMessageId);
                            }
                            catch (Exception ex)
                            {
                                Trace.WriteLine(ex.ToString());
                                addMessage(ErrorLevels.Error, sTitle, "Error: " + ex.Message, ParentMessageId);
                            }
                        }
                    }
                }
            }
        }

        private void iInstallListsEvents(SPList list, XmlNode ndList, int ParentMessageId, bool added)
        {
            var ndEventHandlers = ndList.SelectSingleNode("EventHandlers");

            if (ndEventHandlers != null)
            {
                if (bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Event Handlers", string.Empty, ParentMessageId);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Installing Event Handlers", string.Empty, ParentMessageId);
                }

                var ndParent = ndList.ParentNode;

                foreach (XmlNode ndEventHandler in ndEventHandlers.SelectNodes("EventHandler"))
                {
                    var sType = ApplicationInstallerHelpers.getAttribute(ndEventHandler, "Type");
                    var sAssembly = ApplicationInstallerHelpers.getAttribute(ndEventHandler, "Assembly");
                    var sClass = ApplicationInstallerHelpers.getAttribute(ndEventHandler, "Class");
                    var oType = CoreFunctions.iGetListEventType(sType);

                    if (oType != SPEventReceiverType.InvalidReceiver)
                    {
                        if (bVerifyOnly)
                        {
                            addMessage(0, sType + "(" + sClass + ")", string.Empty, ParentMessageId);
                        }
                        else
                        {
                            var found = false;
                            foreach (SPEventReceiverDefinition oRecDef in list.EventReceivers)
                            {
                                if (oRecDef.Type == oType && oRecDef.Assembly.ToLower() == sAssembly.ToLower() &&
                                    oRecDef.Class.ToLower() == oRecDef.Class.ToLower())
                                {
                                    found = true;
                                    addMessage(ErrorLevels.Upgrade, sType + "(" + sClass + ")", "Event found, skipped", ParentMessageId);
                                    break;
                                }
                            }

                            if (!found)
                            {
                                list.EventReceivers.Add(oType, sAssembly, sClass);

                                addMessage(0, sType + "(" + sClass + ")", string.Empty, ParentMessageId);
                            }
                        }
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, sType + "(" + sClass + ")", "Invalid receiver type", ParentMessageId);
                    }
                }
            }
        }

        private void iInstallListsWorkflowsInstall(SPList oList, string sName, string sDisplayName, SPList oTaskList, SPList oHistoryList,
            XmlNode ndWorkflow)
        {
            SPWorkflowAssociation assocation = null;

            var bAllowManual = false;
            bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndWorkflow, "AllowManual"), out bAllowManual);

            var bStartOnCreate = false;
            bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndWorkflow, "StartOnCreate"), out bStartOnCreate);

            var bStartOnChange = false;
            bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndWorkflow, "StartOnChange"), out bStartOnChange);


            foreach (SPWorkflowTemplate template in oWeb.WorkflowTemplates)
            {
                if (template.Name == sName)
                {
                    assocation = SPWorkflowAssociation.CreateListAssociation(template, sDisplayName, oTaskList, oHistoryList);
                    break;
                }
            }
            if (assocation != null)
            {
                assocation.AllowManual = bAllowManual;
                assocation.AutoStartChange = bStartOnChange;
                assocation.AutoStartCreate = bStartOnCreate;
                oList.WorkflowAssociations.Add(assocation);
            }
        }

        private void iInstallListsWorkflows(SPList list, XmlNode ndList, int ParentMessageId, bool added)
        {
            var ndWorkflows = ndList.SelectSingleNode("Workflows");

            if (ndWorkflows != null)
            {
                if (bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Workflows", string.Empty, ParentMessageId);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Updating Workflows", string.Empty, ParentMessageId);
                }

                var ndParent = ndList.ParentNode;

                foreach (XmlNode ndWorkflow in ndWorkflows.SelectNodes("Workflow"))
                {
                    var sName = ApplicationInstallerHelpers.getAttribute(ndWorkflow, "Name");

                    var sDisplayName = ApplicationInstallerHelpers.getAttribute(ndWorkflow, "DisplayName");
                    if (sDisplayName == string.Empty)
                    {
                        sDisplayName = sName;
                    }

                    if (sName != string.Empty)
                    {
                        try
                        {
                            var sTaskList = ApplicationInstallerHelpers.getAttribute(ndWorkflow, "TaskList");
                            if (sTaskList == string.Empty)
                            {
                                sTaskList = "Workflow Tasks";
                            }

                            var sHistoryList = ApplicationInstallerHelpers.getAttribute(ndWorkflow, "HistoryList");
                            if (sHistoryList == string.Empty)
                            {
                                sHistoryList = "Workflow History";
                            }

                            var bOverwrite = false;
                            bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndWorkflow, "Overwrite"), out bOverwrite);

                            var oTaskList = oWeb.Lists.TryGetList(sTaskList);
                            var oHistoryList = oWeb.Lists.TryGetList(sHistoryList);

                            if (oTaskList != null || (IsListInstalledWithApplication(sTaskList) && bVerifyOnly))
                            {
                                if (oHistoryList != null || (IsListInstalledWithApplication(sHistoryList) && bVerifyOnly))
                                {
                                    if (bVerifyOnly)
                                    {
                                        var found = false;
                                        if (list != null)
                                        {
                                            foreach (SPWorkflowAssociation association in list.WorkflowAssociations)
                                            {
                                                if (association.BaseTemplate.Name == sName)
                                                {
                                                    found = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (found && !bOverwrite)
                                        {
                                            addMessage(ErrorLevels.Error, sName, "Workflow found and cannot overwrite", ParentMessageId);
                                        }
                                        else if (found)
                                        {
                                            addMessage(ErrorLevels.Upgrade, sName, "Workflow found and will upgrade", ParentMessageId);
                                        }
                                        else
                                        {
                                            addMessage(ErrorLevels.NoError, sName, string.Empty, ParentMessageId);
                                        }
                                    }
                                    else
                                    {
                                        SPWorkflowAssociation association = null;

                                        var found = false;

                                        foreach (SPWorkflowAssociation oassociation in list.WorkflowAssociations)
                                        {
                                            if (oassociation.BaseTemplate.Name == sName)
                                            {
                                                association = oassociation;
                                                found = true;
                                                break;
                                            }
                                        }

                                        if (found && bOverwrite)
                                        {
                                            found = false;
                                            list.WorkflowAssociations.Remove(association);

                                            iInstallListsWorkflowsInstall(list, sName, sDisplayName, oTaskList, oHistoryList, ndWorkflow);

                                            addMessage(ErrorLevels.Upgrade, sName, "Workflow found and was upgraded", ParentMessageId);
                                        }
                                        else if (found)
                                        {
                                            addMessage(ErrorLevels.Error, sName, "Workflow found and could not overwrite", ParentMessageId);
                                        }
                                        else
                                        {
                                            iInstallListsWorkflowsInstall(list, sName, sDisplayName, oTaskList, oHistoryList, ndWorkflow);

                                            addMessage(ErrorLevels.NoError, sName, string.Empty, ParentMessageId);
                                        }
                                    }
                                }
                                else
                                {
                                    addMessage(ErrorLevels.Error, sName, "Workflow history list (" + sHistoryList + ") does not exist",
                                        ParentMessageId);
                                }
                            }
                            else
                            {
                                addMessage(ErrorLevels.Error, sName, "Workflow task list (" + sTaskList + ") does not exist", ParentMessageId);
                            }
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                            addMessage(ErrorLevels.Error, sName, "Error: " + ex.Message, ParentMessageId);
                        }
                    }
                }
            }
        }
    }
}
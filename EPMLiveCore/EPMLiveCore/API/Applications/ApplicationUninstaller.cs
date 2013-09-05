using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Navigation;
using System.Collections;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using System.Data.SqlClient;

namespace EPMLiveCore.API
{
    internal class ApplicationUninstaller
    {
        private enum ErrorLevels
        {
            NoError = 0, Upgrade = 1, Skip = 2, Warning = 5, Error = 10
        }

        private string _id;
        private int _maxErrorLevel = 0;
        private DataTable _dtMessages = new DataTable();
        private int _MessageId = 0;
        private SqlConnection _cn;
        private float _lastPercent = 0;
        private EPMLiveCore.Jobs.Applications.Uninstall _configJob;

        private bool bIsInstalledElsewhere = false;
        private bool bVerifyOnly = true;
        private SPWeb oWeb = null;
        private API.ApplicationDef appDef;
        private SPListItem oListItem;

        private float _currentBasePercent = 0;
        private float _currentPercentSpan = 10;

        public ApplicationUninstaller(string id, SqlConnection cn, EPMLiveCore.Jobs.Applications.Uninstall configJob)
        {
            _id = id;
            _cn = cn;
            _configJob = configJob;

            _dtMessages.Columns.Add(new DataColumn("ID", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("ParentID", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("ErrorLevel", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("Message", typeof(string)));
            _dtMessages.Columns.Add(new DataColumn("Details", typeof(string)));
            _dtMessages.Columns.Add(new DataColumn("Tabbing", typeof(string)));
        }

        private bool CheckPermissions()
        {
            bool bHasPerms = false;

            if(bIsInstalledElsewhere)
            {
                SPUser oUser = oWeb.CurrentUser;
                try
                {
                    oUser = oWeb.AllUsers.GetByID(_configJob.userid);
                }
                catch { }
                try
                {
                    using(SPSite tempSite = new SPSite(oWeb.Site.ID, oUser.UserToken))
                    {
                        tempSite.CatchAccessDeniedException = false;
                        using(SPWeb tempWeb = tempSite.OpenWeb(oWeb.ID))
                        {
                            if(tempWeb.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
                                bHasPerms = true;
                        }
                    }
                }
                catch { }

                if(bHasPerms)
                {
                    addMessage(ErrorLevels.NoError, "Permissions Check", "", 0);
                }
                else
                {
                    addMessage(ErrorLevels.Error, "Permissions Check", "You do not have Manage Web permissions", 0);
                }
            }
            else
            {

                bool bHasSolutions = false;

                try
                {
                    XmlNode ndSolutions = appDef.ApplicationXml.FirstChild.SelectSingleNode("Solutions");
                    if(ndSolutions.ChildNodes.Count > 0)
                        bHasSolutions = true;
                }
                catch { }

                if(bHasSolutions)
                {
                    if(oWeb.CurrentUser.IsSiteAdmin)
                    {
                        addMessage(ErrorLevels.NoError, "Permissions Check", "", 0);
                        bHasPerms = true;
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, "Permissions Check", "You are not a site collection administrator", 0);
                    }
                }
                else
                {

                    SPUser oUser = oWeb.CurrentUser;
                    try
                    {
                        oUser = oWeb.AllUsers.GetByID(_configJob.userid);
                    }
                    catch { }

                    try
                    {
                        using(SPSite tempSite = new SPSite(oWeb.Site.ID, oUser.UserToken))
                        {
                            tempSite.CatchAccessDeniedException = false;
                            using(SPWeb tempWeb = tempSite.OpenWeb(oWeb.ID))
                            {
                                if(tempWeb.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
                                    bHasPerms = true;
                            }
                        }
                    }
                    catch { }

                    if(bHasPerms)
                    {
                        addMessage(ErrorLevels.NoError, "Permissions Check", "", 0);
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, "Permissions Check", "You do not have Manage Web permissions", 0);
                    }
                }
            }

            return bHasPerms;
        }

        private bool CheckWhereInstalled()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(oWeb.Site.ID))
                {
                    using(SPWeb root = site.OpenWeb())
                    {
                        SPSiteDataQuery query = new SPSiteDataQuery();
                        query.Lists = "<Lists ServerTemplate='23413'></Lists>";
                        query.Query = "<Where><And><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + appDef.Id + "</Value></Eq><Eq><FieldRef Name='Status' /><Value Type='Text'>Installed</Value></Eq></And></Where>";
                        query.Webs = "<Webs Scope='SiteCollection'/>";

                        DataTable dtApps = oWeb.GetSiteData(query);

                        foreach(DataRow dr in dtApps.Rows)
                        {
                            if(new Guid(dr["WebId"].ToString()) != oWeb.ID)
                            {
                                bIsInstalledElsewhere = true;
                            }
                        }

                        if(bIsInstalledElsewhere)
                        {
                            addMessage(ErrorLevels.Upgrade, "Application Uninstall", "Application is installed somewhere else and will remove from this site only.", 0);
                        }
                    }
                }
            });

            return true;
        }

        private bool CheckForPreReqs()
        {
            //TODO: check for items that have this item as a pre-req
            return true;
        }

        public void UninstallApp(bool verifyonly, SPWeb web)
        {
            bVerifyOnly = verifyonly;
            oWeb = web;
            appDef = API.Applications.GetApplicationInfoFromList(oWeb, _id);
            
            CheckWhereInstalled();

            if(CheckPermissions())
            {
                if(CheckForPreReqs())
                {
                    iUninstallAndConfigureApp();
                }                
            }
        }

        private bool CanDelete(XmlNode nd)
        {
            string NoDelete = getAttribute(nd, "NoDelete");

            if(NoDelete.ToLower() == "true")
                return false;

            return true;
        }

        public static string getAttribute(XmlNode nd, string attribute)
        {
            try
            {
                return nd.Attributes[attribute].Value;
            }
            catch { return ""; }

        }

        #region solutions and lists

        private void iUninstallListTemplate(XmlNode ndSolution, int ParentMessageId)
        {
            try
            {
                SPDocumentLibrary solutions = (SPDocumentLibrary)oWeb.Site.GetCatalog(SPListTemplateType.ListTemplateCatalog);

                string FileName = getAttribute(ndSolution, "FileName");

                if(bVerifyOnly)
                {
                    bool found = false;

                    foreach(SPFile f in solutions.RootFolder.Files)
                    {
                        if(f.Name == FileName)
                        {
                            found = true;
                        }
                    }

                    if(found)
                    {
                        addMessage(ErrorLevels.NoError, FileName, "", ParentMessageId);
                    }
                    else
                        addMessage(ErrorLevels.Skip, FileName, "File not found", ParentMessageId);
                }
                else
                {

                    bool found = false;
                    SPFile foundFile = null;
                    foreach(SPFile f in solutions.RootFolder.Files)
                    {
                        if(f.Name == FileName)
                        {
                            foundFile = f;
                            found = true;
                        }
                    }

                    if(found)
                    {
                        foundFile.Delete();
                        addMessage(ErrorLevels.NoError, FileName, "", ParentMessageId);
                    }
                    else
                    {
                        addMessage(ErrorLevels.Skip, FileName, "File not found", ParentMessageId);
                    }
                }
            }
            catch(Exception ex)
            {
                addMessage(ErrorLevels.Error, getAttribute(ndSolution, "FileName"), "Error: " + ex.Message, ParentMessageId);
            }


        }

        private void iUninstallSolution(XmlNode ndSolution, int ParentMessageId)
        {
            try
            {
                SPDocumentLibrary solutions = (SPDocumentLibrary)oWeb.Site.GetCatalog(SPListTemplateType.SolutionCatalog);

                string FileName = getAttribute(ndSolution, "FileName");

                if(bVerifyOnly)
                {
                    bool found = false;

                    foreach(SPFile f in solutions.RootFolder.Files)
                    {
                        if(f.Name == FileName)
                        {
                            found = true;
                        }
                    }

                    if(found)
                    {
                        addMessage(ErrorLevels.NoError, FileName, "", ParentMessageId);
                    }
                    else
                        addMessage(ErrorLevels.Skip, FileName, "File not found", ParentMessageId);
                }
                else
                {

                    bool found = false;
                    SPFile foundFile = null;
                    foreach(SPFile f in solutions.RootFolder.Files)
                    {
                        if(f.Name == FileName)
                        {
                            foundFile = f;
                            found = true;
                        }
                    }

                    if(found)
                    {
                        foreach(SPUserSolution us in oWeb.Site.Solutions)
                        {
                            if(us.Name == FileName)
                            {
                                oWeb.Site.Solutions.Remove(us);
                                break;
                            }
                        }

                        foundFile.Delete();

                        addMessage(ErrorLevels.NoError, FileName, "", ParentMessageId);
                    }
                    else
                    {
                        addMessage(ErrorLevels.Skip, FileName, "File not found", ParentMessageId);
                    }
                }
            }
            catch(Exception ex)
            {
                addMessage(ErrorLevels.Error, getAttribute(ndSolution, "FileName"), "Error: " + ex.Message, ParentMessageId);
            }
        }

        private void iUninstallSolutions()
        {
            XmlNode ndSolutions = appDef.ApplicationXml.FirstChild.SelectSingleNode("Solutions");
            int ParentMessageId = 0;

            if(ndSolutions != null)
            {
                if(bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Solutions and Lists", "", 0);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Uninstalling Solutions and Lists", "", 0);
                }

                float percent = 0;

                XmlNodeList ListNdSolutions = ndSolutions.ChildNodes;
                float max = ListNdSolutions.Count;
                float counter = 0;

                foreach(XmlNode ndSolution in ListNdSolutions)
                {
                    if(CanDelete(ndSolution))
                    {
                        switch(ndSolution.Name)
                        {
                            case "Solution":
                                iUninstallSolution(ndSolution, ParentMessageId);
                                break;
                            case "ListTemplate":
                                iUninstallListTemplate(ndSolution, ParentMessageId);
                                break;
                        }
                    }
                    else
                    {
                        addMessage(ErrorLevels.Skip, getAttribute(ndSolution, "FileName"), "File will not delete", ParentMessageId);
                    }
                    counter++;
                    percent = counter / max;
                    updateLIPercent(percent);
                }
            }
        }
        #endregion

        #region Lists
        private void iUninstallLists()
        {

            XmlNode ndLists = appDef.ApplicationXml.FirstChild.SelectSingleNode("Lists");
            if(ndLists != null)
            {
                int ParentMessageId = 0;

                if(bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Lists", "", 0);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Uninstalling Lists", "", 0);
                }

                float percent = 0;

                XmlNodeList ListNdLists = ndLists.SelectNodes("List");
                float max = ListNdLists.Count;
                float counter = 0;
                int ListParentMessageId = 0;

                foreach(XmlNode ndList in ListNdLists)
                {
                    bool bAddReporting = false;
                    bool.TryParse(getAttribute(ndList, "Reporting"), out bAddReporting);

                    string sListName = getAttribute(ndList, "Name");

                    bool bDeleted = false;
                    if(CanDelete(ndList))
                    {
                        bDeleted = true;

                        try
                        {

                            SPList oList = oWeb.Lists.TryGetList(sListName);

                            if(oList != null)
                            {
                                if(bAddReporting)
                                {
                                    if(bVerifyOnly)
                                    {
                                        addMessage(ErrorLevels.NoError, "Remove From Reporting Database", "", ListParentMessageId);
                                    }
                                    else
                                    {
                                        try
                                        {
                                            var reportBiz = new EPMLiveReportsAdmin.ReportBiz(oList.ParentWeb.Site.ID);
                                            EPMLiveReportsAdmin.EPMData _DAO = new EPMLiveReportsAdmin.EPMData(oList.ParentWeb.Site.ID);
                                            _DAO.Command = "SELECT TableName FROM RPTList WHERE RPTListID=@RPTListID";
                                            _DAO.AddParam("@RPTListID", oList.ID);
                                            string sTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection).ToString();
                                            DataTable refTables = reportBiz.GetReferencingTables(_DAO, sTableName);
                                            if(refTables.Rows.Count == 0)
                                            {
                                                reportBiz.GetListBiz(oList.ID).Delete();
                                            }
                                            addMessage(ErrorLevels.NoError, "Remove (" + sListName + ") From Reporting Database", "", ListParentMessageId);
                                        }
                                        catch(Exception ex)
                                        {
                                            addMessage(ErrorLevels.Error, "Remove (" + sListName + ") From Reporting Database", ex.Message, ListParentMessageId);
                                        }
                                    }
                                }

                                if(!bVerifyOnly)
                                    oList.Delete();
                                    
                                addMessage(ErrorLevels.NoError, sListName, "", ParentMessageId);
                            }
                            else
                            {
                                addMessage(ErrorLevels.Skip, getAttribute(ndList, "Name"), "List does not exist", ParentMessageId);
                            }
                        }
                        catch(Exception ex)
                        {
                            addMessage(ErrorLevels.Error, getAttribute(ndList, "Name"), "Error: " + ex.Message, ParentMessageId);
                        }
                    }
                    else
                    {
                        ListParentMessageId = addMessage(ErrorLevels.Skip, getAttribute(ndList, "Name"), "List will not delete", ParentMessageId);
                    }

                    if(!bDeleted)
                    {

                        SPList oList = oWeb.Lists.TryGetList(sListName);

                        if(oList != null)
                        {
                            iUninstallListsFields(oList, ndList, ListParentMessageId);
                            iUninstallListsLookups(oList, ndList, ListParentMessageId);
                            iUninstallListsViews(oList, ndList, ListParentMessageId);
                            //iUninstallListsViewsWebparts(oList, ndList, ListParentMessageId, bListAdded);
                            iUninstallListsWorkflows(oList, ndList, ListParentMessageId);
                            iUninstallListsEvents(oList, ndList, ListParentMessageId);
                            iUninstallListsItems(oList, ndList, ListParentMessageId);

                        }
                    }
                    counter++;
                    percent = counter / max;
                    updateLIPercent(percent);
                }

            }
        }

        private void iUninstallListsLookups(SPList list, XmlNode ndList, int ParentMessageId)
        {
            XmlNode ndParent = ndList.ParentNode;

            XmlNode ndLookups = ndList.SelectSingleNode("Lookups");

            if(ndLookups != null)
            {
                if(bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Lookups", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Uninstalling Lookups", "", ParentMessageId);

                foreach(XmlNode ndLookup in ndLookups.SelectNodes("Lookup"))
                {
                    string sInternalName = getAttribute(ndLookup, "InternalName");

                    try
                    {

                        if(CanDelete(ndLookup))
                        {

                            SPField oField = null;
                            try
                            {
                                oField = list.Fields.GetFieldByInternalName(sInternalName);
                            }
                            catch { }
                            if(oField != null)
                            {
                                if(!bVerifyOnly)
                                    oField.Delete();

                                addMessage(ErrorLevels.NoError, sInternalName, "", ParentMessageId);
                            }
                            else
                            {
                                addMessage(ErrorLevels.Skip, sInternalName, "Lookup will not delete", ParentMessageId);
                            }
                        }
                        else
                        {
                            addMessage(ErrorLevels.Skip, sInternalName, "Lookup will not delete", ParentMessageId);
                        }
                    }
                    catch(Exception ex)
                    {
                        addMessage(ErrorLevels.Error, sInternalName, "Error processing: " + ex.Message, ParentMessageId);
                    }
                }

            }
        }

        private void iUninstallListsItems(SPList list, XmlNode ndList, int ParentMessageId)
        {
            XmlNode ndItems = ndList.SelectSingleNode("Items");

            if(ndItems != null)
            {
                if(bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Items", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Uninstalling Items", "", ParentMessageId);

                foreach(XmlNode ndItem in ndItems.SelectNodes("Item"))
                {
                    
                    oWeb.AllowUnsafeUpdates = true;

                    string sTitle = "";
                    try
                    {
                        sTitle = ndItem.SelectSingleNode("Field[@Name='Title']").InnerText;
                    }
                    catch { }
                    if(sTitle == "")
                    {
                        try
                        {
                            sTitle = ndItem.FirstChild.InnerText;
                        }
                        catch { }
                    }

                    if(sTitle != "")
                    {
                        if(CanDelete(ndItem))
                        {
                            if(bVerifyOnly)
                            {
                                addMessage(0, sTitle, "", ParentMessageId);
                            }
                            else
                            {
                                try
                                {

                                    SPQuery query = new SPQuery();
                                    query.Query = "<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + sTitle + "</Value></Eq></Where>";
                                    SPListItemCollection lic = list.GetItems(query);

                                    if(lic.Count > 0)
                                    {
                                        lic[0].Recycle();
                                        addMessage(0, sTitle, "", ParentMessageId);
                                    }
                                    else
                                    {
                                        addMessage(ErrorLevels.Skip, sTitle, "Item not found, skipped", ParentMessageId);
                                    }
                                    
                                }
                                catch(Exception ex)
                                {
                                    addMessage(ErrorLevels.Error, sTitle, "Error: " + ex.Message, ParentMessageId);
                                }
                            }
                        }
                        else
                        {
                            addMessage(ErrorLevels.Skip, sTitle, "Item will not delete", ParentMessageId);
                        }
                    }

                }
            }
        }

        private void iUninstallListsEvents(SPList list, XmlNode ndList, int ParentMessageId)
        {
            XmlNode ndEventHandlers = ndList.SelectSingleNode("EventHandlers");

            if(ndEventHandlers != null)
            {
                if(bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Event Handlers", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Uninstalling Event Handlers", "", ParentMessageId);

                XmlNode ndParent = ndList.ParentNode;

                foreach(XmlNode ndEventHandler in ndEventHandlers.SelectNodes("EventHandler"))
                {
                    
                    string sType = getAttribute(ndEventHandler, "Type");
                    string sAssembly = getAttribute(ndEventHandler, "Assembly");
                    string sClass = getAttribute(ndEventHandler, "Class");

                    try
                    {
                        if(CanDelete(ndEventHandler))
                        {
                            SPEventReceiverType oType = CoreFunctions.iGetListEventType(sType);
                            if(oType != SPEventReceiverType.InvalidReceiver)
                            {
                                bool found = false;

                                foreach(SPEventReceiverDefinition oRecDef in list.EventReceivers)
                                {
                                    if(oRecDef.Type == oType && oRecDef.Assembly.ToLower() == sAssembly.ToLower() && oRecDef.Class.ToLower() == oRecDef.Class.ToLower())
                                    {
                                        found = true;
                                        if(!bVerifyOnly)
                                            oRecDef.Delete();
                                        break;
                                    }
                                }

                                if(found)
                                {
                                    addMessage(ErrorLevels.NoError, sType + "(" + sClass + ")", "", ParentMessageId);
                                }
                                else
                                {
                                    addMessage(ErrorLevels.Skip, sType + "(" + sClass + ")", "Event handler not found", ParentMessageId);
                                }
                            }
                            else
                            {
                                addMessage(ErrorLevels.Skip, sType + "(" + sClass + ")", "Invalid receiver type", ParentMessageId);
                            }
                        }
                        else
                        {
                            addMessage(ErrorLevels.Skip, sType + "(" + sClass + ")", "Event handler will not delete", ParentMessageId);
                        }
                    }
                    catch(Exception ex) { addMessage(ErrorLevels.Error, sType + "(" + sClass + ")", "Error: " + ex.Message, ParentMessageId); }
                }
                    
            }
        }

        private void iUninstallListsWorkflows(SPList list, XmlNode ndList, int ParentMessageId)
        {
            XmlNode ndWorkflows = ndList.SelectSingleNode("Workflows");

            if(ndWorkflows != null)
            {
                if(bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Workflows", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Uninstalling Workflows", "", ParentMessageId);

                XmlNode ndParent = ndList.ParentNode;

                foreach(XmlNode ndWorkflow in ndWorkflows.SelectNodes("Workflow"))
                {

                    string sName = getAttribute(ndWorkflow, "Name");
                    if(sName != "")
                    {
                        try
                        {
                            if(CanDelete(ndWorkflow))
                            {
                                if(!bVerifyOnly)
                                {
                                    foreach(SPWorkflowAssociation association in list.WorkflowAssociations)
                                    {
                                        if(association.BaseTemplate.Name == sName)
                                        {
                                            list.WorkflowAssociations.Remove(association);
                                            break;
                                        }
                                    }
                                }

                                addMessage(ErrorLevels.NoError, sName, "", ParentMessageId);
                            }
                            else
                            {
                                addMessage(ErrorLevels.Skip, sName, "Workflow will not delete", ParentMessageId);
                            }
                        }
                        catch(Exception ex) { addMessage(ErrorLevels.Error, sName, "Error: " + ex.Message, ParentMessageId); }

                    }
                }
            }
        }

        private void iUninstallListsViews(SPList list, XmlNode ndList, int ParentMessageId)
        {
            XmlNode ndViews = ndList.SelectSingleNode("Views");

            if(ndViews != null)
            {
                if(bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Views", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Uninstalling Views", "", ParentMessageId);

                foreach(XmlNode ndView in ndViews.SelectNodes("View"))
                {
                    string sName = getAttribute(ndView, "Name");

                    try
                    {
                        if(CanDelete(ndView))
                        {
                            SPView view = null;
                            try
                            {
                                view = list.Views[sName];
                            }
                            catch { }
                            if(view != null)
                            {
                                if(!bVerifyOnly)
                                {
                                    list.Views.Delete(view.ID);
                                }

                                addMessage(ErrorLevels.NoError, sName, "", ParentMessageId);
                            }
                            else
                            {
                                addMessage(ErrorLevels.Skip, sName, "View not found", ParentMessageId);
                            }
                        }
                        else
                        {
                            addMessage(ErrorLevels.Skip, sName, "View will not delete", ParentMessageId);
                        }
                    }
                    catch(Exception ex)
                    {
                        addMessage(ErrorLevels.Error, sName, "Error: " + ex.Message, ParentMessageId);
                    }
                }
            }
        }

        private void iUninstallListsFields(SPList list, XmlNode ndList, int ParentMessageId)
        {
            XmlNode ndFields = ndList.SelectSingleNode("Fields");

            if(ndFields != null)
            {
                if(bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Fields", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Uninstalling Fields", "", ParentMessageId);

                foreach(XmlNode ndField in ndFields.SelectNodes("Field"))
                {
                    string sInternalName = getAttribute(ndField, "InternalName");
                    string sTotal = getAttribute(ndField, "Total");

                    try
                    {
                        if(CanDelete(ndField))
                        {
                            SPField oField = null;
                            try
                            {
                                oField = list.Fields.GetFieldByInternalName(sInternalName);
                            }
                            catch { }

                            if(oField == null)
                            {

                                addMessage(ErrorLevels.Skip, sInternalName, "Field does not exist", ParentMessageId);

                            }
                            else
                            {
                                if(!bVerifyOnly)
                                {
                                    if(oField.Sealed)
                                    {
                                        oField.Sealed = false;
                                        oField.Update();
                                    }
                                    oField.Delete();

                                    if(!string.IsNullOrEmpty(sTotal))
                                    {
                                        GridGanttSettings gSettings = new GridGanttSettings(list);

                                        string output = "";

                                        string[] fieldList = gSettings.TotalSettings.Split('\n');

                                        foreach(string field in fieldList)
                                        {
                                            if(field != "")
                                            {
                                                string[] fieldData = field.Split('|');
                                                if(fieldData[0] != sInternalName)
                                                {
                                                    output += "\n" + field;
                                                }
                                            }
                                        }

                                        gSettings.TotalSettings = output.Trim('\n');
                                        gSettings.SaveSettings(list);
                                    }
                                }

                                addMessage(ErrorLevels.NoError, sInternalName, "", ParentMessageId);
                            }
                        }
                        else
                        {
                            addMessage(ErrorLevels.Skip, sInternalName, "Field will not delete", ParentMessageId);
                        }
                    }
                    catch(Exception ex)
                    {
                        addMessage(ErrorLevels.Error, sInternalName, "Error: " + ex.Message, ParentMessageId);
                    }
                }
            }
        }

        #endregion

        #region Navigation

        private void UninstallChildren(SPNavigationNodeCollection nodeNavC, string[] sNavNodes, int parentid)
        {

            ArrayList arrDel = new ArrayList();

            foreach(SPNavigationNode oNdNav in nodeNavC)
            {
               
                if(sNavNodes.Contains(oNdNav.Id.ToString()))
                {
                    arrDel.Add(oNdNav);
                }
            }

            foreach(SPNavigationNode ndNav in arrDel)
            {
                try
                {
                    if(!bVerifyOnly)
                        nodeNavC.Delete(ndNav);

                    addMessage(ErrorLevels.NoError, ndNav.Title, "", parentid);
                }
                catch(Exception ex)
                {
                    addMessage(ErrorLevels.Error, ndNav.Title, "Error: " + ex.Message, parentid);
                }
            }
        }

        private void UninstallNav(SPNavigationNodeCollection nodeNavC, string navlist, int parentid)
        {
            string[] sNavNodes = navlist.Split(',');

            ArrayList arrDel = new ArrayList();

            foreach(SPNavigationNode oNdNav in nodeNavC)
            {
                if(sNavNodes.Contains(oNdNav.Id.ToString()))
                {
                    arrDel.Add(oNdNav);
                }
                else
                {
                    UninstallChildren(oNdNav.Children, sNavNodes, parentid);
                }
            }

            foreach(SPNavigationNode ndNav in arrDel)
            {
                try
                {
                    if(!bVerifyOnly)
                        nodeNavC.Delete(ndNav);

                    addMessage(ErrorLevels.NoError, ndNav.Title, "", parentid);
                }
                catch(Exception ex)
                {
                    addMessage(ErrorLevels.Error, ndNav.Title, "Error: " + ex.Message, parentid);
                }
            }
        }

        private void iUninstallQuickLaunch()
        {
            string sQuickLaunch = "";
            string sTopNav = "";

            try
            {
                sQuickLaunch = oListItem["QuickLaunch"].ToString();
            }
            catch { }
            try
            {
                sTopNav = oListItem["TopNav"].ToString();
            }
            catch { }

            if(sQuickLaunch != "" || sTopNav != "")
            {

                int pId = 0;
                if(bVerifyOnly)
                    pId = addMessage(ErrorLevels.NoError, "Checking Navigation", "", 0);
                else
                    pId = addMessage(ErrorLevels.NoError, "Uninstalling Navigation", "", 0);

                if(sQuickLaunch != "")
                {
                    int qpid = addMessage(ErrorLevels.NoError, "Checking QuickLaunch", "", pId);


                    UninstallNav(oWeb.Navigation.QuickLaunch, sQuickLaunch, qpid);

                }

                if(sTopNav != "")
                {
                    int qpid = addMessage(ErrorLevels.NoError, "Checking Top Navigation", "", pId);


                    UninstallNav(oWeb.Navigation.TopNavigationBar, sTopNav, qpid);

                }

            }
        }
        #endregion

        #region Features
        private void iUninstallFeature(Guid gFeatureId, SPFeatureDefinition def, SPFeatureDefinitionScope scope, int ParentMessageId)
        {
            switch(def.Scope)
            {
                case SPFeatureScope.Site:
                    if(!bIsInstalledElsewhere)
                    {
                        if(!bVerifyOnly)
                            oWeb.Site.Features.Remove(gFeatureId);

                        addMessage(ErrorLevels.NoError, def.DisplayName, "", ParentMessageId);
                    }
                    else
                    {
                        addMessage(ErrorLevels.Skip, def.DisplayName, "Application currently installed on another site", ParentMessageId);
                    }
                    break;
                case SPFeatureScope.Web:
                    if(!bVerifyOnly)
                    {
                        oWeb.Features.Remove(gFeatureId);
                        //TODO: Uninstall on All Webs
                    }

                    addMessage(ErrorLevels.NoError, def.DisplayName, "", ParentMessageId);

                    break;
                default:
                    addMessage(ErrorLevels.Skip, def.DisplayName, "Feature Not scoped for Site or Web", ParentMessageId);

                    break;
            }
        }

        private void iUninstallFeatures()
        {
            XmlNode ndFeatures = appDef.ApplicationXml.FirstChild.SelectSingleNode("Features");
            if(ndFeatures != null)
            {
                int ParentMessageId = 0;
                if(bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Features", "", 0);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Uninstalling Features", "", 0);
                }

                float percent = 0;

                XmlNodeList ListNdFeatures = ndFeatures.SelectNodes("Feature");
                float max = ListNdFeatures.Count;
                float counter = 0;

                Dictionary<Guid, SPFeatureDefinition> ArrInstalledSiteFeatures14 = new Dictionary<Guid, SPFeatureDefinition>();
                Dictionary<Guid, SPFeatureDefinition> ArrInstalledFarmFeatures14 = new Dictionary<Guid, SPFeatureDefinition>();
                Dictionary<Guid, SPFeatureDefinition> ArrInstalledSiteFeatures15 = new Dictionary<Guid, SPFeatureDefinition>();
                Dictionary<Guid, SPFeatureDefinition> ArrInstalledFarmFeatures15 = new Dictionary<Guid, SPFeatureDefinition>();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(oWeb.Site.ID))
                    {
                        foreach (SPFeatureDefinition def in site.WebApplication.Farm.FeatureDefinitions)
                        {
                            if (def.CompatibilityLevel == 14)
                                ArrInstalledFarmFeatures14.Add(def.Id, def);
                            else
                                ArrInstalledFarmFeatures15.Add(def.Id, def);
                        }

                        foreach (SPFeatureDefinition def in site.FeatureDefinitions)
                        {
                            if (def.CompatibilityLevel == 14)
                                ArrInstalledSiteFeatures14.Add(def.Id, def);
                            else
                                ArrInstalledSiteFeatures15.Add(def.Id, def);
                        }
                    }
                });

                foreach(XmlNode ndFeature in ListNdFeatures)
                {
                    string FeatureId = getAttribute(ndFeature, "ID");
                    string sFeatureName = getAttribute(ndFeature, "Name");
                    if(FeatureId != "")
                    {
                        try
                        {
                            if(CanDelete(ndFeature))
                            {

                                Guid gFeatureId = new Guid(FeatureId);

                                if (ArrInstalledFarmFeatures15.ContainsKey(gFeatureId))
                                {
                                    SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledFarmFeatures15[gFeatureId];

                                    iUninstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Farm, ParentMessageId);

                                }
                                else if (ArrInstalledFarmFeatures14.ContainsKey(gFeatureId))
                                {
                                    SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledFarmFeatures14[gFeatureId];

                                    iUninstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Farm, ParentMessageId);

                                }
                                else if (ArrInstalledSiteFeatures15.ContainsKey(gFeatureId))
                                {
                                    SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledSiteFeatures15[gFeatureId];

                                    iUninstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Site, ParentMessageId);
                                }
                                else if (ArrInstalledSiteFeatures14.ContainsKey(gFeatureId))
                                {
                                    SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledSiteFeatures14[gFeatureId];

                                    iUninstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Site, ParentMessageId);
                                }

                                //if(ArrInstalledFarmFeatures.ContainsKey(gFeatureId))
                                //{
                                //    SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledFarmFeatures[gFeatureId];

                                //    iUninstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Farm, ParentMessageId);

                                //}
                                //else if(ArrInstalledSiteFeatures.ContainsKey(gFeatureId))
                                //{
                                //    SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledSiteFeatures[gFeatureId];

                                //    iUninstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Site, ParentMessageId);
                                //}
                                else
                                {
                                    addMessage(ErrorLevels.Skip, (sFeatureName == "") ? FeatureId : sFeatureName, "Feature Not Installed on Farm", ParentMessageId);
                                }
                            }
                            else
                            {
                                addMessage(ErrorLevels.Skip, (sFeatureName == "") ? FeatureId : sFeatureName, "Feature will not delete", ParentMessageId);
                            }
                        }
                        catch(Exception ex)
                        {
                            addMessage(ErrorLevels.Error, (sFeatureName == "") ? FeatureId : sFeatureName, "Error: " + ex.Message, ParentMessageId);
                        }
                    }

                    counter++;
                    percent = counter / max;
                    updateLIPercent(percent);

                }
            }
        }
        #endregion

        #region Properties
        private void iUninstallPropertiesSet(string sPropertyName, string sPropertyValue, bool bLockWeb)
        {
            if(bLockWeb)
            {
                Guid lWeb = CoreFunctions.getLockedWeb(oWeb);
                using(SPWeb tWeb = oWeb.Site.OpenWeb(lWeb))
                {
                    CoreFunctions.setConfigSetting(tWeb, sPropertyName, sPropertyValue);
                }
            }
            else
            {
                CoreFunctions.setConfigSetting(oWeb, sPropertyName, sPropertyValue);
            }
        }

        private string iUninstallPropertiesGet(string sPropertyName, bool bLockWeb)
        {
            if(bLockWeb)
            {
                return CoreFunctions.getLockConfigSetting(oWeb, sPropertyName, false);
            }
            else
            {
                return CoreFunctions.getConfigSetting(oWeb, sPropertyName);
            }
        }

        private void iUninstallProperties()
        {
            XmlNode ndWeb = appDef.ApplicationXml.FirstChild.SelectSingleNode("Web");
            if(ndWeb != null)
            {
                XmlNode ndProperties = ndWeb.SelectSingleNode("Properties");
                if(ndProperties != null)
                {
                    int ParentMessageId = 0;

                    if(bVerifyOnly)
                    {
                        ParentMessageId = addMessage(0, "Checking Properties", "", 0);
                    }
                    else
                    {
                        ParentMessageId = addMessage(0, "Uninstalling Properties", "", 0);
                    }

                    float percent = 0;

                    XmlNodeList ListNdProperties = ndProperties.SelectNodes("Property");
                    float max = ListNdProperties.Count;
                    float counter = 0;

                    foreach(XmlNode ndProperty in ListNdProperties)
                    {

                        try
                        {
                            string sPropertyName = ndProperty.Attributes["Name"].Value;

                            if(CanDelete(ndProperty))
                            {
                                string sPropertyValue = ndProperty.Attributes["Value"].Value;
                                bool bAppend = false;
                                bool bOverwrite = false;
                                bool bIsLockWeb = false;
                                bool.TryParse(getAttribute(ndProperty, "Append"), out bAppend);
                                bool.TryParse(getAttribute(ndProperty, "Overwrite"), out bOverwrite);
                                bool.TryParse(getAttribute(ndProperty, "LockWebProperty"), out bIsLockWeb);
                                if(bAppend)
                                {
                                    if(!bVerifyOnly)
                                    {
                                        string CurVal = iUninstallPropertiesGet(sPropertyName, bIsLockWeb);

                                        if(!string.IsNullOrEmpty(CurVal))
                                        {
                                            char sSeperator = getAttribute(ndProperty, "Seperator")[0];

                                            if(getAttribute(ndProperty, "Seperator") == "\\n")
                                                sSeperator = '\n';

                                            if(getAttribute(ndProperty, "Seperator") == "\\r")
                                                sSeperator = '\r';

                                            if(sSeperator == '\0')
                                                sSeperator = ',';

                                            string DuplicateRegEx = getAttribute(ndProperty, "DuplicateRegEx");

                                            if(sSeperator == '\r')
                                                CurVal = CurVal.Replace("\r\n", "\r");

                                            string[] sCurVals = CurVal.Split(sSeperator);

                                            if(DuplicateRegEx == "")
                                                DuplicateRegEx = sPropertyValue;

                                            string sNewVal = "";

                                            foreach(string sCurVal in sCurVals)
                                            {
                                                Match m = Regex.Match(sCurVal, DuplicateRegEx);
                                                if(m.Length == 0)
                                                {
                                                    if(sSeperator == '\r')
                                                        sNewVal += "\r\n" + sCurVal;
                                                    else
                                                        sNewVal += sSeperator + sCurVal;
                                                }
                                            }

                                            if(sSeperator == '\r')
                                                sNewVal = sNewVal.Trim('\r').Trim('\n');
                                            else
                                                sNewVal = sNewVal.Trim(sSeperator);

                                            iUninstallPropertiesSet(sPropertyName, sNewVal, bIsLockWeb);
                                        }

                                        addMessage(ErrorLevels.NoError, sPropertyName, "", ParentMessageId);
                                    }
                                    else
                                        addMessage(ErrorLevels.NoError, sPropertyName, "", ParentMessageId);
                                }
                                else
                                {
                                    if(!bVerifyOnly)
                                        iUninstallPropertiesSet(sPropertyName, "", bIsLockWeb);

                                    addMessage(ErrorLevels.NoError, sPropertyName, "", ParentMessageId);
                                }
                            }
                            else
                            {
                                addMessage(ErrorLevels.Skip, sPropertyName, "Property will not delete", ParentMessageId);
                            }

                        }
                        catch(Exception ex)
                        {
                            addMessage(ErrorLevels.Error, ndProperty.Attributes["Name"].Value, ex.Message, ParentMessageId);
                        }

                        counter++;
                        percent = counter / max;
                        updateLIPercent(percent);

                    }


                }
            }
        }
        #endregion

        private void iProcessFolder(XmlNode ndFolder, int parentid)
        {
            foreach(XmlNode ndChild in ndFolder.ChildNodes)
            {
                //string sRemoteName = getAttribute(ndChild, "RemoteFile");
                string sType = getAttribute(ndChild, "Type");
                string sFullFile = getAttribute(ndChild, "FullFile");
                string sFileName = getAttribute(ndChild, "Name");
                string sParentFolder = System.IO.Path.GetDirectoryName(sFullFile).Replace("\\", "/");

                int pFolderId = 0;

                try
                {
                    if(CanDelete(ndChild))
                    {
                        if(System.IO.Path.GetExtension(sFileName) == "")
                        {
                            if(!sFullFile.Contains("/"))
                            {
                                SPList list = oWeb.Lists.TryGetList(sFileName);
                                if(list == null)
                                {
                                    SPFolder oFolder = oWeb.GetFolder(sFullFile);
                                    if(oFolder.Exists)
                                    {
                                        if(!bVerifyOnly)
                                        {
                                            oFolder.Delete();
                                        }

                                        addMessage(ErrorLevels.NoError, sFileName, "", parentid);
                                    }
                                }
                                else
                                {
                                    pFolderId = addMessage(ErrorLevels.Skip, sFileName, "Folder is a list", parentid);
                                    iProcessFolder(ndChild, pFolderId);
                                }
                            }
                            else
                            {
                                SPFolder oFolder = oWeb.GetFolder(sFullFile);
                                if(oFolder.Exists)
                                {
                                    if(!bVerifyOnly)
                                    {
                                        oFolder.Delete();
                                    }

                                    addMessage(ErrorLevels.NoError, sFileName, "", parentid);
                                }
                            }
                        }
                        else
                        {
                            SPFile oFile = oWeb.GetFile(sFullFile);
                            if(oFile.Exists)
                            {
                                if(!bVerifyOnly)
                                {
                                    oFile.Delete();
                                }

                                addMessage(ErrorLevels.NoError, sFileName, "", parentid);
                            }
                        }
                    }
                    else
                    {
                        pFolderId = addMessage(ErrorLevels.Skip, sFileName, "Skipping", parentid);
                        iProcessFolder(ndChild, pFolderId);
                    }
                }
                catch(Exception ex) { }
            }
        }

        private void iUninstallFiles()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.LoadXml("<Files/>");

            try
            {
                docXml.LoadXml(oListItem["InstalledFiles"].ToString());
            }
            catch { }

            if(docXml.FirstChild.ChildNodes.Count > 0)
            {

                int pid = 0;
                if(bVerifyOnly)
                    pid = addMessage(ErrorLevels.NoError, "Checking Files", "", 0);
                else
                    pid = addMessage(ErrorLevels.NoError, "Uninstalling Files", "", 0);

                iProcessFolder(docXml.FirstChild, pid);

            }
        }

        private void iUninstallCommunity(SPList appList)
        {

            int iCommunity = 0;
            try
            {
                iCommunity = int.Parse(oListItem["LinkedCommunity"].ToString());
            }
            catch { }
            if(iCommunity != 0)
            {
                try
                {
                    Applications.DeleteCommunity(iCommunity, oWeb);

                    addMessage(ErrorLevels.NoError, "Deleting Community", appDef.Community, 0);
                }
                catch(Exception ex)
                {
                    addMessage(ErrorLevels.Warning, "Deleting Community", "Error: " + ex.Message, 0);
                }
            }
        }

        private void iUninstallCommunities(SPList appList)
        {
            if(!bVerifyOnly)
            {
                SPQuery query = new SPQuery();
                query.Query = "<Where><IsNull><FieldRef Name='EXTID'/></IsNull></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

                int pid = addMessage(ErrorLevels.NoError, "Removing App from Communities", "", 0);

                foreach(SPListItem li in appList.GetItems(query))
                {
                    try
                    {
                        Applications.RemoveAppFromCommunity(li, appDef.Id);
                        addMessage(ErrorLevels.NoError, li.Title, "", pid);
                    }
                    catch(Exception ex)
                    {
                        addMessage(ErrorLevels.Error, li.Title + " (Error: " + ex.Message + ")", "", pid);
                    }
                }
            }
        }

        private void iUninstallAndConfigureApp()
        {

            try
            {
                SPList list = oWeb.Lists.TryGetList("Installed Applications");
                if(list != null)
                {

                    XmlNode ndApp = appDef.ApplicationXml.FirstChild.SelectSingleNode("Application");

                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + appDef.Id + "</Value></Eq></Where>";
                    SPListItemCollection lic = list.GetItems(query);

                    if(lic.Count > 0)
                    {
                        oListItem = lic[0];
                    }
                    else
                    {
                        _maxErrorLevel = (int)ErrorLevels.Error;
                        addMessage(ErrorLevels.Error, "Open Application Item", "Could not find item in list", 0);
                        return;
                    }

                    iUninstallCommunities(list);

                    if(!bVerifyOnly)
                        iUninstallCommunity(list);

                    _currentPercentSpan = 10;
                    _currentBasePercent = 0;
                    iUninstallQuickLaunch();

                    _currentPercentSpan = 50;
                    _currentBasePercent = 10;
                    iUninstallLists();
                    
                    _currentPercentSpan = 10;
                    _currentBasePercent = 60;
                    iUninstallFeatures();

                    _currentPercentSpan = 10;
                    _currentBasePercent = 70;
                    iUninstallProperties();

                    _currentPercentSpan = 10;
                    _currentBasePercent = 80;
                    iUninstallFiles();

                    if(!bIsInstalledElsewhere)
                    {
                        _currentPercentSpan = 10;
                        _currentBasePercent = 90;
                        iUninstallSolutions();
                    }
                }
                else
                {
                    if(!bVerifyOnly)
                    {
                        addMessage(ErrorLevels.Error, "Uninstalling Application", "Unable to find Installed Applications List", 0);
                    }
                }
            }
            catch(Exception ex)
            {
                addMessage(ErrorLevels.Error, "Uninstalling Application", "Exception: " + ex.Message, 0);
            }

            if(oListItem != null)
            {
                if(!bVerifyOnly)
                {
                    try
                    {
                        oWeb.Files.Delete("AppDocuments/" + oListItem.ID + System.IO.Path.GetExtension(appDef.Icon));
                    }
                    catch { }

                    if(oWeb.IsRootWeb)
                    {
                        if(bIsInstalledElsewhere)
                        {
                            oListItem["Status"] = "Not Installed";
                            oListItem["Visible"] = false;
                            oListItem["QuickLaunchXML"] = "";
                            oListItem["QuickLaunch"] = "";
                            oListItem.Update();
                        }
                        else
                        {
                            oListItem.Delete();
                        }
                    }
                    else
                    {
                        if(!bIsInstalledElsewhere)
                            UninstallRoot();
                        oListItem.Delete();
                    }
                }
            }
        }

        private void UninstallRoot()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    using(SPSite site = new SPSite(oWeb.Site.ID))
                    {
                        using(SPWeb web = site.OpenWeb())
                        {

                            SPList list = web.Lists.TryGetList("Installed Applications");

                            SPQuery query = new SPQuery();
                            query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + appDef.Id + "</Value></Eq></Where>";
                            SPListItemCollection lic = list.GetItems(query);

                            if(lic.Count > 0)
                            {
                                lic[0].Recycle();
                            }
                        }
                    }
                }
                catch { }
            });
        }

        private void updateLIPercent(float percent)
        {
            oListItem.ParentList.ParentWeb.AllowUnsafeUpdates = true;
            percent = percent * _currentPercentSpan + _currentBasePercent;

            if(oListItem != null)
            {
                oListItem["InstallMessages"] = Message;
                oListItem["InstallPercent"] = Math.Round(percent / 100, 2);
                oListItem.Update();

                if(percent != _lastPercent)
                {
                    _lastPercent = percent;
                    _configJob.SetPercent(_lastPercent);
                }
            }
        }

        private int updateParentStatus(int parent, ErrorLevels level)
        {
            if(parent > 0)
            {
                DataRow[] drParent = _dtMessages.Select("ID='" + parent + "'");
                if(drParent.Length > 0)
                {
                    if((ErrorLevels)drParent[0][2] < level)
                    {
                        drParent[0][2] = (int)level;
                    }

                    int tabLength = updateParentStatus((int)drParent[0]["ParentID"], level);
                    return tabLength + 1;
                }
            }
            return 0;
        }

        private int addMessage(ErrorLevels level, string message, string details, int parent)
        {
            if(_maxErrorLevel < (int)level)
                _maxErrorLevel = (int)level;

            _MessageId++;

            int tabLength = updateParentStatus(parent, level);

            _dtMessages.Rows.Add(new object[] { _MessageId, parent, (int)level, message, details, tabLength.ToString() });

            return _MessageId;
        }


        #region Accessors

        public DataTable DtMessages
        {
            get
            {
                return _dtMessages;
            }
        }

        public XmlDocument XmlMessages
        {
            get
            {
                XmlDocument docMessages = new XmlDocument();
                docMessages.LoadXml("<Messages/>");
                XmlNode ndParent = docMessages.FirstChild;

                foreach(DataRow dr in _dtMessages.Rows)
                {
                    XmlNode ndMessageRow = docMessages.CreateNode(XmlNodeType.Element, "MessageRow", docMessages.NamespaceURI);

                    XmlAttribute attr = docMessages.CreateAttribute("ID");
                    attr.Value = dr["ID"].ToString();
                    ndMessageRow.Attributes.Append(attr);

                    attr = docMessages.CreateAttribute("ErrorLevel");
                    attr.Value = dr["ErrorLevel"].ToString();
                    ndMessageRow.Attributes.Append(attr);

                    XmlNode ndMessage = docMessages.CreateNode(XmlNodeType.Element, "Message", docMessages.NamespaceURI);
                    ndMessage.InnerXml = "<![CDATA[" + System.Web.HttpUtility.HtmlEncode(dr["Message"].ToString()) + "]]>";

                    ndMessageRow.AppendChild(ndMessage);

                    ndMessage = docMessages.CreateNode(XmlNodeType.Element, "Details", docMessages.NamespaceURI);
                    ndMessage.InnerXml = "<![CDATA[" + System.Web.HttpUtility.HtmlEncode(dr["Details"].ToString()) + "]]>";

                    ndMessageRow.AppendChild(ndMessage);

                    XmlNode ndParentMessageRow = ndParent.SelectSingleNode("//MessageRow[@ID='" + dr["ParentID"].ToString() + "']");

                    if(ndParentMessageRow != null)
                        ndParentMessageRow.AppendChild(ndMessageRow);
                    else
                        ndParent.AppendChild(ndMessageRow);

                }


                return docMessages;
            }
        }


        public DataTable DtMessagesHTML
        {
            get
            {
                DataTable dt = DtMessages.Clone();
                foreach(DataRow dr in DtMessages.Rows)
                {
                    DataRow drNew = dt.Rows.Add(new object[] { dr[0], dr[1], dr[2], dr[3], dr[4], dr[5] });

                    for(int i = 0; i < int.Parse(drNew["Tabbing"].ToString()); i++)
                    {
                        drNew["Message"] = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + drNew["Message"].ToString();
                    }
                }
                return dt;
            }
        }

        public string Message
        {
            get
            {
                StringBuilder sbMessage = new StringBuilder();
                DataTable dt = DtMessagesHTML;
                foreach(DataRow dr in dt.Rows)
                {
                    sbMessage.Append(dr[3].ToString());
                    sbMessage.Append("...");

                    switch((ErrorLevels)int.Parse(dr[2].ToString()))
                    {
                        case ErrorLevels.NoError:
                        case ErrorLevels.Skip:
                            sbMessage.Append("Success");
                            break;
                        case ErrorLevels.Warning:
                            sbMessage.Append("Warning");
                            break;
                        case ErrorLevels.Error:
                            sbMessage.Append("Failed");
                            break;
                    }

                    if(dr[4].ToString().Length > 0)
                    {
                        sbMessage.Append(" (");
                        sbMessage.Append(dr[4].ToString());
                        sbMessage.Append(")");
                    }
                    sbMessage.Append("<br>");
                }

                return sbMessage.ToString();
            }
        }

        public int MaxErrorLevel
        {
            get
            {
                return _maxErrorLevel;
            }
        }
        #endregion
    }
}

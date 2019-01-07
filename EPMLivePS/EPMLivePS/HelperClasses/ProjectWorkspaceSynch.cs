using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Xml;
using EPMLiveEnterprise.WebSvcCustomFields;
using Microsoft.SharePoint;
using PSLibrary = Microsoft.Office.Project.Server.Library;

namespace EPMLiveEnterprise
{
    public class ProjectWorkspaceSynch : IDisposable
    {
        private const string TransUIdFieldName = "transuid";
        private const string SummaryFieldName = "Summary";
        private const string TaskHierarchyFieldName = "TaskHierarchy";
        private const string IsAssignmentFieldName = "IsAssignment";
        private const int ErrorReadingCustomFieldId = 320;
        private const int ErrorUpdatingFieldId = 333;
        private const int ErrorAddingFieldId = 331;
        private const int ErrorProcessingTaskCenterId = 330;
        private const string ProjectGuidFieldName = "projectguid";
        private const string IsProjectServerFieldName = "IsProjectServer";
        private const string PublishToPwaFieldName = "PublishToPWA";
        private const string ProjectServerUrlFieldName = "ProjectServerURL";
        private const string SharePointProjectFieldName = "SharePointProject";

        private bool _disposed = false;
        private SqlConnection cn;

        private SPSite mySite;
        private SPWeb myWebToPublish;
        private Guid projectUid;
        private SPSite mySiteToPublish;

        private EventLog myLog = new EventLog("EPM Live", ".", "Project Workspace Synch");
        private WebSvcCustomFields.CustomFields pCf;
        private WebSvcLookupTables.LookupTable psiLookupTable;
        private WebSvcProject.Project psiProject;
        private WebSvcResource.Resource psiResource;

        private string _username;

        public ProjectWorkspaceSynch(Guid projectSiteGuid, string webUrl, Guid projectGuid, string username)
        {
            try
            {
                _username = username;

                mySite = new SPSite(projectSiteGuid);
                mySite.AllowUnsafeUpdates = true;

                cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(mySite.WebApplication.Id));
                cn.Open();

                mySiteToPublish = new SPSite(webUrl);
                myWebToPublish = mySiteToPublish.OpenWeb();
                myWebToPublish.AllowUnsafeUpdates = true;

                pCf = new WebSvcCustomFields.CustomFields();
                pCf.Url = mySite.Url + "/_vti_bin/psi/customfields.asmx";
                pCf.UseDefaultCredentials = true;

                psiLookupTable = new WebSvcLookupTables.LookupTable();
                psiLookupTable.Url = mySite.Url + "/_vti_bin/psi/lookuptable.asmx";
                psiLookupTable.UseDefaultCredentials = true;

                psiProject = new WebSvcProject.Project();
                psiProject.Url = mySite.Url + "/_vti_bin/psi/project.asmx";
                psiProject.UseDefaultCredentials = true;

                psiResource = new WebSvcResource.Resource();
                psiResource.Url = mySite.Url + "/_vti_bin/psi/resource.asmx";
                psiResource.UseDefaultCredentials = true;

                projectUid = projectGuid;
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error Loading Workspace Synch: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 401);
            }

        }

        ~ProjectWorkspaceSynch()
        {
            Dispose(false);

            try
            {
                cn.Close();
                mySite.Close();
                mySiteToPublish.Close();
                myWebToPublish.Close();
            }
            catch { }
        }

        public ProjectWorkspaceSynch()
        {

        }

        private string getSchemaXml(SPField f, string fieldName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(f.SchemaXml);

                //WebSvcCustomFields.CustomFieldDataSet ds = pCf.ReadCustomFieldsByMdPropUids(new Guid[1] { new Guid(fieldName) }, false);
                WebSvcCustomFields.CustomFieldDataSet dsFields = new WebSvcCustomFields.CustomFieldDataSet();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    dsFields = pCf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));
                });

                WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] ds = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])dsFields.CustomFields.Select("MD_PROP_ID=" + fieldName);

                if (ds.Length <= 0)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        dsFields = pCf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.ProjectEntity.UniqueId));
                    });
                    ds = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])dsFields.CustomFields.Select("MD_PROP_ID=" + fieldName);
                }
                if (ds.Length > 0)
                {
                    WebSvcLookupTables.LookupTableDataSet dsLt = new WebSvcLookupTables.LookupTableDataSet();
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        dsLt = psiLookupTable.ReadLookupTablesByUids(new Guid[1] { ds[0].MD_LOOKUP_TABLE_UID }, false, 0);
                    });
                    StringBuilder sbChoices = new StringBuilder();
                    foreach (WebSvcLookupTables.LookupTableDataSet.LookupTableTreesRow tr in dsLt.LookupTableTrees)
                    {
                        switch ((PSLibrary.PSDataType)ds[0].MD_PROP_TYPE_ENUM)
                        {
                            case PSLibrary.PSDataType.STRING:
                                sbChoices.Append("<CHOICE><![CDATA[" + tr.LT_VALUE_FULL + "]]></CHOICE>");
                                break;
                            case PSLibrary.PSDataType.NUMBER:

                                sbChoices.Append("<CHOICE>" + float.Parse(tr.LT_VALUE_NUM.ToString()).ToString() + "</CHOICE>");
                                break;
                        }

                    }

                    string schema = f.SchemaXml;

                    XmlNode ndChoices = doc.SelectSingleNode("//CHOICES");

                    if (ndChoices != null)
                    {
                        ndChoices.InnerXml = sbChoices.ToString();
                    }
                    else
                    {
                        XmlNode nd = doc.CreateNode(XmlNodeType.Element, "CHOICES", doc.NamespaceURI);
                        nd.InnerXml = sbChoices.ToString();
                        XmlElement root = doc.DocumentElement;
                        root.AppendChild(nd);
                    }
                }

                return doc.OuterXml;
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error Processing Lookup Table for field (" + f.Title + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
                return f.SchemaXml;
            }

        }

        public void processTaskCenter()
        {
            try
            {
                if (myWebToPublish.Features[new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055")] == null)
                {
                    myWebToPublish.Features.Add(new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055"), true);
                }

                var newFields = new Hashtable();
                var updFields = new Hashtable();

                using (var command =
                    new SqlCommand("select wssfieldname,editable from customfields where visible = 1 and fieldcategory in (3,4)", cn))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            newFields.Add(dataReader.GetString(0), dataReader.GetBoolean(1));
                        }
                    }
                }

                SPList list = null;
                try
                {
                    list = myWebToPublish.Lists["Task Center"];
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }

                if (list != null)
                {
                    AddCustomTaskCenterFields(list);

                    var customFieldDataSet = GetCustomTaskCenterFieldDataSet();

                    PopulateListsToAddAndUpdate(list, newFields, customFieldDataSet, updFields);
                    UpdateFields(updFields, list, customFieldDataSet);
                    AddNewFields(newFields, list, customFieldDataSet);
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry(string.Format("Error Processing Task Center: {0}{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error, ErrorProcessingTaskCenterId);
            }
        }

        private CustomFieldDataSet GetCustomTaskCenterFieldDataSet()
        {
            var customFieldDataSet = new CustomFieldDataSet();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(
                    delegate { customFieldDataSet = pCf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId)); });
            }
            catch (Exception ex)
            {
                myLog.WriteEntry(
                    string.Format("Error in publishProject() Reading Custom Fields: {0}{1}", ex.Message, ex.StackTrace),
                    EventLogEntryType.Error,
                    ErrorReadingCustomFieldId);
            }
            return customFieldDataSet;
        }

        private static void AddCustomTaskCenterFields(SPList list)
        {
            if (!list.Fields.ContainsField(TransUIdFieldName))
            {
                var fieldTransUid = (SPFieldText)list.Fields.CreateNewField(SPFieldType.Text.ToString(), TransUIdFieldName);
                fieldTransUid.Hidden = true;
                fieldTransUid.Required = false;
                list.Fields.Add(fieldTransUid);
                list.Update();
            }
            if (!list.Fields.ContainsField(SummaryFieldName))
            {
                list.Fields.Add(SummaryFieldName, SPFieldType.Boolean, false);
                var summaryField = list.Fields[SummaryFieldName];
                summaryField.DefaultValue = "0";
                summaryField.Hidden = false;
                summaryField.ShowInEditForm = false;
                summaryField.ShowInNewForm = false;
                summaryField.Update();
            }
            if (!list.Fields.ContainsField(IsAssignmentFieldName))
            {
                list.Fields.Add(IsAssignmentFieldName, SPFieldType.Boolean, false);
                var isAssignmentField = list.Fields[IsAssignmentFieldName];
                isAssignmentField.DefaultValue = "0";
                isAssignmentField.ShowInEditForm = false;
                isAssignmentField.ShowInNewForm = false;
                isAssignmentField.Update();
            }
            if (!list.Fields.ContainsField(TaskHierarchyFieldName))
            {
                list.Fields.Add(TaskHierarchyFieldName, SPFieldType.Note, false);
                var taskHierarchyField = list.Fields[TaskHierarchyFieldName];
                taskHierarchyField.ShowInEditForm = false;
                taskHierarchyField.ShowInNewForm = false;
                taskHierarchyField.Update();
            }
        }

        private static void PopulateListsToAddAndUpdate(SPList list, Hashtable newFields, CustomFieldDataSet customFieldDataSet, Hashtable updFields)
        {
            foreach (SPField field in list.Fields)
            {
                //if (!field.Hidden && !field.Sealed)
                {
                    //if (field.Type == SPFieldType.Boolean || field.Type == SPFieldType.Text || field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.DateTime || field.Type == SPFieldType.Choice || field.InternalName == "AssignedTo" || field.Type == SPFieldType.Note)
                    {
                        if (!newFields.Contains(field.InternalName))
                        {
                            //Enterprise Fields
                            if (field.InternalName.Length > 3)
                            {
                                var fieldName = field.InternalName.Substring(3);
                                var temp = 0;
                                if (int.TryParse(fieldName, out temp))
                                {
                                    var customFieldsRows =
                                        (CustomFieldDataSet.CustomFieldsRow[])customFieldDataSet.CustomFields.Select(
                                            string.Format("MD_PROP_ID={0}", fieldName));

                                    if (customFieldsRows.Length > 0)
                                    {
                                        updFields.Add(field.Id, field.ShowInEditForm);
                                    }
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                updFields.Add(field.Id, newFields[field.InternalName].ToString());
                            }
                            catch (Exception ex)
                            {
                                Trace.TraceError("Exception Suppressed {0}", ex);
                            }
                            try
                            {
                                newFields.Remove(field.InternalName);
                            }
                            catch (Exception ex)
                            {
                                Trace.TraceError("Exception Suppressed {0}", ex);
                            }
                        }
                    }
                }
            }
        }

        private void UpdateFields(Hashtable updFields, SPList list, CustomFieldDataSet customFieldDataSet)
        {
            foreach (DictionaryEntry dictionaryEntry in updFields)
            {
                try
                {
                    var field = list.Fields[new Guid(dictionaryEntry.Key.ToString())];
                    if (field.Type == SPFieldType.Choice)
                    {
                        var fieldName = field.InternalName.Substring(3);
                        var temp = 0;
                        if (int.TryParse(fieldName, out temp))
                        {
                            field.SchemaXml = getSchemaXml(field, fieldName);
                        }

                        //cmd = new SqlCommand("select * from customfields where wssfieldname=@fieldname and fieldcategory=3", cn);
                        //cmd.Parameters.AddWithValue("@fieldname", f.InternalName);
                        //dr = cmd.ExecuteReader();

                        //if (dr.Read())
                        //{

                        //    f.SchemaXml = getSchemaXml(f, dr.GetString(0));
                        //}
                        //dr.Close();
                    }

                    if (isCalculated(customFieldDataSet, field.InternalName.Substring(3)))
                    {
                        field.ShowInEditForm = false;
                        field.ShowInNewForm = false;
                    }

                    //if (de.Value.ToString() == "True")
                    //{
                    //    f.ShowInNewForm = true;
                    //    f.ShowInEditForm = true;
                    //}
                    //else
                    //{
                    //    f.ShowInNewForm = false;
                    //    f.ShowInEditForm = false;
                    //}

                    field.Update();
                }
                catch (Exception ex)
                {
                    myLog.WriteEntry(
                        string.Format("Error Updating Field ({0}): {1}{2}", dictionaryEntry.Key, ex.Message, ex.StackTrace),
                        EventLogEntryType.Error,
                        ErrorUpdatingFieldId);
                }
            }
        }

        private void AddNewFields(Hashtable newFields, SPList list, CustomFieldDataSet customFieldDataSet)
        {
            foreach (DictionaryEntry dictionaryEntry in newFields)
            {
                try
                {
                    var field = GetTaskCenterFieldToAdd(dictionaryEntry, list);
                    AddTaskCenterField(field, customFieldDataSet, dictionaryEntry);
                }
                catch (Exception ex)
                {
                    myLog.WriteEntry(string.Format("Error Adding Field: {0}{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error, ErrorAddingFieldId);
                }
            }
        }

        private SPField GetTaskCenterFieldToAdd(DictionaryEntry dictionaryEntry, SPList list)
        {
            var field = default(SPField);
            using (var command = new SqlCommand("select * from customfields where wssfieldname=@fieldname", cn))
            {
                command.Parameters.AddWithValue("@fieldname", dictionaryEntry.Key.ToString());

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        var fieldTypeName = dataReader.GetString(7);
                        var fieldType = _fieldTypes.ContainsKey(fieldTypeName)
                            ? _fieldTypes[fieldTypeName]
                            : SPFieldType.Text;

                        list.Fields.Add(dictionaryEntry.Key.ToString().Trim(), fieldType, false);

                        field = list.Fields[dictionaryEntry.Key.ToString()];
                        field.Title = dataReader.GetString(2);
                    }
                }
            }
            return field;
        }

        private void AddTaskCenterField(SPField field, CustomFieldDataSet customFieldDataSet, DictionaryEntry dictionaryEntry)
        {
            if (field != null)
            {
                if (field.Type == SPFieldType.Choice)
                {
                    using (var command = new SqlCommand("select * from customfields where wssfieldname=@fieldname and fieldcategory=3", cn))
                    {
                        command.Parameters.AddWithValue("@fieldname", field.InternalName);
                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                field.SchemaXml = getSchemaXml(field, dataReader.GetString(0));
                            }
                        }
                    }
                }
                if (isCalculated(customFieldDataSet, dictionaryEntry.Key.ToString().Substring(3)))
                {
                    field.ShowInEditForm = false;
                    field.ShowInNewForm = false;
                }
                field.Update();
            }
        }

        private readonly IDictionary<string, SPFieldType> _fieldTypes = new Dictionary<string, SPFieldType>
        {
            ["DATETIME"] = SPFieldType.DateTime,
            ["DURATION"] = SPFieldType.Number,
            ["NUMBER"] = SPFieldType.Number,
            ["CURRENCY"] = SPFieldType.Currency,
            ["BOOLEAN"] = SPFieldType.Boolean,
            ["CHOICE"] = SPFieldType.Choice
        };

        public bool isCalculated(WebSvcCustomFields.CustomFieldDataSet cfDs, string fieldName)
        {
            WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] drCf = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select("MD_PROP_ID=" + fieldName);

            if (drCf.Length > 0)
            {
                if (!drCf[0].IsMD_PROP_FORMULANull() && drCf[0].MD_PROP_FORMULA != "")
                    return true;
            }

            return false;
        }

        public void setUpGroups()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(myWebToPublish.Url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPUser owner = null;
                        try
                        {
                            owner = web.SiteUsers[_username];
                        }catch{}
                        string aowner = "";
                        string amember = "";
                        string avisitor = "";
                        string strEPMLiveGroupsPermAssignments = "";
                        Guid lockweb = EPMLiveCore.CoreFunctions.getLockedWeb(web);
                        if (lockweb != Guid.Empty)
                        {
                            using (SPWeb lweb = web.Site.OpenWeb(lockweb))
                            {
                                aowner = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveNewProjectRoleOwners");
                                amember = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveNewProjectRoleMembers");
                                avisitor = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveNewProjectRoleVisitors");
                                strEPMLiveGroupsPermAssignments = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveGroupsPermAssignments");
                            }
                        }
                      
                        web.Update();

                        //=========Owner Group========================
                        SPRole roll = web.Roles["Full Control"];
                        try
                        {
                            if (aowner != "")
                            {
                                web.AssociatedOwnerGroup = web.SiteGroups.GetByID(int.Parse(aowner));
                                roll.AddGroup(web.SiteGroups.GetByID(int.Parse(aowner)));
                            }
                            else
                            {
                                web.AssociatedOwnerGroup = GetSiteGroup(web, web.Title + " Administrators", owner);
                                roll.AddGroup(web.SiteGroups[web.Title + " Administrators"]);
                            }
                        }
                        catch (Exception ex)
                        {
                            myLog.WriteEntry("Error Setting up Owner Group: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 334);
                        }
                        //=========Member Group========================
                        try
                        {
                            if (amember != "")
                            {
                                web.AssociatedMemberGroup = web.SiteGroups.GetByID(int.Parse(amember));
                                roll = web.Roles["Contribute"];
                                roll.AddGroup(web.SiteGroups.GetByID(int.Parse(amember)));
                            }
                            else
                            {
                                web.AssociatedMemberGroup = GetSiteGroup(web, web.Title + " Members", owner);
                                roll = web.Roles["Contribute"];
                                roll.AddGroup(web.SiteGroups[web.Title + " Members"]);
                            }
                        }
                        catch (Exception ex)
                        {
                            myLog.WriteEntry("Error Setting up Member Group: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 334);
                        }
                        //=========Visitor Group========================
                        try
                        {
                            if (avisitor != "")
                            {
                                web.AssociatedVisitorGroup = web.SiteGroups.GetByID(int.Parse(avisitor));
                                roll = web.Roles["Read"];
                                roll.AddGroup(web.SiteGroups.GetByID(int.Parse(avisitor)));
                            }
                            else
                            {
                                web.AssociatedVisitorGroup = GetSiteGroup(web, web.Title + " Visitors", owner);
                                roll = web.Roles["Read"];
                                roll.AddGroup(web.SiteGroups[web.Title + " Visitors"]);
                            }
                        }
                        catch (Exception ex)
                        {
                            myLog.WriteEntry("Error Setting up Visitor Group: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 334);
                        }
                        web.Update();

                        if (strEPMLiveGroupsPermAssignments.Length > 1)
                        {

                            string[] strOuter = strEPMLiveGroupsPermAssignments.Split(new string[] { "|~|" }, StringSplitOptions.None);
                            foreach (string strInner in strOuter)
                            {
                                string[] strInnerMost = strInner.Split('~');
                                SPGroup spGroup = web.SiteGroups.GetByID(Convert.ToInt32(strInnerMost[0]));
                                //Persist groups & permissions to the database
                                if (spGroup != null)
                                {
                                    SPRoleAssignment spRA = new SPRoleAssignment(spGroup);
                                    spRA.RoleDefinitionBindings.Add(web.RoleDefinitions.GetById(Convert.ToInt32(strInnerMost[1])));
                                    web.RoleAssignments.Add(spRA);
                                }
                            }
                        }
                        web.Update();
                    }
                }
            });
        }

        private SPGroup GetSiteGroup(SPWeb web, string name, SPUser owner)
        {
            try
            {
                return web.SiteGroups[name];
            }
            catch{
                web.SiteGroups.Add(name, owner, owner, "");
                return web.SiteGroups[name];
            }
            /*foreach (SPGroup group in web.SiteGroups)
                if (group.Name.ToLower() == name.ToLower())
                    return group;
                */
            

            return null;
        }

        public void processProjectCenter()
        {
            try
            {
                var newFields = new ArrayList();
                var allFields = new Hashtable();
                var delFields = new Hashtable();
                var updateFields = new Hashtable();

                PopulateProjectCenterFieldsLists(allFields, newFields);

                //SPWeb web = mySite.OpenWeb(publishSiteUrl.Replace(mySite.Url, "").Substring(1));

                SPList list = null;
                try
                {
                    list = myWebToPublish.Lists["Project Center"];
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }

                if (list != null)
                {
                    AddCustomProjectCenterFields(list);

                    var customFieldDataSet = new CustomFieldDataSet();
                    try
                    {
                        customFieldDataSet = pCf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry(
                            string.Format("Error in publishProject() Reading Custom Fields: {0}{1}", ex.Message, ex.StackTrace),
                            EventLogEntryType.Error,
                            ErrorReadingCustomFieldId);
                    }

                    PopulateAddAndUpdateLists(list, newFields, customFieldDataSet, updateFields);
                    ProcessProjectCenterFieldsToUpdate(updateFields, list);
                    ProcessNewProjectCenterFields(newFields, list);
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry(string.Format("Error Processing Project Center: {0}{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error, ErrorProcessingTaskCenterId);
            }
        }

        private void PopulateProjectCenterFieldsLists(Hashtable allFields, ArrayList newFields)
        {
            using (var sqlCommand = new SqlCommand("select wssfieldname,editable from customfields where pjvisible=1 order by displayname", cn))
            {
                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        allFields.Add(dataReader.GetString(0), dataReader.GetBoolean(1));
                        newFields.Add(dataReader.GetString(0));
                    }
                }
            }
        }

        private void AddCustomProjectCenterFields(SPList list)
        {
            if (!list.Fields.ContainsField(ProjectGuidFieldName))
            {
                var fieldProjectGuid = (SPFieldText)list.Fields.CreateNewField(SPFieldType.Text.ToString(), ProjectGuidFieldName);
                fieldProjectGuid.Hidden = true;
                fieldProjectGuid.Required = false;
                list.Fields.Add(fieldProjectGuid);
                list.Update();
            }

            if (!list.Fields.ContainsField(IsProjectServerFieldName))
            {
                list.Fields.Add(IsProjectServerFieldName, SPFieldType.Boolean, false);
                var isProjectServerField = list.Fields[IsProjectServerFieldName];
                isProjectServerField.Hidden = true;
                isProjectServerField.Update();
            }

            if (!list.Fields.ContainsField(PublishToPwaFieldName))
            {
                list.Fields.Add(PublishToPwaFieldName, SPFieldType.Boolean, false);
                var publishToPwaField = list.Fields[PublishToPwaFieldName];
                publishToPwaField.Hidden = false;
                publishToPwaField.DefaultValue = "1";
                publishToPwaField.Title = "Publish To Project Server";
                publishToPwaField.Update();
            }

            if (!list.Fields.ContainsField(ProjectServerUrlFieldName))
            {
                list.Fields.Add(ProjectServerUrlFieldName, SPFieldType.Text, false);
                var projectServerUrlField = list.Fields[ProjectServerUrlFieldName];
                projectServerUrlField.Hidden = false;
                projectServerUrlField.ShowInEditForm = false;
                projectServerUrlField.ShowInNewForm = false;
                projectServerUrlField.Sealed = true;
                projectServerUrlField.Title = "Project Server URL";
                projectServerUrlField.Update();
            }

            if (!list.Fields.ContainsField(SharePointProjectFieldName))
            {
                list.Fields.Add(SharePointProjectFieldName, SPFieldType.Boolean, false);
                var sharePointProjectField = list.Fields[SharePointProjectFieldName];
                sharePointProjectField.Hidden = false;
                sharePointProjectField.DefaultValue = "1";
                sharePointProjectField.Title = "SharePoint Project";
                sharePointProjectField.Update();
            }
        }

        private static void PopulateAddAndUpdateLists(SPList list, ArrayList newFields, CustomFieldDataSet customFieldDataSet, Hashtable updateFields)
        {
            foreach (SPField field in list.Fields)
            {
                //if (field.Reorderable)
                {
                    if (field.Type == SPFieldType.Boolean
                        || field.Type == SPFieldType.Text
                        || field.Type == SPFieldType.Number
                        || field.Type == SPFieldType.Currency
                        || field.Type == SPFieldType.DateTime
                        || field.Type == SPFieldType.Choice
                        || field.InternalName == "AssignedTo")
                    {
                        if (!newFields.Contains(field.InternalName))
                        {
                            if (field.InternalName.Length > 3)
                            {
                                var fieldName = field.InternalName.Substring(3);
                                var temp = 0;
                                if (int.TryParse(fieldName, out temp))
                                {
                                    var customFieldsRows = (CustomFieldDataSet.CustomFieldsRow[])customFieldDataSet.CustomFields.Select(
                                        string.Format("MD_PROP_ID={0}", fieldName));

                                    if (customFieldsRows.Length > 0)
                                    {
                                        updateFields.Add(field.Id, false);
                                    }
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                updateFields.Add(field.Id, field.ShowInEditForm);
                            }
                            catch (Exception ex)
                            {
                                Trace.TraceError("Exception Suppressed {0}", ex);
                            }
                            try
                            {
                                newFields.Remove(field.InternalName);
                            }
                            catch (Exception ex)
                            {
                                Trace.TraceError("Exception Suppressed {0}", ex);
                            }
                        }
                    }
                }
            }

            try
            {
                newFields.Remove("StartDate");
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                newFields.Remove("DueDate");
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private void ProcessProjectCenterFieldsToUpdate(Hashtable updateFields, SPList list)
        {
            foreach (DictionaryEntry dictionaryEntry in updateFields)
            {
                try
                {
                    var field = list.Fields[new Guid(dictionaryEntry.Key.ToString())];
                    if (field.Type == SPFieldType.Choice)
                    {
                        var fieldName = field.InternalName.Substring(3);
                        var temp = 0;
                        if (int.TryParse(fieldName, out temp))
                        {
                            field.SchemaXml = getSchemaXml(field, fieldName);
                        }
                    }

                    //bool show = false;
                    //try
                    //{
                    //    show = bool.Parse(de.Value.ToString());
                    //}
                    //catch { }
                    field.ShowInNewForm = false;
                    field.ShowInEditForm = false;
                    field.Update();
                }
                catch (Exception ex)
                {
                    myLog.WriteEntry(string.Format("Error Updating Field ({0}): {1}{2}", dictionaryEntry.Key, ex.Message, ex.StackTrace), EventLogEntryType.Error, ErrorUpdatingFieldId);
                }
            }
        }

        private void ProcessNewProjectCenterFields(ArrayList newFields, SPList list)
        {
            foreach (string str in newFields)
            {
                using (var sqlCommand = new SqlCommand("select * from customfields where wssfieldname=@fieldname", cn))
                {
                    sqlCommand.Parameters.AddWithValue("@fieldname", str);
                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            try
                            {
                                var type = SPFieldType.Text;
                                var fieldValue = dataReader.GetString(7);
                                switch (fieldValue)
                                {
                                    case "DATETIME":
                                        type = SPFieldType.DateTime;
                                        break;
                                    case "DURATION":
                                        type = SPFieldType.Number;
                                        break;
                                    case "NUMBER":
                                        type = SPFieldType.Number;
                                        break;
                                    case "CURRENCY":
                                        type = SPFieldType.Currency;
                                        break;
                                    case "BOOLEAN":
                                        type = SPFieldType.Boolean;
                                        break;
                                    case "CHOICE":
                                        type = SPFieldType.Choice;
                                        break;
                                    default:
                                        Trace.TraceWarning("Unexpected Value:{0}", fieldValue);
                                        break;
                                }

                                list.Fields.Add(str, type, false);

                                var field = list.Fields.GetFieldByInternalName(str);
                                field.Title = dataReader.GetString(2);

                                field.ShowInNewForm = false;
                                field.ShowInEditForm = false;

                                UpdateCustomProjectCenterField(field);

                                field.Update();
                            }
                            catch (Exception ex)
                            {
                                myLog.WriteEntry(string.Format("Error Adding Field To Project Center: {0}{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error, ErrorAddingFieldId);
                            }
                        }
                    }
                }
            }
        }

        private void UpdateCustomProjectCenterField(SPField field)
        {
            if (field.Type == SPFieldType.Choice)
            {
                using (var sqlCommand = new SqlCommand(
                    "select * from customfields where wssfieldname=@fieldname and (fieldcategory=3 OR fieldcategory=4)",
                    cn))
                {
                    sqlCommand.Parameters.AddWithValue("@fieldname", field.InternalName);
                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            field.SchemaXml = getSchemaXml(field, dataReader.GetString(0));
                        }
                    }
                }
            }
        }

        public void processResources()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select pubtype from publishercheck where projectguid=@projectguid",cn);
                cmd.Parameters.AddWithValue("@projectguid", projectUid);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int pubtype = dr.GetInt32(0);
                    dr.Close();
                    try
                    {
                        

                        SPGroup members = myWebToPublish.AssociatedMemberGroup;
                        SPGroup visitors = myWebToPublish.AssociatedVisitorGroup;

                        WebSvcProject.ProjectDataSet pDs = new WebSvcProject.ProjectDataSet();
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            pDs = psiProject.ReadProject(projectUid, EPMLiveEnterprise.WebSvcProject.DataStoreEnum.PublishedStore);
                        });

                        if (pubtype == 3)
                        {
                            foreach(WebSvcProject.ProjectDataSet.TaskRow tr in pDs.Task)
                            {
                                int userId = getResourceIdForTask(tr.TASK_UID,pDs);
                                if(userId != 0)
                                    members.AddUser(myWebToPublish.AllUsers.GetByID(userId));
                            }
                        }
                        else
                        {   
                            foreach (WebSvcProject.ProjectDataSet.ProjectResourceRow pr in pDs.ProjectResource)
                            {
                                try
                                {
                                    if (!pr.IsWRES_ACCOUNTNull())
                                    {
                                        string email = "";
                                        try
                                        {
                                            email = pr.WRES_EMAIL;
                                        }catch{}
                                        if (pr.RES_WORK == 0)
                                            visitors.AddUser(pr.WRES_ACCOUNT, email, pr.RES_NAME, "");
                                        else
                                            members.AddUser(pr.WRES_ACCOUNT, email, pr.RES_NAME, "");
                                    }
                                }
                                catch { }

                             //   myLog.WriteEntry(pr.RES_NAME + ": " + pr.RES_WORK, EventLogEntryType.Information, 330);
                            }
                        }
                        members.Update();
                        visitors.Update();
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error Processing Resources2: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
                    }
                }
                else
                    dr.Close();
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error Processing Resources: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
            }
        }

        public int getResourceIdForTask(Guid taskuid, WebSvcProject.ProjectDataSet pDs)
        {
            int id = 0;

            SqlCommand cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='AssignedToField'", cn);
            SqlDataReader dReader = cmd.ExecuteReader();

            try
            {
                if (dReader.Read())
                {
                    string field = dReader.GetString(0);
                    if (field.Trim() != "")
                    {

                        WebSvcProject.ProjectDataSet.TaskCustomFieldsRow[] dr = (WebSvcProject.ProjectDataSet.TaskCustomFieldsRow[])pDs.TaskCustomFields.Select("TASK_UID='" + taskuid + "' AND MD_PROP_UID='" + field + "'");

                        if (dr.Length > 0)
                        {
                            if (dr[0].IsCODE_VALUENull())
                            {
                                id = getResourceIdByEmail(dr[0].TEXT_VALUE);
                            }
                            else
                            {
                                string email = getLookupDescription(field, dr[0].CODE_VALUE.ToString());
                                id = getResourceIdByEmail(email);
                            }

                        }
                    }
                }
            }
            catch { }
            dReader.Close();
            return id;
        }

        private int getResourceIdByEmail(string email)
        {
            try
            {
                PSLibrary.Filter cfFilter = new PSLibrary.Filter();
                cfFilter.FilterTableName = "Resources";
                cfFilter.Fields.Add(new PSLibrary.Filter.Field("WRES_ACCOUNT"));
                cfFilter.Fields.Add(new PSLibrary.Filter.Field("RES_IS_WINDOWS_USER"));
                cfFilter.Fields.Add(new PSLibrary.Filter.Field("RES_UID"));
                cfFilter.Criteria = new PSLibrary.Filter.FieldOperator(PSLibrary.Filter.FieldOperationType.Equal, "WRES_EMAIL", email);

                WebSvcResource.ResourceDataSet rDs = new WebSvcResource.ResourceDataSet();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    rDs = psiResource.ReadResources(cfFilter.GetXml(), false);
                });

                if (rDs.Resources.Count > 0)
                {
                    if (rDs.Resources[0].RES_IS_WINDOWS_USER)
                    {
                        return getResourceWssId(rDs.Resources[0].RES_UID);
                    }
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error in getResourceIdByEmail(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
            }
            return 0;
        }

        private string getLookupDescription(string fieldName, string lv_id)
        {
            try
            {
                WebSvcCustomFields.CustomFieldDataSet ds = new WebSvcCustomFields.CustomFieldDataSet();
                WebSvcLookupTables.LookupTableDataSet dsLt = new WebSvcLookupTables.LookupTableDataSet();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    ds = pCf.ReadCustomFieldsByMdPropUids(new Guid[1] { new Guid(fieldName) }, false);
                    dsLt = psiLookupTable.ReadLookupTablesByUids(new Guid[1] { ds.CustomFields[0].MD_LOOKUP_TABLE_UID }, false, 0);
                });
                WebSvcLookupTables.LookupTableDataSet.LookupTableTreesRow[] tr = (WebSvcLookupTables.LookupTableDataSet.LookupTableTreesRow[])dsLt.LookupTableTrees.Select("LT_STRUCT_UID = '" + lv_id + "'");

                return tr[0].LT_VALUE_DESC;
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error Reading Lookup Table for field (" + fieldName + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
            }
            return "";
        }

        private int getResourceWssId(Guid RES_GUID)
        {
            try
            {
                WebSvcResource.ResourceDataSet rDs = new WebSvcResource.ResourceDataSet();
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    rDs = psiResource.ReadResource(RES_GUID);
                });

                if (rDs.Resources.Count > 0)
                {
                    if (rDs.Resources[0].RES_IS_WINDOWS_USER)
                    {
                        string username = rDs.Resources[0].WRES_ACCOUNT;
                        try
                        {
                            return myWebToPublish.AllUsers[username].ID;
                        }
                        catch
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error in getResourceWssId(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
            }
            return 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    myLog?.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}

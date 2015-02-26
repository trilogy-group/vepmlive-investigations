
/***********************************************
* Class: SyncProjects{}
* Purpose: Push Tasks From Sharepoint To PWA
*   Handles both Insert and Update Tasks. 
* Parameters In: SPItemEventReceiver ItemUpdating()
* Parameters In: SPItemEventReceiver ItemAdding() 
* Created By: Johnny Bayard
* Date Created: April 18, 2008
* Date Revised: April 29, 2008
************************************************/


using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Microsoft.SharePoint;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using System.Net;
using System.Threading;
using System.Data;
//using LMR.Data.DataAccessLayer;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Web.Services.Protocols;

using System.Runtime.InteropServices;  // DllImport
using System.Security.Principal; // WindowsImpersonationContext
using System.Security.Permissions; // PermissionSetAttribute

using Microsoft.SharePoint.Security;

namespace EPMLiveEnterprise
{
    //public enum SECURITY_IMPERSONATION_LEVEL : int
    //{
    //    SecurityAnonymous = 0,
    //    SecurityIdentification = 1,
    //    SecurityImpersonation = 2,
    //    SecurityDelegation = 3
    //}

    public class EPMLiveEnterpriseTaskEventReceiverItemEventReceiver : SPItemEventReceiver
    {
        //[DllImport("advapi32.dll", SetLastError = true)]
        //public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
        //    int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        //// closes open handes returned by LogonUser
        //[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        //public extern static bool CloseHandle(IntPtr handle);

        //// creates duplicate token handle
        //[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //public extern static bool DuplicateToken(IntPtr ExistingTokenHandle,
        //    int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);
        private Dictionary<string, Dictionary<string, string>> fieldProperties = null;

        const string CONST_SP_CHECK_FIELDS = "spCheckFields";

        const string CONST_SP_RETRIEVE_PROJGUID = "spRetrieveProjGuid";
        const string PARAM_WEBID = "@webid";

        public string siteurl = "";
        private string pwaSiteUrl = "";
        string m_last_errors = string.Empty;
        private static XmlSchema UpdateChangeListSchema = null;
        //private WebSvcStatusing.Statusing Statusing;
        //private WebSvcCustomFields.CustomFields CustomFields;
        //private WebSvcLookupTables.LookupTable LookupTable;
        //private WebSvcProject.Project Project;
        private StatusingDerived Statusing;
        private CustomFieldsDerived CustomFields;
        private LookupTableDerived LookupTable;
        private ProjectDerived Project;

        //private Hashtable valguidTable;
        private Guid pwaSiteGuid;

        public EPMLiveEnterpriseTaskEventReceiverItemEventReceiver()
        {
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ContextEvent(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Asynchronous after event that occurs after a new item has been added to its containing object.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemAdded(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Synchronous before event that occurs when a new item is added to its containing object.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            //Statusing = new WebSvcStatusing.Statusing();
            //CustomFields = new WebSvcCustomFields.CustomFields();
            //Project = new WebSvcProject.Project();
            //LookupTable = new WebSvcLookupTables.LookupTable();

            //Statusing = new StatusingDerived();
            //CustomFields = new CustomFieldsDerived();
            //Project = new ProjectDerived();
            //LookupTable = new LookupTableDerived();

            pwaSiteGuid = properties.SiteId;
            SPSite sitePWA = new SPSite(pwaSiteGuid);
            pwaSiteUrl = sitePWA.Url;

            CustomFields = EPMLiveHelperClasses.GetCustomFieldsDerivedObject(pwaSiteUrl);
            LookupTable = EPMLiveHelperClasses.GetLookupTableDerivedObject(pwaSiteUrl);
            Project = EPMLiveHelperClasses.GetProjectDerivedObject(pwaSiteUrl);
            Statusing = EPMLiveHelperClasses.GetStatusingDerivedObject(pwaSiteUrl);

            if (InsertHandle(properties) == false)
            {
                string logEntry = DateTime.Now.ToString() + "\tItemAdding() Failed\t";
                ErrorTrap(3642, logEntry);
            }

        }

        /// <summary>
        /// Asynchronous after event that occurs after a user adds an attachment to an item.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemAttachmentAdded(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Synchronous before event that occurs when a user adds an attachment to an item.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemAttachmentAdding(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Asynchronous after event that occurs when after a user removes an attachment from an item.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemAttachmentDeleted(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Synchronous before event that occurs when a user removes an attachment from an item.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemAttachmentDeleting(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Asynchronous after event that occurs after an item is checked in.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemCheckedIn(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Asynchronous after event that occurs after an item is checked out.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemCheckedOut(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Synchronous before event that occurs as a file is being checked in.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemCheckingIn(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Synchronous before event that occurs after an item is checked out.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemCheckingOut(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Asynchronous after event that occurs after an existing item is completely deleted.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemDeleted(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Synchronous before event that occurs before an existing item is completely deleted.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemDeleting(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="properties">
        /// TODO
        /// </param>
        //public override void ItemFileConverted(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Occurs after a file is moved.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemFileMoved(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Occurs when a file is being moved.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemFileMoving(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Synchronous before event that occurs as an item is being unchecked out.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemUncheckedOut(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Synchronous before event that occurs as an item is being unchecked out.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemUncheckingOut(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Asynchronous after event that occurs after an existing item is changed, for example, when the user changes data in one or more fields.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        //public override void ItemUpdated(SPItemEventProperties properties)
        //{
        //}

        /// <summary>
        /// Synchronous before event that occurs when an existing item is changed, for example, when the user changes data in one or more fields.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        public override void ItemUpdating(SPItemEventProperties properties)
        {

            //Statusing = new WebSvcStatusing.Statusing();
            //CustomFields = new WebSvcCustomFields.CustomFields();
            //Project = new WebSvcProject.Project();
            //LookupTable = new WebSvcLookupTables.LookupTable();
            //Statusing = new StatusingDerived();
            //CustomFields = new CustomFieldsDerived();
            //Project = new ProjectDerived();
            //LookupTable = new LookupTableDerived();

            try
            {
                SPFieldLookupValue lv = new SPFieldLookupValue(properties.ListItem["Project"].ToString());

                SPList projectCenter = properties.OpenWeb().Lists["Project Center"];
                SPListItem liProject = projectCenter.GetItemById(lv.LookupId);

                pwaSiteUrl = liProject["ProjectServerURL"].ToString();
                SPSite site = new SPSite(pwaSiteUrl);
                pwaSiteGuid = site.ID;
                if (site.ID != properties.SiteId)
                    site.Close();
            }
            catch
            {
                pwaSiteGuid = properties.SiteId;
                pwaSiteUrl = properties.OpenWeb().Site.Url;
            }
            CustomFields = EPMLiveHelperClasses.GetCustomFieldsDerivedObject(pwaSiteUrl);
            Project = EPMLiveHelperClasses.GetProjectDerivedObject(pwaSiteUrl);
            LookupTable = EPMLiveHelperClasses.GetLookupTableDerivedObject(pwaSiteUrl);
            Statusing = EPMLiveHelperClasses.GetStatusingDerivedObject(pwaSiteUrl);

            ///////////////////
            Guid trackingGuid = Guid.NewGuid();
            string lcid = "1033";

            if (UpdateHandle(properties) == false)
            {
                string logEntry = DateTime.Now.ToString() + "\tItemUpdating() Failed\tURL:" + properties.WebUrl + "\tItem:" + properties.ListItem.Title;
                ErrorTrap(3639, logEntry);
            }

        }

        /***********************************************
        * Procedure: public bool UpdateHandle()
        * Purpose: Sub for handling Update
        * Parameters In: SPItemEventProperties properties 
        * Parameters Out: Boolean
        ***********************************************/
        public bool UpdateHandle(SPItemEventProperties properties)
        {
            try
            {
                try
                {
                    string t = properties.AfterProperties["taskuid"].ToString();
                    return true;
                }
                catch { }

                properties.AfterProperties["transuid"] = Guid.NewGuid().ToString();

                //SPSite sitePWA = new SPSite(properties.SiteId);


                SPWeb web = properties.OpenWeb();
                string webid = web.ID.ToString();
                SPSite site = web.Site;
                string siteid = site.ID.ToString();

                string projectName = properties.ListItem["Project"].ToString();

                string projectID = getProjectUid(projectName, web);
                if (projectID != "")
                {
                    int pubType = 1;
                    try
                    {
                        pubType = getPubType(projectID);
                    }
                    catch (Exception ex)
                    {
                        string logEntry = DateTime.Now.ToString() + "\tUpdateHandle() - RetrievePubType Failed\t" + ex.Message.ToString();
                        ErrorTrap(3640, logEntry);
                        return false;
                    }

                    if (pubType == 1)
                    {
                        string taskID = properties.ListItem["taskuid"].ToString();

                        Guid projid = new Guid(projectID);
                        if (taskID.IndexOf(".") > 0)
                        {
                            Guid taskid = new Guid(Right(taskID, 36));

                            UpdateTask(projid, taskid, properties);
                            //UpdateTask(projid, taskid, perComplete, startDate, dueDate);
                        }
                        else
                        {
                            properties.ErrorMessage = "Error Updating Task:<br>That task does not appear to be an assignment.";
                            properties.Cancel = true;
                        }
                    }

                }
                web.Close();
                return true;
            }
            catch (Exception ex)
            {
                string logEntry = DateTime.Now.ToString() + "\tUpdateHandle()\t" + ex.Message.ToString();
                ErrorTrap(3641, logEntry);
                return false;
            }
        }

        /***********************************************
        * Procedure: public bool InsertHandle()
        * Purpose: Sub for handling Insert
        * Parameters In: SPItemEventProperties properties 
        * Parameters Out: Boolean
        ***********************************************/
        public bool InsertHandle(SPItemEventProperties properties)
        {

            try
            {

                try
                {
                    string t = properties.AfterProperties["taskuid"].ToString();
                    return true;
                }
                catch { }


                SPSite sitePWA = new SPSite(properties.SiteId);
                pwaSiteUrl = sitePWA.Url;

                SPWeb web = properties.OpenWeb();
                string webid = web.ID.ToString();
                SPSite site = web.Site;

                string siteid = site.ID.ToString();

                string projectName = properties.AfterProperties["Project"].ToString();

                string projectID = getProjectUid(projectName, web);

                if (projectID != "")
                {
                    int pubType = 1;

                    try
                    {
                        pubType = getPubType(projectID);
                    }
                    catch (Exception ex)
                    {
                        properties.ErrorMessage = "Error Adding New Task to Project Server (RetrieveProjectGuid):\r\n" + ex.Message;
                        properties.Cancel = true;
                        string logEntry = DateTime.Now.ToString() + "\tInsertHandle() - RetrieveProjectGuid Failed\t" + ex.Message.ToString();
                        ErrorTrap(3643, logEntry);
                        return false;
                    }
                    if (pubType == 1)
                    {
                        string startDate = DateTime.Now.ToShortDateString();
                        try
                        {
                            startDate = properties.AfterProperties["StartDate"].ToString();
                        }
                        catch { }

                        string dueDate = DateTime.Now.ToShortDateString();
                        try
                        {
                            dueDate = properties.AfterProperties["DueDate"].ToString();
                        }
                        catch { }

                        /////Insert
                        Guid projid = new Guid(projectID);
                        string taskname = properties.AfterProperties["Title"].ToString();
                        string taskuid = InsertTask(projid, taskname, startDate, dueDate, properties);

                        if (taskuid != "")
                        {
                            properties.AfterProperties["taskuid"] = taskuid;
                        }
                    }
                }
                web.Close();

                return true;
            }
            catch (Exception ex)
            {
                properties.ErrorMessage = "Error Adding New Task to Project Server ( InsertHandle() ):\r\n" + ex.Message;
                properties.Cancel = true;
                string logEntry = DateTime.Now.ToString() + "\tInsertHandle()\t" + ex.Message.ToString() + ex.StackTrace;
                ErrorTrap(3644, logEntry);
                return false;
            }
        }

        public string getProjectUid(string projectname, SPWeb web)
        {
            try
            {
                string projectId = projectname.Replace(";#", "\n").Split('\n')[0];

                SPList list = web.Lists["Project Center"];

                SPListItem li = list.GetItemById(int.Parse(projectId));

                return li["projectguid"].ToString();
            }
            catch
            {

            }
            return "";
        }

        private bool isFieldEditable(SPField field, SPListItem ListItem)
        {
            string displaySettings = "";
            try
            {
                displaySettings = fieldProperties[field.InternalName]["Edit"];
            }
            catch { }
            if (displaySettings != "" && displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
            {
                string where = displaySettings.Split(";".ToCharArray())[1];
                string conditionField = "";
                string condition = "";
                string group = "";
                string valueCondition = "";
                if (where.Equals("[Me]"))
                {
                    condition = displaySettings.Split(";".ToCharArray())[2];
                    group = displaySettings.Split(";".ToCharArray())[3];
                }
                else // [Field]
                {
                    conditionField = displaySettings.Split(";".ToCharArray())[2];
                    condition = displaySettings.Split(";".ToCharArray())[3];
                    valueCondition = displaySettings.Split(";".ToCharArray())[4];
                }
                return !EPMLiveCore.EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, ListItem);
            }
            else
            {
                if (field.ShowInEditForm.HasValue)
                    return field.ShowInEditForm.Value;
                else
                    return true;
            }
        }

        /***********************************************
        * Procedure: public void UpdateTask()
        * Purpose: Sub that creates XML string
        * Parameters In: Guid projectId, Guid taskId, 
        *   string percentComplete, string startDate, 
        *   string dueDate, bool isTask 
        * Parameters Out: Nothing
        ***********************************************/
        public void UpdateTask(Guid projectId, Guid taskId, SPItemEventProperties properties)
        {
            string AssnXML = "";
            try
            {

                string strTimesheetHours = "";

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    string sCn = "";
                    using (SPSite psite = new SPSite(pwaSiteGuid))
                    {
                        sCn = EPMLiveCore.CoreFunctions.getConnectionString(psite.WebApplication.Id);
                    }
                    SqlConnection cn = new SqlConnection(sCn);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='TimesheetHoursField'", cn);
                    SqlDataReader dReader = cmd.ExecuteReader();
                    if (dReader.Read())
                    {
                        try
                        {
                            strTimesheetHours = dReader.GetString(0);
                        }
                        catch { }
                    }
                    dReader.Close();

                    cn.Close();
                });

                //valguidTable = new Hashtable();

                string AssnHeaderXML = "<Changes xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">";
                string AssnProjectXML = "<Proj ID=\"" + projectId.ToString() + "\">";
                string AssnidXML = "<Assn ID=\"" + taskId.ToString() + "\">";

                string strXML = "";
                DataSet ds = RetrieveEditableFields();

                SPWeb web = properties.OpenWeb();
                SPList list = web.Lists[properties.ListId];

                //foreach (SPField field in list.Fields)
                //{
                //    valguidTable.Add(field.InternalName, field);
                //}

                int rowcount = ds.Tables[0].Rows.Count;

                //CustomFields.Url = pwaSiteUrl + "/_vti_bin/psi/CustomFields.asmx";
                //CustomFields.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //CustomFields.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(pwaSiteUrl);
                //CustomFields.EnforceWindowsAuth = true;
                //CustomFields.UseDefaultCredentials = true;

                WebSvcCustomFields.CustomFieldDataSet customFieldDs = CustomFields.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));

                EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

                if(gSettings.DisplaySettings != "")
                    fieldProperties = EPMLiveCore.ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);

                if (rowcount > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string wssFieldName = row["wssFieldName"].ToString();
                        string val = "";

                        SPField field = null;
                        try
                        {
                            field = list.Fields.GetFieldByInternalName(wssFieldName);
                                //(SPField)valguidTable[wssFieldName];
                        }
                        catch { }

                        if (field != null)
                        {

                            if (isFieldEditable(field, properties.ListItem))
                            {
                                if (row["fieldCategory"].ToString() == "1") //REGULAR FIELD
                                {
                                    if (row["assnUpdateColumnId"].ToString() != "" && strTimesheetHours != row["assnUpdateColumnId"].ToString())
                                    {
                                        val = ReturnCalculatedField(ValueToUse(properties, field), (int)row["fieldCategory"], row["fieldtype"].ToString(), (int)row["multiplier"]);

                                        if (field.Type == SPFieldType.DateTime)
                                        {
                                            if (field.SchemaXml.IndexOf("Format=\"DateOnly\"") > 0)
                                                val = Mid(val, 0, 10);

                                        }
                                        if (val != "")
                                            strXML = strXML + "<Change PID=\"" + row["assnUpdateColumnId"].ToString() + "\">" + val + "</Change>";
                                    }
                                }
                                if (row["fieldCategory"].ToString() == "2") //CUSTOM LOCAL FIELDS
                                {
                                    //CustomFields.Url = pwaSiteUrl + "/_vti_bin/psi/CustomFields.asmx";
                                    //CustomFields.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                                    //CustomFields.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(pwaSiteUrl);
                                    //CustomFields.EnforceWindowsAuth = true;
                                    //CustomFields.UseDefaultCredentials = true;


                                    string fieldType = row["fieldtype"].ToString();


                                    val = ReturnCalculatedField(ValueToUse(properties, field), (int)row["fieldCategory"], row["fieldtype"].ToString(), (int)row["multiplier"]);

                                    if (fieldType == "DATETIME")
                                    {
                                        if (field.SchemaXml.IndexOf("Format=\"DateOnly\"") > 0)
                                            val = Mid(val, 0, 10);
                                    }

                                    if (row["wssFieldName"].ToString().Substring(0, 3) == "Dur")
                                    {
                                        fieldType = "Number";

                                        val = ReturnCalculatedField(ValueToUse(properties, field), (int)row["fieldCategory"], "DURATION", (int)row["multiplier"]);
                                    }
                                    else if (row["wssFieldName"].ToString().Substring(0, 3) == "Sta")
                                    {
                                        fieldType = "Date";

                                    }
                                    else if (row["wssFieldName"].ToString().Substring(0, 3) == "Fin")
                                    {
                                        fieldType = "Date";

                                    }
                                    else
                                    {
                                        fieldType = getCustomFieldChangeType(fieldType);
                                    }

                                    if (val != "")
                                        strXML = strXML + "<SimpleCustomFieldChange CustomFieldType=\"" + fieldType + "\" CustomFieldGuid=\"" + row["assnUpdateColumnId"].ToString() + "\" CustomFieldName=\"" + row["wssFieldName"].ToString() + "\">" + val + "</SimpleCustomFieldChange>";

                                }

                                if (row["fieldCategory"].ToString() == "3") //ENTERPRISE CUSTOM FIELDS
                                {
                                    WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] CustomFieldsArray = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])customFieldDs.CustomFields.Select("MD_PROP_UID_SECONDARY = '" + row["assnfieldname"].ToString() + "'"); //.select("TASK_ID = 0");

                                    if (CustomFieldsArray.Length > 0)
                                    {
                                        PSLibrary.PSDataType fieldType = (PSLibrary.PSDataType)CustomFieldsArray[0].MD_PROP_TYPE_ENUM;
                                        if (CustomFieldsArray[0].IsMD_LOOKUP_TABLE_UIDNull())
                                        {

                                            val = ValueToUse(properties, field);

                                            if (((PSLibrary.PSDataType)CustomFieldsArray[0].MD_PROP_TYPE_ENUM) == Microsoft.Office.Project.Server.Library.PSDataType.NUMBER && val == "")
                                                val = "0";


                                            strXML = strXML + "<SimpleCustomFieldChange CustomFieldType=\"" + getCustomFieldChangeType(fieldType) + "\" CustomFieldGuid=\"" + row["assnfieldname"].ToString() + "\" CustomFieldName=\"" + CustomFieldsArray[0].MD_PROP_NAME + "\">" + val + "</SimpleCustomFieldChange>";
                                        }
                                        else // LOOKUPTABLES
                                        {
                                            //LookupTable.Url = pwaSiteUrl + "/_vti_bin/psi/LookupTable.asmx";
                                            //LookupTable.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                                            //LookupTable.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(pwaSiteUrl);
                                            //LookupTable.EnforceWindowsAuth = true;
                                            //LookupTable.UseDefaultCredentials = true;
                                            WebSvcLookupTables.LookupTableDataSet LookupTableDs = LookupTable.ReadLookupTablesByUids(new Guid[] { CustomFieldsArray[0].MD_LOOKUP_TABLE_UID }, false, 0);

                                            string customfieldtype = getCustomFieldChangeType((PSLibrary.PSDataType)CustomFieldsArray[0].MD_PROP_TYPE_ENUM);

                                            string selectstmt = "";
                                            switch (customfieldtype)
                                            {
                                                case "Number":
                                                    selectstmt = "LT_VALUE_NUM = " + ValueToUse(properties, field);
                                                    break;
                                                case "Text":
                                                    selectstmt = "LT_VALUE_TEXT = '" + ValueToUse(properties, field) + "'";
                                                    break;
                                            }

                                            WebSvcLookupTables.LookupTableDataSet.LookupTableTreesRow[] treeRow = (WebSvcLookupTables.LookupTableDataSet.LookupTableTreesRow[])LookupTableDs.LookupTableTrees.Select(selectstmt);

                                            string customfieldguid = row["assnfieldname"].ToString();
                                            string customfieldname = CustomFieldsArray[0].MD_PROP_NAME.ToString();
                                            string lookuptableID = "";
                                            if (treeRow.Length > 0)
                                                lookuptableID = treeRow[0].LT_UID.ToString();

                                            val = ValueToUse(properties, field);//properties.AfterProperties[field.InternalName.ToString()].ToString();

                                            string ltXML = "<LookupTableCustomFieldChange IsMultiValued=\"false\" CustomFieldType=\"" + customfieldtype + "\" CustomFieldGuid=\"" + customfieldguid + "\" CustomFieldName=\"" + customfieldname + "\">";
                                            if (lookuptableID != "")
                                                ltXML = ltXML + "<LookupTableValue Guid=\"" + lookuptableID + "\">" + val + "</LookupTableValue>";

                                            ltXML = ltXML + "</LookupTableCustomFieldChange>";
                                            if (val != "")
                                                strXML = strXML + ltXML;

                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (strTimesheetHours != "")
                {
                    if (properties.AfterProperties["TimesheetHours"] != null)
                    {
                        if (strTimesheetHours == "251658250")
                        {
                            double act = double.Parse(properties.AfterProperties["TimesheetHours"].ToString());

                            strXML = strXML + "<Change PID=\"251658250\">" + (act * 60000).ToString() + "</Change>";

                        }
                        else
                        {
                            WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] CustomFieldsArray = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])customFieldDs.CustomFields.Select("MD_PROP_ID = '" + strTimesheetHours + "'");
                            strXML = strXML + "<SimpleCustomFieldChange CustomFieldType=\"Number\" CustomFieldGuid=\"" + CustomFieldsArray[0].MD_PROP_UID_SECONDARY + "\" CustomFieldName=\"" + CustomFieldsArray[0].MD_PROP_NAME + "\">" + properties.AfterProperties["TimesheetHours"].ToString() + "</SimpleCustomFieldChange>";
                        }
                    }
                }

                string AssnFooterXML = "</Assn></Proj></Changes>";

                //always include notes if they exist
                try
                {
                    if (properties.AfterProperties["Notes"] != null)
                    {
                        string notes = "<![CDATA[" + properties.AfterProperties["Notes"].ToString() + "]]>";
                        notes = notes.Replace("<DIV>", "").Replace("</DIV>", "");
                        strXML = strXML + "<Change PID=\"251658287\">" + notes + "</Change>";
                    }
                }
                catch { }

                AssnXML = AssnHeaderXML + AssnProjectXML + AssnidXML + strXML + AssnFooterXML;

                UpdateStatus(AssnXML, properties);
                SubmitAllUpdates("", properties);

            }
            catch (SoapException ex1)
            {
                properties.ErrorMessage = "SoapError Updating Task to Project Server:<br>" + getError(ex1); ;
                properties.Cancel = true;
            }
            catch (Exception ex)
            {
                properties.ErrorMessage = "Error in UpdateTask:<br>" + ex.Message;
                properties.Cancel = true;
                string logEntry = DateTime.Now.ToString() + "\tUpdateTask()\t" + ex.Message.ToString() + "\r\n\r\nXML: " + AssnXML;
                ErrorTrap(3645, logEntry);
            }
        }

        /***********************************************
        * Procedure: private string ValueToUse()
        * Purpose: Handles null values
        * Parameters In: SPItemEventProperties properties,  
        *   SPField field 
        * Parameters Out: String (handled value)
        ***********************************************/
        private string ValueToUse(SPItemEventProperties properties, SPField field)
        {
            try
            {
                if (field.InternalName != null)
                {
                    if (properties.AfterProperties[field.InternalName.ToString()] != null)
                    {
                        return properties.AfterProperties[field.InternalName.ToString()].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }

            }
            catch (Exception)
            {
                //string logEntry = DateTime.Now.ToString() + "\tValueToUse()\t" + ex.Message.ToString();
                //ErrorTrap(3637, logEntry);
                return "";
            }
        }

        /***********************************************
        * Procedure: private string ReturnCalculatedField()
        * Purpose: Returns Value that needed to be calculated
        * Parameters In: string val, int fieldcat,  
        *   string fieldtype, int multiplier 
        * Parameters Out: String (calculated value)
        ***********************************************/
        private string ReturnCalculatedField(string val, int fieldcat, string fieldtype, int multiplier)
        {

            try
            {
                if (val != "")
                {
                    if (fieldcat == 1)
                    {
                        if (multiplier != 1)
                        {
                            if (fieldtype.ToUpper() == "CURRENCY" || fieldtype.ToUpper() == "NUMBER")
                            {
                                float newval = (float)System.Convert.ToSingle(val);
                                return (newval * multiplier).ToString();
                            }
                        }
                    }
                    if (fieldcat == 2 || fieldcat == 3)
                    {
                        if (fieldtype.ToUpper() == "CURRENCY")
                        {
                            float newval = (float)System.Convert.ToSingle(val);
                            return (newval * 100).ToString();
                        }
                        else
                        {
                            if (fieldtype.ToUpper() == "DURATION")
                            {
                                float newval = (float)System.Convert.ToSingle(val);
                                return (newval * 4800).ToString();
                            }

                        }
                    }
                }
                return val;
            }
            catch (Exception ex)
            {
                string logEntry = DateTime.Now.ToString() + "\tReturnCalculatedField()\t" + ex.Message.ToString();
                ErrorTrap(3638, logEntry);
                return "";
            }
        }


        private Guid getSummaryTask(Guid projectId)
        {
            Guid taskuid = new Guid();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                //Project.Url = pwaSiteUrl + "/_vti_bin/psi/Project.asmx";
                //Project.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //Project.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(pwaSiteUrl);
                //Project.EnforceWindowsAuth = true;
                //Project.UseDefaultCredentials = true;

                WebSvcProject.ProjectDataSet projectDs = Project.ReadProjectEntities(projectId, 2, WebSvcProject.DataStoreEnum.PublishedStore);
                taskuid = projectDs.Task[0].TASK_UID;

            });
            return taskuid;
        }

        /***********************************************
        * Procedure: public void InsertTask()
        * Purpose: Sub that creates XML string
        * Parameters In: Guid projectId, string taskName, 
        *   string startDate, string dueDate, bool isTask 
        * Parameters Out: String (taskid + "." + assnid)
        ***********************************************/
        public string InsertTask(Guid projectId, string taskName, string startDate, string dueDate, SPItemEventProperties properties)
        {
            string location = "Start";
            try
            {
                Guid newAssn = Guid.NewGuid();

                location = "ReadProject";
                Guid summarytaskuid = getSummaryTask(projectId);

                startDate = Mid(startDate, 0, 10);
                dueDate = Mid(dueDate, 0, 10);
                string sDate = Convert.ToDateTime(startDate).ToShortDateString();
                string fDate = Convert.ToDateTime(dueDate).ToShortDateString();
                DateTime myConvertedSDate = Convert.ToDateTime(sDate);
                DateTime myConvertedFDate = Convert.ToDateTime(fDate);

                //Statusing.Url = pwaSiteUrl + "/_vti_bin/psi/Statusing.asmx";//siteurl + "/psi/Statusing.asmx";
                //Statusing.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //Statusing.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(pwaSiteUrl);
                //Statusing.EnforceWindowsAuth = true;
                //Statusing.UseDefaultCredentials = true;
                location = "CreateNewAssignment";
                Statusing.CreateNewAssignment(taskName, projectId, Guid.Empty, newAssn, summarytaskuid, myConvertedSDate, myConvertedFDate, false, true, "");

                WebSvcStatusing.StatusingDataSet statusingDs;
                location = "ReadStatus";
                statusingDs = Statusing.ReadStatus(newAssn, DateTime.MinValue, DateTime.MaxValue);

                string taskid = "";
                string assnid = "";
                location = "GetAssignment";
                DataTable dt = statusingDs.Tables["Assignments"];
                foreach (DataRow dr in dt.Rows)
                {
                    taskid = dr["Task_uid"].ToString();
                    assnid = dr["Assn_uid"].ToString();
                    break;
                }


                return taskid + "." + assnid;
            }
            catch (SoapException ex1)
            {
                properties.ErrorMessage = "Error Adding New Task to Project Server:\r\n" + getError(ex1);
                properties.Cancel = true;
                string logEntry = DateTime.Now.ToString() + "\tInsertTask( @" + location + ")\t" + ex1.Detail.OuterXml;
                ErrorTrap(3646, logEntry);
                return "";
            }
            catch (Exception ex)
            {
                properties.ErrorMessage = "Error Adding New Task to Project Server:\r\n" + ex.Message;
                properties.Cancel = true;
                string logEntry = DateTime.Now.ToString() + "\tInsertTask()\t" + ex.Message.ToString();
                ErrorTrap(3646, logEntry);
                return "";
            }
        }

        private string getError(SoapException ex)
        {
            string sError = "";
            PSLibrary.PSClientError err = new Microsoft.Office.Project.Server.Library.PSClientError(ex);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ex.Detail.InnerXml);
            XmlNode nd = doc.SelectSingleNode("//class");

            sError = "Details: " + nd.Attributes["name"].Value + "<br><br><br>";

            sError += "Error List:<br>";

            foreach (PSLibrary.PSErrorInfo pi in err.GetAllErrors())
            {
                sError += pi.ErrName + "<br>";
                sError += "========================";
            }
            return sError;
        }

        /***********************************************
        * Procedure: public datatable RetrieveEditableFields()
        * Purpose: Retrieves Project Guid
        * Parameters In: string webguid 
        * Parameters Out: String projectguid 
        ***********************************************/
        public DataSet RetrieveEditableFields()
        {
            DataSet ds = new DataSet();
            try
            {

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    string sCn = "";
                    using (SPSite psite = new SPSite(pwaSiteGuid))
                    {
                        sCn = EPMLiveCore.CoreFunctions.getConnectionString(psite.WebApplication.Id);
                    }
                    SqlConnection cn = new SqlConnection(sCn);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMFIELDS where assnUpdateColumnId is not null", cn);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    cn.Close();
                });

            }

            catch (Exception ex)
            {
                string logEntry = DateTime.Now.ToString() + "\tRetrieveEditableFields()\t" + ex.Message.ToString();
                ErrorTrap(3657, logEntry);

            }
            return ds;
        }

        /***********************************************
        * Procedure: public string RetrieveProjectGuid()
        * Purpose: Retrieves Project Guid
        * Parameters In: string webguid 
        * Parameters Out: String projectguid 
        ***********************************************/
        public int getPubType(string projectUid)
        {
            int pType = 1;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    string sCn = "";
                    using (SPSite psite = new SPSite(pwaSiteGuid))
                    {
                        sCn = EPMLiveCore.CoreFunctions.getConnectionString(psite.WebApplication.Id);
                    }
                    SqlConnection cn = new SqlConnection(sCn);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT pubtype from publishercheck where projectgUID=@projectuid", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@projectuid", projectUid);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        pType = dr.GetInt32(0);
                    }
                    dr.Close();

                    cn.Close();
                });
            }
            catch (Exception ex)
            {
                string logEntry = DateTime.Now.ToString() + "\tRetrieveProjectGuid()\t" + ex.Message.ToString();
                ErrorTrap(3657, logEntry);
            }
            return pType;
        }

        /***********************************************
        * Procedure: public bool UpdateStatus()
        * Purpose: Sets the xml for update
        * Parameters In: string changeXML 
        * Parameters Out: boolean (success?) 
        ***********************************************/
        public bool UpdateStatus(string changeXml, SPItemEventProperties properties)
        {
            try
            {

                //Statusing.Url = pwaSiteUrl + "/_vti_bin/psi/Statusing.asmx";
                //Statusing.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //Statusing.UpdateStatus(changeXml);
                //Statusing.Url = pwaSiteUrl + "/_vti_bin/psi/Statusing.asmx";
                //Statusing.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //Statusing.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(pwaSiteUrl);
                //Statusing.EnforceWindowsAuth = true;

                Statusing.UpdateStatus(changeXml);

                return true;
            }

            catch (SoapException ex)
            {
                properties.ErrorMessage = "Error Updating Task to Project Server (UpdateTask):<br>" + getError(ex) + "<br><br>Change XML:<br>" + changeXml;
                properties.Cancel = true;
                //m_last_errors = ExceptionHandlers.HandleSoapException(ex);
                //string logEntry = DateTime.Now.ToString() + "\tUpdateStatus()\t" + m_last_errors;
                //.ErrorTrap(3648, logEntry);
                return false;
            }
            catch (Exception ex)
            {
                m_last_errors = ExceptionHandlers.HandleException(ex);
                string logEntry = DateTime.Now.ToString() + "\tUpdateStatus()\t" + m_last_errors;
                ErrorTrap(3648, logEntry);
                return false;
            }
        }

        /***********************************************
        * Procedure: public bool SubmitAllUpdates()
        * Purpose: submits the xml
        * Parameters In: string statusMsg 
        * Parameters Out: boolean (success?) 
        ***********************************************/
        public bool SubmitAllUpdates(string statusMsg, SPItemEventProperties properties)
        {
            try
            {

                //Statusing.Url = pwaSiteUrl + "/_vti_bin/psi/Statusing.asmx";
                //Statusing.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //Statusing.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(pwaSiteUrl);
                //Statusing.EnforceWindowsAuth = true;
                //Statusing.UseDefaultCredentials = true;

                Statusing.SubmitStatus(null, statusMsg);


                return true;
            }
            catch (SoapException ex)
            {
                properties.ErrorMessage = "Error Submitting Task to Project Server:\r\n" + getError(ex);
                properties.Cancel = true;
                //m_last_errors = ExceptionHandlers.HandleSoapException(ex);
                //string logEntry = DateTime.Now.ToString() + "\tSubmitAllUpdates()\t" + m_last_errors;
                //ErrorTrap(3649, logEntry);
                return false;
            }
            catch (WebException ex)
            {
                m_last_errors = ExceptionHandlers.HandleWebException(ex);
                string logEntry = DateTime.Now.ToString() + "\tSubmitAllUpdates()\t" + m_last_errors;
                ErrorTrap(3649, logEntry);
                return false;

            }
            catch (Exception ex)
            {
                m_last_errors = ExceptionHandlers.HandleException(ex);
                string logEntry = DateTime.Now.ToString() + "\tSubmitAllUpdates()\t" + m_last_errors;
                ErrorTrap(3649, logEntry);
                return false;
            }
        }

        /***********************************************
        * Procedure: public bool ValidateChangeXml()
        * Purpose: validates xml
        * Parameters In: string changeXml 
        * Parameters Out: boolean (success?) 
        ***********************************************/
        public bool ValidateChangeXml(string changeXml)
        {
            try
            {
                XmlDocument changeDoc = new XmlDocument();
                changeDoc.Schemas.Add(UpdateChangeListSchema);
                changeDoc.LoadXml(changeXml);
                changeDoc.Validate(null);
                return true;
            }
            catch (XmlSchemaValidationException ex)
            {
                m_last_errors = "ChangeList XML does not validate against the schema:\r\n" + ex.LineNumber + ":" + ex.LinePosition + " " + ex.Message;
                string logEntry = DateTime.Now.ToString() + "\tValidateChangeXml()\t" + m_last_errors;
                ErrorTrap(3650, logEntry);
                return false;
            }
            catch (System.Xml.XmlException ex)
            {
                m_last_errors = "ChangeList XML is not well-formed:\r\n" + ex.LineNumber + ":" + ex.LinePosition + " " + ex.Message;
                string logEntry = DateTime.Now.ToString() + "\tValidateChangeXml()\t" + m_last_errors;
                ErrorTrap(3650, logEntry);
                return false;
            }
            catch (Exception ex)
            {
                m_last_errors = "An error occured during XML validation:\r\n" + ex.Message;
                string logEntry = DateTime.Now.ToString() + "\tValidateChangeXml()\t" + m_last_errors;
                ErrorTrap(3650, logEntry);
                return false;

            }

        }
        public static string Left(string param, int length)
        {
            try
            {
                //we start at 0 since we want to get the characters starting from the
                //left and with the specified lenght and assign it to a variable
                string result = param.Substring(0, length);
                //return the result of the operation
                return result;
            }
            catch (Exception)
            {
                return "";
            }

        }
        public static string Right(string param, int length)
        {
            try
            {
                //start at the index based on the lenght of the sting minus
                //the specified lenght and assign it a variable
                string result = param.Substring(param.Length - length, length);
                //return the result of the operation
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string Mid(string param, int startIndex, int length)
        {
            try
            {
                //start at the specified index in the string ang get N number of
                //characters depending on the lenght and assign it to a variable
                string result = param.Substring(startIndex, length);
                //return the result of the operation
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string Mid(string param, int startIndex)
        {
            try
            {
                //start at the specified index and return all characters after it
                //and assign it to a variable
                string result = param.Substring(startIndex);
                //return the result of the operation
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /***********************************************
        * Procedure: private Guid GetResourceGuidByWindowsAccount()
        * Purpose: Get Resource Guid from Resource name
        * Parameters In: string site, string ls_name
        * Parameters Out: Resource Guid  
        ***********************************************/
        private Guid GetResourceGuidByWindowsAccount(string site, string ls_name)
        {
            string errLoc = "";
            try
            {

                //WebSvcResource.Resource Resource = new WebSvcResource.Resource();
                //Resource.Url = site.ToString() + "/_vti_bin/PSI/Resource.asmx";
                //WebSvcResource.ResourceDataSet lo_resDS = new WebSvcResource.ResourceDataSet();
                //Resource.Credentials = System.Net.CredentialCache.DefaultCredentials;
                ResourceDerived Resource = EPMLiveHelperClasses.GetResourceDerivedObject(site);
                //ResourceDerived Resource = new ResourceDerived();
                //Resource.Url = site.ToString() + "/_vti_bin/PSI/Resource.asmx";
                //Resource.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //Resource.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(site.ToString());
                //Resource.EnforceWindowsAuth = true;

                WebSvcResource.ResourceDataSet lo_resDS = new WebSvcResource.ResourceDataSet();

                string nameColumn = lo_resDS.Resources.WRES_ACCOUNTColumn.ColumnName;

                string resUID = lo_resDS.Resources.RES_UIDColumn.ColumnName;

                PSLibrary.Filter.FieldOperationType equal = PSLibrary.Filter.FieldOperationType.Equal;
                PSLibrary.Filter lo_filter = new PSLibrary.Filter();

                lo_filter.FilterTableName = lo_resDS.Resources.TableName;
                lo_filter.Fields.Add(new PSLibrary.Filter.Field(resUID));
                lo_filter.Criteria = new PSLibrary.Filter.FieldOperator(equal, nameColumn, ls_name);
                errLoc = "ReadResources()";
                lo_resDS = Resource.ReadResources(lo_filter.GetXml(), false);
                errLoc = "Returning Guid";
                return (Guid)lo_resDS.Tables[lo_resDS.Resources.TableName].Rows[0][0];
            }
            catch (Exception ex)
            {
                string logEntry = DateTime.Now.ToString() + "\tGetResourceGuidByWindowsAccount() Failed @\t" + errLoc + " - " + ex.Message.ToString();
                ErrorTrap(3655, logEntry);
                return new Guid();
            }
        }

        /***********************************************
        * Procedure: public WindowsImpersonationContext ImpersonateUser()
        * Purpose: Set windows user passed to windows current user
        * Parameters In: string sUsername, string ls_name
        * Parameters Out: Resource Guid  
        ***********************************************/
        /*public WindowsImpersonationContext ImpersonateUser(string sUsername, string sDomain, string sPassword)
        {
            // initialize tokens
            IntPtr pExistingTokenHandle = new IntPtr(0);
            IntPtr pDuplicateTokenHandle = new IntPtr(0);
            pExistingTokenHandle = IntPtr.Zero;
            pDuplicateTokenHandle = IntPtr.Zero;

            // if domain name was blank, assume local machine
            if (sDomain == "")
                sDomain = System.Environment.MachineName;

            try
            {
                string sResult = null;

                const int LOGON32_PROVIDER_DEFAULT = 0;

                // create token
                const int LOGON32_LOGON_INTERACTIVE = 2;
                //const int SecurityImpersonation = 2;

                // get handle to token
                bool bImpersonated = LogonUser(sUsername, sDomain, sPassword,
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref pExistingTokenHandle);

                // did impersonation fail?
                if (false == bImpersonated)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    sResult = "LogonUser() failed with error code: " + nErrorCode + "\r\n";

                    // show the reason why LogonUser failed
                    string logEntry = DateTime.Now.ToString() + "Windows Impersonation Failed - " + sResult.ToString();
                    ErrorTrap(3656, logEntry);

                }

                // Get identity before impersonation
                sResult += "Before impersonation: " + WindowsIdentity.GetCurrent().Name + "\r\n";

                bool bRetVal = DuplicateToken(pExistingTokenHandle, (int)SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, ref pDuplicateTokenHandle);

                // did DuplicateToken fail?
                if (false == bRetVal)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    CloseHandle(pExistingTokenHandle); // close existing handle
                    sResult += "DuplicateToken() failed with error code: " + nErrorCode + "\r\n";

                    // show the reason why DuplicateToken failed
                    string logEntry = DateTime.Now.ToString() + "Windows Impersonation Failed (DuplicateToken Failed) - " + sResult.ToString();
                    ErrorTrap(3657, logEntry);
                    return null;
                }
                else
                {
                    // create new identity using new primary token
                    WindowsIdentity newId = new WindowsIdentity(pDuplicateTokenHandle);
                    WindowsImpersonationContext impersonatedUser = newId.Impersonate();

                    // check the identity after impersonation
                    sResult += "After impersonation: " + WindowsIdentity.GetCurrent().Name + "\r\n";
                    string logEntry = DateTime.Now.ToString() + "\tImpersonate User Successful\t" + sResult.ToString();
                    ErrorTrap(3658, logEntry);
                    return impersonatedUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close handle(s)
                if (pExistingTokenHandle != IntPtr.Zero)
                    CloseHandle(pExistingTokenHandle);
                if (pDuplicateTokenHandle != IntPtr.Zero)
                    CloseHandle(pDuplicateTokenHandle);
            }
        }*/

        /***********************************************
        * Procedure: public void ErrorTrap()
        * Purpose: Handles error trapping
        * Parameters In: Int eventId, String logEntry 
        * Parameters Out: Nothing 
        ***********************************************/
        public void ErrorTrap(int eventId, string logEntry)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                //execute code here
                EventLog myLog = new EventLog("EPM Live", ".", "Publisher Update");
                myLog.WriteEntry(logEntry, EventLogEntryType.Error, eventId);
            });
        }

        /***********************************************
        * Procedure: public bool IsAssignedTaskApproved()
        * Purpose: Specifies if the task has been approved
        * Parameters In: Guid assnid 
        * Parameters Out: Boolean 
        ***********************************************/
        public bool IsAssignedTaskApproved(Guid assnid)
        {
            try
            {
                WebSvcStatusing.StatusingDataSet statusingDs;

                statusingDs = Statusing.ReadStatus(assnid, DateTime.MinValue, DateTime.MaxValue);

                DataTable dt = statusingDs.Tables["Assignments_Submitted"];
                if (dt.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                string logEntry = DateTime.Now.ToString() + "\tIsAssignedTaskApproved()\t" + ex.Message.ToString();
                ErrorTrap(3638, logEntry);
                return false;
            }
        }

        /***********************************************
        * OVERLOADED
        * Procedure: private string getCustomFieldChangeType()
        * Purpose: Returns the Type
        * Parameters In: PSLibrary.PSDataType dataType 
        * Parameters Out: String 
        ***********************************************/
        private string getCustomFieldChangeType(PSLibrary.PSDataType dataType)
        {
            switch (dataType)
            {
                case PSLibrary.PSDataType.COST:
                    return "Cost";
                case PSLibrary.PSDataType.NUMBER:
                    return "Number";
                case PSLibrary.PSDataType.DATE:
                    return "Date";
                case PSLibrary.PSDataType.DURATION:
                    return "Duration";
                case PSLibrary.PSDataType.PERCENT:
                    return "Number";
                case PSLibrary.PSDataType.STRING:
                    return "Text";
                case PSLibrary.PSDataType.WORK:
                    return "Number";
                case PSLibrary.PSDataType.YESNO:
                    return "Flag";
                default:
                    return "None";
            }
        }

        /***********************************************
        * OVERLOADED
        * Procedure: private string getCustomFieldChangeType()
        * Purpose: Returns the Type
        * Parameters In: String dataType 
        * Parameters Out: String 
        ***********************************************/
        private string getCustomFieldChangeType(string dataType)
        {
            switch (dataType)
            {
                case "TEXT":
                    return "Text";
                case "CURRENCY":
                    return "Cost";
                case "NUMBER":
                    return "Number";
                case "DATETIME":
                    return "Date";
                case "BOOLEAN":
                    return "Flag";
                default:
                    return "None";
            }
        }
    }
}

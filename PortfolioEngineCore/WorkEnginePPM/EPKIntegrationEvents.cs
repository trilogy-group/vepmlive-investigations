using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;
using System.Xml;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using PortfolioEngineCore;
using EPMLiveCore;
using System.Data.SqlClient;

namespace WorkEnginePPM
{
    public class EPKIntegrationEvents : SPItemEventReceiver
    {

        public override void ItemAdded(SPItemEventProperties properties)
        {
            processItem(properties);
        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            try
            {
                using (SPSite site = new SPSite(properties.SiteId))
                {
                    string xml = "<Items><Item ID=\"" + properties.Web.ID + "." + properties.ListId + "." + properties.ListItemId + "\"/></Items>";

                    string ret = CloseItemXml(xml, properties.Web);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(ret);

                    XmlNode ndStatus = xmlDoc.SelectSingleNode("//STATUS");

                    if (ndStatus != null)
                    {
                        if (ndStatus.InnerText != "0")
                        {
                            properties.Cancel = true;
                            properties.ErrorMessage = "Error deleting Portfolio item: " + xmlDoc.SelectSingleNode("//Error").InnerText;
                        }
                    }
                    else
                    {
                        properties.Cancel = true;
                        properties.ErrorMessage = "Error processing Portfolio item: Unable to get status from Portfolio Integration.";
                    }
                }
            }
            catch (Exception ex)
            {
                properties.ErrorMessage = "Error deleting item: " + ex.Message;
            }
        }

        private const string PROJECT_CENTER_TITLE = "PROJECT CENTER";
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            processItem(properties);
            if (properties.List.Fields.ContainsFieldWithInternalName("Title"))
            {
                UpdateProject(properties);
            }

            if (properties.ListTitle?.ToUpper().Trim() == PROJECT_CENTER_TITLE)
                CheckProjectNameChange(properties);
        }
        /// <summary>
        /// If project name has been changed, then rename every associated items. 
        /// </summary>
        private void CheckProjectNameChange(SPItemEventProperties properties)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                var connectionString = CoreFunctions.getReportingConnectionString(properties.Web.Site.WebApplication.Id, properties.Web.Site.ID);
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var oCommand = new SqlCommand("SELECT * FROM [LSTProjectCenter] WHERE ID=@projectid", con);
                    oCommand.Parameters.AddWithValue("@projectid", properties.ListItemId);

                    string projectNameDB = null;
                    string projectNameNew = properties.AfterProperties["Title"]?.ToString();

                    using (var reader = oCommand.ExecuteReader())
                    {
                        if (reader.Read())
                            projectNameDB = reader["Title"]?.ToString();
                    }
                    
                    if (!string.IsNullOrWhiteSpace(projectNameNew) &&
                        !string.IsNullOrWhiteSpace(projectNameDB) &&
                        projectNameDB != projectNameNew)
                    {
                        UpdateGroupsNames(properties, projectNameDB, projectNameNew);                        
                        UpdateMicrosoftProject(properties, projectNameDB, projectNameNew);
                        UpdateDB(properties, con, projectNameNew);
                    }
                }
            });
        }
        private void UpdateDB(SPItemEventProperties properties, SqlConnection con, string projectNameNew)
        {
            var oCommand = new SqlCommand("UPDATE [LSTChanges] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTChangesSnapshot] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTIssues] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTIssuesSnapshot] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTMyWork] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTMyWorkSnapshot] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTProjectDocuments] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTProjectDocumentsSnapshot] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTRisks] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTRisksSnapshot] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTTaskCenter] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTTaskCenterSnapshot] SET [ProjectText]=@projectName WHERE [ProjectID]=@projectid;" +
                                          "UPDATE [LSTProjectCenter] SET [PreviousPName]=[Title] WHERE [ID]=@projectid;", con);

            oCommand.Parameters.AddWithValue("@projectid", properties.ListItemId);
            oCommand.Parameters.AddWithValue("@projectName", projectNameNew);
            oCommand.ExecuteNonQuery();
        }
        private const string PROJECT_SCHEDULES_FOLDER_NAME = "Project Schedules";
        private const string MSPROJECT_FOLDER_NAME = "MSProject";
        private const string MSPROJECT_FILE_EXTENSION = "mpp";
        private void UpdateMicrosoftProject(SPItemEventProperties properties, string projectNameDB, string projectNameNew)
        {
            var projectItem = properties.Web.Folders[PROJECT_SCHEDULES_FOLDER_NAME]?
                                .SubFolders[MSPROJECT_FOLDER_NAME]?
                                .Files?.OfType<SPFile>()
                                .Where(x => x.Name == $"{projectNameDB}.{MSPROJECT_FILE_EXTENSION}").FirstOrDefault()?
                                .Item;

            if (projectItem != null)
            {
                if (projectItem.File.CheckOutType != SPFile.SPCheckOutType.None)
                    projectItem.File.UndoCheckOut();
                if (projectItem.File.LockType != SPFile.SPLockType.None)
                    projectItem.File.ReleaseLock(projectItem.File.LockId);

                properties.Web.AllowUnsafeUpdates = true;
                projectItem.File.CheckOut();
                projectItem["Name"] = $"{projectNameNew}.mpp";
                projectItem["Title"] = projectNameNew;                
                projectItem.Update();
                projectItem.File.CheckIn("File name has been changed.");                
            }
        }
        private void UpdateGroupsNames(SPItemEventProperties properties, string projectNameDB, string projectNameNew)
        {
            properties.ListItem.RoleAssignments.OfType<SPRoleAssignment>()?.ToList()?.ForEach(role =>
            {
                if (role != null && role.Member != null &&
                    role.Member is SPGroup && role.Member.Name != null)
                {
                    if (role.Member.Name.ToUpper().Contains("VISITOR"))
                        role.Member.Name = projectNameNew + " Visitor";
                    else if (role.Member.Name.ToUpper().Contains("OWNER"))
                        role.Member.Name = projectNameNew + " Owner";
                    else if (role.Member.Name.ToUpper().Contains("MEMBER"))
                        role.Member.Name = projectNameNew + " Member";
                    else
                        role.Member.Name = role.Member.Name.Replace(projectNameDB, projectNameNew);

                    ((SPGroup)role.Member).Update();
                }
            });
        }
        /// <summary>
        /// Updating Project Name in EPG_RPT_Cost and EPG_RPT_Cost
        /// </summary>
        /// <param name="properties"></param>
        public void UpdateProject(SPItemEventProperties properties)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                string connectionString = CoreFunctions.getReportingConnectionString(properties.Web.Site.WebApplication.Id, properties.Web.Site.ID);
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                        con.Open();
                        SqlCommand oCommand = new SqlCommand("Update [EPG_RPT_Cost] set [Project Name] = @projectname where ProjectId=@projectid", con);
                        oCommand.Parameters.AddWithValue("@projectname", properties.AfterProperties["Title"]);
                        oCommand.Parameters.AddWithValue("@projectid", properties.ListItemId);
                        oCommand.ExecuteNonQuery();

                        oCommand = new SqlCommand("Update [EPG_RPT_Projects] set [Project Name] = @projectname where ProjectId=@projectid", con);
                        oCommand.Parameters.AddWithValue("@projectname", properties.AfterProperties["Title"]);
                        oCommand.Parameters.AddWithValue("@projectid", properties.ListItemId);
                        oCommand.ExecuteNonQuery();
                }
            });
        }
        private void processItem(SPItemEventProperties properties)
        {
            //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99900, "WorkEnginePPM", "processItem", "Entry", "");
            if (properties.ListItem != null)
            {
                Hashtable hshFields = new Hashtable();
                Hashtable hshFields2 = new Hashtable();
                try
                {
                    if (properties.AfterProperties["ExternalID"].ToString() != "")
                        return;
                }
                catch { }
                try
                {
                    using (SPSite site = new SPSite(properties.SiteId))
                    {

                        string fields = ConfigFunctions.getConfigSetting(site.RootWeb, "EPK" + properties.List.Title.Replace(" ", "") + "_fields");

                        if (fields == "")
                            fields = ConfigFunctions.getConfigSetting(site.RootWeb, "epkportfoliofields");

                        if (fields != "")
                        {
                            foreach (string field in fields.Split('|'))
                            {
                                string[] spField = field.Split(',');
                                if (spField[2] == "2" || spField[2] == "3")
                                    hshFields.Add(spField[0], spField[1]);
                                if (spField[2] == "1" || spField[2] == "3")
                                    hshFields2.Add(spField[0], spField[1]);
                            }
                        }

                        string xml = "<Items>";

                        xml += ConfigFunctions.getItemXml(properties.ListItem, hshFields, properties.AfterProperties, properties.Web);

                        xml += "</Items>";

                        string ret = UpdateItemXml(xml, properties.Web);
                        //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99901, "WorkEnginePPM", "processItem", xml, ret);

                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(ret);

                        //XmlNode ndStatus = xmlDoc.SelectSingleNode("Reply/STATUS");

                        //if(ndStatus != null)
                        //{
                        if (xmlDoc.FirstChild.SelectSingleNode("//Item[@ItemId='" + properties.Web.ID + "." + properties.ListId + "." + properties.ListItemId + "']").Attributes["Error"].Value != "0")
                        {
                            properties.Cancel = true;
                            properties.ErrorMessage = "Error processing item: " + xmlDoc.FirstChild.SelectSingleNode("//Item[@ItemId='" + properties.Web.ID + "." + properties.ListId + "." + properties.ListItemId + "']").InnerText;
                            return;
                        }

                        CStruct xReply = new CStruct();
                        xReply.LoadXML("<Return>" + ret + "</Return>");

                        // the reply xml contains the "UpdateItems" xml sent back from PE

                        CStruct xUpdatePortfolioItems = xReply.GetSubStruct("UpdatePortfolioItems");
                        if (xUpdatePortfolioItems != null)
                        {
                            SPList list = properties.ListItem.ParentList;
                            string sItemID = list.ParentWeb.ID + "." + list.ID + "." + properties.ListItem.ID;
                            // <Item ItemId="cda5677f-08b8-44ab-8c63-f287d6200cd9.ec269b62-7fe5-47c9-8614-bb9752d4b8e8.3" ID="2" Error="2" ErrorText="Field Name 20017 not found"/>
                            // look for any item errors
                            List<CStruct> lstItems = xUpdatePortfolioItems.GetList("Item");
                            foreach (CStruct xItem in lstItems)
                            {
                                if (xItem.GetStringAttr("ItemId") == sItemID)
                                {
                                    int nError = xItem.GetIntAttr("Error");
                                    if (nError != 0)
                                    {
                                        properties.Cancel = true;
                                        properties.ErrorMessage = "Error processing item: " + nError.ToString() + " - " + xItem.GetStringAttr("ErrorText");
                                        //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99902, "WorkEnginePPM", "processItem", "error1", properties.ErrorMessage);
                                        return;
                                    }
                                }
                            }


                            CStruct xPortfolioItems = xUpdatePortfolioItems.GetSubStruct("PortfolioItems");
                            List<CStruct> lstPortfolioItems = xPortfolioItems.GetList("PortfolioItem");


                            SPItemEventDataCollection afterProperties = properties.AfterProperties;
                            foreach (CStruct xPortfolioItem in lstPortfolioItems)
                            {
                                if (xPortfolioItem.GetStringAttr("ItemID") == sItemID)
                                {

                                    List<CStruct> lstFields = xPortfolioItem.GetList("Field");
                                    //foreach (CStruct xField in lstFields)
                                    //{
                                    //    string sField = xField.GetStringAttr("ID");
                                    //    string sValue = xField.GetStringAttr("Value");
                                    //    if (hshFields.ContainsKey(sField))
                                    //    //if (list.Fields.ContainsField(sField))
                                    //    {
                                    //        string s = hshFields.Values.[sField];
                                    //        afterProperties[sField] = sValue;
                                    //    }
                                    //}

                                    foreach (DictionaryEntry field in hshFields2)
                                    {
                                        string spfield = field.Value.ToString();
                                        string epkfield = field.Key.ToString();

                                        CStruct xCurrentEPKField = null;
                                        foreach (CStruct xField in lstFields)
                                        {
                                            if (xField.GetStringAttr("ID") == epkfield)
                                            {
                                                xCurrentEPKField = xField;
                                                break;
                                            }
                                        }

                                        if (xCurrentEPKField != null)
                                        {
                                            string sValue = xCurrentEPKField.GetStringAttr("Value");
                                            SPField oField = null;
                                            try
                                            {
                                                oField = list.Fields.GetFieldByInternalName(spfield);
                                            }
                                            catch { }

                                            if (oField != null)
                                            {
                                                try
                                                {
                                                    if (oField.Type == SPFieldType.DateTime)
                                                    {
                                                        try
                                                        {
                                                            afterProperties[spfield] = sValue;
                                                        }
                                                        catch { }
                                                    }
                                                    else if (oField.Type == SPFieldType.User)
                                                    {
                                                        try
                                                        {
                                                            //SPUser user = web.AllUsers.GetByID(int.Parse(afterProperties[spfield].ToString().Split(';')[0]));
                                                            //val = EPMLiveCore.CoreFunctions.GetRealUserName(user.LoginName);
                                                        }
                                                        catch { }
                                                    }
                                                    else if (oField.Type == SPFieldType.Number || oField.Type == SPFieldType.Currency)
                                                    {
                                                        try
                                                        {
                                                            afterProperties[spfield] = sValue;
                                                        }
                                                        catch { }
                                                    }
                                                    else if (oField.Type == SPFieldType.Boolean)
                                                    {
                                                        try
                                                        {
                                                            afterProperties[spfield] = sValue;
                                                        }
                                                        catch { }

                                                    }
                                                    else if (oField.Type == SPFieldType.Calculated)
                                                    {
                                                        afterProperties[spfield] = sValue;
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            afterProperties[spfield] = sValue;
                                                        }
                                                        catch { }
                                                    }
                                                }
                                                catch { }
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        //}
                        //else
                        //{
                        //    properties.Cancel = true;
                        //    properties.ErrorMessage = "Error processing item: Unable to get status from Portfolio Integration.";
                        //    //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99904, "WorkEnginePPM", "processItem", "error2", properties.ErrorMessage);
                        //}
                    }
                }
                catch (Exception ex)
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = "General error processing item: " + ex.Message;
                    //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99904, "WorkEnginePPM", "processItem", "Exception", properties.ErrorMessage);
                }
            }
        }

        private string UpdateItemXml(string xml, SPWeb web)
        {
            string username = ConfigFunctions.GetCleanUsername(web);


            SPWeb rootWeb = web.Site.RootWeb;

            string basePath = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
            string ppmId = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
            string ppmCompany = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
            string ppmDbConn = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

            PortfolioEngineCore.PortfolioItems.PortfolioItems we = new PortfolioEngineCore.PortfolioItems.PortfolioItems(basePath, username, ppmId, ppmCompany, ppmDbConn, false);
            string ret = "";
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                ret = we.UpdatePortfolioItems(xml);
            });
            return ret;
        }

        private string CloseItemXml(string xml, SPWeb web)
        {
            string username = ConfigFunctions.GetCleanUsername(web);

            SPWeb rootWeb = web.Site.RootWeb;

            string basePath = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
            string ppmId = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
            string ppmCompany = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
            string ppmDbConn = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

            PortfolioEngineCore.PortfolioItems.PortfolioItems we = new PortfolioEngineCore.PortfolioItems.PortfolioItems(basePath, username, ppmId, ppmCompany, ppmDbConn, false);

            string ret = "";
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                ret = we.ClosePortfolioItems(xml);
            });
            return ret;
        }
    }
}

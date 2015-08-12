using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using System.Xml;
using System.Diagnostics;

namespace EPMLiveEnterprise
{
    public class ProjectWorkspaceSynch
    {
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

                Hashtable newFields = new Hashtable();
                Hashtable delFields = new Hashtable();
                Hashtable updFields = new Hashtable();

                SqlCommand cmd = new SqlCommand("select wssfieldname,editable from customfields where visible = 1 and fieldcategory in (3,4)", cn);
                //SqlCommand cmd = new SqlCommand("select wssfieldname,editable from customfields where visible = 1 and fieldcategory != 1", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    newFields.Add(dr.GetString(0), dr.GetBoolean(1));
                }
                dr.Close();

                SPList list = null;
                try
                {
                    list = myWebToPublish.Lists["Task Center"];
                }
                catch { }

                if (list != null)
                {                    
                    if (!list.Fields.ContainsField("transuid"))
                    {
                        SPFieldText fldTransUid = (SPFieldText)list.Fields.CreateNewField(SPFieldType.Text.ToString(), "transuid");
                        fldTransUid.Hidden = true;
                        fldTransUid.Required = false;
                        list.Fields.Add(fldTransUid);
                        list.Update();
                    }
                    if (!list.Fields.ContainsField("Summary"))
                    {
                        list.Fields.Add("Summary", SPFieldType.Boolean, false);
                        SPField f = list.Fields["Summary"];
                        f.DefaultValue = "0";
                        f.Hidden = false;
                        f.ShowInEditForm = false;
                        f.ShowInNewForm = false;
                        f.Update();

                    }
                    if (!list.Fields.ContainsField("IsAssignment"))
                    {
                        list.Fields.Add("IsAssignment", SPFieldType.Boolean, false);
                        SPField f = list.Fields["IsAssignment"];
                        f.DefaultValue = "0";
                        f.ShowInEditForm = false;
                        f.ShowInNewForm = false;
                        f.Update();
                    }
                    if (!list.Fields.ContainsField("TaskHierarchy"))
                    {
                        list.Fields.Add("TaskHierarchy", SPFieldType.Note, false);
                        SPField f = list.Fields["TaskHierarchy"];
                        f.ShowInEditForm = false;
                        f.ShowInNewForm = false;
                        f.Update();
                    }

                    WebSvcCustomFields.CustomFieldDataSet cfDs = new WebSvcCustomFields.CustomFieldDataSet();
                    try
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cfDs = pCf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));
                        });
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error in publishProject() Reading Custom Fields: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 320);
                    }

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
                                        string fieldName = field.InternalName.Substring(3);
                                        int temp = 0;
                                        if (int.TryParse(fieldName, out temp))
                                        {
                                            WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] drCf = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select("MD_PROP_ID=" + fieldName);
                                            
                                            if (drCf.Length > 0)
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
                                    catch { }
                                    try
                                    {
                                        newFields.Remove(field.InternalName);
                                    }
                                    catch { }
                                }
                            }
                        }
                    }

                    foreach (DictionaryEntry de in updFields)
                    {
                        try
                        {
                            SPField f = list.Fields[new Guid(de.Key.ToString())];
                            if (f.Type == SPFieldType.Choice)
                            {
                                string fieldName = f.InternalName.Substring(3);
                                int temp = 0;
                                if (int.TryParse(fieldName, out temp))
                                {
                                    f.SchemaXml = getSchemaXml(f, fieldName);
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

                            if (isCalculated(cfDs, f.InternalName.Substring(3)))
                            {
                                f.ShowInEditForm = false;
                                f.ShowInNewForm = false;
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
                            
                            f.Update();
                        }
                        catch (Exception ex)
                        {
                            myLog.WriteEntry("Error Updating Field (" + de.Key.ToString() + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 333);
                        }
                    }
                    foreach (DictionaryEntry de in newFields)
                    {
                        cmd = new SqlCommand("select * from customfields where wssfieldname=@fieldname", cn);
                        cmd.Parameters.AddWithValue("@fieldname", de.Key.ToString());
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            try
                            {
                                SPFieldType fType = SPFieldType.Text;
                                switch (dr.GetString(7))
                                {
                                    case "DATETIME":
                                        fType = SPFieldType.DateTime;
                                        break;
                                    case "DURATION":
                                        fType = SPFieldType.Number;
                                        break;
                                    case "NUMBER":
                                        fType = SPFieldType.Number;
                                        break;
                                    case "CURRENCY":
                                        fType = SPFieldType.Currency;
                                        break;
                                    case "BOOLEAN":
                                        fType = SPFieldType.Boolean;
                                        break;
                                    case "CHOICE":
                                        fType = SPFieldType.Choice;
                                        break;
                                }

                                list.Fields.Add(de.Key.ToString().Trim(), fType, false);

                                SPField f = list.Fields[de.Key.ToString()];
                                f.Title = dr.GetString(2);
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
                                dr.Close();
                                if (f.Type == SPFieldType.Choice)
                                {
                                    cmd = new SqlCommand("select * from customfields where wssfieldname=@fieldname and fieldcategory=3", cn);
                                    cmd.Parameters.AddWithValue("@fieldname", f.InternalName);
                                    dr = cmd.ExecuteReader();

                                    if (dr.Read())
                                    {
                                        f.SchemaXml = getSchemaXml(f, dr.GetString(0));
                                    }
                                    dr.Close();
                                }
                                if (isCalculated(cfDs, de.Key.ToString().Substring(3)))
                                {
                                    f.ShowInEditForm = false;
                                    f.ShowInNewForm = false;
                                }
                                f.Update();

                            }
                            catch (Exception ex)
                            {
                                myLog.WriteEntry("Error Adding Field: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 331);
                            }
                            try
                            {
                                dr.Close();
                            }
                            catch { }
                        }
                        dr.Close();
                    }
                }
                else
                {
                    //myLog.WriteEntry("Task Center was not found at site: " + myWebToPublish.Url, EventLogEntryType.Warning, 331);
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error Processing Task Center: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
            }
        }

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
                ArrayList newFields = new ArrayList();
                Hashtable allFields = new Hashtable();
                Hashtable delFields = new Hashtable();
                Hashtable updFields = new Hashtable();

                SqlCommand cmd = new SqlCommand("select wssfieldname,editable from customfields where pjvisible=1 order by displayname", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    allFields.Add(dr.GetString(0), dr.GetBoolean(1));
                    newFields.Add(dr.GetString(0));
                }
                dr.Close();

                //SPWeb web = mySite.OpenWeb(publishSiteUrl.Replace(mySite.Url, "").Substring(1));

                SPList list = null;
                try
                {
                    list = myWebToPublish.Lists["Project Center"];
                }
                catch { }

                if (list != null)
                {                    
                    if (!list.Fields.ContainsField("projectguid"))
                    {
                        SPFieldText fldProjUid = (SPFieldText)list.Fields.CreateNewField(SPFieldType.Text.ToString(), "projectguid");
                        fldProjUid.Hidden = true;
                        fldProjUid.Required = false;
                        list.Fields.Add(fldProjUid);
                        list.Update();
                    }

                    if (!list.Fields.ContainsField("IsProjectServer"))
                    {
                        list.Fields.Add("IsProjectServer", SPFieldType.Boolean, false);
                        SPField f = list.Fields["IsProjectServer"];
                        f.Hidden = true;
                        f.Update();
                    }

                    if (!list.Fields.ContainsField("PublishToPWA"))
                    {
                        list.Fields.Add("PublishToPWA", SPFieldType.Boolean, false);
                        SPField f = list.Fields["PublishToPWA"];
                        f.Hidden = false;
                        f.DefaultValue = "1";
                        f.Title = "Publish To Project Server";
                        f.Update();
                    }

                    if (!list.Fields.ContainsField("ProjectServerURL"))
                    {
                        list.Fields.Add("ProjectServerURL", SPFieldType.Text, false);
                        SPField f = list.Fields["ProjectServerURL"];
                        f.Hidden = false;
                        f.ShowInEditForm = false;
                        f.ShowInNewForm = false;
                        f.Sealed = true;
                        f.Title = "Project Server URL";
                        f.Update();
                    }

                    if (!list.Fields.ContainsField("SharePointProject"))
                    {
                        list.Fields.Add("SharePointProject", SPFieldType.Boolean, false);
                        SPField f = list.Fields["SharePointProject"];
                        f.Hidden = false;
                        f.DefaultValue = "1";
                        f.Title = "SharePoint Project";
                        f.Update();
                    }

                    WebSvcCustomFields.CustomFieldDataSet cfDs = new WebSvcCustomFields.CustomFieldDataSet();
                    try
                    {
                        cfDs = pCf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error in publishProject() Reading Custom Fields: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 320);
                    }

                    foreach (SPField field in list.Fields)
                    {
                        //if (field.Reorderable)
                        {
                            if (field.Type == SPFieldType.Boolean || field.Type == SPFieldType.Text || field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.DateTime || field.Type == SPFieldType.Choice || field.InternalName == "AssignedTo")
                            {

                                if (!newFields.Contains(field.InternalName))
                                {
                                    if (field.InternalName.Length > 3)
                                    {
                                        string fieldName = field.InternalName.Substring(3);
                                        int temp = 0;
                                        if (int.TryParse(fieldName, out temp))
                                        {
                                            WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] drCf = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select("MD_PROP_ID=" + fieldName);

                                            if (drCf.Length > 0)
                                            {
                                                updFields.Add(field.Id, false);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        updFields.Add(field.Id, field.ShowInEditForm);
                                    }
                                    catch { }
                                    try
                                    {
                                        newFields.Remove(field.InternalName);
                                    }
                                    catch { }
                                }
                            }
                        }
                    }

                    try
                    {
                        newFields.Remove("StartDate");
                    }
                    catch { }
                    try
                    {
                        newFields.Remove("DueDate");
                    }
                    catch { }

                    foreach (DictionaryEntry de in updFields)
                    {
                        try
                        {
                            SPField f = list.Fields[new Guid(de.Key.ToString())];
                            if (f.Type == SPFieldType.Choice)
                            {
                                string fieldName = f.InternalName.Substring(3);
                                int temp = 0;
                                if (int.TryParse(fieldName, out temp))
                                {
                                    f.SchemaXml = getSchemaXml(f, fieldName);
                                }
                            }
                            //bool show = false;
                            //try
                            //{
                            //    show = bool.Parse(de.Value.ToString());
                            //}
                            //catch { }
                            f.ShowInNewForm = false;
                            f.ShowInEditForm = false;
                            f.Update();
                        }
                        catch (Exception ex)
                        {
                            myLog.WriteEntry("Error Updating Field (" + de.Key.ToString() + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 333);
                        }
                    }
                    foreach (string str in newFields)
                    {
                        cmd = new SqlCommand("select * from customfields where wssfieldname=@fieldname", cn);
                        cmd.Parameters.AddWithValue("@fieldname", str);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            try
                            {
                                SPFieldType fType = SPFieldType.Text;
                                switch (dr.GetString(7))
                                {
                                    case "DATETIME":
                                        fType = SPFieldType.DateTime;
                                        break;
                                    case "DURATION":
                                        fType = SPFieldType.Number;
                                        break;
                                    case "NUMBER":
                                        fType = SPFieldType.Number;
                                        break;
                                    case "CURRENCY":
                                        fType = SPFieldType.Currency;
                                        break;
                                    case "BOOLEAN":
                                        fType = SPFieldType.Boolean;
                                        break;
                                    case "CHOICE":
                                        fType = SPFieldType.Choice;
                                        break;
                                }

                                list.Fields.Add(str, fType, false);

                                SPField f = list.Fields.GetFieldByInternalName(str);
                                f.Title = dr.GetString(2);

                                f.ShowInNewForm = false;
                                f.ShowInEditForm = false;

                                dr.Close();
                                if (f.Type == SPFieldType.Choice)
                                {
                                    cmd = new SqlCommand("select * from customfields where wssfieldname=@fieldname and (fieldcategory=3 OR fieldcategory=4)", cn);
                                    cmd.Parameters.AddWithValue("@fieldname", f.InternalName);
                                    dr = cmd.ExecuteReader();

                                    if (dr.Read())
                                    {
                                        f.SchemaXml = getSchemaXml(f, dr.GetString(0));
                                    }
                                    dr.Close();
                                }

                                f.Update();

                            }
                            catch (Exception ex)
                            {
                                myLog.WriteEntry("Error Adding Field To Project Center: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 331);
                            }
                            try
                            {
                                dr.Close();
                            }
                            catch { }
                        }
                        dr.Close();
                    }
                }
                else
                {
                    //myLog.WriteEntry("Project Center was not found at site: " + myWebToPublish.Url, EventLogEntryType.Warning, 331);
                }
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error Processing Project Center: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 330);
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
    }
}

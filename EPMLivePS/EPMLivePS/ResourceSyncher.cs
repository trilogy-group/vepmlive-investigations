using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveEnterprise
{
    class ResourceSyncher
    {
        private WebSvcCustomFields.CustomFields pCf;
        private WebSvcCustomFields.CustomFieldDataSet cfDs;
        private WebSvcResource.Resource pResource;
        private WebSvcLookupTables.LookupTable psiLookupTable;
        private SqlConnection cn;

        private Guid resEntity = new Guid(PSLibrary.EntityCollection.Entities.ResourceEntity.UniqueId);
        private Guid siteGuid;

        public ResourceSyncher(Guid siteId)
        {
            siteGuid = siteId;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(siteGuid))
                {
                    pCf = new WebSvcCustomFields.CustomFields();
                    pCf.Url = site.Url + "/_vti_bin/psi/customfields.asmx";
                    pCf.UseDefaultCredentials = true;
                    cfDs = new WebSvcCustomFields.CustomFieldDataSet();
                    cfDs = pCf.ReadCustomFieldsByEntity(resEntity);

                    psiLookupTable = new WebSvcLookupTables.LookupTable();
                    psiLookupTable.Url = site.Url + "/_vti_bin/psi/lookuptable.asmx";
                    psiLookupTable.UseDefaultCredentials = true;

                    pResource = new WebSvcResource.Resource();
                    pResource.Url = site.Url + "/_vti_bin/psi/resource.asmx";
                    pResource.UseDefaultCredentials = true;

                    //SPSecurity.RunWithElevatedPrivileges(delegate()
                    //{

                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();

                    //});
                }
            });
        }

        public void end()
        {
            if (cn != null)
                cn.Close();
        }

        public void synchResource(Guid resGuid)
        {

            using (SPSite site = new SPSite(siteGuid))
            {
                using (SPWeb web = site.RootWeb)
                {
                    string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                    if (resUrl != "")
                    {
                        using (SPSite tempSite = new SPSite(resUrl))
                        {
                            using (SPWeb resWeb = tempSite.OpenWeb())
                            {
                                resWeb.AllowUnsafeUpdates = true;
                                processResource(web, resGuid, resWeb);
                            }
                        }
                    }
                }
            }

            SqlCommand cmd = new SqlCommand("select config_value from econfig where config_name='ConnectedURLs'", cn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string sSites = dr.GetString(0);
                string[] strSites = sSites.Replace("\r\n", "\n").Split('\n');
                foreach (string strSite in strSites)
                {
                    try
                    {
                        using (SPSite site = new SPSite(strSite))
                        {
                            using (SPWeb web = site.OpenWeb())
                            {
                                string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                                if (resUrl != "")
                                {
                                    using (SPSite tempSite = new SPSite(resUrl))
                                    {
                                        using (SPWeb resWeb = tempSite.OpenWeb())
                                        {
                                            resWeb.AllowUnsafeUpdates = true;
                                            processResource(web, resGuid, resWeb);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            dr.Close();
        }

        public void processResource(SPWeb web, Guid resGuid, SPWeb resWeb)
        {
            WebSvcResource.ResourceDataSet rds = pResource.ReadResource(resGuid);

            
            try
            {
                SPUser user = null;
                SPGroup group = null;

                if (!rds.Resources[0].IsWRES_ACCOUNTNull())
                {
                    try
                    {
                        user = resWeb.SiteUsers[rds.Resources[0].WRES_ACCOUNT];
                    }
                    catch { }
                    if (user == null)
                    {
                        string email = "";
                        if (!rds.Resources[0].IsWRES_EMAILNull())
                            email = rds.Resources[0].WRES_EMAIL;

                        resWeb.SiteUsers.Add(rds.Resources[0].WRES_ACCOUNT, email, rds.Resources[0].RES_NAME, "");
                        user = resWeb.SiteUsers[rds.Resources[0].WRES_ACCOUNT];
                    }
                }
                else
                {
                    try
                    {
                        group = resWeb.SiteGroups[rds.Resources[0].RES_NAME];
                    }
                    catch { }
                }
                SPList list = resWeb.Lists["Resources"];

                if (!list.Fields.ContainsField("ResUid"))
                {
                    SPFieldText fldResUid = (SPFieldText)list.Fields.CreateNewField(SPFieldType.Text.ToString(), "ResUid");
                    fldResUid.Hidden = true;
                    fldResUid.Required = false;
                    list.Fields.Add(fldResUid);
                    list.Update();                    
                }

                DataRow []drFields = rds.ResourceCustomFields.Select("RES_UID='" + rds.Resources[0].RES_UID + "'");
                foreach (DataRow drField in drFields)
                {
                    try
                    {
                        string fname = "ENT" + drField["MD_PROP_ID"];
                        if (!list.Fields.ContainsField(fname))
                        {
                            addField(list, drField["MD_PROP_ID"].ToString(), drField["FIELD_TYPE_ENUM"].ToString());
                        }

                    }
                    catch { }
                }

                SPQuery query = new SPQuery();
                if(user != null)
                    query.Query = "<Where><Eq><FieldRef Name='SharePointAccount'/><Value Type='User'>" + user.Name + "</Value></Eq></Where>";
                else if(group != null)
                    query.Query = "<Where><Eq><FieldRef Name='SharePointAccount'/><Value Type='User'>" + group.Name + "</Value></Eq></Where>";
                else
                    query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + rds.Resources[0].RES_NAME + "</Value></Eq></Where>";

                SPListItemCollection lic = list.GetItems(query);

                SPListItem li = null;

                if (lic.Count > 0)
                {
                    li = lic[0];
                }
                else
                {
                    li = list.Items.Add();

                }

                if (user != null)
                    li["SharePointAccount"] = new SPFieldUserValue(resWeb, user.ID, user.Name);

                if (group != null)
                    li["SharePointAccount"] = new SPFieldUserValue(resWeb, group.ID, group.Name);

                li["ResUid"] = resGuid.ToString();

                if (li != null)
                {
                    string name = rds.Resources[0].RES_NAME;
                    string firstname = "";
                    try
                    {
                        firstname = name.Split(' ')[0];
                    }
                    catch { }
                    string lastname = "";
                    try
                    {
                        lastname = name.Substring(firstname.Length + 1);
                    }
                    catch { }

                    li["Title"] = rds.Resources[0].RES_NAME;
                    li["FirstName"] = firstname;
                    li["LastName"] = lastname;
                    if(!rds.Resources[0].IsWRES_EMAILNull())
                        li["Email"] = rds.Resources[0].WRES_EMAIL;

                    if (!rds.Resources[0].IsRES_TIMESHEET_MGR_UIDNull())
                    {
                        if (rds.Resources[0].RES_TIMESHEET_MGR_UID != rds.Resources[0].RES_UID)
                        {
                            WebSvcResource.ResourceDataSet tsRds = pResource.ReadResource(rds.Resources[0].RES_TIMESHEET_MGR_UID);
                            if (tsRds.Resources.Count > 0)
                            {
                                try
                                {
                                    SPUser tuser = null;

                                    try
                                    {
                                        tuser = resWeb.SiteUsers[tsRds.Resources[0].WRES_ACCOUNT];
                                    }
                                    catch { }
                                    if (tuser == null)
                                    {
                                        resWeb.SiteUsers.Add(tsRds.Resources[0].WRES_ACCOUNT, tsRds.Resources[0].WRES_EMAIL, tsRds.Resources[0].RES_NAME, "");
                                        tuser = resWeb.SiteUsers[tsRds.Resources[0].WRES_ACCOUNT];
                                    }

                                    li["TimesheetManager"] = new SPFieldUserValue(resWeb, tuser.ID, tuser.Name);
                                }
                                catch { }
                            }
                        }
                    }

                    foreach (DataRow drField in drFields)
                    {
                        try
                        {
                            string fname = "ENT" + drField["MD_PROP_ID"];
                            if (list.Fields.ContainsField(fname))
                            {
                                string fVal = getfieldvalue(drField);
                                li[list.Fields.GetFieldByInternalName("ENT" + drField["MD_PROP_ID"]).Id] = fVal;
                            }
                        }
                        catch { }
                    }

                    li.SystemUpdate();
                }
            }
            catch { }
        }

        private void addField(SPList list, string fieldid, string type)
        {
            DataRow[] dr = cfDs.CustomFields.Select("MD_PROP_ID=" + fieldid);

            if (dr.Length > 0)
            {
                SPFieldType t;
                switch (type)
                {
                    case "4":
                        t = SPFieldType.DateTime;
                        break;
                    case "6":
                    case "15":
                        t = SPFieldType.Number;
                        break;
                    case "17":
                        t = SPFieldType.Boolean;
                        break;
                    case "9":
                        t = SPFieldType.Currency;
                        break;
                    default:
                        t = SPFieldType.Text;
                        break;
                };

                list.Fields.Add("ENT" + fieldid, t, false);
                SPField f = list.Fields.GetFieldByInternalName("ENT" + fieldid);
                f.ShowInEditForm = false;
                f.Sealed = true;


                f.Title = dr[0]["MD_PROP_NAME"].ToString();

                f.Update();
            }

            
        }

        private string getLookupValue(DataRow drField)
        {
            WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] dr = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select("MD_PROP_ID=" + drField["MD_PROP_ID"].ToString());

            if (dr.Length > 0)
            {
                string tableuid = dr[0]["MD_LOOKUP_TABLE_UID"].ToString();

                WebSvcLookupTables.LookupTableDataSet dsLt = psiLookupTable.ReadLookupTablesByUids(new Guid[1] { new Guid(tableuid) }, false, 0);

                WebSvcLookupTables.LookupTableDataSet.LookupTableTreesRow[] tr = (WebSvcLookupTables.LookupTableDataSet.LookupTableTreesRow[])dsLt.LookupTableTrees.Select("LT_STRUCT_UID = '" + drField["CODE_VALUE"] + "'");

                switch ((PSLibrary.PSDataType)dr[0].MD_PROP_TYPE_ENUM)
                {
                    case PSLibrary.PSDataType.STRING:
                        return tr[0].LT_VALUE_TEXT;
                    case PSLibrary.PSDataType.COST:
                        return (tr[0].LT_VALUE_NUM / 100).ToString();
                    case PSLibrary.PSDataType.NUMBER:
                        return tr[0].LT_VALUE_NUM.ToString();
                }
            }

            return "";
        }

        private string getfieldvalue(DataRow drField)
        {
            try
            {
                if (drField["CODE_VALUE"].ToString() == "")
                {
                    switch (drField["FIELD_TYPE_ENUM"].ToString())
                    {

                        case "4":
                            return drField["Date_VALUE"].ToString();
                        case "6":
                            {
                                double dval = 0;
                                try
                                {
                                    dval = double.Parse(drField["DUR_VALUE"].ToString()) / 4800;
                                }
                                catch { }
                                return dval.ToString();
                            }
                        case "9":
                            {
                                double dval = 0;
                                try
                                {
                                    dval = double.Parse(drField["NUM_VALUE"].ToString()) / 100;
                                }
                                catch { }
                                return dval.ToString();
                            }
                        case "17":
                            if (drField["FLAG_VALUE"].ToString().ToLower() == "true")
                                return "1";
                            else
                                return "0";
                        case "15":
                            return drField["NUM_VALUE"].ToString();
                        case "21":
                            return drField["TEXT_VALUE"].ToString();
                        default:
                            return "";
                    };
                }
                else
                {
                    return getLookupValue(drField);
                }
            }
            catch { }
            return "";
        }

        public void synchAllResources()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                WebSvcResource.ResourceDataSet ds = pResource.ReadUserList(EPMLiveEnterprise.WebSvcResource.ResourceActiveFilter.All);
                using (SPSite site = new SPSite(siteGuid))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                        if (resUrl != "")
                        {
                            using (SPSite tempSite = new SPSite(resUrl))
                            {
                                using (SPWeb resWeb = tempSite.OpenWeb())
                                {
                                    resWeb.AllowUnsafeUpdates = true;
                                    foreach (WebSvcResource.ResourceDataSet.ResourcesRow row in ds.Resources)
                                    {
                                        processResource(web, row.RES_UID, resWeb);
                                    }
                                }
                            }
                        }
                    }
                }

                SqlCommand cmd = new SqlCommand("select config_value from econfig where config_name='ConnectedURLs'", cn);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string sSites = dr.GetString(0);
                    string[] strSites = sSites.Replace("\r\n", "\n").Split('\n');
                    foreach (string strSite in strSites)
                    {
                        try
                        {
                            using (SPSite site = new SPSite(strSite))
                            {
                                using (SPWeb web = site.OpenWeb())
                                {
                                    string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                                    if (resUrl != "")
                                    {
                                        using (SPSite tempSite = new SPSite(resUrl))
                                        {
                                            using (SPWeb resWeb = tempSite.OpenWeb())
                                            {
                                                resWeb.AllowUnsafeUpdates = true;
                                                foreach (WebSvcResource.ResourceDataSet.ResourcesRow row in ds.Resources)
                                                {
                                                    processResource(web, row.RES_UID, resWeb);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }
                dr.Close();
            });

        }


        public void deleteResource(Guid resGuid)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate(){
                using (SPSite site = new SPSite(siteGuid))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        doDeleteResource(site, web, resGuid);
                    }
                }

                SqlCommand cmd = new SqlCommand("select config_value from econfig where config_name='ConnectedURLs'", cn);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string sSites = dr.GetString(0);
                    string[] strSites = sSites.Replace("\r\n", "\n").Split('\n');
                    foreach (string strSite in strSites)
                    {
                        try
                        {
                            using (SPSite site = new SPSite(strSite))
                            {
                                using (SPWeb web = site.OpenWeb())
                                {
                                    doDeleteResource(site, web, resGuid);
                                }
                            }
                        }
                        catch { }
                    }
                }
                dr.Close();
            });
        }

        private void doDeleteResource(SPSite site, SPWeb web, Guid resGuid)
        {
            WebSvcResource.ResourceDataSet rds = pResource.ReadResource(resGuid);

            string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL",true,false);
            if (resUrl != "")
            {
                using (SPSite tempSite = new SPSite(resUrl))
                {
                    using (SPWeb resWeb = tempSite.OpenWeb())
                    {
                        try
                        {
                            SPUser user = resWeb.SiteUsers[rds.Resources[0].WRES_ACCOUNT];

                            SPList list = resWeb.Lists["Resources"];
                            SPQuery query = new SPQuery();
                            query.Query = "<Where><Eq><FieldRef Name='SharePointAccount'/><Value Type='User'>" + user.Name + "</Value></Eq></Where>";

                            SPListItemCollection lic = list.GetItems(query);

                            SPListItem li = null;

                            if (lic.Count > 0)
                            {
                                lic[0].Delete();
                            }
                        }
                        catch { }
                    }
                }
            }
        }
    }
}

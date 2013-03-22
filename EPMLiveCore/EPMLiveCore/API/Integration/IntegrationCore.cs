using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using EPMLiveIntegration;
using System.Xml;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore.API.Integration
{
    public class IntegrationCore
    {
        SPSite _site;
        SPWeb _web;
        SqlConnection cn;
        private bool WasOpen = false;

        private class IntegratorDef
        {
            public IIntegrator iIntegrator;
            public string Title;
            public string IntKey;
            public Guid ListId;
            public string intcol;
            public Guid intlistid;
        }

        public IntegrationCore(Guid SiteId, Guid WebId)
        {
            _site = new SPSite(SiteId);
            _web = _site.OpenWeb(WebId);
            cn = new SqlConnection(CoreFunctions.getConnectionString(_site.WebApplication.Id));
        }

        public DataTable GetIntegrationsForList(Guid ListId)
        {
            DataSet ds = new DataSet();

            OpenConnection();

            SqlCommand cmd = new SqlCommand("select INT_LIST_ID as intlistid, priority, Title as intname , CASE WHEN ACTIVE = 1 THEN 'Yes' ELSE 'No' END AS Active FROM dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID where LIST_ID=@listid order by priority", cn);
            cmd.Parameters.AddWithValue("@listid", ListId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            CloseConnection(false);

            return ds.Tables[0];
        }

        internal bool InstallIntegration(Guid intlistid, Guid listid, out string message)
        {
            try
            {
                IntegratorDef integrator = GetIntegrator(intlistid);

                IntegrationLog log = new IntegrationLog(cn, intlistid, listid, integrator.Title);

                Hashtable hshProps = GetProperties(intlistid);

                WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);

                return integrator.iIntegrator.InstallIntegration(webprops, log, out message, integrator.IntKey, GetAPIUrl(_site.WebApplication.Id));
            }
            catch(Exception ex)
            {
                message = "Install Error: " + ex.Message;
                return false;
            }
        }

        internal SPListItem GetListItemFromExternalID(string intlistid, string intuid)
        {

            IntegratorDef def = GetIntegrator(new Guid(intlistid));

            SPList list = _web.Lists[def.ListId];

            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='" + def.intcol + "'/><Value Type='Text'>" + intuid + "</Value></Eq></Where>";
            SPListItemCollection lic = list.GetItems(query);
            if(lic.Count > 0)
            {

                return lic[0];

            }
            else
                return null;

        }

        internal bool RemoveIntegration(Guid intlistid, Guid listid, out string message)
        {
            try
            {
                IntegratorDef integrator = GetIntegrator(intlistid);

                IntegrationLog log = new IntegrationLog(cn, intlistid, listid, integrator.Title);

                Hashtable hshProps = GetProperties(intlistid);

                WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);

                return integrator.iIntegrator.RemoveIntegration(webprops, log, out message, integrator.IntKey);
            }
            catch(Exception ex)
            {
                message = "Remove Error: " + ex.Message;
                return false;
            }
        }

        public DataTable GetIntegrations(bool bOnline)
        {
            DataSet ds = new DataSet();

            OpenConnection();

            string sql = "";
            if(bOnline)
                sql = "SELECT * FROM INT_MODULES WHERE AvailableOnline = 1";
            else
                sql = "SELECT * FROM INT_MODULES";

            SqlCommand cmd = new SqlCommand(sql, cn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            CloseConnection(false);

            return ds.Tables[0];
        }

        public void ExecuteEvent(DataRow dr)
        {
            try
            {
                
                OpenConnection();

                if(dr["DIRECTION"].ToString() == "1")
                    ProcessItemOutgoing(dr);
                else if(dr["DIRECTION"].ToString() == "2")
                    ProcessItemIncoming(dr); 

                CloseConnection(true);
                
            }
            catch(Exception ex)
            {
                LogMessage("", dr["LIST_ID"].ToString(), "ExecuteEvent: " + ex.Message, 3);
            }
        }

        





        #region private functions

        internal void SaveProperties(Guid intlistid, Hashtable hshProps)
        {
            OpenConnection();

            foreach(DictionaryEntry de in hshProps)
            {
                SqlCommand cmd = new SqlCommand("SPIntSetProperty", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intlistid", intlistid);
                cmd.Parameters.AddWithValue("@property", de.Key.ToString());
                cmd.Parameters.AddWithValue("@value", de.Value.ToString());
                cmd.ExecuteNonQuery();


            }

            CloseConnection(false);
        }

        internal DataSet GetDataSet(string sql, Hashtable sqlparams)
        {
            OpenConnection();

            DataSet ds = new DataSet();
            
            SqlCommand cmd = new SqlCommand(sql, cn);
            foreach(DictionaryEntry de in sqlparams)
                cmd.Parameters.AddWithValue("@" + de.Key.ToString(), de.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            CloseConnection(false);

            return ds;
        }

        internal void ExecuteQuery(string sql, Hashtable sqlparams, bool Close)
        {
            OpenConnection();

            SqlCommand cmd = new SqlCommand(sql, cn);
            foreach(DictionaryEntry de in sqlparams)
                cmd.Parameters.AddWithValue("@" + de.Key.ToString(), de.Value);
            cmd.ExecuteNonQuery();

            if(Close)
                CloseConnection(true);
        }

        internal Dictionary<String, String> GetDropDownProperties(Guid moduleid, Guid intlistid, Guid listid, string property, string parentpropertvalue)
        {
            string title = "";

            IIntegrator integrator = GetIntegratorFromModule(moduleid, out title);

            IntegrationLog log = new IntegrationLog(cn, intlistid, listid, title);

            Hashtable hshProps = GetProperties(intlistid);

            WebProperties webprops = GetWebProps(hshProps, intlistid);

            return integrator.GetDropDownValues(webprops, log, property, parentpropertvalue);
        }

        internal bool TestModuleConnection(Guid moduleid, Guid intlistid, Guid listid, out string message)
        {
            string title = "";

            IIntegrator integrator = GetIntegratorFromModule(moduleid, out title);

            IntegrationLog log = new IntegrationLog(cn, intlistid, listid, title);

            Hashtable hshProps = GetProperties(intlistid);

            WebProperties webprops = GetWebProps(hshProps, intlistid);

            return integrator.TestConnection(webprops, log, out message);
        }

        internal List<ColumnProperty> GetColumns(Hashtable Properties, Guid moduleid, Guid intlistid, SPList list)
        {
            string title = "";

            IIntegrator integrator = GetIntegratorFromModule(moduleid, out title);

            IntegrationLog log = new IntegrationLog(cn, intlistid, list.ID, title);

            WebProperties webprops = GetWebProps(Properties, intlistid);

            return integrator.GetColumns(webprops, log, list.Title);
        }

        internal bool TestModuleConnection(Guid moduleid, Guid intlistid, Guid listid, Hashtable Properties, out string message)
        {
            string title = "";

            IIntegrator integrator = GetIntegratorFromModule(moduleid, out title);

            IntegrationLog log = new IntegrationLog(cn, intlistid, listid, title);

            WebProperties webprops = GetWebProps(Properties, intlistid);

            return integrator.TestConnection(webprops, log, out message);
        }

        internal XmlDocument GetModuleProperties(Guid intlistid, Guid moduleid)
        {
            string sql = "";
            if(intlistid == Guid.Empty)
                sql = "SELECT CustomProps FROM INT_MODULES where module_id=@moduleid";
            else
                sql = "SELECT   CustomProps  FROM         dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID where int_list_id=@intlistid";

            Hashtable hshParams = new Hashtable();

            if(intlistid == Guid.Empty)
                hshParams.Add("moduleid", moduleid);
            else
                hshParams.Add("intlistid", intlistid);

            DataSet ds = GetDataSet(sql, hshParams);
            DataTable dt = ds.Tables[0];


            XmlDocument doc = new XmlDocument();
            if(dt.Rows.Count > 0)
                doc.LoadXml(dt.Rows[0]["CustomProps"].ToString());

            return doc;

        }


        private string GetLookupItem(string listid, string intuid, Guid intlistid, Guid moduleid)
        {

            SPList list = _web.Lists[new Guid(listid)];

            Hashtable hshParams = new Hashtable();
            hshParams.Add("moduleid", moduleid);
            hshParams.Add("listid", listid);

            DataSet ds = GetDataSet("SELECT * FROM INT_LISTS where MODULE_ID=@moduleid and LIST_ID=@listid", hshParams);

            if(ds.Tables[0].Rows.Count > 0)
            {
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='INTUID" + ds.Tables[0].Rows[0]["INT_COLID"].ToString() + "'/><Value Type='Text'>" + intuid + "</Value></Eq></Where>";
                SPListItemCollection lic = list.GetItems(query);
                if(lic.Count > 0)
                {

                    return lic[0].ID + ";#" + lic[0].Title;

                }
                else
                    return null;
            }
            return null;
        }

        private void ProcessItemRow(DataRow dr, SPList list, DataTable dtColumns, Hashtable Properties, string ColId, Guid intlistid, Guid moduleid, bool bCanAdd, DataTable dtUserFields, Hashtable hshUserMap, bool bBuildTeamSec)
        {

            

            int ownerid = 0;

            if(bBuildTeamSec)
            {
                try
                {
                    if(Properties["SecMatch"].ToString() != "")
                    {

                        ownerid = new SPFieldLookupValue(hshUserMap[dr[Properties["SecMatch"].ToString()]].ToString()).LookupId;

                    }
                }
                catch { }
            }

            if(ownerid != 0)
            {
                SPUser user = null;
                try
                {
                    user = list.ParentWeb.SiteUsers.GetByID(ownerid);
                }
                catch { }
                if(user != null)
                {
                    using(SPSite site = new SPSite(list.ParentWeb.Site.ID, user.UserToken))
                    {
                        using(SPWeb web = site.OpenWeb(list.ParentWeb.ID))
                        {
                            SPList tlist = web.Lists[list.ID];
                            iProcessItemRow(dr, tlist, dtColumns, Properties, ColId, intlistid, moduleid, bCanAdd, dtUserFields, hshUserMap);
                        }
                    }
                }
                else
                    iProcessItemRow(dr, list, dtColumns, Properties, ColId, intlistid, moduleid, bCanAdd, dtUserFields, hshUserMap);
            }
            else
            {
                iProcessItemRow(dr, list, dtColumns, Properties, ColId, intlistid, moduleid, bCanAdd, dtUserFields, hshUserMap);
            }

            
        }

        internal int iProcessItemRow(DataRow dr, SPList list, DataTable dtColumns, Hashtable Properties, string ColId, Guid intlistid, Guid moduleid, bool bCanAdd, DataTable dtUserFields, Hashtable hshUserMap)
        {
            int itemid = 0;
            string matchList = "";
            string matchInt = "";
            try
            {
                string[] match = Properties["ItemMatch"].ToString().Split('|');
                matchInt = match[1];
                matchList = match[0];
            }
            catch { }

            if(dr["ID"].ToString() == "")
            {
                if(matchList != "")
                {
                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='" + matchList + "'/><Value Type='Text'>" + dr[matchInt].ToString() + "</Value></Eq></Where>";
                    SPListItemCollection lic = list.GetItems(query);
                    if(lic.Count > 0)
                    {
                        SPListItem li = lic[0];

                        bool bAlreadyMatched = false;
                        try
                        {
                            SPField field = list.Fields.GetFieldByInternalName("INTUID" + ColId);

                            if(li[field.Id].ToString() != "")
                                bAlreadyMatched = true;
                        }
                        catch { }

                        if(!bAlreadyMatched)
                        {
                            itemid = li.ID;
                            ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                        }
                    }
                }
            }
            else
            {
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='INTUID" + ColId + "'/><Value Type='Text'>" + dr["ID"].ToString() + "</Value></Eq></Where>";
                SPListItemCollection lic = list.GetItems(query);
                if(lic.Count > 0)
                {
                    SPListItem li = lic[0];
                    itemid = li.ID;
                    ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                }
                else if(matchList != "")
                {
                    query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='" + matchList + "'/><Value Type='Text'>" + dr[matchInt].ToString() + "</Value></Eq></Where>";
                    lic = list.GetItems(query);
                    if(lic.Count > 0)
                    {
                        SPListItem li = lic[0];
                        itemid = li.ID;
                        bool bAlreadyMatched = false;
                        try
                        {
                            SPField field = list.Fields.GetFieldByInternalName("INTUID" + ColId);

                            if(li[field.Id].ToString() != "")
                                bAlreadyMatched = true;
                        }
                        catch { }

                        if(!bAlreadyMatched)
                        {
                            ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                        }
                        else
                        {
                            if(bCanAdd)
                            {
                                li = list.Items.Add();

                                ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                                itemid = li.ID;
                            }
                        }
                    }
                    else
                    {
                        if(bCanAdd)
                        {
                            SPListItem li = list.Items.Add();

                            ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                            itemid = li.ID;
                        }
                    }
                }
                else
                {
                    if(bCanAdd)
                    {
                        SPListItem li = list.Items.Add();

                        ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                        itemid = li.ID;
                    }
                }
            }

            return itemid;
        }

        internal void ProcessLIItem(SPList list, SPListItem li, DataRow dr, DataTable dtColumns, string ColId, Guid intlistid, Guid moduleid, Hashtable hshUserMap, DataTable dtUserFields)
        {
            try
            {

                SPField field = list.Fields.GetFieldByInternalName("INTUID" + ColId);

                li[field.Id] = dr["ID"].ToString();

                foreach(DataRow drC in dtColumns.Rows)
                {
                    if(drC["IntegrationColumn"].ToString() != "ID")
                    {
                        field = null;
                        try
                        {
                            field = list.Fields.GetFieldByInternalName(drC["SharePointColumn"].ToString());
                        }
                        catch { }

                        if(field != null)
                        {
                            if(field.Type == SPFieldType.User)
                            {
                                string uInfo = "";
                                try
                                {
                                    string[] userinfo = dr[drC["IntegrationColumn"].ToString()].ToString().Split(',');
                                    foreach(string sInfo in userinfo)
                                    {
                                        if(sInfo != "" && hshUserMap.Contains(sInfo))
                                            uInfo += ";#" + hshUserMap[sInfo].ToString();
                                    }

                                    uInfo = uInfo.Trim(';').Trim('#');
                                }
                                catch { }
                                if(uInfo != "")
                                {
                                    li[field.Id] = uInfo;
                                }
                                else
                                {
                                    li[field.Id] = null;
                                }
                            }
                            else if(field.Type == SPFieldType.DateTime)
                            {
                                string sDateVal = dr[drC["IntegrationColumn"].ToString()].ToString();
                                if(sDateVal != "")
                                {
                                    li[field.Id] = sDateVal;
                                }
                                else
                                {
                                    li[field.Id] = null;
                                }
                            }
                            else if(field.Type == SPFieldType.Lookup)
                            {
                                if(drC["Setting"].ToString() != "1")
                                {
                                    DataRow[] drColUser = dtUserFields.Select("Fieldname='" + drC["SharePointColumn"].ToString() + "'");
                                    if(drColUser[0]["LookupIntColID"].ToString() != "")
                                        li[field.Id] = GetLookupItem(((SPFieldLookup)field).LookupList, dr[drC["IntegrationColumn"].ToString()].ToString(), intlistid, moduleid);
                                    else
                                        li[field.Id] = dr[drC["IntegrationColumn"].ToString()].ToString();
                                }
                                else
                                {
                                    li[field.Id] = dr[drC["IntegrationColumn"].ToString()].ToString();
                                }
                            }
                            else
                                li[field.Id] = dr[drC["IntegrationColumn"].ToString()].ToString();
                        }
                    }
                }

                li.SystemUpdate();
            }
            catch(Exception ex)
            {
                LogMessage(intlistid.ToString(), list.ID.ToString(), "Error Updating Item From Incoming: " + ex.Message, 3);
            }
        }



        private void ProcessItemIncoming(DataRow dr)
        {
            try
            {
                SPList list = _web.Lists[new Guid(dr["LIST_ID"].ToString())];

                GridGanttSettings settings = new GridGanttSettings(list);

                bool bBuildTeamSec = settings.BuildTeamSecurity;

                Hashtable parms = new Hashtable();
                parms.Add("listid", list.ID);
                parms.Add("colid", dr["COL_ID"].ToString());

                DataSet dsInt = GetDataSet("SELECT * FROM INT_LISTS where LIST_ID=@listid and INT_COLID=@colid", parms);


                if(dsInt.Tables[0].Rows.Count > 0)
                {
                    DataRow drIntegration = dsInt.Tables[0].Rows[0];

                    if(dr["TYPE"].ToString() == "1")//Update
                    {

                        Hashtable props = GetProperties(new Guid(drIntegration["INT_LIST_ID"].ToString()));

                        if(drIntegration["LIVEINCOMING"].ToString().ToLower() == "true")
                        {

                            parms.Add("intlistid", drIntegration["INT_LIST_ID"].ToString());
                            DataSet dsColumns = GetDataSet("SELECT * FROM INT_COLUMNS where INT_LIST_ID=@intlistid", parms);
                            DataTable dtCols = dsColumns.Tables[0];

                            DataTable dtItem = new DataTable();
                            dtItem.Columns.Add("ID");
                            foreach(DataRow drCol in dtCols.Rows)
                            {
                                dtItem.Columns.Add(drCol["IntegrationColumn"].ToString());
                            }

                            try
                            {
                                if(props["SecMatch"].ToString() != "")
                                    if(!dtItem.Columns.Contains(props["SecMatch"].ToString()))
                                        dtItem.Columns.Add(props["SecMatch"].ToString());
                            }
                            catch { }


                            dtItem = GetExternalItem(dtItem, new Guid(drIntegration["INT_LIST_ID"].ToString()), list.ID, dr["INTITEM_ID"].ToString());
                            
                            DataSet dsUserFields = GetDataSet(list, "", Guid.Empty);
                            DataTable dtUserFields = dsUserFields.Tables[1];
                            Hashtable hshUserMap = new Hashtable();
                            if(dtUserFields.Select("Type='1'").Length > 0 || bBuildTeamSec)
                            {
                                hshUserMap = GetUserMap(drIntegration["INT_LIST_ID"].ToString(), true);
                            }

                            foreach(DataRow drItem in dtItem.Rows)
                            {
                                

                                bool bCanAdd = false;

                                try {
                                    bCanAdd = bool.Parse(props["AllowAddList"].ToString());
                                }
                                catch { }

                                try
                                {
                                    if(props["SecMatch"].ToString() == "")
                                        bBuildTeamSec = false;
                                }
                                catch { bBuildTeamSec = false; }

                                ProcessItemRow(drItem, list, dtCols, props, dr["COL_ID"].ToString(), new Guid(drIntegration["INT_LIST_ID"].ToString()), new Guid(drIntegration["MODULE_ID"].ToString()), bCanAdd, dtUserFields, hshUserMap, bBuildTeamSec);
                            }
                        }
                    }
                    else if(dr["TYPE"].ToString() == "2")//Delete
                    {
                        Hashtable props = GetProperties(new Guid(drIntegration["INT_LIST_ID"].ToString()));

                        bool CanDelete = false;
                        try
                        {
                            CanDelete = bool.Parse(props["AllowDeleteList"].ToString());
                        }
                        catch { }

                        if(CanDelete)
                        {
                            DeleteSharePointItem(list, dr["INTITEM_ID"].ToString(), dr["COL_ID"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogMessage("", dr["LIST_ID"].ToString(), "ProcessItemIncoming: " + ex.Message, 3);
            }
        }

        private void DeleteSharePointItem(SPList list, string intuid, string col)
        {
            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='INTUID" + col + "'/><Value Type='Text'>" + intuid + "</Value></Eq></Where>";
            SPListItemCollection lic = list.GetItems(query);
            if(lic.Count > 0)
            {
                lic[0].Delete();

            }
        }

        internal void UpdatePriorityNumbers(Guid listid)
        {
            OpenConnection();

            SqlCommand cmd = new SqlCommand("SELECT INT_LIST_ID FROM INT_LISTS where LIST_ID=@listid order by priority", cn);
            cmd.Parameters.AddWithValue("@listid", listid);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            int counter = 1;

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                cmd = new SqlCommand("UPDATE INT_LISTS set Priority=@priority where INT_LIST_ID=@intlistid", cn);
                cmd.Parameters.AddWithValue("@intlistid", dr["INT_LIST_ID"].ToString());
                cmd.Parameters.AddWithValue("@priority", counter);
                cmd.ExecuteNonQuery();

                counter++;
            }

            CloseConnection(false);
        }

        private void ProcessItemOutgoing(DataRow dr)
        {
            try
            {
                if(dr["TYPE"].ToString() == "1")//Update
                {
                    SPList list = _web.Lists[new Guid(dr["LIST_ID"].ToString())];
                    SPListItem li = list.Items.GetItemById(int.Parse(dr["ITEM_ID"].ToString()));

                    DataSet dsItem = GetDataSet(list, dr["COL_ID"].ToString(), Guid.Empty);

                    ProcessItem(dsItem, li, list);

                    for(int i = 2; i < dsItem.Tables.Count; i++)
                    {

                        PostIntegration(dsItem.Tables[0].Copy(), dsItem.Tables[1], dsItem.Tables[i], list);

                    }
                }
                else if(dr["TYPE"].ToString() == "2")//Delete
                {

                    DataTable dtItems = new DataTable();
                    dtItems.Columns.Add("ID");
                    dtItems.Columns.Add("SPID");

                    dtItems.Rows.Add(new string[] { dr["INTITEM_ID"].ToString(), dr["ITEM_ID"].ToString() });

                    OpenConnection();

                    SqlCommand cmd = new SqlCommand("SELECT INT_LIST_ID FROM INT_LISTS where LIST_ID=@listid and INT_COLID=@intcolid", cn);
                    cmd.Parameters.AddWithValue("@listid", dr["LIST_ID"].ToString());
                    cmd.Parameters.AddWithValue("@intcolid", dr["COL_ID"].ToString());
                    Guid intlistid = Guid.Empty;
                    SqlDataReader drintlistid = cmd.ExecuteReader();
                    if(drintlistid.Read())
                    {
                        intlistid = drintlistid.GetGuid(0);
                    }
                    drintlistid.Close();

                    Hashtable props = GetProperties(intlistid);

                    bool CanDelete = false;
                    try
                    {
                        CanDelete = bool.Parse(props["AllowDeleteInt"].ToString());
                    }
                    catch { }

                    if(CanDelete)
                    {
                        PostIntegrationDeleteToExternal(dtItems, intlistid, new Guid(dr["LIST_ID"].ToString()));
                    }

                    
                }
            }
            catch(Exception ex)
            {
                LogMessage("", dr["LIST_ID"].ToString(), "ProcessItemOutgoing: " + ex.Message, 3);
            }
        }

        internal void LogMessage(string intlistid, string listid, string message, int type)
        {
            OpenConnection();

            SqlCommand cmdError = new SqlCommand("INSERT INTO INT_LOG (INT_LIST_ID, LIST_ID, LOGTYPE, LOGTEXT) VALUES (@intlistid, @listid, @type, @text)", cn);
            if(intlistid != "")
                cmdError.Parameters.AddWithValue("@intlistid", intlistid);
            else
                cmdError.Parameters.AddWithValue("@intlistid", DBNull.Value);
            cmdError.Parameters.AddWithValue("@listid", listid);
            cmdError.Parameters.AddWithValue("@text", message);
            cmdError.Parameters.AddWithValue("@type", type);
            cmdError.ExecuteNonQuery();

            CloseConnection(false);
        }

        internal Hashtable GetUserMap(string integrationlistid, bool reverse)
        {
            Hashtable hsh = new Hashtable();

            string mapping = "Username";

            SqlCommand cmd = new SqlCommand("SELECT VALUE FROM INT_PROPS where INT_LIST_ID=@intlistid and PROPERTY='UserMapType'", cn);
            cmd.Parameters.AddWithValue("@intlistid", integrationlistid);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
                mapping = dr.GetString(0);
            dr.Close();

            switch(mapping)
            {
                case "Email":
                case "Title":
                case "SPID":
                case "Username":
                    break;
                case "UID":
                    string moduleid = "";
                    string colid = "";

                    cmd = new SqlCommand("SELECT MODULE_ID FROM INT_LISTS where INT_LIST_ID=@intlistid", cn);
                    cmd.Parameters.AddWithValue("@intlistid", integrationlistid);
                    dr = cmd.ExecuteReader();
                    if(dr.Read())
                        moduleid = dr.GetGuid(0).ToString();
                    dr.Close();
                    if(moduleid != "")
                    {
                        string listid = "";

                        Guid lWeb = CoreFunctions.getLockedWeb(_web);
                        if(lWeb != _web.ID)
                        {
                            using(SPWeb oWeb = _site.OpenWeb(lWeb))
                            {
                                SPList list = oWeb.Lists.TryGetList("Resources");
                                if(list != null)
                                {
                                    listid = list.ID.ToString();
                                } 
                            }

                        }
                        else
                        {
                            SPList list = _web.Lists.TryGetList("Resources");
                            if(list!=null)
                            {
                                listid = list.ID.ToString();
                            }
                        }

                        if(listid != "")
                        {
                            cmd = new SqlCommand("SELECT INT_COLID FROM INT_LISTS where LIST_ID=@listid and MODULE_ID=@moduleid", cn);
                            cmd.Parameters.AddWithValue("@listid", listid);
                            cmd.Parameters.AddWithValue("@moduleid", moduleid);
                            dr = cmd.ExecuteReader();
                            if(dr.Read())
                                colid = dr.GetInt32(0).ToString();
                            dr.Close();
                        }
                    }
                    if(colid != "")
                    {
                        mapping = "INTUID" + colid;
                    }
                    else
                    {
                        mapping = "Username";
                    }

                    break;
                default:
                    mapping = "Username";
                    break;
            }

            DataTable dtResources = API.APITeam.GetResourcePool("<Columns>" + mapping + "</Columns>", _web);

            foreach(DataRow drRes in dtResources.Rows)
            {
                if(drRes[mapping].ToString() != "")
                {
                    if(reverse)
                    {
                        if(!hsh.Contains(drRes[mapping].ToString()))
                            hsh.Add(drRes[mapping].ToString(), drRes["SPAccountInfo"].ToString());   
                    }
                    else
                    {
                        if(!hsh.Contains(drRes["SPAccountInfo"].ToString()))
                            hsh.Add(drRes["SPAccountInfo"].ToString(), drRes[mapping].ToString());
                    }
                }
            }

            return hsh;
        }

        internal void PostIntegration(DataTable dtItems, DataTable dtUserFields, DataTable dtColumns, SPList list)
        {
            try
            {
                string colidname = "";
                try
                {
                    colidname = dtColumns.Select("IntegrationColumn='ID'")[0]["SharePointColumn"].ToString();
                }
                catch { }
                Hashtable hshUserMap = new Hashtable();
                if(dtUserFields.Select("Type='1'").Length > 0)
                {
                    hshUserMap = GetUserMap(dtColumns.TableName, false);
                }

                ArrayList arrColsDel = new ArrayList();
                
                Hashtable hshProps = GetProperties(new Guid(dtColumns.TableName));
                
                foreach(DataColumn dc in dtItems.Columns)
                {
                    if(dc.ColumnName != "SPID")
                    {
                        DataRow[] drColMap = dtColumns.Select("SharePointColumn='" + dc.ColumnName + "'");
                        DataRow[] drColUser = dtUserFields.Select("Fieldname='" + dc.ColumnName + "'");

                        if(drColMap.Length > 0)
                        {
                            dc.ColumnName = drColMap[0]["IntegrationColumn"].ToString();
                        }
                        else
                        {
                            arrColsDel.Add(dc);
                        }

                        if(drColUser.Length > 0)
                        {
                            if(drColUser[0]["Type"].ToString() == "1")
                            {
                                foreach(DataRow dr in dtItems.Rows)
                                {
                                    string newUserString = "";

                                    try
                                    {
                                        SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(_web, dr[dc.ColumnName].ToString());

                                        foreach(SPFieldUserValue uv in uvc)
                                        {
                                            try
                                            {
                                                newUserString += "," + hshUserMap[uv.LookupId + ";#" + uv.LookupValue].ToString();
                                            }
                                            catch { }
                                        }
                                    }
                                    catch { }

                                    dr[dc.ColumnName] = newUserString.Trim(',');
                                }
                            }
                            else if(drColUser[0]["Type"].ToString() == "2" && drColMap[0]["Setting"].ToString() != "1")
                            {
                                if(drColUser[0]["LookupIntColID"].ToString() != "")
                                {
                                    SPList lookupList = _web.Lists[new Guid(drColUser[0]["LookupList"].ToString())];

                                    string col = "INTUID" + drColUser[0]["LookupIntColID"].ToString();

                                    foreach(DataRow dr in dtItems.Rows)
                                    {
                                        try
                                        {
                                            SPFieldLookupValue lv = new SPFieldLookupValue(dr[dc.ColumnName].ToString());

                                            SPListItem li = lookupList.GetItemById(lv.LookupId);

                                            dr[dc.ColumnName] = li[col].ToString();
                                        }
                                        catch { dr[dc.ColumnName] = ""; }

                                    }
                                }
                                else
                                {
                                    foreach(DataRow dr in dtItems.Rows)
                                    {
                                        try
                                        {
                                            SPFieldLookupValue lv = new SPFieldLookupValue(dr[dc.ColumnName].ToString());
                                            dr[dc.ColumnName] = lv.LookupValue;
                                        }
                                        catch { }
                                    }

                                }
                            }
                        }
                    }

                }

                foreach(DataColumn dc in arrColsDel)
                {
                    dtItems.Columns.Remove(dc);
                }

                TransactionTable dtReturn = PostIntegrationUpdateToExternal(dtItems, new Guid(dtColumns.TableName), list.ID);

                if(colidname != "")
                {
                    foreach(DataRow dr in dtReturn.Rows)
                    {
                        if(dr["Type"].ToString() == "1" || dr["Type"].ToString() == "2")
                        {
                            int itemid = int.Parse(dr["SPID"].ToString());
                            string intid = dr["ID"].ToString();


                            SPListItem li = list.Items.GetItemById(itemid);
                            string curcolidval = "";
                            try
                            {
                                curcolidval = li[colidname].ToString();
                            }
                            catch { }

                            if(curcolidval != intid)
                            {
                                li[colidname] = intid;
                                li["INTUIDSYS"] = "True";
                                li.SystemUpdate();
                            }
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                LogMessage(dtColumns.TableName, list.ID.ToString(), "PostIntegration: " + ex.Message, 3);
            }


        }

        private void PostIntegrationDeleteToExternal(DataTable dtItems, Guid intlistid, Guid listid)
        {

            IntegratorDef integrator = GetIntegrator(intlistid);

            IntegrationLog log = new IntegrationLog(cn, intlistid, listid, integrator.Title);

            Hashtable hshProps = GetProperties(intlistid);

            WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);

            integrator.iIntegrator.DeleteItems(webprops, dtItems, log);

        }

        internal DataTable PullData(DataTable dtItems, Guid intlistid, Guid listid, DateTime dtLastSynched)
        {

            IntegratorDef integrator = GetIntegrator(intlistid);

            IntegrationLog log = new IntegrationLog(cn, intlistid, listid, integrator.Title);

            Hashtable hshProps = GetProperties(intlistid);

            WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);

            return integrator.iIntegrator.PullData(webprops, log, dtItems, dtLastSynched);

        }

        internal TransactionTable PostIntegrationUpdateToExternal(DataTable dtItems, Guid intlistid, Guid listid)
        {

            IntegratorDef integrator = GetIntegrator(intlistid);

            IntegrationLog log = new IntegrationLog(cn, intlistid, listid, integrator.Title);

            Hashtable hshProps = GetProperties(intlistid);

            WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);

            return integrator.iIntegrator.UpdateItems(webprops, dtItems, log);
        }

        private DataTable GetExternalItem(DataTable dtItems, Guid intlistid, Guid listid, string itemid)
        {
            IntegratorDef integrator = GetIntegrator(intlistid);

            IntegrationLog log = new IntegrationLog(cn, intlistid, listid, integrator.Title);

            Hashtable hshProps = GetProperties(intlistid);

            WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);

            return integrator.iIntegrator.GetItem(webprops, log, itemid, dtItems);
        }

        private WebProperties GetWebProps(Hashtable Props, Guid intlistid)
        {
            WebProperties props = new WebProperties();
            props.Title = _web.Title;
            props.ID = _web.ID;
            props.URL = _web.ServerRelativeUrl;
            props.FullURL = _web.Url;

            props.Site.ID = _site.ID;
            props.Site.Title = _site.RootWeb.Title;
            props.Site.URL = _site.Url;

            props.IntegrationId = intlistid;

            props.Properties = Props;

            return props;
        }

        internal Hashtable GetProperties(Guid intlistid)
        {

            OpenConnection();

            Hashtable hshProps = new Hashtable();


            SqlCommand cmd = new SqlCommand("SELECT     dbo.INT_MODULES.CustomProps FROM         dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID WHERE INT_LIST_ID=@intlistid", cn);
            cmd.Parameters.AddWithValue("@intlistid", intlistid);
            SqlDataReader dr = cmd.ExecuteReader();

            string propxml = "";

            if(dr.Read())
            {
                propxml = dr.GetString(0);
            }
            dr.Close();

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(propxml);
            }
            catch { doc.LoadXml("<props/>"); }

            cmd = new SqlCommand("SELECT     Property, Value FROM INT_PROPS WHERE INT_LIST_ID=@intlistid", cn);
            cmd.Parameters.AddWithValue("@intlistid", intlistid);
            dr = cmd.ExecuteReader();



            while(dr.Read())
            {
                bool bPass = false;
                try
                {
                    XmlNode nd = doc.FirstChild.SelectSingleNode("//Input[@Property='" + dr.GetString(0) + "']");
                    if(nd != null && nd.Attributes["Type"].Value == "Password")
                        bPass = true;
                        
                }
                catch { }

                if(bPass)
                    hshProps.Add(dr.GetString(0), CoreFunctions.Decrypt(dr.GetString(1), "kKGBJ768d3q78^#&^dsas"));
                else
                    hshProps.Add(dr.GetString(0), dr.GetString(1));
            }
            dr.Close();
            CloseConnection(false);

            return hshProps;
        }

        private IntegratorDef GetIntegrator(Guid intlistid)
        {
            OpenConnection();

            IntegratorDef def = new IntegratorDef();

            string netAssembly = "";
            string netClass = "";

            SqlCommand cmd = new SqlCommand("SELECT     dbo.INT_MODULES.MODULE_ID, dbo.INT_MODULES.NetAssembly, dbo.INT_MODULES.NetClass,Title,INT_KEY,LIST_ID,INT_COLID,INT_LIST_ID FROM         dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID WHERE INT_LIST_ID=@intlistid", cn);
            cmd.Parameters.AddWithValue("@intlistid", intlistid);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                netAssembly = dr.GetString(1);
                netClass = dr.GetString(2);
                def.Title = dr.GetString(3);
                def.IntKey = dr.GetString(4);
                def.ListId = dr.GetGuid(5);
                def.intcol = "INTUID" + dr.GetInt32(6);
                def.intlistid = dr.GetGuid(7);
            }
            dr.Close();

            Assembly assemblyInstance = Assembly.Load(netAssembly);
            Type thisClass = assemblyInstance.GetType(netClass);
            
            
            def.iIntegrator = (IIntegrator)Activator.CreateInstance(thisClass);


            return def;

        }

        private IIntegrator GetIntegratorFromModule(Guid moduleid, out string title)
        {

            OpenConnection();

            string netAssembly = "";
            string netClass = "";
            title = "";

            SqlCommand cmd = new SqlCommand("SELECT NetAssembly, NetClass,Title FROM INT_MODULES WHERE MODULE_ID=@moduleid", cn);
            cmd.Parameters.AddWithValue("@moduleid", moduleid);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                netAssembly = dr.GetString(0);
                netClass = dr.GetString(1);
                title = dr.GetString(2);
            }
            dr.Close();
            CloseConnection(true);

            Assembly assemblyInstance = Assembly.Load(netAssembly);
            Type thisClass = assemblyInstance.GetType(netClass);
            return (IIntegrator)Activator.CreateInstance(thisClass);

        }

        internal void ProcessItem(DataSet dsItem, SPListItem li, SPList list)
        {
            
            ArrayList arrCols = new ArrayList();

            foreach(DataColumn dc in dsItem.Tables[0].Columns)
            {

                if(dc.ColumnName == "SPID")
                {
                    arrCols.Add(li.ID.ToString());
                }
                else
                {
                    try
                    {
                        SPField field = list.Fields.GetFieldByInternalName(dc.ColumnName);

                        string val = "";

                        switch(field.Type)
                        {
                            case SPFieldType.Number:
                            case SPFieldType.Currency:
                                val = li[field.Id].ToString();
                                break;
                            case SPFieldType.DateTime:
                                try
                                {
                                    val = DateTime.Parse(li[field.Id].ToString()).ToString("s");
                                }
                                catch { }
                                break;
                            case SPFieldType.Boolean:
                                val = li[field.Id].ToString();
                                break;
                            case SPFieldType.Lookup:
                            case SPFieldType.User:
                                val = li[field.Id].ToString();
                                break;
                            case SPFieldType.Calculated:
                                val = field.GetFieldValue(li[field.Id].ToString()).ToString();
                                int indexof = val.IndexOf(";#");
                                if(indexof > 0)
                                {
                                    val = val.Substring(indexof + 2);
                                }
                                break;
                            default:
                                if(field.TypeAsString == "TotalRollup")
                                    val = field.GetFieldValue(li[field.Id].ToString()).ToString();
                                else
                                    val = field.GetFieldValueAsText(li[field.Id].ToString());
                                break;
                        }

                        arrCols.Add(val); 
                    }
                    catch { arrCols.Add(""); }
                    
                }
            }

            dsItem.Tables[0].Rows.Add((string[])arrCols.ToArray(typeof(string)));

        }

        internal void SubmitDeleteListEvent(SPListItem li, SPItemEventDataCollection AfterProperties)
        {
            OpenConnection();

            SqlCommand cmd = new SqlCommand("SELECT INT_COLID FROM INT_LISTS where LIST_ID=@listid", cn);
            cmd.Parameters.AddWithValue("@listid", li.ParentList.ID);
            DataSet dsInts = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsInts);

            foreach(DataRow dr in dsInts.Tables[0].Rows)
            {
                string intitemid = "";

                try
                {
                    intitemid = li["INTUID" + dr["INT_COLID"].ToString()].ToString();
                }
                catch { }
                if(intitemid != "")
                {
                    cmd = new SqlCommand("INSERT INTO INT_EVENTS (LIST_ID, ITEM_ID, INTITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @itemid, @intitemid, @colid, 0, 1, @type)", cn);
                    cmd.Parameters.AddWithValue("@listid", li.ParentList.ID);
                    cmd.Parameters.AddWithValue("@itemid", li.ID);
                    cmd.Parameters.AddWithValue("@intitemid", intitemid);
                    cmd.Parameters.AddWithValue("@colid", dr["INT_COLID"].ToString());
                    cmd.Parameters.AddWithValue("@type", 2);
                    cmd.ExecuteNonQuery();
                }
            }

            CloseConnection(true);
        }

        internal void SubmitListEvent(SPListItem li, int eventType, SPItemEventDataCollection AfterProperties)
        {
            

            string sys = "";
            try
            {
                sys = AfterProperties["INTUIDSYS"].ToString();
            }
            catch { }

            if(sys == "")
            {
                OpenConnection();

                string colid = "";

                SqlCommand cmd = new SqlCommand("SELECT INT_COLID FROM INT_LISTS where LIST_ID=@listid", cn);
                cmd.Parameters.AddWithValue("@listid", li.ParentList.ID);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    if(AfterProperties["INTUID" + dr.GetInt32(0).ToString()] != null && !string.IsNullOrEmpty(AfterProperties["INTUID" + dr.GetInt32(0).ToString()].ToString()))
                        colid = dr.GetInt32(0).ToString();
                }
                dr.Close();


                cmd = new SqlCommand("INSERT INTO INT_EVENTS (LIST_ID, ITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @itemid, @colid, 0, 1, @type)", cn);
                cmd.Parameters.AddWithValue("@listid", li.ParentList.ID);
                cmd.Parameters.AddWithValue("@itemid", li.ID);
                cmd.Parameters.AddWithValue("@colid", colid);
                cmd.Parameters.AddWithValue("@type", eventType);
                cmd.ExecuteNonQuery();

                CloseConnection(true);
            }
        }

        internal DataSet GetDataSet(SPList list, string eventfromid, Guid intlistid)
        {
            DataSet dsIntegration = new DataSet();

            DataTable dt = new DataTable("Data");
            dt.Columns.Add("SPID");

            DataSet dsIntegrations = new DataSet();

            int priority = 0;

            SqlCommand cmd;

            if(eventfromid != "")
            {
                cmd = new SqlCommand("SELECT PRIORITY FROM INT_LISTS where LIST_ID=@listid and INT_COLID=@colid", cn);
                cmd.Parameters.AddWithValue("@listid", list.ID);
                cmd.Parameters.AddWithValue("@colid", eventfromid);
                SqlDataReader drPri = cmd.ExecuteReader();
                if(drPri.Read())
                    priority = drPri.GetInt32(0);
                drPri.Close();
            }

            if(intlistid == Guid.Empty)
            {
                cmd = new SqlCommand("SELECT * FROM INT_LISTS where LIST_ID=@listid and Active=1 and LIVEOUTGOING=1 and PRIORITY > @priority order by priority", cn);
                cmd.Parameters.AddWithValue("@listid", list.ID);
                cmd.Parameters.AddWithValue("@priority", priority);
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM INT_LISTS where INT_LIST_ID=@intlistid", cn);
                cmd.Parameters.AddWithValue("@intlistid", intlistid);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsIntegrations);
            
            dsIntegration.Tables.Add(dt);

            DataTable dtU = new DataTable("UserFields");
            dtU.Columns.Add("Fieldname");
            dtU.Columns.Add("Type");
            dtU.Columns.Add("LookupIntColID");
            dtU.Columns.Add("LookupList");
            dsIntegration.Tables.Add(dtU);

            foreach(DataRow drIntegrationModule in dsIntegrations.Tables[0].Rows)
            {
                if(drIntegrationModule["INT_COLID"].ToString() != eventfromid)
                {
                    dt.Columns.Add("INTUID" + drIntegrationModule["INT_COLID"].ToString());

                    DataTable dtCols = new DataTable(drIntegrationModule["INT_LIST_ID"].ToString());
                    dtCols.Columns.Add("SharePointColumn");
                    dtCols.Columns.Add("IntegrationColumn");
                    dtCols.Columns.Add("Setting");

                    dsIntegration.Tables.Add(dtCols);

                    dtCols.Rows.Add(new string[] { "INTUID" + drIntegrationModule["INT_COLID"].ToString(), "ID", "" });

                    cmd = new SqlCommand("SELECT SharePointColumn, IntegrationColumn, Setting FROM INT_COLUMNS where INT_LIST_ID=@intlistid", cn);
                    cmd.Parameters.AddWithValue("@intlistid", drIntegrationModule["INT_LIST_ID"].ToString());

                    DataSet dsCols = new DataSet();
                    SqlDataAdapter daCols = new SqlDataAdapter(cmd);
                    daCols.Fill(dsCols);
                    //SqlDataReader dr = cmd.ExecuteReader();

                    foreach(DataRow dr in dsCols.Tables[0].Rows)
                    {
                        try
                        {
                            SPField field = list.Fields.GetFieldByInternalName(dr["SharePointColumn"].ToString());
                            if(field != null)
                            {
                                dtCols.Rows.Add(new string[] { dr["SharePointColumn"].ToString(), dr["IntegrationColumn"].ToString(), dr["Setting"].ToString() });

                                if(!dt.Columns.Contains(dr["SharePointColumn"].ToString()))
                                {
                                    Type t;
                                    switch(field.Type)
                                    {
                                        case SPFieldType.Number:
                                        case SPFieldType.Currency:
                                            t = typeof(string);
                                            break;
                                        case SPFieldType.DateTime:
                                            t = typeof(string);
                                            break;
                                        case SPFieldType.Boolean:
                                            t = typeof(string);
                                            break;
                                        case SPFieldType.User:
                                            t = typeof(string);
                                            if(dtU.Select("Fieldname='" + field.InternalName + "'").Length <= 0)
                                                dtU.Rows.Add(new string[] { field.InternalName, "1", "", "" });
                                            break;
                                        case SPFieldType.Lookup:
                                            t = typeof(string);

                                            try
                                            {
                                                SPFieldLookup l = (SPFieldLookup)field;

                                                Hashtable parms = new Hashtable();
                                                parms.Add("listid", l.LookupList);
                                                parms.Add("moduleid", drIntegrationModule["MODULE_ID"].ToString());

                                                DataSet dsOther = GetDataSet("SELECT * FROM INT_LISTS WHERE LIST_ID=@listid and MODULE_ID=@moduleid", parms);


                                                if(dtU.Select("Fieldname='" + field.InternalName + "'").Length <= 0)
                                                {
                                                    if(dsOther.Tables[0].Rows.Count > 0)
                                                        dtU.Rows.Add(new string[] { field.InternalName, "2", dsOther.Tables[0].Rows[0]["INT_COLID"].ToString(), l.LookupList });
                                                    else
                                                        dtU.Rows.Add(new string[] { field.InternalName, "2", "", "" });
                                                }
                                            }
                                            catch { }

                                            break;
                                        default:
                                            t = typeof(string);
                                            break;
                                    }

                                    dt.Columns.Add(field.InternalName, t);
                                }
                            }
                        }
                        catch { }
                    }

                }
            }

            return dsIntegration;
        }

        private string GetAPIUrl(Guid webappid)
        {
            string apiurl = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPWebApplication webapp = SPWebService.ContentService.WebApplications[webappid];
                    apiurl = webapp.Properties["epmliveapiurl"].ToString();
                    if(apiurl.EndsWith("/"))
                        apiurl += "integration.asmx";
                    else
                        apiurl += "/integration.asmx";
                }
                catch { }
            });
            return apiurl;
        }

        internal void OpenConnection()
        {
            if(cn.State != ConnectionState.Open)
                cn.Open();
            else
                WasOpen = true;
        }

        internal void CloseConnection(bool force)
        {
            if(cn.State == ConnectionState.Open && (force || !WasOpen))
                cn.Close();
        }
        #endregion

        ~IntegrationCore()
        {
            _web.Close();
        }
    }
}

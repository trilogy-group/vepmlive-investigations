using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using EPMLiveCore.GlobalResources;
using EPMLiveIntegration;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore.API.Integration
{
    public class IntegrationCore
    {
        private const string ColNameIntListId = "INT_LIST_ID";
        private const string ColNameListId = "LIST_ID";
        private const string ColNameColId = "COL_ID";
        private const string TextIntUid = "INTUID";
        private SPSite _site;
        SPWeb _web = null;
        SqlConnection cn;
        private bool WasOpen = false;

        public class IntegratorDef
        {
            public IIntegrator iIntegrator;
            public string Title;
            public string IntKey;
            public Guid ListId;
            public string intcol;
            public Guid intlistid;
        }

        public class IntegrationControlDef
        {
            public string id;
            public string HTML;
        }

        public IntegrationCore(Guid SiteId, Guid WebId)
        {
            _site = new SPSite(SiteId);
            _web = _site.OpenWeb(WebId);
            cn = new SqlConnection(CoreFunctions.getConnectionString(_site.WebApplication.Id));
        }

        public DataTable GetIntegrationControl(Guid ListId, string control)
        {
            const string commandText = "SELECT     dbo.INT_LISTS.INT_LIST_ID, dbo.INT_LISTS.INT_COLID, WINDOWSTYLE FROM         dbo.INT_CONTROLS INNER JOIN dbo.INT_LISTS ON dbo.INT_CONTROLS.INT_LIST_ID = dbo.INT_LISTS.INT_LIST_ID where LIST_ID=@listid and control=@control";
            const string paramListId = "@listid";
            const string paramControl = "@control";

            var dataSet = new DataSet();

            try
            {
                OpenConnection();

                using (var sqlCommand = new SqlCommand(commandText, cn))
                {
                    sqlCommand.Parameters.AddWithValue(paramListId, ListId);
                    sqlCommand.Parameters.AddWithValue(paramControl, control);

                    using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        dataAdapter.Fill(dataSet);
                    }
                }
            }
            finally
            {
                CloseConnection(false);
            }

            if (dataSet.Tables.Count == 0)
            {
                throw new InvalidOperationException("No results have been processed");
            }

            return dataSet.Tables[0];
        }

        public DataTable GetIntegrationControlByIntId(Guid IntListId, string control)
        {
            const string commandText = "SELECT   LIST_ID,  dbo.INT_LISTS.INT_LIST_ID, dbo.INT_LISTS.INT_COLID, WINDOWSTYLE FROM         dbo.INT_CONTROLS INNER JOIN dbo.INT_LISTS ON dbo.INT_CONTROLS.INT_LIST_ID = dbo.INT_LISTS.INT_LIST_ID where INT_LISTS.INT_LIST_ID=@IntListId and control=@control";
            const string paramIntListId = "@IntListId";
            const string paramControl = "@control";

            var dataSet = new DataSet();

            try
            {
                OpenConnection();

                using (var sqlCommand = new SqlCommand(commandText, cn))
                {
                    sqlCommand.Parameters.AddWithValue(paramIntListId, IntListId);
                    sqlCommand.Parameters.AddWithValue(paramControl, control);

                    using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        dataAdapter.Fill(dataSet);
                    }
                }
            }
            finally
            {
                CloseConnection(false);
            }

            if (dataSet.Tables.Count == 0)
            {
                throw new InvalidOperationException("No results have been processed");
            }

            return dataSet.Tables[0];
        }

        public DataTable GetIntegrationsForList(Guid ListId)
        {
            const string commandText = "select INT_LIST_ID as intlistid, priority, Title as intname , CASE WHEN ACTIVE = 1 THEN 'Yes' ELSE 'No' END AS Active, INT_COLID FROM dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID where LIST_ID=@listid order by priority";
            const string paramListId = "@listid";

            var dataSet = new DataSet();

            try
            {
                OpenConnection();

                using (var sqlCommand = new SqlCommand(commandText, cn))
                {
                    sqlCommand.Parameters.AddWithValue(paramListId, ListId);

                    using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        dataAdapter.Fill(dataSet);
                    }
                }
            }
            finally
            {
                CloseConnection(false);
            }

            if (dataSet.Tables.Count == 0)
            {
                throw new InvalidOperationException("No results have been processed");
            }

            return dataSet.Tables[0];
        }

        internal bool InstallIntegration(Guid intlistid, Guid listid, out string message)
        {
            try
            {
                IntegratorDef integrator = GetIntegrator(intlistid);

                IntegrationLog log = new IntegrationLog(cn, intlistid, listid, integrator.Title);
                
                Hashtable hshProps = GetProperties(intlistid);

                WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);

                if (integrator.iIntegrator.InstallIntegration(webprops, log, out message, integrator.IntKey, GetAPIUrl(_site.WebApplication.Id)))
                {
                    EPMLiveIntegration.IIntegratorControls controls = null;
                    try
                    {
                        controls = (EPMLiveIntegration.IIntegratorControls)integrator.iIntegrator;
                    }
                    catch { }

                    OpenConnection();

                    SqlCommand cmd = new SqlCommand("DELETE FROM INT_CONTROLS where INT_LIST_ID=@intlistid", cn);
                    cmd.Parameters.AddWithValue("@intlistid", intlistid);
                    cmd.ExecuteNonQuery();

                    if (controls != null)
                    {
                        List<IntegrationControl> ctls = controls.GetPageButtons(webprops, log, false);
                        List<string> lctls = controls.GetEmbeddedItemControls(webprops, log);

                        DataTable dtResInfo = new DataTable();
                        dtResInfo.Columns.Add("INT_CONTROL_ID", typeof(Guid));
                        dtResInfo.Columns.Add("INT_LIST_ID", typeof(Guid));
                        dtResInfo.Columns.Add("CONTROL");
                        dtResInfo.Columns.Add("LOCAL");
                        dtResInfo.Columns.Add("TITLE");
                        dtResInfo.Columns.Add("IMAGE");
                        dtResInfo.Columns.Add("GLOBAL");
                        dtResInfo.Columns.Add("WINDOWSTYLE");

                        foreach (IntegrationControl ictl in ctls)
                        {
                            dtResInfo.Rows.Add(new object[] { Guid.NewGuid(), intlistid, ictl.Control, false, ictl.Title, ictl.Image, false, (int)ictl.Window });
                        }

                        foreach (string ictl in lctls)
                        {
                            dtResInfo.Rows.Add(new object[] { Guid.NewGuid(), intlistid, ictl, true, ictl, "", false, 0 });
                        }


                        AppSettingsHelper appHelper = new AppSettingsHelper();

                        List<IntegrationControl> gctls = controls.GetPageButtons(webprops, log, true);
                        foreach (IntegrationControl ictl in gctls)
                        {
                            dtResInfo.Rows.Add(new object[] { Guid.NewGuid(), intlistid, ictl.Control, false, ictl.Title, ictl.Image, true, (int)ictl.Window });

                            try
                            {
                                var url = _web.ServerRelativeUrl;

                                if (url == "/")
                                    url = "";

                                SPList appList = _web.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);

                                int _appId = appHelper.GetDefaultCommunity(appList).ID;

                                appHelper.CreateParentNode(_appId, "quiklnch", ictl.Title, url + "/_layouts/epmlive/integration/gotoremote.aspx?integrationid=" + intlistid.ToString() + "&control=" + ictl.Control, false, null);
                                API.Applications.CreateQuickLaunchXML(_appId, _web);
                                API.Applications.CreateTopNavXML(_appId, _web);
                            }
                            catch (Exception ex)
                            {
                                log.LogMessage("Error Installing Control (" + ictl.Control + "): " + ex.Message, IntegrationLogType.Warning);
                            }
                        }

                        using (SqlBulkCopy sbc = new SqlBulkCopy(cn))
                        {
                            sbc.DestinationTableName = "INT_CONTROLS";

                            sbc.BatchSize = dtResInfo.Rows.Count;
                            sbc.WriteToServer(dtResInfo);
                            sbc.Close();

                        }


                    }

                    CloseConnection(false);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
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
            if (lic.Count > 0)
            {

                return lic[0];

            }
            else
                return null;

        }

        internal bool RemoveIntegration(Guid intlistid, Guid listid, out string message)
        {
            const string commandText = "DELETE FROM INT_CONTROLS where INT_LIST_ID=@intlistid";
            const string paramIntListId = "@intlistid";

            try
            {
                var integrator = GetIntegrator(intlistid);

                if (integrator == null)
                {
                    throw new InvalidOperationException("Integrator could not be found");
                }

                var log = new IntegrationLog(cn, intlistid, listid, integrator.Title);
                var hashProps = GetProperties(intlistid);
                var webProps = GetWebProps(hashProps, integrator.intlistid);

                if (integrator.iIntegrator.RemoveIntegration(webProps, log, out message, integrator.IntKey))
                {
                    OpenConnection();

                    using (var sqlCommand = new SqlCommand(commandText, cn))
                    {
                        sqlCommand.Parameters.AddWithValue(paramIntListId, intlistid);
                        sqlCommand.ExecuteNonQuery();
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                message = "Remove Error: " + ex.Message;
                Trace.TraceError(ex.ToString());
                return false;
            }
            finally
            {
                CloseConnection(false);
            }
        }

        public DataSet GetIntegrations(bool bOnline)
        {
            DataSet ds = new DataSet();

            OpenConnection();

            string sql = "";
            //if (bOnline)
            //    sql = "SELECT * FROM INT_MODULES WHERE AvailableOnline = 1 AND INT_CAT_ID=@cat";
            //else
            //    sql = "SELECT * FROM INT_MODULES WHERE INT_CAT_ID=@cat";
                sql = "SELECT * FROM INT_MODULES WHERE AvailableOnline = 1 AND INT_CAT_ID=@cat";

            DataSet dsCats = new DataSet();
            SqlCommand cmd = new SqlCommand("SELECT * FROM INT_CATEGORY ORDER BY ORDERBY", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsCats);
            ds.Tables.Add(dsCats.Tables[0].Copy());
            ds.Tables[0].TableName = "Categories";

            DataTable dtCats =  dsCats.Tables[0];

            for (int i = 0; i <dtCats.Rows.Count; i++)
            {
                DataSet dsTemp = new DataSet();

                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@cat", dtCats.Rows[i]["INT_CAT_ID"].ToString());
                da = new SqlDataAdapter(cmd);
                da.Fill(dsTemp);

                ds.Tables.Add(dsTemp.Tables[0].Copy());
                ds.Tables[i + 1].TableName = dtCats.Rows[i]["INT_CAT_ID"].ToString();
            }

            CloseConnection(false);

            return ds;
        }

        public void ExecuteEvent(DataRow dr)
        {
            try
            {

                OpenConnection();
                    
                if (dr["DIRECTION"].ToString() == "1")
                    ProcessItemOutgoing(dr);
                else if (dr["DIRECTION"].ToString() == "2")
                    ProcessItemIncoming(dr);

                CloseConnection(true);

            }
            catch (Exception ex)
            {
                LogMessage("", dr["LIST_ID"].ToString(), "ExecuteEvent: " + ex.Message, (int)IntegrationLogType.Error);
            }
        }

        internal void SaveProperties(Guid intlistid, Hashtable hshProps)
        {
            const string storedProcedureName = "SPIntSetProperty";
            const string paramIntListId = "@intlistid";
            const string paramProperty = "@property";
            const string paramValue = "@value";

            try
            {
                OpenConnection();

                foreach (DictionaryEntry de in hshProps)
                {
                    using (var sqlCommand = new SqlCommand(storedProcedureName, cn))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue(paramIntListId, intlistid);
                        sqlCommand.Parameters.AddWithValue(paramProperty, de.Key.ToString());
                        sqlCommand.Parameters.AddWithValue(paramValue, de.Value.ToString());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                CloseConnection(false);
            }
        }

        internal DataSet GetDataSet(string sql, Hashtable sqlparams)
        {
            const string paramPrefix = "@";

            var dataSet = new DataSet();

            try
            {
                OpenConnection();

                using (var sqlCommand = new SqlCommand(sql, cn))
                {
                    foreach (DictionaryEntry entry in sqlparams)
                    {
                        sqlCommand.Parameters.AddWithValue(string.Concat(paramPrefix, entry.Key), entry.Value);
                    }

                    using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        dataAdapter.Fill(dataSet);
                    }
                }
            }
            finally
            {
                CloseConnection(false);
            }

            return dataSet;
        }

        internal void ExecuteQuery(string sql, Hashtable sqlparams, bool Close)
        {
            const string paramPrefix = "@";

            try
            {
                OpenConnection();

                using (var sqlCommand = new SqlCommand(sql, cn))
                {
                    foreach (DictionaryEntry entry in sqlparams)
                    {
                        sqlCommand.Parameters.AddWithValue(string.Concat(paramPrefix, entry.Key), entry.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                if (Close)
                {
                    CloseConnection(true);
                }
            }
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
            if (intlistid == Guid.Empty)
                sql = "SELECT CustomProps FROM INT_MODULES where module_id=@moduleid";
            else
                sql = "SELECT   CustomProps  FROM         dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID where int_list_id=@intlistid";

            Hashtable hshParams = new Hashtable();

            if (intlistid == Guid.Empty)
                hshParams.Add("moduleid", moduleid);
            else
                hshParams.Add("intlistid", intlistid);

            DataSet ds = GetDataSet(sql, hshParams);
            DataTable dt = ds.Tables[0];


            XmlDocument doc = new XmlDocument();
            if (dt.Rows.Count > 0)
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

            if (ds.Tables[0].Rows.Count > 0)
            {
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='INTUID" + ds.Tables[0].Rows[0]["INT_COLID"].ToString() + "'/><Value Type='Text'>" + intuid + "</Value></Eq></Where>";
                SPListItemCollection lic = list.GetItems(query);
                if (lic.Count > 0)
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

            if (bBuildTeamSec)
            {
                try
                {
                    if (Properties["SecMatch"].ToString() != "")
                    {

                        ownerid = new SPFieldLookupValue(hshUserMap[dr[Properties["SecMatch"].ToString()]].ToString()).LookupId;

                    }
                }
                catch { }
            }

            if (ownerid != 0)
            {
                SPUser user = null;
                try
                {
                    user = list.ParentWeb.SiteUsers.GetByID(ownerid);
                }
                catch { }
                if (user != null)
                {
                    using (SPSite site = new SPSite(list.ParentWeb.Site.ID, user.UserToken))
                    {
                        using (SPWeb web = site.OpenWeb(list.ParentWeb.ID))
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

            if (dr["ID"].ToString() == "")
            {
                if (matchList != "")
                {
                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='" + matchList + "'/><Value Type='Text'>" + dr[matchInt].ToString() + "</Value></Eq></Where>";
                    SPListItemCollection lic = list.GetItems(query);
                    if (lic.Count > 0)
                    {
                        SPListItem li = lic[0];

                        bool bAlreadyMatched = false;
                        try
                        {
                            SPField field = list.Fields.GetFieldByInternalName("INTUID" + ColId);

                            if (li[field.Id].ToString() != "")
                                bAlreadyMatched = true;
                        }
                        catch { }

                        if (!bAlreadyMatched)
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
                if (lic.Count > 0)
                {
                    SPListItem li = lic[0];
                    itemid = li.ID;
                    ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                }
                else if (matchList != "")
                {
                    query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='" + matchList + "'/><Value Type='Text'>" + dr[matchInt].ToString() + "</Value></Eq></Where>";
                    lic = list.GetItems(query);
                    if (lic.Count > 0)
                    {
                        SPListItem li = lic[0];
                        itemid = li.ID;
                        bool bAlreadyMatched = false;
                        try
                        {
                            SPField field = list.Fields.GetFieldByInternalName("INTUID" + ColId);

                            if (li[field.Id].ToString() != "")
                                bAlreadyMatched = true;
                        }
                        catch { }

                        if (!bAlreadyMatched)
                        {
                            ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                        }
                        else
                        {
                            if (bCanAdd)
                            {
                                li = list.Items.Add();

                                ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                                itemid = li.ID;
                            }
                        }
                    }
                    else
                    {
                        if (bCanAdd)
                        {
                            SPListItem li = list.Items.Add();

                            ProcessLIItem(list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields);
                            itemid = li.ID;
                        }
                    }
                }
                else
                {
                    if (bCanAdd)
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

                foreach (DataRow drC in dtColumns.Rows)
                {
                    if (drC["IntegrationColumn"].ToString() != "ID")
                    {
                        field = null;
                        try
                        {
                            field = list.Fields.GetFieldByInternalName(drC["SharePointColumn"].ToString());
                        }
                        catch { }

                        if (field != null)
                        {
                            if (field.Type == SPFieldType.User)
                            {
                                string uInfo = "";
                                try
                                {
                                    string[] userinfo = dr[drC["IntegrationColumn"].ToString()].ToString().Split(',');
                                    foreach (string sInfo in userinfo)
                                    {
                                        if (sInfo != "" && hshUserMap.Contains(sInfo))
                                            uInfo += ";#" + hshUserMap[sInfo].ToString();
                                    }

                                    uInfo = uInfo.Trim(';').Trim('#');
                                }
                                catch { }
                                if (uInfo != "")
                                {
                                    li[field.Id] = uInfo;
                                }
                                else
                                {
                                    li[field.Id] = null;
                                }
                            }
                            else if (field.Type == SPFieldType.DateTime)
                            {
                                string sDateVal = dr[drC["IntegrationColumn"].ToString()].ToString();
                                if (sDateVal != "")
                                {
                                    li[field.Id] = sDateVal;
                                }
                                else
                                {
                                    li[field.Id] = null;
                                }
                            }
                            else if (field.Type == SPFieldType.Lookup)
                            {
                                if (drC["Setting"].ToString() != "1")
                                {
                                    DataRow[] drColUser = dtUserFields.Select("Fieldname='" + drC["SharePointColumn"].ToString() + "'");
                                    if (drColUser[0]["LookupIntColID"].ToString() != "")
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

                //li.SystemUpdate();
                li.Update();
            }
            catch (Exception ex)
            {
                LogMessage(intlistid.ToString(), list.ID.ToString(), "Error Updating Item From Incoming: " + ex.Message, (int)IntegrationLogType.Error);
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


                if (dsInt.Tables[0].Rows.Count > 0)
                {
                    DataRow drIntegration = dsInt.Tables[0].Rows[0];

                    if (dr["TYPE"].ToString() == "1")//Update
                    {

                        Hashtable props = GetProperties(new Guid(drIntegration["INT_LIST_ID"].ToString()));

                        if (drIntegration["LIVEINCOMING"].ToString().ToLower() == "true")
                        {
                            LogMessage(drIntegration["INT_LIST_ID"].ToString(), list.ID.ToString(), "Update Event on ID: " + dr["INTITEM_ID"].ToString() + " Accepted.", (int)IntegrationLogType.Event);

                            parms.Add("intlistid", drIntegration["INT_LIST_ID"].ToString());
                            DataSet dsColumns = GetDataSet("SELECT * FROM INT_COLUMNS where INT_LIST_ID=@intlistid", parms);
                            DataTable dtCols = dsColumns.Tables[0];

                            DataTable dtItem = new DataTable();
                            dtItem.Columns.Add("ID");
                            foreach (DataRow drCol in dtCols.Rows)
                            {
                                dtItem.Columns.Add(drCol["IntegrationColumn"].ToString());
                            }

                            try
                            {
                                if (props["SecMatch"].ToString() != "")
                                    if (!dtItem.Columns.Contains(props["SecMatch"].ToString()))
                                        dtItem.Columns.Add(props["SecMatch"].ToString());
                            }
                            catch { }

                            if (drIntegration["MODULE_ID"].ToString() == "a0950b9b-3525-40b8-a456-6403156dc49c")
                            {
                                DataRow drNew = dtItem.NewRow();

                                try
                                {
                                    drNew["ID"] = dr["INTITEM_ID"].ToString();
                                    bool bOpened = false;
                                    if (cn.State != ConnectionState.Open)
                                    {
                                        bOpened = true;
                                        cn.Open();
                                    }
                                    SqlCommand cmd = new SqlCommand("SELECT DATA FROM INT_EVENTS WHERE INT_EVENT_ID=@inteventid", cn);
                                    cmd.Parameters.AddWithValue("@inteventid", dr["INT_EVENT_ID"].ToString());
                                    string xml = "";

                                    SqlDataReader dataRead = cmd.ExecuteReader();
                                    try
                                    {
                                        if (dataRead.Read())
                                            xml = dataRead.GetString(0);
                                    }
                                    catch { }
                                    dataRead.Close();

                                    if (bOpened)
                                        cn.Close();

                                    if (xml != "")
                                    {
                                        XmlDocument doc = new XmlDocument();
                                        doc.LoadXml(xml);

                                        XmlNode ndFields = doc.FirstChild.SelectSingleNode("Fields");
                                        foreach (XmlNode ndField in ndFields.SelectNodes("Field"))
                                        {
                                            try
                                            {
                                                string fName = ndField.Attributes["Name"].Value;
                                                string fVal = ndField.InnerText;
                                                drNew[fName] = fVal;
                                            }
                                            catch { }
                                        }
                                        dtItem.Rows.Add(drNew);
                                    }
                                }
                                catch { }


                            }

                            dtItem = GetExternalItem(dtItem, new Guid(drIntegration["INT_LIST_ID"].ToString()), list.ID, dr["INTITEM_ID"].ToString());

                            DataSet dsUserFields = GetDataSet(list, "", Guid.Empty);
                            DataTable dtUserFields = dsUserFields.Tables[1];
                            Hashtable hshUserMap = new Hashtable();
                            if (dtUserFields.Select("Type='1'").Length > 0 || bBuildTeamSec)
                            {
                                hshUserMap = GetUserMap(drIntegration["INT_LIST_ID"].ToString(), true);
                            }

                            Guid intlistid = new Guid(drIntegration["INT_LIST_ID"].ToString());

                            foreach (DataRow drItem in dtItem.Rows)
                            {


                                bool bCanAdd = false;

                                try
                                {
                                    bCanAdd = bool.Parse(props["AllowAddList"].ToString());
                                }
                                catch { }

                                try
                                {
                                    if (props["SecMatch"].ToString() == "")
                                        bBuildTeamSec = false;
                                }
                                catch { bBuildTeamSec = false; }

                                ProcessItemRow(drItem, list, dtCols, props, dr["COL_ID"].ToString(), intlistid, new Guid(drIntegration["MODULE_ID"].ToString()), bCanAdd, dtUserFields, hshUserMap, bBuildTeamSec);
                            }
                        }
                        else
                        {
                            LogMessage(drIntegration["INT_LIST_ID"].ToString(), list.ID.ToString(), "Update Event on ID: " + dr["INTITEM_ID"].ToString() + " Ignored (live incoming off)." ,(int)IntegrationLogType.Event);
                        }
                        

                    }
                    else if (dr["TYPE"].ToString() == "2")//Delete
                    {
                        Hashtable props = GetProperties(new Guid(drIntegration["INT_LIST_ID"].ToString()));

                        bool CanDelete = false;
                        try
                        {
                            CanDelete = bool.Parse(props["AllowDeleteList"].ToString());
                        }
                        catch { }

                        if (CanDelete)
                        {
                            DeleteSharePointItem(list, dr["INTITEM_ID"].ToString(), dr["COL_ID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage("", dr["LIST_ID"].ToString(), "ProcessItemIncoming: " + ex.Message, (int)IntegrationLogType.Error);
            }
        }

        private void DeleteSharePointItem(SPList list, string intuid, string col)
        {
            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='INTUID" + col + "'/><Value Type='Text'>" + intuid + "</Value></Eq></Where>";
            SPListItemCollection lic = list.GetItems(query);
            if (lic.Count > 0)
            {
                lic[0].Delete();

            }
        }

        internal void UpdatePriorityNumbers(Guid listid)
        {
            const string selectCommandText = "SELECT INT_LIST_ID FROM INT_LISTS where LIST_ID=@listid order by priority";
            const string updateCommandText = "UPDATE INT_LISTS set Priority=@priority where INT_LIST_ID=@intlistid";
            const string paramListId = "@listid";
            const string paramIntListId = "@intlistid";
            const string paramPriority = "@priority";

            try
            {
                OpenConnection();

                using (var selectCommand = new SqlCommand(selectCommandText, cn))
                {
                    selectCommand.Parameters.AddWithValue(paramListId, listid);

                    using (var dataSet = new DataSet())
                    {
                        using (var dataAdapter = new SqlDataAdapter(selectCommand))
                        {
                            dataAdapter.Fill(dataSet);
                        }

                        if (dataSet.Tables.Count > 0)
                        {
                            var priorityCounter = 1;

                            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                            {
                                using (var updateCommand = new SqlCommand(updateCommandText, cn))
                                {
                                    updateCommand.Parameters.AddWithValue(paramIntListId, dataRow[ColNameIntListId].ToString());
                                    updateCommand.Parameters.AddWithValue(paramPriority, priorityCounter);
                                    updateCommand.ExecuteNonQuery();
                                }

                                priorityCounter++;
                            }
                        }
                    }
                }
            }
            finally
            {
                CloseConnection(false);
            }
        }

        private void ProcessItemOutgoing(DataRow dr)
        {
            try
            {
                if (dr["TYPE"].ToString() == "1")//Update
                {
                    SPList list = _web.Lists[new Guid(dr["LIST_ID"].ToString())];
                    SPListItem li = list.GetItemById(int.Parse(dr["ITEM_ID"].ToString()));

                    DataSet dsItem = GetDataSet(list, dr["COL_ID"].ToString(), Guid.Empty);

                    ProcessItem(dsItem, li, list);

                    for (int i = 2; i < dsItem.Tables.Count; i++)
                    {

                        PostIntegration(dsItem.Tables[0].Copy(), dsItem.Tables[1], dsItem.Tables[i], list);

                    }
                }
                else if (dr["TYPE"].ToString() == "2")//Delete
                {

                    DataTable dtItems = new DataTable();
                    dtItems.Columns.Add("ID");
                    dtItems.Columns.Add("SPID");

                    dtItems.Rows.Add(new string[] { dr["INTITEM_ID"].ToString(), dr["ITEM_ID"].ToString() });

                    OpenConnection();

                    const string selectIntListCommandText = "SELECT INT_LIST_ID FROM INT_LISTS where LIST_ID=@listid and INT_COLID=@intcolid";
                    var intListId = Guid.Empty;
                    using (var selectCommand = new SqlCommand(selectIntListCommandText, cn))
                    {
                        const string paramListId = "@listid";
                        const string paramIntColId = "@intcolid";
                        selectCommand.Parameters.AddWithValue(paramListId, dr[ColNameListId].ToString());
                        selectCommand.Parameters.AddWithValue(paramIntColId, dr[ColNameColId].ToString());

                        using (var dataReader = selectCommand.ExecuteReader())
                        {
                            if (dataReader.Read() && dataReader.FieldCount > 0)
                            {
                                const int firstColIndex = 0;
                                intListId = dataReader.GetGuid(firstColIndex);
                            }

                            dataReader.Close();
                        }
                    }

                    var props = GetProperties(intListId);

                    bool CanDelete = false;
                    try
                    {
                        CanDelete = bool.Parse(props["AllowDeleteInt"].ToString());
                    }
                    catch { }

                    if (CanDelete)
                    {
                        PostIntegrationDeleteToExternal(dtItems, intListId, new Guid(dr["LIST_ID"].ToString()));
                    }


                }
            }
            catch (Exception ex)
            {
                LogMessage("", dr["LIST_ID"].ToString(), "ProcessItemOutgoing: " + ex.Message, (int)IntegrationLogType.Error);
            }
        }

        internal void LogMessage(string intlistid, string listid, string message, int type)
        {
            const string insertCommandText = "INSERT INTO INT_LOG (INT_LIST_ID, LIST_ID, LOGTYPE, LOGTEXT) VALUES (@intlistid, @listid, @type, @text)";
            const string paramIntListId = "@intlistid";
            const string paramListId = "@listid";
            const string paramText = "@text";
            const string paramType = "@type";

            try
            {
                OpenConnection();

                using (var logCommand = new SqlCommand(insertCommandText, cn))
                {
                    if (!string.IsNullOrWhiteSpace(intlistid))
                    {
                        logCommand.Parameters.AddWithValue(paramIntListId, intlistid);
                    }
                    else
                    {
                        logCommand.Parameters.AddWithValue(paramIntListId, DBNull.Value);
                    }
                    
                    logCommand.Parameters.AddWithValue(paramListId, listid);
                    logCommand.Parameters.AddWithValue(paramText, message);
                    logCommand.Parameters.AddWithValue(paramType, type);
                    logCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection(false);
            }
        }

        internal Hashtable GetUserMap(string integrationlistid, bool reverse)
        {
            OpenConnection();

            Hashtable hsh = new Hashtable();

            string mapping = "Username";

            SqlCommand cmd = new SqlCommand("SELECT VALUE FROM INT_PROPS where INT_LIST_ID=@intlistid and PROPERTY='UserMapType'", cn);
            cmd.Parameters.AddWithValue("@intlistid", integrationlistid);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                mapping = dr.GetString(0);
            dr.Close();

            switch (mapping)
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
                    if (dr.Read())
                        moduleid = dr.GetGuid(0).ToString();
                    dr.Close();
                    if (moduleid != "")
                    {
                        string listid = "";

                        Guid lWeb = CoreFunctions.getLockedWeb(_web);
                        if (lWeb != _web.ID)
                        {
                            using (SPWeb oWeb = _site.OpenWeb(lWeb))
                            {
                                SPList list = oWeb.Lists.TryGetList("Resources");
                                if (list != null)
                                {
                                    listid = list.ID.ToString();
                                }
                            }

                        }
                        else
                        {
                            SPList list = _web.Lists.TryGetList("Resources");
                            if (list != null)
                            {
                                listid = list.ID.ToString();
                            }
                        }

                        if (listid != "")
                        {
                            cmd = new SqlCommand("SELECT INT_COLID FROM INT_LISTS where LIST_ID=@listid and MODULE_ID=@moduleid", cn);
                            cmd.Parameters.AddWithValue("@listid", listid);
                            cmd.Parameters.AddWithValue("@moduleid", moduleid);
                            dr = cmd.ExecuteReader();
                            if (dr.Read())
                                colid = dr.GetInt32(0).ToString();
                            dr.Close();
                        }
                    }
                    if (colid != "")
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

            foreach (DataRow drRes in dtResources.Rows)
            {
                if (drRes[mapping].ToString() != "")
                {
                    if (reverse)
                    {
                        if (!hsh.Contains(drRes[mapping].ToString()))
                            hsh.Add(drRes[mapping].ToString(), drRes["SPAccountInfo"].ToString());
                    }
                    else
                    {
                        if (!hsh.Contains(drRes["SPAccountInfo"].ToString()))
                            hsh.Add(drRes["SPAccountInfo"].ToString(), drRes[mapping].ToString());
                    }
                }
            }

            return hsh;

            CloseConnection(false);
        }

        internal void PostIntegration(DataTable dtItems, DataTable dtUserFields, DataTable dtColumns, SPList list)
        {
            Guid intlistid = new Guid(dtColumns.TableName);

            try
            {

                
                string colidname = "";
                try
                {
                    colidname = dtColumns.Select("IntegrationColumn='ID'")[0]["SharePointColumn"].ToString();
                }
                catch { }
                Hashtable hshUserMap = new Hashtable();
                if (dtUserFields.Select("Type='1'").Length > 0)
                {
                    hshUserMap = GetUserMap(dtColumns.TableName, false);
                }

                ArrayList arrColsDel = new ArrayList();

                Hashtable hshProps = GetProperties(intlistid);

                foreach (DataColumn dc in dtItems.Columns)
                {
                    if (dc.ColumnName != "SPID")
                    {
                        DataRow[] drColMap = dtColumns.Select("SharePointColumn='" + dc.ColumnName + "'");
                        DataRow[] drColUser = dtUserFields.Select("Fieldname='" + dc.ColumnName + "'");

                        if (drColMap.Length > 0)
                        {
                            dc.ColumnName = drColMap[0]["IntegrationColumn"].ToString();
                        }
                        else
                        {
                            arrColsDel.Add(dc);
                        }

                        if (drColUser.Length > 0 && drColMap.Length > 0)
                        {
                            if (drColUser[0]["Type"].ToString() == "1")
                            {
                                foreach (DataRow dr in dtItems.Rows)
                                {
                                    string newUserString = "";

                                    try
                                    {
                                        SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(_web, dr[dc.ColumnName].ToString());

                                        foreach (SPFieldUserValue uv in uvc)
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
                            else if (drColUser[0]["Type"].ToString() == "2" && drColMap[0]["Setting"].ToString() != "1")
                            {
                                if (drColUser[0]["LookupIntColID"].ToString() != "")
                                {
                                    SPList lookupList = _web.Lists[new Guid(drColUser[0]["LookupList"].ToString())];

                                    string col = "INTUID" + drColUser[0]["LookupIntColID"].ToString();

                                    foreach (DataRow dr in dtItems.Rows)
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
                                    foreach (DataRow dr in dtItems.Rows)
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

                foreach (DataColumn dc in arrColsDel)
                {
                    dtItems.Columns.Remove(dc);
                }

                TransactionTable dtReturn = PostIntegrationUpdateToExternal(dtItems, new Guid(dtColumns.TableName), list.ID);

                if (colidname != "")
                {
                    foreach (DataRow dr in dtReturn.Rows)
                    {
                        if (dr["Type"].ToString() == "1" || dr["Type"].ToString() == "2")
                        {
                            int itemid = int.Parse(dr["SPID"].ToString());
                            string intid = dr["ID"].ToString();


                            SPListItem li = list.GetItemById(itemid);
                            string curcolidval = "";
                            try
                            {
                                curcolidval = li[colidname].ToString();
                            }
                            catch { }

                            if (curcolidval != intid)
                            {
                                li[colidname] = intid;
                                li["INTUIDSYS"] = "True";
                                li.SystemUpdate();
                            }

                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(dtColumns.TableName, list.ID.ToString(), "PostIntegration: " + ex.Message, (int)IntegrationLogType.Error);
            }

            //PostCheckBit
            foreach (DataRow dr in dtItems.Rows)
            {
                PostCheckBit(intlistid, dr["SPID"].ToString(), true);
            }

        }

        private void PostCheckBit(Guid intlistid, string itemid, bool bCheck)
        {
            const string selectCommandText = "SELECT * FROM INT_CHECK WHERE INT_LIST_ID=@intlistid and ITEM_ID=@itemid";
            const string insertCommandText = "INSERT INTO INT_CHECK (INT_LIST_ID, ITEM_ID, CHECKBIT, CHECKTIME) VALUES (@intlistid, @itemid, @check, GETDATE())";
            const string updateCommandText = "UPDATE INT_CHECK SET CHECKBIT=@check, CHECKTIME=GETDATE() WHERE INT_LIST_ID=@intlistid and ITEM_ID=@itemid";
            const string paramIntListId = "@intlistid";
            const string paramItemId = "@itemid";
            const string paramCheck = "@check";

            var checkLogFound = false;
            using (var selectCommand = new SqlCommand(selectCommandText, cn))
            {
                selectCommand.Parameters.AddWithValue(paramIntListId, intlistid);
                selectCommand.Parameters.AddWithValue(paramItemId, itemid);

                using (var dataReader = selectCommand.ExecuteReader())
                {
                    checkLogFound = dataReader.Read();
                    dataReader.Close();
                }
            }

            if (checkLogFound)
            {
                using (var updateCommand = new SqlCommand(updateCommandText, cn))
                {
                    updateCommand.Parameters.AddWithValue(paramIntListId, intlistid);
                    updateCommand.Parameters.AddWithValue(paramItemId, itemid);
                    updateCommand.Parameters.AddWithValue(paramCheck, bCheck);
                    updateCommand.ExecuteNonQuery();
                }
            }
            else
            {
                using (var insertCommand = new SqlCommand(insertCommandText, cn))
                {
                    insertCommand.Parameters.AddWithValue(paramIntListId, intlistid);
                    insertCommand.Parameters.AddWithValue(paramItemId, itemid);
                    insertCommand.Parameters.AddWithValue(paramCheck, bCheck);
                    insertCommand.ExecuteNonQuery();
                }
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

        public string GetControlURL(Guid intlistid, Guid listid, string control, string ItemId)
        {

            IntegratorDef integrator = GetIntegrator(intlistid);

            IntegrationLog log = new IntegrationLog(cn, intlistid, listid, integrator.Title);

            Hashtable hshProps = GetProperties(intlistid);

            WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);

            try
            {
                return ((IIntegratorControls)integrator.iIntegrator).GetURL(webprops, log, control, ItemId);
            }
            catch { }
            return "";
        }

        public List<IntegrationControl> GetItemButtons(Guid listid, SPListItem li, out string Errors)
        {
            const string selectCommandText = "SELECT     dbo.INT_CONTROLS.CONTROL, dbo.INT_CONTROLS.IMAGE, dbo.INT_CONTROLS.TITLE,  dbo.INT_CONTROLS.WINDOWSTYLE FROM         dbo.INT_LISTS INNER JOIN dbo.INT_CONTROLS ON dbo.INT_LISTS.INT_LIST_ID = dbo.INT_CONTROLS.INT_LIST_ID WHERE LIST_ID=@listid and LOCAL=0 and GLOBAL=0";
            const string paramListId = "@listid";

            List<IntegrationControl> ics = new List<IntegrationControl>();
            Errors = "";
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    OpenConnection();

                    DataSet ds = new DataSet();

                    using (var command = new SqlCommand(selectCommandText, cn))
                    {
                        command.Parameters.AddWithValue(paramListId, listid);

                        using (var dataAdapter = new SqlDataAdapter(command))
                        {
                            dataAdapter.Fill(ds);
                        }
                    }

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        try
                        {
                            IntegrationControl i = new IntegrationControl();
                            i.Control = dr["CONTROL"].ToString();
                            i.Image = dr["IMAGE"].ToString();
                            i.Title = dr["TITLE"].ToString();
                            i.Window = (EPMLiveIntegration.IntegrationControlWindowStyle)int.Parse(dr["WINDOWSTYLE"].ToString());
                            ics.Add(i);
                        }
                        catch { }
                    }

                    CloseConnection(false);
                });

            }
            catch (Exception ex)
            {
                Errors += ex.Message;
            }
            return ics;
        }


        public List<IntegrationControl> GetGlobalButtons(Guid listid, SPListItem li, out string Errors)
        {
            const string selectCommandText = "SELECT     dbo.INT_CONTROLS.CONTROL, dbo.INT_CONTROLS.IMAGE, dbo.INT_CONTROLS.TITLE FROM         dbo.INT_LISTS INNER JOIN dbo.INT_CONTROLS ON dbo.INT_LISTS.INT_LIST_ID = dbo.INT_CONTROLS.INT_LIST_ID WHERE LIST_ID=@listid and LOCAL=0 and GLOBAL=0";
            const string paramListId = "@listid";

            List<IntegrationControl> ics = new List<IntegrationControl>();
            Errors = "";
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    OpenConnection();

                    DataSet ds = new DataSet();

                    using (var command = new SqlCommand(selectCommandText, cn))
                    {
                        command.Parameters.AddWithValue(paramListId, listid);

                        using (var dataAdapter = new SqlDataAdapter(command))
                        {
                            dataAdapter.Fill(ds);
                        }
                    }

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        IntegrationControl i = new IntegrationControl();
                        i.Control = dr["CONTROL"].ToString();
                        i.Image = dr["IMAGE"].ToString();
                        i.Title = dr["TITLE"].ToString();

                        ics.Add(i);
                    }

                    CloseConnection(false);
                });

            }
            catch (Exception ex)
            {
                Errors += ex.Message;
            }
            return ics;
        }

        public List<IntegrationControlDef> GetEmbbededControls(Guid listid, SPListItem li, out string Errors)
        {
            List<IntegrationControlDef> icds = new List<IntegrationControlDef>();
            Errors = "";
            try
            {
                DataTable dtInts = new DataTable();
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    dtInts = GetIntegrationsForList(listid);
                
                    foreach (DataRow dr in dtInts.Rows)
                    {
                        Guid intlistid = new Guid(dr["intlistid"].ToString());

                        IntegratorDef integrator = GetIntegrator(intlistid);

                        IntegrationLog log = new IntegrationLog(cn, intlistid, listid, integrator.Title);

                        Hashtable hshProps = GetProperties(intlistid);

                        WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);
                        
                        string ItemId = "";
                        try
                        {
                            ItemId = li["INTUID" + dr["INT_COLID"].ToString()].ToString();
                        }catch{}

                        if(ItemId != "")
                        {
                            try
                            {
                                List<string> conts = ((IIntegratorControls)integrator.iIntegrator).GetEmbeddedItemControls(webprops, log);

                                foreach (string cont in conts)
                                {
                                    IntegrationControlDef icd = new IntegrationControlDef();
                                    icd.HTML = ((IIntegratorControls)integrator.iIntegrator).GetControlCode(webprops, log, ItemId, cont);
                                    icd.id = dr["intlistid"].ToString();
                                    icds.Add(icd);
                                }
                            }
                            catch { }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Errors += ex.Message;
            }
            return icds;
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

        internal string GetProxyResult(Guid intlistid, string ItemId, string Control, string Property)
        {
            IntegratorDef integrator = GetIntegrator(intlistid);

            IntegrationLog log = new IntegrationLog(cn, intlistid, integrator.ListId, integrator.Title);

            Hashtable hshProps = GetProperties(intlistid);

            WebProperties webprops = GetWebProps(hshProps, integrator.intlistid);

            return ((IIntegratorControls)integrator.iIntegrator).GetProxyResult(webprops, log, ItemId, Control, Property);
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

            props.EnabledFeatures = new ArrayList();

            OpenConnection();

            SqlCommand cmd = new SqlCommand("SELECT     LIST_ID,INT_KEY from INT_LISTS where INT_LIST_ID=@intlistid", cn);
            cmd.Parameters.AddWithValue("@intlistid", intlistid);
            SqlDataReader dr = cmd.ExecuteReader();
            Guid listid = Guid.Empty;
            if (dr.Read())
            {
                listid = dr.GetGuid(0);
                props.IntegrationKey = dr.GetString(1);
            }
            dr.Close();
            CloseConnection(false);

            if (listid != Guid.Empty)
            {
                SPList list = _web.Lists[listid];

                GridGanttSettings gSettings = new GridGanttSettings(list);

                props.EnabledFeatures.Add("comments");
                if (gSettings.BuildTeam)
                    props.EnabledFeatures.Add("team");

                SPWeb rweb = _site.RootWeb;

                try
                {
                    if (_web.Site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null)
                    {

                        ArrayList arr = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPKLists").ToLower().Split(','));
                        if (arr.Contains(list.Title.ToLower()))
                        {
                            string menus = "";
                            menus = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPK" + list.Title.Replace(" ", "") + "_menus");
                            if (menus == "")
                                menus = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPKMenus");

                            ArrayList arrButtons = new ArrayList(menus.Split('|'));

                            if (arrButtons.Contains("costs"))
                                props.EnabledFeatures.Add("costplan");
                            if (arrButtons.Contains("resplan"))
                                props.EnabledFeatures.Add("resplan");
                        }
                    }
                }
                catch { }

                try
                {
                    if (_web.Site.Features[new Guid("e6df7606-1541-4bf1-a810-e8e9b11819e3")] != null)
                    {
                        string planners = CoreFunctions.getLockConfigSetting(_web, "EPMLivePlannerPlanners", false);

                        foreach (string planner in planners.Split(','))
                        {
                            if (!String.IsNullOrEmpty(planner))
                            {
                                string[] sPlanner = planner.Split('|');
                                string pc = CoreFunctions.getLockConfigSetting(_web, "EPMLivePlanner" + sPlanner[0] + "ProjectCenter", false);

                                if (pc == list.Title)
                                {
                                    props.EnabledFeatures.Add("workplan");
                                    break;
                                }
                            }
                        }
                    }
                }
                catch { }

                try
                {
                    ArrayList lists = new ArrayList(CoreFunctions.getConfigSetting(rweb, "EPMLiveTSLists").Replace("\r\n", "\n").Split('\n')); ;

                    if (lists.Contains(list.Title))
                    {
                        props.EnabledFeatures.Add("worklog");
                    }
                }
                catch { }
            }

            props.IntegrationAPIUrl = GetAPIUrl(_site.WebApplication.Id);

            return props;
        }

        internal Hashtable GetProperties(Guid intlistid)
        {
            const string selectCommandText01 = "SELECT     dbo.INT_MODULES.CustomProps FROM         dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID WHERE INT_LIST_ID=@intlistid";
            const string selectCommandText02 = "SELECT     Property, Value FROM INT_PROPS WHERE INT_LIST_ID=@intlistid";
            const string paramIntListId = "@intlistid";

            var properties = new Hashtable();

            try
            {
                OpenConnection();

                var propertyXml = string.Empty;

                using (var cmd = new SqlCommand(selectCommandText01, cn))
                {
                    cmd.Parameters.AddWithValue(paramIntListId, intlistid);

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read() && dataReader.FieldCount > 0)
                        {
                            propertyXml = dataReader.GetString(0);
                        }

                        dataReader.Close();
                    }
                }

                var xmlDoc = new XmlDocument();

                try
                {
                    xmlDoc.LoadXml(propertyXml);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                    xmlDoc.LoadXml("<props/>");
                }

                using (var command = new SqlCommand(selectCommandText02, cn))
                {
                    command.Parameters.AddWithValue(paramIntListId, intlistid);

                    using (var dataReader = command.ExecuteReader())
                    {
                        const int firstFieldIndex = 0;
                        const int secondFieldIndex = 1;

                        while (dataReader.Read() && dataReader.FieldCount > secondFieldIndex)
                        {
                            var pass = false;
                            try
                            {
                                const string attrType = "Type";
                                const string valuePassword = "Password";

                                var xmlNode = xmlDoc.FirstChild.SelectSingleNode(string.Format("//Input[@Property='{0}']",
                                                                                               dataReader.GetString(firstFieldIndex)));
                                if (xmlNode != null && xmlNode.Attributes[attrType].Value == valuePassword)
                                {
                                    pass = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                Trace.TraceError(ex.ToString());
                            }

                            if (pass)
                            {
                                const string passPhrase = "kKGBJ768d3q78^#&^dsas";
                                properties.Add(dataReader.GetString(firstFieldIndex),
                                               CoreFunctions.Decrypt(dataReader.GetString(secondFieldIndex), passPhrase));
                            }
                            else
                            {
                                properties.Add(dataReader.GetString(firstFieldIndex), dataReader.GetString(secondFieldIndex));
                            }
                        }

                        dataReader.Close();
                    }
                }
            }
            finally
            {
                CloseConnection(false);
            }

            return properties;
        }

        private IntegratorDef GetIntegrator(Guid intlistid)
        {
            const string selectCommandText = "SELECT     dbo.INT_MODULES.MODULE_ID, dbo.INT_MODULES.NetAssembly, dbo.INT_MODULES.NetClass,Title,INT_KEY,LIST_ID,INT_COLID,INT_LIST_ID FROM         dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID WHERE INT_LIST_ID=@intlistid";
            const string paramIntListId = "@intlistid";
            const string intColPrefix = "INTUID";
            const int indexOfAssemblyName = 1;
            const int indexOfTypeName = 2;
            const int indexOfTitle = 3;
            const int indexOfIntKey = 4;
            const int indexOfListId = 5;
            const int indexOfColId = 6;
            const int indexOfIntListId = 7;

            OpenConnection();

            IntegratorDef def = new IntegratorDef();

            string netAssembly = "";
            string netClass = "";

            using (var command = new SqlCommand(selectCommandText, cn))
            {
                command.Parameters.AddWithValue(paramIntListId, intlistid);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read() && dataReader.FieldCount > indexOfIntListId)
                    {
                        netAssembly = dataReader.GetString(indexOfAssemblyName);
                        netClass = dataReader.GetString(indexOfTypeName);
                        def.Title = dataReader.GetString(indexOfTitle);
                        def.IntKey = dataReader.GetString(indexOfIntKey);
                        def.ListId = dataReader.GetGuid(indexOfListId);
                        def.intcol = string.Concat(intColPrefix, dataReader.GetInt32(indexOfColId));
                        def.intlistid = dataReader.GetGuid(indexOfIntListId);
                    }
                    dataReader.Close();
                }
            }

            Assembly assemblyInstance = Assembly.Load(netAssembly);
            Type thisClass = assemblyInstance.GetType(netClass);


            def.iIntegrator = (IIntegrator)Activator.CreateInstance(thisClass);


            return def;

        }

        private IIntegrator GetIntegratorFromModule(Guid moduleid, out string title)
        {
            const string selectCommandText = "SELECT NetAssembly, NetClass,Title FROM INT_MODULES WHERE MODULE_ID=@moduleid";
            const string paramModuleId = "@moduleid";
            const int indexOfAssemblyName = 0;
            const int indexOfTypeName = 1;
            const int indexOfTitle = 2;

            OpenConnection();

            string netAssembly = "";
            string netClass = "";
            title = "";

            using (var command = new SqlCommand(selectCommandText, cn))
            {
                command.Parameters.AddWithValue(paramModuleId, moduleid);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        netAssembly = dataReader.GetString(indexOfAssemblyName);
                        netClass = dataReader.GetString(indexOfTypeName);
                        title = dataReader.GetString(indexOfTitle);
                    }

                    dataReader.Close();
                }
            }

            CloseConnection(true);

            Assembly assemblyInstance = Assembly.Load(netAssembly.Trim());
            Type thisClass = assemblyInstance.GetType(netClass.Trim());
            return (IIntegrator)Activator.CreateInstance(thisClass);

        }

        internal void ProcessItem(DataSet dsItem, SPListItem li, SPList list)
        {

            ArrayList arrCols = new ArrayList();

            foreach (DataColumn dc in dsItem.Tables[0].Columns)
            {

                if (dc.ColumnName == "SPID")
                {
                    arrCols.Add(li.ID.ToString());
                }
                else
                {
                    try
                    {
                        SPField field = list.Fields.GetFieldByInternalName(dc.ColumnName);

                        string val = "";

                        switch (field.Type)
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
                                if (indexof > 0)
                                {
                                    val = val.Substring(indexof + 2);
                                }
                                break;
                            default:
                                if (field.TypeAsString == "TotalRollup")
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
            if (li == null)
            {
                throw new ArgumentNullException("li");
            }

            const string selectCommandText = "SELECT INT_COLID FROM INT_LISTS where LIST_ID=@listid";
            const string insertCommandText = "INSERT INTO INT_EVENTS (LIST_ID, ITEM_ID, INTITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @itemid, @intitemid, @colid, 0, 1, @type)";
            const string colNameIntColId = "INT_COLID";
            const string fieldNameIntUniqueId = "INTUID";
            const string paramListId = "@listid";
            const string paramItemId = "@itemid";
            const string paramIntItemId = "@intitemid";
            const string paramColId = "@colid";
            const string paramType = "@type";
            const int eventType = 2;

            try
            {
                OpenConnection();

                using (var selectCommand = new SqlCommand(selectCommandText, cn))
                {
                    selectCommand.Parameters.AddWithValue(paramListId, li.ParentList.ID);

                    using (var dataSet = new DataSet())
                    using (var dataAdapter = new SqlDataAdapter(selectCommand))
                    {
                        dataAdapter.Fill(dataSet);

                        if (dataSet.Tables.Count > 0)
                        {
                            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                            {
                                var intItemId = string.Empty;

                                try
                                {
                                    intItemId = li[string.Concat(fieldNameIntUniqueId, dataRow[colNameIntColId])].ToString();
                                }
                                catch (Exception ex)
                                {
                                    Trace.TraceError(ex.ToString());
                                }

                                if (!string.IsNullOrWhiteSpace(intItemId))
                                {
                                    using (var insertCommand = new SqlCommand(insertCommandText, cn))
                                    {
                                        insertCommand.Parameters.AddWithValue(paramListId, li.ParentList.ID);
                                        insertCommand.Parameters.AddWithValue(paramItemId, li.ID);
                                        insertCommand.Parameters.AddWithValue(paramIntItemId, intItemId);
                                        insertCommand.Parameters.AddWithValue(paramColId, dataRow[colNameIntColId].ToString());
                                        insertCommand.Parameters.AddWithValue(paramType, eventType);
                                        insertCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                CloseConnection(true);
            }
        }

        internal void SubmitListEvent(SPListItem li, int eventType, SPItemEventDataCollection AfterProperties)
        {
            const string selectCommandText = "SELECT INT_COLID, INT_LIST_ID FROM INT_LISTS where LIST_ID=@listid";
            const string insertCommandText = "INSERT INTO INT_EVENTS (LIST_ID, ITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @itemid, @colid, 0, 1, @type)";
            const string paramListId = "@listid";
            const string paramItemId = "@itemid";
            const string paramColId = "@colid";
            const string paramType = "@type";

            if (li == null)
            {
                throw new ArgumentNullException("li");
            }

            if (AfterProperties == null)
            {
                throw new ArgumentNullException("AfterProperties");
            }

            try
            {
                string sys = "";
                try
                {
                    sys = AfterProperties["INTUIDSYS"].ToString();
                }
                catch { }

                if (sys == "")
                {
                    OpenConnection();

                    string colid = "";
                    Guid intlistid = Guid.Empty;

                    using (var sqlCommand = new SqlCommand(selectCommandText, cn))
                    {
                        sqlCommand.Parameters.AddWithValue(paramListId, li.ParentList.ID);

                        const int indexOfColId = 0;
                        const int indexOfIntListId = 1;

                        using (var dataReader = sqlCommand.ExecuteReader())
                        {
                            string fieldIntUid;
                            while (dataReader.Read() && dataReader.FieldCount > indexOfIntListId)
                            {
                                fieldIntUid = string.Concat(TextIntUid, dataReader.GetInt32(indexOfColId));
                                if (AfterProperties[fieldIntUid] != null &&
                                    !string.IsNullOrWhiteSpace(AfterProperties[fieldIntUid].ToString()))
                                {
                                    intlistid = dataReader.GetGuid(indexOfIntListId);
                                    colid = dataReader.GetInt32(indexOfColId).ToString();
                                    break;
                                }
                            }
                            dataReader.Close();
                        }
                    }

                    if (colid == string.Empty || bCheckBit(intlistid, li.ID, colid))
                    {
                        using (var sqlCommand = new SqlCommand(insertCommandText, cn))
                        {
                            sqlCommand.Parameters.AddWithValue(paramListId, li.ParentList.ID);
                            sqlCommand.Parameters.AddWithValue(paramItemId, li.ID);
                            sqlCommand.Parameters.AddWithValue(paramColId, colid);
                            sqlCommand.Parameters.AddWithValue(paramType, eventType);
                            sqlCommand.ExecuteNonQuery();
                        }
                    }

                    if (intlistid != Guid.Empty)
                    {
                        PostCheckBit(intlistid, li.ID.ToString(), false);
                    }

                    CloseConnection(true);
                }
            }
            catch (Exception ex)
            {
                LogMessage("", li.ParentList.ID.ToString(), "SubmitListEvent: " + ex.Message, (int)IntegrationLogType.Error);
            }
        }

        private bool bCheckBit(Guid intlistid, int itemid, string colid)
        {
            const string commandText = "SELECT CHECKBIT,CHECKTIME FROM dbo.INT_LISTS INNER JOIN dbo.INT_CHECK ON dbo.INT_LISTS.INT_LIST_ID = dbo.INT_CHECK.INT_LIST_ID WHERE INT_CHECK.INT_LIST_ID=@intlistid and ITEM_ID=@itemid and INT_COLID=@colid";
            const string paramIntListId = "@intlistid";
            const string paramColId = "@colid";
            const string paramItemId = "@itemid";

            var bCheck = false;

            using (var cmd = new SqlCommand(commandText, cn))
            {
                cmd.Parameters.AddWithValue(paramIntListId, intlistid);
                cmd.Parameters.AddWithValue(paramColId, colid);
                cmd.Parameters.AddWithValue(paramItemId, itemid);

                using (var dataReader = cmd.ExecuteReader())
                {
                    const int indexOfCheckBit = 0;
                    const int indexofCheckTime = 1;

                    if (dataReader.Read())
                    {
                        if (!dataReader.GetBoolean(indexOfCheckBit))
                        {
                            bCheck = true;
                        }
                        else
                        {
                            const int minMinutes = 5;
                            var ts = DateTime.Now - dataReader.GetDateTime(indexofCheckTime);

                            bCheck = ts.TotalMinutes > minMinutes;
                        }
                    }
                    else
                    {
                        bCheck = true;
                    }

                    dataReader.Close();
                }
            }

            return bCheck;
        }

        private void AddField(SPField field, DataTable dtU, DataRow drIntegrationModule, ref DataTable dt)
        {
            if (!dt.Columns.Contains(field.InternalName))
            {
                Type t;
                switch (field.Type)
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
                        if (dtU.Select("Fieldname='" + field.InternalName + "'").Length <= 0)
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


                            if (dtU.Select("Fieldname='" + field.InternalName + "'").Length <= 0)
                            {
                                if (dsOther.Tables[0].Rows.Count > 0)
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

        internal DataSet GetDataSet(SPList list, string eventfromid, Guid intlistid)
        {
            const string paramIntListId = "@intlistid";
            const string paramListId = "@listid";
            const string paramPriority = "@priority";

            DataSet dsIntegration = new DataSet();

            DataTable dt = new DataTable("Data");
            dt.Columns.Add("SPID");

            DataSet dsIntegrations = new DataSet();

            int priority = 0;

            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = cn;

                if (intlistid == Guid.Empty)
                {
                    sqlCommand.CommandText = "SELECT * FROM INT_LISTS where LIST_ID=@listid and Active=1 and LIVEOUTGOING=1 and PRIORITY > @priority order by priority";
                    sqlCommand.Parameters.AddWithValue(paramListId, list.ID);
                    sqlCommand.Parameters.AddWithValue(paramPriority, priority);
                }
                else
                {
                    sqlCommand.CommandText = "SELECT * FROM INT_LISTS where INT_LIST_ID=@intlistid";
                    sqlCommand.Parameters.AddWithValue(paramIntListId, intlistid);
                }

                using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    dataAdapter.Fill(dsIntegrations);
                }
            }

            dsIntegration.Tables.Add(dt);

            DataTable dtU = new DataTable("UserFields");
            dtU.Columns.Add("Fieldname");
            dtU.Columns.Add("Type");
            dtU.Columns.Add("LookupIntColID");
            dtU.Columns.Add("LookupList");
            dsIntegration.Tables.Add(dtU);

            foreach (DataRow drIntegrationModule in dsIntegrations.Tables[0].Rows)
            {
                if (drIntegrationModule["INT_COLID"].ToString() != eventfromid)
                {
                    dt.Columns.Add("INTUID" + drIntegrationModule["INT_COLID"].ToString());

                    DataTable dtCols = new DataTable(drIntegrationModule["INT_LIST_ID"].ToString());
                    dtCols.Columns.Add("SharePointColumn");
                    dtCols.Columns.Add("IntegrationColumn");
                    dtCols.Columns.Add("Setting");

                    dsIntegration.Tables.Add(dtCols);

                    dtCols.Rows.Add(new string[] { "INTUID" + drIntegrationModule["INT_COLID"].ToString(), "ID", "" });

                    var dsCols = new DataSet();
                    using (var sqlCommand = new SqlCommand("SELECT SharePointColumn, IntegrationColumn, Setting FROM INT_COLUMNS where INT_LIST_ID=@intlistid", cn))
                    {
                        sqlCommand.Parameters.AddWithValue(paramIntListId, drIntegrationModule[ColNameIntListId].ToString());

                        using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            dataAdapter.Fill(dsCols);
                        }
                    }

                    foreach (DataRow dr in dsCols.Tables[0].Rows)
                    {
                        try
                        {
                            SPField field = list.Fields.GetFieldByInternalName(dr["SharePointColumn"].ToString());
                            if (field != null)
                            {
                                dtCols.Rows.Add(new string[] { dr["SharePointColumn"].ToString(), dr["IntegrationColumn"].ToString(), dr["Setting"].ToString() });

                                if (!dt.Columns.Contains(dr["SharePointColumn"].ToString()))
                                {
                                    AddField(field, dtU, drIntegrationModule, ref dt);
                                }
                            }
                        }
                        catch { }
                    }

                }
            }

            return dsIntegration;
        }

        internal string GetAPIUrl(Guid webappid)
        {
            string apiurl = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPWebApplication webapp = SPWebService.ContentService.WebApplications[webappid];
                    apiurl = webapp.Properties["epmliveapiurl"].ToString();
                    if (apiurl.EndsWith("/"))
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
            if (cn.State != ConnectionState.Open)
                cn.Open();
            else
                WasOpen = true;
        }

        internal void CloseConnection(bool force)
        {
            if (cn.State == ConnectionState.Open && (force || !WasOpen))
                cn.Close();
        }

        ~IntegrationCore()
        {
            if(_web != null)
                _web.Close();
        }
    }
}

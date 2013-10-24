using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Xml;
using System.Collections;
using System.Data.SqlClient;

namespace EPMLiveCore.API
{
    public class APITeam
    {
        private static DataTable getResources(SPWeb web, string filterfield, string filtervalue, bool hasPerms, ArrayList arrColumns, SPListItem liItem)
        {

            SPList list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool")];
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("SPID");
            dt.Columns.Add("SPAccountInfo");
            dt.Columns.Add("Username");
            dt.Columns.Add("PrincipalType");
            dt.Columns.Add("Photo");
            dt.Columns.Add("Groups");

            if (hasPerms)
            {
                if (arrColumns != null)
                {
                    if (arrColumns.Contains("SimpleColumns"))
                    {
                        dt.Columns.Remove("Groups");
                        dt.Columns.Remove("Photo");
                        dt.Columns.Add("Title");
                    }
                    else
                    {
                        foreach (SPField f in list.Fields)
                        {
                            if (arrColumns.Contains(f.InternalName))
                            {
                                dt.Columns.Add(f.InternalName);
                            }
                        }
                    }
                }
                else
                {
                    foreach (SPField f in list.Fields)
                    {
                        if (!f.Hidden && f.Reorderable)
                        {
                            dt.Columns.Add(f.InternalName);
                        }
                    }
                }
            }
            else
            {
                dt.Columns.Add("Title");
            }


            var rb = new EPMLiveReportsAdmin.ReportBiz(web.Site.ID);

            if (rb.SiteExists())
            {
                EPMLiveReportsAdmin.EPMData data = new EPMLiveReportsAdmin.EPMData(web.Site.ID);

                SqlConnection cn = data.GetClientReportingConnection;

                bool bNewDB = false;
                bool blookup = false;

                SqlCommand cmd = new SqlCommand("select * from sys.tables where name = 'RPTGROUPUSER'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    bNewDB = true;

                dr.Close();


                if (bNewDB)
                {
                    if (filterfield != "")
                    {
                        if (list.Fields.GetFieldByInternalName(filterfield).Type == SPFieldType.User || list.Fields.GetFieldByInternalName(filterfield).Type == SPFieldType.Lookup)
                        {
                            filterfield += "Text";
                            blookup = true;
                        }
                    }

                    dt = iGetResourceFromRPT(cn, list, dt, web, filterfield, filtervalue, blookup, hasPerms, arrColumns, liItem);
                }
                else
                    dt = iGetResourcesFromlist(list, dt, web, filterfield, filtervalue, hasPerms, arrColumns, liItem);

                cn.Close();


            }
            else
                dt = iGetResourcesFromlist(list, dt, web, filterfield, filtervalue, hasPerms, arrColumns, liItem);

            return dt;
        }

        private static DataTable iGetResourceFromRPT(SqlConnection cn, SPList list, DataTable dt, SPWeb web, string filterfield, string filtervalue, bool filterIsLookup, bool hasPerms, ArrayList arrColumns, SPListItem liItem)
        {
            SPList userInfoList = web.SiteUserInfoList;

            string query = "";

            if (filterfield != "")
            {
                if (filterIsLookup)
                    query = "';'+" + filterfield + "+';' like '%;" + filtervalue + ";%'";
                else
                    query = filterfield + " like '%" + filtervalue + "%'";
            }

            SqlCommand cmd = new SqlCommand("select * from information_schema.parameters where specific_name='spGetReportListData' and parameter_name='@orderby'", cn);
            bool borderby = false;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                borderby = true;
            dr.Close();

            cmd = new SqlCommand("spGetReportListData", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
            cmd.Parameters.AddWithValue("@webid", web.ID);
            cmd.Parameters.AddWithValue("@weburl", web.ServerRelativeUrl);
            cmd.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
            cmd.Parameters.AddWithValue("@rollup", false);
            cmd.Parameters.AddWithValue("@list", "Resourcepool");
            cmd.Parameters.AddWithValue("@query", query);
            if (borderby)
                cmd.Parameters.AddWithValue("@orderby", "Title");

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                ArrayList item = new ArrayList();

                if (dRow["SharePointAccountID"].ToString() != "")
                {
                    int userid = int.Parse(dRow["SharePointAccountID"].ToString());

                    SPUser oUser = null;
                    try
                    {
                        oUser = web.SiteUsers.GetByID(userid);
                    }
                    catch { }

                    foreach (DataColumn col in dt.Columns)
                    {

                        if (col.ColumnName == "ID")
                        {
                            item.Add(dRow["ItemId"].ToString());
                        }
                        else if (col.ColumnName == "SPID")
                        {
                            item.Add(dRow["SharePointAccountID"].ToString());
                        }
                        else if (col.ColumnName == "Groups")
                        {
                            if (liItem != null)
                            {
                                string sGroups = "";
                                try
                                {
                                    if (oUser != null)
                                    {
                                        foreach (SPRoleAssignment role in liItem.RoleAssignments)
                                        {
                                            try
                                            {
                                                if (role.Member.GetType() == typeof(SPGroup))
                                                {
                                                    SPGroup group = (SPGroup)role.Member;
                                                    if (group.Users.GetByID(userid) != null)
                                                    {
                                                        sGroups += ";" + group.ID;
                                                    }
                                                }
                                            }
                                            catch { }
                                        }

                                        sGroups = sGroups.Trim(';');
                                    }
                                }
                                catch { }

                                item.Add(sGroups);
                            }
                            else
                            {
                                string sGroups = "";
                                try
                                {
                                    if (oUser != null)
                                    {
                                        foreach (SPGroup g in oUser.Groups)
                                        {
                                            sGroups += ";" + g.ID;
                                        }
                                    }
                                    sGroups = sGroups.Trim(';');
                                }
                                catch { }

                                item.Add(sGroups);
                            }
                        }
                        else if (col.ColumnName == "Photo")
                        {
                            string userPictureUrl = ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_layouts/images/person.gif";
                            try
                            {
                                SPListItem userItem = userInfoList.GetItemById(oUser.ID);

                                if (userItem["Picture"] != null)
                                {
                                    userPictureUrl = userItem["Picture"].ToString().Remove(userItem["Picture"].ToString().IndexOf(','));
                                }
                            }
                            catch { }
                            item.Add("<img src=\"" + userPictureUrl + "\" height=\"62\">");
                        }
                        else if (col.ColumnName == "PrincipalType")
                        {
                            try
                            {
                                if (oUser == null)
                                    item.Add("SharePointGroup");
                                else
                                    item.Add("User");
                            }
                            catch { item.Add(""); }
                        }
                        else if (col.ColumnName == "Username")
                        {
                            try
                            {
                                if (oUser == null)
                                    item.Add(userid);
                                else
                                    item.Add(oUser.LoginName);
                            }
                            catch { item.Add(""); }
                        }
                        else if (col.ColumnName == "SPAccountInfo")
                        {
                            try
                            {
                                item.Add(dRow["SharePointAccountID"].ToString() + ";#" + dRow["SharePointAccountText"].ToString());
                            }
                            catch { item.Add(""); }
                        }
                        else
                        {
                            string val = "";
                            try
                            {
                                SPField f = list.Fields.GetFieldByInternalName(col.ColumnName);
                                if (f.Type == SPFieldType.Number || f.Type == SPFieldType.Currency)
                                {
                                    val = dRow[col.ColumnName].ToString();
                                }
                                else if (f.Type == SPFieldType.Lookup || f.Type == SPFieldType.User)
                                {
                                    if (dRow[col.ColumnName + "ID"].ToString() != "")
                                    {
                                        try
                                        {
                                            string[] sIds = dRow[col.ColumnName + "ID"].ToString().Split(',');
                                            string[] sVals = dRow[col.ColumnName + "Text"].ToString().Split(',');

                                            for (int i = 0; i < sIds.Length; i++)
                                            {
                                                val += ";" + sVals[i];
                                            }

                                            val = val.Substring(1);
                                        }
                                        catch { }
                                    }
                                }
                                else
                                    val = f.GetFieldValueAsText(dRow[col.ColumnName].ToString());
                            }
                            catch { }
                            item.Add(val);
                        }
                    }
                    dt.Rows.Add(item.ToArray());
                }
            }

            return dt;
        }

        private static DataTable iGetResourcesFromlist(SPList list, DataTable dt, SPWeb web, string filterfield, string filtervalue, bool hasPerms, ArrayList arrColumns, SPListItem liItem)
        {
            SPQuery query = new SPQuery();
            if (filterfield == "")
                query.Query = "<OrderBy><FieldRef Name='Title'/></OrderBy>";
            else
                query.Query = "<Where><Contains><FieldRef Name='" + filterfield + "'/><Value Type=\"Text\">" + filtervalue + "</Value></Contains></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

            if (arrColumns != null)
            {
                foreach (string col in arrColumns)
                {
                    query.ViewFields += "<FieldRef Name='" + col + "'/>";
                }
                if (!arrColumns.Contains("SharePointAccount"))
                    query.ViewFields += "<FieldRef Name='SharePointAccount'/>";
            }

            SPList userInfoList = web.SiteUserInfoList;

            SPListItemCollection lic = list.GetItems(query);

            foreach (SPListItem li in lic)
            {
                string spAccount = "";
                try
                {
                    spAccount = li["SharePointAccount"].ToString();
                }
                catch { }
                if (spAccount != "")
                {
                    ArrayList item = new ArrayList();

                    SPFieldUserValue uv = null;
                    try
                    {
                        uv = new SPFieldUserValue(web, li["SharePointAccount"].ToString());
                    }
                    catch { }

                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName == "ID")
                        {
                            item.Add(li.ID);
                        }
                        else if (col.ColumnName == "SPID")
                        {
                            item.Add(uv.LookupId);
                        }
                        else if (col.ColumnName == "Groups")
                        {
                            if (liItem != null)
                            {
                                string sGroups = "";
                                try
                                {
                                    if (uv.User != null)
                                    {
                                        foreach (SPRoleAssignment role in liItem.RoleAssignments)
                                        {
                                            try
                                            {
                                                if (role.Member.GetType() == typeof(SPGroup))
                                                {
                                                    SPGroup group = (SPGroup)role.Member;
                                                    if (group.Users.GetByID(uv.LookupId) != null)
                                                    {
                                                        sGroups += ";" + group.ID;
                                                    }
                                                }
                                            }
                                            catch { }
                                        }
                                    }
                                    sGroups = sGroups.Trim(';');
                                }
                                catch { }

                                item.Add(sGroups);
                            }
                            else
                            {
                                string sGroups = "";
                                try
                                {
                                    if (uv.User != null)
                                    {
                                        foreach (SPGroup g in uv.User.Groups)
                                        {
                                            sGroups += ";" + g.ID;
                                        }
                                    }
                                    sGroups = sGroups.Trim(';');
                                }
                                catch { }

                                item.Add(sGroups);
                            }
                        }
                        else if (col.ColumnName == "Photo")
                        {
                            string userPictureUrl = ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_layouts/images/person.gif";
                            try
                            {
                                SPListItem userItem = userInfoList.GetItemById(uv.User.ID);

                                if (userItem["Picture"] != null)
                                {
                                    userPictureUrl = userItem["Picture"].ToString().Remove(userItem["Picture"].ToString().IndexOf(','));
                                }
                            }
                            catch { }
                            item.Add("<img src=\"" + userPictureUrl + "\" height=\"62\">");
                        }
                        else if (col.ColumnName == "PrincipalType")
                        {
                            try
                            {
                                if (uv.User == null)
                                    item.Add("SharePointGroup");
                                else
                                    item.Add("User");
                            }
                            catch { item.Add(""); }
                        }
                        else if (col.ColumnName == "Username")
                        {
                            try
                            {
                                if (uv.User == null)
                                    item.Add(uv.LookupValue);
                                else
                                    item.Add(uv.User.LoginName);
                            }
                            catch { item.Add(""); }
                        }
                        else if (col.ColumnName == "SPAccountInfo")
                        {
                            try
                            {
                                item.Add(li["SharePointAccount"].ToString());
                            }
                            catch { item.Add(""); }
                        }
                        else
                        {
                            string val = "";
                            try
                            {
                                SPField f = list.Fields.GetFieldByInternalName(col.ColumnName);
                                if (f.Type == SPFieldType.Number || f.Type == SPFieldType.Currency)
                                {
                                    val = li[col.ColumnName].ToString();
                                }
                                else
                                    val = f.GetFieldValueAsText(li[col.ColumnName].ToString());
                            }
                            catch { }
                            item.Add(val);
                        }
                    }
                    dt.Rows.Add(item.ToArray());
                }
            }

            return dt;
        }

        public static string SaveTeam(string sdoc, SPWeb oWeb)
        {
            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml("<Team/>");

            try
            {
                string modifiedUsers = "";

                XmlDocument docTeam = new XmlDocument();
                docTeam.LoadXml(sdoc);

                Guid listid = Guid.Empty;
                int itemid = 0;

                try
                {
                    listid = new Guid(docTeam.FirstChild.Attributes["ListId"].Value);
                }
                catch { }
                try
                {
                    itemid = int.Parse(docTeam.FirstChild.Attributes["ItemId"].Value);
                }
                catch { }


                oWeb.AllowUnsafeUpdates = true;

                bool bUseTeam = false;

                if (listid != Guid.Empty)
                {
                    SPList list = oWeb.Lists[listid];
                    GridGanttSettings gSettings = new GridGanttSettings(list);
                    bUseTeam = gSettings.BuildTeam;
                }

                if (listid != Guid.Empty && bUseTeam)
                {

                    SPList list = oWeb.Lists[listid];
                    SPListItem li = list.GetItemById(itemid);

                    SPFieldUserValueCollection uvc = null;
                    try
                    {
                        uvc = new SPFieldUserValueCollection(oWeb, li["AssignedTo"].ToString());
                    }
                    catch { }
                    if (uvc == null)
                        uvc = new SPFieldUserValueCollection();

                    DataTable dtResourcePool = null;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        dtResourcePool = GetResourcePool(sdoc, oWeb);
                    });

                    ArrayList arrUsers = new ArrayList();

                    foreach (SPFieldUserValue uv in uvc)
                    {
                        arrUsers.Add(uv.LookupId);
                    }

                    foreach (XmlNode nd in docTeam.SelectNodes("//Team/Member"))
                    {
                        DataRow[] drRes = dtResourcePool.Select("ID='" + nd.Attributes["ID"].Value + "'");
                        if (drRes.Length > 0)
                        {
                            SPFieldUserValue uv = new SPFieldUserValue(oWeb, drRes[0]["SPID"].ToString());

                            if (!arrUsers.Contains(int.Parse(drRes[0]["SPID"].ToString())))
                            {
                                uvc.Add(uv);
                            }

                            if (uv.User != null)
                                modifiedUsers += "," + uv.User.ID;

                            setItemPermissions(oWeb, uv.ToString(), nd.Attributes["Permissions"].Value, li);

                            try
                            {
                                arrUsers.Remove(int.Parse(drRes[0]["SPID"].ToString()));
                            }
                            catch { }
                        }


                    }

                    ArrayList arrDelete = new ArrayList();

                    foreach (int i in arrUsers)
                    {
                        foreach (SPFieldUserValue uv in uvc)
                        {
                            if (uv.LookupId == i)
                            {
                                arrDelete.Add(uv);
                                setItemPermissions(oWeb, uv.ToString(), "", li);

                                if (uv.User != null)
                                    modifiedUsers += "," + uv.User.ID;
                            }
                        }
                    }

                    foreach (SPFieldUserValue uv in arrDelete)
                    {
                        uvc.Remove(uv);
                    }

                    li["AssignedTo"] = uvc;
                    li.SystemUpdate();


                }
                else
                {
                    SPList list = oWeb.Lists["Team"];
                    DataTable dt = list.Items.GetDataTable();

                    DataTable dtResourcePool = null;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        dtResourcePool = GetResourcePool(sdoc, oWeb);
                    });

                    foreach (XmlNode nd in docTeam.SelectNodes("//Team/Member"))
                    {

                        string id = nd.Attributes["ID"].Value;
                        DataRow[] drRes = dtResourcePool.Select("ID='" + id + "'");
                        if (dt == null)
                        {
                            SPListItem li = list.Items.Add();
                            li["Title"] = drRes[0]["Title"].ToString();
                            li["ResID"] = drRes[0]["ID"].ToString();
                            li.Update();
                        }
                        else
                        {
                            DataRow[] drs = dt.Select("ResID=" + id);

                            if (drs.Length == 0)
                            {
                                SPListItem li = list.Items.Add();
                                li["Title"] = drRes[0]["Title"].ToString();
                                li["ResID"] = drRes[0]["ID"].ToString();
                                li.Update();
                            }
                            else
                            {
                                dt.Rows.Remove(drs[0]);
                            }
                        }
                        setPermissions(oWeb, drRes[0]["SPAccountInfo"].ToString(), nd.Attributes["Permissions"].Value);

                        try
                        {
                            modifiedUsers += "," + drRes[0]["SPID"].ToString();
                        }
                        catch { }

                        XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "Member", docOut.NamespaceURI);

                        XmlAttribute nattr = docOut.CreateAttribute("ID");
                        nattr.Value = nd.Attributes["ID"].Value;
                        ndNew.Attributes.Append(nattr);

                        nattr = docOut.CreateAttribute("Status");
                        nattr.Value = "0";
                        ndNew.Attributes.Append(nattr);

                        docOut.FirstChild.AppendChild(ndNew);
                    }

                    if (dt != null)
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using (SPSite oSite = new SPSite(oWeb.Site.ID))
                            {
                                using (SPWeb Web = oSite.OpenWeb(oWeb.ID))
                                {
                                    Web.AllowUnsafeUpdates = true;

                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        try
                                        {
                                            DataRow[] drRes = dtResourcePool.Select("ID='" + dr["ResID"].ToString() + "'");

                                            SPFieldUserValue uv = new SPFieldUserValue(oWeb, drRes[0]["SPAccountInfo"].ToString());

                                            try
                                            {
                                                modifiedUsers += "," + uv.User.ID;
                                            }
                                            catch { }

                                            foreach (SPGroup g in Web.Groups)
                                            {
                                                try
                                                {
                                                    g.Users.RemoveByID(uv.LookupId);
                                                }
                                                catch { }
                                            }
                                        }
                                        catch { }

                                        list.Items.DeleteItemById(int.Parse(dr["ID"].ToString()));

                                    }

                                }
                            }

                        });
                    }
                }


                try
                {
                    Guid tJob = API.Timer.AddTimerJob(oWeb.Site.ID, oWeb.ID, "Process Security", 40, modifiedUsers.Trim(','), "", 0, 99, "");
                    API.Timer.Enqueue(tJob, 0, oWeb.Site);
                }
                catch { }
            }
            catch (Exception ex)
            {
                throw new APIException(3010, ex.Message);
            }
            return docOut.OuterXml;
        }

        private static void setItemPermissions(SPWeb web, string user, string perms, SPListItem li)
        {
            //bool isCurrentlyInGroup = false;
            //bool isAdded = false;

            try
            {
                SPFieldUserValue uv = new SPFieldUserValue(web, user);
                ArrayList arr = new ArrayList(perms.Split(';'));

                foreach (SPRoleAssignment role in li.RoleAssignments)
                {
                    try
                    {
                        if (role.Member.GetType() == typeof(SPGroup))
                        {
                            SPGroup group = (SPGroup)role.Member;
                            SPUser tempuser = null;
                            try
                            {
                                tempuser = group.Users.GetByID(uv.LookupId);
                            }
                            catch { }
                            if (tempuser == null && arr.Contains(group.ID.ToString()))
                            {
                                group.AddUser(uv.User);
                            }
                            if (tempuser != null && !arr.Contains(group.ID.ToString()))
                            {
                                group.RemoveUser(uv.User);
                            }
                        }
                    }
                    catch { }
                }

                //foreach(SPGroup group in web.Groups)
                //{
                //    try
                //    {
                //        if(group.Users.GetByID(uv.LookupId) != null)
                //        {
                //            isCurrentlyInGroup = true;
                //        }
                //    }
                //    catch { }

                //    if(group.CanCurrentUserEditMembership)
                //    {
                //        if(arr.Contains(group.ID.ToString()))
                //        {
                //            try
                //            {
                //                group.AddUser(uv.User);
                //                isAdded = true;
                //            }
                //            catch { }
                //        }
                //        else
                //        {
                //            try
                //            {
                //                group.RemoveUser(uv.User);
                //            }
                //            catch { }
                //        }
                //    }
                //}
                //if(!isCurrentlyInGroup && isAdded)
                //{
                //    APIEmail.sendEmail(2, uv.LookupId, new Hashtable());
                //}
            }
            catch { }

        }

        private static void setPermissions(SPWeb web, string user, string perms)
        {
            bool isCurrentlyInGroup = false;
            bool isAdded = false;

            try
            {
                SPFieldUserValue uv = new SPFieldUserValue(web, user);
                ArrayList arr = new ArrayList(perms.Split(';'));

                foreach (SPGroup group in web.Groups)
                {
                    try
                    {
                        if (group.Users.GetByID(uv.LookupId) != null)
                        {
                            isCurrentlyInGroup = true;
                        }
                    }
                    catch { }

                    if (group.CanCurrentUserEditMembership)
                    {
                        if (arr.Contains(group.ID.ToString()))
                        {
                            try
                            {
                                group.AddUser(uv.User);
                                isAdded = true;
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                group.RemoveUser(uv.User);
                            }
                            catch { }
                        }
                    }
                }
                if (!isCurrentlyInGroup && isAdded)
                {
                    APIEmail.sendEmail(2, uv.LookupId, new Hashtable());
                }
            }
            catch { }

        }

        public static string GetTeam(string queryDoc, SPWeb oWeb)
        {
            try
            {
                string filterfield = "";
                string filterval = "";
                ArrayList columns = null;
                Guid webid = Guid.Empty;
                Guid listid = Guid.Empty;
                int itemid = 0;
                string currentteam = null;

                bool bUseTeam = false;

                if (queryDoc != "")
                {
                    try
                    {
                        XmlDocument docQuery = new XmlDocument();
                        docQuery.LoadXml(queryDoc);

                        try
                        {
                            currentteam = docQuery.FirstChild.Attributes["CurrentTeam"].Value;
                        }
                        catch { }
                        try
                        {
                            webid = new Guid(docQuery.FirstChild.Attributes["WebId"].Value);
                        }
                        catch { }
                        try
                        {
                            listid = new Guid(docQuery.FirstChild.Attributes["ListId"].Value);
                        }
                        catch { }
                        try
                        {
                            itemid = int.Parse(docQuery.FirstChild.Attributes["ItemId"].Value);
                        }
                        catch { }

                        try
                        {
                            filterfield = docQuery.FirstChild.Attributes["Column"].Value;
                            filterval = docQuery.FirstChild.Attributes["Value"].Value;
                        }
                        catch { }

                        try
                        {
                            XmlNode ndCols = docQuery.FirstChild.SelectSingleNode("//Columns");
                            if (ndCols != null)
                            {
                                columns = new ArrayList();

                                if (ndCols.InnerText != "")
                                {
                                    string[] cols = ndCols.InnerText.Split(',');
                                    foreach (string col in cols)
                                    {
                                        columns.Add(col);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                    catch { }


                }

                XmlDocument doc;



                if (webid != Guid.Empty)
                {
                    using (SPWeb web = oWeb.Site.OpenWeb(webid))
                    {
                        if (listid != Guid.Empty)
                        {
                            SPList list = web.Lists[listid];
                            GridGanttSettings gSettings = ListCommands.GetGridGanttSettings(list);
                            bUseTeam = gSettings.BuildTeam;
                        }


                        if (currentteam != null)
                        {
                            doc = GetTeamFromCurrent(web, filterfield, filterval, columns, currentteam);
                        }
                        else if (listid != Guid.Empty && bUseTeam)
                        {
                            doc = GetTeamFromListItem(web, filterfield, filterval, columns, listid, itemid);
                        }
                        else
                        {
                            doc = GetTeamFromWeb(web, filterfield, filterval, columns);
                        }
                    }
                }
                else
                {
                    if (listid != Guid.Empty)
                    {
                        SPList list = oWeb.Lists[listid];
                        GridGanttSettings gSettings = new GridGanttSettings(list);
                        bUseTeam = gSettings.BuildTeam;
                    }

                    if (currentteam != null)
                    {
                        doc = GetTeamFromCurrent(oWeb, filterfield, filterval, columns, currentteam);
                    }
                    else if (listid != Guid.Empty && bUseTeam)
                    {
                        doc = GetTeamFromListItem(oWeb, filterfield, filterval, columns, listid, itemid);
                    }
                    else
                    {
                        doc = GetTeamFromWeb(oWeb, filterfield, filterval, columns);
                    }
                }

                return doc.OuterXml;
            }
            catch (Exception ex)
            {
                throw new APIException(3010, "Error in Get Team: " + ex.Message);
            }
        }

        private static XmlDocument GetTeamFromCurrent(SPWeb web, string filterfield, string filterval, ArrayList arrColumns, string currentteam)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Team/>");

            try
            {


                string resUrl = "";

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(web.Site.ID))
                    {
                        using (SPWeb aweb = site.OpenWeb(web.ID))
                        {
                            resUrl = CoreFunctions.getConfigSetting(aweb, "EPMLiveResourceURL", true, false);
                        }
                    }
                });

                DataTable dtResources = null;

                try
                {
                    using (SPSite rsite = new SPSite(resUrl))
                    {
                        using (SPWeb rweb = rsite.OpenWeb())
                        {
                            dtResources = getResources(rweb, filterfield, filterval, true, arrColumns, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("access is denied"))
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using (SPSite rsite = new SPSite(resUrl))
                            {
                                using (SPWeb rweb = rsite.OpenWeb())
                                {
                                    dtResources = getResources(rweb, filterfield, filterval, false, arrColumns, null);
                                }
                            }
                        });
                    }
                }

                try
                {
                    string[] sTeam = currentteam.Split(',');

                    foreach (string member in sTeam)
                    {
                        DataRow[] drs = dtResources.Select("SPID='" + member + "'");
                        if (drs.Length > 0)
                        {
                            XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "Member", doc.NamespaceURI);

                            foreach (DataColumn dc in dtResources.Columns)
                                addAttribute(ref ndNew, doc, drs[0], dc.ColumnName);

                            doc.FirstChild.AppendChild(ndNew);
                        }
                    }
                }
                catch { }
            }
            catch (Exception ex)
            {
                throw new APIException(3025, "Error: " + ex.Message);
            }

            return doc;
        }

        private static XmlDocument GetTeamFromListItem(SPWeb web, string filterfield, string filterval, ArrayList arrColumns, Guid ListId, int ItemId)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Team/>");

            try
            {
                SPListItem li = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite tSite = new SPSite(web.Site.ID))
                    {
                        using (SPWeb tWeb = tSite.OpenWeb(web.ID))
                        {
                            SPList list = tWeb.Lists[ListId];
                            li = list.GetItemById(ItemId);



                            string resUrl = "";

                            //SPSecurity.RunWithElevatedPrivileges(delegate()
                            //{
                            //using(SPSite site = new SPSite(web.Site.ID))
                            //{
                            //using(SPWeb aweb = site.OpenWeb(web.ID))
                            //{
                            resUrl = CoreFunctions.getConfigSetting(tWeb, "EPMLiveResourceURL", true, false);
                            //}
                            //}
                            //});

                            DataTable dtResources = null;

                            try
                            {
                                using (SPSite rsite = new SPSite(resUrl))
                                {
                                    using (SPWeb rweb = rsite.OpenWeb())
                                    {
                                        dtResources = getResources(rweb, filterfield, filterval, true, arrColumns, li);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.ToLower().Contains("access is denied"))
                                {
                                    SPSecurity.RunWithElevatedPrivileges(delegate()
                                    {
                                        //using(SPSite rsite = new SPSite(resUrl))
                                        {
                                            using (SPWeb rweb = tSite.OpenWeb())
                                            {
                                                dtResources = getResources(rweb, filterfield, filterval, false, arrColumns, li);
                                            }
                                        }
                                    });
                                }
                            }

                            try
                            {

                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(tWeb, li["AssignedTo"].ToString());

                                SortedList slUsers = new SortedList();

                                foreach (SPFieldUserValue uv in uvc)
                                {
                                    DataRow[] drs = dtResources.Select("SPID='" + uv.LookupId + "'");
                                    if (drs.Length > 0)
                                    {
                                        XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "Member", doc.NamespaceURI);

                                        foreach (DataColumn dc in dtResources.Columns)
                                            addAttribute(ref ndNew, doc, drs[0], dc.ColumnName);

                                        //doc.FirstChild.AppendChild(ndNew);

                                        string perms = "";
                                        try
                                        {
                                            foreach (SPRoleAssignment role in li.RoleAssignments)
                                            {
                                                try
                                                {
                                                    if (role.Member.GetType() == typeof(SPGroup))
                                                    {
                                                        SPGroup group = (SPGroup)role.Member;
                                                        if (group.Users.GetByID(uv.LookupId) != null)
                                                        {
                                                            perms += ";" + group.ID;
                                                        }
                                                    }
                                                }
                                                catch { }
                                            }
                                        }
                                        catch { }

                                        XmlAttribute attr = doc.CreateAttribute("Permissions");
                                        attr.Value = perms.Trim(';');
                                        ndNew.Attributes.Append(attr);

                                        slUsers.Add(drs[0]["Title"].ToString(), ndNew);
                                    }
                                }

                                foreach (DictionaryEntry de in slUsers)
                                {
                                    doc.FirstChild.AppendChild((XmlNode)de.Value);
                                }

                            }
                            catch { }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                throw new APIException(3025, "Error: " + ex.Message);
            }

            return doc;
        }

        private static XmlDocument GetTeamFromWeb(SPWeb web, string filterfield, string filterval, ArrayList arrColumns)
        {
            SPList list = web.Lists.TryGetList("Team");
            web.Site.CatchAccessDeniedException = false;
            if (list == null)
            {
                web.AllowUnsafeUpdates = true;
                web.Lists.Add("Team", "Use this list to manage your project team", SPListTemplateType.GenericList);
                list = web.Lists.TryGetList("Team");
                try
                {
                    list.Fields.Add("ResID", SPFieldType.Number, false);
                    list.Update();
                }
                catch { }
            }

            if (list == null)
            {
                throw new APIException(3011, "Cannot Find Team List or Create a new Team List");
            }

            //DataTable dtTeam = list.Items.GetDataTable();
            DataTable dtTeam = null;
            try
            {
                DataView dv = list.Items.GetDataTable().DefaultView;
                dv.Sort = "Title";
                dtTeam = dv.Table;
            }
            catch { }

            DataTable dtResources = null;

            web.Site.CatchAccessDeniedException = false;
            bool isResSite = false;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Team/>");
            string resUrl = "";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(web.Site.ID))
                {
                    using (SPWeb aweb = site.OpenWeb(web.ID))
                    {
                        resUrl = CoreFunctions.getConfigSetting(aweb, "EPMLiveResourceURL", true, false);
                    }
                }
            });

            try
            {
                using (SPSite rsite = new SPSite(resUrl))
                {
                    using (SPWeb rweb = rsite.OpenWeb())
                    {
                        if (resUrl.ToLower() == web.ServerRelativeUrl.ToLower())
                            isResSite = true;

                        dtResources = getResources(rweb, filterfield, filterval, true, arrColumns, null);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("access is denied"))
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite rsite = new SPSite(resUrl))
                        {
                            using (SPWeb rweb = rsite.OpenWeb())
                            {
                                if (resUrl.ToLower() == web.ServerRelativeUrl.ToLower())
                                    isResSite = true;

                                dtResources = getResources(rweb, filterfield, filterval, false, arrColumns, null);
                            }
                        }
                    });
                }
            }

            bool IsBuildTeamFeatureEnabled = false;

            if (web.Features[new Guid("84520a2b-8e2b-4ada-8f48-60b138923d01")] != null)
                IsBuildTeamFeatureEnabled = true;

            if (dtTeam != null && dtResources != null || isResSite || !IsBuildTeamFeatureEnabled)
            {

                foreach (DataRow dr in dtResources.Rows)
                {
                    if (isResSite || !IsBuildTeamFeatureEnabled || dtTeam.Select("ResID='" + dr["ID"].ToString() + "'").Length > 0)
                    {
                        XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "Member", doc.NamespaceURI);

                        foreach (DataColumn dc in dtResources.Columns)
                            addAttribute(ref ndNew, doc, dr, dc.ColumnName);

                        doc.FirstChild.AppendChild(ndNew);

                        string perms = "";

                        try
                        {
                            SPFieldUserValue uv = new SPFieldUserValue(web, dr["SPAccountInfo"].ToString());
                            foreach (SPGroup group in uv.User.Groups)
                            {
                                try
                                {
                                    if (web.Groups.GetByID(group.ID) != null)
                                    {
                                        perms += ";" + group.ID;
                                    }
                                }
                                catch { }
                            }
                            //foreach(SPGroup group in web.Groups)
                            //{
                            //    try
                            //    {
                            //        if(group.Users.GetByID(uv.LookupId) != null)
                            //        {
                            //            perms += ";" + group.ID;
                            //        }
                            //    }
                            //    catch { }
                            //}
                        }
                        catch { }

                        XmlAttribute attr = doc.CreateAttribute("Permissions");
                        attr.Value = perms.Trim(';');
                        ndNew.Attributes.Append(attr);
                    }
                }
            }

            return doc;
        }

        private static void addAttribute(ref XmlNode nd, XmlDocument doc, DataRow dr, string attribute)
        {
            XmlAttribute attr = doc.CreateAttribute(attribute);
            try
            {
                attr.Value = dr[attribute].ToString();
            }
            catch { }
            nd.Attributes.Append(attr);
        }

        private static XmlDocument GetGenericResourceGrid(string id, SPWeb oWeb)
        {

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtTeamGridLayout);

            XmlNode cfg = docOut.FirstChild.SelectSingleNode("//Cfg[@id='TeamGrid']");
            cfg.Attributes["id"].Value = id;

            XmlNode ndHeader = docOut.SelectSingleNode("//Header");
            XmlNode ndCols = docOut.SelectSingleNode("//Cols");
            XmlNode ndNew;
            XmlAttribute attr;

            oWeb.Site.CatchAccessDeniedException = false;

            try
            {
                string sResList = "";

                sResList = CoreFunctions.getConfigSetting(oWeb, "EPMLiveResourceURL", true, false);

                using (SPSite site = new SPSite(sResList))
                {
                    site.CatchAccessDeniedException = false;
                    using (SPWeb rWeb = site.OpenWeb())
                    {
                        SPList list = rWeb.Lists.TryGetList("Resources");
                        if (list != null)
                        {
                            foreach (SPField field in list.Fields)
                            {
                                if (!field.Hidden && field.Reorderable)
                                {
                                    if (field.InternalName != "Title" && field.InternalName != "Permissions")
                                    {
                                        ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
                                        attr = docOut.CreateAttribute("Name");
                                        attr.Value = field.InternalName;
                                        ndNew.Attributes.Append(attr);

                                        attr = docOut.CreateAttribute("Type");
                                        attr.Value = "Html";
                                        ndNew.Attributes.Append(attr);

                                        attr = docOut.CreateAttribute("Visible");
                                        attr.Value = "0";
                                        ndNew.Attributes.Append(attr);

                                        attr = docOut.CreateAttribute("Width");
                                        attr.Value = "100";
                                        ndNew.Attributes.Append(attr);

                                        ndCols.AppendChild(ndNew);

                                        attr = docOut.CreateAttribute(field.InternalName);
                                        attr.Value = field.Title;
                                        ndHeader.Attributes.Append(attr);

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("access is denied"))
                {
                    docOut.LoadXml(Properties.Resources.txtTeamGridLayout);
                    ndCols = docOut.SelectSingleNode("//Cols");
                    ndHeader = docOut.SelectSingleNode("//Header");

                    cfg = docOut.FirstChild.SelectSingleNode("//Cfg[@id='TeamGrid']");
                    cfg.Attributes["id"].Value = id;

                    ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
                    attr = docOut.CreateAttribute("Name");
                    attr.Value = "Title";
                    ndNew.Attributes.Append(attr);

                    attr = docOut.CreateAttribute("Type");
                    attr.Value = "Html";
                    ndNew.Attributes.Append(attr);

                    attr = docOut.CreateAttribute("RelWidth");
                    attr.Value = "100";
                    ndNew.Attributes.Append(attr);

                    ndCols.AppendChild(ndNew);

                    attr = docOut.CreateAttribute("Title");
                    attr.Value = "Display Name";
                    ndHeader.Attributes.Append(attr);
                }
            }

            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "SPAccountInfo";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Html";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);

            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "Groups";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Html";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);

            return docOut;
        }

        public static string GetTeamGridLayout(string xml, SPWeb oWeb)
        {
            XmlDocument doc = GetGenericResourceGrid("TeamGrid", oWeb);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite tSite = new SPSite(oWeb.Site.ID))
                {
                    using (SPWeb tWeb = tSite.OpenWeb(oWeb.ID))
                    {



                        Guid listid = Guid.Empty;
                        int itemid = 0;
                        GridGanttSettings gSettings = null;
                        SPList oList = null;
                        SPListItem oLi = null;

                        if (!string.IsNullOrEmpty(xml))
                        {
                            XmlDocument InputDoc = new XmlDocument();
                            InputDoc.LoadXml(xml);

                            try
                            {
                                listid = new Guid(InputDoc.FirstChild.Attributes["ListId"].Value);
                                oList = tWeb.Lists[listid];
                                gSettings = new GridGanttSettings(oList);
                            }
                            catch { }
                            try
                            {
                                itemid = int.Parse(InputDoc.FirstChild.Attributes["ItemId"].Value);
                                oLi = oList.GetItemById(itemid);
                            }
                            catch { }
                        }




                        XmlNode ndRightCols = doc.SelectSingleNode("//Cols");
                        XmlNode ndHeader = doc.SelectSingleNode("//Header");

                        XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "C", doc.NamespaceURI);
                        XmlAttribute attr = doc.CreateAttribute("Name");
                        attr.Value = "Permissions";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("Type");
                        attr.Value = "Enum";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("Range");
                        attr.Value = "1";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("RelWidth");
                        attr.Value = "1";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("Visible");
                        attr.Value = "1";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("CanHide");
                        attr.Value = "0";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("IconAlign");
                        attr.Value = "Right";
                        ndNew.Attributes.Append(attr);

                        XmlNode nd = doc.SelectSingleNode("//C[@Name='Photo']");
                        if (nd != null)
                        {
                            nd.Attributes["Visible"].Value = "1";
                        }

                        nd = doc.SelectSingleNode("//C[@Name='Role']");
                        if (nd != null)
                        {
                            nd.Attributes["Visible"].Value = "1";
                        }

                        nd = doc.SelectSingleNode("//C[@Name='Email']");
                        if (nd != null)
                        {
                            nd.Attributes["Visible"].Value = "1";
                        }

                        string enums = "";
                        string enumkeys = "";



                        if (gSettings != null && gSettings.BuildTeam && oLi != null && oLi.HasUniqueRoleAssignments)
                        {
                            foreach (SPRoleAssignment assn in oLi.RoleAssignments)
                            {
                                if (assn.Member.GetType() == typeof(Microsoft.SharePoint.SPGroup))
                                {
                                    SPGroup group = (SPGroup)assn.Member;

                                    if (group.CanCurrentUserEditMembership)
                                    {
                                        enums += "|" + group.Name;
                                        enumkeys += "|" + group.ID;
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (SPGroup group in tWeb.Groups)
                            {
                                if (group.CanCurrentUserEditMembership)
                                {
                                    enums += "|" + group.Name;
                                    enumkeys += "|" + group.ID;
                                }

                            }
                        }

                        attr = doc.CreateAttribute("Enum");
                        attr.Value = enums;
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("EnumKeys");
                        attr.Value = enumkeys;
                        ndNew.Attributes.Append(attr);


                        ndRightCols.AppendChild(ndNew);
                    }
                }
            });

            return doc.OuterXml;
        }

        public static string GetResourceGridLayout(string xml, SPWeb oWeb)
        {
            XmlDocument doc = GetGenericResourceGrid("ResourceGrid", oWeb);

            XmlNode nd = doc.SelectSingleNode("//C[@Name='Role']");
            if (nd != null)
            {
                nd.Attributes["Visible"].Value = "1";
            }

            nd = doc.SelectSingleNode("//C[@Name='Department']");
            if (nd != null)
            {
                nd.Attributes["Visible"].Value = "1";
            }

            nd = doc.SelectSingleNode("//C[@Name='Photo']");
            if (nd != null)
            {
                nd.Attributes["Visible"].Value = "0";
            }


            return doc.OuterXml;
        }

        private static bool isValidResField(string field)
        {
            switch (field)
            {
                case "Permissions":
                    return false;
            };
            return true;
        }

        public static string GetResourceGridData(string xml, SPWeb oWeb)
        {

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml("<Grid><Body><B></B></Body></Grid>");

            XmlNode ndBody = docOut.FirstChild.SelectSingleNode("//B");

            try
            {
                DataTable dtTemp = GetResourcePool("", oWeb);
                foreach (DataRow dr in dtTemp.Rows)
                {
                    XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);

                    XmlAttribute nattr = docOut.CreateAttribute("NoColorState");
                    nattr.Value = "1";
                    ndNew.Attributes.Append(nattr);

                    foreach (DataColumn dc in dtTemp.Columns)
                    {
                        if (dc.ColumnName == "ID")
                        {
                            nattr = docOut.CreateAttribute("id");
                            nattr.Value = dr[dc].ToString();
                            ndNew.Attributes.Append(nattr);
                        }
                        else
                        {
                            if (isValidResField(dc.ColumnName))
                            {
                                nattr = docOut.CreateAttribute(dc.ColumnName);
                                //nattr.Value = list.Fields.GetFieldByInternalName(dc.ColumnName).GetFieldValueAsText(dr[dc].ToString());
                                nattr.Value = dr[dc].ToString();
                                ndNew.Attributes.Append(nattr);
                            }
                        }
                    }

                    if (dr["Disabled"].ToString() == "Yes")
                    {
                        nattr = docOut.CreateAttribute("Visible");
                        nattr.Value = "0";
                        ndNew.Attributes.Append(nattr);
                    }

                    ndBody.AppendChild(ndNew);
                }
            }
            catch { }

            return docOut.OuterXml;
        }

        public static string GetTeamGridData(string xml, SPWeb oWeb)
        {
            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml("<Grid><Body><B></B></Body></Grid>");

            XmlNode ndBody = docOut.FirstChild.SelectSingleNode("//B");

            XmlDocument docTeam = new XmlDocument();
            docTeam.LoadXml(GetTeam(xml, oWeb));

            foreach (XmlNode nd in docTeam.FirstChild.ChildNodes)
            {
                XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);

                XmlAttribute nattr = docOut.CreateAttribute("NoColorState");
                nattr.Value = "1";
                ndNew.Attributes.Append(nattr);

                foreach (XmlAttribute attr in nd.Attributes)
                {
                    if (attr.Name == "ID")
                    {
                        nattr = docOut.CreateAttribute("id");
                        nattr.Value = attr.Value;
                        ndNew.Attributes.Append(nattr);
                    }
                    else
                    {
                        nattr = docOut.CreateAttribute(attr.Name);
                        nattr.Value = attr.Value;
                        ndNew.Attributes.Append(nattr);
                    }
                }

                ndBody.AppendChild(ndNew);
            }

            return docOut.OuterXml;
        }

        public static DataTable GetResourcePool(string xml, SPWeb oWeb)
        {
            string resUrl = "";

            ArrayList arrColumns = null;
            string filterval = "";
            string filterfield = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);

                try
                {
                    XmlNode ndCols = doc.FirstChild.SelectSingleNode("//Columns");
                    if (ndCols != null)
                    {
                        arrColumns = new ArrayList();

                        if (ndCols.InnerText != "")
                        {
                            string[] cols = ndCols.InnerText.Split(',');
                            foreach (string col in cols)
                            {
                                arrColumns.Add(col);
                            }
                        }
                    }
                }
                catch { }

                try
                {
                    filterfield = doc.FirstChild.Attributes["FilterField"].Value;
                    filterval = doc.FirstChild.Attributes["FilterFieldValue"].Value;
                }
                catch { }
            }
            catch { }

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(oWeb.Site.ID))
                {
                    using (SPWeb aweb = site.OpenWeb(oWeb.ID))
                    {
                        resUrl = CoreFunctions.getConfigSetting(aweb, "EPMLiveResourceURL", true, false);
                    }
                }
            });

            DataTable dt = new DataTable();

            try
            {
                using (SPSite rsite = new SPSite(resUrl))
                {
                    rsite.CatchAccessDeniedException = false;
                    using (SPWeb rweb = rsite.OpenWeb())
                    {
                        dt = getResources(rweb, filterfield, filterval, true, arrColumns, null);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("access is denied"))
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite rsite = new SPSite(resUrl))
                        {
                            using (SPWeb rweb = rsite.OpenWeb())
                            {
                                dt = getResources(rweb, filterfield, filterval, false, arrColumns, null);
                            }
                        }
                    });
                }
            }

            return dt;
        }
    }
}

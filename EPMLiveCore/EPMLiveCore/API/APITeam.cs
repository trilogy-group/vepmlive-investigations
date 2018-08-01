using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DocumentFormat.OpenXml.Drawing.Charts;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using System.Data;
using System.Xml;
using System.Collections;
using System.Data.SqlClient;
using EPMLiveCore.Infrastructure;
using DataTable = System.Data.DataTable;
using EPMLiveCore.Infrastructure.Logging;
using EPMLiveCore.PfeData;

using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore.API
{
    public class APITeam
    {
        private const string AllowEditProjectRateColumn = "AllowEditProjectRate";
        private const string GenericColumn = "Generic";
        private const string GenericColumnYes = "Yes";
        private const string ProjectCenterListName = "Project Center";
        private const string ProjectRateColumn = "ProjectRate";
        private const string ProjectRateColumnCaption = "Project Rate";
        private const string ProjectRateEditColumn = "ProjectRateEdit";
        private const string StandardRateColumn = "StandardRate";
        private const string TitleColumn = "Title";
        private const string UsernameColumn = "Username";

        private static DataTable getResources(SPWeb web, string filterfield, string filtervalue, bool hasPerms, ArrayList arrColumns, SPListItem liItem, XmlNodeList nodeTeam)
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
                    //else
                    {
                        foreach (SPField f in list.Fields)
                        {
                            if (arrColumns.Contains(f.InternalName))
                            {
                                try
                                {
                                    dt.Columns.Add(f.InternalName);
                                }
                                catch { }
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
                            try
                            {
                                dt.Columns.Add(f.InternalName);
                            }
                            catch { }
                        }
                    }
                }
            }
            else
            {
                dt.Columns.Add("Title");
            }

            var reportBiz = new ReportHelper.ReportBiz(web.Site.ID);
            if (reportBiz.SiteExists())
            {
                var epmData = new ReportHelper.EPMData(web.Site.ID);
                using (var sqlConnection = epmData.GetClientReportingConnection)
                {
                    var isNewDb = false;
                    var isLookup = false;

                    using (var sqlCommand = new SqlCommand("select * from sys.tables where name = 'RPTGROUPUSER'", sqlConnection))
                    {
                        using (var dataReader = sqlCommand.ExecuteReader())
                        {
                            isNewDb = dataReader.Read();
                        }
                    }

                    if (isNewDb)
                    {
                        if (filterfield != string.Empty)
                        {
                            var filterFieldType = list.Fields.GetFieldByInternalName(filterfield).Type;
                            if (filterFieldType == SPFieldType.User || filterFieldType == SPFieldType.Lookup)
                            {
                                filterfield += "Text";
                                isLookup = true;
                            }
                        }

                        dt = iGetResourceFromRPT(
                            sqlConnection,
                            list,
                            dt,
                            web,
                            filterfield,
                            filtervalue,
                            isLookup,
                            hasPerms,
                            arrColumns,
                            liItem,
                            nodeTeam);
                    }
                    else
                    {
                        dt = iGetResourcesFromlist(list, dt, web, filterfield, filtervalue, hasPerms, arrColumns, liItem);
                    }
                }
            }
            else
            {
                dt = iGetResourcesFromlist(list, dt, web, filterfield, filtervalue, hasPerms, arrColumns, liItem);
            }

            return dt;
        }

        private static DataTable iGetResourceFromRPT(SqlConnection cn, SPList list, DataTable dt, SPWeb web, string filterfield, string filtervalue, bool filterIsLookup, bool hasPerms, ArrayList arrColumns, SPListItem liItem, XmlNodeList nodeTeam)
        {
            SPList userInfoList = web.SiteUserInfoList;

            string query = "";

            if (filterfield != "")
            {
                if (filterIsLookup)
                    query = "';'+" + filterfield + "+';' like '%;" + filtervalue + ";%'" + " OR " + filterfield + " like '%" + filtervalue + "%'";
                else
                    query = filterfield + " like '%" + filtervalue + "%'";
            }

            SqlCommand cmd = new SqlCommand("select * from information_schema.parameters where specific_name='spGetReportListData' and parameter_name='@orderby'", cn);
            bool borderby = false;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                borderby = true;
            dr.Close();

            string filterOnID = "";
            string iDs = "";
            Dictionary<string, int> liItemSPGroups = new Dictionary<string, int>();
            if (liItem != null)
            {
                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(web, Convert.ToString(liItem["AssignedTo"]));
                foreach (var uv in uvc)
                {
                    iDs = uv.LookupId + "," + iDs;
                }
                if (iDs != "")
                {
                    filterOnID = "SharePointAccountID in (###)";
                    iDs = iDs.Substring(0, iDs.Length - 1);
                    filterOnID = filterOnID.Replace("###", iDs);
                }

                foreach (SPRoleAssignment role in liItem.RoleAssignments)
                {
                    if (role.Member.GetType() == typeof(SPGroup))
                    {
                        SPGroup group = (SPGroup)role.Member;
                        GridGanttSettings gSettings = new GridGanttSettings(list);
                        List<string> gridSettingPermissions = new List<string>();
                        if (gSettings.BuildTeamPermissions.Length > 1)
                        {

                            string[] strOuter = gSettings.BuildTeamPermissions.Split(new string[] { "|~|" }, StringSplitOptions.None);
                            foreach (string strInner in strOuter)
                            {
                                string[] strInnerMost = strInner.Split('~');
                                SPGroup g = null;
                                try
                                {
                                    g = web.SiteGroups.GetByID(Convert.ToInt32(strInnerMost[0]));
                                }
                                catch { g = null; }
                                if (g != null)
                                {
                                    gridSettingPermissions.Add(g.Name);
                                }
                            }
                        }
                        if (!gridSettingPermissions.Contains(group.Name))
                        {
                            foreach (SPUser user in group.Users)
                            {
                                liItemSPGroups.Add(string.Format("{0}-{1}", group.ID, user.ID), user.ID);
                            }
                        }
                    }
                }
            }
            else if (nodeTeam != null && nodeTeam.Count > 0)
            {
                foreach (XmlNode node in nodeTeam)
                {
                    iDs = node.Attributes["ID"].Value + "," + iDs;
                }
                if (iDs != "")
                {
                    filterOnID = "ID in (###)";
                    iDs = iDs.Substring(0, iDs.Length - 1);
                    filterOnID = filterOnID.Replace("###", iDs);
                }
            }

            cmd = new SqlCommand("spGetReportListData", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
            cmd.Parameters.AddWithValue("@webid", web.ID);
            cmd.Parameters.AddWithValue("@weburl", web.ServerRelativeUrl);
            cmd.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
            cmd.Parameters.AddWithValue("@rollup", false);
            cmd.Parameters.AddWithValue("@list", "Resourcepool");
            cmd.Parameters.AddWithValue("@query", query != "" ? query : filterOnID);
            if (borderby)
                cmd.Parameters.AddWithValue("@orderby", "Title");

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            DataSet dsUserInfo = new DataSet();
            DataTable dtUserInfo = null;
            cmd = new SqlCommand("SELECT ID,Picture FROM LSTUserInformationList where siteid = @siteid and webid = @webid", cn);
            cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
            cmd.Parameters.AddWithValue("@webid", web.ID);
            da = new SqlDataAdapter(cmd);
            da.Fill(dsUserInfo);
            if (dsUserInfo.Tables.Count > 0)
            {
                dtUserInfo = dsUserInfo.Tables[0];
            }

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
                                        //foreach (SPRoleAssignment role in liItem.RoleAssignments)
                                        //{
                                        //    try
                                        //    {
                                        //        if (role.Member.GetType() == typeof(SPGroup))
                                        //        {
                                        //            SPGroup group = (SPGroup)role.Member;
                                        //            if (group.Users.GetByID(userid) != null)
                                        //            {
                                        //                sGroups += ";" + group.ID;
                                        //            }
                                        //        }
                                        //    }
                                        //    catch { }
                                        //}
                                        //sGroups = sGroups.Trim(';');

                                        try
                                        {
                                            var groupIds = (from lg in liItemSPGroups
                                                            where lg.Value.Equals(userid)
                                                            select lg.Key.Split('-')[0]).ToArray();
                                            sGroups = string.Join(";", groupIds);
                                        }
                                        catch { }
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
                                //SPListItem userItem = userInfoList.GetItemById(oUser.ID);
                                //if (userItem["Picture"] != null)
                                //{
                                //    userPictureUrl = userItem["Picture"].ToString().Remove(userItem["Picture"].ToString().IndexOf(','));
                                //}
                                DataRow[] drUserInfo = dtUserInfo.Select("ID = " + oUser.ID);
                                if (drUserInfo != null && drUserInfo.Count() > 0)
                                {
                                    string imgUrl = Convert.ToString(drUserInfo[0]["Picture"]);
                                    if (!string.IsNullOrEmpty(imgUrl))
                                    {
                                        if (imgUrl.Contains(","))
                                            imgUrl = imgUrl.Remove(imgUrl.IndexOf(','));
                                        userPictureUrl = imgUrl;
                                    }
                                }
                            }
                            catch { }
                            item.Add("<img src=\"" + userPictureUrl + "\" height=\"62\" />");
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
            ResourceGrid.ClearCache(oWeb);
            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml("<Team/>");
            bool bUseTeam = false;
            int teamMemberCount = 0;

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

                try
                {
                    if (listid == Guid.Empty && itemid == 0)
                    {
                        APITeam.VerifyProjectTeamWorkspace(oWeb, out itemid, out listid);
                        if (itemid > 0 && listid != Guid.Empty)
                        {
                            try
                            {
                                while (!oWeb.IsRootWeb) //Inherit | Open
                                {
                                    if (oWeb.IsRootWeb)
                                        break;
                                    oWeb = oWeb.ParentWeb;
                                }

                                SPList list = oWeb.Lists[listid];
                                GridGanttSettings gSettings = ListCommands.GetGridGanttSettings(list);
                                bUseTeam = gSettings.BuildTeam;
                            }
                            catch { }
                        }
                    }
                }
                catch { }

                oWeb.AllowUnsafeUpdates = true;

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
                    var projectResourceRatesFeatureIsEnabled = IsProjectCenter(oWeb, listid) && IsPfeSite(oWeb);
                    var projectId = projectResourceRatesFeatureIsEnabled ? GetProjectId(oWeb, listid, itemid) : 0;

                    SPFieldUserValueCollection uvc = null;
                    try
                    {
                        uvc = new SPFieldUserValueCollection(oWeb, Convert.ToString(li["AssignedTo"]));
                    }
                    catch { }
                    if (uvc == null)
                        uvc = new SPFieldUserValueCollection();

                    DataTable dtResourcePool = null;
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        dtResourcePool = GetResourcePoolForSave(sdoc, oWeb, docTeam.SelectNodes("//Team/Member"));
                    });

                    ArrayList arrUsers = new ArrayList();

                    foreach (SPFieldUserValue uv in uvc)
                    {
                        arrUsers.Add(uv.LookupId);
                    }

                    var savedRatesUserIds = new List<int>();
                    foreach (XmlNode nd in docTeam.SelectNodes("//Team/Member"))
                    {
                        DataRow[] drRes = dtResourcePool.Select("ID='" + nd.Attributes["ID"].Value + "'");
                        if (drRes.Length > 0)
                        {
                            SPFieldUserValue uv = new SPFieldUserValue(oWeb, drRes[0]["SPAccountInfo"].ToString());

                            if (!arrUsers.Contains(int.Parse(drRes[0]["SPID"].ToString())))
                            {
                                uvc.Add(uv);
                            }

                            if (uv.User != null)
                            {
                                modifiedUsers += "," + uv.User.ID;
                            }

                            setItemPermissions(oWeb, uv.ToString(), nd.Attributes["Permissions"].Value, li);

                            if (projectResourceRatesFeatureIsEnabled)
                            {
                                var resourceId = GetResourceId(oWeb, drRes[0]);
                                if (resourceId > 0 && projectId > 0)
                                {
                                    // update rate for existing resources if rate is not equal to the standard rate, otherwise remove rate
                                    var rateString = nd.Attributes[ProjectRateColumn].Value;
                                    var standardRateString = drRes[0].Table.Columns.Contains(StandardRateColumn) 
                                        ? drRes[0][StandardRateColumn]?.ToString()
                                        : null;

                                    var rateValue = !string.IsNullOrWhiteSpace(rateString) ? Convert.ToDecimal(rateString) : (decimal?)null;
                                    var standardRateValue =  !string.IsNullOrWhiteSpace(standardRateString) ? Convert.ToDecimal(standardRateString) : 0;
                                    UpdateProjectResourceRate(oWeb, projectId, resourceId, rateValue != standardRateValue ? rateValue : null);

                                    // keep resource id for cleanup action
                                    savedRatesUserIds.Add(resourceId);
                                }
                            }

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
                                {
                                    modifiedUsers += "," + uv.User.ID;
                                }
                            }
                        }
                    }

                    foreach (SPFieldUserValue uv in arrDelete)
                    {
                        uvc.Remove(uv);
                    }

                    if (projectResourceRatesFeatureIsEnabled && projectId > 0)
                    {
                        // remove rates for all resources except whose we saved recently (cleanup for removed team members)
                        DeleteProjectResourceRates(oWeb, projectId, savedRatesUserIds.ToArray());
                    }

                    try
                    {
                        li["AssignedTo"] = uvc;
                        li.SystemUpdate();
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        string error = $"You do not have write access to project: {li["Title"]}";
                        throw new Exception(error, ex);
                    }


                }
                else
                {
                    SPList list = oWeb.Lists["Team"];
                    DataTable dt = list.Items.GetDataTable();

                    DataTable dtResourcePool = null;
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
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

                        teamMemberCount++;
                    }

                    SPSecurity.RunWithElevatedPrivileges(() =>
                    {
                        using (SPSite eSite = new SPSite(oWeb.Site.ID))
                        {
                            using (SqlConnection con = new SqlConnection(CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
                            {
                                con.Open();
                                var cmd = new SqlCommand(@"Update [dbo].[RPTWeb] Set [Members] = " + teamMemberCount + " WHERE [SiteId] = '" + oWeb.Site.ID + "' AND [WebId] = '" + oWeb.ID + "'");
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    });

                    if (dt != null)
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate ()
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

        /// <summary>
        /// Updates project resource rate (if necessary) or deletes existing rate value if provided rate is null.
        /// </summary>
        private static void UpdateProjectResourceRate(SPWeb web, int projectId, int resourceId, decimal? rate)
        {
            var repository = new ProjectResourceRateRepository();
            var currentRate = repository.GetRate(web, DateTime.Today, projectId, resourceId);

            if (rate.HasValue)
            {
                // update if rate changed
                if (currentRate == null || currentRate.Rate != rate.Value)
                {
                    repository.SaveRate(web, projectId, resourceId, rate.Value);
                }
            }
            else
            {
                // delete if rate exists
                if (currentRate != null)
                {
                    repository.DeleteRates(web, projectId, resourceId);
                }
            }
        }

        /// <summary>
        /// Deletes all project resource rates except ones provided in exceptResourceIds array.
        /// </summary>
        private static void DeleteProjectResourceRates(SPWeb web, int projectId, int[] exceptResourceIds)
        {
            var repository = new ProjectResourceRateRepository();
            repository.DeleteAllRates(web, projectId, exceptResourceIds);
        }

        private static int GetResourceId(SPWeb oWeb, DataRow row)
        {
            var isGeneric = row.Table.Columns.Contains(GenericColumn) &&
                            row[GenericColumn]?.ToString() == GenericColumnYes;

            var resourceUsername = !isGeneric && row.Table.Columns.Contains(UsernameColumn)
                ? row[UsernameColumn]?.ToString()
                : null;
            var resourceName = row.Table.Columns.Contains(TitleColumn)
                ? row[TitleColumn]?.ToString()
                : null;

            var resourceId = GetResourceId(oWeb, resourceUsername, resourceName);
            return resourceId;
        }

        /// <summary>
        /// Gets the PFE resource id based on username or full name (for generic accounts only).
        /// </summary>
        private static int GetResourceId(SPWeb web, string username, string name)
        {
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(name))
            {
                return 0;
            }

            var usersRepository = new ResourceRepository();
            var accountName = !string.IsNullOrWhiteSpace(username) 
                ? CoreFunctions.GetCleanUserNameWithDomain(web, username) 
                : null;
            return usersRepository.FindResourceId(web, accountName, name);
        }

        /// <summary>
        /// Get the PFE unique project id based on list item id.
        /// </summary>
        private static int GetProjectId(SPWeb web, Guid listId, int id)
        {
            if (id == 0 || listId == Guid.Empty)
            {
                return 0;
            }

            var repository = new ProjectRepository();
            return repository.FindProjectId(web, listId, id);
        }

        private static void setItemPermissions(SPWeb web, string user, string perms, SPListItem li)
        {
            try
            {
                GridGanttSettings gSettings = ListCommands.GetGridGanttSettings(li.ParentList);
                SPFieldUserValue uv = new SPFieldUserValue(web, user);
                ArrayList arr = new ArrayList(perms.Split(';'));
                List<string> additionalPermissions = new List<string>();
                List<string> lookupsSecurityGroups = new List<string>();

                if (li != null && li.HasUniqueRoleAssignments)
                {
                    EnhancedLookupConfigValuesHelper valueHelper = null;
                    string lookupSettings = gSettings.Lookups;
                    //string rawValue = "Region^dropdown^none^none^xxx|State^autocomplete^Region^Region^xxx|City^autocomplete^State^State^xxx";                    
                    valueHelper = new EnhancedLookupConfigValuesHelper(lookupSettings);

                    if (valueHelper != null)
                    {
                        List<string> fields = valueHelper.GetSecuredFields();

                        // has security fields
                        if (fields != null && fields.Count > 0)
                        {
                            foreach (string fld in fields)
                            {
                                SPFieldLookup lookup = null;
                                try
                                {
                                    lookup = li.ParentList.Fields.GetFieldByInternalName(fld) as SPFieldLookup;
                                }
                                catch { }

                                if (lookup == null) continue;

                                SPList lookupParentList = web.Lists[new Guid(lookup.LookupList)];
                                GridGanttSettings parentListSettings = new GridGanttSettings(lookupParentList);

                                // skip fields with empty lookup values
                                string securityFieldValue = string.Empty;

                                try { securityFieldValue = li[fld].ToString(); }
                                catch { }

                                if (string.IsNullOrEmpty(securityFieldValue)) continue;

                                SPFieldLookupValue lookupVal = new SPFieldLookupValue(securityFieldValue.ToString());
                                SPListItem parentListItem = lookupParentList.GetItemById(lookupVal.LookupId);

                                if (!parentListItem.HasUniqueRoleAssignments) continue;

                                SPRoleAssignmentCollection raCol = parentListItem.RoleAssignments;

                                foreach (SPRoleAssignment ra in raCol)
                                    lookupsSecurityGroups.Add(ra.Member.Name);
                            }
                        }
                    }
                }

                string[] permissionsString = gSettings.BuildTeamPermissions.Split('|');
                for (int i = 0; i < permissionsString.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        string[] strIds = permissionsString[i].Split('~');
                        for (int j = 0; j < strIds.Length; j++)
                        {
                            if (j % 2 == 0)
                            {
                                additionalPermissions.Add(strIds[j]);
                            }
                        }
                    }
                }

                //check if this is for user or it's a generic (EPMLCID-11683)
                if (uv.User != null)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        using (SPSite spSite = new SPSite(web.Site.ID))
                        {
                            using (SPWeb spWeb = spSite.OpenWeb(web.ID))
                            {
                                spWeb.AllowUnsafeUpdates = true;
                                SPUser spUser = spWeb.EnsureUser(uv.User.LoginName);
                                if (spUser != null)
                                {
                                    // Re-opening the item with the system account
                                    SPListItem adminItem = spWeb.Lists[li.ParentList.ID].GetItemByUniqueId(li.UniqueId);
                                    foreach (SPRoleAssignment role in adminItem.RoleAssignments)
                                    {
                                        try
                                        {
                                            if (role.Member.GetType() == typeof(SPGroup))
                                            {
                                                SPGroup group = spWeb.Groups.GetByID(role.Member.ID);
                                                SPUser tempuser = null;

                                                if (group != null)
                                                {
                                                    if (lookupsSecurityGroups != null && lookupsSecurityGroups.Contains(group.Name))
                                                    {
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            tempuser = group.Users.GetByID(spUser.ID);
                                                        }
                                                        catch { }
                                                        if (tempuser == null && arr.Contains(group.ID.ToString()))
                                                        {
                                                            group.AddUser(spUser);
                                                        }
                                                        if (tempuser != null && !arr.Contains(group.ID.ToString()) && li.HasUniqueRoleAssignments)
                                                        {
                                                            if (additionalPermissions.Contains(Convert.ToString(group.ID)))
                                                                continue;
                                                            else
                                                                group.RemoveUser(spUser);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                    });
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
            catch (Exception ex) { throw ex; }

        }

        private static void setPermissions(SPWeb web, string user, string perms)
        {
            bool isCurrentlyInGroup = false;
            bool isAdded = false;

            try
            {
                SPFieldUserValue uv = new SPFieldUserValue(web, user);
                ArrayList arr = new ArrayList(perms.Split(';'));

                foreach (SPGroup group in from SPGroup spGroup in web.Groups
                                          let roles = spGroup.Roles
                                          let canUse = roles.Cast<SPRole>().Any(role => role.PermissionMask != (SPRights)134287360)
                                          where spGroup.CanCurrentUserEditMembership && canUse
                                          select spGroup)
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
            catch (Exception ex) { throw ex; }
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
                SPList list = null;
                bool bUseTeam = false;

                if (queryDoc != "")
                {
                    try
                    {
                        XmlDocument docQuery = new XmlDocument();
                        docQuery.LoadXml(queryDoc);

                        try
                        {
                            if (docQuery.FirstChild.Attributes["CurrentTeam"] != null)
                                currentteam = docQuery.FirstChild.Attributes["CurrentTeam"].Value;
                        }
                        catch { }
                        try
                        {
                            if (docQuery.FirstChild.Attributes["WebId"] != null)
                                webid = new Guid(docQuery.FirstChild.Attributes["WebId"].Value);
                        }
                        catch { }
                        try
                        {
                            if (docQuery.FirstChild.Attributes["ListId"] != null)
                                listid = new Guid(docQuery.FirstChild.Attributes["ListId"].Value);
                        }
                        catch { }
                        try
                        {
                            if (docQuery.FirstChild.Attributes["ItemId"] != null)
                                itemid = int.Parse(docQuery.FirstChild.Attributes["ItemId"].Value);
                        }
                        catch { }

                        try
                        {
                            if (docQuery.FirstChild.Attributes["Column"] != null && docQuery.FirstChild.Attributes["Value"] != null)
                            {
                                filterfield = docQuery.FirstChild.Attributes["Column"].Value;
                                filterval = docQuery.FirstChild.Attributes["Value"].Value;
                            }
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

                XmlDocument doc = new XmlDocument();



                if (webid != Guid.Empty)
                {
                    SPWeb web = oWeb.Site.OpenWeb(webid);
                    try
                    {
                        if (listid != Guid.Empty)
                        {
                            try
                            {
                                list = web.Lists[listid];
                                GridGanttSettings gSettings = ListCommands.GetGridGanttSettings(list);
                                bUseTeam = gSettings.BuildTeam;
                            }
                            catch (Exception ex)
                            {
                                //EPML-5575:need to re-initialize these variables in case of Item level workspace created using Project/Collaborative workspace template
                                listid = Guid.Empty;
                                itemid = 0;
                                LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString());
                            }
                        }

                        try
                        {
                            if (listid == Guid.Empty && itemid == 0)
                            {
                                APITeam.VerifyProjectTeamWorkspace(web, out itemid, out listid);
                                if (itemid > 0 && listid != Guid.Empty)
                                {
                                    try
                                    {
                                        while (!web.IsRootWeb) //Inherit | Open
                                        {
                                            if (web.IsRootWeb)
                                                break;
                                            web = web.ParentWeb;
                                        }

                                        list = web.Lists[listid];
                                        GridGanttSettings gSettings = ListCommands.GetGridGanttSettings(list);
                                        bUseTeam = gSettings.BuildTeam;
                                    }
                                    catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                                }
                            }
                        }
                        catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }

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
                    catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                    finally { if (web != null) web.Dispose(); }
                }
                else
                {
                    if (listid != Guid.Empty)
                    {
                        list = oWeb.Lists[listid];
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
                LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString());
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

                SPSecurity.RunWithElevatedPrivileges(delegate ()
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
                            dtResources = getResources(rweb, filterfield, filterval, true, arrColumns, null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("access is denied"))
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate ()
                        {
                            using (SPSite rsite = new SPSite(resUrl))
                            {
                                using (SPWeb rweb = rsite.OpenWeb())
                                {
                                    dtResources = getResources(rweb, filterfield, filterval, false, arrColumns, null, null);
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
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite tSite = new SPSite(web.Site.ID))
                    {
                        using (SPWeb tWeb = tSite.OpenWeb(web.ID))
                        {
                            SPList list = tWeb.Lists[ListId];
                            li = list.GetItemById(ItemId);

                            string resUrl = CoreFunctions.getConfigSetting(tWeb, "EPMLiveResourceURL", true, false);

                            GridGanttSettings gSettings = ListCommands.GetGridGanttSettings(li.ParentList);
                            List<string> additionalPermissions = new List<string>();
                            string[] permissionsString = gSettings.BuildTeamPermissions.Split('|');

                            for (int i = 0; i < permissionsString.Length; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    string[] strIds = permissionsString[i].Split('~');
                                    for (int j = 0; j < strIds.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            additionalPermissions.Add(strIds[j]);
                                        }
                                    }
                                }
                            }

                            DataTable dtResources = null;

                            try
                            {
                                using (SPSite rsite = new SPSite(resUrl))
                                {
                                    using (SPWeb rweb = rsite.OpenWeb())
                                    {
                                        dtResources = getResources(rweb, filterfield, filterval, true, arrColumns, li, null);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.ToLower().Contains("access is denied"))
                                {
                                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                                    {
                                        using (SPWeb rweb = tSite.OpenWeb())
                                        {
                                            dtResources = getResources(rweb, filterfield, filterval, false, arrColumns, li, null);
                                        }
                                    });
                                }

                                throw ex;
                            }

                            try
                            {

                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(tWeb, Convert.ToString(li["AssignedTo"]));

                                int index = 0;
                                SortedList slUsers = new SortedList();

                                foreach (SPFieldUserValue uv in uvc)
                                {
                                    DataRow[] drs = dtResources.Select("SPID='" + uv.LookupId + "'");
                                    if (drs.Length > 0)
                                    {
                                        XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "Member", doc.NamespaceURI);

                                        foreach (DataColumn dc in dtResources.Columns)
                                            addAttribute(ref ndNew, doc, drs[0], dc.ColumnName);

                                        string perms = "";
                                        try
                                        {
                                            perms = Convert.ToString(drs[0]["Groups"]);

                                            if (additionalPermissions.Contains(perms))
                                                perms = "";

                                        }
                                        catch { }

                                        XmlAttribute attr = doc.CreateAttribute("Permissions");
                                        attr.Value = perms.Trim(';');
                                        ndNew.Attributes.Append(attr);

                                        slUsers.Add(drs[0]["Title"].ToString() + index++, ndNew);
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

            SPSecurity.RunWithElevatedPrivileges(delegate ()
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

                        dtResources = getResources(rweb, filterfield, filterval, true, arrColumns, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("access is denied"))
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        using (SPSite rsite = new SPSite(resUrl))
                        {
                            using (SPWeb rweb = rsite.OpenWeb())
                            {
                                if (resUrl.ToLower() == web.ServerRelativeUrl.ToLower())
                                    isResSite = true;

                                dtResources = getResources(rweb, filterfield, filterval, false, arrColumns, null, null);
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

                                        AddHtmlColumn(docOut, ndCols, ndHeader, false, AllowEditProjectRateColumn, string.Empty, null, 10, null);
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

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite tSite = new SPSite(oWeb.Site.ID))
                {
                    SPWeb tWeb = tSite.OpenWeb(oWeb.ID);
                    try
                    {
                        Guid listid = Guid.Empty;
                        int itemid = 0;
                        GridGanttSettings gSettings = null;
                        SPList oList = null;
                        SPListItem oLi = null;
                        var projectResourceRatesEnabled = false;

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
                            catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                            try
                            {
                                itemid = int.Parse(InputDoc.FirstChild.Attributes["ItemId"].Value);
                                oLi = oList.GetItemById(itemid);
                            }
                            catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                        }

                        try
                        {
                            if (oList == null && oLi == null)
                            {
                                APITeam.VerifyProjectTeamWorkspace(tWeb, out itemid, out listid);
                                if (itemid > 0 && listid != Guid.Empty)
                                {
                                    try
                                    {
                                        while (!tWeb.IsRootWeb) //Inherit | Open
                                        {
                                            if (tWeb.IsRootWeb)
                                                break;
                                            tWeb = tWeb.ParentWeb;
                                        }

                                        oList = tWeb.Lists[listid];
                                        gSettings = new GridGanttSettings(oList);
                                        oLi = oList.GetItemById(itemid);
                                    }
                                    catch { }
                                }
                            }
                        }
                        catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }


                        projectResourceRatesEnabled = IsProjectCenter(tWeb, listid) && IsPfeSite(tWeb);

                        XmlNode ndRightCols = doc.SelectSingleNode("//Cols");
                        XmlNode ndLeftCols = doc.SelectSingleNode("//LeftCols");
                        XmlNode ndHeader = doc.SelectSingleNode("//Header");

                        AddHtmlColumn(doc, ndRightCols, ndHeader, projectResourceRatesEnabled, ProjectRateColumn, ProjectRateColumnCaption, null, 100, "Right");
                        AddHtmlColumn(doc, ndRightCols, ndHeader, projectResourceRatesEnabled, ProjectRateEditColumn, string.Empty, null, 30, "Left");

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

                        //attr = doc.CreateAttribute("RelWidth");
                        //attr.Value = "1";
                        //ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("Width");
                        attr.Value = "250";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("Visible");
                        if (listid == null || listid == Guid.Empty)
                        {
                            if (tWeb.HasUniqueRoleAssignments)
                                attr.Value = "1"; //Permissions column visible in case of Private workspace (Unique Permissions)
                            else
                                attr.Value = "0"; //Permissions column Hide in case of Open workspace (Inherit Permissions)
                        }
                        else
                        {
                            //Item level permissions
                            if (oLi != null && oLi.HasUniqueRoleAssignments)
                                attr.Value = "1";
                            else
                                attr.Value = "0";
                        }
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

                        //nd = doc.SelectSingleNode("//C[@Name='Role']");
                        //if (nd != null)
                        //{
                        //    nd.Attributes["Visible"].Value = "1";
                        //}

                        //nd = doc.SelectSingleNode("//C[@Name='Email']");
                        //if (nd != null)
                        //{
                        //    nd.Attributes["Visible"].Value = "1";
                        //}

                        string enums = "";
                        string enumkeys = "";
                        List<string> idArrays = new List<string>();
                        List<string> lookupsSecurityGroups = new List<string>();
                        bool CurrentUserHasPermissionToChangeOwner = true;
                        //Get second level permissions: find lookups that has security enabled
                        if (oLi != null && oLi.HasUniqueRoleAssignments)
                        {
                            EnhancedLookupConfigValuesHelper valueHelper = null;
                            string lookupSettings = gSettings.Lookups;
                            //string rawValue = "Region^dropdown^none^none^xxx|State^autocomplete^Region^Region^xxx|City^autocomplete^State^State^xxx";                    
                            valueHelper = new EnhancedLookupConfigValuesHelper(lookupSettings);

                            if (valueHelper != null)
                            {
                                List<string> fields = valueHelper.GetSecuredFields();

                                // has security fields
                                if (fields != null && fields.Count > 0)
                                {
                                    foreach (string fld in fields)
                                    {
                                        SPFieldLookup lookup = null;
                                        try
                                        {
                                            lookup = oList.Fields.GetFieldByInternalName(fld) as SPFieldLookup;
                                        }
                                        catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }

                                        if (lookup == null) continue;

                                        SPList lookupParentList = tWeb.Lists[new Guid(lookup.LookupList)];
                                        GridGanttSettings parentListSettings = new GridGanttSettings(lookupParentList);

                                        // skip fields with empty lookup values
                                        string securityFieldValue = string.Empty;

                                        try { securityFieldValue = oLi[fld].ToString(); }
                                        catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }

                                        if (string.IsNullOrEmpty(securityFieldValue)) continue;

                                        SPFieldLookupValue lookupVal = new SPFieldLookupValue(securityFieldValue.ToString());
                                        SPListItem parentListItem = lookupParentList.GetItemById(lookupVal.LookupId);

                                        if (!parentListItem.HasUniqueRoleAssignments) continue;

                                        SPRoleAssignmentCollection raCol = parentListItem.RoleAssignments;

                                        foreach (SPRoleAssignment ra in raCol)
                                            lookupsSecurityGroups.Add(ra.Member.Name);
                                    }
                                }
                            }
                        }

                        if (gSettings != null && gSettings.BuildTeam && oLi != null && oLi.HasUniqueRoleAssignments)
                        {
                            string[] permissionsString = gSettings.BuildTeamPermissions.Split('|');
                            for (int i = 0; i < permissionsString.Length; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    string[] strIds = permissionsString[i].Split('~');
                                    for (int j = 0; j < strIds.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            idArrays.Add(strIds[j]);
                                        }
                                    }
                                }
                            }

                            foreach (SPRoleAssignment assn in oLi.RoleAssignments)
                            {
                                if (assn.Member.GetType() == typeof(Microsoft.SharePoint.SPGroup))
                                {
                                    SPGroup group = (SPGroup)assn.Member;
                                    
                                    if (group.CanCurrentUserEditMembership)
                                    {
                                        if (!idArrays.Contains(Convert.ToString(group.ID)))
                                        {
                                            if (lookupsSecurityGroups != null && lookupsSecurityGroups.Contains(group.Name))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                enums += "|" + group.Name;
                                                enumkeys += "|" + group.ID;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else //Manage Web Team Security
                        {
                            if (listid == null || listid == Guid.Empty)
                            {
                                foreach (SPGroup group in from SPGroup spGroup in tWeb.Groups
                                                          let roles = spGroup.Roles
                                                          let canUse = roles.Cast<SPRole>().Any(role => role.PermissionMask != (SPRights)134287360)
                                                          where spGroup.CanCurrentUserEditMembership && canUse
                                                          select spGroup)
                                {
                                    if (group.CanCurrentUserEditMembership)
                                    {
                                        enums += "|" + group.Name;
                                        enumkeys += "|" + group.ID;
                                    }
                                }
                            }
                        }

                        attr = doc.CreateAttribute("Enum");
                        attr.Value = enums;
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("EnumKeys");
                        attr.Value = enumkeys;
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("CurrentUserHasPermissionToChangeOwner");
                        attr.Value = Convert.ToString(CurrentUserHasPermissionToChangeOwner);
                        ndNew.Attributes.Append(attr);

                        ndRightCols.AppendChild(ndNew);
                        ndLeftCols.AppendChild(ndRightCols);
                    }
                    catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                    finally { if (tWeb != null) tWeb.Dispose(); }
                }
            });

            return doc.OuterXml;
        }

        private static void AddHtmlColumn(XmlDocument xml, XmlNode allColumnsNode, XmlNode headerNode, bool visible, string name, string displayName,
            int? relativeWidth, int? width, string align)
        {
            var columnNode = xml.CreateNode(XmlNodeType.Element, "C", xml.NamespaceURI);
            if (columnNode.Attributes != null)
            {
                // add name
                var attribute = xml.CreateAttribute("Name");
                attribute.Value = name;
                columnNode.Attributes.Append(attribute);

                // add type
                attribute = xml.CreateAttribute("Type");
                attribute.Value = "Html";
                columnNode.Attributes.Append(attribute);

                // add relative width (if specified)
                if (relativeWidth.HasValue)
                {
                    attribute = xml.CreateAttribute("RelWidth");
                    attribute.Value = relativeWidth.Value.ToString();
                    columnNode.Attributes.Append(attribute);
                }

                // add width (if specified)
                if (width.HasValue)
                {
                    attribute = xml.CreateAttribute("Width");
                    attribute.Value = width.Value.ToString();
                    columnNode.Attributes.Append(attribute);
                }

                // add cell format (if specified)
                if (align != null)
                {
                    attribute = xml.CreateAttribute("Align");
                    attribute.Value = align;
                    columnNode.Attributes.Append(attribute);
                }

                // add visible status
                attribute = xml.CreateAttribute("Visible");
                attribute.Value = visible ? "1" : "0";
                columnNode.Attributes.Append(attribute);

                // add header info (if display name specified)
                if (displayName != null && headerNode.Attributes != null)
                {
                    attribute = xml.CreateAttribute(name);
                    attribute.Value = displayName;
                    headerNode.Attributes.Append(attribute);
                }
            }

            allColumnsNode.AppendChild(columnNode);
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

            DataTable dtTemp = GetResourcePool("", oWeb);

            try
            {
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (dr["Disabled"] != null && dr["Disabled"].ToString() == "Yes")
                        continue;

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
                        
                        var allowEditRate = IsPfeSite(oWeb) && GetResourceId(oWeb, dr) > 0;

                        // this value used in UI to determine whether new team members can edit rates (i.e. we can get valid resource id)
                        nattr = docOut.CreateAttribute(AllowEditProjectRateColumn);
                        nattr.Value = allowEditRate ? "1" : "0";
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

            var queryDocument = new XmlDocument();
            queryDocument.LoadXml(xml);

            // get the list and list item id from the query XML
            var listItemId = 0;
            var listId = Guid.Empty;
            if (queryDocument.FirstChild != null && queryDocument.FirstChild.Attributes != null)
            {
                listItemId = queryDocument.FirstChild.Attributes["ItemId"] != null
                    ? Convert.ToInt32(queryDocument.FirstChild.Attributes["ItemId"].Value)
                    : 0;

                listId = queryDocument.FirstChild.Attributes["ListId"] != null
                    ? new Guid(queryDocument.FirstChild.Attributes["ListId"].Value)
                    : Guid.Empty;
            }

            var projectResourceRateFeatureIsEnabled = IsProjectCenter(oWeb, listId) && IsPfeSite(oWeb);
            var projectId = projectResourceRateFeatureIsEnabled ? GetProjectId(oWeb, listId, listItemId) : 0;

            XmlDocument docTeam = new XmlDocument();
            docTeam.LoadXml(GetTeam(xml, oWeb));
            var ratesRepository  = new ProjectResourceRateRepository();
            foreach (XmlNode nd in docTeam.FirstChild.ChildNodes)
            {
                XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);

                XmlAttribute nattr = docOut.CreateAttribute("NoColorState");
                nattr.Value = "1";
                ndNew.Attributes.Append(nattr);
                var id = nd.Attributes["ID"].Value;
                var standardRate = nd.Attributes[StandardRateColumn] != null ? nd.Attributes[StandardRateColumn].Value : String.Empty;
                var isGeneric = nd.Attributes[GenericColumn] != null && nd.Attributes[GenericColumn].Value == GenericColumnYes;
                var resourceUsername = nd.Attributes[UsernameColumn] != null && !isGeneric
                    ? nd.Attributes[UsernameColumn].Value
                    : string.Empty;
                var resourceName = nd.Attributes[TitleColumn] != null ? nd.Attributes[TitleColumn].Value : string.Empty;

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

                // before get project resource rates, validate all inputs: should be project center list item with valid user id
                var allowEditRate = false;
                if (projectResourceRateFeatureIsEnabled 
                    && projectId > 0)
                {
                    var resourceId = GetResourceId(oWeb, resourceUsername, resourceName);
                    if (resourceId > 0)
                    {
                        // get the rate value
                        var rate = ratesRepository.GetRate(oWeb, DateTime.Today, projectId, resourceId);
                        var rateValue = rate != null ? string.Format("{0:0.##}", rate.Rate) : standardRate;

                        // add project rate value
                        nattr = docOut.CreateAttribute(ProjectRateColumn);
                        nattr.Value = string.Format("{0:0.##}", rateValue);
                        ndNew.Attributes.Append(nattr);

                        // add project rate edit hyperlink
                        nattr = docOut.CreateAttribute(ProjectRateEditColumn);
                        nattr.Value = string.Format(
                            "<img class=\"projectRateEditButton\" src=\"images/editrate16.gif\" onclick=\"ShowRateDialog('{0}');return false;\"></input>",
                            id);
                        ndNew.Attributes.Append(nattr);

                        allowEditRate = true;
                    }
                }

                // this value used in UI to determine whether new team members can edit rates (i.e. we can get valid resource id)
                nattr = docOut.CreateAttribute(AllowEditProjectRateColumn);
                nattr.Value = allowEditRate ? "1" : "0";
                ndNew.Attributes.Append(nattr);

                ndBody.AppendChild(ndNew);
            }

            return docOut.OuterXml;
        }
        
        public static string GetResourcePoolXml(string xml, SPWeb oWeb)
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();
            DataTable dt = GetResourcePool(xml, oWeb);
            dt.TableName = "Resources";
            dt.WriteXml(writer, XmlWriteMode.WriteSchema, false);
            return writer.ToString();
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
                if (!string.IsNullOrEmpty(xml))
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
                        filterval = CoreFunctions.GetSafeUserTitle(Convert.ToString(doc.FirstChild.Attributes["FilterFieldValue"].Value));
                    }
                    catch { }
                }
            }
            catch { }

            SPSecurity.RunWithElevatedPrivileges(delegate ()
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
                        dt = getResources(rweb, filterfield, filterval, true, arrColumns, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("access is denied"))
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        using (SPSite rsite = new SPSite(resUrl))
                        {
                            using (SPWeb rweb = rsite.OpenWeb())
                            {
                                dt = getResources(rweb, filterfield, filterval, false, arrColumns, null, null);
                            }
                        }
                    });
                }

                throw ex;
            }

            return dt;
        }

        public static DataTable GetResourcePoolForSave(string xml, SPWeb oWeb, XmlNodeList nodeTeam)
        {
            string resUrl = "";

            ArrayList arrColumns = null;
            string filterval = "";
            string filterfield = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                if (!string.IsNullOrEmpty(xml))
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
            }
            catch { }

            SPSecurity.RunWithElevatedPrivileges(delegate ()
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
                        dt = getResources(rweb, filterfield, filterval, true, arrColumns, null, nodeTeam);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("access is denied"))
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        using (SPSite rsite = new SPSite(resUrl))
                        {
                            using (SPWeb rweb = rsite.OpenWeb())
                            {
                                dt = getResources(rweb, filterfield, filterval, false, arrColumns, null, nodeTeam);
                            }
                        }
                    });
                }

                throw ex;
            }

            return dt;
        }

        public static List<SPGroup> GetWebGroups(SPWeb spWeb)
        {
            var spGroups = new List<SPGroup>();

            try
            {
                var queryExecutor = new QueryExecutor(spWeb);

                var dataTable = queryExecutor.ExecuteReportingDBQuery(WEB_GROUPS_QUERY, new Dictionary<string, object>
                {
                    {"@WebId", spWeb.ID}
                });

                spGroups.AddRange(from DataRow row in dataTable.Rows select spWeb.Groups.GetByID((int)row["Id"]));
            }
            catch
            {
                spGroups.AddRange(from SPGroup spGroup in spWeb.Groups
                                  let roles = spGroup.Roles
                                  let canUse = roles.Cast<SPRole>().Any(role => role.PermissionMask != (SPRights)134287360)
                                  where spGroup.CanCurrentUserEditMembership && canUse
                                  select spGroup);
            }

            return spGroups;
        }

        public static void VerifyProjectTeamWorkspace(SPWeb web, out int itemId, out Guid listId)
        {
            itemId = 0;
            listId = Guid.Empty;

            try
            {
                ReportHelper.EPMData data = new ReportHelper.EPMData(web.Site.ID);

                SqlConnection cn = data.GetClientReportingConnection;
                SqlCommand cmd = new SqlCommand("SELECT ItemId, ItemListId, WebId FROM RPTWeb WHERE WebId = '" + web.ID.ToString() + "'", cn);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    itemId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    listId = new Guid(Convert.ToString(ds.Tables[0].Rows[0][1]));
                }
            }
            catch { }
        }

        private static bool IsProjectCenter(SPWeb web, Guid listId)
        {
            try
            {
                if (listId == Guid.Empty)
                {
                    return false;
                }

                return web.Lists[ProjectCenterListName].ID == listId;
            }
            catch (ArgumentException)
            {
                // in case when list does not exist return false
                return false;
            }
        }

        private static bool IsPfeSite(SPWeb web)
        {
            return ConnectionProvider.AllowDatabaseConnections(web);
        }

        private const string WEB_GROUPS_QUERY =
            @"SELECT    dbo.RPTWEBGROUPS.GROUPID AS Id
              FROM      dbo.RPTWEBGROUPS INNER JOIN dbo.LSTUserInformationList 
                            ON dbo.RPTWEBGROUPS.WEBID = dbo.LSTUserInformationList.WebId 
                            AND dbo.RPTWEBGROUPS.GROUPID = dbo.LSTUserInformationList.ID
              WHERE     (dbo.RPTWEBGROUPS.WEBID = @WebId) AND (dbo.RPTWEBGROUPS.SECTYPE = 1) AND (dbo.RPTWEBGROUPS.GROUPID <> 999999)
              ORDER BY  dbo.LSTUserInformationList.Title";
    }
}

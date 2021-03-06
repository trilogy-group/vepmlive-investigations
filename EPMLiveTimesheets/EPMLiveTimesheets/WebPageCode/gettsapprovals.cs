using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TimeSheets
{
    public partial class gettsapprovals : EPMLiveWebParts.getgriditems
    {
        SPSite site = SPContext.Current.Site;
        int period;
        string username = SPContext.Current.Web.CurrentUser.LoginName;
        DataSet dsTSHours = new DataSet();
        static string bgcolor = "EFEFEF";
        SqlConnection cn = null;

        private DataSet dsTimesheets;
        private DataSet dsTimesheetTotals;
        private DataSet dsTimesheetTasks;
        private DataSet dsTimesheetTaskHours;
        private DataSet dsTimesheetTypes;
        private DataSet dsTimesheetNotes;
        private DataSet dsTimesheetMeta;

        SPWeb resWeb = null;

        bool usecurrent = true;

        public override void Dispose()
        {
            if (resWeb != null)
                if (resWeb.ID != SPContext.Current.Web.ID)
                    resWeb.Close();
            
            base.Dispose();
        }

        public override void getParams(SPWeb curWeb)
        {
            base.getParams(curWeb);
            isTimesheet = true;

            string strPeriod = Request["period"];
            period = int.Parse(strPeriod);
            base.inEditMode = false;
            string resUrl = "";


            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(curWeb.Site.WebApplication.Id));
                    cn.Open();
                }
                catch { }
                resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(curWeb, "EPMLiveResourceURL", true, false); 
            });

            try
            {
                if (resUrl != "")
                {
                    if (resUrl.ToLower() != curWeb.Url.ToLower())
                    {
                        using (SPSite tempSite = new SPSite(resUrl))
                        {
                            tempSite.CatchAccessDeniedException = false;
                            resWeb = tempSite.OpenWeb();
                            if (resWeb.Url.ToLower() != resUrl.ToLower())
                            {
                                resWeb = null;
                            }
                        }
                    }
                    else
                        resWeb = curWeb;
                }
            }
            catch { }

            SqlCommand cmd = new SqlCommand("select ts_uid,username,submitted,approval_status,approval_notes,resourcename,jobstatus,jobtype_id from vwTSTimesheetWQueue where period_id=@period_id and site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheets = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheets);

            cmd = new SqlCommand("select hours,ts_item_date,ts_uid from vwTSTimesheetTotals where period_id=@period_id and site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetTotals = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetTotals);

            cmd = new SqlCommand("select title,project,ts_uid,web_uid,list_uid,item_id,ts_item_uid,approval_status,resourcename,username from vwTSTasks where period_id=@period_id and site_uid=@siteid order by project", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetTasks = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetTasks);

            cmd = new SqlCommand("select Hours,ts_item_date,ts_item_uid,ts_item_type_id from vwTSHoursByTask where period_id=@period_id and site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetTaskHours = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetTaskHours);

            cmd = new SqlCommand("select tstype_id from TSTYPE where site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetTypes = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetTypes);

            cmd = new SqlCommand("select ts_item_uid,ts_item_notes,ts_item_date from vwTSNotes where period_id=@period_id and site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetNotes = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetNotes);

            cmd = new SqlCommand("select ts_item_uid,columnname,columnvalue from vwTSItemMeta where period_id=@period_id and site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetMeta = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetMeta);
        }

        public override void populateGroups(string query, SortedList arrGTemp, SPWeb curWeb)
        {
            if (resWeb != null)
            {
                SPQuery spquery = new SPQuery();
                spquery.Query = "<Where><Eq><FieldRef Name='TimesheetManager'/><Value Type='User'><UserID/></Value></Eq></Where>";

                DataTable dtItems = new DataTable();
                dtItems.Columns.Add("WebId");
                dtItems.Columns.Add("ListId");
                dtItems.Columns.Add("ItemId");
                dtItems.Columns.Add("Username");
                dtItems.Columns.Add("Name");

                SPList resList = resWeb.Lists["Resources"];

                foreach (SPListItem li in resList.GetItems(spquery))
                {
                    if (li["SharePointAccount"] != null)
                    {
                        SPFieldUserValue uv = new SPFieldUserValue(curWeb, li["SharePointAccount"].ToString());
                        if (uv.User != null)
                        {
                            DataRow[] drs = dsTimesheetTasks.Tables[0].Select("username = '" + uv.User.LoginName + "'");

                            DataRow[] drts = dsTimesheets.Tables[0].Select("username = '" + uv.User.LoginName + "'");

                            if (!arrGTemp.Contains(li.Title))
                                arrGTemp.Add(li.Title, "");

                            XmlNode newNode = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
                            XmlAttribute attrId = docXml.CreateAttribute("id");
                            attrId.InnerText = li.Title;
                            newNode.Attributes.Append(attrId);

                            string status = "";//<![CDATA[<img src=\"_layouts/epmlive/images/tsflagnone.gif\" alt=\"No Timesheet\">]]>";
                            string notes = "";

                            if (drts.Length > 0)
                            {
                                XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                                newCol.InnerText = drts[0]["ts_uid"].ToString();
                                XmlAttribute attrName = docXml.CreateAttribute("name");
                                attrName.Value = "tsuid";
                                newCol.Attributes.Append(attrName);
                                newNode.AppendChild(newCol);

                                string locked = "0";


                                if(drts[0]["jobstatus"].ToString().ToLower() == "1")
                                {
                                    switch(drts[0]["jobtype_id"].ToString())
                                    {
                                        case "30":
                                            status = "<![CDATA[<img src=\"_layouts/epmlive/images/tsqueueprocessing.gif\" alt=\"Approval Processing\">]]>";
                                            break;
                                        default:
                                            status = "<![CDATA[<img src=\"_layouts/epmlive/images/tsqueueprocessing.gif\" alt=\"Item Processing\">]]>";
                                            break;
                                    }
                                    locked = "1";
                                }
                                else if(drts[0]["jobstatus"].ToString().ToLower() == "0")
                                {
                                    switch(drts[0]["jobtype_id"].ToString())
                                    {
                                        case "30":
                                            status = "<![CDATA[<img src=\"_layouts/epmlive/images/tsqueueprocessing.gif\" alt=\"Approval Queued\">]]>";
                                            break;
                                        default:
                                            status = "<![CDATA[<img src=\"_layouts/epmlive/images/tsqueueprocessing.gif\" alt=\"Item Queued\">]]>";
                                            break;
                                    }
                                    locked = "1";
                                }
                                else if (drts[0]["approval_status"].ToString().ToLower() == "1")
                                {
                                    status = "<![CDATA[<img src=\"_layouts/images/green.gif\" alt=\"Approved\">]]>";
                                }
                                else if (drts[0]["approval_status"].ToString().ToLower() == "2")
                                {
                                    status = "<![CDATA[<img src=\"_layouts/images/red.gif\" alt=\"Rejected\">]]>";
                                }
                                else if (drts[0]["submitted"].ToString().ToLower() == "true")
                                {
                                    status = "<![CDATA[<img src=\"_layouts/images/yellow.gif\" alt=\"Submitted\">]]>";
                                }
                                else
                                {
                                    //status = "<![CDATA[<img src=\"_layouts/epmlive/images/tsflagwhite.gif\" alt=\"Saved\">]]>";
                                    locked = "1";
                                }

                                newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                                newCol.InnerText = locked;
                                attrName = docXml.CreateAttribute("name");
                                attrName.Value = "nosub";
                                newCol.Attributes.Append(attrName);
                                newNode.AppendChild(newCol);

                                notes = drts[0]["approval_notes"].ToString();
                            }
                            else
                            {
                                XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                                newCol.InnerText = "";
                                XmlAttribute attrName = docXml.CreateAttribute("name");
                                attrName.Value = "tsuid";
                                newCol.Attributes.Append(attrName);
                                newNode.AppendChild(newCol);

                                newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                                newCol.InnerText = "1";
                                attrName = docXml.CreateAttribute("name");
                                attrName.Value = "nosub";
                                newCol.Attributes.Append(attrName);
                                newNode.AppendChild(newCol);
                            }

                            XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newCell.InnerText = "";
                            XmlAttribute attrStyle = docXml.CreateAttribute("style");
                            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
                            newCell.Attributes.Append(attrStyle);
                            newNode.AppendChild(newCell);

                            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newCell.InnerText = notes;
                            attrStyle = docXml.CreateAttribute("style");
                            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
                            newCell.Attributes.Append(attrStyle);
                            newNode.AppendChild(newCell);

                            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newCell.InnerXml = status;
                            attrStyle = docXml.CreateAttribute("style");
                            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
                            newCell.Attributes.Append(attrStyle);
                            newNode.AppendChild(newCell);

                            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newCell.InnerText = "";
                            attrStyle = docXml.CreateAttribute("style");
                            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
                            newCell.Attributes.Append(attrStyle);
                            newNode.AppendChild(newCell);

                            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newCell.InnerText = li.Title;
                            attrStyle = docXml.CreateAttribute("style");
                            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
                            newNode.Attributes.Append(attrStyle);
                            newNode.AppendChild(newCell);



                            ndMainParent.AppendChild(newNode);

                            hshItemNodes.Add(li.Title, newNode);

                            foreach (DataRow dr in drs)
                            {
                                dtItems.Rows.Add(new string[] { dr["web_uid"].ToString(), dr["list_uid"].ToString(), dr["item_id"].ToString(), dr["username"].ToString(), li.Title });
                            }
                        }
                    }
                }

                Guid webGuid = new Guid();
                Guid listGuid = new Guid();
                SPWeb iWeb = null;
                SPList iList = null;

                foreach (DataRow dr in dtItems.Select("", "WebId, ListId"))
                {
                    try
                    {
                        Guid wGuid = new Guid(dr[0].ToString());
                        Guid lGuid = new Guid(dr[1].ToString());

                        if (webGuid != wGuid)
                        {
                            if (iWeb != null)
                            {
                                iWeb.Close();
                                iWeb = site.OpenWeb(wGuid);
                            }
                            else
                                iWeb = site.OpenWeb(wGuid);
                            webGuid = iWeb.ID;
                        }
                        if (listGuid != lGuid)
                        {
                            iList = iWeb.Lists[lGuid];
                            listGuid = iList.ID;
                        }
                        SPListItem li = iList.GetItemById(int.Parse(dr[2].ToString()));

                        addTSItem(li, arrGTemp, dr[3].ToString(), dr[4].ToString());
                    }
                    catch { }
                }
            }
        }

        protected override void outputXml()
        {
            ArrayList arr = new ArrayList();
            string worktypes = "";
            bool timeeditor = false;
            bool timenotes = false;
            string filterHead = "";
            XmlNodeList ndCols = docXml.SelectNodes("//head/column");

            int columnCount = ndCols.Count;
            string strColumns = "";

            SPWeb web = site.RootWeb;
            {
                usecurrent = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTSUseCurrent"));
            }

                try
                {

                    //ndCols[0].Attributes["width"].Value = "25";

                    XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    newCol.InnerXml = "<![CDATA[#master_checkbox]]>";
                    XmlAttribute attrType = docXml.CreateAttribute("type");
                    attrType.Value = "ch";
                    XmlAttribute attrWidth = docXml.CreateAttribute("width");
                    attrWidth.Value = "25";
                    XmlAttribute attrAlign = docXml.CreateAttribute("align");
                    attrAlign.Value = "center";
                    XmlAttribute attrColor = docXml.CreateAttribute("color");
                    attrColor.Value = "#F0F0F0";

                    newCol.Attributes.Append(attrType);
                    newCol.Attributes.Append(attrWidth);
                    newCol.Attributes.Append(attrAlign);
                    newCol.Attributes.Append(attrColor);

                    docXml.SelectSingleNode("//head").InsertBefore(newCol, ndCols[0]);

                    newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    newCol.InnerXml = "<![CDATA[Notes]]>";
                    attrType = docXml.CreateAttribute("type");
                    attrType.Value = "tsnotes";
                    attrWidth = docXml.CreateAttribute("width");
                    attrWidth.Value = "50";
                    attrAlign = docXml.CreateAttribute("align");
                    attrAlign.Value = "center";
                    attrColor = docXml.CreateAttribute("color");
                    attrColor.Value = "#F0F0F0";

                    newCol.Attributes.Append(attrType);
                    newCol.Attributes.Append(attrWidth);
                    newCol.Attributes.Append(attrAlign);
                    newCol.Attributes.Append(attrColor);

                    docXml.SelectSingleNode("//head").InsertBefore(newCol, ndCols[0]);


                    newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    newCol.InnerXml = "<![CDATA[TM]]>";
                    attrType = docXml.CreateAttribute("type");
                    attrType.Value = "ro";
                    attrWidth = docXml.CreateAttribute("width");
                    attrWidth.Value = "35";
                    attrAlign = docXml.CreateAttribute("align");
                    attrAlign.Value = "center";
                    attrColor = docXml.CreateAttribute("color");
                    attrColor.Value = "#F0F0F0";

                    newCol.Attributes.Append(attrType);
                    newCol.Attributes.Append(attrWidth);
                    newCol.Attributes.Append(attrAlign);
                    newCol.Attributes.Append(attrColor);

                    docXml.SelectSingleNode("//head").InsertBefore(newCol, ndCols[0]);


                    newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    newCol.InnerXml = "<![CDATA[PM]]>";
                    attrType = docXml.CreateAttribute("type");
                    attrType.Value = "ro";
                    attrWidth = docXml.CreateAttribute("width");
                    attrWidth.Value = "35";
                    attrAlign = docXml.CreateAttribute("align");
                    attrAlign.Value = "center";
                    attrColor = docXml.CreateAttribute("color");
                    attrColor.Value = "#F0F0F0";

                    newCol.Attributes.Append(attrType);
                    newCol.Attributes.Append(attrWidth);
                    newCol.Attributes.Append(attrAlign);
                    newCol.Attributes.Append(attrColor);

                    docXml.SelectSingleNode("//head").InsertBefore(newCol, ndCols[0]);
                    

                    SqlCommand cmd = new SqlCommand("select TSTYPE_ID from TSTYPE where site_uid=@siteid", cn);
                    cmd.Parameters.AddWithValue("@siteid", site.ID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        timeeditor = true;
                        worktypes += "|" + dr.GetInt32(0).ToString();
                    }
                    if (worktypes != "")
                        worktypes = worktypes.Substring(1);
                    else
                        worktypes = "0";
                    dr.Close();

                    if (EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSAllowNotes").ToLower() == "true")
                    {
                        timenotes = true;
                        timeeditor = true;
                    }

                    string[] dayDefs = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveDaySettings").Split('|');

                    cmd = new SqlCommand("select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@siteid", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@period_id", period);
                    cmd.Parameters.AddWithValue("@siteid", site.ID);
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        DateTime dtStart = dr.GetDateTime(0);
                        DateTime dtEnd = dr.GetDateTime(1);
                        TimeSpan ts = dtEnd - dtStart;
                        int colBase = docXml.SelectSingleNode("//head").SelectNodes("column").Count;
                        int colCount = 0;
                        for (int i = 0; i <= ts.Days; i++)
                        {
                            string showday = "";
                            try
                            {
                                showday = dayDefs[((int)dtStart.AddDays(i).DayOfWeek) * 3];
                            }
                            catch { }
                            //if (dtStart.AddDays(i).DayOfWeek != DayOfWeek.Sunday && dtStart.AddDays(i).DayOfWeek != DayOfWeek.Saturday)
                            if (showday == "True")
                            {
                                filterHead += ",&nbsp;";
                                colCount++;
                                arr.Add(dtStart.AddDays(i));
                                newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                                newCol.InnerXml = "<![CDATA[" + dtStart.AddDays(i).DayOfWeek.ToString().Substring(0, 3) + "<br>" + dtStart.AddDays(i).Day + "]]>";
                                attrType = docXml.CreateAttribute("type");
                                //if (timeeditor)
                                //    attrType.Value = "timeeditor";
                                //else
                                    attrType.Value = "ro[=sum]";
                                attrWidth = docXml.CreateAttribute("width");
                                attrWidth.Value = "40";
                                attrAlign = docXml.CreateAttribute("align");
                                attrAlign.Value = "right";
                                XmlAttribute attrId1 = docXml.CreateAttribute("id");
                                attrId1.Value = "_TsDate_" + dtStart.AddDays(i).ToShortDateString().Replace("/", "_");

                                newCol.Attributes.Append(attrType);
                                newCol.Attributes.Append(attrWidth);
                                newCol.Attributes.Append(attrAlign);
                                newCol.Attributes.Append(attrId1);

                                docXml.SelectSingleNode("//head").AppendChild(newCol);
                            }
                        }
                        string cols = "";

                        //for (int i = 0; i < colBase - 1; i++)
                        //{
                        //    footer += ",#cspan";
                        //}
                        //for (int i = colBase; i < colBase + colCount; i++)
                        //{
                        //    cols += "+c" + i.ToString();
                        //    if (timeeditor)
                        //        footer += ",{#stat_summ}";
                        //    else
                        //        footer += ",{#stat_total}";
                        //}

                        //footer += ",{#stat_total}";

                        XmlNode newCol1 = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                        newCol1.InnerText = "Total";
                        XmlAttribute attrType1 = docXml.CreateAttribute("type");
                        attrType1.Value = "ro[=sum]";
                        XmlAttribute attrWidth1 = docXml.CreateAttribute("width");
                        attrWidth1.Value = "50";
                        XmlAttribute attrAlign1 = docXml.CreateAttribute("align");
                        attrAlign1.Value = "right";
                        //XmlAttribute attrStyle = docXml.CreateAttribute("style");
                        //attrStyle.Value = "background: #c0c0c0";

                        XmlAttribute attrId = docXml.CreateAttribute("id");
                        attrId.Value = "_TsTotal_";

                        newCol1.Attributes.Append(attrType1);
                        newCol1.Attributes.Append(attrWidth1);
                        newCol1.Attributes.Append(attrAlign1);
                        newCol1.Attributes.Append(attrId);
                        //newCol1.Attributes.Append(attrStyle);

                        docXml.SelectSingleNode("//head").AppendChild(newCol1);

                        //XmlNode callNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                        //XmlAttribute attr = docXml.CreateAttribute("command");
                        //attr.Value = "attachFooter";
                        //callNode.Attributes.Append(attr);
                        //callNode.InnerXml = "<param>" + footer + "</param>";

                        //docXml.SelectSingleNode("//head/beforeInit").AppendChild(callNode);
                    }
                    dr.Close();
                }
                catch { }


                XmlNode ndHead = docXml.SelectSingleNode("//head");

                if (!usecurrent)
                {
                    foreach (XmlNode nd in ndHead.SelectNodes("column"))
                    {
                        string id = "";
                        try
                        {
                            id = nd.Attributes["id"].Value;
                        }
                        catch { }
                        strColumns += "," + id;
                    }
                    strColumns = strColumns.Substring(1);
                }

                XmlNode newColWork = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                newColWork.InnerXml = "<![CDATA[% Work Spent]]>";
                XmlAttribute attrTypeWork = docXml.CreateAttribute("type");
                attrTypeWork.Value = "percentwork";
                XmlAttribute attrWidthWork = docXml.CreateAttribute("width");
                attrWidthWork.Value = "125";
                XmlAttribute attrAlignWork = docXml.CreateAttribute("align");
                attrAlignWork.Value = "left";
                XmlAttribute attrColorWork = docXml.CreateAttribute("color");
                attrColorWork.Value = "#F0F0F0";
                XmlAttribute attrIdWork = docXml.CreateAttribute("id");
                attrIdWork.Value = "_PercentWork_";

                newColWork.Attributes.Append(attrTypeWork);
                newColWork.Attributes.Append(attrWidthWork);
                newColWork.Attributes.Append(attrAlignWork);
                newColWork.Attributes.Append(attrColorWork);
                newColWork.Attributes.Append(attrIdWork);

                ndHead.AppendChild(newColWork);

                ndHead.RemoveChild(ndHead.SelectSingleNode("settings"));

                string[] strworktypes = worktypes.Split('|');

                int rowCounter = 1;
            List<string> resetResources = new List<string>();
            foreach (XmlNode nd in docXml.SelectNodes("//row"))
                {
                    double hours = 0;
                    XmlNode ndListId = nd.SelectSingleNode("userdata[@name='listid']");
                    XmlNode ndItemId = nd.SelectSingleNode("userdata[@name='itemid']");
                    XmlNode ndTsuid = nd.SelectSingleNode("userdata[@name='tsuid']");

                    if (ndTsuid != null)
                    {
                        
                    }
                    else if (ndListId != null && ndItemId != null)
                    {
                        
                        string rowId = nd.Attributes["id"].Value;
                        string curUser = "";
                        int firstDot = rowId.IndexOf(".", 75);
                        curUser = rowId.Substring(firstDot + 1, rowId.LastIndexOf(".") - firstDot - 1);

                        SqlCommand cmd = new SqlCommand("spTSgetTSHours", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", curUser);
                        cmd.Parameters.AddWithValue("@siteguid", site.ID);
                        cmd.Parameters.AddWithValue("@period_id", period);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dsTSHours);

                        DataSet dsTotalHours = new DataSet();

                        cmd = new SqlCommand("spTSGetTotalHoursForItem", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@listuid", ndListId.InnerText);
                        cmd.Parameters.AddWithValue("@siteguid", site.ID);
                        cmd.Parameters.AddWithValue("@itemid", ndItemId.InnerText);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dsTotalHours);
                        

                        cmd = new SqlCommand("select ts_item_uid,submitted,approval_status,project from vwtstasks where list_uid=@listuid and item_id=@itemid and username=@username and period_id=@period_id", cn);
                        cmd.Parameters.AddWithValue("@listuid", ndListId.InnerText);
                        cmd.Parameters.AddWithValue("@itemid", ndItemId.InnerText);
                        cmd.Parameters.AddWithValue("@username", curUser);
                        cmd.Parameters.AddWithValue("@period_id", period);

                        SqlDataReader drItem = cmd.ExecuteReader();
                        XmlNode newCell;
                        XmlAttribute attrStyle2;

                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCell.InnerText = "";
                        XmlAttribute attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro";
                        newCell.Attributes.Append(attrType);
                        attrStyle2 = docXml.CreateAttribute("style");
                        attrStyle2.Value = "background: #" + bgcolor;
                        newCell.Attributes.Append(attrStyle2);
                        nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCell.InnerText = "";
                        attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro";
                        newCell.Attributes.Append(attrType);
                        attrStyle2 = docXml.CreateAttribute("style");
                        attrStyle2.Value = "background: #" + bgcolor;
                        newCell.Attributes.Append(attrStyle2);
                        nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCell.InnerText = "";
                        attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro";
                        newCell.Attributes.Append(attrType);
                        attrStyle2 = docXml.CreateAttribute("style");
                        attrStyle2.Value = "background: #" + bgcolor;
                        newCell.Attributes.Append(attrStyle2);
                        nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

                        XmlNode newCol;

                        string ts_item_uid = Guid.Empty.ToString();

                        if(drItem.Read())
                        {
                            ts_item_uid = drItem.GetGuid(0).ToString();
                            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);

                            if (drItem.GetString(3) != "No Project" && drItem.GetBoolean(1))
                            {
                                if (drItem.GetInt32(2) == 0)
                                    newCell.InnerXml = "<![CDATA[<img src=\"_layouts/images/yellow.gif\" alt=\"Pending\">]]>";
                                else if (drItem.GetInt32(2) == 1)
                                    newCell.InnerXml = "<![CDATA[<img src=\"_layouts/images/green.gif\" alt=\"Approved\">]]>";
                                else if (drItem.GetInt32(2) == 2)
                                    newCell.InnerXml = "<![CDATA[<img src=\"_layouts/images/red.gif\" alt=\"Rejected\">]]>";
                            }
                            attrStyle2 = docXml.CreateAttribute("style");
                            attrStyle2.Value = "background: #" + bgcolor;
                            newCell.Attributes.Append(attrStyle2);
                            nd.InsertBefore(newCell, nd.SelectNodes("cell")[3]);
                        }
                        

                        //        //DataRow[] drsItem = dsTSHours.Tables[2].Select("list_uid='" + ndListId.InnerText + "' and item_id=" + ndItemId.InnerText);
                        //        //if (drsItem.Length > 0)
                        //        //{
                        //        //    newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                        //        //    newCol.InnerText = drsItem[0]["TS_ITEM_UID"].ToString();
                        //        //    attrName = docXml.CreateAttribute("name");
                        //        //    attrName.Value = "tsitemuid";
                        //        //    newCol.Attributes.Append(attrName);
                        //        //    nd.AppendChild(newCol);
                        //        //}

                        double total = 0;

                        if (!usecurrent && drItem.GetBoolean(1))
                        {
                            string[] arrCols = strColumns.Split(',');
                            XmlNodeList ndList = nd.SelectNodes("cell");

                            for (int i = 0; i < ndList.Count; i++)
                            {
                                string cell = ndList[i].OuterXml;
                                string colid = arrCols[i].Replace("<![CDATA[", "").Replace("]]>", "");
                                if (colid == "Project")
                                {
                                    DataRow[] drs = dsTimesheetTasks.Tables[0].Select("ts_item_uid ='" + ts_item_uid + "'");
                                    if (drs.Length > 0)
                                    {
                                        ndList[i].InnerText = drs[0]["project"].ToString();
                                    }
                                }
                                else if (colid != "Title" && colid != "List" && colid != "Site" && colid != "")
                                {

                                    DataRow[] drs = dsTimesheetMeta.Tables[0].Select("ts_item_uid='" + ts_item_uid + "' and columnname='" + colid + "'");
                                    string colval = "";
                                    if (drs.Length > 0)
                                        colval = drs[0]["columnvalue"].ToString();

                                    bool bIsIndicator = false;
                                    try
                                    {
                                        SPField field = list.Fields.GetFieldByInternalName(colid);
                                        if (field.Type == SPFieldType.Calculated && colval.ToLower().Contains(".gif"))
                                        {
                                            bIsIndicator = true;
                                        }
                                    }
                                    catch { }

                                    if (bIsIndicator)
                                        ndList[i].InnerText = "<img src=\"/_layouts/images/" + colval + "\">";
                                    else
                                        ndList[i].InnerText = colval;

                                if (colid == "Work")
                                {

                                    double savedWork = 0;
                                    XmlNode ndWorkTotal = nd.ParentNode.SelectSingleNode("cell[@id='Work']");
                                    if (resetResources.IndexOf(curUser) >= 0)
                                    {
                                        double.TryParse(ndWorkTotal.InnerText, out savedWork);
                                    }
                                    else
                                    {
                                        resetResources.Add(curUser);
                                    }
                                    double newWork;
                                    if (double.TryParse(colval, out newWork))
                                    {
                                        savedWork += newWork;
                                    }
                                    else if (double.TryParse(ndList[i].InnerText, out newWork))
                                    {
                                        savedWork += newWork;
                                    }
                                    ndWorkTotal.InnerText = savedWork.ToString("F2");

                                }
                            }

                            }
                        }
                        drItem.Close();

                        foreach (DateTime dt in arr)
                        {
                            if (timeeditor)
                            {
                                newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                attrType = docXml.CreateAttribute("type");
                                attrType.Value = "timeeditor";
                                newCol.Attributes.Append(attrType);
                                foreach (string strWorkType in strworktypes)
                                {

                                    //DataRow[] drs = dsTSHours.Tables[0].Select("list_uid='" + ndListId.InnerText + "' and item_id=" + ndItemId.InnerText + " and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyyy") + "# and tstype_id='" + strWorkType + "'");
                                    DataRow[] drs = dsTSHours.Tables[0].Select("ts_item_uid = '" + ts_item_uid + "' and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyyy") + "# and tstype_id='" + strWorkType + "'");
                                    if (drs.Length > 0)
                                    {
                                        total += double.Parse(drs[0]["TS_ITEM_HOURS"].ToString());
                                        newCol.InnerText += "|" + strWorkType + "|" + drs[0]["TS_ITEM_HOURS"].ToString();
                                    }
                                    else
                                    {
                                        newCol.InnerText += "|" + strWorkType + "|0";
                                    }
                                }

                                if (timenotes)
                                {
                                    DataRow[] drs = dsTSHours.Tables[1].Select("ts_item_uid = '" + ts_item_uid + "' and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyy") + "#");
                                    if (drs.Length > 0)
                                    {
                                        newCol.InnerText += "|N|" + drs[0]["TS_ITEM_NOTES"].ToString();
                                    }
                                    else
                                    {
                                        newCol.InnerText += "|N|";
                                    }
                                }

                                if (newCol.InnerText.Length > 1)
                                    newCol.InnerText = newCol.InnerText.Substring(1);

                                nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);


                            }
                            else
                            {
                                newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                XmlAttribute attr = docXml.CreateAttribute("type");
                                attr.InnerText = "ro";
                                newCol.Attributes.Append(attr);
                                DataRow[] drs = dsTSHours.Tables[0].Select("ts_item_uid = '" + ts_item_uid + "' and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyyy") + "#");
                                if (drs.Length > 0)
                                {
                                    newCol.InnerText = double.Parse(drs[0]["TS_ITEM_HOURS"].ToString()).ToString();
                                    total += double.Parse(drs[0]["TS_ITEM_HOURS"].ToString());
                                    nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
                                }
                                else
                                {
                                    newCol.InnerText = "0";
                                    nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
                                }
                            }
                        }

                        newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCol.InnerText = total.ToString();
                        XmlAttribute attrStyle1 = docXml.CreateAttribute("style");
                        attrStyle1.Value = "background: #" + bgcolor + "; font-weight: bold";
                        newCol.Attributes.Append(attrStyle1);
                        nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);

                        XmlNode ndWork = nd.SelectSingleNode("userdata[@name='Work']");

                        newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        if (dsTotalHours.Tables[0].Rows.Count > 0)
                            newCol.InnerText = ndWork.InnerText + "|" + double.Parse(dsTotalHours.Tables[0].Rows[0][0].ToString()).ToString();
                        else
                            newCol.InnerText = ndWork.InnerText + "|0";

                        attrStyle1 = docXml.CreateAttribute("style");
                        attrStyle1.Value = "background: #" + bgcolor + "; font-weight: bold";
                        newCol.Attributes.Append(attrStyle1);
                        nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
                    }
                    else
                    {
                        XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCell.InnerText = "";
                        XmlAttribute attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro";
                        newCell.Attributes.Append(attrType);

                        nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCell.InnerText = "";
                        attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro";
                        newCell.Attributes.Append(attrType);

                        nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCell.InnerText = "";
                        attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro";
                        newCell.Attributes.Append(attrType);

                        nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCell.InnerText = "";
                        attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro";
                        newCell.Attributes.Append(attrType);

                        nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

                        foreach (XmlNode ndCell in nd.SelectNodes("cell"))
                        {
                            XmlAttribute attrStyle = docXml.CreateAttribute("style");
                            attrStyle.Value = "background: #" + bgcolor + "; font-weight: bold;";
                            ndCell.Attributes.Append(attrStyle);
                        }

                        foreach (DateTime dt in arr)
                        {
                            XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newCol.InnerText = "";
                            XmlAttribute attrStyle = docXml.CreateAttribute("style");
                            attrStyle.Value = "background: #" + bgcolor;
                            newCol.Attributes.Append(attrStyle);

                            //attrType = docXml.CreateAttribute("type");
                            //attrType.Value = "ro";
                            //newCol.Attributes.Append(attrType);

                            //nd.AppendChild(newCol);
                            nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
                        }

                        XmlNode newCol2 = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCol2.InnerText = "";
                        XmlAttribute attrStyle2 = docXml.CreateAttribute("style");
                        attrStyle2.Value = "background: #" + bgcolor + ";font-weight: bold;";
                        newCol2.Attributes.Append(attrStyle2);

                        //XmlAttribute attrType2 = docXml.CreateAttribute("type");
                        //attrType2.Value = "ro";
                        //newCol2.Attributes.Append(attrType2);

                        nd.InsertAfter(newCol2,nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);

                        newCol2 = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCol2.InnerText = "";
                        attrStyle2 = docXml.CreateAttribute("style");
                        attrStyle2.Value = "background: #" + bgcolor + ";font-weight: bold;";
                        newCol2.Attributes.Append(attrStyle2);
                        attrStyle2 = docXml.CreateAttribute("type");
                        attrStyle2.Value = "ro";
                        newCol2.Attributes.Append(attrStyle2);
                        nd.InsertAfter(newCol2, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
                    }
                    nd.Attributes["id"].Value = rowCounter.ToString();
                    rowCounter++;
                }

                XmlNode ndFilter = docXml.SelectSingleNode("//head/beforeInit/call[@command='attachHeader']");
                if (ndFilter != null)
                {
                    string xml = ndFilter.FirstChild.InnerXml;
                    xml = xml.Replace("<![CDATA[", "<![CDATA[&nbsp;,&nbsp;,&nbsp;,&nbsp;,").Replace("gridfilter" + gridname + "('1", "gridfilter" + gridname + "('2").Replace("]]>", filterHead + ",&nbsp;]]>");
                    ndFilter.FirstChild.InnerXml = xml;
                }

                double fullWidth = double.Parse(Request["width"]);
                double reservedWidth = 0;

                XmlNodeList ndNewCols = docXml.SelectNodes("//head/column");
                for (int i = columnCount + 4; i < ndNewCols.Count; i++)
                {
                    try
                    {
                        string w = ndNewCols[i].Attributes["width"].Value;
                        reservedWidth += double.Parse(w);
                    }
                    catch { }
                }
                reservedWidth += 125;

                fullWidth -= reservedWidth;
                fullWidth = fullWidth / (columnCount + 1);

                if (fullWidth < 50)
                    fullWidth = 50;

                for (int i = 4; i <= columnCount+3; i++)
                {
                    string id = "";
                    try
                    {
                        id = ndNewCols[i].Attributes["type"].Value;
                    }
                    catch { }
                    if (id == "tree")
                        ndNewCols[i].Attributes["width"].Value = (fullWidth * 2 - 10).ToString();
                    else
                    {
                        ndNewCols[i].Attributes["width"].Value = fullWidth.ToString();
                        ndNewCols[i].Attributes["type"].Value = "ro";
                    }
                }

                //XmlNode ndAfterInit = docXml.SelectSingleNode("//head/afterInit");
                //if (ndAfterInit != null)
                //{
                //    XmlNode nd = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                //    nd.InnerXml = "<param>3</param>";
                //    XmlAttribute attrCommand = docXml.CreateAttribute("command");
                //    attrCommand.Value = "splitAt";
                //    nd.Attributes.Append(attrCommand);
                //    ndAfterInit.AppendChild(nd);
                //}
                //XmlNode ndBeforeInit = docXml.SelectSingleNode("//head/beforeInit");
                //XmlNode ndfooter = ndBeforeInit.SelectSingleNode("call[@command='attachFooter']");
                //ndBeforeInit.RemoveChild(ndfooter); 


            cn.Close();

            data = docXml.OuterXml;
        }

        private void addTSItem(SPListItem li, SortedList arrGTemp, string username, string resource)
        {
            string[] group = new string[1] { null };

            //for (int i = 0; i < group.Length; i++)
            //{
            //    if (group[i] == null)
            //        group[i] = resource;
            //    else
            //        group[i] += "\n" + resource;
            //    if (!arrGTemp.Contains(group[i]))
            //    {
            //        arrGTemp.Add(group[i], "");
            //    }
            //}

            group[0] = resource;
            

            if (arrGroupFields != null)
            {
                foreach (string groupby in arrGroupFields)
                {
                    SPField field = list.Fields.GetFieldByInternalName(groupby);
                    string newgroup = getField(li, groupby, true);
                    try
                    {
                        newgroup = formatField(newgroup, groupby, field.Type == SPFieldType.Calculated, true, li);
                    }
                    catch { }
                    if (field.Type == SPFieldType.User || field.Type == SPFieldType.MultiChoice)
                    {
                        string[] sGroups = newgroup.Split('\n');
                        string[] tmpGroups = new string[group.Length * sGroups.Length];

                        //group = new string[sGroups.Length];
                        int tmpCounter = 0;
                        foreach (string g in group)
                        {
                            foreach (string sGroup in sGroups)
                            {
                                if (g == null)
                                    tmpGroups[tmpCounter] = sGroup.Trim();
                                else
                                    tmpGroups[tmpCounter] = g + "\n" + sGroup.Trim();

                                if (!arrGTemp.Contains(tmpGroups[tmpCounter]))
                                {
                                    arrGTemp.Add(tmpGroups[tmpCounter], "");
                                }
                                tmpCounter++;
                            }
                        }
                        group = tmpGroups;
                    }
                    else
                    {
                        for (int i = 0; i < group.Length; i++)
                        {
                            if (group[i] == null)
                                group[i] = newgroup;
                            else
                                group[i] += "\n" + newgroup;
                            if (!arrGTemp.Contains(group[i]))
                            {
                                arrGTemp.Add(group[i], "");
                            }
                        }
                    }
                }
            }
            
            AddItemType it = new AddItemType();
            it.indexer = li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID + "." + username;
            it.o = li;
            arrItems.Add(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID + "." + username, group);
            queueAllItems.Enqueue(it);
        }
    }

}


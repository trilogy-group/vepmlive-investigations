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

namespace TimeSheets
{
    public partial class gettimesheet : EPMLiveWebParts.getgriditems
    {
        SPSite site = SPContext.Current.Site;
        int period;
        string username = SPContext.Current.Web.CurrentUser.LoginName;
        DataSet dsTSHours = new DataSet();
        DataSet dsTSMeta = new DataSet();
        DataSet dsTimesheetTasks;
        static string bgcolor = "EFEFEF";
        bool submitted = false;
        bool usecurrent = true;
        DataTable dtTemp = new DataTable();

        public override void getParams(SPWeb curWeb)
        {
            base.getParams(curWeb);
            isTimesheet = true;

            string strPeriod = Request["period"];
            period = int.Parse(strPeriod);

            //base.inEditMode = true;
        }

        public override void populateGroups(string query, SortedList arrGTemp, SPWeb curWeb)
        {
            
            DataSet ds = new DataSet();
            bool newTimesheet = false;
            //string flagfield = "";
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                string requestedUser = Page.Request["duser"];
                string resname = "";
                if (requestedUser != null && requestedUser != "")
                {
                    if (SharedFunctions.canUserImpersonate(username, requestedUser, site.RootWeb, out resname))
                    {
                        username = requestedUser;
                    }
                }

                

                //flagfield = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSFlag");
                try
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(curWeb.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("spTSGetTSForSite", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@siteguid", site.ID);
                    cmd.Parameters.AddWithValue("@period_id", period);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    cmd = new SqlCommand("Select submitted from tstimesheet where username=@username and site_uid=@siteguid and period_id=@period_id", cn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@siteguid", site.ID);
                    cmd.Parameters.AddWithValue("@period_id", period);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        submitted = dr.GetBoolean(0);
                    dr.Close();

                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        newTimesheet = true;
                        ds = new DataSet();
                        int intPeriod = 1;
                        SqlCommand cmd1 = new SqlCommand("SELECT TOP (1) PERIOD_ID FROM TSTIMESHEET WHERE     (USERNAME LIKE @username) and site_uid=@siteid ORDER BY PERIOD_ID DESC", cn);
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Parameters.AddWithValue("@username", username);
                        cmd1.Parameters.AddWithValue("@siteid", site.ID);
                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            intPeriod = dr1.GetInt32(0);

                        }

                        dr1.Close();

                        cmd = new SqlCommand("spTSGetTSForSite", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@siteguid", site.ID);
                        cmd.Parameters.AddWithValue("@period_id", intPeriod);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                    }
                    else
                    {

                    }

                    cmd = new SqlCommand("spTSgetTSHours", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@siteguid", site.ID);
                    cmd.Parameters.AddWithValue("@period_id", period);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dsTSHours);

                    //if (submitted)
                    {
                        cmd = new SqlCommand("spTSgetTSMeta", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@siteguid", site.ID);
                        cmd.Parameters.AddWithValue("@period_id", period);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dsTSMeta);
                    }

                    cmd = new SqlCommand("select title,project,ts_uid,web_uid,list_uid,item_id,ts_item_uid,approval_status,resourcename,username from vwTSTasks where period_id=@period_id and site_uid=@siteid order by project", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@period_id", period);
                    cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
                    dsTimesheetTasks = new DataSet();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dsTimesheetTasks);
                }
                catch { }

                Guid webGuid = new Guid();
                Guid listGuid = new Guid();
                SPWeb iWeb = null;
                SPList iList = null;
                bool foundli = false;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    foundli = false;
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
                        foundli = true;
                        if (newTimesheet)
                        {
                            try
                            {
                                if (li["Timesheet"].ToString() == "True")
                                {
                                    addItem(li, arrGTemp);
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            addItem(li, arrGTemp);
                        }
                    }
                    catch { }
                    if (!foundli && !newTimesheet)
                    {
                        addItem(dr, arrGTemp, curWeb);
                        //SqlCommand cmd = new SqlCommand("delete from tsitem where ts_item_uid=@tsitemuid", cn);
                        //cmd.Parameters.AddWithValue("@tsitemuid", dr["ts_item_uid"].ToString());
                        //cmd.ExecuteNonQuery();
                    }
                }
            });
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

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPWeb web = site.RootWeb;
                    {
                        usecurrent = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTSUseCurrent"));
                    }

                    ndCols[0].Attributes["width"].Value = "25";
                    
                    XmlNode ndBeforeInit = docXml.SelectSingleNode("//head/beforeInit");

                    XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    newCol.InnerXml = "<![CDATA[&nbsp;]]>";
                    XmlAttribute attrType = docXml.CreateAttribute("type");
                    if(submitted)
                        attrType.Value = "ro";
                    else
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

                    


                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();
                    
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

                    string []dayDefs = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveDaySettings").Split('|');

                    cmd = new SqlCommand("select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@siteid", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@period_id", period);
                    cmd.Parameters.AddWithValue("@siteid", site.ID);
                    dr = cmd.ExecuteReader();

                    string footer = ",Totals:";
                    
                    if(dr.Read())
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
                                newCol.InnerXml = "<![CDATA[" + dtStart.AddDays(i).DayOfWeek.ToString().Substring(0,3) + "<br>" + dtStart.AddDays(i).Day + "]]>";
                                attrType = docXml.CreateAttribute("type");
                                if (timeeditor)
                                    attrType.Value = "timeeditor";
                                else
                                    attrType.Value = "edn";
                                attrWidth = docXml.CreateAttribute("width");
                                attrWidth.Value = "40";
                                attrAlign = docXml.CreateAttribute("align");
                                attrAlign.Value = "right";
                                XmlAttribute attrId1 = docXml.CreateAttribute("id");
                                attrId1.Value = "_TsDate_" + dtStart.AddDays(i).ToShortDateString().Replace("/","_");

                                newCol.Attributes.Append(attrType);
                                newCol.Attributes.Append(attrWidth);
                                newCol.Attributes.Append(attrAlign);
                                newCol.Attributes.Append(attrId1);

                                docXml.SelectSingleNode("//head").AppendChild(newCol);
                            }
                        }
                        string cols = "";
                        
                        for (int i = 1; i < colBase - 1; i++)
                        {
                            footer += ",#cspan";
                        }
                        for (int i = colBase; i < colBase + colCount; i++)
                        {
                            cols += "+c" + i.ToString();
                            if(timeeditor)
                                footer += ",{#stat_summ}";
                            else
                                footer += ",{#stat_total}";

                            //XmlNode call = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                            //XmlAttribute attrC = docXml.CreateAttribute("command");
                            //attrC.Value = "setNumberFormat";
                            //call.Attributes.Append(attrC);

                            //XmlNode param = docXml.CreateNode(XmlNodeType.Element, "param", docXml.NamespaceURI);
                            //param.InnerText = "";
                            //call.AppendChild(param);

                            //param = docXml.CreateNode(XmlNodeType.Element, "param", docXml.NamespaceURI);
                            //param.InnerText = i.ToString();
                            //call.AppendChild(param);

                            //param = docXml.CreateNode(XmlNodeType.Element, "param", docXml.NamespaceURI);
                            //param.InnerText = web.RegionalSettings.DecimalSeparator;
                            //call.AppendChild(param);

                            //param = docXml.CreateNode(XmlNodeType.Element, "param", docXml.NamespaceURI);
                            //param.InnerText = web.RegionalSettings.ThousandSeparator;
                            //call.AppendChild(param);

                            //ndBeforeInit.AppendChild(call);
                        }

                        footer += ",{#stat_totalsumm},-";

                        XmlNode newCol1 = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                        newCol1.InnerText = "Total";
                        XmlAttribute attrType1 = docXml.CreateAttribute("type");
                        if (cols.Length > 1)
                            attrType1.Value = "ron[=" + cols.Substring(1) + "]";
                        else
                            attrType1.Value = "ro";

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

                        XmlNode callNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                        XmlAttribute attr = docXml.CreateAttribute("command");
                        attr.Value = "attachFooter";
                        callNode.Attributes.Append(attr);
                        callNode.InnerXml = "<param>" + footer + "</param>";

                        docXml.SelectSingleNode("//head/beforeInit").AppendChild(callNode);
                    }
                    dr.Close();
                }
                catch { }
            });

            XmlNode ndHead = docXml.SelectSingleNode("//head");
            if (submitted && !usecurrent)
            {
                foreach(XmlNode nd in ndHead.SelectNodes("column"))
                {
                    string id = "";
                    try
                    {
                        id = nd.Attributes["id"].Value;
                    }catch{}
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

            #region rowparsing
            foreach (XmlNode nd in docXml.SelectNodes("//row"))
            {

                XmlNode ndListId = nd.SelectSingleNode("userdata[@name='listid']");
                XmlNode ndItemId = nd.SelectSingleNode("userdata[@name='itemid']");
                
                if (ndListId != null && ndItemId != null)
                {
                    XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    newCell.InnerText = "";
                    XmlAttribute attrStyle2 = docXml.CreateAttribute("style");
                    if(inEditMode)
                        attrStyle2.Value = "background: #" + bgcolor;
                    newCell.Attributes.Append(attrStyle2);
                    nd.SelectSingleNode("cell").Attributes.Append((XmlAttribute)attrStyle2.Clone());

                    nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

                    /*//foreach (XmlNode ndCell in nd.SelectNodes("cell"))
                    //{
                    //    XmlAttribute attrStyle = docXml.CreateAttribute("style");
                    //    attrStyle.Value = "background: #" + bgcolor;
                    //    ndCell.Attributes.Append(attrStyle);
                    //}*/

                    XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                    if(inEditMode)
                        newCol.InnerText = view.ViewFields.Count.ToString();
                    else
                        newCol.InnerText = (view.ViewFields.Count - 1).ToString();
                    XmlAttribute attrName = docXml.CreateAttribute("name");
                    attrName.Value = "fieldcount";
                    newCol.Attributes.Append(attrName);
                    nd.AppendChild(newCol);

                    newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                    if(arr.Count > 0)
                        newCol.InnerText = arr[0].ToString();
                    attrName = docXml.CreateAttribute("name");
                    attrName.Value = "firstdate";
                    newCol.Attributes.Append(attrName);
                    nd.AppendChild(newCol);

                    newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                    newCol.InnerText = arr.Count.ToString();
                    attrName = docXml.CreateAttribute("name");
                    attrName.Value = "datecount";
                    newCol.Attributes.Append(attrName);
                    nd.AppendChild(newCol);

                    DataRow[] drsItem = dsTSHours.Tables[2].Select("list_uid='" + ndListId.InnerText + "' and item_id=" + ndItemId.InnerText);

                    Guid ts_item_uid = Guid.Empty;

                    if (drsItem.Length > 0)
                    {
                        newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                        newCol.InnerText = drsItem[0]["TS_ITEM_UID"].ToString();
                        attrName = docXml.CreateAttribute("name");
                        attrName.Value = "tsitemuid";
                        newCol.Attributes.Append(attrName);
                        nd.AppendChild(newCol);

                        ts_item_uid = new Guid(drsItem[0]["TS_ITEM_UID"].ToString());
                    }

                    if (submitted && !usecurrent)
                    {
                        string[] arrCols = strColumns.Split(',');
                        XmlNodeList ndList = nd.SelectNodes("cell");

                        for(int i = 0;i<ndList.Count;i++)
                        {
                            string cell = ndList[i].OuterXml;
                            string colid = arrCols[i].Replace("<![CDATA[","").Replace("]]>","");
                            if (colid == "Project")
                            {
                                DataRow[] drs = dsTimesheetTasks.Tables[0].Select("ts_item_uid ='" + ts_item_uid + "'");
                                if (drs.Length > 0)
                                {
                                    ndList[i].InnerText = drs[0]["project"].ToString();
                                }
                            }
                            else if (colid != "Title" && colid != "List" && colid != "Site")
                            {
                                
                                DataRow[] drs = dsTSMeta.Tables[0].Select("list_uid='" + ndListId.InnerText + "' and item_id=" + ndItemId.InnerText + " and columnname='" + colid + "'");
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

                                if(bIsIndicator)
                                    ndList[i].InnerText = "<img src=\"/_layouts/images/" + colval + "\">";
                                else
                                    ndList[i].InnerText = colval;

                                
                            }
                            
                        }
                    }
                    bool ro = false;
                    try
                    {
                        if (nd.SelectSingleNode("userdata[@name='tsdisabled']").InnerText == "1")
                            ro = true;
                    }
                    catch { }

                    foreach (DateTime dt in arr)
                    {
                        if (timeeditor)
                        {
                            newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);

                            foreach (string strWorkType in strworktypes)
                            {

                                DataRow[] drs = dsTSHours.Tables[0].Select("list_uid='" + ndListId.InnerText + "' and item_id=" + ndItemId.InnerText + " and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyyy") + "# and tstype_id='" + strWorkType + "'");
                                if (drs.Length > 0)
                                {
                                    newCol.InnerText += "|" + strWorkType + "|" + drs[0]["TS_ITEM_HOURS"].ToString();
                                }
                                else
                                {
                                    newCol.InnerText += "|" + strWorkType + "|0";
                                }
                            }

                            if (timenotes)
                            {
                                DataRow[] drs = dsTSHours.Tables[1].Select("list_uid='" + ndListId.InnerText + "' and item_id=" + ndItemId.InnerText + " and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyy") + "#");
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

                            nd.AppendChild(newCol);
                        }
                        else
                        {
                            newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);

                            DataRow[] drs = dsTSHours.Tables[0].Select("list_uid='" + ndListId.InnerText + "' and item_id=" + ndItemId.InnerText + " and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyyy") + "#");
                            if (drs.Length > 0)
                            {
                                newCol.InnerText = drs[0]["TS_ITEM_HOURS"].ToString();
                            }
                            else
                            {

                                newCol.InnerText = "0";

                            }

                            if (ro)
                            {
                                XmlAttribute attrType = docXml.CreateAttribute("type");
                                attrType.Value = "ro";
                                newCol.Attributes.Append(attrType);
                            }


                            nd.AppendChild(newCol);
                        }
                    }



                    newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    newCol.InnerText = "";
                    XmlAttribute attrStyle1 = docXml.CreateAttribute("style");
                    attrStyle1.Value = "background: #" + bgcolor;
                    newCol.Attributes.Append(attrStyle1);
                    nd.AppendChild(newCol);

                    DataRow[] drTotal = dsTSHours.Tables[3].Select("list_uid='" + ndListId.InnerText + "' and item_id=" + ndItemId.InnerText);

                    XmlNode ndWork = nd.SelectSingleNode("userdata[@name='Work']");

                    newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    if (drTotal.Length > 0)
                        newCol.InnerText = ndWork.InnerText + "|" + drTotal[0][0].ToString();
                    else
                        newCol.InnerText = ndWork.InnerText + "|0";

                    attrStyle1 = docXml.CreateAttribute("style");
                    attrStyle1.Value = "background: #" + bgcolor;
                    newCol.Attributes.Append(attrStyle1);
                    nd.AppendChild(newCol);
                }
                else
                {
                    XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    newCell.InnerText = "";
                    XmlAttribute attrType = docXml.CreateAttribute("type");
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

                        attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro";
                        newCol.Attributes.Append(attrType);

                        nd.AppendChild(newCol);
                    }

                    XmlNode newCol2 = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    newCol2.InnerText = "-";
                    XmlAttribute attrStyle2 = docXml.CreateAttribute("style");
                    attrStyle2.Value = "background: #" + bgcolor;
                    newCol2.Attributes.Append(attrStyle2);

                    XmlAttribute attrType2 = docXml.CreateAttribute("type");
                    attrType2.Value = "ron";
                    newCol2.Attributes.Append(attrType2);

                    nd.AppendChild(newCol2);

                    newCol2 = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    newCol2.InnerText = "&nbsp;";
                    attrType2 = docXml.CreateAttribute("style");
                    attrType2.Value = "background: #" + bgcolor;
                    newCol2.Attributes.Append(attrType2);
                    nd.AppendChild(newCol2);
                }
            }
            #endregion

            XmlNode ndFilter = docXml.SelectSingleNode("//head/beforeInit/call[@command='attachHeader']");
            if (ndFilter != null)
            {
                string xml = ndFilter.FirstChild.InnerXml;
                xml = xml.Replace("<![CDATA[", "<![CDATA[&nbsp;,").Replace("]]>",filterHead + ",&nbsp;,&nbsp;]]>");
                ndFilter.FirstChild.InnerXml = xml;
            }

            double fullWidth = double.Parse(Request["width"].Split('.')[0]);
            double reservedWidth = 0;

            

            XmlNodeList ndNewCols = docXml.SelectNodes("//head/column");
            for (int i = columnCount + 1; i < ndNewCols.Count; i++)
            {
                try
                {
                    string w = ndNewCols[i].Attributes["width"].Value;
                    reservedWidth += double.Parse(w);
                }
                catch { }
            }
            if (inEditMode)
                reservedWidth += 40;
            else
                reservedWidth += 30;

            fullWidth -= reservedWidth;

            int start = 1;
            if (inEditMode)
            {
                start = 2;
                fullWidth = fullWidth / columnCount;
            }
            else
            {
                fullWidth = fullWidth / (columnCount + 1);
            }            

            if (fullWidth < 50)
                fullWidth = 50;

            for (int i = start; i <= columnCount; i++)
            {
                string id = "";
                try
                {
                    id = ndNewCols[i].Attributes["type"].Value;
                }
                catch { }
                if (id == "tree")
                    ndNewCols[i].Attributes["width"].Value = (fullWidth * 2 - 10).ToString("#");
                else
                {
                    ndNewCols[i].Attributes["width"].Value = fullWidth.ToString("#");
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


             
             
            data = docXml.OuterXml;
        }

        private void addItem(DataRow dr, SortedList arrGTemp, SPWeb curWeb)
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("WebId");
            dtTemp.Columns.Add("ListId");
            dtTemp.Columns.Add("Id");
            dtTemp.Columns.Add("Title");
            dtTemp.Columns.Add("SiteUrl");
            dtTemp.Columns.Add("SiteId");
            dtTemp.Columns.Add("Project");
            dtTemp.Columns.Add("TSDisableItem");
            dtTemp.Columns.Add("List");

            dtTemp.Rows.Add(new object[] { dr["Web_UID"].ToString(), dr["List_UID"].ToString(), dr["ITEM_ID"].ToString(), dr["Title"].ToString(), curWeb.Site.ServerRelativeUrl, curWeb.Site.ID, dr["Project"].ToString(), 1, dr["List"].ToString() });

            int counter = 9;

            foreach (DataRow drCol in dsTSMeta.Tables[0].Select("list_uid='" + dr["List_UID"].ToString() + "' and item_id=" + dr["ITEM_ID"].ToString()))
            {
                if (!dtTemp.Columns.Contains(drCol["columnName"].ToString()))
                {
                    dtTemp.Columns.Add(drCol["columnName"].ToString());

                    dtTemp.Rows[0][counter] = drCol["columnValue"].ToString();

                    counter++;
                }
            }

            string[] group = new string[1] { null };
            if (arrGroupFields != null)
            {
                foreach (string groupby in arrGroupFields)
                {
                    SPField field = list.Fields.GetFieldByInternalName(groupby);
                    /////////TODO
                    string newgroup = "";
                    try
                    {
                        newgroup = dr[groupby].ToString();
                        newgroup = formatField(newgroup, groupby, dr, true);
                    }
                    catch { }
                    if (newgroup == "")
                        newgroup = " No " + field.Title;
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
                    //}

                }
            }
            arrItems.Add(dr["Web_UID"].ToString() + "." + dr["List_UID"].ToString() + "." + dr["ITEM_ID"].ToString(), group);

            queueAllItems.Enqueue(dtTemp.Rows[0]);
        }

        private void addItem(SPListItem li, SortedList arrGTemp)
        {
            string[] group = new string[1] { null };
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
                    if (newgroup == "")
                        newgroup = " No " + field.Title;
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
                    //}

                }
            }
            arrItems.Add(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID, group);
            queueAllItems.Enqueue(li);
        }
    }

}


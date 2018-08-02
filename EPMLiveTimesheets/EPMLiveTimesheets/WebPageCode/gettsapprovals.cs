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
using System.Diagnostics;

namespace TimeSheets
{
    public partial class GetTsApprovals : ApprovalBase
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
            {
                if (resWeb.ID != SPContext.Current.Web.ID)
                {
                    resWeb.Close();
                }}
            
            base.Dispose();
        }

        public override void getParams(SPWeb curWeb)
        {
            base.getParams(curWeb);
            isTimesheet = true;

            string strPeriod = Request["period"];
            period = int.Parse(strPeriod);
            base.inEditMode = false;
            string resUrl = string.Empty;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(curWeb.Site.WebApplication.Id));
                    cn.Open();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(curWeb, "EPMLiveResourceURL", true, false); 
            });

            try
            {
                if (resUrl != string.Empty)
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
                    {
                        resWeb = curWeb;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

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
                            {
                                arrGTemp.Add(li.Title, string.Empty);
                            }

                            XmlNode newNode = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
                            XmlAttribute attrId = docXml.CreateAttribute("id");
                            attrId.InnerText = li.Title;
                            newNode.Attributes.Append(attrId);

                            string status = string.Empty;//<![CDATA[<img src=\"_layouts/epmlive/images/tsflagnone.gif\" alt=\"No Timesheet\">]]>";
                            string notes = string.Empty;

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
                                newCol.InnerText = string.Empty;
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
                            newCell.InnerText = string.Empty;
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
                            newCell.InnerText = string.Empty;
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

                foreach (DataRow dr in dtItems.Select(string.Empty, "WebId, ListId"))
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
                            {
                                iWeb = site.OpenWeb(wGuid);
                            }
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
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            }
        }

        protected override void outputXml()
        {
            ArrayList arr = new ArrayList();
            string worktypes = string.Empty;
            bool timeeditor = false;
            bool timenotes = false;
            string filterHead = string.Empty;
            XmlNodeList ndCols = docXml.SelectNodes("//head/column");

            int columnCount = ndCols.Count;
            string strColumns = string.Empty;

            SPWeb web = site.RootWeb;
            {
                usecurrent = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTSUseCurrent"));
            }

            try
            {
                AddNodes(
                    ndCols,
                    site,
                    cn,
                    "<![CDATA[Notes]]>",
                    "tsnotes",
                    "50",
                    period,
                    arr,
                    ref filterHead,
                    ref worktypes,
                    ref timeeditor,
                    ref timenotes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


                XmlNode ndHead = docXml.SelectSingleNode("//head");

                if (!usecurrent)
                {
                    foreach (XmlNode nd in ndHead.SelectNodes("column"))
                    {
                        string id = string.Empty;
                        try
                        {
                            id = nd.Attributes["id"].Value;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
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

                foreach (XmlNode nd in docXml.SelectNodes("//row"))
                {
                    double hours = 0;
                    XmlNode ndListId = nd.SelectSingleNode("userdata[@name='listid']");
                    XmlNode ndItemId = nd.SelectSingleNode("userdata[@name='itemid']");
                    XmlNode ndTsuid = nd.SelectSingleNode("userdata[@name='tsuid']");

                    if (ndListId != null && ndItemId != null)
                    {
                        AddCells(
                            nd, 
                            site, 
                            ndListId, 
                            ndItemId, 
                            period, 
                            dsTSHours, 
                            arr, 
                            bgcolor, 
                            usecurrent, 
                            strColumns, 
                            dsTimesheetTasks, 
                            dsTimesheetMeta,
                            timeeditor,
                            strworktypes,
                            timenotes, 
                            cn);
                    }
                    else
                    {
                        AddCells(nd, bgcolor, arr);
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
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
                reservedWidth += 125;

                fullWidth -= reservedWidth;
                fullWidth = fullWidth / (columnCount + 1);

                if (fullWidth < 50)
                    fullWidth = 50;

                for (int i = 4; i <= columnCount+3; i++)
                {
                    string id = string.Empty;
                    try
                    {
                        id = ndNewCols[i].Attributes["type"].Value;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    if (id == "tree")
                        ndNewCols[i].Attributes["width"].Value = (fullWidth * 2 - 10).ToString();
                    else
                    {
                        ndNewCols[i].Attributes["width"].Value = fullWidth.ToString();
                        ndNewCols[i].Attributes["type"].Value = "ro";
                    }
                }

            cn.Close();

            data = docXml.OuterXml;
        }

        private void addTSItem(SPListItem li, SortedList arrGTemp, string username, string resource)
        {
            string[] group = new string[1] { null };

            group[0] = resource;

            ProcessGroupFields(arrGroupFields, li, group, arrGTemp);

            AddItemType it = new AddItemType();
            it.indexer = li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID + "." + username;
            it.o = li;
            arrItems.Add(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID + "." + username, group);
            queueAllItems.Enqueue(it);
        }

        protected override void AddColumn2(XmlNode nd, ArrayList arr)
        {
            XmlNode newCell;
            XmlAttribute attrStyle2;

            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = string.Empty;
            XmlAttribute attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            newCell.Attributes.Append(attrType);
            attrStyle2 = docXml.CreateAttribute("style");
            attrStyle2.Value = "background: #" + bgcolor;
            newCell.Attributes.Append(attrStyle2);
            nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = string.Empty;
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            newCell.Attributes.Append(attrType);
            attrStyle2 = docXml.CreateAttribute("style");
            attrStyle2.Value = "background: #" + bgcolor;
            newCell.Attributes.Append(attrStyle2);
            nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = string.Empty;
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            newCell.Attributes.Append(attrType);
            attrStyle2 = docXml.CreateAttribute("style");
            attrStyle2.Value = "background: #" + bgcolor;
            newCell.Attributes.Append(attrStyle2);
            nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));
        }

        protected override void AddCell1(SqlDataReader drItem, XmlNode nd)
        {
            var newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);

            if (drItem.GetString(3) != "No Project" && drItem.GetBoolean(1))
            {
                if (drItem.GetInt32(2) == 0)
                {
                    newCell.InnerXml = "<![CDATA[<img src=\"_layouts/images/yellow.gif\" alt=\"Pending\">]]>";
                }
                else if (drItem.GetInt32(2) == 1)
                {
                    newCell.InnerXml = "<![CDATA[<img src=\"_layouts/images/green.gif\" alt=\"Approved\">]]>";
                }
                else if (drItem.GetInt32(2) == 2)
                {
                    newCell.InnerXml = "<![CDATA[<img src=\"_layouts/images/red.gif\" alt=\"Rejected\">]]>";
                }
            }
            var attrStyle2 = docXml.CreateAttribute("style");
            attrStyle2.Value = "background: #" + bgcolor;
            newCell.Attributes.Append(attrStyle2);
            nd.InsertBefore(newCell, nd.SelectNodes("cell")[3]);
        }

        protected override XmlNode CreateCell(DataSet dsTsHours, string ts_item_uid, string[] strworktypes, DateTime dt, ref double total)
        {
            var newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            var attrType = docXml.CreateAttribute("type");
            attrType.Value = "timeeditor";
            newCol.Attributes.Append(attrType);
            foreach (string strWorkType in strworktypes)
            {
                var drs = dsTSHours.Tables[0].Select("ts_item_uid = '" + ts_item_uid + "' and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyyy") + "# and tstype_id='" + strWorkType + "'");
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

            return newCol;
        }

        protected override void InsertNodes(XmlNodeList ndCols)
        {
            var newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            newCol.InnerXml = "<![CDATA[TM]]>";
            var attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            var attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "35";
            var attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";
            var attrColor = docXml.CreateAttribute("color");
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
        }

        protected override void InsertCell1(XmlNode nd)
        {
            var newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = string.Empty;
            var attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            newCell.Attributes.Append(attrType);

            nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));

            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = string.Empty;
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            newCell.Attributes.Append(attrType);

            nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));
        }

        protected override void InsertCell2(XmlNode nd)
        {
            var newCol2 = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCol2.InnerText = string.Empty;
            var attrStyle2 = docXml.CreateAttribute("style");
            attrStyle2.Value = "background: #" + bgcolor + ";font-weight: bold;";
            newCol2.Attributes.Append(attrStyle2);
            attrStyle2 = docXml.CreateAttribute("type");
            attrStyle2.Value = "ro";
            newCol2.Attributes.Append(attrStyle2);
            nd.InsertAfter(newCol2, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
        }
    }
}
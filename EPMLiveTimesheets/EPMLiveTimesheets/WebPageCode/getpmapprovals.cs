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
    public partial class GetPmApprovals : ApprovalBase
    {
        SPSite site = SPContext.Current.Site;
        int period;
        string username = SPContext.Current.Web.CurrentUser.LoginName;
        DataSet dsTSHours = new DataSet();
        static string bgcolor = "EFEFEF";
        SqlConnection cn = null;
        bool usecurrent = true;
        private DataSet dsTimesheetMeta;
        private DataSet dsTimesheetTasks;

        public override void getParams(SPWeb curWeb)
        {
            base.getParams(curWeb);
            isTimesheet = true;

            string strPeriod = Request["period"];
            period = int.Parse(strPeriod);
            base.inEditMode = false;

            
        }

        public override void populateGroups(string query, SortedList arrGTemp, SPWeb curWeb)
        {

            SPSiteDataQuery dq = new SPSiteDataQuery();
            dq.ViewFields = "<FieldRef Name='Title' Nullable='TRUE'/>";
            dq.Webs = "<Webs Scope='Recursive'/>";
            dq.Lists = "<Lists ServerTemplate='10701'/>";
            dq.Query = "<Where><Eq><FieldRef Name=\"ProjectManagers\" /><Value Type=\"User\"><UserID/></Value></Eq></Where>";

            DataTable dtData = curWeb.GetSiteData(dq);


            DataTable dtItems = new DataTable();

            
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(curWeb.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select ts_item_uid,columnname,columnvalue from vwTSItemMeta where period_id=@period_id and site_uid=@siteid", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@period_id", period);
                    cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
                    dsTimesheetMeta = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dsTimesheetMeta);

                    foreach(DataRow drProjects in dtData.Rows)
                    {
                        cmd = new SqlCommand("select web_uid, list_uid,item_id,username,resourcename from vwTSTasks where web_uid=@webuid and (project=@project or (title=@project and list_uid=@listid)) and period_id=@period_id and totalhours > 0", cn);
                        cmd.Parameters.AddWithValue("@webuid", drProjects["WebId"].ToString());
                        cmd.Parameters.AddWithValue("@project", drProjects["Title"].ToString());
                        cmd.Parameters.AddWithValue("@listid", drProjects["ListId"].ToString());
                        cmd.Parameters.AddWithValue("@period_id", period);
                        da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dtItems.Merge(ds.Tables[0], false);
                        
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
            });

            Guid webGuid = new Guid();
            Guid listGuid = new Guid();
            SPWeb iWeb = null;
            SPList iList = null;

            foreach (DataRow dr in dtItems.Rows)
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

                foreach (XmlNode nd in docXml.SelectNodes("//row"))
                {
                    double hours = 0;
                    XmlNode ndListId = nd.SelectSingleNode("userdata[@name='listid']");
                    XmlNode ndItemId = nd.SelectSingleNode("userdata[@name='itemid']");

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
                    }
                    nd.Attributes["id"].Value = rowCounter.ToString();
                    rowCounter++;
                }

                XmlNode ndFilter = docXml.SelectSingleNode("//head/beforeInit/call[@command='attachHeader']");
                if (ndFilter != null)
                {
                    string xml = ndFilter.FirstChild.InnerXml;
                    xml = xml.Replace("<![CDATA[", "<![CDATA[&nbsp;,&nbsp;,").Replace("gridfilter" + gridname + "('1", "gridfilter" + gridname + "('2").Replace("]]>", filterHead + ",&nbsp;]]>");
                    ndFilter.FirstChild.InnerXml = xml;
                }

                double fullWidth = double.Parse(Request["width"]);
                double reservedWidth = 0;

                XmlNodeList ndNewCols = docXml.SelectNodes("//head/column");
                for (int i = columnCount + 2; i < ndNewCols.Count; i++)
                {
                    try
                    {
                        string w = ndNewCols[i].Attributes["width"].Value;
                        reservedWidth += double.Parse(w);
                    }
                    catch { }
                }
                reservedWidth += 30;

                fullWidth -= reservedWidth;
                fullWidth = fullWidth / (columnCount + 1);

                if (fullWidth < 50)
                    fullWidth = 50;

                for (int i = 2; i <= columnCount+1; i++)
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
            for (int i = 0; i < group.Length; i++)
            {
                if (group[i] == null)
                    group[i] = resource;
                else
                    group[i] += "\n" + resource;
                if (!arrGTemp.Contains(group[i]))
                {
                    arrGTemp.Add(group[i], "");
                }
            }
            AddItemType it = new AddItemType();
            it.indexer = li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID + "." + username;
            it.o = li;
            arrItems.Add(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID + "." + username, group);
            queueAllItems.Enqueue(it);
        }

        protected override void AddColumn1(XmlNode nd, ArrayList arr)
        {
            XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
            newCol.InnerText = view.ViewFields.Count.ToString();
            XmlAttribute attrName = docXml.CreateAttribute("name");
            attrName.Value = "fieldcount";
            newCol.Attributes.Append(attrName);
            nd.AppendChild(newCol);

            newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
            if (arr.Count > 0)
            {
                newCol.InnerText = arr[0].ToString();
            }
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
        }

        protected override void AddCell1(SqlDataReader drItem, XmlNode nd)
        {
            var newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
            newCol.InnerText = drItem.GetGuid(0).ToString();
            var attrName = docXml.CreateAttribute("name");
            attrName.Value = "tsitemuid";
            newCol.Attributes.Append(attrName);
            nd.AppendChild(newCol);

            newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
            newCol.InnerText = drItem.GetBoolean(1).ToString();
            attrName = docXml.CreateAttribute("name");
            attrName.Value = "submitted";
            newCol.Attributes.Append(attrName);
            nd.AppendChild(newCol);

            var newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            if (drItem.GetBoolean(1))
            {
                if (drItem.GetInt32(2) == 0)
                {
                    newCell.InnerXml = "<![CDATA[<img src=\"_layouts/images/yellow.gif\" alt=\"Submitted\">]]>";
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

            nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));
        }

        protected override void AddCell2(SqlDataReader drItem, XmlNode nd)
        {
            var newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = "";
            var attrStyle2 = docXml.CreateAttribute("style");
            attrStyle2.Value = "background: #" + bgcolor;
            newCell.Attributes.Append(attrStyle2);

            nd.InsertBefore(newCell, nd.SelectSingleNode("cell"));
        }

        protected override XmlNode CreateCell(DataSet dsTsHours, string ts_item_uid, string[] strworktypes, DateTime dt, ref double total)
        {
            var newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            XmlAttribute attr = docXml.CreateAttribute("type");
            attr.InnerText = "timeeditor";
            newCol.Attributes.Append(attr);
            foreach (string strWorkType in strworktypes)
            {


                DataRow[] drs = dsTSHours.Tables[0].Select("ts_item_uid = '" + ts_item_uid + "' and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyyy") + "# and tstype_id='" + strWorkType + "'");
                if (drs.Length > 0)
                {
                    total += double.Parse(drs[0]["TS_ITEM_HOURS"].ToString());
                    newCol.InnerText += "|" + strWorkType + "|" + double.Parse(drs[0]["TS_ITEM_HOURS"].ToString()).ToString();
                }
                else
                {
                    newCol.InnerText += "|" + strWorkType + "|0";
                }
            }

            return newCol;
        }
    }
}


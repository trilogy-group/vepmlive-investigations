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
        private const string TsUid = "ts_uid";
        private const string WebUid = "web_uid";
        private const string ListUid = "list_uid";
        private const string ItemId = "item_id";
        private const string UserName = "username";
        private const string ApprovalNotes = "approval_notes";
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

        private const string Width = "width";
        private const string TypeAttribute = "type";
        private const string TreeId = "tree";
        private const string Align = "align";
        private const string Color = "color";
        private const string Id = "id";
        private const string Column = "column";
        private const string UserData = "userdata[@name='{0}']";
        private const int ColumnStartIndex = 4;

        SPWeb resWeb = null;

        bool usecurrent = true;

        public override void Dispose()
        {
            if (resWeb != null)
            {
                if (resWeb.ID != SPContext.Current.Web.ID)
                {
                    resWeb.Close();
                }
            }

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

            SPSecurity.RunWithElevatedPrivileges(delegate ()
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
            if (arrGTemp == null)
            {
                throw new ArgumentNullException(nameof(arrGTemp));
            }
            if (curWeb == null)
            {
                throw new ArgumentNullException(nameof(curWeb));
            }
            if (resWeb == null)
            {
                return;
            }

            var spquery = new SPQuery
            {
                Query = "<Where><Eq><FieldRef Name='TimesheetManager'/><Value Type='User'><UserID/></Value></Eq></Where>"
            };

            var dtItems = new DataTable();
            dtItems.Columns.Add("WebId");
            dtItems.Columns.Add("ListId");
            dtItems.Columns.Add("ItemId");
            dtItems.Columns.Add("Username");
            dtItems.Columns.Add("Name");

            var resources = resWeb.Lists["Resources"];

            foreach (SPListItem listItem in resources.GetItems(spquery))
            {
                if (listItem["SharePointAccount"] != null)
                {
                    FillItems(arrGTemp, curWeb, dtItems, listItem);
                }
            }

            foreach (var dataRow in dtItems.Select(string.Empty, "WebId, ListId"))
            {
                try
                {
                    AddListItem(arrGTemp, dataRow);
                }
                catch (Exception ex)
                {
                    // here we catch more than few exceptions
                    // listing all of them might kill simplicty
                    Debug.WriteLine(ex);
                }
            }
        }

        private void FillItems(IDictionary arrGTemp, SPWeb curWeb, DataTable dtItems, SPListItem listItem)
        {
            if (arrGTemp == null)
            {
                throw new ArgumentNullException(nameof(arrGTemp));
            }
            if (dtItems == null)
            {
                throw new ArgumentNullException(nameof(dtItems));
            }
            if (listItem == null)
            {
                throw new ArgumentNullException(nameof(listItem));
            }
            var userValue = new SPFieldUserValue(curWeb, listItem["SharePointAccount"].ToString());
            if (userValue.User == null)
            {
                return;
            }

            var dataRowsTimeSheetTask = dsTimesheetTasks.Tables[0].Select($"username = '{userValue.User.LoginName}'");

            var dataRowsTimeSheet = dsTimesheets.Tables[0].Select($"username = '{userValue.User.LoginName} '");

            if (!arrGTemp.Contains(listItem.Title))
            {
                arrGTemp.Add(listItem.Title, string.Empty);
            }

            var newNode = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
            var attrId = docXml.CreateAttribute("id");
            attrId.InnerText = listItem.Title;
            newNode.Attributes.Append(attrId);

            var status = string.Empty;
            var notes = string.Empty;

            if (dataRowsTimeSheet.Length > 0)
            {
                AddColumn(newNode, dataRowsTimeSheet[0][TsUid].ToString(), "tsuid");
                string locked;
                GetValues(dataRowsTimeSheet, out status, out locked);
                AddColumn(newNode, locked, "nosub");
                notes = dataRowsTimeSheet[0][ApprovalNotes].ToString();
            }
            else
            {
                AddColumn(newNode, string.Empty, "tsuid");
                AddColumn(newNode, "1", "nosub");
            }

            AddCells(listItem, newNode, status, notes);

            ndMainParent.AppendChild(newNode);

            hshItemNodes.Add(listItem.Title, newNode);

            foreach (var dataRow in dataRowsTimeSheetTask)
            {
                var array = new string[] {
                    dataRow[WebUid].ToString(),
                    dataRow[ListUid].ToString(),
                    dataRow[ItemId].ToString(),
                    dataRow[UserName].ToString(),
                    listItem.Title };

                dtItems.Rows.Add(array);
            }
        }

        private void AddCells(SPListItem listItem, XmlNode newNode, string status, string notes)
        {
            if (listItem == null)
            {
                throw new ArgumentNullException(nameof(listItem));
            }
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }
            AddCell(newNode, string.Empty);
            AddCell(newNode, notes);

            var newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerXml = status;
            var attrStyle = docXml.CreateAttribute("style");
            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
            newCell.Attributes.Append(attrStyle);
            newNode.AppendChild(newCell);

            AddCell(newNode, string.Empty);

            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = listItem.Title;
            attrStyle = docXml.CreateAttribute("style");
            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
            newNode.Attributes.Append(attrStyle);
            newNode.AppendChild(newCell);
        }

        private static void GetValues(DataRow[] dataRowsTimeSheet, out string status, out string locked)
        {
            if (dataRowsTimeSheet == null || dataRowsTimeSheet.Length == 0)
            {
                throw new ArgumentException("Argument is empty collection", nameof(dataRowsTimeSheet));
            }
            status = string.Empty;
            locked = "0";

            if (dataRowsTimeSheet[0]["jobstatus"].ToString().ToLower() == "1")
            {
                switch (dataRowsTimeSheet[0]["jobtype_id"].ToString())
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
            else if (dataRowsTimeSheet[0]["jobstatus"].ToString().ToLower() == "0")
            {
                switch (dataRowsTimeSheet[0]["jobtype_id"].ToString())
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
            else if (dataRowsTimeSheet[0]["approval_status"].ToString().ToLower() == "1")
            {
                status = "<![CDATA[<img src=\"_layouts/images/green.gif\" alt=\"Approved\">]]>";
            }
            else if (dataRowsTimeSheet[0]["approval_status"].ToString().ToLower() == "2")
            {
                status = "<![CDATA[<img src=\"_layouts/images/red.gif\" alt=\"Rejected\">]]>";
            }
            else if (dataRowsTimeSheet[0]["submitted"].ToString().ToLower() == "true")
            {
                status = "<![CDATA[<img src=\"_layouts/images/yellow.gif\" alt=\"Submitted\">]]>";
            }
            else
            {
                locked = "1";
            }
        }

        private void AddColumn(XmlNode newNode, string innerText, string value)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }
            var newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
            newCol.InnerText = innerText;
            var attrName = docXml.CreateAttribute("name");
            attrName.Value = value;
            newCol.Attributes.Append(attrName);
            newNode.AppendChild(newCol);
        }

        private void AddCell(XmlNode newNode, string innerText)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }
            var newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = innerText;
            var attrStyle = docXml.CreateAttribute("style");
            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
            newCell.Attributes.Append(attrStyle);
            newNode.AppendChild(newCell);
        }

        private void AddListItem(SortedList arrGTemp, DataRow dataRow)
        {
            if (dataRow == null)
            {
                throw new ArgumentNullException(nameof(dataRow));
            }
            var webGuid = new Guid();
            var listGuid = new Guid();
            SPWeb iWeb = null;
            SPList iList = null;

            var wGuid = new Guid(dataRow[0].ToString());
            var lGuid = new Guid(dataRow[1].ToString());

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
            var listItem = iList.GetItemById(int.Parse(dataRow[2].ToString()));

            addTSItem(listItem, arrGTemp, dataRow[3].ToString(), dataRow[4].ToString());
        }

        protected override void outputXml()
        {
            var arrayList = new ArrayList();
            var workTypes = string.Empty;
            var timeEditor = false;
            var timeNotes = false;
            var filterHead = string.Empty;
            var ndCols = docXml.SelectNodes("//head/column");

            var columnCount = ndCols.Count;
            var strColumns = string.Empty;

            var web = site.RootWeb;
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
                    arrayList,
                    ref filterHead,
                    ref workTypes,
                    ref timeEditor,
                    ref timeNotes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            var ndHead = docXml.SelectSingleNode("//head");
            if (!usecurrent)
            {
                strColumns = GetColumns(ndHead);
            }

            AddColumnWork(ndHead);
            ndHead.RemoveChild(ndHead.SelectSingleNode("settings"));

            var strWorktypes = workTypes.Split('|');
            var rowCounter = 1;

            foreach (XmlNode rowNode in docXml.SelectNodes("//row"))
            {
                var ndListId = rowNode.SelectSingleNode(string.Format(UserData, "listid"));
                var ndItemId = rowNode.SelectSingleNode(string.Format(UserData, "itemid"));
                var ndTsuid = rowNode.SelectSingleNode(string.Format(UserData, "tsuid"));

                if (ndListId != null && ndItemId != null)
                {
                    var sql = "select ts_item_uid,submitted,approval_status,project from vwtstasks where list_uid=@listuid and item_id=@itemid and username=@username and period_id=@period_id";
                    AddCells(
                        rowNode,
                        site,
                        ndListId,
                        ndItemId,
                        period,
                        dsTSHours,
                        arrayList,
                        bgcolor,
                        usecurrent,
                        strColumns,
                        dsTimesheetTasks,
                        dsTimesheetMeta,
                        timeEditor,
                        strWorktypes,
                        timeNotes,
                        cn,
                        sql);
                }
                else
                {
                    AddCells(rowNode, bgcolor, arrayList);
                }
                rowNode.Attributes[Id].Value = rowCounter.ToString();
                rowCounter++;
            }

            var ndFilter = docXml.SelectSingleNode("//head/beforeInit/call[@command='attachHeader']");
            if (ndFilter != null)
            {
                var xml = ndFilter.FirstChild.InnerXml;
                xml = xml.Replace("<![CDATA[", "<![CDATA[&nbsp;,&nbsp;,&nbsp;,&nbsp;,")
                        .Replace($"gridfilter{gridname}('1", $"gridfilter{gridname}('2")
                        .Replace("]]>", $"{filterHead},&nbsp;]]>");
                ndFilter.FirstChild.InnerXml = xml;
            }

            UpdateHeadColumns(columnCount);

            cn.Close();

            data = docXml.OuterXml;
        }

        private void UpdateHeadColumns(int columnCount)
        {
            var fullWidth = double.Parse(Request[Width]);
            double reservedWidth = 0;

            var ndNewCols = docXml.SelectNodes("//head/column");
            for (var i = columnCount + 4; i < ndNewCols.Count; i++)
            {
                try
                {
                    var witdth = ndNewCols[i].Attributes[Width].Value;
                    reservedWidth += double.Parse(witdth);
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
            {
                fullWidth = 50;
            }

            for (var i = ColumnStartIndex; i <= columnCount + 3; i++)
            {
                var id = string.Empty;
                try
                {
                    id = ndNewCols[i].Attributes[TypeAttribute].Value;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                if (id == TreeId)
                {
                    ndNewCols[i].Attributes[Width].Value = (fullWidth * 2 - 10).ToString();
                }
                else
                {
                    ndNewCols[i].Attributes[Width].Value = fullWidth.ToString();
                    ndNewCols[i].Attributes[TypeAttribute].Value = "ro";
                }
            }
        }

        private void AddColumnWork(XmlNode ndHead)
        {
            if (ndHead == null)
            {
                throw new ArgumentNullException(nameof(ndHead));
            }

            var newColWork = docXml.CreateNode(XmlNodeType.Element, Column, docXml.NamespaceURI);
            newColWork.InnerXml = "<![CDATA[% Work Spent]]>";
            var attrTypeWork = docXml.CreateAttribute(TypeAttribute);
            attrTypeWork.Value = "percentwork";
            var attrWidthWork = docXml.CreateAttribute(Width);
            attrWidthWork.Value = "125";
            var attrAlignWork = docXml.CreateAttribute(Align);
            attrAlignWork.Value = "left";
            var attrColorWork = docXml.CreateAttribute(Color);
            attrColorWork.Value = "#F0F0F0";
            var attrIdWork = docXml.CreateAttribute(Id);
            attrIdWork.Value = "_PercentWork_";

            newColWork.Attributes.Append(attrTypeWork);
            newColWork.Attributes.Append(attrWidthWork);
            newColWork.Attributes.Append(attrAlignWork);
            newColWork.Attributes.Append(attrColorWork);
            newColWork.Attributes.Append(attrIdWork);

            ndHead.AppendChild(newColWork);
        }

        private static string GetColumns(XmlNode ndHead)
        {
            if (ndHead == null)
            {
                throw new ArgumentNullException(nameof(ndHead));
            }

            var stringBuilder = new StringBuilder();
            foreach (XmlNode nd in ndHead.SelectNodes(Column))
            {
                string id = string.Empty;
                try
                {
                    id = nd.Attributes[Id].Value;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                stringBuilder.AppendFormat(",{0}", id);
            }
            var strColumns = stringBuilder.ToString().Substring(1);
            return strColumns;
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
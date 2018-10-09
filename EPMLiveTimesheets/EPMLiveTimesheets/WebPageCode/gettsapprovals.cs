using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;

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

            var strPeriod = Request["period"];
            period = int.Parse(strPeriod);
            base.inEditMode = false;
            var resUrl = string.Empty;

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
                        using (var tempSite = new SPSite(resUrl))
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

            InitializeTimSheets(curWeb.Site.ID);
        }

        private void InitializeTimSheets(Guid siteId)
        {
            var sql = "select ts_uid,username,submitted,approval_status,approval_notes,resourcename,jobstatus,jobtype_id from vwTSTimesheetWQueue where period_id=@period_id and site_uid=@siteid";
            dsTimesheets = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select hours,ts_item_date,ts_uid from vwTSTimesheetTotals where period_id=@period_id and site_uid=@siteid";
            dsTimesheetTotals = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select title,project,ts_uid,web_uid,list_uid,item_id,ts_item_uid,approval_status,resourcename,username from vwTSTasks where period_id=@period_id and site_uid=@siteid order by project";
            dsTimesheetTasks = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select Hours,ts_item_date,ts_item_uid,ts_item_type_id from vwTSHoursByTask where period_id=@period_id and site_uid=@siteid";
            dsTimesheetTaskHours = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select tstype_id from TSTYPE where site_uid=@siteid";
            dsTimesheetTypes = DataSetUtils.CreateDataSet(cn, sql, period, siteId); 
            
            sql = "select ts_item_uid,ts_item_notes,ts_item_date from vwTSNotes where period_id=@period_id and site_uid=@siteid";
            dsTimesheetNotes = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select ts_item_uid,columnname,columnvalue from vwTSItemMeta where period_id=@period_id and site_uid=@siteid";
            dsTimesheetMeta = DataSetUtils.CreateDataSet(cn, sql, period, siteId);            
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
            var group = new string[1] { null };

            group[0] = resource;

            ProcessGroupFields(arrGroupFields, li, group, arrGTemp);

            var it = new AddItemType
            {
                indexer = li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID + "." + username,
                o = li
            };
            arrItems.Add(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID + "." + username, group);
            queueAllItems.Enqueue(it);
        }

        protected override void AddColumn2(XmlNode nd, ArrayList arr)
        {
            XmlNode newCell;
            XmlAttribute attrStyle2;

            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCell.InnerText = string.Empty;
            var attrType = docXml.CreateAttribute("type");
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
            foreach (var strWorkType in strworktypes)
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
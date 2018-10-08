using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using Microsoft.SharePoint;
using TimeSheets.WebPageCode;
using SystemTrace = System.Diagnostics.Trace;


namespace TimeSheets
{
    public partial class getts : System.Web.UI.Page
    {
        private const string True = "True";
        private const string TypeConst = "type";
        private const string Ro = "ro";
        private const string One = "1";
        private const string Style = "style";
        private const string Id = "id";
        private const string Open = "open";
        private const string Row = "row";
        private const string TsUid = "ts_uid";
        private const string Cell = "cell";
        private const string Name = "name";
        private const string TsItemUid = "ts_item_uid";
        private const string TimeEditor = "timeeditor";
        private const string TsTypeId = "tstype_id";
        private const string Hours = "hours";
        private const string TsItemNotes = "ts_item_notes";
        private const string Zero = "0";
        private const string Dot = ".";
        private const string Two = "2";
        XmlDocument docXml = new XmlDocument();
        XmlNode ndMainParent;
        protected string data = string.Empty;
        private string period = string.Empty;
        private DateTime periodStart;
        private DateTime periodEnd;
        private DataSet dsTimesheets;
        private DataSet dsTimesheetTotals;
        private DataSet dsTimesheetTasks;
        private DataSet dsTimesheetTaskHours;
        private DataSet dsTimesheetTypes;
        private DataSet dsTimesheetNotes;
        private string[] dayDefs;
        SPList list;
        //SPView view;

        private Hashtable hshLists = new Hashtable();
        private Hashtable hshItemNodes = new Hashtable();
        private Hashtable hshResNodes = new Hashtable();
        protected SortedList arrItems = new SortedList();
        protected Queue queueAllItems = new Queue();

        XmlNode ndBeforeInit;

        SqlConnection cn;

        protected string[] arrGroupFields;
        private string Project;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            period = Request["period_id"];

            docXml.LoadXml("<rows></rows>");
            ndMainParent = docXml.ChildNodes[0];

            SPWeb web = SPContext.Current.Web;
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    try
                    {
                        cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        cn.Open();
                    }
                    catch { }
                });



                string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                SPWeb resWeb = null;
                if (resUrl != string.Empty)
                {
                    if (resUrl.ToLower() != web.Url.ToLower())
                    {
                        SPSite tempSite = new SPSite(resUrl);

                        resWeb = tempSite.OpenWeb();
                        if (resWeb.Url.ToLower() != resUrl.ToLower())
                        {
                            resWeb = null;
                        }
                        tempSite.Close();
                    }
                    else
                        resWeb = web;
                    if (resWeb != null)
                    {
                        list = resWeb.Lists["Resources"];
                        addHeader(web);
                        addGroups(resWeb);
                    }
                    if (resWeb.ID != SPContext.Current.Web.ID)
                        resWeb.Close();
                }
                cn.Close();
            }

            data = docXml.OuterXml;
        }

        private void addHeader(SPWeb curWeb)
        {
            var ndHead = docXml.CreateNode(XmlNodeType.Element, "head", docXml.NamespaceURI);
            docXml.ChildNodes[0].AppendChild(ndHead);
            ndBeforeInit = docXml.CreateNode(XmlNodeType.Element, "beforeInit", docXml.NamespaceURI);
            ndHead.AppendChild(ndBeforeInit);
            var afterInitNode = docXml.CreateNode(XmlNodeType.Element, "afterInit", docXml.NamespaceURI);
            ndHead.AppendChild(afterInitNode);

            AddColumns(ndHead);

            var sql = "select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@siteid";
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@period_id", period);
                cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
                using (var dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        periodStart = dataReader.GetDateTime(0);
                        periodEnd = dataReader.GetDateTime(1);
                    }
                }
            }

            dayDefs = EPMLiveCore.CoreFunctions.getConfigSetting(curWeb.Site.RootWeb, "EPMLiveDaySettings").Split('|');

            var timeSpan = periodEnd - periodStart;
            for (var day = 0; day <= timeSpan.Days; day++)
            {
                var showDay = string.Empty;
                try
                {
                    showDay = dayDefs[((int)periodStart.AddDays(day).DayOfWeek) * 3];
                }
                catch (Exception ex)
                {
                    SystemTrace.WriteLine(ex.ToString());
                }
                if (showDay == True)
                {
                    var newCol = AddNewColumn(day);

                    ndHead.AppendChild(newCol);
                }
            }

            var newColumn = AddNewColumn();

            ndHead.AppendChild(newColumn);

            InitializeTimSheets(curWeb.Site.ID);
        }

        private void AddColumns(XmlNode ndHead)
        {
            var ndNewColumn = AddNewColumn("#master_checkbox", "ch", "20", "center");
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = AddNewColumn("<![CDATA[Notes]]>", "tsnotes", "50", "center");
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = AddNewColumn("<![CDATA[Resource Name]]>", "tree", "*", "left");
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = AddNewColumn("<![CDATA[TM]]>", Ro, "35", "center");
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = AddNewColumn("<![CDATA[PM]]>", Ro, "35", "center");
            ndHead.AppendChild(ndNewColumn);
        }

        private XmlNode AddNewColumn(string innerXm, string typeValue, string withdValue, string alignValue)
        {
            XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerXml = innerXm;

            var attrType = docXml.CreateAttribute(TypeConst);
            attrType.Value = typeValue;
            var attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = withdValue;
            var attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = alignValue;

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            return ndNewColumn;
        }

        private XmlNode AddNewColumn(int days)
        {
            XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            newCol.InnerXml = "<![CDATA[" + periodStart.AddDays(days).DayOfWeek.ToString().Substring(0, 3) + "<br>" + periodStart.AddDays(days).Day + "]]>";
            var attrType = docXml.CreateAttribute(TypeConst);
            attrType.Value = "ro[=sum]";
            var attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "40";
            var attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "right";
            var attrId = docXml.CreateAttribute(Id);
            attrId.Value = "_TsDate_" + periodStart.AddDays(days).ToShortDateString().Replace("/", "_"); ;

            newCol.Attributes.Append(attrType);
            newCol.Attributes.Append(attrWidth);
            newCol.Attributes.Append(attrAlign);
            newCol.Attributes.Append(attrId);
            return newCol;
        }

        private XmlNode AddNewColumn()
        {
            var newColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            newColumn.InnerXml = "Total";
            var attrType = docXml.CreateAttribute(TypeConst);
            attrType.Value = "ro[=sum]";
            var attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "60";
            var attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "right";
            var attrId = docXml.CreateAttribute(Id);
            attrId.Value = "Total";

            newColumn.Attributes.Append(attrType);
            newColumn.Attributes.Append(attrWidth);
            newColumn.Attributes.Append(attrAlign);
            newColumn.Attributes.Append(attrId);
            return newColumn;
        }

        private void InitializeTimSheets(Guid siteId)
        {
            var sql = "select ts_uid,username,submitted,approval_status,approval_notes from TSTIMESHEET where period_id=@period_id and site_uid=@siteid";
            dsTimesheets = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select hours,ts_item_date,ts_uid from vwTSTimesheetTotals where period_id=@period_id and site_uid=@siteid";
            dsTimesheetTotals = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select title,project,ts_uid,ts_item_uid,approval_status from vwTSTasks where period_id=@period_id and site_uid=@siteid order by project";
            dsTimesheetTasks = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select Hours,ts_item_date,ts_item_uid,ts_item_type_id from vwTSHoursByTask where period_id=@period_id and site_uid=@siteid";
            dsTimesheetTaskHours = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select tstype_id from TSTYPE where site_uid=@siteid";
            dsTimesheetTypes = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select ts_item_uid,ts_item_notes,ts_item_date from vwTSNotes where period_id=@period_id and site_uid=@siteid";
            dsTimesheetNotes = DataSetUtils.CreateDataSet(cn, sql, period, siteId);
        }

        private void addGroups(SPWeb curWeb)
        {
            var arrGTemp = new SortedList();

            processList(curWeb, arrGTemp);

            var timeSpan = periodEnd - periodStart;

            foreach (DictionaryEntry entry in arrGTemp)
            {
                var newItem = entry.Key.ToString();
                var parentInd = newItem.LastIndexOf("\n");
                var parent = string.Empty;

                if (parentInd >= 0)
                {
                    parent = newItem.Substring(0, parentInd);
                    newItem = newItem.Substring(parentInd + 1);
                }

                if ((hshItemNodes.Contains(parent) && !hshItemNodes.Contains(entry.Key.ToString())) || 
                    (parentInd == -1 && !hshItemNodes.Contains(entry.Key.ToString())))
                {
                    var parentNode = (parentInd == -1)
                        ? ndMainParent
                        : (XmlNode)hshItemNodes[parent];

                    var newNode = docXml.CreateNode(XmlNodeType.Element, Row, docXml.NamespaceURI);
                    AppendChilds(entry.Key.ToString(), newItem, parentNode, newNode);

                    for (var i = 0; i <= timeSpan.Days; i++)
                    {
                        var showDay = string.Empty;
                        try
                        {
                            showDay = dayDefs[((int)periodStart.AddDays(i).DayOfWeek) * 3];
                        }
                        catch (Exception ex)
                        {
                            SystemTrace.WriteLine(ex.ToString());
                        }
                        if (showDay == True)
                        {
                            AppendChild(newNode, string.Empty);
                        }
                    }

                    hshItemNodes.Add(entry.Key.ToString(), newNode);
                }
            }

            while (queueAllItems.Count > 0)
            {
                var listItem = (SPListItem)queueAllItems.Dequeue();
                if (arrItems.Contains(listItem.ID.ToString()))
                {
                    ProcessListItem(curWeb, timeSpan, listItem);
                }
            }
        }

        private void AppendChilds(string entryKey, string newItem, XmlNode parentNode, XmlNode newNode)
        {
            if (parentNode == null)
            {
                throw new ArgumentNullException(nameof(parentNode));
            }

            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }

            var attrId = docXml.CreateAttribute(Id);

            if (!string.IsNullOrWhiteSpace(entryKey))
            {
                attrId.Value = entryKey;
            }
            else
            {
                attrId.Value = Guid.NewGuid().ToString();
            }

            newNode.Attributes.Append(attrId);

            AppendAttribute(newNode, "locked", One);

            AppendAttribute(newNode, Open, One);
            
            parentNode.AppendChild(newNode);

            AppendChild(newNode, TypeConst, Ro);
            AppendChild(newNode, TypeConst, Ro);

            var newCell = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);
            newCell.InnerText = string.IsNullOrWhiteSpace(newItem) ? "No Value" : newItem;
            newNode.AppendChild(newCell);

            AppendAttribute(newNode, Style, "font-weight:bold;background: #B6C8ED");
            AppendChild(newNode, string.Empty);
        }

        private void ProcessListItem(SPWeb curWeb, TimeSpan timeSpan, SPListItem listItem)
        {
            if (listItem == null)
            {
                throw new ArgumentNullException(nameof(listItem));
            }

            var resName = listItem.Title;
            var realName = string.Empty;
            var loginName = string.Empty;
            try
            {
                var userValue = new SPFieldUserValue(curWeb, listItem["SharePointAccount"].ToString());
                loginName = userValue.User.LoginName;
                realName = userValue.User.Name;
            }
            catch (Exception ex)
            {
                SystemTrace.WriteLine(ex.ToString());
            }

            var dataRows = dsTimesheets.Tables[0].Select("username like '" + loginName + "'");

            if (!string.IsNullOrWhiteSpace(loginName) && dataRows.Length > 0)
            {
                var groupName = string.Empty;
                if (arrItems[listItem.ID.ToString()] == null)
                {
                    groupName = loginName;
                }
                else
                {
                    groupName = arrItems[listItem.ID.ToString()] + "\n" + loginName;
                }

                var newItem = groupName;
                var parentInd = newItem.LastIndexOf("\n");
                var parent = string.Empty;

                if (parentInd >= 0)
                {
                    parent = newItem.Substring(0, parentInd);
                    newItem = newItem.Substring(parentInd + 1);
                }

                if ((hshItemNodes.Contains(parent) && !hshItemNodes.Contains(groupName)) || 
                    (parentInd == -1 && !hshItemNodes.Contains(groupName)))
                {
                    ProcessNodes(
                        timeSpan,
                        listItem.ID.ToString(),
                        resName,
                        realName,
                        loginName,
                        dataRows,
                        groupName,
                        parentInd,
                        parent);
                }
            }
        }

        private void ProcessNodes(
            TimeSpan timeSpan,
            string listItemId,
            string resName,
            string realName,
            string loginName,
            DataRow[] dataRows,
            string groupName,
            int parentInd,
            string parent)
        {
            if (dataRows == null)
            {
                throw new ArgumentNullException(nameof(dataRows));
            }

            var parentNode = (parentInd == -1)
                ? ndMainParent
                : (XmlNode)hshItemNodes[parent];

            var newNode = docXml.CreateNode(XmlNodeType.Element, Row, docXml.NamespaceURI);

            AppendChilds(listItemId, resName, realName, dataRows, parentNode, newNode);

            for (var days = 0; days <= timeSpan.Days; days++)
            {
                var showDay = string.Empty;
                try
                {
                    showDay = dayDefs[((int)periodStart.AddDays(days).DayOfWeek) * 3];
                }
                catch (Exception ex)
                {
                    SystemTrace.WriteLine(ex.ToString());
                }
                if (showDay == True)
                {
                    AppendChild(newNode, string.Empty);
                }
            }

            var drTasks = dsTimesheetTasks.Tables[0].Select("ts_uid = '" + dataRows[0][TsUid] + "'");
            var regex = new Regex("[^0-9a-zA-Z]+", RegexOptions.Compiled);
            foreach (DataRow drTask in drTasks)
            {
                ProcessTask(timeSpan, listItemId, newNode, regex, drTask);
            }

            if (!hshItemNodes.Contains(groupName))
            {
                hshItemNodes.Add(groupName, newNode);
            }

            if (!hshResNodes.Contains(loginName))
            {
                hshResNodes.Add(loginName, newNode);
            }
        }

        private void AppendChilds(string listItemId, string resName, string realName, DataRow[] dataRows, XmlNode parentNode, XmlNode newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }

            if (parentNode == null)
            {
                throw new ArgumentNullException(nameof(parentNode));
            }

            if (dataRows == null)
            {
                throw new ArgumentNullException(nameof(dataRows));
            }

            AppendAttribute(newNode, Id, listItemId);

            var attrExpand = docXml.CreateAttribute(Open);
            parentNode.AppendChild(newNode);

            var newCell = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);
            newNode.AppendChild(newCell);

            var ndNotes = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);
            newNode.AppendChild(ndNotes);

            newCell = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);
            newCell.InnerText = resName.Equals(realName, StringComparison.InvariantCultureIgnoreCase)
                ? resName
                : resName + " (" + realName + ")";
            newNode.AppendChild(newCell);

            var attrStyle = docXml.CreateAttribute(Style);
            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
            newNode.Attributes.Append(attrStyle);

            newCell = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);

            ndNotes.InnerText = dataRows[0]["approval_notes"].ToString();

            AppendChild(newNode, Name, "tsuid", dataRows[0][TsUid].ToString());

            var approvalStatus = dataRows[0]["approval_status"].ToString();
            if (approvalStatus.Equals(One, StringComparison.OrdinalIgnoreCase))
            {
                newCell.InnerXml = "<![CDATA[<img src=\"images/tsflaggreen.gif\" alt=\"Approved\">]]>";
            }
            else if (approvalStatus.Equals(Two, StringComparison.OrdinalIgnoreCase))
            {
                newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagred.gif\" alt=\"Rejected\">]]>";
            }
            else if (dataRows[0]["submitted"].ToString().Equals(True, StringComparison.OrdinalIgnoreCase))
            {
                newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagyellow.gif\" alt=\"Submitted\">]]>";
            }
            else
            {
                newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagblue.gif\" alt=\"Saved\">]]>";
            }
            newNode.AppendChild(newCell);

            AppendChild(newNode, Name, "Status", newCell.InnerText);
        }

        private void ProcessTask(TimeSpan timeSpan, string listItemId, XmlNode newNode, Regex regex, DataRow drTask)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }

            if (drTask == null)
            {
                throw new ArgumentNullException(nameof(drTask));
            }

            var curProject = string.Empty;
            XmlNode projectNode = null;

            Project = "project";
            if (!string.IsNullOrWhiteSpace(drTask[Project].ToString()))
            {
                projectNode = docXml.CreateNode(XmlNodeType.Element, Row, docXml.NamespaceURI);
                curProject = drTask[Project].ToString();

                ProcessProject(timeSpan, listItemId, newNode, regex, curProject, projectNode);
            }

            var taskNode = docXml.CreateNode(XmlNodeType.Element, Row, docXml.NamespaceURI);

            var attrId = docXml.CreateAttribute(Id);
            attrId.Value = listItemId + Dot + regex.Replace(curProject, string.Empty) + Dot + regex.Replace(drTask["title"].ToString(), string.Empty);
            taskNode.Attributes.Append(attrId);

            AppendChild(taskNode, TypeConst, Ro);
            AppendChild(taskNode, TypeConst, Ro);

            AppendChild(taskNode, drTask["title"].ToString());
            AppendChild(taskNode, string.Empty);

            var newCell = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);
            switch (drTask["APPROVAL_STATUS"].ToString())
            {
                case Zero:
                    newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagwhite.gif\" alt=\"Pending\">]]>";
                    break;
                case One:
                    newCell.InnerXml = "<![CDATA[<img src=\"images/tsflaggreen.gif\" alt=\"Approved\">]]>";
                    break;
                case Two:
                    newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagred.gif\" alt=\"Rejected\">]]>";
                    break;
            };
            taskNode.AppendChild(newCell);

            double total = 0;

            for (var i = 0; i <= timeSpan.Days; i++)
            {
                ProcessDay(drTask, taskNode, out total, i);
            }

            AppendChild(taskNode, total.ToString());

            projectNode.AppendChild(taskNode);
        }

        private void ProcessProject(TimeSpan timeSpan, string listItemId, XmlNode newNode, Regex regex, string curProject, XmlNode projectNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }
            if (projectNode == null)
            {
                throw new ArgumentNullException(nameof(projectNode));
            }
            var attrId = docXml.CreateAttribute(Id);
            attrId.Value = listItemId + Dot + regex.Replace(curProject, string.Empty);
            projectNode.Attributes.Append(attrId);

            var attrExpand = docXml.CreateAttribute(Open);
            attrExpand.Value = One;
            projectNode.Attributes.Append(attrExpand);

            newNode.AppendChild(projectNode);

            AppendChild(projectNode, TypeConst, Ro);
            AppendChild(projectNode, TypeConst, Ro);

            AppendChild(projectNode, curProject);
            AppendChild(projectNode, string.Empty);
            AppendChild(projectNode, string.Empty);

            for (var days = 0; days <= timeSpan.Days; days++)
            {
                var showday = string.Empty;
                try
                {
                    showday = dayDefs[((int)periodStart.AddDays(days).DayOfWeek) * 3];
                }
                catch (Exception ex)
                {
                    SystemTrace.WriteLine(ex.ToString());
                }
                if (showday == True)
                {
                    AppendChild(projectNode, string.Empty);
                }
            }

            AppendAttribute(projectNode, Style, "font-weight:bold;");
        }

        private void ProcessDay(DataRow drTask, XmlNode taskNode, out double total, int days)
        {
            if (drTask == null)
            {
                throw new ArgumentNullException(nameof(drTask));
            }

            if (taskNode == null)
            {
                throw new ArgumentNullException(nameof(taskNode));
            }

            total = 0;
            var showDay = string.Empty;
            try
            {
                showDay = dayDefs[((int)periodStart.AddDays(days).DayOfWeek) * 3];
            }
            catch (Exception ex)
            {
                SystemTrace.WriteLine(ex.ToString());
            }
            if (showDay == True)
            {
                var drTaskTimes = dsTimesheetTaskHours.Tables[0].Select("ts_item_uid='" + drTask[TsItemUid] + "' and ts_item_date = '" + periodStart.AddDays(days) + "'");
                var drTaskNotes = dsTimesheetNotes.Tables[0].Select("ts_item_uid='" + drTask[TsItemUid] + "' and ts_item_date = '" + periodStart.AddDays(days) + "'");

                var newCell = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);
                var hours = string.Empty;

                if (dsTimesheetTypes.Tables[0].Rows.Count > 0)
                {
                    GetHoursTotal(newCell, drTask, drTaskNotes, days, out total, out hours);
                }
                else
                {
                    GetHoursTotal(newCell, drTaskTimes, drTaskNotes, out total, out hours);
                }

                newCell.InnerText = hours;

                taskNode.AppendChild(newCell);
            }
        }

        private void GetHoursTotal(XmlNode newCell, DataRow drTask, DataRow[] drTaskNotes, int days, out double total, out string hours)
        {
            if (drTask == null)
            {
                throw new ArgumentNullException(nameof(drTask));
            }

            if (drTaskNotes == null)
            {
                throw new ArgumentNullException(nameof(drTaskNotes));
            }

            total = 0;
            hours = string.Empty;

            AppendAttribute(newCell, TypeConst, TimeEditor);

            foreach (DataRow drType in dsTimesheetTypes.Tables[0].Rows)
            {
                var drTaskTypeTime = dsTimesheetTaskHours.Tables[0].Select("ts_item_uid='" + drTask[TsItemUid] + "' and ts_item_date = '" + periodStart.AddDays(days) + "' and ts_item_type_id=" + drType[TsTypeId]);
                if (drTaskTypeTime.Length > 0)
                {
                    hours += "|" + drType[TsTypeId] + "|" + drTaskTypeTime[0][Hours];
                    try
                    {
                        total += double.Parse(drTaskTypeTime[0][Hours].ToString());
                    }
                    catch (Exception ex)
                    {
                        SystemTrace.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    hours += "|" + drType[TsTypeId] + "|0";
                }
            }
            hours = hours.Substring(1);
            if (drTaskNotes.Length > 0)
            {
                hours += "|N|" + drTaskNotes[0][TsItemNotes].ToString();
            }
        }

        private void GetHoursTotal(XmlNode newCell, DataRow[] drTaskTimes, DataRow[] drTaskNotes, out double total, out string hours)
        {
            if (drTaskTimes == null)
            {
                throw new ArgumentNullException(nameof(drTaskTimes));
            }

            if (drTaskNotes == null)
            {
                throw new ArgumentNullException(nameof(drTaskNotes));
            }

            total = 0;
            hours = drTaskTimes.Length > 0 
                ? drTaskTimes[0][Hours].ToString() 
                : Zero;

            if (!double.TryParse(hours, out total))
            {
                SystemTrace.WriteLine($"Unable to parse double from string '{hours}'");
            }
            
            if (drTaskNotes.Length > 0)
            {
                AppendAttribute(newCell, TypeConst, TimeEditor);

                hours = "0|" + hours + "|N|" + drTaskNotes[0][TsItemNotes].ToString();
            }
        }

        private void AppendAttribute(XmlNode xmlNode, string attrType, string attValue)
        {
            if (xmlNode == null)
            {
                throw new ArgumentNullException(nameof(xmlNode));
            }
            var attrTType = docXml.CreateAttribute(attrType);
            attrTType.Value = attValue;
            xmlNode.Attributes.Append(attrTType);
        }

        private void AppendChild(XmlNode xmlNode, string innterText)
        {
            if (xmlNode == null)
            {
                throw new ArgumentNullException(nameof(xmlNode));
            }

            var newCell = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);
            newCell.InnerText = innterText;
            xmlNode.AppendChild(newCell);
        }

        private void AppendChild(XmlNode xmlNode, string attrType, string attValue)
        {
            if (xmlNode == null)
            {
                throw new ArgumentNullException(nameof(xmlNode));
            }

            var newCell = docXml.CreateNode(XmlNodeType.Element, Cell, docXml.NamespaceURI);
            var attrTType = docXml.CreateAttribute(attrType);
            attrTType.Value = attValue;
            newCell.Attributes.Append(attrTType);
            xmlNode.AppendChild(newCell);
        }

       private void AppendChild(XmlNode xmlNode, string attrType, string attValue, string innerText)
        {
           if (xmlNode == null)
           {
               throw new ArgumentNullException(nameof(xmlNode));
           }

           var ndStatus = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
            var attrName = docXml.CreateAttribute(attrType);
            attrName.Value = attValue;
            ndStatus.InnerText = innerText;
            ndStatus.Attributes.Append(attrName);
            xmlNode.AppendChild(ndStatus);
        }

        protected void processList(SPWeb web, SortedList arrGTemp)
        {
            try
            {
                SPQuery query = new SPQuery();
                query.Query = "<OrderBy><FieldRef Name = 'FirstName' Ascending = 'True'/><FieldRef Name = 'LastName' Ascending = 'True'/></OrderBy>";
                SPListItemCollection listItems = list.GetItems(query);
                if (listItems != null && listItems.Count > 0)
                {
                    foreach (SPListItem li in listItems)
                    {
                        string group = null;
                        if (arrGroupFields != null)
                        {
                            foreach (string groupby in arrGroupFields)
                            {
                                SPField field = list.Fields.GetFieldByInternalName(groupby);
                                string newgroup = field.GetFieldValueAsText(li[field.Id].ToString());

                                if (group == null)
                                    group = newgroup;
                                else
                                    group += "\n" + newgroup;

                                if (!arrGTemp.Contains(group))
                                {
                                    arrGTemp.Add(group, string.Empty);
                                }
                            }
                        }

                        arrItems.Add(li.ID.ToString(), group);
                        queueAllItems.Enqueue(li);
                    }
                }
            }
            catch { }
        }

        private SPField getRealField(SPField field)
        {
            try
            {
                if (field.Type == SPFieldType.Computed)
                {
                    {
                        XmlDocument fieldXml = new XmlDocument();
                        fieldXml.LoadXml(field.SchemaXml);

                        string parentField = string.Empty;
                        try
                        {
                            parentField = fieldXml.FirstChild.Attributes["DisplayNameSrcField"].Value;
                        }
                        catch { }
                        if (parentField != string.Empty)
                        {
                            try
                            {
                                field = field.ParentList.Fields.GetFieldByInternalName(parentField);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
            return field;
        }
    }
}

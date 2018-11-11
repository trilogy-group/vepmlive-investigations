using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml;
using EPMLiveCore;
using Microsoft.SharePoint;
using SystemTrace = System.Diagnostics.Trace;

namespace TimeSheets
{
    public partial class getts : Page
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

        protected string[] arrGroupFields;
        protected SortedList arrItems = new SortedList();

        private SqlConnection cn;
        protected string data = string.Empty;
        private string[] dayDefs;
        private readonly XmlDocument docXml = new XmlDocument();
        private DataSet dsTimesheetNotes;
        private DataSet dsTimesheets;
        private DataSet dsTimesheetTaskHours;
        private DataSet dsTimesheetTasks;
        private DataSet dsTimesheetTotals;
        private DataSet dsTimesheetTypes;
        private readonly Hashtable hshItemNodes = new Hashtable();

        private Hashtable hshLists = new Hashtable();
        private readonly Hashtable hshResNodes = new Hashtable();
        private SPList list;

        private XmlNode ndBeforeInit;
        private XmlNode ndMainParent;
        private string period = string.Empty;
        private DateTime periodEnd;
        private DateTime periodStart;
        private string Project;
        protected Queue queueAllItems = new Queue();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = Encoding.UTF8;

            period = Request["period_id"];

            docXml.LoadXml("<rows></rows>");
            ndMainParent = docXml.ChildNodes[0];

            var web = SPContext.Current.Web;
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    try
                    {
                        cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        cn.Open();
                    }
                    catch (Exception ex)
                    {
                        SystemTrace.WriteLine(ex.ToString());
                    }
                });

                var resUrl = CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                if (resUrl != string.Empty)
                {
                    SPWeb resWeb;
                    if (!string.Equals(resUrl, web.Url, StringComparison.InvariantCultureIgnoreCase))
                    {
                        using (var tempSite = new SPSite(resUrl))
                        {
                            resWeb = tempSite.OpenWeb();
                            if (resWeb.Url.ToLower() != resUrl.ToLower())
                            {
                                resWeb = null;
                            }
                        }
                    }
                    else
                    {
                        resWeb = web;
                    }
                    if (resWeb != null)
                    {
                        list = resWeb.Lists["Resources"];
                        addHeader(web);
                        addGroups(resWeb);
                    }
                    if (resWeb?.ID != SPContext.Current.Web.ID)
                    {
                        resWeb?.Close();
                    }
                }
                cn.Close();
            }

            data = docXml.OuterXml;
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
                : $"{resName} ({realName})";
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
            var status = drTask["APPROVAL_STATUS"].ToString();
            switch (status)
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
                default:
                    SystemTrace.WriteLine($"ArgumentOutOfRangeException: {status}");
                    break;
            }
            
            taskNode.AppendChild(newCell);

            double daystotal = 0;
            double total = 0;

            for (var i = 0; i <= timeSpan.Days; i++)
            {
                ProcessDay(drTask, taskNode, out total, i);
                daystotal += total;
            }

            AppendChild(taskNode, daystotal.ToString());

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
                    showday = dayDefs[(int)periodStart.AddDays(days).DayOfWeek * 3];
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
                showDay = dayDefs[(int)periodStart.AddDays(days).DayOfWeek * 3];
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
                hours += "|N|" + drTaskNotes[0][TsItemNotes];
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

                hours = "0|" + hours + "|N|" + drTaskNotes[0][TsItemNotes];
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
    }
}
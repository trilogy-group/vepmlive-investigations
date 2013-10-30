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

namespace EPMLiveWebParts
{
    public partial class getgriditems : System.Web.UI.Page
    {
        private const int MAX_LOOKUPFILTER = 300;

        protected XmlDocument docXml;

        //protected SPWeb curWeb;
        protected string data = "";
        protected bool isTimesheet = false;
        bool titleFieldFound = false;

        protected SPList list = null;
        protected SPView view = null;

        protected string strlist;
        protected string strview;
        protected string usewbs;
        protected string executive;
        protected string linktype;
        protected string[] rollupsites;
        protected string[] rolluplists;
        protected string gridname;
        protected string additionalgroups;
        protected int expandlevel;
        protected bool inEditMode = false;
        protected bool showinsertrow;
        protected bool usePerformance;
        protected bool usePopup;
        protected bool requestsenabled;
        protected bool showCheckboxes;
        protected int iPageSize = 0;
        protected int iPage = 0;
        protected string WPID = "";

        protected string expanded;

        protected string filterfield;
        protected string filtervalue;

        protected string lookupFilterField;
        protected string lookupFilterFieldList;
        protected ArrayList lookupFilterIDs = new ArrayList();
        protected ArrayList reportFilterIDs = new ArrayList();
        protected string reportFilterField = "";

        protected string sSearchField = "";
        protected string sSearchValue = "";
        protected string sSearchType = "";

        private SortedList hshGroups = new SortedList();
        protected string[] arrGroupFields;

        protected string globalError = "";

        protected bool bCleanValues = false;

        protected string ReportID = "";

        private bool bUseReporting = false;

        private struct PlannerMenus
        {
            public bool agile;
            public bool workplan;
            public bool project;
        }

        private Dictionary<Guid, PlannerMenus> hshMenus = new Dictionary<Guid, PlannerMenus>();

        protected struct AddItemType
        {
            public string indexer;
            public object o;
        }

        protected Queue queueAllItems = new Queue();
        protected SortedList arrItems = new SortedList();
        protected Hashtable hshItemNodes = new Hashtable();
        private int treeCol = 0;
        private SortedList arrAggregationDef = new SortedList();
        private SortedList arrAggregationVals = new SortedList();
        private Hashtable hshWBS = new Hashtable();
        private SortedList arrGroupMin = new SortedList();
        private SortedList arrGroupMax = new SortedList();
        protected XmlNode ndMainParent;
        private Hashtable hshLists = new Hashtable();
        private Hashtable hshColumnSelectFilter = new Hashtable();
        private Hashtable hshFieldProperties = new Hashtable();
        //=========================Data=========
        private ArrayList arrColumns = new ArrayList();
        private XmlNode ndBeforeInit;
        //======================================
        private Hashtable hshComboCells = new Hashtable();
        //======================================
        System.Globalization.NumberFormatInfo providerEn = new System.Globalization.NumberFormatInfo();

        protected bool isResPlan = false;
        private XmlNode ndNewRowCells;
        private bool hasGroups = false;

        private string LookupFilterField = "";
        private string LookupFilterValue = "";

        protected string StartDateField = "";
        protected string DueDateField = "";
        protected string ProgressField = "";
        protected string InfoField = "";

        protected virtual void outputXml()
        {
            if (inEditMode && rolluplists == null && showinsertrow)
            {
                SPListItem li = list.Items.Add();
                arrItems.Add(li.ParentList.ID + ".0", new string[1] { null });
                addItem(li, li.ParentList.ID + ".0");

                XmlNode ndRow = docXml.SelectSingleNode("//row[@id='" + li.ParentList.ID + ".0.1']");
                ndRow.Attributes["id"].Value = "_NEWROW_";
                ndRow.SelectSingleNode("cell").InnerXml = "<![CDATA[<img src='/_layouts/images/newitem.GIF' border='0'>]]>";

                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "isNewRow";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = "1";
                ndRow.AppendChild(ndSiteUrl);

                //XmlNode ndRows = docXml.SelectSingleNode("/rows");
                //XmlNode ndRow = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
                //XmlAttribute attrId = docXml.CreateAttribute("id");
                //attrId.Value = "_NEW_";
                //ndRow.Attributes.Append(attrId);
                //XmlNode ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                //ndRow.AppendChild(ndCell);
                //foreach(string vf in view.ViewFields)
                //{
                //    ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                //    ndRow.AppendChild(ndCell);
                //}
                //ndRows.AppendChild(ndRow);
            }

            if (globalError != "")
            {
                XmlNode nd = docXml.FirstChild.SelectSingleNode("//afterInit");
                if (nd != null)
                {
                    XmlNode ndCall = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                    XmlAttribute attrName = docXml.CreateAttribute("command");
                    attrName.Value = "alerterror";
                    ndCall.Attributes.Append(attrName);

                    XmlNode ndParam = docXml.CreateNode(XmlNodeType.Element, "param", docXml.NamespaceURI);
                    ndParam.InnerText = globalError;

                    ndCall.AppendChild(ndParam);
                    nd.AppendChild(ndCall);
                }
            }

            data = docXml.OuterXml;


        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            providerEn.NumberDecimalSeparator = ".";
            providerEn.NumberGroupSeparator = ",";
            providerEn.NumberGroupSizes = new int[] { 3 };

            //using (SPWeb curWeb = SPContext.Current.Web)
            SPWeb curWeb = SPContext.Current.Web;
            {
                curWeb.Site.CatchAccessDeniedException = false;

                getParams(curWeb);



                docXml = new XmlDocument();
                docXml.LoadXml("<rows></rows>");
                ndMainParent = docXml.ChildNodes[0];

                XmlDocument docGroup = new XmlDocument();
                docGroup.LoadXml("<Query>" + view.Query + "</Query>");
                try
                {
                    expanded = docGroup.FirstChild.FirstChild.Attributes["Collapse"].Value;
                }
                catch { }
                try
                {
                    if (docGroup.FirstChild.SelectSingleNode("GroupBy") != null)
                        hasGroups = true;
                }
                catch { }
                if (view.AggregationsStatus == "On")
                {
                    XmlDocument docAgg = new XmlDocument();
                    docAgg.LoadXml("<A>" + view.Aggregations + "</A>");

                    foreach (XmlNode ndagg in docAgg.FirstChild.ChildNodes)
                    {
                        SPField field = getRealField(list.Fields.GetFieldByInternalName(ndagg.Attributes["Name"].Value));
                        arrAggregationDef.Add(field.InternalName, ndagg.Attributes["Type"].Value);
                    }
                }

                EPMLiveCore.GridGanttSettings gSettings = EPMLiveCore.API.ListCommands.GetGridGanttSettings(list);
                if (gSettings.TotalSettings != "")
                {
                    string[] fieldList = gSettings.TotalSettings.Split('\n');
                    foreach (string field in fieldList)
                    {
                        if (field != "")
                        {
                            string[] fieldData = field.Split('|');
                            try
                            {
                                if (list.Fields.GetFieldByInternalName(fieldData[0]) != null)
                                    if (!arrAggregationDef.Contains(fieldData[0]))
                                        arrAggregationDef.Add(fieldData[0], fieldData[1]);
                            }
                            catch { }
                        }
                    }
                }

                addHeader();
                addGroups(curWeb);
                addItems();

                foreach (DictionaryEntry de in hshItemNodes)
                {
                    if (de.Key.ToString() != "")
                    {
                        XmlNode ndGroup = (XmlNode)de.Value;

                        for (int i = 1; i < arrColumns.Count; i++)
                        {
                            XmlNode ndCell = ndGroup.SelectSingleNode("cell[@id='" + arrColumns[i] + "']");//docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            string cellValue = "";
                            if (ndCell != null)
                            {
                                if (arrAggregationDef.Contains(arrColumns[i]))
                                {
                                    try
                                    {
                                        string agg = de.Key.ToString() + "\n" + arrColumns[i];
                                        string val = arrAggregationVals[agg].ToString();

                                        switch (arrAggregationDef[arrColumns[i]].ToString())
                                        {
                                            case "AVG":
                                                if (val.Length > 0)
                                                {
                                                    val = val.Substring(1);
                                                    double fVal = 0;
                                                    string[] vals = val.Split(',');

                                                    foreach (string s in vals)
                                                    {
                                                        try
                                                        {
                                                            fVal += double.Parse(s, providerEn);
                                                        }
                                                        catch { }
                                                    }

                                                    fVal = fVal / vals.Length;
                                                    val = fVal.ToString(providerEn);

                                                }
                                                break;
                                            case "STDEV":
                                                if (val.Length > 0)
                                                {
                                                    val = val.Substring(1);
                                                    double avg = 0;
                                                    string[] vals = val.Split(',');
                                                    double[] devs = new double[vals.Length];
                                                    foreach (string s in vals)
                                                    {
                                                        try
                                                        {
                                                            avg += double.Parse(s, providerEn);
                                                        }
                                                        catch { }
                                                    }
                                                    avg = avg / vals.Length;

                                                    try
                                                    {
                                                        for (int j = 0; j < vals.Length; j++)
                                                        {
                                                            devs[j] = double.Parse(vals[j], providerEn) - avg;
                                                            devs[j] = devs[j] * devs[j];
                                                        }
                                                    }
                                                    catch { }
                                                    avg = 0;
                                                    try
                                                    {
                                                        foreach (double f in devs)
                                                            avg += f;
                                                    }
                                                    catch { }
                                                    if (devs.Length >= 2)
                                                        avg = avg / (devs.Length - 1);
                                                    avg = Math.Sqrt(avg);
                                                    val = avg.ToString(providerEn);
                                                }
                                                break;
                                        };
                                        if (arrAggregationDef[arrColumns[i]].ToString() == "COUNT" || bCleanValues)
                                            cellValue = val;
                                        else
                                            cellValue = formatField(val, arrColumns[i].ToString(), false, true, null);
                                    }
                                    catch { }
                                }
                                ndCell.InnerXml = cellValue;
                            }

                            //ndGroup.AppendChild(ndCell);
                        }
                    }
                }

                XmlNode ndParam = docXml.SelectSingleNode("//rows/head/beforeInit/call[@command='attachHeader']/param");
                if (ndParam != null)
                {
                    foreach (DictionaryEntry de in hshColumnSelectFilter)
                    {
                        string options = "";
                        string[] strFilters = de.Value.ToString().Split('\n');
                        foreach (string strFilter in strFilters)
                        {
                            options += "<option value=\"" + strFilter.Replace(",", "&#44;") + "\">" + strFilter.Replace(",", "&#44;") + "</option>";
                        }
                        ndParam.InnerText = ndParam.InnerText.Replace("#" + de.Key.ToString() + "#", options);
                    }
                    ndParam.InnerXml = "<![CDATA[" + ndParam.InnerText + "]]>";
                }
            }
            outputXml();
        }

        private void addItems()
        {
            while (queueAllItems.Count > 0)
            {
                object o = queueAllItems.Dequeue();
                if (o.GetType().ToString() == "Microsoft.SharePoint.SPListItem")
                {
                    SPListItem li = (SPListItem)o;

                    if (arrItems.Contains(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID))
                        addItem(li, li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID);

                }
                else if (o.GetType().ToString() == "System.Data.DataRow")
                {
                    addItem((DataRow)o);
                }
                else if (o.GetType().ToString() == "EPMLiveWebParts.getgriditems+AddItemType")
                {
                    AddItemType it = (AddItemType)o;
                    SPListItem li = (SPListItem)it.o;
                    if (arrItems.Contains(it.indexer))
                        addItem(li, it.indexer);
                }
            }
        }

        private XmlNode addMenus(XmlNode ndNewItem, SPList list, string showcreateworkspace)
        {

            int[] viewMenus = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            if (list.DoesUserHavePermissions(SPBasePermissions.ViewListItems))
                viewMenus[0] = 1;

            if (list.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                viewMenus[1] = 1;

            if (list.DoesUserHavePermissions(SPBasePermissions.ManagePermissions))
                viewMenus[2] = 1;

            if (list.DoesUserHavePermissions(SPBasePermissions.DeleteListItems) && !isTimesheet)
                viewMenus[3] = 1;


            if (list.EnableVersioning)
                if (list.DoesUserHavePermissions(SPBasePermissions.ViewVersions))
                    viewMenus[4] = 1;

            //if (list.WorkflowAssociations.Count > 0)
            //    if (list.DoesUserHavePermissions(SPBasePermissions.EditListItems))
            //        viewMenus[0] = 1;


            viewMenus[5] = 1;

            if (list.EnableModeration)
                if (list.DoesUserHavePermissions(SPBasePermissions.ApproveItems))
                    viewMenus[6] = 1;

            if (list.WorkflowAssociations.Count > 0)
                viewMenus[7] = 1;



            if (!hshMenus.ContainsKey(list.ID))
            {
                string pubPC = "";

                bool wp = false;
                bool ap = false;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(list.ParentWeb.Site.ID))
                    {
                        using (SPWeb web = site.OpenWeb())
                        {

                            Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(web);
                            if (lockWeb == Guid.Empty || lockWeb == list.ParentWeb.ID)
                            {
                                if (EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb, "EPMLiveWPProjectCenter") == list.Title)
                                {
                                    try
                                    {
                                        wp = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb, "EPMLiveWPEnable"));
                                    }
                                    catch { }
                                }
                                if (EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb, "EPMLiveAgileProjectCenter") == list.Title)
                                {
                                    try
                                    {
                                        ap = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb, "EPMLiveAgileEnable"));
                                    }
                                    catch { }
                                }
                                pubPC = EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb, "EPMLivePublisherProjectCenter");
                            }
                            else
                            {
                                using (SPWeb w = site.OpenWeb(lockWeb))
                                {
                                    if (EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPProjectCenter") == list.Title)
                                    {
                                        try
                                        {
                                            wp = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPEnable"));
                                        }
                                        catch { }
                                    }
                                    if (EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveAgileProjectCenter") == list.Title)
                                    {
                                        try
                                        {
                                            ap = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveAgileEnable"));
                                        }
                                        catch { }
                                    }
                                    pubPC = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePublisherProjectCenter");
                                }
                            }
                        }
                    }

                });
                PlannerMenus pm = new PlannerMenus();
                pm.agile = ap;
                pm.workplan = wp;
                try
                {
                    SPDocumentLibrary pschedules = (SPDocumentLibrary)list.ParentWeb.Lists["Project Schedules"];
                    if (pschedules != null && pubPC.ToLower() == list.Title.ToLower())
                    {
                        pm.project = true;
                    }
                }
                catch { }
                hshMenus.Add(list.ID, pm);
            }

            //if (list.TemplateFeatureId == new Guid("8fdde10b-891e-4600-ad06-dd9e554faca0") || list.TemplateFeatureId == new Guid("8087cd06-a830-49b9-9697-f1457a276bcb") || list.Title == EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb, "EPMLiveProjectCenter"))
            //show project button
            try
            {
                if (hshMenus[list.ID].agile || hshMenus[list.ID].workplan || hshMenus[list.ID].project)
                    viewMenus[8] = 1;
            }
            catch { }
            //show create workspace
            if (requestsenabled && list.ParentWeb.DoesUserHavePermissions(SPBasePermissions.ManageSubwebs) && showcreateworkspace.ToLower() == "true")
                viewMenus[9] = 1;

            //show work planner
            try
            {
                if (hshMenus[list.ID].workplan)
                    viewMenus[10] = 1;
            }
            catch { }
            //show agile planner
            try
            {
                if (hshMenus[list.ID].agile)
                    viewMenus[11] = 1;
            }
            catch { }
            //if (list.ParentWeb.Features[new Guid("")] != null)
            //    viewMenus[10] = 1;

            if (list.EnableAttachments && list.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                viewMenus[12] = 1;

            //show edit in project (NON PS)
            try
            {
                if (hshMenus[list.ID].project)
                    viewMenus[13] = 1;
            }
            catch { }

            string strViewMenus = "";

            foreach (int v in viewMenus)
            {
                strViewMenus += "," + v.ToString();
            }
            strViewMenus = strViewMenus.Substring(1);
            XmlNode ndUserData = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
            ndUserData.InnerText = strViewMenus;

            XmlAttribute attrName = docXml.CreateAttribute("name");
            attrName.Value = "viewMenus";
            ndUserData.Attributes.Append(attrName);

            ndNewItem.AppendChild(ndUserData);

            return ndNewItem;
        }

        private void addFilterItems(string field, string value)
        {
            string strVals = hshColumnSelectFilter[field].ToString();
            string[] vals = strVals.Split('\n');
            foreach (string val in vals)
            {
                if (val == value)
                {
                    return;
                }
            }
            strVals += "\n" + value;
            hshColumnSelectFilter[field] = strVals;
        }

        private void addItem(DataRow dr)
        {
            if (!arrItems.Contains(dr["WebID"].ToString() + "." + dr["ListID"].ToString() + "." + dr["ID"].ToString()))
            {
                return;
            }

            //NEED TO DO
            string tsdisabled = "";
            string wbs = "";
            if (dr.Table.Columns.Contains(usewbs))
                wbs = dr[usewbs].ToString();
            //string wbs = getField(li, usewbs, false);

            string[] groups = (string[])arrItems[dr["WebID"].ToString() + "." + dr["ListID"].ToString() + "." + dr["ID"].ToString()];

            XmlNode ndNewItem = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
            XmlAttribute attrId = docXml.CreateAttribute("id");
            attrId.Value = dr["WebID"].ToString().ToLower().Trim("{}".ToCharArray()) + "." + dr["ListID"].ToString().ToLower().Trim("{}".ToCharArray()) + "." + dr["ID"].ToString();

            XmlAttribute attrLocked = docXml.CreateAttribute("locked");

            if (!inEditMode)
            {
                attrLocked.Value = "1";
            }
            ndNewItem.Attributes.Append(attrId);
            if (!isTimesheet)
                ndNewItem.Attributes.Append(attrLocked);

            //NEED TO DO

            bool createworkspace = false;
            if (dr["WebID"].ToString().Trim("{}".ToCharArray()).Equals(list.ParentWeb.ID.ToString(), StringComparison.CurrentCultureIgnoreCase) && ((dr.Table.Columns.Contains("_ModerationStatus") && dr["_ModerationStatus"].ToString() == "0") || (!dr.Table.Columns.Contains("_ModerationStatus"))))
            {
                if (dr.Table.Columns.Contains("WorkspaceUrl"))
                {
                    if (dr["WorkspaceUrl"].ToString() == "")
                        createworkspace = true;
                }
                else
                    createworkspace = true;
            }

            ndNewItem = addMenus(ndNewItem, list, createworkspace.ToString());


            if (isTimesheet)
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "Work";
                ndSiteUrl.Attributes.Append(attrName);
                try
                {
                    ndSiteUrl.InnerText = dr["Work"].ToString();
                }
                catch { ndSiteUrl.InnerText = "0"; }
                ndNewItem.AppendChild(ndSiteUrl);
            }

            //===========Site URL====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "SiteUrl";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = dr["SiteUrl"].ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            ////===========Site URL====================
            //{
            //    XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
            //    XmlAttribute attrName = docXml.CreateAttribute("name");
            //    attrName.Value = "FullURL";
            //    ndSiteUrl.Attributes.Append(attrName);
            //    ndSiteUrl.InnerText = li.ParentList.ParentWeb.Url;
            //    ndNewItem.AppendChild(ndSiteUrl);
            //}
            //===========WebId====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "webid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = dr["WebID"].ToString().Trim("{}".ToCharArray());
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========SiteId====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "siteid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = dr["siteid"].ToString().Trim("{}".ToCharArray()); ;
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========ListId====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "listid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = dr["ListID"].ToString().Trim("{}".ToCharArray()); ;
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========ParentItem====================
            try
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "parentitemid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = dr["ParentItem"].ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            catch { }
            //===========WorkspaceUrl====================
            try
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "wsurl";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = dr["WorkspaceUrl"].ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            catch { }
            //===========ITemId====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "itemid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = dr["ID"].ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========Item Title====================
            {
                try
                {
                    XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                    XmlAttribute attrName = docXml.CreateAttribute("name");
                    attrName.Value = "title";
                    ndSiteUrl.Attributes.Append(attrName);
                    ndSiteUrl.InnerText = dr["Title"].ToString();
                    ndNewItem.AppendChild(ndSiteUrl);
                }
                catch { }
            }
            //===========

            try
            {
                tsdisabled = dr["TSDisableItem"].ToString();
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "tsdisabled";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = tsdisabled;
                ndNewItem.AppendChild(ndSiteUrl);
            }
            catch { }
            //===========EditUrl====================
            if (usePopup && !inEditMode)
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "popup";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = "yes";
                ndNewItem.AppendChild(ndSiteUrl);
            }
            if (inEditMode)
            {
                XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                ndNewCell.InnerText = "";
                ndNewItem.AppendChild(ndNewCell);
            }
            if (showCheckboxes && !isTimesheet)
            {
                XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                ndNewCell.InnerXml = "<![CDATA[<input type=\"checkbox\" style=\"display:none;\" onClick=\"(arguments[0]||event).cancelBubble=true;RefreshCommandUI();\">]]>";
                ndNewItem.AppendChild(ndNewCell);
            }
            if (!titleFieldFound)
            {
                XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                ndNewItem.AppendChild(ndNewCell);
            }
            SPViewFieldCollection vfc = view.ViewFields;
            for (int i = 0; i < vfc.Count; i++)
            {
                string val = "";
                string displayValue = "";
                XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);

                bool wrapInCData = true;

                try
                {
                    string fieldName = vfc[i];

                    if (fieldName == "Edit")
                    {
                        displayValue = "#roweditid#";
                    }
                    else
                    {

                        SPField field = null;

                        if (fieldName == "List" || fieldName == "Site")
                        {
                            field = list.Fields.GetFieldByInternalName(fieldName);
                            val = dr[field.InternalName].ToString();
                            displayValue = val;
                        }
                        else
                        {
                            field = getRealField(list.Fields.GetFieldByInternalName(fieldName));

                            if (bUseReporting)
                            {

                                if (field.Type == SPFieldType.User || field.Type == SPFieldType.Lookup)
                                {
                                    try
                                    {
                                        if (dr[field.InternalName + "ID"].ToString() != "")
                                        {
                                            string[] sids = dr[field.InternalName + "ID"].ToString().Split(',');
                                            string[] svals = dr[field.InternalName + "Text"].ToString().Split(',');

                                            for (int j = 0; j < sids.Length; j++)
                                            {
                                                val += sids[j] + ";#";
                                                try
                                                {
                                                    val += svals[j] + ";#";
                                                }
                                                catch { }

                                            }

                                            val = val.Trim('#');
                                            val = val.Trim(';');
                                        }
                                    }
                                    catch { }

                                }
                                else if (field.Type == SPFieldType.Calculated)
                                {
                                    SPFieldCalculated calc = (SPFieldCalculated)field;
                                    if (calc.ShowAsPercentage)
                                        try
                                        {
                                            val = (float.Parse(dr[field.InternalName].ToString()) / 100).ToString();
                                        }
                                        catch { }
                                    else
                                        val = dr[field.InternalName].ToString();
                                }
                                else
                                {
                                    val = dr[field.InternalName].ToString();
                                }
                            }

                            else
                            {
                                val = dr[field.InternalName].ToString();
                            }
                        }



                        if (field.Type != SPFieldType.Attachments)
                            displayValue = formatField(val, fieldName, dr, false);

                        bool editable = false;
                        try
                        {
                            editable = true;
                            //TODO
                            //if ((li.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm == null || li.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm.Value == true) && !li.Fields.GetFieldByInternalName(field.InternalName).ReadOnlyField)
                            //    editable = true;
                        }
                        catch { }
                        XmlDocument fieldXml = new XmlDocument();
                        //if (inEditMode)
                        //{
                        //    try
                        //    {
                        //        fieldXml.LoadXml(li.Fields.GetFieldByInternalName(field.InternalName).SchemaXml);
                        //    }
                        //    catch { }
                        //}
                        if (field.InternalName == "DocIcon")
                        {
                            if (dr.Table.Columns.Contains("List"))
                            {
                                if (hshLists.Contains(dr["List"].ToString()))
                                {
                                    string tIcon = hshLists[dr["List"].ToString()].ToString();
                                    if (tIcon != "")
                                        val = "<img src=\"" + list.ParentWeb.ServerRelativeUrl + "/_layouts/images/" + tIcon + "\">"; ;
                                }
                                displayValue = val;
                            }
                        }
                        //else if (field.InternalName == "FileLeafRef")
                        //{
                        //    XmlDocument doc = new XmlDocument();
                        //    doc.LoadXml(li.Xml);
                        //    SPFieldLookupValue dref = new SPFieldLookupValue(doc.ChildNodes[0].Attributes["ows_FileDirRef"].Value);
                        //    string docicon = doc.ChildNodes[0].Attributes["ows_DocIcon"].Value;
                        //    string basename = doc.ChildNodes[0].Attributes["ows_BaseName"].Value;
                        //    string Cid = doc.ChildNodes[0].Attributes["ows_ContentTypeId"].Value;
                        //    string perm = doc.ChildNodes[0].Attributes["ows_PermMask"].Value;
                        //    string url = "";

                        //    switch (linktype)
                        //    {
                        //        case "view":
                        //            //url = li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                        //            val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','TRUE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "</A>";
                        //            break;
                        //        case "edit":
                        //            //url = li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                        //            val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A></td><td><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">";
                        //            break;
                        //        case "":
                        //            if (fieldName == "LinkFilenameNoMenu")
                        //                //url = li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                        //                val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','TRUE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "</A>";
                        //            else if (fieldName == "LinkFilename")
                        //                //url = li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                        //                val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A></td><td><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">";
                        //            break;
                        //    };
                        //    //if (url != "")
                        //    {
                        //        //val = "<table border=0 cellpadding=0 cellspacing=0 width=100% height=\"100%\"><tr><td width=\"100%\" style=\"padding-left:0px;padding-right:0px;\"><table height=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"ms-unselectedtitle\" onmouseover=\"OnItem(this)\" CTXName=\"ctx1\" Id=\"" + li.ID + "\" Url=\"" + li.File.ServerRelativeUrl + "\" DRef=\"" + dref.LookupValue + "\" Perm=\"" + perm + "\" Type=\"\" Ext=\"" + docicon + "\" Icon=\"" + li.File.IconUrl + "|Microsoft Office Word|" + Microsoft.SharePoint.Utilities.SPUtility.MapToControl(li.ParentList.ParentWeb, li.File.Name, "") + "\" OType=\"0\" COUId=\"\" SRed=\"\" COut=\"0\" HCD=\"\" CSrc=\"\" MS=\"0\" CType=\"" + li.ContentType.Name + "\" CId=\"" + li.ContentType.Id + "\" UIS=\"" + li.File.UIVersion.ToString() + "\" SUrl=\"\"><tr><td width=\"100%\" Class=\"ms-vb\"><A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A></td><td><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\"></td></tr></table></td><td style=\"padding-left:0px;padding-right:0px;\"><img src=\"/_layouts/images/blank.gif\" border=0 width=1 height=20></td></tr></table>";
                        //        //val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A></td><td><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">";
                        //    }
                        //    displayValue = val;

                        //}
                        //else 
                        else if (field.InternalName == "WorkspaceUrl")
                        {
                            val = "<a href=\"" + dr["WorkspaceUrl"].ToString().Split(',')[0] + "\"><img src=\"" + list.ParentWeb.ServerRelativeUrl + "/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>"; ;

                            displayValue = val;

                        }
                        else if (field.InternalName == "Title")
                        {
                            if (hshColumnSelectFilter.Contains("Title"))
                            {
                                addFilterItems("Title", val);
                            }

                            if (tsdisabled == "1")
                            {
                                displayValue = val;
                            }
                            else
                            {
                                string url = "";
                                switch (linktype)
                                {
                                    case "view":
                                        if (usePopup && !inEditMode)
                                            url = "\" onclick=\"javascript:viewItem" + gridname + "(this,'view');return false;";
                                        else
                                            url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=view&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                        break;
                                    case "edit":
                                        if (usePopup && !inEditMode)
                                            url = "\" onclick=\"javascript:viewItem" + gridname + "(this,'edit');return false;";
                                        else
                                            url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=edit&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                        break;
                                    case "":
                                        if (fieldName == "LinkTitleNoMenu")
                                            if (usePopup && !inEditMode)
                                                url = "\" onclick=\"javascript:viewItem" + gridname + "(this,'view');return false;";
                                            else
                                                url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=view&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                        else if (fieldName == "LinkTitle")
                                            if (usePopup && !inEditMode)
                                                url = "\" onclick=\"javascript:viewItem" + gridname + "(this,'edit');return false;";
                                            else
                                                url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=edit&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                        break;
                                    case "workspace":
                                        url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=workspace&webid=" + dr["WebId"].ToString();
                                        break;
                                    case "workplan":
                                        url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=workplan&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString();
                                        break;
                                    case "planner":
                                        url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=planner&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString();
                                        break;
                                    case "tasks":
                                        url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=tasks&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]) + "&FilterField1=Project&FilterValue1=" + System.Web.HttpUtility.UrlEncode(dr[fieldName].ToString());
                                        break;
                                };

                                if (!inEditMode)
                                {
                                    if (url != "")
                                    {
                                        val = "<a href=\"" + url + "\">" + val + "</a>";
                                        try
                                        {
                                            DateTime dtCreated = DateTime.Parse(dr["Created"].ToString());
                                            if (dtCreated.AddDays(2) > DateTime.Now)
                                                val += " <img src=\"/_layouts/" + list.ParentWeb.Language.ToString() + "/images/new.gif\">";


                                        }
                                        catch { }
                                    }
                                    try
                                    {
                                        string scomments = dr["CommentCount"].ToString();
                                        double comments = 0;
                                        double.TryParse(scomments, out comments);
                                        if (comments > 0)
                                        {
                                            if (list.Fields.ContainsFieldWithStaticName("Commenters") && list.Fields.ContainsFieldWithStaticName("CommentersRead"))
                                            {
                                                ArrayList commenters = new ArrayList();
                                                int authorid = 0;
                                                try
                                                {
                                                    commenters = new ArrayList(dr["Commenters"].ToString().Split(','));
                                                }
                                                catch { }
                                                try
                                                {
                                                    SPFieldUserValue uv = new SPFieldUserValue(list.ParentWeb, dr["Author"].ToString());
                                                    authorid = uv.LookupId;
                                                }
                                                catch { }
                                                bool isAssigned = false;
                                                try
                                                {
                                                    SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(list.ParentWeb, dr["AssignedTo"].ToString());
                                                    foreach (SPFieldUserValue uv in uvc)
                                                    {
                                                        if (uv.LookupId == list.ParentWeb.CurrentUser.ID)
                                                        {
                                                            isAssigned = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                                catch { }
                                                if (commenters.Contains(list.ParentWeb.CurrentUser.ID.ToString()) || authorid == list.ParentWeb.CurrentUser.ID || isAssigned)
                                                {
                                                    ArrayList commentersread = new ArrayList();
                                                    try
                                                    {
                                                        commentersread = new ArrayList(dr["CommentersRead"].ToString().Split(','));
                                                    }
                                                    catch { }
                                                    if (commentersread.Contains(list.ParentWeb.CurrentUser.ID.ToString()))
                                                    {
                                                        val += " &nbsp;<a href=\"javascript:viewItem" + gridname + "(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/comment-small.png\" border=\"0\"></a>";
                                                    }
                                                    else
                                                    {
                                                        val += " &nbsp;<a href=\"javascript:viewItem" + gridname + "(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>";
                                                    }
                                                }
                                                else
                                                    val += " &nbsp;<a href=\"javascript:viewItem" + gridname + "(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/comment-small.png\" border=\"0\"></a>";
                                            }
                                            else
                                                val += " &nbsp;<a href=\"javascript:viewItem" + gridname + "(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/comment-small.png\" border=\"0\"></a>";
                                        }
                                    }
                                    catch { }

                                    var sWsUrl = string.Empty;
                                    try
                                    {
                                        sWsUrl = dr["WorkspaceUrl"].ToString();
                                        }
                                    catch { }

                                    if (!string.IsNullOrEmpty(sWsUrl))
                                    {
                                        var tVal = "&nbsp;<a href=\"" + sWsUrl.Split(',')[0] + "\"><img src=\"" + list.ParentWeb.ServerRelativeUrl + "/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>";
                                        val += tVal;
                                    }
                                }

                                displayValue = val;
                            }
                        }
                        else
                        {
                            if (bCleanValues)
                            {
                                SPField oField = list.Fields.GetFieldByInternalName(field.InternalName);
                                switch (oField.Type)
                                {
                                    case SPFieldType.Calculated:
                                        if (field.Description == "Indicator")
                                        {
                                            if (val != "")
                                                val = "<img src=\"/_layouts/images/" + val.ToLower() + "\">";
                                            displayValue = val;
                                        }
                                        else
                                            displayValue = val;
                                        break;
                                    case SPFieldType.User:
                                        displayValue = oField.GetFieldValueAsHtml(val);
                                        break;
                                    default:
                                        displayValue = val;
                                        break;
                                }
                            }
                            else if (inEditMode && editable && bUseReporting)
                            {
                                
                                XmlAttribute attrType;
                                XmlAttribute attrText;
                                switch (list.Fields.GetFieldByInternalName(field.InternalName).Type)
                                {
                                    case SPFieldType.Number:
                                        if (fieldXml.InnerXml.Contains("Percentage=\"TRUE\""))
                                        {
                                            try
                                            {
                                                double fval = double.Parse(val.Replace("%", "")) * 100;
                                                val = fval.ToString();
                                                displayValue = val;
                                            }
                                            catch { }
                                        }
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "edn";
                                        ndNewCell.Attributes.Append(attrType);
                                        displayValue = val;
                                        break;
                                    case SPFieldType.User:
                                        if (hshColumnSelectFilter.Contains(field.InternalName) && dr[field.InternalName + "Text"] != null)
                                        {
                                            if (field.GetFieldValue(val).GetType().ToString() == "Microsoft.SharePoint.SPFieldUserValue")
                                            {
                                                SPFieldLookupValue lv = new SPFieldLookupValue(dr[field.InternalName + "Text"].ToString());
                                                addFilterItems(field.InternalName, lv.LookupValue);
                                            }
                                            else
                                            {
                                                SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(dr[field.InternalName + "Text"].ToString());
                                                foreach (SPFieldLookupValue lv in lvc)
                                                {
                                                    addFilterItems(field.InternalName, lv.LookupValue);
                                                }
                                            }



                                        }
                                        if (fieldXml.InnerXml.Contains("Type=\"UserMulti\""))
                                        {
                                            attrType = docXml.CreateAttribute("type");
                                            attrType.Value = "usereditorm";
                                            ndNewCell.Attributes.Append(attrType);
                                        }
                                        else
                                        {
                                            attrType = docXml.CreateAttribute("type");
                                            attrType.Value = "usereditor";
                                            ndNewCell.Attributes.Append(attrType);
                                        }
                                        displayValue = "";
                                        if (val != "")
                                        {

                                            if (field.GetFieldValue(val).GetType().ToString() == "Microsoft.SharePoint.SPFieldUserValue")
                                            {
                                                SPFieldUserValue uv = new SPFieldUserValue(list.ParentWeb, val);

                                                if (uv.User != null)
                                                    displayValue = uv.User.LoginName + "\n" + uv.User.Name;
                                                else
                                                    displayValue = uv.LookupId + "\n" + uv.LookupValue;
                                            }
                                            else
                                            {

                                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(list.ParentWeb, val);
                                                displayValue = "";
                                                foreach (SPFieldUserValue uv in uvc)
                                                {
                                                    if (uv.User != null)
                                                        displayValue += "\n" + uv.User.LoginName + "\n" + uv.User.Name;
                                                    else
                                                        displayValue += "\n" + uv.LookupId + "\n" + uv.LookupValue;
                                                }
                                                if (displayValue.Length > 1)
                                                    displayValue = displayValue.Substring(1);
                                            }
                                        }
                                        displayValue += "\t";

                                        if (hshComboCells.Contains(field.InternalName + "-" + list.ParentWeb.ID.ToString()))
                                        {
                                            displayValue += hshComboCells[field.InternalName + "-" + list.ParentWeb.ID.ToString()].ToString();
                                        }
                                        else
                                        {
                                            string mode = "";
                                            try
                                            {
                                                mode = fieldXml.FirstChild.Attributes["UserSelectionMode"].Value;
                                            }
                                            catch { }

                                            string userList = getMultiUser(mode, list.ParentWeb);
                                            hshComboCells[field.InternalName + "-" + list.ParentWeb.ID.ToString()] = userList;
                                            displayValue += userList;
                                        }
                                        break;
                                    case SPFieldType.MultiChoice:
                                        displayValue = "";
                                        if (val != "")
                                        {
                                            string choices = "";
                                            if (val[0] == ';' && val[1] == '#')
                                                choices = val.Substring(2, val.Length - 4);
                                            else
                                                choices = val;

                                            choices = choices.Replace(";#", "\n");
                                            foreach (string choice in choices.Split('\n'))
                                            {
                                                displayValue += "\n" + choice + ";#" + choice;
                                                if (hshColumnSelectFilter.Contains(field.InternalName))
                                                {
                                                    addFilterItems(field.InternalName, choice);
                                                }
                                            }
                                            if (displayValue.Length > 1)
                                                displayValue = displayValue.Substring(1);
                                        }
                                        displayValue += "\t";
                                        if (hshComboCells.Contains(field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()))
                                        {
                                            displayValue += hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()].ToString();
                                        }
                                        else
                                        {
                                            XmlDocument doc = new XmlDocument();
                                            doc.LoadXml(list.Fields.GetFieldByInternalName(field.InternalName).SchemaXml);

                                            string inputs = "";
                                            foreach (XmlNode nd in doc.SelectNodes("//CHOICE"))
                                            {
                                                inputs += "\n" + nd.InnerText + ";#" + nd.InnerText;
                                            }
                                            if (inputs.Length > 1)
                                                inputs = inputs.Substring(1);
                                            displayValue += inputs;
                                            hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ID.ToString()] = inputs;
                                        }
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "mchoice";
                                        ndNewCell.Attributes.Append(attrType);
                                        break;
                                    case SPFieldType.Choice:
                                        displayValue = "";
                                        if (val != "")
                                        {
                                            if (!val.Contains(";#"))
                                                displayValue = val + ";#" + val;
                                            else
                                                displayValue = val;

                                            if (hshColumnSelectFilter.Contains(field.InternalName))
                                            {
                                                addFilterItems(field.InternalName, val);
                                            }
                                        }
                                        displayValue += "\t";
                                        if (hshComboCells.Contains(field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()))
                                        {
                                            displayValue += hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()].ToString();
                                        }
                                        else
                                        {
                                            XmlDocument doc = new XmlDocument();
                                            doc.LoadXml(list.Fields.GetFieldByInternalName(field.InternalName).SchemaXml);

                                            string inputs = "";
                                            foreach (XmlNode nd in doc.SelectNodes("//CHOICE"))
                                            {
                                                inputs += "\n" + nd.InnerText + ";#" + nd.InnerText;
                                            }
                                            if (inputs.Length > 1)
                                                inputs = inputs.Substring(1);
                                            displayValue += inputs;
                                            hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()] = inputs;
                                        }
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "choice";
                                        ndNewCell.Attributes.Append(attrType);
                                        break;
                                    case SPFieldType.Lookup:
                                        if (list.Fields.GetFieldByInternalName(field.InternalName).TypeAsString == "LookupMulti")
                                        {
                                            attrType = docXml.CreateAttribute("type");
                                            attrType.Value = "mchoice";
                                            ndNewCell.Attributes.Append(attrType);
                                            displayValue = "";
                                            if (val != "")
                                            {
                                                SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                                                foreach (SPFieldLookupValue lv in lvc)
                                                {
                                                    displayValue += "\n" + lv.ToString();
                                                    if (hshColumnSelectFilter.Contains(field.InternalName))
                                                    {
                                                        addFilterItems(field.InternalName, lv.LookupValue);
                                                    }
                                                }
                                                if (displayValue.Length > 1)
                                                    displayValue = displayValue.Substring(1);
                                            }
                                            string lookuplist = fieldXml.ChildNodes[0].Attributes["List"].Value;
                                            string lookupfield = fieldXml.ChildNodes[0].Attributes["ShowField"].Value;

                                            if (!hshComboCells.Contains(field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()))
                                            {
                                                hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()] = getLookupList(list.ParentWeb, lookuplist, lookupfield);
                                            }
                                            displayValue += "\t" + hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()].ToString();

                                        }
                                        else
                                        {

                                            if (val != "")
                                            {
                                                SPFieldLookupValue lv = new SPFieldLookupValue(val);
                                                val = lv.LookupId.ToString() + ";#" + lv.LookupValue;
                                                if (hshColumnSelectFilter.Contains(field.InternalName))
                                                {
                                                    addFilterItems(field.InternalName, lv.LookupValue);
                                                }
                                            }

                                            attrText = docXml.CreateAttribute("text");
                                            attrText.Value = displayValue;

                                            attrType = docXml.CreateAttribute("type");
                                            attrType.Value = "choice";

                                            if (hshComboCells.Contains(field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()))
                                            {
                                                displayValue = val + "\t" + hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()].ToString();
                                            }
                                            else
                                            {
                                                string lookuplist = fieldXml.ChildNodes[0].Attributes["List"].Value;
                                                string lookupfield = fieldXml.ChildNodes[0].Attributes["ShowField"].Value;
                                                string lvals = getLookupList(list.ParentWeb, lookuplist, lookupfield);
                                                hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()] = lvals;
                                                displayValue = val + "\t" + lvals;
                                            }

                                            if (hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()].ToString() == "")
                                            {
                                                attrType.Value = "ro";
                                            }
                                            else
                                            {

                                                //attrxmlContent = docXml.CreateAttribute("xmlcontent");
                                                //attrxmlContent.Value = "1";
                                                //attrAutoComplete = docXml.CreateAttribute("autocomplete");
                                                //attrAutoComplete.Value = "1";

                                                //ndNewCell.Attributes.Append(attrxmlContent);
                                                //ndNewCell.Attributes.Append(attrAutoComplete);
                                                //ndNewCell.Attributes.Append(attrType);
                                                //ndNewCell.Attributes.Append(attrText);
                                            }
                                            ndNewCell.Attributes.Append(attrType);
                                        }
                                        break;
                                    case SPFieldType.Calculated:
                                        if (field.Description == "Indicator")
                                        {
                                            //XmlAttribute attrValueFormat = docXml.CreateAttribute("ValueFormat");
                                            //attrValueFormat.Value = "1";
                                            //ndNewCell.Attributes.Append(attrValueFormat);
                                            if (val != "")
                                                val = "<img src=\"/_layouts/images/" + val.ToLower() + "\">";
                                            displayValue = val;
                                        }
                                        break;
                                    case SPFieldType.Currency:
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "edn";
                                        ndNewCell.Attributes.Append(attrType);
                                        displayValue = val;
                                        break;
                                    case SPFieldType.Text:
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "ed";
                                        ndNewCell.Attributes.Append(attrType);
                                        break;
                                    case SPFieldType.Boolean:
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "ch";
                                        ndNewCell.Attributes.Append(attrType);
                                        if (val.ToLower() == "true")
                                            displayValue = "1";
                                        else
                                            displayValue = "0";
                                        break;
                                    case SPFieldType.DateTime:
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "dhxCalendarA";
                                        ndNewCell.Attributes.Append(attrType);
                                        break;
                                    default:
                                        switch (field.TypeAsString)
                                        {
                                            case "FilteredLookup":

                                                if (inEditMode)
                                                {

                                                    Guid lookuplist = new Guid(fieldXml.ChildNodes[0].Attributes["List"].Value);
                                                    Guid lookupfield = new Guid(fieldXml.ChildNodes[0].Attributes["ShowField"].Value);
                                                    Guid lookupweb = new Guid(fieldXml.ChildNodes[0].Attributes["WebId"].Value);

                                                    XmlNode nd = fieldXml.ChildNodes[0].SelectSingleNode("Customization").SelectSingleNode("ArrayOfProperty");

                                                    string query = nd.SelectSingleNode("Property[Name='QueryFilterAsString']").SelectSingleNode("Value").InnerText;
                                                    string listview = nd.SelectSingleNode("Property[Name='ListViewFilter']").SelectSingleNode("Value").InnerText;
                                                    string multi = nd.SelectSingleNode("Property[Name='SupportsMultipleValues']").SelectSingleNode("Value").InnerText;
                                                    string recurse = nd.SelectSingleNode("Property[Name='IsFilterRecursive']").SelectSingleNode("Value").InnerText;

                                                    string strType = "choice";
                                                    if (multi.ToLower() == "true")
                                                    {
                                                        strType = "mchoice";
                                                        SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                                                        foreach (SPFieldLookupValue lv in lvc)
                                                        {
                                                            displayValue += "\n" + lv.ToString();
                                                        }
                                                        if (displayValue.Length > 1)
                                                            displayValue = displayValue.Substring(1);
                                                    }
                                                    else
                                                    {
                                                        displayValue = val;
                                                    }

                                                    attrType = docXml.CreateAttribute("type");
                                                    attrType.Value = strType;
                                                    ndNewCell.Attributes.Append(attrType);

                                                    if (!hshComboCells.Contains(field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()))
                                                    {
                                                        string choices = "";
                                                        if (lookupweb == list.ParentWeb.ID)
                                                        {
                                                            choices = getLookupList(list.ParentWeb, lookuplist, lookupfield, query, listview);
                                                        }
                                                        else
                                                        {
                                                            try
                                                            {
                                                                using (SPWeb w = list.ParentWeb.Site.OpenWeb(lookupweb))
                                                                {
                                                                    choices = getLookupList(w, lookuplist, lookupfield, query, listview);
                                                                }
                                                            }
                                                            catch { }
                                                        }
                                                        hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()] = choices;
                                                    }
                                                    displayValue += "\t" + hshComboCells[field.InternalName + "-" + list.ID.ToString() + "-" + list.ParentWeb.ID.ToString()].ToString();

                                                }

                                                break;
                                        }
                                        break;
                                };
                                
                            }
                            else
                            {
                                switch (field.Type)
                                {
                                    case SPFieldType.Attachments:
                                        //if (li.Attachments.Count > 0)
                                        //{
                                        //    SPFolder sourceItemAttachmentsFolder = li.Web.Folders["Lists"].SubFolders[li.ParentList.Title].SubFolders["Attachments"].SubFolders[li.ID.ToString()];
                                        //    val = "<a href=\"" + sourceItemAttachmentsFolder.Files[0].ServerRelativeUrl + "\">" + sourceItemAttachmentsFolder.Files[0].Name + "</a>";
                                        //    displayValue = val;
                                        //}
                                        //else
                                        //    val = "";
                                        if (val == "true")
                                            val = "<a href=\"" + dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=attachments&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]) + "\">View</a>";
                                        else
                                            val = "";
                                        break;
                                    case SPFieldType.User:
                                        if (hshColumnSelectFilter.Contains(field.InternalName) && dr[fieldName].ToString() != "")
                                        {
                                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(dr[fieldName].ToString());
                                            foreach (SPFieldLookupValue lv in lvc)
                                            {
                                                addFilterItems(field.InternalName, lv.LookupValue);
                                            }
                                        }
                                        break;
                                    case SPFieldType.Calculated:
                                        if (field.Description == "Indicator")
                                        {
                                            if (val.IndexOf(";#") == 0)
                                                displayValue = "";
                                            //XmlAttribute attrValueFormat = docXml.CreateAttribute("ValueFormat");
                                            //attrValueFormat.Value = "1";
                                            //ndNewCell.Attributes.Append(attrValueFormat);
                                            if (displayValue != "")
                                                displayValue = "<img src=\"/_layouts/images/" + displayValue.ToLower() + "\">";
                                        }
                                        break;
                                    case SPFieldType.MultiChoice:
                                    case SPFieldType.Choice:
                                    case SPFieldType.Lookup:
                                        if (val != "")
                                        {
                                            string[] vals = val.Split(',');
                                            foreach (string sval in vals)
                                            {
                                                if (hshColumnSelectFilter.Contains(field.InternalName))
                                                {
                                                    addFilterItems(field.InternalName, sval);
                                                }
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        if (!wbs.Contains("."))
                        {
                            foreach (string group in groups)
                            {
                                setAggVal(group, fieldName, val, list);
                            }
                        }
                        if (editable && inEditMode && (list.Fields.GetFieldByInternalName(field.InternalName).Type == SPFieldType.Choice || list.Fields.GetFieldByInternalName(field.InternalName).Type == SPFieldType.Lookup))
                        {
                            wrapInCData = false;

                        }
                        if (!editable && inEditMode)
                        {
                            XmlAttribute attrType = docXml.CreateAttribute("type");
                            attrType.Value = "ro";
                            ndNewCell.Attributes.Append(attrType);
                        }
                    }
                }
                catch { }
                //XmlAttribute attrStyle = docXml.CreateAttribute("style");
                //attrStyle.Value = "height:auto;white-space:normal;";
                //ndNewCell.Attributes.Append(attrStyle);
                //XmlAttribute attrValueFormat1 = docXml.CreateAttribute("ValueFormat");
                //attrValueFormat1.Value = "1";
                //ndNewCell.Attributes.Append(attrValueFormat1);

                if (wrapInCData)
                    displayValue = "<![CDATA[" + displayValue + "]]>";

                ndNewCell.InnerXml = displayValue;

                try
                {
                    ndNewItem.AppendChild(ndNewCell);
                }
                catch
                {
                    ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    ndNewItem.AppendChild(ndNewCell);
                }

            }

            int counter = 1;

            foreach (string group in groups)
            {

                bool wbsfound = false;
                XmlNode ndGroup = null;
                if (wbs != "")
                {
                    int ind = wbs.LastIndexOf(".");
                    if (ind > 0)
                    {
                        string parentwbs = wbs.Substring(0, ind);
                        if (hshWBS.Contains(group + "\n" + parentwbs))
                        {
                            wbsfound = true;
                            try
                            {
                                ndGroup = (XmlNode)hshWBS[group + "\n" + parentwbs];
                            }
                            catch { }
                            if (ndGroup == null)
                                return;

                            if (expanded == "FALSE" || expanded == null)
                            {
                                XmlAttribute attrExpand = docXml.CreateAttribute("open");
                                attrExpand.Value = "1";
                                try
                                {
                                    XmlAttribute attrBold = docXml.CreateAttribute("style");
                                    attrBold.Value = "font-weight:bold;";
                                    ndGroup.Attributes.Append(attrBold);
                                }
                                catch { }
                                ndGroup.Attributes.Append(attrExpand);
                            }
                        }
                    }
                }

                if (!wbsfound)
                {
                    if (group != null)
                        ndGroup = (XmlNode)hshItemNodes[group];
                    else
                        ndGroup = ndMainParent;

                    if (ndGroup == null)
                        return;

                    //ndItems = ndGroup.SelectSingleNode("Items");
                    //if(ndItems == null)
                    //{
                    //    ndItems = docXml.CreateNode(XmlNodeType.Element, "Items", docXml.NamespaceURI);
                    //    ndGroup.AppendChild(ndItems);
                    //}

                    //if (group == "")
                    //{
                    //    ndItems = ndGroup;
                    //}
                    //else if (ndItems == null)
                    //{
                    //    ndItems = docXml.CreateNode(XmlNodeType.Element, "Items", docXml.NamespaceURI);
                    //    ndGroup.AppendChild(ndItems);
                    //}
                }

                XmlNode ndCloned = ndNewItem.CloneNode(true);
                string grouping = group;

                if (grouping == null)
                    grouping = "";
                ndCloned.Attributes["id"].Value = ndCloned.Attributes["id"].Value + "." + counter.ToString();


                XmlNode editNode = ndCloned.SelectSingleNode("//cell[.='#roweditid#']");
                if (editNode != null)
                    editNode.InnerText = "<a onclick=\"javascript:editRow" + gridname + "('" + ndCloned.Attributes["id"].Value + "');\" style=\"cursor:hand\"><img src=\"/_layouts/images/edit.gif\" border=\"0\"></a>";

                ndGroup.AppendChild(ndCloned);
                if (wbs != "")
                {
                    if (!hshWBS.Contains(group + "\n" + wbs))
                        hshWBS.Add(group + "\n" + wbs, ndCloned);
                }
                counter++;
            }
        }

        private bool isEditable(SPListItem li, SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties)
        {

            try
            {
                if (!fieldProperties[field.InternalName].ContainsKey("Edit"))
                    return true;

                string displaySettings = string.Empty;

                displaySettings = fieldProperties[field.InternalName]["Edit"];
                if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                {
                    string where = displaySettings.Split(";".ToCharArray())[1];
                    string conditionField = "";
                    string condition = "";
                    string group = "";
                    string valueCondition = "";
                    if (where.Equals("[Me]"))
                    {
                        condition = displaySettings.Split(";".ToCharArray())[2];
                        group = displaySettings.Split(";".ToCharArray())[3];
                    }
                    else // [Field]
                    {
                        conditionField = displaySettings.Split(";".ToCharArray())[2];
                        condition = displaySettings.Split(";".ToCharArray())[3];
                        valueCondition = displaySettings.Split(";".ToCharArray())[4];
                    }
                    bool e = EPMLiveCore.EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, li);
                    if (!e)
                        return false;
                }

                displaySettings = fieldProperties[field.InternalName]["Editable"];
                if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("never"))
                    return false;
                if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                {
                    string where = displaySettings.Split(";".ToCharArray())[1];
                    string conditionField = "";
                    string condition = "";
                    string group = "";
                    string valueCondition = "";
                    if (where.Equals("[Me]"))
                    {
                        condition = displaySettings.Split(";".ToCharArray())[2];
                        group = displaySettings.Split(";".ToCharArray())[3];
                    }
                    else // [Field]
                    {
                        conditionField = displaySettings.Split(";".ToCharArray())[2];
                        condition = displaySettings.Split(";".ToCharArray())[3];
                        valueCondition = displaySettings.Split(";".ToCharArray())[4];
                    }
                    return EPMLiveCore.EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, li);
                }

            }
            catch { }
            return true;

        }



        private void addItem(SPListItem li, string indexer)
        {

            string wbs = getField(li, usewbs, false);

            string[] groups = (string[])arrItems[indexer];

            XmlNode ndNewItem = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
            XmlAttribute attrId = docXml.CreateAttribute("id");
            attrId.Value = indexer;

            XmlAttribute attrLocked = docXml.CreateAttribute("locked");

            if (!inEditMode)
            {
                attrLocked.Value = "1";
            }
            ndNewItem.Attributes.Append(attrId);
            if (!isTimesheet)
                ndNewItem.Attributes.Append(attrLocked);


            Dictionary<string, Dictionary<string, string>> fieldProperties = null;

            if (hshFieldProperties.Contains(li.ParentList.ID.ToString()))
                fieldProperties = (Dictionary<string, Dictionary<string, string>>)hshFieldProperties[li.ParentList.ID.ToString()];


            if (inEditMode)
            {
                XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                ndNewCell.InnerText = "";
                ndNewItem.AppendChild(ndNewCell);
            }
            if (showCheckboxes && !isTimesheet)
            {
                XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                ndNewCell.InnerXml = "<![CDATA[<input type=\"checkbox\" style=\"display:none;\" onClick=\"(arguments[0]||event).cancelBubble=true;CheckBoxSelectRow(this);\">]]>";
                ndNewItem.AppendChild(ndNewCell);
            }
            SPViewFieldCollection vfc = view.ViewFields;
            if (!titleFieldFound)
            {
                XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                ndNewItem.AppendChild(ndNewCell);
            }
            for (int i = 0; i < vfc.Count; i++)
            {
                string val = "";
                string displayValue = "";
                XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);

                bool wrapInCData = true;

                try
                {
                    string fieldName = vfc[i];

                    if (fieldName == "Edit" && !inEditMode)
                    {
                        displayValue = "#roweditid#";
                    }
                    else
                    {
                        SPField field = null;

                        if (fieldName == "List" || fieldName == "Site")
                        {
                            field = list.Fields.GetFieldByInternalName(fieldName);
                            displayValue = li.ParentList.Title;
                        }
                        else
                        {
                            field = getRealField(list.Fields.GetFieldByInternalName(fieldName));
                            val = getField(li, field.InternalName, false);
                            if (field.Type != SPFieldType.Attachments)
                                displayValue = formatField(val, fieldName, field.Type == SPFieldType.Calculated, false, li);
                        }

                        bool editable = false;
                        try
                        {
                            //if (li.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm == null && !li.Fields.GetFieldByInternalName(field.InternalName).ReadOnlyField)
                            //    editable = true;

                            if (li.Fields.GetFieldByInternalName(field.InternalName).ReadOnlyField)
                                editable = false;
                            if (li.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm == null)
                                editable = isEditable(li, li.Fields.GetFieldByInternalName(field.InternalName), fieldProperties);
                            else if (!li.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm.Value)
                                editable = false;
                            else
                                editable = isEditable(li, li.Fields.GetFieldByInternalName(field.InternalName), fieldProperties);
                        }
                        catch { }
                        XmlDocument fieldXml = new XmlDocument();
                        if (inEditMode)
                        {
                            try
                            {
                                fieldXml.LoadXml(li.Fields.GetFieldByInternalName(field.InternalName).SchemaXml);
                            }
                            catch { }
                        }
                        if (field.InternalName == "DocIcon")
                        {
                            if (li.File != null)
                                val = "<img src=\"" + ((li.Web.ServerRelativeUrl == "/") ? "" : li.Web.ServerRelativeUrl) + "/_layouts/images/" + li.File.IconUrl + "\">";
                            else if (rolluplists != null && rolluplists.Length > 0)
                            {
                                string icon = li.ParentList.ImageUrl;
                                if (hshLists.Contains(li.ParentList.Title))
                                {
                                    string tIcon = hshLists[li.ParentList.Title].ToString();
                                    if (tIcon != "")
                                        icon = "/_layouts/images/" + tIcon;
                                }

                                val = "<img src=\"" + ((li.Web.ServerRelativeUrl == "/") ? "" : li.Web.ServerRelativeUrl) + icon + "\">";
                            }
                            else if (val.Contains("/1"))
                                displayValue = "";
                            else
                                displayValue = val;
                        }
                        else if (field.InternalName == "WorkspaceUrl")
                        {
                            val = "<a href=\"" + li["WorkspaceUrl"].ToString().Split(',')[0] + "\"><img src=\"" + list.ParentWeb.ServerRelativeUrl + "/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>"; ;

                            displayValue = val;

                        }
                        else if (field.InternalName == "ContentType")
                        {
                            if (li.ID == 0)
                                displayValue = li.ParentList.ContentTypes[0].Name + ";#" + li.ParentList.ContentTypes[0].Name + "\t" + hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()].ToString();
                            else
                                displayValue = li.ContentType.Name + ";#" + li.ContentType.Name + "\t" + hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()].ToString();
                        }
                        else if (field.InternalName == "FileLeafRef")
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(li.Xml);
                            SPFieldLookupValue dref = new SPFieldLookupValue(doc.ChildNodes[0].Attributes["ows_FileDirRef"].Value);
                            string docicon = doc.ChildNodes[0].Attributes["ows_DocIcon"].Value;
                            string basename = doc.ChildNodes[0].Attributes["ows_BaseName"].Value;
                            string Cid = doc.ChildNodes[0].Attributes["ows_ContentTypeId"].Value;
                            string perm = doc.ChildNodes[0].Attributes["ows_PermMask"].Value;

                            switch (linktype)
                            {
                                case "view":
                                    //url = li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                    val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','TRUE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "</A>";
                                    break;
                                case "edit":
                                    //url = li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                    val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A></td><td><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">";
                                    break;
                                case "":
                                    if (fieldName == "LinkFilenameNoMenu")
                                        //url = li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                        val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','TRUE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "</A>";
                                    else if (fieldName == "LinkFilename")
                                        //url = li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                        val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A></td><td><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">";
                                    break;
                            };
                            //if (url != "")
                            {
                                //val = "<table border=0 cellpadding=0 cellspacing=0 width=100% height=\"100%\"><tr><td width=\"100%\" style=\"padding-left:0px;padding-right:0px;\"><table height=\"100%\" cellpadding=\"0\" cellspacing=\"0\" class=\"ms-unselectedtitle\" onmouseover=\"OnItem(this)\" CTXName=\"ctx1\" Id=\"" + li.ID + "\" Url=\"" + li.File.ServerRelativeUrl + "\" DRef=\"" + dref.LookupValue + "\" Perm=\"" + perm + "\" Type=\"\" Ext=\"" + docicon + "\" Icon=\"" + li.File.IconUrl + "|Microsoft Office Word|" + Microsoft.SharePoint.Utilities.SPUtility.MapToControl(li.ParentList.ParentWeb, li.File.Name, "") + "\" OType=\"0\" COUId=\"\" SRed=\"\" COut=\"0\" HCD=\"\" CSrc=\"\" MS=\"0\" CType=\"" + li.ContentType.Name + "\" CId=\"" + li.ContentType.Id + "\" UIS=\"" + li.File.UIVersion.ToString() + "\" SUrl=\"\"><tr><td width=\"100%\" Class=\"ms-vb\"><A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A></td><td><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\"></td></tr></table></td><td style=\"padding-left:0px;padding-right:0px;\"><img src=\"/_layouts/images/blank.gif\" border=0 width=1 height=20></td></tr></table>";
                                //val = "<A onfocus=\"OnLink(this)\" HREF=\"" + li.File.ServerRelativeUrl + "\" onclick=\"return DispEx(this,event,'TRUE','FALSE','FALSE','SharePoint.OpenDocuments.3','0','SharePoint.OpenDocuments','','','','1','0','0','" + perm + "')\">" + basename + "<img src=\"/_layouts/images/blank.gif\" class=\"ms-hidden\" border=1 width=1 height=26 alt=\"Use SHIFT+ENTER to open the menu (new window).\"></A></td><td><img src=\"/_layouts/images/blank.gif\" width=13 style=\"visibility:hidden\" alt=\"\">";
                            }
                            displayValue = val;

                        }
                        else if (field.InternalName == "Title")
                        {
                            if (hshColumnSelectFilter.Contains("Title"))
                            {
                                addFilterItems("Title", val);
                            }

                            string url = "";
                            switch (linktype)
                            {
                                case "view":
                                    if (usePopup && !inEditMode)
                                        url = "\" onclick=\"javascript:viewItem" + gridname + "(this,'view');return false;";
                                    else
                                        url = li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                    break;
                                case "edit":
                                    if (usePopup && !inEditMode)
                                        url = "\" onclick=\"javascript:viewItem" + gridname + "(this,'edit');return false;";
                                    else
                                        url = li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                    break;
                                case null:
                                case "":
                                    if (fieldName == "LinkTitleNoMenu")
                                        if (usePopup && !inEditMode)
                                            url = "\" onclick=\"javascript:viewItem" + gridname + "(this,'view');return false;";
                                        else
                                            url = li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                    else if (fieldName == "LinkTitle")
                                        if (usePopup && !inEditMode)
                                            url = "\" onclick=\"javascript:viewItem" + gridname + "(this,'edit');return false;";
                                        else
                                            url = li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                    break;
                                case "workspace":
                                    url = li.ParentList.ParentWeb.ServerRelativeUrl + "/";
                                    break;
                                case "workplan":
                                    url = li.ParentList.ParentWeb.ServerRelativeUrl + "/_layouts/epmlive/tasks.aspx?ID=" + li.ID;
                                    break;
                                case "planner":
                                    string u = li.ParentList.ParentWeb.ServerRelativeUrl;
                                    url = ((u == "/") ? "" : u) + "/_layouts/epmlive/workplanner.aspx?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                    break;
                                case "tasks":
                                    SPList taskList = null;
                                    try
                                    {
                                        taskList = li.ParentList.ParentWeb.Lists["Task Center"];
                                    }
                                    catch { }
                                    if (taskList != null)
                                    {
                                        url = taskList.ParentWeb.ServerRelativeUrl + "/" + taskList.DefaultView.Url + "?FilterField1=Project&FilterValue1=" + System.Web.HttpUtility.UrlEncode(li.Title);
                                    }
                                    break;
                            };

                            if (url != "" && !inEditMode)
                            {
                                displayValue = "<a href=\"" + url + "\">" + displayValue + "</a>";
                                try
                                {
                                    DateTime dtCreated = DateTime.Parse(li["Created"].ToString());
                                    if (dtCreated.AddDays(2) > DateTime.Now)
                                        displayValue += " <img src=\"/_layouts/" + li.Web.Language.ToString() + "/images/new.gif\">";
                                }
                                catch { }


                            }
                            else if (isTimesheet)
                            {
                                if (url != "")
                                    displayValue = "<a href=\"" + url + "\">" + displayValue + "</a>";
                                //url = "\" onclick=\"javascript:viewItem" + gridname + "(this,'view');return false;";
                                //displayValue = "<a href=\"" + url + "\">" + displayValue + "</a>";
                            }
                            if (!inEditMode)
                            {
                                try
                                {
                                    string scomments = li["CommentCount"].ToString();
                                    double comments = 0;
                                    double.TryParse(scomments, out comments);
                                    if (comments > 0)
                                    {
                                        if (list.Fields.ContainsFieldWithStaticName("Commenters") && list.Fields.ContainsFieldWithStaticName("CommentersRead"))
                                        {
                                            ArrayList commenters = new ArrayList();
                                            int authorid = 0;
                                            try
                                            {
                                                commenters = new ArrayList(li[list.Fields.GetFieldByInternalName("Commenters").Id].ToString().Split(','));
                                            }
                                            catch { }
                                            try
                                            {
                                                SPFieldUserValue uv = new SPFieldUserValue(li.ParentList.ParentWeb, li["Author"].ToString());
                                                authorid = uv.LookupId;
                                            }
                                            catch { }
                                            bool isAssigned = false;
                                            try
                                            {
                                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(li.ParentList.ParentWeb, li["AssignedTo"].ToString());
                                                foreach (SPFieldUserValue uv in uvc)
                                                {
                                                    if (uv.LookupId == li.ParentList.ParentWeb.CurrentUser.ID)
                                                    {
                                                        isAssigned = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            catch { }
                                            if (commenters.Contains(li.ParentList.ParentWeb.CurrentUser.ID.ToString()) || authorid == li.ParentList.ParentWeb.CurrentUser.ID || isAssigned)
                                            {
                                                ArrayList commentersread = new ArrayList();
                                                try
                                                {
                                                    commentersread = new ArrayList(li[list.Fields.GetFieldByInternalName("CommentersRead").Id].ToString().Split(','));
                                                }
                                                catch { }
                                                if (commentersread.Contains(li.ParentList.ParentWeb.CurrentUser.ID.ToString()))
                                                {
                                                    displayValue += " &nbsp;<a href=\"javascript:viewItem" + gridname + "(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/comment-small.png\" border=\"0\"></a>";
                                                }
                                                else
                                                {
                                                    displayValue += " &nbsp;<a href=\"javascript:viewItem" + gridname + "(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>";
                                                }
                                            }
                                            else
                                                displayValue += " &nbsp;<a href=\"javascript:viewItem" + gridname + "(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/comment-small.png\" border=\"0\"></a>";
                                        }
                                        else
                                            displayValue += " &nbsp;<a href=\"javascript:viewItem" + gridname + "(this,'comments');return false;\"><img src=\"/_layouts/epmlive/images/mywork/comment-small.png\" border=\"0\"></a>";
                                    }
                                }
                                catch { }

                                if (!vfc.Exists("WorkspaceUrl"))
                                {
                                    try
                                    {
                                        string tVal = "&nbsp;<a href=\"" + li["WorkspaceUrl"].ToString().Split(',')[0] + "\"><img src=\"" + list.ParentWeb.ServerRelativeUrl + "/_layouts/epmlive/images/itemworkspace.png\" border=\"0\"></a>"; ;

                                        displayValue += tVal;
                                    }
                                    catch { }
                                }
                            }
                        }
                        else
                        {
                            if (bCleanValues)
                            {
                                SPField oField = li.Fields.GetFieldByInternalName(field.InternalName);
                                switch (oField.Type)
                                {
                                    case SPFieldType.Calculated:
                                        if (field.Description == "Indicator")
                                        {
                                            if (val != "")
                                                val = "<img src=\"/_layouts/images/" + val.ToLower() + "\">";
                                            displayValue = val;
                                        }
                                        else
                                            displayValue = val;
                                        break;
                                    case SPFieldType.User:
                                        displayValue = oField.GetFieldValueAsHtml(val);
                                        break;
                                    default:
                                        displayValue = val;
                                        break;
                                }
                            }
                            else if (inEditMode && editable)
                            {
                                XmlAttribute attrType;
                                XmlAttribute attrText;
                                switch (li.Fields.GetFieldByInternalName(field.InternalName).Type)
                                {
                                    case SPFieldType.Number:
                                        if (fieldXml.InnerXml.Contains("Percentage=\"TRUE\""))
                                        {
                                            try
                                            {
                                                double fval = double.Parse(val.Replace("%", "")) * 100;
                                                val = fval.ToString();
                                                displayValue = val;
                                            }
                                            catch { }
                                        }
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "edn";
                                        ndNewCell.Attributes.Append(attrType);
                                        displayValue = val;
                                        break;
                                    case SPFieldType.User:
                                        if (hshColumnSelectFilter.Contains(field.InternalName) && li[li.Fields.GetFieldByInternalName(field.InternalName).Id] != null)
                                        {
                                            if (field.GetFieldValue(val).GetType().ToString() == "Microsoft.SharePoint.SPFieldUserValue")
                                            {
                                                SPFieldLookupValue lv = new SPFieldLookupValue(li[li.Fields.GetFieldByInternalName(field.InternalName).Id].ToString());
                                                addFilterItems(field.InternalName, lv.LookupValue);
                                            }
                                            else
                                            {
                                                SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(li[li.Fields.GetFieldByInternalName(field.InternalName).Id].ToString());
                                                foreach (SPFieldLookupValue lv in lvc)
                                                {
                                                    addFilterItems(field.InternalName, lv.LookupValue);
                                                }
                                            }



                                        }
                                        if (fieldXml.InnerXml.Contains("Type=\"UserMulti\""))
                                        {
                                            attrType = docXml.CreateAttribute("type");
                                            attrType.Value = "usereditorm";
                                            ndNewCell.Attributes.Append(attrType);
                                        }
                                        else
                                        {
                                            attrType = docXml.CreateAttribute("type");
                                            attrType.Value = "usereditor";
                                            ndNewCell.Attributes.Append(attrType);
                                        }
                                        displayValue = "";
                                        if (val != "")
                                        {

                                            if (field.GetFieldValue(val).GetType().ToString() == "Microsoft.SharePoint.SPFieldUserValue")
                                            {
                                                SPFieldUserValue uv = new SPFieldUserValue(li.Web, val);

                                                if (uv.User != null)
                                                    displayValue = uv.User.LoginName + "\n" + uv.User.Name;
                                                else
                                                    displayValue = uv.LookupId + "\n" + uv.LookupValue;
                                            }
                                            else
                                            {

                                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(li.Web, val);
                                                displayValue = "";
                                                foreach (SPFieldUserValue uv in uvc)
                                                {
                                                    if (uv.User != null)
                                                        displayValue += "\n" + uv.User.LoginName + "\n" + uv.User.Name;
                                                    else
                                                        displayValue += "\n" + uv.LookupId + "\n" + uv.LookupValue;
                                                }
                                                if (displayValue.Length > 1)
                                                    displayValue = displayValue.Substring(1);
                                            }
                                        }
                                        displayValue += "\t";

                                        if (hshComboCells.Contains(field.InternalName + "-" + li.Web.ID.ToString()))
                                        {
                                            displayValue += hshComboCells[field.InternalName + "-" + li.Web.ID.ToString()].ToString();
                                        }
                                        else
                                        {
                                            string mode = "";
                                            try
                                            {
                                                mode = fieldXml.FirstChild.Attributes["UserSelectionMode"].Value;
                                            }
                                            catch { }

                                            string userList = getMultiUser(mode, li.Web);
                                            hshComboCells[field.InternalName + "-" + li.Web.ID.ToString()] = userList;
                                            displayValue += userList;
                                        }
                                        break;
                                    case SPFieldType.MultiChoice:
                                        displayValue = "";
                                        if (val != "")
                                        {
                                            string choices = "";
                                            if (val[0] == ';' && val[1] == '#')
                                                choices = val.Substring(2, val.Length - 4);
                                            else
                                                choices = val;

                                            choices = choices.Replace(";#", "\n");
                                            foreach (string choice in choices.Split('\n'))
                                            {
                                                displayValue += "\n" + choice + ";#" + choice;
                                                if (hshColumnSelectFilter.Contains(field.InternalName))
                                                {
                                                    addFilterItems(field.InternalName, choice);
                                                }
                                            }
                                            if (displayValue.Length > 1)
                                                displayValue = displayValue.Substring(1);
                                        }
                                        displayValue += "\t";
                                        if (hshComboCells.Contains(field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()))
                                        {
                                            displayValue += hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()].ToString();
                                        }
                                        else
                                        {
                                            XmlDocument doc = new XmlDocument();
                                            doc.LoadXml(li.Fields.GetFieldByInternalName(field.InternalName).SchemaXml);

                                            string inputs = "";
                                            foreach (XmlNode nd in doc.SelectNodes("//CHOICE"))
                                            {
                                                inputs += "\n" + nd.InnerText + ";#" + nd.InnerText;
                                            }
                                            if (inputs.Length > 1)
                                                inputs = inputs.Substring(1);
                                            displayValue += inputs;
                                            hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()] = inputs;
                                        }
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "mchoice";
                                        ndNewCell.Attributes.Append(attrType);
                                        break;
                                    case SPFieldType.Choice:
                                        displayValue = "";
                                        if (val != "")
                                        {
                                            if (!val.Contains(";#"))
                                                displayValue = val + ";#" + val;
                                            else
                                                displayValue = val;

                                            if (hshColumnSelectFilter.Contains(field.InternalName))
                                            {
                                                addFilterItems(field.InternalName, val);
                                            }
                                        }
                                        displayValue += "\t";
                                        if (hshComboCells.Contains(field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()))
                                        {
                                            displayValue += hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()].ToString();
                                        }
                                        else
                                        {
                                            XmlDocument doc = new XmlDocument();
                                            doc.LoadXml(li.Fields.GetFieldByInternalName(field.InternalName).SchemaXml);

                                            string inputs = "";
                                            foreach (XmlNode nd in doc.SelectNodes("//CHOICE"))
                                            {
                                                inputs += "\n" + nd.InnerText + ";#" + nd.InnerText;
                                            }
                                            if (inputs.Length > 1)
                                                inputs = inputs.Substring(1);
                                            displayValue += inputs;
                                            hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()] = inputs;
                                        }
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "choice";
                                        ndNewCell.Attributes.Append(attrType);
                                        break;
                                    case SPFieldType.Lookup:
                                        if (li.Fields.GetFieldByInternalName(field.InternalName).TypeAsString == "LookupMulti")
                                        {
                                            attrType = docXml.CreateAttribute("type");
                                            attrType.Value = "mchoice";
                                            ndNewCell.Attributes.Append(attrType);
                                            displayValue = "";
                                            if (val != "")
                                            {
                                                SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                                                foreach (SPFieldLookupValue lv in lvc)
                                                {
                                                    displayValue += "\n" + lv.ToString();
                                                    if (hshColumnSelectFilter.Contains(field.InternalName))
                                                    {
                                                        addFilterItems(field.InternalName, lv.LookupValue);
                                                    }
                                                }
                                                if (displayValue.Length > 1)
                                                    displayValue = displayValue.Substring(1);
                                            }
                                            string lookuplist = fieldXml.ChildNodes[0].Attributes["List"].Value;
                                            string lookupfield = fieldXml.ChildNodes[0].Attributes["ShowField"].Value;

                                            if (!hshComboCells.Contains(field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()))
                                            {
                                                hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()] = getLookupList(li.Web, lookuplist, lookupfield);
                                            }
                                            displayValue += "\t" + hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()].ToString();

                                        }
                                        else
                                        {

                                            if (val != "")
                                            {
                                                SPFieldLookupValue lv = new SPFieldLookupValue(val);
                                                val = lv.LookupId.ToString() + ";#" + lv.LookupValue;
                                                if (hshColumnSelectFilter.Contains(field.InternalName))
                                                {
                                                    addFilterItems(field.InternalName, lv.LookupValue);
                                                }
                                            }

                                            attrText = docXml.CreateAttribute("text");
                                            attrText.Value = displayValue;

                                            attrType = docXml.CreateAttribute("type");
                                            attrType.Value = "choice";

                                            if (hshComboCells.Contains(field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()))
                                            {
                                                displayValue = val + "\t" + hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()].ToString();
                                            }
                                            else
                                            {
                                                string lookuplist = fieldXml.ChildNodes[0].Attributes["List"].Value;
                                                string lookupfield = fieldXml.ChildNodes[0].Attributes["ShowField"].Value;
                                                string lvals = getLookupList(li.Web, lookuplist, lookupfield);
                                                hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()] = lvals;
                                                displayValue = val + "\t" + lvals;
                                            }

                                            if (hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()].ToString() == "")
                                            {
                                                attrType.Value = "ro";
                                            }
                                            else
                                            {

                                                //attrxmlContent = docXml.CreateAttribute("xmlcontent");
                                                //attrxmlContent.Value = "1";
                                                //attrAutoComplete = docXml.CreateAttribute("autocomplete");
                                                //attrAutoComplete.Value = "1";

                                                //ndNewCell.Attributes.Append(attrxmlContent);
                                                //ndNewCell.Attributes.Append(attrAutoComplete);
                                                //ndNewCell.Attributes.Append(attrType);
                                                //ndNewCell.Attributes.Append(attrText);
                                            }
                                            ndNewCell.Attributes.Append(attrType);
                                        }
                                        break;
                                    case SPFieldType.Calculated:
                                        if (field.Description == "Indicator")
                                        {
                                            //XmlAttribute attrValueFormat = docXml.CreateAttribute("ValueFormat");
                                            //attrValueFormat.Value = "1";
                                            //ndNewCell.Attributes.Append(attrValueFormat);
                                            if (val != "")
                                                val = "<img src=\"/_layouts/images/" + val.ToLower() + "\">";
                                            displayValue = val;
                                        }
                                        break;
                                    case SPFieldType.Currency:
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "edn";
                                        ndNewCell.Attributes.Append(attrType);
                                        displayValue = val;
                                        break;
                                    case SPFieldType.Attachments:
                                        if (li.Attachments.Count > 0)
                                        {
                                            SPFolder sourceItemAttachmentsFolder = li.Web.Folders["Lists"].SubFolders[li.ParentList.Title].SubFolders["Attachments"].SubFolders[li.ID.ToString()];
                                            val = "<a href=\"" + sourceItemAttachmentsFolder.Files[0].ServerRelativeUrl + "\">" + sourceItemAttachmentsFolder.Files[0].Name + "</a>";
                                            displayValue = val;
                                        }
                                        else
                                            val = "";
                                        break;
                                    case SPFieldType.Text:
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "ed";
                                        ndNewCell.Attributes.Append(attrType);
                                        break;
                                    case SPFieldType.Boolean:
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "ch";
                                        ndNewCell.Attributes.Append(attrType);
                                        if (val.ToLower() == "true")
                                            displayValue = "1";
                                        else
                                            displayValue = "0";
                                        break;
                                    case SPFieldType.DateTime:
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "dhxCalendarA";
                                        ndNewCell.Attributes.Append(attrType);
                                        break;
                                    default:
                                        switch (field.TypeAsString)
                                        {
                                            case "FilteredLookup":

                                                if (inEditMode)
                                                {

                                                    Guid lookuplist = new Guid(fieldXml.ChildNodes[0].Attributes["List"].Value);
                                                    Guid lookupfield = new Guid(fieldXml.ChildNodes[0].Attributes["ShowField"].Value);
                                                    Guid lookupweb = new Guid(fieldXml.ChildNodes[0].Attributes["WebId"].Value);

                                                    XmlNode nd = fieldXml.ChildNodes[0].SelectSingleNode("Customization").SelectSingleNode("ArrayOfProperty");

                                                    string query = nd.SelectSingleNode("Property[Name='QueryFilterAsString']").SelectSingleNode("Value").InnerText;
                                                    string listview = nd.SelectSingleNode("Property[Name='ListViewFilter']").SelectSingleNode("Value").InnerText;
                                                    string multi = nd.SelectSingleNode("Property[Name='SupportsMultipleValues']").SelectSingleNode("Value").InnerText;
                                                    string recurse = nd.SelectSingleNode("Property[Name='IsFilterRecursive']").SelectSingleNode("Value").InnerText;

                                                    string strType = "choice";
                                                    if (multi.ToLower() == "true")
                                                    {
                                                        strType = "mchoice";
                                                        SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                                                        foreach (SPFieldLookupValue lv in lvc)
                                                        {
                                                            displayValue += "\n" + lv.ToString();
                                                        }
                                                        if (displayValue.Length > 1)
                                                            displayValue = displayValue.Substring(1);
                                                    }
                                                    else
                                                    {
                                                        displayValue = val;
                                                    }

                                                    attrType = docXml.CreateAttribute("type");
                                                    attrType.Value = strType;
                                                    ndNewCell.Attributes.Append(attrType);

                                                    if (!hshComboCells.Contains(field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()))
                                                    {
                                                        string choices = "";
                                                        if (lookupweb == list.ParentWeb.ID)
                                                        {
                                                            choices = getLookupList(list.ParentWeb, lookuplist, lookupfield, query, listview);
                                                        }
                                                        else
                                                        {
                                                            try
                                                            {
                                                                using (SPWeb w = list.ParentWeb.Site.OpenWeb(lookupweb))
                                                                {
                                                                    choices = getLookupList(w, lookuplist, lookupfield, query, listview);
                                                                }
                                                            }
                                                            catch { }
                                                        }
                                                        hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()] = choices;
                                                    }
                                                    displayValue += "\t" + hshComboCells[field.InternalName + "-" + li.ParentList.ID.ToString() + "-" + li.Web.ID.ToString()].ToString();

                                                }

                                                break;
                                        }
                                        break;
                                };
                            }
                            else
                            {
                                switch (field.Type)
                                {
                                    case SPFieldType.Attachments:
                                        if (li.Attachments.Count > 0)
                                        {
                                            SPFolder sourceItemAttachmentsFolder = li.Web.Folders["Lists"].SubFolders[li.ParentList.Title].SubFolders["Attachments"].SubFolders[li.ID.ToString()];
                                            val = "<a href=\"" + sourceItemAttachmentsFolder.Files[0].ServerRelativeUrl + "\">" + sourceItemAttachmentsFolder.Files[0].Name + "</a>";
                                            displayValue = val;
                                        }
                                        else
                                            val = "";
                                        break;
                                    case SPFieldType.User:
                                        if (hshColumnSelectFilter.Contains(field.InternalName) && li[field.Id] != null)
                                        {
                                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(li[field.Id].ToString());
                                            foreach (SPFieldLookupValue lv in lvc)
                                            {
                                                addFilterItems(field.InternalName, lv.LookupValue);
                                            }
                                        }
                                        break;
                                    case SPFieldType.Calculated:
                                        if (field.Description == "Indicator")
                                        {
                                            //XmlAttribute attrValueFormat = docXml.CreateAttribute("ValueFormat");
                                            //attrValueFormat.Value = "1";
                                            //ndNewCell.Attributes.Append(attrValueFormat);
                                            if (val != "")
                                                val = "<img src=\"/_layouts/images/" + val.ToLower() + "\">";
                                            displayValue = val;
                                        }
                                        break;
                                    case SPFieldType.MultiChoice:
                                    case SPFieldType.Choice:
                                    case SPFieldType.Lookup:
                                        if (val != "")
                                        {
                                            string[] vals = val.Split(',');
                                            foreach (string sval in vals)
                                            {
                                                if (hshColumnSelectFilter.Contains(field.InternalName))
                                                {
                                                    addFilterItems(field.InternalName, sval);
                                                }
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        if (!wbs.Contains("."))
                        {
                            foreach (string group in groups)
                            {
                                setAggVal(group, fieldName, val, list);
                            }
                        }
                        if (!editable && inEditMode && field.InternalName != "Title")
                        {
                            XmlAttribute attrType = docXml.CreateAttribute("type");
                            attrType.Value = "ro";
                            ndNewCell.Attributes.Append(attrType);
                        }
                    }
                }
                catch { }
                //XmlAttribute attrStyle = docXml.CreateAttribute("style");
                //attrStyle.Value = "height:auto;white-space:normal;";
                //ndNewCell.Attributes.Append(attrStyle);
                //XmlAttribute attrValueFormat1 = docXml.CreateAttribute("ValueFormat");
                //attrValueFormat1.Value = "1";
                //ndNewCell.Attributes.Append(attrValueFormat1);

                if (wrapInCData)
                    displayValue = "<![CDATA[" + displayValue + "]]>";

                ndNewCell.InnerXml = displayValue;

                try
                {
                    ndNewItem.AppendChild(ndNewCell);
                }
                catch
                {
                    ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    ndNewItem.AppendChild(ndNewCell);
                }

            }
            bool createworkspace = false;
            string childitem = "";
            try
            {
                childitem = li["ChildItem"].ToString();
            }
            catch { }

            if (li.ParentList.ParentWeb.ID.ToString().Equals(list.ParentWeb.ID.ToString(), StringComparison.CurrentCultureIgnoreCase) && (li.ModerationInformation == null || li.ModerationInformation.Status == SPModerationStatusType.Approved) && childitem == "")
                createworkspace = true;

            ndNewItem = addMenus(ndNewItem, li.ParentList, createworkspace.ToString());
            if (isTimesheet)
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "Work";
                ndSiteUrl.Attributes.Append(attrName);
                try
                {
                    ndSiteUrl.InnerText = li["Work"].ToString();
                }
                catch { ndSiteUrl.InnerText = "0"; }
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========Site URL====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "SiteUrl";
                ndSiteUrl.Attributes.Append(attrName);
                //ndSiteUrl.InnerText = (li.ParentList.ParentWeb.ServerRelativeUrl == "/") ? "" : li.ParentList.ParentWeb.ServerRelativeUrl;
                ndSiteUrl.InnerText = li.ParentList.ParentWeb.Site.Url;
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========Full URL====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "FullURL";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ParentList.ParentWeb.ServerRelativeUrl;
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========WebId====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "webid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ParentList.ParentWeb.ID.ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========SiteId====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "siteid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ParentList.ParentWeb.Site.ID.ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========ListId====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "listid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ParentList.ID.ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========ParentItem====================
            try
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "parentitemid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li["ParentItem"].ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            catch { }
            //===========WorkspaceUrl====================
            try
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "wsurl";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li["WorkspaceUrl"].ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            catch { }
            //===========ITemId====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "itemid";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ID.ToString();
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========ViewUrl====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "viewurl";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].ServerRelativeUrl;
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========EditUrl====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "editurl";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl;
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========Item Title====================
            {
                try
                {
                    if (li.ID != 0)
                    {
                        XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                        XmlAttribute attrName = docXml.CreateAttribute("name");
                        attrName.Value = "title";
                        ndSiteUrl.Attributes.Append(attrName);
                        ndSiteUrl.InnerText = li.Title;
                        ndNewItem.AppendChild(ndSiteUrl);
                    }

                }
                catch { }
            }
            //===========Popup====================
            if (usePopup && !inEditMode)
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "popup";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = "yes";
                ndNewItem.AppendChild(ndSiteUrl);
            }

            int counter = 1;

            foreach (string group in groups)
            {

                bool wbsfound = false;
                XmlNode ndGroup = null;
                if (wbs != "")
                {
                    int ind = wbs.LastIndexOf(".");
                    if (ind > 0)
                    {
                        string parentwbs = wbs.Substring(0, ind);
                        if (hshWBS.Contains(group + "\n" + parentwbs))
                        {
                            wbsfound = true;
                            try
                            {
                                ndGroup = (XmlNode)hshWBS[group + "\n" + parentwbs];
                            }
                            catch { }
                            if (ndGroup == null)
                                return;

                            if (expanded == "FALSE" || expanded == null)
                            {
                                XmlAttribute attrExpand = docXml.CreateAttribute("open");
                                attrExpand.Value = "1";
                                ndGroup.Attributes.Append(attrExpand);
                            }
                            try
                            {
                                XmlAttribute attrBold = docXml.CreateAttribute("style");
                                attrBold.Value = "font-weight:bold;";
                                ndGroup.Attributes.Append(attrBold);
                            }
                            catch { }
                        }
                    }
                }

                if (!wbsfound)
                {
                    if (group != null)
                        ndGroup = (XmlNode)hshItemNodes[group];
                    else
                        ndGroup = ndMainParent;

                    if (ndGroup == null)
                        return;

                    //ndItems = ndGroup.SelectSingleNode("Items");
                    //if(ndItems == null)
                    //{
                    //    ndItems = docXml.CreateNode(XmlNodeType.Element, "Items", docXml.NamespaceURI);
                    //    ndGroup.AppendChild(ndItems);
                    //}

                    //if (group == "")
                    //{
                    //    ndItems = ndGroup;
                    //}
                    //else if (ndItems == null)
                    //{
                    //    ndItems = docXml.CreateNode(XmlNodeType.Element, "Items", docXml.NamespaceURI);
                    //    ndGroup.AppendChild(ndItems);
                    //}
                }

                XmlNode ndCloned = ndNewItem.CloneNode(true);
                string grouping = group;

                if (grouping == null)
                    grouping = "";
                ndCloned.Attributes["id"].Value = ndCloned.Attributes["id"].Value + "." + counter.ToString();

                XmlNode editNode = ndCloned.SelectSingleNode("//cell[.='#roweditid#']");
                if (editNode != null)
                    editNode.InnerText = "<a onclick=\"javascript:editRow" + gridname + "('" + ndCloned.Attributes["id"].Value + "');\" style=\"cursor:hand\"><img src=\"/_layouts/images/edit.gif\" border=\"0\"></a>";


                ndGroup.AppendChild(ndCloned);
                if (wbs != "")
                {
                    if (!hshWBS.Contains(group + "\n" + wbs))
                        hshWBS.Add(group + "\n" + wbs, ndCloned);
                }
                counter++;
            }
        }

        private string getSingleLookup(string list, string field, SPWeb web)
        {
            string data = "";
            try
            {
                SPList lookupList = web.Lists[new Guid(list)];

                foreach (SPListItem li in lookupList.Items)
                {
                    data = data + "\r\n<option value=\"" + li.ID + "\">" + HttpUtility.HtmlEncode(li[field].ToString()) + "</option>";
                }
            }
            catch { }
            return data;
        }

        private string getLookupList(SPWeb web, string list, string field)
        {
            string data = "";
            try
            {
                SPList lookupList = web.Lists[new Guid(list)];

                foreach (SPListItem li in lookupList.Items)
                {
                    data += "\n" + li.ID + ";#" + li[field].ToString();
                }

                data = data.Substring(1);
            }
            catch { }
            return data;
        }

        private string getLookupList(SPWeb web, Guid list, Guid field, string query, string view)
        {
            string data = "";
            try
            {
                SPList lookupList = web.Lists[list];

                if (view == "" && query == "")
                {
                    foreach (SPListItem li in lookupList.Items)
                    {
                        data += "\n" + li.ID + ";#" + li[field].ToString();
                    }
                }
                else if (view == "")
                {
                    SPQuery spquery = new SPQuery();
                    spquery.Query = HttpUtility.HtmlDecode(query);
                    foreach (SPListItem li in lookupList.GetItems(spquery))
                    {
                        data += "\n" + li.ID + ";#" + li[field].ToString();
                    }
                }
                else
                {
                    foreach (SPListItem li in lookupList.GetItems(lookupList.Views[new Guid(view)]))
                    {
                        SPListItem litemp = lookupList.GetItemById(li.ID);
                        data += "\n" + litemp.ID + ";#" + litemp[field].ToString();
                    }
                }


                data = data.Substring(1);
            }
            catch { }
            return data;
        }

        private string getMultiUser(string mode, SPWeb web)
        {
            string data = "";
            try
            {
                SortedList userList = new SortedList();
                web.Site.CatchAccessDeniedException = false;
                foreach (SPGroup g in web.Groups)
                {
                    try
                    {
                        if (g.CanCurrentUserViewMembership)
                        {
                            if (mode == "PeopleAndGroups" || mode == "")
                                userList.Add(g.Name, g.ID);
                            foreach (SPUser u in g.Users)
                            {
                                if (!userList.Contains(u.Name))
                                    userList.Add(u.Name, u.LoginName);
                            }
                        }
                    }
                    catch { }
                }
                foreach (SPUser u in web.Users)
                {
                    if (!userList.Contains(u.Name))
                        userList.Add(u.Name, u.LoginName);
                }
                foreach (DictionaryEntry e in userList)
                {
                    data += "\n" + e.Value + ";#" + e.Key.ToString().Replace(",", ";");
                }
                if (data.Length > 0)
                    data = data.Substring(1);
            }
            catch { }
            return data;
        }

        private void setAggVal(string group, string fieldname, string val, SPList aggList)
        {
            try
            {



                SPField field = getRealField(aggList.Fields.GetFieldByInternalName(fieldname));
                fieldname = field.InternalName;

                XmlDocument fieldXml = new XmlDocument();
                fieldXml.LoadXml(field.SchemaXml);
                try
                {
                    if (field.Type == SPFieldType.Calculated)
                    {
                        val = val.Replace(";#", "\n").Split('\n')[1];
                    }
                }
                catch { }
                if (arrAggregationDef.Contains(fieldname) && arrAggregationVals.Contains(group + "\n" + fieldname))
                {
                    string curVal = arrAggregationVals[group + "\n" + fieldname].ToString();
                    switch (arrAggregationDef[fieldname].ToString())
                    {
                        case "COUNT":
                            {
                                int iCurVal = int.Parse(curVal, providerEn) + 1;
                                arrAggregationVals[group + "\n" + fieldname] = iCurVal;
                            }
                            val = arrAggregationVals[group + "\n" + fieldname].ToString();
                            break;
                        case "STDEV":
                        case "AVG":
                            {
                                arrAggregationVals[group + "\n" + fieldname] = curVal + "," + val.Replace("%", "");
                            }
                            break;
                        case "SUM":
                            {
                                double iCurVal = double.Parse(curVal, providerEn);
                                double iNewVal = double.Parse(val.Replace("%", ""), providerEn);
                                arrAggregationVals[group + "\n" + fieldname] = (iNewVal + iCurVal).ToString(providerEn);
                            }
                            //val = arrAggregationVals[group + "\n" + fieldname].ToString();
                            break;
                        case "MIN":
                            if (field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.Calculated || field.TypeAsString == "TotalRollup")
                            {
                                double iNewVal = double.Parse(val.Replace("%", ""), providerEn);
                                if (curVal != "")
                                {
                                    double iCurVal = double.Parse(curVal, providerEn);
                                    if (iNewVal < iCurVal)
                                        arrAggregationVals[group + "\n" + fieldname] = iNewVal.ToString(providerEn);
                                }
                                else
                                    arrAggregationVals[group + "\n" + fieldname] = iNewVal.ToString(providerEn);
                            }
                            else if (field.Type == SPFieldType.DateTime)
                            {
                                DateTime iCurVal = DateTime.Parse(curVal, providerEn);
                                DateTime iNewVal = DateTime.Parse(val.Replace("%", ""), providerEn);
                                string newval = iNewVal.ToString();
                                string format = "";
                                try
                                {
                                    format = fieldXml.ChildNodes[0].Attributes["Format"].Value;
                                }
                                catch { }

                                if (format == "DateOnly")
                                    newval = iNewVal.ToShortDateString();

                                if (iNewVal < iCurVal)
                                    arrAggregationVals[group + "\n" + fieldname] = newval;
                            }
                            val = arrAggregationVals[group + "\n" + fieldname].ToString();
                            break;
                        case "MAX":
                            if (field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.Calculated || field.TypeAsString == "TotalRollup")
                            {
                                double iNewVal = double.Parse(val.Replace("%", ""), providerEn);
                                if (curVal != "")
                                {
                                    double iCurVal = double.Parse(curVal, providerEn);

                                    if (iNewVal > iCurVal)
                                        arrAggregationVals[group + "\n" + fieldname] = iNewVal.ToString(providerEn);
                                }
                                else
                                    arrAggregationVals[group + "\n" + fieldname] = iNewVal.ToString(providerEn);
                            }
                            else if (field.Type == SPFieldType.DateTime)
                            {
                                DateTime iCurVal = DateTime.Parse(curVal);
                                DateTime iNewVal = DateTime.Parse(val);
                                string newval = iNewVal.ToString();

                                string format = "";
                                try
                                {
                                    format = fieldXml.ChildNodes[0].Attributes["Format"].Value;
                                }
                                catch { }

                                if (format == "DateOnly")
                                    newval = iNewVal.ToShortDateString();

                                if (iNewVal > iCurVal)
                                    arrAggregationVals[group + "\n" + fieldname] = newval;

                            }
                            val = arrAggregationVals[group + "\n" + fieldname].ToString();
                            break;
                    };
                    if (group.Contains("\n"))
                    {
                        int ind = group.LastIndexOf("\n");
                        setAggVal(group.Substring(0, ind), fieldname, val, aggList);
                    }
                }

            }
            catch { }

        }

        protected void processList(SPWeb web, string spquery, SPList curList, SortedList arrGTemp)
        {
            int lastid = 0;
            int firstid = 0;

            string lastsort = "";
            string firstsort = "";
            SPListItem lastLi = null;
            ArrayList arrSort = new ArrayList();
            bool bHasMore = false;
            try
            {
                EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

                if (gSettings.DisplaySettings != "")
                    hshFieldProperties.Add(curList.ID.ToString(), EPMLiveCore.ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings));

                //if (curList.ParentWeb.Properties.ContainsKey(String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(curList.DefaultView.Url))))
                //    hshFieldProperties.Add(curList.ID.ToString(), EPMLiveCore.ListDisplayUtils.ConvertFromString(curList.ParentWeb.Properties[String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(curList.DefaultView.Url))]));

                SPQuery query = new SPQuery();
                query.Query = spquery;


                if (iPageSize != 0)
                {
                    XmlDocument docQ = new XmlDocument();
                    docQ.LoadXml("<Query>" + spquery + "</Query>");

                    XmlNode ndSort = docQ.FirstChild.SelectSingleNode("//OrderBy");
                    if (ndSort != null)
                    {
                        foreach (XmlNode ndF in ndSort.SelectNodes("FieldRef"))
                        {
                            arrSort.Add(ndF.Attributes["Name"].Value);
                        }
                    }

                    query.RowLimit = (uint)iPageSize;
                    if (iPage != 0)
                    {


                        if (iPage > 0)
                        {
                            string f = (string)EPMLiveCore.Infrastructure.CacheStore.Current.Get("GVPageL-" + WPID + "-" + web.CurrentUser.ID, "GridSettings-" + list.ID.ToString(), () =>
                            {
                                return "";
                            }, true).Value;
                            query.ListItemCollectionPosition = new SPListItemCollectionPosition("Paged=TRUE&p_ID=" + iPage.ToString() + f);
                        }
                        else
                        {
                            string f = (string)EPMLiveCore.Infrastructure.CacheStore.Current.Get("GVPageF-" + WPID + "-" + web.CurrentUser.ID, "GridSettings-" + list.ID.ToString(), () =>
                            {
                                return "";
                            }, true).Value;
                            query.ListItemCollectionPosition = new SPListItemCollectionPosition("Paged=TRUE&PagedPrev=TRUE&p_ID=" + (iPage * -1).ToString() + f);
                        }
                    }
                }
                SPField oLookupFilterField = null;
                try
                {
                    if (!String.IsNullOrEmpty(lookupFilterField))
                        oLookupFilterField = curList.Fields.GetFieldByInternalName(lookupFilterField);
                }
                catch { }
                SPField oReportFilterField = null;
                try
                {
                    if (!String.IsNullOrEmpty(reportFilterField))
                        oReportFilterField = curList.Fields.GetFieldByInternalName(reportFilterField);
                }
                catch { }

                SPListItemCollection lic = curList.GetItems(query);

                bHasMore = lic.ListItemCollectionPosition != null;

                foreach (SPListItem li in lic)
                {
                    if (iPageSize != 0)
                    {
                        if (firstid == 0)
                        {
                            firstid = li.ID;
                            firstsort = "";

                            foreach (string sort in arrSort)
                            {
                                firstsort += "&p_" + sort + "=";
                                try
                                {
                                    firstsort += HttpUtility.UrlEncode(li[sort].ToString());
                                }
                                catch { }
                            }
                        }
                    }
                    bool canView = true;
                    if (filterfield != "")
                    {
                        try
                        {
                            SPField f = li.Fields.GetFieldByInternalName(filterfield);
                            string val = li[f.Id].ToString();
                            if (f.Type == SPFieldType.Lookup)
                            {
                                val = val.Replace(";#", "\n").Split('\n')[1];
                            }
                            if (val != filtervalue)
                            {
                                canView = false;
                            }
                        }
                        catch { }
                    }

                    if (!String.IsNullOrEmpty(lookupFilterField) && lookupFilterIDs.Count >= MAX_LOOKUPFILTER)
                    {
                        canView = false;
                        try
                        {
                            SPFieldLookupValue lv = new SPFieldLookupValue(li[oLookupFilterField.Id].ToString());
                            if (lookupFilterIDs.Contains(lv.LookupValue))
                                canView = true;
                        }
                        catch { }
                    }

                    if (!String.IsNullOrEmpty(ReportID) && reportFilterIDs.Count >= MAX_LOOKUPFILTER)
                    {
                        canView = false;
                        try
                        {
                            SPFieldLookupValue lv = new SPFieldLookupValue(li[oReportFilterField.Id].ToString());
                            if (reportFilterIDs.Contains(lv.LookupValue))
                                canView = true;
                        }
                        catch { }
                    }

                    if (canView)
                    {
                        string[] group = new string[1] { null };
                        if (arrGroupFields != null)
                        {
                            foreach (string groupby in arrGroupFields)
                            {

                                //if (groupby == "--SITE--")
                                //{
                                //    if (group[0] == null)
                                //        group[0] = web.Title;
                                //    else
                                //        group[0] += "\n" + web.Title;
                                //    if (!arrGTemp.Contains(group[0]))
                                //    {
                                //        arrGTemp.Add(group[0], "");
                                //    }
                                //}
                                //else
                                //{
                                SPField field = list.Fields.GetFieldByInternalName(groupby);
                                string newgroup = getField(li, groupby, true);

                                try
                                {
                                    newgroup = formatField(newgroup, groupby, field.Type == SPFieldType.Calculated, true, li);
                                }
                                catch { }
                                if (newgroup == "")
                                    newgroup = " No " + field.Title;
                                if (field.Type == SPFieldType.User || field.Type == SPFieldType.MultiChoice || field.Type == SPFieldType.Lookup || field.TypeAsString == "FilteredLookup")
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
                        arrItems.Add(web.ID + "." + li.ParentList.ID + "." + li.ID, group);
                        queueAllItems.Enqueue(li);
                    }

                    lastid = li.ID;
                    lastLi = li;
                }
            }
            catch { }

            if (iPageSize > 0)
            {
                if (lastLi != null)
                {
                    lastsort = "";

                    foreach (string sort in arrSort)
                    {
                        lastsort += "&p_" + sort + "=";
                        try
                        {
                            lastsort += HttpUtility.UrlEncode(lastLi[sort].ToString());
                        }
                        catch { }
                    }
                }

                EPMLiveCore.Infrastructure.CacheStore.Current.Set("GVPageF-" + WPID + "-" + web.CurrentUser.ID, firstsort, "GridSettings-" + list.ID.ToString(), true);
                EPMLiveCore.Infrastructure.CacheStore.Current.Set("GVPageL-" + WPID + "-" + web.CurrentUser.ID, lastsort, "GridSettings-" + list.ID.ToString(), true);

                XmlNode nd = docXml.FirstChild.SelectSingleNode("//afterInit");
                if (nd != null)
                {


                    XmlNode ndCall = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                    XmlAttribute attrName = docXml.CreateAttribute("command");
                    attrName.Value = "setuppaging";
                    ndCall.Attributes.Append(attrName);

                    XmlNode ndParam = docXml.CreateNode(XmlNodeType.Element, "param", docXml.NamespaceURI);
                    ndParam.InnerText = iPage + "|" + lastid.ToString() + "|" + firstid.ToString() + "|" + bHasMore.ToString().ToLower();

                    ndCall.AppendChild(ndParam);
                    nd.AppendChild(ndCall);
                }
            }
        }

        protected void processListDT(SPWeb web, DataRow[] dtRows, SortedList arrGTemp, string listname)
        {
            try
            {
                foreach (DataRow dr in dtRows)
                {
                    bool canView = true;

                    if (!String.IsNullOrEmpty(lookupFilterField) && lookupFilterIDs.Count >= MAX_LOOKUPFILTER)
                    {
                        canView = false;
                        try
                        {
                            SPFieldLookupValue lv = new SPFieldLookupValue(dr[lookupFilterField].ToString());
                            if (lookupFilterIDs.Contains(lv.LookupValue))
                                canView = true;
                        }
                        catch { }
                    }
                    if (!String.IsNullOrEmpty(ReportID) && reportFilterIDs.Count >= MAX_LOOKUPFILTER)
                    {
                        canView = false;
                        try
                        {
                            SPFieldLookupValue lv = new SPFieldLookupValue(dr[reportFilterField].ToString());
                            if (reportFilterIDs.Contains(lv.LookupValue))
                                canView = true;
                        }
                        catch { }
                    }
                    if (canView)
                    {
                        dr["SiteUrl"] = web.Site.Url.ToString();
                        dr["siteid"] = web.Site.ID.ToString();
                        if (dr.Table.Columns.Contains("List"))
                            dr["List"] = listname;

                        string[] group = new string[1] { null };
                        if (arrGroupFields != null)
                        {
                            foreach (string groupfield in arrGroupFields)
                            {
                                string groupby = groupfield;

                                SPField field = getRealField(list.Fields.GetFieldByInternalName(groupby));
                                //string newgroup = getField(li, groupby, true);

                                if (bUseReporting && (field.Type == SPFieldType.Lookup || field.Type == SPFieldType.User))
                                {
                                    groupby += "Text";
                                }

                                string newgroup = dr[groupby].ToString();
                                try
                                {
                                    newgroup = formatField(newgroup, groupby, dr, true);
                                }
                                catch { }
                                if (newgroup == "")
                                    newgroup = " No " + field.Title;
                                if (field.Type == SPFieldType.User || field.Type == SPFieldType.MultiChoice || field.Type == SPFieldType.Lookup || field.TypeAsString == "FilteredLookup")
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
                        arrItems.Add(dr["WebID"].ToString() + "." + dr["ListID"].ToString() + "." + dr["ID"].ToString(), group);
                        queueAllItems.Enqueue(dr);
                    }
                }
            }
            catch { }

        }


        public virtual string getQuery()
        {
            return view.Query;//.Replace("<FieldRef Name=\"SiteURLNoMenu\" />", "");
        }





        public virtual void addGroups(SPWeb web, string spquery, SortedList arrGTemp)
        {
            if (bUseReporting)
            {
                string orderby = "";
                string query = EPMLiveCore.ReportingData.GetReportQuery(web, list, spquery, out orderby);

                if (rolluplists == null)
                {
                    try
                    {
                        DataSet ds = EPMLiveCore.ReportingData.GetReportingData(web, list.Title, false, query, orderby, iPage, iPageSize);
                        if (ds != null)
                        {
                            DataTable dt = ds.Tables[0];
                            dt.Columns.Add("SiteURL");
                            dt.Columns.Add("siteid");
                            if (filterfield != "")
                            {
                                try
                                {
                                    processListDT(web, dt.Select(filterfield + " = '" + filtervalue + "'"), arrGTemp, list.Title);
                                }
                                catch { }
                            }
                            else
                                processListDT(web, dt.Select(), arrGTemp, list.Title);

                            if (iPageSize > 0 && ds.Tables.Count > 1)
                            {
                                XmlNode nd = docXml.FirstChild.SelectSingleNode("//afterInit");
                                if (nd != null)
                                {
                                    XmlNode ndCall = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                                    XmlAttribute attrName = docXml.CreateAttribute("command");
                                    attrName.Value = "setuppaging";
                                    ndCall.Attributes.Append(attrName);

                                    XmlNode ndParam = docXml.CreateNode(XmlNodeType.Element, "param", docXml.NamespaceURI);
                                    ndParam.InnerText = ds.Tables[1].Rows[0][0].ToString();

                                    ndCall.AppendChild(ndParam);
                                    nd.AppendChild(ndCall);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        globalError += ex.Message + "<br>";
                    }

                }
                else
                {
                    foreach (string rlist in rolluplists)
                    {
                        try
                        {
                            DataTable dt = EPMLiveCore.ReportingData.GetReportingData(web, rlist, true, query, orderby);
                            if (dt != null)
                            {
                                dt.Columns.Add("SiteURL");
                                dt.Columns.Add("siteid");
                                if (filterfield != "")
                                {
                                    try
                                    {
                                        processListDT(web, dt.Select(filterfield + " = '" + filtervalue + "'"), arrGTemp, rlist);
                                    }
                                    catch { }
                                }
                                else
                                    processListDT(web, dt.Select(), arrGTemp, rlist);
                            }
                        }
                        catch (Exception ex)
                        {
                            globalError += ex.Message + "<br>";
                        }
                    }
                }
            }
            else if (rolluplists == null)
            {
                processList(web, spquery, list, arrGTemp);
            }
            else
            {
                if (inEditMode || !usePerformance)
                {
                    foreach (string strList in rolluplists)
                    {
                        try
                        {
                            SPList tList = web.Lists[strList];
                            if (tList != null)
                                processList(web, spquery, tList, arrGTemp);
                        }
                        catch { }
                    }
                    try
                    {

                        foreach (SPWeb w in web.Webs)
                        {
                            try
                            {
                                addGroups(w, spquery, arrGTemp);
                            }
                            catch { }
                            w.Close();
                        }
                    }
                    catch (Exception exception)
                    {
                        string msg = exception.Message;
                        if (msg.Contains("Access is denied"))
                        {
                            if (web.DoesUserHavePermissions(SPBasePermissions.ViewPages) && !web.DoesUserHavePermissions(SPBasePermissions.BrowseDirectories))
                                globalError = "Although some data may have been returned, access was denied to some data due to incorrect security configuration. Visit <a href=\"http://kb.epmlive.com/KnowledgebaseArticle50056.aspx\">Our Knowledge Base</a> for more information.";
                        }
                        else
                        {
                            globalError = msg;
                        }
                    }
                }
                else
                {

                    foreach (string rlist in rolluplists)
                    {
                        try
                        {
                            DataTable dt = EPMLiveCore.CoreFunctions.getSiteItems(web, view, spquery, filterfield, usewbs, rlist.Trim(), arrGroupFields);
                            if (dt != null)
                            {
                                dt.Columns.Add("SiteURL");
                                dt.Columns.Add("siteid");
                                if (filterfield != "")
                                {
                                    try
                                    {
                                        processListDT(web, dt.Select(filterfield + " = '" + filtervalue + "'"), arrGTemp, rlist);
                                    }
                                    catch { }
                                }
                                else
                                    processListDT(web, dt.Select(), arrGTemp, rlist);
                            }
                        }
                        catch (Exception ex)
                        {
                            globalError += ex.Message + "<br>";
                        }
                    }

                    //string lists = "";
                    //SqlConnection cn = null;
                    //SPSecurity.RunWithElevatedPrivileges(delegate()
                    //{
                    //    //using (SPSite s = SPContext.Current.Site)
                    //    {
                    //        string dbCon = web.Site.ContentDatabase.DatabaseConnectionString;
                    //        cn = new SqlConnection(dbCon);
                    //        cn.Open();
                    //    }
                    //});

                    //if (cn.State == ConnectionState.Open)
                    //{

                    //    try
                    //    {


                    //        string siteurl = web.ServerRelativeUrl.Substring(1);

                    //        ArrayList arr = new ArrayList();
                    //        string dqFields = "";
                    //        foreach (string field in view.ViewFields)
                    //        {
                    //            SPField f = getRealField(list.Fields.GetFieldByInternalName(field));
                    //            arr.Add(f.InternalName.ToLower());
                    //            dqFields += "<FieldRef Name='" + f.InternalName + "' Nullable='TRUE'/>";
                    //        }
                    //        foreach (string groupby in arrGroupFields)
                    //        {
                    //            if (!arr.Contains(groupby.ToLower()))
                    //            {
                    //                arr.Add(groupby.ToLower());
                    //                dqFields += "<FieldRef Name='" + groupby + "' Nullable='TRUE'/>";
                    //            }
                    //        }

                    //        XmlDocument doc = new XmlDocument();
                    //        doc.LoadXml("<Where>" + spquery + "</Where>");
                    //        XmlNode nl = doc.FirstChild.SelectSingleNode("//OrderBy");
                    //        if(nl != null)
                    //        {
                    //            foreach (XmlNode nd in nl.ChildNodes)
                    //            {
                    //                string fname = nd.Attributes["Name"].Value;
                    //                if (!arr.Contains(fname.ToLower()))
                    //                {
                    //                    arr.Add(fname.ToLower());
                    //                    dqFields += "<FieldRef Name='" + fname + "' Nullable='TRUE'/>";
                    //                }
                    //            }
                    //        }


                    //        if (!arr.Contains("title") && list.Fields.ContainsField("Title"))
                    //        {
                    //            dqFields += "<FieldRef Name='Title' Nullable='TRUE'/>";
                    //        }
                    //        if (!arr.Contains("created"))
                    //        {
                    //            dqFields += "<FieldRef Name='Created'/>";
                    //        }
                    //        if (!arr.Contains("_moderationstatus"))
                    //        {
                    //            dqFields += "<FieldRef Name='_ModerationStatus' Nullable='TRUE'/>";
                    //        }
                    //        if (filterfield != "")
                    //        {
                    //            if (!arr.Contains(filterfield.ToLower()))
                    //            {
                    //                dqFields += "<FieldRef Name='" + filterfield + "' Nullable='TRUE'/>";
                    //            }
                    //        }
                    //        if (usewbs != "")
                    //        {
                    //            if (!arr.Contains(usewbs.ToLower()))
                    //            {
                    //                dqFields += "<FieldRef Name='" + usewbs + "' Nullable='TRUE'/>";
                    //            }
                    //        }
                    //        if (!arr.Contains("list"))
                    //        {
                    //            dqFields += "<FieldRef Name='List' Nullable='TRUE'/>";
                    //        }

                    //        foreach (string rlist in rolluplists)
                    //        {
                    //            try
                    //            {
                    //                lists = "";
                    //                string query = "";
                    //                if (siteurl == "")
                    //                    query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='" + web.Site.ID + "' AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";
                    //                else
                    //                    query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '" + siteurl + "/%' OR dbo.Webs.FullUrl = '" + siteurl + "') AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";

                    //                SqlCommand cmd = new SqlCommand(query, cn);
                    //                //cmd.Parameters.AddWithValue("@rlist", rlist);
                    //                SqlDataReader dr = cmd.ExecuteReader();

                    //                while (dr.Read())
                    //                {
                    //                    lists += "<List ID='" + dr.GetGuid(0).ToString() + "'/>";
                    //                }
                    //                dr.Close();

                    //                if (lists != "")
                    //                {
                    //                    SPSiteDataQuery dq = new SPSiteDataQuery();
                    //                    dq.Lists = "<Lists MaxListLimit='0'>" + lists + "</Lists>";
                    //                    dq.Query = spquery;
                    //                    dq.Webs = "<Webs Scope='Recursive'/>";
                    //                    dq.ViewFields = dqFields;
                    //                    try
                    //                    {
                    //                        DataTable dt = web.GetSiteData(dq);
                    //                        dt.Columns.Add("SiteURL");
                    //                        dt.Columns.Add("siteid");
                    //                        if (filterfield != "")
                    //                        {
                    //                            try
                    //                            {
                    //                                processListDT(web, dt.Select(filterfield + " = '" + filtervalue + "'"), arrGTemp, rlist);
                    //                            }
                    //                            catch { }
                    //                        }
                    //                        else
                    //                            processListDT(web, dt.Select(), arrGTemp, rlist);
                    //                    }
                    //                    catch (Exception ex)
                    //                    {
                    //                        globalError += "Error getting site data: " + ex.Message + "<br>";
                    //                    }
                    //                }
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                globalError += "Error getting site data lists: " + ex.Message + "<br>";
                    //            }

                    //        }


                    //        cn.Close();
                    //    }
                    //    catch { }
                    //    cn.Close();
                    //}
                    //dq.Lists = "<Lists ServerTemplate='10701'/>";

                }
            }



            //if (rolluplists != null)
            //{
            //    foreach (SPWeb w in web.Webs)
            //    {
            //        try
            //        {
            //            addGroups(w, spquery, arrGTemp);
            //        }
            //        catch { }
            //        w.Close();
            //    }
            //}
        }

        private void setInitialAggs(string grouping)
        {
            foreach (DictionaryEntry de in arrAggregationDef)
            {
                try
                {
                    SPField field = getRealField(list.Fields.GetFieldByInternalName(de.Key.ToString()));
                    switch (de.Value.ToString())
                    {
                        case "COUNT":
                            arrAggregationVals[grouping + "\n" + de.Key] = 0;
                            break;
                        case "AVG":
                        case "STDEV":
                            arrAggregationVals[grouping + "\n" + de.Key] = "";
                            break;
                        case "SUM":
                            arrAggregationVals[grouping + "\n" + de.Key] = 0;
                            break;
                        case "MIN":
                            if (field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.Calculated || field.TypeAsString == "TotalRollup")
                            {
                                arrAggregationVals[grouping + "\n" + de.Key] = "";
                            }
                            else if (field.Type == SPFieldType.DateTime)
                            {
                                arrAggregationVals[grouping + "\n" + de.Key] = DateTime.MaxValue;
                            }
                            break;
                        case "MAX":
                            if (field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.Calculated || field.TypeAsString == "TotalRollup")
                            {
                                arrAggregationVals[grouping + "\n" + de.Key] = "";
                            }
                            else if (field.Type == SPFieldType.DateTime)
                            {
                                arrAggregationVals[grouping + "\n" + de.Key] = DateTime.MinValue;
                            }
                            break;
                    };
                }
                catch { }
            }
        }

        public virtual void populateGroups(string query, SortedList arrGTemp, SPWeb curWeb)
        {
            if (rollupsites == null)
            {
                if (executive == "on")
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite site = new SPSite(curWeb.Site.Url))
                        {
                            using (SPWeb web = site.OpenWeb(curWeb.ID))
                            {
                                addGroups(web, query, arrGTemp);
                            }
                        }
                    });
                }
                else
                {
                    addGroups(curWeb, query, arrGTemp);
                }

            }
            else
            {
                foreach (string sWeb in rollupsites)
                {
                    try
                    {
                        using (SPSite site = new SPSite(sWeb))
                        {
                            using (SPWeb web = site.OpenWeb())
                            {
                                addGroups(web, query, arrGTemp);
                            }
                        }
                    }
                    catch { }
                }
            }
        }
        private string GetLookupValuesQuery()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in lookupFilterIDs)
            {
                sb.Append("<Value Type=\"Text\">");
                sb.Append(HttpUtility.HtmlEncode(s));
                sb.Append("</Value>");
            }

            return sb.ToString();
        }

        private string GetReportFilters()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in reportFilterIDs)
            {
                sb.Append("<Value Type=\"Text\">");
                sb.Append(HttpUtility.HtmlEncode(s));
                sb.Append("</Value>");
            }

            return sb.ToString();
        }

        private void appendLookupQuery(ref XmlDocument xmlQuery, ref ArrayList arrTempGroups)
        {
            SPWeb web = SPContext.Current.Web;
            if (!string.IsNullOrEmpty(lookupFilterField) && !String.IsNullOrEmpty(lookupFilterFieldList))
            {

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    //using (SPSite s = SPContext.Current.Site)
                    {
                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("SELECT VALUE FROM PERSONALIZATIONS where userid=@userid and [key]=@key and listid=@listid", cn);
                        cmd.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
                        cmd.Parameters.AddWithValue("@key", "LIP");
                        cmd.Parameters.AddWithValue("@listid", lookupFilterFieldList);
                        cmd.ExecuteNonQuery();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            lookupFilterIDs = new ArrayList(dr.GetString(0).Split(','));
                        }
                        dr.Close();
                        cn.Close();
                    }
                });

                if (lookupFilterIDs.Count < MAX_LOOKUPFILTER)
                {
                    XmlNode ndWhere = null;
                    ndWhere = xmlQuery.FirstChild.SelectSingleNode("Where");
                    if (ndWhere == null)
                    {
                        ndWhere = xmlQuery.CreateElement("Where");
                        xmlQuery.FirstChild.PrependChild(ndWhere);

                        ndWhere.InnerXml = "<In><FieldRef Name=\"" + lookupFilterField + "\"/><Values>" + GetLookupValuesQuery() + "</Values></In>";
                    }
                    else
                    {
                        ndWhere.InnerXml = "<And><In><FieldRef Name=\"" + lookupFilterField + "\"/><Values>" + GetLookupValuesQuery() + "</Values></In>" + ndWhere.InnerXml + "</And>";
                    }

                }
                else if (lookupFilterIDs.Count >= MAX_LOOKUPFILTER)
                {
                    arrTempGroups.Add(lookupFilterField);
                }
            }

            try
            {
                string searchtypedisplay = "Contains";
                switch (sSearchType)
                {
                    case "2":
                        searchtypedisplay = "Eq";
                        break;
                    case "3":
                        searchtypedisplay = "Neq";
                        break;
                    case "4":
                        searchtypedisplay = "Gt";
                        break;
                    case "5":
                        searchtypedisplay = "Geq";
                        break;
                    case "6":
                        searchtypedisplay = "Lt";
                        break;
                    case "7":
                        searchtypedisplay = "Leq";
                        break;
                    case "8":
                        searchtypedisplay = "BeginsWith";
                        break;

                };

                if (!String.IsNullOrEmpty(sSearchField))
                {
                    XmlNode ndWhere = null;
                    ndWhere = xmlQuery.FirstChild.SelectSingleNode("Where");

                    string query = "<" + searchtypedisplay + "><FieldRef Name=\"" + sSearchField + "\"/><Value Type=\"Text\">" + HttpUtility.HtmlEncode(sSearchValue) + "</Value></" + searchtypedisplay + ">";

                    if (searchtypedisplay == "Eq" && sSearchValue == "")
                    {
                        query = "<Or>" + query + "<IsNull><FieldRef Name=\"" + sSearchField + "\"/></IsNull></Or>";
                    }

                    if (ndWhere == null)
                    {
                        ndWhere = xmlQuery.CreateElement("Where");
                        xmlQuery.FirstChild.PrependChild(ndWhere);



                        ndWhere.InnerXml = query;
                    }
                    else
                    {
                        ndWhere.InnerXml = "<And>" + query + ndWhere.InnerXml + "</And>";
                    }
                }
            }
            catch { }

            if (!string.IsNullOrEmpty(LookupFilterField))
            {
                XmlNode ndWhere = null;
                ndWhere = xmlQuery.FirstChild.SelectSingleNode("Where");
                if (ndWhere == null)
                {
                    ndWhere = xmlQuery.CreateElement("Where");
                    xmlQuery.FirstChild.PrependChild(ndWhere);

                    ndWhere.InnerXml = "<Eq><FieldRef Name=\"" + LookupFilterField + "\"  LookupId='TRUE'/><Value Type=\"Lookup\">" + HttpUtility.HtmlEncode(LookupFilterValue) + "</Value></Eq>";
                }
                else
                {
                    ndWhere.InnerXml = "<And><Eq><FieldRef Name=\"" + LookupFilterField + "\"  LookupId='TRUE'/><Value Type=\"Lookup\">" + HttpUtility.HtmlEncode(LookupFilterValue) + "</Value></Eq>" + ndWhere.InnerXml + "</And>";
                }
            }

            if (!string.IsNullOrEmpty(ReportID))
            {
                Guid listid = Guid.Empty;


                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    try
                    {
                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("SELECT VALUE,listid FROM PERSONALIZATIONS where userid=@userid and [key]=@key and FK=@FK", cn);
                        cmd.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
                        cmd.Parameters.AddWithValue("@key", "ReportFilterWebPartSelections");
                        cmd.Parameters.AddWithValue("@FK", ReportID);
                        cmd.ExecuteNonQuery();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            reportFilterIDs = new ArrayList(dr.GetString(0).Split('|')[0].Split(','));
                            listid = dr.GetGuid(1);
                        }
                        dr.Close();
                        cn.Close();
                    }
                    catch { }
                });

                if (listid == list.ID)
                {
                    reportFilterField = "Title";

                    if (reportFilterIDs.Count < MAX_LOOKUPFILTER)
                    {
                        XmlNode ndWhere = null;
                        ndWhere = xmlQuery.FirstChild.SelectSingleNode("Where");
                        if (ndWhere == null)
                        {
                            ndWhere = xmlQuery.CreateElement("Where");
                            xmlQuery.FirstChild.PrependChild(ndWhere);

                            ndWhere.InnerXml = "<In><FieldRef Name=\"Title\"/><Values>" + GetReportFilters() + "</Values></In>";
                        }
                        else
                        {
                            ndWhere.InnerXml = "<And><In><FieldRef Name=\"Title\"/><Values>" + GetReportFilters() + "</Values></In>" + ndWhere.InnerXml + "</And>";
                        }

                    }
                    else if (reportFilterIDs.Count >= MAX_LOOKUPFILTER)
                    {
                        //arrTempGroups.Add(lookupFilterField);
                    }
                }
                else if (listid != Guid.Empty)
                {



                    foreach (SPField oField in list.Fields)
                    {
                        if (oField.Type == SPFieldType.Lookup)
                        {
                            try
                            {
                                SPFieldLookup oLookup = (SPFieldLookup)oField;
                                if (new Guid(oLookup.LookupList) == listid)
                                {
                                    reportFilterField = oLookup.InternalName;
                                    break;
                                }
                            }
                            catch { }
                        }
                    }


                    if (reportFilterIDs.Count < MAX_LOOKUPFILTER && reportFilterField != "")
                    {
                        XmlNode ndWhere = null;
                        ndWhere = xmlQuery.FirstChild.SelectSingleNode("Where");
                        if (ndWhere == null)
                        {
                            ndWhere = xmlQuery.CreateElement("Where");
                            xmlQuery.FirstChild.PrependChild(ndWhere);

                            ndWhere.InnerXml = "<In><FieldRef Name=\"" + reportFilterField + "\"/><Values>" + GetReportFilters() + "</Values></In>";
                        }
                        else
                        {
                            ndWhere.InnerXml = "<And><In><FieldRef Name=\"" + reportFilterField + "\"/><Values>" + GetReportFilters() + "</Values></In>" + ndWhere.InnerXml + "</And>";
                        }

                    }
                    else if (reportFilterIDs.Count >= MAX_LOOKUPFILTER)
                    {
                        //arrTempGroups.Add(lookupFilterField);
                    }
                }


            }
        }

        private void addGroups(SPWeb curWeb)
        {
            string query = getQuery();

            XmlDocument querydoc = new XmlDocument();
            querydoc.LoadXml("<Query>" + query + "</Query>");
            XmlNode ndGroupBy = querydoc.SelectSingleNode("//GroupBy");
            int counter = 0;
            ArrayList arrTempGroups = new ArrayList();
            if (ndGroupBy != null)
            {
                foreach (XmlNode nd in ndGroupBy.ChildNodes)
                {
                    string groupfield = nd.Attributes["Name"].Value;
                    arrTempGroups.Add(groupfield);
                }
            }
            foreach (string additionalgroup in additionalgroups.Split('|'))
            {
                if (additionalgroup.Trim() != "")
                    arrTempGroups.Add(additionalgroup);
            }



            XmlDocument xmlQuery = new XmlDocument();
            xmlQuery.LoadXml("<Query>" + query + "</Query>");

            ndGroupBy = xmlQuery.SelectSingleNode("//GroupBy");
            if (ndGroupBy != null)
            {
                xmlQuery.ChildNodes[0].RemoveChild(ndGroupBy);
            }


            appendLookupQuery(ref xmlQuery, ref arrTempGroups);

            


            arrGroupFields = new string[arrTempGroups.Count];
            foreach (string s in arrTempGroups)
            {
                arrGroupFields[counter++] = s;
            }


            SortedList arrGTemp = new SortedList();

            if (arrGroupFields.Length > 0)
            {

                XmlNode ndOrderBy = xmlQuery.FirstChild.SelectSingleNode("//OrderBy");
                if (ndOrderBy == null)
                {
                    ndOrderBy = xmlQuery.CreateNode(XmlNodeType.Element, "OrderBy", docXml.NamespaceURI);
                    xmlQuery.FirstChild.AppendChild(ndOrderBy);
                }
                foreach (string sG in arrGroupFields)
                {
                    XmlNode nd = xmlQuery.FirstChild.SelectSingleNode("//OrderBy/FieldRef[@Name='" + sG + "']");
                    if (nd == null)
                    {
                        XmlNode newNode = xmlQuery.CreateNode(XmlNodeType.Element, "FieldRef", docXml.NamespaceURI);
                        XmlAttribute attrId = xmlQuery.CreateAttribute("Name");
                        attrId.Value = sG;
                        newNode.Attributes.Append(attrId);
                        ndOrderBy.PrependChild(newNode);
                    }
                }
            }
                query = xmlQuery.ChildNodes[0].InnerXml;

            populateGroups(query, arrGTemp, curWeb);

            /////////////////////
            foreach (DictionaryEntry e in arrGTemp)
            {
                string newItem = e.Key.ToString();
                int parentInd = newItem.LastIndexOf("\n");
                string parent = "";

                if (parentInd >= 0)
                {
                    parent = newItem.Substring(0, parentInd);
                    newItem = newItem.Substring(parentInd + 1);
                }

                if ((hshItemNodes.Contains(parent) && !hshItemNodes.Contains(e.Key.ToString())) || (parentInd == -1 && !hshItemNodes.Contains(e.Key.ToString())))
                {
                    XmlNode ndParent = null;
                    if (parentInd == -1)
                        ndParent = ndMainParent;
                    else
                        ndParent = (XmlNode)hshItemNodes[parent];


                    XmlNode newNode = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
                    XmlAttribute attrId = docXml.CreateAttribute("id");

                    if (e.Key.ToString() != "")
                        attrId.Value = e.Key.ToString();
                    else
                        attrId.Value = Guid.NewGuid().ToString();

                    newNode.Attributes.Append(attrId);
                    XmlAttribute attrLocked = docXml.CreateAttribute("locked");
                    attrLocked.Value = "1";
                    newNode.Attributes.Append(attrLocked);

                    int indentlevel = e.Key.ToString().Split('\n').Length;

                    if (expandlevel == 0 && expanded == "FALSE")
                    {
                        XmlAttribute attrExpand = docXml.CreateAttribute("open");
                        attrExpand.Value = "1";
                        newNode.Attributes.Append(attrExpand);
                    }
                    else if (expandlevel >= indentlevel)
                    {
                        XmlAttribute attrExpand = docXml.CreateAttribute("open");
                        attrExpand.Value = "1";
                        newNode.Attributes.Append(attrExpand);
                    }

                    ndParent.AppendChild(newNode);

                    if (inEditMode)
                    {
                        XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCell.InnerText = "";
                        newNode.AppendChild(newCell);
                    }
                    if (showCheckboxes && !isTimesheet)
                    {
                        XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        ndNewCell.InnerXml = "<![CDATA[<input type=\"checkbox\" onClick=\"mygrid" + gridname + ".checksubs(this);(arguments[0]||event).cancelBubble=true;RefreshCommandUI();\" style=\"display:none;\" id=\"chkrow\">]]>";
                        newNode.AppendChild(ndNewCell);

                        //XmlAttribute attrType = docXml.CreateAttribute("type");
                        //attrType.Value = "ro";
                        //ndNewCell.Attributes.Append(attrType);

                        newNode.AppendChild(ndNewCell);
                    }
                    if (!titleFieldFound)
                    {
                        XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        if (newItem == "")
                            newCell.InnerText = "No Value";
                        else
                            newCell.InnerText = newItem;
                        newNode.AppendChild(newCell);
                    }
                    foreach (string f in view.ViewFields)
                    {
                        SPField field = getRealField(list.Fields.GetFieldByInternalName(f));
                        if (field.InternalName == "Title" || field.InternalName == "URL" || field.InternalName == "FileLeafRef")
                        {
                            XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            if (newItem == "")
                                newCell.InnerText = "No Value";
                            else
                                newCell.InnerText = newItem;
                            newNode.AppendChild(newCell);
                        }
                        else
                        {
                            XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newNode.AppendChild(newCell);
                            XmlAttribute attrCellId = docXml.CreateAttribute("id");
                            attrCellId.Value = field.InternalName;
                            newCell.Attributes.Append(attrCellId);
                            XmlAttribute attrType = docXml.CreateAttribute("type");
                            attrType.Value = "ro";
                            newCell.Attributes.Append(attrType);
                        }
                    }

                    XmlAttribute attrBold = docXml.CreateAttribute("style");
                    attrBold.Value = "font-weight:bold;";
                    newNode.Attributes.Append(attrBold);

                    hshItemNodes.Add(e.Key.ToString(), newNode);

                    arrGroupMin.Add(e.Key.ToString(), DateTime.MaxValue);
                    arrGroupMax.Add(e.Key.ToString(), DateTime.MinValue);
                    //SPViewFieldCollection vfc = view.ViewFields;
                    //for (int i = 0; i < vfc.Count; i++)
                    //{
                    //    arrAggregationVals.Add(e.Key.ToString() + "\n" + vfc[i], "");
                    //}
                    setInitialAggs(e.Key.ToString());
                }
            }

        }

        private void addHeader()
        {

            float inWidth = 1000;
            try
            {
                inWidth = float.Parse(Request["width"]);
            }
            catch { }
            inWidth -= 5;
            XmlNode ndHead = docXml.CreateNode(XmlNodeType.Element, "head", docXml.NamespaceURI);
            docXml.ChildNodes[0].AppendChild(ndHead);
            ndBeforeInit = docXml.CreateNode(XmlNodeType.Element, "beforeInit", docXml.NamespaceURI);
            ndHead.AppendChild(ndBeforeInit);
            XmlNode afterInitNode = docXml.CreateNode(XmlNodeType.Element, "afterInit", docXml.NamespaceURI);
            ndHead.AppendChild(afterInitNode);

            XmlNode callNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
            XmlAttribute attr = docXml.CreateAttribute("command");
            attr.Value = "attachHeader";
            callNode.Attributes.Append(attr);

            XmlNode ndSettings = docXml.CreateNode(XmlNodeType.Element, "settings", docXml.NamespaceURI);
            XmlNode ndColwith = docXml.CreateNode(XmlNodeType.Element, "colwidth", docXml.NamespaceURI);
            ndColwith.InnerText = "%";
            //ndSettings.AppendChild(ndColwith);
            ndHead.AppendChild(ndSettings);

            if (inEditMode)
            {
                ndNewRowCells = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
            }

            int counter = 0;
            string filterfield = "";
            string tooltips = "";
            if (isResPlan)
                counter = 1;
            if (inEditMode)
            {
                counter = 1;

                XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                ndNewColumn.InnerXml = "<![CDATA[&nbsp;]]>";

                XmlAttribute attrType = docXml.CreateAttribute("type");
                attrType.Value = "ro";
                XmlAttribute attrWidth = docXml.CreateAttribute("width");
                attrWidth.Value = "25";
                XmlAttribute attrAlign = docXml.CreateAttribute("align");
                attrAlign.Value = "center";
                XmlAttribute attrColor = docXml.CreateAttribute("color");
                attrColor.Value = "#F0F0F0";

                ndNewColumn.Attributes.Append(attrType);
                ndNewColumn.Attributes.Append(attrWidth);
                ndNewColumn.Attributes.Append(attrAlign);
                ndNewColumn.Attributes.Append(attrColor);
                ndHead.AppendChild(ndNewColumn);

                filterfield += ",&nbsp;";

                inWidth -= 25;
            }
            if (showCheckboxes && !isTimesheet)
            {
                counter++;

                XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                ndNewColumn.InnerXml = "<![CDATA[#master_checkbox2]]>";

                XmlAttribute attrType = docXml.CreateAttribute("type");
                attrType.Value = "ro";
                XmlAttribute attrWidth = docXml.CreateAttribute("width");
                attrWidth.Value = "25";
                XmlAttribute attrAlign = docXml.CreateAttribute("align");
                attrAlign.Value = "center";

                ndNewColumn.Attributes.Append(attrType);
                ndNewColumn.Attributes.Append(attrWidth);
                ndNewColumn.Attributes.Append(attrAlign);
                ndHead.AppendChild(ndNewColumn);

                filterfield += ",&nbsp;";

                inWidth -= 25;
            }
            if (isTimesheet)
            {
                //if (Request["status"].ToLower() != "submitted" && Request["status"].ToLower() != "approved")
                {
                    counter++;
                }
            }

            double fwidth;

            int fieldcounter = 0;

            foreach (string field in view.ViewFields)
            {
                SPField f = getRealField(list.Fields.GetFieldByInternalName(field));
                if (f.InternalName == "Title" || f.InternalName == "FileLeafRef" || f.InternalName == "URL")
                {
                    titleFieldFound = true;
                }
                if (f.InternalName == "Edit" || f.InternalName == "DocIcon" || f.InternalName == "WorkspaceUrl")
                {
                    inWidth -= 60;
                }
                else
                {
                    fieldcounter++;
                }
            }


            if (!hasGroups && additionalgroups == "|" && !titleFieldFound)
            {
                titleFieldFound = true;
                fwidth = (inWidth / (float)(fieldcounter));
                if (inEditMode)
                    fwidth -= (2 / (float)fieldcounter);
            }
            else if (titleFieldFound)
            {
                fwidth = (inWidth / (float)(fieldcounter + 1));
            }
            else
            {
                fwidth = (inWidth / (float)(fieldcounter + 2));

                double tWidth = Math.Round(fwidth * 2, 2);

                string width = tWidth.ToString(providerEn);
                XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                ndNewColumn.InnerXml = "<![CDATA[&nbsp;]]>";

                XmlAttribute attrType = docXml.CreateAttribute("type");
                attrType.Value = "tree";
                XmlAttribute attrWidth = docXml.CreateAttribute("width");
                attrWidth.Value = width;

                ndNewColumn.Attributes.Append(attrType);
                ndNewColumn.Attributes.Append(attrWidth);

                ndHead.AppendChild(ndNewColumn);
                counter++;

                filterfield += ",&nbsp;";
            }

            foreach (string field in view.ViewFields)
            {

                tooltips += ",true";
                SPField f = getRealField(list.Fields.GetFieldByInternalName(field));
                string FieldTitle = f.Title;
                string width = Math.Round(fwidth, 2).ToString(providerEn);

                string strType = "ro";
                string strAlign = "left";
                string strSort = "str";
                string inputs = "";

                try
                {
                    if (f.InternalName == "DocIcon")
                    {
                        filterfield += ",&nbsp;";
                        width = "60";
                    }
                    else if (f.InternalName == "WorkspaceUrl")
                    {
                        filterfield += ",&nbsp;";
                        width = "60";
                        strAlign = "center";
                        FieldTitle = "";
                    }
                    else if (f.InternalName == "Edit")
                    {
                        filterfield += ",&nbsp;";
                        width = "60";
                        strAlign = "center";
                    }
                    else if (f.InternalName == "WBS")
                    {
                        filterfield += ",#select_filter";
                        //width = "50";
                    }
                    else if (f.InternalName == "List")
                    {
                        string items = "<option value=\"\"></option>";
                        foreach (DictionaryEntry de in hshLists)
                        {
                            items += "<option value=\"" + de.Key + "\">" + de.Key + "</option>";
                        }
                        filterfield += ",<select onClick=\"(arguments[0]||event).cancelBubble=true;\" onChange=\"gridfilter" + gridname + "('" + counter + "|' + this.value);\" style='margin-top: 1px; width: 90%; font-family: Tahoma; font-size: 8pt;'>" + items + "</select>";
                        if (!hshColumnSelectFilter.Contains(f.InternalName))
                            hshColumnSelectFilter.Add(f.InternalName, "");
                    }
                    else if (f.InternalName == "Title" || f.InternalName == "FileLeafRef" || f.InternalName == "URL")
                    {
                        filterfield += ",<select onClick=\"(arguments[0]||event).cancelBubble=true;\" onChange=\"gridfilter" + gridname + "('" + counter + "|' + this.value);\" style='margin-top: 1px; width: 90%; font-family: Tahoma; font-size: 8pt;'>#" + f.InternalName + "#</select>";
                        if (!hshColumnSelectFilter.Contains(f.InternalName))
                            hshColumnSelectFilter.Add(f.InternalName, "");

                        treeCol = counter;
                        strType = "tree";
                        double tWidth = Math.Round(fwidth * 2, 2);
                        if (inEditMode)
                            tWidth -= 2;
                        width = tWidth.ToString(providerEn);
                    }
                    else if (f.TypeAsString == "TotalRollup")
                    {
                        filterfield += ",#select_filter";
                        strAlign = "right";
                    }
                    else if (f.InternalName == "ContentType")
                    {


                        if (inEditMode && rolluplists == null && list.ContentTypesEnabled)
                        {

                            filterfield += ",#select_filter";

                            if (!hshColumnSelectFilter.Contains(f.InternalName))
                                hshColumnSelectFilter.Add(f.InternalName, "");

                            strType = "choice";
                            //choices = getLookupList(f.ParentList.ParentWeb, lookuplist, lookupfield);

                            string cts = "";
                            foreach (SPContentType ct in list.ContentTypes)
                            {
                                if (!ct.Hidden)
                                {
                                    if (ct.Parent.Name == "Folder")
                                    {
                                        if (list.EnableFolderCreation)
                                            cts += "\n" + ct.Name + ";#" + ct.Name;
                                    }
                                    else
                                    {
                                        cts += "\n" + ct.Name + ";#" + ct.Name;
                                    }
                                }
                            }

                            if (cts.Length > 1)
                                cts = cts.Substring(1);

                            hshComboCells[f.InternalName + "-" + f.ParentList.ID.ToString() + "-" + f.ParentList.ParentWeb.ID.ToString()] = cts;

                        }
                        else
                        {
                            filterfield += ",#select_filter";
                            strType = "ro";
                        }

                    }
                    else
                    {
                        XmlDocument fieldXml = new XmlDocument();
                        fieldXml.LoadXml(f.SchemaXml);
                        System.Globalization.CultureInfo cInfo = new System.Globalization.CultureInfo(f.ParentList.ParentWeb.Locale.LCID);
                        switch (f.Type)
                        {
                            case SPFieldType.Note:
                                if (f.SchemaXml.Contains("RichText=\"FALSE\""))
                                    strType = "txt";
                                filterfield += ",&nbsp;";
                                break;
                            case SPFieldType.Calculated:
                                if (f.Description == "Indicator")
                                {
                                    filterfield += ",";
                                    strAlign = "center";
                                    //width = "60";
                                }
                                else
                                {
                                    string resulttype = "";
                                    try
                                    {
                                        resulttype = fieldXml.ChildNodes[0].Attributes["ResultType"].Value;
                                    }
                                    catch { }
                                    switch (resulttype)
                                    {
                                        case "DateTime":
                                            filterfield += ",#select_filter";
                                            strAlign = "right";
                                            strSort = "date";
                                            break;
                                        case "Text":
                                            filterfield += ",#select_filter";
                                            strAlign = "left";
                                            break;
                                        case "Currency":
                                        case "Number":
                                            strSort = "int";
                                            filterfield += ",#select_filter";
                                            strAlign = "right";
                                            break;
                                        default:
                                            filterfield += ",#select_filter";
                                            strAlign = "left";
                                            break;
                                    };
                                }
                                break;
                            case SPFieldType.DateTime:
                                if (inEditMode)
                                    strType = "dhxCalendarA";
                                strSort = "date";
                                string format = "";
                                try
                                {
                                    format = fieldXml.ChildNodes[0].Attributes["Format"].Value;
                                }
                                catch { }
                                //if (format == "DateOnly")
                                //    width = "80";
                                //else
                                //    width = "130";
                                strAlign = "right";
                                filterfield += ",#select_filter";
                                break;
                            case SPFieldType.Number:

                                strSort = "int";
                                filterfield += ",#select_filter";
                                //width = "80";
                                strAlign = "right";
                                if (inEditMode)
                                {
                                    strType = "edn";
                                    if (f.SchemaXml.Contains("Percentage=\"TRUE\""))
                                    {
                                        string decimals = "";
                                        int decCount = 0;
                                        XmlDocument dec = new XmlDocument();
                                        dec.LoadXml(f.SchemaXml);

                                        try
                                        {
                                            decCount = int.Parse(dec.FirstChild.Attributes["Decimals"].Value);
                                        }
                                        catch { }

                                        for (int i = 0; i < decCount; i++)
                                        {
                                            decimals += "0";
                                        }

                                        if (decCount > 0)
                                            decimals = "." + decimals;

                                        XmlNode cNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                                        attr = docXml.CreateAttribute("command");
                                        attr.Value = "setNumberFormat";
                                        cNode.Attributes.Append(attr);
                                        cNode.InnerXml = "<param>0,000" + decimals + "%</param><param>" + counter.ToString() + "</param><param>" + cInfo.NumberFormat.CurrencyDecimalSeparator + "</param><param>" + cInfo.NumberFormat.CurrencyGroupSeparator + "</param>";
                                        ndBeforeInit.AppendChild(cNode);
                                    }
                                    else
                                    {
                                        string decimals = "";
                                        int decCount = 0;
                                        XmlDocument dec = new XmlDocument();
                                        dec.LoadXml(f.SchemaXml);

                                        try
                                        {
                                            decCount = int.Parse(dec.FirstChild.Attributes["Decimals"].Value);
                                        }
                                        catch { }

                                        for (int i = 0; i < decCount; i++)
                                        {
                                            decimals += "0";
                                        }

                                        if (decCount > 0)
                                            decimals = "." + decimals;

                                        XmlNode cNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                                        attr = docXml.CreateAttribute("command");
                                        attr.Value = "setNumberFormat";
                                        cNode.Attributes.Append(attr);
                                        cNode.InnerXml = "<param>0,000" + decimals + "</param><param>" + counter.ToString() + "</param><param>" + cInfo.NumberFormat.CurrencyDecimalSeparator + "</param><param>" + cInfo.NumberFormat.CurrencyGroupSeparator + "</param>";
                                        ndBeforeInit.AppendChild(cNode);
                                    }
                                }
                                break;
                            case SPFieldType.Currency:
                                strSort = "int";
                                filterfield += ",#select_filter";
                                //width = "80";
                                strAlign = "right";
                                if (inEditMode)
                                {
                                    string decimals = "";
                                    int decCount = 0;
                                    XmlDocument dec = new XmlDocument();
                                    dec.LoadXml(f.SchemaXml);

                                    try
                                    {
                                        decCount = int.Parse(dec.FirstChild.Attributes["Decimals"].Value);
                                    }
                                    catch { }

                                    for (int i = 0; i < decCount; i++)
                                    {
                                        decimals += "0";
                                    }

                                    if (decCount > 0)
                                        decimals = "." + decimals;

                                    strType = "edn";

                                    XmlNode cNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                                    attr = docXml.CreateAttribute("command");
                                    attr.Value = "setNumberFormat";
                                    cNode.Attributes.Append(attr);

                                    string symbol = "";
                                    try
                                    {
                                        string lcid = fieldXml.FirstChild.Attributes["LCID"].Value;
                                        symbol = System.Globalization.CultureInfo.GetCultureInfo(int.Parse(lcid)).NumberFormat.CurrencySymbol;
                                    }
                                    catch { }
                                    if (symbol == "")
                                        symbol = cInfo.NumberFormat.CurrencySymbol;

                                    cNode.InnerXml = "<param>" + symbol + "0,000" + decimals + "</param><param>" + counter.ToString() + "</param><param>" + cInfo.NumberFormat.CurrencyDecimalSeparator + "</param><param>" + cInfo.NumberFormat.CurrencyGroupSeparator + "</param>";
                                    ndBeforeInit.AppendChild(cNode);
                                }
                                break;
                            case SPFieldType.Attachments:
                                filterfield += ",  ";
                                break;
                            case SPFieldType.User:
                                //if (inEditMode)
                                //    strType = "usereditor";

                                filterfield += ",<select onClick=\"(arguments[0]||event).cancelBubble=true;\" onChange=\"gridfilter" + gridname + "('" + counter + "|' + this.value);\" style='margin-top: 1px; width: 90%; font-family: Tahoma; font-size: 8pt;'>#" + f.InternalName + "#</select>";
                                if (!hshColumnSelectFilter.Contains(f.InternalName))
                                    hshColumnSelectFilter.Add(f.InternalName, "");

                                if (inEditMode)
                                {
                                    string mode = "";
                                    try
                                    {
                                        mode = fieldXml.FirstChild.Attributes["UserSelectionMode"].Value;
                                    }
                                    catch { }
                                    string choices = getMultiUser(mode, f.ParentList.ParentWeb);
                                    if (fieldXml.InnerXml.Contains("Type=\"UserMulti\""))
                                        strType = "usereditorm";
                                    else
                                        strType = "usereditor";
                                    hshComboCells[f.InternalName + "-" + f.ParentList.ParentWeb.ID.ToString()] = choices;
                                    inputs += "\t" + choices;
                                }
                                break;
                            case SPFieldType.Boolean:
                                if (inEditMode)
                                    strType = "ch";
                                filterfield += ",#select_filter";
                                strAlign = "center";
                                break;
                            case SPFieldType.Choice:

                                filterfield += ",<select onClick=\"(arguments[0]||event).cancelBubble=true;\" onChange=\"gridfilter" + gridname + "('" + counter + "|' + this.value);\" style='margin-top: 1px; width: 90%; font-family: Tahoma; font-size: 8pt;'>#" + f.InternalName + "#</select>";
                                if (!hshColumnSelectFilter.Contains(f.InternalName))
                                    hshColumnSelectFilter.Add(f.InternalName, "");

                                if (inEditMode)
                                {
                                    strType = "choice";
                                    string choices = "";
                                    foreach (XmlNode nd in fieldXml.SelectNodes("//CHOICE"))
                                    {
                                        choices += "\n" + nd.InnerText + ";#" + nd.InnerText;
                                    }
                                    if (choices.Length > 1)
                                        choices = choices.Substring(1);

                                    hshComboCells[f.InternalName + "-" + f.ParentList.ID.ToString() + "-" + f.ParentList.ParentWeb.ID.ToString()] = choices;

                                    inputs += "test\t" + choices;
                                }
                                break;
                            case SPFieldType.MultiChoice:
                                if (inEditMode)
                                {
                                    strType = "mchoice";
                                    string choices = "";
                                    foreach (XmlNode nd in fieldXml.SelectNodes("//CHOICE"))
                                    {
                                        choices += "\n" + nd.InnerText + ";#" + nd.InnerText;
                                    }
                                    if (choices.Length > 1)
                                        choices = choices.Substring(1);

                                    hshComboCells[f.InternalName + "-" + f.ParentList.ID.ToString() + "-" + f.ParentList.ParentWeb.ID.ToString()] = choices;

                                    inputs += "test\t" + choices;
                                }

                                string choiceOptions = "<option value=\"\"></option>";
                                foreach (XmlNode nd in fieldXml.SelectNodes("//CHOICE"))
                                {
                                    choiceOptions += "<option value=\"" + nd.InnerText + "\">" + nd.InnerText + "</option>";
                                }
                                filterfield += ",<select onClick=\"(arguments[0]||event).cancelBubble=true;\" onChange=\"gridfilter" + gridname + "('" + counter + "|' + this.value);\" style='margin-top: 1px; width: 90%; font-family: Tahoma; font-size: 8pt;'>" + choiceOptions + "</select>";
                                //if (!hshColumnSelectFilter.Contains(f.InternalName))
                                //    hshColumnSelectFilter.Add(f.InternalName, "");
                                break;
                            case SPFieldType.Lookup:

                                //filterfield += ",#select_filter";

                                if (inEditMode)
                                {

                                    string lookuplist = fieldXml.ChildNodes[0].Attributes["List"].Value;
                                    string lookupfield = fieldXml.ChildNodes[0].Attributes["ShowField"].Value;
                                    string choices = "";

                                    filterfield += ",<select onClick=\"(arguments[0]||event).cancelBubble=true;\" onChange=\"gridfilter" + gridname + "('" + counter + "|' + this.value);\" style='margin-top: 1px; width: 90%; font-family: Tahoma; font-size: 8pt;'>#" + f.InternalName + "#</select>";
                                    if (!hshColumnSelectFilter.Contains(f.InternalName))
                                        hshColumnSelectFilter.Add(f.InternalName, "");

                                    if (f.TypeAsString == "LookupMulti")
                                    {
                                        strType = "mchoice";
                                        choices = getLookupList(f.ParentList.ParentWeb, lookuplist, lookupfield);
                                    }
                                    else
                                    {
                                        strType = "choice";
                                        choices = getLookupList(f.ParentList.ParentWeb, lookuplist, lookupfield);
                                    }

                                    hshComboCells[f.InternalName + "-" + f.ParentList.ID.ToString() + "-" + f.ParentList.ParentWeb.ID.ToString()] = choices;
                                    inputs += "\t" + choices;
                                    if (choices == "")
                                        strType = "ro";


                                }
                                else
                                    filterfield += ",#select_filter";

                                break;
                            case SPFieldType.Text:
                                if (inEditMode)
                                    strType = "ed";
                                filterfield += ",#select_filter";
                                break;
                            default:
                                switch (f.TypeAsString)
                                {
                                    case "FilteredLookup":
                                        filterfield += ",#select_filter";

                                        if (inEditMode)
                                        {
                                            Guid lookuplist = new Guid(fieldXml.ChildNodes[0].Attributes["List"].Value);
                                            Guid lookupfield = new Guid(fieldXml.ChildNodes[0].Attributes["ShowField"].Value);
                                            Guid lookupweb = new Guid(fieldXml.ChildNodes[0].Attributes["WebId"].Value);

                                            XmlNode nd = fieldXml.ChildNodes[0].SelectSingleNode("Customization").SelectSingleNode("ArrayOfProperty");

                                            string query = nd.SelectSingleNode("Property[Name='QueryFilterAsString']").SelectSingleNode("Value").InnerText;
                                            string listview = nd.SelectSingleNode("Property[Name='ListViewFilter']").SelectSingleNode("Value").InnerText;
                                            string multi = nd.SelectSingleNode("Property[Name='SupportsMultipleValues']").SelectSingleNode("Value").InnerText;
                                            string recurse = nd.SelectSingleNode("Property[Name='IsFilterRecursive']").SelectSingleNode("Value").InnerText;

                                            if (multi.ToLower() == "true")
                                                strType = "mchoice";
                                            else
                                                strType = "choice";



                                            string choices = "";
                                            if (lookupweb == list.ParentWeb.ID)
                                            {
                                                choices = getLookupList(list.ParentWeb, lookuplist, lookupfield, query, listview);
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    using (SPWeb w = list.ParentWeb.Site.OpenWeb(lookupweb))
                                                    {
                                                        choices = getLookupList(w, lookuplist, lookupfield, query, listview);
                                                    }
                                                }
                                                catch { }
                                            }
                                            hshComboCells[f.InternalName + "-" + f.ParentList.ID.ToString() + "-" + f.ParentList.ParentWeb.ID.ToString()] = choices;
                                        }

                                        break;
                                    default:
                                        filterfield += ",#select_filter";
                                        break;
                                }
                                break;
                        };
                        //                        width = "100";
                    }
                }
                catch { }

                if (inEditMode)
                {
                    XmlNode rLookupCall = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                    XmlAttribute attrCommand = docXml.CreateAttribute("command");
                    attrCommand.Value = "registerLookup" + gridname;
                    rLookupCall.Attributes.Append(attrCommand);
                    rLookupCall.InnerXml = "<param>" + counter.ToString() + "</param><param><![CDATA[" + inputs + "]]></param>";
                    afterInitNode.AppendChild(rLookupCall);


                }
                XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                ndNewColumn.InnerXml = "<![CDATA[<div style=\"width:100%; text-align:" + strAlign + ";padding-right:4px\">" + HttpUtility.HtmlEncode(FieldTitle).Replace(",", "&#44;") + "</div>]]>";

                XmlAttribute attrType = docXml.CreateAttribute("type");
                attrType.Value = strType;
                XmlAttribute attrSort = docXml.CreateAttribute("sort");
                attrSort.Value = strSort;
                XmlAttribute attrWidth = docXml.CreateAttribute("width");
                attrWidth.Value = width;
                XmlAttribute attrId = docXml.CreateAttribute("id");
                attrId.Value = "<![CDATA[" + HttpUtility.HtmlEncode(f.InternalName).Replace(",", "&#44;") + "]]>";
                XmlAttribute attrAlign = docXml.CreateAttribute("align");
                attrAlign.Value = strAlign;




                ndNewColumn.Attributes.Append(attrType);
                ndNewColumn.Attributes.Append(attrWidth);
                ndNewColumn.Attributes.Append(attrId);
                ndNewColumn.Attributes.Append(attrSort);
                ndNewColumn.Attributes.Append(attrAlign);
                //if (f.Type == SPFieldType.Choice || f.Type == SPFieldType.Lookup)
                //{
                //    XmlAttribute attrxmlContent = docXml.CreateAttribute("xmlcontent");
                //    attrxmlContent.Value = "1";
                //    XmlAttribute attrAutoComplete = docXml.CreateAttribute("autocomplete");
                //    attrAutoComplete.Value = "1";
                //    ndNewColumn.Attributes.Append(attrxmlContent);
                //    ndNewColumn.Attributes.Append(attrAutoComplete);
                //}
                ndHead.AppendChild(ndNewColumn);

                arrColumns.Add(f.InternalName);
                counter++;
            }

            //if (!titleFieldFound)
            //{
            //    fwidth = (100.00 / (float)(view.ViewFields.Count + 1));


            //    if (inEditMode)
            //    {
            //        ndHead.InsertAfter(ndNewColumn, ndHead.SelectSingleNode("column"));
            //    }
            //    else
            //    {
            //        ndHead.InsertBefore(ndNewColumn, ndHead.SelectSingleNode("column"));
            //    }

            //    //filterfield = "," + filterfield;

            //    treeCol = 1;
            //}


            if (filterfield.Length > 1)
                filterfield = filterfield.Substring(1);

            callNode.InnerXml = "<param><![CDATA[" + filterfield + "]]></param>";
            ndBeforeInit.AppendChild(callNode);

            callNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
            attr = docXml.CreateAttribute("command");
            attr.Value = "enableTooltips";
            callNode.Attributes.Append(attr);
            if (tooltips.Length > 1)
            {
                tooltips = tooltips.Substring(1);
                callNode.InnerXml = "<param>" + tooltips + "</param>";
                ndBeforeInit.AppendChild(callNode);
            }
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

                        string parentField = "";
                        try
                        {
                            parentField = fieldXml.FirstChild.Attributes["DisplayNameSrcField"].Value;
                        }
                        catch { }
                        if (parentField != "")
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

        public virtual void getParams(SPWeb curWeb)
        {
            try
            {
                Hashtable hshParams = new Hashtable();

                byte[] encodedDataAsBytes = System.Convert.FromBase64String(Request["data"]);

                string[] props = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes).Split('\n');

                foreach (string s in props)
                {
                    hshParams.Add(s.Split('\t')[0], s.Split('\t')[1]);
                }

                strlist = hshParams["List"].ToString();
                strview = hshParams["View"].ToString();
                try
                {
                    ReportID = hshParams["ReportID"].ToString();
                }
                catch { }
                try
                {
                    usewbs = hshParams["WBS"].ToString();
                }
                catch { }
                try
                {
                    executive = hshParams["Executive"].ToString();
                }
                catch { }
                try
                {
                    linktype = hshParams["LType"].ToString();
                }
                catch { }
                try
                {
                    lookupFilterField = hshParams["LookupField"].ToString();
                }
                catch { }
                try
                {
                    lookupFilterFieldList = hshParams["LookupFieldList"].ToString();
                }
                catch { }

                try
                {
                    sSearchField = Request["searchfield"].ToString();
                }
                catch { }
                try
                {
                    sSearchValue = Request["searchvalue"].ToString();
                }
                catch { }
                try
                {
                    sSearchType = Request["searchtype"].ToString();
                }
                catch { }

                try
                {
                    if (hshParams["RLists"].ToString() != "")
                    {
                        string[] tRollupLists = hshParams["RLists"].ToString().Split(',');
                        rolluplists = new string[tRollupLists.Length];
                        for (int i = 0; i < tRollupLists.Length; i++)
                        {
                            string[] tRlist = tRollupLists[i].Split('|');
                            rolluplists[i] = tRlist[0];
                            string icon = "";
                            try
                            {
                                icon = tRlist[1];
                            }
                            catch { }
                            hshLists.Add(rolluplists[i], icon);
                        }
                    }
                }
                catch { }

                filterfield = hshParams["FilterField"].ToString();
                filtervalue = hshParams["FilterValue"].ToString();

                try
                {
                    LookupFilterField = hshParams["LookupFilterField"].ToString();
                }
                catch { }
                try
                {
                    LookupFilterValue = hshParams["LookupFilterValue"].ToString();
                }
                catch { }

                try
                {
                    if (hshParams["RSites"].ToString() != "")
                    {
                        rollupsites = hshParams["RSites"].ToString().Split(',');
                    }
                }
                catch { }
                gridname = hshParams["GridName"].ToString();
                try
                {
                    additionalgroups = hshParams["AGroups"].ToString();
                }
                catch { }
                expandlevel = 0;
                try
                {
                    expandlevel = int.Parse(hshParams["Expand"].ToString());
                }
                catch { }

                try
                {
                    InfoField = hshParams["Info"].ToString();
                }
                catch { }
                try
                {
                    StartDateField = hshParams["Start"].ToString();
                }
                catch { }
                try
                {
                    DueDateField = hshParams["Finish"].ToString();
                }
                catch { }
                try
                {
                    ProgressField = hshParams["Percent"].ToString();
                }
                catch { }

                SPList tempList = null;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite s = new SPSite(curWeb.Url))
                    {
                        using (SPWeb w = s.OpenWeb())
                        {
                            tempList = w.GetListFromUrl(strlist);
                        }
                    }
                });

                list = curWeb.Lists[tempList.ID];
                view = list.Views[strview];
                try
                {
                    inEditMode = bool.Parse(Request["edit"]);
                }
                catch { }
                try
                {
                    showinsertrow = bool.Parse(hshParams["ShowInsert"].ToString());
                }
                catch { }
                try
                {
                    usePerformance = false;
                    usePerformance = bool.Parse(hshParams["UsePerf"].ToString());
                }
                catch { }
                try
                {
                    usePopup = false;
                    usePopup = bool.Parse(hshParams["UsePopup"].ToString());
                }
                catch { }
                try
                {
                    requestsenabled = false;
                    requestsenabled = bool.Parse(hshParams["Requests"].ToString());
                }
                catch { }
                try
                {
                    showCheckboxes = false;
                    showCheckboxes = bool.Parse(hshParams["ShowCheckboxes"].ToString());
                }
                catch { }
                try
                {
                    bUseReporting = bool.Parse(hshParams["UseReporting"].ToString());
                }
                catch { }
                try
                {
                    iPageSize = int.Parse(hshParams["PageSize"].ToString());
                }
                catch { }
                try
                {
                    iPage = int.Parse(Request["Page"].ToString());
                }
                catch { }
                try
                {
                    WPID = hshParams["WPID"].ToString();
                }
                catch { }
            }
            catch { }

        }
        public string getField(SPListItem li, string field, bool group)
        {
            string val = "";
            try
            {
                SPField spfield = list.Fields.GetFieldByInternalName(field);
                if (li.ID == 0)
                {
                    XmlDocument fieldXml = new XmlDocument();
                    fieldXml.LoadXml(spfield.SchemaXml);
                    XmlNode ndDefault = fieldXml.SelectSingleNode("//Default");
                    if (ndDefault != null)
                    {
                        val = list.Fields[spfield.Id].GetFieldValue(ndDefault.InnerText).ToString();
                        switch (spfield.Type)
                        {
                            case SPFieldType.DateTime:
                                if (val == "[today]")
                                {
                                    val = DateTime.Now.ToShortDateString();
                                }
                                else
                                {
                                    val = Microsoft.SharePoint.Utilities.SPUtility.CreateDateTimeFromISO8601DateTimeString(val).ToShortDateString();
                                }
                                break;
                        };
                        return val;
                    }
                }
                bool editable = false;
                if (inEditMode && !group)
                {
                    try
                    {
                        if (li.Fields.GetFieldByInternalName(spfield.InternalName).ShowInEditForm == null || li.Fields.GetFieldByInternalName(spfield.InternalName).ShowInEditForm.Value == true)
                            editable = true;
                    }
                    catch { }
                }
                switch (field)
                {
                    case "Site":
                        if (spfield.Type == SPFieldType.URL)
                            return "<a href=\"" + li.ParentList.ParentWeb.ServerRelativeUrl + "\">" + li.ParentList.ParentWeb.Title + "</a>";
                        else
                            return li.ParentList.ParentWeb.Title;
                    case "List":
                        if (spfield.Type == SPFieldType.URL)
                            return "<a href=\"" + li.ParentList.DefaultViewUrl + "\">" + li.ParentList.Title + "</a>";
                        else
                            return li.ParentList.Title;
                    case "Due":
                        return EPMLiveCore.CoreFunctions.GetDueField(li);
                    case "DaysOverdue":
                        return EPMLiveCore.CoreFunctions.GetDaysOverdueField(li);
                    case "ScheduleStatus":
                        return EPMLiveCore.CoreFunctions.GetScheduleStatusField(li);
                    default:
                        spfield = li.Fields.GetFieldByInternalName(field);
                        val = li[spfield.Id].ToString();

                        //if (spfield.TypeAsString == "TotalRollup")
                        //{
                        //    try
                        //    {
                        //        //val = double.Parse(val,providerEn).ToString("0");
                        //    }catch{}
                        //}
                        switch (spfield.Type)
                        {
                            case SPFieldType.DateTime:
                                try
                                {
                                    return ((DateTime)li[spfield.Id]).ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                catch { }
                                break;
                            case SPFieldType.User:
                                if (group)
                                {
                                    string retVal = "";
                                    SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                                    foreach (SPFieldLookupValue lv in lvc)
                                    {
                                        retVal += "\n" + lv.LookupValue;
                                    }
                                    return retVal.Substring(1);
                                }
                                break;
                            case SPFieldType.Lookup:
                                if (inEditMode && editable)
                                {
                                    return val;
                                    //if (spfield.TypeAsString == "LookupMulti")
                                    //{
                                    //    string retVal = "";
                                    //    SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                                    //    foreach (SPFieldLookupValue lv in lvc)
                                    //    {
                                    //        retVal += "," + lv.LookupId;
                                    //    }
                                    //    if (retVal.Length > 1)
                                    //        retVal = retVal.Substring(1);
                                    //    return retVal;
                                    //}
                                    //else
                                    //{
                                    //    SPFieldLookupValue lv = new SPFieldLookupValue(val);
                                    //    return lv.LookupId.ToString();
                                    //}
                                }
                                else
                                {
                                    if (spfield.TypeAsString == "LookupMulti")
                                    {
                                        string retVal = "";
                                        SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                                        foreach (SPFieldLookupValue lv in lvc)
                                        {
                                            if (group)
                                                retVal += "\n" + lv.LookupValue;
                                            else
                                                retVal += "," + lv.LookupValue;
                                        }
                                        return retVal.Substring(1);
                                    }
                                    else
                                        return spfield.GetFieldValueAsText(val);
                                }
                            case SPFieldType.Calculated:
                                string[] sdata = val.Replace(";#", "\n").Split('\n');

                                if (sdata.Length > 1)
                                    val = sdata[1];

                                break;
                            case SPFieldType.Number:
                            case SPFieldType.Currency:
                                try
                                {
                                    val = double.Parse(val).ToString(providerEn);
                                }
                                catch { }
                                break;
                            default:
                                if (spfield.TypeAsString == "FilteredLookup" && group)
                                {
                                    val = val.Replace(",", "\n");
                                }
                                break;
                        };
                        break;
                    //return formatField(val, spfield.InternalName, spfield.Type == SPFieldType.Calculated,group, li);
                };

            }
            catch { }
            return val;
        }

        public string formatField(string val, string fieldname, bool calculated, bool group, SPListItem li)
        {
            if (val == "")
                return "";


            SPField spfield = null;
            if (li == null)
                spfield = getRealField(list.Fields.GetFieldByInternalName(fieldname));
            else
                spfield = getRealField(li.Fields.GetFieldByInternalName(fieldname));
            string format = "";
            XmlDocument fieldXml = new XmlDocument();
            fieldXml.LoadXml(spfield.SchemaXml);
            if (calculated && !group)
            {
                //val = val.Replace(";#", "\n").Split('\n')[1];
            }
            switch (spfield.Type)
            {
                case SPFieldType.User:
                    if (!group)
                    {
                        if (spfield.GetFieldValue(val).GetType().ToString() == "Microsoft.SharePoint.SPFieldUserValue")
                        {
                            SPFieldUserValue uv = (SPFieldUserValue)spfield.GetFieldValue(val);
                            val = "";
                            val += "<a href=\"" + li.Web.Url + "/_layouts/userdisp.aspx?ID=" + uv.LookupId.ToString() + "\">" + uv.LookupValue + "</a>";
                        }
                        else
                        {
                            SPFieldUserValueCollection uvc = (SPFieldUserValueCollection)spfield.GetFieldValue(val);
                            val = "";
                            foreach (SPFieldUserValue uv in uvc)
                            {
                                val += "; <a href=\"" + li.Web.Url + "/_layouts/userdisp.aspx?ID=" + uv.LookupId.ToString() + "\">" + uv.LookupValue + "</a>";
                            }
                            if (val.Length > 1)
                                val = val.Substring(2);
                        }
                    }
                    break;
                case SPFieldType.DateTime:
                    if (DateTime.Parse(val).ToString() == DateTime.MaxValue.ToString() || DateTime.Parse(val).ToString() == DateTime.MinValue.ToString())
                    {
                        val = "";
                    }
                    else
                    {
                        try
                        {
                            format = fieldXml.ChildNodes[0].Attributes["Format"].Value;
                        }
                        catch { }
                        if (format == "DateOnly")
                            val = DateTime.Parse(val).ToShortDateString();
                    }
                    break;
                case SPFieldType.Number:
                case SPFieldType.Currency:
                    //val = double.Parse(val, providerEn).ToString();
                    val = spfield.GetFieldValueAsText(val);
                    break;
                case SPFieldType.Boolean:
                    if (val == "True")
                        val = "Yes";
                    else
                        val = "No";
                    break;
                case SPFieldType.MultiChoice:
                    if (group)
                    {
                        if (val != "" && val[0] == ';' && val[1] == '#')
                            val = val.Substring(2, val.Length - 4).Replace(";#", "\n");
                    }
                    else
                        val = spfield.GetFieldValueAsText(val);
                    break;
                case SPFieldType.Lookup:
                    break;
                case SPFieldType.URL:
                    if (((SPFieldUrl)spfield).DisplayFormat == SPUrlFieldFormatType.Image)
                        val = spfield.GetFieldValueAsHtml(val).Replace("a href", "img src").Replace(">", " alt=\"").Replace("</a alt=\"", "\">");
                    else
                        val = spfield.GetFieldValueAsHtml(val);
                    break;
                case SPFieldType.Calculated:
                    string[] sdata = val.Replace(";#", "\n").Split('\n');
                    string resulttype = "";
                    try
                    {
                        resulttype = fieldXml.ChildNodes[0].Attributes["ResultType"].Value;
                    }
                    catch { }

                    if (sdata.Length > 1)
                        val = sdata[1];

                    switch (resulttype)
                    {
                        case "Text":
                            break;
                        case "Currency":
                            {
                                double fval = double.Parse(val, providerEn);
                                val = fval.ToString("c");
                            }
                            break;
                        case "DateTime":
                            if (DateTime.Parse(val).ToString() == DateTime.MaxValue.ToString() || DateTime.Parse(val).ToString() == DateTime.MinValue.ToString())
                            {
                                val = "";
                            }
                            else
                            {
                                try
                                {
                                    format = fieldXml.ChildNodes[0].Attributes["Format"].Value;
                                }
                                catch { }
                                if (format == "DateOnly")
                                    val = DateTime.Parse(val).ToShortDateString();
                            }
                            break;
                        case "Number":
                            int decimals = 0;
                            try
                            {
                                decimals = int.Parse(fieldXml.ChildNodes[0].Attributes["Decimals"].Value);
                                for (int j = 0; j < decimals; j++)
                                {
                                    format += "0";
                                }
                                if (format.Length > 0)
                                    format = "#,##0." + format;
                                else
                                    format = "#,##0";
                            }
                            catch { }
                            if (spfield.SchemaXml.Contains("Percentage=\"TRUE\""))
                            {
                                try
                                {
                                    //if (!group && !bUseReporting)
                                    {
                                        double fval = double.Parse(val, providerEn) * 100;
                                        val = fval.ToString(format) + "%";
                                    }
                                    //else
                                    //    val += "%";
                                }
                                catch { }
                            }
                            else
                            {
                                try
                                {
                                    double fval = double.Parse(val, providerEn);
                                    val = fval.ToString(format);

                                }
                                catch { }
                            }
                            break;
                    };
                    break;
                default:
                    if (spfield.TypeAsString == "TotalRollup")
                    {
                        try
                        {
                            val = spfield.GetFieldValueAsText(val);
                            //val = double.Parse(val, providerEn).ToString("0.#");
                        }
                        catch { }
                    }
                    else if (spfield.TypeAsString == "FilteredLookup" && !inEditMode)
                    {
                        if (val != "")
                        {

                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                            val = "";
                            foreach (SPFieldLookupValue lv in lvc)
                            {
                                if (group)
                                    val += "\n" + lv.LookupValue;
                                else
                                    val += ", " + lv.LookupValue;
                            }
                            if (val.Length > 2)
                                val = val.Substring(2);
                        }
                    }
                    else
                    {
                        if (group)
                            try
                            {
                                val = spfield.GetFieldValueAsText(val);
                            }
                            catch { }
                        else
                        {
                            val = spfield.GetFieldValueAsHtml(val);
                        }
                    }
                    break;
            };
            return val;
        }
        public string formatField(string val, string fieldname, DataRow dr, bool group)
        {
            if (val == "")
                return "";

            SPField spfield = getRealField(list.Fields.GetFieldByInternalName(fieldname));
            string format = "";
            XmlDocument fieldXml = new XmlDocument();
            fieldXml.LoadXml(spfield.SchemaXml);

            switch (spfield.Type)
            {
                case SPFieldType.User:

                    if (spfield.GetFieldValue(val).GetType().ToString() == "Microsoft.SharePoint.SPFieldUserValue")
                    {
                        SPFieldUserValue uv = (SPFieldUserValue)spfield.GetFieldValue(val);
                        val = "";
                        val += "<a href=\"" + dr["SiteUrl"].ToString() + "/_layouts/userdisp.aspx?ID=" + uv.LookupId.ToString() + "\">" + uv.LookupValue + "</a>";
                    }
                    else
                    {
                        SPFieldUserValueCollection uvc = (SPFieldUserValueCollection)spfield.GetFieldValue(val);
                        val = "";
                        foreach (SPFieldUserValue uv in uvc)
                        {
                            val += "; <a href=\"" + dr["SiteUrl"].ToString() + "/_layouts/userdisp.aspx?ID=" + uv.LookupId.ToString() + "\">" + uv.LookupValue + "</a>";
                        }
                        if (val.Length > 1)
                            val = val.Substring(2);
                    }

                    //SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(list.ParentWeb, val);
                    //val = "";
                    //foreach (SPFieldUserValue uv in uvc)
                    //{
                    //    val += "; <a href=\"" + dr["SiteUrl"].ToString() + "/_layouts/userdisp.aspx?ID=" + uv.LookupId.ToString() + "\">" + uv.LookupValue + "</a>";
                    //}
                    //if (val.Length > 1)
                    //    val = val.Substring(2);
                    break;
                case SPFieldType.DateTime:
                    if (DateTime.Parse(val).ToString() == DateTime.MaxValue.ToString() || DateTime.Parse(val).ToString() == DateTime.MinValue.ToString())
                    {
                        val = "";
                    }
                    else
                    {
                        try
                        {
                            format = fieldXml.ChildNodes[0].Attributes["Format"].Value;
                        }
                        catch { }
                        if (format == "DateOnly")
                            val = DateTime.Parse(val).ToShortDateString();
                    }
                    break;
                case SPFieldType.Number:
                case SPFieldType.Currency:
                    //val = double.Parse(val, providerEn).ToString();
                    val = list.Fields[spfield.Id].GetFieldValueAsText(val);
                    break;
                case SPFieldType.Boolean:
                    if (val == "True" || val == "1")
                        val = "Yes";
                    else
                        val = "No";
                    break;
                case SPFieldType.Lookup:
                    val = list.Fields[spfield.Id].GetFieldValueAsText(val);
                    break;
                case SPFieldType.URL:
                    if (((SPFieldUrl)spfield).DisplayFormat == SPUrlFieldFormatType.Image)
                        val = list.Fields[spfield.Id].GetFieldValueAsHtml(val).Replace("a href", "img src").Replace(">", " alt=\"").Replace("</a alt=\"", "\">");
                    else
                        val = list.Fields[spfield.Id].GetFieldValueAsHtml(val);
                    break;
                case SPFieldType.Calculated:
                    string[] sdata = val.Replace(";#", "\n").Split('\n');
                    string resulttype = "";
                    try
                    {
                        resulttype = fieldXml.ChildNodes[0].Attributes["ResultType"].Value;
                    }
                    catch { }

                    if (sdata.Length > 1)
                        val = sdata[1];

                    switch (resulttype)
                    {
                        case "Text":
                            break;
                        case "Currency":
                            {
                                double fval = double.Parse(val, providerEn);
                                val = fval.ToString("c");
                            }
                            break;
                        case "DateTime":
                            if (DateTime.Parse(val).ToString() == DateTime.MaxValue.ToString() || DateTime.Parse(val).ToString() == DateTime.MinValue.ToString())
                            {
                                val = "";
                            }
                            else
                            {
                                try
                                {
                                    format = fieldXml.ChildNodes[0].Attributes["Format"].Value;
                                }
                                catch { }
                                if (format == "DateOnly")
                                    val = DateTime.Parse(val).ToShortDateString();
                            }
                            break;
                        case "Number":
                            int decimals = 0;
                            try
                            {
                                decimals = int.Parse(fieldXml.ChildNodes[0].Attributes["Decimals"].Value);
                                for (int j = 0; j < decimals; j++)
                                {
                                    format += "0";
                                }
                                if (format.Length > 0)
                                    format = "#,##0." + format;
                                else
                                    format = "#,##0";
                            }
                            catch { }
                            if (spfield.SchemaXml.Contains("Percentage=\"TRUE\""))
                            {
                                double fval = double.Parse(val, providerEn) * 100;
                                val = fval.ToString(format);
                                val += "%";
                            }
                            else
                            {
                                try
                                {
                                    double fval = double.Parse(val, providerEn);
                                    val = fval.ToString(format);

                                }
                                catch { }
                            }
                            break;
                    };
                    break;
                case SPFieldType.MultiChoice:
                    if (group)
                    {
                        if (val != "" && val[0] == ';' && val[1] == '#')
                            val = val.Substring(2, val.Length - 4).Replace(";#", "\n");
                    }
                    else
                        val = list.Fields[spfield.Id].GetFieldValueAsText(val);
                    break;
                default:
                    if (spfield.TypeAsString == "TotalRollup")
                    {
                        try
                        {
                            //val = double.Parse(val, providerEn).ToString("0.#");
                            val = spfield.GetFieldValueAsText(val);
                        }
                        catch { }
                    }
                    else
                    {
                        val = list.Fields[spfield.Id].GetFieldValueAsHtml(val);
                    }
                    break;
            };
            return val;
        }

    }
}

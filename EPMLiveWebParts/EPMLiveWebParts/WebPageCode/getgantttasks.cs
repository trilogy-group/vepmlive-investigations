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
using System.Text.RegularExpressions;

using System.Data.SqlClient;

namespace EPMLiveWebParts
{
    public partial class getgantttasks : System.Web.UI.Page
    {
        protected ArrayList filterResources;
        //protected SPWeb curWeb;
        protected SPUser curUser;
        protected string data;

        protected SPList list = null;
        protected SPView view = null;

        protected string strlist;
        protected string strview;
        protected string start;
        protected string finish;
        protected string progress;
        protected string wbsfield;
        protected string milestone;
        protected string executive;
        protected string information;
        protected string linktype;
        protected string[] rolluplists;
        protected string[] rollupsites;
        protected bool usePerformance;
        protected string additionalgroups;

        protected string globalError = "";

        protected bool usePopup;

        protected string filterfield;
        protected string filtervalue;

        protected string expanded;

        private Hashtable hshItemNodes = new Hashtable();
        private Queue queueAllItems = new Queue();
        private string[] arrGroupFields;
        private SortedList arrGroupMin = new SortedList();
        private SortedList arrGroupMax = new SortedList();
        private SortedList arrAggregationDef = new SortedList();
        private SortedList arrAggregationVals = new SortedList();
        private SortedList arrItems = new SortedList();
        private ArrayList arrColumns = new ArrayList();
        private Hashtable hshImages = new Hashtable();
        private Hashtable hshWBS = new Hashtable();
        private Hashtable hshWBSSummaryTasks = new Hashtable();
        private DateTime overallMin = DateTime.MaxValue;
        protected Hashtable hshLists = new Hashtable();
        private XmlNode ndMainParent;
        protected XmlDocument docComplete;
        protected bool isResourcePlan;

        protected int startHour;
        protected int endHour;
        protected int nonWork;
        protected BitArray workdays = new BitArray(7);

        System.Globalization.NumberFormatInfo providerEn = new System.Globalization.NumberFormatInfo();
        System.Globalization.DateTimeFormatInfo dtProviderEn = new System.Globalization.DateTimeFormatInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            providerEn.NumberDecimalSeparator = ".";
            providerEn.NumberGroupSeparator = ",";
            providerEn.NumberGroupSizes = new int[] { 3 };

            dtProviderEn.DateSeparator = "/";
            dtProviderEn.ShortDatePattern = "MM/dd/yyyy";

            SPWeb curWeb = SPContext.Current.Web;
            {
                getParams(curWeb);
            
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPSite site = SPContext.Current.Site;
                    {
                        startHour = site.RootWeb.RegionalSettings.WorkDayStartHour / 60;
                        endHour = site.RootWeb.RegionalSettings.WorkDayEndHour / 60;
                        int work = site.RootWeb.RegionalSettings.WorkDays;
                        for (byte x = 0; x < workdays.Count; x++)
                        {
                            workdays[6 - x] = (((work >> x) & 0x01) == 0x01) ? true : false;
                            if (!workdays[6 - x])
                                nonWork++;
                        }
                    }
                });


                curUser = curWeb.CurrentUser;
                curWeb.Site.CatchAccessDeniedException = false;
                try
                {
                    list = curWeb.GetListFromUrl(strlist);
                    view = list.Views[strview];
                }
                catch { }
                if (list != null && view != null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml("<Content></Content>");
                    XmlNode nd = doc.ChildNodes[0];
                    XmlAttribute attrAuthor = doc.CreateAttribute("Author");
                    attrAuthor.Value = "EPM Live";
                    XmlAttribute attrComponent = doc.CreateAttribute("Component");
                    attrComponent.Value = "ExG2antt";
                    XmlAttribute attrVersion = doc.CreateAttribute("Version");
                    attrVersion.Value = "1.0";
                    nd.Attributes.Append(attrVersion);
                    nd.Attributes.Append(attrComponent);
                    nd.Attributes.Append(attrAuthor);
                    XmlNode mainNode = doc.ChildNodes[0];
                    XmlNode headNode = doc.CreateNode(XmlNodeType.Element, "Chart", doc.NamespaceURI);
                    mainNode.AppendChild(headNode);

                    XmlAttribute attrShowLinks = doc.CreateAttribute("ShowLinks", doc.NamespaceURI);
                    attrShowLinks.Value = "-1";
                    headNode.Attributes.Append(attrShowLinks);

                    //=============Links=================

                    XmlNode linksNode = doc.CreateNode(XmlNodeType.Element, "Links", doc.NamespaceURI);
                    headNode.AppendChild(linksNode);

                    //===================================

                    //==============Build Bars
                    //<Bar Name="TaskP" Pattern="3" Color="16711680" Height="13" NW="Split" Percent="Progress" Histogram="6"/>
                    XmlNode ndBars = doc.CreateNode(XmlNodeType.Element, "Bars", doc.NamespaceURI);
                    headNode.AppendChild(ndBars);


                    XmlNode ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);
                    ndBars.AppendChild(ndBar);

                    XmlAttribute attrName = doc.CreateAttribute("Name");
                    attrName.Value = "TaskP";
                    XmlAttribute attrColor = doc.CreateAttribute("Color");
                    attrColor.Value = "1073741824";
                    XmlAttribute attrPercent = doc.CreateAttribute("Percent");
                    attrPercent.Value = "Progress";
                    ndBar.Attributes.Append(attrName);
                    ndBar.Attributes.Append(attrColor);
                    ndBar.Attributes.Append(attrPercent);

                    //
                    ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);
                    ndBars.AppendChild(ndBar);
                    attrPercent = doc.CreateAttribute("Percent");
                    attrPercent.Value = "Progress";
                    attrName = doc.CreateAttribute("Name");
                    attrName.Value = "TaskC";
                    attrColor = doc.CreateAttribute("Color");
                    attrColor.Value = "1056964608";
                    ndBar.Attributes.Append(attrName);
                    ndBar.Attributes.Append(attrColor);
                    ndBar.Attributes.Append(attrPercent);
                    //
                    ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);
                    ndBars.AppendChild(ndBar);
                    attrPercent = doc.CreateAttribute("Percent");
                    attrPercent.Value = "Progress";
                    attrName = doc.CreateAttribute("Name");
                    attrName.Value = "Summary";
                    attrColor = doc.CreateAttribute("Color");
                    attrColor.Value = "1090519040";
                    ndBar.Attributes.Append(attrName);
                    ndBar.Attributes.Append(attrColor);
                    ndBar.Attributes.Append(attrPercent);

                    //<Bar Name="Milestone" Shape="0" Pattern="0" StartShape="3"/>
                    ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);
                    ndBars.AppendChild(ndBar);

                    attrName = doc.CreateAttribute("Name");
                    attrName.Value = "Milestone";
                    attrColor = doc.CreateAttribute("Shape");
                    attrColor.Value = "0";
                    XmlAttribute attrPattern = doc.CreateAttribute("Pattern");
                    attrPattern.Value = "0";
                    XmlAttribute attrStartShape = doc.CreateAttribute("StartShape");
                    attrStartShape.Value = "3";
                    ndBar.Attributes.Append(attrName);
                    ndBar.Attributes.Append(attrColor);
                    ndBar.Attributes.Append(attrPattern);
                    ndBar.Attributes.Append(attrStartShape);

                    //<Bar Name="Progress" Shape="3" Color="16711680" HistogramColor="16711680"/>
                    ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);
                    ndBars.AppendChild(ndBar);

                    attrName = doc.CreateAttribute("Name");
                    attrName.Value = "Progress";
                    attrColor = doc.CreateAttribute("Color");
                    attrColor.Value = "0";
                    attrStartShape = doc.CreateAttribute("Shape");
                    attrStartShape.Value = "3";
                    ndBar.Attributes.Append(attrName);
                    ndBar.Attributes.Append(attrColor);
                    ndBar.Attributes.Append(attrStartShape);
                    //===============================

                    doc = addHeader(doc);
                    Hashtable hshItems = new Hashtable();
                    XmlNode ndItems = doc.CreateNode(XmlNodeType.Element, "Items", doc.NamespaceURI);
                    doc.FirstChild.AppendChild(ndItems);
                    ndMainParent = ndItems;
                    //hshItemNodes.Add("", ndItems);
                    //if (rolluplist != "")

                    XmlDocument docGroup = new XmlDocument();
                    docGroup.LoadXml("<Query>" + view.Query + "</Query>");
                    try
                    {
                        expanded = docGroup.FirstChild.FirstChild.Attributes["Collapse"].Value;
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

                    EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

                    if(gSettings.TotalSettings != "")
                    {
                        string[] fieldList = gSettings.TotalSettings.Split('\n');
                        foreach (string field in fieldList)
                        {
                            if (field != "")
                            {
                                string[] fieldData = field.Split('|');
                                if (!arrAggregationDef.Contains(fieldData[0]))
                                    arrAggregationDef.Add(fieldData[0], fieldData[1]);
                            }
                        }
                    }

                    doc = addItems(doc, curWeb);
                    //else
                    //    doc = addItems(doc);

                    if (overallMin < DateTime.MaxValue)
                    {
                        XmlAttribute attrFirstVisibleDate = doc.CreateAttribute("FirstVisibleDate");
                        attrFirstVisibleDate.Value = overallMin.ToString(dtProviderEn);
                        headNode.Attributes.Append(attrFirstVisibleDate);
                    }

                    foreach (DictionaryEntry de in hshItemNodes)
                    {
                        if (de.Key.ToString() != "")
                        {
                            XmlNode ndGroup = (XmlNode)de.Value;

                            for (int i = 1; i < arrColumns.Count; i++)
                            {
                                XmlNode ndCell = doc.CreateNode(XmlNodeType.Element, "Cell", doc.NamespaceURI);
                                XmlAttribute attrValue = doc.CreateAttribute("Value");
                                attrValue.Value = "";
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
                                                    try
                                                    {
                                                        foreach (string s in vals)
                                                            fVal += double.Parse(s);
                                                    }
                                                    catch { }
                                                    fVal = fVal / vals.Length;
                                                    val = fVal.ToString();

                                                }
                                                break;
                                            case "STDEV":
                                                if (val.Length > 0)
                                                {
                                                    val = val.Substring(1);
                                                    double avg = 0;
                                                    string[] vals = val.Split(',');
                                                    double[] devs = new double[vals.Length];
                                                    try
                                                    {
                                                        foreach (string s in vals)
                                                            avg += double.Parse(s);
                                                    }
                                                    catch { }
                                                    avg = avg / vals.Length;

                                                    try
                                                    {
                                                        for (int j = 0; j < vals.Length; j++)
                                                        {
                                                            devs[j] = double.Parse(vals[j]) - avg;
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
                                                    val = avg.ToString();
                                                }
                                                break;
                                        };
                                        if (arrAggregationDef[arrColumns[i]].ToString() == "COUNT")
                                            attrValue.Value = "<b>" + val + "</b>";
                                        else
                                            attrValue.Value = "<b>" + formatField(val, arrColumns[i].ToString(), false, true) + "</b>";
                                    }
                                    catch { }
                                }
                                XmlAttribute attrValueFormat = doc.CreateAttribute("ValueFormat");
                                attrValueFormat.Value = "1";
                                ndCell.Attributes.Append(attrValueFormat);
                                ndCell.Attributes.Append(attrValue);
                                ndGroup.AppendChild(ndCell);
                            }
                        }
                    }
                    if (ndItems.ChildNodes.Count <= 0)
                        doc.ChildNodes[0].RemoveChild(ndItems);
                    else
                    {

                    }

                    doc = createLinks(doc, linksNode);
                    docComplete = doc;
                    outputData();
                }
            }
            //curWeb.Close();
        }

        protected virtual void outputData()
        {
            XmlNode ndItems = docComplete.SelectSingleNode("//Items");
            if (ndItems == null)
            {
                ndItems = docComplete.CreateNode(XmlNodeType.Element, "Items", docComplete.NamespaceURI);
                docComplete.FirstChild.AppendChild(ndItems);
            }
            data = docComplete.OuterXml;
        }

        private XmlDocument createLinks(XmlDocument doc, XmlNode ndLinks)
        {
            XmlNodeList ndl = ndMainParent.SelectNodes("//Item");
            int counter = 0;
            foreach (XmlNode nd in ndl)
            {
                XmlAttribute attrValueFormat = doc.CreateAttribute("Index");
                attrValueFormat.Value = counter.ToString();
                nd.Attributes.Append(attrValueFormat);
                counter++;
            }
            counter = 0;
            foreach (XmlNode nd in ndl)
            {
                string preds = "";
                string groupto = "";
                try
                {
                    preds = nd.Attributes["Predecessors"].Value;
                    groupto = nd.Attributes["GroupTo"].Value;
                    int gInd = groupto.LastIndexOf(".");
                    groupto = groupto.Substring(0, gInd);
                }
                catch { }
                if(groupto != "" && preds != "")
                {
                    string []arrpreds = preds.Split(',');
                    foreach(string pred in arrpreds)
                    {
                        string regExp = @"^\d*|\w*";
                        string startPos = "2";
                        string endPos = "0";
                        MatchCollection mc = Regex.Matches(pred, regExp);
                        string realPred = pred;
                        if (mc.Count > 0)
                        {
                            realPred = mc[0].Value;
                            string linktype = mc[1].Value;
                            switch (linktype)
                            {
                                case "SS":
                                    startPos = "0";
                                    endPos = "0";
                                    break;
                                case "FF":
                                    startPos = "2";
                                    endPos = "2";
                                    break;
                                case "SF":
                                    startPos = "0";
                                    endPos = "2";
                                    break;
                            };
                        }

                        XmlNode startNode = doc.SelectSingleNode("//Item[@GroupTo='" + groupto + "." + realPred + "']");
                        if (startNode != null)
                        {
                            XmlNode linkNode = doc.CreateNode(XmlNodeType.Element, "Link", doc.NamespaceURI);
                            XmlAttribute attrKey = doc.CreateAttribute("Key", doc.NamespaceURI);
                            attrKey.Value = "Link" + counter.ToString();
                            XmlAttribute attrStartItem = doc.CreateAttribute("StartItem", doc.NamespaceURI);
                            attrStartItem.Value = startNode.Attributes["Index"].Value;
                            XmlAttribute attrStartPos = doc.CreateAttribute("StartPos", doc.NamespaceURI);
                            attrStartPos.Value = startPos;

                            XmlAttribute attrEndItem = doc.CreateAttribute("EndItem", doc.NamespaceURI);
                            attrEndItem.Value = nd.Attributes["Index"].Value;
                            XmlAttribute attrEndPos = doc.CreateAttribute("EndPos", doc.NamespaceURI);
                            attrEndPos.Value = endPos;

                            XmlAttribute attrVisible = doc.CreateAttribute("Visible", doc.NamespaceURI);
                            attrVisible.Value = "-1";

                            XmlAttribute attrColor1 = doc.CreateAttribute("Color", doc.NamespaceURI);
                            attrColor1.Value = "0";

                            XmlAttribute attrShowDir = doc.CreateAttribute("ShowDir", doc.NamespaceURI);
                            attrShowDir.Value = "-1";
                            linkNode.Attributes.Append(attrKey);
                            linkNode.Attributes.Append(attrStartItem);
                            linkNode.Attributes.Append(attrStartPos);
                            linkNode.Attributes.Append(attrEndItem);
                            linkNode.Attributes.Append(attrEndPos);
                            linkNode.Attributes.Append(attrVisible);
                            linkNode.Attributes.Append(attrColor1);
                            linkNode.Attributes.Append(attrShowDir);
                            ndLinks.AppendChild(linkNode);
                            counter++;
                        }
                    }
                }
            }


            return doc;
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
                            if (field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.Calculated)
                            {
                                arrAggregationVals[grouping + "\n" + de.Key] = "";
                            }
                            else if (field.Type == SPFieldType.DateTime)
                            {
                                arrAggregationVals[grouping + "\n" + de.Key] = DateTime.MaxValue;
                            }
                            break;
                        case "MAX":
                            if (field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.Calculated)
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
                    start = hshParams["Start"].ToString();
                }
                catch { }
                try
                {
                    finish = hshParams["Finish"].ToString();
                }
                catch { }
                try
                {
                    progress = hshParams["Percent"].ToString();
                }
                catch { }
                try
                {
                    wbsfield = hshParams["WBS"].ToString();
                }
                catch { }
                try
                {
                    milestone = hshParams["Milestone"].ToString();
                }
                catch { }
                try
                {
                    information = hshParams["Info"].ToString();
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
                    if (hshParams["RSites"].ToString() != "")
                    {
                        rollupsites = hshParams["RSites"].ToString().Split(',');
                    }
                }
                catch { }
                try
                {
                    additionalgroups = hshParams["AGroups"].ToString();
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
            }
            catch { }

            /*try
            {
                byte[] encodedDataAsBytes = System.Convert.FromBase64String(Request["data"]);

                string[] data = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes).Split('\n');

                strlist = data[0];
                strview = data[1];
                start = data[2];
                finish = data[3];
                progress = data[4];
                wbsfield = data[5];
                milestone = data[6];
                executive = data[7];
                information = data[8];
                linktype = data[9];
                if (data[10] != "")
                {
                    string[] tRollupLists = data[10].Split(',');
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


                filterfield = data[11];
                filtervalue = data[12];

                if (data[13] != "")
                {
                    rollupsites = data[13].Split(',');
                }

                try
                {
                    additionalgroups = data[14];
                }
                catch { }

                try
                {
                    usePerformance = false;
                    usePerformance = bool.Parse(data[15]);
                }
                catch { }

                try
                {
                    usePopup = false;
                    usePopup = bool.Parse(data[16]);
                }
                catch { }


            }
            catch { }*/

        }

        private XmlNode addBar(XmlDocument doc, string nodeData)
        {
            XmlNode nd = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);
            string[] attribs = nodeData.Split(',');
            foreach (string attrib in attribs)
            {
                string[] attribData = attrib.Split('|');
                XmlAttribute attr = doc.CreateAttribute(attribData[0]);
                attr.Value = attribData[1];
                nd.Attributes.Append(attr);
            }

            return nd;
        }

        private XmlDocument addHeader(XmlDocument doc)
        {
            XmlNode mainNode = doc.ChildNodes[0];
            XmlNode headNode = doc.CreateNode(XmlNodeType.Element, "Columns", doc.NamespaceURI);
            mainNode.AppendChild(headNode);

            SPViewFieldCollection vfc = view.ViewFields;

            int counter = 0;

            foreach (string f in vfc)
            {
                arrColumns.Add(f);
                SPField field = list.Fields.GetFieldByInternalName(f);
                XmlAttribute attrAlign = doc.CreateAttribute("Alignment");
                XmlAttribute attrType = doc.CreateAttribute("Type");
                XmlAttribute attrWidth = doc.CreateAttribute("Width");
                XmlAttribute attrPosition = doc.CreateAttribute("Position");
                XmlAttribute attrCaption = doc.CreateAttribute("Caption");
                XmlAttribute attrFilter = doc.CreateAttribute("DisplayFilterButton");
                XmlAttribute attrFilterType = doc.CreateAttribute("FilterType");
                XmlAttribute attrSortType = doc.CreateAttribute("SortType");
                attrFilter.Value = "1";
                attrFilterType.Value = "0";
                attrCaption.Value = field.Title;
                attrPosition.Value = (counter++).ToString();
                attrSortType.Value = "0";

                field = getRealField(field);

                if (field.InternalName == "Title" || f == "URL" || f == "URLNoMenu")
                {
                    attrWidth.Value = "200";
                    attrAlign.Value = "0";
                }
                else
                {
                    switch (field.Type)
                    {
                        case SPFieldType.Calculated:
                            XmlDocument fDoc = new XmlDocument();
                            fDoc.LoadXml(field.SchemaXml);
                            string output = "";
                            try
                            {
                                output = fDoc.FirstChild.Attributes["ResultType"].Value;
                            }
                            catch { }
                            if (output == "Number")
                            {
                                attrSortType.Value = "1";
                                attrWidth.Value = "80";
                                attrAlign.Value = "2";
                            }
                            else if (field.Description == "Indicator")
                            {
                                attrWidth.Value = "80";
                                attrAlign.Value = "1";
                            }
                            break;
                        case SPFieldType.DateTime:
                            attrWidth.Value = "80";
                            attrAlign.Value = "2";
                            attrFilterType.Value = "4";
                            attrSortType.Value = "3";
                            break;
                        case SPFieldType.Currency:
                            attrWidth.Value = "80";
                            attrAlign.Value = "2";
                            attrSortType.Value = "1";
                            break;
                        case SPFieldType.Number:
                            attrSortType.Value = "1";
                            attrWidth.Value = "80";
                            attrAlign.Value = "2";
                            break;
                    };
                }

                XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Column", doc.NamespaceURI);
                newNode.Attributes.Append(attrCaption);
                newNode.Attributes.Append(attrWidth);
                newNode.Attributes.Append(attrPosition);
                newNode.Attributes.Append(attrAlign);
                newNode.Attributes.Append(attrFilter);
                newNode.Attributes.Append(attrFilterType);
                newNode.Attributes.Append(attrSortType);
                
                headNode.AppendChild(newNode);
            }
            return doc;
        }
        protected void processListDT(SPWeb web, DataRow[] dtRows, SortedList arrGTemp, string listname)
        {
            try
            {
                foreach (DataRow dr in dtRows)
                {
                    dr["SiteUrl"] = web.Site.Url.ToString();
                    dr["siteid"] = web.Site.ID.ToString();
                    if (dr.Table.Columns.Contains("List"))
                        dr["List"] = listname;

                    string[] group = new string[1] { null };
                    if (arrGroupFields != null)
                    {
                        foreach (string groupby in arrGroupFields)
                        {

                            SPField field = getRealField(list.Fields.GetFieldByInternalName(groupby));
                            //string newgroup = getField(li, groupby, true);
                            string newgroup = dr[groupby].ToString();
                            try
                            {
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
                    arrItems.Add(dr["WebID"].ToString() + "." + dr["ListID"].ToString() + "." + dr["ID"].ToString(), group);
                    queueAllItems.Enqueue(dr);
                }
            }
            catch { }

        }

        private void processList(SPWeb web, string spquery, SPList curList, SortedList arrGTemp)
        {
            SPQuery query = new SPQuery();
                query.Query = spquery;

                foreach (SPListItem li in curList.GetItems(query))
                {
                    if (!(Request["ignorelistid"] == curList.ID.ToString("B") && Request["ignoreitemid"] == li.ID.ToString()))
                    {
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
                        if (canView)
                        {
                            string[] group = new string[1] { null };
                            if (arrGroupFields != null)
                            {
                                foreach (string groupby in arrGroupFields)
                                {

                                    if (groupby == "--SITE--")
                                    {
                                        if (group[0] == null)
                                            group[0] = web.Title;
                                        else
                                            group[0] += "\n" + web.Title;
                                        if (!arrGTemp.Contains(group[0]))
                                        {
                                            arrGTemp.Add(group[0], "");
                                        }
                                    }
                                    else
                                    {
                                        SPField field = list.Fields.GetFieldByInternalName(groupby);
                                        string newgroup = getField(li, groupby);
                                        if (newgroup == "")
                                            newgroup = " No " + field.Title;
                                        if (field.Type == SPFieldType.User || field.Type == SPFieldType.MultiChoice || field.TypeAsString == "LookupMulti")
                                        {
                                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(newgroup);

                                            if (lvc.Count > 0)
                                            {
                                                //string[] sGroups = newgroup.Replace(";#","\n").Split('\n');
                                                string[] tmpGroups = new string[group.Length * lvc.Count];

                                                //group = new string[sGroups.Length];
                                                int tmpCounter = 0;
                                                foreach (string g in group)
                                                {
                                                    foreach (SPFieldLookupValue lv in lvc)
                                                    {
                                                        if (g == null)
                                                            tmpGroups[tmpCounter] = lv.LookupValue;
                                                        else
                                                            tmpGroups[tmpCounter] = g + "\n" + lv.LookupValue;

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
                                                int tmpCounter = 0;
                                                string[] tmpGroups = new string[group.Length];
                                                foreach (string g in group)
                                                {
                                                    if (g == null)
                                                        tmpGroups[tmpCounter] = "";
                                                    else
                                                        tmpGroups[tmpCounter] = g + "\n";

                                                    if (!arrGTemp.Contains(tmpGroups[tmpCounter]))
                                                    {
                                                        arrGTemp.Add(tmpGroups[tmpCounter], "");
                                                    }
                                                    tmpCounter++;
                                                }
                                                group = tmpGroups;
                                            }
                                        }
                                        else
                                        {
                                            newgroup = formatField(newgroup, groupby, field.Type == SPFieldType.Calculated, true);
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
                            }
                            arrItems.Add(web.ID + "." + li.ParentList.ID + "." + li.ID, group);
                            queueAllItems.Enqueue(li);
                        }
                    }
                }
        }

        private string additionalPerfFields(string dqFields, ArrayList arr)
        {
            if (!arr.Contains("title") && list.Fields.ContainsField("Title"))
                dqFields += "<FieldRef Name='Title' Nullable='TRUE'/>";

            if (!arr.Contains("created"))
                dqFields += "<FieldRef Name='Created' Nullable='TRUE'/>";

            if (!arr.Contains("duration"))
                dqFields += "<FieldRef Name='Duration' Nullable='TRUE'/>";

            if (!arr.Contains("work"))
                dqFields += "<FieldRef Name='Work' Nullable='TRUE'/>";

            if (!arr.Contains("predecessors"))
                dqFields += "<FieldRef Name='Predecessors' Nullable='TRUE'/>";

            if (!arr.Contains("taskorder"))
                dqFields += "<FieldRef Name='TaskOrder' Nullable='TRUE'/>";

            if (!arr.Contains("critical"))
                dqFields += "<FieldRef Name='Critical' Nullable='TRUE'/>";

            if (!arr.Contains("list"))
                dqFields += "<FieldRef Name='List' Nullable='TRUE'/>";

            if(start != "")
                if (!arr.Contains(start.ToLower()))
                    dqFields += "<FieldRef Name='" + start + "' Nullable='TRUE'/>";

            if(finish != "")
                if (!arr.Contains(finish.ToLower()))
                    dqFields += "<FieldRef Name='" + finish + "' Nullable='TRUE'/>";

            if(progress != "")
                if (!arr.Contains(progress.ToLower()))
                    dqFields += "<FieldRef Name='" + progress + "' Nullable='TRUE'/>";

            if(wbsfield != "")
                if (!arr.Contains(wbsfield.ToLower()))
                    dqFields += "<FieldRef Name='" + wbsfield + "' Nullable='TRUE'/>";

            if(milestone != "")
                if (!arr.Contains(milestone.ToLower()))
                    dqFields += "<FieldRef Name='" + milestone + "' Nullable='TRUE'/>";

            if(information != "")
                if (!arr.Contains(information.ToLower()))
                    dqFields += "<FieldRef Name='" + information + "' Nullable='TRUE'/>";

            return dqFields;
        }

        private XmlDocument addGroups(XmlDocument doc, SPWeb web, string spquery, SortedList arrGTemp)
        {
            
            try
            {
                if (rolluplists == null)
                {
                    processList(web, spquery, list, arrGTemp);
                }
                else
                {
                    if (!usePerformance)
                    {
                        foreach (string strList in rolluplists)
                        {
                            try
                            {
                                SPList tList = web.Lists[strList];
                                if (tList != null)
                                {
                                    if (isResourcePlan)
                                    {
                                        if (tList.Fields.ContainsField("Work") && tList.Fields.ContainsField("StartDate") && tList.Fields.ContainsField("DueDate"))
                                        {
                                            processList(web, spquery, tList, arrGTemp);
                                        }
                                    }
                                    else
                                    {
                                        processList(web, spquery, tList, arrGTemp);
                                    }
                                }
                            }
                            catch { }
                        }
                        try
                        {
                            foreach (SPWeb w in web.Webs)
                            {
                                try
                                {
                                    doc = addGroups(doc, w, spquery, arrGTemp);
                                }
                                catch { }
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
                        string lists = "";
                        SqlConnection cn = null;
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            SPSite s = SPContext.Current.Site;
                            {
                                string dbCon = s.ContentDatabase.DatabaseConnectionString;
                                cn = new SqlConnection(dbCon);
                                cn.Open();
                            }
                        });
                        if (cn.State == ConnectionState.Open)
                        {
                            SPSite s = SPContext.Current.Site;
                            {
                                SPWeb w = SPContext.Current.Web;
                                {
                                    try
                                    {


                                        string siteurl = w.ServerRelativeUrl.Substring(1);

                                        ArrayList arr = new ArrayList();
                                        string dqFields = "";
                                        foreach (string field in view.ViewFields)
                                        {
                                            SPField f = getRealField(list.Fields.GetFieldByInternalName(field));
                                            arr.Add(f.InternalName.ToLower());
                                            dqFields += "<FieldRef Name='" + f.InternalName + "' Nullable='TRUE'/>";
                                        }
                                        foreach (string groupby in arrGroupFields)
                                        {
                                            if (!arr.Contains(groupby.ToLower()))
                                            {
                                                arr.Add(groupby.ToLower());
                                                dqFields += "<FieldRef Name='" + groupby + "' Nullable='TRUE'/>";
                                            }
                                        }
                                        if (!arr.Contains("title") && list.Fields.ContainsField("Title"))
                                        {
                                            dqFields += "<FieldRef Name='Title' Nullable='TRUE'/>";
                                        }
                                        if (!arr.Contains("created"))
                                        {
                                            dqFields += "<FieldRef Name='Created'/>";
                                        }
                                        if (filterfield != "")
                                        {
                                            if (!arr.Contains(filterfield.ToLower()))
                                            {
                                                dqFields += "<FieldRef Name='" + filterfield + "' Nullable='TRUE'/>";
                                            }
                                        }
                                        dqFields = additionalPerfFields(dqFields, arr);
                                        foreach (string rlist in rolluplists)
                                        {
                                            try
                                            {
                                                lists = "";
                                                string query = "";
                                                if (siteurl == "")
                                                    query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='" + web.Site.ID + "' AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";
                                                else
                                                    query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '" + siteurl + "/%' OR dbo.Webs.FullUrl = '" + siteurl + "') AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";


                                                SqlCommand cmd = new SqlCommand(query, cn);
                                                cmd.Parameters.AddWithValue("@rlist", rlist);
                                                SqlDataReader dr = cmd.ExecuteReader();

                                                while (dr.Read())
                                                {
                                                    lists += "<List ID='" + dr.GetGuid(0).ToString() + "'/>";
                                                }
                                                dr.Close();


                                                SPSiteDataQuery dq = new SPSiteDataQuery();
                                                dq.Lists = "<Lists MaxListLimit='0'>" + lists + "</Lists>";
                                                dq.Query = spquery;
                                                dq.Webs = "<Webs Scope='Recursive'/>";
                                                dq.ViewFields = dqFields;
                                                try
                                                {
                                                    DataTable dt = web.GetSiteData(dq);
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
                                                catch { }
                                            }
                                            catch (Exception ex)
                                            {
                                                string message = ex.Message;
                                            }

                                        }


                                        cn.Close();
                                    }
                                    catch { }
                                }
                            }
                            cn.Close();
                        }
                    }
                }
            }
            catch { }
            return doc;
        }

        private string getField(DataRow dr, string field)
        {
            if (dr.Table.Columns.Contains(field))
                return dr[field].ToString();
            return "";
        }

        private string getField(SPListItem li, string field)
        {
            string val = "";
            try
            {
                SPField spfield = list.Fields.GetFieldByInternalName(field);
                switch (field)
                {
                    case "Site":
                        if (spfield.Type == SPFieldType.URL)
                            return "<a" + li.ParentList.ParentWeb.Url + ">" + li.ParentList.ParentWeb.Title + "</a>";
                        else
                            return li.ParentList.ParentWeb.Title;
                    case "List":
                        if (spfield.Type == SPFieldType.URL)
                            return "<a" + li.ParentList.DefaultViewUrl + ">" + li.ParentList.Title + "</a>";
                        else
                            return li.ParentList.Title;
                    default:
                        spfield = li.Fields.GetFieldByInternalName(field);
                        val = li[spfield.Id].ToString();
                        if (filterResources != null && spfield.Type == SPFieldType.User)
                        {
                            SPFieldUserValueCollection nuvc = new SPFieldUserValueCollection();
                            try
                            {
                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(li.ParentList.ParentWeb, val);
                                foreach (SPFieldUserValue uv in uvc)
                                {
                                    if (filterResources.Contains(uv.LookupValue))
                                        nuvc.Add(uv);
                                }
                            }
                            catch { }
                            val = nuvc.ToString();
                        }
                        if (spfield.TypeAsString == "TotalRollup")
                        {
                            try
                            {
                                val = double.Parse(val, providerEn).ToString("0");
                            }
                            catch { }
                        }
                        switch (spfield.Type)
                        {
                            case SPFieldType.Lookup:
                                if (spfield.TypeAsString == "LookupMulti")
                                {
                                    return val;
                                }
                                else
                                    return spfield.GetFieldValueAsText(val);

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

                        };
                        break;
                        //return formatField(val, spfield.InternalName, spfield.Type == SPFieldType.Calculated, false);
                };
            }
            catch { }
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
                    SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(list.ParentWeb, val);
                    val = "";
                    foreach (SPFieldUserValue uv in uvc)
                    {
                        val += "; <a href=\"" + dr["SiteUrl"].ToString() + "/_layouts/userdisp.aspx?ID=" + uv.LookupId.ToString() + "\">" + uv.LookupValue + "</a>";
                    }
                    if (val.Length > 1)
                        val = val.Substring(2);
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
                    if (val == "True")
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
                            if (spfield.Description == "Indicator")
                            {
                                val = "<img>" + val.ToLower() + "</img>";
                            }
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
                            val = double.Parse(val, providerEn).ToString("0.#");
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
        private string formatField(string val, string fieldname, bool calculated, bool group)
        {
            try
            {
                SPField spfield = list.Fields.GetFieldByInternalName(fieldname);
                string format = "";
                XmlDocument fieldXml = new XmlDocument();
                fieldXml.LoadXml(spfield.SchemaXml);
                //if (calculated && !group)
                //{
                //    val = val.Replace(";#", "\n").Split('\n')[1];
                //}
                switch (spfield.Type)
                {
                    case SPFieldType.User:
                        if (group)
                        {

                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                            val = "";
                            foreach (SPFieldLookupValue lv in lvc)
                            {
                                val += ", " + lv.LookupValue;
                            }
                            if (val.Length > 1)
                                val = val.Substring(2);
                        }
                        else
                            val = list.Fields[spfield.Id].GetFieldValueAsText(val);
                        break;
                    case SPFieldType.Calculated:
                        string[] sdata = val.Replace(";#", "\n").Split('\n');
                        string resulttype = "";
                        try
                        {
                            resulttype = fieldXml.ChildNodes[0].Attributes["ResultType"].Value;
                        }
                        catch { }


                        switch (resulttype)
                        {
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
                            case "Text":
                                if (spfield.Description == "Indicator")
                                {
                                    val = "<img>" + val.ToLower() + "</img>";
                                }
                                else
                                {
                                    //val = sdata[1];
                                }
                                break;
                            case "Currency":
                                {
                                    double fval = double.Parse(val, providerEn);
                                    val = fval.ToString("c");
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
                                        double fval = double.Parse(val, providerEn) * 100;
                                        val = fval.ToString(format) + "%";
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
                    case SPFieldType.Boolean:
                        if (val == "True")
                            val = "Yes";
                        else
                            val = "No";
                        break;
                    case SPFieldType.URL:
                        val = list.Fields[spfield.Id].GetFieldValueAsHtml(val).Replace(" href=", "").Replace("\"", "");
                        break;
                    case SPFieldType.Lookup:
                        if (spfield.TypeAsString == "LookupMulti")
                        {
                            string retVal = "";
                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                            foreach (SPFieldLookupValue lv in lvc)
                            {
                                retVal += "," + lv.LookupValue;
                            }
                            val = retVal.Substring(1);
                        }
                        break;
                    default:
                        val = list.Fields[spfield.Id].GetFieldValueAsText(val);
                        break;
                };
            }
            catch { }
            return val;
        }

        private void setMinMax(string group, DateTime min, DateTime max)
        {

            if (hshItemNodes.Contains(group))
            {
                DateTime dtMin = (DateTime)arrGroupMin[group];
                if (min < dtMin)
                    arrGroupMin[group] = min;
                DateTime dtMax = (DateTime)arrGroupMax[group];
                if (max > dtMax)
                    arrGroupMax[group] = max;
            }
            if (group.LastIndexOf("\n") > 0)
            {
                string g = group.Substring(0, group.LastIndexOf("\n"));
                setMinMax(g, (DateTime)arrGroupMin[group], (DateTime)arrGroupMax[group]);

            }
        }

        public virtual string getQuery()
        {
            return view.Query;//.Replace("<FieldRef Name=\"SiteURLNoMenu\" />", "");
        }

        private XmlDocument addItems(XmlDocument doc, SPWeb curWeb)
        {
            
            
            ///================================Get Query=====================
            string query = getQuery();
            XmlDocument xmlQuery = new XmlDocument();
            xmlQuery.LoadXml("<Query>" + query + "</Query>");

            XmlNode ndGroupBy = xmlQuery.SelectSingleNode("//GroupBy");
            if (ndGroupBy != null)
            {
                xmlQuery.ChildNodes[0].RemoveChild(ndGroupBy);
            }
            query = xmlQuery.ChildNodes[0].InnerXml;
            //=============================================================

            XmlDocument querydoc = new XmlDocument();
            querydoc.LoadXml("<Query>" + view.Query + "</Query>");
            ndGroupBy = querydoc.SelectSingleNode("//GroupBy");
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
            if (additionalgroups != null)
            {
                foreach (string additionalgroup in additionalgroups.Split('|'))
                {
                    if (additionalgroup.Trim() != "")
                        arrTempGroups.Add(additionalgroup);
                }
            }

            arrGroupFields = new string[arrTempGroups.Count];
            foreach (string s in arrTempGroups)
            {
                arrGroupFields[counter++] = s;
            }

            SortedList arrGTemp = new SortedList();

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
                                addGroups(doc, web, query, arrGTemp);
                            }
                        }
                        //addRollupItems();
                    });
                }
                else
                {
                    doc = addGroups(doc, curWeb, query, arrGTemp);
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
                                addGroups(doc, web, query, arrGTemp);
                            }
                        }
                    }
                    catch { }
                }
            }
            
            ////////////////////////////////////

            //XmlNode nd = doc.SelectSingleNode("/Content/Items");

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

                if (hshItemNodes.Contains(parent) && !hshItemNodes.Contains(e.Key.ToString()) || (parentInd == -1 && !hshItemNodes.Contains(e.Key.ToString())))
                {
                    XmlNode ndParent = (XmlNode)hshItemNodes[parent];
                    XmlNode ndParentItems = null;
                    if (parentInd == -1)
                    {
                        ndParentItems = ndMainParent;//.SelectSingleNode("Items");
                    }
                    else if (ndParentItems == null)
                    {
                        ndParentItems = doc.CreateNode(XmlNodeType.Element, "Items", doc.NamespaceURI);
                        ndParent.AppendChild(ndParentItems);
                    }

                    XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Item", doc.NamespaceURI);
                    if (expanded == "FALSE")
                    {
                        XmlAttribute attrExpand = doc.CreateAttribute("Expanded");
                        attrExpand.Value = "1";
                        newNode.Attributes.Append(attrExpand);
                    }
                    XmlAttribute attrBold = doc.CreateAttribute("ValueType");
                    attrBold.Value = "True";
                    newNode.Attributes.Append(attrBold);
                    ndParentItems.AppendChild(newNode);
                    XmlNode newCell = doc.CreateNode(XmlNodeType.Element, "Cell", doc.NamespaceURI);
                    XmlAttribute attrValue = doc.CreateAttribute("Value");
                    if (newItem.Trim() == "")
                        attrValue.Value = "<b>No Value</b>";
                    else
                        attrValue.Value = "<b>" + newItem + "</b>";
                    XmlAttribute attrValueFormat = doc.CreateAttribute("ValueFormat");
                    attrValueFormat.Value = "1";
                    newCell.Attributes.Append(attrValueFormat);

                    newCell.Attributes.Append(attrValue);
                    newNode.AppendChild(newCell);

                    hshItemNodes.Add(e.Key.ToString(), newNode);
                    arrGroupMin.Add(e.Key.ToString(), DateTime.MaxValue);
                    arrGroupMax.Add(e.Key.ToString(), DateTime.MinValue);
                    SPViewFieldCollection vfc = view.ViewFields;
                    for (int i = 0; i < vfc.Count; i++)
                    {
                        arrAggregationVals.Add(e.Key.ToString() + "\n" + vfc[i], "");
                    }
                    setInitialAggs(e.Key.ToString());
                }
            }

            ////////////////////////////////////


            while (queueAllItems.Count > 0)
            {
                object o = queueAllItems.Dequeue();
                if (o.GetType().ToString() == "Microsoft.SharePoint.SPListItem")
                    doc = addItem((SPListItem)o, doc);
                else if (o.GetType().ToString() == "System.Data.DataRow")
                    doc = addItem((DataRow)o, doc);

                 //addItem((SPListItem)queueAllItems.Dequeue(), doc);
            }

            foreach (DictionaryEntry de in hshItemNodes)
            {
                try
                {
                    string group = de.Key.ToString();
                    DateTime dtStart = (DateTime)arrGroupMin[group];
                    DateTime dtFinish = (DateTime)arrGroupMax[group];
                    if (dtStart != DateTime.MaxValue && dtFinish != DateTime.MinValue)
                    {
                        dtFinish = dtFinish.AddDays(1);
                        XmlNode ndGroup = (XmlNode)de.Value;
                        XmlNode ndBars = doc.CreateNode(XmlNodeType.Element, "Bars", doc.NamespaceURI);
                        ndGroup.AppendChild(ndBars);
                        XmlNode ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);
                        XmlAttribute attrName = doc.CreateAttribute("Name");
                        attrName.Value = "Summary";
                        XmlAttribute attrStart = doc.CreateAttribute("Start");
                        attrStart.Value = dtStart.ToShortDateString();
                        XmlAttribute attrEnd = doc.CreateAttribute("End");
                        attrEnd.Value = dtFinish.ToShortDateString();

                        ndBar.Attributes.Append(attrName);
                        ndBar.Attributes.Append(attrStart);
                        ndBar.Attributes.Append(attrEnd);

                        ndBars.AppendChild(ndBar);
                    }
                }catch{}
            }

            return doc;
        }

        private XmlDocument addItem(DataRow dr, XmlDocument doc)
        {
            if (!arrItems.Contains(dr["WebID"].ToString() + "." + dr["ListID"].ToString() + "." + dr["ID"].ToString()))
            {
                return doc;
            }

            string wbs = "";
            if (dr.Table.Columns.Contains(wbsfield))
                wbs = dr[wbsfield].ToString();

            string[] groups = (string[])arrItems[dr["WebID"].ToString() + "." + dr["ListID"].ToString() + "." + dr["ID"].ToString()];

            XmlNode ndNewItem = doc.CreateNode(XmlNodeType.Element, "Item", doc.NamespaceURI);
            SPViewFieldCollection vfc = view.ViewFields;
            for (int i = 0; i < vfc.Count; i++)
            {
                string val = "";
                string displayValue = "";
                XmlNode ndNewCell = doc.CreateNode(XmlNodeType.Element, "Cell", doc.NamespaceURI);

                try
                {
                    string fieldName = vfc[i];

                    SPField field = null;
                    if (fieldName == "List" || fieldName == "Site")
                    {
                        field = list.Fields.GetFieldByInternalName(fieldName);
                    }
                    else
                    {
                        field = getRealField(list.Fields.GetFieldByInternalName(fieldName));
                    }

                    val = dr[field.InternalName].ToString();

                    if (fieldName != "List" && fieldName != "Site" && field.Type != SPFieldType.Attachments)
                        displayValue = formatField(val, fieldName, dr, false);
                    else
                        displayValue = val;
                    
                    if (field.InternalName == "Title")
                    {
                        string url = "";
                        switch (linktype)
                        {
                            case "view":
                                if (usePopup)
                                    url = "javascript:viewItem(" + dr["ID"].ToString() + ",'" + dr["ListId"].ToString() + "','" + dr["WebId"].ToString() + "','" + dr["siteid"].ToString() + "','" + dr["SiteUrl"].ToString() + "',1);";
                                else
                                    url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=view&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                break;
                            case "edit":
                                if (usePopup)
                                    url = "javascript:viewItem(" + dr["ID"].ToString() + ",'" + dr["ListId"].ToString() + "','" + dr["WebId"].ToString() + "','" + dr["siteid"].ToString() + "','" + dr["SiteUrl"].ToString() + "',2);";
                                else
                                    url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=edit&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                break;
                            case "":
                                if (fieldName == "LinkTitleNoMenu")
                                {
                                    if (usePopup)
                                        url = "javascript:viewItem(" + dr["ID"].ToString() + ",'" + dr["ListId"].ToString() + "','" + dr["WebId"].ToString() + "','" + dr["siteid"].ToString() + "','" + dr["SiteUrl"].ToString() + "',1);";
                                    else
                                        url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=view&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                }
                                else if (fieldName == "LinkTitle")
                                {
                                    if (usePopup)
                                        url = "javascript:viewItem(" + dr["ID"].ToString() + ",'" + dr["ListId"].ToString() + "','" + dr["WebId"].ToString() + "','" + dr["siteid"].ToString() + "','" + dr["SiteUrl"].ToString() + "',2);";
                                    else
                                        url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=edit&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                }
                                break;
                            case "workspace":
                                url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=workspace&webid=" + dr["WebId"].ToString();
                                break;
                            case "workplan":
                                url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=workplan&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString();
                                break;
                            case "tasks":
                                url = dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=tasks&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]) + "&FilterField1=Project&FilterValue1=" + System.Web.HttpUtility.UrlEncode(dr[fieldName].ToString());
                                break;
                        };
                        if (url != "")
                        {
                            XmlAttribute attrValueFormat = doc.CreateAttribute("ValueFormat");
                            attrValueFormat.Value = "1";
                            ndNewCell.Attributes.Append(attrValueFormat);

                            val = "<a" + url + ">" + val + "</a>";
                            displayValue = val;
                        }
                    }
                    else if (field.Type == SPFieldType.Attachments)
                    {
                        if (val == "true")
                            val = "<a href=\"" + dr["SiteUrl"].ToString() + "/_layouts/epmlive/gridaction.aspx?action=attachments&webid=" + dr["WebId"].ToString() + "&listid=" + dr["ListId"].ToString() + "&ID=" + dr["ID"].ToString() + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]) + "\">View</a>";
                        else
                            val = "";
                        break;
                    }
                    //else
                    //{
                    //    switch (field.Type)
                    //    {
                    //        case SPFieldType.Calculated:
                    //            if (field.Description == "Indicator")
                    //            {
                    //                XmlAttribute attrValueFormat = doc.CreateAttribute("ValueFormat");
                    //                attrValueFormat.Value = "1";
                    //                ndNewCell.Attributes.Append(attrValueFormat);
                    //                val = "<img>" + val.ToLower() + "</img>";
                    //            }
                    //            break;
                    //    }
                    //}
                    if (!wbs.Contains("."))
                    {
                        foreach (string group in groups)
                        {
                            setAggVal(group, fieldName, val, list);
                        }
                    }
                }
                catch { }
                XmlAttribute attrValue = doc.CreateAttribute("Value");
                attrValue.Value = displayValue;
                ndNewCell.Attributes.Append(attrValue);
                XmlAttribute attrValueFormat1 = doc.CreateAttribute("ValueFormat");
                attrValueFormat1.Value = "1";
                ndNewCell.Attributes.Append(attrValueFormat1);
                ndNewItem.AppendChild(ndNewCell);

            }
            string strStart = "";
            if (dr.Table.Columns.Contains(start))
                strStart = dr[start].ToString();

            string strFinish = "";
            if (dr.Table.Columns.Contains(finish))
                strFinish = dr[finish].ToString();

            if (strFinish != "")
            {
                bool forceMS = false;
                if (strStart == "")
                {
                    strStart = strFinish;
                    forceMS = true;
                }
                XmlNode ndBars = doc.CreateNode(XmlNodeType.Element, "Bars", doc.NamespaceURI);
                ndNewItem.AppendChild(ndBars);
                try
                {
                    DateTime dtStart = DateTime.Parse(strStart);
                    DateTime dtFinish = DateTime.Parse(strFinish);

                    strStart = dtStart.ToString();//"MM/dd/yyyy", dtProviderEn);

                    string duration = getField(dr, "Duration");

                    foreach (string group in groups)
                    {
                        if (group != null)
                            setMinMax(group, dtStart, dtFinish);
                    }
                    if (dtStart < overallMin)
                        overallMin = dtStart;

                    XmlNode ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);

                    string isMilestone = "False";
                    if (milestone != "")
                        isMilestone = getField(dr, milestone);

                    XmlAttribute attrName = doc.CreateAttribute("Name");
                    XmlAttribute attrPercent = doc.CreateAttribute("Percent");
                    attrPercent.Value = "0";

                    XmlAttribute attrStart = doc.CreateAttribute("Start");

                    if (isMilestone == "True" || duration == "0" || forceMS)
                    {
                        attrName.Value = "Milestone";
                        attrStart.Value = dtStart.ToString();//"MM/dd/yyyy", dtProviderEn);
                    }
                    else
                    {

                        try
                        {
                            //string strPct = getField(li, progress);
                            //double pct = double.Parse(getField(li, progress).Replace("%", "")) / 100;
                            attrPercent.Value = getField(dr, progress); //pct.ToString();
                        }
                        catch { }
                        attrStart.Value = strStart;
                        attrName.Value = "TaskP";

                        try
                        {
                            if (getField(dr, "Critical") == "True" && !isResourcePlan)
                                attrName.Value = "TaskC";
                        }
                        catch { }
                    }

                    XmlAttribute attrEnd = doc.CreateAttribute("End");
                    attrEnd.Value = dtFinish.AddDays(1).ToString();//"MM/dd/yyyy",dtProviderEn);
                    XmlAttribute attrCaption = doc.CreateAttribute("Caption");
                    string info = getField(dr, information);
                    try
                    {
                        info = formatField(info, information, false, false);
                    }
                    catch { }
                    attrCaption.Value = info;
                    XmlAttribute attrHAlignCaption = doc.CreateAttribute("HAlignCaption");
                    attrHAlignCaption.Value = "18";
                    ndBar.Attributes.Append(attrName);
                    ndBar.Attributes.Append(attrStart);
                    ndBar.Attributes.Append(attrEnd);
                    ndBar.Attributes.Append(attrCaption);
                    ndBar.Attributes.Append(attrPercent);
                    ndBar.Attributes.Append(attrHAlignCaption);

                    if (isResourcePlan)
                    {
                        //double work = 0;
                        //try
                        //{
                        //    work = double.Parse(getField(dr,"Work"));
                        //    SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(li.ParentList.ParentWeb, li[li.Fields.GetFieldByInternalName("AssignedTo").Id].ToString());
                        //    work = work / uvc.Count;
                        //}
                        //catch { }
                        //XmlAttribute attrWork = doc.CreateAttribute("EPMLiveWork");
                        //attrWork.Value = work.ToString();
                        //ndBar.Attributes.Append(attrWork);


                        //XmlAttribute attrRW = doc.CreateAttribute("EPMLiveRW");
                        //attrRW.Value = li.DoesUserHavePermissions(curUser, SPBasePermissions.EditListItems).ToString();
                        //ndBar.Attributes.Append(attrRW);
                    }

                    ndBars.AppendChild(ndBar);

                    if (progress != "" && isMilestone != "True")
                    {
                        try
                        {
                            double pct = double.Parse(getField(dr, progress).Replace("%", "")) / 100;

                            TimeSpan ts = dtFinish - dtStart;
                            double seconds = ts.Seconds * pct;

                            strFinish = dtStart.AddSeconds(seconds).ToString("MM/dd/yyyy", dtProviderEn);

                            ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);
                            attrName = doc.CreateAttribute("Name");
                            attrName.Value = "Progress";
                            attrStart = doc.CreateAttribute("Start");
                            attrStart.Value = strStart;
                            attrEnd = doc.CreateAttribute("End");
                            attrEnd.Value = strFinish;
                            ndBar.Attributes.Append(attrName);
                            ndBar.Attributes.Append(attrStart);
                            ndBar.Attributes.Append(attrEnd);

                            //ndBars.AppendChild(ndBar);

                        }
                        catch { }
                    }
                }
                catch { }
                if (ndBars.ChildNodes.Count <= 0)
                {
                    ndNewItem.RemoveChild(ndBars);
                }
            }
            foreach (string group in groups)
            {


                XmlNode ndItems = null;
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
                            ndGroup = (XmlNode)hshWBS[group + "\n" + parentwbs];

                            if (ndGroup == null)
                                return doc;

                            ndItems = ndGroup.SelectSingleNode("Items");
                            if (ndItems == null)
                            {
                                ndItems = doc.CreateNode(XmlNodeType.Element, "Items", doc.NamespaceURI);
                                ndGroup.AppendChild(ndItems);
                            }

                            if (expanded == "FALSE")
                            {
                                XmlAttribute attrExpand = doc.CreateAttribute("Expanded");
                                attrExpand.Value = "1";
                                ndGroup.Attributes.Append(attrExpand);
                            }

                            try
                            {
                                XmlNode ndBars = ndGroup.SelectSingleNode("Bars");
                                ndBars.ChildNodes[0].Attributes["Name"].Value = "Summary";
                            }
                            catch { }

                            foreach (XmlNode nd in ndGroup.ChildNodes)
                            {
                                if (nd.Name == "Cell")
                                {
                                    if (nd.Attributes["Value"].Value.Contains("<b>"))
                                        break;
                                    else
                                        nd.Attributes["Value"].Value = "<b>" + nd.Attributes["Value"].Value + "</b>";


                                }
                            }

                            if (!hshWBSSummaryTasks.Contains(group + "\n" + parentwbs))
                                hshWBSSummaryTasks.Add(group + "\n" + parentwbs, ndGroup);
                        }
                    }
                }

                if (!wbsfound)
                {
                    if (group != null)
                        ndGroup = (XmlNode)hshItemNodes[group];
                    else
                        ndGroup = ndMainParent;
                    // (XmlNode)hshItemNodes[group];

                    if (ndGroup == null)
                        return doc;

                    if (ndGroup.Name == "Items")
                        ndItems = ndGroup;
                    else
                        ndItems = ndGroup.SelectSingleNode("Items");
                    //if(ndItems == null)
                    //{
                    //    ndItems = doc.CreateNode(XmlNodeType.Element, "Items", doc.NamespaceURI);
                    //    ndGroup.AppendChild(ndItems);
                    //}

                    //if (group == "")
                    //{
                    //    ndItems = ndGroup;
                    //}
                    //else 
                    if (ndItems == null)
                    {
                        ndItems = doc.CreateNode(XmlNodeType.Element, "Items", doc.NamespaceURI);
                        ndGroup.AppendChild(ndItems);
                    }
                }

                XmlAttribute attrgroupto = doc.CreateAttribute("GroupTo");
                attrgroupto.Value = group + "." + getField(dr, "taskorder");
                XmlAttribute attrPreds = doc.CreateAttribute("Predecessors");
                attrPreds.Value = getField(dr, "Predecessors");
                ndNewItem.Attributes.Append(attrgroupto);
                ndNewItem.Attributes.Append(attrPreds);

                XmlNode ndCloned = ndNewItem.CloneNode(true);
                ndItems.AppendChild(ndCloned);
                if (wbs != "")
                {
                    if (!hshWBS.Contains(group + "\n" + wbs))
                        hshWBS.Add(group + "\n" + wbs, ndCloned);
                }
            }
            return doc;
        }

        private XmlDocument addItem(SPListItem li, XmlDocument doc)
        {
            if (!arrItems.Contains(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID))
            {
                return doc;
            }

            string wbs = getField(li, wbsfield);

            string[] groups = (string[])arrItems[li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID];

            XmlNode ndNewItem = doc.CreateNode(XmlNodeType.Element, "Item", doc.NamespaceURI);
            SPViewFieldCollection vfc = view.ViewFields;
            for (int i = 0; i < vfc.Count; i++)
            {
                string val = "";
                string displayValue = "";
                XmlNode ndNewCell = doc.CreateNode(XmlNodeType.Element, "Cell", doc.NamespaceURI);

                try
                {
                    string fieldName = vfc[i];

                    val = getField(li, fieldName);

                    SPField field = null;
                    if (fieldName == "List" || fieldName == "Site")
                    {
                        field = list.Fields.GetFieldByInternalName(fieldName);
                        displayValue = val;
                    }
                    else
                    {
                        field = getRealField(li.ParentList.Fields.GetFieldByInternalName(fieldName));
                        displayValue = formatField(val, fieldName, field.Type == SPFieldType.Calculated, false);
                    }
                    if (field.InternalName == "Title")
                    {
                        string url = "";
                        string weburl = ((list.ParentWeb.ServerRelativeUrl == "/") ? "" : list.ParentWeb.ServerRelativeUrl);
                        switch (linktype)
                        {
                            case "":
                                if (fieldName == "LinkTitleNoMenu")
                                {
                                    if (usePopup)
                                        url = "javascript:viewItem(" + li.ID + ",'" + li.ParentList.ID + "','" + li.ParentList.ParentWeb.ID + "','" + li.ParentList.ParentWeb.Site.ID + "','" + weburl + "',1);";
                                    else
                                        url = li.ParentList.ParentWeb.Url + "/" + li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                }
                                else if (fieldName == "LinkTitle")
                                {
                                    if (usePopup)
                                        url = "javascript:viewItem(" + li.ID + ",'" + li.ParentList.ID + "','" + li.ParentList.ParentWeb.ID + "','" + li.ParentList.ParentWeb.Site.ID + "','" + weburl + "',2);";
                                    else
                                        url = li.ParentList.ParentWeb.Url + "/" + li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].Url + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                }
                                break;
                            case "view":
                                if(usePopup)
                                    url = "javascript:void(0);\" onclick=\"javascript:viewItem(" + li.ID + ",'" + li.ParentList.ID + "','" + li.ParentList.ParentWeb.ID + "','" + li.ParentList.ParentWeb.Site.ID + "','" + weburl + "',1);";
                                else
                                    url = li.ParentList.ParentWeb.Url + "/" + li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                break;
                            case "edit":
                                if (usePopup)
                                    url = "javascript:void(0);\" onclick=\"javascript:viewItem(" + li.ID + ",'" + li.ParentList.ID + "','" + li.ParentList.ParentWeb.ID + "','" + li.ParentList.ParentWeb.Site.ID + "','" + weburl + "',2);";
                                else
                                    url = li.ParentList.ParentWeb.Url + "/" + li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].Url + "?ID=" + li.ID + "&Source=" + System.Web.HttpUtility.UrlEncode(Request["source"]);
                                break;
                            case "workspace":
                                url = li.ParentList.ParentWeb.Url + "/";
                                break;
                            case "workplan":
                                url = li.ParentList.ParentWeb.Url + "/_layouts/epmlive/tasks.aspx?ID=" + li.ID;
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
                                    url = li.ParentList.ParentWeb.Url + "/" + taskList.DefaultView.Url + "?FilterField1=Project&FilterValue1=" + System.Web.HttpUtility.UrlEncode(li.Title);
                                }
                                break;
                        };
                        if (url != "")
                        {
                            XmlAttribute attrValueFormat = doc.CreateAttribute("ValueFormat");
                            attrValueFormat.Value = "1";
                            ndNewCell.Attributes.Append(attrValueFormat);

                            val = "<a" + url + ">" + val + "</a>";
                            displayValue = val;
                        }
                    }
                    else if (field.Type == SPFieldType.Attachments)
                    {
                        if (li.Attachments.Count > 0)
                        {
                            SPFolder sourceItemAttachmentsFolder = li.Web.Folders["Lists"].SubFolders[li.ParentList.Title].SubFolders["Attachments"].SubFolders[li.ID.ToString()];

                            XmlAttribute attrValueFormat = doc.CreateAttribute("ValueFormat");
                            attrValueFormat.Value = "1";
                            ndNewCell.Attributes.Append(attrValueFormat);

                            val = "<a" + sourceItemAttachmentsFolder.Files[0].ServerRelativeUrl + ">" + sourceItemAttachmentsFolder.Files[0].Name + "</a>";
                        }
                        else
                            val = "";
                        displayValue = val;
                    }
                    //else
                    //{
                    //    switch (field.Type)
                    //    {
                    //        case SPFieldType.Calculated:
                    //            if (field.Description == "Indicator")
                    //            {
                    //                XmlAttribute attrValueFormat = doc.CreateAttribute("ValueFormat");
                    //                attrValueFormat.Value = "1";
                    //                ndNewCell.Attributes.Append(attrValueFormat);
                    //                val = "<img>" + val.ToLower() + "</img>";
                    //            }
                    //            break;
                    //    }
                    //}
                    if (!wbs.Contains("."))
                    {
                        foreach (string group in groups)
                        {
                            setAggVal(group, fieldName, val, list);
                        }
                    }
                }
                catch { }
                XmlAttribute attrValue = doc.CreateAttribute("Value");
                attrValue.Value = displayValue;
                ndNewCell.Attributes.Append(attrValue);
                XmlAttribute attrValueFormat1 = doc.CreateAttribute("ValueFormat");
                attrValueFormat1.Value = "1";
                ndNewCell.Attributes.Append(attrValueFormat1);
                ndNewItem.AppendChild(ndNewCell);

            }
            string strStart = getField(li, start);
            string strFinish = getField(li, finish);

            if (strFinish != "")
            {
                bool forceMS = false;
                if (strStart == "")
                {
                    strStart = strFinish;
                    forceMS = true;
                }
                XmlNode ndBars = doc.CreateNode(XmlNodeType.Element, "Bars", doc.NamespaceURI);
                ndNewItem.AppendChild(ndBars);
                try
                {
                    DateTime dtStart = DateTime.Parse(strStart);
                    dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, startHour, 0, 0);
                    //dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, 0, 0, 0);
                    DateTime dtFinish = DateTime.Parse(strFinish);
                    dtFinish = new DateTime(dtFinish.Year, dtFinish.Month, dtFinish.Day, endHour, 0, 0);
                    //dtFinish = new DateTime(dtFinish.Year, dtFinish.Month, dtFinish.Day, 23, 59, 59);

                    strStart = dtStart.ToString();//"MM/dd/yyyy", dtProviderEn);

                    string duration = getField(li, "Duration");

                    foreach (string group in groups)
                    {
                        if(group != null)
                            setMinMax(group, dtStart, dtFinish);
                    }
                    if (dtStart < overallMin)
                        overallMin = dtStart;

                    XmlNode ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);

                    string isMilestone = "False";
                    if (milestone != "")
                        isMilestone = getField(li, milestone);

                    XmlAttribute attrName = doc.CreateAttribute("Name");
                    XmlAttribute attrPercent = doc.CreateAttribute("Percent");
                    attrPercent.Value = "0";

                    XmlAttribute attrStart = doc.CreateAttribute("Start");

                    if (isMilestone == "True" || duration == "0" || forceMS)
                    {
                        attrName.Value = "Milestone";
                        attrStart.Value = dtStart.ToString();//"MM/dd/yyyy", dtProviderEn);
                    }
                    else
                    {

                        try
                        {
                            //string strPct = getField(li, progress);
                            //double pct = double.Parse(getField(li, progress).Replace("%", "")) / 100;
                            attrPercent.Value = getField(li, progress); //pct.ToString();
                        }
                        catch { }
                        attrStart.Value = strStart;
                        attrName.Value = "TaskP";

                        try
                        {
                            if (getField(li, "Critical") == "True" && !isResourcePlan)
                                attrName.Value = "TaskC";
                        }
                        catch { }
                    }

                    XmlAttribute attrEnd = doc.CreateAttribute("End");
                    attrEnd.Value = dtFinish.ToString();
                    XmlAttribute attrCaption = doc.CreateAttribute("Caption");
                    string info = getField(li, information);
                    try{
                        info = formatField(info, information, false, false);
                    }catch{}
                    attrCaption.Value = info;
                    XmlAttribute attrHAlignCaption = doc.CreateAttribute("HAlignCaption");
                    attrHAlignCaption.Value = "18";
                    ndBar.Attributes.Append(attrName);
                    ndBar.Attributes.Append(attrStart);
                    ndBar.Attributes.Append(attrEnd);
                    ndBar.Attributes.Append(attrCaption);
                    ndBar.Attributes.Append(attrPercent);
                    ndBar.Attributes.Append(attrHAlignCaption);

                    if (isResourcePlan)
                    {
                        double work = 0;
                        try
                        {
                            work = double.Parse(li[li.Fields.GetFieldByInternalName("Work").Id].ToString());
                            SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(li.ParentList.ParentWeb, li[li.Fields.GetFieldByInternalName("AssignedTo").Id].ToString());
                            work = work / uvc.Count;
                        }
                        catch { }
                        XmlAttribute attrWork = doc.CreateAttribute("EPMLiveWork");
                        attrWork.Value = work.ToString();
                        ndBar.Attributes.Append(attrWork);


                        XmlAttribute attrRW = doc.CreateAttribute("EPMLiveRW");
                        attrRW.Value = li.DoesUserHavePermissions(curUser, SPBasePermissions.EditListItems).ToString();
                        ndBar.Attributes.Append(attrRW);
                    }

                    ndBars.AppendChild(ndBar);

                    if (progress != "" && isMilestone != "True")
                    {
                        try
                        {
                            double pct = double.Parse(getField(li, progress).Replace("%", "")) / 100;

                            TimeSpan ts = dtFinish - dtStart;
                            double seconds = ts.Seconds * pct;

                            strFinish = dtStart.AddSeconds(seconds).ToString("MM/dd/yyyy", dtProviderEn);

                            ndBar = doc.CreateNode(XmlNodeType.Element, "Bar", doc.NamespaceURI);
                            attrName = doc.CreateAttribute("Name");
                            attrName.Value = "Progress";
                            attrStart = doc.CreateAttribute("Start");
                            attrStart.Value = strStart;
                            attrEnd = doc.CreateAttribute("End");
                            attrEnd.Value = strFinish;
                            ndBar.Attributes.Append(attrName);
                            ndBar.Attributes.Append(attrStart);
                            ndBar.Attributes.Append(attrEnd);

                            //ndBars.AppendChild(ndBar);

                        }
                        catch { }
                    }
                }
                catch{ }
                if (ndBars.ChildNodes.Count <= 0)
                {
                    ndNewItem.RemoveChild(ndBars);
                }
            }



            foreach (string group in groups)
            {

                
                XmlNode ndItems = null;
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
                            ndGroup = (XmlNode)hshWBS[group + "\n" + parentwbs];

                            if (ndGroup == null)
                                return doc;

                            ndItems = ndGroup.SelectSingleNode("Items");
                            if (ndItems == null)
                            {
                                ndItems = doc.CreateNode(XmlNodeType.Element, "Items", doc.NamespaceURI);
                                ndGroup.AppendChild(ndItems);
                            }

                            if (expanded == "FALSE")
                            {
                                XmlAttribute attrExpand = doc.CreateAttribute("Expanded");
                                attrExpand.Value = "1";
                                ndGroup.Attributes.Append(attrExpand);
                            }

                            try
                            {
                                XmlNode ndBars = ndGroup.SelectSingleNode("Bars");
                                ndBars.ChildNodes[0].Attributes["Name"].Value = "Summary";
                            }
                            catch { }

                            foreach (XmlNode nd in ndGroup.ChildNodes)
                            {
                                if (nd.Name == "Cell")
                                {
                                    if (nd.Attributes["Value"].Value.Contains("<b>"))
                                        break;
                                    else
                                        nd.Attributes["Value"].Value = "<b>" + nd.Attributes["Value"].Value + "</b>";


                                }
                            }

                            if (!hshWBSSummaryTasks.Contains(group + "\n" + parentwbs))
                                hshWBSSummaryTasks.Add(group + "\n" + parentwbs, ndGroup);
                        }
                    }
                }

                if (!wbsfound)
                {
                    if (group != null)
                        ndGroup = (XmlNode)hshItemNodes[group];
                    else
                        ndGroup = ndMainParent;
                    // (XmlNode)hshItemNodes[group];

                    if (ndGroup == null)
                        return doc;

                    if (ndGroup.Name == "Items")
                        ndItems = ndGroup;
                    else
                    ndItems = ndGroup.SelectSingleNode("Items");
                    //if(ndItems == null)
                    //{
                    //    ndItems = doc.CreateNode(XmlNodeType.Element, "Items", doc.NamespaceURI);
                    //    ndGroup.AppendChild(ndItems);
                    //}

                    //if (group == "")
                    //{
                    //    ndItems = ndGroup;
                    //}
                    //else 
                    if (ndItems == null)
                    {
                        ndItems = doc.CreateNode(XmlNodeType.Element, "Items", doc.NamespaceURI);
                        ndGroup.AppendChild(ndItems);
                    }
                }

                XmlAttribute attrgroupto = doc.CreateAttribute("GroupTo");
                attrgroupto.Value = group + "." + getField(li, "taskorder");
                XmlAttribute attrPreds = doc.CreateAttribute("Predecessors");
                attrPreds.Value = getField(li, "Predecessors");
                ndNewItem.Attributes.Append(attrgroupto);
                ndNewItem.Attributes.Append(attrPreds);

                XmlNode ndCloned = ndNewItem.CloneNode(true);
                ndItems.AppendChild(ndCloned);
                if (wbs != "")
                {
                    if (!hshWBS.Contains(group + "\n" + wbs))
                        hshWBS.Add(group + "\n" + wbs, ndCloned);
                }
            }

            return doc;
        }

        private void setAggVal(string group, string fieldname, string val, SPList aggList)
        {
            try
            {
                SPField field = getRealField(aggList.Fields.GetFieldByInternalName(fieldname));
                fieldname = field.InternalName;

                XmlDocument fieldXml = new XmlDocument();
                fieldXml.LoadXml(field.SchemaXml);

                if (arrAggregationDef.Contains(fieldname) && arrAggregationVals.Contains(group + "\n" + fieldname))
                {
                    string curVal = arrAggregationVals[group + "\n" + fieldname].ToString();
                    switch (arrAggregationDef[fieldname].ToString())
                    {
                        case "COUNT":
                            {
                                int iCurVal = int.Parse(curVal) + 1;
                                arrAggregationVals[group + "\n" + fieldname] = iCurVal;
                            }
                            val = arrAggregationVals[group + "\n" + fieldname].ToString();
                            break;
                        case "STDEV":
                        case "AVG":
                            {
                                arrAggregationVals[group + "\n" + fieldname] = curVal + "," + val.Replace("%", "").Replace("$", "");
                            }
                            break;
                        case "SUM":
                            {
                                double iCurVal = double.Parse(curVal);
                                double iNewVal = double.Parse(val.Replace("%","").Replace("$",""));
                                arrAggregationVals[group + "\n" + fieldname] = iNewVal + iCurVal;
                            }
                            //val = arrAggregationVals[group + "\n" + fieldname].ToString();
                            break;
                        case "MIN":
                            if (field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.Calculated)
                            {
                                double iNewVal = double.Parse(val.Replace("%", "").Replace("$", ""));
                                if (curVal != "")
                                {
                                    double iCurVal = double.Parse(curVal);

                                    if (iNewVal < iCurVal)
                                        arrAggregationVals[group + "\n" + fieldname] = iNewVal;
                                }
                                else
                                    arrAggregationVals[group + "\n" + fieldname] = iNewVal;
                            }
                            else if (field.Type == SPFieldType.DateTime)
                            {
                                DateTime iCurVal = DateTime.Parse(curVal);
                                DateTime iNewVal = DateTime.Parse(val.Replace("%", "").Replace("$", ""));
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
                            if (field.Type == SPFieldType.Number || field.Type == SPFieldType.Currency || field.Type == SPFieldType.Calculated)
                            {
                                double iNewVal = double.Parse(val.Replace("%", "").Replace("$", ""));
                                if (curVal != "")
                                {
                                    double iCurVal = double.Parse(curVal);

                                    if (iNewVal > iCurVal)
                                        arrAggregationVals[group + "\n" + fieldname] = iNewVal;
                                }
                                else
                                    arrAggregationVals[group + "\n" + fieldname] = iNewVal;
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
                }
                if (group.Contains("\n"))
                {
                    int ind = group.LastIndexOf("\n");
                    setAggVal(group.Substring(0, ind), fieldname, val, aggList);
                }
            }
            catch { }

        }

        protected SPField getRealField(SPField field)
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

        //private XmlDocument addItems(XmlDocument doc)
        //{
            
            
        //    SPViewFieldCollection vfc = view.ViewFields;
        //    SPQuery query = new SPQuery();
        //    query.Query = view.Query;
        //    foreach (SPListItem li in list.GetItems(query))
        //    {
        //        XmlNode ndItem = doc.CreateNode(XmlNodeType.Element, "Item", doc.NamespaceURI);
        //        XmlAttribute attrExpanded = doc.CreateAttribute("Expanded");
        //        attrExpanded.Value = "-1";
        //        ndItem.Attributes.Append(attrExpanded);
        //        foreach (string f in vfc)
        //        {
        //            if (f == "LinkTitle" || f == "Title")
        //            {
                         
        //                XmlNode ndCell = doc.CreateNode(XmlNodeType.Element, "Cell", doc.NamespaceURI);
        //                XmlAttribute attrValue = doc.CreateAttribute("Value");
        //                try
        //                {
        //                    attrValue.Value = li[list.Fields.GetFieldByInternalName(f).Id].ToString();
        //                }
        //                catch { }
        //                ndCell.Attributes.Append(attrValue);
        //                ndItem.AppendChild(ndCell);
        //            }
        //            else
        //            {
        //                XmlNode ndCell = doc.CreateNode(XmlNodeType.Element, "Cell", doc.NamespaceURI);
        //                XmlAttribute attrValue = doc.CreateAttribute("Value");
        //                try
        //                {
        //                    attrValue.Value = li[list.Fields.GetFieldByInternalName(f).Id].ToString();
        //                }
        //                catch { }
        //                ndCell.Attributes.Append(attrValue);
        //                ndItem.AppendChild(ndCell);
                        
        //            }
        //        }
        //        ndItems.AppendChild(ndItem);
        //    }
        //    doc.ChildNodes[0].AppendChild(ndItems);
        //    return doc;
        //}
    }
}

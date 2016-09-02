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
using System.Xml.XPath;

namespace EPMLiveWebParts
{
    public partial class getitems : System.Web.UI.Page
    {
        private string strXml = "";
        private XmlDocument docXml;
        private XmlDocument docConfig;
        private XmlNode ndCurrentView;

        private SPWeb curWeb;
        private string curView = "";
        protected string data = "";

        //=========================Data=========
        private ArrayList arrColumns = new ArrayList();
        private Queue queueAllItems = new Queue();
        private SortedList arrItems = new SortedList();
        private Hashtable hshItemNodes = new Hashtable();
        
        private SortedList arrAggregationDef = new SortedList();
        private SortedList arrAggregationVals = new SortedList();
        private Hashtable hshWBS = new Hashtable();
        private SortedList arrGroupMin = new SortedList();
        private SortedList arrGroupMax = new SortedList();
        private XmlNode ndMainParent;
        private Hashtable hshGroups = new Hashtable();
        private string[] arrGroupFields;
        private string[] arrGroupExpand;
        //======================================

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            curWeb = SPContext.Current.Web;
            curWeb.Site.CatchAccessDeniedException = false;

            strXml = Request["data"];
            try
            {
                curView = Request["view"].ToString();
            }
            catch { }
            curView = curView.Replace("'", "&apos;");
            docConfig = new XmlDocument();
            docConfig.LoadXml(strXml);

            docXml = new XmlDocument();
            docXml.LoadXml("<rows></rows>");
            ndMainParent = docXml.ChildNodes[0];

            if (curView == "")
                ndCurrentView = docConfig.SelectSingleNode("Views/View[@Default=1]");
            else
                ndCurrentView = docConfig.SelectSingleNode("Views/View[@Name='" + curView + "']");

            addHeader();
            addGroups();
            addItems();

            data = docXml.OuterXml;
            
        }

        private void addGroups()
        {
            XmlNodeList ndGroups = ndCurrentView.SelectNodes("GroupBy");

            arrGroupFields = new string[ndGroups.Count];
            arrGroupExpand = new string[ndGroups.Count];
            int counter = 0;
            foreach (XmlNode nd in ndGroups)
            {
                try
                {
                    arrGroupFields[counter] = nd.Attributes["Column"].Value;
                    try
                    {
                        arrGroupExpand[counter] = nd.Attributes["Expand"].Value;
                    }catch{arrGroupExpand[counter] = "0";}
                    counter++;
                }
                catch { }
            }
            addGroups(curWeb);
        }

        private void addItems()
        {
            while (queueAllItems.Count > 0)
            {
                addItem((SPListItem)queueAllItems.Dequeue());
            }
        }

        private void addItem(SPListItem li)
        {

            if (!arrItems.Contains(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID))
            {
                return;
            }

            string[] itemInfo = arrItems[li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID].ToString().Split('|');

            XmlNode ndNewItem = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
            XmlAttribute attrId = docXml.CreateAttribute("id");
            attrId.Value = li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID;
            if (!li.DoesUserHavePermissions(SPBasePermissions.EditListItems))
            {
                XmlAttribute attrLocked = docXml.CreateAttribute("locked");
                attrLocked.Value = "1";
                ndNewItem.Attributes.Append(attrLocked);
            }
            ndNewItem.Attributes.Append(attrId);
            

            //////////////////////////////////////////////////////////ndNewItem = addMenus(ndNewItem, li.ParentList);

            //===========Site URL====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "SiteUrl";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ParentList.ParentWeb.Url;
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
            //===========ViewUrl====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "viewurl";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
                ndNewItem.AppendChild(ndSiteUrl);
            }
            //===========EditUrl====================
            {
                XmlNode ndSiteUrl = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                XmlAttribute attrName = docXml.CreateAttribute("name");
                attrName.Value = "editurl";
                ndSiteUrl.Attributes.Append(attrName);
                ndSiteUrl.InnerText = li.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].Url;
                ndNewItem.AppendChild(ndSiteUrl);
            }

            foreach (XmlNode ndColumn in ndCurrentView.SelectNodes("Column"))
            {
                string field = ndColumn.Attributes["Name"].Value;

                XmlNode ndRealCol = ndCurrentView.SelectSingleNode("Lists/List[@Name='" + itemInfo[3].Replace("'", "&apos;") + "']/Column[@Name='" + field.Replace("'", "&apos;") + "']");
                if (ndRealCol != null)
                {
                    try
                    {
                        field = ndRealCol.Attributes["Mapping"].Value;
                    }
                    catch { }
                }
                string format = "Text";
                try
                {
                    format = ndColumn.Attributes["Format"].Value;
                }
                catch { }
                string val = "";
                XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                XmlAttribute attrStyle = docXml.CreateAttribute("type");
                
                try
                {
                    val = getField(li, field, false);
                    if (field == "~Icon")
                    {
                        val = "_layouts/images/" + itemInfo[1];
                    }
                    else if (field == "~Site")
                    {
                        val = "<a href=\"" + li.ParentList.ParentWeb.Url + "\">" + li.ParentList.ParentWeb.Title + "</a>";
                    }
                    else if (field == "~Complete")
                    {
                        string column = "";
                        try
                        {
                            XmlNode ndComplete = ndCurrentView.SelectSingleNode("Lists/List[@Name='" + itemInfo[3] + "']/Complete");
                            string tmp = ndComplete.Attributes["Value"].Value;
                            column = ndComplete.Attributes["Column"].Value;
                        }
                        catch { }
                        if(column == "")
                            attrStyle.Value = "ro";

                        val = "";
                    }
                    else if (field == "~List")
                    {
                        val = "<a href=\"" + li.ParentList.ParentWeb.Url + "/" + li.ParentList.DefaultView.Url + "\">" + itemInfo[2] + "</a>";
                    }
                    else
                    {
                        attrStyle.Value = "ro";
                        try
                        {
                            SPField spfield = li.Fields.GetFieldByInternalName(field);
                            switch (spfield.Type)
                            {
                                case SPFieldType.Calculated:
                                    if (spfield.Description == "Indicator")
                                    {
                                        //XmlAttribute attrValueFormat = docXml.CreateAttribute("ValueFormat");
                                        //attrValueFormat.Value = "1";
                                        //ndNewCell.Attributes.Append(attrValueFormat);
                                        val = "<img src=\"" + curWeb.Url + "/_layouts/images/" + val.ToLower() + "\">";
                                    }
                                    break;
                            }
                            if (spfield.ShowInEditForm == true || spfield.ShowInEditForm == null)
                            {
                                attrStyle.Value = "";
                                if (field == "Title")
                                {
                                    attrStyle.Value = "tree";
                                }
                                else
                                {
                                    switch (spfield.Type)
                                    {
                                        case SPFieldType.DateTime:
                                            attrStyle.Value = "dhxCalendarA";
                                            break;
                                        case SPFieldType.Currency:
                                            attrStyle.Value = "price";
                                            break;
                                        default:
                                            //attrStyle.Value = "ed";
                                            break;
                                    }
                                }


                            }

                        }
                        catch { }
                    }

                        //foreach (string group in groups)
                        //{
                        //    setAggVal(group, fieldName, val, list);
                        //}
                }
                catch { }
                if(attrStyle.Value  != "")
                    ndNewCell.Attributes.Append(attrStyle);
                //XmlAttribute attrStyle = docXml.CreateAttribute("style");
                //attrStyle.Value = "height:auto;white-space:normal;";
                //ndNewCell.Attributes.Append(attrStyle);
                //XmlAttribute attrValueFormat1 = docXml.CreateAttribute("ValueFormat");
                //attrValueFormat1.Value = "1";
                //ndNewCell.Attributes.Append(attrValueFormat1);



                ndNewCell.InnerXml = "<![CDATA[" + val + "]]>";

                ndNewItem.AppendChild(ndNewCell);

            }

            XmlNode ndNewCell1 = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            ndNewCell1.InnerText = "1";
            ndNewItem.AppendChild(ndNewCell1);

            //foreach (string group in groups)
            {
                string group = itemInfo[0];
                string wbs = "";
                try
                {
                    if(ndCurrentView.Attributes["WBS"].Value == "1")
                        getField(li, "WBS", false);
                }catch{}
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
                                return;
                        }
                    }
                }

                if (!wbsfound)
                {
                    if (group != "*")
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
                ndGroup.AppendChild(ndCloned);
                if (wbs != "")
                {
                    if (!hshWBS.Contains(group + "\n" + wbs))
                        hshWBS.Add(group + "\n" + wbs, ndCloned);
                }
            }
        }

        private string getRealQuery(XmlNode nd, SPWeb web)
        {
            string strQuery = "";
            try { strQuery = nd.SelectSingleNode("Query").InnerText; }
            catch { }
            try
            {
                string strFilterQuery = "";
                try { strFilterQuery = nd.SelectSingleNode("FilterQuery").InnerText; }
                catch { }
                string strFilterQueryList = "";
                try { strFilterQueryList = nd.SelectSingleNode("FilterQuery").Attributes["List"].Value; }
                catch { }
                string strFilterQueryDataColumn = "";
                try { strFilterQueryDataColumn = nd.SelectSingleNode("FilterQuery").Attributes["DataColumn"].Value; }
                catch { }
                string strFilterQueryChildColumn = "";
                try { strFilterQueryChildColumn = nd.SelectSingleNode("FilterQuery").Attributes["ChildColumn"].Value; }
                catch { }

                if (strFilterQuery != "" && strFilterQueryDataColumn != "" && strFilterQueryList != "" && strFilterQueryChildColumn != "")
                {
                    string newQuery = "";
                    SPList list = web.Lists[strFilterQueryList];
                    SPQuery query = new SPQuery();
                    query.Query = "<Where>" + strFilterQuery + "</Where>";
                    foreach (SPListItem li in list.GetItems(query))
                    {
                        if (newQuery == "")
                            newQuery = "<Eq><FieldRef Name='" + strFilterQueryChildColumn + "'/><Value Type='Text'>" + li[strFilterQueryDataColumn].ToString() + "</Value></Eq>";
                        else
                            newQuery = "<Or>" + newQuery + "<Eq><FieldRef Name='" + strFilterQueryChildColumn + "'/><Value Type='Text'>" + li[strFilterQueryDataColumn].ToString() + "</Value></Eq></Or>";
                    }

                    if (newQuery != "")
                    {
                        strQuery = strQuery.Replace("#FilterQuery#", newQuery);
                    }
                }
            }
            catch { }

            return strQuery;
        }

        private void addGroups(SPWeb web)
        {
            SortedList arrGTemp = new SortedList();
            try
            {
                XmlNodeList ndLists = ndCurrentView.SelectNodes("Lists/List");

                foreach (XmlNode nd in ndLists)
                {
                    try
                    {
                        string strList = nd.Attributes["Name"].Value;
                        
                        string strDisplay = "";
                        try{strDisplay = nd.Attributes["Display"].Value;}catch{}
                        
                        string strIcon = "";
                        try{strIcon = nd.Attributes["Icon"].Value;}catch{}

                        string strQuery = "<Where>" + getRealQuery(nd, web) + "</Where>";
                       
                        SPList curList = web.Lists[strList];

                        SPQuery query = new SPQuery();
                        query.Query = strQuery;

                        foreach (SPListItem li in curList.GetItems(query))
                        {
                            string group = null;
                            if (arrGroupFields != null)
                            {
                                foreach (string groupby in arrGroupFields)
                                {

                                    if (groupby == "~Site")
                                    {
                                        if (group == null)
                                            group = web.Title;
                                        else
                                            group += "\n" + web.Title;
                                        if (!arrGTemp.Contains(group))
                                        {
                                            arrGTemp.Add(group, "");
                                        }
                                    }
                                    else if (groupby == "~List")
                                    {
                                        if (group == null)
                                            group = strDisplay;
                                        else
                                            group += "\n" + strDisplay;
                                        if (!arrGTemp.Contains(group))
                                        {
                                            arrGTemp.Add(group, "");
                                        }
                                    }
                                    else
                                    {
                                        //SPField field = curList.Fields.GetFieldByInternalName(groupby);
                                        string newgroup = getField(li, groupby, true);
                                        if (group == null)
                                            group = newgroup;
                                        else
                                            group = group + "\n" + newgroup;

                                        if (!arrGTemp.Contains(group))
                                        {
                                            arrGTemp.Add(group, "");
                                        }

                                    }
                                }
                                if (group == null)
                                    group = "*";
                                arrItems.Add(web.ID + "." + li.ParentList.ID + "." + li.ID, group + "|" + strIcon + "|" + strDisplay + "|" + strList);
                                queueAllItems.Enqueue(li);
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }
            //XmlNode nd = docXml.SelectSingleNode("/Content/Items");

            foreach (DictionaryEntry e in arrGTemp)
            {
                string newItem = e.Key.ToString();
                int parentInd = newItem.LastIndexOf("\n");
                string parent = "";

                if (parentInd > 0)
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

                    //if (e.Key.ToString() != "")
                    //    attrId.Value = e.Key.ToString();
                    //else
                        attrId.Value = Guid.NewGuid().ToString();

                    newNode.Attributes.Append(attrId);
                    XmlAttribute attrLocked = docXml.CreateAttribute("locked");
                    attrLocked.Value = "1";
                    newNode.Attributes.Append(attrLocked);

                    if (arrGroupExpand[e.Key.ToString().Split('\n').Length-1] == "1")
                    {
                        XmlAttribute attrExpand = docXml.CreateAttribute("open");
                        attrExpand.Value = "1";
                        newNode.Attributes.Append(attrExpand);
                    }

                    ndParent.AppendChild(newNode);



                    foreach (XmlNode ndColumn in ndCurrentView.SelectNodes("Column"))
                    {
                        string field = ndColumn.Attributes["Name"].Value;
                        
                        if (field == "Title")
                        {
                            XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            if (newItem == "")
                                newCell.InnerText = "No Value";
                            else
                                newCell.InnerText = newItem;
                            newNode.AppendChild(newCell);
                        }
                        else if (field == "~Icon")
                        {
                            XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newCell.InnerText = "_layouts/images/blank.gif";
                            newNode.AppendChild(newCell);
                        }
                        else if (field == "~Complete")
                        {
                            XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newNode.AppendChild(newCell);
                            XmlAttribute attrCellId = docXml.CreateAttribute("id");
                            attrCellId.Value = field;
                            XmlAttribute atrrType = docXml.CreateAttribute("type");
                            atrrType.Value = "ro";
                            newCell.Attributes.Append(attrCellId);
                            newCell.Attributes.Append(atrrType);

                        }
                        else
                        {
                            XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newNode.AppendChild(newCell);
                            XmlAttribute attrCellId = docXml.CreateAttribute("id");
                            attrCellId.Value = field;
                            newCell.Attributes.Append(attrCellId);
                            XmlAttribute atrrType = docXml.CreateAttribute("type");
                            atrrType.Value = "ro";
                            newCell.Attributes.Append(atrrType);
                        }
                    }

                    XmlAttribute attrBold = docXml.CreateAttribute("style");
                    attrBold.Value = "font-weight:bold;";
                    newNode.Attributes.Append(attrBold);

                    hshItemNodes.Add(e.Key.ToString(), newNode);

                    arrGroupMin.Add(e.Key.ToString(), DateTime.MaxValue);
                    arrGroupMax.Add(e.Key.ToString(), DateTime.MinValue);
                    //setInitialAggs(e.Key.ToString());
                }
            }
            //if (rolluplist != "")
            //{
            try
            {
                foreach (SPWeb w in web.Webs)
                {
                    try
                    {
                        addGroups(w);
                    }
                    catch { }
                    w.Close();
                }
            }
            catch { }
            //}
        }

        private string getField(SPListItem li, string field, bool group)
        {
            string val = "";
            try
            {

                SPField spfield = li.Fields.GetFieldByInternalName(field);
                val = li[spfield.Id].ToString();
                return formatField(val, spfield.InternalName, spfield.Type == SPFieldType.Calculated, group, li);

            }
            catch { }
            return val;
        }

        private string formatField(string val, string fieldname, bool calculated, bool group, SPListItem li)
        {
            SPField spfield = li.ParentList.Fields.GetFieldByInternalName(fieldname);
            string format = "";
            XmlDocument fieldXml = new XmlDocument();
            fieldXml.LoadXml(spfield.SchemaXml);
            if (calculated && !group)
            {
                val = val.Replace(";#", "\n").Split('\n')[1];
            }
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
                        val = li.ParentList.Fields[spfield.Id].GetFieldValueAsHtml(val);
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
                        case "Text":
                            if (spfield.Description == "Indicator")
                            {
                                val = val.ToLower();
                            }
                            else
                            {
                                //val = sdata[1];
                            }
                            break;
                        case "Currency":
                            {
                                double fval = double.Parse(val);
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
                                    double fval = double.Parse(val) * 100;
                                    val = fval.ToString(format) + "%";
                                }
                                catch { }
                            }
                            else
                            {
                                try
                                {
                                    double fval = double.Parse(val);
                                    val = fval.ToString(format);

                                }
                                catch { }
                            }
                            break;
                    };
                    break;
                case SPFieldType.DateTime:
                    try
                    {
                        format = fieldXml.ChildNodes[0].Attributes["Format"].Value;
                    }
                    catch { }
                    if (format == "DateOnly")
                        val = DateTime.Parse(val).ToShortDateString();
                    break;
                default:
                    val = li.ParentList.Fields[spfield.Id].GetFieldValueAsHtml(val);
                    break;
            };
            return val;
        }

        private void addHeader()
        {
            XmlNode ndHead = docXml.CreateNode(XmlNodeType.Element, "head", docXml.NamespaceURI);
            docXml.ChildNodes[0].AppendChild(ndHead);
            XmlNode beforeInitNode = docXml.CreateNode(XmlNodeType.Element, "beforeInit", docXml.NamespaceURI);
            ndHead.AppendChild(beforeInitNode);
            //try
            //{
            //    XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            //    ndNewColumn.InnerText = "Type";

            //    XmlAttribute attrType = docXml.CreateAttribute("type");
            //    attrType.Value = "img";
            //    XmlAttribute attrWidth = docXml.CreateAttribute("width");
            //    attrWidth.Value = "50";
            //    XmlAttribute attrId = docXml.CreateAttribute("id");
            //    attrId.Value = "~Icon";

            //    ndNewColumn.Attributes.Append(attrType);
            //    ndNewColumn.Attributes.Append(attrWidth);
            //    ndNewColumn.Attributes.Append(attrId);
            //    ndHead.AppendChild(ndNewColumn);

            //    arrColumns.Add("~Icon");
            //}
            //catch { }
            int counter = 0;
            foreach (XmlNode ndColumn in ndCurrentView.SelectNodes("Column"))
            {
                string name = "";
                string displayname = "";
                string width = "*";
                string format = "";
                try
                {
                    name =  ndColumn.Attributes["Name"].Value;
                }catch{}
                try
                {
                    format = ndColumn.Attributes["Format"].Value;
                }
                catch { }
                 try
                {
                    displayname = ndColumn.Attributes["Display"].Value;
                }catch{}
                try
                {
                    width = ndColumn.Attributes["Width"].Value;
                }
                catch { }
                XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                ndNewColumn.InnerText = displayname;
                
                XmlAttribute attrType = docXml.CreateAttribute("type");
                XmlAttribute attrWidth = docXml.CreateAttribute("width");
                XmlAttribute attrAlign = docXml.CreateAttribute("align");
                
                attrAlign.Value = "left";
                attrWidth.Value = width;

                if (name == "Title")
                {
                    attrType.Value = "tree";
                }
                else if (name == "~Icon")
                {
                    ndNewColumn.InnerText = "Type";
                    attrWidth.Value = "50";
                    attrAlign.Value = "center";
                    attrType.Value = "img";
                }
                else if (name == "~Complete")
                {
                    ndNewColumn.InnerText = "Complete";
                    attrWidth.Value = "80";
                    attrAlign.Value = "center";
                    attrType.Value = "ch";
                }
                else if (name == "~List")
                {
                    ndNewColumn.InnerText = "List Name";
                    attrWidth.Value = "150";
                    attrAlign.Value = "left";
                    attrType.Value = "ro";
                }
                else if (name == "~Site")
                {
                    ndNewColumn.InnerText = "Site Name";
                    attrWidth.Value = "150";
                    attrAlign.Value = "left";
                    attrType.Value = "ro";
                }
                else
                {
                    if (format == "Percent")
                    {
                        attrType.Value = "edn";
                        attrWidth.Value = "90";
                        attrAlign.Value = "right";
                        XmlNode callNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                        XmlAttribute attr = docXml.CreateAttribute("command");
                        attr.Value = "setNumberFormat";
                        callNode.Attributes.Append(attr);
                        callNode.InnerXml = "<param>000%</param><param>" + counter.ToString() + "</param>";
                        beforeInitNode.AppendChild(callNode);
                    }
                    else if (format == "DateTime" || format=="DateOnly" || format== "Currency")
                    {
                        attrType.Value = "ro";
                        attrWidth.Value = "80";
                        attrAlign.Value = "right";
                    }
                    else if (format == "Indicator")
                    {
                        attrType.Value = "ro";
                        attrWidth.Value = "80";
                        attrAlign.Value = "center";
                    }

                    else if (format == "Number")
                    {
                        attrType.Value = "edn";
                    }
                    else
                        attrType.Value = "ed";
                }
                if(width != "*")
                    attrWidth.Value = width;

                XmlAttribute attrId = docXml.CreateAttribute("id");
                attrId.Value = name;

                if(attrType.Value != "")
                    ndNewColumn.Attributes.Append(attrType);

                ndNewColumn.Attributes.Append(attrWidth);
                ndNewColumn.Attributes.Append(attrId);
                ndNewColumn.Attributes.Append(attrAlign);
                ndHead.AppendChild(ndNewColumn);

                arrColumns.Add(name);
                counter++;
            }
            //try
            //{
            //    if (ndCurrentView.Attributes["ShowCompleteCheck"].Value == "1")
            //    {
            //        XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            //        ndNewColumn.InnerText = "Complete";

            //        XmlAttribute attrType = docXml.CreateAttribute("type");
            //        attrType.Value = "ch";
            //        XmlAttribute attrWidth = docXml.CreateAttribute("width");
            //        attrWidth.Value = "70";
            //        XmlAttribute attrAlign = docXml.CreateAttribute("align");
            //        attrAlign.Value = "center";
            //        XmlAttribute attrId = docXml.CreateAttribute("id");
            //        attrId.Value = "~CompleteCheck";

            //        ndNewColumn.Attributes.Append(attrType);
            //        ndNewColumn.Attributes.Append(attrWidth);
            //        ndNewColumn.Attributes.Append(attrAlign);
            //        ndNewColumn.Attributes.Append(attrId);
            //        ndHead.AppendChild(ndNewColumn);

            //        arrColumns.Add("~CompleteCheck");
            //    }
            //}
            //catch { }
            
        }
    }
}

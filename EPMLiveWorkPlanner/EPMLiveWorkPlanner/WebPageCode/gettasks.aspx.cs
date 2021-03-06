using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Xml;
using Microsoft.SharePoint;
using static System.Diagnostics.Trace;

namespace EPMLiveWorkPlanner
{
    public partial class gettasks : System.Web.UI.Page
    {
        protected string data;

        protected bool useResourcePool;
        //string resourceList = "";
        SortedList slResources = new SortedList();

        SPView view;
        SPWeb web;
        private Hashtable hshComboCells = new Hashtable();

        private ArrayList arrNewTasks = new ArrayList();

        private int taskordercol = -1;

        SPList lstProjectCenter;
        SPList lstTaskCenter;
        string sResourcePoolUrl;
        string sResourceList;
        string wpFields;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            web = SPContext.Current.Web;

            ConfigHelper.GetConfigSettings(
                web,
                ref lstProjectCenter,
                ref lstTaskCenter,
                ref useResourcePool,
                ref sResourcePoolUrl,
                ref sResourceList,
                ref wpFields);

            SPListItem project = lstProjectCenter.GetItemById(int.Parse(Request["ID"].ToString()));

            string autoCalc = "true";

            //try
            //{
            //    autoCalc = project["AutoCalculate"].ToString().ToLower();
            //}
            //catch { }

            view = lstTaskCenter.Views[new Guid(Request["view"].ToString())];

            string sQuery = view.Query;
            if (Request["disablefilters"] == "true")
            {
                sQuery = "<Where><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + Request["ID"] + "</Value></Eq></Where>";
            }
            else
            {
                if (sQuery.Contains("<Where>"))
                {
                    sQuery = sQuery.Replace("<Where>", "<Where><And>");
                    sQuery = sQuery.Replace("</Where>", "<Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + Request["ID"] + "</Value></Eq></And></Where>");
                }
                else
                    sQuery = "<Where><Eq><FieldRef Name='Project'LookupId='TRUE'/><Value Type='Lookup'>" + Request["ID"] + "</Value></Eq></Where>";
            }
            if (sQuery.Contains("<OrderBy>"))
            {
                sQuery = sQuery.Replace("<OrderBy>", "<OrderBy><FieldRef Name='taskorder'/>");
            }
            else
                sQuery += "<OrderBy><FieldRef Name='taskorder'/></OrderBy>";

            SPQuery query = new SPQuery();
            query.Query = sQuery;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<rows></rows>");
            XmlNode nd = doc.ChildNodes[0];

            doc = addHeader(doc);

            string percentageCalc = getPercentCalc(web);

            //{
                
                XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);

                XmlAttribute attr = doc.CreateAttribute("id");
                attr.Value = "_SummaryTask_";
                newNode.Attributes.Append(attr);

                XmlAttribute attrStyle = doc.CreateAttribute("style");
                attrStyle.Value = "font-weight:bold;";
                newNode.Attributes.Append(attrStyle);

                XmlAttribute attrOpen = doc.CreateAttribute("open");
                attrOpen.Value = "1";
                newNode.Attributes.Append(attrOpen);

                XmlAttribute attrLocked = doc.CreateAttribute("locked");
                attrLocked.Value = "1";
                newNode.Attributes.Append(attrLocked);

                newNode.InnerXml += getCellData(project);

                nd.AppendChild(newNode);

                nd = newNode;

                XmlNode summaryNode = newNode;
            //}

            double lastTaskOrder = 1;

            foreach (SPListItem li in lstTaskCenter.GetItems(query))
            {
                string wbs = getWBS(li);
                string taskorder = "0";
                try
                {
                    taskorder = li["taskorder"].ToString();
                    double.TryParse(taskorder, out lastTaskOrder);
                }
                catch { }
                
                int dotLoc = wbs.LastIndexOf(".");
                if (dotLoc > 0)
                {
                    string parentWbs = wbs.Substring(0, dotLoc);
                    string xpathExpr = "//row[wbs='" + parentWbs + "']";
                    XmlNode parent = nd.SelectSingleNode(xpathExpr);
                    string innerXml;
                    CreateNode(doc, li, wbs, taskorder, percentageCalc, out newNode, out innerXml);

                    newNode.InnerXml = innerXml;

                    newNode.InnerXml += getCellData(li);

                    if (parent != null)
                    {
                        parent.AppendChild(newNode);
                        if (parent.Attributes["locked"] == null && autoCalc == "true")
                        {
                            XmlAttribute newattr = doc.CreateAttribute("locked");
                            newattr.Value = "true";
                            //parent.Attributes.Append(newattr);
                        }
                        if (parent.Attributes["style"] == null)
                        {
                            XmlAttribute newattr = doc.CreateAttribute("style");
                            newattr.Value = "font-weight:bold;";
                            parent.Attributes.Append(newattr);
                        }
                        else
                        {
                            parent.Attributes["style"].Value = "font-weight:bold;";
                        }
                        attrOpen = doc.CreateAttribute("open");
                        attrOpen.Value = "1";
                        parent.Attributes.Append(attrOpen);
                    }
                    else
                        nd.AppendChild(newNode);
                }
                else
                {
                    string innerXml;
                    CreateNode(doc, li, wbs, taskorder, percentageCalc, out newNode, out innerXml);

                    newNode.InnerXml += getCellData(li);

                    if (li["taskorder"] == null)
                        arrNewTasks.Add(newNode);
                    else
                        nd.AppendChild(newNode);
                }
            }

            foreach (XmlNode ndNew in arrNewTasks)
            {
                lastTaskOrder++;

                ndNew.SelectSingleNode("//userdata[@name='taskorder']").InnerText = lastTaskOrder.ToString();
                if(taskordercol > 0)
                    ndNew.SelectNodes("//cell")[taskordercol].InnerText = lastTaskOrder.ToString();
                summaryNode.AppendChild(ndNew);
                
            }

            data = doc.OuterXml;
        }

        private void CreateNode(
            XmlDocument xmlDocument,
            SPListItem listItem,
            string wbs,
            string taskOrder,
            string percentageCalc,
            out XmlNode newNode,
            out string innerXml)
        {
            XmlAttribute attribute;
            attribute = xmlDocument.CreateAttribute("id");
            attribute.Value = listItem.ID.ToString();
            newNode = xmlDocument.CreateNode(XmlNodeType.Element, "row", xmlDocument.NamespaceURI);
            newNode.Attributes.Append(attribute);

            innerXml = string.Format(
                "<wbs>{0}</wbs><userdata name=\"wbs\">{0}</userdata><userdata name=\"taskorder\">{1}</userdata><userdata name=\"SharePointId\">{2}</userdata>",
                wbs,
                taskOrder,
                listItem.ID);

            var stringBuilder = new StringBuilder(innerXml);

            try
            {
                if (lstTaskCenter.Fields.GetFieldByInternalName("Predecessors") != null)
                {
                    stringBuilder.Append(string.Format("<userdata name=\"Predecessors\">{0}</userdata>", listItem["Predecessors"]));
                    innerXml = stringBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                TraceError("Exception Suppressed {0}", ex);
            }

            try
            {
                stringBuilder.Append(string.Format("<userdata name=\"{0}\">{1}</userdata>", percentageCalc, listItem[percentageCalc]));
                innerXml = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                TraceError("Exception Suppressed {0}", ex);
            }

            newNode.InnerXml = stringBuilder.ToString();

            if (newNode.SelectSingleNode("userdata[@name='Duration']") == null)
            {
                try
                {
                    stringBuilder.Append(string.Format("<userdata name=\"Duration\">{0}</userdata>", listItem["Duration"]));
                    innerXml = stringBuilder.ToString();
                }
                catch (Exception ex)
                {
                    TraceError("Exception Suppressed {0}", ex);
                }
            }
            if (newNode.SelectSingleNode("userdata[@name='ActualDuration']") == null)
            {
                try
                {
                    stringBuilder.Append(string.Format("<userdata name=\"ActualDuration\">{0}</userdata>", listItem["ActualDuration"]));
                    innerXml = stringBuilder.ToString();
                }
                catch (Exception ex)
                {
                    TraceError("Exception Suppressed {0}", ex);
                }
            }
        }

        private string getPercentCalc(SPWeb web)
        {
            string calc = "";

            if (wpFields != null && wpFields != "")
            {
                string[] sProps = wpFields.Split('\n');
                foreach (string sProp in sProps)
                {
                    string[] sField = sProp.Split('|');
                    if (sField[0] == "PercentComplete")
                        calc = sField[1];
                }

            }
            return calc;
        }

        //private string getLookupList(string list, string field)
        //{
        //    string data = "";
        //    try
        //    {
        //        SPList lookupList = web.Lists[new Guid(list)];

        //        foreach (SPListItem li in lookupList.Items)
        //        {
        //            data = data + "," + li.ID + " - " + li[field].ToString();
        //        }

        //        data = data.Substring(1);
        //    }
        //    catch { }
        //    return data;
        //}

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

        private string getSingleLookup(string list, string field)
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

        private string getSingleUser(string mode)
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
                            if(mode == "PeopleAndGroups")
                                userList.Add(g.Name, g.ID);
                            foreach (SPUser u in g.Users)
                            {
                                if (!userList.Contains(u.Name))
                                    userList.Add(u.Name, u.ID);
                            }
                        }
                    }
                    catch { }
                }
                foreach (SPUser u in web.Users)
                {
                    if (!userList.Contains(u.Name))
                        userList.Add(u.Name, u.ID);
                }
                foreach (DictionaryEntry e in userList)
                {
                    data += "\r\n<option value=\"" + e.Value + "\">" + e.Key + "</option>";
                }
            }
            catch { }
            return data;
        }

        /*private string getMultiUser(string mode)
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
                                    userList.Add(u.Name, u.ID);
                            }
                        }
                    }
                    catch { }
                }
                foreach (SPUser u in web.Users)
                {
                    if (!userList.Contains(u.Name))
                        userList.Add(u.Name, u.ID);
                }
                foreach (DictionaryEntry e in userList)
                {
                    data += "," + e.Value + " - " + e.Key.ToString().Replace(",",";");
                }
                if (data.Length > 0)
                    data = data.Substring(1);
            }
            catch { }
            return data;
        }*/

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

        private XmlDocument addHeader(XmlDocument doc)
        {
            XmlNode mainNode = doc.ChildNodes[0];
            XmlNode headNode = doc.CreateNode(XmlNodeType.Element, "head", doc.NamespaceURI);
            mainNode.AppendChild(headNode);
            XmlNode beforeInitNode = doc.CreateNode(XmlNodeType.Element, "afterInit", doc.NamespaceURI);
            headNode.AppendChild(beforeInitNode);

            SPViewFieldCollection vfc = view.ViewFields;

            System.Globalization.CultureInfo cInfo = new System.Globalization.CultureInfo(web.Locale.LCID);


            int counter = 1;

            {
                XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                newNode.InnerText = "&nbsp;";
                XmlAttribute attrWidth = doc.CreateAttribute("width");
                attrWidth.InnerText = "25";
                XmlAttribute attrType = doc.CreateAttribute("type");
                attrType.InnerText = "ro";
                XmlAttribute attrId = doc.CreateAttribute("_Status_");
                attrId.InnerText = "id";
                XmlAttribute attrSort = doc.CreateAttribute("sort");
                attrSort.InnerText = "na";
                newNode.Attributes.Append(attrSort);
                newNode.Attributes.Append(attrId);
                newNode.Attributes.Append(attrWidth);
                newNode.Attributes.Append(attrType);
                headNode.AppendChild(newNode);
            }
            foreach (string f in vfc)
            {
                SPField field = getRealField(lstTaskCenter.Fields.GetFieldByInternalName(f));
                XmlDocument fieldXml = new XmlDocument();
                fieldXml.LoadXml(field.SchemaXml);

                XmlAttribute attrAlign = doc.CreateAttribute("align");
                XmlAttribute attrType = doc.CreateAttribute("type");
                XmlAttribute attrWidth = doc.CreateAttribute("width");
                XmlAttribute attrSort = doc.CreateAttribute("sort");
                XmlAttribute attrID = doc.CreateAttribute("id");

                string innerXml = "";
                attrID.Value = field.InternalName;
                if (field.InternalName == "taskorder")
                {
                    taskordercol = counter;
                    attrType.Value = "ro";
                    attrWidth.Value = "50";
                    attrSort.Value = "";
                    attrAlign.Value = "left";
                }
                else if (field.InternalName == "_ModerationStatus")
                {
                    attrType.Value = "ro";
                    attrWidth.Value = "100";
                    attrSort.Value = "str";
                    attrAlign.Value = "left";
                }
                else if (field.InternalName == "WBS")
                {
                    attrType.Value = "ro";
                    attrWidth.Value = "50";
                    attrSort.Value = "na";
                    attrAlign.Value = "left";
                }
                else if (field.InternalName == "OutlineNumber")
                {
                    attrType.Value = "ro";
                    attrWidth.Value = "80";
                    attrSort.Value = "na";
                    attrAlign.Value = "right";
                }
                else if (field.InternalName == "Predecessors")
                {
                    attrType.Value = "ro";
                    attrWidth.Value = "100";
                    attrSort.Value = "na";
                    attrAlign.Value = "left";
                }
                else if (field.InternalName == "TimesheetHours")
                {
                    attrType.Value = "ro";
                    attrWidth.Value = "120";
                    attrSort.Value = "na";
                    attrAlign.Value = "right";
                }
                else if (field.InternalName == "LinkTitle" || field.InternalName == "Title")
                {
                    attrType.Value = "tree";
                    attrWidth.Value = "200";
                    attrSort.Value = "str";
                    attrAlign.Value = "left";
                }
                else if (field.ReadOnlyField == true)
                {
                    attrType.Value = "ro";
                    attrWidth.Value = "100";
                    attrSort.Value = "";
                    if (field.Type == SPFieldType.Calculated && field.Description == "Indicator")
                        attrAlign.Value = "center";
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
                            case "Currency":
                            case "Number":
                                attrAlign.Value = "right";
                                break;
                            default:
                                attrAlign.Value = "left";
                                break;
                        };
                    }
                }
                else if (!useResourcePool && field.InternalName == "ResourceNames")
                {
                    attrType.Value = "ro";
                    attrWidth.Value = "100";
                    attrSort.Value = "";
                }
                else if (useResourcePool && (field.InternalName == "ResourceNames" || field.InternalName == "AssignedTo") && sResourcePoolUrl != "")
                {

                    attrType.Value = "mchoice";
                    attrWidth.Value = "200";
                    attrSort.Value = "str";
                    attrAlign.Value = "left";

                    string resourceList = "";

                    using (SPSite oSiteCollection = new SPSite(sResourcePoolUrl))
                    {
                        using (SPWeb oWebsite = oSiteCollection.OpenWeb())
                        {
                            try
                            {
                                SortedList userList = new SortedList();
                                SPList resList = oWebsite.Lists[sResourceList];
                                foreach (SPListItem li in resList.Items)
                                {
                                    if (!userList.Contains(li.Title))
                                    {
                                        if (!li.Title.Contains(","))
                                        {
                                            userList.Add(li.Title, li.ID);
                                            if (!slResources.Contains(li.Title))
                                                slResources.Add(li.Title, li.ID);
                                        }
                                        //resourceList += "," + li.Title.Replace(",",";");
                                    }
                                }
                                foreach (DictionaryEntry e in userList)
                                {
                                    resourceList += "\n" + e.Value + ";#" + e.Key.ToString();
                                }

                                resourceList = resourceList.Substring(1);
                            }
                            catch { }

                        }
                    }

                    if (resourceList == "")
                    {
                        attrType.Value = "ro";
                    }
                    else
                    {
                        XmlNode callNode = doc.CreateNode(XmlNodeType.Element, "call", doc.NamespaceURI);
                        XmlAttribute attr = doc.CreateAttribute("command");
                        attr.Value = "registerLookup";
                        callNode.Attributes.Append(attr);
                        callNode.InnerXml = "<param>" + counter.ToString() + "</param><param><![CDATA[" + resourceList + "]]></param>";
                        beforeInitNode.AppendChild(callNode);
                    }
                }
                else
                {
                    switch (field.Type)
                    {
                        case SPFieldType.Lookup:

                            attrWidth.Value = "200";
                            attrSort.Value = "str";
                            attrAlign.Value = "left";

                            string lookuplist = "";
                            string lookupfield = "";
                            {

                                lookuplist = fieldXml.ChildNodes[0].Attributes["List"].Value;
                                lookupfield = fieldXml.ChildNodes[0].Attributes["ShowField"].Value;

                                if (field.TypeAsString == "LookupMulti")
                                {
                                    attrType.Value = "mchoice";

                                }
                                else
                                {
                                    innerXml = field.Title + getSingleLookup(lookuplist, lookupfield);
                                    attrType.Value = "co";
                                }

                                if (field.SchemaXml.Contains("Mult=\"TRUE\""))
                                {
                                    //    attrType.Value = "clist";
                                    //    try
                                    //    {

                                    //    }
                                    //    catch { }
                                    XmlNode callNode = doc.CreateNode(XmlNodeType.Element, "call", doc.NamespaceURI);
                                    XmlAttribute attr = doc.CreateAttribute("command");
                                    attr.Value = "registerLookup";
                                    callNode.Attributes.Append(attr);
                                    callNode.InnerXml = "<param>" + counter.ToString() + "</param><param><![CDATA[" + getLookupList(web, lookuplist, lookupfield) + "]]></param>";
                                    beforeInitNode.AppendChild(callNode);
                                }
                                //else
                                //{
                                //    innerXml = field.Title + getSingleLookup(lookuplist, lookupfield);
                                //    attrType.Value = "co";
                                //}
                            }
                            break;
                        case SPFieldType.MultiChoice:
                            attrType.Value = "mchoice";
                            attrWidth.Value = "200";
                            attrSort.Value = "str";
                            attrAlign.Value = "left";

                            //string inner = "";
                            //try
                            //{
                            //    foreach (XmlNode nd in fieldXml.ChildNodes[0].ChildNodes)
                            //    {
                            //        if (nd.Name == "CHOICES")
                            //        {
                            //            foreach (XmlNode choice in nd.ChildNodes)
                            //            {
                            //                inner = inner + "," + choice.InnerText;
                            //            }
                            //        }
                            //    }
                            //    inner = inner.Substring(1);
                            //}
                            //catch { }
                            {
                                string strChoices = "";
                                if (hshComboCells.Contains(field.InternalName))
                                {
                                    strChoices += hshComboCells[field.InternalName].ToString();
                                }
                                else
                                {
                                    string inputs = "";
                                    foreach (XmlNode nd in fieldXml.SelectNodes("//CHOICE"))
                                    {
                                        inputs += "\n" + nd.InnerText + ";#" + nd.InnerText;
                                    }
                                    if (inputs.Length > 1)
                                        inputs = inputs.Substring(1);
                                    strChoices += inputs;
                                    hshComboCells[field.InternalName] = inputs;
                                }

                                XmlNode callNode = doc.CreateNode(XmlNodeType.Element, "call", doc.NamespaceURI);
                                XmlAttribute attr = doc.CreateAttribute("command");
                                attr.Value = "registerLookup";
                                callNode.Attributes.Append(attr);
                                callNode.InnerXml = "<param>" + counter.ToString() + "</param><param><![CDATA[" + strChoices + "]]></param>";
                                beforeInitNode.AppendChild(callNode);
                            }
                            break;
                        case SPFieldType.Choice:
                            attrType.Value = "co";
                            attrWidth.Value = "200";
                            attrSort.Value = "str";
                            attrAlign.Value = "left";

                            innerXml = field.Title;
                            try
                            {
                                foreach (XmlNode nd in fieldXml.ChildNodes[0].ChildNodes)
                                {
                                    if (nd.Name == "CHOICES")
                                    {
                                        foreach (XmlNode choice in nd.ChildNodes)
                                        {
                                            innerXml = innerXml + "\r\n<option value=\"" + HttpUtility.HtmlEncode(choice.InnerText) + "\">" + HttpUtility.HtmlEncode(choice.InnerText) + "</option>";

                                        }
                                    }
                                }
                            }
                            catch { }
                            break;
                        case SPFieldType.User:
                            string mode = "";
                            XmlDocument fDoc = new XmlDocument();
                            fDoc.LoadXml(field.SchemaXml);

                            try
                            {
                                mode = fDoc.FirstChild.Attributes["UserSelectionMode"].Value;
                            }
                            catch { }

                            if (field.TypeAsString == "UserMulti")
                            {
                                //XmlNode callNode = doc.CreateNode(XmlNodeType.Element, "call", doc.NamespaceURI);
                                //XmlAttribute attr = doc.CreateAttribute("command");
                                //attr.Value = "registerCList";
                                //callNode.Attributes.Append(attr);
                                //string multiuser = getMultiUser(mode);
                                //if (multiuser != "")
                                //{
                                //    callNode.InnerXml = "<param>" + counter.ToString() + "</param><param>" + multiuser + "</param>";
                                //    beforeInitNode.AppendChild(callNode);
                                //}
                                //attrType.Value = "clist";
                                //innerXml = field.Title  + "<t>asdf</t>";


                                attrType.Value = "usereditorm";
                            }
                            else
                            {
                                //innerXml = field.Title + getSingleUser(mode);
                                attrType.Value = "usereditor";
                            }
                            {
                                XmlNode callNode = doc.CreateNode(XmlNodeType.Element, "call", doc.NamespaceURI);
                                XmlAttribute attr = doc.CreateAttribute("command");
                                attr.Value = "registerLookup";
                                callNode.Attributes.Append(attr);
                                callNode.InnerXml = "<param>" + counter.ToString() + "</param><param><![CDATA[" + getMultiUser(mode, web) + "]]></param>";
                                beforeInitNode.AppendChild(callNode);
                            }


                            attrWidth.Value = "200";
                            attrSort.Value = "str";
                            attrAlign.Value = "left";
                            break;
                        case SPFieldType.DateTime:
                            attrType.Value = "dhxCalendarA";
                            attrWidth.Value = "100";
                            attrSort.Value = "date";
                            attrAlign.Value = "right";
                            break;
                        case SPFieldType.Boolean:
                            attrType.Value = "ch";
                            attrWidth.Value = "50";
                            attrSort.Value = "na";
                            attrAlign.Value = "center";
                            break;
                        case SPFieldType.Currency:
                            attrType.Value = "edn";
                            attrWidth.Value = "80";
                            attrSort.Value = "int";
                            attrAlign.Value = "right";
                            {
                                
                                XmlNode callNode = doc.CreateNode(XmlNodeType.Element, "call", doc.NamespaceURI);
                                XmlAttribute attr = doc.CreateAttribute("command");
                                attr.Value = "setNumberFormat";
                                callNode.Attributes.Append(attr);
                                callNode.InnerXml = "<param>" + cInfo.NumberFormat.CurrencySymbol + "0,000.00</param><param>" + counter.ToString() + "</param><param>" + cInfo.NumberFormat.CurrencyDecimalSeparator + "</param><param>" + cInfo.NumberFormat.CurrencyGroupSeparator + "</param>";
                                beforeInitNode.AppendChild(callNode);
                            }
                            break;
                        case SPFieldType.Number:
                            if (field.SchemaXml.Contains("Percentage=\"TRUE\""))
                            {
                                attrType.Value = "edn";
                                attrWidth.Value = "100";
                                attrSort.Value = "int";
                                attrAlign.Value = "right";

                                string decimals = "";
                                int decCount = 0;
                                XmlDocument dec = new XmlDocument();
                                dec.LoadXml(field.SchemaXml);

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

                                XmlNode callNode = doc.CreateNode(XmlNodeType.Element, "call", doc.NamespaceURI);
                                XmlAttribute attr = doc.CreateAttribute("command");
                                attr.Value = "setNumberFormat";
                                callNode.Attributes.Append(attr);
                                callNode.InnerXml = "<param>000" + decimals + "%</param><param>" + counter.ToString() + "</param><param>" + cInfo.NumberFormat.CurrencyDecimalSeparator + "</param><param>" + cInfo.NumberFormat.CurrencyGroupSeparator + "</param>";
                                beforeInitNode.AppendChild(callNode);
                            }
                            else
                            {
                                string decimals = "";
                                int decCount = 0;
                                XmlDocument dec = new XmlDocument();
                                dec.LoadXml(field.SchemaXml);

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

                                XmlNode callNode = doc.CreateNode(XmlNodeType.Element, "call", doc.NamespaceURI);
                                XmlAttribute attr = doc.CreateAttribute("command");
                                attr.Value = "setNumberFormat";
                                callNode.Attributes.Append(attr);
                                callNode.InnerXml = "<param>0,000" + decimals + "</param><param>" + counter.ToString() + "</param><param>" + cInfo.NumberFormat.CurrencyDecimalSeparator + "</param><param>" + cInfo.NumberFormat.CurrencyGroupSeparator + "</param>";
                                beforeInitNode.AppendChild(callNode);

                                attrType.Value = "edn";
                                attrWidth.Value = "100";
                                attrSort.Value = "int";
                                attrAlign.Value = "right";
                            }
                            break;
                        case SPFieldType.Calculated:
                            if (field.Description == "Indicator")
                            {
                                attrWidth.Value = "50";
                                attrSort.Value = "str";
                                attrAlign.Value = "center";
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
                                    case "Text":
                                        attrAlign.Value = "left";
                                        break;
                                    case "Currency":
                                    case "Number":
                                        attrAlign.Value = "right";
                                        break;
                                };

                                attrWidth.Value = "100";
                                attrSort.Value = "na";


                                //string decimals = "";
                                //int decCount = 0;
                                //XmlDocument dec = new XmlDocument();
                                //dec.LoadXml(field.SchemaXml);

                                //try
                                //{
                                //    decCount = int.Parse(dec.FirstChild.Attributes["Decimals"].Value);
                                //}
                                //catch { }

                                //for (int i = 0; i < decCount; i++)
                                //{
                                //    decimals += "0";
                                //}

                                //if (decCount > 0)
                                //    decimals = "." + decimals;
                            }
                            attrType.Value = "ro";
                            break;
                        case SPFieldType.Note:
                            attrType.Value = "txt";
                            attrWidth.Value = "250";
                            attrSort.Value = "na";
                            attrAlign.Value = "left";
                            break;
                        default:
                            attrType.Value = "ed";
                            attrWidth.Value = "150";
                            attrSort.Value = "na";
                            attrAlign.Value = "left";
                            break;
                    }

                }

                attrSort.Value = "na";
                XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "column", doc.NamespaceURI);
                newNode.Attributes.Append(attrAlign);
                newNode.Attributes.Append(attrType);
                newNode.Attributes.Append(attrWidth);
                newNode.Attributes.Append(attrSort);
                newNode.Attributes.Append(attrID);

                if (innerXml != "")
                {
                    newNode.InnerXml = innerXml;
                }
                else
                {
                    newNode.InnerText = field.Title;
                }

                headNode.AppendChild(newNode);
                counter++;
            }
            return doc;

        }

        private string getCellData(SPListItem li)
        {
            StringBuilder sb = new StringBuilder();
            SPViewFieldCollection vfc = view.ViewFields;

            System.Globalization.NumberFormatInfo nf = new System.Globalization.NumberFormatInfo();
            nf.NumberDecimalSeparator = ".";
            nf.NumberGroupSeparator = ",";

            sb.Append("<cell/>");
            foreach (string f in vfc)
            {
                try
                {
                    string strF = f;
                    if (li.ParentList.ID == lstProjectCenter.ID)
                    {
                        if (f == "StartDate")
                            strF = "Start";
                        if (f == "DueDate")
                            strF = "Finish";
                    }
                    SPField field = li.ParentList.Fields.GetFieldByInternalName(strF);
                    XmlDocument fieldXml = new XmlDocument();
                    fieldXml.LoadXml(field.SchemaXml);
                    string data = "";
                    try
                    {
                        data = li[field.Id].ToString();
                    }
                    catch { }
                    if (field.InternalName == "_ModerationStatus")
                    {
                        switch (li[field.Id].ToString())
                        {
                            case "0":
                                sb.Append("<cell>Approved</cell>");
                                break;
                            case "1":
                                sb.Append("<cell>Rejected</cell>");
                                break;
                            case "2":
                                sb.Append("<cell>Pending</cell>");
                                break;
                        };

                    }
                    else if (useResourcePool && field.InternalName == "ResourceNames" || field.InternalName == "AssignedTo")
                    {
                        try
                        {
                            data = li["ResourceNames"].ToString();
                        }
                        catch { }
                        string[] strResources = data.Split(',');
                        string strFinalResources = "";
                        foreach (string strResource in strResources)
                        {
                            if (slResources.Contains(strResource.Trim()))
                                strFinalResources += "\n" + slResources[strResource.Trim()].ToString() + ";#" + strResource.Trim();
                        }
                        if (strFinalResources.Length > 1)
                            strFinalResources = strFinalResources.Substring(1);
                        sb.Append("<cell><![CDATA[" + strFinalResources + "]]></cell>");
                    }
                    else if (field.InternalName != "LinkTitle" && field.InternalName != "Title")
                    {
                        updatetask.ProcessFieldType(useResourcePool, li, field, data, sb, nf, f, web.Url);
                    }
                    else
                    {
                        sb.Append("<cell image=\"blank.gif\"><![CDATA[" + li.Title + "]]></cell>");
                    }
                }
                catch { sb.Append("<cell/>"); }
            }
            return sb.ToString();
        }

        private string getWBS(SPListItem li)
        {
            try
            {
                return li["WBS"].ToString();
            }
            catch { }
            return "";
        }
    }
}
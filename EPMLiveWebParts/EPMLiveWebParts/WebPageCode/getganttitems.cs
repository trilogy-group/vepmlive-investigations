using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;
using System.Collections;
using System.Text.RegularExpressions;
using System.Globalization;

namespace EPMLiveWebParts
{
    public partial class getganttitems : getgriditems
    {
        private ArrayList arrHidden = new ArrayList();

        private Hashtable hshLookupEnums = new Hashtable();
        private Hashtable hshLookupEnumKeys = new Hashtable();

        private int curId = 0;


        public override void getParams(SPWeb curWeb)
        {
            tb.AddTimer();
            base.getParams(curWeb);
            ArrayList arrFields = new ArrayList();

            foreach (string field in aViewFields)
            {
                arrFields.Add(field);
            }

            if (!arrFields.Contains(StartDateField) && StartDateField != "")
            {
                arrHidden.Add(StartDateField);
                view.ViewFields.Add(StartDateField);
            }
            if (!arrFields.Contains(DueDateField) && DueDateField != "")
            {
                arrHidden.Add(DueDateField);
                view.ViewFields.Add(DueDateField);
            }
            if (!arrFields.Contains(ProgressField) && ProgressField != "")
            {
                arrHidden.Add(ProgressField);
                view.ViewFields.Add(ProgressField);
            }
            if (!arrFields.Contains("Duration"))
            {
                try
                {
                    arrHidden.Add("Duration");
                    view.ViewFields.Add("Duration");
                }
                catch { }
            }
            if (!arrFields.Contains("Predecessors"))
            {
                try
                {
                    arrHidden.Add("Predecessors");
                    view.ViewFields.Add("Predecessors");
                }
                catch { }
            }
            if (!arrFields.Contains("Project"))
            {
                try
                {
                    arrHidden.Add("Project");
                    view.ViewFields.Add("Project");
                }
                catch { }
            }
            if (!arrFields.Contains("taskorder"))
            {
                try
                {
                    arrHidden.Add("taskorder");
                    view.ViewFields.Add("taskorder");
                }
                catch { }
            }
            if (!arrFields.Contains("Descendants"))
            {
                try
                {
                    arrHidden.Add("Descendants");
                    view.ViewFields.Add("Descendants");
                }
                catch { }
            }

            //inEditMode = true;
            bCleanValues = true;
            tb.StopTimer();
        }

        protected override void outputXml()
        {
            tb.AddTimer();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.txtGanttLayout.Replace("#gridid#", base.gridname));

            XmlNode ndHeader = doc.FirstChild.SelectSingleNode("//Header");
            XmlNode ndCols = doc.FirstChild.SelectSingleNode("//LeftCols");

            //XmlNode ndLeftCols = doc.FirstChild.SelectSingleNode("//LeftCols");

            if (showCheckboxes)
            {
                doc.FirstChild.SelectSingleNode("//Panel").Attributes["Visible"].Value = "1";
            }

            ArrayList arrFields = new ArrayList();

            string sTitleField = "Title";

            foreach (string field in aViewFields)
            {
                try
                {

                    SPField oField = getRealField(list.Fields.GetFieldByInternalName(field));

                    if (oField.InternalName == "Title")
                        sTitleField = field;

                    arrFields.Add(oField.InternalName);

                    XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "C", doc.NamespaceURI);
                    XmlAttribute attr = doc.CreateAttribute("Name");
                    attr.Value = oField.InternalName;

                    if (attr.Value == "State")
                        attr.Value = "FState";

                    ndNew.Attributes.Append(attr);

                    attr = doc.CreateAttribute("CaseSensitive");
                    attr.Value = "0";
                    ndNew.Attributes.Append(attr);

                    XmlDocument oDoc = new XmlDocument();
                    oDoc.LoadXml(oField.SchemaXml);

                    string sFormat = getFormat(oField, oDoc, SPContext.Current.Web);
                    string sType = "Html";

                    string sTitle = oField.Title;
                    string sTitleAlign = "Left";

                    if (sFormat != "")
                    {
                        attr = doc.CreateAttribute("Format");
                        attr.Value = sFormat;
                        ndNew.Attributes.Append(attr);
                    }

                    if (oField.InternalName == "Edit")
                    {
                        attr = doc.CreateAttribute("Width");
                        attr.Value = "50";
                        ndNew.Attributes.Append(attr);
                    }
                    else if (oField.InternalName == "Title")
                    {
                        attr = doc.CreateAttribute("MinWidth");
                        attr.Value = "300";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("Button");
                        attr.Value = "Html";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("RelWidth");
                        attr.Value = "1";
                        ndNew.Attributes.Append(attr);
                    }
                    else if (oField.InternalName == "WorkspaceUrl")
                    {
                        attr = doc.CreateAttribute("Width");
                        attr.Value = "60";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("Align");
                        attr.Value = "Center";
                        sTitleAlign = "Center";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("WorkspaceUrl");
                        attr.Value = "h";
                        ndHeader.Attributes.Append(attr);

                        sTitle = "";
                    }
                    else
                    {

                        string sWidth = "150";

                        switch (oField.Type)
                        {
                            case SPFieldType.Text:
                                sWidth = "150";
                                break;
                            case SPFieldType.Number:
                                attr = doc.CreateAttribute("Align");
                                attr.Value = "Right";
                                sTitleAlign = "Right";
                                ndNew.Attributes.Append(attr);
                                sType = "Float";
                                break;
                            case SPFieldType.Currency:
                                attr = doc.CreateAttribute("Align");
                                attr.Value = "Right";
                                sTitleAlign = "Right";
                                ndNew.Attributes.Append(attr);
                                sType = "Float";
                                break;
                            case SPFieldType.DateTime:
                                attr = doc.CreateAttribute("Align");
                                attr.Value = "Left";
                                ndNew.Attributes.Append(attr);
                                sType = "Date";
                                break;
                            case SPFieldType.Boolean:
                                sType = "Bool";
                                break;
                            case SPFieldType.Calculated:
                                SPFieldCalculated oFC = (SPFieldCalculated)oField;
                                if (oFC.OutputType == SPFieldType.Number || oFC.OutputType == SPFieldType.Currency || oFC.OutputType == SPFieldType.DateTime)
                                {
                                    attr = doc.CreateAttribute("Align");
                                    attr.Value = "Right";
                                    sTitleAlign = "Right";
                                    ndNew.Attributes.Append(attr);
                                    sType = "Float";
                                }
                                else if (oFC.Description == "Indicator")
                                {
                                    attr = doc.CreateAttribute("Align");
                                    attr.Value = "Center";
                                    sTitleAlign = "Center";
                                    ndNew.Attributes.Append(attr);
                                    sWidth = "80";
                                }
                                break;
                            case SPFieldType.Choice:
                                //sType = "Enum";
                                {
                                    //Reference: http://longboo.com/demo/ejs-treegrid/Doc/TypeEnum.htm
                                    string senum = "";
                                    string senumrange = "";

                                    SPFieldChoice oCField = (SPFieldChoice)oField;

                                    //Used to prepare dropdown with field choice options
                                    foreach (string sChoice in oCField.Choices)
                                        senum += ";" + sChoice.Replace(";", "");

                                    //Used to prepare count for an item
                                    //for (int i = 0; i < oCField.Choices.Count; i++)
                                    //    senumrange += ";" + i.ToString();
                                    senumrange = senum;
                                    attr = doc.CreateAttribute("Enum");
                                    attr.Value = senum;
                                    ndNew.Attributes.Append(attr);

                                    attr = doc.CreateAttribute("Value");
                                    attr.Value = senumrange;
                                    ndNew.Attributes.Append(attr);
                                }
                                sWidth = "150";
                                break;
                            case SPFieldType.Lookup:
                                sWidth = "150";

                                sType = "Enum";

                                attr = doc.CreateAttribute("Enum");
                                attr.Value = "";
                                ndNew.Attributes.Append(attr);

                                attr = doc.CreateAttribute("EnumKeys");
                                attr.Value = "";
                                ndNew.Attributes.Append(attr);

                                //attr = doc.CreateAttribute("Range");
                                //attr.Value = "1";
                                //ndNew.Attributes.Append(attr);

                                hshLookupEnums.Add(oField.InternalName, new ArrayList());
                                hshLookupEnumKeys.Add(oField.InternalName, new ArrayList());

                                break;
                            case SPFieldType.MultiChoice:
                                {
                                    string senum = "";

                                    SPFieldMultiChoice oCField = (SPFieldMultiChoice)oField;
                                    foreach (string sChoice in oCField.Choices)
                                        senum += ";" + sChoice.Replace(";", "");

                                    attr = doc.CreateAttribute("Enum");
                                    attr.Value = senum;
                                    ndNew.Attributes.Append(attr);

                                    attr = doc.CreateAttribute("Range");
                                    attr.Value = "1";
                                    ndNew.Attributes.Append(attr);
                                }
                                sType = "Enum";
                                sWidth = "150";
                                break;
                            case SPFieldType.Note:
                                sWidth = "200";
                                break;
                            case SPFieldType.URL:
                                sWidth = "150";
                                break;
                            case SPFieldType.User:
                                sWidth = "150";
                                attr = doc.CreateAttribute("CaseSensitive");
                                attr.Value = "0";
                                ndNew.Attributes.Append(attr);
                                break;
                            default:
                                switch (oField.TypeAsString)
                                {
                                    case "TotalRollup":
                                        attr = doc.CreateAttribute("Align");
                                        attr.Value = "Right";
                                        sTitleAlign = "Right";
                                        ndNew.Attributes.Append(attr);
                                        break;
                                }
                                break;
                        }

                        attr = doc.CreateAttribute("MinWidth");
                        attr.Value = sWidth;
                        ndNew.Attributes.Append(attr);
                    }

                    attr = doc.CreateAttribute("Wrap");
                    attr.Value = "0";
                    ndNew.Attributes.Append(attr);

                    attr = doc.CreateAttribute("Type");
                    attr.Value = sType;
                    ndNew.Attributes.Append(attr);

                    ndCols.AppendChild(ndNew);

                    if (oField.InternalName == "Title")
                    {
                        ndCols = doc.FirstChild.SelectSingleNode("//Cols");
                    }

                    string iFieldName = oField.InternalName;
                    if (iFieldName == "State")
                        iFieldName = "FState";

                    attr = doc.CreateAttribute(iFieldName);
                    attr.Value = sTitle;
                    ndHeader.Attributes.Append(attr);

                    attr = doc.CreateAttribute(oField.InternalName + "Align");
                    attr.Value = sTitleAlign;
                    ndHeader.Attributes.Append(attr);

                    if (arrHidden.Contains(oField.InternalName))
                    {
                        attr = doc.CreateAttribute("Visible");
                        attr.Value = "0";
                        ndNew.Attributes.Append(attr);
                    }
                }
                catch { }

            }



            XmlNode ndGantt = doc.FirstChild.SelectSingleNode("//RightCols/C[@Name='G']");
            ndGantt.Attributes["GanttStart"].Value = StartDateField;
            ndGantt.Attributes["GanttEnd"].Value = DueDateField;
            ndGantt.Attributes["GanttComplete"].Value = ProgressField;
            ndGantt.Attributes["GanttText"].Value = InfoField;

            if (bShowGantt)
                ndGantt.Attributes["Visible"].Value = "1";

            XmlNodeList ndRows = docXml.FirstChild.SelectNodes("row");
            XmlNode ndParent = doc.FirstChild.SelectSingleNode("//B");

            XmlNodeList ndOldCols = docXml.FirstChild.SelectNodes("//head/column");
            XmlNode ndSummary = doc.FirstChild.SelectSingleNode("//Def/D[@Name='Summary']");

            if (StartDateField != "")
            {
                XmlAttribute attr = doc.CreateAttribute(StartDateField + "Formula");
                attr.Value = "ganttstart()";
                ndSummary.Attributes.Append(attr);
            }

            if (DueDateField != "")
            {
                XmlAttribute attr = doc.CreateAttribute(DueDateField + "Formula");
                attr.Value = "ganttend()";
                ndSummary.Attributes.Append(attr);
            }

            if (ProgressField != "")
            {
                XmlAttribute attr = doc.CreateAttribute(ProgressField + "Formula");
                attr.Value = "ganttpercent()";
                ndSummary.Attributes.Append(attr);
            }
            //PercentCompleteFormula="ganttpercent('StartDate','DueDate','d')" 

            foreach (XmlNode ndRow in ndRows)
                ProcessItems(ndParent, ndRow, ndOldCols, doc);

            foreach (XmlNode ndRow in doc.FirstChild.SelectNodes("//I[@Predecessors!='']"))
            {
                processPredecessors(ndRow, doc);
            }


            foreach (DictionaryEntry de in hshLookupEnums)
            {
                XmlNode nd = doc.FirstChild.SelectSingleNode("//C[@Name='" + de.Key.ToString() + "']");
                if (nd != null)
                {
                    nd.Attributes["EnumKeys"].Value = ";" + string.Join(";", (int[])((ArrayList)de.Value).ToArray(Type.GetType("System.Int32")));
                }
            }

            foreach (DictionaryEntry de in hshLookupEnumKeys)
            {
                XmlNode nd = doc.FirstChild.SelectSingleNode("//C[@Name='" + de.Key.ToString() + "']");
                if (nd != null)
                {
                    nd.Attributes["Enum"].Value = ";" + string.Join(";", (string[])((ArrayList)de.Value).ToArray(Type.GetType("System.String")));
                }
            }


            XmlNode ndPag = docXml.SelectSingleNode("//call[@command='setuppaging']");

            XmlNode ndCfg = doc.SelectSingleNode("//Cfg");

            if (ndPag != null)
            {


                XmlAttribute attr = doc.CreateAttribute("PagInfo");
                attr.Value = ndPag.InnerText;
                ndSummary.Attributes.Append(attr);

                ndCfg.Attributes.Append(attr);

                attr = doc.CreateAttribute("PagSize");
                attr.Value = view.RowLimit.ToString();
                ndSummary.Attributes.Append(attr);

                ndCfg.Attributes.Append(attr);
            }

            XmlAttribute attrT = doc.CreateAttribute("LinkTitleField");
            attrT.Value = sTitleField;
            ndCfg.Attributes.Append(attrT);

            tb.StopTimers();

            if (epmdebug != null && epmdebug == "true")
            {
                XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "I", doc.NamespaceURI);

                XmlAttribute attr = doc.CreateAttribute("Title");
                attr.Value = tb.GetHtml();
                ndNew.Attributes.Append(attr);

                doc.FirstChild.SelectSingleNode("//B").AppendChild(ndNew);
            }

            if (list.BaseType == SPBaseType.DocumentLibrary)
            {
                XmlAttribute attr = doc.CreateAttribute("NameCol");
                attr.Value = "FileLeafRef";
                ndCfg.Attributes.Append(attr);
                attr = doc.CreateAttribute("MainCol");
                attr.Value = "FileLeafRef";
                ndCfg.Attributes.Append(attr);
            }
            else
            {
                XmlAttribute attr = doc.CreateAttribute("NameCol");
                attr.Value = "Title";
                ndCfg.Attributes.Append(attr);
                attr = doc.CreateAttribute("MainCol");
                attr.Value = "Title";
                ndCfg.Attributes.Append(attr);
            }

            data = doc.OuterXml;
        }

        private string getAttribute(XmlNode nd, string attribute)
        {
            try
            {
                if (nd.Attributes[attribute] != null)
                    return nd.Attributes[attribute].Value;
            }
            catch { }
            return "";
        }

        private void processPredecessor(XmlDocument doc, string pred, string project, string rowid, string suffix)
        {
            XmlNode nd = doc.FirstChild.SelectSingleNode("//I[@taskorder='" + pred + "' and @Project='" + project + "']");

            if (nd != null)
            {
                if (nd.Attributes["Descendants"] == null)
                {
                    XmlAttribute attr = doc.CreateAttribute("Descendants");
                    attr.Value = rowid + suffix;
                    nd.Attributes.Append(attr);
                }
                else
                {
                    nd.Attributes["Descendants"].Value = (nd.Attributes["Descendants"].Value + "," + rowid + suffix).Trim();
                }
            }
        }

        private void processPredecessors(XmlNode ndRow, XmlDocument doc)
        {
            string predecessors = getAttribute(ndRow, "Predecessors");
            string project = getAttribute(ndRow, "Project");
            string rowid = getAttribute(ndRow, "id");

            if (!string.IsNullOrEmpty(predecessors) && !string.IsNullOrEmpty(project))
            {
                string[] sPreds = predecessors.Split(',');
                foreach (string sPred in sPreds)
                {
                    if (sPred != "")
                    {
                        MatchCollection mc = Regex.Matches(sPred, @"^\d+");

                        string suffix = "";
                        try
                        {
                            suffix = Regex.Matches(sPred.Substring(mc[0].Value.Length), @"\w+")[0].Value;
                        }
                        catch { }

                        processPredecessor(doc, mc[0].Value, project, rowid, suffix);

                        //ndRow.Attributes["Predecessors"].Value = "AR7";
                    }
                }
            }
        }

        private string getFieldValue(string fieldname, string value)
        {
            try
            {
                SPField oField = base.list.Fields.GetFieldByInternalName(fieldname);
                switch (oField.Type)
                {
                    case SPFieldType.DateTime:
                        if (value != "")
                        {
                            try
                            {
                                DateTime dt = (DateTime)oField.GetFieldValue(value);
                                return dt.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            catch { }
                        }
                        return value;
                    case SPFieldType.Number:
                        SPFieldNumber num = (SPFieldNumber)oField;
                        if (num.ShowAsPercentage)
                        {
                            if (value.Contains("%"))
                                return value.Replace("%", "");
                            else
                                return (float.Parse(value, providerEn) * 100).ToString(providerEn);
                        }
                        else
                        {
                            return float.Parse(value, providerEn).ToString(providerEn);
                        }
                    case SPFieldType.Calculated:
                        if (oField.Description == "Indicator")
                        {
                            if (value != "" && !value.StartsWith("<img src"))
                                value = "<img src=\"/_layouts/images/" + value.ToLower() + "\">";
                        }
                        SPFieldCalculated calc = (SPFieldCalculated)oField;
                        if (calc.ShowAsPercentage)
                        {
                            if (value.Contains("%"))
                                return value.Replace("%", "");
                            else
                                return (float.Parse(value, providerEn) * 100).ToString(providerEn);
                        }
                        else
                        {
                            return float.Parse(value, providerEn).ToString(providerEn);
                        }
                    case SPFieldType.Boolean:
                        if (value.ToLower() == "true")
                            return "1";
                        return "0";
                    default:
                        switch (oField.TypeAsString)
                        {
                            case "TotalRollup":
                                return oField.GetFieldValueAsText(value);
                            default:
                                return value;
                        }
                }
            }
            catch { }
            return value;
        }

        private void ProcessItems(XmlNode ndParent, XmlNode ndRow, XmlNodeList arrFields, XmlDocument doc)
        {


            XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "I", doc.NamespaceURI);

            XmlNodeList ndCells = ndRow.SelectNodes("cell");

            try
            {
                if (ndRow.SelectSingleNode("row") != null)
                {
                    string open = "0";
                    try
                    {
                        open = ndRow.Attributes["open"].Value;
                    }
                    catch { }
                    XmlAttribute attr = doc.CreateAttribute("Expanded");
                    attr.Value = open;
                    ndNew.Attributes.Append(attr);
                }
            }
            catch { }

            try
            {
                XmlAttribute attr = doc.CreateAttribute("siteid");
                attr.Value = ndRow.SelectSingleNode("userdata[@name='siteid']").InnerText;
                ndNew.Attributes.Append(attr);
            }
            catch { }
            try
            {
                XmlAttribute attr = doc.CreateAttribute("webid");
                attr.Value = ndRow.SelectSingleNode("userdata[@name='webid']").InnerText;
                ndNew.Attributes.Append(attr);
            }
            catch { }
            try
            {
                XmlAttribute attr = doc.CreateAttribute("itemid");
                attr.Value = ndRow.SelectSingleNode("userdata[@name='itemid']").InnerText;
                ndNew.Attributes.Append(attr);
            }
            catch { }
            try
            {
                XmlAttribute attr = doc.CreateAttribute("wsurl");
                attr.Value = ndRow.SelectSingleNode("userdata[@name='wsurl']").InnerText;
                ndNew.Attributes.Append(attr);
            }
            catch { }
            try
            {
                XmlAttribute attr = doc.CreateAttribute("listid");
                attr.Value = ndRow.SelectSingleNode("userdata[@name='listid']").InnerText;
                ndNew.Attributes.Append(attr);
            }
            catch { }
            try
            {
                XmlAttribute attr = doc.CreateAttribute("SiteUrl");
                attr.Value = ndRow.SelectSingleNode("userdata[@name='SiteUrl']").InnerText;
                ndNew.Attributes.Append(attr);
            }
            catch { }
            try
            {
                XmlAttribute attr = doc.CreateAttribute("viewMenus");
                attr.Value = ndRow.SelectSingleNode("userdata[@name='viewMenus']").InnerText;
                ndNew.Attributes.Append(attr);
            }
            catch { }
            try
            {
                XmlAttribute attr = doc.CreateAttribute("HasComments");
                attr.Value = ndRow.SelectSingleNode("userdata[@name='HasComments']").InnerText;
                ndNew.Attributes.Append(attr);
            }
            catch { }
            try
            {
                XmlAttribute attr = doc.CreateAttribute("id");
                attr.Value = (curId++).ToString();
                ndNew.Attributes.Append(attr);
            }
            catch { }


            for (int i = 0; i < ndCells.Count; i++)
            {
                try
                {
                    string fieldName = arrFields[i].Attributes["id"].Value.Replace("<![CDATA[", "").Replace("]]>", "");
                    string val = getFieldValue(fieldName, ndCells[i].InnerText);

                    if ((fieldName == StartDateField || fieldName == DueDateField) && val == "")
                    {
                    }
                    else if (fieldName == DueDateField)
                    {
                        //val = DateTime.Parse(val).AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");

                        XmlAttribute attr = doc.CreateAttribute(fieldName);
                        attr.Value = val;
                        ndNew.Attributes.Append(attr);
                    }
                    else if (fieldName == "Predecessors")
                    {
                        XmlAttribute attr = doc.CreateAttribute(fieldName);
                        attr.Value = val;
                        ndNew.Attributes.Append(attr);

                    }
                    else if (fieldName == "Title")
                    {
                        XmlAttribute attr = doc.CreateAttribute(fieldName);
                        attr.Value = val;
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute(fieldName + "ButtonText");
                        if (ndRow.SelectSingleNode("userdata[@name='itemid']") != null && ndRow.SelectSingleNode("userdata[@name='itemid']").InnerText != "")
                        {
                            //attr.Value = "<div class=\"gridmenuspan\" style=\"position:relative;\"><a data-itemid=\"" + ndRow.SelectSingleNode("userdata[@name='itemid']").InnerText + "\" data-listid=\"" + ndRow.SelectSingleNode("userdata[@name='listid']").InnerText + "\" data-webid=\"" + ndRow.SelectSingleNode("userdata[@name='webid']").InnerText + "\" data-siteid=\"" + ndRow.SelectSingleNode("userdata[@name='siteid']").InnerText + "\" ></a></div>";
                        }
                        ndNew.Attributes.Append(attr);
                    }
                    else
                    {
                        if (hshLookupEnums.Contains(fieldName))
                        {
                            string newval = "";
                            if (val != "")
                            {
                                SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);

                                foreach (SPFieldLookupValue lv in lvc)
                                {
                                    if (!((ArrayList)hshLookupEnums[fieldName]).Contains(lv.LookupId))
                                    {
                                        ((ArrayList)hshLookupEnums[fieldName]).Add(lv.LookupId);
                                        ((ArrayList)hshLookupEnumKeys[fieldName]).Add(lv.LookupValue.Replace(";", ""));

                                    }

                                    newval += ";" + lv.LookupId;
                                }
                            }

                            val = newval.Trim(';');
                        }

                        if (fieldName == "State")
                            fieldName = "FState";

                        XmlAttribute attr = doc.CreateAttribute(fieldName);
                        attr.Value = val;
                        ndNew.Attributes.Append(attr);

                    }
                }
                catch { }
            }

            ndParent.AppendChild(ndNew);

            XmlNodeList ndRows = ndRow.SelectNodes("row");

            if (ndRows.Count > 0)
            {
                XmlAttribute attr = doc.CreateAttribute("Def");
                attr.Value = "Summary";
                ndNew.Attributes.Append(attr);

                for (int i = 0; i < ndRows.Count; i++)
                {
                    ProcessItems(ndNew, ndRows[i], arrFields, doc);
                }
            }
        }

        private static string getFormat(SPField oField, XmlDocument oDoc, SPWeb oWeb)
        {
            string format = "";

            switch (oField.Type)
            {
                case SPFieldType.DateTime:
                    try
                    {

                        if (oDoc.FirstChild.Attributes["Format"].Value == "DateOnly")
                        {
                            format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        }
                        else
                        {
                            format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern;
                        }
                    }
                    catch { }
                    break;
                case SPFieldType.Number:
                    if (oDoc.FirstChild.Attributes["Percentage"] != null && oDoc.FirstChild.Attributes["Percentage"].Value.ToLower() == "true")
                    {
                        format = "0\\%;0\\%;0\\%";
                    }
                    else
                    {
                        int decCount = 0;
                        string decimals = "";
                        try
                        {
                            decCount = int.Parse(oDoc.FirstChild.Attributes["Decimals"].Value);
                        }
                        catch { }

                        for (int i = 0; i < decCount; i++)
                        {
                            decimals += "0";
                        }

                        if (decCount > 0)
                            decimals = "." + decimals;

                        format = ",0" + decimals;
                        break;
                    }
                    break;
                case SPFieldType.Currency:
                    SPFieldCurrency c = (SPFieldCurrency)oField;
                    System.Globalization.NumberFormatInfo nInfo = System.Globalization.CultureInfo.GetCultureInfo(c.CurrencyLocaleId).NumberFormat;
                    if ((0).ToString("c0", nInfo)[0] == '0')
                        format = ",0.00 " + nInfo.CurrencySymbol;
                    else
                        format = nInfo.CurrencySymbol + ",0.00";
                    break;
                case SPFieldType.Calculated:
                    switch (oDoc.FirstChild.Attributes["ResultType"].Value)
                    {
                        case "Currency":
                            format = oWeb.Locale.NumberFormat.CurrencySymbol + ",0.00";
                            break;
                        case "Number":
                            if (oDoc.FirstChild.Attributes["Percentage"] != null && oDoc.FirstChild.Attributes["Percentage"].Value.ToLower() == "true")
                            {
                                format = "0\\%;0\\%;0\\%";
                            }
                            else
                            {
                                int decCount = 0;
                                string decimals = "";
                                try
                                {
                                    decCount = int.Parse(oDoc.FirstChild.Attributes["Decimals"].Value);
                                }
                                catch { }

                                for (int i = 0; i < decCount; i++)
                                {
                                    decimals += "0";
                                }

                                if (decCount > 0)
                                    decimals = "." + decimals;

                                format = ",0" + decimals;
                            }
                            break;
                    };
                    break;

            };

            return format;
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
    }
}

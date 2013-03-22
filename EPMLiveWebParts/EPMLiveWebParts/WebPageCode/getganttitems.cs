using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;
using System.Collections;
using System.Text.RegularExpressions;

namespace EPMLiveWebParts
{
    public partial class getganttitems : getgriditems
    {
        private ArrayList arrHidden = new ArrayList();

        private int curId = 0;

        public override void getParams(SPWeb curWeb)
        {
            base.getParams(curWeb);
            ArrayList arrFields = new ArrayList();

            foreach(string field in view.ViewFields)
            {
                arrFields.Add(field);
            }

            if(!arrFields.Contains(StartDateField))
            {
                arrHidden.Add(StartDateField);
                view.ViewFields.Add(StartDateField);
            }
            if(!arrFields.Contains(DueDateField))
            {
                arrHidden.Add(DueDateField);
                view.ViewFields.Add(DueDateField);
            }
            if(!arrFields.Contains(ProgressField) && ProgressField != "")
            {
                arrHidden.Add(ProgressField);
                view.ViewFields.Add(ProgressField);
            }
            if(!arrFields.Contains("Duration"))
            {
                try
                {
                    arrHidden.Add("Duration");
                    view.ViewFields.Add("Duration");
                }
                catch { }
            }
            if(!arrFields.Contains("Predecessors"))
            {
                try
                {
                    arrHidden.Add("Predecessors");
                    view.ViewFields.Add("Predecessors");
                }
                catch { }
            }
            if(!arrFields.Contains("Project"))
            {
                try
                {
                    arrHidden.Add("Project");
                    view.ViewFields.Add("Project");
                }
                catch { }
            }
            if(!arrFields.Contains("taskorder"))
            {
                try
                {
                    arrHidden.Add("taskorder");
                    view.ViewFields.Add("taskorder");
                }
                catch { }
            }
            if(!arrFields.Contains("Descendants"))
            {
                try
                {
                    arrHidden.Add("Descendants");
                    view.ViewFields.Add("Descendants");
                }
                catch { }
            }

            inEditMode = true;
            bCleanValues = true;
        }

        protected override void outputXml()
        {
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.txtGanttLayout.Replace("#gridid#", base.gridname));

            XmlNode ndHeader = doc.FirstChild.SelectSingleNode("//Header");
            XmlNode ndCols = doc.FirstChild.SelectSingleNode("//LeftCols");

            //XmlNode ndLeftCols = doc.FirstChild.SelectSingleNode("//LeftCols");

            ArrayList arrFields = new ArrayList();

            foreach(string field in view.ViewFields)
            {
                try
                {
                    SPField oField = getRealField(list.Fields.GetFieldByInternalName(field));

                    arrFields.Add(oField.InternalName);

                    XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "C", doc.NamespaceURI);
                    XmlAttribute attr = doc.CreateAttribute("Name");
                    attr.Value = oField.InternalName;
                    ndNew.Attributes.Append(attr);



                    XmlDocument oDoc = new XmlDocument();
                    oDoc.LoadXml(oField.SchemaXml);

                    string sFormat = getFormat(oField, oDoc, SPContext.Current.Web);
                    string sType = "Html";

                    string sTitle = oField.Title;

                    if(sFormat != "")
                    {
                        attr = doc.CreateAttribute("Format");
                        attr.Value = sFormat;
                        ndNew.Attributes.Append(attr);
                    }

                    if(oField.InternalName == "Title")
                    {
                        attr = doc.CreateAttribute("Width");
                        attr.Value = "300";
                        ndNew.Attributes.Append(attr);
                    }
                    else if(oField.InternalName == "WorkspaceUrl")
                    {
                        attr = doc.CreateAttribute("Width");
                        attr.Value = "60";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("Align");
                        attr.Value = "Center";
                        ndNew.Attributes.Append(attr);

                        attr = doc.CreateAttribute("WorkspaceUrl");
                        attr.Value = "h";
                        ndHeader.Attributes.Append(attr);

                        sTitle = "";
                    }
                    else
                    {
                        string sWidth = "150";

                        switch(oField.Type)
                        {
                            case SPFieldType.Text:
                                sWidth = "150";
                                break;
                            case SPFieldType.Number:
                                attr = doc.CreateAttribute("Align");
                                attr.Value = "Right";
                                ndNew.Attributes.Append(attr);
                                sType = "Float";
                                break;
                            case SPFieldType.Currency:
                                attr = doc.CreateAttribute("Align");
                                attr.Value = "Right";
                                ndNew.Attributes.Append(attr);
                                sType = "Float";
                                break;
                            case SPFieldType.DateTime:
                                attr = doc.CreateAttribute("Align");
                                attr.Value = "Right";
                                ndNew.Attributes.Append(attr);
                                sType = "Date";
                                break;
                            case SPFieldType.Boolean:
                                sType = "Bool";
                                break;
                            case SPFieldType.Calculated:
                                SPFieldCalculated oFC = (SPFieldCalculated)oField;
                                if(oFC.OutputType == SPFieldType.Number || oFC.OutputType == SPFieldType.Currency || oFC.OutputType == SPFieldType.DateTime)
                                {
                                    attr = doc.CreateAttribute("Align");
                                    attr.Value = "Right";
                                    ndNew.Attributes.Append(attr);
                                    sType = "Float";
                                }
                                else if(oFC.Description == "Indicator")
                                {
                                    attr = doc.CreateAttribute("Align");
                                    attr.Value = "Center";
                                    ndNew.Attributes.Append(attr);
                                    sWidth = "80";
                                }
                                break;
                            case SPFieldType.Choice:
                                sWidth = "150";
                                break;
                            case SPFieldType.Lookup:
                                sWidth = "150";
                                break;
                            case SPFieldType.MultiChoice:
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
                                break;
                            default:
                                switch(oField.TypeAsString)
                                {
                                    case "TotalRollup":
                                        attr = doc.CreateAttribute("Align");
                                        attr.Value = "Right";
                                        ndNew.Attributes.Append(attr);
                                        break;
                                }
                                break;
                        }

                        attr = doc.CreateAttribute("Width");
                        attr.Value = sWidth;
                        ndNew.Attributes.Append(attr);
                    }

                    attr = doc.CreateAttribute("Type");
                    attr.Value = sType;
                    ndNew.Attributes.Append(attr);

                    ndCols.AppendChild(ndNew);

                    if(oField.InternalName == "Title")
                    {
                        ndCols = doc.FirstChild.SelectSingleNode("//Cols");
                    }

                    attr = doc.CreateAttribute(oField.InternalName);
                    attr.Value = sTitle;
                    ndHeader.Attributes.Append(attr);

                    if(arrHidden.Contains(oField.InternalName))
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

            XmlNodeList ndRows = docXml.FirstChild.SelectNodes("row");
            XmlNode ndParent = doc.FirstChild.SelectSingleNode("//B");

            XmlNodeList ndOldCols = docXml.FirstChild.SelectNodes("//head/column");
            XmlNode ndSummary = doc.FirstChild.SelectSingleNode("//Def/D[@Name='Summary']");

            if(StartDateField != "")
            {
                XmlAttribute attr = doc.CreateAttribute(StartDateField + "Formula");
                attr.Value = "ganttstart()";
                ndSummary.Attributes.Append(attr);
            }

            if(DueDateField != "")
            {
                XmlAttribute attr = doc.CreateAttribute(DueDateField + "Formula");
                attr.Value = "ganttend()";
                ndSummary.Attributes.Append(attr);
            }

            if(ProgressField != "")
            {
                XmlAttribute attr = doc.CreateAttribute(ProgressField + "Formula");
                attr.Value = "ganttpercent()";
                ndSummary.Attributes.Append(attr);
            }


            //PercentCompleteFormula="ganttpercent('StartDate','DueDate','d')" 

            foreach(XmlNode ndRow in ndRows)
                ProcessItems(ndParent, ndRow, ndOldCols, doc);

            foreach(XmlNode ndRow in doc.FirstChild.SelectNodes("//I[@Predecessors!='']"))
            {
                processPredecessors(ndRow, doc);
            }
            
            data = doc.OuterXml;
        }

        private string getAttribute(XmlNode nd, string attribute)
        {
            try
            {
                if(nd.Attributes[attribute] != null)
                    return nd.Attributes[attribute].Value;
            }
            catch { }
            return "";
        }

        private void processPredecessor(XmlDocument doc, string pred, string project, string rowid, string suffix)
        {
            XmlNode nd = doc.FirstChild.SelectSingleNode("//I[@taskorder='" + pred + "' and @Project='" + project + "']");

            if(nd != null)
            {
                if(nd.Attributes["Descendants"] == null)
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

            if(!string.IsNullOrEmpty(predecessors) && !string.IsNullOrEmpty(project))
            {
                string[] sPreds = predecessors.Split(',');
                foreach(string sPred in sPreds)
                {
                    if(sPred != "")
                    {
                        MatchCollection mc = Regex.Matches(sPred, @"^\d+");

                        string suffix = "";
                        try
                        {
                            suffix = Regex.Matches(sPred.Substring(mc[0].Value.Length), @"\w+")[0].Value;
                        }catch{}

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
                switch(oField.Type)
                {
                    case SPFieldType.DateTime:
                        if(value != "")
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
                        if(num.ShowAsPercentage)
                        {
                            if(value.Contains("%"))
                                return value.Replace("%", "");
                            else
                                return (float.Parse(value) * 100).ToString();
                        }
                        else
                            return value;
                    case SPFieldType.Calculated:
                        if(oField.Description == "Indicator")
                        {
                            if(value != "" && !value.StartsWith("<img src"))
                                value = "<img src=\"/_layouts/images/" + value.ToLower() + "\">";
                        }
                        SPFieldCalculated calc = (SPFieldCalculated)oField;
                        if(calc.ShowAsPercentage)
                        {
                            if(value.Contains("%"))
                                return value.Replace("%", "");
                            else
                                return (float.Parse(value) * 100).ToString();
                        }
                        else
                            return value;

                    default:
                        switch(oField.TypeAsString)
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
                if(ndRow.SelectSingleNode("row") != null)
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
            }catch{}
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
                XmlAttribute attr = doc.CreateAttribute("id");
                attr.Value = (curId++).ToString();
                ndNew.Attributes.Append(attr);
            }
            catch { }
            

            for(int i = 0; i < ndCells.Count; i++)
            {
                try
                {
                    string fieldName = arrFields[i].Attributes["id"].Value.Replace("<![CDATA[","").Replace("]]>","");
                    string val = getFieldValue(fieldName, ndCells[i].InnerText);

                    if((fieldName == StartDateField || fieldName == DueDateField) && val == "")
                    {
                    }
                    else if(fieldName == DueDateField)
                    {
                        val = DateTime.Parse(val).AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");

                        XmlAttribute attr = doc.CreateAttribute(fieldName);
                        attr.Value = val;
                        ndNew.Attributes.Append(attr);
                    }
                    else if(fieldName == "Predecessors")
                    {
                        XmlAttribute attr = doc.CreateAttribute(fieldName);
                        attr.Value = val;
                        ndNew.Attributes.Append(attr);

                    }
                    else
                    {
                        XmlAttribute attr = doc.CreateAttribute(fieldName);
                        attr.Value = val;
                        ndNew.Attributes.Append(attr);
                    }
                }
                catch { }
            }

            ndParent.AppendChild(ndNew);

            XmlNodeList ndRows = ndRow.SelectNodes("row");

            if(ndRows.Count > 0)
            {
                XmlAttribute attr = doc.CreateAttribute("Def");
                attr.Value = "Summary";
                ndNew.Attributes.Append(attr);

                for(int i = 0; i < ndRows.Count; i++)
                {
                    ProcessItems(ndNew, ndRows[i], arrFields, doc);
                }
            }
        }

        private static string getFormat(SPField oField, XmlDocument oDoc, SPWeb oWeb)
        {
            string format = "";

            switch(oField.Type) 
            {
                case SPFieldType.DateTime:
                    try
                    {
                        if(oDoc.FirstChild.Attributes["Format"].Value == "DateOnly")
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
                    if(oDoc.FirstChild.Attributes["Percentage"] != null && oDoc.FirstChild.Attributes["Percentage"].Value.ToLower() == "true")
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

                        for(int i = 0; i < decCount; i++)
                        {
                            decimals += "0";
                        }

                        if(decCount > 0)
                            decimals = "." + decimals;

                        format = ",0" + decimals;
                        break;
                    }
                    break;
                case SPFieldType.Currency:
                    format = oWeb.Locale.NumberFormat.CurrencySymbol + ",0.00";
                    break;
                case SPFieldType.Calculated:
                    switch(oDoc.FirstChild.Attributes["ResultType"].Value)
                    {
                        case "Currency":
                            format = oWeb.Locale.NumberFormat.CurrencySymbol + ",0.00";
                            break;
                        case "Number":
                            if(oDoc.FirstChild.Attributes["Percentage"] != null && oDoc.FirstChild.Attributes["Percentage"].Value.ToLower() == "true")
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

                                for(int i = 0; i < decCount; i++)
                                {
                                    decimals += "0";
                                }

                                if(decCount > 0)
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
                if(field.Type == SPFieldType.Computed)
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
                        if(parentField != "")
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

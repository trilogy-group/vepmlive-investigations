using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using System.Xml;
using System.Globalization;
using System.Data;

namespace EPMLiveWebParts
{
    public class WPAPI
    {
        public static string GetGrid(string data, SPWeb web)
        {

            API.GridAPI grid = new API.GridAPI(data, web);

            return grid.ToString();

        }
        public static string GetGridRow(string data, SPWeb web)
        {
            XmlDocument DocIn = new XmlDocument();
            DocIn.LoadXml(data);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Grid><Changes><I id=\"" + DocIn.FirstChild.Attributes["id"].Value + "\"/></Changes></Grid>");

            Guid SiteId = new Guid(DocIn.FirstChild.Attributes["siteid"].Value);
            Guid WebId = new Guid(DocIn.FirstChild.Attributes["webid"].Value);
                

            try
            {
                    
                if (SiteId != web.Site.ID)
                {
                    using (SPSite oSite = new SPSite(SiteId))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb(WebId))
                        {
                            iGetGridRow(ref doc, oWeb, DocIn);
                        }
                    }
                }
                else if (WebId != web.ID)
                {
                    using (SPWeb oWeb = web.Site.OpenWeb(WebId))
                    {
                        iGetGridRow(ref doc, oWeb, DocIn);
                    }
                }
                else
                    iGetGridRow(ref doc, web, DocIn);

                return "<Result Status=\"0\"><![CDATA[" + doc.OuterXml + "]]></Result>";
            }
            catch (Exception ex)
            {
                return "<Result Status=\"1\"><Error ID=\"9003\">Error (9003): " + ex.Message + "</Error></Result>";
            }
        }

        private static void iGetGridRow(ref XmlDocument doc, SPWeb oWeb, XmlDocument DocIn)
        {
            Guid ListId = new Guid(DocIn.FirstChild.Attributes["listid"].Value);
            int itemid = int.Parse(DocIn.FirstChild.Attributes["itemid"].Value);

            SPList list = oWeb.Lists[ListId];
            SPListItem li = list.GetItemById(itemid);


            iGetRowValue(ref doc, oWeb, DocIn, list, li);
        }

        public static string SetGridRowEdit(string data, SPWeb web)
        {
            try
            {
                XmlDocument DocIn = new XmlDocument();
                DocIn.LoadXml(data);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<Grid><Changes><I id=\"" + DocIn.FirstChild.Attributes["id"].Value + "\"/></Changes></Grid>");

                Guid SiteId = new Guid(DocIn.FirstChild.Attributes["siteid"].Value);
                Guid WebId = new Guid(DocIn.FirstChild.Attributes["webid"].Value);
                
                try
                {

                    
                    if (SiteId != web.Site.ID)
                    {
                        using (SPSite oSite = new SPSite(SiteId))
                        {
                            using (SPWeb oWeb = oSite.OpenWeb(WebId))
                            {
                                iSetGridRowEdit(ref doc, oWeb, DocIn);
                            }
                        }
                    }
                    else if (WebId != web.ID)
                    {
                        using (SPWeb oWeb = web.Site.OpenWeb(WebId))
                        {
                            iSetGridRowEdit(ref doc, oWeb, DocIn);
                        }
                    }
                    else
                        iSetGridRowEdit(ref doc, web, DocIn);

                    return "<Result Status=\"0\"><![CDATA[" + doc.OuterXml + "]]></Result>";
                }
                catch (Exception ex)
                {
                    return "<Result Status=\"1\"><Error ID=\"9003\">Error (9003): " + ex.Message + "</Error></Result>";
                }
                
            }
            catch (Exception ex)
            {
                return "<Result Status=\"1\"><Error ID=\"9002\">Error (9002): " + ex.Message + "</Error></Result>";
            }
        }

        private static void iGetRowValue(ref XmlDocument doc, SPWeb oWeb, XmlDocument DocIn, SPList list, SPListItem li)
        {
            string[] sCols = DocIn.FirstChild.Attributes["Cols"].Value.Split(',');
            XmlNode nd = doc.SelectSingleNode("//I");

            foreach (string sCol in sCols)
            {
                if (ValidEditCol(sCol))
                {
                    SPField oField = null;
                    try
                    {
                        oField = list.Fields.GetFieldByInternalName(sCol);
                    }
                    catch { }
                    if (oField != null)
                    {
                        XmlAttribute attr = doc.CreateAttribute(sCol);
                        attr.Value = GetCellValue(li, oField, true, oWeb);
                        nd.Attributes.Append(attr);
                    }
                }
            }
        }

        private static void iSetGridRowEdit(ref XmlDocument doc, SPWeb oWeb, XmlDocument DocIn)
        {
            Guid ListId = new Guid(DocIn.FirstChild.Attributes["listid"].Value);
            int itemid = int.Parse(DocIn.FirstChild.Attributes["itemid"].Value);

            SPList list = oWeb.Lists[ListId];
            SPListItem li = list.GetItemById(itemid);

            oWeb.AllowUnsafeUpdates = true;
            foreach (XmlNode nd in DocIn.FirstChild.SelectNodes("//Field"))
            {
                SPField oField = list.Fields.GetFieldByInternalName(nd.Attributes["Name"].Value);
                switch(oField.Type)
                {
                    case SPFieldType.User:
                        if (nd.InnerText != "")
                        {
                            string[] sUVals = nd.InnerText.Split(';');
                            SPFieldUserValueCollection uvc = new SPFieldUserValueCollection();
                            foreach (string sVal in sUVals)
                            {
                                SPFieldUserValue lv = new SPFieldUserValue(oWeb, sVal);
                                uvc.Add(lv);
                            }
                            li[oField.Id] = uvc;
                        }
                        else
                            li[oField.Id] = null;
                        break;
                    case SPFieldType.Lookup:
                        string[] sVals = nd.InnerText.Split(';');
                        SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection();
                        foreach (string sVal in sVals)
                        {
                            SPFieldLookupValue lv = new SPFieldLookupValue(sVal);
                            lvc.Add(lv);
                        }
                        li[oField.Id] = lvc;
                        break;
                    case SPFieldType.MultiChoice:
                        li[oField.Id] = nd.InnerText.Replace(";",";#");
                        break;
                    case SPFieldType.Currency:
                    case SPFieldType.Number:
                        if (nd.InnerText == "")
                            li[oField.Id] = null;
                        else
                            li[oField.Id] = nd.InnerText;
                        break;
                    case SPFieldType.DateTime:
                        if (nd.InnerText == "")
                            li[oField.Id] = null;
                        else
                            li[oField.Id] = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(double.Parse(nd.InnerText));
                        break;
                    default:
                        li[oField.Id] = nd.InnerText;
                        break;
                }
            }

            li.Update();

            iGetRowValue(ref doc, oWeb, DocIn, list, li);
        }

        public static string GetGridRowEdit(string data, SPWeb web)
        {
            try
            {
                XmlDocument DocIn = new XmlDocument();
                DocIn.LoadXml(data);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<Grid><Changes><I id=\"" + DocIn.FirstChild.Attributes["id"].Value + "\"/></Changes></Grid>");

                Guid SiteId = new Guid(DocIn.FirstChild.Attributes["siteid"].Value);
                Guid WebId = new Guid(DocIn.FirstChild.Attributes["webid"].Value);


                if (SiteId != web.Site.ID)
                {
                    using (SPSite oSite = new SPSite(SiteId))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb(WebId))
                        {
                            iGetGridRowEdit(ref doc, oWeb, DocIn);
                        }
                    }
                }
                else if (WebId != web.ID)
                {
                    using (SPWeb oWeb = web.Site.OpenWeb(WebId))
                    {
                        iGetGridRowEdit(ref doc, oWeb, DocIn);
                    }
                }
                else
                    iGetGridRowEdit(ref doc, web, DocIn);

                return "<Result Status=\"0\"><![CDATA[" + doc.OuterXml + "]]></Result>";
            }
            catch (Exception ex)
            {
                return "<Result Status=\"1\"><Error ID=\"9001\">Error: " + ex.Message + "</Error></Result>";
            }
        }

        private static void iGetGridRowEdit(ref XmlDocument doc, SPWeb oWeb, XmlDocument DocIn)
        {
            Guid ListId = new Guid(DocIn.FirstChild.Attributes["listid"].Value);
            int itemid = int.Parse(DocIn.FirstChild.Attributes["itemid"].Value);
            string[] sCols = DocIn.FirstChild.Attributes["Cols"].Value.Split(',');

            SPList list = oWeb.Lists[ListId];
            SPListItem li = list.GetItemById(itemid);

            XmlNode nd = doc.SelectSingleNode("//I");
            EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);
            Dictionary<string, Dictionary<string, string>> fieldProperties = EPMLiveCore.ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);

            foreach (string sCol in sCols)
            {
                if (ValidEditCol(sCol))
                {
                    SPField oField = null;
                    try
                    {
                        oField = list.Fields.GetFieldByInternalName(sCol);
                    }
                    catch { }
                    if (oField != null)
                    {
                        if (EPMLiveCore.EditableFieldDisplay.isEditable(li, oField, fieldProperties))
                        {
                            XmlAttribute attr = doc.CreateAttribute(sCol + "CanEdit");
                            attr.Value = "1";
                            nd.Attributes.Append(attr);

                            string senum = "";
                            string senumkeys = "";
                            string sFormat = "";
                            string sRange = "";

                            attr = doc.CreateAttribute(sCol + "Type");
                            attr.Value = GetFieldType(oField, out senum, out senumkeys, out sFormat, out sRange, oWeb);
                            nd.Attributes.Append(attr);

                            if (senum != "")
                            {
                                attr = doc.CreateAttribute(sCol + "Enum");
                                attr.Value = senum;
                                nd.Attributes.Append(attr);
                            }
                            if (senumkeys != "")
                            {
                                attr = doc.CreateAttribute(sCol + "EnumKeys");
                                attr.Value = senumkeys;
                                nd.Attributes.Append(attr);
                            }
                            if (sFormat != "")
                            {
                                attr = doc.CreateAttribute(sCol + "Format");
                                attr.Value = sFormat;
                                nd.Attributes.Append(attr);
                            }
                            if (sRange != "")
                            {
                                attr = doc.CreateAttribute(sCol + "Range");
                                attr.Value = sRange;
                                nd.Attributes.Append(attr);
                            }

                            attr = doc.CreateAttribute(sCol);
                            attr.Value = GetCellValue(li, oField, true, oWeb);
                            nd.Attributes.Append(attr);
                            
                        }
                    }
                }
            }
        }

        private static string GetFieldType(SPField oField, out string senum, out string senumkeys, out string sFormat, out string sRange, SPWeb oWeb)
        {
            var currencyFormatDictionary = new Dictionary<int, string> { { 0, "$n" }, { 1, "n$" }, { 2, "$ n" }, { 3, "n $" } };

            senum = "";
            senumkeys = "";
            sFormat = "";
            sRange = "";

            switch (oField.Type)
            {
                case SPFieldType.Boolean:
                    return "Bool";
                 case SPFieldType.DateTime:
                    SPFieldDateTime oDTField = (SPFieldDateTime)oField;
                    string dateFormat = GetExampleDateFormat(oWeb, "yyyy", "M", "d");
                    sFormat = oDTField.GetProperty("Format").Equals("DateOnly") ? dateFormat : string.Format("{0} h:mm tt", dateFormat);
                    return "Date";
                case SPFieldType.Currency:
                    var currenvyCultureInfo = new CultureInfo(((SPFieldCurrency)oField).CurrencyLocaleId);
                    NumberFormatInfo numberFormatInfo = currenvyCultureInfo.NumberFormat;

                    sFormat = currencyFormatDictionary[numberFormatInfo.CurrencyPositivePattern]
                        .Replace("$", numberFormatInfo.CurrencySymbol)
                        .Replace("n",
                            string.Format("##,#.{0}", new string('0', numberFormatInfo.CurrencyDecimalDigits)));
                    return "Float";
                case SPFieldType.Note:
                    return "Lines";
                case SPFieldType.Number:
                    string percentageSign = string.Empty;

                        if (((SPFieldNumber)oField).ShowAsPercentage)
                        {
                            percentageSign = @"%";
                        }

                        switch (((SPFieldNumber)oField).DisplayFormat)
                        {
                            case SPNumberFormatTypes.Automatic:
                                sFormat = ",#0.##########" + percentageSign;
                                break;
                            case SPNumberFormatTypes.NoDecimal:
                                sFormat = ",#0" + percentageSign;
                                break;
                            case SPNumberFormatTypes.OneDecimal:
                                sFormat = ",#0.0" + percentageSign;
                                break;
                            case SPNumberFormatTypes.TwoDecimals:
                                sFormat = ",#0.00" + percentageSign;
                                break;
                            case SPNumberFormatTypes.ThreeDecimals:
                                sFormat = ",#0.000" + percentageSign;
                                break;
                            case SPNumberFormatTypes.FourDecimals:
                                sFormat = ",#0.0000" + percentageSign;
                                break;
                            case SPNumberFormatTypes.FiveDecimals:
                                sFormat = ",#0.00000" + percentageSign;
                                break;
                        }
                    return "Float";
                case SPFieldType.Choice:
                    SPFieldChoice oCField = (SPFieldChoice)oField;
                    foreach (string sChoice in oCField.Choices)
                        senum += ";" + sChoice;
                    return "Enum";
                case SPFieldType.Lookup:
                    SPFieldLookup oLField = (SPFieldLookup)oField;
                    if (oLField.AllowMultipleValues)
                        sRange = "1";

                    SPList oLookupList = oWeb.Lists[new Guid(oLField.LookupList)];

                    foreach (SPListItem li in oLookupList.Items)
                    {
                        senum += ";" + li.Title.Replace(";", "");
                        senumkeys += ";" + li.ID;
                    }

                    return "Enum";
                case SPFieldType.MultiChoice:
                    SPFieldMultiChoice oMCField = (SPFieldMultiChoice)oField;
                    foreach (string sChoice in oMCField.Choices)
                        senum += ";" + sChoice;
                    sRange = "1";
                    return "Enum";
                case SPFieldType.User:

                    DataTable dtResources = EPMLiveCore.API.APITeam.GetResourcePool("<Pool><Columns>SimpleColumns</Columns></Pool>", oWeb);

                    foreach (DataRow dr in dtResources.Rows)
                    {
                        senum += ";" + dr["Title"].ToString();
                        senumkeys += ";" + dr["SPID"].ToString();
                    }

                    SPFieldUser oUField = (SPFieldUser)oField;
                    if (oUField.AllowMultipleValues)
                        sRange = "1";
                    return "Enum";
                default:
                    return "Text";
            }
        }

        private static string GetExampleDateFormat(SPWeb web, string yearLabel, string monthLabel, string dayLabel)
        {
            string format = string.Empty;

            SPContext context = SPContext.GetContext(web);

            SPRegionalSettings spRegionalSettings = context.Web.CurrentUser.RegionalSettings ?? context.RegionalSettings;

            string dateSeparator = spRegionalSettings.DateSeparator;
            var calendarOrderType = (SPCalendarOrderType)spRegionalSettings.DateFormat;

            switch (calendarOrderType)
            {
                case SPCalendarOrderType.MDY:
                    format = monthLabel + dateSeparator + dayLabel + dateSeparator + yearLabel;
                    break;
                case SPCalendarOrderType.DMY:
                    format = dayLabel + dateSeparator + monthLabel + dateSeparator + yearLabel;
                    break;
                case SPCalendarOrderType.YMD:
                    format = yearLabel + dateSeparator + monthLabel + dateSeparator + dayLabel;
                    break;
            }

            return format;
        }

        private static bool ValidEditCol(string sCol)
        {
            switch (sCol)
            {
                case "siteid":
                case "webid":
                case "listid":
                case "itemid":
                case "G":
                    return false;
            }
            return true;
        }

        private static string GetCellValue(SPListItem li, SPField oField, bool bEditMode, SPWeb oWeb)
        {
            
            string val = "";

            if (li[oField.Id] != null)
            {
                val = li[oField.Id].ToString();

                switch (oField.Type)
                {
                    case SPFieldType.User:
                        if (bEditMode)
                        {
                            SPFieldUserValueCollection lvc = new SPFieldUserValueCollection(oWeb, val);
                            val = "";
                            foreach(SPFieldUserValue lv in lvc)
                            {
                                val += ";" + lv.LookupId;
                            }
                            val = val.Trim(';');
                        }
                        else
                            oField.GetFieldValueForEdit(li[oField.Id].ToString());
                        break;
                    case SPFieldType.Lookup:
                        if (bEditMode)
                        {
                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(val);
                            val = "";
                            foreach(SPFieldLookupValue lv in lvc)
                            {
                                val += ";" + lv.LookupId;
                            }
                            val = val.Trim(';');
                        }
                        else
                            oField.GetFieldValueForEdit(li[oField.Id].ToString());
                        break;
                    case SPFieldType.MultiChoice:
                        if (bEditMode)
                        {
                            SPFieldMultiChoiceValue v = (SPFieldMultiChoiceValue)oField.GetFieldValue(li[oField.Id].ToString());
                            val = "";
                            for (int i = 0; i < v.Count; i++)
                            {
                                val += ";" + v[i];
                            }
                            val = val.Trim(';');
                        }
                        else
                            oField.GetFieldValueForEdit(val);
                        break;
                    case SPFieldType.Calculated:
                        val = li[oField.Id].ToString();
                        if (oField.Description == "Indicator" || val.ToLower().EndsWith(".gif") || val.ToLower().EndsWith(".png") || val.ToLower().EndsWith(".jpg"))
                        {
                            val = "<img src=\"/_layouts/15/images/" + oField.GetFieldValueAsText(val) + "\">";
                        }
                        else
                        {

                        }
                        break;
                    default:

                        if (bEditMode)
                            val =  li[oField.Id].ToString();
                        else
                            val = oField.GetFieldValueAsText(li[oField.Id].ToString());
                        break;
                }
            }
            return val;
        }
    }
}

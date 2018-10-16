using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;
using DiagTrace = System.Diagnostics.Trace;

namespace TimeSheets
{
    public partial class gettimesheet
    {
        private void ProcessXmlNode(IList arrayList, string strColumns, bool timeEditor, string[] strWorkTypes, bool timeNotes, string filterHead)
        {
            foreach (XmlNode xmlNode in docXml.SelectNodes("//row"))
            {
                var ndListId = xmlNode.SelectSingleNode("userdata[@name='listid']");
                var ndItemId = xmlNode.SelectSingleNode("userdata[@name='itemid']");

                if (ndListId != null && ndItemId != null)
                {
                    XmlDocumentNodeCreate(arrayList, strColumns, xmlNode, ndListId, ndItemId);

                    var ro = false;

                    try
                    {
                        if (xmlNode.SelectSingleNode("userdata[@name='tsdisabled']").InnerText == "1")
                        {
                            ro = true;
                        }
                    }
                    catch (Exception exception)
                    {
                        DiagTrace.WriteLine(exception);
                    }

                    foreach (DateTime dateTime in arrayList)
                    {
                        if (timeEditor)
                        {
                            ProcessXmlNodeInnerText(strWorkTypes, timeNotes, ndListId, ndItemId, dateTime, xmlNode);
                        }
                        else
                        {
                            XmlNodeAttributes(ndListId, ndItemId, dateTime, ro, xmlNode);
                        }
                    }

                    var newCol = docXml.CreateNode(XmlNodeType.Element, CellText, docXml.NamespaceURI);
                    newCol.InnerText = string.Empty;
                    var attrStyle1 = docXml.CreateAttribute(StyleText);
                    attrStyle1.Value = $"background: #{bgcolor}";
                    newCol.Attributes.Append(attrStyle1);
                    xmlNode.AppendChild(newCol);
                    var drTotal = dsTSHours.Tables[3].Select($"list_uid=\'{ndListId.InnerText}\' and item_id={ndItemId.InnerText}");
                    var ndWork = xmlNode.SelectSingleNode("userdata[@name='Work']");
                    newCol = docXml.CreateNode(XmlNodeType.Element, CellText, docXml.NamespaceURI);

                    newCol.InnerText = drTotal.Length > 0
                        ? $"{ndWork.InnerText}|{drTotal[0][0]}"
                        : $"{ndWork.InnerText}|0";

                    attrStyle1 = docXml.CreateAttribute(StyleText);
                    attrStyle1.Value = $"background: #{bgcolor}";
                    newCol.Attributes.Append(attrStyle1);
                    xmlNode.AppendChild(newCol);
                }
                else
                {
                    XmlNodeAppendChild(arrayList, xmlNode);
                }
            }

            var ndFilter = docXml.SelectSingleNode("//head/beforeInit/call[@command='attachHeader']");

            if (ndFilter != null)
            {
                var innerXml = ndFilter.FirstChild.InnerXml;
                innerXml = innerXml.Replace("<![CDATA[", "<![CDATA[&nbsp;,").Replace("]]>", $"{filterHead},&nbsp;,&nbsp;]]>");
                ndFilter.FirstChild.InnerXml = innerXml;
            }
        }

        private void ProcessXmlNodeInnerText(string[] strWorkTypes, bool timeNotes, XmlNode ndListId, XmlNode ndItemId, DateTime dateTime, XmlNode xmlNode)
        {
            Guard.ArgumentIsNotNull(xmlNode, nameof(xmlNode));
            Guard.ArgumentIsNotNull(ndItemId, nameof(ndItemId));
            Guard.ArgumentIsNotNull(ndListId, nameof(ndListId));
            Guard.ArgumentIsNotNull(strWorkTypes, nameof(strWorkTypes));

            var newCol = XmlNode(strWorkTypes, ndListId, ndItemId, dateTime, out var colInnerTextBuilder);

            if (timeNotes)
            {
                var dataRows = dsTSHours.Tables[1]
                   .Select(
                        "list_uid='" +
                        ndListId.InnerText +
                        "' and item_id=" +
                        ndItemId.InnerText +
                        " and TS_ITEM_DATE=#" +
                        dateTime.ToString("MM/dd/yyy") +
                        "#");

                colInnerTextBuilder.Append(
                    dataRows.Length > 0
                        ? $"|N|{dataRows[0]["TS_ITEM_NOTES"]}"
                        : "|N|");
            }

            newCol.InnerText = colInnerTextBuilder.ToString();

            if (newCol.InnerText.Length > 1)
            {
                newCol.InnerText = newCol.InnerText.Substring(1);
            }

            xmlNode.AppendChild(newCol);
        }

        private void XmlNodeAttributes(XmlNode ndListId, XmlNode ndItemId, DateTime dateTime, bool ro, XmlNode xmlNode)
        {
            var newCol = docXml.CreateNode(XmlNodeType.Element, CellText, docXml.NamespaceURI);

            var dataRows = dsTSHours.Tables[0]
               .Select(
                    "list_uid='" +
                    ndListId.InnerText +
                    "' and item_id=" +
                    ndItemId.InnerText +
                    " and TS_ITEM_DATE=#" +
                    dateTime.ToString("MM/dd/yyyy") +
                    "#");

            newCol.InnerText = dataRows.Length > 0
                ? dataRows[0]["TS_ITEM_HOURS"].ToString()
                : Zero;

            if (ro)
            {
                var attrType = docXml.CreateAttribute(TypeText);
                attrType.Value = RoText;
                newCol.Attributes.Append(attrType);
            }

            xmlNode.AppendChild(newCol);
        }

        private XmlNode XmlNode(string[] strWorkTypes, XmlNode ndListId, XmlNode ndItemId, DateTime dateTime, out StringBuilder colInnerTextBuilder)
        {
            Guard.ArgumentIsNotNull(ndItemId, nameof(ndItemId));
            Guard.ArgumentIsNotNull(ndListId, nameof(ndListId));
            Guard.ArgumentIsNotNull(strWorkTypes, nameof(strWorkTypes));

            var newCol = docXml.CreateNode(XmlNodeType.Element, CellText, docXml.NamespaceURI);
            colInnerTextBuilder = new StringBuilder(newCol.InnerText);

            foreach (var strWorkType in strWorkTypes)
            {
                var dataRows = dsTSHours.Tables[0]
                   .Select(
                        "list_uid='" +
                        ndListId.InnerText +
                        "' and item_id=" +
                        ndItemId.InnerText +
                        " and TS_ITEM_DATE=#" +
                        dateTime.ToString("MM/dd/yyyy") +
                        "# and tstype_id='" +
                        strWorkType +
                        "'");

                colInnerTextBuilder.Append(
                    dataRows.Length > 0
                        ? $"|{strWorkType}|{dataRows[0]["TS_ITEM_HOURS"]}"
                        : $"|{strWorkType}|0");
            }

            return newCol;
        }

        private void XmlNodeAppendChild(IList arrayList, XmlNode xmlNode)
        {
            Guard.ArgumentIsNotNull(xmlNode, nameof(xmlNode));
            Guard.ArgumentIsNotNull(arrayList, nameof(arrayList));

            var newCell = docXml.CreateNode(XmlNodeType.Element, CellText, docXml.NamespaceURI);
            newCell.InnerText = string.Empty;
            var attrType = docXml.CreateAttribute(TypeText);
            attrType.Value = RoText;
            newCell.Attributes.Append(attrType);

            xmlNode.InsertBefore(newCell, xmlNode.SelectSingleNode(CellText));

            foreach (XmlNode ndCell in xmlNode.SelectNodes(CellText))
            {
                var attrStyle = docXml.CreateAttribute(StyleText);
                attrStyle.Value = $"background: #{bgcolor}; font-weight: bold;";
                ndCell.Attributes.Append(attrStyle);
            }

            foreach (var newCol in from DateTime dateTime in arrayList
                select docXml.CreateNode(XmlNodeType.Element, CellText, docXml.NamespaceURI))
            {
                newCol.InnerText = string.Empty;
                var attrStyle = docXml.CreateAttribute(StyleText);
                attrStyle.Value = $"background: #{bgcolor}";
                newCol.Attributes.Append(attrStyle);
                attrType = docXml.CreateAttribute(TypeText);
                attrType.Value = RoText;
                newCol.Attributes.Append(attrType);
                xmlNode.AppendChild(newCol);
            }

            var newCol2 = docXml.CreateNode(XmlNodeType.Element, CellText, docXml.NamespaceURI);
            newCol2.InnerText = "-";
            var attrStyle2 = docXml.CreateAttribute(StyleText);
            attrStyle2.Value = $"background: #{bgcolor}";
            newCol2.Attributes.Append(attrStyle2);
            var attrType2 = docXml.CreateAttribute(TypeText);
            attrType2.Value = "ron";
            newCol2.Attributes.Append(attrType2);
            xmlNode.AppendChild(newCol2);
            newCol2 = docXml.CreateNode(XmlNodeType.Element, CellText, docXml.NamespaceURI);
            newCol2.InnerText = "&nbsp;";
            attrType2 = docXml.CreateAttribute(StyleText);
            attrType2.Value = $"background: #{bgcolor}";
            newCol2.Attributes.Append(attrType2);
            xmlNode.AppendChild(newCol2);
        }

        private void XmlDocumentNodeCreate(IList arrayList, string strColumns, XmlNode xmlNode, XmlNode ndListId, XmlNode ndItemId)
        {
            Guard.ArgumentIsNotNull(ndItemId, nameof(ndItemId));
            Guard.ArgumentIsNotNull(ndListId, nameof(ndListId));
            Guard.ArgumentIsNotNull(xmlNode, nameof(xmlNode));
            Guard.ArgumentIsNotNull(strColumns, nameof(strColumns));
            Guard.ArgumentIsNotNull(arrayList, nameof(arrayList));

            var newCell = docXml.CreateNode(XmlNodeType.Element, CellText, docXml.NamespaceURI);
            newCell.InnerText = string.Empty;
            var attrStyle2 = docXml.CreateAttribute(StyleText);

            if (inEditMode)
            {
                attrStyle2.Value = $"background: #{bgcolor}";
            }

            newCell.Attributes.Append(attrStyle2);
            xmlNode.SelectSingleNode(CellText).Attributes.Append((XmlAttribute)attrStyle2.Clone());
            xmlNode.InsertBefore(newCell, xmlNode.SelectSingleNode(CellText));

            var newCol = docXml.CreateNode(XmlNodeType.Element, UserDataText, docXml.NamespaceURI);

            newCol.InnerText = inEditMode
                ? view.ViewFields.Count.ToString()
                : (view.ViewFields.Count - 1).ToString();

            var attrName = docXml.CreateAttribute(NameText);
            attrName.Value = "fieldcount";
            newCol.Attributes.Append(attrName);
            xmlNode.AppendChild(newCol);
            newCol = docXml.CreateNode(XmlNodeType.Element, UserDataText, docXml.NamespaceURI);

            if (arrayList.Count > 0)
            {
                newCol.InnerText = arrayList[0].ToString();
            }

            attrName = docXml.CreateAttribute(NameText);
            attrName.Value = "firstdate";
            newCol.Attributes.Append(attrName);
            xmlNode.AppendChild(newCol);
            newCol = docXml.CreateNode(XmlNodeType.Element, UserDataText, docXml.NamespaceURI);
            newCol.InnerText = arrayList.Count.ToString();
            attrName = docXml.CreateAttribute(NameText);
            attrName.Value = "datecount";
            newCol.Attributes.Append(attrName);
            xmlNode.AppendChild(newCol);
            XmlNodeList(strColumns, ndListId, ndItemId, xmlNode);
        }

        private void XmlNodeList(string strColumns, XmlNode ndListId, XmlNode ndItemId, XmlNode xmlNode)
        {
            Guard.ArgumentIsNotNull(xmlNode, nameof(xmlNode));
            Guard.ArgumentIsNotNull(ndItemId, nameof(ndItemId));
            Guard.ArgumentIsNotNull(ndListId, nameof(ndListId));
            Guard.ArgumentIsNotNull(strColumns, nameof(strColumns));

            var drsItem = dsTSHours.Tables[2].Select($"list_uid=\'{ndListId.InnerText}\' and item_id={ndItemId.InnerText}");
            var tsItemUid = Guid.Empty;

            if (drsItem.Length > 0)
            {
                var newCol = docXml.CreateNode(XmlNodeType.Element, UserDataText, docXml.NamespaceURI);
                newCol.InnerText = drsItem[0]["TS_ITEM_UID"].ToString();
                var attrName = docXml.CreateAttribute(NameText);
                attrName.Value = "tsitemuid";
                newCol.Attributes.Append(attrName);
                xmlNode.AppendChild(newCol);
                tsItemUid = new Guid(drsItem[0]["TS_ITEM_UID"].ToString());
            }

            if (submitted && !usecurrent)
            {
                var arrCols = strColumns.Split(',');
                var ndList = xmlNode.SelectNodes(CellText);

                for (var i = 0; i < ndList.Count; i++)
                {
                    var colId = arrCols[i].Replace("<![CDATA[", string.Empty).Replace("]]>", string.Empty);

                    if (colId == ProjectText)
                    {
                        var dataRows = dsTimesheetTasks.Tables[0].Select($"ts_item_uid =\'{tsItemUid}\'");

                        if (dataRows.Length > 0)
                        {
                            ndList[i].InnerText = dataRows[0]["project"].ToString();
                        }
                    }
                    else if (colId != TitleText && colId != ListText && colId != "Site")
                    {
                        var dataRows = dsTSMeta.Tables[0]
                           .Select($"list_uid=\'{ndListId.InnerText}\' and item_id={ndItemId.InnerText} and columnname=\'{colId}\'");
                        var colVal = string.Empty;

                        if (dataRows.Length > 0)
                        {
                            colVal = dataRows[0]["columnvalue"].ToString();
                        }

                        var bIsIndicator = false;

                        try
                        {
                            var field = list.Fields.GetFieldByInternalName(colId);

                            if (field.Type == SPFieldType.Calculated && colVal.IndexOf(".gif", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                bIsIndicator = true;
                            }
                        }
                        catch (Exception exception)
                        {
                            DiagTrace.WriteLine(exception);
                        }

                        ndList[i].InnerText = bIsIndicator
                            ? $"<img src=\"/_layouts/images/{colVal}\">"
                            : colVal;
                    }
                }
            }
        }
    }
}
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using EPMLiveCore;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;
using DiagTrace = System.Diagnostics.Trace;

namespace TimeSheets
{
    public partial class gettimesheet
    {
        protected override void outputXml()
        {
            var arrayList = new ArrayList();
            var workTypes = string.Empty;
            var timeEditor = false;
            var timeNotes = false;
            var filterHead = string.Empty;
            var ndCols = docXml.SelectNodes(ColumnHead);
            var columnCount = ndCols.Count;
            var strColumns = string.Empty;

            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    try
                    {
                        timeNotes = ProcessXmlDocument(ndCols, arrayList, ref workTypes, ref timeEditor, ref filterHead, ref timeNotes);
                    }
                    catch (Exception exception)
                    {
                        DiagTrace.WriteLine(exception);
                    }
                });

            var ndHead = docXml.SelectSingleNode(SingleNodePath);

            if (submitted && !usecurrent)
            {
                var strColumnsBuilder = new StringBuilder(strColumns);

                foreach (XmlNode xmlNode in ndHead.SelectNodes(ColumnText))
                {
                    var value = string.Empty;

                    try
                    {
                        value = xmlNode.Attributes[IdText].Value;
                    }
                    catch (Exception exception)
                    {
                        DiagTrace.WriteLine(exception);
                    }

                    strColumnsBuilder.Append($",{value}");
                }

                strColumns = strColumnsBuilder.ToString().Substring(1);
            }

            XmlNodeList xmlNodeList;
            int start;

            var fullWidth = FullWidth(ndHead, workTypes, arrayList, strColumns, timeEditor, timeNotes, filterHead, columnCount, out xmlNodeList, out start);

            for (var i = start; i <= columnCount; i++)
            {
                var value = string.Empty;

                try
                {
                    value = xmlNodeList[i].Attributes[TypeText].Value;
                }
                catch (Exception exception)
                {
                    DiagTrace.WriteLine(exception);
                }

                if (value == "tree")
                {
                    xmlNodeList[i].Attributes[WidthText].Value = (fullWidth * 2 - 10).ToString("#");
                }
                else
                {
                    xmlNodeList[i].Attributes[WidthText].Value = fullWidth.ToString("#");
                    xmlNodeList[i].Attributes[TypeText].Value = RoText;
                }
            }

            data = docXml.OuterXml;
        }

        private double FullWidth(
            XmlNode nodeHead,
            string workTypes,
            ArrayList arrayList,
            string strColumns,
            bool timeEditor,
            bool timeNotes,
            string filterHead,
            int columnCount,
            out XmlNodeList xmlNodeList,
            out int start)
        {
            Guard.ArgumentIsNotNull(filterHead, nameof(filterHead));
            Guard.ArgumentIsNotNull(strColumns, nameof(strColumns));
            Guard.ArgumentIsNotNull(arrayList, nameof(arrayList));
            Guard.ArgumentIsNotNull(workTypes, nameof(workTypes));
            Guard.ArgumentIsNotNull(nodeHead, nameof(nodeHead));

            var newColWork = docXml.CreateNode(XmlNodeType.Element, ColumnText, docXml.NamespaceURI);
            newColWork.InnerXml = "<![CDATA[% Work Spent]]>";
            var attrTypeWork = docXml.CreateAttribute(TypeText);
            attrTypeWork.Value = "percentwork";
            var attrWidthWork = docXml.CreateAttribute(WidthText);
            attrWidthWork.Value = "125";
            var attrAlignWork = docXml.CreateAttribute(AlignText);
            attrAlignWork.Value = "left";
            var attrColorWork = docXml.CreateAttribute(ColorText);
            attrColorWork.Value = "#F0F0F0";
            var attrIdWork = docXml.CreateAttribute(IdText);
            attrIdWork.Value = "_PercentWork_";

            newColWork.Attributes.Append(attrTypeWork);
            newColWork.Attributes.Append(attrWidthWork);
            newColWork.Attributes.Append(attrAlignWork);
            newColWork.Attributes.Append(attrColorWork);
            newColWork.Attributes.Append(attrIdWork);

            nodeHead.AppendChild(newColWork);
            nodeHead.RemoveChild(nodeHead.SelectSingleNode("settings") ?? throw new InvalidOperationException());

            var strWorkTypes = workTypes.Split('|');

            ProcessXmlNode(arrayList, strColumns, timeEditor, strWorkTypes, timeNotes, filterHead);

            var fullWidth = double.Parse(Request[WidthText].Split('.')[0]);
            xmlNodeList = docXml.SelectNodes(ColumnHead);
            double reservedWidth = 0;

            for (var i = columnCount + 1; i < xmlNodeList.Count; i++)
            {
                try
                {
                    var value = xmlNodeList[i].Attributes[WidthText].Value;
                    reservedWidth += double.Parse(value);
                }
                catch (Exception exception)
                {
                    DiagTrace.WriteLine(exception);
                }
            }

            reservedWidth += inEditMode
                ? 40
                : 30;

            fullWidth -= reservedWidth;
            start = 1;

            if (inEditMode)
            {
                start = 2;
                fullWidth = fullWidth / columnCount;
            }
            else
            {
                fullWidth = fullWidth / (columnCount + 1);
            }

            if (fullWidth < 50)
            {
                fullWidth = 50;
            }

            return fullWidth;
        }

        private bool ProcessXmlDocument(XmlNodeList ndCols, ArrayList arrayList, ref string workTypes, ref bool timeEditor, ref string filterHead, ref bool timeNotes)
        {
            Guard.ArgumentIsNotNull(filterHead, nameof(filterHead));
            Guard.ArgumentIsNotNull(workTypes, nameof(workTypes));
            Guard.ArgumentIsNotNull(arrayList, nameof(arrayList));
            Guard.ArgumentIsNotNull(ndCols, nameof(ndCols));

            var siteRootWeb = site.RootWeb;
            {
                usecurrent = bool.Parse(CoreFunctions.getConfigSetting(siteRootWeb, "EPMLiveTSUseCurrent"));
            }

            ndCols[0].Attributes[WidthText].Value = "25";

            docXml.SelectSingleNode(XPathText);
            var newCol = docXml.CreateNode(XmlNodeType.Element, ColumnText, docXml.NamespaceURI);
            newCol.InnerXml = "<![CDATA[&nbsp;]]>";
            var attrType = docXml.CreateAttribute(TypeText);

            attrType.Value = submitted
                ? RoText
                : ChText;

            var attrWidth = docXml.CreateAttribute(WidthText);
            attrWidth.Value = "25";
            var attrAlign = docXml.CreateAttribute(AlignText);
            attrAlign.Value = "center";
            var attrColor = docXml.CreateAttribute(ColorText);
            attrColor.Value = "#F0F0F0";

            newCol.Attributes.Append(attrType);
            newCol.Attributes.Append(attrWidth);
            newCol.Attributes.Append(attrAlign);
            newCol.Attributes.Append(attrColor);

            docXml.SelectSingleNode(SingleNodePath).InsertBefore(newCol, ndCols[0]);

            using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id)))
            {
                sqlConnection.Open();

                using (var sqlCommand = new SqlCommand("select TSTYPE_ID from TSTYPE where site_uid=@siteid", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(IdSite, site.ID);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        var workBuilder = new StringBuilder(workTypes);

                        while (dataReader.Read())
                        {
                            timeEditor = true;
                            workBuilder.Append($"|{dataReader.GetInt32(0)}");
                        }

                        workTypes = workBuilder.ToString();
                        workTypes = !string.IsNullOrWhiteSpace(workTypes)
                            ? workTypes.Substring(1)
                            : Zero;
                    }
                }

                if (CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSAllowNotes").Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    timeNotes = true;
                    timeEditor = true;
                }

                var dayDefs = CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveDaySettings").Split('|');

                using (var sqlCommand = new SqlCommand(
                    "select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@siteid",
                    sqlConnection)
                {
                    CommandType = CommandType.Text
                })
                {
                    sqlCommand.Parameters.AddWithValue(IdPeriod, period);
                    sqlCommand.Parameters.AddWithValue(IdSite, site.ID);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        var footer = ",Totals:";

                        if (dataReader.Read())
                        {
                            var dtStart = dataReader.GetDateTime(0);
                            var dtEnd = dataReader.GetDateTime(1);
                            var timeSpan = dtEnd - dtStart;
                            var colBase = docXml.SelectSingleNode(SingleNodePath).SelectNodes(ColumnText).Count;
                            var colCount = 0;

                            filterHead = FilterHead(timeSpan, dayDefs, dtStart, filterHead, arrayList, timeEditor, ref colCount);
                            XmlDocumentAppend(footer, colBase, colCount, timeEditor);
                        }
                    }
                }
            }

            return timeNotes;
        }

        private void XmlDocumentAppend(string footer, int colBase, int colCount, bool timeEditor)
        {
            Guard.ArgumentIsNotNull(footer, nameof(footer));

            var cols = string.Empty;
            var footerBuilder = new StringBuilder(footer);
            var colsBuilder = new StringBuilder(cols);

            for (var i = 1; i < colBase - 1; i++)
            {
                footerBuilder.Append(",#cspan");
            }

            for (var i = colBase; i < colBase + colCount; i++)
            {
                colsBuilder.Append("+c{i}");
                footerBuilder.Append(
                    timeEditor
                        ? ",{#stat_summ}"
                        : ",{#stat_total}");
            }

            footerBuilder.Append(",{#stat_totalsumm},-");
            footer = footerBuilder.ToString();
            cols = colsBuilder.ToString();

            var newCol1 = docXml.CreateNode(XmlNodeType.Element, ColumnText, docXml.NamespaceURI);
            newCol1.InnerText = "Total";
            var attrType1 = docXml.CreateAttribute(TypeText);

            attrType1.Value = cols.Length > 1
                ? $"ron[={cols.Substring(1)}]"
                : RoText;

            var attrWidth1 = docXml.CreateAttribute(WidthText);
            attrWidth1.Value = "50";
            var attrAlign1 = docXml.CreateAttribute(AlignText);
            attrAlign1.Value = "right";
            var attrId = docXml.CreateAttribute(IdText);
            attrId.Value = "_TsTotal_";
            newCol1.Attributes.Append(attrType1);
            newCol1.Attributes.Append(attrWidth1);
            newCol1.Attributes.Append(attrAlign1);
            newCol1.Attributes.Append(attrId);
            docXml.SelectSingleNode(SingleNodePath).AppendChild(newCol1);
            var callNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
            var attr = docXml.CreateAttribute("command");
            attr.Value = "attachFooter";
            callNode.Attributes.Append(attr);
            callNode.InnerXml = $"<param>{footer}</param>";
            docXml.SelectSingleNode(XPathText).AppendChild(callNode);
        }

        private string FilterHead(
            TimeSpan timeSpan,
            string[] dayDefs,
            DateTime dtStart,
            string filterHead,
            ArrayList arrayList,
            bool timeEditor,
            ref int colCount)
        {
            Guard.ArgumentIsNotNull(arrayList, nameof(arrayList));
            Guard.ArgumentIsNotNull(filterHead, nameof(filterHead));
            Guard.ArgumentIsNotNull(dayDefs, nameof(dayDefs));

            var filterHeadBuilder = new StringBuilder(filterHead);

            for (var i = 0; i <= timeSpan.Days; i++)
            {
                var showDay = string.Empty;

                try
                {
                    showDay = dayDefs[(int)dtStart.AddDays(i).DayOfWeek * 3];
                }
                catch (Exception exception)
                {
                    DiagTrace.WriteLine(exception);
                }

                if (showDay == TrueText)
                {
                    filterHeadBuilder.Append(",&nbsp;");
                    colCount++;
                    arrayList.Add(dtStart.AddDays(i));
                    var newCol = docXml.CreateNode(XmlNodeType.Element, ColumnText, docXml.NamespaceURI);
                    newCol.InnerXml = $"<![CDATA[{dtStart.AddDays(i).DayOfWeek.ToString().Substring(0, 3)}<br>{dtStart.AddDays(i).Day}]]>";
                    var attrType = docXml.CreateAttribute(TypeText);

                    attrType.Value = timeEditor
                        ? "timeeditor"
                        : "edn";

                    var attrWidth = docXml.CreateAttribute(WidthText);
                    attrWidth.Value = "40";
                    var attrAlign = docXml.CreateAttribute(AlignText);
                    attrAlign.Value = "right";
                    var attrId1 = docXml.CreateAttribute(IdText);
                    attrId1.Value = $"_TsDate_{dtStart.AddDays(i).ToShortDateString().Replace("/", "_")}";

                    newCol.Attributes.Append(attrType);
                    newCol.Attributes.Append(attrWidth);
                    newCol.Attributes.Append(attrAlign);
                    newCol.Attributes.Append(attrId1);

                    docXml.SelectSingleNode(SingleNodePath).AppendChild(newCol);
                }
            }

            return filterHeadBuilder.ToString();
        }
    }
}
using System;
using System.Collections;
using System.Diagnostics;
using System.Xml;

namespace TimeSheets
{
    public partial class GetTsApprovals
    {
        protected override void outputXml()
        {
            var arrayList = new ArrayList();
            var workTypes = string.Empty;
            var timeEditor = false;
            var timeNotes = false;
            var filterHead = string.Empty;
            var ndCols = docXml.SelectNodes("//head/column");

            var columnCount = ndCols.Count;
            var strColumns = string.Empty;

            var web = site.RootWeb;
            {
                usecurrent = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTSUseCurrent"));
            }

            try
            {
                AddNodes(
                    ndCols,
                    site,
                    cn,
                    "<![CDATA[Notes]]>",
                    "tsnotes",
                    "50",
                    period,
                    arrayList,
                    ref filterHead,
                    ref workTypes,
                    ref timeEditor,
                    ref timeNotes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            var ndHead = docXml.SelectSingleNode("//head");
            if (!usecurrent)
            {
                strColumns = GetColumns(ndHead);
            }

            AddColumnWork(ndHead);
            ndHead.RemoveChild(ndHead.SelectSingleNode("settings"));

            var strWorktypes = workTypes.Split('|');
            var rowCounter = 1;

            foreach (XmlNode rowNode in docXml.SelectNodes("//row"))
            {
                var ndListId = rowNode.SelectSingleNode(string.Format(UserData, "listid"));
                var ndItemId = rowNode.SelectSingleNode(string.Format(UserData, "itemid"));
                var ndTsuid = rowNode.SelectSingleNode(string.Format(UserData, "tsuid"));

                if (ndListId != null && ndItemId != null)
                {
                    var sql = "select ts_item_uid,submitted,approval_status,project from vwtstasks where list_uid=@listuid and item_id=@itemid and username=@username and period_id=@period_id";
                    AddCells(
                        rowNode,
                        site,
                        ndListId,
                        ndItemId,
                        period,
                        dsTSHours,
                        arrayList,
                        bgcolor,
                        usecurrent,
                        strColumns,
                        dsTimesheetTasks,
                        dsTimesheetMeta,
                        timeEditor,
                        strWorktypes,
                        timeNotes,
                        cn,
                        sql);
                }
                else
                {
                    AddCells(rowNode, bgcolor, arrayList);
                }
                rowNode.Attributes[Id].Value = rowCounter.ToString();
                rowCounter++;
            }

            var ndFilter = docXml.SelectSingleNode("//head/beforeInit/call[@command='attachHeader']");
            if (ndFilter != null)
            {
                var xml = ndFilter.FirstChild.InnerXml;
                xml = xml.Replace("<![CDATA[", "<![CDATA[&nbsp;,&nbsp;,&nbsp;,&nbsp;,")
                        .Replace($"gridfilter{gridname}('1", $"gridfilter{gridname}('2")
                        .Replace("]]>", $"{filterHead},&nbsp;]]>");
                ndFilter.FirstChild.InnerXml = xml;
            }

            UpdateHeadColumns(columnCount);

            cn.Close();

            data = docXml.OuterXml;
        }

        private void AddColumnWork(XmlNode ndHead)
        {
            if (ndHead == null)
            {
                throw new ArgumentNullException(nameof(ndHead));
            }

            var newColWork = docXml.CreateNode(XmlNodeType.Element, Column, docXml.NamespaceURI);
            newColWork.InnerXml = "<![CDATA[% Work Spent]]>";
            var attrTypeWork = docXml.CreateAttribute(TypeAttribute);
            attrTypeWork.Value = "percentwork";
            var attrWidthWork = docXml.CreateAttribute(Width);
            attrWidthWork.Value = "125";
            var attrAlignWork = docXml.CreateAttribute(Align);
            attrAlignWork.Value = "left";
            var attrColorWork = docXml.CreateAttribute(Color);
            attrColorWork.Value = "#F0F0F0";
            var attrIdWork = docXml.CreateAttribute(Id);
            attrIdWork.Value = "_PercentWork_";

            newColWork.Attributes.Append(attrTypeWork);
            newColWork.Attributes.Append(attrWidthWork);
            newColWork.Attributes.Append(attrAlignWork);
            newColWork.Attributes.Append(attrColorWork);
            newColWork.Attributes.Append(attrIdWork);

            ndHead.AppendChild(newColWork);
        }

        private void UpdateHeadColumns(int columnCount)
        {
            var fullWidth = double.Parse(Request[Width]);
            double reservedWidth = 0;

            var ndNewCols = docXml.SelectNodes("//head/column");
            for (var i = columnCount + 4; i < ndNewCols.Count; i++)
            {
                try
                {
                    var witdth = ndNewCols[i].Attributes[Width].Value;
                    reservedWidth += double.Parse(witdth);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            reservedWidth += 125;

            fullWidth -= reservedWidth;
            fullWidth = fullWidth / (columnCount + 1);

            if (fullWidth < 50)
            {
                fullWidth = 50;
            }

            for (var i = ColumnStartIndex; i <= columnCount + 3; i++)
            {
                var id = string.Empty;
                try
                {
                    id = ndNewCols[i].Attributes[TypeAttribute].Value;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                if (id == TreeId)
                {
                    ndNewCols[i].Attributes[Width].Value = (fullWidth * 2 - 10).ToString();
                }
                else
                {
                    ndNewCols[i].Attributes[Width].Value = fullWidth.ToString();
                    ndNewCols[i].Attributes[TypeAttribute].Value = "ro";
                }
            }
        }
    }
}
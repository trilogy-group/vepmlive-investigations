using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using EPMLiveCore;
using Microsoft.SharePoint;
using SystemTrace = System.Diagnostics.Trace;

namespace TimeSheets
{ 
    public partial class getts
    {
        private void addHeader(SPWeb curWeb)
        {
            var ndHead = docXml.CreateNode(XmlNodeType.Element, "head", docXml.NamespaceURI);
            docXml.ChildNodes[0].AppendChild(ndHead);
            ndBeforeInit = docXml.CreateNode(XmlNodeType.Element, "beforeInit", docXml.NamespaceURI);
            ndHead.AppendChild(ndBeforeInit);
            var afterInitNode = docXml.CreateNode(XmlNodeType.Element, "afterInit", docXml.NamespaceURI);
            ndHead.AppendChild(afterInitNode);

            AddColumns(ndHead);

            var sql = "select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@siteid";
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@period_id", period);
                cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
                using (var dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        periodStart = dataReader.GetDateTime(0);
                        periodEnd = dataReader.GetDateTime(1);
                    }
                }
            }

            dayDefs = CoreFunctions.getConfigSetting(curWeb.Site.RootWeb, "EPMLiveDaySettings").Split('|');

            var timeSpan = periodEnd - periodStart;
            for (var day = 0; day <= timeSpan.Days; day++)
            {
                var showDay = string.Empty;
                try
                {
                    showDay = dayDefs[(int)periodStart.AddDays(day).DayOfWeek * 3];
                }
                catch (Exception ex)
                {
                    SystemTrace.WriteLine(ex.ToString());
                }
                if (showDay == True)
                {
                    var newCol = AddNewColumn(day);

                    ndHead.AppendChild(newCol);
                }
            }

            var newColumn = AddNewColumn();

            ndHead.AppendChild(newColumn);

            InitializeTimSheets(curWeb.Site.ID);
        }



        private void AddColumns(XmlNode ndHead)
        {
            var ndNewColumn = AddNewColumn("#master_checkbox", "ch", "20", "center");
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = AddNewColumn("<![CDATA[Notes]]>", "tsnotes", "50", "center");
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = AddNewColumn("<![CDATA[Resource Name]]>", "tree", "*", "left");
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = AddNewColumn("<![CDATA[TM]]>", Ro, "35", "center");
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = AddNewColumn("<![CDATA[PM]]>", Ro, "35", "center");
            ndHead.AppendChild(ndNewColumn);
        }


        private XmlNode AddNewColumn(string innerXm, string typeValue, string withdValue, string alignValue)
        {
            var ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerXml = innerXm;

            var attrType = docXml.CreateAttribute(TypeConst);
            attrType.Value = typeValue;
            var attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = withdValue;
            var attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = alignValue;

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            return ndNewColumn;
        }

        private XmlNode AddNewColumn(int days)
        {
            var newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            newCol.InnerXml = "<![CDATA[" + periodStart.AddDays(days).DayOfWeek.ToString().Substring(0, 3) + "<br>" + periodStart.AddDays(days).Day +
                              "]]>";
            var attrType = docXml.CreateAttribute(TypeConst);
            attrType.Value = "ro[=sum]";
            var attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "40";
            var attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "right";
            var attrId = docXml.CreateAttribute(Id);
            attrId.Value = "_TsDate_" + periodStart.AddDays(days).ToShortDateString().Replace("/", "_");
            ;

            newCol.Attributes.Append(attrType);
            newCol.Attributes.Append(attrWidth);
            newCol.Attributes.Append(attrAlign);
            newCol.Attributes.Append(attrId);
            return newCol;
        }

        private XmlNode AddNewColumn()
        {
            var newColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            newColumn.InnerXml = "Total";
            var attrType = docXml.CreateAttribute(TypeConst);
            attrType.Value = "ro[=sum]";
            var attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "60";
            var attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "right";
            var attrId = docXml.CreateAttribute(Id);
            attrId.Value = "Total";

            newColumn.Attributes.Append(attrType);
            newColumn.Attributes.Append(attrWidth);
            newColumn.Attributes.Append(attrAlign);
            newColumn.Attributes.Append(attrId);
            return newColumn;
        }

        private void InitializeTimSheets(Guid siteId)
        {
            var sql =
                "select ts_uid,username,submitted,approval_status,approval_notes from TSTIMESHEET where period_id=@period_id and site_uid=@siteid";
            dsTimesheets = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select hours,ts_item_date,ts_uid from vwTSTimesheetTotals where period_id=@period_id and site_uid=@siteid";
            dsTimesheetTotals = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql =
                "select title,project,ts_uid,ts_item_uid,approval_status from vwTSTasks where period_id=@period_id and site_uid=@siteid order by project";
            dsTimesheetTasks = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select Hours,ts_item_date,ts_item_uid,ts_item_type_id from vwTSHoursByTask where period_id=@period_id and site_uid=@siteid";
            dsTimesheetTaskHours = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select tstype_id from TSTYPE where site_uid=@siteid";
            dsTimesheetTypes = DataSetUtils.CreateDataSet(cn, sql, period, siteId);

            sql = "select ts_item_uid,ts_item_notes,ts_item_date from vwTSNotes where period_id=@period_id and site_uid=@siteid";
            dsTimesheetNotes = DataSetUtils.CreateDataSet(cn, sql, period, siteId);
        }
    }
}
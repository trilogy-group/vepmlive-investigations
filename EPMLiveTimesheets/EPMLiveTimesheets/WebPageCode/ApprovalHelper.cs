using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.SharePoint;

namespace TimeSheets.WebPageCode
{
    public class ApprovalHelper
    {
        public static void AddPeriods(XmlDocument docXml, SPSite site, ArrayList arr, int period, ref string filterHead, SqlConnection cn)
        {
            string[] dayDefs = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveDaySettings").Split('|');

            var cmd = new SqlCommand("select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", site.ID);
            var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                DateTime dtStart = dr.GetDateTime(0);
                DateTime dtEnd = dr.GetDateTime(1);
                TimeSpan ts = dtEnd - dtStart;
                int colBase = docXml.SelectSingleNode("//head").SelectNodes("column").Count;
                int colCount = 0;
                for (int i = 0; i <= ts.Days; i++)
                {
                    string showday = "";
                    try
                    {
                        showday = dayDefs[((int)dtStart.AddDays(i).DayOfWeek) * 3];
                    }
                    catch { }
                    //if (dtStart.AddDays(i).DayOfWeek != DayOfWeek.Sunday && dtStart.AddDays(i).DayOfWeek != DayOfWeek.Saturday)
                    if (showday == "True")
                    {
                        filterHead += ",&nbsp;";
                        colCount++;
                        arr.Add(dtStart.AddDays(i));
                        var newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                        newCol.InnerXml = "<![CDATA[" + dtStart.AddDays(i).DayOfWeek.ToString().Substring(0, 3) + "<br>" + dtStart.AddDays(i).Day + "]]>";
                        var attrType = docXml.CreateAttribute("type");
                        //if (timeeditor)
                        //    attrType.Value = "timeeditor";
                        //else
                        attrType.Value = "ro[=sum]";
                        var attrWidth = docXml.CreateAttribute("width");
                        attrWidth.Value = "40";
                        var attrAlign = docXml.CreateAttribute("align");
                        attrAlign.Value = "right";
                        XmlAttribute attrId1 = docXml.CreateAttribute("id");
                        attrId1.Value = "_TsDate_" + dtStart.AddDays(i).ToShortDateString().Replace("/", "_");

                        newCol.Attributes.Append(attrType);
                        newCol.Attributes.Append(attrWidth);
                        newCol.Attributes.Append(attrAlign);
                        newCol.Attributes.Append(attrId1);

                        docXml.SelectSingleNode("//head").AppendChild(newCol);
                    }
                }
                string cols = "";

                //for (int i = 0; i < colBase - 1; i++)
                //{
                //    footer += ",#cspan";
                //}
                //for (int i = colBase; i < colBase + colCount; i++)
                //{
                //    cols += "+c" + i.ToString();
                //    if (timeeditor)
                //        footer += ",{#stat_summ}";
                //    else
                //        footer += ",{#stat_total}";
                //}

                //footer += ",{#stat_total}";

                XmlNode newCol1 = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                newCol1.InnerText = "Total";
                XmlAttribute attrType1 = docXml.CreateAttribute("type");
                attrType1.Value = "ro[=sum]";
                XmlAttribute attrWidth1 = docXml.CreateAttribute("width");
                attrWidth1.Value = "50";
                XmlAttribute attrAlign1 = docXml.CreateAttribute("align");
                attrAlign1.Value = "right";
                //XmlAttribute attrStyle = docXml.CreateAttribute("style");
                //attrStyle.Value = "background: #c0c0c0";

                XmlAttribute attrId = docXml.CreateAttribute("id");
                attrId.Value = "_TsTotal_";

                newCol1.Attributes.Append(attrType1);
                newCol1.Attributes.Append(attrWidth1);
                newCol1.Attributes.Append(attrAlign1);
                newCol1.Attributes.Append(attrId);
                //newCol1.Attributes.Append(attrStyle);

                docXml.SelectSingleNode("//head").AppendChild(newCol1);

                //XmlNode callNode = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                //XmlAttribute attr = docXml.CreateAttribute("command");
                //attr.Value = "attachFooter";
                //callNode.Attributes.Append(attr);
                //callNode.InnerXml = "<param>" + footer + "</param>";

                //docXml.SelectSingleNode("//head/beforeInit").AppendChild(callNode);
            }
            dr.Close();
        }
    }
}

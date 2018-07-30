using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml;
using EPMLiveCore;
using EPMLiveWebParts;
using Microsoft.SharePoint;

namespace TimeSheets.WebPageCode
{
    public abstract class ApprovalBase : getgriditems
    {
        protected void AddPeriods(XmlDocument docXml, SPSite site, ArrayList arr, int period, ref string filterHead, SqlConnection connection)
        {
            if (docXml == null)
            {
                throw new ArgumentNullException(nameof(docXml));
            }

            if (site == null)
            {
                throw new ArgumentNullException(nameof(site));
            }

            var dayDefs = CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveDaySettings").Split('|');

            var command = new SqlCommand("select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@siteid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.AddWithValue("@period_id", period);
            command.Parameters.AddWithValue("@siteid", site.ID);
            var dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                var dtStart = dataReader.GetDateTime(0);
                var dtEnd = dataReader.GetDateTime(1);
                var ts = dtEnd - dtStart;
                var colBase = docXml.SelectSingleNode("//head").SelectNodes("column").Count;
                var colCount = 0;
                for (var i = 0; i <= ts.Days; i++)
                {
                    var showday = "";
                    try
                    {
                        showday = dayDefs[(int)dtStart.AddDays(i).DayOfWeek * 3];
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                    if (showday == "True")
                    {
                        filterHead += ",&nbsp;";
                        colCount++;
                        arr.Add(dtStart.AddDays(i));
                        var newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                        newCol.InnerXml = "<![CDATA[" + dtStart.AddDays(i).DayOfWeek.ToString().Substring(0, 3) + "<br>" + dtStart.AddDays(i).Day +
                                          "]]>";
                        var attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro[=sum]";
                        var attrWidth = docXml.CreateAttribute("width");
                        attrWidth.Value = "40";
                        var attrAlign = docXml.CreateAttribute("align");
                        attrAlign.Value = "right";
                        var attrId1 = docXml.CreateAttribute("id");
                        attrId1.Value = "_TsDate_" + dtStart.AddDays(i).ToShortDateString().Replace("/", "_");

                        newCol.Attributes.Append(attrType);
                        newCol.Attributes.Append(attrWidth);
                        newCol.Attributes.Append(attrAlign);
                        newCol.Attributes.Append(attrId1);

                        docXml.SelectSingleNode("//head").AppendChild(newCol);
                    }
                }

                var cols = "";

                var newCol1 = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                newCol1.InnerText = "Total";
                var attrType1 = docXml.CreateAttribute("type");
                attrType1.Value = "ro[=sum]";
                var attrWidth1 = docXml.CreateAttribute("width");
                attrWidth1.Value = "50";
                var attrAlign1 = docXml.CreateAttribute("align");
                attrAlign1.Value = "right";

                var attrId = docXml.CreateAttribute("id");
                attrId.Value = "_TsTotal_";

                newCol1.Attributes.Append(attrType1);
                newCol1.Attributes.Append(attrWidth1);
                newCol1.Attributes.Append(attrAlign1);
                newCol1.Attributes.Append(attrId);

                docXml.SelectSingleNode("//head").AppendChild(newCol1);
            }
            dataReader.Close();
        }

        protected void ProcessGroupFields(string[] arrGroupFields, SPListItem listItem, string[] groups, SortedList arrGTemp)
        {
            if (listItem == null)
            {
                throw new ArgumentNullException(nameof(listItem));
            }

            if (arrGTemp == null)
            {
                throw new ArgumentNullException(nameof(arrGTemp));
            }

            if (arrGroupFields != null)
            {
                foreach (var groupby in arrGroupFields)
                {
                    var field = list.Fields.GetFieldByInternalName(groupby);
                    var newgroup = getField(listItem, groupby, true);
                    try
                    {
                        newgroup = formatField(newgroup, groupby, field.Type == SPFieldType.Calculated, true, listItem);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                    if (field.Type == SPFieldType.User || field.Type == SPFieldType.MultiChoice)
                    {
                        var sGroups = newgroup.Split('\n');
                        var tmpGroups = new string[groups.Length * sGroups.Length];

                        var tmpCounter = 0;
                        foreach (var g in groups)
                        {
                            foreach (var sGroup in sGroups)
                            {
                                if (g == null)
                                {
                                    tmpGroups[tmpCounter] = sGroup.Trim();
                                }
                                else
                                {
                                    tmpGroups[tmpCounter] = g + "\n" + sGroup.Trim();
                                }

                                if (!arrGTemp.Contains(tmpGroups[tmpCounter]))
                                {
                                    arrGTemp.Add(tmpGroups[tmpCounter], "");
                                }
                                tmpCounter++;
                            }
                        }
                        groups = tmpGroups;
                    }
                    else
                    {
                        for (var i = 0; i < groups.Length; i++)
                        {
                            if (groups[i] == null)
                            {
                                groups[i] = newgroup;
                            }
                            else
                            {
                                groups[i] += "\n" + newgroup;
                            }
                            if (!arrGTemp.Contains(groups[i]))
                            {
                                arrGTemp.Add(groups[i], "");
                            }
                        }
                    }
                }
            }
        }

        protected DataSet FillTotalHours(DataSet dsTSHours, XmlNode node, XmlNode ndListId, XmlNode ndItemId, SPSite site, SqlConnection connection, int period, out string curUser)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (ndListId == null)
            {
                throw new ArgumentNullException(nameof(ndListId));
            }

            if (site == null)
            {
                throw new ArgumentNullException(nameof(site));
            }

            var rowId = node.Attributes["id"].Value;
            var firstDot = rowId.IndexOf(".", 75);
            curUser = rowId.Substring(firstDot + 1, rowId.LastIndexOf(".") - firstDot - 1);

            var command = new SqlCommand("spTSgetTSHours", connection) {CommandType = CommandType.StoredProcedure};
            command.Parameters.AddWithValue("@username", curUser);
            command.Parameters.AddWithValue("@siteguid", site.ID);
            command.Parameters.AddWithValue("@period_id", period);
            var dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dsTSHours);

            var dsTotalHours = new DataSet();

            command = new SqlCommand("spTSGetTotalHoursForItem", connection) {CommandType = CommandType.StoredProcedure};
            command.Parameters.AddWithValue("@listuid", ndListId.InnerText);
            command.Parameters.AddWithValue("@siteguid", site.ID);
            command.Parameters.AddWithValue("@itemid", ndItemId.InnerText);
            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dsTotalHours);

            return dsTotalHours;
        }

        protected void InsertColumns(string innerXml, string typeValue, string widthValue, XmlNodeList ndCols)
        {
            if (ndCols == null)
            {
                throw new ArgumentNullException(nameof(ndCols));
            }

            var newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            newCol.InnerXml = "<![CDATA[#master_checkbox]]>";
            var attrType = docXml.CreateAttribute("type");
            attrType.Value = "ch";
            var attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "25";
            var attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";
            var attrColor = docXml.CreateAttribute("color");
            attrColor.Value = "#F0F0F0";

            newCol.Attributes.Append(attrType);
            newCol.Attributes.Append(attrWidth);
            newCol.Attributes.Append(attrAlign);
            newCol.Attributes.Append(attrColor);

            docXml.SelectSingleNode("//head").InsertBefore(newCol, ndCols[0]);

            newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            newCol.InnerXml = innerXml;
            attrType = docXml.CreateAttribute("type");
            attrType.Value = typeValue;
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = widthValue;
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";
            attrColor = docXml.CreateAttribute("color");
            attrColor.Value = "#F0F0F0";

            newCol.Attributes.Append(attrType);
            newCol.Attributes.Append(attrWidth);
            newCol.Attributes.Append(attrAlign);
            newCol.Attributes.Append(attrColor);

            docXml.SelectSingleNode("//head").InsertBefore(newCol, ndCols[0]);
        }
    }
}
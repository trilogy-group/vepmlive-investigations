using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.RollupSummary
{
    public partial class RollupSummary
    {
        private void ProcesNodes(XmlDocument doc, ref bool duplicateFound)
        {
            foreach (XmlNode sections in doc.SelectSingleNode("Sections").SelectNodes("Section"))
            {
                foreach (XmlNode item in sections.SelectSingleNode("Items").SelectNodes("Item"))
                {
                    var id = string.Empty;
                    try
                    {
                        id = item.Attributes["ID"].Value;
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                    if (id != string.Empty)
                    {
                        if (!hshNodes.Contains(id))
                        {
                            hshNodes.Add(id, item);
                            hshCounts.Add(id, 0);
                        }
                        else
                        {
                            duplicateFound = true;
                        }
                    }
                }
            }
        }

        private void OpenConnectionWithPriviligedAccess()
        {
            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    using (var spSite = new SPSite(SPContext.Current.Site.ID))
                    {
                        try
                        {
                            var connectionString = spSite.ContentDatabase.DatabaseConnectionString;
                            cn = new SqlConnection(connectionString);
                            cn.Open();
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceError("Exception Suppressed {0}", ex);
                        }
                    }
                });
        }

        private void processSection(XmlNode ndSection)
        {
            var section = string.Empty;
            var url = string.Empty;
            try
            {
                section = ndSection.Attributes["Title"].Value;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception suppressed {0}", ex);
            }
            try
            {
                var rUrl = web.ServerRelativeUrl;
                if (rUrl == "/")
                {
                    rUrl = string.Empty;
                }
                url = ndSection.Attributes["URL"].Value;
                url = url.Replace("{WebUrl}", rUrl);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception suppressed {0}", ex);
            }

            sb.Append("<tr>");
            sb.Append(
                url.Trim() != ""
                    ? $"<td colspan=\"4\"><font class=\"ms-sectionheader\"><a class=\"ms-sectionheader\" href=\"{url}\">{section}</a></td>"
                    : $"<td colspan=\"4\"><font class=\"ms-sectionheader\"><font class=\"ms-sectionheader a\">{section}</font></td>");
            sb.Append("</tr>");

            foreach (XmlNode n in ndSection.SelectSingleNode("Items"))
            {
                processItem(n);
            }
            sb.Append("<tr>");
            sb.Append("<td>&nbsp;</td>");
            sb.Append("</tr>");
        }

        private void processDisplay(XmlNode ndDisplays, int count)
        {
            var display = string.Empty;
            foreach (XmlNode displayNode in ndDisplays)
            {
                var compare = string.Empty;
                var intValue = 0;
                try
                {
                    compare = displayNode.Attributes["Comparator"].Value;
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception suppressed {0}", ex);
                }
                try
                {
                    int.TryParse(displayNode.Attributes["Value"].Value, out intValue);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception suppressed {0}", ex);
                }
                if (compare == "GT")
                {
                    if (count > intValue)
                    {
                        display = displayNode.InnerText;
                        break;
                    }
                }
                else if (compare == "LT")
                {
                    if (count < intValue)
                    {
                        display = displayNode.InnerText;
                        break;
                    }
                }
                else
                {
                    display = displayNode.InnerText;
                    break;
                }
            }
            display = display.Replace("{#}", count.ToString());
            display = display.Replace("{WebUrl}", web.ServerRelativeUrl);
            sb.Append($"<td nowrap=\"nowrap\" colspan=\"3\"><span class=\"ms-stdtxt\">{display}</span></td>");
        }

        private void processWeb(SPWeb curWeb)
        {
            try
            {
                foreach (DictionaryEntry dictionaryEntry in hshNodes)
                {
                    var nodeItem = (XmlNode)dictionaryEntry.Value;
                    var id = string.Empty;
                    var list = string.Empty;
                    var query = string.Empty;

                    try
                    {
                        id = nodeItem.Attributes["ID"].Value;
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception suppressed {0}", ex);
                    }
                    try
                    {
                        list = nodeItem.SelectSingleNode("Query").Attributes["List"].Value;
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception suppressed {0}", ex);
                    }
                    try
                    {
                        query = nodeItem.SelectSingleNode("Query").InnerText;
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception suppressed {0}", ex);
                    }

                    hshCounts[id] = (int)hshCounts[id] + getCount(list, query, curWeb);
                }
            }
            catch (Exception ex)
            {
                sb.Append($"ERROR: {ex.Message}{ex.StackTrace}");
            }
        }

        private int getCount(string list, string query, SPWeb curWeb)
        {
            var siteUrl = curWeb.ServerRelativeUrl.Substring(1);

            var siteDataQuery = new SPSiteDataQuery();
            var count = 0;
            try
            {
                var lists = new StringBuilder();

                var squery = siteUrl == string.Empty
                    ? $"SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='{web.Site.ID}' AND (dbo.AllLists.tp_Title like '{list.Replace("'", "''")}')"
                    : $"SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '{siteUrl}/%' OR dbo.Webs.FullUrl = '{siteUrl}') AND (dbo.AllLists.tp_Title like '{list.Replace("'", "''")}')";

                var sqlCommand = new SqlCommand(squery, cn);

                var dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    lists.Append($"<List ID='{dataReader.GetGuid(0)}'/>");
                }
                dataReader.Close();

                siteDataQuery.Lists = $"<Lists>{lists}</Lists>";
                siteDataQuery.Query = $"<Where>{query}</Where>";
                siteDataQuery.Webs = "<Webs Scope='Recursive'/>";
                siteDataQuery.QueryThrottleMode = SPQueryThrottleOption.Override;
                var dataTable = new DataTable();
                SPSecurity.RunWithElevatedPrivileges(delegate { dataTable = curWeb.GetSiteData(siteDataQuery); });
                count = dataTable.Rows.Count;
            }
            catch (Exception ex)
            {
                sb.Append($"ERROR: {ex.Message}{ex.StackTrace}");
            }

            return count;
        }
    }
}
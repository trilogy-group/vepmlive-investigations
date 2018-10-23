using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Xml;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class ReportingData
    {
        public static DataSet GetReportingData(SPWeb web, string list, bool bRollup, string query, string orderby, int page, int pagesize)
        {

            var reportBiz = new ReportBiz(web.Site.ID);

            if (reportBiz.SiteExists())
            {
                var oList = web.Lists[list];
                EPMData data = null;

                try
                {
                    data = new EPMData(web.Site.ID);
                    var clientReportingConnection = data.GetClientReportingConnection;
                    var borderBy = false;
                    using (var sqlCommand = new SqlCommand(
                        "select * from information_schema.parameters where specific_name='spGetReportListData' and parameter_name='@orderby'",
                        clientReportingConnection))
                    {
                        using (var reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                borderBy = true;
                            }
                        }
                    }

                    var dataSet = new DataSet();
                    using (var sqlCommand = new SqlCommand("spGetReportListData", clientReportingConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@siteid", web.Site.ID);
                        sqlCommand.Parameters.AddWithValue("@webid", web.ID);
                        sqlCommand.Parameters.AddWithValue("@weburl", web.ServerRelativeUrl);
                        sqlCommand.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
                        sqlCommand.Parameters.AddWithValue("@rollup", bRollup);
                        sqlCommand.Parameters.AddWithValue("@list", list);
                        sqlCommand.Parameters.AddWithValue("@query", query);
                        sqlCommand.Parameters.AddWithValue("@pagesize", pagesize);
                        sqlCommand.Parameters.AddWithValue("@page", page);
                        sqlCommand.Parameters.AddWithValue("@listid", oList.ID);

                        if (borderBy)
                        {
                            sqlCommand.Parameters.AddWithValue("@orderby", orderby);
                        }

                        using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            dataAdapter.Fill(dataSet);
                        }
                    }

                    return dataSet;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    if (data != null)
                    {
                        data.Dispose();
                    }
                }
            }
            else
            {
                throw new Exception("Reporting Not Setup.");
            }
        }

        public static DataTable GetReportingData(SPWeb web, string list, bool bRollup, string query, string orderby)
        {
            return GetReportingData(web, list, bRollup, query, orderby, 0, 0).Tables[0];

        }

        public static string GetReportQuery(SPWeb web, SPList list, string spquery, out string orderby)
        {
            orderby = "";

            if (spquery == "")
                return "";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Query>" + spquery + "</Query>");

            XmlNode ndWhere = doc.FirstChild.SelectSingleNode("//Where");

            XmlNode ndGroupBy = doc.FirstChild.SelectSingleNode("//OrderBy");

            if (ndGroupBy != null)
            {
                foreach (XmlNode nd in ndGroupBy.SelectNodes("FieldRef"))
                {

                    SPField oField = list.Fields.GetFieldByInternalName(nd.Attributes["Name"].Value);
                    if (oField.Type == SPFieldType.Lookup || oField.Type == SPFieldType.User)
                        orderby += "," + nd.Attributes["Name"].Value + "Text";
                    else
                        orderby += "," + nd.Attributes["Name"].Value;
                    try
                    {
                        if (nd.Attributes["Ascending"].Value.ToLower() == "false")
                            orderby += " DESC";
                    }
                    catch
                    {
                    }
                }
            }

            orderby = orderby.Trim(',');

            if (ndWhere == null)
                return "";

            string q = GetReportQueryNode(web, ndWhere.FirstChild, list);



            return q;

        }

        private static string GetReportQueryNode(SPWeb web, XmlNode nd, SPList list)
        {
            var query = GetQuery(web, nd, list);
            if (!string.IsNullOrWhiteSpace(query))
            {
                return query;
            }

            var fieldName = nd.SelectSingleNode("FieldRef").Attributes["Name"].Value;
            var fieldNameStringBuilder = new StringBuilder(fieldName);

            if (!string.IsNullOrWhiteSpace(fieldName))
            {
                var field = GetField(list, fieldName);

                if (field != null)
                {
                    //Lookups and User type of columns were created in database as ID and Text fields hence direct returning (column name is null) will not work. Fixed this.
                    if (nd.Name == "IsNull" && field.Type != SPFieldType.Lookup && field.Type != SPFieldType.User)
                    {
                        return string.Format("{0} is null", fieldName);
                    }

                    string values;
                    if (GetValues(nd, field, fieldNameStringBuilder, fieldName, out values))
                    {
                        return values;
                    }

                    return FormatResponse(web, nd, field, fieldNameStringBuilder);
                }
            }
            return string.Empty;
        }

        private static string FormatResponse(SPWeb web, XmlNode nd, SPField field, StringBuilder fieldNameStringBuilder)
        {
            string fieldName;
            bool lookup;
            var nodeValue = GetNodeValue(web, nd, field, fieldNameStringBuilder, out lookup, out fieldName);

            if (string.Equals(nd.Name, "BeginsWith", StringComparison.OrdinalIgnoreCase))
            {
                return string.Format("{0} Like '{1}%'", fieldName, nodeValue);
            }
            if (string.Equals(nd.Name, "Contains", StringComparison.OrdinalIgnoreCase))
            {
                return string.Format("{0} Like '%{1}%'", fieldName, nodeValue);
            }
            if (string.Equals(nd.Name, "Neq", StringComparison.OrdinalIgnoreCase))
            {
                if (field.Type == SPFieldType.DateTime)
                {
                    return string.Format(
                        "((CONVERT(nvarchar,{0}, 111) <> CONVERT(nvarchar, CONVERT(DateTime, '{1}'), 111)) OR {0} IS NULL)",
                        fieldName,
                        nodeValue);
                }
                return string.Format("({0} <> '{1}' OR {0} IS NULL)", fieldName, nodeValue);
            }
            if (string.Equals(nd.Name, "IsNotNull", StringComparison.OrdinalIgnoreCase))
            {
                return string.Format("{0} Is Not Null", fieldName);
            }
            if (string.Equals(nd.Name, "IsNull", StringComparison.OrdinalIgnoreCase))
            {
                return string.Format("{0} Is Null", fieldName);
            }
            var sign = GetNodeSign(nd.Name);

            if (lookup && sign == "=")
            {
                return string.Format("',' + CAST({0} as varchar(MAX)) + ',' LIKE '%,{1},%'", fieldName, nodeValue);
            }
            if (field.Type.Equals(SPFieldType.DateTime))
            {
                // Need to use actual sign operator to match only the date part 
                return string.Format("CONVERT(nvarchar, {0}, 111) {1} CONVERT(nvarchar, CONVERT(DateTime, '{2}'), 111)", fieldName, sign, nodeValue);
            }
            return string.Format("{0} {1} '{2}'", fieldName, sign, nodeValue);
        }

        private static string GetNodeValue(SPWeb web, XmlNode nd, SPField field, StringBuilder fieldNameStringBuilder, out bool lookup, out string fieldName)
        {
            var nodeValue = string.Empty;

            if (nd.SelectSingleNode("Value") != null)
            {
                nodeValue = nd.SelectSingleNode("Value").InnerText;
            }

            if (nd.SelectSingleNode("Value") != null && nd.SelectSingleNode("Value").SelectSingleNode("UserID") != null)
            {
                nodeValue = web.CurrentUser.ID.ToString();
            }

            lookup = false;
            var containToday = false;

            GetFieldValues(nd, field, fieldNameStringBuilder, ref nodeValue, ref containToday, ref lookup);

            fieldName = fieldNameStringBuilder.ToString();

            if (nodeValue.Contains("Today") && containToday)
            {
                if (string.Equals(nodeValue, "[today]", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(nodeValue, "<today />", StringComparison.OrdinalIgnoreCase))
                {
                    nodeValue = DateTime.Now.ToString("s");
                }
                else
                {
                    try
                    {
                        var offsetDays = Convert.ToDouble(nd.SelectSingleNode("//Value/Today").Attributes[0].Value);
                        nodeValue = DateTime.Now.AddDays(offsetDays).ToString("s");
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Expression Suppressed {0}", ex);
                        nodeValue = DateTime.Now.ToString("s");
                    }
                }
            }
            return nodeValue;
        }

        private static bool GetValues(XmlNode nd, SPField field, StringBuilder fieldNameStringBuilder, string fieldName, out string result)
        {
            result = string.Empty;

            var valuesNodes = GetValuesNodes(nd);

            if (valuesNodes != null)
            {
                var valuesStringBuilder = new StringBuilder("(");

                if (field.Type == SPFieldType.Lookup || field.Type == SPFieldType.User)
                {
                    fieldNameStringBuilder.Append("Text");
                }

                if (valuesNodes.SelectNodes("Value").Count > 0)
                {
                    foreach (XmlNode ndVal in valuesNodes.SelectNodes("Value"))
                    {
                        valuesStringBuilder.Append(string.Format("{0} = '{1}' OR ", fieldName, ndVal.InnerText.Replace("'", "''")));
                    }
                }
                else
                {
                    valuesStringBuilder.Append(string.Format("{0} = ''", fieldName));
                }

                var values = valuesStringBuilder.ToString();
                {
                    result = values.Trim(' ').Trim('R').Trim('O') + ")";
                    return true;
                }
            }
            return false;
        }

        private static void GetFieldValues(
            XmlNode nd,
            SPField field,
            StringBuilder fieldNameStringBuilder,
            ref string nodeValue,
            ref bool containToday,
            ref bool lookup)
        {
            switch (field.Type)
            {
                case SPFieldType.Calculated:
                    if (((SPFieldCalculated)field).ShowAsPercentage)
                    {
                        nodeValue = Convert.ToString(double.Parse(nodeValue) * 100);
                    }
                    break;
                case SPFieldType.DateTime:

                    //Initially the code developed use to check the dates based on Like operator also regardless of  sign and offset set through sharepoint
                    //Corrected the code so that it works with sign and  offsetdays like [Today]-1 or [Today]-20 accordingly
                    if (string.IsNullOrWhiteSpace(nodeValue) && nd.SelectSingleNode("Value").InnerXml.Contains("Today"))
                    {
                        nodeValue = nd.SelectSingleNode("Value").InnerXml;
                        containToday = true;
                    }
                    break;
                case SPFieldType.Lookup:
                    try
                    {
                        lookup = true;
                        var lookupField = field as SPFieldLookup;
                        var lookupList = lookupField.ParentList.ParentWeb.Lists[new Guid(lookupField.LookupList)];
                        var fieldType = lookupList.Fields.GetFieldByInternalName(lookupField.LookupField).Type;

                        if (fieldType.Equals(SPFieldType.Integer) || fieldType.Equals(SPFieldType.Counter))
                        {
                            fieldNameStringBuilder.Append("ID");
                        }

                        // Need this condition while adding external task
                        else if (nd.SelectSingleNode("Value") != null
                            && nd.SelectSingleNode("Value").Attributes["Type"] != null
                            && nd.SelectSingleNode("Value").Attributes["Type"].Value.Equals(SPFieldType.Counter.ToString()))
                        {
                            fieldNameStringBuilder.Append("ID");
                        }
                        else
                        {
                            fieldNameStringBuilder.Append("Text");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Expression Suppressed {0}", ex);
                        fieldNameStringBuilder.Append("Text");
                    }
                    break;
                case SPFieldType.User:
                    lookup = true;
                    var tempVal = 0;

                    fieldNameStringBuilder.Append(
                        int.TryParse(Convert.ToString(nodeValue), out tempVal)
                            ? "ID"
                            : "Text");
                    break;
                default:
                    Trace.TraceError("Unexpected Value for {0}: {1}", nameof(field.Type), field.Type);
                    break;
            }
        }

        private static XmlNode GetValuesNodes(XmlNode nd)
        {
            XmlNode valuesNodes = null;
            try
            {
                valuesNodes = nd.SelectSingleNode("Values");
            }
            catch (Exception ex)
            {
                Trace.TraceError("Expression Suppressed {0}", ex);
            }
            return valuesNodes;
        }

        private static SPField GetField(SPList list, string fieldName)
        {
            SPField field = null;
            try
            {
                field = list.Fields.GetFieldByInternalName(fieldName);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Expression Suppressed {0}", ex);
            }
            return field;
        }

        private static string GetQuery(SPWeb web, XmlNode nd, SPList list)
        {
            if (nd.Name == "And")
            {
                return string.Format("({0} And {1})", GetReportQueryNode(web, nd.FirstChild, list), GetReportQueryNode(web, nd.FirstChild.NextSibling, list));
            }
            if (nd.Name == "Or")
            {
                return string.Format("({0} Or {1})", GetReportQueryNode(web, nd.FirstChild, list), GetReportQueryNode(web, nd.FirstChild.NextSibling, list));
            }
            return null;
        }

        public static string GetNodeSign(string name)
        {
            switch (name.ToLower())
            {
                case "eq":
                    return "=";
                case "neq":
                    return "<>";
                case "gt":
                    return ">";
                case "geq":
                    return ">=";
                case "lt":
                    return "<";
                case "leq":
                    return "<=";
                case "beginswith":
                    return "";
                case "contains":
                    return "";
                default:
                    return "=";
            }
        }

        // TEST //
        public static string ProcessReportFilter(SPList list, SPWeb web, string filterWpId)
        {
            string ret = "";
            ArrayList reportFilterIDs = new ArrayList();
            Guid listid = Guid.Empty;
            string reportFilterField = "";
            int MAX_LOOKUPFILTER = 300;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    using (var connection = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(
                            "SELECT VALUE,listid FROM PERSONALIZATIONS where userid=@userid and [key]=@key and FK=@FK",
                            connection))
                        {
                            command.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
                            command.Parameters.AddWithValue("@key", "ReportFilterWebPartSelections");
                            command.Parameters.AddWithValue("@FK", filterWpId);
                            command.ExecuteNonQuery();
                            using (var dataReader = command.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    reportFilterIDs = new ArrayList(dataReader.GetString(0).Split('|')[0].Split(','));
                                    listid = dataReader.GetGuid(1);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            });

            if (listid == list.ID)
            {
                reportFilterField = "Title";

                if (reportFilterIDs.Count < MAX_LOOKUPFILTER)
                {

                    ret = "<In><FieldRef Name=\"Title\"/><Values>" + GetReportFilters(reportFilterIDs) + "</Values></In>";

                }
            }
            else if (listid != Guid.Empty)
            {



                foreach (SPField oField in list.Fields)
                {
                    if (oField.Type == SPFieldType.Lookup)
                    {
                        try
                        {
                            SPFieldLookup oLookup = (SPFieldLookup)oField;
                            if (new Guid(oLookup.LookupList) == listid)
                            {
                                reportFilterField = oLookup.InternalName;
                                break;
                            }
                        }
                        catch { }
                    }
                }


                if (reportFilterIDs.Count < MAX_LOOKUPFILTER && reportFilterField != "")
                {
                    ret = "<In><FieldRef Name=\"" + reportFilterField + "\"/><Values>" + GetReportFilters(reportFilterIDs) + "</Values></In>";
                }
            }


            return ret;
        }

        private static string GetReportFilters(ArrayList reportFilterIDs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in reportFilterIDs)
            {
                sb.Append("<Value Type=\"Text\">");
                sb.Append(System.Web.HttpUtility.HtmlEncode(s));
                sb.Append("</Value>");
            }

            return sb.ToString();
        }
    }
}

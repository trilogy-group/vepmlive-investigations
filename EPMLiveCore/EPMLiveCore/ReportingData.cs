using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace EPMLiveCore
{
    public class ReportingData
    {
        public static DataSet GetReportingData(SPWeb web, string list, bool bRollup, string query, string orderby, int page, int pagesize)
        {

            var rb = new EPMLiveReportsAdmin.ReportBiz(web.Site.ID);

            if (rb.SiteExists())
            {
                SPList oList = web.Lists[list];

                EPMLiveReportsAdmin.EPMData data = new EPMLiveReportsAdmin.EPMData(web.Site.ID);

                SqlConnection cn = data.GetClientReportingConnection;

                SqlCommand cmd = new SqlCommand("select * from information_schema.parameters where specific_name='spGetReportListData' and parameter_name='@orderby'", cn);
                bool borderby = false;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    borderby = true;
                dr.Close();

                cmd = new SqlCommand("spGetReportListData", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                cmd.Parameters.AddWithValue("@webid", web.ID);
                cmd.Parameters.AddWithValue("@weburl", web.ServerRelativeUrl);
                cmd.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
                cmd.Parameters.AddWithValue("@rollup", bRollup);
                cmd.Parameters.AddWithValue("@list", list);
                cmd.Parameters.AddWithValue("@query", query);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@listid", oList.ID);
                
                if (borderby)
                    cmd.Parameters.AddWithValue("@orderby", orderby);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                cn.Close();

                return ds;
            }
            else
                throw new Exception("Reporting Not Setup.");
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
                    if(oField.Type == SPFieldType.Lookup || oField.Type == SPFieldType.User)
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
            if (nd.Name == "And")
            {
                return "(" + GetReportQueryNode(web, nd.FirstChild, list) + " And " + GetReportQueryNode(web, nd.FirstChild.NextSibling, list) + ")";
            }
            else if (nd.Name == "Or")
            {
                return "(" + GetReportQueryNode(web, nd.FirstChild, list) + " Or " + GetReportQueryNode(web, nd.FirstChild.NextSibling, list) + ")";
            }
            else
            {
                string field = nd.SelectSingleNode("FieldRef").Attributes["Name"].Value;

                SPField oField = list.Fields.GetFieldByInternalName(field);

                if (nd.Name == "IsNull" && oField.Type != SPFieldType.Lookup)
                {
                    return field + " is null";
                }
                else
                {
                    XmlNode ndVals = null;
                    try
                    {
                        ndVals = nd.SelectSingleNode("Values");
                    }
                    catch { }

                    if (ndVals != null)
                    {
                        string vals = "(";

                        if (oField.Type == SPFieldType.Lookup || oField.Type == SPFieldType.User)
                        {
                            field += "Text";
                        }

                        if (ndVals.SelectNodes("Value").Count > 0)
                        {
                            foreach (XmlNode ndVal in ndVals.SelectNodes("Value"))
                            {
                                vals += field + " = '" + ndVal.InnerText.Replace("'","''") + "' OR ";
                            }
                        }
                        else
                        {
                            vals += field + " = ''";
                        }

                        return vals.Trim(' ').Trim('R').Trim('O') + ")";
                    }
                    else
                    {
                        string val = string.Empty;
                        // Avoiding NULL value when nothing is provided for filter value
                        if (nd.SelectSingleNode("Value") != null)
                        {
                            val = nd.SelectSingleNode("Value").InnerText;
                        }

                        bool bLookup = false;
                        SPFieldType fieldType = SPFieldType.Text;

                        switch (oField.Type)
                        {
                            case SPFieldType.Calculated:
                                {
                                    // Multiply by 100 if show as percentage true
                                    if (((SPFieldCalculated)oField).ShowAsPercentage)
                                    {
                                        val = Convert.ToString(double.Parse(val) * 100);
                                    }
                                }
                                break;
                            case SPFieldType.DateTime:
                                {
                                    // Converting value to ShortDate string from LongDate string
                                    // because SharePoint also does not consider the time part in view filter settings so ignoring it
                                    val = DateTime.Parse(val).ToString("d");
                                }
                                break;
                            case SPFieldType.Lookup:
                                {
                                    try
                                    {
                                        SPFieldLookup lookupField = oField as SPFieldLookup;
                                        SPList lookupList = lookupField.ParentList.ParentWeb.Lists[new Guid(lookupField.LookupList)];
                                        fieldType = lookupList.Fields.GetFieldByInternalName(lookupField.LookupField.ToString()).Type;
                                        // Check if field type is text / number
                                        if (fieldType.Equals(SPFieldType.Integer) || fieldType.Equals(SPFieldType.Counter))
                                            field += "ID";
                                        else
                                            field += "Text";
                                    }
                                    catch
                                    {
                                        field += "Text";
                                    }
                                }
                                break;
                            case SPFieldType.User:
                                {
                                    bLookup = true;
                                    if (nd.Name == "Contains")
                                        field += "Text";
                                    else
                                        field += "ID";
                                }
                                break;
                        }

                        if (nd.SelectSingleNode("Value") != null && nd.SelectSingleNode("Value").SelectSingleNode("UserID") != null)
                        {
                            val = web.CurrentUser.ID.ToString();
                        }
                        if (val.ToLower() == "[today]")
                        {
                            val = DateTime.Now.ToString("s");
                        }

                        if (nd.Name == "BeginsWith")
                        {
                            return field + " Like '" + val + "%'";
                        }
                        else if (nd.Name == "Contains")
                        {
                            return field + " Like '%" + val + "%'";
                        }
                        else if (nd.Name == "Neq")
                        {
                            return "(" + field + " <> '" + val + "' OR " + field + " IS NULL)";
                        }
                        else if (nd.Name == "IsNotNull")
                        {
                            return field + " Is Not Null";
                        }
                        else if (nd.Name == "IsNull")
                        {
                            return field + " Is Null";
                        }
                        else
                        {
                            string sign = GetNodeSign(nd.Name);

                            if (bLookup && sign == "=")
                            {
                                return "',' + CAST(" + field + " as varchar(MAX)) + ',' LIKE '%," + val + ",%'";
                            }
                            else if (oField.Type.Equals(SPFieldType.DateTime))
                            {
                                // Need to use like operator to match only the date part 
                                // and ignore time part from db column value same as SharePoint does.
                                return field + " LIKE '%'+" + " convert(varchar(10), convert(datetime,'" + val + "',101)) " + "+'%'";
                            }
                            else
                            {
                                return field + " " + sign + " '" + val + "'";
                            }
                        }
                    }
                }
            }
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
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT VALUE,listid FROM PERSONALIZATIONS where userid=@userid and [key]=@key and FK=@FK", cn);
                    cmd.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
                    cmd.Parameters.AddWithValue("@key", "ReportFilterWebPartSelections");
                    cmd.Parameters.AddWithValue("@FK", filterWpId);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        reportFilterIDs = new ArrayList(dr.GetString(0).Split('|')[0].Split(','));
                        listid = dr.GetGuid(1);
                    }
                    dr.Close();
                    cn.Close();
                }
                catch { }
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

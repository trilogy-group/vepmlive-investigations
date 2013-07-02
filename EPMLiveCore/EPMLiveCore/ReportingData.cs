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
        public static DataTable GetReportingData(SPWeb web, string list, bool bRollup, string query, string orderby)
        {

            var rb = new EPMLiveReportsAdmin.ReportBiz(web.Site.ID);

            if(rb.SiteExists())
            {
                EPMLiveReportsAdmin.EPMData data = new EPMLiveReportsAdmin.EPMData(web.Site.ID);

                SqlConnection cn = data.GetClientReportingConnection;

                SqlCommand cmd = new SqlCommand("select * from information_schema.parameters where specific_name='spGetReportListData' and parameter_name='@orderby'", cn);
                bool borderby = false;
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
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
                if(borderby)
                    cmd.Parameters.AddWithValue("@orderby", orderby);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                cn.Close();

                return ds.Tables[0];
            }
            else
                throw new Exception("Reporting Not Setup.");
        }

        public static string GetReportQuery(SPWeb web, SPList list, string spquery, out string orderby)
        {
            orderby = "";

            if(spquery == "")
                return "";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Query>" + spquery + "</Query>");

            XmlNode ndWhere = doc.FirstChild.SelectSingleNode("//Where");

            XmlNode ndGroupBy = doc.FirstChild.SelectSingleNode("//OrderBy");

            foreach(XmlNode nd in ndGroupBy.SelectNodes("FieldRef"))
            {
                string orderField = nd.Attributes["Name"].Value;
                if (orderField == "ID")
                    orderField = "ItemID";

                orderby += "," + orderField;

                try
                {
                    if(nd.Attributes["Ascending"].Value.ToLower() == "false")
                        orderby += " DESC";
                }
                catch { }
            }
            orderby = orderby.Trim(',');

            if(ndWhere == null)
                return "";

            string q = GetReportQueryNode(web, ndWhere.FirstChild, list);



            return q;

        }

        private static string GetReportQueryNode(SPWeb web, XmlNode nd, SPList list)
        {

            if(nd.Name == "And")
            {
                return "(" + GetReportQueryNode(web, nd.FirstChild, list) + " And " + GetReportQueryNode(web, nd.FirstChild.NextSibling, list) + ")";
            }
            else if(nd.Name == "Or")
            {
                return "(" + GetReportQueryNode(web, nd.FirstChild, list) + " Or " + GetReportQueryNode(web, nd.FirstChild.NextSibling, list) + ")";
            }
            else
            {


                string field = nd.SelectSingleNode("FieldRef").Attributes["Name"].Value;

                if(nd.Name == "IsNull")
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

                    SPField oField = list.Fields.GetFieldByInternalName(field);



                    if(ndVals != null)
                    {
                        string vals = "(";

                        if(oField.Type == SPFieldType.Lookup || oField.Type == SPFieldType.User)
                        {
                            field += "Text";
                        }

                        if (ndVals.SelectNodes("Value").Count > 0)
                        {
                            foreach (XmlNode ndVal in ndVals.SelectNodes("Value"))
                            {
                                vals += field + " = '" + ndVal.InnerText + "' OR ";
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
                        string val = nd.SelectSingleNode("Value").InnerText;



                        bool bLookup = false;

                        if(oField.Type == SPFieldType.Lookup || oField.Type == SPFieldType.User)
                        {
                            bLookup = true;
                            field += "ID";
                        }

                        if(nd.SelectSingleNode("Value").SelectSingleNode("UserID") != null)
                        {
                            val = web.CurrentUser.ID.ToString();
                        }
                        if(val.ToLower() == "[today]")
                        {
                            val = DateTime.Now.ToString("s");
                        }

                        if(nd.Name == "BeginsWith")
                        {
                            return field + " Like '" + val + "%'";
                        }
                        else if(nd.Name == "Contains")
                        {
                            return field + " Like '%" + val + "%'";
                        }
                        else
                        {
                            string sign = GetNodeSign(nd.Name);

                            if(bLookup && sign == "=")

                                return "',' + CAST(" + field + " as varchar(MAX)) + ',' LIKE '%," + val + ",%'";
                            else
                                return field + " " + sign + " '" + val + "'";
                        }
                    }
                }
            }
        }

        public static string GetNodeSign(string name)
        {
            switch(name.ToLower())
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
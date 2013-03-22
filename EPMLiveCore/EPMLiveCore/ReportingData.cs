using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;

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
                orderby += "," + nd.Attributes["Name"].Value;
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

                        foreach(XmlNode ndVal in ndVals.SelectNodes("Value"))
                        {
                            vals += field + " = '" + ndVal.InnerText + "' OR";
                        }

                        return vals.Trim('R').Trim('O') + ")";
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
    }
}

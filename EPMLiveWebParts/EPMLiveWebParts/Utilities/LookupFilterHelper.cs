using System;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Xml;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.Utilities
{
    public class LookupFilterHelper
    {
        public static void AppendLookupQueryToExistingQuery(ref XmlDocument xmlQuery, string lookupField, string lookupFieldList)
        {
            var web = SPContext.Current.Web;

            if (string.IsNullOrEmpty(lookupField) || String.IsNullOrEmpty(lookupFieldList)) return;

            ArrayList lookupFilterIDs = null;
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                {
                    var cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                    cn.Open();

                    var cmd = new SqlCommand("SELECT VALUE FROM PERSONALIZATIONS where userid=@userid and [key]=@key and listid=@listid", cn);
                    cmd.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
                    cmd.Parameters.AddWithValue("@key", "LIP");
                    cmd.Parameters.AddWithValue("@listid", lookupFieldList);
                    cmd.ExecuteNonQuery();
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lookupFilterIDs = new ArrayList(dr.GetString(0).Split(','));
                    }
                    dr.Close();
                    cn.Close();
                }
            });

            XmlNode ndWhere = null;
            ndWhere = xmlQuery.SelectSingleNode("Where");
            if (ndWhere == null)
            {
                ndWhere = xmlQuery.CreateElement("Where");
                xmlQuery.FirstChild.PrependChild(ndWhere);

                ndWhere.InnerXml = "<In><FieldRef Name=\"" + lookupField + "\"/><Values>" + GetLookupValuesQuery(lookupFilterIDs) + "</Values></In>";
            }
            else
            {
                ndWhere.InnerXml = "<And><In><FieldRef Name=\"" + lookupField + "\"/><Values>" + GetLookupValuesQuery(lookupFilterIDs) + "</Values></In>" + ndWhere.InnerXml + "</And>";
            }
        }

        private static string GetLookupValuesQuery(IEnumerable lookupFilterIDs)
        {
            var sb = new StringBuilder();
            foreach (string s in lookupFilterIDs)
            {
                sb.Append("<Value Type=\"Text\">");
                sb.Append(HttpUtility.HtmlEncode(s));
                sb.Append("</Value>");
            }

            return sb.ToString();
        }         
    }
}
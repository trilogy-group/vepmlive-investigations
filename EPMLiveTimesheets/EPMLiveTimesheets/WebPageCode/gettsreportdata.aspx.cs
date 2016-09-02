using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;

using System.Net.Mail;

namespace TimeSheets
{
    public partial class gettsreportdata : System.Web.UI.Page
    {
        protected GridView listGrid;

        private DataTable dtRollup = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                cn.Open();
            });
            if (cn != null)
            {
                SPWeb web = SPContext.Current.Web;

                string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);

                if (resUrl != "")
                {
                    SPWeb resWeb = null;
                    try
                    {
                        if (resUrl.ToLower() != web.Url.ToLower())
                        {
                            using (SPSite tempSite = new SPSite(resUrl))
                            {

                                resWeb = tempSite.OpenWeb();
                                if (resWeb.Url.ToLower() != resUrl.ToLower())
                                {
                                    resWeb = null;
                                }
                            }
                        }
                        else
                            resWeb = web;
                    }
                    catch { }

                    if (resWeb != null)
                    {
                        switch (Request["Report"])
                        {
                            case "1":
                                try
                                {
                                    SPList list = resWeb.Lists["Resources"];

                                    SPQuery query = new SPQuery();
                                    query.Query = "<Where><Eq><FieldRef Name='TimesheetManager'/><Value Type='User'><UserID/></Value></Eq></Where>";

                                    SPListItemCollection lic = list.GetItems(query);

                                    foreach (SPListItem li in lic)
                                    {
                                        string username = "";
                                        string name = "";
                                        try
                                        {
                                            string user = li["SharePointAccount"].ToString();
                                            SPFieldUserValue uv = new SPFieldUserValue(resWeb, user);
                                            username = uv.User.LoginName;
                                            name = uv.User.Name;
                                        }
                                        catch { }
                                        if (username != "")
                                        {
                                            SqlCommand cmd = new SqlCommand("spTSData", cn);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@siteuid", web.Site.ID);
                                            cmd.Parameters.AddWithValue("@username", username);
                                            cmd.Parameters.AddWithValue("@start", Request["start"]);
                                            cmd.Parameters.AddWithValue("@end", Request["end"]);
                                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                                            DataTable dttemp = new DataTable();
                                            da.Fill(dttemp);
                                            dtRollup.Merge(dttemp, false, MissingSchemaAction.Add);
                                        }
                                    }
                                }
                                catch { }
                                break;
                            case "2":
                                try
                                {
                                    SPList list = resWeb.Lists["Resources"];

                                    SPQuery query = new SPQuery();
                                    query.Query = "<Where><Eq><FieldRef Name='SharePointAccount'/><Value Type='User'><UserID/></Value></Eq></Where>";

                                    SPListItemCollection lic = list.GetItems(query);

                                    if (lic.Count > 0)
                                    {
                                        try
                                        {
                                            if (lic[0]["TimesheetAdministrator"].ToString().ToLower() == "true")
                                            {
                                                foreach (SPListItem li in list.Items)
                                                {
                                                    string username = "";
                                                    string name = "";
                                                    try
                                                    {
                                                        string user = li["SharePointAccount"].ToString();
                                                        SPFieldUserValue uv = new SPFieldUserValue(resWeb, user);
                                                        username = uv.User.LoginName;
                                                        name = uv.User.Name;
                                                    }
                                                    catch { }
                                                    if (username != "")
                                                    {
                                                        SqlCommand cmd = new SqlCommand("spTSData", cn);
                                                        cmd.CommandType = CommandType.StoredProcedure;
                                                        cmd.Parameters.AddWithValue("@siteuid", web.Site.ID);
                                                        cmd.Parameters.AddWithValue("@username", username);
                                                        cmd.Parameters.AddWithValue("@start", Request["start"]);
                                                        cmd.Parameters.AddWithValue("@end", Request["end"]);
                                                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                                                        DataTable dttemp = new DataTable();
                                                        da.Fill(dttemp);
                                                        dtRollup.Merge(dttemp, false, MissingSchemaAction.Add);
                                                    }
                                                }
                                            }
                                        }
                                        catch { }
                                    }

                                    
                                }
                                catch { }
                                break;
                            case "3":
                                try
                                {
                                    SPList list = resWeb.Lists["Resources"];

                                    SPQuery query = new SPQuery();
                                    query.Query = "<Where><Eq><FieldRef Name='SharePointAccount'/><Value Type='User'><UserID/></Value></Eq></Where>";

                                    SPListItemCollection lic = list.GetItems(query);

                                    if (lic.Count > 0)
                                    {
                                        try
                                        {
                                            foreach (SPListItem li in lic)
                                            {
                                                string username = "";
                                                string name = "";
                                                try
                                                {
                                                    string user = li["SharePointAccount"].ToString();
                                                    SPFieldUserValue uv = new SPFieldUserValue(resWeb, user);
                                                    username = uv.User.LoginName;
                                                    name = uv.User.Name;
                                                }
                                                catch { }
                                                if (username != "")
                                                {
                                                    SqlCommand cmd = new SqlCommand("spTSData", cn);
                                                    cmd.CommandType = CommandType.StoredProcedure;
                                                    cmd.Parameters.AddWithValue("@siteuid", web.Site.ID);
                                                    cmd.Parameters.AddWithValue("@username", username);
                                                    cmd.Parameters.AddWithValue("@start", Request["start"]);
                                                    cmd.Parameters.AddWithValue("@end", Request["end"]);
                                                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                                                    DataTable dttemp = new DataTable();
                                                    da.Fill(dttemp);
                                                    dtRollup.Merge(dttemp, false, MissingSchemaAction.Add);
                                                }
                                            }
                                        }
                                        catch { }
                                    }


                                }
                                catch { }
                                break;
                        };
                        if (resWeb.ID != SPContext.Current.Web.ID)
                            resWeb.Close();
                    }
                }
                


                cn.Close();
                listGrid.DataSource = dtRollup;
                listGrid.DataBind();
            }
        }
    }
}

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
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;

namespace EPMLiveCore
{
    public partial class viewmessages : LayoutsPageBase
    {

        protected string output;
        protected Label lblTitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;
            {
                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn.Open();
                });

                SqlCommand cmd = new SqlCommand("select resulttext from vwQueueTImerLog where jobtype=@log_type and siteguid = @siteguid and listguid is null", cn);
                cmd.Parameters.AddWithValue("@log_type", Request["type"]);
                cmd.Parameters.AddWithValue("@siteguid", site.ID);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    output = dr.GetString(0);
                }
                dr.Close();

                cn.Close();

                switch (Request["type"])
                {
                    case "1":
                        lblTitle.Text = "Resource Plan";
                        break;
                    case "2":
                        lblTitle.Text = "Today Fix";
                        break;
                    case "3":
                        lblTitle.Text = "Notifications";
                        break;
                    case "4":
                        lblTitle.Text = "Admin Synch";
                        break;
                    case "5":
                        lblTitle.Text = "Reporting Refresh";
                        break;
                    case "7":
                        lblTitle.Text = "Reporting Snapshot";
                        break;
                };
            }

        }
    }
}
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
using System.Data.SqlClient;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveEnterprise
{
    public partial class esynchlog : LayoutsPageBase
    {

        protected string output;

        protected void Page_Load(object sender, EventArgs e)
        {


            SqlConnection cn = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                cn.Open();
            });

            SqlCommand cmd = new SqlCommand("select resulttext from vwQueueTimerLog where siteguid=@siteguid and jobtype=9", cn);
            cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                output = dr.GetString(0);
            }
            dr.Close();

            cn.Close();
                        
        }
    }
}
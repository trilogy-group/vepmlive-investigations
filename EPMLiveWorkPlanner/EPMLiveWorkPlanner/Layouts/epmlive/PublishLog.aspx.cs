using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class PublishLog : LayoutsPageBase
    {
        protected string sStatus = "";
        protected string sLog = "";
        protected string sPublished = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });

            SqlCommand cmd = new SqlCommand("select timerjobuid,runtime,percentComplete,status,dtfinished,result,resulttext from vwQueueTimerLog where listguid=@listguid and itemid=@itemid", cn);
            cmd.Parameters.AddWithValue("@listguid", Request["ListId"]);
            cmd.Parameters.AddWithValue("@itemid", Request["ID"]);
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                sStatus = dr.GetString(5);
                sLog = dr.GetString(6);
                sPublished = dr.GetDateTime(4).ToString();
            }

            cn.Close();
        }
    }
}

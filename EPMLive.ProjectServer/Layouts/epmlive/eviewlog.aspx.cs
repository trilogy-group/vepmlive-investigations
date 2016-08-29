using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EPMLiveEnterprise.Layouts.epmlive
{
    public partial class eviewlog : LayoutsPageBase
    {
        protected Label lblLog;
        protected Label lblStatus;
        protected Label lblDate;

        protected string sProjectName;

        protected void Page_Load(object sender, EventArgs e)
        {

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                cn.Open();
                SqlCommand cmd = new SqlCommand("select projectname,logtext,[status],laststatusdate from vwGetProjectStatus where projectguid=@projectid", cn);
                cmd.Parameters.AddWithValue("@projectid", Request["projectid"]);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(1))
                        lblLog.Text = dr.GetString(1);
                    if (!dr.IsDBNull(0))
                        sProjectName = dr.GetString(0);
                    if (!dr.IsDBNull(2))
                        lblStatus.Text = dr.GetString(2);
                    if (!dr.IsDBNull(3))
                        lblDate.Text = dr.GetDateTime(3).ToString();
                }
                dr.Close();



                cn.Close();

            });
        }
    }
}

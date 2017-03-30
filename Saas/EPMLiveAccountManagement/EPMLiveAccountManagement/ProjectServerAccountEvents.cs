using System;
using System.Data.SqlClient;

namespace EPMLiveAccountManagement
{
    class ProjectServerAccountEvents : Microsoft.Office.Project.Server.Events.ResourceEventReceiver
    {
        public override void OnChanging(Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, Microsoft.Office.Project.Server.Events.ResourceUpdatePreEventArgs e)
        {
            return;
            string account = "";
            try
            {
                account = e.ResourceInformation.Resources[0].WRES_ACCOUNT;
            }
            catch { }
            
            string message = "";

            if (account != "" && !checkUser(account, contextInfo.SiteGuid, out message))
            {
                //e.Cancel = true;
                //e.CancelReason = message;
                e.CancelEvent(message);
            }

        }

        public override void OnCreating(Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, Microsoft.Office.Project.Server.Events.ResourceCreatePreEventArgs e)
        {
            return;
            string account = "";
            try
            {
                account = e.ResourceInformation.Resources[0].WRES_ACCOUNT;
            }
            catch { }

            string message = "";

            if (account != "" && !checkUser(account, contextInfo.SiteGuid, out message))
            {
                //e.Cancel = true;
                //e.CancelReason = message;
                e.CancelEvent(message);
            }
        }

        public override void OnDeleting(Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, Microsoft.Office.Project.Server.Events.ResourceDeletePreEventArgs e)
        {
            
        }

        private bool checkUser(string account, Guid siteid, out string message)
        {
            bool success = false;
            message = "";
            try
            {
                if (account != "")
                {
                    SqlConnection cn = new SqlConnection(Settings.getConnectionString());

                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select * from vwSiteUsers where username=@username and siteguid=@siteid", cn);
                    cmd.Parameters.AddWithValue("@username", account);
                    cmd.Parameters.AddWithValue("@siteid", siteid);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        success = true;
                    else
                        message = "That user has not been added to your account. You will need to first add that user to your account by navigating to people and groups.";
                    dr.Close();
                    cn.Close();
                }
                else
                    success = true;
            }
            catch (Exception ex)
            {
                success = false;
                message = "Error verifying user: " + ex.Message;
            }
            return success;
        }
    }
}

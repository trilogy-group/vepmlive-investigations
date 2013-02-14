using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace EPMLiveSynch
{
    public partial class Synch : System.Web.UI.Page
    {
        private XmlDocument doc = new XmlDocument();
        protected string data;

        
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            //int iOldSessionTimeout = Session.Timeout;
            //try
            //{
            //    int iNewTimeout;
            //    int.TryParse(System.Configuration.ConfigurationManager.AppSettings["AdminSyncTimeout"].ToString(), out iNewTimeout);
            //    Session.Timeout = iNewTimeout;
            //}
            //catch { }
            using (SPWeb web = SPContext.Current.Web)
            {
                string sUser = SPContext.Current.Web.CurrentUser.Name;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    try
                    {
                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn.Open();
                        });

                        SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where listguid=@listguid and jobtype=4", cn);
                        cmd.Parameters.AddWithValue("@listguid", new Guid(Request["listorurl"]));
                        SqlDataReader dr = cmd.ExecuteReader();

                        Guid tJob = Guid.Empty;

                        if (!dr.Read())
                        {
                            tJob = Guid.NewGuid();
                            dr.Close();
                            cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid) VALUES (@timerjobuid, @siteguid, 4, 'Enterprise List Synch', 9, @webguid, @listguid)", cn);
                            cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                            cmd.Parameters.AddWithValue("@webguid", web.ID.ToString());
                            cmd.Parameters.AddWithValue("@listguid", new Guid(Request["listorurl"]));
                            cmd.Parameters.AddWithValue("@timerjobuid", tJob);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            tJob = dr.GetGuid(0);
                            dr.Close();
                        }

                        if (tJob != Guid.Empty)
                        {
                            EPMLiveCore.CoreFunctions.enqueue(tJob, 0);
                        }

                        cn.Close();

                        //EPMLiveCore.CoreFunctions.enqueue(EPMLiveCore.QueueType.AdminListSynch, "", new Guid(Request["listorurl"]), null, 0);

                        data = "Success";
                    }
                    catch (Exception ex)
                    {
                        data = "Error: " + ex.Message;
                    }
                });
            }


            

            //Session.Timeout = iOldSessionTimeout;

            //data = sResult + ": " + sResults;
        }

    }
}
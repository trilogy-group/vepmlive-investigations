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
                        using (var cmdSelect = new SqlCommand("select timerjobuid from timerjobs where listguid=@listguid and jobtype=4", cn))
                        {
                            cmdSelect.Parameters.AddWithValue("@listguid", new Guid(Request["listorurl"]));

                            using (var dataReader = cmdSelect.ExecuteReader())
                            {
                                var timerJobId = Guid.Empty;

                                if (!dataReader.Read())
                                {
                                    timerJobId = Guid.NewGuid();
                                    dataReader.Close();
                                    using (var cmdInsert = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid) VALUES (@timerjobuid, @siteguid, 4, 'Enterprise List Synch', 9, @webguid, @listguid)", cn))
                                    {
                                        cmdInsert.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                                        cmdInsert.Parameters.AddWithValue("@webguid", web.ID.ToString());
                                        cmdInsert.Parameters.AddWithValue("@listguid", new Guid(Request["listorurl"]));
                                        cmdInsert.Parameters.AddWithValue("@timerjobuid", timerJobId);
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    timerJobId = dataReader.GetGuid(0);
                                    dataReader.Close();
                                }

                                if (timerJobId != Guid.Empty)
                                {
                                    EPMLiveCore.CoreFunctions.enqueue(timerJobId, 0);
                                }
                            }
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
using System;
using System.Data.SqlClient;
using System.Web;
using System.Xml;
using Microsoft.SharePoint;
using SystemTrace = System.Diagnostics.Trace;

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

            using (SPWeb web = SPContext.Current.Web)
            {
                var currentUser = SPContext.Current.Web.CurrentUser.Name;

                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    try
                    {
                        using (var connection = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate ()
                            {
                                connection.Open();
                            });

                            using (var cmdSelect = new SqlCommand("select timerjobuid from timerjobs where listguid=@listguid and jobtype=4", connection))
                            {
                                cmdSelect.Parameters.AddWithValue("@listguid", new Guid(Request["listorurl"]));

                                using (var dataReader = cmdSelect.ExecuteReader())
                                {
                                    var timerJobId = Guid.Empty;

                                    if (!dataReader.Read())
                                    {
                                        timerJobId = Guid.NewGuid();
                                        dataReader.Close();
                                        using (var cmdInsert = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid) VALUES (@timerjobuid, @siteguid, 4, 'Enterprise List Synch', 9, @webguid, @listguid)", connection))
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

                            connection.Close();
                        }

                        data = "Success";
                    }
                    catch (Exception ex)
                    {
                        SystemTrace.WriteLine(ex.ToString());
                        data = "Error: " + ex.Message;
                    }
                });
            }
        }
    }
}
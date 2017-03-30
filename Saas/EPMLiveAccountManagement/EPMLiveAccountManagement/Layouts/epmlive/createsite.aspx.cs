using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Threading;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class createsite : LayoutsPageBase
    {
        protected string output = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["siteURL"].ToString() + Request["siteurl"];
            string title = Request["sitetitle"];
            string template = System.Configuration.ConfigurationManager.AppSettings["templatepath"].ToString().Replace("\\\\", "\\") + "\\" + Request["template"];
            string description = Request["description"];
            string account = Request["account"];

            if (url == "")
            {
                output = "Please enter a url";
                return;
            }

            if (title == "")
            {
                output = "Please enter a title";
                return;
            }

            try
            {
                //string err = createSite(txtTitle.Text, txtURL.Text, ddlSolution.SelectedValue, ddlSolution.SelectedValue);

                SPUser spuser = SPContext.Current.Web.CurrentUser;
                string user = spuser.LoginName;
                string fullName = spuser.Name;
                string email = spuser.Email;

                Guid newsiteguid = Guid.NewGuid();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmdAddUserSite;

                    SqlConnection cn2 = new SqlConnection(Settings.getConnectionString());
                    cn2.Open();

                    cmdAddUserSite = new SqlCommand("select firstname, lastname from users where username=@username", cn2);
                    cmdAddUserSite.Parameters.AddWithValue("@username", EPMLiveCore.CoreFunctions.GetRealUserName(user));
                    SqlDataReader dru = cmdAddUserSite.ExecuteReader();
                    string firstname = "";
                    string lastname = "";

                    if(dru.Read())
                    {
                        firstname = dru.GetString(0);
                        lastname = dru.GetString(1);
                    }
                    dru.Close();
                    cn2.Close();

                    cmdAddUserSite = new SqlCommand("INSERT INTO NEWSITEQUEUE (newsitequeue_id,siteurl,sitename,sitedesc,template,ownerlogin,firstname,lastname,ownername,owneremail,account,blevel) VALUES (@newsitequeue_id,@siteurl,@sitename,@sitedesc,@template,@ownerlogin,@firstname,@lastname,@ownername,@owneremail,@account,@blevel)", cn);
                    cmdAddUserSite.Parameters.AddWithValue("@newsitequeue_id", newsiteguid);
                    cmdAddUserSite.Parameters.AddWithValue("@siteurl", url);
                    cmdAddUserSite.Parameters.AddWithValue("@sitename", title);
                    cmdAddUserSite.Parameters.AddWithValue("@sitedesc", description);
                    cmdAddUserSite.Parameters.AddWithValue("@template", template);
                    cmdAddUserSite.Parameters.AddWithValue("@ownername", fullName);
                    cmdAddUserSite.Parameters.AddWithValue("@firstname", firstname);
                    cmdAddUserSite.Parameters.AddWithValue("@lastname", lastname);
                    cmdAddUserSite.Parameters.AddWithValue("@owneremail", email);
                    cmdAddUserSite.Parameters.AddWithValue("@ownerlogin", user);
                    cmdAddUserSite.Parameters.AddWithValue("@account", account);
                    cmdAddUserSite.Parameters.AddWithValue("@blevel", Settings.getContractLevel());
                    
                    cmdAddUserSite.ExecuteNonQuery();

                    int counter = 0;

                    while (counter < 60)
                    {
                        Thread.Sleep(1000);

                        SqlCommand cmd;
                        cmd = new SqlCommand("select status, message from newsitequeue where newsitequeue_id=@id", cn);
                        cmd.Parameters.AddWithValue("@id", newsiteguid);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            int status = dr.GetInt32(0);
                            string message = "";
                            if(!dr.IsDBNull(1))
                                message = dr.GetString(1);

                            if (status == 1)
                            {
                                output = "Success";
                                dr.Close();
                                break;
                            }
                            else if (status == 2)
                            {
                                output = message;
                                dr.Close();
                                break;
                            }
                            dr.Close();
                        }
                        else
                        {
                            output = "Failed to read status";
                            dr.Close();
                            break;
                        }
                    }

                    cn.Close();
                });
            }
            catch (Exception ex)
            {
                output = "Error: " + ex.Message;
            }
        }
    }
}

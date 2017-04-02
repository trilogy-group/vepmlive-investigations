using System;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint;
using System.Data.SqlClient;
using System.Data;

namespace EPMLiveAccountManagement
{
    public class AccountModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute
              += new EventHandler(context_PreRequestHandlerExecute);
        }

        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;

            string redir = "";
            try
            {
                redir = System.Configuration.ConfigurationManager.AppSettings["homeredirect"].ToString();
            }
            catch { }
            if (redir != "")
            {
                try
                {
                    string[] sredir = redir.Split(',');
                    if (HttpContext.Current.Request.Url.ToString() == sredir[0])
                        HttpContext.Current.Response.Redirect(sredir[1]);
                }
                catch { }
            }

            if (page != null)
            {
                // register handler for PreInit event
                page.PreInit += new EventHandler(page_PreInit);
            }
        }

        void page_PreInit(object sender, EventArgs e)
        {
            string dlg = "";
            
            string redirect = "";
            SPSite site = null;
            Page page = null;
            try
            {
                page = sender as Page;
            }
            catch { }

            string username = "";
            try
            {
                username = EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName);
            }catch{}

            string ignoreuser = "";
            try
            {
                ignoreuser = System.Configuration.ConfigurationManager.AppSettings["ignoreuser"].ToString();
            }
            catch { }

            try
            {

                if (page.Request["isDlg"] == "1")
                    dlg = "?isDlg=1";
                if(username == "SHAREPOINT\\system" || username == ignoreuser)
                    return;
                
                try
                {
                    site = SPContext.Current.Site;
                }
                catch { }

                if(site != null)
                {
                    

                    bool bIsResPool = false;

                    try
                    {
                        if(SPContext.Current.List.Title == "Resources")
                            bIsResPool = true;
                    }
                    catch { }

                    if(page.AppRelativeVirtualPath.ToLower().Contains("~/_layouts/epmlive/createnewworkspace.aspx"))
                    {
                    }
                    else
                    {
                        if(page.AppRelativeVirtualPath.ToLower().Contains("~/_layouts/"))
                            return;

                        if(page.AppRelativeVirtualPath.ToLower().Contains("~/_layouts/epmlive"))
                            return;
                    }

                    if (page.AppRelativeVirtualPath.ToLower().Contains("~/_layouts/accessdenied.aspx"))
                        return;

                    if(page.AppRelativeVirtualPath.ToLower().Contains("~/_layouts/authenticate.aspx"))
                        return;

                    if(page.AppRelativeVirtualPath.ToLower().Contains("~/_forms/"))
                        return;

                    SPWeb web = SPContext.Current.Web;

                    if (Settings.getConnectionString() == null)
                    {
                        redirect = site.Url + "/_layouts/epmlive/amerror.aspx?error=No Connect String Defined";
                    }
                    else
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            SqlConnection cn = new SqlConnection(Settings.getConnectionString());

                            cn.Open();

                            string cLevel = Settings.getContractLevel();


                            SqlCommand cmd = new SqlCommand("2012SP_GetActivationInfo", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@siteid", site.ID);
                            cmd.Parameters.AddWithValue("@username", "");

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(ds);
                            int ActivationType = 0;
                            try
                            {
                                ActivationType = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                            }
                            catch { }

                            cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@siteid", site.ID);
                            cmd.Parameters.AddWithValue("@contractLevel", cLevel);
                            SqlDataReader dr = cmd.ExecuteReader();

                            int inTrial = 0;
                            int daysLeft = 0;
                            bool expired = true;
                            int accountref = 0;
                            int minBuy = 1;
                            int max = 0;

                            if(dr.Read())
                            {
                                inTrial = dr.GetInt32(4);
                                try
                                {
                                    expired = dr.GetBoolean(6);
                                }
                                catch { }
                                try
                                {
                                    daysLeft = dr.GetInt32(7);
                                }
                                catch { }
                                try
                                {
                                    accountref = dr.GetInt32(10);
                                }
                                catch { }
                                try
                                {
                                    minBuy = dr.GetInt32(1);
                                }
                                catch { }
                                try
                                {
                                    max = dr.GetInt32(0);
                                }
                                catch { }
                            }
                            dr.Close();

                            cmd = new SqlCommand("SP_IsUserInAccountSite", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@siteuid", site.ID);
                            cmd.Parameters.AddWithValue("@username", username);

                            dr = cmd.ExecuteReader();

                            bool bIsInAccount = false;

                            if(dr.Read())
                            {
                                if(dr.GetInt32(0) > 0)
                                {
                                    bIsInAccount = true;
                                }
                            }
                            dr.Close();

                            int pMax = 0;

                            if(cLevel == "3")
                            {
                                cmd = new SqlCommand("2010SP_GetSiteProjectMax", cn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@siteid", site.ID);
                                cmd.Parameters.AddWithValue("@contractLevel", cLevel);
                                dr = cmd.ExecuteReader();
                                if(dr.Read())
                                {
                                    if(!dr.IsDBNull(0))
                                        pMax = dr.GetInt32(0);
                                }
                                dr.Close();
                            }

                            cn.Close();

                            //page.FindControl("");

                            if (accountref == 0)
                            {
                                redirect = site.Url + "/_layouts/epmlive/nolink.aspx";
                                //page.Response.Filter = new AdStream(page.Response.Filter, "Your site with ID: " + site.ID + " is not associated with an account");
                            }
                            else if(expired || max == 0 && !bIsResPool)
                            {
                                redirect = site.Url + "/_layouts/epmlive/expired.aspx";
                            }
                            else
                            {
                                if(!bIsInAccount)
                                {
                                    redirect = site.Url + "/_layouts/epmlive/notinaccount.aspx";
                                }
                            }
                            if(cLevel == "3")
                            {
                                if(page.AppRelativeVirtualPath.ToLower().Contains("~/_layouts/epmlive/createnewworkspace.aspx") && pMax >= 0)
                                {
                                    string []arrGroupFields = new string[0];

                                    SPSecurity.RunWithElevatedPrivileges(delegate()
                                    {
                                        using(SPSite isite = new SPSite(web.Site.ID))
                                        {
                                            using(SPWeb iweb = isite.OpenWeb())
                                            {
                                                //SPList list = iweb.Lists.TryGetList("Project Center");
                                                //if(list != null)
                                                {
                                                    
                                                    //DataTable dt = EPMLiveCore.CoreFunctions.getSiteItems(iweb, list.DefaultView, "", "", "", "Project Center", arrGroupFields);

                                                    if((isite.AllWebs.Count - 1) >= pMax)
                                                    {
                                                        redirect = site.Url + "/_layouts/epmlive/pebuynow.aspx?isdlg=1";
                                                    }
                                                }
                                            }
                                        }
                                    });
                                }
                            }
                            /*switch (page.AppRelativeVirtualPath)
                            {
                                case "~/_layouts/mngsiteadmin.aspx":
                                case "~/_layouts/people.aspx":
                                    {
                                        string ignoreuser = "";
                                        try
                                        {
                                            ignoreuser = System.Configuration.ConfigurationManager.AppSettings["epmliveadminuser"].ToString();
                                        }
                                        catch { }
                                        if (ignoreuser == "")
                                            redirect = getResourceUrl(web);
                                        else
                                        {
                                            if (username.ToLower() != ignoreuser.ToLower())
                                                redirect = getResourceUrl(web);
                                        }
                                    }
                                    break;
                                case "~/_layouts/aclinv.aspx":
                                    if (page.Request["obj"] == null || page.Request["obj"] == "")
                                    {
                                        string ignoreuser = "";
                                        try
                                        {
                                            ignoreuser = System.Configuration.ConfigurationManager.AppSettings["epmliveadminuser"].ToString();
                                        }
                                        catch { }
                                        if (ignoreuser == "")
                                            redirect = getResourceUrl(web);
                                        else
                                        {
                                            if(username.ToLower() != ignoreuser.ToLower())
                                                redirect = getResourceUrl(web);
                                        }
                                    }
                                    break;
                            }*/
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                if(site != null)
                    redirect = site.Url + "/_layouts/epmlive/amerror.aspx?error=" + ex.Message;
            }
            try
            {
                if (redirect != "")
                {
                    if(redirect.Contains("?"))
                    {
                        dlg = dlg.Replace("?", "&");
                    }

                    page.Response.Redirect(redirect + dlg);
                    
                }
            }
            catch { }
        }

        private string getResourceUrl(SPWeb web)
        {
            string resUrl = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    using(SPWeb aweb = site.OpenWeb(web.ID))
                    {
                        resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(aweb, "EPMLiveResourceURL", true, false);
                    }
                }
            });
            return resUrl;
        }
        #endregion
        
        public void Application_Error(object sender, EventArgs e)
        {            
            
        }
    }
}

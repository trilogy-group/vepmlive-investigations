using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace EPMLiveAccountManagement
{
    public partial class newsitecollection : LayoutsPageBase
    {
        public string strTitle;
        public string strTemplate;
        public static Hashtable desc;
        protected string baseSiteUrl;
        protected string weburl;

        SPWeb mySite = SPContext.Current.Web;

        protected void Page_Load(object sender, EventArgs e)
        {
            baseSiteUrl = System.Configuration.ConfigurationManager.AppSettings["siteURL"].ToString();
            weburl = weburl = SPContext.Current.Web.ServerRelativeUrl;
            if(weburl == "/")
                weburl = "";
            //if (!canCreateSites())
            //    Response.Redirect(mySite.Url + "/_layouts/accessdenied.aspx");

            //Button1.Attributes.Add("onclick", "javascript:" +
            //          Button1.ClientID + ".disabled=true;" +
            //          this.GetPostBackEventReference(Button1));

            //Button1.Attributes.Add("onclick", "createSite();");

            if (!IsPostBack)
            {
                desc = new Hashtable();
                //populateTemplates();
                string[] files = Directory.GetDirectories(System.Configuration.ConfigurationManager.AppSettings["templatepath"].ToString());
                foreach (string file in files)
                {
                    string template = Path.GetFileName(file);
                    ListItem li = new ListItem(template, template);
                    this.ddlSolution.Items.Add(li);
                }

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = new SqlConnection(Settings.getConnectionString());
                    cn.Open();

                    SqlCommand cmdGetSites;

                    string username = EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName);
                    if (username.Split('|').Length > 1)
                        username = username.Split('|')[1];

                    cmdGetSites = new SqlCommand("SELECT     dbo.ACCOUNT.accountDescription, dbo.ACCOUNT.account_id FROM         dbo.ACCOUNT INNER JOIN dbo.USERS ON dbo.ACCOUNT.owner_id = dbo.USERS.uid where username like @username", cn);
                    cmdGetSites.Parameters.AddWithValue("@username", username);

                    SqlDataReader dr = cmdGetSites.ExecuteReader();
                    while (dr.Read())
                    {
                        ddlAccount.Items.Add(new ListItem(dr.GetString(0), dr.GetGuid(1).ToString()));
                    }

                    cn.Close();
                });
            }
            /*string title = "";
            string template = "";
            if (IsPostBack)
            {
                try
                {
                    title = txtTitle.Value;
                }
                catch (Exception ex)
                { title = ""; }
                if (title != "")
                {
                    string ret = createSite(title, ddlSolution.SelectedValue);
                    if (ret == "0")
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = true;
                        Response.Redirect("newsite.aspx?URL=" + System.Configuration.ConfigurationManager.AppSettings["siteURL"].ToString() + title);
                        //HyperLink1.NavigateUrl = System.Configuration.ConfigurationManager.AppSettings["siteURL"].ToString() + title;
                        //HyperLink1.Text = System.Configuration.ConfigurationManager.AppSettings["siteURL"].ToString() + title;
                    }
                    else
                    {
                        //Panel1.Visible = true;
                        Panel2.Visible = false;
                        Panel4.Visible = true;
                        Label1.Text = ret;
                    };
                }
            }
            //else
                //populateTemplates();*/
        }

        private bool canCreateSites()
        {
            SqlConnection cn = new SqlConnection(Settings.getConnectionString());
            cn.Open();

            SqlCommand cmdGetSites;

            string username = EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName);
            if (username.Split('|').Length > 1)
                username = username.Split('|')[1];

            cmdGetSites = new SqlCommand("SP_CanCreateSites", cn);
            cmdGetSites.CommandType = CommandType.StoredProcedure;
            cmdGetSites.Parameters.AddWithValue("@USERNAME", username);
            SqlDataAdapter da = new SqlDataAdapter(cmdGetSites);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            if (ds.Tables[0].Rows[0][0].ToString() == "1")
                return true;
            return false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("sites.aspx");
        }

        protected void ddlSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateTemplates();
        }


        protected void lbxTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(Settings.getConnectionString());
            cn.Open();

            SqlCommand cmdAddUserSite;

            cmdAddUserSite = new SqlCommand("SELECT description,image FROM templates where template_name='" + lbxTemplate.SelectedValue.ToString() + "'", cn);
            cmdAddUserSite.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmdAddUserSite);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            lblDesc.Text = ds.Tables[0].Rows[0][0].ToString();
            imgDesc.ImageUrl = "images/" + ds.Tables[0].Rows[0][1].ToString();
        }
        public bool IsAlphaNumeric(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex(@"[^a-zA-Z0-9\s]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            pnlTitle.Visible = false;
            pnlURL.Visible = false;
            pnlURLBad.Visible = false;
            pnlExists.Visible = false;
            pnlSiteCreated.Visible = false;
            if (txtTitle.Text == "")
            {
                pnlTitle.Visible = true;
            }
            else if (txtURL.Text == "")
            {
                pnlURL.Visible = true;
            }
            else if (!IsAlphaNumeric(txtURL.Text))
            {
                pnlURLBad.Visible = true;
            }
            else
            {
                //string err = createSite(txtTitle.Text, txtURL.Text, ddlSolution.SelectedValue, ddlSolution.SelectedValue);
                //if (err == "0")
                //{
                //    hlCreated.Text = System.Configuration.ConfigurationManager.AppSettings["siteURL"].ToString() + txtURL.Text;
                //    hlCreated.NavigateUrl = System.Configuration.ConfigurationManager.AppSettings["siteURL"].ToString() + txtURL.Text;
                //    pnlSiteCreated.Visible = true;
                //    pnlCreate.Visible = false;
                //}
                //else if (err.Contains("Another site already exists"))
                //{
                //    pnlExists.Visible = true;
                //    //Response.Write(err);
                //}
                //else
                //{
                //    //pnlCreate.Visible = false;
                //    Response.Write(err);
                //}
            }
        }

        private void populateTemplates()
        {
            this.lbxTemplate.Items.Clear();
            desc.Clear();
            SqlConnection cn = new SqlConnection(Settings.getConnectionString());
            cn.Open();

            SqlCommand cmdAddUserSite;

            cmdAddUserSite = new SqlCommand("SP_GetTemplates", cn);
            cmdAddUserSite.CommandType = CommandType.StoredProcedure;
            cmdAddUserSite.Parameters.Add("@type", ddlSolution.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmdAddUserSite);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cn.Close();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li = new ListItem(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());
                desc.Add(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString());
                try
                {
                    this.lbxTemplate.Items.Add(li);
                }
                catch (Exception) { }
            }
            lbxTemplate.SelectedIndex = 0;
            lbxTemplate_SelectedIndexChanged(null, null);

        }

        static void EnsureSiteCollectionFeaturesActivated(SPUserSolution solution, SPSite site)
        {
            SPUserSolutionCollection solutions = site.Solutions;
            List<SPFeatureDefinition> oListofFeatures = GetFeatureDefinitionsInSolution(solution, site);
            foreach (SPFeatureDefinition def in oListofFeatures)
            {
                if (((def.Scope == SPFeatureScope.Site) && def.ActivateOnDefault) && (site.Features[def.Id] == null))
                {
                    site.Features.Add(def.Id, false, SPFeatureDefinitionScope.Site);
                    //site.Features.Add(def.Id);


                }
            }
        }
        static List<SPFeatureDefinition> GetFeatureDefinitionsInSolution(SPUserSolution solution, SPSite site)
        {
            List<SPFeatureDefinition> list = new List<SPFeatureDefinition>();
            foreach (SPFeatureDefinition definition in site.FeatureDefinitions)
            {
                if (definition.SolutionId.Equals(solution.SolutionId))
                {
                    list.Add(definition);
                }
            }
            return list;
        }


        /*private string createSite(string title, string url, string template, string templateAlias)
        {
            string error = "0";
            SPUser spuser = SPContext.Current.Web.CurrentUser;
            string user = spuser.LoginName;
            string fullName = spuser.Name;
            string email = spuser.Email;
            string siteguid = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPWebService myWebService = SPWebService.ContentService;

                    SPWebApplication spApp = myWebService.WebApplications[System.Configuration.ConfigurationManager.AppSettings["WebApplication"].ToString()];
                    string bUrl = System.Configuration.ConfigurationManager.AppSettings["siteURL"].ToString();
                    SPSite site = spApp.Sites.Add(bUrl + url, title, "", Convert.ToUInt32(ddlLanguage.SelectedValue), "", user, fullName, email);
                    
                    //SPSite site = spApp.Sites.Add(bUrl + url, user, email);
                    
                    site.AllowUnsafeUpdates = true;
                    SPWeb web = site.OpenWeb();
                    web.Title = title;
                    web.AllowUnsafeUpdates = true;
                    web.Site.AllowUnsafeUpdates = true;
                    web.Site.RootWeb.AllowUnsafeUpdates = true;
                    //SPDocumentLibrary solGallery1 = (SPDocumentLibrary)web.Site.RootWeb.Site.GetCatalog(SPListTemplateType.SolutionCatalog);

                    FileStream fstream = File.OpenRead(System.Configuration.ConfigurationManager.AppSettings["templatepath"].ToString() + template + ".wsp");
                    byte[] content = new byte[fstream.Length];
                    fstream.Read(content, 0, (int)fstream.Length);
                    fstream.Close();
                    web.Files.Add(web.ServerRelativeUrl + "/_catalogs/solutions/" + template + ".wsp", content);

                    SPUserSolution solution = web.Site.Solutions.Add(1);
                    EnsureSiteCollectionFeaturesActivated(solution, web.Site);
                    SPWebTemplate webtemplate = null;
                    foreach (SPWebTemplate t in web.GetAvailableWebTemplates((uint)web.Locale.LCID))
                    {
                        if(t.Title == template)
                        {
                            webtemplate = t;
                            break;
                        }
                    }

                    if(webtemplate != null)
                        web.ApplyWebTemplate(webtemplate);
  
                    web.AllUsers.Add(user, email, fullName, "");
                    //web.AllUsers.Add(System.Configuration.ConfigurationManager.AppSettings["owner"].ToString(), "", System.Configuration.ConfigurationManager.AppSettings["owner"].ToString(), "");
                    web.Users[user].Name = fullName;
                    web.Users[user].Update();

                    web.Update();
                    SPUser owner = web.AllUsers[user];


                    web.SiteGroups.Add("Administrators", owner, owner, "");

                    web.Update();
                    web.AssociatedOwnerGroup = GetSiteGroup(web, "Administrators");
                    SPRole roll = web.Roles["Full Control"];
                    roll.AddGroup(web.SiteGroups["Administrators"]);
                    SPMember newOwner = web.SiteGroups["Administrators"];

                    web.SiteGroups.Add("Team Members", newOwner, owner, "");
                    web.SiteGroups.Add("Visitors", newOwner, owner, "");
                    web.SiteGroups.Add("Project Managers", newOwner, owner, "");
                    web.Update();

                    web.AssociatedVisitorGroup = GetSiteGroup(web, "Visitors");
                    web.AssociatedOwnerGroup = GetSiteGroup(web, "Administrators");
                    web.AssociatedMemberGroup = GetSiteGroup(web, "Team Members");
                    web.Update();

                    web.SiteGroups["Administrators"].Users[user].Name = fullName;
                    web.SiteGroups["Project Managers"].Users[user].Name = fullName;
                    web.SiteGroups["Team Members"].Users[user].Name = fullName;
                    web.SiteGroups["Visitors"].Users[user].Name = fullName;

                    web.Roles.Add("Contribute2", "Can view, add, update, delete and manage subwebs", web.Roles["Contribute"].PermissionMask | SPRights.ManageSubwebs);

                    web.Update();

                    //SPRights rights = web.Roles["Contribute"].PermissionMask | SPRights.ManageSubwebs;
                    //SPMember pm = web.SiteGroups["Project Managers"];

                    //web.Permissions.Add(pm, rights);

                    roll = web.Roles["Full Control"];
                    roll.AddGroup(web.SiteGroups["Administrators"]);

                    roll = web.Roles["Contribute"];
                    roll.AddGroup(web.SiteGroups["Team Members"]);

                    roll = web.Roles["Read"];
                    roll.AddGroup(web.SiteGroups["Visitors"]);

                    roll = web.Roles["Contribute2"];
                    roll.AddGroup(web.SiteGroups["Project Managers"]);

                    //web.Roles["Full Control"]

                    //SPUser spadmin = web.AllUsers[System.Configuration.ConfigurationManager.AppSettings["owner"].ToString()];
                    //site.Owner = spadmin;
                    //web.Update();
                    siteguid = site.ID.ToString();
                    addUserSite(user, title, siteguid, templateAlias);
                }
                catch (Exception ex)
                { error = ex.Message.ToString() + ex.StackTrace; }
            });

            return error;
        }*/

        private string getFullName()
        {
            accounts.Service s = new accounts.Service();
            s.UseDefaultCredentials = true;
            return s.getName();
        }
        private string getEmail()
        {
            accounts.Service s = new accounts.Service();
            s.UseDefaultCredentials = true;
            return s.getEmail();
        }
        private SPGroup GetSiteGroup(SPWeb web, string name)
        {
            foreach (SPGroup group in web.SiteGroups)
                if (group.Name.ToLower() == name.ToLower())
                    return group;
            return null;
        }

        private void addUserSite(string username, string title, string siteguid, string template)
        {
            SqlConnection cn = new SqlConnection(Settings.getConnectionString());
            cn.Open();

            SqlCommand cmdAddUserSite;

            cmdAddUserSite = new SqlCommand("2010SP_addUserSite", cn);
            cmdAddUserSite.CommandType = CommandType.StoredProcedure;
            cmdAddUserSite.Parameters.AddWithValue("@username", username);
            cmdAddUserSite.Parameters.AddWithValue("@title", title);
            cmdAddUserSite.Parameters.AddWithValue("@template", template);
            cmdAddUserSite.Parameters.AddWithValue("@siteguid", new Guid(siteguid));
            cmdAddUserSite.ExecuteNonQuery();
            cn.Close();
        }
    }
}
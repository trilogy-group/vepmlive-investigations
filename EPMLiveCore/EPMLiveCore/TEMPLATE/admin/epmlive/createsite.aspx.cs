using System;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EPMLiveCore.Layouts.EPMLiveCore
{
    public partial class createsite : LayoutsPageBase
    {
        protected SPWebApplication app;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    string[] files = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + "\\workengine\\templates");
                    foreach (string file in files)
                    {
                        string template = Path.GetFileName(file);
                        ListItem li = new ListItem(template, template);
                        this.ddlSolution.Items.Add(li);
                    }
                }
                catch { }
                if(ddlSolution.Items.Count > 0)
                {
                    BtnCreateSite.Enabled = true;
                    BtnCreateSiteTop.Enabled = true;
                }
            }
        }

        protected void Selector_ContextChange(object sender, EventArgs e)
        {

            app = webAppSelector.CurrentItem;
            HidVirtualServerUrl.Value = app.AlternateUrls[0].Uri.ToString().TrimEnd("/".ToCharArray());
            foreach (SPPrefix pref in app.Prefixes)
            {
                if (pref.PrefixType == SPPrefixType.ExplicitInclusion)
                {
                    try
                    {
                        SPSite site = new SPSite(HidVirtualServerUrl.Value + pref.Name);
                        site.Close();
                    }
                    catch
                    {
                        DdlWildcardInclusion.Items.Add(new ListItem("/" + pref.Name, "1:/" + pref.Name)); 
                    }
                }
                else
                {
                    DdlWildcardInclusion.Items.Add(new ListItem("/" + pref.Name + "/", "0:/" + pref.Name + "/"));
                }
            }
        }

        protected void BtnCreateSite_Click(object sender, EventArgs e)
        {
            bool sitefound = false;
            string url = "";
            try
            {
                if (DdlWildcardInclusion.SelectedValue.Substring(0, 1) == "0")
                {
                    url = DdlWildcardInclusion.SelectedItem.Text + TxtSiteName.Text;
                    SPSite site = new SPSite(HidVirtualServerUrl.Value + DdlWildcardInclusion.SelectedItem.Text + TxtSiteName.Text);
                    sitefound = true;
                    site.Close();
                }
                else
                {
                    url = DdlWildcardInclusion.SelectedItem.Text;
                }
            }
            catch{}
            if (sitefound)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "url", "<script language=\"javascript\">alert('That URL is already in use.');</script>");

            }
            else
            {
                bool databasegood = true;
                lblErrorDatabase.Visible = false;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    try
                    {
                        if (txtDatabaseServer.Text != "")
                        {
                            if (sacccount.Checked)
                            {
                                if (btnNew.Checked)
                                {
                                    SqlConnection cn = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", txtDatabaseServer.Text, "master", username.Text, password.Text));
                                    cn.Open();
                                    cn.Close();
                                }
                                else
                                {
                                    SqlConnection cn = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", txtDatabaseServer.Text, txtDatabaseName.Text, username.Text, password.Text));
                                    cn.Open();
                                    cn.Close();
                                }
                            }
                            else
                            {
                                if (btnNew.Checked)
                                {
                                    SqlConnection cn = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI", txtDatabaseServer.Text, "master"));
                                    cn.Open();
                                    cn.Close();
                                }
                                else
                                {
                                    SqlConnection cn = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI", txtDatabaseServer.Text, txtDatabaseName.Text));
                                    cn.Open();
                                    cn.Close();
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        lblErrorDatabase.Text = ex.Message;
                        lblErrorDatabase.Visible = true;
                        databasegood = false;
                    }
                });

                if (databasegood)
                {
                    app = webAppSelector.CurrentItem;

                    string username = ((Microsoft.SharePoint.WebControls.PickerEntity)PickerOwner.ResolvedEntities[0]).Description;
                    string name = ((Microsoft.SharePoint.WebControls.PickerEntity)PickerOwner.ResolvedEntities[0]).DisplayText;

                    if (app.UseClaimsAuthentication)
                    {
                        username = "i:0#.w|" + username;
                    }

                    Guid siteguid = Guid.Empty;

                    string error = createSite(url, TxtCreateSiteTitle.Text, TxtCreateSiteDescription.Text, username, name, "", ddlSolution.SelectedValue, out siteguid);
                    if (error == "")
                    {
                        Response.Redirect("../SiteCreated.aspx?SiteId=" + HttpUtility.UrlEncode(siteguid.ToString()));
                    }
                    else
                    {
                        lblSiteError.Text = error;
                        lblSiteError.Visible = true;
                    }
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../generalapplicationsettings.aspx");
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
        static SPGroup GetSiteGroup(SPWeb web, string name)
        {
            foreach (SPGroup group in web.SiteGroups)
                if (group.Name.ToLower() == name.ToLower())
                    return group;
            return null;
        }

        private static void addfile(string file, SPWeb web, string path, int counter)
        {
            FileStream fstream = File.OpenRead(path);
            byte[] content = new byte[fstream.Length];
            fstream.Read(content, 0, (int)fstream.Length);
            fstream.Close();
            web.Files.Add(((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_catalogs/solutions/" + file + ".wsp", content);

            SPUserSolution solution = web.Site.Solutions.Add(counter);
            EnsureSiteCollectionFeaturesActivated(solution, web.Site);

        }

        protected string mapReports(SPSite site)
        {
            string errors = "";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                var reportData = new ReportHelper.ReportData(
                new Guid(site.ID.ToString()),
                txtDatabaseName.Text,
                txtDatabaseServer.Text, sacccount.Checked, username.Text, ReportHelper.EPMData.Encrypt(password.Text));
                bool found = reportData.DatabaseExists();

                ReportHelper.EPMData epmdata = new ReportHelper.EPMData(site.ID);

                bool reportingdone = epmdata.MapDataBase(site.ID, site.WebApplication.Id, txtDatabaseServer.Text, txtDatabaseName.Text, username.Text, password.Text, sacccount.Checked, found, out errors);

                if (reportingdone)
                    errors = "";
            });
            return errors;
        }

        private string createSite(string url, string title, string description, string user, string fullName, string email, string template, out Guid siteid)
        {
            siteid = Guid.Empty;
            string errors = "";
            try
            {
                
                //SPWebService myWebService = SPWebService.ContentService;

                //SPWebApplication spApp = myWebService.WebApplications[System.Configuration.ConfigurationManager.AppSettings["WebApplication"].ToString()];

                SPSite site = app.Sites.Add(url, title, description, 1033, "", user, fullName, email);

                //SPSite site = spApp.Sites.Add(bUrl + url, user, email);

                site.AllowUnsafeUpdates = true;
                SPWeb web = site.OpenWeb();
                web.Title = title;
                web.AllowUnsafeUpdates = true;
                web.Site.AllowUnsafeUpdates = true;
                web.Site.RootWeb.AllowUnsafeUpdates = true;
                //SPDocumentLibrary solGallery1 = (SPDocumentLibrary)web.Site.RootWeb.Site.GetCatalog(SPListTemplateType.SolutionCatalog);


                string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + "\\workengine\\templates\\" + template);
                int counter = 1;
                foreach (string file in files)
                {
                    addfile(Path.GetFileNameWithoutExtension(file), web, file, counter);
                    counter++;
                }

                SPWebTemplate webtemplate = null;
                foreach (SPWebTemplate t in web.GetAvailableWebTemplates((uint)web.Locale.LCID))
                {
                    if (t.Title == template)
                    {
                        webtemplate = t;
                        break;
                    }
                }

                if (webtemplate != null)
                    web.ApplyWebTemplate(webtemplate);

                //web.Update();

                //web.AllUsers.Add(user, email, fullName, "");
                ////web.AllUsers.Add(System.Configuration.ConfigurationManager.AppSettings["owner"].ToString(), "", System.Configuration.ConfigurationManager.AppSettings["owner"].ToString(), "");
                //web.Users[user].Name = fullName;
                //web.Users[user].Update();

                //web.Update();
                SPUser owner = web.AllUsers[user];


                web.SiteGroups.Add("Administrators", owner, owner, "");

                //web.Update();
                web.AssociatedOwnerGroup = GetSiteGroup(web, "Administrators");
                SPRole roll = web.Roles["Full Control"];
                roll.AddGroup(web.SiteGroups["Administrators"]);
                SPMember newOwner = web.SiteGroups["Administrators"];

                web.SiteGroups.Add("Team Members", newOwner, owner, "");
                web.SiteGroups.Add("Visitors", newOwner, owner, "");
                web.SiteGroups.Add("Project Managers", newOwner, owner, "");
                //web.Update();

                web.AssociatedVisitorGroup = GetSiteGroup(web, "Visitors");
                web.AssociatedOwnerGroup = GetSiteGroup(web, "Administrators");
                web.AssociatedMemberGroup = GetSiteGroup(web, "Team Members");
                // web.Update();

                //web.SiteGroups["Administrators"].Users[user].Name = fullName;
                //web.SiteGroups["Project Managers"].Users[user].Name = fullName;
                //web.SiteGroups["Team Members"].Users[user].Name = fullName;
                //web.SiteGroups["Visitors"].Users[user].Name = fullName;

                web.Roles.Add("Contribute2", "Can view, add, update, delete and manage subwebs", web.Roles["Contribute"].PermissionMask | SPRights.ManageSubwebs);

                roll = web.Roles["Full Control"];
                roll.AddGroup(web.SiteGroups["Administrators"]);

                roll = web.Roles["Contribute"];
                roll.AddGroup(web.SiteGroups["Team Members"]);

                roll = web.Roles["Read"];
                roll.AddGroup(web.SiteGroups["Visitors"]);

                roll = web.Roles["Contribute2"];
                roll.AddGroup(web.SiteGroups["Project Managers"]);

                siteid = site.ID;

                if(txtDatabaseServer.Text != "")
                    errors = mapReports(site);

                web.Close();
                site.Close();

            }
            catch (Exception ex)
            {
                errors = ex.Message;
            }

            return errors;
        }
    }
}


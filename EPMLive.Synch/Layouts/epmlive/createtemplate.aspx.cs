using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;
using EPMLiveCore;

namespace EPMLiveSynch.Layouts.epmlive
{
    public partial class createtemplate : LayoutsPageBase
    {
        protected string baseURL = "";
        protected string metaDataString = "";
        protected string processString = "";
        protected bool requiredOK = true;
        protected Button btnOK;
        protected DropDownList DdlTemplate;
        protected Panel pnlTitle;
        protected Panel pnlURL;
        protected Panel pnlURLBad;
        protected TextBox txtURL;
        protected TextBox txtTitle;
        protected Label label1;
        protected Panel Panel2;
        protected RadioButton rdoTopLinkYes;
        protected RadioButton rdoTopLinkNo;
        protected RadioButton rdoUnique;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnOK.Attributes.Add("onclick", "javascript:" +
                      btnOK.ClientID + ".disabled=true;");

            SPWeb mySite = SPContext.Current.Web;

            baseURL = mySite.Url + "/";

            if (!IsPostBack)
                populateTemplates(mySite);

        }

        /*private string createSite(string title, string url, string template, SPWeb mySite)
        {
            try
            {
                string user = HttpContext.Current.User.Identity.Name.ToString();
                //SPWeb mySite = SPContext.Current.Web;
                using (SPWeb web = mySite.Webs.Add(url, title, "", 1033, template, true, false))
                {
                    if (web.CurrentUser.IsSiteAdmin)
                    {
                        web.Navigation.TopNavigationBar.Navigation.UseShared = rdoTopLinkYes.Checked;
                        web.AllowUnsafeUpdates = true;

                        web.Update();

                        SPUser owner = web.AllUsers[user];

                        try
                        {
                            web.SiteGroups.Add(title + " Administrators", owner, owner, "");
                        }
                        catch (Exception) { }

                        web.Update();
                        web.AssociatedOwnerGroup = GetSiteGroup(web, title + " Administrators");
                        SPRole roll = web.Roles["Full Control"];
                        roll.AddGroup(web.SiteGroups[title + " Administrators"]);
                        SPMember newOwner = web.SiteGroups[title + " Administrators"];

                        try
                        {
                            web.SiteGroups.Add(title + " Project Managers", newOwner, owner, "");
                        }
                        catch (Exception) { }
                        try
                        {
                            web.SiteGroups.Add(title + " Team Members", newOwner, owner, "");
                        }
                        catch (Exception) { }
                        try
                        {
                            web.SiteGroups.Add(title + " Visitors", newOwner, owner, "");
                        }
                        catch (Exception) { }
                        web.Update();



                        //web.Roles.Add("Project Manager", "", web.Roles["Contribute"].PermissionMask | SPRights.ManageLists);
                        //web.Update();

                        SPMember pms = web.SiteGroups[title + " Project Managers"];
                        SPMember tms = web.SiteGroups[title + " Team Members"];
                        SPMember vst = web.SiteGroups[title + " Visitors"];

                        try
                        {
                            SPList list = web.Lists["My Tasks"];
                            list.Permissions.Add(pms, web.Roles["Design"].PermissionMask | SPRights.ManageLists);
                            list.Permissions.Add(tms, web.Roles["Contribute"].PermissionMask);
                            list.Permissions.Add(vst, web.Roles["Read"].PermissionMask);
                        }
                        catch { }

                        web.AssociatedVisitorGroup = GetSiteGroup(web, title + " Visitors");
                        web.AssociatedMemberGroup = GetSiteGroup(web, title + " Team Members");
                        web.Update();


                        roll = web.Roles["Contribute"];
                        roll.AddGroup(web.SiteGroups[title + " Team Members"]);
                        roll.AddGroup(web.SiteGroups[title + " Project Managers"]);
                        roll = web.Roles["Read"];
                        roll.AddGroup(web.SiteGroups[title + " Visitors"]);
                        web.Update();

                        // add Template ID property if not exists. Enterprise synched templates will have this prop
                        if (!web.Properties.ContainsKey("EPMLiveTemplateID"))
                        {
                            string sGUID = System.Guid.NewGuid().ToString();
                            web.Properties.Add("EPMLiveTemplateID", sGUID);
                            web.Properties.Update();
                        }

                        using (SPSite site = SPContext.Current.Site)
                        {
                            using (SPWeb rootWeb = site.RootWeb)
                            {
                                AddAsSynchedTemplate(rootWeb, web.ID.ToString());
                            }
                        }
                        //SPFeature oFT = null;
                        //try
                        //{
                        //    oFT = web.Features[new Guid("dfb82bdd-a86c-4314-a0f2-654526c7814e")];
                        //}
                        //catch { }
                        //if (oFT == null)
                        //{
                        //    try
                        //    {
                        //        web.Features.Add(new Guid("dfb82bdd-a86c-4314-a0f2-654526c7814e"));
                        //    }
                        //    catch { }
                        //}

                        web.AllowUnsafeUpdates = false;
                    }

                    return "0:" + web.Url;

                }
            }
            catch (Exception ex) { return ex.Message.ToString(); }
        }
        */
        public void AddAsSynchedTemplate(SPWeb rootWeb, string sTemplateID)
        {
            try
            {
                if (rootWeb.Properties.ContainsKey("EPMLiveSiteTemplateIDs"))
                {
                    string sIDs = rootWeb.Properties["EPMLiveSiteTemplateIDs"];
                    rootWeb.AllowUnsafeUpdates = true;
                    rootWeb.Properties["EPMLiveSiteTemplateIDs"] = sIDs + "|" + sTemplateID;
                    rootWeb.Properties.Update();
                    rootWeb.AllowUnsafeUpdates = false;
                }
                else
                {
                    rootWeb.AllowUnsafeUpdates = true;
                    rootWeb.Properties.Add("EPMLiveSiteTemplateIDs", sTemplateID);
                    rootWeb.Properties.Update();
                    rootWeb.AllowUnsafeUpdates = false;
                }
            }
            catch { }
        }

        private void populateTemplates(SPWeb site)
        {
            string sTemplates = CoreFunctions.getConfigSetting(site, "EPMLiveValidTemplates");

            ArrayList validTemplates = new ArrayList();

            if (sTemplates != "")
            {
                string[] ssTemplates = sTemplates.Split('|');
                foreach (string sTemplate in ssTemplates)
                {
                    validTemplates.Add(sTemplate);
                }
            }

            SortedList sl = new SortedList();
            foreach (SPWebTemplate template in site.GetAvailableWebTemplates(site.Language))
            {
                if (!template.IsHidden)
                {
                    if (!template.Title.Contains("EPM Live"))
                    {
                        if (validTemplates.Count == 0)
                        {
                            if (template.IsCustomTemplate)
                            {
                                sl.Add(template.Title, template.Name);
                            }
                        }
                        else
                        {
                            if (validTemplates.Contains(template.Title))
                            {
                                sl.Add(template.Title, template.Name);
                            }
                        }
                    }
                }
            }

            foreach (DictionaryEntry de in sl)
            {
                ListItem li = new ListItem(de.Key.ToString(), de.Value.ToString());
                DdlTemplate.Items.Add(li);
            }

        }

        private SPGroup GetSiteGroup(SPWeb web, string name)
        {
            foreach (SPGroup group in web.SiteGroups)
                if (group.Name.ToLower() == name.ToLower())
                    return group;
            return null;
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //using (
                SPWeb mySite = SPContext.Current.Web;
                {
                    string sCurrURL = mySite.Url;

                    pnlTitle.Visible = false;
                    pnlURL.Visible = false;
                    pnlURLBad.Visible = false;

                    string title = txtTitle.Text;
                    string group = DdlTemplate.SelectedItem.Value;

                    string selectedWorkspace = Request["hdnSelectedWorkspace"];
                    string sParentWSURL = selectedWorkspace.Replace(mySite.ServerRelativeUrl, "");
                    if (!String.IsNullOrEmpty(sParentWSURL))
                        sParentWSURL = sParentWSURL.Substring(1);

                    SPWeb w = mySite;
                    if (sParentWSURL != "")
                        w = mySite.Webs[sParentWSURL];

                    string err = "";
                    if (w.Exists)
                    {
                        string sNewURL = txtURL.Text;
                        err = CoreFunctions.createSite(title, sNewURL, group, mySite.CurrentUser.LoginName, true, rdoTopLinkYes.Checked, mySite);                        
                    }
                    else
                    {
                        err = "The site that you selected does not exist.";
                    }

                    w.Close();

                    if (err.Substring(0, 1) == "0")
                    {
                        SPSite site = new SPSite(err.Substring(2));
                        SPWeb web = site.OpenWeb();

                        if (!web.Properties.ContainsKey("EPMLiveTemplateID"))
                        {
                            string sGUID = System.Guid.NewGuid().ToString();
                            web.Properties.Add("EPMLiveTemplateID", sGUID);
                            web.Properties.Update();
                        }

                        SPWeb rootWeb = site.RootWeb;
                        AddAsSynchedTemplate(rootWeb, web.ID.ToString());

                        Response.Redirect(sCurrURL + "/_layouts/epmlive/templates.aspx");
                    }
                    else
                    {
                        label1.Text = err;
                        Panel2.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex.Message + ex.StackTrace;
                Panel2.Visible = true;
            }
        }
    }
}

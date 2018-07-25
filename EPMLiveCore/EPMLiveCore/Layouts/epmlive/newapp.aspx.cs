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
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;
using EPMLiveCore.Infrastructure.Logging;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace EPMLiveCore
{
    public partial class newapp : LayoutsPageBase
    {
        protected string baseURL = "";
        protected string metaDataString = "";
        protected string processString = "";
        protected bool requiredOK = true;
        protected Button btnOK;
        protected DropDownList DdlGroup;
        protected Panel pnlTitle;
        protected Panel pnlURL;
        protected Panel pnlURLBad;
        protected TextBox txtURL;
        protected TextBox txtTitle;
        protected Label label1;
        protected Panel Panel2;
        protected string URL = "";
        protected RadioButton rdoTopLinkYes;
        protected RadioButton rdoTopLinkNo;
        protected RadioButton rdoUnique;
        protected RadioButton rdoInherit;

        protected string wsTypeNew = "checked";
        protected string wsTypeExisting;

        protected string listName;
        protected string strName;

        protected Microsoft.SharePoint.WebControls.InputFormSection inpName;

        ArrayList validTemplates = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {


            btnOK.Attributes.Add("onclick", "javascript:" + btnOK.ClientID + ".disabled=true;");

            if (!IsPostBack)
            {
                string login = SPContext.Current.Web.CurrentUser.LoginName;
                string url = SPContext.Current.Web.Url;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using(SPSite mysite = new SPSite(url))
                    {
                        using(SPWeb myweb = mysite.OpenWeb())
                        {
                            myweb.Site.CatchAccessDeniedException = false;
                            try
                            {
                                if (!myweb.DoesUserHavePermissions(login, SPBasePermissions.ManageSubwebs))
                                    Microsoft.SharePoint.Utilities.SPUtility.Redirect("accessdenied.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                            }
                            catch
                            {
                                Microsoft.SharePoint.Utilities.SPUtility.Redirect("accessdenied.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                            }
                            URL = myweb.ServerRelativeUrl;

                            SPList list = myweb.Lists[new Guid(Request["List"])];
                            listName = list.Title;
                            strName = "";

                            try
                            {
                                GridGanttSettings gSettings = new GridGanttSettings(list);
                                strName = gSettings.NewMenuName;
                            }
                            catch { }
                            if (strName == "")
                                strName = listName;

                            inpName.Title = strName + " Name";
                            btnOK.Text = "Create " + strName;

                            baseURL = myweb.Url + "/";
                            Guid lockweb = CoreFunctions.getLockedWeb(myweb);
                            if (lockweb != Guid.Empty)
                            {
                                using (SPWeb web = myweb.Site.AllWebs[lockweb])
                                {
                                    string wsType = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectWorkspaceType");
                                    string nav = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectNavigation");
                                    string perms = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectPermissions");

                                    string sTemplates = CoreFunctions.getConfigSetting(web, "EPMLiveValidTemplates");

                                    if (sTemplates != "")
                                    {
                                        string[] ssTemplates = sTemplates.Split('|');
                                        foreach (string sTemplate in ssTemplates)
                                        {
                                            validTemplates.Add(sTemplate);
                                        }
                                    }


                                    if (nav == "True")
                                    {
                                        rdoTopLinkYes.Checked = true;
                                        rdoTopLinkNo.Enabled = false;
                                        rdoTopLinkYes.Enabled = false;
                                    }
                                    else if (nav == "False")
                                    {
                                        rdoTopLinkNo.Checked = true;
                                        rdoTopLinkNo.Enabled = false;
                                        rdoTopLinkYes.Enabled = false;
                                    }

                                    if (perms == "Unique")
                                    {
                                        rdoInherit.Checked = false;
                                        rdoUnique.Checked = true;
                                        rdoUnique.Enabled = false;
                                        rdoInherit.Enabled = false;
                                    }
                                    else if (perms == "Same")
                                    {
                                        rdoUnique.Checked = false;
                                        rdoUnique.Enabled = false;
                                        rdoInherit.Enabled = false;
                                        rdoInherit.Checked = true;
                                    }

                                    if (wsType == "New")
                                    {
                                        wsTypeNew = "checked disabled=\"true\"";
                                        wsTypeExisting = " disabled=\"true\"";

                                    }
                                    else if (wsType == "Existing")
                                    {
                                        wsTypeNew = " disabled=\"true\"";
                                        wsTypeExisting = "checked disabled=\"true\"";
                                        Page.RegisterStartupScript("existingws", "<script>existingWorkspace();</script>");
                                    }
                                }
                            }
                            populateTemplates(myweb);
                        }
                    }
                });
            }
        }

        private void populateTemplates(SPWeb site)
        {
            SortedList sl = new SortedList();
            string version = getMajorVersion(site);
            foreach (SPWebTemplate template in site.GetAvailableWebTemplates(site.Language))
            {
                if (!template.IsHidden)
                {
                    if (!template.Title.Contains("EPM Live"))
                    {
                        if (validTemplates.Count == 0)
                        {
                            if (template.IsCustomTemplate && isValidTemplate(template.Title, version, site))
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
                DdlGroup.Items.Add(li);
            }
        }

        private bool isValidTemplate(string template, string version, SPWeb web)
        {
            if (version == "2")
            {
                switch (template)
                {
                    case "Basic Project Workspace":
                    case "Enterprise Project Management Workgroup":
                        return false;
                };
            }
            else if (version == "1")
            {
                switch (template)
                {
                    case "Project Workspace":
                        return false;
                }
            }
            return true;
        }


        private string getMajorVersion(SPWeb web)
        {
            try
            {
                string[] fullversion = web.Properties["TemplateVersion"].Split('.');
                return fullversion[0];
            }
            catch { }
            return "1";
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            var web = SPContext.Current.Web;
            var workspaceType = Request["hdnWorkspaceType"];
            var selectedWorkspace = Request["hdnSelectedWorkspace"];
            var listId = new Guid(Request["List"]);
            var currentList = web.Lists[listId];

            if (workspaceType == "Existing")
            {
                var workspaceId = new Guid(selectedWorkspace);
                var redirectUrl = UpdateList(web, currentList, workspaceId);
                if (!string.IsNullOrEmpty(redirectUrl))
                {
                    Response.Redirect(redirectUrl);
                }
            }
            else
            {
                try
                {
                    pnlTitle.Visible = false;
                    pnlURL.Visible = false;
                    pnlURLBad.Visible = false;

                    var url = txtURL.Text;
                    var title = txtTitle.Text;
                    var group = DdlGroup.SelectedItem.Value;

                    if (requiredOK)
                    {
                        if (CoreFunctions.IsAlphaNumeric(title))
                        {
                            var err = CoreFunctions.createSite(title, url, group, web.CurrentUser.LoginName, rdoUnique.Checked, rdoTopLinkYes.Checked, web);

                            if (err.Substring(0, 1) == "0")
                            {
                                var redirectUrl = CoreFunctions.CreateProjectInNewWorkspace(web, currentList.Title, baseURL + url, title);
                                if (!string.IsNullOrEmpty(redirectUrl))
                                {
                                    Response.Redirect(redirectUrl + "&rnd=" + Guid.NewGuid());
                                }
                            }
                            else
                            {
                                label1.Text = err;
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            label1.Text = "Your site title must contain only alpha-numeric characters only.";
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

        private string UpdateList(SPWeb web, SPList currentList, Guid workspaceId)
        {
            var result = string.Empty;
            try
            {
                using (var webWorkspace = web.Webs[workspaceId])
                {
                    SPList list = null;
                    try
                    {
                        list = webWorkspace.Lists[currentList.Title];
                    }
                    catch (Exception ex)
                    {
                        LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.VerboseEx, ex.ToString());
                    }

                    if (list != null)
                    {
                        var listItem = list.Items.Add();
                        listItem["Title"] = txtTitle.Text;
                        listItem.Update();

                        result = list.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + listItem.ID;
                    }
                    else
                    {
                        label1.Text = "Error: The list " + currentList.Title + " does not exist";
                        Panel2.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex.Message;
                Panel2.Visible = true;

                LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.VerboseEx, ex.ToString());
            }

            return result;
        }
    }
}
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using EPMLiveCore.Infrastructure.Logging;
using EPMLiveCore.SPUtilities;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace EPMLiveCore
{
    public partial class newproject : Page
    {
        private SPProjectUtility _spProjectUtility = new SPProjectUtility();

        protected string baseURL = string.Empty;
        protected string metaDataString = string.Empty;
        protected string processString = string.Empty;
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

        ArrayList validTemplates = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnOK.Attributes.Add("onclick", string.Format("javascript:{0}.disabled=true;", btnOK.ClientID));
            
            if (!IsPostBack)
            {
                var projectInfo = _spProjectUtility.RequestProjectInfo();

                switch (projectInfo.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        SPUtility.Redirect("accessdenied.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                        break;
                    default:
                        URL = projectInfo.ServerRelativeUrl;
                        baseURL = projectInfo.BaseUrl;

                        foreach (DictionaryEntry dictionaryEntry in projectInfo.PopulatedTemplates)
                        {
                            var li = new ListItem(dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString());
                            DdlGroup.Items.Add(li);
                        }

                        if (projectInfo.IsNavigationEnabled.HasValue)
                        {
                            rdoTopLinkYes.Checked = projectInfo.IsNavigationEnabled == true;
                            rdoTopLinkNo.Checked = projectInfo.IsNavigationEnabled == false;
                            rdoTopLinkNo.Enabled = false;
                            rdoTopLinkYes.Enabled = false;
                        }
                        
                        if (projectInfo.IsUnique.HasValue)
                        {
                            rdoUnique.Checked = projectInfo.IsUnique == true;
                            rdoInherit.Checked = projectInfo.IsUnique == false;
                            rdoUnique.Enabled = false;
                            rdoInherit.Enabled = false;
                        }

                        if (projectInfo.IsWorkspaceExisting == false)
                        {
                            wsTypeNew = "checked disabled=\"true\"";
                            wsTypeExisting = " disabled=\"true\"";
                        }
                        else if (projectInfo.IsWorkspaceExisting == true)
                        {
                            wsTypeNew = " disabled=\"true\"";
                            wsTypeExisting = "checked disabled=\"true\"";
                            Page.RegisterStartupScript("existingws", "<script>existingWorkspace();</script>");
                        }
                        break;
                }
            }
        }
        
        private string createProject(SPWeb web)
        {
            SPList list = web.Lists["Project Center"];
            SPListItem li = list.Items.Add();
            li["Title"] = txtTitle.Text;
            li.Update();

            return list.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + li.ID;
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            var workspaceType = Request["hdnWorkspaceType"];
            var selectedWorkspace = Request["hdnSelectedWorkspace"];

            if (workspaceType == "Existing")
            {
                var redirectUrl = CreateProjectInExistingWorkspace(selectedWorkspace);
                if (redirectUrl != string.Empty)
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
                        if (IsAlphaNumeric(title))
                        {
                            var web = SPContext.Current.Web;
                            var err = CoreFunctions.createSite(title, url, group, web.CurrentUser.LoginName, rdoUnique.Checked, rdoTopLinkYes.Checked, web);

                            if (err.Substring(0, 1) == "0")
                            {
                                var redirectUrl = CreateProjectInNewWorkspace(web, url, title);
                                if (redirectUrl != string.Empty)
                                {
                                    Response.Redirect(redirectUrl);
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

        private string CreateProjectInNewWorkspace(SPWeb web, string url, string title)
        {
            SPListItem li = null;
            try
            {
                var workspacelist = web.Lists["Workspace Center"];
                li = workspacelist.Items.Add();
                li["URL"] = baseURL + url + ", " + title;
                li.Update();

                var workspaceID = li.ID;
                var listUrl = workspacelist.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl;
            }
            catch (Exception ex)
            {
                WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.VerboseEx, ex.ToString());
            }

            using (var webAtUrl = web.Webs[url])
            {
                var list = webAtUrl.Lists["Project Center"];

                SPField field = null;
                try
                {
                    field = list.Fields.GetFieldByInternalName("EPMLiveListConfig");
                }
                catch (Exception ex)
                {
                    WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString());
                }

                if (field == null)
                {
                    if (list.DoesUserHavePermissions(SPBasePermissions.ManageLists))
                    {
                        try
                        {
                            list.ParentWeb.AllowUnsafeUpdates = true;
                            field = new SPField(list.Fields, "EPMLiveConfigField", "EPMLiveListConfig");
                            field.Hidden = true;
                            list.Fields.Add(field);
                            field.Update();
                            list.Update();
                        }
                        catch (Exception ex)
                        {
                            WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString());
                        }
                    }
                }

                var query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>Template</Value></Eq></Where>";

                li = null;

                foreach (SPListItem listItem in list.GetItems(query))
                {
                    li = listItem;
                    listItem["Title"] = txtTitle.Text;
                    listItem.SystemUpdate();
                    break;
                }

                if (li == null)
                {
                    li = list.Items.Add();
                    li["Title"] = txtTitle.Text;
                    li.Update();
                }

                return list.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + li.ID;
            }
        }

        private string CreateProjectInExistingWorkspace(string selectedWorkspace)
        {
            var redirectUrl = string.Empty;
            var web = SPContext.Current.Web;

            try
            {
                var url = selectedWorkspace.Replace(web.ServerRelativeUrl, string.Empty);
                if (url != string.Empty)
                {
                    url = url.Substring(1);
                }

                if (url != string.Empty)
                {
                    using (SPWeb webAtUrl = web.Webs[url])
                    {
                        redirectUrl = createProject(webAtUrl);
                    }
                }
                else
                {
                    redirectUrl = createProject(web);
                }
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex.Message;
                Panel2.Visible = true;
            }

            return redirectUrl;
        }

        public bool IsAlphaNumeric(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex(@"[^a-zA-Z0-9\s]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }
    }
}
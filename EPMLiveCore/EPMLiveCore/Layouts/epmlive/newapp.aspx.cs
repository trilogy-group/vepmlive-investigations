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
using EPMLiveCore.SPUtilities;
using System.Net;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore
{
    public partial class newapp : LayoutsPageBase
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
        protected string URL = string.Empty;
        protected RadioButton rdoTopLinkYes;
        protected RadioButton rdoTopLinkNo;
        protected RadioButton rdoUnique;
        protected RadioButton rdoInherit;

        protected string wsTypeNew = "checked";
        protected string wsTypeExisting;

        protected string listName;
        protected string strName;

        protected InputFormSection inpName;

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
                        var workspaceInfo = _spProjectUtility.RequestWorkspaceInfo(new Guid(Request["List"]));

                        listName = workspaceInfo.ListName;
                        strName = workspaceInfo.WorkspaceName;

                        URL = projectInfo.ServerRelativeUrl;
                        baseURL = projectInfo.BaseUrl;

                        foreach (DictionaryEntry dictionaryEntry in projectInfo.PopulatedTemplates)
                        {
                            var li = new ListItem(dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString());
                            DdlGroup.Items.Add(li);
                        }

                        inpName.Title = strName + " Name";
                        btnOK.Text = "Create " + strName;

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
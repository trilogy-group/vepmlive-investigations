using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;
using EPMLiveCore.SPUtilities;
using Microsoft.SharePoint.Utilities;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace EPMLiveCore
{
    public partial class requestworkspace : LayoutsPageBase
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
                        var workspaceInfo = _spProjectUtility.RequestWorkspaceInfo(
                            new Guid(Request["List"]), 
                            int.Parse(Request["id"]));

                        listName = workspaceInfo.ListName;
                        strName = workspaceInfo.WorkspaceName;

                        URL = projectInfo.ServerRelativeUrl;
                        baseURL = projectInfo.BaseUrl;

                        foreach (DictionaryEntry dictionaryEntry in projectInfo.PopulatedTemplates)
                        {
                            var li = new ListItem(dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString());
                            DdlGroup.Items.Add(li);
                        }

                        inpName.Title = "Workspace Name";
                        txtTitle.Text = strName;
                        txtURL.Text = strName.ToLower().Replace(" ", string.Empty);
                        btnOK.Text = "Create Workspace";

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

        private string createProject(SPWeb newWeb, SPList curList)
        {
            if (newWeb != null)
            {
                try
                {
                    var oldLi = curList.GetItemById(int.Parse(Request["ID"]));
                    var gSettings = new GridGanttSettings(curList);
                    var listName = string.Empty;
                    try
                    {
                        var tRollupLists = gSettings.RollupLists.Split(',');
                        listName = tRollupLists[0].Split('|')[0];
                    }
                    catch (Exception ex)
                    {
                        WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
                    }

                    var newList = newWeb.Lists[listName];

                    SPField confField = null;
                    try
                    {
                        confField = newList.Fields.GetFieldByInternalName("EPMLiveListConfig");
                    }
                    catch(Exception ex)
                    {
                        WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
                    }

                    if (confField == null)
                    {
                        if (newList.DoesUserHavePermissions(SPBasePermissions.ManageLists))
                        {
                            try
                            {
                                newList.ParentWeb.AllowUnsafeUpdates = true;
                                confField = new SPField(newList.Fields, "EPMLiveConfigField", "EPMLiveListConfig");
                                confField.Hidden = true;
                                newList.Fields.Add(confField);
                                confField.Update();
                                newList.Update();
                            }
                            catch (Exception ex)
                            {
                                WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
                            }
                        }
                    }

                    var newLi = newList.Items.Add();
                    newLi["Title"] = oldLi.Title;

                    foreach (SPField field in curList.Fields)
                    {
                        if (field.Reorderable)
                        {
                            if (newList.Fields.ContainsField(field.InternalName))
                            {
                                try
                                {
                                    if (newList.Fields.GetFieldByInternalName(field.InternalName).Type == field.Type)
                                    {
                                        try
                                        {
                                            newLi[field.InternalName] = oldLi[field.InternalName];
                                        }
                                        catch (Exception ex)
                                        {
                                            WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
                                }
                            }
                        }
                    }

                    newLi.Update();

                    try
                    {
                        var sourceItemAttachmentsFolder = SPContext.Current.Web.Folders["Lists"].SubFolders[oldLi.ParentList.Title].SubFolders["Attachments"].SubFolders[oldLi.ID.ToString()];
                        foreach (SPFile file in sourceItemAttachmentsFolder.Files)
                        {
                            var binFile = file.OpenBinary();
                            newLi.Attachments.Add(file.Name, binFile);
                        }

                        newLi.Update();
                    }
                    catch (Exception ex)
                    {
                        WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
                    }

                    oldLi.Delete();
                    return newList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + newLi.ID;
                }
                catch (Exception ex)
                {
                    label1.Text = "Error: " + ex.Message + ex.StackTrace;
                    Panel2.Visible = true;
                }
            }

            return string.Empty;
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            var wType = Request["hdnWorkspaceType"];
            var selectedWorkspace = Request["hdnSelectedWorkspace"];
            var retURL = string.Empty;

            var web = SPContext.Current.Web;
            var curList = web.Lists[new Guid(Request["List"])];

            if (wType == "Existing")
            {
                try
                {
                    var url = selectedWorkspace.Replace(web.ServerRelativeUrl, string.Empty);
                    if (url != string.Empty)
                    {
                        url = url.Substring(1);
                    }

                    if (url != string.Empty)
                    {
                        using (var newWeb = web.Webs[url])
                        {
                            retURL = createProject(newWeb, curList);
                        }
                    }
                    else
                    {
                        retURL = createProject(web, curList);
                    }
                }
                catch (Exception ex)
                {
                    label1.Text = "Error: " + ex.Message;
                    Panel2.Visible = true;
                }
            }
            else
            {
                try
                {
                    pnlTitle.Visible = false;
                    pnlURL.Visible = false;
                    pnlURLBad.Visible = false;

                    var inputUrl = txtURL.Text;
                    var inputTitle = txtTitle.Text;
                    var inputGroup = DdlGroup.SelectedItem.Value;

                    if (requiredOK)
                    {
                        if (IsAlphaNumeric(inputTitle))
                        {
                            var errorCode = CoreFunctions.createSite(
                                inputTitle, 
                                inputUrl, 
                                inputGroup, 
                                SPContext.Current.Web.CurrentUser.LoginName, 
                                rdoUnique.Checked, 
                                rdoTopLinkYes.Checked, 
                                web);

                            if (errorCode[0] == '0')
                            {
                                SPListItem li = null;
                                try
                                {
                                    var workspacelist = web.Lists["Workspace Center"];
                                    li = workspacelist.Items.Add();
                                    li["URL"] = baseURL + inputUrl + ", " + inputTitle;
                                    li.Update();

                                    int workspaceID = li.ID;
                                    string listUrl = workspacelist.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl;
                                }
                                catch (Exception ex)
                                {
                                    WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.LayoutPage, TraceSeverity.VerboseEx, ex.ToString());
                                }

                                using (var newWeb = web.Webs[inputUrl])
                                {
                                    retURL = createProject(newWeb, curList);
                                }
                            }
                            else
                            {
                                label1.Text = errorCode;
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

            if (retURL != string.Empty)
            {
                Response.Redirect(retURL);
            }
        }

        public bool IsAlphaNumeric(string strToCheck)
        {
            var objAlphaNumericPattern = new Regex(@"[^a-zA-Z0-9\s]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }
    }
}
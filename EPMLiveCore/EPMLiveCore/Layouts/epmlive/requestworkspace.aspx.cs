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
using EPMLiveCore.SPUtilities;
using System.Net;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore
{
    public partial class requestworkspace : LayoutsPageBase
    {
        private SPProjectUtility _spProjectUtility = new SPProjectUtility();

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

        protected InputFormSection inpName;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnOK.Attributes.Add("onclick", "javascript:" + btnOK.ClientID + ".disabled=true;");

            if (!IsPostBack)
            {
                var projectInfo = _spProjectUtility.RequestProjectInfoExtended();

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
                        txtURL.Text = strName.ToLower().Replace(" ", "");
                        btnOK.Text = "Create Workspace";

                        if (projectInfo.IsNavigationEnabled)
                        {
                            rdoTopLinkYes.Checked = true;
                            rdoTopLinkNo.Enabled = false;
                            rdoTopLinkYes.Enabled = false;
                        }
                        else
                        {
                            rdoTopLinkNo.Checked = true;
                            rdoTopLinkNo.Enabled = false;
                            rdoTopLinkYes.Enabled = false;
                        }

                        if (projectInfo.IsUnique)
                        {
                            rdoInherit.Checked = false;
                            rdoUnique.Checked = true;
                            rdoUnique.Enabled = false;
                            rdoInherit.Enabled = false;
                        }
                        else
                        {
                            rdoUnique.Checked = false;
                            rdoUnique.Enabled = false;
                            rdoInherit.Enabled = false;
                            rdoInherit.Checked = true;
                        }

                        if (projectInfo.IsWorkspaceExisting)
                        {
                            wsTypeNew = "checked disabled=\"true\"";
                            wsTypeExisting = " disabled=\"true\"";
                        }
                        else
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
            if(newWeb != null)
            {
                try
                {
                    SPListItem oldLi = curList.GetItemById(int.Parse(Request["ID"]));



                    //string strProps = EPMLiveCore.CoreFunctions.getListSetting(curList, "GeneralSettings");
                    //string[] props = strProps.Split('\n');

                    GridGanttSettings gSettings = new GridGanttSettings(curList);

                    string listname = "";
                    try
                    {
                        string[] tRollupLists = gSettings.RollupLists.Split(',');
                        listname = tRollupLists[0].Split('|')[0];
                    }
                    catch { }

                    SPList newList = newWeb.Lists[listname];

                    SPField confField = null;
                    try
                    {
                        confField = newList.Fields.GetFieldByInternalName("EPMLiveListConfig");
                    }
                    catch { }
                    if(confField == null)
                    {
                        if(newList.DoesUserHavePermissions(SPBasePermissions.ManageLists))
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
                            catch { }
                        }
                    }

                    SPListItem newLi = newList.Items.Add();
                    newLi["Title"] = oldLi.Title;

                    foreach(SPField f in curList.Fields)
                    {
                        if(f.Reorderable)
                        {
                            if(newList.Fields.ContainsField(f.InternalName))
                            {
                                try
                                {
                                    if(newList.Fields.GetFieldByInternalName(f.InternalName).Type == f.Type)
                                    {
                                        try
                                        {
                                            newLi[f.InternalName] = oldLi[f.InternalName];
                                        }
                                        catch { }
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    newLi.Update();

                    try
                    {
                        SPFolder sourceItemAttachmentsFolder = SPContext.Current.Web.Folders["Lists"].SubFolders[oldLi.ParentList.Title].SubFolders["Attachments"].SubFolders[oldLi.ID.ToString()];

                        foreach(SPFile file in sourceItemAttachmentsFolder.Files)
                        {
                            byte[] binFile = file.OpenBinary();

                            newLi.Attachments.Add(file.Name, binFile);
                        }
                        newLi.Update();
                    }
                    catch { }
                    oldLi.Delete();
                    return newList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + newLi.ID;
                    //newWeb.Close();
                    //web.Close();
                    
                }
                catch(Exception ex)
                {
                    label1.Text = "Error: " + ex.Message + ex.StackTrace;
                    Panel2.Visible = true;
                }
                //newWeb.Close();
            }
            return "";
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            string wType = Request["hdnWorkspaceType"];
            string selectedWorkspace = Request["hdnSelectedWorkspace"];
            string retURL = "";

            SPWeb web = SPContext.Current.Web;
            SPList curList = web.Lists[new Guid(Request["List"])];

            if (wType == "Existing")
            {

                try
                {
                    string url = selectedWorkspace.Replace(web.ServerRelativeUrl, "");
                    if (url != "")
                        url = url.Substring(1);

                    if(url != "")
                    {
                        using(SPWeb newWeb = web.Webs[url])
                        {
                            retURL = createProject(newWeb, curList);
                        }
                    }
                    else
                        retURL = createProject(web, curList);

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

                    string url = txtURL.Text;
                    string title = txtTitle.Text;
                    string group = DdlGroup.SelectedItem.Value;

                    if (requiredOK)
                    {
                        if (IsAlphaNumeric(title))
                        {
                            string err = CoreFunctions.createSite(title, url, group, SPContext.Current.Web.CurrentUser.LoginName, rdoUnique.Checked, rdoTopLinkYes.Checked, web);

                            if (err.Substring(0, 1) == "0")
                            {
                                SPListItem li = null;
                                try
                                {
                                    SPList workspacelist = web.Lists["Workspace Center"];
                                    li = workspacelist.Items.Add();
                                    li["URL"] = baseURL + url + ", " + title;
                                    li.Update();

                                    int workspaceID = li.ID;
                                    string listUrl = workspacelist.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl;
                                }
                                catch { }
                                using(SPWeb newWeb = web.Webs[url])
                                {
                                    retURL = createProject(newWeb, curList);
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

            if(retURL != "")
                Response.Redirect(retURL);
            //web.Close();
        }
        public bool IsAlphaNumeric(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex(@"[^a-zA-Z0-9\s]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }
    }
}
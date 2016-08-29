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

namespace EPMLiveCore
{
    public partial class requestworkspace : LayoutsPageBase
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
                    //using (SPSite mysite = new SPSite(url))
                    using(SPSite mysite = new SPSite(url))
                    {
                        //using (SPWeb myweb = mysite.OpenWeb())
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

                            GridGanttSettings gSettings = new GridGanttSettings(list);

                            try
                            {
                                string[] tRollupLists = gSettings.RollupLists.Split(',');
                                listName = tRollupLists[0].Split('|')[0];
                            }
                            catch { }
                            strName = "";

                            SPListItem li = list.GetItemById(int.Parse(Request["id"]));
                            strName = li.Title;

                            inpName.Title = "Workspace Name";
                            txtTitle.Text = strName;
                            txtURL.Text = strName.ToLower().Replace(" ", "");
                            btnOK.Text = "Create Workspace";

                            baseURL = myweb.Url + "/";
                            Guid lockweb = CoreFunctions.getLockedWeb(myweb);
                            if (lockweb != Guid.Empty)
                            {
                                //using (SPWeb web = myweb.Site.AllWebs[lockweb])
                                using(SPWeb web = myweb.Site.AllWebs[lockweb])
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
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
            string wType = Request["hdnWorkspaceType"];
            string selectedWorkspace = Request["hdnSelectedWorkspace"];
            string retURL = "";
            if (wType == "Existing")
            {
                SPWeb web = SPContext.Current.Web;

                try
                {
                    string url = selectedWorkspace.Replace(web.ServerRelativeUrl, "");
                    if(url != "")
                        url = url.Substring(1);

                    if(url != "")
                    {  
                        using(SPWeb w = web.Webs[url])
                        {
                            retURL = createProject(w);
                        }
                    }
                    else
                        retURL = createProject(web);
                }
                catch(Exception ex)
                {
                    label1.Text = "Error: " + ex.Message;
                    Panel2.Visible = true;
                }

                //web.Close();
                if(retURL != "")
                    Response.Redirect(retURL);
            }
            else
            {
                try
                {
                    SPWeb mySite = SPContext.Current.Web;

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
                            string err = CoreFunctions.createSite(title, url, group, mySite.CurrentUser.LoginName, rdoUnique.Checked, rdoTopLinkYes.Checked, mySite);

                            if (err.Substring(0, 1) == "0")
                            {
                                SPListItem li = null;
                                try
                                {
                                    SPList workspacelist = mySite.Lists["Workspace Center"];
                                    li = workspacelist.Items.Add();
                                    li["URL"] = baseURL + url + ", " + title;
                                    li.Update();

                                    int workspaceID = li.ID;
                                    string listUrl = workspacelist.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl;
                                }
                                catch { }
                                using (SPWeb w = mySite.Webs[url])
                                {
                                    SPList list = w.Lists["Project Center"];

                                    SPField f = null;
                                    try
                                    {
                                        f = list.Fields.GetFieldByInternalName("EPMLiveListConfig");
                                    }
                                    catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                                    if (f == null)
                                    {
                                        if (list.DoesUserHavePermissions(SPBasePermissions.ManageLists))
                                        {
                                            try
                                            {
                                                list.ParentWeb.AllowUnsafeUpdates = true;
                                                f = new SPField(list.Fields, "EPMLiveConfigField", "EPMLiveListConfig");
                                                f.Hidden = true;
                                                list.Fields.Add(f);
                                                f.Update();
                                                list.Update();
                                            }
                                            catch(Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                                        }
                                    }

                                    SPQuery query = new SPQuery();
                                    query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>Template</Value></Eq></Where>";

                                    li = null;

                                    foreach (SPListItem l in list.GetItems(query))
                                    {
                                        li = l;
                                        l["Title"] = txtTitle.Text;
                                        l.SystemUpdate();
                                        break;
                                    }

                                    if (li == null)
                                    {
                                        li = list.Items.Add();
                                        li["Title"] = txtTitle.Text;
                                        li.Update();
                                    }
                                    //w.Close();

                                    retURL = list.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + li.ID;

                                    //Response.Redirect(listUrl + "?ID=" + workspaceID + "&Source=" + retURL);
                                    
                                }
                                Response.Redirect(retURL);
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
        public bool IsAlphaNumeric(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex(@"[^a-zA-Z0-9\s]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }
    }
}
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
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;

namespace EPMLiveCore
{
    public partial class CreateWorkspace : System.Web.UI.Page
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

        
        private void populateTemplates(SPWeb site)
        {
            SortedList sl = new SortedList();
            string version = getMajorVersion(site);
            foreach (SPWebTemplate template in site.GetAvailableWebTemplates(site.Language))
            {
                if (!template.IsHidden && template.IsCustomTemplate)
                {
                    if (!template.Title.Contains("EPM Live"))
                    {
                        if (isValidTemplate(template.Title, version, site))
                        {
                            sl.Add(template.Title, template.Name);
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
                if (CoreFunctions.getConfigSetting(web, "EPMLiveHideDefaultTemplates") == "True" && template == "Project Workspace")
                    return false;
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

        private bool isValidTemplate(string template, string version)
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
            try
            {
                SPWeb mySite = SPContext.Current.Web;

                pnlTitle.Visible = false;
                pnlURL.Visible = false;
                pnlURLBad.Visible = false;
                string listname = "Workspace Center";

                string url = txtURL.Text;
                string title = txtTitle.Text;
                string group = DdlGroup.SelectedItem.Value;

                if (requiredOK)
                {
                    string err = CoreFunctions.createSite(title, url, group, SPContext.Current.Web.CurrentUser.LoginName, rdoUnique.Checked, rdoTopLinkYes.Checked, mySite);

                    if (err.Substring(0, 1) == "0")
                    {
                        try
                        {
                            SPList list = mySite.Lists["Workspace Center"];
                            list.ParentWeb.AllowUnsafeUpdates = true;
                            SPListItem li = list.Items.Add();
                            SPFieldUrlValue surl = new SPFieldUrlValue();
                            surl.Url = baseURL + url;
                            surl.Description = title;

                            li["URL"] = surl;
                            li.Update();

                            Response.Redirect(baseURL + "/Lists/" + listname + "/EditForm.aspx?ID=" + li.ID + "&Source=" + baseURL + url, false);
                        }
                        catch
                        {
                            Response.Redirect(baseURL + url, false);
                        }
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
        public bool IsAlphaNumeric(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex(@"[^a-zA-Z0-9\s]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }
    }
}
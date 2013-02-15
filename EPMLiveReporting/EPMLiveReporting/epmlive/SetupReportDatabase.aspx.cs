using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;

namespace EPMLiveReportsAdmin.Layouts.EPMLive  
{
    public partial class SetupReportDatabase : LayoutsPageBase
    {
        //protected HtmlInputRadioButton btnExisting;
        //protected HtmlInputRadioButton btnNew;
        //protected DropDownList ddlDatabaseName;
        //protected Label lblErrorSite;
        //protected Label lblErrorDatabase;
        //protected SiteAdministrationSelector SiteAdministrationSelector1;
        //protected HtmlTableRow trExisting;
        //protected HtmlTableRow trNew1;
        //protected HtmlTableRow trNew2;
        //protected HtmlTableRow trNew3;
        //protected HtmlTableRow trNew4;

        //protected HtmlTableRow trSelect;
        //protected TextBox txtDatabaseName;
        //protected TextBox txtDatabaseServer;
        //protected TextBox txtMessage;
        //protected TextBox username;
        //protected TextBox password;
        //protected CheckBox sacccount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ConfigureServerForm();
        }

        private void ConfigureServerForm()
        {
            Guid webAppId = Guid.Empty;
            if (Request.QueryString["id"] != null)
            {
                webAppId = new Guid(Request.QueryString["id"]);
                var rb = new ReportBiz(SPContext.Current.Site.ID, webAppId);
                Dictionary<string, string> databases = rb.GetDistinctDatabaseList();
                DataRow SAInfo = rb.SAccountInfo(webAppId);
                if (SAInfo != null && (bool)SAInfo["SAccount"])
                {
                    username.Text = SAInfo["Username"].ToString();
                    password.Text = SAInfo["Password"].ToString();
                    sacccount.Checked = true;
                }
            }
            btnExisting.Checked = true; //Default setting
        }

        private static void Show(HtmlControl control, bool visible)
        {
            control.Attributes.Add("style", visible ? "display:block" : "display:none");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        Guid webAppId = new Guid(Request.QueryString["id"]);
                        Guid siteId = new Guid(SiteAdministrationSelector1.CurrentId);
                        var rb = new ReportBiz(SPContext.Current.Site.ID, webAppId);
                        var databases = rb.GetDatabaseMappings();
                        string dbServer = txtDatabaseServer.Text;
                        string dbName = txtDatabaseName.Text;
                        string un = username.Text;
                        string pw = password.Text;
                        bool useSA = sacccount.Checked;
                        bool dbExists = btnExisting.Checked;
                        bool processed = false;
                        string statusMsg = string.Empty;

                        EPMData oEPM = new EPMData(siteId);
                        processed = oEPM.MapDataBase(siteId, webAppId, dbServer, dbName, un, pw, useSA, dbExists, out statusMsg);

                        if (processed)
                        {
                            Response.Redirect(SPContext.Current.Site.ServerRelativeUrl + "_admin/EPMLive/ReportDatabases.aspx");
                        }
                        else
                        {
                            ShowDatabaseError(statusMsg);
                            sacccount.Checked = false;
                            Show(trNew3, false);
                            Show(trNew4, false);
                        }

                    });
                }
                catch (Exception ex)
                {

                }
            }
        }


        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    if (Request.QueryString["id"] != null)
        //    {
        //        Guid webAppId = new Guid(Request.QueryString["id"]);
        //        var selectedSiteId = SiteAdministrationSelector1.CurrentId;
        //        var rb = new ReportBiz(SPContext.Current.Site.ID, webAppId);
        //        var databases = rb.GetDatabaseMappings();

        //        if (databases.ContainsKey(selectedSiteId))
        //        {
        //            string db;
        //            databases.TryGetValue(selectedSiteId, out db);
        //            ShowDatabaseError("This site is already mapped to a database. " + db);
        //            sacccount.Checked = false;
        //            Show(trNew3, false);
        //            Show(trNew4, false);
        //            return;
        //        }

        //        string dbServer;
        //        string dbName;
        //        dbServer = txtDatabaseServer.Text;
        //        dbName = txtDatabaseName.Text;
        //        if (dbServer.Trim().Length == 0 || dbName.Trim().Length == 0)
        //        {
        //            ShowDatabaseError("Please enter a server and a name for the new database.");
        //            sacccount.Checked = false;
        //            Show(trNew3, false);
        //            Show(trNew4, false);
        //        }
        //        else
        //        {
        //            var reportData = new ReportData(
        //            new Guid(selectedSiteId),
        //            dbName,
        //            dbServer, sacccount.Checked, username.Text, EPMData.Encrypt(password.Text));

        //            if (!reportData.CheckServerConnection())
        //            {
        //                ShowDatabaseError(reportData.GetError());
        //                if (sacccount.Checked)
        //                {
        //                    Show(trNew3, true);
        //                    Show(trNew4, true);
        //                }
        //                return;
        //            }

        //            if (btnNew.Checked)
        //            {
        //                if (reportData.DatabaseExists())
        //                {
        //                    ShowDatabaseError("The database already exists. If this is an existing valid EPM Reporting database, please check 'Existing' and select it from the list above.");
        //                    sacccount.Checked = false;
        //                    Show(trNew3, false);
        //                    Show(trNew4, false);
        //                    return;
        //                }
        //                if (!reportData.CreateDatabase())
        //                {
        //                    ShowDatabaseError(reportData.GetError());
        //                    sacccount.Checked = false;
        //                    Show(trNew3, false);
        //                    Show(trNew4, false);
        //                    return;
        //                }
        //                if (!reportData.InitializeDatabase())
        //                {
        //                    ShowDatabaseError(reportData.GetError());
        //                    sacccount.Checked = false;
        //                    Show(trNew3, false);
        //                    Show(trNew4, false);
        //                    return;
        //                }
        //            }


        //            if (btnExisting.Checked)
        //            {
        //                if (!reportData.DatabaseExists())
        //                {
        //                    ShowDatabaseError("This database does not exists.");
        //                    sacccount.Checked = false;
        //                    Show(trNew3, false);
        //                    Show(trNew4, false);
        //                    return;
        //                }

        //                if (!reportData.IsReportingDB())
        //                {
        //                    ShowDatabaseError(string.Format("Invalid database."));
        //                    sacccount.Checked = false;
        //                    Show(trNew3, false);
        //                    Show(trNew4, false);
        //                    return;
        //                }
        //            }

        //            if (sacccount.Checked && username.Text != string.Empty && password.Text != string.Empty)
        //            {
        //                reportData.UserName = username.Text;
        //                reportData.Password = EPMData.Encrypt(password.Text);
        //                reportData.UseSqlAccount = true;
        //            }
        //            else
        //            {
        //                reportData.UseSqlAccount = false;
        //            }

        //            if (reportData.InsertDbEntry())
        //            {
        //                EPMData DAO;
        //                if (sacccount.Checked)
        //                {
        //                    DAO = new EPMData(new Guid(selectedSiteId), txtDatabaseName.Text, txtDatabaseServer.Text, true, username.Text, EPMData.Encrypt(password.Text));
        //                }
        //                else
        //                {
        //                    DAO = new EPMData(new Guid(selectedSiteId));
        //                }

        //                string defaultLists = string.Empty;
        //                SPSecurity.RunWithElevatedPrivileges(delegate()
        //                {
        //                    using (SPSite spSite = new SPSite(new Guid(selectedSiteId)))
        //                    {
        //                        defaultLists = DAO.DefaultLists(spSite.RootWeb);
        //                    }
        //                });

        //                //Add RPTSettings entry 
        //                string sResult;
        //                DAO.UpdateRPTSettings(string.Empty, 0, out sResult);

        //                //Map default lists
        //                DAO.MapDefaultLists(defaultLists);

        //                //Refresh all lists data to sql table
        //                DAO.RefreshDefaultLists(defaultLists);
        //                DAO.GrantUserDbAccess();
        //                DAO.Dispose();
        //            }

        //            reportData.Dispose();
        //            Response.Redirect(SPContext.Current.Site.ServerRelativeUrl + "_admin/EPMLive/ReportDatabases.aspx");
        //        }
        //    }
        //}

        private void ShowDatabaseError(string message)
        {
            lblErrorDatabase.Text = message;
            lblErrorDatabase.Visible = true;
        }

        private void ShowSiteError(string message)
        {
            lblErrorSite.Text = message;
            lblErrorSite.Visible = true;            
        }
    }
}

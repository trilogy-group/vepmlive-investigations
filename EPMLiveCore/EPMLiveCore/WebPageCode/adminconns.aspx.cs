using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class adminconns : System.Web.UI.Page 
    {
        protected TextBox txtConnString;
        protected Label lblStatus;
        protected Label lblStatusDyn;
        protected XmlDocument xWebConfig = new XmlDocument();
        protected WebApplicationSelector WebApplicationSelector1;
        protected TextBox txtReportServer;
        protected TextBox txtDefaultPath;
        protected CheckBox chkIntegrated;
        protected CheckBox chkWindowsAuth;
        protected TextBox txtUsername;
        protected TextBox txtPassword;
        protected Button btnUpgrade;
        protected Label lblVersion;
        protected Button btnInstallDB;

        protected InputFormControl con1;
        protected InputFormControl con2;
        protected InputFormControl con3;

        protected string sCoreStatus;
        protected string sWPStatus;
        protected string sTSStatus;
        protected string sDashboardStatus;
        protected string sPFEStatus;

        protected string webappid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //GetConnSettings();
            }
        }

        protected void WebApplicationSelector1_ContextChange(object sender, EventArgs e)
        {
            GetConnSettings();
        }

        protected void GetConnSettings()
        {
            try
            {
                txtConnString.Text = "";
                SPWebApplication webApp = WebApplicationSelector1.CurrentItem;
                webappid = webApp.Id.ToString();
                string sConn = CoreFunctions.getConnectionString(webApp.Id);

                if (sConn != "")
                {
                    txtConnString.Text = sConn;
                    lblStatusDyn.Text = "Active";

                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        try
                        {
                            var curVersion = "";
                            using (var cn = new SqlConnection(sConn))
                            {
                                cn.Open();
                                using (var cmd = new SqlCommand("SELECT TOP 1 VERSION FROM VERSIONS order by dtInstalled DESC", cn))
                                {
                                    using (var dr = cmd.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            curVersion = dr.GetString(0);
                                        }
                                    }
                                }
                            }

                            lblVersion.Text = curVersion;
                            if (curVersion != CoreFunctions.GetFullAssemblyVersion())
                            {
                                btnUpgrade.Visible = true;
                                lblVersion.BackColor = Color.Red;
                            }
                        }
                        catch (Exception ex)
                        {
                            lblStatusDyn.Text = "Error: " + ex.Message;
                        }
                    });
                }
                else
                {
                    lblStatusDyn.Text = "No connection string configured.";
                    con1.Visible = false;
                    con3.Visible = false;
                    btnInstallDB.Visible = true;
                }

                ReportAuth _chrono = webApp.GetChild<ReportAuth>("ReportAuth");
                if (_chrono != null)
                {
                    txtUsername.Text = _chrono.Username;
                }

                if (SPFarm.Local.Solutions[new Guid("55aca119-d7c7-494a-b5a7-c3ade07d06eb")].DeployedWebApplications.Contains(webApp))
                    sCoreStatus = "Deployed";
                else
                    sCoreStatus = "Not Deployed";

                if(SPFarm.Local.Solutions[new Guid("98e5c373-e1a0-45ce-8124-30c203cd8003")].DeployedWebApplications.Contains(webApp))
                    sWPStatus = "Deployed";
                else
                    sWPStatus = "Not Deployed";

                if(SPFarm.Local.Solutions[new Guid("1858d521-0375-4a61-9281-f5210854bc12")].DeployedWebApplications.Contains(webApp))
                    sTSStatus = "Deployed";
                else
                    sTSStatus = "Not Deployed";

                if (SPFarm.Local.Solutions[new Guid("8f916fa9-1c2d-4416-8036-4a272256e23d")].DeployedWebApplications.Contains(webApp))
                    sDashboardStatus = "Deployed";
                else
                    sDashboardStatus = "Not Deployed";

                if(SPFarm.Local.Solutions[new Guid("5a3fe24c-2dc5-4a1c-aec1-6ce942825ceb")].DeployedWebApplications.Contains(webApp))
                    sPFEStatus = "Deployed";
                else
                    sPFEStatus = "Not Deployed";

           }
            catch (Exception exception)
            {
                lblStatusDyn.Text = "Error: " + exception.Message;
                lblStatusDyn.BackColor = System.Drawing.Color.Red;
            }

            
            try
            {
                txtReportServer.Text = CoreFunctions.getWebAppSetting(new Guid(WebApplicationSelector1.CurrentId), "ReportingServicesURL");
                txtDefaultPath.Text = CoreFunctions.getWebAppSetting(new Guid(WebApplicationSelector1.CurrentId), "ReportsRootFolder");                
                chkIntegrated.Checked = bool.Parse(CoreFunctions.getWebAppSetting(new Guid(WebApplicationSelector1.CurrentId), "ReportsUseIntegrated"));
                chkWindowsAuth.Checked = bool.Parse(CoreFunctions.getWebAppSetting(new Guid(WebApplicationSelector1.CurrentId), "ReportsWindowsAuthentication"));
            }
            catch { }
        }

        protected void btnUpgrade_Click(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWebApplication webApp = WebApplicationSelector1.CurrentItem;
                using (var cn = new SqlConnection(CoreFunctions.getConnectionString(webApp.Id)))
                {
                    cn.Open();

                    using (var cmd = new SqlCommand(Properties.Resources._0Tables01, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SqlCommand(Properties.Resources._0Tables02, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SqlCommand(Properties.Resources._1Views01, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SqlCommand(Properties.Resources._2SPs01, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SqlCommand(Properties.Resources._9Data01, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SqlCommand(Properties.Resources._9Data02, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SqlCommand("INSERT INTO VERSIONS (VERSION, DTINSTALLED) VALUES (@version, GETDATE())", cn))
                    {
                        cmd.Parameters.AddWithValue("@version", CoreFunctions.GetFullAssemblyVersion());
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Redirect("/_admin/epmlive/wcsettings.aspx?WebApplicationId=" + webApp.Id);
            });
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddorUpdateConnString();
        }

        protected void AddorUpdateConnString()
        {            
            try
            {

                if (ConnectionTest(txtConnString.Text))
                {

                    //string sVal = DropDownList1.SelectedItem.Value;
                    //SPWebApplication webApp = SPWebService.ContentService.WebApplications[new Guid(DropDownList1.SelectedValue)];
                    SPWebApplication webApp = WebApplicationSelector1.CurrentItem;

                    string sError = "";

                    CoreFunctions.setConnectionString(webApp.Id, txtConnString.Text, out sError);

                    if (sError != "")
                    {
                        lblStatusDyn.Text = "Error: " + sError;
                        lblStatusDyn.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblStatusDyn.Text = "Connection test successful & connection string updated. ";
                        lblStatusDyn.BackColor = System.Drawing.Color.LightGreen;
                    }

                    
                    
                    CoreFunctions.setWebAppSetting(new Guid(WebApplicationSelector1.CurrentId), "ReportingServicesURL", txtReportServer.Text);
                    CoreFunctions.setWebAppSetting(new Guid(WebApplicationSelector1.CurrentId), "ReportsRootFolder", txtDefaultPath.Text);
                    CoreFunctions.setWebAppSetting(new Guid(WebApplicationSelector1.CurrentId), "ReportsUseIntegrated", chkIntegrated.Checked.ToString());
                    CoreFunctions.setWebAppSetting(new Guid(WebApplicationSelector1.CurrentId), "ReportsWindowsAuthentication", chkWindowsAuth.Checked.ToString());

                    if (txtPassword.Text != "" || txtUsername.Text == "")
                    {
                        ReportAuth _chrono = webApp.GetChild<ReportAuth>("ReportAuth");
                        if (_chrono == null)
                        {
                            _chrono = new ReportAuth("ReportAuth", webApp, Guid.NewGuid());
                            _chrono.Update();
                            //webApp.Update();
                        }
                        _chrono.Username = txtUsername.Text;
                        _chrono.Password = CoreFunctions.Encrypt(txtPassword.Text, "KgtH(@C*&@Dhflosdf9f#&f");
                        _chrono.Update();
                        //webApp.Update();
                    }
                }
                else
                {
                    lblStatusDyn.Text = "Connection test unsuccessful. Invalid connection string.";
                    lblStatusDyn.BackColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception exception) 
            {
                lblStatusDyn.Text = "Error: " + exception.Message;
                lblStatusDyn.BackColor = System.Drawing.Color.Red;
            }
        }

        

        private void AddWebConfigModification(SPWebApplication webApp, string path, string name, uint sequence, string value, SPWebConfigModification.SPWebConfigModificationType type)
        {
            webApp.WebService.WebConfigModifications.Add(new SPWebConfigModification()
            {
                Path = path,
                Name = name,
                Sequence = sequence,
                Owner = "System",
                Type = type,
                Value = value
            });
        }

        

        protected bool ConnectionTest(string sDBConnStr)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (var cn = new SqlConnection())
                    {
                        cn.ConnectionString = sDBConnStr;
                        cn.Open();
                    }
                });

                return true; // success
            }
            catch
            {
                return false; 
            }
        }
    }
}

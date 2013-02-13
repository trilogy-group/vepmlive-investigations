using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;
using System.Drawing;
using System.IO;
using System.Text;

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
        protected TextBox txtUsername;
        protected TextBox txtPassword;
        

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
                //string sVal =  
                SPWebApplication webApp = WebApplicationSelector1.CurrentItem;
                //SPWebService.ContentService.WebApplications[new Guid(DropDownList1.SelectedValue)];
                
                //SPIisSettings iis = webApp.IisSettings[SPUrlZone.Default];
                string sConn = CoreFunctions.getConnectionString(webApp.Id);
                //if (File.Exists(iis.Path + "\\web.config"))
                //{
                    //xWebConfig.InnerXml = File.ReadAllText(iis.Path + "\\web.config");
                    //XmlNode nConnStr = xWebConfig.SelectSingleNode("configuration/connectionStrings/add[@name='epmlive']");

                    if (sConn != "")
                    {
                        //txtConnString.Text = nConnStr.Attributes["connectionString"].Value;
                        txtConnString.Text = sConn;
                        lblStatusDyn.Text = "Active";
                    }
                    else
                    {
                        lblStatusDyn.Text = "No connection string configured.";
                        lblStatusDyn.BackColor = System.Drawing.Color.Red;
                    }
                //}
                //else
                //{
                //    lblStatusDyn.Text = "Web config file '" + iis.Path + "\\web.config" + "' not found.";
                //    lblStatusDyn.BackColor = System.Drawing.Color.Red;
                //}

                    ReportAuth _chrono = webApp.GetChild<ReportAuth>("ReportAuth");
                    if (_chrono != null)
                    {
                        txtUsername.Text = _chrono.Username;
                    }
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


                
            }
            catch { }
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

        protected bool ConnectionTest(string sDBConnStr)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = sDBConnStr;
                    cn.Open();
                    cn.Close();
                    cn.Dispose();
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

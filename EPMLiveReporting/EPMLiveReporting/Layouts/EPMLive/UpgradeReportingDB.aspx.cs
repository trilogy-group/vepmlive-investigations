using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using EPMLiveCore;
using EPMLiveReportsAdmin.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.ReportHelper;
namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class UpgradeReportingDB : LayoutsPageBase
    {
        private List<HtmlGenericControl> _messages;

        #region Methods (9) 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var reportBiz = new ReportBiz(SPContext.Current.Site.ID);

                if (reportBiz.SiteExists()) return;

                NotConfiguredLabel.Visible = true;
                ConfiguredLabel.Visible = false;
                UpgradeButton.Enabled = false;
                UpgradeButton.CssClass += " button-green-disabled";
            }
            else
            {
                TitleLiteral.Text = "Upgrade Reporting Database - Completed";
                ConfiguredLabel.Visible = false;
                UpgradeButton.Visible = false;
            }
        }

        protected void UpgradeButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                _messages = (new UpgradeReportingDBHelper()).Upgrade();



                MessageLabel.Text = "Upgrade Result:";
            }
            catch (Exception exception)
            {
                MessageLabel.ForeColor = Color.Red;

                foreach (
                    string message in
                        exception.Message.Split(new[] { "\r", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    MessageLabel.Text += message + "<br/>";
                }

                MessageLabel.Visible = true;
            }
            finally
            {
                foreach (HtmlGenericControl htmlGenericControl in _messages)
                {
                    MessagePanel.Controls.Add(htmlGenericControl);
                }
            }
        }

        #endregion Methods 
    }
}
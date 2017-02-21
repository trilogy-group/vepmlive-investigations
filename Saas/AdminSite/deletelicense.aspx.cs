using EPMLive.OnlineLicensing.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSite
{
    public partial class deletelicense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var comment = txaComments.Value;

            using (var licenseManager = new LicenseManager())
            {
                licenseManager.DeleteLicense(Guid.Parse(Request["orderId"]), comment);
            }

            var script = $@"
                        <script>
                            parent.location.href='editaccount.aspx?account_id={Request["accountId"]}&tab=4';
                        </script>
                    ";

            ClientScript.RegisterStartupScript(this.GetType(), "RenewLicense", script);
        }
    }
}
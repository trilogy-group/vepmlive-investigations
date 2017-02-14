using EPMLive.OnlineLicensing.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSite
{
    public partial class renewlicense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRenew_Click(object sender, EventArgs e)
        {
            var newExpirationDate = TxtExpirationDate.Value;
            var orderId = "8FF388FC-6E4E-4F6D-9527-E77867AE56E2";

            using (var license = new LicenseManager())
            {
                if (!license.ValidateNewLicenseExtension())
                {
                    ShowErrorMessage("The new license expiration date should be greater than the previous.");
                    return;
                }

                license.RenewLicense(Guid.Parse(orderId), DateTime.Parse(newExpirationDate));
            }
        }

        private void ShowErrorMessage(string message)
        {
            errorLabel.InnerText = message;
            errorLabel.Visible = true;
        }
    }
}
using System;
using EPMLive.OnlineLicensing.Api;

namespace AdminSite.WebControls.Licensing
{
    public partial class InactiveLicenses : BaseWebControl
    {
        protected int AccountRef => AccountRepository.GetAccountReference(Guid.Parse(Request["account_id"]));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInactiveLicenses();
            }
        }

        private void LoadInactiveLicenses()
        {
            grdInactiveLicenses.DataSource= LicenseManager.GetAllInactiveLicenses(AccountRef);
            grdInactiveLicenses.DataBind();
        }
    }
}
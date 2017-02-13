using System;
using System.Collections.Generic;
using EPMLive.OnlineLicensing.Api;
using EPMLive.OnlineLicensing.Api.Data;

namespace AdminSite.WebControls.Product
{
    public partial class ListProductFeatures : BaseWebControl
    {
        protected IEnumerable<LicenseDetail> Features;
        private int CurrentProductId => Convert.ToInt32(Request["id"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadProductDetails();
        }


        private void LoadProductDetails()
        {
            Features = ProductCatalogManager.GetLicenseProductFeatures(CurrentProductId);
            grdProductFeatures.DataSource = Features;
            grdProductFeatures.DataBind();
        }
    }
}
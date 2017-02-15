using EPMLive.OnlineLicensing.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSite
{
    public partial class editlicense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProductCatalog();
            }

            PopulateFeatureList();
        }

        private void PopulateProductCatalog()
        {
            var licenseManager = new LicenseManager();
            var license = licenseManager.GetOrder(Guid.Parse(Request["orderId"] ?? string.Empty));

            var products = ProductCatalogManager.GetAllActiveProducts();

            foreach (var item in products)
            {
                DropDownProductCatalog.Items.Add(new ListItem
                {
                    Text = item.name,
                    Value = item.product_id.ToString(),
                });

                DropDownProductCatalog.SelectedIndex = Convert.ToInt32(license.product_id);
            }
        }

        private void PopulateFeatureList()
        {
            throw new NotImplementedException();
        }
    }
}
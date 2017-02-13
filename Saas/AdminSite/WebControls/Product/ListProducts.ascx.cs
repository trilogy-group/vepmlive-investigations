using System;
using EPMLive.OnlineLicensing.Api;

namespace AdminSite.WebControls.Product
{
    public partial class ListProducts : BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdProducts.DataSource = ProductCatalogManager.GetAllProducts();
                grdProducts.DataBind();
            }
        }

    }
}
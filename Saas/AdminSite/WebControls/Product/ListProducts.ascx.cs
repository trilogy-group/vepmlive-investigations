using System;
using OnlineLicensing.Api;
using OnlineLicensing.Api.Data;

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
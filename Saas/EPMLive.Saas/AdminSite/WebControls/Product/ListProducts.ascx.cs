using System;
using EPMLive.OnlineLicensing.Api;
using EPMLive.OnlineLicensing.Api.Data;

namespace AdminSite.WebControls.Product
{
    public partial class ListProducts : BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdProducts.DataSource = new ProductRepository(ConnectionHelper.CreateLicensingModel()).GetAllProducts();
                grdProducts.DataBind();
            }
        }

    }
}
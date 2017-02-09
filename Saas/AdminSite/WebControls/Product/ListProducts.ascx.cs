using System;
using OnlineLicensing.Api;
using OnlineLicensing.Api.Data;

namespace AdminSite.WebControls.Product
{
    public partial class ListProducts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdProducts.DataSource = ProductCatalogManager.GetAllProducts();
                grdProducts.DataBind();
            }
        }

        protected object CheckIfDeletable(object product)
        {
            var currentProduct = product as LICENSEPRODUCT;

            return currentProduct != null && currentProduct.CanBeDeleted
                ? $"| <a OnClick=\"return confirm('Are you sure you want to Delete:{currentProduct.name} ?'); \") href ='addproduct.aspx?id={currentProduct.product_id}&del=1'>Delete</a>"
                : "";
        }

        protected string ActiveToYesNo(object product)
        {
            var currentProduct = product as LICENSEPRODUCT;
            return currentProduct != null && currentProduct.active ? "Yes" : "No";
        }
    }
}
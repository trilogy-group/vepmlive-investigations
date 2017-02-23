using System;

namespace AdminSite
{
    public partial class manageproducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            //grdProducts.DataSource = ProductRepository.GetAllProducts();
        }
    }
}
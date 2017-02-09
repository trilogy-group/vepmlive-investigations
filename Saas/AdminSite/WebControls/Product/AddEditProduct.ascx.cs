using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineLicensing.Api;
using OnlineLicensing.Api.Exceptions;

namespace AdminSite.WebControls.Product
{
    public partial class AddEditProduct : System.Web.UI.UserControl
    {
        private bool EditMode => Request["edit"] == "1";
        private bool DeleteMode => Request["del"] == "1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (!EditMode && !DeleteMode) return;
            LoadProduct(Convert.ToInt32(Request["id"]));
            pnlForm.Enabled = !DeleteMode;
            txtSKU.Enabled = !EditMode && !DeleteMode;
            btnSave.Text = DeleteMode ? "Delete" : "Save";
        }

        private void LoadProduct(int productId)
        {
            var prod = ProductCatalogManager.GetProduct(productId);
            lblProductId.Text = prod.product_id.ToString();
            txtSKU.Text = prod.sku;
            txtName.Text = prod.name;
            chkActive.Checked = prod.active;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveProduct()) Response.Redirect("manageproducts.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("manageproducts.aspx");
        }

        private bool SaveProduct()
        {
            if (!EditMode && !DeleteMode)
            {
                try
                {
                    if (ProductCatalogManager.CheckForSkuDuplicate(txtSKU.Text)) { lblMessage.Text = "The SKU entered already exists for another product. "; return false; }
                    ProductCatalogManager.AddProduct(txtSKU.Text, txtName.Text, chkActive.Checked);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "There was an error saving the new product: " + ex.Message;
                    return false;
                }
            }
            else if (DeleteMode)
            {
                try
                {
                    ProductCatalogManager.DeleteProduct(Convert.ToInt32(lblProductId.Text));
                }
                catch (LicenseProductInUseException)
                {
                    lblMessage.Text = "Cannot delete this product because it is in use. ";
                    return false;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "There was an error deleting this product: " + ex.Message;
                    return false;
                }
            }
            else
            {

                try
                {
                    ProductCatalogManager.UpdateProduct(Convert.ToInt32(lblProductId.Text), txtName.Text, chkActive.Checked);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "There was an error saving the product changes: " + ex.Message;
                    return false;
                }
            }
            return true;
        }
    }
}
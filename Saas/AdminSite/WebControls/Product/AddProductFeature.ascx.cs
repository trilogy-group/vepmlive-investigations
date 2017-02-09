using System;
using OnlineLicensing.Api;

namespace AdminSite.WebControls.Product
{
    public partial class AddProductFeature : BaseWebControl
    {
        private int CurrentProductId => Convert.ToInt32(Request["id"]);
        private int CurrentFeatureId => Convert.ToInt32(Request["fid"]);
        private bool DeleteMode => Request["del"] == "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (DeleteMode) DeleteCurrentFeature();
                LoadDetailTypes();
            }
        }

        private void DeleteCurrentFeature()
        {
            try
            {
                ProductCatalogManager.DeleteProductFeature(CurrentFeatureId);
                Response.Redirect($"addproduct.aspx?id={CurrentProductId}&edit=1&tab=2");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "There was an error deleting this product: " + ex.Message;
            }
        }

        private void LoadDetailTypes()
        {
            ddlDetailType.DataTextField = "detail_name";
            ddlDetailType.DataValueField = "detail_type_id";
            ddlDetailType.DataSource = ProductCatalogManager.GetAllDetailTypes();
            ddlDetailType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveProductFeature()) Response.Redirect($"addproduct.aspx?id={CurrentProductId}&edit=1&tab=2");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect($"addproduct.aspx?id={CurrentProductId}&edit=1&tab=2");
        }


        private bool SaveProductFeature()
        {
            if (DeleteMode) return true;
            try
            {
                var detailTypeId = Convert.ToInt32(ddlDetailType.SelectedValue);

                if (ProductCatalogManager.CheckForFeatureDuplicate(CurrentProductId, detailTypeId)) { lblMessage.Text = $"The License feature: {ddlDetailType.SelectedItem.Text} is already part of the features for this product. "; return false; }
                ProductCatalogManager.AddProductFeature(CurrentProductId, detailTypeId);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "There was an error adding feature to product: " + ex.Message;
                return false;
            }
            return true;
        }
    }

}
using System;
using EPMLive.OnlineLicensing.Api;
using EPMLive.OnlineLicensing.Api.Data;

namespace AdminSite.WebControls.Product
{
    public partial class AddProductFeature : BaseWebControl
    {
        private int CurrentProductId => Convert.ToInt32(Request["id"]);
        private int CurrentFeatureId => Convert.ToInt32(Request["fid"]);
        private bool DeleteMode => Request["del"] == "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (DeleteMode) DeleteCurrentFeature();
            LoadDetailTypes();
        }

        private void DeleteCurrentFeature()
        {
            try
            {
                new ProductRepository(ConnectionHelper.CreateLicensingModel()).DeleteProductFeature(CurrentFeatureId);
                Response.Redirect($"addproduct.aspx?id={CurrentProductId}&edit=1&tab=2");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "There was an error deleting this product: " + ex.Message;
                Logger.WarnFormat("There was an error deleting this product: {0}", ex.ToString());
            }
        }

        private void LoadDetailTypes()
        {
            ddlDetailType.DataTextField = "detail_name";
            ddlDetailType.DataValueField = "detail_type_id";
            ddlDetailType.DataSource = new ProductRepository(ConnectionHelper.CreateLicensingModel()).GetAllDetailTypes();
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
                var prodManager = new ProductRepository(ConnectionHelper.CreateLicensingModel());
                if (prodManager.CheckForFeatureDuplicate(CurrentProductId, detailTypeId)) { lblMessage.Text = $"The License feature: {ddlDetailType.SelectedItem.Text} is already part of the features for this product. "; return false; }
                prodManager.AddProductFeature(CurrentProductId, detailTypeId);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "There was an error adding feature to product: " + ex.Message;
                Logger.WarnFormat("There was an error adding feature to product: {0}", ex.ToString());
                return false;
            }
            return true;
        }
    }

}
using EPMLive.OnlineLicensing.Api;
using EPMLive.OnlineLicensing.Api.Data;
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
        Table table = new Table();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProductCatalog();
                PopulateDates();
            }

            PopulateFeatureList();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var orderId = Guid.Parse(Request["orderId"]);
            var newActivationDate = DateTime.Parse(TxtNewActivationDate.Value);
            var newExpirationDate = DateTime.Parse(TxtNewExpirationDate.Value);

            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var licenseManager = new LicenseManager();

                if (!licenseManager.ValidateLicensePeriod(newActivationDate, newExpirationDate))
                {
                    ShowErrorMessage("License period must be at least 1 day.");
                    return;
                };

                if (!licenseManager.ValidateQuantitiesCannotBeAllZero(GetFeaturesAndQuantities()))
                {
                    ShowErrorMessage("At least one feature should be different that zero.");
                    return;
                }

                licenseManager.ExtendLicense(orderId, newActivationDate, newExpirationDate, GetFeaturesAndQuantities());

                var script = $@"
                        <script>
                            parent.location.href='editaccount.aspx?account_id={Request["accountId"]}&tab=4';
                        </script>
                    ";

                ClientScript.RegisterStartupScript(this.GetType(), "EditLicense", script);
            }
        }

        private void PopulateProductCatalog()
        {
            var licenseManager = new LicenseManager();
            var license = licenseManager.GetOrder(Guid.Parse(Request["orderId"] ?? string.Empty));

            var productCatalogManager = new ProductCatalogManager(ConnectionHelper.CreateLicensingModel);
            var products = productCatalogManager.GetAllActiveProducts();

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
            var orderId = Guid.Parse(Request["orderId"]);
            table.ID = "productFeaturesTable";

            var licenseManager = new LicenseManager();
            var license = licenseManager.GetOrder(orderId);

            var orderDetails = licenseManager.GetOrderDetails(orderId, Convert.ToInt32(license.product_id));

            foreach (var item in orderDetails)
            {
                var row = new TableRow();
                var cell = new TableCell();

                var tb = new TextBox() { ID = $" {item.Name.Replace(" ", "") }Qty", Text = item.Value.ToString() };
                var label = new Label() { Text = item.Name, ID = item.Id.ToString() };
                var validator = new RegularExpressionValidator() { CssClass = "QtyValidator", ControlToValidate = tb.ID, ValidationExpression = @"\d+", ErrorMessage = "Only Numbers allowed" };

                cell.Controls.Add(label);
                cell.Controls.Add(tb);
                cell.Controls.Add(validator);

                row.Cells.Add(cell);
                table.Rows.Add(row);
            }

            featureListInnerDiv.Controls.Add(table);
        }

        private void PopulateDates()
        {
            var orderId = Guid.Parse(Request["orderId"]);
            var licenseManager = new LicenseManager();
            var license = licenseManager.GetOrder(orderId);

            TxtNewActivationDate.Value = license.activation.HasValue ? license.activation.Value.ToShortDateString() : string.Empty;
            TxtNewExpirationDate.Value = license.expiration.ToShortDateString();
        }

        private List<Tuple<int, int>> GetFeaturesAndQuantities()
        {
            List<Tuple<int, int>> featureList = new List<Tuple<int, int>>();

            foreach (TableRow item in table.Rows)
            {
                var featureId = Convert.ToInt32(item.Cells[0].Controls[0].ID);
                var txtQty = item.Cells[0].Controls[1] as TextBox;
                if (txtQty != null)
                {
                    var quantity = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToInt32(txtQty.Text);
                    featureList.Add(new Tuple<int, int>(featureId, quantity));
                };
            }

            return featureList;
        }

        private void ShowErrorMessage(string message)
        {
            errorLabel.InnerText = message;
            errorLabel.Visible = true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLive.OnlineLicensing.Api;

namespace AdminSite
{
    public partial class newlicense : System.Web.UI.Page
    {
        Table table = new Table();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProductCatalog();
            }

            PopulateFeatureList();
        }

        /// <summary>
        /// Populates the product catalog drop down list with active products.
        /// </summary>
        private void PopulateProductCatalog()
        {
            var products = ProductCatalogManager.GetAllActiveProducts();

            foreach (var item in products)
            {
                DropDownProductCatalog.Items.Add(new ListItem
                {
                    Text = item.name,
                    Value = item.product_id.ToString()
                });
            }
        }

        /// <summary>
        /// Populates feature list table with active features for that product.
        /// </summary>
        private void PopulateFeatureList()
        {
            var featureList = ProductCatalogManager.GetEnabledLicenseProductFeatures(Convert.ToInt32(DropDownProductCatalog.SelectedValue));

            table.ID = "productFeaturesTable";

            foreach (var item in featureList)
            {
                var row = new TableRow();
                var cell = new TableCell();

                var tb = new TextBox() { ID = $" {item.Name.Replace(" ", "") }Qty" };
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Guid accountId = Guid.Parse(Request["accountId"]);

            var accountRef = AccountManager.GetAccountReference(accountId);
            var activationDate = Convert.ToDateTime(TxtActivationDate.Value);
            var expirationDate = Convert.ToDateTime(TxtExpirationDate.Value);
            var productId = Convert.ToInt32(DropDownProductCatalog.SelectedValue);
            var contractId = "50000010";

            if (!ValidateQuantities()) return;
            if (!ValidLicensePeriod(activationDate, expirationDate))
            {
                ShowErrorMessage("License period must be at least 1 day.");
            };
           
            var featureList = ExtractFeaturesAndQuantities();

            using (var license = new LicenseManager())
            {
                if (license.ValidateSingleActiveLicenseForProduct(productId, accountRef))
                {
                    ShowErrorMessage($"There is already an active license for the product: { DropDownProductCatalog.SelectedItem.Text }");
                }
                else
                {
                    license.AddLicense(accountRef, activationDate, expirationDate, productId, contractId, featureList);

                    var script = $@"
                        <script>
                            parent.location.href='editaccount.aspx?account_id={Request["accountId"]}&tab=4';
                        </script>
                    ";

                    ClientScript.RegisterStartupScript(this.GetType(), "AddLicense", script);
                }
            }
        }

        /// <summary>
        /// Checks that license is at least 1 day.
        /// </summary>
        /// <returns></returns>
        private bool ValidLicensePeriod(DateTime activationDate, DateTime expirationDate)
        {
            var validPeriod = expirationDate > activationDate && (expirationDate.DayOfYear - activationDate.DayOfYear) >= 1;
            if (validPeriod) return true;

            return false;
            
        }

        private void ShowErrorMessage(string message)
        {
            errorLabel.InnerText = message;
            errorLabel.Visible = true;
            return;
        }

        /// <summary>
        /// Check that no quantities are zero.
        /// </summary>
        /// <returns></returns>
        private bool ValidateQuantities()
        {
            var offendingLines = new StringBuilder();

            foreach (TableRow item in table.Rows)
            {
                var txtQty = item.Cells[0].Controls[1] as TextBox;
                if (txtQty == null) continue;
                var quantity = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToInt32(txtQty.Text);
                if (quantity > 0) continue;

                var featureName = item.Cells[0].Controls[0] as Label;
                if (featureName != null)
                {
                    offendingLines.AppendFormat("{0} Quantity is required and cannot be zero <br/>", featureName.Text);
                }
            }

            if (offendingLines.Length == 0) return true;

            errorLabel.InnerHtml = offendingLines.ToString();
            errorLabel.Visible = true;

            return false;
        }

        private List<Tuple<int, int>> ExtractFeaturesAndQuantities()
        {
            List<Tuple<int, int>> featureList = new List<Tuple<int, int>>();

            foreach (TableRow item in table.Rows)
            {
                var featureId = Convert.ToInt32(item.Cells[0].Controls[0].ID);
                var txtQty = item.Cells[0].Controls[1] as TextBox;
                if (txtQty == null) continue;
                var quantity = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToInt32(txtQty.Text);
                featureList.Add(new Tuple<int, int>(featureId, quantity));
            }

            return featureList;
        }

        protected void DropDownProductCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            table.Rows.Clear();
            PopulateFeatureList();
        }
    }
}
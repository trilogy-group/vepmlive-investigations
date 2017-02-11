using OnlineLicensing.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                PopulateFeatureList();
            }
        }

        private void PopulateProductCatalog()
        {
            var Products = ProductCatalogManager.GetAllActiveProducts();

            foreach (var item in Products)
            {
                DropDownProductCatalog.Items.Add(new ListItem
                {
                    Text = item.name,
                    Value = item.product_id.ToString()
                });
            }
        }

        private void PopulateFeatureList()
        {
            var featureList = ProductCatalogManager.GenerateProductDetail(Convert.ToInt32(DropDownProductCatalog.SelectedValue));

            table.ID = "Table1";

            foreach (var item in featureList)
            {
                var row = new TableRow();
                var cell = new TableCell();

                var tb = new TextBox() { ID = $" {item.Name.Replace(" ", "") }Qty" };
                var label = new Label() { Text = item.Name, ID = item.Id.ToString() };
                var validator = new RegularExpressionValidator() { ControlToValidate = tb.ID, ValidationExpression = @"\d+", ErrorMessage = "Only Numbers allowed" };

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
            //TODO: check for active licenses for that product, what to do if a license is active for that product?

            Guid accountId = Guid.Parse(Request["accountId"]);

            var accountRef = AccountManager.GetAccountReference(accountId);
            var activationDate = Convert.ToDateTime(TxtActivationDate.Value);
            var expirationDate = Convert.ToDateTime(TxtExpirationDate.Value);
            var productId = Convert.ToInt32(DropDownProductCatalog.SelectedValue);
            var featureList = new List<Tuple<int, int>>();

            foreach (TableRow item in table.Rows)
            {
                var featureId = Convert.ToInt32(item.Cells[0].Controls[0].ID);
                var quantity = Convert.ToInt32(string.IsNullOrEmpty((item.Cells[0].Controls[1] as TextBox).Text) ? "0" : (item.Cells[0].Controls[1] as TextBox).Text);

                featureList.Add(new Tuple<int, int>(featureId, quantity));
            }

            using (var license = new LicenseManager())
            {

                if (license.ValidateSingleActiveLicenseForProduct(productId, accountRef))
                {
                    errorLabel.InnerText = $"There is already an active license for the product: { DropDownProductCatalog.SelectedItem.Text }";
                    errorLabel.Visible = true;
                    PopulateFeatureList();
                }
                else
                {
                    license.AddLicense(accountRef, activationDate, expirationDate, productId, featureList);

                    var script = string.Format(@"
                        <script>
                            parent.location.href='editaccount.aspx?account_id={0}&tab=4';
                        </script>
                    ", Request["accountId"]);

                    ClientScript.RegisterStartupScript(this.GetType(), "AddLicense", script);
                }
            }
        }

        protected void DropDownProductCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            table.Rows.Clear();
            PopulateFeatureList();
        }
    }
}
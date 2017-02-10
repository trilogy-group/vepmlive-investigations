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
            PopulateProductCatalog();
            PopulateFeatureList();
        }

        private void PopulateProductCatalog()
        {
            List<string> Products = new List<string>() { "Epm Live Online" };

            foreach (var item in Products)
            {
                DropDownProductCatalog.Items.Add(new ListItem
                {
                    Text = "Epm Live Online",
                    Value = "9"
                });
            }

            //TODO: Add the product catalog manager to get the enabled products from the catalog, should only return epm live online

            //foreach (var item in ProductCatalogManager.GetAllProducts())
            //{
            //    DropDownProductCatalog.Items.Add(new ListItem
            //    {
            //        Text = item.name,
            //        Value = item.product_id.ToString()
            //    });
            //}
        }

        private void PopulateFeatureList()
        {
            //TODO: Get the feature list from the feature list method
            var list = new List<FeatureClass>
        {
            new FeatureClass { Id = 3, Name = "Full User" },
            new FeatureClass { Id = 1, Name = "Team Member" }
        };


            table.ID = "Table1";

            foreach (var item in list)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                var tb = new TextBox() { ID = $" {item.Name.Replace(" ", "") }Qty" };
                var label = new Label() { Text = item.Name, ID = item.Id.ToString() };


                cell.Controls.Add(label);
                cell.Controls.Add(tb);

                row.Cells.Add(cell);
                table.Rows.Add(row);
            }

            featureListInnerDiv.Controls.Add(table);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //TODO: Get the account Id from the request object
            Guid accountId = Guid.Parse("5448E44C-64AB-415D-A6D8-7E22F3EF7BD2");

            var accountRef = AccountManager.GetAccountReference(accountId);
            var activationDate = Convert.ToDateTime(TxtActivationDate.Text);
            var expirationDate = Convert.ToDateTime(TxtExpirationDate.Text);
            var productId = Convert.ToInt32(DropDownProductCatalog.SelectedValue);
            var featureList = new List<Tuple<int, int>>();

            foreach (TableRow item in table.Rows)
            {
                var featureId = Convert.ToInt32(item.Cells[0].Controls[0].ID);
                var quantity = Convert.ToInt32((item.Cells[0].Controls[1] as TextBox).Text);

                featureList.Add(new Tuple<int, int>(featureId, quantity));
            }

            using (var license = new LicenseManager())
            {
                license.AddLicense(accountRef, activationDate, expirationDate, productId, featureList);
            }
        }

        private class FeatureClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
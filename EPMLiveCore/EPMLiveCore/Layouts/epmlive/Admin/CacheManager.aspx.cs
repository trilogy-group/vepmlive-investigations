using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Web.UI.WebControls;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Telerik.Web.UI;

namespace EPMLiveCore.Layouts.epmlive.Admin
{
    public partial class CacheManager : LayoutsPageBase
    {
        #region Methods (12) 

        // Protected Methods (5) 

        protected void CacheGrid_OnDeleteCommand(object sender, GridCommandEventArgs e)
        {
            var item = e.Item as GridDataItem;

            DeleteItem(item);
        }

        protected void CacheGrid_OnItemCreated(object sender, GridItemEventArgs e)
        {
            AddGroupDeleteButton(e);
        }

        protected void CacheGrid_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            AddGroupDeleteButton(e);
        }

        protected void CacheGrid_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            LoadData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ValidateAccess();

                if (IsPostBack) return;

                GetServerInfo();
                LoadData();
            }
            catch (Exception exception)
            {
                ErrorMessage.Text = exception.Message;

                ErrorPanel.Visible = true;
                MainPanel.Visible = false;
            }
        }

        // Private Methods (7) 

        private void AddGroupDeleteButton(GridItemEventArgs e)
        {
            var header = e.Item as GridGroupHeaderItem;

            if (header == null) return;

            var c1 = new TableCell {Width = new Unit(75, UnitType.Percentage)};
            c1.Controls.Add(new Literal {Text = header.DataCell.Text});

            var delButton = new Button {Text = @"Delete", ID = header.DataCell.Text.Md5()};
            delButton.Click += delButton_Click;

            var c2 = new TableCell {Width = new Unit(25, UnitType.Percentage)};
            c2.Controls.Add(delButton);

            var table = new Table {Width = new Unit(100, UnitType.Percentage)};
            table.Rows.Add(new TableRow());

            table.Rows[0].Cells.Add(c1);
            table.Rows[0].Cells.Add(c2);

            header.DataCell.Controls.Add(table);
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            var btn = (Button) sender;

            var container = (GridGroupHeaderItem) btn.NamingContainer;
            DeleteItemsForCategory(container.DataCell.Text.Replace("Category: ", string.Empty));

            CacheGrid.Rebind();
        }

        private static void DeleteItem(GridDataItem item)
        {
            if (item == null) return;

            string key = item["Key"].Text;
            CacheStore.Current.Remove(key);
        }

        private void DeleteItemsForCategory(string category)
        {
            CacheStore.Current.RemoveCategory(category);
        }

        private void GetServerInfo()
        {
            ServerName.Text = (string) CacheStore.Current.Get("ServerName", CacheStoreCategory.Infrastructure, () =>
            {
                string domainName = IPGlobalProperties.GetIPGlobalProperties().DomainName;
                string hostName = Dns.GetHostName();

                string fqdn = !hostName.Contains(domainName) ? hostName + "." + domainName : hostName;

                return fqdn.ToUpper();
            }, true).Value;
        }

        private void LoadData()
        {
            CacheGrid.DataSource = CacheStore.Current.GetDataTable();
        }

        private void ValidateAccess()
        {
            if (!Web.CurrentUser.IsSiteAdmin && !Web.DoesUserHavePermissions(SPBasePermissions.FullMask))
            {
                throw new Exception(
                    @"You need to be either ""Site Admin"" or ""Site Collection Admin"" to access this page.");
            }
        }

        #endregion Methods 
    }
}
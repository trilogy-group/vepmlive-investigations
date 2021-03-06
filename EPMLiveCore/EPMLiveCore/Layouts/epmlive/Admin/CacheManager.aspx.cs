﻿using System;
using System.Data;
using System.Linq;
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
        #region Fields (1) 

        private long _totalBytes;

        #endregion Fields 

        #region Methods (14) 

        // Protected Methods (5) 

        /// <inheritdoc />
        public sealed override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ErrorPanel?.Dispose();
                ErrorMessage?.Dispose();
                MainPanel?.Dispose();
                ServerName?.Dispose();
                MemoryAllocation?.Dispose();
                RadAjaxManager?.Dispose();
                CacheGrid?.Dispose();
            }
        }

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
                CalculateMemoryAllocation();
            }
            catch (Exception exception)
            {
                ErrorMessage.Text = exception.Message;

                ErrorPanel.Visible = true;
                MainPanel.Visible = false;
            }
        }

        // Private Methods (9) 

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

        private void CalculateMemoryAllocation()
        {
            string memoryAllocation;

            if (_totalBytes < 2)
            {
                memoryAllocation = _totalBytes + " byte";
            }
            else if (_totalBytes < 1024)
            {
                memoryAllocation = _totalBytes + " bytes";
            }
            else if (_totalBytes < 131072)
            {
                memoryAllocation = _totalBytes/1024 + " KB";
            }
            else
            {
                memoryAllocation = _totalBytes/131072 + " MB";
            }

            MemoryAllocation.Text = @"~" + memoryAllocation;
        }

        private void CalculateSize(DataTable dataTable)
        {
            dataTable.Columns.Add("Size", typeof (long));

            DataColumnCollection cols = dataTable.Columns;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                DataRow row = dataRow;
                long size = (from DataColumn col in cols
                    select col.ColumnName
                    into columnName
                    where !columnName.Equals("Size")
                    select row[columnName]
                    into value
                    where value != null && value != DBNull.Value
                    select value).Sum(value => value.GetSize());

                dataRow["Size"] = size;
                _totalBytes += size;
            }
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
            CacheStore.Current.Remove(key, new CacheStoreCategory().Navigation);
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
            DataTable dataTable = CacheStore.Current.GetDataTable();

            CalculateSize(dataTable);

            CacheGrid.DataSource = dataTable;
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
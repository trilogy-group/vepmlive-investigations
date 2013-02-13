using System;
using System.Data;
using System.Data.SqlClient;
using EPMLiveReportsAdmin;
using Microsoft.SharePoint;

namespace EPMLiveCore.TagManager
{
    internal class TagOrderRepository
    {
        #region Fields (1) 

        private readonly SPWeb _spWeb;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="TagOrderRepository" /> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public TagOrderRepository(SPWeb spWeb)
        {
            _spWeb = spWeb;
        }

        #endregion Constructors 

        #region Methods (3) 

        // Public Methods (3) 

        /// <summary>
        ///     Adds the specified tag order.
        /// </summary>
        /// <param name="tagOrder">The tag order.</param>
        /// <returns></returns>
        public TagOrder Add(TagOrder tagOrder)
        {
            TagOrder order = Find(tagOrder.TagId, tagOrder.ListId, tagOrder.ItemId);

            if (order != null)
            {
                return order;
            }

            var epmData = new EPMData(_spWeb.Site.ID)
                              {
                                  Command =
                                      @"INSERT INTO TagOrders (TagId, ListId, ItemId, TagOrder) VALUES (@TagId, @ListId, @ItemId, 
                                               (SELECT (SELECT COALESCE(MAX(TagOrder), 0) FROM TagOrders WHERE TagId = @TagId) + 1))",
                                  CommandType = CommandType.Text
                              };

            epmData.Params.Add(new SqlParameter("@TagId", tagOrder.TagId));
            epmData.Params.Add(new SqlParameter("@ListId", tagOrder.ListId));
            epmData.Params.Add(new SqlParameter("@ItemId", tagOrder.ItemId));

            epmData.ExecuteNonQuery(epmData.GetClientReportingConnection);

            return Find(tagOrder.TagId, tagOrder.ListId, tagOrder.ItemId);
        }

        /// <summary>
        ///     Finds the specified tag id.
        /// </summary>
        /// <param name="tagId">The tag id.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="itemId">The item id.</param>
        /// <returns></returns>
        public TagOrder Find(Guid tagId, Guid listId, int itemId)
        {
            var epmData = new EPMData(_spWeb.Site.ID)
                              {
                                  Command =
                                      @"SELECT TagOrderId, TagOrder FROM TagOrders WHERE TagId = @TagId AND ListId = @ListId AND ItemId = @ItemId",
                                  CommandType = CommandType.Text
                              };

            epmData.Params.Add(new SqlParameter("@TagId", tagId));
            epmData.Params.Add(new SqlParameter("@ListId", listId));
            epmData.Params.Add(new SqlParameter("@ItemId", itemId));

            DataTable dataTable = epmData.GetTable(epmData.GetClientReportingConnection);

            if (dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];
                return new TagOrder((Guid) dataRow["TagOrderId"])
                           {ItemId = itemId, ListId = listId, Order = (int) dataRow["TagOrder"], TagId = tagId};
            }

            return null;
        }

        /// <summary>
        ///     Removes the specified tag order.
        /// </summary>
        /// <param name="tagOrder">The tag order.</param>
        public void Remove(TagOrder tagOrder)
        {
            TagOrder order = Find(tagOrder.TagId, tagOrder.ListId, tagOrder.ItemId);

            if (order == null) return;

            var epmData = new EPMData(_spWeb.Site.ID)
                              {
                                  Command =
                                      @"DELETE FROM TagOrders WHERE TagId = @TagId AND ListId = @ListId AND ItemId = @ItemId",
                                  CommandType = CommandType.Text
                              };

            epmData.Params.Add(new SqlParameter("@TagId", tagOrder.TagId));
            epmData.Params.Add(new SqlParameter("@ListId", tagOrder.ListId));
            epmData.Params.Add(new SqlParameter("@ItemId", tagOrder.ItemId));

            epmData.ExecuteNonQuery(epmData.GetClientReportingConnection);
        }

        #endregion Methods 
    }
}
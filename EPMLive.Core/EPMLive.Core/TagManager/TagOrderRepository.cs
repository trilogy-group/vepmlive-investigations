using System;
using System.Collections.Generic;
using System.Data;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.TagManager
{
    internal class TagOrderRepository
    {
        #region Fields (2) 

        private readonly QueryExecutor _queryExecutor;
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
            _queryExecutor = new QueryExecutor(_spWeb);
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

            _queryExecutor.ExecuteEpmLiveNonQuery(
                @"INSERT INTO TagOrders (TagId, ListId, ItemId, TagOrder) VALUES (@TagId, @ListId, @ItemId, (SELECT (SELECT COALESCE(MAX(TagOrder), 0) FROM TagOrders WHERE TagId = @TagId) + 1))",
                new Dictionary<string, object>
                    {
                        {"@TagId", tagOrder.TagId},
                        {"@ListId", tagOrder.ListId},
                        {"@ItemId", tagOrder.ItemId}
                    });

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
            DataTable dataTable = _queryExecutor.ExecuteEpmLiveQuery(
                @"SELECT TagOrderId, TagOrder FROM TagOrders WHERE TagId = @TagId AND ListId = @ListId AND ItemId = @ItemId",
                new Dictionary<string, object> {{"@TagId", tagId}, {"@ListId", listId}, {"@ItemId", itemId}});

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

            _queryExecutor.ExecuteEpmLiveNonQuery(
                @"DELETE FROM TagOrders WHERE TagId = @TagId AND ListId = @ListId AND ItemId = @ItemId",
                new Dictionary<string, object>
                    {
                        {"@TagId", tagOrder.TagId},
                        {"@ListId", tagOrder.ListId},
                        {"@ItemId", tagOrder.ItemId}
                    });
        }

        #endregion Methods 
    }
}
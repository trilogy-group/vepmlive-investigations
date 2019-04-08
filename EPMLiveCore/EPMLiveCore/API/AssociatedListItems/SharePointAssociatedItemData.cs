using System;
using System.Collections;
using System.Data;
using System.Text;

namespace EPMLiveCore.API
{
    internal class SharePointAssociatedItemData
    {
        internal SharePointAssociatedItemData(ArrayList associatedLists, StringBuilder sqlGetListHeaders, DataTable listNameDataTable, string projectLinkedField, string itemId, string sourceUrl,
            Guid listId,
            string itemTitle)
        {
            AssociatedLists = associatedLists;
            SqlGetListHeaders = sqlGetListHeaders;
            ListNameDataTable = listNameDataTable;
            ProjectLinkedField = projectLinkedField;
            ItemId = itemId;
            SourceUrl = sourceUrl;
            ListId = listId;
            ItemTitle = itemTitle;
        }

        internal ArrayList AssociatedLists { get; private set; }
        internal StringBuilder SqlGetListHeaders { get; private set; }
        internal DataTable ListNameDataTable { get; set; }
        internal string ProjectLinkedField { get; set; }
        internal string ItemId { get; private set; }
        internal string SourceUrl { get; private set; }
        internal Guid ListId { get; private set; }
        internal string ItemTitle { get; private set; }
    }
}
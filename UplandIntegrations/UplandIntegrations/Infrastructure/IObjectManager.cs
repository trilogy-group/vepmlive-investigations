using System;
using System.Collections.Generic;
using System.Data;
using EPMLiveIntegration;

namespace UplandIntegrations.Infrastructure
{
    internal interface IObjectManager
    {
        #region Operations (5) 

        IEnumerable<IntTransactionResult> DeleteItems(string[] itemIds, Guid integrationId);

        List<ColumnProperty> GetColumns();

        IEnumerable<IntObject> GetItems(string[] itemIds);

        string TranslateIdToUserEmail(string userId);

        IEnumerable<IntTransactionResult> UpsertItems(DataTable items, Guid integrationId);

        #endregion Operations 
    }
}
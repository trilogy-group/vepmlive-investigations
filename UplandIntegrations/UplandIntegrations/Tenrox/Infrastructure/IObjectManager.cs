using System;
using System.Collections.Generic;
using System.Data;
using EPMLiveIntegration;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal interface IObjectManager
    {
        #region Operations (4) 

        IEnumerable<TenroxTransactionResult> DeleteItems(int[] itemIds, Guid integrationId);

        List<ColumnProperty> GetColumns();

        IEnumerable<TenroxObject> GetItems(int[] itemIds);

        IEnumerable<TenroxTransactionResult> UpsertItems(DataTable items, Guid integrationId);

        #endregion Operations 
    }
}
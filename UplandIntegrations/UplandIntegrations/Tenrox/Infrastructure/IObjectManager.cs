using System;
using System.Collections.Generic;
using System.Data;
using EPMLiveIntegration;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal interface IObjectManager
    {
        #region Operations (3) 

        List<ColumnProperty> GetColumns();

        IEnumerable<TenroxObject> GetItems(int[] itemIds);

        IEnumerable<TenroxUpsertResult> UpsertItems(DataTable items, Guid integrationId, string integrationKey);

        #endregion Operations 
    }
}
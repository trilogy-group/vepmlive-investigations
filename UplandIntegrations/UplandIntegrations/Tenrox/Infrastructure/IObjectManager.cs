using System.Collections.Generic;
using System.Data;
using EPMLiveIntegration;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal interface IObjectManager
    {
        #region Operations (4) 

        List<ColumnProperty> GetColumns();

        IEnumerable<TenroxObject> GetItems(int[] itemIds);

        void UpdateBinding(int itemId, int objectType, string integrationKey);

        IEnumerable<TenroxUpsertResult> UpsertItems(DataTable items, string integrationKey);

        #endregion Operations 
    }
}
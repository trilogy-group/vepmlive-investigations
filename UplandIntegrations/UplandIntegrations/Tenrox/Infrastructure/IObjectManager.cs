using System.Collections.Generic;
using EPMLiveIntegration;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal interface IObjectManager
    {
        #region Operations (2) 

        List<ColumnProperty> GetColumns();

        IEnumerable<TenroxObject> GetItems(int[] itemIds);

        #endregion Operations 
    }
}
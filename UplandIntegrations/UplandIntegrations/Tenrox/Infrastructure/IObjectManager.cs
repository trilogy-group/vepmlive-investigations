using System.Collections.Generic;
using EPMLiveIntegration;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal interface IObjectManager
    {
        #region Operations (1) 

        List<ColumnProperty> GetColumns();

        #endregion Operations 
    }
}
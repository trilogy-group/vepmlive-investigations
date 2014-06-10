using PortfolioEngineCore.Services.DataServices.Core;

namespace PortfolioEngineCore.Services.DataServices.Contracts
{
    internal interface IDataServiceModule
    {
        #region Operations (1) 

        void Initialize(DataServiceEvents serviceEvents);

        #endregion Operations 
    }
}
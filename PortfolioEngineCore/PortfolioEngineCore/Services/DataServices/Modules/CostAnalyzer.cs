using System;
using PortfolioEngineCore.Services.DataServices.Contracts;
using PortfolioEngineCore.Services.DataServices.Core;

namespace PortfolioEngineCore.Services.DataServices.Modules
{
    internal class CostAnalyzer : IDataServiceModule
    {
        #region Implementation of IDataServiceModule

        public void Initialize(DataServiceEvents serviceEvents)
        {
            serviceEvents.OnValidateRequest += OnValidateRequest;
            serviceEvents.OnProcessRequest += OnProcessRequest;
        }

        private void OnProcessRequest(ProcessRequestEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void OnValidateRequest(ProcessRequestEventArgs args)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
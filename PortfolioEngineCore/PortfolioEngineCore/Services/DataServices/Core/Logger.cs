using System;

namespace PortfolioEngineCore.Services.DataServices.Core
{
    internal class Logger
    {
        #region Methods (2) 

        // Public Methods (2) 

        public void LogError(Guid transactionId, string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void LogProgress(Guid transactionId, decimal percentage)
        {
            throw new NotImplementedException();
        }

        #endregion Methods 
    }
}
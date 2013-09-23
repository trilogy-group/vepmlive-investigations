using EPMLiveIntegration;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal class TenroxUpsertResult
    {
        #region Constructors (1) 

        public TenroxUpsertResult(int id, TransactionType transactionType, string error = null)
        {
            Error = error;
            TransactionType = transactionType;
            Id = id;
        }

        #endregion Constructors 

        #region Properties (4) 

        public string Error { get; private set; }

        public int Id { get; private set; }

        public bool Success
        {
            get { return string.IsNullOrEmpty(Error); }
        }

        public TransactionType TransactionType { get; private set; }

        #endregion Properties 
    }
}
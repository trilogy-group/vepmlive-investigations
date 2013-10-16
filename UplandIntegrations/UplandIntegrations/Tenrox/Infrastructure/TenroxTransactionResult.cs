using EPMLiveIntegration;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal class TenroxTransactionResult
    {
        #region Constructors (1) 

        public TenroxTransactionResult(int id, int spId, object txObject, TransactionType transactionType,
            string error = null)
        {
            TxObject = txObject;
            SpId = spId;
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
        public int SpId { get; private set; }
        public object TxObject { get; private set; }

        #endregion Properties 
    }
}
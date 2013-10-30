using EPMLiveIntegration;

namespace UplandIntegrations.Infrastructure
{
    internal class IntTransactionResult
    {
        #region Constructors (1) 

        public IntTransactionResult(string id, int spId, object intObject, TransactionType transactionType,
            string error = null)
        {
            IntObject = intObject;
            SpId = spId;
            Error = error;
            TransactionType = transactionType;
            Id = id;
        }

        #endregion Constructors 

        #region Properties (6) 

        public string Error { get; private set; }

        public string Id { get; private set; }

        public object IntObject { get; private set; }

        public int SpId { get; private set; }

        public bool Success
        {
            get { return string.IsNullOrEmpty(Error); }
        }

        public TransactionType TransactionType { get; private set; }

        #endregion Properties 
    }
}
using EPMLiveIntegration;

namespace EPMLiveCore.Integrations.Office365.Infrastructure
{
    internal class O365Result
    {
        #region Fields (4) 

        private readonly string _error;
        private readonly int _itemId;
        private readonly bool _success;
        private readonly TransactionType _transactionType;

        #endregion Fields 

        #region Constructors (1) 

        public O365Result(int itemId, TransactionType transactionType, bool success = true, string error = null)
        {
            _itemId = itemId;
            _transactionType = transactionType;
            _success = success;
            _error = error;
        }

        #endregion Constructors 

        #region Properties (4) 

        public string Error
        {
            get { return _error; }
        }

        public int? ItemId
        {
            get { return _itemId == 0 ? (int?) null : _itemId; }
        }

        public bool Success
        {
            get { return _success; }
        }

        public TransactionType TransactionType
        {
            get { return _transactionType; }
        }

        #endregion Properties 
    }
}
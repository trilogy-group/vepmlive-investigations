namespace PortfolioEngineCore.Services.DataServices.Core
{
    public delegate void TransactionDelegate<in T>(T e);

    public class TransactionProgressedEventArgs
    {
        #region Fields (1) 

        private readonly decimal _progressPercentage;

        #endregion Fields 

        #region Constructors (1) 

        public TransactionProgressedEventArgs(decimal progressPercentage)
        {
            _progressPercentage = progressPercentage;
        }

        #endregion Constructors 

        #region Properties (1) 

        public decimal ProgressPercentage
        {
            get { return _progressPercentage; }
        }

        #endregion Properties 
    }

    public class TransactionCanceledEventArgs
    {
        #region Fields (1) 

        private readonly string _cancellationReason;

        #endregion Fields 

        #region Constructors (1) 

        public TransactionCanceledEventArgs(string cancellationReason)
        {
            _cancellationReason = cancellationReason;
        }

        #endregion Constructors 

        #region Properties (1) 

        public string CancellationReason
        {
            get { return _cancellationReason; }
        }

        #endregion Properties 
    }

    public class TransactionCompletedEventArgs
    {
        #region Fields (1) 

        private readonly object _data;

        #endregion Fields 

        #region Constructors (1) 

        public TransactionCompletedEventArgs(object data)
        {
            _data = data;
        }

        #endregion Constructors 

        #region Properties (1) 

        public object Data
        {
            get { return _data; }
        }

        #endregion Properties 
    }
}
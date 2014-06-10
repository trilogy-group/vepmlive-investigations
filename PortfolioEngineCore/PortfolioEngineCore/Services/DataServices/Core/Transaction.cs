using System;

namespace PortfolioEngineCore.Services.DataServices.Core
{
    public class Transaction
    {
        #region Fields (4) 

        private readonly ActionKind _actionKind;
        private readonly Guid _id;
        private readonly Logger _logger;
        private readonly ModuleKind _moduleKind;

        #endregion Fields 

        #region Constructors (1) 

        internal Transaction(ModuleKind moduleKind, ActionKind actionKind, Logger logger)
        {
            _moduleKind = moduleKind;
            _actionKind = actionKind;
            _logger = logger;
            _id = Guid.NewGuid();
        }

        #endregion Constructors 

        #region Properties (7) 

        public ActionKind ActionKind
        {
            get { return _actionKind; }
        }

        public Guid Id
        {
            get { return _id; }
        }

        internal Logger Logger
        {
            get { return _logger; }
        }

        public ModuleKind ModuleKind
        {
            get { return _moduleKind; }
        }

        public TransactionDelegate<TransactionCanceledEventArgs> OnCanceled { get; set; }

        public TransactionDelegate<TransactionCompletedEventArgs> OnComplete { get; set; }

        public TransactionDelegate<TransactionProgressedEventArgs> OnProgressed { get; set; }

        #endregion Properties 

        #region Methods (3) 

        // Internal Methods (3) 

        internal void Cancel(string message)
        {
            if (OnCanceled != null) OnCanceled(new TransactionCanceledEventArgs(message));
        }

        internal void Complete(object data)
        {
            if (OnComplete != null) OnComplete(new TransactionCompletedEventArgs(data));
        }

        internal void ReportProgress(decimal percentage)
        {
            if (OnProgressed != null) OnProgressed(new TransactionProgressedEventArgs(percentage));
        }

        #endregion Methods 
    }
}
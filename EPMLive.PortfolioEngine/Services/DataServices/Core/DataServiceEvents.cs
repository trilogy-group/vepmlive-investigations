using System.Collections.Generic;

namespace PortfolioEngineCore.Services.DataServices.Core
{
    internal delegate void DataServiceModuleDelegate<in T>(T e);

    internal class DataServiceEvents
    {
        #region Properties (4) 

        public string CancellationReason { get; set; }

        public bool IsCanceled { get; set; }

        public DataServiceModuleDelegate<ProcessRequestEventArgs> OnProcessRequest { get; set; }

        public DataServiceModuleDelegate<ProcessRequestEventArgs> OnValidateRequest { get; set; }

        #endregion Properties 
    }

    internal class ProcessRequestEventArgs
    {
        #region Fields (2) 

        private readonly Dictionary<string, object> _data;
        private readonly Transaction _transaction;

        #endregion Fields 

        #region Constructors (1) 

        public ProcessRequestEventArgs(Transaction transaction, Dictionary<string, object> data)
        {
            _transaction = transaction;
            _data = data;
        }

        #endregion Constructors 

        #region Properties (4) 

        public ActionKind ActionKind
        {
            get { return _transaction.ActionKind; }
        }

        public Dictionary<string, object> Data
        {
            get { return _data; }
        }

        public ModuleKind ModuleKind
        {
            get { return _transaction.ModuleKind; }
        }

        public Transaction Transaction
        {
            get { return _transaction; }
        }

        #endregion Properties 
    }
}
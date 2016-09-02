using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PortfolioEngineCore.Services.DataServices.Contracts;
using PortfolioEngineCore.Services.DataServices.Core;

namespace PortfolioEngineCore.Services.DataServices
{
    public class Controller
    {
        #region Fields (4) 

        private static volatile Controller _instance;
        private static readonly object Locker = new object();
        private readonly DataServiceEvents _events;
        private readonly Logger _logger;

        #endregion Fields 

        #region Constructors (1) 

        private Controller()
        {
            _logger = new Logger();
            _events = new DataServiceEvents();

            LoadModules();
        }

        #endregion Constructors 

        #region Properties (1) 

        public static Controller Current
        {
            get
            {
                if (_instance != null) return _instance;

                lock (Locker)
                {
                    if (_instance == null)
                    {
                        _instance = new Controller();
                    }
                }

                return _instance;
            }
        }

        #endregion Properties 

        #region Methods (2) 

        // Public Methods (1) 

        public Transaction ProcessRequest(ModuleKind moduleKind, ActionKind actionKind,
            Dictionary<string, object> data)
        {
            var transaction = new Transaction(moduleKind, actionKind, _logger);

            Task.Factory.StartNew(() =>
            {
                var eventArgs = new ProcessRequestEventArgs(transaction, data);

                if (_events.OnValidateRequest != null) _events.OnValidateRequest(eventArgs);

                if (!_events.IsCanceled)
                {
                    try
                    {
                        if (_events.OnProcessRequest != null) _events.OnProcessRequest(eventArgs);
                    }
                    catch (Exception exception)
                    {
                        transaction.Cancel(exception.Message);
                    }
                }
                else
                {
                    transaction.Cancel(_events.CancellationReason);
                }
            });

            return transaction;
        }

        // Private Methods (1) 

        private void LoadModules()
        {
            IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in types)
            {
                if (t.IsInterface || !t.GetInterfaces().Contains(typeof (IDataServiceModule))) continue;

                var module = Activator.CreateInstance(t) as IDataServiceModule;
                if (module != null) module.Initialize(_events);
            }
        }

        #endregion Methods 
    }
}
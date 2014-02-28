using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.SocialEngine.Contracts;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Events;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine
{
    internal sealed class SocialEngine
    {
        #region Fields (4) 

        private static volatile SocialEngine _instance;
        private static readonly object Locker = new Object();
        private readonly SocialEngineEvents _events;
        private readonly Logger _logger;

        #endregion Fields 

        #region Constructors (1) 

        private SocialEngine()
        {
            _logger = new Logger();
            _events = new SocialEngineEvents();

            LoadModules();
        }

        #endregion Constructors 

        #region Properties (1) 

        public static SocialEngine Current
        {
            get
            {
                if (_instance != null) return _instance;

                lock (Locker)
                {
                    if (_instance == null)
                    {
                        _instance = new SocialEngine();
                    }
                }

                return _instance;
            }
        }

        #endregion Properties 

        #region Methods (2) 

        // Private Methods (1) 

        private void LoadModules()
        {
            Parallel.ForEach(AssemblyManager.Current.GetTypes(), t =>
            {
                if (t.IsInterface || !t.GetInterfaces().Contains(typeof (ISocialEngineModule))) return;

                var module = Activator.CreateInstance(t) as ISocialEngineModule;
                if (module != null) module.Initialize(_events);
            });
        }

        // Internal Methods (1) 

        internal void ProcessActivity(ObjectKind objectKind, ActivityKind activityKind,
            Dictionary<string, object> data, SPWeb spWeb)
        {
            try
            {
                using (var transactionScope = new TransactionScope())
                {
                    using (var streamManager = new StreamManager(spWeb))
                    {
                        using (var threadManager = new ThreadManager(spWeb))
                        {
                            using (var activityManager = new ActivityManager(spWeb))
                            {
                                var args = new ProcessActivityEventArgs(objectKind, activityKind, data, spWeb,
                                    streamManager, threadManager, activityManager);

                                if (_events.OnValidateActivity != null)
                                {
                                    _events.OnValidateActivity(args);
                                }

                                if (!args.Cancel)
                                {
                                    if (_events.OnActivityRegistration != null)
                                    {
                                        _events.OnActivityRegistration(args);
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(args.CancellationMessage))
                                    {
                                        _logger.Log(objectKind, activityKind, data, spWeb, args.CancellationMessage);
                                    }
                                }
                            }
                        }
                    }

                    transactionScope.Complete();
                }
            }
            catch (AggregateException exception)
            {
                foreach (Exception innerException in exception.InnerExceptions)
                {
                    _logger.Log(objectKind, activityKind, data, spWeb, innerException);
                }
            }
            catch (Exception exception)
            {
                _logger.Log(objectKind, activityKind, data, spWeb, exception);
            }
        }

        #endregion Methods 
    }
}
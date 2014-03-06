using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using EPMLiveCore.API;
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

        #region Methods (4) 

        // Private Methods (2) 

        private void BuildRequestContext(XDocument request, out ObjectKind objectKind, out ActivityKind activityKind,
            out Dictionary<string, object> data)
        {
            data = new Dictionary<string, object>();

            XElement root = request.Root;

            if (root == null) throw new Exception("Missing root level element: ProcessActivity");

            XAttribute objKindAttr = root.Attribute("ObjectKind");
            XAttribute actKindAttr = root.Attribute("ActivityKind");

            if (objKindAttr == null) throw new Exception("Missing ObjectKind attribute on ProcessActivity element");
            if (actKindAttr == null) throw new Exception("Missing Activity attribute on ProcessActivity element");

            string objKind = objKindAttr.Value;
            string actKind = actKindAttr.Value;

            Enum.TryParse(objKind, out objectKind);
            Enum.TryParse(actKind, out activityKind);

            foreach (XElement element in root.Elements())
            {
                string key = element.Name.LocalName;
                object value;

                string val = element.Value;

                XAttribute dtAttr = element.Attribute("DataType");
                if (dtAttr == null)
                {
                    throw new Exception(string.Format("Missing DataType attribute on ProcessActivity/{0} element", key));
                }

                string dataType = dtAttr.Value;
                switch (dataType.ToLower())
                {
                    case "null":
                        value = null;
                        break;
                    case "guid":
                        value = Guid.Parse(val);
                        break;
                    case "datetime":
                        value = DateTime.Parse(val);
                        break;
                    case "int32":
                        value = int.Parse(val);
                        break;
                    default:
                        value = val;
                        break;
                }

                if (!data.ContainsKey(key))
                {
                    data.Add(key, value);
                }
            }
        }

        private void LoadModules()
        {
            Parallel.ForEach(AssemblyManager.Current.GetTypes(), t =>
            {
                if (t.IsInterface || !t.GetInterfaces().Contains(typeof (ISocialEngineModule))) return;

                var module = Activator.CreateInstance(t) as ISocialEngineModule;
                if (module != null) module.Initialize(_events);
            });
        }

        // Internal Methods (2) 

        internal void ProcessActivity(string data, SPWeb contextWeb)
        {
            try
            {
                XDocument request = XDocument.Parse(data);

                ObjectKind objectKind;
                ActivityKind activityKind;
                Dictionary<string, object> dataDict;

                BuildRequestContext(request, out objectKind, out activityKind, out dataDict);

                string result = Current.ProcessActivity(objectKind, activityKind, dataDict, contextWeb);

                if (string.IsNullOrEmpty(result)) return;

                bool multiple = result.Contains(",");

                throw new Exception(
                    string.Format("One or more error occured. Check out logs with {0} correlation id{1}: {2}",
                        multiple ? "these" : "this", multiple ? "s" : string.Empty, result));
            }
            catch (Exception exception)
            {
                throw new APIException(66001, exception.Message);
            }
        }

        internal string ProcessActivity(ObjectKind objectKind, ActivityKind activityKind,
            Dictionary<string, object> data, SPWeb spWeb)
        {
            var correlationIds = new List<Guid>();

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
            catch (AggregateException e)
            {
                correlationIds.AddRange(
                    e.InnerExceptions.Select(i => _logger.Log(objectKind, activityKind, data, spWeb, i)));
            }
            catch (Exception exception)
            {
                correlationIds.Add(_logger.Log(objectKind, activityKind, data, spWeb, exception));
            }

            return string.Join(", ", correlationIds.ToArray());
        }

        #endregion Methods 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
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
        private object _locker;

        #endregion Fields 

        #region Constructors (1) 

        private SocialEngine()
        {
            _locker = new object();
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

        #region Methods (5) 

        // Private Methods (3) 

        private void BuildRequestContext(XDocument request, out ObjectKind objectKind, out ActivityKind activityKind,
            out Dictionary<string, object> data, out Guid siteId, out Guid webId, out SPUserToken userToken)
        {
            data = new Dictionary<string, object>();

            XElement root = request.Root;

            if (root == null) throw new Exception("Missing root level element: ProcessActivity");

            XAttribute objKindAttr = root.Attribute("ObjectKind");
            XAttribute actKindAttr = root.Attribute("ActivityKind");

            if (objKindAttr == null) throw new Exception("Missing ObjectKind attribute on ProcessActivity element");
            if (actKindAttr == null) throw new Exception("Missing Activity attribute on ProcessActivity element");

            XElement context = root.Element("Context");
            if (context == null) throw new Exception("Missing element: ProcessActivity/Context");

            XAttribute siteIdAttr = context.Attribute("SiteId");
            XAttribute webIdAttr = context.Attribute("WebId");
            XAttribute userIdAttr = context.Attribute("UserId");

            if (siteIdAttr == null) throw new Exception("Missing SiteId attribute on Context element");
            if (webIdAttr == null) throw new Exception("Missing WebId attribute on Context element");
            if (userIdAttr == null) throw new Exception("Missing UserId attribute on Context element");

            int userId;

            if (!Guid.TryParse(siteIdAttr.Value, out siteId))
            {
                throw new Exception(siteIdAttr.Value + " is not a valid Site ID");
            }

            if (!Guid.TryParse(webIdAttr.Value, out webId))
            {
                throw new Exception(webIdAttr.Value + " is not a valid Web ID");
            }

            if (!int.TryParse(userIdAttr.Value, out userId))
            {
                throw new Exception(userIdAttr.Value + " is not a valid User ID");
            }

            Guid sid = siteId;
            SPUserToken token = null;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var spSite = new SPSite(sid))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        token = spWeb.AllUsers.GetByID(userId).UserToken;
                    }
                }
            });

            userToken = token;

            string objKind = objKindAttr.Value;
            string actKind = actKindAttr.Value;

            Enum.TryParse(objKind, out objectKind);
            Enum.TryParse(actKind, out activityKind);

            foreach (XElement element in root.Elements())
            {
                string key = element.Name.LocalName;

                if (key.Equals("Context")) continue;

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
                    case "boolean":
                        value = bool.Parse(val);
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
            IEnumerable<Type> types = AssemblyManager.Current.GetTypes();

            foreach (Type t in types)
            {
                if (t.IsInterface || !t.GetInterfaces().Contains(typeof (ISocialEngineModule))) continue;

                var module = Activator.CreateInstance(t) as ISocialEngineModule;
                if (module != null) module.Initialize(_events);
            }
        }

        private void LogCancellation(ObjectKind objectKind, ActivityKind activityKind, Dictionary<string, object> data,
            SPWeb spWeb,
            ProcessActivityEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.CancellationMessage))
            {
                _logger.Log(objectKind, activityKind, data, spWeb, args.CancellationMessage);
            }
        }

        // Internal Methods (2) 

        internal string ProcessActivity(string data)
        {
            try
            {
                XDocument request = XDocument.Parse(data);

                ObjectKind objectKind;
                ActivityKind activityKind;
                Dictionary<string, object> dataDict;

                Guid siteId;
                Guid webId;
                SPUserToken userToken;

                BuildRequestContext(request, out objectKind, out activityKind, out dataDict, out siteId, out webId,
                    out userToken);

                string result = null;

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var spSite = new SPSite(siteId, userToken))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb(webId))
                        {
                            result = Current.ProcessActivity(objectKind, activityKind, dataDict, spWeb);
                        }
                    }
                });

                if (string.IsNullOrEmpty(result)) return string.Empty;

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
            lock (_locker)
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
                                        if (_events.OnPreActivityRegistration != null)
                                        {
                                            _events.OnPreActivityRegistration(args);
                                        }
                                    }

                                    if (!args.Cancel)
                                    {
                                        if (_events.OnActivityRegistration != null)
                                        {
                                            _events.OnActivityRegistration(args);
                                        }
                                    }

                                    if (!args.Cancel)
                                    {
                                        if (_events.OnPostActivityRegistration != null)
                                        {
                                            _events.OnPostActivityRegistration(args);
                                        }
                                    }

                                    if (args.Cancel)
                                    {
                                        LogCancellation(objectKind, activityKind, data, spWeb, args);
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
        }

        #endregion Methods 
    }
}
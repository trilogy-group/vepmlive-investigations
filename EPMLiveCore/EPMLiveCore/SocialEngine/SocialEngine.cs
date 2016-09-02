using System;
using System.Collections.Generic;
using System.Data;
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
        #region Fields (5) 

        private static volatile SocialEngine _instance;
        private static readonly object Locker = new Object();
        private readonly SocialEngineEvents _events;
        private readonly object _locker;
        private readonly Logger _logger;

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

        #region Methods (6) 

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

            foreach (var module in (from t in types
                where !t.IsInterface && t.GetInterfaces().Contains(typeof (ISocialEngineModule))
                select Activator.CreateInstance(t)).OfType<ISocialEngineModule>())
            {
                module.Initialize(_events);
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

        // Internal Methods (3) 

        internal DataTable GetActivities(SPWeb contextWeb, DateTime? minDate, DateTime? maxDate, int? page, int? limit,
            Guid? threadId)
        {
            try
            {
                using (var dbConnectionManager = new DBConnectionManager(contextWeb))
                {
                    try
                    {
                        var activityManager = new ActivityManager(dbConnectionManager);
                        return activityManager.GetActivities(contextWeb.CurrentUser.ID, contextWeb.ServerRelativeUrl,
                            minDate, maxDate, page, limit, threadId);
                    }
                    catch (AggregateException e)
                    {
                        foreach (Exception exception in e.InnerExceptions)
                        {
                            _logger.Log(contextWeb, exception);
                        }

                        throw e.Flatten();
                    }
                    catch (Exception exception)
                    {
                        _logger.Log(contextWeb, exception);
                        throw;
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Log(contextWeb, exception);
                throw;
            }
        }

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
            var correlationIds = new List<Guid>();

            try
            {
                using (var dbConnectionManager = new DBConnectionManager(spWeb))
                {
                    try
                    {
                        var streamManager = new StreamManager(dbConnectionManager);
                        var threadManager = new ThreadManager(dbConnectionManager);
                        var activityManager = new ActivityManager(dbConnectionManager);

                        var args = new ProcessActivityEventArgs(objectKind, activityKind, data, spWeb,
                            streamManager, threadManager, activityManager);

                        lock (_locker)
                        {
                            using (var transactionScope = new TransactionScope())
                            {
                                if (_events.OnActivityRegistrationRequest != null)
                                {
                                    _events.OnActivityRegistrationRequest(args);
                                }

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
                                    args.UntransactionedOperation =
                                        () => LogCancellation(objectKind, activityKind, data, spWeb, args);

                                    args.EcecuteUntransactionedOperation = true;
                                }

                                transactionScope.Complete();
                            }
                        }

                        if (args.EcecuteUntransactionedOperation)
                        {
                            args.UntransactionedOperation();
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
                }
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
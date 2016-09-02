using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.WorkEngineService;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine
{
    public static class SocialEngineProxy
    {
        #region Fields (1) 

        private static readonly object Locker = new object();

        #endregion Fields 

        #region Methods (5) 

        // Public Methods (5) 

        public static void ClearTransaction(Guid transactionId, SPWeb contextWeb)
        {
            try
            {
                lock (Locker)
                {
                    using (var dbConnectionManager = new DBConnectionManager(contextWeb))
                    {
                        var transactionManager = new TransactionManager(dbConnectionManager);
                        transactionManager.ClearTransaction(transactionId);
                    }
                }
            }
            catch (Exception exception)
            {
                new Logger().Log(contextWeb, exception);
            }
        }

        public static DataTable GetActivities(SPWeb contextWeb, DateTime? minDate = null, DateTime? maxDate = null,
            int? page = null, int? limit = null, Guid? threadId = null)
        {
            return SocialEngine.Current.GetActivities(contextWeb, minDate, maxDate, page, limit, threadId);
        }

        public static Guid? GetTransaction(Guid webId, Guid listId, int itemId, SPWeb contextWeb)
        {
            try
            {
                using (var dbConnectionManager = new DBConnectionManager(contextWeb))
                {
                    var transactionManager = new TransactionManager(dbConnectionManager);
                    var transaction = transactionManager.GetTransaction(webId, listId, itemId);

                    return transaction != null ? (Guid?) transaction.Id : null;
                }
            }
            catch (Exception exception)
            {
                new Logger().Log(contextWeb, exception);
            }

            return Guid.Empty;
        }

        public static string ProcessActivity(ObjectKind objectKind, ActivityKind activityKind,
            Dictionary<string, object> data, SPWeb contextWeb)
        {
            try
            {
                string webUrl = contextWeb.Url;

                var request = new XElement("ProcessActivity",
                    new XAttribute("ObjectKind", objectKind),
                    new XAttribute("ActivityKind", activityKind),
                    new XElement("Context",
                        new XAttribute("SiteId", contextWeb.Site.ID),
                        new XAttribute("WebId", contextWeb.ID),
                        new XAttribute("UserId", contextWeb.CurrentUser.ID)));

                foreach (var property in data)
                {
                    request.Add(new XElement(property.Key,
                        new XAttribute("DataType", property.Value == null ? "NULL" : property.Value.GetType().Name),
                        new XCData((property.Value ?? string.Empty).ToString())));
                }

                using (var api = new WorkEngine())
                {
                    api.Url = webUrl + (webUrl.EndsWith("/") ? string.Empty : "/") + "_vti_bin/WorkEngine.asmx";
                    api.UseDefaultCredentials = true;
                    return api.Execute("SocialEngine_ProcessActivity", request.ToString());
                }
            }
            catch (Exception exception)
            {
                new Logger().Log(objectKind, activityKind, data, contextWeb, exception);
            }

            return null;
        }

        public static Guid SetTransaction(Guid webId, Guid listId, int itemId, string componentName, SPWeb contextWeb)
        {
            try
            {
                lock (Locker)
                {
                    using (var dbConnectionManager = new DBConnectionManager(contextWeb))
                    {
                        var transactionManager = new TransactionManager(dbConnectionManager);
                        return transactionManager.SetTransaction(webId, listId, itemId, componentName).Id;
                    }
                }
            }
            catch (Exception exception)
            {
                new Logger().Log(contextWeb, exception);
            }

            return Guid.Empty;
        }

        #endregion Methods 
    }
}
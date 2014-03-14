using System;
using System.Collections.Generic;
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

        #region Methods (4) 

        // Public Methods (4) 

        public static void ClearTransaction(Guid transactionId, SPWeb contextWeb)
        {
            try
            {
                lock (Locker)
                {
                    using (var transactionManager = new TransactionManager(contextWeb))
                    {
                        transactionManager.ClearTransaction(transactionId);
                    }
                }
            }
            catch (Exception exception)
            {
                new Logger().Log(contextWeb, exception);
            }
        }

        public static Guid GetTransaction(Guid webId, Guid listId, int itemId, SPWeb contextWeb)
        {
            try
            {
                using (var transactionManager = new TransactionManager(contextWeb))
                {
                    return transactionManager.GetTransaction(webId, listId, itemId).Id;
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
                    using (var transactionManager = new TransactionManager(contextWeb))
                    {
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
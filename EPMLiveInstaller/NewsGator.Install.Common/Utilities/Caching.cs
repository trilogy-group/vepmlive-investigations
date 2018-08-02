using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsGator.Install.Common.Output;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Caching
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NewsGator"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static OutputQueue SetCachingConfiguration(bool? cacheSuggestAhead, bool? cacheContent, string cacheName,
            int? nGramTTL, int? eventCacheTTL, int? notificationCacheTTL, int? userCacheTTL, int? channelOpenTimeout, int? requestTimeout, string cacheServers)
        {
            var output = new OutputQueue();

            try
            {
                var cacheSettingsType = NewsGator.Install.Common.Entities.SocialSites.Caching.CacheSettings.CacheSettingsType;
                if (cacheSettingsType == null)
                    throw new InvalidOperationException("Cannot load NewsGator.Caching assembly.");

                var constructor = cacheSettingsType.GetConstructors(Reflection.AllBindings).First();
                var cacheSettings = constructor.Invoke(new object[] { });

                var instance = Reflection.GetPropertyValue(cacheSettingsType, cacheSettings, "Instance");

                if (cacheSuggestAhead.HasValue)
                    Reflection.SetPropertyValue(instance, "CacheSuggestAheadEnabled", cacheSuggestAhead.Value);

                if (cacheContent.HasValue)
                    Reflection.SetPropertyValue(instance, "CacheContentEnabled", cacheContent.Value);

                if (!string.IsNullOrEmpty(cacheName))
                    Reflection.SetPropertyValue(instance, "CacheName", cacheName);

                if (nGramTTL.HasValue)
                    Reflection.SetPropertyValue(instance, "SocialFeedServiceSAnGramCacheTTL", nGramTTL.Value);

                if (eventCacheTTL.HasValue)
                    Reflection.SetPropertyValue(instance, "SocialFeedServiceEventCacheTTL", eventCacheTTL.Value);

                if (notificationCacheTTL.HasValue)
                    Reflection.SetPropertyValue(instance, "SocialFeedServiceNotificationCacheTTL", notificationCacheTTL.Value);

                if (userCacheTTL.HasValue)
                    Reflection.SetPropertyValue(instance, "SocialFeedServiceUserCacheTTL", userCacheTTL.Value);

                if (channelOpenTimeout.HasValue)
                    Reflection.SetPropertyValue(instance, "CacheChannelOpenTimeout", channelOpenTimeout.Value);

                if (requestTimeout.HasValue)
                    Reflection.SetPropertyValue(instance, "CacheRequestTimeout", requestTimeout.Value);

                if (!string.IsNullOrEmpty(cacheServers))
                    Reflection.SetPropertyValue(instance, "CacheServers", cacheServers);

                Reflection.ExecuteMethod(instance.GetType(), instance, "Update", new Type[] { }, new object[] { });
            }
            catch (Exception exception)
            {
                output.Add(exception.Message, OutputType.Error, null, exception);
            }

            return output;
        }
    }
}

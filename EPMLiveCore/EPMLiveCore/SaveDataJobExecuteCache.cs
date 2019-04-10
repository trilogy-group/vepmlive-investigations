using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class SaveDataJobExecuteCache : IDisposable
    {
        [ThreadStatic] private static SaveDataJobExecuteCache _cache;

        private readonly Lazy<SPSite> _elevatedSite;
        private readonly Dictionary<string, SPWeb> _websCache = new Dictionary<string, SPWeb>();
        private readonly Dictionary<string, SPWeb> _websByRelativeUrlCache = new Dictionary<string, SPWeb>();

        /// <summary>
        /// Mapping of tuples of Web relative URL, and List ID to SPListItemCollection
        /// </summary>
        private readonly Dictionary<Tuple<string, Guid>, SPListItemCollection> _itemsCache = new Dictionary<Tuple<string, Guid>, SPListItemCollection>();

        public static SaveDataJobExecuteCache Cache => _cache;

        public static SaveDataJobExecuteCache InitializeCache(SPSite site)
        {
            if (_cache != null)
            {
                throw new InvalidOperationException();
            }

            _cache = new SaveDataJobExecuteCache(site);
            return _cache;
        }

        public static SPSite GetSiteFromCache(bool elevated, Func<SPSite> noCacheCallback)
        {
            if (!ShouldUseCache)
            {
                return noCacheCallback();
            }

            return !elevated ? Cache.Site : Cache._elevatedSite.Value;
        }

        public static void DisposeSite(SPSite site)
        {
            if (ShouldUseCache && (site == Cache.Site || (Cache._elevatedSite.IsValueCreated && site == Cache._elevatedSite.Value)))
            {
                return;
            }

            site.Dispose();
        }

        public static SPWeb GetWeb(SPItemEventProperties properties)
        {
            return ShouldUseCache ? Cache.GetWebByRelativeUrl(properties.RelativeWebUrl) : properties.Web;
        }

        public static SPList GetList(SPItemEventProperties properties)
        {
            return ShouldUseCache ? GetWeb(properties).Lists[properties.ListId] : properties.List;
        }

        public static SPListItem GetListItem(SPItemEventProperties properties)
        {
            return ShouldUseCache 
                ? Cache.GetListItem(properties.RelativeWebUrl, properties.ListId, properties.ListItemId)
                : properties.ListItem;
        }

        private static bool ShouldUseCache => _cache != null;

        private SaveDataJobExecuteCache(SPSite site)
        {
            Site = site;
            _elevatedSite = new Lazy<SPSite>(() =>
            {
                SPSite result = null;
                SPSecurity.RunWithElevatedPrivileges(() => result = new SPSite(site.ID));
                return result;
            });
        }

        public SPSite Site { get; }

        public SPWeb GetWeb(string id)
        {
            SPWeb result;
            if (!_websCache.TryGetValue(id, out result))
            {
                result = Site.OpenWeb(new Guid(id));
                _websCache.Add(id, result);
                _websByRelativeUrlCache.Add(result.ServerRelativeUrl, result);
            }

            return result;
        }

        public SPWeb GetWebByRelativeUrl(string relativeWebUrl)
        {
            return _websByRelativeUrlCache[relativeWebUrl];
        }

        /// <summary>
        /// Bulk loading of list items
        /// </summary>
        /// <param name="items">Triples of Web ID, List ID and Item ID</param>
        /// <returns>Tuple of error presence flag and error message</returns>
        public Tuple<bool, string> PreloadListItems(IEnumerable<ListItemInfo> items)
        {
            _itemsCache.Clear();
            var groupByLists = items
                .Where(i => !string.IsNullOrEmpty(i.WebId) && !string.IsNullOrEmpty(i.ListId) && !string.IsNullOrEmpty(i.ListItemId))
                .GroupBy(i => Tuple.Create(i.WebId, i.ListId), i => i.ListItemId);
            var anyError = false;
            var errors = new StringBuilder();
            foreach (var listInfo in groupByLists)
            {
                var web = GetWeb(listInfo.Key.Item1);
                var list = web.Lists[new Guid(listInfo.Key.Item2)];

                try
                {
                    var query = new SPQuery();
                    query.RowLimit = (uint)listInfo.Count();
                    var values = string.Join(string.Empty, listInfo.Select(itemId => $"<Value Type='Counter'>{itemId}</Value>"));
                    query.Query = $"<Where><In><FieldRef Name='ID' /><Values>{values}</Values></In></Where>";
                    query.MeetingInstanceId = -2; // It is part of SPList.GetItemById() implementation and so kept here
                    _itemsCache.Add(Tuple.Create(web.ServerRelativeUrl, list.ID), list.GetItems(query));
                }
                catch (Exception ex)
                {
                    anyError = true;
                    errors.Append($"Items ({string.Join(", ", listInfo)}) Error: {ex}");
                }
            }

            return Tuple.Create(anyError, errors.ToString());
        }

        public SPListItem GetListItem(string relativeWebUrl, Guid listId, int itemId)
        {
            return _itemsCache[Tuple.Create(relativeWebUrl, listId)].GetItemById(itemId);
        }

        void IDisposable.Dispose()
        {
            foreach (var web in _websCache.Values)
            {
                web.Dispose();
            }

            // NOTE: Site should be disposed by caller, only elevated site is disposed here
            if (_elevatedSite.IsValueCreated)
            {
                _elevatedSite.Value.Dispose();
            }

            _cache = null;
        }

        public class ListItemInfo
        {
            public string WebId { get; set; }

            public string ListId { get; set; }

            public string ListItemId { get; set; }
        }
    }
}

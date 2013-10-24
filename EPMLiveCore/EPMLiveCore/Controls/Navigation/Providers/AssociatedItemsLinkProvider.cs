using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "AssociatedItems")]
    public class AssociatedItemsLinkProvider : NavLinkProvider
    {
        #region Fields (3) 

        private const string LIST_URL =
            @"javascript:SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', {{ url: '{0}?lookupfield={1}&LookupFieldList={2}', showMaximized: true }});";

        private const string PARENT_WEB_LIST_ITEM_QUERY =
            @"SELECT TOP(1) ParentWebId, ItemListId AS ParentListId, ItemId AS ParentItemId FROM RPTWeb WHERE WebId = @WebId";

        private readonly string _key;

        #endregion Fields 

        #region Constructors (1) 

        public AssociatedItemsLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username)
        {
            _key = "NavLinks_AssociatedItems_W_" + WebId + "_U_" + UserId;
        }

        #endregion Constructors 

        #region Methods (4) 

        // Private Methods (4) 

        private void GetAssociatedItems(List<NavLink> links)
        {
            Guid parentWebId = Guid.Empty;
            Guid parentListId = Guid.Empty;
            int parentItemId = 0;

            ParentWebListItemId(ref parentWebId, ref parentListId, ref parentItemId);

            if (parentWebId == Guid.Empty || parentListId == Guid.Empty || parentItemId <= 0) return;

            links.Add(new NavLink
            {
                Title = @"Associated Items<span class=""icon-info-2"" style=""padding-left: 8px;"" title=""Since this Workspace was created from an Item in the parent site, you have access to these associated parent Lists and Libraries."" data-delay=""100"" data-placement=""right"" data-toggle=""tooltip""></span>",
                Url = "Header"
            });

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(parentWebId))
                {
                    SPList spList = null;

                    try
                    {
                        spList = spWeb.Lists.GetList(parentListId, false);
                    }
                    catch { }

                    if (spList == null) return;

                    NavLink navLink = GetLink(spList, parentItemId);

                    if (navLink != null)
                    {
                        links.Add(navLink);
                    }

                    links.AddRange(from object associatedList in ListCommands.GetAssociatedLists(spList)
                        where associatedList != null
                        select (AssociatedListInfo) associatedList
                        into listInfo
                        select GetLink(listInfo, spList)
                        into link
                        where link != null
                        select link);
                }
            }
        }

        private NavLink GetLink(AssociatedListInfo listInfo, SPList spList)
        {
            SPList list = null;

            try
            {
                list = spList.ParentWeb.Lists.GetList(listInfo.ListId, false);
            }
            catch { }

            return list == null
                ? null
                : new NavLink
                {
                    Id = listInfo.ListId.ToString(),
                    Title = listInfo.Title,
                    Url = string.Format(LIST_URL, list.DefaultViewUrl, listInfo.LinkedField, spList.ID)
                };
        }

        private NavLink GetLink(SPList spList, int itemId)
        {
            SPListItem item = null;

            try
            {
                item = spList.GetItemById(itemId);
            }
            catch { }

            if (item == null) return null;

            Guid listId = spList.ID;

            return new NavLink
            {
                Id = listId + "-" + itemId,
                Title = item.Title,
                Url = string.Format(
                    @"javascript:OpenCreateWebPageDialog('{0}/_layouts/15/epmlive/redirectionproxy.aspx?action=view&webid={1}&listid={2}&id={3}');",
                    RelativeUrl, spList.ParentWeb.ID, listId, itemId)
            };
        }

        private void ParentWebListItemId(ref Guid parentWebId, ref Guid parentListId, ref int parentItemId)
        {
            DataTable dataTable = null;

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    if (!spWeb.IsRootWeb)
                    {
                        try
                        {
                            var queryExecutor = new QueryExecutor(spWeb);
                            dataTable = queryExecutor.ExecuteReportingDBQuery(PARENT_WEB_LIST_ITEM_QUERY,
                                new Dictionary<string, object>
                                {
                                    {"@WebId", WebId}
                                });
                        }
                        catch { }
                    }
                }
            }

            if (dataTable == null || dataTable.Rows.Count <= 0) return;

            DataRow row = dataTable.Rows[0];

            string webId = S(row["ParentWebId"]);
            if (string.IsNullOrEmpty(webId)) return;

            var pWebId = new Guid(webId);
            if (Guid.Empty == pWebId) return;

            parentWebId = pWebId;

            string listId = S(row["ParentListId"]);
            if (string.IsNullOrEmpty(listId)) return;

            var pListId = new Guid(listId);
            if (Guid.Empty == pListId) return;

            parentListId = pListId;

            string itemId = S(row["ParentItemId"]);
            if (string.IsNullOrEmpty(itemId)) return;

            int id;
            if (!int.TryParse(itemId, out id)) return;

            if (id > 0)
            {
                parentItemId = id;
            }
        }

        #endregion Methods 

        #region Overrides of NavLinkProvider

        protected override string Key
        {
            get { return _key; }
        }

        public override IEnumerable<INavObject> GetLinks()
        {
            return (IEnumerable<INavObject>) CacheStore.Current.Get(_key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>();

                GetAssociatedItems(links);

                return links;
            }).Value;
        }

        #endregion
    }
}
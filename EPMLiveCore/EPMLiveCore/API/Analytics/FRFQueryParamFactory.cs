using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;

namespace EPMLiveCore.API
{
    public static class FRFQueryParamFactory
    {
        public static Dictionary<string, object> GetParam(AnalyticsData data)
        {
            var queryParams = new Dictionary<string, object>();
            switch (data.Type)
            {
                case AnalyticsType.Favorite:
                    queryParams = GetFavoriteQueryParams(data);
                    break;
                case AnalyticsType.Frequent:
                    queryParams = GetFrequentQueryParams(data);
                    break;
                case AnalyticsType.Recent:
                    queryParams = GetRecentItemQueryParams(data);
                    break;
                case AnalyticsType.FavoriteWorkspace:
                    break;

            }

            return queryParams;
        }

        #region PARAM CATEOGRY FACADES

        private static Dictionary<string, object> GetFavoriteQueryParams(AnalyticsData data)
        {
            var queryParams = new Dictionary<string, object>();
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    queryParams = GetCreateFavoriteQueryParams(data);
                    break;
                case AnalyticsAction.Read:
                    queryParams = GetFavoriteStatusQueryParams(data);
                    break;
                case AnalyticsAction.Update:
                    break;
                case AnalyticsAction.Delete:
                    queryParams = GetRemoveFavoriteQueryParams(data);
                    break;

            }

            return queryParams;
        }

        private static Dictionary<string, object> GetFrequentQueryParams(AnalyticsData data)
        {
            var queryParams = new Dictionary<string, object>();
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    queryParams = GetCreateFrequentQueryParams(data);
                    break;
                case AnalyticsAction.Read:
                    queryParams = GetReadFrequentQueryParams(data);
                    break;
                case AnalyticsAction.Update:
                    break;
                case AnalyticsAction.Delete:
                    queryParams = GetDeleteFrequentQueryParams(data);
                    break;

            }

            return queryParams;
        }

        private static Dictionary<string, object> GetRecentItemQueryParams(AnalyticsData data)
        {
            var queryParams = new Dictionary<string, object>();
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    queryParams = GetCreateRecentItemQueryParams(data);
                    break;

            }

            return queryParams;
        }

        #endregion

        #region FAVORITES

        private static Dictionary<string, object> GetFavoriteStatusQueryParams(AnalyticsData data)
        {
            return data.IsItem ?
                    new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", data.ItemId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                        
                    }
                    :
                    new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@userid", data.UserId},
                        {"@fstring", data.FString}
                    };
        }

        private static Dictionary<string, object> GetRemoveFavoriteQueryParams(AnalyticsData data)
        {
            return data.IsItem ?
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", data.ItemId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            :
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            ;
        }

        private static Dictionary<string, object> GetCreateFavoriteQueryParams(AnalyticsData data)
        {
            return data.IsItem ?
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", data.ItemId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            :
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", DBNull.Value},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            ;
        }

        #endregion

        #region FREQUENT APPS

        private static Dictionary<string, object> GetCreateFrequentQueryParams(AnalyticsData data)
        {
            return new Dictionary<string, object>
                        {
                            {"@siteid", data.SiteId},
                            {"@webid", data.WebId},
                            {"@listid", data.ListId},
                            {"@userid", data.UserId},
                            {"@icon", data.Icon},
                            {"@title", data.Title},
                        };
        }

        private static Dictionary<string, object> GetReadFrequentQueryParams(AnalyticsData data)
        {
            return data.IsItem ?
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", data.ItemId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            :
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            ;
        }

        private static Dictionary<string, object> GetUpdateFrequentQueryParams(AnalyticsData data)
        {
            return data.IsItem ?
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", data.ItemId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            :
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", DBNull.Value},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            ;
        }

        private static Dictionary<string, object> GetDeleteFrequentQueryParams(AnalyticsData data)
        {
            return data.IsItem ?
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", data.ItemId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            :
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", DBNull.Value},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            ;
        }

        #endregion

        #region RECENT ITEMS

        private static Dictionary<string, object> GetCreateRecentItemQueryParams(AnalyticsData data)
        {
            return new Dictionary<string, object>
                        {
                            {"@siteid", data.SiteId},
                            {"@webid", data.WebId},
                            {"@listid", data.ListId},
                            {"@itemid", data.ItemId},
                            {"@userid", data.UserId},
                            {"@icon", data.Icon},
                            {"@title", data.Title},
                        };
        }

        #endregion
    }
}

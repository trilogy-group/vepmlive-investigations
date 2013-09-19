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
                    queryParams = GetFavQueryParams(data);
                    break;
                case AnalyticsType.Frequent:
                    break;
                case AnalyticsType.Recent:
                    break;
                case AnalyticsType.FavoriteWorkspace:
                    break;

            }

            return queryParams;
        }

        private static Dictionary<string, object> GetFavQueryParams(AnalyticsData data)
        {
            var queryParams = new Dictionary<string, object>();
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    queryParams = GetAddFavoriteQueryParams(data);
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

        private static Dictionary<string, object> GetAddFavoriteQueryParams(AnalyticsData data)
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
    }
}

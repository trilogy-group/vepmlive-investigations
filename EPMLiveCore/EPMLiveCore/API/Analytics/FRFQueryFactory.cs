using System.Diagnostics;
using EPMLiveCore.Helpers;

namespace EPMLiveCore.API
{
    public static class FRFQueryFactory
    {
        public static string GetQuery(AnalyticsData data)
        {
            Guard.ArgumentIsNotNull(data, nameof(data));

            switch (data.Type)
            {
                case AnalyticsType.Favorite:
                    return GetFavoriteQueries(data);
                case AnalyticsType.Frequent:
                    return GetFrequentQueries(data);
                case AnalyticsType.Recent:
                    return GetRecentQueries(data);
                case AnalyticsType.FavoriteWorkspace:
                    return GetFavoriteWorkspaceQueries(data);
                default:
                    Trace.WriteLine($"Unexpected type {data.Type}");
                    return string.Empty;
            }
        }

        private static string GetFavoriteQueries(AnalyticsData data)
        {
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    return GetCreateFavoriteQuery(data);
                case AnalyticsAction.Read:
                    return GetReadFavoriteQuery(data);
                case AnalyticsAction.Update:
                    return string.Empty;
                case AnalyticsAction.Delete:
                    return GetRemoveFavoriteQuery(data);
                default:
                    Trace.WriteLine($"Unexpected action {data.Action}");
                    return string.Empty;
            }
        }

        private static string GetFavoriteWorkspaceQueries(AnalyticsData data)
        {
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    return GetCreateFavWorkSpaceQuery(data);
                case AnalyticsAction.Read:
                    return GetReadFavWorkSpaceQuery(data);
                case AnalyticsAction.Update:
                    return string.Empty;
                case AnalyticsAction.Delete:
                    return GetRemoveFavWorkSpaceQuery(data);
                default:
                    Trace.WriteLine($"Unexpected action {data.Action}");
                    return string.Empty;
            }
        }

        private static string GetFrequentQueries(AnalyticsData data)
        {
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    return GetCreateFrequentQuery(data);
                case AnalyticsAction.Read:
                    return GetReadFrequentQuery(data);
                case AnalyticsAction.Update:
                    return GetUpdateFrequentQuery(data);
                case AnalyticsAction.Delete:
                    return GetRemoveFrequentQuery(data);
                default:
                    Trace.WriteLine($"Unexpected action {data.Action}");
                    return string.Empty;
            }
        }

        private static string GetRecentQueries(AnalyticsData data)
        {
            if(data.Action == AnalyticsAction.Create)
            {
                return GetCreateRecentItemQuery(data);
            }

            return string.Empty;
        }

        private static string GetCreateFavoriteQuery(AnalyticsData data)
        {
            return data.IsItem ? FRFQueries.QueryCreateFavItem : FRFQueries.QueryCreateFavNonItem;
        }

        private static string GetRemoveFavoriteQuery(AnalyticsData data)
        {
            return data.IsItem ? FRFQueries.QueryRemoveFavItem : FRFQueries.QueryRemoveFavNonItem;
        }

        private static string GetReadFavoriteQuery(AnalyticsData data)
        {
            return data.IsItem ? FRFQueries.QueryCheckFavStatusItem : FRFQueries.QueryCheckFavStatusNonItem;
        }

        private static string GetCreateFavWorkSpaceQuery(AnalyticsData data)
        {
            return data.IsItem ? FRFQueries.QueryCreateFavWSItem : FRFQueries.QueryCreateFavWSNonItem;
        }

        private static string GetRemoveFavWorkSpaceQuery(AnalyticsData data)
        {
            return data.IsItem ? FRFQueries.QueryRemoveFavWSItem : FRFQueries.QueryRemoveFavWSNonItem;
        }

        private static string GetReadFavWorkSpaceQuery(AnalyticsData data)
        {
            return data.IsItem ? FRFQueries.QueryReadFavWSStatusItem : FRFQueries.QueryReadFavWSStatusNonItem;
        }

        private static string GetCreateFrequentQuery(AnalyticsData data)
        {
            return FRFQueries.QueryCreateFrequent;
        }

        private static string GetRemoveFrequentQuery(AnalyticsData data)
        {
            return data.IsItem ? FRFQueries.QueryRemoveFrequentItem : FRFQueries.QueryRemoveFrequentNonItem;
        }

        private static string GetReadFrequentQuery(AnalyticsData data)
        {
            return data.IsItem ? FRFQueries.QueryCheckFrequentStatusItem : FRFQueries.QueryCheckFrequentStatusNonItem;
        }

        private static string GetUpdateFrequentQuery(AnalyticsData data)
        {
            return data.IsItem ? FRFQueries.QueryCheckFrequentStatusItem : FRFQueries.QueryCheckFrequentStatusNonItem;
        }

        private static string GetCreateRecentItemQuery(AnalyticsData data)
        {
            return FRFQueries.QueryCreateRecentItem;
        }
    }
}

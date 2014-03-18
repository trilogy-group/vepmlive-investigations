using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Services.DataContracts.SocialEngine;
using EPMLiveCore.SocialEngine;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveCore.Services
{
    [ServiceContract(Namespace = "http://api.epmlive.com/SocialEngine", Name = "SocialEngine")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SocialEngine
    {
        #region Methods (12) 

        // Public Methods (1) 

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/activities")]
        [OperationContract]
        public DailyActivities GetActivities()
        {
            const int LIMIT = 20;
            const int PAGE = 1;
            SqlDateTime minDate = SqlDateTime.MinValue;
            DateTime maxDate = DateTime.Now;

            SPWeb spWeb = SPContext.Current.Web;
            var activityRows = new List<DataRow>();

            GetActivities(activityRows, spWeb, minDate.Value, maxDate, PAGE, LIMIT);

            if (!activityRows.Any()) return null;

            var dailyActivities = new DailyActivities
            {
                days = new List<DailyActivities.Day>(),
                threads = new List<DailyActivities.Thread>(),
                activities = new List<DailyActivities.Activity>(),
                webs = new List<DailyActivities.Web>(),
                lists = new List<DailyActivities.ItemList>(),
                users = new List<DailyActivities.User>()
            };

            var daysProcessed = new List<string>();
            var threadsProcessed = new List<Guid>();
            var websProcessed = new List<Guid>();
            var listsProcessed = new List<Guid>();
            var usersProcessed = new List<int>();

            OrderedParallelQuery<DataRow> activityThreads =
                activityRows.AsParallel().OrderByDescending(r => r["ThreadLastActivityOn"]);

            foreach (DataRow t in activityThreads)
            {
                var threadId = (Guid) t["ThreadId"];

                if (threadsProcessed.Contains(threadId)) continue;

                var webId = (Guid) t["WebId"];
                object listId = t["ListId"];
                var userId = (int) t["UserId"];
                var webUrl = (string) t["WebUrl"];
                object dateTime = t["ActivityDate"];
                var activityDay = (((DateTime) dateTime).Date).ToString("s");

                DailyActivities.Thread thread = BuildThread(threadId, activityDay, webId, listId, t);

                OrderedParallelQuery<DataRow> threadActivities = activityRows.AsParallel()
                    .OrderByDescending(a => a["ActivityDate"]);

                foreach (DailyActivities.Activity activity in threadActivities
                    .Select(a => BuildActivity(a, threadId, dateTime, userId))
                    .Where(activity => activity != null))
                {
                    dailyActivities.activities.Add(activity);

                    thread.activities.Add(activity.id);

                    BuildDay(daysProcessed, activityDay, threadId, dailyActivities);

                    BuildWeb(websProcessed, webId, webUrl, threadId, dailyActivities, t);

                    BuildList(listId, listsProcessed, threadId, dailyActivities, t);

                    BuildUser(usersProcessed, userId, thread, dailyActivities, t);
                }

                dailyActivities.threads.Add(thread);
                threadsProcessed.Add(threadId);
            }

            return dailyActivities;
        }

        // Private Methods (11) 

        private static DailyActivities.Activity BuildActivity(DataRow a, Guid threadId, object dateTime, int userId)
        {
            if ((Guid) a["ThreadId"] == threadId)
            {
                return new DailyActivities.Activity
                {
                    id = (Guid) a["ActivityId"],
                    key = a["ActivityKey"] as string,
                    metaData = a["ActivityData"] as string,
                    kind = ((ActivityKind) a["ActivityKind"]).ToString().ToUpper(),
                    isMassOperation = (bool) a["IsMassOperation"],
                    time = ((DateTime) dateTime).ToString("s"),
                    user = userId,
                    thread = threadId
                };
            }

            return null;
        }

        private static void BuildDay(List<string> daysProcessed, string activityDay, Guid threadId,
            DailyActivities dailyActivities)
        {
            if (!daysProcessed.Contains(activityDay))
            {
                var day = new DailyActivities.Day
                {
                    id = activityDay,
                    threads = new List<Guid> {threadId}
                };

                dailyActivities.days.Add(day);
                daysProcessed.Add(activityDay);
            }
            else
            {
                foreach (DailyActivities.Day day in dailyActivities.days
                    .Where(day => day.id.Equals(activityDay))
                    .Where(day => !day.threads.Contains(threadId)))
                {
                    day.threads.Add(threadId);
                    break;
                }
            }
        }

        private void BuildList(object listId, List<Guid> listsProcessed, Guid threadId,
            DailyActivities dailyActivities, DataRow r)
        {
            if (listId == null || listId == DBNull.Value) return;

            var lId = (Guid) listId;

            if (!listsProcessed.Contains(lId))
            {
                var icon = r["ListIcon"];
                if (icon == null || icon == DBNull.Value) icon = null;

                var list = new DailyActivities.ItemList
                {
                    id = lId,
                    name = GetListName(r["ListName"] as string, (Guid) r["WebId"], lId),
                    url = GetListUrl((Guid) r["WebId"], lId),
                    icon = icon as string,
                    threads = new List<Guid> {threadId}
                };

                dailyActivities.lists.Add(list);
                listsProcessed.Add(lId);
            }
            else
            {
                foreach (DailyActivities.ItemList list in dailyActivities.lists.Where(list => list.id == lId))
                {
                    list.threads.Add(threadId);
                    break;
                }
            }
        }

        private static DailyActivities.Thread BuildThread(Guid threadId, string activityDay, Guid webId, object listId,
            DataRow r)
        {
            var thread = new DailyActivities.Thread
            {
                id = threadId,
                title = r["ThreadTitle"] as string,
                url = r["ThreadUrl"] as string,
                kind = ((ObjectKind) r["ThreadKind"]).ToString().ToUpper(),
                lastActivityOn = ((DateTime) r["ThreadLastActivityOn"]).ToString("s"),
                day = activityDay,
                web = webId,
                list = listId as Guid?,
                itemId = r["ItemId"] as int?,
                activities = new List<Guid>()
            };

            return thread;
        }

        private static void BuildUser(List<int> usersProcessed, int userId, DailyActivities.Thread thread,
            DailyActivities dailyActivities, DataRow r)
        {
            if (!usersProcessed.Contains(userId))
            {
                var avatar = r["UserPicture"] as string;

                if (!string.IsNullOrEmpty(avatar))
                {
                    try
                    {
                        avatar = (avatar.Split(',')[1]).Trim();
                    }
                    catch { }
                }

                var user = new DailyActivities.User
                {
                    id = userId,
                    name = (string) r["UserDisplayName"],
                    account = (string) r["UserAccount"],
                    avatar = avatar,
                    activities = new List<Guid>()
                };

                foreach (Guid id in thread.activities)
                {
                    user.activities.Add(id);
                }

                dailyActivities.users.Add(user);
                usersProcessed.Add(userId);
            }
            else
            {
                foreach (DailyActivities.User user in dailyActivities.users.Where(user => user.id == userId))
                {
                    foreach (Guid id in thread.activities)
                    {
                        user.activities.Add(id);
                    }

                    break;
                }
            }
        }

        private static void BuildWeb(List<Guid> websProcessed, Guid webId, string webUrl, Guid threadId,
            DailyActivities dailyActivities, DataRow r)
        {
            if (!websProcessed.Contains(webId))
            {
                var web = new DailyActivities.Web
                {
                    id = webId,
                    title = (string) r["WebTitle"],
                    url = webUrl,
                    threads = new List<Guid> {threadId}
                };

                dailyActivities.webs.Add(web);
                websProcessed.Add(webId);
            }
            else
            {
                foreach (DailyActivities.Web web in dailyActivities.webs.Where(web => web.id == webId))
                {
                    web.threads.Add(threadId);
                    break;
                }
            }
        }

        private static void GetActivities(List<DataRow> activityRows, SPWeb spWeb, DateTime minDate, DateTime maxDate,
            int page, int limit)
        {
            while (activityRows.Count <= limit)
            {
                DataTable dataTable = SocialEngineProxy.GetActivities(spWeb, minDate, maxDate, page++, limit);
                if (dataTable.Rows.Count == 0) break;

                EnumerableRowCollection<DataRow> rows = dataTable.AsEnumerable();

                Parallel.ForEach(rows, r =>
                {
                    if (activityRows.Count >= limit) return;

                    if (!(bool) r["IsMassOperation"])
                    {
                        activityRows.Add(r);
                    }
                    else
                    {
                        if (rows.AsParallel().Any(
                            x => !((bool) x["IsMassOperation"]) &&
                                 (int) x["ActivityKind"] != (int) ActivityKind.BulkOperation))
                        {
                            activityRows.Add(r);
                        }
                    }
                });
            }
        }

        private static Dictionary<Guid, Tuple<string, string>> GetListDict()
        {
            var dict =
                (Dictionary<Guid, Tuple<string, string>>)
                    CacheStore.Current.Get("SS_Lists", new CacheStoreCategory().SocialStream,
                        () => new Dictionary<Guid, Tuple<string, string>>(), true).Value;
            return dict;
        }

        private string GetListName(string listName, Guid webId, Guid listId)
        {
            if (!string.IsNullOrEmpty(listName)) return listName;

            Dictionary<Guid, Tuple<string, string>> dict = GetListDict();

            if (dict.ContainsKey(listId))
            {
                return dict[listId].Item1;
            }

            SPList list = SetListDict(webId, listId, dict);

            return list == null ? null : list.Title;
        }

        private string GetListUrl(Guid webId, Guid listId)
        {
            Dictionary<Guid, Tuple<string, string>> dict = GetListDict();

            if (dict.ContainsKey(listId))
            {
                return dict[listId].Item2;
            }

            SPList list = SetListDict(webId, listId, dict);

            return list == null ? null : list.DefaultDisplayFormUrl;
        }

        private static SPList SetListDict(Guid webId, Guid listId, Dictionary<Guid, Tuple<string, string>> dict)
        {
            SPList list = null;

            try
            {
                using (var spSite = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                    {
                        SPList spList = spWeb.Lists.GetList(listId, false);
                        dict.Add(listId, new Tuple<string, string>(spList.Title, spList.DefaultDisplayFormUrl));

                        CacheStore.Current.Set("SS_List", dict, new CacheStoreCategory().SocialStream, true);

                        list = spList;
                    }
                }
            }
            catch { }

            return list;
        }

        #endregion Methods 
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading.Tasks;
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
        #region Methods (9) 

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

            var dailyActivities = new DailyActivities();

            if (!activityRows.Any()) return dailyActivities;

            var daysProcessed = new List<string>();
            var threadsProcessed = new List<Guid>();
            var websProcessed = new List<Guid>();
            var listsProcessed = new List<Guid>();
            var usersProcessed = new List<int>();

            List<DataRow> activityThreads =
                activityRows.AsParallel().OrderByDescending(r => r["ThreadLastActivityOn"]).ToList();

            foreach (DataRow t in activityThreads)
            {
                var threadId = (Guid) t["ThreadId"];

                if (threadsProcessed.Contains(threadId)) continue;

                var webId = (Guid) t["WebId"];
                object listId = t["ListId"];
                var userId = (int) t["UserId"];
                var webUrl = (string) t["WebUrl"];
                object dateTime = t["ActivityDate"];
                string activityDay = (((DateTime) dateTime).Date).ToString("s");

                DailyActivities.Thread thread = BuildThread(threadId, activityDay, webId, listId, t);

                List<DataRow> threadActivities = activityRows.AsParallel()
                    .Where(a => (Guid) a["ThreadId"] == threadId)
                    .OrderBy(a => a["ActivityDate"]).ToList();

                foreach (DataRow a in threadActivities)
                {
                    object time = a["ActivityDate"];

                    string day = (((DateTime) time).Date).ToString("s");
                    if (!thread.days.Contains(day)) thread.days.Add(day);

                    DailyActivities.Activity activity = BuildActivity(a, threadId, time, userId);
                    if (activity == null) continue;

                    dailyActivities.activities.Add(activity);

                    thread.activities.Add(activity.id);

                    DataRow th = t;

                    var tasks = new[]
                    {
                        Task.Factory.StartNew(() => BuildDay(daysProcessed, day, threadId, dailyActivities)),
                        Task.Factory.StartNew(() => BuildWeb(websProcessed, webId, webUrl, threadId, dailyActivities, th)),
                        Task.Factory.StartNew(() => BuildList(listId, listsProcessed, threadId, dailyActivities, th)),
                        Task.Factory.StartNew(() => BuildUser(usersProcessed, userId, thread, dailyActivities, th))
                    };

                    Task.WaitAll(tasks);
                }

                dailyActivities.threads.Add(thread);
                threadsProcessed.Add(threadId);
            }

            List<KeyValuePair<DateTime, List<DailyActivities.ActivityThread>>> dict =
                BuildActivityThreads(dailyActivities).ToList();
            IEnumerable<DailyActivities.ActivityThread> atList = dict.SelectMany(at => at.Value);

            foreach (DailyActivities.ActivityThread activityThread in atList)
            {
                dailyActivities.activityThreads.Add(activityThread);
            }

            return dailyActivities;
        }

        // Private Methods (8) 

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

        private static OrderedParallelQuery<KeyValuePair<DateTime, List<DailyActivities.ActivityThread>>>
            BuildActivityThreads(DailyActivities dailyActivities)
        {
            var dictionary = new Dictionary<DateTime, List<DailyActivities.ActivityThread>>();
            var locker = new object();

            Parallel.ForEach(dailyActivities.days, day =>
            {
                DateTime date = DateTime.Parse(day.id).Date;

                foreach (Guid threadId in day.threads)
                {
                    var activityThread = new DailyActivities.ActivityThread
                    {
                        id = (threadId.ToString() + day.id).Md5(),
                        day = day.id,
                        thread = threadId,
                        todaysActivities = new List<Guid>(),
                        previousActivities = new List<Guid>(),
                        newerActivities = new List<Guid>()
                    };

                    foreach (DailyActivities.Activity activity in dailyActivities.activities)
                    {
                        if (activity.thread != threadId) continue;

                        DateTime activityTime = DateTime.Parse(activity.time).Date;

                        if (activityTime == date)
                        {
                            activityThread.todaysActivities.Add(activity.id);
                        }
                        else if (activityTime < date)
                        {
                            activityThread.previousActivities.Add(activity.id);
                        }
                        else
                        {
                            activityThread.newerActivities.Add(activity.id);
                        }
                    }

                    lock (locker)
                    {
                        if (!dictionary.ContainsKey(date))
                        {
                            dictionary.Add(date, new List<DailyActivities.ActivityThread> {activityThread});
                        }
                        else
                        {
                            dictionary[date].Add(activityThread);
                        }

                        day.activityThreads.Add(activityThread.id);

                        Guid id = threadId;

                        List<DailyActivities.Thread> threads =
                            dailyActivities.threads.Where(thread => thread.id == id).ToList();

                        foreach (DailyActivities.Thread thread in threads)
                        {
                            thread.activityThreads.Add(activityThread.id);
                        }
                    }
                }
            });

            return dictionary.AsParallel().OrderByDescending(at => at.Key);
        }

        private static void BuildDay(List<string> daysProcessed, string activityDay, Guid threadId,
            DailyActivities dailyActivities)
        {
            if (!daysProcessed.Contains(activityDay))
            {
                var day = new DailyActivities.Day
                {
                    id = activityDay,
                    threads = new List<Guid> {threadId},
                    activityThreads = new List<string>()
                };

                dailyActivities.days.Add(day);
                daysProcessed.Add(activityDay);
            }
            else
            {
                List<DailyActivities.Day> days = dailyActivities.days
                    .Where(day => day.id.Equals(activityDay))
                    .Where(day => !day.threads.Contains(threadId)).ToList();

                foreach (DailyActivities.Day day in days)
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
                object icon = r["ListIcon"];
                if (icon == null || icon == DBNull.Value) icon = null;

                var listUrl =
                    string.Format("{0}/_layouts/15/epmlive/redirectionproxy.aspx?action=gotolist&webid={1}&listid={2}",
                        r["WebUrl"], r["WebId"], lId);

                var list = new DailyActivities.ItemList
                {
                    id = lId,
                    name = r["ListName"] as string,
                    url = listUrl,
                    icon = icon as string,
                    threads = new List<Guid> {threadId}
                };

                dailyActivities.lists.Add(list);
                listsProcessed.Add(lId);
            }
            else
            {
                List<DailyActivities.ItemList> itemLists = dailyActivities.lists.Where(list => list.id == lId).ToList();
                foreach (DailyActivities.ItemList list in itemLists)
                {
                    if (!list.threads.Contains(threadId)) list.threads.Add(threadId);
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
                days = new List<string> {activityDay},
                web = webId,
                list = listId as Guid?,
                itemId = r["ItemId"] as int?,
                isMassOperation = (bool) r["IsMassOperation"],
                activities = new List<Guid>(),
                activityThreads = new List<string>()
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
                    DailyActivities.User usr = user;
                    List<Guid> users = thread.activities.Where(id => !usr.activities.Contains(id)).ToList();
                    foreach (Guid id in users)
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
                List<DailyActivities.Web> webs = dailyActivities.webs.Where(web => web.id == webId).ToList();
                foreach (DailyActivities.Web web in webs)
                {
                    if (!web.threads.Contains(threadId)) web.threads.Add(threadId);
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
                        if (rows.AsParallel()
                            .Count(x => !((bool) x["IsMassOperation"]) && x["ThreadId"] == r["ThreadId"] &&
                                        (int) x["ActivityKind"] != (int) ActivityKind.BulkOperation) > 1)
                        {
                            activityRows.Add(r);
                        }
                    }
                });
            }
        }

        #endregion Methods 
    }
}
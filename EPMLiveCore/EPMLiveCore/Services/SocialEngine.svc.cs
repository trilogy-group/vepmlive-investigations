using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using System.Web;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure.Navigation;
using EPMLiveCore.Services.DataContracts.SocialEngine;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveCore.Services
{
    [ServiceContract(Namespace = "http://api.epmlive.com/SocialEngine", Name = "SocialEngine")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SocialEngine
    {
        #region Fields (7) 

        private const string DATE_FORMAT = "s";
        private const string PROXY_URL = "_layouts/15/epmlive/redirectionproxy.aspx";
        private readonly string[] _activityDateTimeColumns = {"ActivityDate"};
        private readonly object _locker = new object();
        private readonly string[] _threadDateTimeColumns = {"ThreadLastActivityOn", "ThreadFirstActivityOn"};
        private readonly Dictionary<DateTime, DateTime> _utcTimeDict = new Dictionary<DateTime, DateTime>();
        private SPRegionalSettings _regionalSettings;

        #endregion Fields 

        #region Methods (19) 

        // Public Methods (3) 

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/activities")]
        [OperationContract]
        public SEActivities GetActivities()
        {
            var activities = new SEActivities();

            try
            {
                int limit;
                int page;
                int activityLimit;
                int commentLimit;
                DateTime offset;

                ParseMetaData(out page, out limit, out activityLimit, out commentLimit, out offset);

                GetData(page, limit, activityLimit, commentLimit, activities);

                return activities;
            }
            catch (Exception exception)
            {
                if (exception is AggregateException)
                {
                    exception = ((AggregateException) exception).Flatten();
                }

                activities.error = new Error
                {
                    message = exception.Message,
                    stackTrace = exception.StackTrace,
                    kind = typeof (Exception).ToString()
                };
            }

            return activities;
        }

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/creatables")]
        public Creatables GetCreatables()
        {
            var creatables = new Creatables();

            try
            {
                SPWeb contextWeb = SPContext.Current.Web;

                var applicationsLinkProvider = new ApplicationsLinkProvider(SPContext.Current.Site.ID,
                    contextWeb.ID,
                    contextWeb.CurrentUser.LoginName);

                var reportingLists = new DataTable();

                var tasks = new[]
                {
                    Task.Factory.StartNew(() => BuildCreatables(applicationsLinkProvider, creatables)),
                    Task.Factory.StartNew(() => GetReportingListLibs(reportingLists, contextWeb))
                };

                Task.WaitAll(tasks);

                var toRemove = new List<Creatables.Creatable>();
                EnumerableRowCollection<DataRow> listLibs = reportingLists.AsEnumerable();

                Parallel.ForEach(creatables.collection, c =>
                {
                    bool found = false;

                    foreach (DataRow row in Enumerable.Where(listLibs, r => r["Id"].ToString().ToLower()
                        .Equals(c.id.ToLower())))
                    {
                        found = true;

                        object icon = row["icon"];
                        if (icon != DBNull.Value && icon != null) c.icon = icon as string;

                        break;
                    }

                    if (!found) toRemove.Add(c);
                });

                foreach (Creatables.Creatable creatable in toRemove.Distinct())
                {
                    creatables.collection.Remove(creatable);
                }
            }
            catch (Exception exception)
            {
                if (exception is AggregateException)
                {
                    exception = ((AggregateException) exception).Flatten();
                }

                creatables.error = new Error
                {
                    message = exception.Message,
                    stackTrace = exception.StackTrace,
                    kind = typeof (Exception).ToString()
                };
            }

            return creatables;
        }

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/thread/{threadId}/{kind}")]
        [OperationContract]
        public SEActivities GetItemsForThread(string threadId, string kind)
        {
            var activities = new SEActivities();

            try
            {
                int limit;
                int page;
                int activityLimit;
                int commentLimit;
                DateTime offset;

                ParseMetaData(out page, out limit, out activityLimit, out commentLimit, out offset);

                GetData(activities, new Guid(threadId), kind, offset);
            }
            catch (Exception exception)
            {
                if (exception is AggregateException)
                {
                    exception = ((AggregateException) exception).Flatten();
                }

                activities.error = new Error
                {
                    message = exception.Message,
                    stackTrace = exception.StackTrace,
                    kind = typeof (Exception).ToString()
                };
            }

            return activities;
        }

        // Private Methods (16) 

        private void AddList(SEActivities.Thread thread, SEActivities activities, DataRow tr)
        {
            if (!thread.listId.HasValue) return;

            bool found = activities.lists.Any(list => list.id == thread.listId.Value);
            if (found) return;

            lock (_locker)
            {
                found = activities.lists.Any(list => list.id == thread.listId.Value);
                if (found) return;

                string url = string.Format("{0}/{1}?action=gotolist&webid={2}&listid={3}",
                    tr["WebUrl"], PROXY_URL, thread.webId, thread.listId);

                if (((ObjectKind) tr["ThreadKind"]) == ObjectKind.List)
                {
                    tr["ListName"] = tr["ThreadTitle"];
                }

                activities.lists.Add(new SEActivities.ItemList
                {
                    id = thread.listId.Value,
                    name = tr["ListName"] as string,
                    icon = tr["ListIcon"] as string,
                    url = url
                });
            }
        }

        private void AddUser(SEActivities activities, SEActivities.Thread.Activity activity, DataRow ar)
        {
            bool found = activities.users.Any(u => u.id == activity.userId);
            if (found) return;

            lock (_locker)
            {
                found = activities.users.Any(u => u.id == activity.userId);
                if (found) return;

                activities.users.Add(new SEActivities.User
                {
                    id = activity.userId,
                    name = (string) ar["UserName"],
                    displayName = (string) ar["UserDisplayName"],
                    picture = ((ar["UserPicture"] as string) ?? string.Empty).Split(',')[0]
                });
            }
        }

        private void AddWeb(SEActivities activities, SEActivities.Thread thread, DataRow tr)
        {
            bool found = activities.webs.Any(w => w.id == thread.webId);
            if (found) return;

            lock (_locker)
            {
                found = activities.webs.Any(w => w.id == thread.webId);
                if (found) return;

                activities.webs.Add(new SEActivities.Web
                {
                    id = thread.webId,
                    title = (string) tr["WebTitle"],
                    url = (string) tr["WebUrl"]
                });
            }
        }

        private void BuildActivities(IEnumerable<DataRow> activityRows, SEActivities activities,
            SEActivities.Thread thread)
        {
            Parallel.ForEach(activityRows, r =>
            {
                foreach (string column in _activityDateTimeColumns)
                {
                    SetLocalDateTime(r, column, _utcTimeDict, _regionalSettings);
                }

                SEActivities.Thread.Activity activity = BuildActivity(r, activities);
                thread.activities.Add(activity);
            });
        }

        private SEActivities.Thread.Activity BuildActivity(DataRow ar, SEActivities activities)
        {
            var activity = new SEActivities.Thread.Activity
            {
                id = (Guid) ar["ActivityId"],
                key = ar["ActivityKey"] as string,
                data = ar["ActivityData"] as string,
                kind = ((ActivityKind) ar["ActivityKind"]).ToString(),
                time = ((DateTime) ar["ActivityDate"]).ToString(DATE_FORMAT),
                isBulkOperation = (bool) ar["ActivityIsMassOperation"],
                userId = (int) ar["UserId"]
            };

            AddUser(activities, activity, ar);
            return activity;
        }

        private void BuildComments(IEnumerable<DataRow> commentRows, SEActivities activities, SEActivities.Thread thread)
        {
            Parallel.ForEach(commentRows, r =>
            {
                foreach (string column in _activityDateTimeColumns)
                {
                    SetLocalDateTime(r, column, _utcTimeDict, _regionalSettings);
                }

                SEActivities.Thread.Activity activity = BuildActivity(r, activities);
                thread.comments.Add(activity);
            });
        }

        private static void BuildCreatables(ApplicationsLinkProvider applicationsLinkProvider, Creatables creatables)
        {
            foreach (NavLink navLink in applicationsLinkProvider.GetLinks().Cast<NavLink>()
                .Where(navLink => !string.IsNullOrEmpty(navLink.ObjectId)))
            {
                creatables.collection.Add(new Creatables.Creatable
                {
                    id = navLink.ObjectId,
                    title = navLink.Title
                });
            }
        }

        private SEActivities.Thread BuildThread(DataRow tr, DBConnectionManager manager, int userId, int activityLimit,
            int commentLimit, SEActivities activities, DateTime? offset, string kind = null)
        {
            foreach (string column in _threadDateTimeColumns)
            {
                SetLocalDateTime(tr, column, _utcTimeDict, _regionalSettings);
            }

            var activityRows = new List<DataRow>();
            var commentRows = new List<DataRow>();

            var totalActivities = (int) tr["TotalActivities"];
            var totalComments = (int) tr["TotalComments"];

            var threadKind = (ObjectKind) tr["ThreadKind"];
            bool ignoreAccess = threadKind == ObjectKind.StatusUpdate;

            if (!string.IsNullOrEmpty(kind))
            {
                kind = kind.ToLower();

                if (kind.Equals("activities"))
                {
                    activityRows =
                        GetThreadActivities(manager, userId, 0, 3, activityLimit, tr, offset, ignoreAccess)
                            .AsEnumerable()
                            .ToList();
                }
                else if (kind.Equals("comments"))
                {
                    commentRows =
                        GetThreadActivities(manager, userId, 4, 4, commentLimit, tr, offset, ignoreAccess)
                            .AsEnumerable()
                            .ToList();
                }
            }
            else
            {
                if (totalActivities > 0)
                {
                    activityRows =
                        GetThreadActivities(manager, userId, 0, 3, activityLimit, tr, null, ignoreAccess)
                            .AsEnumerable()
                            .ToList();
                }

                if (totalComments > 0)
                {
                    commentRows =
                        GetThreadActivities(manager, userId, 4, 4, commentLimit, tr, null, ignoreAccess)
                            .AsEnumerable()
                            .ToList();
                }
            }

            var webId = (Guid) tr["WebId"];
            var listId = tr["ListId"] as Guid?;
            var itemId = tr["ItemId"] as int?;

            var url = tr["ThreadUrl"] as string;

            if (listId.HasValue && itemId.HasValue)
            {
                url = string.Format("{0}/{1}?action=view&webid={2}&listid={3}&id={4}",
                    tr["WebUrl"], PROXY_URL, webId, listId.Value, itemId.Value);
            }

            var thread = new SEActivities.Thread
            {
                id = (Guid) tr["ThreadId"],
                title = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode((string) tr["ThreadTitle"])),
                url = url,
                kind = ((ObjectKind) tr["ThreadKind"]).ToString(),
                lastActivityOn = ((DateTime) tr["ThreadLastActivityOn"]).ToString(DATE_FORMAT),
                firstActivityOn = ((DateTime) tr["ThreadFirstActivityOn"]).ToString(DATE_FORMAT),
                webId = webId,
                listId = listId,
                itemId = itemId,
                totalActivities = totalActivities,
                totalComments = totalComments
            };

            var threadTasks = new[]
            {
                Task.Factory.StartNew(() => BuildActivities(activityRows, activities, thread)),
                Task.Factory.StartNew(() => BuildComments(commentRows, activities, thread)),
                Task.Factory.StartNew(() => AddWeb(activities, thread, tr)),
                Task.Factory.StartNew(() => AddList(thread, activities, tr))
            };

            Task.WaitAll(threadTasks);

            thread.activities = thread.activities.Distinct().ToList();
            thread.comments = thread.comments.Distinct().ToList();

            return thread;
        }

        private void GetData(SEActivities activities, Guid threadId, string kind, DateTime offset)
        {
            SPWeb web = SPContext.Current.Web;
            int userId = web.CurrentUser.ID;

            _regionalSettings = SPContext.Current.RegionalSettings;

            using (var connectionManager = new DBConnectionManager(web))
            {
                DBConnectionManager manager = connectionManager;

                List<DataRow> threadRows = GetThreads(manager, userId, web, 0, 0, threadId).AsEnumerable().ToList();

                List<SEActivities.Thread> threads =
                    threadRows.Select(tr => BuildThread(tr, manager, userId, 0, 0, activities, offset, kind))
                        .ToList();

                foreach (SEActivities.Thread thread in threads)
                {
                    activities.threads.Add(thread);
                }
            }

            SortThreadActivities(activities);
        }

        private void GetData(int page, int limit, int activityLimit, int commentLimit, SEActivities activities)
        {
            SPWeb web = SPContext.Current.Web;
            int userId = web.CurrentUser.ID;

            _regionalSettings = SPContext.Current.RegionalSettings;

            using (var connectionManager = new DBConnectionManager(web))
            {
                DBConnectionManager manager = connectionManager;

                List<DataRow> threadRows = GetThreads(manager, userId, web, page, limit, null).AsEnumerable().ToList();

                List<SEActivities.Thread> threads =
                    threadRows.Select(
                        tr => BuildThread(tr, manager, userId, activityLimit, commentLimit, activities, null))
                        .ToList();

                foreach (SEActivities.Thread thread in threads)
                {
                    activities.threads.Add(thread);
                }
            }

            activities.threads = activities.threads.Distinct().ToList();
            activities.webs = activities.webs.Distinct().ToList();
            activities.lists = activities.lists.Distinct().ToList();
            activities.users = activities.users.Distinct().ToList();

            SortThreadActivities(activities);
        }

        private static void GetReportingListLibs(DataTable reportingLists, SPWeb contextWeb)
        {
            using (var manager = new DBConnectionManager(contextWeb))
            {
                const string SQL = @"
                        SELECT  dbo.RPTList.RPTListId AS Id, dbo.RPTList.ListName AS Name, dbo.ReportListIds.ListIcon AS Icon
                        FROM    dbo.RPTList LEFT OUTER JOIN dbo.ReportListIds ON dbo.RPTList.RPTListId = dbo.ReportListIds.Id";

                var sqlCommand = new SqlCommand(SQL, manager.SqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reportingLists.Load(reader);
            }
        }

        private DataTable GetThreadActivities(DBConnectionManager manager, int userId, int kindMin, int kindMax,
            int activityLimit, DataRow tr, DateTime? offset, bool ignoreAccess)
        {
            var dataTable = new DataTable();

            try
            {
                using (var sqlCommand = new SqlCommand("SS_GetLatestActivities", manager.SqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    sqlCommand.Parameters.AddWithValue("@ThreadId", tr["ThreadId"]);
                    sqlCommand.Parameters.AddWithValue("@WebId", tr["WebId"]);
                    sqlCommand.Parameters.AddWithValue("@ListId", tr["ListId"]);
                    sqlCommand.Parameters.AddWithValue("@ItemId", tr["ItemId"]);
                    sqlCommand.Parameters.AddWithValue("@KindMin", kindMin);
                    sqlCommand.Parameters.AddWithValue("@KindMax", kindMax);
                    sqlCommand.Parameters.AddWithValue("@IgnoreAccess", ignoreAccess);
                    if (activityLimit > 0) sqlCommand.Parameters.AddWithValue("@Limit", activityLimit);
                    if (offset.HasValue) sqlCommand.Parameters.AddWithValue("@Offset", offset.Value);

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    dataTable.Load(reader);
                }
            }
            catch { }

            return dataTable;
        }

        private DataTable GetThreads(DBConnectionManager connectionManager, int userId, SPWeb web, int page, int limit,
            Guid? threadId)
        {
            var dataTable = new DataTable();

            using (var sqlCommand = new SqlCommand("SS_GetLatestThreads", connectionManager.SqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@WebUrl", web.ServerRelativeUrl);

                if (page > 0) sqlCommand.Parameters.AddWithValue("@Page", page);
                if (limit > 0) sqlCommand.Parameters.AddWithValue("@Limit", limit);
                if (threadId.HasValue) sqlCommand.Parameters.AddWithValue("@ThreadId", threadId.Value);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                dataTable.Load(reader);
            }

            return dataTable;
        }

        private void ParseMetaData(out int page, out int limit, out int activityLimit, out int commentLimit,
            out DateTime offset)
        {
            page = 1;
            limit = 10;
            activityLimit = 1;
            commentLimit = 2;
            offset = DateTime.UtcNow;

            OperationContext context = OperationContext.Current;
            MessageProperties properties = context.IncomingMessageProperties;
            var request = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;

            if (request == null) return;

            string queryString = request.QueryString;
            if (string.IsNullOrEmpty(queryString)) return;

            NameValueCollection parameters = HttpUtility.ParseQueryString(queryString);

            if (parameters.AllKeys.Contains("page"))
            {
                int.TryParse(parameters["page"], out page);
            }

            if (parameters.AllKeys.Contains("limit"))
            {
                int.TryParse(parameters["limit"], out limit);
            }

            if (parameters.AllKeys.Contains("activityLimit"))
            {
                int.TryParse(parameters["activityLimit"], out activityLimit);
            }

            if (parameters.AllKeys.Contains("commentLimit"))
            {
                int.TryParse(parameters["commentLimit"], out activityLimit);
            }

            if (parameters.AllKeys.Contains("offset"))
            {
                SPRegionalSettings regionalSettings = SPContext.Current.RegionalSettings;
                offset = regionalSettings.TimeZone.LocalTimeToUTC(DateTime.Parse(parameters["offset"]));
            }
        }

        private void SetLocalDateTime(DataRow tr, string column, Dictionary<DateTime, DateTime> utcTimeDict,
            SPRegionalSettings regionalSettings)
        {
            try
            {
                var value = (DateTime) tr[column];

                if (utcTimeDict.ContainsKey(value))
                {
                    tr[column] = utcTimeDict[value];
                }
                else
                {
                    DateTime result = regionalSettings.TimeZone.UTCToLocalTime(value);
                    tr[column] = result;

                    lock (_locker)
                    {
                        try
                        {
                            utcTimeDict.Add(value, result);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }

        private static void SortThreadActivities(SEActivities activities)
        {
            Parallel.ForEach(activities.threads,
                thread => { thread.activities = thread.activities.OrderByDescending(a => a.time).ToList(); });

            activities.threads = activities.threads.OrderByDescending(t => t.lastActivityOn).ToList();
        }

        #endregion Methods 
    }
}
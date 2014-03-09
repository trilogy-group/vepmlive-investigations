using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.SocialEngine.Contracts;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Entities;
using EPMLiveCore.SocialEngine.Events;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Modules
{
    internal class ListItem : ISocialEngineModule
    {
        #region Fields (1) 

        private const string ALREADY_CREATED_EXCEPTION_MESSAGE =
            "Cannot register more than one List Item Created activity on the same list item.";

        #endregion Fields 

        #region Methods (11) 

        // Private Methods (11) 

        private static void AddThreadUsers(Dictionary<string, object> data, ThreadManager threadManager, Thread thread)
        {
            var users=new List<User> {new User {Id = (int) data["UserId"], Role = UserRole.Creator}};

            if (data.ContainsKey("AssignedTo"))
            {
                var assignedToUsers = data["AssignedTo"] as string;
                if (!string.IsNullOrEmpty(assignedToUsers))
                {
                    string[] asu = assignedToUsers.Split(',');

                    foreach (string user in asu)
                    {
                        int userId;
                        if (!int.TryParse(user.Trim(), out userId)) continue;

                        User tu = (from u in users where u.Id == userId select u).FirstOrDefault();

                        if (tu == null)
                        {
                            users.Add(new User {Id = userId, Role = UserRole.Assignee});
                        }
                        else
                        {
                            tu.Role |= UserRole.Assignee;
                        }
                    }
                }
            }

            thread.Users = users.AsParallel().Distinct().ToArray();
            threadManager.AddUsers(thread);
        }

        private TimeSpan GetRelatedActivityInterval(SPWeb contextWeb)
        {
            const string SETTING_KEY = "EPM_SS_RelatedActivityInterval";

            return (TimeSpan) CacheStore.Current.Get(SETTING_KEY, "SocialStream", () =>
            {
                SPWeb rootWeb = contextWeb.Site.RootWeb;

                string setting = CoreFunctions.getConfigSetting(rootWeb, SETTING_KEY);

                if (!string.IsNullOrEmpty(setting))
                {
                    int ai;
                    if (int.TryParse(setting, out ai))
                    {
                        return ai.Seconds();
                    }
                }

                CoreFunctions.setConfigSetting(rootWeb, SETTING_KEY, "10");

                return 10.Seconds();
            }, true).Value;
        }

        private static bool EnsureNotIgnoredList(ProcessActivityEventArgs args, Dictionary<string, object> data)
        {
            var listTitle = (string) data["ListTitle"];

            if (!Core.Utilities.IsIgnoredList(listTitle, args.ContextWeb)) return false;

            args.Cancel = true;
            args.CancellationMessage = listTitle + " is part of ignored Social Stream lists.";

            return true;
        }

        private void OnActivityRegistration(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.ListItem) return;

            if (args.ActivityKind == ActivityKind.Created) RegisterCreationActivity(args);
        }

        private void OnPreActivityRegistration(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.ListItem) return;

            PerformPreRegistrationSteps(args);
        }

        private void OnValidateActivity(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.ListItem) return;

            if (args.ActivityKind == ActivityKind.Created) ValidateCreationActivity(args);
            else if (args.ActivityKind == ActivityKind.Updated) ValidateUpdationActivity(args);
            else if (args.ActivityKind == ActivityKind.Deleted) ValidateDeletionActivity(args);
        }

        private void PerformPreRegistrationSteps(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;
            ActivityManager activityManager = args.ActivityManager;

            TimeSpan interval = GetRelatedActivityInterval(args.ContextWeb);
            var activityTime = (DateTime) data["ActivityTime"];

            var listId = (Guid) data["ListId"];
            var userId = (int) data["UserId"];

            Activity relatedActivity = activityManager.FindRelatedActivity(listId, userId, activityTime, interval);

            if (relatedActivity == null) return;

            if (!relatedActivity.IsMassOperation) activityManager.FlagMassOperation(relatedActivity.Id);

            if (!args.Data.ContainsKey("IsMassOperation")) args.Data.Add("IsMassOperation", true);
            else args.Data["IsMassOperation"] = true;

            activityManager.EnqueueActivity((Guid) data["SiteId"], (Guid) data["WebId"], listId,
                userId, activityTime, activityTime - interval);
        }

        private void RegisterCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;
            ThreadManager threadManager = args.ThreadManager;
            ActivityManager activityManager = args.ActivityManager;
            StreamManager streamManager = args.StreamManager;

            var webId = (Guid) data["WebId"];

            Thread thread = threadManager.SaveThread(new Thread
            {
                Title = (string) data["Title"],
                Url = (string) data["URL"],
                Kind = ObjectKind.ListItem,
                WebId = webId,
                ListId = (Guid) data["ListId"],
                ItemId = (int) data["Id"]
            });

            Activity activity = activityManager.RegisterActivity(new Activity
            {
                Kind = args.ActivityKind,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = (DateTime) data["ActivityTime"]
            });

            if (data.ContainsKey("IsMassOperation"))
            {
                if ((bool) data["IsMassOperation"])
                {
                    activityManager.FlagMassOperation(activity.Id);
                }
            }

            Guid streamId = streamManager.GetGlobalStreamId(webId);
            threadManager.AssociateStreams(thread, new[] {streamId});

            AddThreadUsers(data, threadManager, thread);
        }

        private void ValidateCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"Id", DataType.Int},
                {"Title", DataType.String},
                {"URL", DataType.String},
                {"ListTitle", DataType.String},
                {"ListId", DataType.Guid},
                {"WebId", DataType.Guid},
                {"SiteId", DataType.Guid},
                {"UserId", DataType.Int},
                {"ActivityTime", DataType.DateTime}
            });

            if (EnsureNotIgnoredList(args, data)) return;

            if (args.ActivityManager.ActivityExists(ObjectKind.ListItem, ActivityKind.Created,
                (Guid) data["WebId"], (Guid) data["ListId"], (int) data["Id"]))
            {
                throw new SocialEngineException(ALREADY_CREATED_EXCEPTION_MESSAGE, LogKind.Info);
            }
        }

        private void ValidateDeletionActivity(ProcessActivityEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void ValidateUpdationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"Id", DataType.Int},
                {"Title", DataType.String},
                {"ListId", DataType.Guid},
                {"WebId", DataType.Guid},
                {"SiteId", DataType.Guid},
                {"UserId", DataType.Int},
                {"ChangedProperties", DataType.String},
                {"ActivityTime", DataType.DateTime}
            });

            EnsureNotIgnoredList(args, data);
        }

        #endregion Methods 

        #region Implementation of ISocialEngineModule

        public void Initialize(SocialEngineEvents events)
        {
            events.OnValidateActivity += OnValidateActivity;
            events.OnPreActivityRegistration += OnPreActivityRegistration;
            events.OnActivityRegistration += OnActivityRegistration;
        }

        #endregion
    }
}
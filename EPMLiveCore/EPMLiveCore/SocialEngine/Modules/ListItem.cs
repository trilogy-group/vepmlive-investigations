using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
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

        #region Methods (16) 

        // Private Methods (16) 

        private static bool EnsureNotIgnoredList(ProcessActivityEventArgs args, Dictionary<string, object> data)
        {
            var listTitle = (string) data["ListTitle"];

            if (!Core.Utilities.IsIgnoredList(listTitle, args.ContextWeb)) return false;

            args.Cancel = true;
            args.CancellationMessage = listTitle + " is part of ignored Social Stream lists.";

            return true;
        }

        private static void EnsureValideData(Dictionary<string, object> data)
        {
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

        private void OnActivityRegistration(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.ListItem) return;

            switch (args.ActivityKind)
            {
                case ActivityKind.Created:
                    RegisterCreationActivity(args);
                    break;
                case ActivityKind.Updated:
                    RegisterUpdationActivity(args);
                    break;
                case ActivityKind.Deleted:
                    RegisterDeletionActivity(args);
                    break;
            }
        }

        private void OnPostActivityRegistration(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.ListItem) return;

            PerformPostRegistrationSteps(args);
        }

        private void OnPreActivityRegistration(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.ListItem) return;

            PerformPreRegistrationSteps(args);
        }

        private void OnValidateActivity(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.ListItem) return;

            switch (args.ActivityKind)
            {
                case ActivityKind.Created:
                    ValidateCreationActivity(args);
                    break;
                case ActivityKind.Updated:
                    ValidateUpdationActivity(args);
                    break;
                case ActivityKind.Deleted:
                    ValidateDeletionActivity(args);
                    break;
                default:
                    throw new SocialEngineException("This activity cannot be performed on a list item.", LogKind.Info);
            }
        }

        private void PerformPostRegistrationSteps(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            ThreadManager threadManager = args.ThreadManager;
            ActivityManager activityManager = args.ActivityManager;
            StreamManager streamManager = args.StreamManager;

            var activity = (Activity) data["#!Activity"];
            var thread = (Thread) data["#!Thread"];

            if (data.ContainsKey("IsMassOperation"))
            {
                if ((bool) data["IsMassOperation"])
                {
                    activityManager.FlagMassOperation(activity.Id);
                }
            }

            Guid streamId = streamManager.GetGlobalStreamId((Guid) data["WebId"]);
            threadManager.AssociateStreams(thread, new[] {streamId});

            UpdateThreadUsers(data, threadManager, thread);
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

            data.Add("#!Thread", thread);
            data.Add("#!Activity", activity);
        }

        private void RegisterDeletionActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;
            ThreadManager threadManager = args.ThreadManager;

            Thread thread = threadManager.GetThread((Guid) data["WebId"], (Guid) data["ListId"], (int) data["Id"]) ??
                            threadManager.SaveThread(new Thread
                            {
                                Title = (string) data["Title"],
                                Url = (string) data["URL"],
                                Kind = args.ObjectKind,
                                WebId = (Guid) data["WebId"],
                                ListId = (Guid) data["ListId"],
                                ItemId = (int) data["Id"]
                            });

            threadManager.DeleteThread(thread);

            Activity activity = args.ActivityManager.RegisterActivity(new Activity
            {
                Kind = ActivityKind.Deleted,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = (DateTime) data["ActivityTime"]
            });

            data.Add("#!Thread", thread);
            data.Add("#!Activity", activity);
        }

        private void RegisterUpdationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;
            ThreadManager threadManager = args.ThreadManager;
            ActivityManager activityManager = args.ActivityManager;

            Thread thread = threadManager.GetThread((Guid) data["WebId"], (Guid) data["ListId"], (int) data["Id"]) ??
                            threadManager.SaveThread(new Thread
                            {
                                Title = (string) data["Title"],
                                Url = (string) data["URL"],
                                Kind = args.ObjectKind,
                                WebId = (Guid) data["WebId"],
                                ListId = (Guid) data["ListId"],
                                ItemId = (int) data["Id"]
                            });

            string metaData = null;

            if (data.ContainsKey("ChangedProperties"))
            {
                var changedProperties = data["ChangedProperties"] as string;
                if (!string.IsNullOrEmpty(changedProperties))
                {
                    bool renamed = changedProperties.Split(',').Any(p => p.Trim().ToLower().Equals("title"));

                    var serializer = new JavaScriptSerializer();
                    metaData = serializer.Serialize(new
                    {
                        changedProperties,
                        renamed
                    });
                }
            }

            Activity activity = activityManager.RegisterActivity(new Activity
            {
                Kind = args.ActivityKind,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = (DateTime) data["ActivityTime"],
                RawData = metaData
            });

            data.Add("#!Thread", thread);
            data.Add("#!Activity", activity);
        }

        private static void UpdateThreadUsers(Dictionary<string, object> data, ThreadManager threadManager,
            Thread thread)
        {
            var users = new List<User> {new User {Id = (int) data["UserId"], Role = UserRole.Author}};

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
            threadManager.UpdateUsers(thread);
        }

        private void ValidateCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            EnsureValideData(data);
            if (EnsureNotIgnoredList(args, data)) return;

            if (args.ActivityManager.ActivityExists(ObjectKind.ListItem, ActivityKind.Created,
                (Guid) data["WebId"], (Guid) data["ListId"], (int) data["Id"]))
            {
                throw new SocialEngineException(ALREADY_CREATED_EXCEPTION_MESSAGE, LogKind.Info);
            }
        }

        private void ValidateDeletionActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            EnsureValideData(data);
            if (EnsureNotIgnoredList(args, data)) return;

            if (args.ActivityManager.ActivityExists(ObjectKind.List, ActivityKind.Deleted, (Guid) data["WebId"],
                (Guid) data["ListId"], (int) data["Id"]))
            {
                throw new SocialEngineException(
                    "Cannot register more than one deleted activity on the same item.", LogKind.Info);
            }
        }

        private void ValidateUpdationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            EnsureValideData(data);
            EnsureNotIgnoredList(args, data);
        }

        #endregion Methods 

        #region Implementation of ISocialEngineModule

        public void Initialize(SocialEngineEvents events)
        {
            events.OnValidateActivity += OnValidateActivity;
            events.OnPreActivityRegistration += OnPreActivityRegistration;
            events.OnActivityRegistration += OnActivityRegistration;
            events.OnPostActivityRegistration += OnPostActivityRegistration;
        }

        #endregion
    }
}
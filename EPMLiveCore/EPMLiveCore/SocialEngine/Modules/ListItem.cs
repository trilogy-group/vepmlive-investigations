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
            "Cannot register more than one created activity on the same list item.";

        #endregion Fields 

        #region Methods (24) 

        // Private Methods (24) 

        private void AddAssociatedThreads(string associatedListItems, Thread thread, ThreadManager threadManager)
        {
            var dictionary = new Dictionary<Guid, int>();

            foreach (string li in associatedListItems.Split(','))
            {
                string[] values = li.Split('|');

                Guid listId = Guid.Parse(values[0]);
                int itemId = int.Parse(values[1]);

                if (!dictionary.ContainsKey(listId)) dictionary.Add(listId, itemId);
                else dictionary[listId] = itemId;
            }

            threadManager.UpdateAssociatedThreads(thread.Id, dictionary);
        }

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
            const string SETTING_KEY = "epm_ss_related_activity_interval";

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

        private static void ManageCommentUsers(ProcessActivityEventArgs args, Thread thread)
        {
            Dictionary<string, object> data = args.Data;
            var users = new List<User> {new User {Id = (int) data["UserId"], Role = UserRole.Commenter}};

            if (data.ContainsKey("Commenters"))
            {
                var commenters = data["Commenters"] as string;

                if (!string.IsNullOrEmpty(commenters))
                {
                    string[] cu = commenters.Split(',');

                    foreach (string user in cu)
                    {
                        int userId;
                        if (!int.TryParse(user.Trim(), out userId)) continue;

                        User tu = (from u in users where u.Id == userId select u).FirstOrDefault();

                        if (tu == null)
                        {
                            users.Add(new User {Id = userId, Role = UserRole.Commenter});
                        }
                        else
                        {
                            tu.Role |= UserRole.Commenter;
                        }
                    }
                }
            }

            thread.Users = users.AsParallel().Distinct().ToArray();
            args.ThreadManager.UpdateCommenters(thread);

            var validCommenters = new List<int>();

            IEnumerable<Activity> activities = args.ActivityManager.GetActivities(thread,
                new[] {ActivityKind.CommentAdded, ActivityKind.CommentUpdated});

            foreach (Activity activity in activities)
            {
                try
                {
                    string[] cu = ((string) ((dynamic) activity).GetData().commenters).Split(',');

                    validCommenters.AddRange(cu.Select(int.Parse));
                }
                catch { }
            }

            args.ThreadManager.CleanupCommenters(thread, validCommenters.AsParallel().Distinct());
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
                case ActivityKind.CommentAdded:
                    RegisterCommentCreationActivity(args);
                    break;
                case ActivityKind.CommentUpdated:
                    RegisterCommentUpdationActivity(args);
                    break;
                case ActivityKind.CommentRemoved:
                    RegisterCommentDeletionActivity(args);
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

            switch (args.ActivityKind)
            {
                case ActivityKind.CommentAdded:
                case ActivityKind.CommentUpdated:
                case ActivityKind.CommentRemoved:
                    return;
            }

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
                case ActivityKind.CommentAdded:
                    ValidateCommentCreationActivity(args);
                    break;
                case ActivityKind.CommentUpdated:
                    ValidateCommentUpdationActivity(args);
                    break;
                case ActivityKind.CommentRemoved:
                    ValidateCommentDeletionActivity(args);
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

            var thread = (Thread) data["#!Thread"];

            if (data.ContainsKey("IsMassOperation"))
            {
                if ((bool) data["IsMassOperation"])
                {
                    var activity = (Activity) data["#!Activity"];
                    activityManager.FlagMassOperation(activity.Id);
                }
            }

            Guid streamId = streamManager.GetGlobalStreamId((Guid) data["WebId"]);
            threadManager.AssociateStreams(thread, new[] {streamId});

            UpdateThreadUsers(args, thread);

            if (!data.ContainsKey("AssociatedListItems")) return;

            var associatedListItems = (string) (data["AssociatedListItems"] ?? string.Empty);

            if (!string.IsNullOrEmpty(associatedListItems))
            {
                AddAssociatedThreads(associatedListItems, thread, threadManager);
            }
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

            args.EcecuteUntransactionedOperation = true;
            args.UntransactionedOperation =
                () => ActivityManager.EnqueueActivity((Guid) data["SiteId"], (Guid) data["WebId"], listId,
                    userId, activityTime, activityTime - interval, args.ContextWeb);
        }

        private void RegisterCommentCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            Thread thread = args.ThreadManager.GetThread((Guid) data["WebId"], (Guid) data["ListId"], (int) data["Id"]);

            if (thread == null)
            {
                RegisterCreationActivity(args);
                thread = (Thread) data["#!Thread"];
            }
            else
            {
                data["#!Thread"] = thread;
            }

            var act = new Activity
            {
                Kind = args.ActivityKind,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = (DateTime) data["ActivityTime"],
                Key = data["CommentId"].ToString()
            };

            act.SetData(new {comment = data["Comment"], commenters = data["Commenters"]});

            Activity activity = args.ActivityManager.RegisterActivity(act);

            data.Add("#!Activity", activity);
        }

        private void RegisterCommentDeletionActivity(ProcessActivityEventArgs args)
        {
            RegisterDeletionActivity(args);

            args.ActivityManager.DeleteActivity(new Dictionary<string, object>
            {
                {"ActivityKey", args.Data["CommentId"].ToString().ToUpper()}
            });
        }

        private void RegisterCommentUpdationActivity(ProcessActivityEventArgs args)
        {
            RegisterUpdationActivity(args);

            Dictionary<string, object> data = args.Data;

            args.ActivityManager.UpdateActivity(new Dictionary<string, object>
            {
                {
                    "Data", new JavaScriptSerializer().Serialize(new
                    {
                        comment = data["Comment"],
                        commenters = data["Commenters"]
                    })
                }
            }, new Dictionary<string, object>
            {
                {"ActivityKey", data["CommentId"].ToString().ToUpper()}
            });
        }

        private void RegisterCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;
            ThreadManager threadManager = args.ThreadManager;
            ActivityManager activityManager = args.ActivityManager;

            var webId = (Guid) data["WebId"];
            var activityDateTime = (DateTime) data["ActivityTime"];

            Thread thread = threadManager.SaveThread(new Thread
            {
                Title = (string) data["Title"],
                Url = (string) data["URL"],
                Kind = ObjectKind.ListItem,
                FirstActivityDateTime = activityDateTime,
                WebId = webId,
                ListId = (Guid) data["ListId"],
                ItemId = (int) data["Id"]
            });

            data.Add("#!Thread", thread);

            if (args.ActivityKind != ActivityKind.Created) return;

            Activity activity = activityManager.RegisterActivity(new Activity
            {
                Kind = args.ActivityKind,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = activityDateTime
            });

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

            data.Add("#!Thread", thread);

            if (args.ActivityKind != ActivityKind.Deleted) return;

            threadManager.DeleteThread(thread);

            Activity activity = args.ActivityManager.RegisterActivity(new Activity
            {
                Kind = ActivityKind.Deleted,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = (DateTime) data["ActivityTime"]
            });

            data.Add("#!Activity", activity);
        }

        private void RegisterUpdationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;
            ThreadManager threadManager = args.ThreadManager;
            ActivityManager activityManager = args.ActivityManager;

            Thread thread = threadManager.GetThread((Guid) data["WebId"], (Guid) data["ListId"], (int) data["Id"]);

            if (thread == null)
            {
                var webId = (Guid) data["WebId"];
                var activityDateTime = (DateTime) data["ActivityTime"];

                thread = new Thread
                {
                    Title = (string) data["Title"],
                    Url = (string) data["URL"],
                    Kind = ObjectKind.ListItem,
                    FirstActivityDateTime = activityDateTime,
                    WebId = webId,
                    ListId = (Guid) data["ListId"],
                    ItemId = (int) data["Id"]
                };
            }
            else
            {
                thread.Title = (string) data["Title"];
                thread.Url = (string) data["URL"];
            }

            threadManager.SaveThread(thread);

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

            data.Add("#!Thread", thread);

            if (args.ActivityKind != ActivityKind.Updated) return;

            var act = new Activity
            {
                Kind = args.ActivityKind,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = (DateTime) data["ActivityTime"]
            };

            act.SetData(metaData);

            Activity activity = activityManager.RegisterActivity(act);

            data.Add("#!Activity", activity);
        }

        private static void UpdateThreadUsers(ProcessActivityEventArgs args, Thread thread)
        {
            if (args.ActivityKind == ActivityKind.CommentAdded ||
                args.ActivityKind == ActivityKind.CommentUpdated ||
                args.ActivityKind == ActivityKind.CommentRemoved)
            {
                ManageCommentUsers(args, thread);
                return;
            }

            Dictionary<string, object> data = args.Data;
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
            args.ThreadManager.UpdateUsers(thread);
        }

        private void ValidateCommentCreationActivity(ProcessActivityEventArgs args)
        {
            ValidateCreationActivity(args);

            Dictionary<string, object> data = args.Data;

            if (EnsureNotIgnoredList(args, data)) return;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"CommentId", DataType.Guid},
                {"Comment", DataType.String}
            });

            if (args.ActivityManager.ActivityExists(ObjectKind.ListItem, args.ActivityKind,
                (Guid) data["WebId"], (Guid) data["ListId"], (int) data["Id"], data["CommentId"].ToString()))
            {
                throw new SocialEngineException("Cannot register creation activity on the same comment more than once",
                    LogKind.Info);
            }
        }

        private void ValidateCommentDeletionActivity(ProcessActivityEventArgs args)
        {
            ValidateDeletionActivity(args);

            Dictionary<string, object> data = args.Data;

            if (EnsureNotIgnoredList(args, data)) return;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"CommentId", DataType.Guid}
            });

            if (!args.ActivityManager.ActivityExists(ObjectKind.ListItem, ActivityKind.CommentAdded,
                (Guid) data["WebId"], (Guid) data["ListId"], (int) data["Id"], data["CommentId"].ToString().ToUpper()))
            {
                throw new SocialEngineException("Cannot delete a comment that has not been registerd", LogKind.Info);
            }
        }

        private void ValidateCommentUpdationActivity(ProcessActivityEventArgs args)
        {
            ValidateUpdationActivity(args);

            Dictionary<string, object> data = args.Data;

            if (EnsureNotIgnoredList(args, data)) return;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"CommentId", DataType.Guid},
                {"Comment", DataType.String}
            });

            if (!args.ActivityManager.ActivityExists(ObjectKind.ListItem, ActivityKind.CommentAdded,
                (Guid) data["WebId"], (Guid) data["ListId"], (int) data["Id"], data["CommentId"].ToString().ToUpper()))
            {
                throw new SocialEngineException("Cannot update a comment that has not been registerd", LogKind.Info);
            }
        }

        private void ValidateCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            EnsureValideData(data);
            if (EnsureNotIgnoredList(args, data)) return;

            if (args.ActivityKind != ActivityKind.Created) return;

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

            if (args.ActivityKind != ActivityKind.Deleted) return;

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
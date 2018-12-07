using System;
using System.Collections.Generic;
using EPMLiveCore.SocialEngine.Contracts;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Entities;
using EPMLiveCore.SocialEngine.Events;

namespace EPMLiveCore.SocialEngine.Modules
{
    internal class List : ISocialEngineModule
    {
        #region Fields (1) 

        private const string ALREADY_CREATED_EXCEPTION_MESSAGE =
            "Cannot register more than one created activity on the same list.";

        #endregion Fields 

        #region Methods (9) 

        // Private Methods (9) 

        private static bool IsIgnoredList(ProcessActivityEventArgs args, Dictionary<string, object> data)
        {
            var listTitle = (string) data["Title"];

            if (!Core.Utilities.IsIgnoredList(listTitle, args.ContextWeb)) return false;

            args.Cancel = true;
            args.CancellationMessage = listTitle + " is part of ignored Social Stream lists.";

            return true;
        }

        private void OnActivityRegistration(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.List) return;

            switch (args.ActivityKind)
            {
                case ActivityKind.Created:
                    RegisterCreationActivity(args);
                    break;
                case ActivityKind.Deleted:
                    RegisterDeletionActivity(args);
                    break;
                case ActivityKind.BulkOperation:
                    RegisterBulkOperationActivity(args);
                    break;
            }
        }

        private void OnValidateActivity(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.List) return;

            switch (args.ActivityKind)
            {
                case ActivityKind.Created:
                    ValidateCreationActivity(args);
                    break;
                case ActivityKind.Deleted:
                    ValidateDeletionActivity(args);
                    break;
                case ActivityKind.BulkOperation:
                    ValidateBulkOperationActivity(args);
                    break;
                default:
                    throw new SocialEngineException("This activity cannot be performed on a list.", LogKind.Info);
            }
        }

        private void RegisterBulkOperationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;
            ThreadManager threadManager = args.ThreadManager;
            ActivityManager activityManager = args.ActivityManager;
            StreamManager streamManager = args.StreamManager;

            var webId = (Guid) data["WebId"];

            var activityDateTime = (DateTime) data["ActivityTime"];

            Thread thread = threadManager.SaveThread(new Thread
            {
                Title = string.Empty,
                Url = string.Empty,
                Kind = ObjectKind.List,
                WebId = webId,
                ListId = (Guid) data["Id"],
                FirstActivityDateTime = activityDateTime,
                Users = new[] {new User {Id = (int) data["UserId"], Role = UserRole.Author}}
            });

            var activity = new Activity
            {
                Kind = args.ActivityKind,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = activityDateTime
            };

            activity.SetData(new {totalActivities = data["TotalActivities"]});

            activityManager.RegisterActivity(activity);

            Guid streamId = streamManager.GetGlobalStreamId(webId);

            threadManager.AssociateStreams(thread, new[] {streamId});
            threadManager.UpdateUsers(thread);
        }

        private void RegisterCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;
            ThreadManager threadManager = args.ThreadManager;
            ActivityManager activityManager = args.ActivityManager;
            StreamManager streamManager = args.StreamManager;

            var webId = (Guid) data["WebId"];

            var activityDateTime = (DateTime) data["ActivityTime"];

            Thread thread = threadManager.SaveThread(new Thread
            {
                Title = (string) data["Title"],
                Url = (string) data["URL"],
                Kind = ObjectKind.List,
                FirstActivityDateTime = activityDateTime,
                WebId = webId,
                ListId = (Guid) data["Id"],
                Users = new[] {new User {Id = (int) data["UserId"], Role = UserRole.Author}}
            });

            activityManager.RegisterActivity(new Activity
            {
                Kind = args.ActivityKind,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = activityDateTime
            });

            Guid streamId = streamManager.GetGlobalStreamId(webId);

            threadManager.AssociateStreams(thread, new[] {streamId});
            threadManager.UpdateUsers(thread);
        }

        private void RegisterDeletionActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            ThreadManager threadManager = args.ThreadManager;
            var webId = (Guid) data["WebId"];

            Thread thread = threadManager.GetThread(webId, (Guid) data["Id"]);

            if (thread == null)
            {
                thread = threadManager.SaveThread(new Thread
                {
                    Title = (string) data["Title"],
                    Url = (string) data["URL"],
                    Kind = ObjectKind.List,
                    WebId = webId,
                    ListId = (Guid) data["Id"],
                    Users = new[] {new User {Id = (int) data["UserId"], Role = UserRole.Author}}
                });

                Guid streamId = args.StreamManager.GetGlobalStreamId(webId);

                threadManager.AssociateStreams(thread, new[] {streamId});
                threadManager.UpdateUsers(thread);
            }

            threadManager.DeleteThread(thread);

            args.ActivityManager.RegisterActivity(new Activity
            {
                Kind = ActivityKind.Deleted,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = (DateTime) data["ActivityTime"]
            });
        }

        private void ValidateBulkOperationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"Id", DataType.Guid},
                {"WebId", DataType.Guid},
                {"SiteId", DataType.Guid},
                {"UserId", DataType.Int},
                {"TotalActivities", DataType.Int},
                {"ActivityTime", DataType.DateTime}
            });
        }

        private void ValidateCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"Id", DataType.Guid},
                {"Title", DataType.String},
                {"URL", DataType.String},
                {"WebId", DataType.Guid},
                {"UserId", DataType.Int},
                {"ActivityTime", DataType.DateTime}
            });

            if (IsIgnoredList(args, data)) return;

            if (args.ActivityManager.ActivityExists(ObjectKind.Workspace, ActivityKind.Created,
                (Guid) data["WebId"], (Guid) data["Id"]))
            {
                throw new SocialEngineException(ALREADY_CREATED_EXCEPTION_MESSAGE, LogKind.Info);
            }
        }

        private void ValidateDeletionActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"Id", DataType.Guid},
                {"Title", DataType.String},
                {"URL", DataType.String},
                {"WebId", DataType.Guid},
                {"UserId", DataType.Int},
                {"ActivityTime", DataType.DateTime}
            });

            if (IsIgnoredList(args, data)) return;

            if (args.ActivityManager.ActivityExists(ObjectKind.List, ActivityKind.Deleted, (Guid) data["WebId"],
                (Guid) data["Id"]))
            {
                throw new SocialEngineException(
                    "Cannot register more than one deleted activity on the same list.", LogKind.Info);
            }
        }

        #endregion Methods 

        #region Implementation of ISocialEngineModule

        public void Initialize(SocialEngineEvents events)
        {
            events.OnValidateActivity += OnValidateActivity;
            events.OnActivityRegistration += OnActivityRegistration;
        }

        #endregion
    }
}
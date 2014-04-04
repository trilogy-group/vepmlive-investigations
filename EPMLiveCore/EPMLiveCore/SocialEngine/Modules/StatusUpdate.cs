using System;
using System.Collections.Generic;
using EPMLiveCore.SocialEngine.Contracts;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Entities;
using EPMLiveCore.SocialEngine.Events;

namespace EPMLiveCore.SocialEngine.Modules
{
    internal class StatusUpdate : ISocialEngineModule
    {
        #region Fields (1) 

        private const string ALREADY_CREATED_EXCEPTION_MESSAGE =
            "Cannot register more than one created activity on the same status update.";

        #endregion Fields 

        #region Methods (6) 

        // Private Methods (6) 

        private void OnActivityRegistration(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.StatusUpdate) return;

            if (args.ActivityKind == ActivityKind.Created) RegisterCreationActivity(args);
            else if (args.ActivityKind == ActivityKind.CommentAdded) RegisterCommentCreationActivity(args);
        }

        private void OnValidateActivity(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.StatusUpdate) return;

            switch (args.ActivityKind)
            {
                case ActivityKind.Created:
                    ValidateCreationActivity(args);
                    break;
                case ActivityKind.CommentAdded:
                    ValidateCommentCreationActivity(args);
                    break;
            }
        }

        private void RegisterCommentCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            Thread thread = args.ThreadManager.GetThread((Guid) data["WebId"], (Guid) data["ListId"],
                (int) data["ItemId"]);

            if (thread == null)
            {
                RegisterCreationActivity(args);
                thread = (Thread) data["#!Thread"];
            }

            var act = new Activity
            {
                Kind = args.ActivityKind,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = (DateTime) data["CommentTime"],
                Key = data["CommentId"].ToString()
            };

            act.SetData(new {comment = data["Comment"]});

            Activity activity = args.ActivityManager.RegisterActivity(act);
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
                Title = (string) data["Status"],
                Kind = args.ObjectKind,
                FirstActivityDateTime = activityDateTime,
                WebId = webId,
                ListId = (Guid) data["ListId"],
                ItemId = (int) data["ItemId"],
                Users = new[] {new User {Id = (int) data["UserId"], Role = UserRole.Author}}
            });

            data["#!Thread"] = thread;

            activityManager.RegisterActivity(new Activity
            {
                Key = data["Id"].ToString(),
                Kind = args.ActivityKind,
                UserId = (int) data["UserId"],
                Thread = thread,
                Date = activityDateTime
            });

            Guid streamId = streamManager.GetGlobalStreamId(webId);

            threadManager.AssociateStreams(thread, new[] {streamId});
            threadManager.UpdateUsers(thread);
        }

        private void ValidateCommentCreationActivity(ProcessActivityEventArgs args)
        {
            ValidateCreationActivity(args);

            Dictionary<string, object> data = args.Data;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"CommentId", DataType.Guid},
                {"Comment", DataType.String},
                {"CommentTime", DataType.DateTime}
            });

            if (args.ActivityManager.ActivityExists(ObjectKind.StatusUpdate, ActivityKind.CommentAdded,
                (Guid) data["WebId"], (Guid) data["ListId"], (int) data["ItemId"], data["CommentId"].ToString()))
            {
                throw new SocialEngineException("Cannot register creation activity on the same comment more than once",
                    LogKind.Info);
            }
        }

        private void ValidateCreationActivity(ProcessActivityEventArgs args)
        {
            Dictionary<string, object> data = args.Data;

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"Id", DataType.Guid},
                {"WebId", DataType.Guid},
                {"ListId", DataType.Guid},
                {"ItemId", DataType.Int},
                {"Status", DataType.String},
                {"UserId", DataType.Int},
                {"ActivityTime", DataType.DateTime}
            });

            if (args.ActivityKind == ActivityKind.CommentAdded) return;            

            if (args.ActivityManager.ActivityExists(ObjectKind.StatusUpdate, ActivityKind.Created,
                (Guid) data["WebId"], (Guid) data["ListId"], (int) data["ItemId"], data["Id"].ToString()))
            {
                throw new SocialEngineException(ALREADY_CREATED_EXCEPTION_MESSAGE, LogKind.Info);
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
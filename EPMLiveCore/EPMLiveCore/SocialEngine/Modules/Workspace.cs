using System;
using System.Collections.Generic;
using EPMLiveCore.SocialEngine.Contracts;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Entities;
using EPMLiveCore.SocialEngine.Events;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Modules
{
    internal class Workspace : ISocialEngineModule
    {
        #region Fields (2) 

        private const string ALREADY_CREATED_EXCEPTION_MESSAGE =
            "Cannot register more than one Workspace Created activity on the same workspace.";

        private const string CREATED_CONFIG_KEY = "EPM_SE_WC_Processed";

        #endregion Fields 

        #region Methods (7) 

        // Private Methods (7) 

        private void OnActivityRegistration(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.Workspace) return;

            RegisterWorkspaceActivity(args.ActivityKind, args.Data, args.ContextWeb,
                args.StreamManager, args.ThreadManager, args.ActivityManager);
        }

        private void OnValidateActivity(ProcessActivityEventArgs args)
        {
            if (args.ObjectKind != ObjectKind.Workspace) return;

            switch (args.ActivityKind)
            {
                case ActivityKind.Created:
                    ValidateWorkspaceCreationActivity(args.Data, args.ActivityManager, args.ContextWeb);
                    break;
                case ActivityKind.Deleted:
                    ValidateWorkspaceDeletionActivity(args.Data, args.ActivityManager);
                    break;
                default:
                    throw new SocialEngineException("This activity cannot be performed on a workspace.", LogKind.Info);
            }
        }

        private static void RegisterCreationActivity(ActivityKind activityKind, Dictionary<string, object> data,
            SPWeb contextWeb,
            StreamManager streamManager, ThreadManager threadManager, ActivityManager activityManager)
        {
            var webId = (Guid) data["Id"];

            Thread thread = threadManager.SaveThread(new Thread
            {
                Title = (string) data["Title"],
                Url = (string) data["URL"],
                Kind = ObjectKind.Workspace,
                WebId = webId
            });

            activityManager.RegisterActivity(new Activity
            {
                Kind = activityKind,
                UserId = (int) data["UserId"],
                Thread = thread
            });

            Guid streamId = streamManager.GetGlobalStreamId(webId);

            threadManager.AssociateStreams(thread, new[] {streamId});

            threadManager.AddUsers(thread, new[] {(int) data["UserId"]});
            streamManager.AddUsers(streamId, new[] {(int) data["UserId"]});

            CoreFunctions.setConfigSetting(contextWeb, CREATED_CONFIG_KEY, true.ToString());
        }

        private static void RegisterDeletionActivity(Dictionary<string, object> data, ThreadManager threadManager,
            ActivityManager activityManager)
        {
            Thread thread = threadManager.GetThread((Guid) data["Id"]);
            if (thread == null) return;

            threadManager.DeleteThread(thread);

            activityManager.RegisterActivity(new Activity
            {
                Kind = ActivityKind.Deleted,
                UserId = (int) data["UserId"],
                Thread = thread
            });
        }

        private void RegisterWorkspaceActivity(ActivityKind activityKind, Dictionary<string, object> data,
            SPWeb contextWeb,
            StreamManager streamManager, ThreadManager threadManager, ActivityManager activityManager)
        {
            if (activityKind == ActivityKind.Created)
            {
                RegisterCreationActivity(activityKind, data, contextWeb, streamManager, threadManager, activityManager);
            }
            else
            {
                RegisterDeletionActivity(data, threadManager, activityManager);
            }
        }

        private void ValidateWorkspaceCreationActivity(Dictionary<string, object> data, ActivityManager activityManager,
            SPWeb contextWeb)
        {
            string settingValue = CoreFunctions.getConfigSetting(contextWeb, CREATED_CONFIG_KEY);
            bool processed;

            bool.TryParse(settingValue, out processed);
            if (processed) throw new SocialEngineException(ALREADY_CREATED_EXCEPTION_MESSAGE, LogKind.Info);

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"Id", DataType.Guid},
                {"Title", DataType.String},
                {"URL", DataType.String},
                {"SiteId", DataType.Guid},
                {"UserId", DataType.Int}
            });

            if (activityManager.ActivityExists(ObjectKind.Workspace, ActivityKind.Created, (Guid) data["Id"]))
            {
                throw new SocialEngineException(ALREADY_CREATED_EXCEPTION_MESSAGE, LogKind.Info);
            }
        }

        private void ValidateWorkspaceDeletionActivity(Dictionary<string, object> data, ActivityManager activityManager)
        {
            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                {"Id", DataType.Guid},
                {"UserId", DataType.Int}
            });

            if (activityManager.ActivityExists(ObjectKind.Workspace, ActivityKind.Deleted, (Guid) data["Id"]))
            {
                throw new SocialEngineException(
                    "Cannot register more than one Workspace Deleted activity on the same workspace.", LogKind.Info);
            }
        }

        #endregion Methods 

        #region Implementation of ISocialEngineModule

        public void Initialize(SocialEngineEvents events)
        {
            events.OnValidateActivity = OnValidateActivity;
            events.OnActivityRegistration = OnActivityRegistration;
        }

        #endregion
    }
}
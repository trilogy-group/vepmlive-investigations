using System;
using System.Collections.Generic;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Events;

namespace EPMLiveCore.SocialEngine.Modules
{
    internal static class ListItemValidator
    {
        private const string AlreadyCreatedExceptionMessage =
            "Cannot register more than one created activity on the same list item.";

        internal static void ValidateCommentCreationActivity(this ProcessActivityEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            ValidateCreationActivity(args);

            var data = args.Data;

            if (EnsureNotIgnoredList(args, data))
            {
                return;
            }

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                { "CommentId", DataType.Guid },
                { "Comment", DataType.String }
            });

            Guid webId;
            Guid listId;
            int id;
            ParseActivityVales(data, out webId, out listId, out id);

            if (args.ActivityManager.ActivityExists(
                ObjectKind.ListItem,
                args.ActivityKind,
                webId,
                listId,
                id,
                data["CommentId"].ToString()))
            {
                throw new SocialEngineException(
                    "Cannot register creation activity on the same comment more than once",
                    LogKind.Info);
            }
        }

        internal static void ValidateCommentDeletionActivity(this ProcessActivityEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            ValidateDeletionActivity(args);

            var data = args.Data;

            if (EnsureNotIgnoredList(args, data))
            {
                return;
            }

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                { "CommentId", DataType.Guid }
            });

            Guid webId;
            Guid listId;
            int id;
            ParseActivityVales(data, out webId, out listId, out id);

            if (!args.ActivityManager.ActivityExists(
                ObjectKind.ListItem,
                ActivityKind.CommentAdded,
                webId,
                listId,
                id,
                data["CommentId"].ToString().ToUpper()))
            {
                throw new SocialEngineException("Cannot delete a comment that has not been registerd", LogKind.Info);
            }
        }

        internal static void ValidateCommentUpdationActivity(this ProcessActivityEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            ValidateUpdationActivity(args);

            var data = args.Data;

            if (EnsureNotIgnoredList(args, data))
            {
                return;
            }

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                { "CommentId", DataType.Guid },
                { "Comment", DataType.String }
            });

            Guid webId;
            Guid listId;
            int id;
            ParseActivityVales(data, out webId, out listId, out id);

            if (!args.ActivityManager.ActivityExists(
                ObjectKind.ListItem,
                ActivityKind.CommentAdded,
                webId,
                listId,
                id,
                data["CommentId"].ToString().ToUpper()))
            {
                throw new SocialEngineException("Cannot update a comment that has not been registerd", LogKind.Info);
            }
        }

        internal static void ValidateDeletionActivity(this ProcessActivityEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var data = args.Data;

            EnsureValideData(data);
            if (EnsureNotIgnoredList(args, data))
            {
                return;
            }

            if (args.ActivityKind != ActivityKind.Deleted)
            {
                return;
            }

            Guid webId;
            Guid listId;
            int id;
            ParseActivityVales(data, out webId, out listId, out id);

            if (args.ActivityManager.ActivityExists(
                ObjectKind.List,
                ActivityKind.Deleted,
                webId,
                listId,
                id))
            {
                throw new SocialEngineException(
                    "Cannot register more than one deleted activity on the same item.",
                    LogKind.Info);
            }
        }

        internal static void ValidateUpdationActivity(this ProcessActivityEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var data = args.Data;
            EnsureValideData(data);
            EnsureNotIgnoredList(args, data);
        }

        private static void ValidateCreationActivity(ProcessActivityEventArgs args)
        {
            var data = args.Data;

            EnsureValideData(data);
            if (EnsureNotIgnoredList(args, data))
            {
                return;
            }

            if (args.ActivityKind != ActivityKind.Created)
            {
                return;
            }

            Guid webId;
            Guid listId;
            int id;
            ParseActivityVales(data, out webId, out listId, out id);

            if (args.ActivityManager.ActivityExists(
                ObjectKind.ListItem,
                ActivityKind.Created,
                webId,
                listId,
                id))
            {
                throw new SocialEngineException(AlreadyCreatedExceptionMessage, LogKind.Info);
            }
        }

        private static bool EnsureNotIgnoredList(ProcessActivityEventArgs args, Dictionary<string, object> data)
        {
            var listTitle = GetDataString(data, "ListTitle");

            if (!Core.Utilities.IsIgnoredList(listTitle, args.ContextWeb))
            {
                return false;
            }

            args.Cancel = true;
            args.CancellationMessage = $"{listTitle} is part of ignored Social Stream lists.";

            return true;
        }

        private static void EnsureValideData(Dictionary<string, object> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            new DataValidator(data).Validate(new Dictionary<string, DataType>
            {
                { "Id", DataType.Int },
                { "Title", DataType.String },
                { "URL", DataType.String },
                { "ListTitle", DataType.String },
                { "ListId", DataType.Guid },
                { "WebId", DataType.Guid },
                { "SiteId", DataType.Guid },
                { "UserId", DataType.Int },
                { "ActivityTime", DataType.DateTime }
            });

            var oriUrl = data["URL"].ToString();

            if (oriUrl.StartsWith("lists/", StringComparison.InvariantCultureIgnoreCase) &&
                oriUrl.IndexOf("id=", StringComparison.InvariantCultureIgnoreCase) < 0)
            {
                throw new SocialEngineException($"{oriUrl} is not a valid URL.");
            }
        }

        private static void ParseActivityVales(
            Dictionary<string, object> data,
            out Guid webId,
            out Guid listId,
            out int id)
        {
            var webIdStr = GetDataString(data, "WebId");
            webId = ParseGuid(webIdStr);

            var listIdStr = GetDataString(data, "ListId");
            listId = ParseGuid(listIdStr);

            var idStr = GetDataString(data, "Id");
            id = ParseInt(idStr);
        }

        private static string GetDataString(Dictionary<string, object> data, string dataKey)
        {
            object dataValue;
            if (!data.TryGetValue(dataKey, out dataValue))
            {
                throw new InvalidOperationException($"{nameof(data)} doesn't contain key '{dataKey}'.");
            }

            var valueString = dataValue as string;
            return valueString;
        }

        private static Guid ParseGuid(string guidStr)
        {
            Guid guid;
            Guid.TryParse(guidStr, out guid);
            return guid;
        }

        private static int ParseInt(string intStr)
        {
            int number;
            int.TryParse(intStr, out number);
            return number;
        }
    }
}

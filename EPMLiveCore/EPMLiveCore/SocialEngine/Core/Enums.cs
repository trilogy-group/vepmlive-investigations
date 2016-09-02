using System;

namespace EPMLiveCore.SocialEngine.Core
{
    public enum ActivityKind
    {
        Created,
        Updated,
        Deleted,
        BulkOperation,
        CommentAdded,
        CommentUpdated,
        CommentRemoved
    }

    internal enum DataType
    {
        String,
        Int,
        Guid,
        DateTime
    }

    public enum LogKind
    {
        Error,
        Info
    }

    public enum ObjectKind
    {
        Workspace,
        List,
        ListItem,
        StatusUpdate
    }

    [Flags]
    public enum UserRole
    {
        None = 0x0000,
        Author = 0x0001,
        Commenter = 0x0002,
        Assignee = 0x0004,
        Liker = 0x0008
    }
}
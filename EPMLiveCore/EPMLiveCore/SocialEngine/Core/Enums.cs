using System;

namespace EPMLiveCore.SocialEngine.Core
{
    public enum ActivityKind
    {
        Created,
        Updated,
        Deleted
    }

    internal enum DataType
    {
        String,
        Int,
        Guid,
        DateTime
    }

    internal enum LogKind
    {
        Error,
        Info
    }

    public enum ObjectKind
    {
        Workspace,
        List,
        ListItem
    }

    [Flags]
    public enum UserRole
    {
        None        = 0x0000,
        Creator     = 0x0001,
        Editor      = 0x0002,
        Commenter   = 0x0004,
        Assignee    = 0x0008,
        Follower    = 0x0016
    }
}
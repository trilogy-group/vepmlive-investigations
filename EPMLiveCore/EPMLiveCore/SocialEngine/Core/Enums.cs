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
}
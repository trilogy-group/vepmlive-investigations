namespace EPMLiveCore.Infrastructure.Navigation
{
    public interface INavObject
    {
        string Id { get; }
        string CssClass { get; set; }
        bool Active { get; set; }
        bool Visible { get; set; }
        bool External { get; set; }
        string Url { get; set; }
        string Title { get; set; }
    }
}
namespace EPMLiveCore.Infrastructure.Navigation
{
    public interface INavObject
    {
        #region Data Members (7) 

        bool Active { get; set; }

        string CssClass { get; set; }

        bool External { get; set; }

        string Id { get; }

        string Title { get; set; }

        string Url { get; set; }

        bool Visible { get; set; }

        #endregion Data Members 
    }
}
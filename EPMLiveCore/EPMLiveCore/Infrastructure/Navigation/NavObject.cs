namespace EPMLiveCore.Infrastructure.Navigation
{
    public abstract class NavObject : INavObject
    {
        #region Constructors (1) 

        protected NavObject()
        {
            Visible = true;
        }

        #endregion Constructors 

        #region Implementation of INavObject

        public string Id { get; set; }
        public string CssClass { get; set; }
        public bool Active { get; set; }
        public bool Visible { get; set; }
        public bool External { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }

        #endregion
    }
}
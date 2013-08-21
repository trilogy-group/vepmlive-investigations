namespace EPMLiveCore.Infrastructure.Navigation
{
    public class NavLink : NavObject
    {
        #region Properties (3) 

        public string Category { get; set; }

        public int Order { get; set; }

        public bool Separator { get; set; }

        #endregion Properties 
    }
}
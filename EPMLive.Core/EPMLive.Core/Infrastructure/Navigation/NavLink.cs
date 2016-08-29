namespace EPMLiveCore.Infrastructure.Navigation
{
    public class NavLink : NavObject
    {
        #region Properties (4) 

        public string Category { get; set; }

        public string ObjectId { get; set; }

        public int Order { get; set; }

        public bool Separator { get; set; }

        #endregion Properties 
    }
}
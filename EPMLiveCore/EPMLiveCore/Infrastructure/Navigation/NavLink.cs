namespace EPMLiveCore.Infrastructure.Navigation
{
    public class NavLink : NavObject
    {
        public int Order { get; set; }
        public bool Separator { get; set; }
        public string Category { get; set; }
    }
}
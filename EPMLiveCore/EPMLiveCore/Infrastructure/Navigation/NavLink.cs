namespace EPMLiveCore.Infrastructure.Navigation
{
    public class NavLink : NavObject
    {
        private string _section;

        public string Section
        {
            get { return string.IsNullOrEmpty(_section) ? "TOP" : _section; }
            set { _section = value; }
        }
    }
}
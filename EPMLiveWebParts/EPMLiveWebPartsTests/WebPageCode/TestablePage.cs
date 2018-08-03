using System.Web;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public class TestablePage: getgantttasks
    {
        private HttpContextBase _context;

        public new HttpContextBase Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new HttpContextWrapper(HttpContext.Current);
                }
                return _context;
            }
            set { _context = value; }
        }

        public new HttpRequestBase Request
        {
            get { return Context.Request; }
        }
    }
}

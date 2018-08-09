using System.Web.Fakes;

namespace EPMLive.TestFakes.Utility
{
    public class HttpShims
    {
        public ShimHttpRequest RequestShim { get; private set; }

        public HttpShims()
        {
        }
    }
}

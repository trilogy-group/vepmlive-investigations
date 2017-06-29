using EMPLive.SSO;
using System.Net;

namespace EPMLive.SSO.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new ReportingService2010Extended();
            proxy.LogonUser("farmadmin", "Pass@word1", null);
        }
    }
}
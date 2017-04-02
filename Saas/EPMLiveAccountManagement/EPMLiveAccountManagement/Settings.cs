namespace EPMLiveAccountManagement
{
    public class Settings
    {
        public static string getPrefix()
        {
            string s = "";
            try
            {
                s = System.Configuration.ConfigurationManager.AppSettings["prefix"].ToString();
            }catch{}
            return s;
        }

        public static string getContractLevel()
        {
            string s = "2";
            try
            {
                s = System.Configuration.ConfigurationManager.AppSettings["contractLevel"].ToString();
            }
            catch { }
            return s;
        }

        public static string getConnectionStringByWebApp(string webappname)
        {
            string s = "server=192.168.2.80;database=EPMLIVE;User ID=epmlivedb;Password=MCjhfd4562D^7;Max Pool Size=200";
            try
            {
                s = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/", webappname).ConnectionStrings.ConnectionStrings["epmliveaccounts"].ConnectionString;
            }
            catch { }
            return s;
        }

        public static string getConnectionString()
        {
            string s = "server=192.168.2.80;database=EPMLIVE;User ID=epmlivedb;Password=MCjhfd4562D^7;Max Pool Size=200";
            try
            {
                s = System.Configuration.ConfigurationManager.ConnectionStrings["epmliveaccounts"].ConnectionString;
            }
            catch { }
            return s;
        }

        public static string getDomain()
        {
            string s = "epm";
            try
            {
                s = System.Configuration.ConfigurationManager.AppSettings["domain"].ToString();
            }
            catch { }
            return s;
        }
    }
}

using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Configuration;

namespace BillingSite
{
    class ZuoraHelper
    {
        private ZuoraAPI.ZuoraService zsvc;

        public ZuoraHelper()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ServicePointManager.ServerCertificateValidationCallback +=
            delegate (
                object sender,
                X509Certificate certificate,
                X509Chain chain,
                SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            zsvc = new ZuoraAPI.ZuoraService();
            zsvc.Url = ConfigurationManager.AppSettings["ServiceURL"];
            ZuoraAPI.LoginResult lr = zsvc.login(ConfigurationManager.AppSettings["ZuoraUserName"], ConfigurationManager.AppSettings["ZuoraPassword"]);

            zsvc.SessionHeaderValue = new ZuoraAPI.SessionHeader();
            zsvc.SessionHeaderValue.session = lr.Session;
        }

        public ZuoraAPI.QueryResult RunQuery(string query)
        {
            return zsvc.query(query);
        }

        public ZuoraAPI.SaveResult[] Create(ZuoraAPI.zObject[] zObjects)
        {
            return zsvc.create(zObjects);
        }

        public ZuoraAPI.SaveResult[] Update(ZuoraAPI.zObject[] zObjects)
        {
            return zsvc.update(zObjects);
        }

        public ZuoraAPI.DeleteResult[] Delete(string type, string []ids)
        {
            return zsvc.delete(type, ids);
        }

        public ZuoraAPI.SubscribeResult[] Subscribe(ZuoraAPI.SubscribeRequest[] zObjects)
        {
            return zsvc.subscribe(zObjects);
        }


    }
}

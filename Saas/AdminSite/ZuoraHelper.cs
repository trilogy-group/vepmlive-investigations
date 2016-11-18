using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;
using System.Net;

namespace AdminSite
{
    public class ZuoraHelper
    {
        public struct ProductCharge
        {
            #region Data Members (3)

            public string BillingPeriod;
            public string BillingPeriodDisplay;
            public string Id;
            public decimal? Price;

            #endregion Data Members
        }

        public struct ProductComponent
        {
            #region Data Members (2)

            public string IncludedUnits;
            public string Name;

            #endregion Data Members
        }

        private ZuoraAPI.ZuoraService zsvc;

        public ZuoraHelper()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ServicePointManager.ServerCertificateValidationCallback +=
            delegate(
                object sender,
                X509Certificate certificate,
                X509Chain chain,
                SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            zsvc = new ZuoraAPI.ZuoraService();
            zsvc.Url = "https://www.zuora.com/apps/services/a/33.0";
            ZuoraAPI.LoginResult lr = zsvc.login("colo@epmlive.com", "XUVzI5fo8RuegoTqsZ15");
            //zsvc.Url = "https://apisandbox.zuora.com/apps/services/a/33.0";
            //ZuoraAPI.LoginResult lr = zsvc.login("jhughes@epmlive.com", "Internet1");

            zsvc.SessionHeaderValue = new ZuoraAPI.SessionHeader();
            zsvc.SessionHeaderValue.session = lr.Session;
        }

        public ZuoraAPI.QueryResult RunQuery(string query)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
            delegate(
                object sender,
                X509Certificate certificate,
                X509Chain chain,
                SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
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

        public ZuoraAPI.DeleteResult[] Delete(string type, string[] ids)
        {
            return zsvc.delete(type, ids);
        }

        public ZuoraAPI.SubscribeResult[] Subscribe(ZuoraAPI.SubscribeRequest[] zObjects)
        {
            return zsvc.subscribe(zObjects);
        }

        public ZuoraAPI.AmendResult[] Amend(ZuoraAPI.AmendRequest[] ammendRequests)
        {
            return zsvc.amend(ammendRequests);
        }

        public ZuoraAPI.SaveResult[] Generate(ZuoraAPI.zObject[] zObjects)
        {
            return zsvc.generate(zObjects);
        }

    }
}

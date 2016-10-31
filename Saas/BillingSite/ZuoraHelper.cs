using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BillingSite
{
    class ZuoraHelper
    {
        private ZuoraAPI.ZuoraService zsvc;

        public ZuoraHelper()
        {
            zsvc = new ZuoraAPI.ZuoraService();
            
            zsvc.Url = "https://www.zuora.com/apps/services/a/33.0";
            ZuoraAPI.LoginResult lr = zsvc.login("colo@epmlive.com", "XUVzI5fo8RuegoTqsZ15");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //zsvc.Url = "https://apisandbox.zuora.com/apps/services/a/33.0";
            //ZuoraAPI.LoginResult lr = zsvc.login("jhughes@epmlive.com", "Internet1");

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

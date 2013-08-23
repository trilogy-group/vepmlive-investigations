using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EPMLiveIntegrationService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://epmlive.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Proxy : System.Web.Services.WebService
    {

        [WebMethod]
        public string PostItemSimple(string URL, string IntegrationKey, string ID)
        {
            try
            {
                IntService.Integration t = new IntService.Integration();
                t.Url = URL;
                return t.PostItemSimple(IntegrationKey, ID);
            }
            catch(Exception ex)
            {
                return "<Error>" + ex.Message + "</Error>";
            }
        }

        [WebMethod]
        public string AddUpdateItem(string URL, string IntegrationKey, string XML)
        {
            try
            {
                IntService.Integration t = new IntService.Integration();
                t.Url = URL;
                return t.AddUpdateItem(IntegrationKey, XML);
            }
            catch(Exception ex)
            {
                return "<Error>" + ex.Message + "</Error>";
            }
        }

        [WebMethod]
        public string DeleteItem(string URL, string IntegrationKey, string ID)
        {
            try
            {
                IntService.Integration t = new IntService.Integration();
                t.Url = URL;
                return t.DeleteItem(IntegrationKey, ID);
            }
            catch(Exception ex)
            {
                return "<Error>" + ex.Message + "</Error>";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WE_RSVP;

namespace PortfolioEngineCore.Services
{
    public class WSSAdmin
    {
        

        public string RSVPRequest(string sContexts, string sBasepath, string sTargetJobGuid = "")
        {
            RequestMgr oRequestMgr = new RequestMgr();
            string result = string.Empty;
            switch (sContexts)
            {
                case "ManageQueue":
                    oRequestMgr.ManageQueue(sBasepath, sTargetJobGuid);
                    result = "<Reply><HRESULT>0</HRESULT><STATUS>0</STATUS></Reply>";
                    break;
                case "ManageTimerJobs":
                    int value = oRequestMgr.ManageTimedJobs(sBasepath);
                    result = string.Format("<Reply><HRESULT>0</HRESULT><STATUS>{0}</STATUS></Reply>", value);
                    break;
                default:
                    break;
            }
            return result;

        }
        public string XMLRequest(string sContext, string sCookie, string sXML)
        {
            string result = string.Empty;
            WE_PDSExt.CMain oEPKPDS;
            WE_DBASvr.CMain oEPKDBA;
            switch (sContext)
            {
                case "EPKRequest":
                    oEPKPDS = new WE_PDSExt.CMain();
                    result = oEPKPDS.SoapXMLRequest(sCookie, sXML, "-a");
                    break;
                case "DBARequest":
                    oEPKDBA = new WE_DBASvr.CMain();
                    result = oEPKDBA.SoapXMLRequest(sCookie, sXML, "-a");
                    break;
                default:
                    oEPKPDS = new WE_PDSExt.CMain();
                    result = oEPKPDS.SoapXMLRequest(sCookie, sXML, "-a");
                    break;
            }
            return result;
        }
        
    }
}

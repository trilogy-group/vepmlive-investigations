using System;
using System.Reflection;

namespace PortfolioEngineCore
{
    public class PfEInterface : PFEBase
    {
        public PfEInterface(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading PfEInterface Class");
        }

        public PfEInterface(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading PfEInterface Class");
        }
        
        public bool HandleRequest(string sContext, string sRequest, out string sReply)
        {
            sReply = "";
            
            try
            {
                string sXML = BuildProductInfoString(IntPtr.Zero);
                // this is what we want to do
                //WE_PDSExt.CMain oEPK;
                //oEPK = new WE_PDSExt.CMain();
                //s = oEPK.SoapXMLRequest(sXML, sRequest, "");
                //oEPK = null;

                // this is what we have to do to late bind to a 32bit com+ vb6 object from a 64bit .net process
                Type comObjectType = Type.GetTypeFromProgID("WE_WSSAdmin.WSSAdmin");
                object comObject = Activator.CreateInstance(comObjectType);
                object[] myparams = new object[] {sContext, sXML, sRequest};
                sReply = (string)comObjectType.InvokeMember("XMLRequest", BindingFlags.InvokeMethod, null, comObject, myparams);

                comObject = null;
            }
            catch (Exception ex)
            {
                //s = HandleException(ex);
                return false;
            }
            return true;
        }

        private string BuildProductInfoString(IntPtr token)
        {
            //string basePath, username, pid, company, dbcnstring;
            //PortfolioEngineCore.SecurityLevels secLevel;
            //WebAdmin.CapturePFEBaseInfo(out basePath, out username, out pid, out company, out dbcnstring, out secLevel);

            //string sBaseInfo = WebAdmin.BuildBaseInfo(context);
            //PortfolioEngineCore.PFEBase pfebase = new PortfolioEngineCore.PFEBase(sBaseInfo);

            CStruct xEPKServer = new CStruct();
            xEPKServer.Initialize("EPKServer");
            xEPKServer.CreateString("BasePath", _basepath);
            xEPKServer.CreateInt("Port", _port);
            xEPKServer.CreateString("ConnectInfo", _dbcnstring);
            xEPKServer.CreateString("ResName", _username);
            xEPKServer.CreateInt("WResID", _userWResID);
            xEPKServer.CreateString("SessionInfo", _session);
            xEPKServer.CreateInt("ActiveTraceChannels", 0);
            //string sPID = WebAdmin.GetSPSessionString(context, "PID");
            //int nProductFlags = 0;
            //Int32.TryParse(Security.GetData(sPID, Security.vars.v_products), out nProductFlags);
            //xEPKServer.CreateString("ProductFlags", nProductFlags.ToString());


            //int nLicensedUsers = 0;
            //Int32.TryParse(Security.GetData(pid, Security.vars.v_users), out nLicensedUsers);
            //sLicensedUsers = nLicensedUsers.ToString();

            //int nLicenseType = 0;
            //Int32.TryParse(Security.GetData(pid, Security.vars.v_license), out nLicenseType);
            //xEPKServer.CreateString("LicenseType", nLicenseType.ToString());

            //if (nLicenseType == (int)Security.LicenseType.ltEvaluation)
            //{
            //    xEPKServer.CreateString("EvaluationEndDate", Security.GetData(pid, Security.vars.v_toDt));
            //}

            //xEPKServer.CreateString("IdentityToken", context.Session["IdentityToken"].ToString());
            if (token != IntPtr.Zero)
                xEPKServer.CreateString("IdentityToken", token.ToString());

            return xEPKServer.XML();
        }
    }
}

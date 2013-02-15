using System;
using System.Web;
using System.Web.Services;
using Microsoft.Win32;
using System.Security.Principal;
using PortfolioEngineCore;
using System.Reflection;

namespace WorkEnginePPM
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "PPM.Services")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public string BeginSession(string sUserName, string sPassword, string sNTAuth)
        {
            return BeginSessionEx();
        }

        [WebMethod(EnableSession = true)]
        public string BeginSessionEx()
        {
            string sStage;
            try
            {
                if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
                    return WebAdmin.GetSPSessionString(Context, "SessionInfo");
                else
                    return HandleError("BeginSessionEx", "User Authentication Failed. Stage=" + sStage);

            }
            catch (Exception ex)
            {
                return HandleException(ex, "BeginSessionEx");
            }
        }

        [WebMethod(EnableSession = true)]
        public void EndSession()
        {
            return;
        }

        [WebMethod(EnableSession = true)]
        public string XMLRequest(string sContext, string sRequest)
        {
            string sStage = "";
            try
            {
                if (Context.Session.Count > 0)
                {
                    //bool bAuthenticated = false;
                    //bool.TryParse(WebAdmin.GetSPSessionString(Context,"IsAuthenticated"), out bAuthenticated);
                    //if (bAuthenticated)
                    {
                        WebAdmin.DBTrace((StatusEnum) 0, TraceChannelEnum.WebServices, "WebService.XMLRequest",
                                         "Request",
                                         sContext, sRequest);
                        string s = "";
                        //string userName = WebAdmin.GetSPSessionString(Context,"userName");
                        //string sWResID = WebAdmin.GetSPSessionString(Context,"WResID");

                        //string basePath = WebAdmin.GetSPSessionString(Context,"basePath");
                        //string port = WebAdmin.GetSPSessionString(Context,"port");
                        //RegistryKey rk;
                        //string sRegKey = WebAdmin.BuildSiteRegistryKey(basePath);
                        //rk = Registry.LocalMachine.OpenSubKey(sRegKey);
                        //if (rk == null)
                        //{
                        //    s = HandleError(sContext, "Registry key not found : " + sRegKey);
                        //}
                        //else if (Session.Count == 0)
                        //{
                        //    s = HandleError(sContext, "Session values not initialized - Underscore in DNS name?");
                        //}
                        //else
                        //{
                        //    string connectionString = rk.GetValue("ConnectionString").ToString();
                        //    rk.Close();

                        //    if (sWResID != "")
                            {
                                IntPtr token = ((WindowsIdentity) Context.User.Identity).Token;
                                //if (token != IntPtr.Zero)
                                //    xEPKServer.CreateString("IdentityToken", token.ToString());

                                switch (sContext)
                                {
                                    case "EPKRequest":
                                    case "EPKCSRequest":
                                    case "DBARequest":
                                        {
                                            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                                            PortfolioEngineCore.PfEInterface pfeif = new PortfolioEngineCore.PfEInterface(sBaseInfo);
                                            try
                                            {
                                                pfeif.HandleRequest(sContext, sRequest, out s);
                                            }
                                            catch (Exception ex)
                                            {
                                                s = HandleException(ex, sContext);
                                            }
                                            break;
                                        }

                                    case "ManageQueue":
                                        {
                                            try
                                            {
                                                // check the queue for .net items before using RSVP
                                                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                                                PortfolioEngineCore.QueueManager qm = new QueueManager(sBaseInfo);
                                                if (qm.ReadNextQueuedItem() == true)
                                                {
                                                    // we have a queued item - try to handle it in portfolioenginecore first
                                                    if (qm.ManageQueue() == false) // false means not handled
                                                    {
                                                        switch (qm.Context)
                                                        {
                                                            case 200:
                                                                PortfolioEngineAPI pFeAPI = new PortfolioEngineAPI();
                                                                pFeAPI.Execute("RefreshRoles", "");
                                                                pFeAPI.Dispose();
                                                                qm.SetJobCompleted();
                                                                break;
                                                            default:
                                                                qm.HandleRequest("ManageQueue", sRequest, out s);
                                                                break;
                                                        }
                                                    }
                                                    qm = null;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                s = HandleException(ex, sContext);
                                            }
                                            break;
                                        }

                                    case "ManageTimerJobs":
                                        {
                                            try
                                            {
                                                string basePath, username, pid, company, dbcnstring;
                                                PortfolioEngineCore.SecurityLevels secLevel;
                                                WebAdmin.CapturePFEBaseInfo(out basePath, out username, out pid, out company, out dbcnstring, out secLevel);
                                                Type comObjectType = Type.GetTypeFromProgID("WE_WSSAdmin.WSSAdmin");
                                                object comObject = Activator.CreateInstance(comObjectType);
                                                object[] myparams = new object[] {"ManageTimerJobs", basePath};
                                                s = (string) comObjectType.InvokeMember("RSVPRequest",
                                                                                        BindingFlags.InvokeMethod,
                                                                                        null,
                                                                                        comObject,
                                                                                        myparams);

                                                comObject = null;
                                            }
                                            catch (Exception ex)
                                            {
                                                s = HandleException(ex, sContext);
                                            }
                                            break;
                                        }

                                    case "Ping":
                                        {
                                            s = HandlePing(Context);
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                        //}
                        WebAdmin.DBTrace((StatusEnum) 0, TraceChannelEnum.WebServices, "WebService.XMLRequest", "Reply",
                                         sContext, s);
                        return s;
                    }
                }
                return HandleError("WebService.XMLRequest", "User Authentication Failed. Session not valid. Stage=" + sStage);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "XMLRequest");
            }
        }

        [WebMethod(EnableSession = true)]
        public string SessionInfo(string sItem)
        {
            string s = "";
            switch (sItem)
            {
                case "BasePath":
                    s += WebAdmin.GetSPSessionString(Context,"basePath");
                    break;
                case "WResID":
                    s += WebAdmin.GetSPSessionString(Context,"WResID");
                    break;
                case "UserName":
                    s += WebAdmin.GetSPSessionString(Context,"userName");
                    break;
                case "SessionInfo":
                    s += WebAdmin.GetSPSessionString(Context,"SessionInfo");
                    break;
                //case "IsAuthenticated":
                //    if (IsAuthenticated) s += "true"; else s += "false";
                //    break;
                default:
                    break;
            }
            return s;
        }

        private static string HandlePing(HttpContext Context)
        {
            //string userName = Context.Session["userName"].ToString();
            //string sWResID = Context.Session["WResID"].ToString();

            //string basePath = Context.Session["basePath"].ToString();
            //string port = Context.Session["port"].ToString();
            //WorkEnginePPM.CStruct xReply = new WorkEnginePPM.CStruct();
            //xReply.Initialize("Reply");
            //xReply.CreateString("HRESULT", "0");
            //xReply.CreateString("STATUS", "0");
            //WorkEnginePPM.CStruct xPing = xReply.CreateSubStruct("Ping");
            //xPing.CreateString("BasePath", basePath);
            //xPing.CreateString("Port", port);
            ////xPing.CreateString("ConnectInfo", connectionString);
            //xPing.CreateString("ResName", userName);
            //xPing.CreateString("WResID", sWResID);
            //xPing.CreateString("SessionInfo", Context.Session["SessionInfo"].ToString());
            //xPing.CreateString("ActiveTraceChannels", Context.Session["ActiveTraceChannels"].ToString());
            //xPing.CreateString("ProductFlags", Context.Session["ProductFlags"].ToString());

            //return xReply.XML();
            return "Ping";
        }

        private static string HandleError(string sContext, string sError)
        {
            WorkEnginePPM.CStruct xReply = new WorkEnginePPM.CStruct();
            xReply.Initialize("Reply");
            xReply.CreateString("Error", "WebService.asmx Context=" + sContext + "; Error=" + sError + ";");
            xReply.CreateString("HRESULT", "0");
            xReply.CreateString("STATUS", "91111");

            string s = xReply.XML();
            WebAdmin.DBTrace((StatusEnum)91111, TraceChannelEnum.WebServices, "WebService.HandleError", "Reply", sContext, s);
            return s;
        }

        private static string HandleException(Exception ex, string sContext)
        {
            WorkEnginePPM.CStruct xReply = new WorkEnginePPM.CStruct();
            xReply.Initialize("Reply");
            xReply.CreateString("Error", "WebService.asmx Context=" + sContext + "; Exception=" + ex.Message.ToString() + ";");
            xReply.CreateString("HRESULT", "0");
            xReply.CreateString("STATUS", "99812");

            string s = xReply.XML();
            WebAdmin.DBTrace((StatusEnum)99812, TraceChannelEnum.WebServices, "WebService.HandleException", "Reply", sContext, s);
            return s;
        }
    }
}


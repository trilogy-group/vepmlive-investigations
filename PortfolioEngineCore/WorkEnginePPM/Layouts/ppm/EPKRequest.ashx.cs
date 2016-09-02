using System;
using System.Web;
using System.IO;
using WorkEnginePPM;
using WorkEnginePPM.Core.DataSync;
using Microsoft.SharePoint;
using PortfolioEngineCore;

namespace PPM
{

    public partial class EPKRequest : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Server.ScriptTimeout = 86400;
            StreamReader sr = new StreamReader(context.Request.InputStream);
            string sRequest = sr.ReadToEnd();
 
            context.Response.ContentType = "text/xml; charset=utf-8";
            if (sRequest.Length == 0)
                context.Response.Write("<Reply><HRESULT>0</HRESULT><Error>EPKRequest:rsRequestStringEmpty: Request String Is Empty</Error><STATUS>4</STATUS></Reply>");
            else if (context.User.Identity.IsAuthenticated == false)
                context.Response.Write("<Reply><HRESULT>0</HRESULT><Error>EPKRequest:rsUserNotAuthenticated: User Not Authenticated</Error><STATUS>11</STATUS></Reply>");
            else if (context.Session == null)
                context.Response.Write("<Reply><HRESULT>0</HRESULT><Error>EPKRequest:rsSessionNotInitialized: Session not initialized</Error><STATUS>12</STATUS></Reply>");
            else
            {
                string s = "";
                string sBaseInfo = WebAdmin.BuildBaseInfo(context);
                PortfolioEngineCore.PfEInterface pfeif = new PortfolioEngineCore.PfEInterface(sBaseInfo);
                try
                {
                    pfeif.HandleRequest("EPKRequest", sRequest, out s);
                    // addition of code to call RefreshRoles
                    CStruct xRequest = new CStruct();
                    if (xRequest.LoadXML(sRequest))
                    {
                        CStruct xnode = xRequest.GetSubStruct("EPKSet");
                        if (xnode != null)
                        {
                            xnode = xnode.GetSubStruct("CostAdmin");
                            if (xnode != null)
                            {
                                xnode = xnode.GetSubStruct("CostUpdate");
                                if (xnode != null)
                                {
                                    if (xnode.GetInt("Categories") == 2)
                                    {
                                        //PortfolioEngineAPI pFeAPI = new PortfolioEngineAPI();
                                        //pFeAPI.Execute("RefreshRoles", "");
                                        //pFeAPI.Dispose();

                                        string response;
                                        using (var roleManager = new RoleManager(SPContext.Current.Web))
                                        {
                                            response = roleManager.RunRefresh();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    s = HandleException(ex);
                }
                context.Response.Write(s);
            }
        }

        private static string HandleException(Exception ex)
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("Reply");
            xReply.CreateString("HRESULT", "0");
            xReply.CreateString("STATUS", "9222");
            xReply.CreateString("Error", "EPKRequest Exception : " + ex.Message.ToString());

            return xReply.XML();
        }
        #endregion
    }
}

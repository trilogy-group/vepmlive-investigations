using System;
using System.Web;
using Microsoft.Win32;
using Microsoft.SharePoint;
using EPMLiveCore;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    public class WebAdmin
    {
        public static void CapturePFEBaseInfo(out string basepath, out string username, out string ppmId, out string ppmCompany, out string ppmDbConn, out SecurityLevels secLevel)
        {
            secLevel = SecurityLevels.Base;
            using (var site = new SPSite(SPContext.Current.Web.Site.ID))
            {
                //using (SPWeb rootWeb = site.RootWeb)
                SPWeb rootWeb = site.RootWeb;
                {

                    basepath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                    ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                    ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                    ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");
                    username = ConfigFunctions.GetCleanUsername(rootWeb);
                }
            }
        }

        public static void CapturePFEBaseInfo(SPWeb web, out string basepath, out string username, out string ppmId, out string ppmCompany, out string ppmDbConn, out SecurityLevels secLevel)
        {
            secLevel = SecurityLevels.Base;
            using (var site = new SPSite(web.Site.ID))
            {
                //using (SPWeb rootWeb = site.RootWeb)
                SPWeb rootWeb = site.RootWeb;
                {

                    basepath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                    ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                    ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                    ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");
                    username = ConfigFunctions.GetCleanUsername(rootWeb);
                }
            }
        }

        public static string BuildBaseInfo(HttpContext context, SPWeb web)
        {
            string basePath, username, pid, company, dbcnstring;
            SecurityLevels secLevel;
            CapturePFEBaseInfo(web, out basePath, out username, out pid, out company, out dbcnstring, out secLevel);

            CStruct xEPKServer = new CStruct();
            xEPKServer.Initialize("BaseInfo");
            xEPKServer.CreateString("basepath", basePath);
            xEPKServer.CreateString("username", username);
            xEPKServer.CreateString("pid", pid);
            xEPKServer.CreateString("company", company);
            xEPKServer.CreateString("dbcnstring", dbcnstring);
            if (context != null)
            {
                xEPKServer.CreateInt("port", context.Request.Url.Port);
                xEPKServer.CreateString("session", GetSPSessionString(context, "SessionInfo"));
            }
            return xEPKServer.XML();
        }


        public static string BuildBaseInfo(HttpContext context)
        {
            string basePath, username, pid, company, dbcnstring;
            SecurityLevels secLevel;
            CapturePFEBaseInfo(out basePath, out username, out pid, out company, out dbcnstring, out secLevel);
            
            CStruct xEPKServer = new CStruct();
            xEPKServer.Initialize("BaseInfo");
            xEPKServer.CreateString("basepath", basePath);
            xEPKServer.CreateString("username", username);
            xEPKServer.CreateString("pid", pid);
            xEPKServer.CreateString("company", company);
            xEPKServer.CreateString("dbcnstring", dbcnstring);
            xEPKServer.CreateInt("port", context.Request.Url.Port);
            xEPKServer.CreateString("session", GetSPSessionString(context, "SessionInfo"));

            return xEPKServer.XML();
        }

        public static string GetConnectionString(HttpContext Context)
        {
            return GetConnectionString();
        }

        public static string GetConnectionString()
        {
            //string basePath = Context.Request.ApplicationPath;

            // Bugfix V4.2 CRL 03NOV2011 need to always read basepath from SP as multiple sites with different basepaths can share session
            string basePath = GetBasePath();
            return GetConnectionString(basePath);
        }

        public static string GetConnectionString(string basePath)
        {
            string sConnection = "";
            if (basePath.Length > 0)
            {
                //EPML-4761
                sConnection = PortfolioEngineCore.Utilities.GetConnectionString(basePath);
                //RegistryKey rk = PortfolioEngineCore.Utilities.GetRegistryKey(basePath);
                //if (rk != null)
                //{
                //    var value = rk.GetValue("ConnectionString");
                //    sConnection = (value != null ? value.ToString() : string.Empty);
                //    rk.Close();
                //}
            }
            return sConnection;
        }

        public static string BuildSiteRegistryKey(string basePath)
        {
            const string sRoot = "SOFTWARE\\Wow6432Node\\EPMLive\\PortfolioEngine\\";
            if (basePath.Length > 0)
                return  sRoot + basePath;
            else
                return sRoot;
        }

        public static string GetBasePath()
        {
            try
            {
                string basePath = ConfigFunctions.getConfigSetting(SPContext.Current.Web.Site.RootWeb, "EPKBasepath").Replace("/", "").Replace("\\", "");
                return basePath;
            }
            catch { return ""; }
        }

        public static string GetSPSessionString(HttpContext Context, string sName)
        {
            try
            {
                string basePath = GetBasePath();
                return Context.Session[basePath + "_" + sName].ToString();
            }
            catch { return ""; }
        }

        public static void SetSPSessionString(HttpContext Context, string basePath, string sName, string sValue)
        {
            try
            {
                Context.Session[basePath + "_" + sName] = sValue;
            }
            catch { }
        }

        public static void SetSPSessionString(HttpContext Context, string sName, string sValue)
        {
            try
            {
                string basePath = GetBasePath();
                Context.Session[basePath + "_" + sName] = sValue;
            }
            catch { }
        }

        public static bool AuthenticateUserAndProduct(HttpContext Context, out string sStage)
        {
            sStage = "";
            bool bAuthenticated;

            try
            {
                bAuthenticated = Context.Request.IsAuthenticated;
                if (bAuthenticated == true)
                {
                    string basePath = GetBasePath();
                    string sSession = GetSPSessionString(Context, "SessionInfo");
                    if (sSession == "")
                        SetSPSessionString(Context, basePath, "SessionInfo", Guid.NewGuid().ToString().ToUpper());
                }
            }
            catch(Exception e)
            {
                sStage += " Exception=" + e.Message;
                bAuthenticated = false;
            }
            return bAuthenticated;
        }
        public static bool HasPagePermission(string sPageId, string sMode)
        {
            return true;
        }
        public static string CheckRequest(HttpContext context, string this_class, string sRequest)
        {
            string sStage;
            string s = "";
            if (sRequest.Length == 0)
                s = "<Reply><HRESULT>0</HRESULT><Error>" + this_class + ":rsRequestStringEmpty: Request String Is Empty</Error><STATUS>4</STATUS></Reply>";
            else if (context.User.Identity.IsAuthenticated == false)
                s = "<Reply><HRESULT>0</HRESULT><Error>" + this_class + ":rsUserNotAuthenticated: User Not Authenticated</Error><STATUS>11</STATUS></Reply>";
            else if (context.Session == null)
                s = "<Reply><HRESULT>0</HRESULT><Error>" + this_class + ":rsSessionNotInitialized: Session not initialized</Error><STATUS>12</STATUS></Reply>";
            else if (WebAdmin.AuthenticateUserAndProduct(context, out sStage) != true)
                s = "<Reply><HRESULT>0</HRESULT><Error>" + this_class + ":AuthenticateUserAndProduct: " + sStage + "</Error><STATUS>8</STATUS></Reply>";
            return s;
        }
        public static string BuildReply(string this_class, string sFunction, string sContext, string sReply)
        {
            return "<reply handler=\"" + this_class + "\" function=\"" + sFunction + "\" context=\"" + sContext + "\" >" + sReply + "</reply>";
        }
        public static string FormatError(string severity, string location, string message, string trace = "")
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("error");
            xReply.CreateString("severity", severity);
            xReply.CreateString("location", location);
            xReply.CreateString("message", message);
            xReply.CreateString("trace", trace);
            return xReply.XML();
        }
        public static string FormatWarning(string message)
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("warning");
            xReply.CreateString("message", message);
            return xReply.XML();
        }
    }
}

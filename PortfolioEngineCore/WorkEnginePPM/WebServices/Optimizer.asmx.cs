using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Security.Principal;
using OptmizerDataCache;
using System.Reflection;
using System.Globalization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using EPMLiveCore;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using PortfolioEngineCore.Analyzers;
using PortfolioEngineCore.PortfolioItems;


namespace WorkEnginePPM
{

    [WebService(Namespace = "WorkEnginePPM")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]

    public class Optimizer : System.Web.Services.WebService
    {

        private static string basePath;
        private static string ppmId;
        private static string ppmCompany;
        private static string ppmDbConn;
        private static string username;
        private static SecurityLevels securityLevel;

        private string GetSPSessionBasePath()
        {
            using (SPWeb web = SPContext.Current.Web)
            {
                return ConfigFunctions.getConfigSetting(web, "EPKBasepath");
            }
        }


        private string GetOptimizerSessionKey()
        {
            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);

            string suname = username.Replace('\\', '_');

            return GetSPSessionBasePath() + "_OPT" + suname; //WebAdmin.GetSPSessionString(Context, "WResID");
        }

 
        [WebMethod(EnableSession = true)]
        public string Execute(string Function, string Dataxml)
        {
            string sStage;
            string cakey = GetOptimizerSessionKey();

            clsOptmizerDataCache datacache = null;


            bool bNew = false;


            if (Function == "GetOptimizerData" && datacache != null)
            {
               // this.Context.Session[cakey] = null;
                datacache = null;
            }
            else
                datacache = (clsOptmizerDataCache)GetCachedData(this.Context, cakey);

            if (datacache == null)
            {
                bNew = true;
                datacache = new clsOptmizerDataCache();
            }

            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {
                try
                {
                    Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                    Type thisClass = assemblyInstance.GetType("WorkEnginePPM.Optimizer", true, true);
                    MethodInfo m = thisClass.GetMethod(Function);
                    object result = m.Invoke(null, new object[] { this.Context, Dataxml, datacache });

                    //if (Function == "GetOptimizerData" && bNew == true)
                    //    this.Context.Session[cakey] = datacache;

                    SaveCachedData(Context, cakey, datacache);
 
                      return result.ToString();
                }
                catch (Exception ex)
                {
                    return HandleError("Execute", 99999, string.Format("Error executing function: {0}", ex.Message));
                }
            }
            else
                return HandleError("Execute", 99999, string.Format("PfE User Authentication Failed. Stage: {0}", sStage));
        }

        [WebMethod(EnableSession = true)]
        public string ExecuteJSON(string Function, string Dataxml)
        {
            string sReply = "";
            //string ids = "";
            try
            {
                sReply = Execute(Function, Dataxml);
                //if (Dataxml != string.Empty)
                //{
                //    var doc = new XmlDocument();
                //    doc.LoadXml(Dataxml);
                //    if (doc.FirstChild != null && doc.FirstChild.Attributes["IDList"] != null)
                //        ids = doc.FirstChild.Attributes["IDList"].Value;
                //}
            }
            catch (Exception ex)
            {
                sReply = HandleError("ExecuteJSON", 99999, string.Format("Error executing function: {0}", ex.Message));
            }

            return CStruct.ConvertXMLToJSON(sReply);
        }

        public static string OptimizerSessionPing(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {
            
            // this does nothing but help keep the data in the session live....
            return "";
        }

        public static string GetOptimizerData(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {

            string sReply = "";


            int ipopstart = 0;
            int ipopfin = 0;

            string sgpPMOAdmin = "";
            string sTicketResourcesXML = "";
            int iRawDataCount = 0;

            string sErrStage = "O010";

            CStruct xRoot = new CStruct(); 
            xRoot.LoadXML(sXML);

           // string sTicket = sXML;

            string sTicket = xRoot.GetStringAttr("Ticket");
            string ListID = xRoot.GetStringAttr("ListID");


            string sEchoReplyMessage = "";
            string sReplyMessage = "";


            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);

            PortfolioEngineCore.OptimizerData opt = new OptimizerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            string sPids = opt.GrabPidsFromTicket(sTicket);

            
            CStruct xResult = BuildResultXML("GetOptimzerData", 0);
            CStruct Extradata;


            Extradata = xResult.CreateSubStruct("OptData");
            string sOpt = opt.OptimizerLoadData(sPids);

            datacache.CaptureOptData(sOpt, sTicket, sPids, ListID);
            string sViews = "";
            if (opt.GetOptimizerViewsXML(out sViews) == false)
                sViews = "";

            string sStrat = "";
            if (opt.GetOptimizerStratagiesXML(ListID, out sStrat) == false)
                sStrat = "";

            datacache.StashViews(sViews);
            datacache.StashStratagies(sStrat);

            Extradata.AppendXML(sOpt);

            if (sViews != "")
                xResult.AppendXML(sViews);
            if (sStrat != "")
                xResult.AppendXML(sStrat);
    
            return xResult.XML();
        }


        public static string GetProjectGridData(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {

            return datacache.GetProjectsGrid();
        }

        public static string SetPIStatusModeChange(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {

            datacache.SetPIStatusModeChange(sXML);
            return "";
        }



        public static string UpdateFilteredList(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {

            datacache.UpdateFilteredList(sXML);
            return "";
        }


        public static string SaveOptimizerView(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.OptimizerData opt = new OptimizerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
             try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("SaveOptimizerView", 99999, "Invalid request xml");
                }

                CStruct xView = xExecute.GetSubStruct("View");

                Guid guidView = xView.GetGuidAttr("ViewGUID");
                string sName = xView.GetStringAttr("Name");
                bool bPersonal = (xView.GetIntAttr("Personal") == 1) ? true : false;
                bool bDefault = (xView.GetIntAttr("Default") == 1) ? true : false;
                string sData = xView.XML(); ;

                if (opt.SaveOptimizerViewXML(guidView, sName, bPersonal, bDefault, sData) == false)
                {
                    sReply = HandleError("SaveOptimizerView", opt.Status, opt.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("SaveOptimizerView", 0);
                    xResult.AppendSubStruct(xView);
                    sReply = xResult.XML();

                    string sViews = "";
                    if (opt.GetOptimizerViewsXML(out sViews) == false)
                        sViews = "";
                    datacache.StashViews(sViews);


                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveOptimizerView", 99999, ex, "");
            }
            return sReply;
        }

        public static string DeleteOptimizerView(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.OptimizerData opt = new OptimizerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("DeleteOptimizerView", 99999, "Invalid request xml");
                }

                CStruct xView = xExecute.GetSubStruct("View");

                Guid guidView = xView.GetGuidAttr("ViewGUID");

                if (opt.DeleteOptimizerViewXML(guidView) == false)
                {
                    sReply = HandleError("DeleteOptimizerView", opt.Status, opt.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("DeleteOptimizerView", 0);
                    xResult.AppendSubStruct(xView);
                    sReply = xResult.XML();

                    string sViews = "";
                    if (opt.GetOptimizerViewsXML(out sViews) == false)
                        sViews = "";
                    datacache.StashViews(sViews);
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("DeleteOptimizerView", 99999, ex, "");
            }
            return sReply;
        }

        public static string RenameOptimizerView(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.OptimizerData opt = new OptimizerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("RenameOptimizerView", 99999, "Invalid request xml");
                }

                CStruct xView = xExecute.GetSubStruct("View");

                Guid guidView = xView.GetGuidAttr("ViewGUID");
                string sName = xView.GetStringAttr("Name");

                if (opt.RenameOptimizerViewXML(guidView, sName) == false)
                {
                    sReply = HandleError("RenameOptimizerView", opt.Status, opt.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("RenameOptimizerView", 0);
                    xResult.AppendSubStruct(xView);
                    sReply = xResult.XML();

                    string sViews = "";
                    if (opt.GetOptimizerViewsXML(out sViews) == false)
                        sViews = "";
                    datacache.StashViews(sViews);
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("RenameOptimizerView", 99999, ex, "");
            }
            return sReply;
        }


        public static string SaveOptimizerStratagy(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.OptimizerData opt = new OptimizerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("SaveOptimizerStratagy", 99999, "Invalid request xml");
                }

                CStruct xStratagy = xExecute.GetSubStruct("Stratagy");

                Guid guidStratagy = xStratagy.GetGuidAttr("StratagyGUID");
                string sName = xStratagy.GetStringAttr("Name");
                bool bPersonal = (xStratagy.GetIntAttr("Personal") == 1) ? true : false;
                bool bDefault = (xStratagy.GetIntAttr("Default") == 1) ? true : false;
                string sData = xStratagy.XML(); 

                if (opt.SaveOptimizerStratagyXML(guidStratagy, sName, bPersonal, bDefault, sData) == false)
                {
                    sReply = HandleError("SaveOptimizerStratagy", opt.Status, opt.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("SaveOptimizerStratagy", 0);
                    xResult.AppendSubStruct(xStratagy);
                    sReply = xResult.XML();

                    string sStratagy = "";
                    if (opt.GetOptimizerStratagiesXML(datacache.GetListID(), out sStratagy) == false)
                        sStratagy = "";
                    datacache.StashStratagies(sStratagy);


                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveOptimizerStratagy", 99999, ex, "");
            }
            return sReply;
        }

        public static string DeleteOptimizerStratagy(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.OptimizerData opt = new OptimizerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("DeleteOptimizerView", 99999, "Invalid request xml");
                }

                CStruct xStratagy = xExecute.GetSubStruct("Stratagy");

                Guid guidStratagy = xStratagy.GetGuidAttr("StratagyGUID");


                if (opt.DeleteOptimizerStratagyXML(guidStratagy) == false)
                {
                    sReply = HandleError("DeleteOptimizerStratagy", opt.Status, opt.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("DeleteOptimizerStratagy", 0);
                    xResult.AppendSubStruct(xStratagy);
                    sReply = xResult.XML();

                    string sStratagy = "";
                    if (opt.GetOptimizerStratagiesXML(datacache.GetListID(), out sStratagy) == false)
                        sStratagy = "";
                    datacache.StashStratagies(sStratagy);
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("DeleteOptimizerStratagy", 99999, ex, "");
            }
            return sReply;
        }

        public static string RenameOptimizerStratagy(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.OptimizerData opt = new OptimizerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("RenameOptimizerStratagy", 99999, "Invalid request xml");
                }

                CStruct xStratagy = xExecute.GetSubStruct("Stratagy");

                Guid guidStratagy = xStratagy.GetGuidAttr("StratagyGUID");
                string sName = xStratagy.GetStringAttr("Name");

                if (opt.RenameOptimizerStratagyXML(guidStratagy, sName) == false)
                {
                    sReply = HandleError("RenameOptimizerView", opt.Status, opt.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("RenameOptimizerStratagy", 0);
                    xResult.AppendSubStruct(xStratagy);
                    sReply = xResult.XML();

                    string sStratagy = "";
                    if (opt.GetOptimizerStratagiesXML(datacache.GetListID(), out sStratagy) == false)
                        sStratagy = "";
                    datacache.StashStratagies(sStratagy);
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("RenameOptimizerStratagy", 99999, ex, "");
            }
            return sReply;
        }

        public static string CommitOptimizerStratagy(HttpContext Context, string sXML, clsOptmizerDataCache datacache)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.OptimizerData opt = new OptimizerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            PortfolioEngineCore.PortfolioItems.PortfolioItems  pcpi = new PortfolioItems(basePath, username, ppmId, ppmCompany, ppmDbConn, false);
            
            CStruct xResult = BuildResultXML("CommitOptimizerStratagy", 0);
            sReply = xResult.XML();
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("CommitOptimizerStratagy", 99999, "Invalid request xml");
                }

                string sIn = xExecute.GetStringAttr("In");
                string sOut = xExecute.GetStringAttr("Out");

                string sField = datacache.ReturnCommitflagName();

                sIn = sIn.Trim();
                sOut = sOut.Trim();

                sIn = sIn.Replace(' ', ',');
                sOut = sOut.Replace(' ', ',');

                if (sField != "")
                {

                    if (sIn != "" || sOut != "")
                    {
                        opt.CommitOptimizerStratagy(sField, sIn, sOut);

                        string sPids = "";

                        if (sIn != "" && sOut != "")
                            sPids = sIn + "," + sOut;
                        else 
                            sPids = sIn + sOut;

                        string sUpdatexml = pcpi.CreateUpdateUpdatePortfolioItemsXML(sPids);

                        Integration weInt = new Integration();
                        weInt.execute("UpdateItems", sUpdatexml);
                    }
                
                }

    
             //   pcpi.
            //    {
            //        sReply = HandleError("CommitOptimizerStratagy", opt.Status, opt.FormatErrorText());
            //    }
            //    else


            }
            catch (Exception ex)
            {
                sReply = HandleException("CommitOptimizerStratagy", 99999, ex, "");
            }
            return sReply;
        }

             
        private static CStruct BuildResultXML(string sContext = "", int nStatus = 0)
        {
            CStruct xResult = new CStruct();
            xResult.Initialize("Result");
            xResult.CreateStringAttr("Context", sContext);
            xResult.CreateIntAttr("Status", nStatus);
            return xResult;
        }

        private static string HandleError(string sContext, int nStatus, string sError)
        {
            CStruct xResult = BuildResultXML(sContext, nStatus);
            CStruct xError = xResult.CreateSubStruct("Error");
            //xError.Value = sError;
            xError.CreateIntAttr("ID", 100);
            xError.CreateStringAttr("Value", sError);
            return xResult.XML();
        }

        private static string HandleException(string sContext, int nStatus, Exception ex, string sStage)
        {
            return HandleError(sContext, nStatus, "Exception in CostAnalyzer.asmx (" + sStage + "): '" + ex.Message.ToString() + "'");

        }

        private static void SaveCachedData(HttpContext Context, string sKey, object value)
        {
            Context.Session[sKey] = null;
            Context.Session[sKey] = value;
            //DataCacheAPI.SaveCachedData(Context, sKey, value);
        }


        private static object GetCachedData(HttpContext Context, string sKey)
        {
            return Context.Session[sKey];
            //return DataCacheAPI.GetCachedData(Context, sKey);
        }       


    }

}


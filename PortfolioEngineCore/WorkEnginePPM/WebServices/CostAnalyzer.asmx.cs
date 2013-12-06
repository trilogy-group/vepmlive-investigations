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
using ResourceValues;
using RPADataCache;
using System.Reflection;
using System.Globalization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using EPMLiveCore;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using PortfolioEngineCore.Analyzers;
using CostDataValues;
using CADataCache;
using PortfolioEngineCore.PortfolioItems;

namespace WorkEnginePPM
{


    /// <summary>
    /// Summary description for EditCosts
    /// </summary>
    [WebService(Namespace = "WorkEnginePPM")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]

    public class CostAnalyzer : System.Web.Services.WebService
    {

        private static string basePath;
        private static string ppmId;
        private static string ppmCompany;
        private static string ppmDbConn;
        private static string username;
        private static SecurityLevels securityLevel;

        private string GetSPSessionBasePath()
        {
            //using (SPWeb web = SPContext.Current.Web)
            SPWeb web = SPContext.Current.Web;
            {
                return ConfigFunctions.getConfigSetting(web, "EPKBasepath");
            }
        }
      
        
        private string GetCASessionKey()
        {
            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);

            string suname = username.Replace('\\', '_');

            return GetSPSessionBasePath() + "_CA" + suname; //WebAdmin.GetSPSessionString(Context, "WResID");
        }

 
        [WebMethod(EnableSession = true)]
        public string Execute(string Function, string Dataxml)
        {
            string sStage;
            string cakey = GetCASessionKey();

            CostAnalyzerDataCache datacache = null; // (CostAnalyzerDataCache)this.Context.Session[cakey];
            bool bNew = false;

            if (Function == "CALoadData") // && datacache != null)
            {
                //this.Context.Session[cakey] = null;
                datacache = null;
            }
            else
                datacache = (CostAnalyzerDataCache) GetCachedData(this.Context, cakey);

            if (datacache == null)
            {
                bNew = true;
                datacache = new CostAnalyzerDataCache();
            }



  
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {
                try
                {
                    Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                    Type thisClass = assemblyInstance.GetType("WorkEnginePPM.CostAnalyzer", true, true);
                    MethodInfo m = thisClass.GetMethod(Function);
                    object result = m.Invoke(null, new object[] { this.Context, Dataxml, datacache});

                    //if (Function == "CALoadData" && bNew == true)
                    //    this.Context.Session[cakey] = datacache;

                    if ((Function != "GetPortfolioItemList") && (Function != "GetGeneratedPortfolioItemTicket")) 
                        SaveCachedData(this.Context, cakey, datacache);
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


        public static string GetPortfolioItemList(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string sReply = "";


            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioItems oPI = new PortfolioItems(basePath, username, ppmId, ppmCompany, ppmDbConn, false);

            try
            {
                string sPIDs = "";
                string sExts = "";
                string sxml = "";

                oPI.ObtainManagedPortfolioItems(out sExts, out sPIDs, out sxml);
                CStruct xResult = BuildResultXML("GetPortfolioItemList", 0);
                CStruct xData = xResult.CreateSubStruct("IDLists");
                xData.CreateStringAttr("EXTLIST", sExts);
                xData.CreateStringAttr("IDLIST", sPIDs);
                xData.AppendXML(sxml);

                sReply = xResult.XML();

            }
            catch (Exception ex)
            {
                sReply = HandleException("GetPortfolioItemList", 99999, ex, "");
            }
            return sReply;
        }

        public static string GetGeneratedPortfolioItemTicket(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string sReply = "";


            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioItems oPI = new PortfolioItems(basePath, username, ppmId, ppmCompany, ppmDbConn, false);

            try
            {
                string sGUID = "";


                sGUID = oPI.GeneratePortfolioItemTicket(sXML);
                CStruct xResult = BuildResultXML("GetGeneratedPortfolioItemTicket", 0);
                CStruct xData = xResult.CreateSubStruct("Ticket");
                xData.CreateStringAttr("Value", sGUID);

                sReply = xResult.XML();

            }
            catch (Exception ex)
            {
                sReply = HandleException("GetGeneratedPortfolioItemTicket", 99999, ex, "");
            }
            return sReply;
        }


        public static string CASessionPing(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            
            // this does nothing but help keep the data in the session live....
            return "";
        }

        public static string CALoadData(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {

            CStruct xRoot = new CStruct();
            string sTargets = "";
            string sViews = "";
            string sTotal = "";
            string sDetails = "";
            string sDispMode = "";
            string sHeatmaptext = "";
            string sPeriods = "";
            string sCTNames = "";

            int ipopstart = 0;
            int ipopfin = 0;

            string sgpPMOAdmin = "";
            string sTicketResourcesXML = "";
            int iRawDataCount = 0;

            string sErrStage = "O010";

            xRoot.LoadXML(sXML);

            sErrStage = "O011";

            string sTicket = xRoot.GetStringAttr("Ticket");
            string ViewID = xRoot.GetStringAttr("ViewID");

            string sEchoReplyMessage = "";
            string sReplyMessage = "";
            CStruct xResult = BuildResultXML("GetCostData", 0);

  
            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);


            PortfolioEngineCore.CostAnalyzerData cda = new CostAnalyzerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            string smsg = "";
            int retcode = 0;

            clsCostData clsda = null;


            clsda = cda.InitalLoadData(sTicket, ViewID, out smsg, out retcode);

            if (clsda == null)
            {

                xResult = BuildResultXML("CostAnalyzer.CALoadData at " + retcode.ToString(), 99999);
                CStruct xError = xResult.CreateSubStruct("Error");
                xError.CreateIntAttr("ID", 100);
                xError.CreateStringAttr("Value", smsg);
                return xResult.XML();
            }
            CStruct xPerms = xResult.CreateSubStruct("Perms");
            xPerms.CreateIntAttr("Value", clsda.m_gPOPerm);
            if (clsda.m_gPOPerm == 0)
            {
                return xResult.XML();
            }

            datacache.GrabCAData(clsda);

            if (cda.GetCostAnalyzerViewsXML(out sViews) == false)
                sViews = "";
            datacache.StashViews(sViews);

            sPeriods = datacache.GetPeriodsData();
            sCTNames  = datacache.GetCostTypeNameData();

            sTargets = datacache.GetTargetRGBData();
            
                                    // sErrStage = "O027";
                                    //RAData.GrabRAData(resValues, lw, "", resValues.ResExamView, StartID, CalID, out sErrStage);

                                    //sErrStage = "O028";
                                    //sReply = RAData.GetTargetRGBData();

                                    //sErrStage = "O029";
                                    //if (rpa.GetResourceAnalyzerViewsXML(out sViews) == false)
                                    //{
                                    //    sReply = HandleError("GetResourceValues", rpa.Status, rpa.FormatErrorText());
                                    //    sViews = "";
                                    //}

                                    //sErrStage = "O030";
                                    //RAData.StashViews(sViews);
                                    //sErrStage = "O031";
                                    //RAData.StashCapacityReloadXML(xSaveParms.XML());

                                    sErrStage = "O032";
                                    sTotal = datacache.GetTotalsData();

                                    //sErrStage = "O033";

                                    //sDetails = RAData.GetDetailsData();


            sDispMode = datacache.GetDisplayMode();

                                    //sErrStage = "O035";
                                    //sgpPMOAdmin = RAData.GetPMOAdmin();
                                    //sErrStage = "O036";
                                    //iRawDataCount = RAData.GetRawDataCount();

            datacache.GetStartFinishDataPeriods(out ipopstart, out ipopfin);
                                    //sHeatmaptext = RAData.GetHeatmapText();

 
            //sReply = "<Error Value='GetResourceValues failed - " + sEchoReplyMessage + "'/>";  //  stuck here as a test
            

            CStruct Extradata;

            if (sTargets != "")
                xResult.AppendXML(sTargets);
            if (sPeriods != "")
                xResult.AppendXML(sPeriods);
            if (sCTNames != "")
                xResult.AppendXML(sCTNames);
            if (sDispMode != "")
                xResult.AppendXML(sDispMode);
            if (sViews != "")
                xResult.AppendXML(sViews);
            if (sTotal != "")
            {
                Extradata = xResult.CreateSubStruct("TotalsConfiguration");
                Extradata.CreateStringAttr("Value", sTotal);
            }
            

            //xResult.AppendXML(sReply);
            //if (sViews != "")
            //    xResult.AppendXML(sViews);




            //Extradata = xResult.CreateSubStruct("TotalsConfiguration");
            //Extradata.CreateStringAttr("Value", sTotal);
            //Extradata.AppendXML(sTotal);
            //Extradata = xResult.CreateSubStruct("DetailsConfiguration");
            //Extradata.CreateStringAttr("Value", sDetails);
            //Extradata.AppendXML(sDetails);

            Extradata = xResult.CreateSubStruct("DisplayModeXML");
            Extradata.CreateStringAttr("Value", sDispMode);



            //Extradata = xResult.CreateSubStruct("gpPMOAdmin");
            //Extradata.CreateStringAttr("Value", sgpPMOAdmin);
            //Extradata = xResult.CreateSubStruct("LoadingDataReply");
            //Extradata.CreateStringAttr("Value", sEchoReplyMessage);
            //Extradata = xResult.CreateSubStruct("TicketValue");
            //Extradata.CreateStringAttr("Value", sTicket);
            //Extradata = xResult.CreateSubStruct("TicketReturns");
            //Extradata.CreateStringAttr("Value", sTicketResourcesXML);
            //Extradata = xResult.CreateSubStruct("DetailsLoaded");
            //Extradata.CreateIntAttr("Value", iRawDataCount);
           Extradata = xResult.CreateSubStruct("PeriodRange");
           Extradata.CreateIntAttr("Start", ipopstart);
           Extradata.CreateIntAttr("Finish", ipopfin);
            //Extradata = xResult.CreateSubStruct("HeatMapText");
            //Extradata.CreateStringAttr("Value", sHeatmaptext);

    
            return xResult.XML();
        }

        public static string SetCTDetails(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetCTDetails", 99999, "Invalid request xml");
            }

            datacache.SetCTStateData(xData);

            return "";
        }

        public static string SetDisplayMode(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetDisplayMode", 99999, "Invalid request xml");
            }



            datacache.SetDisplayMode(xData);

            return "";
        }

        public static string GetCostAnalyzerData(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string s = datacache.GetTopGrid();
            return s;
        }

        public static string GetCostAnalyzerTotals(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string s = datacache.GetBottomGrid();
            return s;
        }

        public static string GetTargetGrid(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string s = datacache.GetTargetGrid();
            return s;
        }
        public static string GetTotalsConfiguration(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {

            CStruct xResult = BuildResultXML("GetTotalsColumnsConfiguration", 0);
            xResult.AppendXML(datacache.GetTotalsData());
            return xResult.XML(); 
        }

        public static string SetTotalsConfiguration(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {

            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetColumnsConfiguration", 99999, "Invalid request xml");
            }

            

            datacache.SetTotalsData(xData);

   

            return "";
        } 
        
        
        public static string GetCompareCostTypeList(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {

            CStruct xResult = BuildResultXML("GetCompareCostTypeList", 0);
            xResult.AppendXML(datacache.GetCompareCostTypeList());
            return xResult.XML();
        }

        public static string SetCompareCostTypeList(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {

            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetCompareCostTypeList", 99999, "Invalid request xml");
            }

            CStruct xResult = BuildResultXML("SetCompareCostTypeList", 0);
            xResult.AppendXML(datacache.SetCompareCostType(xData));
            return xResult.XML(); 
           
        }


        public static string SetDetailsSelectedFlag(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {

            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetDetailsSelectedFlag", 99999, "Invalid request xml");
            }




            datacache.SetSelectedForRows(xData);
            return "";
       }

        public static string SetDetailsFilteredFlag(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {

            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetDetailsFilteredFlag", 99999, "Invalid request xml");
            }




            datacache.SetFilteredForRows(xData);
            return "";
        }

        public static string GetLegendKey(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string s = datacache.GetLegendGrid();


            return s;
        }


        public static string SetShowRemaining(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {

            datacache.SetShowRemaining(sXML == "1");

            return "";
        }


        public static string SaveCostPlanAnalyzerView(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);


            PortfolioEngineCore.CostAnalyzerData cda = new CostAnalyzerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("SaveCostPlanAnalyzerView", 99999, "Invalid request xml");
                }

                CStruct xView = xExecute.GetSubStruct("View");

                Guid guidView = xView.GetGuidAttr("ViewGUID");
                string sName = xView.GetStringAttr("Name");
                bool bPersonal = (xView.GetIntAttr("Personal") == 1) ? true : false;
                bool bDefault = (xView.GetIntAttr("Default") == 1) ? true : false;
                string sData = xView.XML(); ;

                if (cda.SaveCostAnalyzerViewXML(guidView, sName, bPersonal, bDefault, sData) == false)
                {
                    sReply = HandleError("SaveCostPlanAnalyzerView", cda.Status, cda.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("SaveCostAnalyzerView", 0);
                    xResult.AppendSubStruct(xView);
                    sReply = xResult.XML();

                    string sViews = "";
                    if (cda.GetCostAnalyzerViewsXML(out sViews) == false)
                          sViews = "";
                    datacache.StashViews(sViews);


                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveCostAnalyzerView", 99999, ex, "");
            }
            return sReply;
        }

        public static string DeleteCostAnalyzerView(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string sReply = "";


            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);


            PortfolioEngineCore.CostAnalyzerData cda = new CostAnalyzerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("DeleteResourceAnalyzerView", 99999, "Invalid request xml");
                }

                CStruct xView = xExecute.GetSubStruct("View");

                Guid guidView = xView.GetGuidAttr("ViewGUID");

                if (cda.DeleteCostAnalyzerViewXML(guidView) == false)
                {
                    sReply = HandleError("DeleteCostAnalyzerView", cda.Status, cda.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("DeleteResourceAnalyzerView", 0);
                    xResult.AppendSubStruct(xView);
                    sReply = xResult.XML();

                    string sViews = "";
                    if (cda.GetCostAnalyzerViewsXML(out sViews) == false)
                        sViews = "";
                    datacache.StashViews(sViews);
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("DeleteResourceAnalyzerView", 99999, ex, "");
            }
            return sReply;
        }

        public static string RenameCostAnalyzerView(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string sReply = "";


            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);


            PortfolioEngineCore.CostAnalyzerData cda = new CostAnalyzerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("RenameResourceAnalyzerView", 99999, "Invalid request xml");
                }

                CStruct xView = xExecute.GetSubStruct("View");

                Guid guidView = xView.GetGuidAttr("ViewGUID");
                string sName = xView.GetStringAttr("Name");

                if (cda.RenameCostAnalyzerViewXML(guidView, sName) == false)
                {
                    sReply = HandleError("RenameCostAnalyzerView", cda.Status, cda.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("RenameResourceAnalyzerView", 0);
                    xResult.AppendSubStruct(xView);
                    sReply = xResult.XML();

                    string sViews = "";
                    if (cda.GetCostAnalyzerViewsXML(out sViews) == false)
                        sViews = "";
                    datacache.StashViews(sViews);
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("RenameResourceAnalyzerView", 99999, ex, "");
            }
            return sReply;
        }



        public static string ApplyCostAnalyzerViewServerSideSettings(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            CStruct xResult = BuildResultXML("ApplyCostAnalyzerViewServerSideSettings", 0);
            xResult.AppendXML(datacache.ApplyServerSideViewSettings(sXML));
            return xResult.XML();
        }



        public static string GetTargetList(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {



            CStruct xResult = BuildResultXML("GetTargetList", 0);
            xResult.AppendXML(datacache.GetTargetList());
            return xResult.XML();
        }

        public static string DeleteTarget(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {
            string shmt = ""; 
            
            try
            {
                int tarID = int.Parse(sXML);



                bool bdtatabasedelete = datacache.DeleteTarget(tarID, out shmt);

                if (bdtatabasedelete)
                {


                    WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);


                    PortfolioEngineCore.CostAnalyzerData cda = new CostAnalyzerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

                    cda.DeleteTarget(tarID);
 
                }



            }
            catch (Exception ex) { }

            CStruct xResult = BuildResultXML("DeleteTarget", 0);

            CStruct Extradata = xResult.CreateSubStruct("HeatMapText");
            Extradata.CreateStringAttr("Value", shmt); 
            return xResult.XML();           

        }



        public static string GetClientSideCalcData(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {



            CStruct xResult = BuildResultXML("GetTargetList", 0);
            xResult.AppendXML(datacache.RatesAndCategory());
            return xResult.XML();
        }


        public static string GetTargetTotalsData(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {



            CStruct xResult = BuildResultXML("GetTargetTotalsData", 0);
            xResult.AppendXML(datacache.GetTargetTotalsData());
            return xResult.XML();
        }

        public static string PrepareTargetData(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {



            CStruct xResult = BuildResultXML("GetTargetData", 0);
            xResult.AppendXML(datacache.PrepareTargetData(sXML));
            return xResult.XML();
        }


        public static string SaveTargetData(HttpContext Context, string sXML, CostAnalyzerDataCache datacache)
        {



            CStruct xResult = BuildResultXML("SaveTarget", 0);
            CStruct Extradata = new CStruct();
            Extradata.Initialize("SaveTarget");
            CStruct Extradata1 = Extradata.CreateSubStruct("Target");



            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);


            PortfolioEngineCore.CostAnalyzerData cda = new CostAnalyzerData(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            int targetID;
            string sTargetName;
            bool bNewTarget;
            cda.SaveTargetData(sXML, datacache.Get_CB_ID(), out targetID, out sTargetName, out bNewTarget);

            if (targetID > 0)
            {
                clsCostData clsda = cda.ReloadTargets(datacache.Get_CB_ID(), datacache.Get_MaxPeriods());
                datacache.RefreshTargets(clsda);


            }

            Extradata1.CreateIntAttr("Value", targetID);
            xResult.AppendXML(Extradata.XML());
            return xResult.XML();
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


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Security.Principal;
using EPMLiveCore.Infrastructure.Logging;
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

    public class ResPlanAnalyzer : System.Web.Services.WebService
    {
        private const string COMPONENT_NAME = "Resource Plan Analyzer";

        private static string basePath;
        private static string ppmId;
        private static string ppmCompany;
        private static string ppmDbConn;
        private static string username;
        private static SecurityLevels securityLevel;

        private string GetSPSessionBasePath()
        {
           // using (SPWeb web = SPContext.Current.Web)
            SPWeb web = SPContext.Current.Web;
            {
                return ConfigFunctions.getConfigSetting(web, "EPKBasepath");
            }
        }
      
        
        private string GetRPSessionKey()
        {
            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);

            string suname = username.Replace('\\','_');

            return GetSPSessionBasePath() + "_RPA" + suname; //WebAdmin.GetSPSessionString(Context, "WResID");
        }

 
        [WebMethod(EnableSession = true)]
        public string Execute(string Function, string Dataxml)
        {
            string sStage;
            string rpkey = GetRPSessionKey();
            RPAData RAData = null; // (RPAData)this.Context.Session[rpkey];
            bool bNew = false;


            if (Function == "RALoadData")   // && RAData != null)
            {
                //     this.Context.Session[rpkey] = null;
                RAData = null;
            }
            else
                RAData = (RPAData) GetCachedData(this.Context, rpkey);

            if (RAData == null)
            {
                bNew = true;
                RAData = new RPAData();
            }

            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {
                try
                {

                    if (Function == "ReloadPlanData")
                        return ReloadPlanData(this.Context, RAData);

                    else
                    {
                        Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                        Type thisClass = assemblyInstance.GetType("WorkEnginePPM.ResPlanAnalyzer", true, true);
                        MethodInfo m = thisClass.GetMethod(Function);
                        object result = m.Invoke(null, new object[] {this.Context, Dataxml, RAData});

                    //    if (Function == "RALoadData" && bNew == true)
                    //        this.Context.Session[rpkey] = RAData;

                        if ((Function != "GetPortfolioItemList") && (Function != "GetGeneratedPortfolioItemTicket"))
                            SaveCachedData(Context, rpkey, RAData);

                        return result.ToString();
                    }
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
            using (var logger = new Logger(SPContext.Current.Web))
            {
                logger.LogMessage("ResPlanAnalyzer.asmx --> ExecuteJSON", COMPONENT_NAME, LogKind.Info);

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
                    logger.LogMessage(ex, COMPONENT_NAME);
                    sReply = HandleError("ExecuteJSON", 99999, string.Format("Error executing function: {0}", ex.Message));
                }

                string jsonReply = CStruct.ConvertXMLToJSON(sReply);

                logger.LogMessage("ExecureJSON Original Reply: " + sReply, COMPONENT_NAME, LogKind.Info);
                logger.LogMessage("ExecureJSON JSON Reply: " + jsonReply, COMPONENT_NAME, LogKind.Info);

                return jsonReply;
            }
        }

        public static string GetRAUserCalendarInfo(HttpContext Context, string sXML, RPAData RAData)
        {
            string sReply = "";


             WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
             PortfolioEngineCore.ResourceAnalyzer rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
  
            try
            {
                string sRPACalInfoXML = "";
                if (rpa.GetResourceAnalyzerUserCalendarSettingsXML(out sRPACalInfoXML) == false)
                {
                    sReply = HandleError("GetRAUserCalendarInfo", rpa.Status, rpa.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("GetRAUserCalendarInfo", 0);
                    xResult.AppendXML(sRPACalInfoXML);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetRAUserCalendarInfo", 99999, ex,"");
            }
            return sReply;
        }


        public static string GetPortfolioItemList(HttpContext Context, string sXML, RPAData RAData)
        {
            string sReply = "";


            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioItems oPI = new PortfolioItems(basePath, username, ppmId, ppmCompany, ppmDbConn, false);
 
            try
            {
                string sPIDs = "";
                string sExts= "";
                string sxml = "";

                oPI.ObtainManagedPortfolioItems(out sExts, out sPIDs, out sxml);
                CStruct xResult = BuildResultXML("GetPortfolioItemList", 0);
                CStruct xData = xResult.CreateSubStruct("IDLists");
                xData.CreateStringAttr("EXTLIST",sExts );
                xData.CreateStringAttr("IDLIST", sPIDs);
                xData.AppendXML(sxml);

                sReply =  xResult.XML();

            }
            catch (Exception ex)
            {
                sReply = HandleException("GetPortfolioItemList", 99999, ex, "");
            }
            return sReply;
        }

        public static string GetGeneratedPortfolioItemTicket(HttpContext Context, string sXML, RPAData RAData)
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

                sReply =  xResult.XML();

            }
            catch (Exception ex)
            {
                sReply = HandleException("GetGeneratedPortfolioItemTicket", 99999, ex, "");
            }
            return sReply;
        }

        public static string RASessionPing(HttpContext Context, string sXML, RPAData RAData)
        {
            
            // this does nothing but help keep the data in the session live....
            return "";
        }

        public static string RALoadData(HttpContext Context, string sXML, RPAData RAData)
        {

            CStruct xRoot = new CStruct();
            string sReply = "";
            string sViews = "";
            string sTotal = "";
            string sDetails = "";
            string sDispMode = "";
            string sHeatmaptext = "";
            string sFromResGrid = "0";

            int ipopstart = 0;
            int ipopfin = 0;
            bool bNegMode = false;

            string sgpPMOAdmin = "";
            string sTicketResourcesXML = "";
            int iRawDataCount = 0;

            string sErrStage = "O010";

            xRoot.LoadXML(sXML);

            sErrStage = "O011";

            string sTicket = xRoot.GetStringAttr("Ticket");
            int CalID = xRoot.GetIntAttr("CalID");
            int StartID = xRoot.GetIntAttr("StartID");
            int FinishID = xRoot.GetIntAttr("FinishID");

            string sEchoReplyMessage = "";
            string sReplyMessage = "";


            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.ResourceAnalyzer rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);


            PortfolioEngineCore.CapacityScenarios rpcs = new CapacityScenarios(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            bool RoleBasedCSAllowed = rpcs.RoleBasedCSAllowed();

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            //PortfolioEngineCore.ResourceAnalyzer rpa = new PortfolioEngineCore.ResourceAnalyzer(sBaseInfo);
            try
            {
                if (rpa.SetResourceAnalyzerUserCalendarSettingsXML(CalID, StartID, FinishID) == false)
                {
                    sErrStage = "O012";
                    sReply = HandleError("RALoadData", rpa.Status, rpa.FormatErrorText());
                }
                else
                {

                    string sStage;
                    if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
                    {

                        string sDBConnect = WebAdmin.GetConnectionString(Context);
                        sErrStage = "O013";

                        PortfolioEngineCore.Capacity capacity = new PortfolioEngineCore.Capacity(sBaseInfo);
                        //                        string sDeptXML;
                        //                        capacity.SelectMyDepts(out sDeptXML);

                        // check if I can see ALL resources
                        sErrStage = "O014";
                        bool bSuperRM = capacity.GetSuperRM();
                        bool bSuperPM = capacity.GetSuperPM();
                        List<CStruct> listResources = null;
                        List<CStruct> listPIs = null;

                        if (sTicket.Contains("?") || sTicket == "") sTicket = "A6CD298B-BAB7-4459-99DD-05C0F7A3C3D3";  // a value I was putting into the dbs during testing...

                        sErrStage = "O020";
                        if ((StatusEnum)capacity.SelectResourcesFromTicket(sTicket, out sTicketResourcesXML, out sEchoReplyMessage) == StatusEnum.rsSuccess)
                        {
                            string sParmXML, sReplyXML;
                            CStruct xParms = new CStruct();
                            xParms.Initialize("Parms");
                            xParms.CreateInt("CalID", CalID);
                            xParms.CreateInt("StartPeriodID", StartID);
                            xParms.CreateInt("FinishPeriodID", FinishID);

                            // this code was used to set the Departments into the parameters when using SelectMyDepartments above - will it come back? not impossible
                            //CStruct xDepts = xParms.CreateSubStruct("Depts");
                            //CStruct xSelDepts = new CStruct();
                            //xSelDepts.LoadXML(sDeptXML);
                            //List<CStruct> listDepts = xSelDepts.GetList("Dept");
                            //foreach (CStruct xSelDept in listDepts)
                            //{
                            //    int lDeptID = xSelDept.GetIntAttr("ID");
                            //    string sDeptName = xSelDept.GetStringAttr("Name");

                            //    CStruct xDept = xDepts.CreateSubStruct("Dept");
                            //    xDept.CreateIntAttr("ID", lDeptID);
                            //    xDept.CreateStringAttr("Name", sDeptName);
                            //}

                            CStruct xSelItems = new CStruct();
                            sErrStage = "O021";
                            xSelItems.LoadXML(sTicketResourcesXML);
                            sErrStage = "O022";
                            listResources = xSelItems.GetList("Resource");
                            if (listResources.Count == 0) listPIs = xSelItems.GetList("PI");

                            if (listResources.Count > 0)
                            {
                                sErrStage = "O020a";
                                //  stuff all the resources I am allowed to manage into a Dictionary
                                Dictionary<int, int> dicMyResources = new Dictionary<int, int>();

                                sFromResGrid = "1";

                                if (bSuperRM == false)
                                {
                                    string sResourceXML;
                                    sErrStage = "O020b";
                                    capacity.SelectMyResources(out sResourceXML);
                                    CStruct xMyResources = new CStruct();
                                    sErrStage = "O020c";
                                    xMyResources.LoadXML(sResourceXML);
                                    sErrStage = "O020d";
                                    List<CStruct>  listMyResources = xMyResources.GetList("Resource");
                                    sErrStage = "O020e";
                                    foreach (CStruct xSelResource in listMyResources)
                                    {
                                        int lWResID = xSelResource.GetIntAttr("ID");
                                        dicMyResources.Add(lWResID, lWResID);
                                    }
                                }

                                sErrStage = "O023";
                                xParms.CreateInt("RequestNo", (int)ResCenterRequest.ResourceValuesForResources);
                                CStruct xResources = xParms.CreateSubStruct("Resources");

                                int lNumBlockedResources = 0;
                                foreach (CStruct xSelResource in listResources)
                                {
                                    int lWResID = xSelResource.GetIntAttr("ID");
                                    if (bSuperRM || dicMyResources.ContainsKey(lWResID))
                                    {
                                        CStruct xResource = xResources.CreateSubStruct("Resource");
                                        xResource.CreateIntAttr("ID", lWResID);
                                    }
                                    else
                                    {
                                        string sName = xSelResource.GetStringAttr("Name");
                                        if (lNumBlockedResources == 0) { sEchoReplyMessage += "\n" + "You do not have access to these resources: " + "\n" + sName; lNumBlockedResources = 1; }
                                        else if (lNumBlockedResources == 5) { sEchoReplyMessage += ",..."; lNumBlockedResources += 1; }
                                        else if (lNumBlockedResources < 5) { sEchoReplyMessage += "," + sName; lNumBlockedResources += 1; }
                                        else lNumBlockedResources += 1;
                                    }
                                }
                            }
                            else if (listPIs.Count > 0)
                            {
                                sErrStage = "O024";
                                Dictionary<int, int> dicMyProjects = new Dictionary<int, int>();
                                if (bSuperPM == false)
                                {
                                    string sProjectXML;
                                    sErrStage = "O024b";
                                    capacity.SelectMyProjects(out sProjectXML);
                                    CStruct xMyProjects = new CStruct();
                                    sErrStage = "O024c";
                                    xMyProjects.LoadXML(sProjectXML);
                                    sErrStage = "O024d";
                                    List<CStruct> listMyProjects = xMyProjects.GetList("Project");
                                    sErrStage = "O024e";
                                    foreach (CStruct xSelProject in listMyProjects)
                                    {
                                        int lProjID = xSelProject.GetIntAttr("ID");
                                        dicMyProjects.Add(lProjID, lProjID);
                                    }
                                }

                                sErrStage = "O024x";
                                xParms.CreateInt("RequestNo", (int)ResCenterRequest.ResourceValuesForPIs);
                                CStruct xPIs = xParms.CreateSubStruct("PIs");

                                int lNumBlockedProjects = 0;
                                foreach (CStruct xSelPI in listPIs)
                                {
                                    int lProjID = xSelPI.GetIntAttr("ID");
                                    if (bSuperPM || dicMyProjects.ContainsKey(lProjID))
                                    {
                                        CStruct xPI = xPIs.CreateSubStruct("PI");
                                        xPI.CreateIntAttr("ID", lProjID);
                                    }
                                    else
                                    {
                                        string sName = xSelPI.GetStringAttr("Name");
                                        if (lNumBlockedProjects == 0) { sEchoReplyMessage += "\n" + "You do not have access to these projects: " + "\n" + sName; lNumBlockedProjects = 1; }
                                        else if (lNumBlockedProjects == 5) { sEchoReplyMessage += ",..."; lNumBlockedProjects += 1; }
                                        else if (lNumBlockedProjects < 5) { sEchoReplyMessage += "," + sName; lNumBlockedProjects += 1; }
                                        else lNumBlockedProjects += 1;
                                    }
                                }
                            }


                            // *****    save parms (in case need when editing Capacity Scenarios within RPA)
                            CStruct xSaveParms = new CStruct();
                            xSaveParms.Initialize("Parms");
                            xSaveParms.CreateInt("CalID", CalID);
                            xSaveParms.CreateInt("StartPeriodID", StartID);
                            xSaveParms.CreateInt("FinishPeriodID", FinishID);

                            int lRequestNo = (int)ResCenterRequest.CapacityValues;
                            xSaveParms.CreateInt("RequestNo", lRequestNo);
                            // *****   save parms 

                            sParmXML = xParms.XML();

                            sErrStage = "O025";
                            if ((StatusEnum)capacity.GetRVInfo(sParmXML, out sReplyXML, out sReplyMessage) == StatusEnum.rsSuccess)
                            {


                                sErrStage = "O026";
                                if (sReplyMessage != "")
                                    sEchoReplyMessage += "\n" + sReplyMessage;

                                clsResourceValues resValues = new clsResourceValues();
                                bool bDoIt = false;
                                if (sReplyXML != "")
                                    bDoIt = resValues.LoadFromXML(sReplyXML);


                                if (bDoIt)
                                {

                                    sErrStage = "O027";
                                    RAData.GrabRAData(resValues, "", resValues.ResExamView, StartID, CalID, sParmXML, out sErrStage);

                                    string sModeXML = "";

                                    string sDepts = RAData.GetCSDeptUIDs();

                                    rpcs.GetCapacityScenariosXML(out sModeXML, RoleBasedCSAllowed, sDepts);
                                    CStruct xCSMode = new CStruct();
                                    xCSMode.LoadXML(sModeXML);


                                    RAData.StashCSRoleMode(RoleBasedCSAllowed);
                                    RAData.UpdateCSDataMode(xCSMode);

                                    sErrStage = "O028";
                                    sReply = RAData.GetTargetRGBData();

                                    sErrStage = "O029";
                                    if (rpa.GetResourceAnalyzerViewsXML(out sViews) == false)
                                    {
                                        sReply = HandleError("GetResourceValues", rpa.Status, rpa.FormatErrorText());
                                        sViews = "";
                                    }

                                    sErrStage = "O030";
                                    RAData.StashViews(sViews);
                                    sErrStage = "O031";
                                    RAData.StashCapacityReloadXML(xSaveParms.XML());

                                    sErrStage = "O032";
                                    sTotal = RAData.GetTotalsData(true);

                                    sErrStage = "O033";

                                    sDetails = RAData.GetDetailsData();

                                    sErrStage = "O034";
                                    sDispMode = RAData.GetDisplayMode();

                                    sErrStage = "O035";
                                    sgpPMOAdmin = RAData.GetPMOAdmin();
                                    sErrStage = "O036";
                                    iRawDataCount = RAData.GetRawDataCount();

                                    RAData.GetStartFinishDataPeriods(out ipopstart, out ipopfin);
                                    sHeatmaptext = RAData.GetHeatmapText();
                                    bNegMode = RAData.GetNegotiationMode();


                                }
                                else
                                    sReply = "<Error Value='Loading Data failed'/>";
                            }
                            else
                            {
                                sReply = "<Error Value = '" + sEchoReplyMessage + "\n" + sReplyMessage + "'/>";
                            }
                        }
                        else
                        {
                            sReply = "<Error Value='Failed to decode ticket - " + sEchoReplyMessage + "'/>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return HandleException("ResPlanAnalyzer.RALoadData at", 99999, ex, sErrStage);
            }

            //sReply = "<Error Value='GetResourceValues failed - " + sEchoReplyMessage + "'/>";  //  stuck here as a test
            
            CStruct xResult = BuildResultXML("GetTotalsColumnsConfiguration", 0);
            xResult.AppendXML(sReply);
            if (sViews != "")
                xResult.AppendXML(sViews);


            CStruct Extradata;
            Extradata = xResult.CreateSubStruct("TotalsConfiguration");
            Extradata.CreateStringAttr("Value", sTotal);
            Extradata.AppendXML(sTotal);
            Extradata = xResult.CreateSubStruct("DetailsConfiguration");
            Extradata.CreateStringAttr("Value", sDetails);
            Extradata.AppendXML(sDetails);

            Extradata = xResult.CreateSubStruct("FromResGrid");

            RAData.SetCalledFromResources(sFromResGrid == "1");
            Extradata.CreateStringAttr("Value", sFromResGrid);

            Extradata = xResult.CreateSubStruct("AllowCSResMode");
            Extradata.CreateIntAttr("Value", (RoleBasedCSAllowed ? 1 : 0));

            Extradata = xResult.CreateSubStruct("DisplayMode");
            Extradata.CreateStringAttr("Value", sDispMode);
            Extradata = xResult.CreateSubStruct("gpPMOAdmin");
            Extradata.CreateStringAttr("Value", sgpPMOAdmin);
            Extradata = xResult.CreateSubStruct("LoadingDataReply");
            Extradata.CreateStringAttr("Value", sEchoReplyMessage);
            Extradata = xResult.CreateSubStruct("TicketValue");
            Extradata.CreateStringAttr("Value", sTicket);
            Extradata = xResult.CreateSubStruct("TicketReturns");
            Extradata.CreateStringAttr("Value", sTicketResourcesXML);
            Extradata = xResult.CreateSubStruct("DetailsLoaded");
            Extradata.CreateIntAttr("Value", iRawDataCount);
            Extradata = xResult.CreateSubStruct("PeriodRange");
            Extradata.CreateIntAttr("Start", ipopstart);
            Extradata.CreateIntAttr("Finish", ipopfin);
            Extradata = xResult.CreateSubStruct("HeatMapText");
            Extradata.CreateStringAttr("Value", sHeatmaptext);
            Extradata = xResult.CreateSubStruct("NegMode");
            Extradata.CreateBooleanAttr("Value", bNegMode);
    
            return xResult.XML();
        }

        public static string GetRAWorkDetails(HttpContext Context, string sXML, RPAData RAData)
        {
            CStruct xResult = BuildResultXML("GetRAWorkDetails", 0);
            xResult.AppendXML(RAData.GetDetailsData());
            return xResult.XML();
        }

        public static string SetRAWorkDetails(HttpContext Context, string sXML, RPAData RAData)
        {
            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetRAWorkDetails", 99999, "Invalid request xml");
            }

            RAData.SetDetailsData(xData);

            return "";
        }

        public static string SetRAWorkDisplayMode(HttpContext Context, string sXML, RPAData RAData)
        {
            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetRAWorkModeDisplay", 99999, "Invalid request xml");
            }

            RAData.SetDisplayMode(xData);

            return "";
        }

        public static string GetResourceAnalyzerData(HttpContext Context, string sXML, RPAData RAData)
        {
            string s = RAData.GetTopGrid(sXML);
            return s;
        }

        public static string GetResourceAnalyzerTotals(HttpContext Context, string sXML, RPAData RAData)
        {
            string s = RAData.GetBottomGrid();
            return s;
        }
        public static string SetBottomDetailsDisplay(HttpContext Context, string sXML, RPAData RAData)
        {
            RAData.BottomDetailsDisplay(sXML);
            return "";
        }


        public static string GetTotalsColumnsConfiguration(HttpContext Context, string sXML, RPAData RAData)
        {

            CStruct xResult = BuildResultXML("GetTotalsColumnsConfiguration", 0);
            xResult.AppendXML(RAData.GetTotalsData(true));
            return xResult.XML(); 
        }

        public static string SetTotalsColumnsConfiguration(HttpContext Context, string sXML, RPAData RAData)
        {

            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetTotalsColumnsConfiguration", 99999, "Invalid request xml");
            }

            


            CStruct xResult = BuildResultXML("SetTotalsColumnsConfiguration", 0);
            xResult.AppendXML(RAData.SetTotalsData(xData));
            return xResult.XML();
       }

        public static string SetRADetailsSelectedFlag(HttpContext Context, string sXML, RPAData RAData)
        {

            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetRADetailsSelectedFlag", 99999, "Invalid request xml");
            }




            RAData.SetSelectedForRows(xData);
            return "";
       }

        public static string SetRATotalSelectedFlag(HttpContext Context, string sXML, RPAData RAData)
        {

            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetRATotalSelectedFlag", 99999, "Invalid request xml");
            }




            RAData.SetSelectedForTotals(xData);
            return "";
        }

        public static string SetRADragRows(HttpContext Context, string sXML, RPAData RAData)
        {

            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetRADragRows", 99999, "Invalid request xml");
            }




            RAData.SetRADragRows(xData);
            return "";
       }

        public static string UndoRADragRows(HttpContext Context, string sXML, RPAData RAData)
        {
            RAData.UndoRADragRows();
            return "";
        }


        public static string SetRADetailsFilteredFlag(HttpContext Context, string sXML, RPAData RAData)
        {

            CStruct xData = new CStruct();
            if (xData.LoadXML(sXML) == false)
            {
                return HandleError("SetRADetailsFilteredFlag", 99999, "Invalid request xml");
            }




            RAData.SetFilteredForRows(xData);
            return "";
        }

        public static string GetResourceAnalyzerViews(HttpContext Context, string sXML, RPAData RAData)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.ResourceAnalyzer rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
          //  string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
          //  PortfolioEngineCore.ResourceAnalyzer rpa = new PortfolioEngineCore.ResourceAnalyzer(sBaseInfo);
            try
            {
                string sViewsXML = "";
                if (rpa.GetResourceAnalyzerViewsXML(out sViewsXML) == false)
                {
                    sReply = HandleError("GetResourceAnalyzerViews", rpa.Status, rpa.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("GetResourceAnalyzerViews", 0);
                    xResult.AppendXML(sViewsXML);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetResourceAnalyzerViews", 99999, ex,"");
            }
            return sReply;
        }

        public static string GetResourceAnalyzerView(HttpContext Context, string sXML, RPAData RAData)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.ResourceAnalyzer rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            //PortfolioEngineCore.ResourceAnalyzer rpa = new PortfolioEngineCore.ResourceAnalyzer(sBaseInfo);
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("GetResourceAnalyzerView", 99999, "Invalid request xml");
                }

                Guid guidView = xExecute.GetGuid("ViewGUID");

                string sViewsXML;
                if (rpa.GetResourceAnalyzerViewXML(guidView, out sViewsXML) == false)
                {
                    sReply = HandleError("GetResourceAnalyzerView", rpa.Status, rpa.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("GetResourceAnalyzerView", 0);
                    xResult.AppendXML(sViewsXML);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetResourceAnalyzerViews", 99999, ex,"");
            }
            return sReply;
        }

        public static string SaveResourceAnalyzerView(HttpContext Context, string sXML, RPAData RAData)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.ResourceAnalyzer rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
           // PortfolioEngineCore.ResourceAnalyzer rpa = new PortfolioEngineCore.ResourceAnalyzer(sBaseInfo);
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("SaveResourceAnalyzerView", 99999, "Invalid request xml");
                }

                CStruct xView = xExecute.GetSubStruct("View");

                Guid guidView = xView.GetGuidAttr("ViewGUID");
                string sName = xView.GetStringAttr("Name");
                bool bPersonal = (xView.GetIntAttr("Personal") == 1) ? true : false;
                bool bDefault = (xView.GetIntAttr("Default") == 1) ? true : false;
                string sData = xView.XML(); ;

                if (rpa.SaveResourceAnalyzerViewXML(guidView, sName, bPersonal, bDefault, sData) == false)
                {
                    sReply = HandleError("SaveResourceAnalyzerView", rpa.Status, rpa.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("SaveResourceAnalyzerView", 0);
                    xResult.AppendSubStruct(xView);
                    sReply = xResult.XML();

                    string sViews = "";
                    if (rpa.GetResourceAnalyzerViewsXML(out sViews) == false)
                          sViews = "";
                     RAData.StashViews(sViews);


                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveResourceAnalyzerView", 99999, ex, "");
            }
            return sReply;
        }

        public static string DeleteResourceAnalyzerView(HttpContext Context, string sXML, RPAData RAData)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.ResourceAnalyzer rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
           // PortfolioEngineCore.ResourceAnalyzer rpa = new PortfolioEngineCore.ResourceAnalyzer(sBaseInfo);
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("DeleteResourceAnalyzerView", 99999, "Invalid request xml");
                }

                CStruct xView = xExecute.GetSubStruct("View");

                Guid guidView = xView.GetGuidAttr("ViewGUID");

                 if (rpa.DeleteResourceAnalyzerViewXML(guidView) == false)
                {
                    sReply = HandleError("DeleteResourceAnalyzerView", rpa.Status, rpa.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("DeleteResourceAnalyzerView", 0);
                    xResult.AppendSubStruct(xView);
                    sReply = xResult.XML();

                    string sViews = "";
                    if (rpa.GetResourceAnalyzerViewsXML(out sViews) == false)
                        sViews = "";
                    RAData.StashViews(sViews);
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("DeleteResourceAnalyzerView", 99999, ex, "");
            }
            return sReply;
        }

        public static string RenameResourceAnalyzerView(HttpContext Context, string sXML, RPAData RAData)
        {
            string sReply = "";

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.ResourceAnalyzer rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            //PortfolioEngineCore.ResourceAnalyzer rpa = new PortfolioEngineCore.ResourceAnalyzer(sBaseInfo);
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

                if (rpa.RenameResourceAnalyzerViewXML(guidView, sName) == false)
                {
                    sReply = HandleError("RenameResourceAnalyzerView", rpa.Status, rpa.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("RenameResourceAnalyzerView", 0);
                    xResult.AppendSubStruct(xView);
                    sReply = xResult.XML();

                    string sViews = "";
                    if (rpa.GetResourceAnalyzerViewsXML(out sViews) == false)
                        sViews = "";
                    RAData.StashViews(sViews);
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("RenameResourceAnalyzerView", 99999, ex, "");
            }
            return sReply;
        }


        public static string ApplyResourceAnalyzerViewServerSideSettings(HttpContext Context, string sXML, RPAData RAData)
        {
            CStruct xResult = BuildResultXML("ApplyResourceAnalyzerViewServerSideSettings", 0);
            xResult.AppendXML(RAData.ApplyServerSideViewSettings(sXML));
            return xResult.XML();
        }


        public static string GetCapacityScenarioList(HttpContext Context, string sXML, RPAData RAData)
        {

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.CapacityScenarios rpcs = new CapacityScenarios(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            //PortfolioEngineCore.CapacityScenarios rpcs = new PortfolioEngineCore.CapacityScenarios(sBaseInfo);     
            string sRetXML = "";

            string sDepts = RAData.GetCSDeptUIDs();
            rpcs.GetCapacityScenariosXML(out sRetXML, RAData.IsCSRoleAllowed(), sDepts);

            CStruct xResult = BuildResultXML("GetCapacityScenarioList", 0);
            xResult.AppendXML(sRetXML);
            xResult.AppendXML(RAData.GetCSDeptList());


            
            return xResult.XML();

        }


        public static string DeleteCapacityScenario(HttpContext Context, string sXML, RPAData RAData)
        {
            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.CapacityScenarios rpcs = new CapacityScenarios(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);            
            //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            //PortfolioEngineCore.CapacityScenarios rpcs = new PortfolioEngineCore.CapacityScenarios(sBaseInfo);     
            string sReply = "";

            try {

                int csid = int.Parse(sXML);

                rpcs.DeleteCapacityScenario(csid); 
                RAData.RemoveCapacityScenario(csid);


            }


            catch (Exception ex)
            {
                sReply = HandleException("DeleteCapacityScenario", 99999, ex, "");
            }

            return sReply;
          
   
        }

        public static string GetCapacityScenarioData(HttpContext Context, string sXML, RPAData RAData)
        {
            CStruct xResult;

            SPWeb spWeb = SPContext.Current.Web;

            using (var logger = new Logger(spWeb))
            {
                try
                {
                    logger.LogMessage("Location: ResPlanAnalyzer.asmx.cs --> GetCapacityScenarioData",
                        COMPONENT_NAME, LogKind.Info, "[DATA] sXML: " + sXML);

                    logger.LogMessage("Capturing PFE base info", COMPONENT_NAME, LogKind.Info);
                    WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn,
                        out securityLevel);

                    logger.LogMessage("Initializing Capacity Scenarios", COMPONENT_NAME, LogKind.Info);
                    var rpcs = new CapacityScenarios(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

                    //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                    //PortfolioEngineCore.CapacityScenarios rpcs = new PortfolioEngineCore.CapacityScenarios(sBaseInfo);

                    string sRetXml;
                    int statusnum;

                    var xExecute = new CStruct();
                    if (xExecute.LoadXML(sXML) == false)
                    {
                        logger.LogMessage("Invalid request XML", COMPONENT_NAME, LogKind.Warning);
                        return HandleError("GetCapacityScenarioData", 99999, "Invalid request xml");
                    }

                    int csid = xExecute.GetIntAttr("ID");
                    int csmode = xExecute.GetIntAttr("MODE");

                    if (rpcs.GetCapacityScenarioValuesXML(csid, out sRetXml, out statusnum) == false)
                    {
                        logger.LogMessage("Cannot get Capacity Scenario values", COMPONENT_NAME, LogKind.Warning,
                            string.Format(@"[DATA] StatusNum: {0}, Return XML: {1}", statusnum, sRetXml));

                        xResult = BuildResultXML("GetCapacityScenarioData", statusnum);
                        xResult.AppendXML(sRetXml);
                        return xResult.XML();
                    }

                    logger.LogMessage("Getting Capacity Scenario values was successful", COMPONENT_NAME, LogKind.Info);

                    xResult = BuildResultXML("GetCapacityScenarioData", 0);
                    xResult.AppendXML(RAData.PrepareCSGrid(sRetXml, csmode));

                    logger.LogMessage("Return XML prepared", COMPONENT_NAME, LogKind.Info);

                    return xResult.XML();
                }
                catch (Exception exception)
                {
                    logger.LogMessage(exception, COMPONENT_NAME);
                }

                xResult = BuildResultXML("GetCapacityScenarioData", -99);
                return xResult.XML();
            }
        }

        public static string GetCapacityScenarioEdit(HttpContext Context, string sXML, RPAData RAData)
        {
            string s = RAData.GetCapacityScenarioGrid();


            return s;
        }

        public static string GetLegendKey(HttpContext Context, string sXML, RPAData RAData)
        {
            string s = RAData.GetLegendGrid();


            return s;
        }


        

        public static string RPASaveDraggedData(HttpContext Context, string sXML, RPAData RAData)
        {
            string s = RAData.RPASaveDraggedData();

            if (s != "")
            {
                WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
                PortfolioEngineCore.ResourceAnalyzer rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
                //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                //PortfolioEngineCore.ResourceAnalyzer rpa = new PortfolioEngineCore.ResourceAnalyzer(sBaseInfo);
                rpa.SetResourceAnalyzerDraggedDataXML(s);
            }
            return "";
        }

        public static string SaveCapacityScenarioData(HttpContext Context, string sXML, RPAData RAData)
        {

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.CapacityScenarios rpcs = new CapacityScenarios(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            //PortfolioEngineCore.CapacityScenarios rpcs = new PortfolioEngineCore.CapacityScenarios(sBaseInfo);
            string sRetXML = "";
            int statusnum = 0;
            CStruct xResult;

            if (rpcs.SaveCapacityScenarioData(sXML, out sRetXML, out statusnum) == false)
            {
                xResult = BuildResultXML("SaveCapacityScenarioData", statusnum);
                xResult.AppendXML(sRetXML);
                return xResult.XML();

            }

            string sParmXML = RAData.GetCapacityReloadXML();
            string sReplyXML = "";
            string sReplyMessage = "";

            PortfolioEngineCore.Capacity capacity = new PortfolioEngineCore.Capacity(sBaseInfo);



            if ((StatusEnum)capacity.GetRVInfo(sParmXML, out sReplyXML, out sReplyMessage) == StatusEnum.rsSuccess)
            {

                clsResourceValues resValues = new clsResourceValues();
                bool bDoIt = false;

                if (sReplyXML != "")
                    bDoIt = resValues.LoadFromXML(sReplyXML);


                if (bDoIt)
                {
                    RAData.ReplaceCSData(resValues);

                    string sModeXML = "";

                    bool RoleBasedCSAllowed = RAData.IsCSRoleAllowed();

                    string sDepts = RAData.GetCSDeptUIDs();

                    rpcs.GetCapacityScenariosXML(out sModeXML, RoleBasedCSAllowed, sDepts);
                    CStruct xCSMode = new CStruct();
                    xCSMode.LoadXML(sModeXML);
                    RAData.UpdateCSDataMode(xCSMode);

                }
            }

            xResult = BuildResultXML("SaveCapacityScenarioData", 0);
            xResult.AppendXML(sRetXML);
            return xResult.XML();


        }


        private string ReloadPlanData(HttpContext Context, RPAData RAData)
        {

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn,
                                        out securityLevel);
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);          
            try
            {
                PortfolioEngineCore.Capacity capacity = new PortfolioEngineCore.Capacity(sBaseInfo);

                string sParmXML = RAData.GetInitialParamXML();
                string sReplyXML = "";
                string sReplyMessage = "";
                int StartID = 1;
                int CalID = 1;
                string sDispMode = RAData.GetDisplayMode();                
                
                capacity.GetRVInfo(sParmXML, out sReplyXML, out sReplyMessage);

                clsResourceValues resValues = new clsResourceValues();
                bool bDoIt = false;   

                if (sReplyXML != "")
                    bDoIt = resValues.LoadFromXML(sReplyXML);


                if (bDoIt)
                {
                    RPAData newRPA = new RPAData();

                    newRPA.GrabRAData(resValues, "", resValues.ResExamView, StartID, CalID, sParmXML, out sReplyMessage);

                    newRPA.SetCalledFromResources(RAData.GetCalledFromResources());

                    string setDispMode = SetRAWorkDisplayMode(this.Context, sDispMode, newRPA);

                    string rpkey = GetRPSessionKey();

                    SaveCachedData(Context, rpkey, newRPA);


//                    this.Context.Session[rpkey] = null;
                    RAData = newRPA;

//                    this.Context.Session[rpkey] = newRPA;
                   
                }


            }
            catch (Exception ex)
            {
                
            }

            return "";
        }
        
        
        public static string SaveCurrentToScenario (HttpContext Context, string sXML, RPAData RAData)
        {
            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.CapacityScenarios rpcs = new CapacityScenarios(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            //PortfolioEngineCore.CapacityScenarios rpcs = new PortfolioEngineCore.CapacityScenarios(sBaseInfo);
            string sRetXML = "";
            int statusnum;
            CStruct xResult;

            rpcs.GetCapacityScenarioValuesXML(1, out sRetXML, out statusnum);

            string sRoleData = RAData.GetRoleScrenarioData(sRetXML, sXML);

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);

            rpcs.SaveCurrentScenarioData(sXML, sRoleData);
 
            string sParmXML = RAData.GetCapacityReloadXML();
            string sReplyXML = "";
            string sReplyMessage = "";

            PortfolioEngineCore.Capacity capacity = new PortfolioEngineCore.Capacity(sBaseInfo);

            if ((StatusEnum)capacity.GetRVInfo(sParmXML, out sReplyXML, out sReplyMessage) == StatusEnum.rsSuccess)
            {

                clsResourceValues resValues = new clsResourceValues();
                bool bDoIt = false;

                if (sReplyXML != "")
                    bDoIt = resValues.LoadFromXML(sReplyXML);


                if (bDoIt)
                {
                    RAData.ReplaceCSData(resValues);

                    string sModeXML = "";
                    bool RoleBasedCSAllowed = RAData.IsCSRoleAllowed();

                    string sDepts = RAData.GetCSDeptUIDs();
                    rpcs.GetCapacityScenariosXML(out sModeXML, RoleBasedCSAllowed, sDepts);
                    CStruct xCSMode = new CStruct();
                    xCSMode.LoadXML(sModeXML);
                    RAData.UpdateCSDataMode(xCSMode);

                }
            }


            xResult = BuildResultXML("SaveCurrentToScenario", 0);
            return xResult.XML();

        }




        public static string SetAllCheckMarks(HttpContext Context, string sXML, RPAData RAData)
        {
            RAData.SetAllChecks(sXML != "0");

            return "";
        }


        public static string EditResPlanTicket(HttpContext Context, string sXML, RPAData RAData)
        {

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            PortfolioEngineCore.CapacityScenarios rpcs = new CapacityScenarios(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);
            //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            //PortfolioEngineCore.CapacityScenarios rpcs = new PortfolioEngineCore.CapacityScenarios(sBaseInfo);
            string sRetXML = "";



            string sPids = RAData.GetEditResPlanPIList();
            string sRids = RAData.GetEditResPlanResList();

            bool bFromRGrid = RAData.GetCalledFromResources();

            if (bFromRGrid == false && sPids != "")
            {

                sXML = rpcs.GetListTicket(sPids, true);
            }
            else if (bFromRGrid == true && sRids != "")
            {
                sXML = rpcs.GetListTicket(sRids, false);
            }

            //rpcs.GetCapacityScenarioValuesXML(1, out sRetXML, out statusnum);


            CStruct xResult = new CStruct();
            xResult = BuildResultXML("EditResPlanTicket", 0);
            xResult.AppendXML(RAData.GetEditResPlanTicket(sXML));
            return xResult.XML();


        }




        public static string GetTotalsGridChartData(HttpContext Context, string sXML, RPAData RAData)
        {


            CStruct xResult = new CStruct();
            xResult = BuildResultXML("GetTotalsGridChartData", 0);
            xResult.AppendXML(RAData.GetTotalsGridChartData());
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
            return HandleError(sContext, nStatus, "Exception in ResPlanAnalyzer.asmx (" + sStage + "): '" + ex.Message.ToString() + "'");

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


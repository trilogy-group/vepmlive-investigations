using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using EPMLiveCore.Infrastructure.Logging;
using ResourceValues;
using RPADataCache;
using System.Reflection;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using PortfolioEngineCore.PortfolioItems;
using System.Dynamic;
using System.Text;

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
        private const int CapacityValuesRequestNumber = (int)ResCenterRequest.CapacityValues;

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

        public static string RALoadData(HttpContext context, string xml, RPAData rpaData)
        {
            var root = new CStruct();
            dynamic data = null;
            
            root.LoadXML(xml);
            
            WebAdmin.CapturePFEBaseInfo(out basePath, 
                out username, 
                out ppmId, 
                out ppmCompany, 
                out ppmDbConn, 
                out securityLevel);
            var resourceAnalyzer = new ResourceAnalyzer(basePath, 
                username, 
                ppmId, 
                ppmCompany, 
                ppmDbConn, 
                securityLevel);
            var capacityScenario = new CapacityScenarios(basePath, 
                username, 
                ppmId, 
                ppmCompany, 
                ppmDbConn,
                securityLevel);

            var roleBasedCsAllowed = capacityScenario.RoleBasedCSAllowed();

            var buildBaseInfo = WebAdmin.BuildBaseInfo(context);
            try
            {
                data = PerformDataLoad(resourceAnalyzer, 
                    root, 
                    context, 
                    buildBaseInfo, 
                    rpaData, 
                    capacityScenario, 
                    roleBasedCsAllowed);
                if (data.Exception != null)
                {
                    throw (Exception)data.Exception;
                }
            }
            catch (Exception ex)
            {
                return HandleException("ResPlanAnalyzer.RALoadData at", 99999, ex, data.ErrorStage);
            }

            var result = SetExtraData(rpaData, roleBasedCsAllowed, data);

            return result.XML();
        }
        
        private static dynamic PerformDataLoad(ResourceAnalyzer resourceAnalyzer, 
            CStruct root, 
            HttpContext context, 
            string buildBaseInfo, 
            RPAData rpaData,
            CapacityScenarios capacityScenario,
            bool roleBasedCsAllowed)
        {
            dynamic data = new ExpandoObject();
            try
            {
                data.Exception = null;
                data.Reply = string.Empty;
                data.Views = string.Empty;
                data.Total = string.Empty;
                data.Details = string.Empty;
                data.DisplayMode = string.Empty;
                data.HeatMapText = string.Empty;
                data.PmoAdmin = string.Empty;
                data.TicketResourcesXml = string.Empty;
                data.EchoReplyMessage = string.Empty;
                data.FromResGrid = "0";
                data.NegotiationMode = false;
                data.RawDataCount = 0;
                data.Ticket = root.GetStringAttr("Ticket");
                data.CalId = root.GetIntAttr("CalID");
                data.StartId = root.GetIntAttr("StartID");
                data.FinishId = root.GetIntAttr("FinishID");
                data.ErrorStage = "O011";
                data.IpOperationStart = 0;
                data.IpOperationFin = 0;

                if (resourceAnalyzer.SetResourceAnalyzerUserCalendarSettingsXML(data.CalId, 
                        data.StartId, 
                        data.FinishId) == false)
                {
                    data.ErrorStage = "O012";
                    data.Reply = HandleError("RALoadData",
                        resourceAnalyzer.Status,
                        resourceAnalyzer.FormatErrorText());
                }
                else
                {
                    ProcessAnalyzerUserCalendarSettings(context, 
                        data, 
                        buildBaseInfo, 
                        capacityScenario, 
                        rpaData, 
                        roleBasedCsAllowed, 
                        resourceAnalyzer);
                }
            }
            catch (Exception ex)
            {
                data.Exception = ex;
            }

            return data;
        }
        
        private static void ProcessAnalyzerUserCalendarSettings(HttpContext context, 
            dynamic data, 
            string buildBaseInfo, 
            CapacityScenarios capacityScenario, 
            RPAData rpaData, 
            bool roleBasedCsAllowed, 
            ResourceAnalyzer resourceAnalyzer)
        {
            string stage;
            if (!WebAdmin.AuthenticateUserAndProduct(context, out stage))
            {
                return;
            }

            data.ErrorStage = "O013";

            var capacity = new Capacity(buildBaseInfo);

            // check if I can see ALL resources
            data.ErrorStage = "O014";
            var superRm = capacity.GetSuperRM();
            var superPm = capacity.GetSuperPM();
            List<CStruct> listPis = null;

            if (data.Ticket.Contains("?") || data.Ticket == string.Empty)
            {
                // a value I was putting into the dbs during testing...
                data.Ticket = "A6CD298B-BAB7-4459-99DD-05C0F7A3C3D3";
            }

            data.ErrorStage = "O020";
            string ticketResourcesXml, echoReplyMessage;
            var resourceStatus = (StatusEnum)capacity.SelectResourcesFromTicket(data.Ticket,
                out ticketResourcesXml,
                out echoReplyMessage);
            data.TicketResourcesXml = ticketResourcesXml;
            data.EchoReplyMessage = echoReplyMessage;
            if (resourceStatus == StatusEnum.rsSuccess)
            {
                var paramsStruct = new CStruct();
                paramsStruct.Initialize("Parms");
                paramsStruct.CreateInt("CalID", data.CalId);
                paramsStruct.CreateInt("StartPeriodID", data.StartId);
                paramsStruct.CreateInt("FinishPeriodID", data.FinishId);

                var selectedItem = new CStruct();
                data.ErrorStage = "O021";
                selectedItem.LoadXML(data.TicketResourcesXml);
                data.ErrorStage = "O022";
                var listResources = selectedItem.GetList("Resource");
                if (listResources.Count == 0) listPis = selectedItem.GetList("PI");

                if (listResources.Count > 0)
                {
                    ProcessResources(data, capacity, superRm, paramsStruct, listResources);
                }
                else if (listPis.Count > 0)
                {
                    ProcessListPis(data, listPis, capacity, paramsStruct, superPm);
                }
                
                // save params (in case need when editing Capacity Scenarios within RPA)
                SaveParams(data, 
                    paramsStruct, 
                    capacity, 
                    capacityScenario, 
                    roleBasedCsAllowed, 
                    resourceAnalyzer,
                    rpaData);
            }
            else
            {
                data.Reply = $"<Error Value='Failed to decode ticket - {data.EchoReplyMessage}'/>";
            }
        }
        
        private static void ProcessResources(dynamic data, Capacity capacity, bool superRm, CStruct paramsStruct, List<CStruct> listResources)
        {
            data.ErrorStage = "O020a";

            // stuff all the resources I am allowed to manage into a Dictionary
            var resourcesDictionary = new Dictionary<int, int>();
            var echoReplyMessage = new StringBuilder();

            data.FromResGrid = "1";

            if (superRm == false)
            {
                data.ErrorStage = "O020b";
                string resourceXml;
                capacity.SelectMyResources(out resourceXml);
                var xMyResources = new CStruct();
                data.ErrorStage = "O020c";
                xMyResources.LoadXML(resourceXml);
                data.ErrorStage = "O020d";
                var listMyResources = xMyResources.GetList("Resource");
                data.ErrorStage = "O020e";
                foreach (var selectedResource in listMyResources)
                {
                    var resourceId = selectedResource.GetIntAttr("ID");
                    resourcesDictionary.Add(resourceId, resourceId);
                }
            }

            data.ErrorStage = "O023";
            paramsStruct.CreateInt("RequestNo", (int)ResCenterRequest.ResourceValuesForResources);
            var resources = paramsStruct.CreateSubStruct("Resources");

            var blockedResourcesNumber = 0;
            foreach (var selectedResource in listResources)
            {
                var resourceId = selectedResource.GetIntAttr("ID");
                if (superRm || resourcesDictionary.ContainsKey(resourceId))
                {
                    var resource = resources.CreateSubStruct("Resource");
                    resource.CreateIntAttr("ID", resourceId);
                }
                else
                {
                    var name = selectedResource.GetStringAttr("Name");
                    if (blockedResourcesNumber != 0)
                    {
                        if (blockedResourcesNumber == 5)
                        {
                            echoReplyMessage.Append(",...");
                            blockedResourcesNumber += 1;
                        }
                        else if (blockedResourcesNumber < 5)
                        {
                            echoReplyMessage.Append($",{name}");
                            blockedResourcesNumber += 1;
                        }
                        else blockedResourcesNumber += 1;
                    }
                    else
                    {
                        echoReplyMessage.Append($"\nYou do not have access to these resources: \n{name}");
                        blockedResourcesNumber = 1;
                    }
                }
            }

            data.EchoReplyMessage += echoReplyMessage.ToString();
        }

        private static void SaveParams(dynamic data, 
            CStruct paramsStruct, 
            Capacity capacity, 
            CapacityScenarios capacityScenario, 
            bool roleBasedCsAllowed, 
            ResourceAnalyzer resourceAnalyzer,
            RPAData rpaData)
        {
            var saveParams = new CStruct();
            saveParams.Initialize("Parms");
            saveParams.CreateInt("CalID", data.CalId);
            saveParams.CreateInt("StartPeriodID", data.StartId);
            saveParams.CreateInt("FinishPeriodID", data.FinishId);

            saveParams.CreateInt("RequestNo", CapacityValuesRequestNumber);

            // save params
            var paramXml = paramsStruct.XML();

            data.ErrorStage = "O025";
            string replyMessage;
            string replyXml;
            if ((StatusEnum)capacity.GetRVInfo(paramXml,
                    out replyXml,
                    out replyMessage) == StatusEnum.rsSuccess)
            {
                data.ErrorStage = "O026";
                if (replyMessage != "")
                {
                    data.EchoReplyMessage += $"\n{replyMessage}";
                }

                var resourceValues = new clsResourceValues();
                var replyXmlLoaded = false;
                if (replyXml != "")
                {
                    replyXmlLoaded = resourceValues.LoadFromXML(replyXml);
                }

                if (replyXmlLoaded)
                {
                    SetReplyXmlLoadedData(data, 
                        rpaData, 
                        resourceValues, 
                        paramXml,
                        capacityScenario, 
                        roleBasedCsAllowed, 
                        resourceAnalyzer, 
                        saveParams);
                }
                else
                {
                    data.Reply = "<Error Value='Loading Data failed'/>";
                }
            }
            else
            {
                data.Reply = $"<Error Value = '{data.EchoReplyMessage}\n{replyMessage}'/>";
            }
        }

        private static void ProcessListPis(dynamic data, 
            IEnumerable<CStruct> listPis, 
            Capacity capacity, CStruct paramsStruct, bool superPm)
        {
            data.ErrorStage = "O024";
            var dicMyProjects = new Dictionary<int, int>();
            if (superPm == false)
            {
                string projectXml;
                data.ErrorStage = "O024b";
                capacity.SelectMyProjects(out projectXml);
                var myProjects = new CStruct();
                data.ErrorStage = "O024c";
                myProjects.LoadXML(projectXml);
                data.ErrorStage = "O024d";
                var listMyProjects = myProjects.GetList("Project");
                data.ErrorStage = "O024e";
                foreach (var selectedProject in listMyProjects)
                {
                    var projectId = selectedProject.GetIntAttr("ID");
                    dicMyProjects.Add(projectId, projectId);
                }
            }

            data.ErrorStage = "O024x";
            paramsStruct.CreateInt("RequestNo", (int)ResCenterRequest.ResourceValuesForPIs);
            var pis = paramsStruct.CreateSubStruct("PIs");

            var lNumBlockedProjects = 0;
            var echoReplyMessage = new StringBuilder();
            foreach (var selectedPi in listPis)
            {
                var projectId = selectedPi.GetIntAttr("ID");
                if (superPm || dicMyProjects.ContainsKey(projectId))
                {
                    var pi = pis.CreateSubStruct("PI");
                    pi.CreateIntAttr("ID", projectId);
                }
                else
                {
                    var sName = selectedPi.GetStringAttr("Name");
                    if (lNumBlockedProjects != 0)
                    {
                        if (lNumBlockedProjects == 5)
                        {
                            echoReplyMessage.Append(",...");
                            lNumBlockedProjects += 1;
                        }
                        else if (lNumBlockedProjects < 5)
                        {
                            echoReplyMessage.Append($",{sName}");
                            lNumBlockedProjects += 1;
                        }
                        else lNumBlockedProjects += 1;
                    }
                    else
                    {
                        echoReplyMessage.Append($"\nYou do not have access to these projects: \n{sName}");
                        lNumBlockedProjects = 1;
                    }
                }
            }

            data.EchoReplyMessage += echoReplyMessage.ToString();
        }

        private static void SetReplyXmlLoadedData(dynamic data, 
            RPAData rpaData, 
            clsResourceValues resourceValues, 
            string paramXml, 
            CapacityScenarios capacityScenario,
            bool roleBasedCsAllowed,
            ResourceAnalyzer resourceAnalyzer,
            CStruct saveParams)
        {
            data.ErrorStage = "O027";
            string errorStage;
            rpaData.GrabRAData(resourceValues,
                string.Empty,
                resourceValues.ResExamView,
                data.StartId,
                data.CalId,
                paramXml,
                out errorStage);
            data.ErrorStage = errorStage;
            string modeXml;

            var departmentIds = rpaData.GetCSDeptUIDs();

            capacityScenario.GetCapacityScenariosXML(out modeXml,
                roleBasedCsAllowed,
                departmentIds);

            var csMode = new CStruct();
            csMode.LoadXML(modeXml);

            rpaData.StashCSRoleMode(roleBasedCsAllowed);
            rpaData.UpdateCSDataMode(csMode);

            data.ErrorStage = "O028";
            data.Reply = rpaData.GetTargetRGBData();

            data.ErrorStage = "O029";
            string views;
            if (resourceAnalyzer.GetResourceAnalyzerViewsXML(out views) == false)
            {
                data.Reply = HandleError("GetResourceValues",
                    resourceAnalyzer.Status,
                    resourceAnalyzer.FormatErrorText());
                views = string.Empty;
            }

            data.Views = views;
            data.ErrorStage = "O030";
            rpaData.StashViews(data.Views);
            data.ErrorStage = "O031";
            rpaData.StashCapacityReloadXML(saveParams.XML());

            data.ErrorStage = "O032";
            data.Total = rpaData.GetTotalsData(true);

            data.ErrorStage = "O033";

            data.Details = rpaData.GetDetailsData();

            data.ErrorStage = "O034";
            data.DisplayMode = rpaData.GetDisplayMode();

            data.ErrorStage = "O035";
            data.PmoAdmin = rpaData.GetPMOAdmin();
            data.ErrorStage = "O036";
            data.RawDataCount = rpaData.GetRawDataCount();

            int ipOperationStart;
            int ipOperationFin;
            rpaData.GetStartFinishDataPeriods(out ipOperationStart, out ipOperationFin);
            data.IpOperationStart = ipOperationStart;
            data.IpOperationFin = ipOperationFin;
            data.HeatMapText = rpaData.GetHeatmapText();
            data.NegotiationMode = rpaData.GetNegotiationMode();
        }

        private static CStruct SetExtraData(RPAData rpaData,
            bool roleBasedCsAllowed, 
            dynamic data)
        {
            var result = BuildResultXML("GetTotalsColumnsConfiguration", 0);
            result.AppendXML(data.Reply);
            if (data.Views != string.Empty)
            {
                result.AppendXML(data.Views);
            }

            var extraData = result.CreateSubStruct("TotalsConfiguration");
            extraData.CreateStringAttr("Value", data.Total);
            extraData.AppendXML(data.Total);
            extraData = result.CreateSubStruct("DetailsConfiguration");
            extraData.CreateStringAttr("Value", data.Details);
            extraData.AppendXML(data.Details);

            extraData = result.CreateSubStruct("FromResGrid");

            rpaData.SetCalledFromResources(data.FromResGrid == "1");
            extraData.CreateStringAttr("Value", data.FromResGrid);

            extraData = result.CreateSubStruct("AllowCSResMode");
            extraData.CreateIntAttr("Value", (roleBasedCsAllowed ? 1 : 0));

            extraData = result.CreateSubStruct("DisplayMode");
            extraData.CreateStringAttr("Value", data.DisplayMode);
            extraData = result.CreateSubStruct("gpPMOAdmin");
            extraData.CreateStringAttr("Value", data.PmoAdmin);
            extraData = result.CreateSubStruct("LoadingDataReply");
            extraData.CreateStringAttr("Value", data.EchoReplyMessage);
            extraData = result.CreateSubStruct("TicketValue");
            extraData.CreateStringAttr("Value", data.Ticket);
            extraData = result.CreateSubStruct("TicketReturns");
            extraData.CreateStringAttr("Value", data.TicketResourcesXml);
            extraData = result.CreateSubStruct("DetailsLoaded");
            extraData.CreateIntAttr("Value", data.RawDataCount);
            extraData = result.CreateSubStruct("PeriodRange");
            extraData.CreateIntAttr("Start", data.IpOperationStart);
            extraData.CreateIntAttr("Finish", data.IpOperationFin);
            extraData = result.CreateSubStruct("HeatMapText");
            extraData.CreateStringAttr("Value", data.HeatMapText);
            extraData = result.CreateSubStruct("NegMode");
            extraData.CreateBooleanAttr("Value", data.NegotiationMode);

            return result;
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


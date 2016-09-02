using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Globalization;
using System.Xml;
using System.Security.Principal;
using Microsoft.SharePoint;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ModelDataCache;
using System.Data.SqlClient;
using EPMLiveCore;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using PortfolioEngineCore.Analyzers;
using Microsoft.Win32;
using PortfolioEngineCore.PortfolioItems;


namespace WorkEnginePPM
{

    //enum GlobalPermissionsEnum
    //{
    //    gpToday = 3001,       // EPK B01 Home, Delegate,
    //    gpUserAdmin = 3002,   // EPK A04 Manage Status Date and Non-Work Items,
    //    gpDBA = 3003,         // EPK A06 DBA Utilities,
    //    gpTimesheet = 3004,   // EPK T01 Timesheet and Plan Non-working time,
    //    //gpTaskStatus = 3005,  // EPK T02 Progressor  - requires T02 - NOT USED
    //    gpTSDeptApproval = 3006,      // EPK T03 Department Timesheet Approval,
    //    gpTSProjApproval = 3007,      // EPK T04 Project Timesheet Approval,
    //    gpTSOverview = 3008,  // EPK A02 Timesheet App Admin,
    //    gpTSAdmin = 3009,     // EPK A01 Base and Timesheet SysAdmin,
    //    gpPortCenter = 3010,  // EPK P01 View Portfolio,
    //    gpPortfolio = 3011,   // EPK P02 View Portfolio Item Details,
    //    gpEditPI = 3012,      // EPK P03 Edit Portfolio Item,
    //    gpCreatePI = 3013,    // EPK P04 Create Portfolio Item,
    //    gpEditCostType = 3014,        // EPK P05 Edit Cost - requires P03,
    //    gpEditStage = 3015,   // EPK P06 Edit Stage - requires P03,
    //    gpManageWSS = 3016,   // EPK P07 Manage WSS Site,
    //    gpPublishPI = 3017,   // EPK P08 Publish Portfolio Item,
    //    gpWorkItems = 3018,   // EPK P09 Work Items - requires P03,
    //    gpEditSecurity = 3019,        // EPK P10 Edit Security - requires P03,
    //    gpClosePI = 3020,     // EPK P11 Close Portfolio Item,
    //    gpBudgetAnalyzer = 3021,      // EPK P12 Save Changes made in Modeler,
    //    gpProjectVerCenter = 3022,    // EPK P13 CT Analyzer,
    //    gpProjectVersions = 3023,     // EPK P21 View Project Details,
    //    gpProjectsTab = 3024,         // EPK P22 Create/Link Projects,
    //    gpPortAdmin = 3025,   // EPK A03 Portfolio and Capacity SysAdmin,
    //    gpResourcePlan = 3026,        // EPK C02 Edit Resource Plan,
    //    gpCommitments = 3027,         // EPK C01 View Resource Plans,
    //    gpCapCenter = 3028,   // EPK R01 Resource Center,
    //    gpUserBtn1 = 3029,    // EPK U01 User Button 1,
    //    gpUserBtn2 = 3030,    // EPK U02 User Button 2,
    //    gpUserBtn3 = 3031,    // EPK U03 User Button 3,
    //    gpUserBtn4 = 3032,    // EPK U04 User Button 4,
    //    gpUserBtn5 = 3033,    // EPK U05 User Button 5,
    //    gpUserBtn6 = 3034,    // EPK U06 User Button 6,
    //    gpUserBtn7 = 3035,    // EPK U07 User Button 7,
    //    gpUserBtn8 = 3036,    // EPK U08 User Button 8,
    //    gpUserBtn9 = 3037,    // EPK U09 User Button 9,
    //    gpUserBtn10 = 3038,   // EPK U10 User Button 10,
    //    gpSuperPIM = 3040,    // EPK C03 Edit Res Plans for All Portfolio Items,
    //    gpSuperRM = 3041,     // EPK C04 Edit Res Plans for All Departments,
    //    gpPMOAdmin = 3042,    // EPK A05 PMO App Admin,
    //    gpResDept = 3043,     // EPK C05 Resource Plans Analyzer,
    //    gpEVUser = 3044      // EPK E01 Earned Value User,
    //}
 
    
    /// <summary>
    /// Summary description for EditCosts
    /// </summary>
    [WebService(Namespace = "WorkEnginePPM")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Model : System.Web.Services.WebService
    {

        private static string basePath;
        private static string ppmId;
        private static string ppmCompany;
        private static string ppmDbConn;
        private static string username;
        private static SecurityLevels securityLevel;

        [WebMethod(EnableSession = true)]
        public string Execute(string Ticket, string Function, string Dataxml)
        {
            string sStage;

            ModelCache ModelData;

            if ((Function != "GetPortfolioItemList") && (Function != "GetGeneratedPortfolioItemTicket"))
                ModelData = (ModelCache)GetCachedData(this.Context, Ticket);
            else
                ModelData = new ModelCache();

            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {
                try
                {
                    Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                    Type thisClass = assemblyInstance.GetType("WorkEnginePPM.Model", true, true);
                    MethodInfo m = thisClass.GetMethod(Function);
                    object result = m.Invoke(null, new object[] { this.Context, Dataxml, ModelData });

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    return HandleError("Execute", 99999, string.Format("Error executing function: {0}", ex.Message));
                }

                if ((Function != "GetPortfolioItemList") && (Function != "GetGeneratedPortfolioItemTicket")) 
                    SaveCachedData(this.Context, Ticket, ModelData);
            }
            else
                return HandleError("Execute", 99999, string.Format("PfE User Authentication Failed. Stage: {0}", sStage));
        }

        [WebMethod(EnableSession = true)]
        public string ExecuteJSON(string Ticket, string Function, string Dataxml)
        {
            string sReply = "";
            //string ids = "";
            try
            {
                sReply = Execute(Ticket, Function, Dataxml);
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


        public static string GetPortfolioItemList(HttpContext Context, string sXML, ModelCache ModelData)
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
                sReply = HandleError("GetPortfolioItemList", 99999, string.Format("Error executing function: {0}", ex.Message));
            }
            return sReply;
        }

        public static string GetGeneratedPortfolioItemTicket(HttpContext Context, string sXML, ModelCache ModelData)
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
                sReply = HandleError("GetGeneratedPortfolioItemTicket", 99999, string.Format("Error executing function: {0}", ex.Message));
            }
            return sReply;
        }

        public static string GetTopGrid(HttpContext Context, string sXML, ModelCache ModelData)
        {
            return ModelData.GetTopGrid();
        }
        public static string GetBottomGrid(HttpContext Context, string sXML, ModelCache ModelData)
        {
            return ModelData.GetBottomGrid();
        }

        public static string GetFTEMode(HttpContext Context, string sXML, ModelCache ModelData)
        {
            CStruct xResult = BuildResultXML("GetFTEMode", 0);
            CStruct xMode = xResult.CreateSubStruct("Mode");
            xMode.CreateIntAttr("Value", ModelData.GetFTEMode());
            return xResult.XML(); 
        }

        /// <summary>
        /// Builds xml to drive the layout of the CostType grid
        /// </summary>
        /// <param name="sTicket"></param>
        /// <param name="sModel"></param>
        /// <param name="sVersions"></param>
        /// <param name="sViewID"></param>
        /// <returns>XML formatted string</returns>
        [WebMethod(EnableSession = true)]
        public string LoadModelData(string sTicket, string sModel, string sVersions, string sViewID)
        {

            bool bpermallow = false;


            try
            {


                if (sTicket == "")
                    sTicket = "ebe45859-43b7-4e4c-a5df-4615b14904ed";

                if (sModel == "")
                    sModel = "1";


                if (sVersions == "")
                    sVersions = "0";


                string sStage;
                if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
                {

                    string sDBConnect = WebAdmin.GetConnectionString(this.Context);


                    int lw;

                    SqlConnection conn = ObtainSqlConnection(out lw);
                        
                        ModelCache ModelData = null;

                        GlobalPermissionsEnum perm = GlobalPermissionsEnum.gpBudgetAnalyzer;

                        if (sViewID != "")
                            perm = GlobalPermissionsEnum.gpProjectVerCenter;

                        if (CheckUserGlobalPermission(conn, lw, perm) == true)
                             bpermallow = true;


                        if (ModelData == null)
                        {
 
                            ModelData = new ModelCache();
                            ModelData.InitalLoadData(conn, sTicket, sModel, sVersions, lw.ToString(), sViewID);

                        }
                        else
                            ModelData.InitalLoadData(conn, sTicket, sModel, sVersions, lw.ToString(), sViewID);


                        SaveCachedData(Context, sTicket, ModelData);

                }

                if (bpermallow == false)
                    return "***PermsisionsCheck***";
                return "";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Informs backend to unselect a row
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="Row"></param>
        /// <returns>void</returns>
        [WebMethod(EnableSession = true)]
        public void DoTopGridCheck(string Ticket, string Row)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.SetSelectedForRow(Row);
            SaveCachedData(this.Context, Ticket, ModelData);
            return;
        }


        
      /// <summary>
        /// Informs backend to move a bar
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="Row"></param>
        /// <param name="StartDate"></param>
        /// <param name="FinishDate"></param>
        /// <returns>void</returns>
        [WebMethod(EnableSession = true)]
        public ModelBarsChanged DoBarMoved(string Ticket, string Row, string sStart, string sFinish)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelBarsChanged retData = new ModelBarsChanged();

            ModelData.DoBarMove(Row, sStart, sFinish, ref retData);
            SaveCachedData(this.Context, Ticket, ModelData);
            return retData;

         }


        /// <summary>
        /// Informs backend to copy a version to->from for PIs
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="SFrom"></param>
        /// <param name="sTo"></param>
        /// <param name="sPIs"></param>
        /// <returns>void</returns>
        [WebMethod(EnableSession = true)]
        public void DoCopyVersion(string Ticket, string sFrom, string sTo, string sPIs)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);
            ModelData.DoCopyVersion(sFrom, sTo, sPIs);
            SaveCachedData(this.Context, Ticket, ModelData);
            return;

        }

        /// <summary>
        /// Informs backend to Load a version
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="sLoad"></param>
        /// <returns>void</returns>
        [WebMethod(EnableSession = true)]
        public void DoLoadVersion(string Ticket, string sLoad)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
 
                ModelData.LoadScenarioData(conn, sLoad);
 
            }


            SaveCachedData(this.Context, Ticket, ModelData);

            return;

        }

        /// <summary>
        /// Informs backend to Load and apply Target
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="sTarget"></param>
        /// <returns>void</returns>
        [WebMethod(EnableSession = true)]
        public void DoLoadTarget(string Ticket, string sTarget)
        {


            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);


            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);

                ModelData.LoadTargetData(conn, sTarget);
 
            }


            SaveCachedData(this.Context, Ticket, ModelData);

            return;

        }


        /// <summary>
        /// Builds xml to drive the layout of the top details grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>XML formatted string</returns>
        [WebMethod(EnableSession = true)]
        public string GetTopGridLayout(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetTopGridLayout();
        }
 
            
         /// <summary>
        /// Builds XML to populate the Model Top Grid 
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetTopGridData(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetTopGridData();
        }
      /// <summary>
        /// Builds xml to drive the layout of the CostType grid
        /// </summary>
        /// <param name="ForGrid"></param>
        /// <param name="Ticket"></param>
        /// <returns>XML formatted string</returns>
        [WebMethod(EnableSession = true)]
        public string GetBottomGridLayout(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetBottomGridLayout();
        }

        /// <summary>
        /// Builds XML to populate the CostType grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetBottomGridData(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetBottomGridData();
 
         }

        /// <summary>
        /// Builds XML to populate the CostType grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="FTEMode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void DoShowFTEs(string Ticket, int FTEMode)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.SetFTEMode(FTEMode);

            SaveCachedData(this.Context, Ticket, ModelData);

            return;   // ModelData.GetBottomGridData();

        }

        /// <summary>
        /// Ping the session data
        /// </summary>
        /// <param name="Ticket"></param>
         /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void DoPingSession(string Ticket)
        {

  
            return;   // ModelData.GetBottomGridData();

        }

        /// <summary>
        /// Builds XML to populate the CostType grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="GanttMode"></param>
        /// <returns>int</returns>
        [WebMethod(EnableSession = true)]
        public int DoShowGantt(string Ticket, int GanttMode)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);
            int gm =  ModelData.SetGanttMode(GanttMode);
            SaveCachedData(this.Context, Ticket, ModelData);

            return gm;

        }

        /// <summary>
        /// Sets the PI grouping flag
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="GroupMode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void DoSetGroupingFlag(string Ticket, int GroupMode)
        {


            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.DoSetGroupingFlag(GroupMode);
            SaveCachedData(this.Context, Ticket, ModelData);
            return;


        }


        

        /// <summary>
        /// Gets list of available models
        /// </summary>
         /// <returns>List of Models</returns>
        [WebMethod(EnableSession = true)]
        public List<ItemDefn> GetModels()
        {

            List<ItemDefn> models = new List<ItemDefn>();
            string sStage;
            ItemDefn mdl = null;

           if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {
                
                string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);

                bool bpermallow = false;
                //int lw = vb.val(WebAdmin.GetSPSessionString(Context, "WResID"));

                GlobalPermissionsEnum perm = GlobalPermissionsEnum.gpBudgetAnalyzer;

                if (CheckUserGlobalPermission(conn, lw, perm) == true)
                        bpermallow = true;


                if (bpermallow == false)
                {

                    mdl = new ItemDefn();
                    mdl.Id = 0;
                    mdl.Name = "***PermsisionsCheck***";
                    models.Add(mdl);
                }
                else
                {


                    string cmdText = "SELECT MODEL_UID, MODEL_NAME FROM EPGP_MODEL_SCENARIOS ORDER BY MODEL_NAME";

                    SqlCommand oCommand = new SqlCommand(cmdText, conn);
                    SqlDataReader reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        mdl = new ItemDefn();
                        mdl.Id = DBAccess.ReadIntValue(reader["MODEL_UID"]);
                        mdl.Name = DBAccess.ReadStringValue(reader["MODEL_NAME"]);
                        mdl.Deflt = 0;
                        models.Add(mdl);
                    }
                    reader.Close();

                }

            }
            return models;

        }

        

        /// <summary>
        /// Gets list of available versions for this model
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns>List of Models</returns>
        [WebMethod(EnableSession = true)]
        public List<ItemDefn> LoadSelectVersions(int modelID)
        {

            List<ItemDefn> vers = new List<ItemDefn>();
            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {
                string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                //DataTable dt;
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
                ModelCache ModelData = new ModelCache();

                ModelData.ReadModelNames(modelID.ToString(), lw.ToString(), conn, ref vers);


            }
            return vers;

        }

        private static string HandleError(string sError, int nstatus, string sContext)
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("Reply");
            xReply.CreateString("HRESULT", "0");
            xReply.CreateInt("STATUS", nstatus);
            xReply.CreateString("Error", "WebService.asmx Context=" + sContext + "; Error=" + sError + ";");

            return xReply.XML();
        }

        private static string HandleException(Exception ex, string sContext)
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("Reply");
            xReply.CreateString("HRESULT", "0");
            xReply.CreateString("STATUS", "9111");
            xReply.CreateString("Error", "WebService.asmx Context=" + sContext + "; Exception=" + ex.Message.ToString() + ";");

            return xReply.XML();
        }

        /// <summary>
        /// Builds xml to drive the layout of the top details grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>XML formatted string</returns>
        [WebMethod(EnableSession = true)]
        public string GetFilterGridLayout(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetFilterGridLayout();
        }


        /// <summary>
        /// Builds XML to populate the Model Top Grid 
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetFilterGridData(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetFilterGridData();
        }

       /// <summary>
        /// Set the filter data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="filterData"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void SetFilterData(string Ticket, string sfilterData)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            string sVer = ModelData.SetFilterData(sfilterData);

            if (sVer != "")
            {

                string sStage;
                if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
                {

                    string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                    int lw; 
                    SqlConnection conn = ObtainSqlConnection(out lw);

                    ModelData.LoadScenarioData(conn, sVer);
                }

            }

            ModelData.ProcessAndCreateDistplayLists();
            SaveCachedData(this.Context, Ticket, ModelData);
            return;
        }

        /// <summary>
        /// Builds xml to drive the layout of the top TotalsOption grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>XML formatted string</returns>
        [WebMethod(EnableSession = true)]
        public string GetTotalGridLayout(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetTotalGridLayout();
        }


        /// <summary>
        /// Builds XML to populate the TotalsOption grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetTotalGridData(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetTotalGridData();
        }

        /// <summary>
        /// Builds XML to populate the Compare Cost Types grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetCostTypeCompareGridData(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetCTCmpGridData();
        }

        /// <summary>
        /// Set the total data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="CTCmpData"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void SetCostTypeCompareData(string Ticket, string sCTCmpData)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.SetCTCmpData(sCTCmpData);


            ModelData.ProcessAndCreateDistplayLists();
            SaveCachedData(this.Context, Ticket, ModelData);
            return;
        }

        /// <summary>
        /// Builds XML to populate the TotalsOption grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetColumnGridData(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetColumnGridData();
        }

        /// <summary>
        /// Set the total data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="totalData"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void SetTotalData(string Ticket, string sTotalData)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.SetTotalData(sTotalData);


            ModelData.ProcessAndCreateDistplayLists();
            SaveCachedData(this.Context, Ticket, ModelData);
            return;
        }

        /// <summary>
        /// Get the sort and group data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>SortGroupDefn</returns>
        [WebMethod(EnableSession = true)]
        public SortGroupDefn GetSortAndGroup(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            SortGroupDefn sng = new SortGroupDefn();

            ModelData.GetSortAndGroup(ref sng);
            SaveCachedData(this.Context, Ticket, ModelData);

            return sng;
        }

        /// <summary>
        /// Set the sort and group data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="SortGroupDefn"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void SetSortAndGroup(string Ticket, SortGroupDefn SnG)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.SetSortAndGroup(SnG);
            SaveCachedData(this.Context, Ticket, ModelData);
            return;
        }

        /// <summary>
        /// Get thecolumn order data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>SortGroupDefn</returns>
        [WebMethod(EnableSession = true)]
        public SortGroupDefn GetColumnOrderData(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            SortGroupDefn sng = new SortGroupDefn();

            ModelData.GetColumnData(ref sng);

            return sng;
        }

        
        /// <summary>
        /// Set the Column order data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="SortGroupDefn"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void SetColumnOrder(string Ticket, SortGroupDefn SnG)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.SetColumnOrderData(SnG);
            SaveCachedData(this.Context, Ticket, ModelData);
            return;
        }

        
         /// <summary>
        /// Set the Column order data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="FromVer"></param>
        /// <param name="ToVer"></param>
        /// <returns>lists of PIs</returns>
        [WebMethod(EnableSession = true)]
        public SortGroupDefn LoadCopyVersionPILists(string Ticket, int fromVer, int toVer)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            SortGroupDefn sng = new SortGroupDefn();

            ModelData.GetVersionsPILists(ref sng, fromVer, toVer);

            return sng;
        }

        /// <summary>
        /// Gets list of available versions to save
        /// </summary>
        /// <returns>List of Loaded/Copied versions</returns>
        [WebMethod(EnableSession = true)]
        public List<ItemDefn> GetSaveVersions(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            List<ItemDefn> versions = new List<ItemDefn>();

            ModelData.GetSaveVersions(ref versions);
            return versions;

        }

       /// <summary>
        /// Gets list of available versions to save
        /// </summary>
        /// <returns>List of Loaded/Copied versions</returns>
        [WebMethod(EnableSession = true)]
        public List<ItemDefn> GetTargetList(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            List<ItemDefn> targets = new List<ItemDefn>();

            ModelData.GetTargets(ref targets);
            return targets;

        }


        

        /// <summary>
        /// Informs backend to save a version
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="sVersion"></param>
        /// <returns>void</returns>
        [WebMethod(EnableSession = true)]
        public void DoSaveVersion(string Ticket, string sVersion)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);


            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
  
                ModelData.SaveVersion(conn, sVersion);
  
            }
            SaveCachedData(this.Context, Ticket, ModelData);
            return;

        }

        

        /// <summary>
        /// Gets periods and display option data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>SortGroupDefn</returns>
        [WebMethod(EnableSession = true)]
        public PeriodsAndOptions GetPeriodsandDisplay(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            PeriodsAndOptions pao = new PeriodsAndOptions();

            ModelData.GetPeriodsandVersions(ref pao);

            return pao;

        }


        /// <summary>
        /// Sets periods and display option data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="poa"></param>
        /// <returns>void</returns>
        [WebMethod(EnableSession = true)]
        public void SetPeriodsandDisplay(string Ticket, PeriodsAndOptions poa)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.SetPeriodsandVersions(poa);
            ModelData.ProcessAndCreateDistplayLists();
            SaveCachedData(this.Context, Ticket, ModelData);

        }

 
        /// <summary>
        /// Delete a target
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="sTarget"></param>
        /// <returns>void</returns>
        [WebMethod(EnableSession = true)]
        public void DoDeleteTarget(string Ticket, string sTarget)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
 
                ModelData.DeleteTarget(conn, sTarget);
 
            }

            SaveCachedData(this.Context, Ticket, ModelData);
   
        }

        
       /// <summary>
        /// Delete a target
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="sTargetName"></param>
        /// <param name="sTargetDesc"></param>
        /// <param name="localTarget"></param>
        /// <returns>ItemDefn</returns>
        [WebMethod(EnableSession = true)]
        public ItemDefn CreateTarget(string Ticket, string sTargetName, string sTargetDesc, int localTarget, int lCopyfromTarget)
        {
            ItemDefn ret = new ItemDefn();
            ret.Id = 0;

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
   
                ret.Id = ModelData.CreateTarget(conn, sTargetName, sTargetDesc, localTarget, lCopyfromTarget);
                ret.Name = sTargetName;
               }

            SaveCachedData(this.Context, Ticket, ModelData);
            return ret;
   
        }

        /// <summary>
        /// Grabs the rates and category data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>CSRatesAndCategory</returns>
        [WebMethod(EnableSession = true)]
        public CSRatesAndCategory GetClientSideCalcData(string Ticket)
        {
            CSRatesAndCategory ret = new CSRatesAndCategory();
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.RatesAndCategory(ref ret);

            return ret;
        }
      

        /// <summary>
        /// Grabs the rates and category data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="TargetID"></param>
        /// <returns>CSTargetData</returns>
        [WebMethod(EnableSession = true)]
        public CSTargetData PrepareTargetData(string Ticket, int targetID)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            CSTargetData targetData = new CSTargetData();

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
  
 
                ModelData.PrepareTargetData(conn, targetID, ref targetData);
            }
            SaveCachedData(this.Context, Ticket, ModelData);
            return  targetData;

        }


        /// <summary>
        /// Builds xml to drive the layout of the Target grid
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>XML formatted string</returns>
        [WebMethod(EnableSession = true)]
        public string GetTargetGridLayout(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetTargetGridLayout();
        }


        /// <summary>
        /// Builds XML to populate the Model Top Grid 
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetTargetGridData(string Ticket)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetTargetGridData();
        }

        /// <summary>
        /// Loads a version if needed and returns it as a target row array 
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="VersID"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public CSTargetData ReturnVersionAsTarget(string Ticket, int VersID)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            CSTargetData targetData = new CSTargetData();

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
 

                ModelData.LoadVersionTargetData(conn, VersID, ref targetData);
 
            }

            SaveCachedData(this.Context, Ticket, ModelData);
            return targetData;

        }

        /// <summary>
        /// Saves the targets data
        /// </summary>
        /// <param name="Ticket"></param>
        /// <param name="CSTargetData"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void SaveTargetData(string Ticket, int TargetID, CSTargetData targetData)
        {

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
 
                ModelData.SaveTargetData(conn, TargetID, targetData);

 
            }

            SaveCachedData(this.Context, Ticket, ModelData);
 
        }

         /// <summary>
        /// Gets list of Cost Views
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<ItemDefn> GetCostViews()
        {

            List<ItemDefn> retData = new List<ItemDefn>();
            ItemDefn cvw = null;
            string sStage;

            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);

                DBAccess dba = new DBAccess(sDBConnect);
                if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                DataTable dt;

                string cmdText = "SELECT* FROM EPGT_COSTVIEW_DISPLAY";
                dba.SelectData(cmdText, (StatusEnum)99827, out dt);

                foreach (DataRow row in dt.Rows)
                {
                    cvw = new ItemDefn();
                    cvw.Id = DBAccess.ReadIntValue(row["VIEW_UID"]);
                    cvw.Name = DBAccess.ReadStringValue(row["VIEW_NAME"]);
                    retData.Add(cvw);
                }
Status_Error:
                dba.Close();
            }
            return retData;
        }


         /// <summary>
        /// Gets list of Cost Views
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public void DoShowRemTotal(string Ticket, int showRemFlag)
        {


            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            ModelData.SetShowRemainingFlag(showRemFlag != 0);
            SaveCachedData(this.Context, Ticket, ModelData);
        }


        /// <summary>
        /// Gets Legend grid layout xml
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetLegendGridLayout(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetLegendGridLayout();

        }

        /// <summary>
        /// Gets Legend grid layout xml
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetLegendGridData(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetLegendGridData();

        }


        /// <summary>
        /// Gets Legend grid layout xml
        /// </summary>
        /// <returns>list of user views</returns>
        [WebMethod(EnableSession = true)]
        public List<ItemDefn> LoadUserViewData(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);
            List<ItemDefn> rv = ModelData.LoadUserViewData();
            SaveCachedData(this.Context, Ticket, ModelData);
            return rv;
        }

        /// <summary>
        /// Deletes the specified Spec
        /// </summary>
        /// <returns>list of user views</returns>
        [WebMethod(EnableSession = true)]
        public List<ItemDefn> DeleteUserViewData(string Ticket, string sviewName, int localflag)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            string sStage;

            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
 
                ModelData.DeleteUserViewData(conn, sviewName, localflag);
            }


            List<ItemDefn> rv = ModelData.LoadUserViewData();
            SaveCachedData(this.Context, Ticket, ModelData);
            return rv;

        }

        /// <summary>
        /// renames the specified Spec
        /// </summary>
        /// <returns>list of user views</returns>
        [WebMethod(EnableSession = true)]
        public List<ItemDefn> RenameUserViewData(string Ticket, string snewName, string sviewName, int localflag)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            string sStage;

            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
 
                ModelData.RenameUserViewData(conn, snewName, sviewName, localflag);

             }

            List<ItemDefn> rv = ModelData.LoadUserViewData();
            SaveCachedData(this.Context, Ticket, ModelData);
            return rv;
        }

        /// <summary>
        /// Saves the current setting to spec...
        /// </summary>
        /// <returns>list of user views</returns>
        [WebMethod(EnableSession = true)]
        public List<ItemDefn> SaveUserViewData(string Ticket, string sviewName, int localflag, string sZoomTo)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            string sStage;

            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);
 
                ModelData.SaveUserViewData(conn, sviewName, localflag, sZoomTo);

            }
            List<ItemDefn> rv = ModelData.LoadUserViewData();
            SaveCachedData(this.Context, Ticket, ModelData);
            return rv;

        }

        /// <summary>
        /// Applies the spec...
        /// </summary>
        /// <returns>list of user views</returns>
        [WebMethod(EnableSession = true)]
        public SortGroupDefn SelectUserViewData(string Ticket, int viewIndex)
        {
            SortGroupDefn sng = new SortGroupDefn();

            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            string sStage;

            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {

                string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                int lw;
                SqlConnection conn = ObtainSqlConnection(out lw);

                sng.ViewZoomTo = ModelData.SelectUserViewData(conn, viewIndex);
                ModelData.ProcessAndCreateDistplayLists();
                ModelData.GetSortAndGroup(ref sng);
                SaveCachedData(this.Context, Ticket, ModelData);
                return sng;
            }
            return null;
        }

        /// <summary>
        /// returns the string to display showing the comparison text
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>string</returns>
        [WebMethod(EnableSession = true)]
        public string GetCompareStringValue(string Ticket)
        {
            ModelCache ModelData = (ModelCache)GetCachedData(this.Context, Ticket);

            return ModelData.GetCmpString();
        }



        private static bool CheckUserGlobalPermission(SqlConnection oDataAccess, int lWResID, GlobalPermissionsEnum ePermUID)
        {
            bool bRet = false;
            // Administrator has all permissions
            if (lWResID == 1)
                bRet = true;
            else
            {
                SqlCommand oCommand = null;
                SqlDataReader reader = null;
                oCommand = new SqlCommand("EPG_SP_CheckUserGlobalPermission", oDataAccess);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("WResID", SqlDbType.Int).Value = lWResID;
                oCommand.Parameters.Add("PermUID", SqlDbType.Int).Value = (int)ePermUID;
                reader = oCommand.ExecuteReader();

                if (reader.Read())
                    bRet = true;

                reader.Close();
                reader = null;
            }
            return bRet;
        }

        private SqlConnection ObtainSqlConnection(out int WResID)
        {
            string basePath;
            string ppmId;
            string ppmCompany;
            string ppmDbConn;
            string username;
            SecurityLevels securityLevel;

            WResID = 0;

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn,
                                        out securityLevel);

            SqlConnection cn = null;
            try
            {
                PortfolioEngineCore.ModelSupport modsup = new ModelSupport(basePath, username, ppmId, ppmCompany,
                                                                           ppmDbConn, securityLevel);
                cn = modsup.GetConnection();
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Open();

            }
            catch (Exception ex)
            {
                throw new PFEException(20002, "Unable to open database: " + ex.Message);
                return null;

            }



            string resName = username.Trim();

            if (resName != "")
            {
                string sCommand = "SELECT WRES_ID FROM EPG_RESOURCES Where ( { fn UCASE(WRES_NT_ACCOUNT) } = '" +
                                  resName.ToUpper() + "')";
                SqlCommand oCommand = new SqlCommand(sCommand, cn);

                SqlDataReader reader = null;
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    WResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                }
                reader.Close();
                reader = null;
            }

            return cn;
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

        private static CStruct BuildResultXML(string sContext = "", int nStatus = 0)
        {
            CStruct xResult = new CStruct();
            xResult.Initialize("Result");
            xResult.CreateStringAttr("Context", sContext);
            xResult.CreateIntAttr("Status", nStatus);
            return xResult;
        }

    }
}


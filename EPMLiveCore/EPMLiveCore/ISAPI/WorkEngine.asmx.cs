using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using EPMLiveCore.API;
using EPMLiveCore.API.ResourceManagement;
using EPMLiveCore.API.SPAdmin;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using FieldInfo = EPMLiveCore.API.FieldInfo;

namespace EPMLiveCore
{

    #region Error Codes

    /*
     * Error Code Usage:
     * =====================
     * CORE FUNCTIONS
     * =====================
     * 1000 - Execute
     * 1010 - GetConfigWebId
     * 
     * =====================
     * MY WORK FUNCTIONS
     * =====================
     * 2000 - GetMyWork
     * 2020 - GetMyGridData
     * 2030 - RenameMyWorkGridView
     * 2035 - DeleteMyWorkGridView
     * 2040 - GetMyGridLayout
     * 2045 - CheckMyWorkListEditPermission
     * 2050 - UpdateMyWorkItem
     * 2060 - GetMyWorkGridColType
     * 2070 - GetMyWorkGridEnum
     * 2080 - GetMyWorkGridViews
     * 2090 - SaveMyWorkGridView
     * 
     * ===============================
     * Build Team
     * ===============================
     * 3000 - Get Team
     * 3010 - Save Team
     * 
     * ===============================
     * Publishing Items
     * ===============================
     * 4000 - General Errors
     * 4010 - Publish
     * 4020 - GetUpdates
     * 4020 - ProcessUpdates
     * 
     * ===============================
     * PERSONALIZATION FUNCTIONS
     * ===============================
     * 5030 - Personalization_Get
     * 5040 - Personalization_Set
     * 
     * ===============================
     * FIELD INFO FUNCTIONS
     * ===============================
     * 6000 - IsFieldEditable
     * 
     * ===============================
     * TEMPLATE INFO FUNCTIONS
     * ===============================
     * 7000 - GetAllTempGalTemps
     * 7001 - GetAllSolGalTemps
     * 
     * 10600 - GetTemplateInformation
     * 
     * ===============================
     * CREATE WORKSPACE/PROJECT/TEMPLATE FUNCTIONS
     * ===============================
     * 8000 - CreateWorkspace
     * 
     * ===============================
     * COMMENTS CRUD FUNCTIONS
     * ===============================
     * 9000 - CreateComment
     * 9001 - ReadComment
     * 9002 - UpdateComment
     * 9003 - DeleteComment
     * 
     * ===============================
     * LIST ITEM FUNCTIONS
     * ===============================
     * 6050 - UpdateListItem
     * 6060 - GetListItem
     * 6070 - IsModerationEnabled
     * 
     * ===============================
     * NOTIFICATION FUNCTIONS
     * =============================== 
     * 10000 - GetNotifications
     * 10500 - SetNotificationFlags
     * 
     * ===============================
     * RESOURCE POOL FUNCTIONS
     * =============================== 
     * 15xxx
     * 
     * ===============================
     * RESOURCE MANAGEMENT FUNCTIONS
     * ===============================
     * 16xxx
     * 
     * ===============================
     * REPORTING FUNCTIONS
     * ===============================
     * 17000 - Reporting_GetMyWorkData
     * 17100 - Reporting_GetMyWorkFields
     * 17600 - Reporting_RefreshAll
     *
     * ===============================
     * ASSIGNMENT PLANNER
     * ===============================
     * 18000 - AssignmentPlanner_GetGridData
     * 18100 - AssignmentPlanner_GetGridLayout
     * 18200 - AssignmentPlanner_Publish
     * 18300 - 399 - AssignmentPlanner_LoadViews, SaveViews, UpdateViews, DeleteViews
     * 
     * ===============================
     * TAG MANAGER
     * ===============================
     * 19xxx
     * 
     * ===============================
     * NAVIGATION SERVICE
     * ===============================
     * 20xxx
     * 
     * ===============================
     * EPMLIVE FAVORITES SERVICE
     * ===============================
     * 21xxx 
     * 
     * ===============================
     * SHAREPOINT ADMIN FUNCTIONS
     * ===============================
     * 9001xx - EventReceiverManager
     * 9002xx - AddRemoveFeatureEvents
     * 
     * ===============================
     * INFRASTRUCTURE ERRORS
     * ===============================
     * 9991xx - Grid View Manager related errors
     * 9992xx - Resource Manager
     * 9993xx - SPListObjectManager
     * 
     * ===============================
     * 9999 - TestFunction
    */

    #endregion

    /// <summary>
    /// WorkEngine Data API
    /// </summary>
    [ScriptService]
    [WebService(Namespace = "workengine.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WorkEngineAPI : WebService
    {
        private const string EPMLiveReportingAssembly = "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
        private const string EPMLiveTSAssembly = "TimeSheets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";

        #region Methods (3)

        // Public Methods (3) 

        /// <summary>
        /// Executes the specified function.
        /// </summary>
        /// <param name="Function">The function.</param>
        /// <param name="Dataxml">The data xml.</param>
        /// <error code="1000">Generic error.</error>
        /// <returns></returns>
        [WebMethod]
        public string Execute(string Function, string Dataxml)
        {
            try
            {
                string[] FunctionParts = Function.Split('_');

                MethodInfo m = null;
                Assembly assemblyInstance;
                Type thisClass;
                object apiClass = null;

                switch(FunctionParts[0].ToLower())
                {
                    case "timesheet":
                        assemblyInstance = Assembly.Load(EPMLiveTSAssembly);
                        thisClass = assemblyInstance.GetType("TimeSheets.TimesheetAPI", true, true);
                        m = thisClass.GetMethod(FunctionParts[1]);
                        break;
                    case "reporting":
                        assemblyInstance = Assembly.Load(EPMLiveReportingAssembly);
                        thisClass = assemblyInstance.GetType("EPMLiveReportsAdmin.ReportingAPI", true, true);
                        m = thisClass.GetMethod(FunctionParts[1], BindingFlags.Public | BindingFlags.Instance);
                        apiClass = Activator.CreateInstance(thisClass);
                        break;
                    case "assignmentplanner":
                        assemblyInstance = Assembly.GetExecutingAssembly();
                        thisClass = assemblyInstance.GetType("EPMLiveCore.AssignmentPlanner.API.Gateway", true, true);
                        m = thisClass.GetMethod(FunctionParts[1], BindingFlags.Public | BindingFlags.Instance);
                        apiClass = Activator.CreateInstance(thisClass);
                        break;
                    case "tagmanager":
                        assemblyInstance = Assembly.GetExecutingAssembly();
                        thisClass = assemblyInstance.GetType("EPMLiveCore.TagManager.API.Gateway", true, true);
                        m = thisClass.GetMethod(FunctionParts[1], BindingFlags.Public | BindingFlags.Instance);
                        apiClass = Activator.CreateInstance(thisClass);
                        break;
                    case "personalization":
                        assemblyInstance = Assembly.GetExecutingAssembly();
                        thisClass = assemblyInstance.GetType("EPMLiveCore.API.Personalization", true, true);
                        m = thisClass.GetMethod(FunctionParts[1], BindingFlags.Public | BindingFlags.Instance);
                        apiClass = Activator.CreateInstance(thisClass);
                        break;
                    default:
                        assemblyInstance = Assembly.GetExecutingAssembly();
                        thisClass = assemblyInstance.GetType("EPMLiveCore.WorkEngineAPI", true, true);
                        m = thisClass.GetMethod(Function);
                        break;
                }

                if(m != null)
                {
                    object result = m.Invoke(apiClass, new object[] { Dataxml, SPContext.Current.Web });
                    return result.ToString();
                }
                else
                    return Response.Failure(1001, "Invalid Method Info Call");
            }
            catch (Exception ex)
            {
                return Response.Failure(1000, string.Format("Error executing function: {0}", ex.Message));
            }
        }

        [WebMethod]
        public string ExecuteJSON(string Function, string Dataxml)
        {
            try
            {
                //Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                //Type thisClass = assemblyInstance.GetType("EPMLiveCore.WorkEngineAPI", true, true);
                //MethodInfo m = thisClass.GetMethod(Function);
                //object result = m.Invoke(null, new object[] { Dataxml, SPContext.Current.Web });
                object result = Execute(Function, Dataxml);
                string ids = "";
                try
                {
                    var doc = new XmlDocument();
                    doc.LoadXml(Dataxml);
                    ids = doc.FirstChild.Attributes["IDList"].Value;
                }
                catch
                {
                }
                return JSONUtil.ConvertXmlToJson(result.ToString(), ids);
            }
            catch (Exception ex)
            {
                return Response.Failure(1000, string.Format("Error executing function: {0}", ex.Message));
            }
        }

        public static string testFunction(string data, SPWeb oWeb)
        {
            try
            {
                return
                    Response.Success(string.Format("<SPWeb>{0}</SPWeb><Data>{1}</Data>", oWeb.ID, data));
            }
            catch (Exception ex)
            {
                return Response.Failure(9999, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion Methods

        #region Publish And Update Methods

        public static string GetPublisherSettings(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APIPublish.GetPublisherSettings(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string GetPublisherItemInfo(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APIPublish.GetPublisherItemInfo(data, oWeb));
            }
            catch(APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Publishes a Planner
        /// </summary>
        /// <param name="data">The data.</param>
        /// <error code="40XX">error.</error>
        /// <returns></returns>
        public static string Publish(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APIPublish.Publish(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Publishes a Planner
        /// </summary>
        /// <param name="data">The data.</param>
        /// <error code="40XX">error.</error>
        /// <returns></returns>
        public static string PublishStatus(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APIPublish.PublishStatus(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string GetProjectInfoFromName(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APIPublish.GetProjectInfoFromName(data, oWeb));
            }
            catch(APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets Update Count
        /// </summary>
        /// <param name="data">The data.</param>
        /// <error code="403X">error.</error>
        /// <returns></returns>
        public static string GetUpdateCount(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APIPublish.GetUpdateCount(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets Updates
        /// </summary>
        /// <param name="data">The data.</param>
        /// <error code="404X">error.</error>
        /// <returns></returns>
        public static string GetUpdates(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APIPublish.GetUpdates(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Process Updates
        /// </summary>
        /// <param name="data">The data.</param>
        /// <error code="405X">error.</error>
        /// <returns></returns>
        public static string ProcessUpdates(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APIPublish.ProcessUpdates(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion

        #region Team Methods

        /// <summary>
        /// Gets Project Team.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <error code="3000">Generic error.</error>
        /// <returns></returns>
        public static string GetTeam(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APITeam.GetTeam(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string SaveTeam(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APITeam.SaveTeam(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string GetTeamGridLayout(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APITeam.GetTeamGridLayout(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string GetResourceGridLayout(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APITeam.GetResourceGridLayout(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string GetResourceGridData(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APITeam.GetResourceGridData(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string GetTeamGridData(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(APITeam.GetTeamGridData(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion

        #region My Work Methods

        /// <summary>
        /// Gets the type of my work grid col.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetMyWorkGridColType(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.GetMyWorkGridColType(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Determines whether [is moderation enabled] [the specified list].
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string IsModerationEnabled(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ListItem.IsModerationEnabled(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Deletes my work grid view.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string DeleteMyWorkGridView(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.DeleteMyWorkGridView(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Renames my work grid view.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string RenameMyWorkGridView(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.RenameMyWorkGridView(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets my work grid views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetMyWorkGridViews(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.GetMyWorkGridViews(oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Checks my work list edit permission.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string CheckMyWorkListEditPermission(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.CheckListEditPermission(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Saves my work grid view.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string SaveMyWorkGridView(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.SaveMyWorkGridView(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets my work grid enum.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetMyWorkGridEnum(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.GetMyWorkGridEnum(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the list item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetListItem(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ListItem.GetListItem(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets my work list item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetMyWorkListItem(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.GetMyWorkListItem(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets my personalization.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetMyPersonalization(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyPersonalization.GetMyPersonalization(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets my work.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetMyWork(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.GetMyWork(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets my work grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetMyWorkGridData(string data, SPWeb oWeb)
        {
            try
            {
                return MyWork.GetMyWorkGridData(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets my work grid layout.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetMyWorkGridLayout(string data, SPWeb oWeb)
        {
            try
            {
                return MyWork.GetMyWorkGridLayout(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the working on grid layout.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="oWeb">The o web.</param>
        /// <returns></returns>
        public static string GetWorkingOnGridLayout(string data, SPWeb oWeb)
        {
            try
            {
                return MyWork.GetWorkingOnGridLayout(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the working on grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="oWeb">The o web.</param>
        /// <returns></returns>
        public static string GetWorkingOnGridData(string data, SPWeb oWeb)
        {
            try
            {
                return MyWork.GetWorkingOnGridData(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Determines whether the specified field is editable or not.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string IsFieldEditable(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(FieldInfo.IsFieldEditable(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Sets my personalization.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string SetMyPersonalization(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyPersonalization.SetMyPersonalization(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Updates the list item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string UpdateListItem(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ListItem.UpdateListItem(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Updates my work item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string UpdateMyWorkItem(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(MyWork.UpdateMyWorkItem(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion

        #region Templates Region

        /// <summary>
        /// Gets the template information.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetTemplateInformation(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(Template.GetTemplateInformation(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <error code="7000"></error>
        /// <returns></returns>
        public static string GetAllTempGalTemps(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(SolLibTemplatesManager.ReturnAllLocalTemplatesInXML(data));
            }
            catch (Exception e)
            {
                return Response.Failure(7000, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <error code="7001"></error>
        /// <returns></returns>
        public static string GetAllSolGalTemps(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(SolLibTemplatesManager.ReturnAllSolutionGalleryTemplatesInXML(data));
            }
            catch (Exception e)
            {
                return Response.Failure(7001, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <error code="7002"></error>
        /// <returns></returns>
        public static string CreateWorkspace(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(SolLibTemplatesManager.CreateWorkspace(data));
            }
            catch (Exception e)
            {
                return Response.Failure(8000, e.Message);
            }
        }

        /// <summary>
        /// Queues up the job to create workspace
        /// </summary>
        /// <param name="data"></param>
        /// <param name="oWeb"></param>
        /// <returns></returns>
        public static string QueueCreateWorkspace(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(WorkspaceTimerjobAgent.QueueCreateWorkspace(data));
            }
            catch (Exception e)
            {
                return Response.Failure(8001, e.Message);
            }
        }

        public static string AddAndQueueCreateWorkspaceJob(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(WorkspaceTimerjobAgent.AddAndQueueCreateWorkspaceJob(data));
            }
            catch (Exception e)
            {
                return Response.Failure(8002, e.Message);
            }
        }

        /// <summary>
        /// Get all market apps
        /// </summary>
        /// <param name="data"></param>
        /// <param name="oWeb"></param>
        /// <returns></returns>
        public static string GetAllMarketAppsInJSON(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(SolLibTemplatesManager.CreateWorkspace(data));
            }
            catch (Exception e)
            {
                return Response.Failure(8002, e.Message);
            }
        }

        #endregion

        #region Comment Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <error code="9000"></error>
        /// <returns></returns>
        public static string CreateComment(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(CommentManager.CreateComment(data));
            }
            catch (Exception e)
            {
                return Response.Failure(9000, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <error code="9001"></error>
        /// <returns></returns>
        public static string ReadComment(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(CommentManager.ReadComment(data));
            }
            catch (Exception e)
            {
                return Response.Failure(9001, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <error code="9002"></error>
        /// <returns></returns>
        public static string UpdateComment(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(CommentManager.UpdateComment(data));
            }
            catch (Exception e)
            {
                return Response.Failure(9002, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <error code="9003"></error>
        /// <returns></returns>
        public static string DeleteComment(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(CommentManager.DeleteComment(data));
            }
            catch (Exception e)
            {
                return Response.Failure(9003, e.Message);
            }
        }

        public static string GetMyCommentsByDate(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(CommentManager.GetMyCommentsByDate(data));
            }
            catch (Exception e)
            {
                return Response.Failure(9004, e.Message);
            }
        }

        #endregion

        #region Notification Methods

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetNotifications(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(Notification.GetNotifications(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Sets the notification flags.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string SetNotificationFlags(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(Notification.SetNotificationFlags(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }


        public static string QueueItemMessage(string data, SPWeb oWeb)
        {
            try
            {
                return APIEmail.QueueItemMessageXml(data, oWeb);
            }
            catch(Exception ex)
            {
                return Response.Failure(30011, string.Format("Error: {0}", ex.Message));
            }
        }

        
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string SendEmail(string data, SPWeb oWeb)
        {
            try
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(data);
                    int templateid = int.Parse(doc.FirstChild.Attributes["TemplateId"].Value);
                    Guid siteid = new Guid(doc.FirstChild.Attributes["SiteId"].Value);
                    Guid webid = new Guid(doc.FirstChild.Attributes["WebId"].Value);
                    int toUserId = int.Parse(doc.FirstChild.Attributes["ToUserId"].Value);
                    int fromUserId = int.Parse(doc.FirstChild.Attributes["FromUserId"].Value);

                    Hashtable hshProps = new Hashtable();

                    foreach (XmlNode nd in doc.FirstChild.ChildNodes)
                    {
                        if (!hshProps.ContainsKey(nd.Name))
                            hshProps.Add(nd.Name, nd.InnerText);
                    }

                    SPUser fromUser = null;
                    SPUser toUser = null;

                    using (SPSite site = new SPSite(siteid))
                    {
                        using (SPWeb web = site.OpenWeb(webid))
                        {
                            fromUser = web.SiteUsers.GetByID(fromUserId);
                            toUser = web.SiteUsers.GetByID(toUserId);
                        }
                    }

                    APIEmail.sendEmail(templateid, siteid, webid, fromUser, toUser, hshProps);

                    return Response.Success("Success");
                }
                catch (Exception ex)
                {
                    throw new APIException(10100, ex.Message);
                }
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion

        #region Resource Pool Methods

        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetResources(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ResourceGrid.GetResources(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the resource pool data grid.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetResourcePoolDataGrid(string data, SPWeb oWeb)
        {
            try
            {
                return ResourceGrid.GetResourcePoolDataGrid(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the resource pool data grid changes.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="oWeb">The SP web.</param>
        /// <returns></returns>
        public static string GetResourcePoolDataGridChanges(string data, SPWeb oWeb)
        {
            try
            {
                return ResourceGrid.GetResourcePoolDataGridChanges(data, oWeb);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the resource pool layout grid.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetResourcePoolLayoutGrid(string data, SPWeb oWeb)
        {
            try
            {
                return ResourceGrid.GetResourcePoolLayoutGrid(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string GetResourcePoolViews(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ResourceGrid.GetResourcePoolViews(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Saves the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string SaveResourcePoolViews(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ResourceGrid.SaveResourcePoolViews(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Deletes the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string DeleteResourcePoolViews(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ResourceGrid.DeleteResourcePoolViews(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Updates the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string UpdateResourcePoolViews(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ResourceGrid.UpdateResourcePoolViews(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Deletes the resource pool resource.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="oWeb">The o web.</param>
        /// <returns></returns>
        public static string DeleteResourcePoolResource(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ResourceGrid.DeleteResourcePoolResource(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Exports the resources.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="oWeb">The o web.</param>
        /// <returns></returns>
        public static string ExportResources(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ResourceGrid.ExportResources(oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion

        #region Resource Management Methods

        /// <summary>
        /// Gets the resource time off.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static string GetResourceTimeOff(string data, SPWeb spWeb)
        {
            try
            {
                var resourceManager = new ResourceManager(spWeb);
                return Response.Success(resourceManager.GetTimeOff(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion

        #region SharePoint Administration Methods

        /// <summary>
        /// Event receiver manager.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static string EventReceiverManager(string data, SPWeb spWeb)
        {
            try
            {
                var eventReceiverManager = new EventReceiverManager(spWeb);
                return Response.Success(eventReceiverManager.Manage(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Adds or remove feature events.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static string AddRemoveFeatureEvents(string data, SPWeb spWeb)
        {
            try
            {
                var featureEventsManager = new FeatureEventsManager(spWeb);
                return Response.Success(featureEventsManager.Manage(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string ClearCache(string data, SPWeb spWeb)
        {
            try
            {
                CacheStore.Current.Clear(data);
                return Response.Success(string.Empty);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion

        #region ChartWizard Methods

        public static string GetListsAndViewsGridData(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ChartWizardDataHelper.GetListsAndViewsGridData(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string GetListAndViewsGridLayout(string data, SPWeb oWeb)
        {
            try
            {
                return Response.Success(ChartWizardDataHelper.GetListsAndViewsGridLayout(data, oWeb));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion

        #region Navigation Methods

        public static string GetNavigationLinks(string data, SPWeb oWeb)
        {
            try
            {
                var watch = new Stopwatch();
                watch.Start();

                var navigationService = new NavigationService(data.Split(','), oWeb);
                var links = navigationService.GetLinks();

                watch.Stop();

                return Response.Success(links + GetDiagnosticsInfo(watch));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string ReorderLinks(string data, SPWeb oWeb)
        {
            try
            {
                var watch = new Stopwatch();
                watch.Start();

                var navigationService = new NavigationService(oWeb);
                navigationService.ReorderLinks(data);

                watch.Stop();

                return Response.Success(GetDiagnosticsInfo(watch));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string RemoveNavigationLink(string data, SPWeb oWeb)
        {
            try
            {
                var watch = new Stopwatch();
                watch.Start();

                var navigationService = new NavigationService(oWeb);
                navigationService.RemoveNavigationLink(data);

                watch.Stop();

                return Response.Success(GetDiagnosticsInfo(watch));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string GetContextualMenuItems(string data, SPWeb oWeb)
        {
            try
            {
                var watch = new Stopwatch();
                watch.Start();

                var navigationService = new NavigationService(oWeb);
                var menuItems = navigationService.GetContextualMenuItems(data);

                watch.Stop();

                return Response.Success(menuItems + GetDiagnosticsInfo(watch));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion

        #region EPMLIVE ANALYTICS

        public static string LoadFavoriteStatus(string data, SPWeb spWeb)
        {
            try
            {
                return Response.Success(Favorites.IsFav(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string AddFavorites(string data, SPWeb spWeb)
        {
            try
            {  
                return Response.Success(Favorites.AddFav(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string RemoveFavorites(string data, SPWeb spWeb)
        {
            try
            {
                return Response.Success(Favorites.RemoveFav(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string LoadFavoriteWsStatus(string data, SPWeb spWeb)
        {
            try
            {
                return Response.Success(FavoritesWorkspace.IsFavWorkspace(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string AddFavoritesWs(string data, SPWeb spWeb)
        {
            try
            {
                return Response.Success(FavoritesWorkspace.AddFavWorkspace(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string RemoveFavoritesWs(string data, SPWeb spWeb)
        {
            try
            {
                return Response.Success(FavoritesWorkspace.RemoveFavWorkspace(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string CreateFrequentApp(string data, SPWeb spWeb)
        {
            try
            {
                return Response.Success(FrequentApps.Create(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string CreateRecentItem(string data, SPWeb spWeb)
        {
            try
            {
                return Response.Success(RecentItems.Create(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion  

        public static string GenerateQuickLaunchFromApp(string data, SPWeb spWeb)
        {
            try
            {
                Applications.GenerateQuickLaunchFromApp(spWeb);
                return Response.Success("");
            }
            catch(APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #region Helper Methods

        private static string GetDiagnosticsInfo(Stopwatch watch)
        {
            return
                new XElement("DiagnosticsInfo",
                    new XElement("ProcessTime", watch.ElapsedMilliseconds, new XAttribute("Unit", "Milliseconds")))
                    .ToString();
        }

        #endregion
    }
}

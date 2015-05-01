using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using WorkEnginePPM.Core.DataSync;
using WorkEnginePPM.WebServices.Core;
using PEC = PortfolioEngineCore;
using WEC = EPMLiveCore;
using WSC = WorkEnginePPM.WebServices.Core;
using WorkEnginePPM.Core.PFEDataServiceManager;
using EPMLiveCore.Infrastructure;

namespace WorkEnginePPM
{
    /// <summary>
    /// Summary description for EditCosts
    /// </summary>
    [WebService(Namespace = "PortfolioEngine")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class PortfolioEngineAPI : WebService
    {
        #region Fields (1)

        private static SPWeb _spWeb;

        #endregion Fields

        #region Constructors (3)

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioEngineAPI"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public PortfolioEngineAPI(SPWeb spWeb)
        {
            _spWeb = spWeb;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioEngineAPI"/> class.
        /// </summary>
        public PortfolioEngineAPI()
        {
            _spWeb = SPContext.Current.Web;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="PortfolioEngineAPI"/> is reclaimed by garbage collection.
        /// </summary>
        ~PortfolioEngineAPI()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Methods (4)

        // Public Methods (3) 

        /// <summary>
        /// Executes the specified function.
        /// </summary>
        /// <param name="Function">The function.</param>
        /// <param name="Dataxml">The dataxml.</param>
        /// <returns>XML</returns>
        [WebMethod]
        public string Execute(string Function, string Dataxml)
        {
            try
            {
                Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                Type thisClass = assemblyInstance.GetType("WorkEnginePPM.PortfolioEngineAPI", true, true);
                MethodInfo m = thisClass.GetMethod(Function);
                object result = m.Invoke(null, new object[] { Dataxml });
                return result.ToString();
            }
            catch (Exception ex)
            {
                return Response.Failure((int)APIError.Execute,
                                        string.Format("Error executing function: {0}", ex.GetBaseMessage()));
            }
        }

        /// <summary>
        /// Executes the specified function.
        /// </summary>
        /// <param name="Function">The function.</param>
        /// <param name="Dataxml">The dataxml.</param>
        /// <returns>JSON</returns>
        [WebMethod]
        public string ExecuteJSON(string Function, string Dataxml)
        {
            try
            {
                Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                Type thisClass = assemblyInstance.GetType("WorkEnginePPM.PortfolioEngineAPI", true, true);
                MethodInfo m = thisClass.GetMethod(Function);
                object result = m.Invoke(null, new object[] { Dataxml });
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
                return Response.Failure((int)APIError.ExecuteJSON,
                                        string.Format("Error executing function: {0}", ex.GetBaseMessage()));
            }
        }

        [PublicAPI(false)]
        [Description("This function returns definitions")]
        [SampleInOut("", "")]
        public static string GetFunctions(string data)
        {
            var doc = new XmlDocument();
            doc.LoadXml("<Functions/>");

            Assembly assemblyInstance = Assembly.GetExecutingAssembly();
            Type thisClass = assemblyInstance.GetType("WorkEnginePPM.PortfolioEngineAPI", true, true);

            foreach (MethodInfo methodInfo in thisClass.GetMethods(BindingFlags.Static | BindingFlags.Public))
            {
                bool isPublic = false;

                XmlNode nd = doc.CreateElement("Function");

                XmlNode attr = doc.CreateElement("Name");
                attr.InnerText = methodInfo.Name;
                nd.AppendChild(attr);

                object[] attribs = methodInfo.GetCustomAttributes(false);

                foreach (object attrib in attribs)
                {
                    if (attrib.GetType().Name == "PublicAPI")
                    {
                        try
                        {
                            var pub = (PublicAPI)attrib;
                            isPublic = pub.IsPublic;
                        }
                        catch
                        {
                        }
                    }
                    else if (attrib.GetType().Name == "SampleInOut")
                    {
                        var si = (SampleInOut)attrib;

                        attr = doc.CreateElement("Input");
                        attr.AppendChild(doc.CreateCDataSection(si.In));
                        nd.AppendChild(attr);

                        attr = doc.CreateElement("Output");
                        attr.AppendChild(doc.CreateCDataSection(si.Out));
                        nd.AppendChild(attr);
                    }
                    else if (attrib.GetType().Name == "DescriptionAttribute")
                    {
                        var da = (DescriptionAttribute)attrib;

                        attr = doc.CreateElement("Description");
                        attr.InnerText = da.Description;
                        nd.AppendChild(attr);
                    }
                }

                if (isPublic)
                {
                    doc.FirstChild.AppendChild(nd);
                }
            }

            return doc.OuterXml;
        }

        // Protected Methods (1) 

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.MarshalByValueComponent"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!disposing) return;

            if (_spWeb == null) return;

            _spWeb.Dispose();
            _spWeb = null;
        }

        [WebMethod]
        public string UploadFile(byte[] fileBytes, string fileName)
        {
            try
            {
                string fileId;
                using (var epmLiveFileStore = new EPMLiveFileStore(_spWeb))
                {
                    fileId = epmLiveFileStore.Add(fileBytes);
                }
                return Response.Success(String.Format("<UploadFileId>{0}</UploadFileId>", fileId));
            }
            catch (Exception ex)
            {
                return Response.Failure((int)APIError.UploadFile,
                                        string.Format("Error executing function: {0}", ex.GetBaseMessage()));
            }
        }

        #endregion Methods

        #region Resource Management

        [PublicAPI(true)]
        [Description("This function returns a list of all permission groups in the system.")]
        [SampleInOut(SIO.ReadPermissionGroupsIn, SIO.ReadPermissionGroupsOut)]
        public static string ReadPermissionGroups(string data)
        {
            string response;

            using (var resourceManager = new ResourceManager(_spWeb))
            {
                response = resourceManager.ReadPermissionGroups();
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function returns a list of all permission groups for requested users.")]
        [SampleInOut(SIO.ReadResourcePermissionGroupsIn, SIO.ReadResourcePermissionGroupsOut)]
        public static string ReadResourcePermissionGroups(string data)
        {
            string response;

            using (var resourceManager = new ResourceManager(_spWeb))
            {
                response = resourceManager.ReadResourcePermissionGroups(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function returns a list of all permission groups for requested users.")]
        public static string ReadResourceCostCategoryRole(string data)
        {
            string response;

            using (var resourceManager = new ResourceManager(_spWeb))
            {
                response = resourceManager.ReadResourceCostCategoryRole(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function returns a list of requested resources.")]
        [SampleInOut(SIO.ReadResourcesIn, SIO.ReadResourcesOut)]
        public static string ReadResources(string data)
        {
            string response;

            using (var resourceManager = new ResourceManager(_spWeb))
            {
                response = resourceManager.ReadResources(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function updates the requested resources.")]
        [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdateResources(string data)
        {
            string response;

            using (var resourceManager = new ResourceManager(_spWeb))
            {
                response = resourceManager.UpdateResources(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function checks if specified resources can be deleted.")]
        public static string DeleteResourceCheck(string data)
        {
            string response;

            using (var resourceManager = new ResourceManager(_spWeb))
            {
                response = resourceManager.DeleteResourceCheck(data);
            }

            return response;
        }

        #endregion

        #region Analyzer

        [PublicAPI(false)]
        public static string GenerateDataTicket(string data)
        {
            string response;

            using (var analyzerManager = new AnalyzerManager(_spWeb))
            {
                response = analyzerManager.GenerateDataTicket(data);
            }

            return response;
        }

        #endregion

        #region PFEAdmin

        [PublicAPI(true)]
        [Description("This function returns all cost category roles")]
        public static string GetCostCategoryRoles(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.GetCostCategoryRoles(data);
            }

            return response;
        }


        [PublicAPI(true)]
        [Description("This function returns Department Informations")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string GetDepartments(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.GetDepartments();
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function returns Holiday Informations")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string GetHolidaySchedules(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.GetHolidaySchedules();
            }

            return response;
        }


        [PublicAPI(true)]
        [Description("This function returns Personal Item Informations")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string GetPersonalItems(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.GetPersonalItems();
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function returns WorkHour Informations")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string GetWorkSchedules(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.GetWorkSchedules();
            }

            return response;
        }


        [PublicAPI(true)]
        [Description("This function updates the Department Lookup and Manager Informations")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdateDepartments(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.UpdateDepartments(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function deletes individual Departments from the Lookup")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string DeleteDepartments(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.DeleteDepartments(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function updates the Role Lookup")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdateRoles(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.UpdateRoles(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function deletes individual Roles from the Lookup")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string DeleteRoles(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.DeleteRoles(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function updates a Work Schedule")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdateWorkSchedule(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.UpdateWorkSchedule(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function updates a Work Schedule")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdateScheduledWork(string data)
        {
            string response;

            var doc = new XmlDocument();
            doc.LoadXml(data);

            XmlNode ndProject = doc.FirstChild.SelectSingleNode("//Project");
            if (ndProject != null)
            {
                string sList = (ndProject.Attributes["List"] == null) ? "" : ndProject.Attributes["List"].Value;
                string sId = (ndProject.Attributes["ID"] == null) ? "" : ndProject.Attributes["ID"].Value;

                if (sList == "")
                {
                    return Response.PfEFailure(new PFEException(5001, "Project List Attribute Not Found"));
                }
                else if (sId == "")
                {
                    return Response.PfEFailure(new PFEException(5002, "Project ID Attribute Not Found"));
                }
                else
                {
                    SPWeb web = SPContext.Current.Web;

                    SPList oList = web.Lists.TryGetList(sList);

                    if (oList == null)
                    {
                        return Response.PfEFailure(new PFEException(5003, "Project List Not Found"));
                    }
                    else
                    {
                        SPListItem oLi = null;
                        try
                        {
                            oLi = oList.GetItemById(int.Parse(sId));
                        }
                        catch
                        {
                        }

                        if (oLi == null)
                        {
                            return
                                Response.PfEFailure(new PFEException(5004, "Project Item (ID: " + sId + ") Not Found"));
                        }
                        else
                        {
                            XmlAttribute attr = doc.CreateAttribute("ExtId");
                            attr.Value = web.ID + "." + oList.ID + "." + oLi.ID;

                            ndProject.Attributes.Append(attr);
                            ndProject.Attributes.Remove(ndProject.Attributes["List"]);
                            ndProject.Attributes.Remove(ndProject.Attributes["ID"]);


                            DataTable dtResources =
                                APITeam.GetResourcePool("<GetResources><Columns>EXTID</Columns></GetResources>", web);

                            XmlNodeList ndResources = ndProject.SelectNodes("//Resource");

                            foreach (XmlNode nd in ndResources)
                            {
                                DataRow[] dr = dtResources.Select("ID='" + nd.Attributes["Id"].Value + "'");
                                try
                                {
                                    if (dr.Length > 0 && dr[0]["EXTID"].ToString() != "")
                                    {
                                        nd.Attributes["Id"].Value = dr[0]["EXTID"].ToString();
                                    }
                                    else
                                    {
                                        nd.ParentNode.RemoveChild(nd);
                                    }
                                }
                                catch
                                {
                                    nd.ParentNode.RemoveChild(nd);
                                }
                            }

                            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
                            {
                                response = pfeadminmanager.UpdateScheduledWork(doc.OuterXml);
                            }

                            return response;
                        }
                    }
                }
            }
            else
                return Response.PfEFailure(new PFEException(5000, "No Project Node Listed"));
        }

        [PublicAPI(true)]
        [Description("This function deletes a Work Schedule")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string DeleteWorkSchedule(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.DeleteWorkSchedule(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function updates Holiday Schedules")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdateHolidaySchedules(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.UpdateHolidaySchedules(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function deletes a Holiday Schedule")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string DeleteHolidaySchedule(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.DeleteHolidaySchedule(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function updates the Personal Items List")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdatePersonalItems(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.UpdatePersonalItems(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function deletes items from the Personal Items List")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string DeletePersonalItems(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.DeletePersonalItems(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function updates non work entries for a list of resources")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdateResourceTimeoff(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.UpdateResourceTimeoff(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function deletes non work entries for a list of resources")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string DeleteResourceTimeoff(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.DeleteResourceTimeoff(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description(
            "This function replaces the Scheduled Work for a PI by Item - Work2 comes from SP List and must be spread")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdateListWork(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.UpdateListWork(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function replaces the Scheduled Work for a PI")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string UpdateScheduledWorkByID(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.UpdateScheduledWork(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function deletes Scheduled Work Item entries for a PI by Item - Work2 comes from SP List")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string DeleteListWork(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.DeleteListWork(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function deletes Scheduled Work Item entries for a PI - all Items - Work2 comes from SP List"
            )]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string DeletePIListWork(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.DeletePIListWork(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function sets the version in the PfE database table EPG_SYSTEM")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string SetDatabaseVersion(string data)
        {
            string response;

            using (var weintegrationManager = new WEIntegrationManager(_spWeb))
            {
                response = weintegrationManager.SetDatabaseVersion(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function sets the reporting extract db connection and/or executes the reporting extract")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string ExecuteReportExtract(string data)
        {
            string response;

            using (var weintegrationManager = new WEIntegrationManager(_spWeb))
            {
                response = weintegrationManager.ExecuteReportExtract(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function imports WE Timesheet data into EPG_WE_CHARGES and ACTUALHOURS")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string PostTimesheetData(string data)
        {
            string response;

            using (var weintegrationManager = new WEIntegrationManager(_spWeb))
            {
                response = weintegrationManager.PostTimesheetData(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function Posts Cost Values for a CB/CT combination")]
        // [SampleInOut(SIO.UpdateResourcesIn, SIO.UpdateResourcesOut)]
        public static string PostCostValues(string data)
        {
            string response;

            using (var pfeadminmanager = new PFEAdminManager(_spWeb))
            {
                response = pfeadminmanager.PostCostValues(data);
            }

            return response;
        }

        #endregion

        #region Data Sync

        [PublicAPI(false)]
        [Description("This function will transfer PFE CCR to the Roles list.")]
        public static string RefreshRoles(string data)
        {
            string response;

            using (var roleManager = new RoleManager(_spWeb))
            {
                response = roleManager.RunRefresh();
            }

            return response;
        }
        [PublicAPI(false)]
        [Description("This function will delete Role from the Roles list based on PFE delete action.")]
        public static string DeleteRolesByCostCategories(string data)
        {
            string response;

            using (var roleManager = new RoleManager(_spWeb))
            {
                response = roleManager.DeleteRolesByCostCategories(data);
            }

            return response;
        }
        #endregion

        #region Nested type: PublicAPI

        public class PublicAPI : Attribute
        {
            // positional parameters
            public PublicAPI(bool isPublic)
            {
                IsPublic = isPublic;
            }

            // property for named parameter
            public bool IsPublic { get; set; }
        }

        #endregion

        #region Nested type: SIO

        private static class SIO
        {
            public const string UpdateResourcesIn =
                @"<UpdateResources>
                    <Data>
                        <Resource Id=""[int]"" ExtId=""[string]"" Username=""[string]"" DataId=""[string]"">
                            <Field Id=""[int]"">[string:value]</Field>
                            <Field Id=""[int]"">[string:value]</Field>
                        </Resource>
                        <Resource Id=""[int]"" ExtId=""[string]"" Username=""[string]"" DataId=""[string]"">
                            <Field Id=""[int]"">[string:value]</Field>
                            <Field Id=""[int]"">[string:value]</Field>
                        </Resource>
                    </Data>
                  </UpdateResources>";

            public const string UpdateResourcesOut =
                @"<UpdateResources>
                    <Result Status=""[0|1]"">[string:message]</Result>
                    <Data>
                        <Resource Id=""[int]"" DataId=""[string]"">
                            <Result Status=""[0|1]"">[string:message]</Result>
                        </Resource>
                        <Resource Id=""[int]"" DataId=""[string]"">
                            <Result Status=""[0|1]"">[string:message]</Result>
                        </Resource>
                    </Data>
                  </UpdateResources>";

            public const string ReadPermissionGroupsIn = "<ReadPermissionGroups/>";

            public const string ReadResourcePermissionGroupsIn =
                @"<ReadResourcePermissionGroups>
                    <Result Status=""[0|1]"">[string:message]</Result>
                    <Data>
                        <Resource Id=""[int]"" ExtId=""[string]"" Username=""[string]"" DataId=""[string]""/>
                        <Resource Id=""[int]"" ExtId=""[string]"" Username=""[string]"" DataId=""[string]""/>
                    </Data>
                  </ReadResourcePermissionGroups>";

            public const string ReadResourcePermissionGroupsOut =
                @"<ReadResourcePermissionGroups>
                    <Result Status=""[0|1]"">[string:message]</Result>
                    <Data>
                        <Resource Id=""[int]"" ExtId=""[string]"" Username=""[string]"" DataId=""[string]"">
                            <Result Status=""[0|1]"">[string:message]</Result>
                            <PermissionGroup Id=""[int]"" Name=""[string]""/>
                            <PermissionGroup Id=""[int]"" Name=""[string]""/>
                        </Resource>
                        <Resource Id=""[int]"" ExtId=""[string]"" Username=""[string]"" DataId=""[string]"">
                            <Result Status=""[0|1]"">[string:Message]</Result>
                            <PermissionGroup Id=""[int]"" Name=""[string]""/>
                            <PermissionGroup Id=""[int]"" Name=""[string]""/>
                        </Resource>
                    </Data>
                  </ReadResourcePermissionGroups>";

            public const string ReadResourcesIn =
                @"<ReadResources>
                    <Data>
                        <Resource Id=""[int]"" ExtId=""[string]"" Username=""[string]"" DataId=""[string]""/>
                        <Resource Id=""[int]"" ExtId=""[string]"" Username=""[string]"" DataId=""[string]""/>
                    </Data>
                  </ReadResources>";

            public const string ReadResourcesOut =
                @"<ReadResources>
                    <Result Status=""[0|1]"">[string:message]</Result>
                    <Data>
                        <Resource Id=""[int]"" DataId=""[string]"">
                            <Result Status=""[0|1]"">[string:message]</Result>
                            <Field Id=""[int]"" Name=""[string]"" Type=""[string]"">[string:value]</Field>
                            <Field Id=""[int]"" Name=""[string]"" Type=""[string]"">[string:value]</Field>
                        </Resource>
                        <Resource Id=""[int]"" DataId=""[string]"">
                            <Result Status=""[0|1]"">[string:message]</Result>
                            <Field Id=""[int]"" Name=""[string]"" Type=""[string]"">[string:value]</Field>
                            <Field Id=""[int]"" Name=""[string]"" Type=""[string]"">[string:value]</Field>
                        </Resource>
                    </Data>
                  </ReadResources>";

            public const string ReadPermissionGroupsOut =
                @"<ReadPermissionGroups>
                    <Result Status=""[0|1]"">[string:message]</Result>
                    <Data>
                        <PermissionGroup Id=""[int]"" Name=""[string]"">[string:description]</PermissionGroup>
                        <PermissionGroup Id=""[int]"" Name=""[string]"">[string:description]</PermissionGroup>
                    <Data/>
                  <ReadPermissionGroups/>";
        }

        #endregion

        #region Nested type: SampleInOut

        public class SampleInOut : Attribute
        {
            // positional parameters
            public SampleInOut(string sIn, string sOut)
            {
                In = sIn;
                Out = sOut;
            }

            // property for named parameter
            public string In { get; set; }

            // property for named parameter
            public string Out { get; set; }
        }

        #endregion

        #region PFE Import\Export

        [PublicAPI(true)]
        [Description("This function creates job for DSMComponents for PFE import-export")]
        public static string ScheduleDataImport(string data)
        {
            string response;

            using (var pFEDataServiceManager = new PFEDataServiceManager(_spWeb))
            {
                response = pFEDataServiceManager.ScheduleDataImport(data);
            }

            return response;
        }

        [PublicAPI(true)]
        [Description("This function gets dsm job result for DSMComponents for PFE import-export")]
        public static string CollectDataImportResult(string data)
        {
            string response;

            using (var pFEDataServiceManager = new PFEDataServiceManager(_spWeb))
            {
                response = pFEDataServiceManager.CollectDataImportResult(data);
            }

            return response;
        }


        #endregion
    }
}
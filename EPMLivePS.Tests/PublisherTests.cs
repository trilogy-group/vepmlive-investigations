using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Fakes;
using System.Reflection;
using System.Web.Fakes;
using System.Web.Services.Protocols.Fakes;
using System.Xml.Linq;
using EPMLiveCore.Fakes;
using EPMLiveEnterprise;
using EPMLiveEnterprise.EPMLivePortfolioEngine.Fakes;
using EPMLiveEnterprise.Fakes;
using EPMLiveEnterprise.WebSvcCustomFields.Fakes;
using EPMLiveEnterprise.WebSvcLookupTables.Fakes;
using EPMLiveEnterprise.WebSvcProject.Fakes;
using EPMLiveEnterprise.WebSvcResource.Fakes;
using EPMLiveEnterprise.WebSvcStatusing.Fakes;
using EPMLiveEnterprise.WebSvcWssInterop.Fakes;
using Microsoft.Office.Project.Server.Events;
using Microsoft.Office.Project.Server.Library;
using Microsoft.Office.Project.Server.Library.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static EPMLiveEnterprise.WebSvcCustomFields.CustomFieldDataSet;
using static EPMLiveEnterprise.WebSvcCustomFields.Fakes.ShimCustomFieldDataSet;
using static EPMLiveEnterprise.WebSvcLookupTables.Fakes.ShimLookupTableDataSet;
using static EPMLiveEnterprise.WebSvcLookupTables.LookupTableDataSet;
using static EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet;
using static EPMLiveEnterprise.WebSvcProject.ProjectDataSet;
using static EPMLiveEnterprise.WebSvcResource.Fakes.ShimResourceDataSet;
using static EPMLiveEnterprise.WebSvcWssInterop.Fakes.ShimProjectWSSInfoDataSet;
using static EPMLiveEnterprise.WebSvcWssInterop.Fakes.ShimWssSettingsDataSet;

namespace EPMLivePS.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class PublisherTests
    {
        private object reflectionObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private Guid guid;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPList spList;
        private ShimSPListItem spListItem;
        private ShimSPUser spUser;
        private ShimSPField spField;
        private ShimSqlDataReader dataReader;
        private BindingFlags publicStatic;
        private BindingFlags nonPublicStatic;
        private BindingFlags publicInstance;
        private BindingFlags nonPublicInstance;
        private ArrayList fieldsToPublish;
        private const string GuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string GuidString1 = "83e81819-9108-4c22-bb70-d8ba101e9e0c";
        private const string GuidString2 = "83e81819-2580-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string PublishSiteUrl = "somedomain.com/sampleApp/sampleAction";
        private const string LinkProjectWssMethodName = "linkProjectWss";
        private const string GetProjectWssMethodName = "getProjectWss";
        private const string CanDeleteMethodName = "canDelete";
        private const string SetPubPercentMethodName = "setPubPercent";
        private const string ProcessPFEWorkMethodName = "ProcessPFEWork";
        private const string AssignGroupsToTasksMethodName = "AssignGroupsToTasks";
        private const string LoadFieldsMethodName = "loadFields";
        private const string LoadCurrentTasksMethodName = "loadCurrentTasks";
        private const string ProcessAssignmentMethodName = "processAssignment";
        private const string ProcessProjectCenterFieldsMethodName = "processProjectCenterFields";
        private const string ProcessTaskMethodName = "processTask";
        private const string GetResourceUsernameMethodName = "getResourceUsername";
        private const string GetLookupValueMethodName = "getLookupValue";
        private const string PublishProjectCenterMethodName = "publishProjectCenter";
        private const string PublishTasksMethodName = "publishTasks";
        private const string GetHierarchyMethodName = "getHierarchy";
        private const string DoPublishMethodName = "doPublish";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            var psContextInfo = new ShimPSContextInfo()
            {
                SiteGuidGet = () => guid
            };
            var eventArgs = new ProjectPostPublishEventArgs()
            {
                ProjectGuid = guid,
                ProjectName = DummyString
            };

            Type type = typeof(EPMLivePublisher).Assembly.GetType("EPMLiveEnterprise.Publisher");
            var constructors = type.GetConstructors();
            var requiredConstructor = constructors[0];
            reflectionObject = requiredConstructor.Invoke(new object[] { psContextInfo.Instance, eventArgs });

            privateObject = new PrivateObject(reflectionObject);
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            SetupVariables();
            ShimSelectMethod();

            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.RootWebGet = _ => spWeb;
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.UrlGet = _ => DummyString;
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlDataAdapter.ConstructorSqlCommand = (_, __) => new ShimSqlDataAdapter();
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimWssSettingsDataSet.Constructor = _ => new ShimWssSettingsDataSet();
            ShimProjectWSSInfoDataSet.Constructor = _ => new ShimProjectWSSInfoDataSet();
            ShimWssInterop.Constructor = _ => new ShimWssInterop();
            ShimEPMLiveHelperClasses.getProjectServerPublishedConnectionStringGuid = _ => DummyString;
            ShimWssInterop.AllInstances.UrlSetString = (_, __) => { };
            ShimWebClientProtocol.AllInstances.CredentialsSetICredentials = (_, __) => { };
            ShimPortfolioEngineAPI.Constructor = _ => new ShimPortfolioEngineAPI();
            ShimSPQuery.Constructor = _ => new ShimSPQuery();
            ShimSPQuery.AllInstances.QuerySetString = (_, __) => { };
            ShimPortfolioEngineAPI.AllInstances.UrlSetString = (_, __) => { };
            ShimPortfolioEngineAPI.AllInstances.UseDefaultCredentialsSetBoolean = (_, __) => { };
            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = _ => new ShimSPRoleAssignmentCollection();
            ShimResourceDataSet.AllInstances.ResourcesGet = _ => new ShimResourcesDataTable();
            ShimCustomFieldDataSet.AllInstances.CustomFieldsGet = _ => new ShimCustomFieldsDataTable();
            ShimLookupTableDataSet.AllInstances.LookupTableTreesGet = _ => new ShimLookupTableTreesDataTable();
            ShimHttpUtility.UrlDecodeString = input => input;
            ShimCustomFields.Constructor = _ => new ShimCustomFields();
            ShimLookupTable.Constructor = _ => new ShimLookupTable();
            EPMLiveEnterprise.WebSvcResource.Fakes.ShimResource.Constructor = _ => new EPMLiveEnterprise.WebSvcResource.Fakes.ShimResource();
            EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject.Constructor = _ => new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject();
            ShimStatusing.Constructor = _ => new ShimStatusing();
            ShimWssInterop.Constructor = _ => new ShimWssInterop();
            ShimCustomFields.AllInstances.UrlSetString = (_, __) => { };
            ShimLookupTable.AllInstances.UrlSetString = (_, __) => { };
            EPMLiveEnterprise.WebSvcResource.Fakes.ShimResource.AllInstances.UrlSetString = (_, __) => { };
            EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject.AllInstances.UrlSetString = (_, __) => { };
            ShimStatusing.AllInstances.UrlSetString = (_, __) => { };
            ShimWssInterop.AllInstances.UrlSetString = (_, __) => { };
            EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet.Constructor = _AppDomain => new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet();
        }

        private void ShimSelectMethod()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("DATE_VALUE");
            dataTable.Columns.Add("DUR_VALUE");
            dataTable.Columns.Add("NUM_VALUE");
            dataTable.Columns.Add("FLAG_VALUE");
            dataTable.Columns.Add("TEXT_VALUE");
            dataTable.Columns.Add("CODE_VALUE");
            var row = dataTable.NewRow();
            row["DATE_VALUE"] = DateTime.Now;
            row["DUR_VALUE"] = 100;
            row["NUM_VALUE"] = 100;
            row["FLAG_VALUE"] = true;
            row["TEXT_VALUE"] = DummyString;
            row["CODE_VALUE"] = DummyString;
            var rowArray = new DataRow[]
            {
                row
            };
            ShimDataTable.AllInstances.SelectString = (_, condition) =>
            {
                if (condition.Contains("TASK_UID"))
                {
                    if (condition.Contains("MD_PROP_UID") || condition.Contains("MD_PROP_ID"))
                    {
                        return rowArray;
                    }
                    if (condition.Contains(new Guid(GuidString1).ToString()))
                    {
                        return new AssignmentRow[]
                        {
                            new ShimAssignmentRow()
                            {
                                TASK_UIDGet = () => guid,
                                ASSN_UIDGet = () => guid,
                                ASSN_NOTESGet = () => DummyString,
                                RES_UID_OWNERGet = () => guid,
                                ASSN_PCT_WORK_COMPLETEGet = () => 100,
                                IsASSN_NOTESNull = () => false
                            }
                        };
                    }
                    return new TaskRow[]
                    {
                        new ShimTaskRow()
                        {
                            TASK_PARENT_UIDGet = () => guid,
                            TASK_NAMEGet = () => DummyString,
                            TASK_WBSGet = () => DummyString,
                            TASK_UIDGet = () => guid,
                            TASK_IDGet = () => 111,
                            TASK_IS_SUMMARYGet = () => true
                        }
                    };
                }
                else if (condition.Contains("MD_PROP_ID"))
                {
                    if (condition.Contains("CODE_VALUE"))
                    {
                        return new CustomFieldsRow[]
                        {
                            new ShimCustomFieldsRow()
                        };
                    }
                    return rowArray;
                }
                else if (condition.Contains("LT_STRUCT_UID"))
                {
                    return new LookupTableTreesRow[]
                    {
                        new ShimLookupTableTreesRow()
                        {
                            LT_VALUE_TEXTGet = () => DummyString,
                            LT_VALUE_NUMGet = () => 111
                        }
                    };
                }
                else if (condition.Contains("TASK_ID"))
                {
                    return new TaskRow[]
                    {
                        new ShimTaskRow()
                        {
                            TASK_PARENT_UIDGet = () => guid,
                            TASK_NAMEGet = () => DummyString,
                            TASK_WBSGet = () => DummyString,
                            TASK_UIDGet = () => guid,
                            TASK_IDGet = () => 111,
                            TASK_IS_SUMMARYGet = () => true
                        }
                    };
                }
                else if (condition.Contains("RES_UID"))
                {
                    dataTable = new DataTable();
                    dataTable.Columns.Add("RES_IS_WINDOWS_USER");
                    dataTable.Columns.Add("WRES_ACCOUNT");
                    row = dataTable.NewRow();
                    row["RES_IS_WINDOWS_USER"] = "True";
                    row["WRES_ACCOUNT"] = DummyString;
                    return new DataRow[]
                    {
                        row
                    };
                }
                else if (condition.Contains("ASSN_UID") && !condition.Contains("rolldown"))
                {
                    return rowArray;
                }
                else if (condition.Contains("LINK_SUCC_UID"))
                {
                    dataTable = new DataTable();
                    dataTable.Columns.Add("LINK_TYPE");
                    dataTable.Columns.Add("LINK_PRED_UID");
                    row = dataTable.NewRow();
                    row["LINK_TYPE"] = "0";
                    row["LINK_PRED_UID"] = DummyString;
                    var rowList = new List<DataRow>()
                    {
                        row
                    };
                    row = dataTable.NewRow();
                    row["LINK_TYPE"] = "2";
                    row["LINK_PRED_UID"] = DummyString;
                    rowList.Add(row);
                    row = dataTable.NewRow();
                    row["LINK_TYPE"] = "3";
                    row["LINK_PRED_UID"] = DummyString;
                    rowList.Add(row);
                    return rowList.ToArray();
                }
                return new DataRow[0];
            };
        }

        private void SetupVariables()
        {
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            nonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;
            guid = new Guid(GuidString);
            fieldsToPublish = new ArrayList()
            {
                "TASK_RESNAMES#######",
                "TASK_PCT_COMP#######",
                "Other###3#DATETIME###",
                "Other###3#DURATION###",
                "Other###3#NUMBER###",
                "Other###3#CURRENCY###",
                "Other###3#BOOLEAN###",
                "Other###3#TEXT###",
                "Other##rolldown#3#DATETIME###true",
                "Other##rolldown#3#DURATION###true",
                "Other##rolldown#3#NUMBER###true",
                "Other##rolldown#3#CURRENCY###true",
                "Other##rolldown#3#BOOLEAN###true",
                "Other##rolldown#3#TEXT###true",
                "Other###2#DATETIME###",
                "Other###2#DURATION###",
                "Other###2#NUMBER###",
                "Other###2#CURRENCY###",
                "Other###2#BOOLEAN###",
                "Other###2#TEXT###",
                "TASK_PREDECESSORS###1#TEXT###",
                "Other##Custom#1#DATETIME###",
                "Other##Custom#1#ELSE#100##"
            };
            dataReader = new ShimSqlDataReader()
            {
                Close = () => { }
            };
            spField = new ShimSPField()
            {
                IdGet = () => guid
            };
            spSite = new ShimSPSite()
            {
                UrlGet = () => DummyString
            };
            spList = new ShimSPList()
            {
                GetItemByIdInt32 = _ => spListItem,
                GetItemByUniqueIdGuid = _ => spListItem,
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = _ => spField,
                    ContainsFieldString = _ => true
                },
                GetItemsSPQuery = _ => new ShimSPListItemCollection()
                {
                    CountGet = () => 1,
                    ItemGetInt32 = __ => spListItem
                },
                ItemsGet = () => new ShimSPListItemCollection()
                {
                    Add = () => spListItem
                }
            };
            spListItem = new ShimSPListItem()
            {
                IDGet = () => 111,
                ItemGetString = key =>
                {
                    if (key.Equals("IsProjectServer"))
                    {
                        return "True";
                    }
                    return DummyString;
                },
                HasUniqueRoleAssignmentsGet = () => true,
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = _ => spField,
                    ContainsFieldString = _ => true
                },
                ParentListGet = () => spList
            };
            spUser = new ShimSPUser()
            {
                IDGet = () => 111,
                NameGet = () => DummyString
            };
            spWeb = new ShimSPWeb()
            {
                UrlGet = () => DummyString,
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = _ => spList
                },
                AllUsersGet = () => new ShimSPUserCollection()
                {
                    ItemGetString = _ => spUser
                }
            };
        }

        private object InvokeMethod(string methodName, BindingFlags bindingFlags, object[] parameters)
        {
            SetFieldsOrProperties();
            return privateObject.Invoke(methodName, bindingFlags, parameters);
        }

        private void SetFieldsOrProperties()
        {
            privateObject.SetFieldOrProperty("publishSiteUrl", nonPublicInstance, PublishSiteUrl);
            privateObject.SetFieldOrProperty("projectServerUrl", nonPublicInstance, PublishSiteUrl);
            privateObject.SetFieldOrProperty("mySiteGuid", nonPublicInstance, guid);
            privateObject.SetFieldOrProperty("lastTransUid", nonPublicInstance, guid);
            privateObject.SetFieldOrProperty("pWssInterop", nonPublicInstance, new ShimWssInterop().Instance);
            privateObject.SetFieldOrProperty("cn", nonPublicInstance, new ShimSqlConnection().Instance);
            privateObject.SetFieldOrProperty("pctComplete", nonPublicInstance, 10D);
            privateObject.SetFieldOrProperty("pService", nonPublicInstance, new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject().Instance);
            privateObject.SetFieldOrProperty("pResource", nonPublicInstance, new EPMLiveEnterprise.WebSvcResource.Fakes.ShimResource().Instance);
            privateObject.SetFieldOrProperty("rDs", nonPublicInstance, new ShimResourceDataSet().Instance);
            privateObject.SetFieldOrProperty("mySiteToPublish", nonPublicInstance, spWeb.Instance);
            privateObject.SetFieldOrProperty("mySite", nonPublicInstance, spSite.Instance);
            privateObject.SetFieldOrProperty("pCf", nonPublicInstance, new ShimCustomFields().Instance);
            privateObject.SetFieldOrProperty("taskEntity", nonPublicInstance, guid);
            privateObject.SetFieldOrProperty("projectGuid", nonPublicInstance, guid);
            privateObject.SetFieldOrProperty("hshTaskCenterFields", nonPublicInstance, new Hashtable());
            privateObject.SetFieldOrProperty("hshProjectCenterFields", nonPublicInstance, new Hashtable());
            privateObject.SetFieldOrProperty("hshCurTasks", nonPublicInstance, new Hashtable());
            privateObject.SetFieldOrProperty("hshTaskHierarchy", nonPublicInstance, new Hashtable());
            privateObject.SetFieldOrProperty("arrFieldsToPublish", nonPublicInstance, new ArrayList());
            privateObject.SetFieldOrProperty("arrPJFieldsToPublish", nonPublicInstance, new ArrayList());
            privateObject.SetFieldOrProperty("arrDelNewTasks", nonPublicInstance, new ArrayList());
            privateObject.SetFieldOrProperty("dsFields", nonPublicInstance, new ShimCustomFieldDataSet().Instance);
            privateObject.SetFieldOrProperty("dsLt", nonPublicInstance, new ShimLookupTableDataSet().Instance);
            privateObject.SetFieldOrProperty("pService", nonPublicInstance, new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject().Instance);
            privateObject.SetFieldOrProperty("workspaceSynch", nonPublicInstance, new ShimProjectWorkspaceSynch().Instance);
            privateObject.SetFieldOrProperty("psiLookupTable", nonPublicInstance, new ShimLookupTable().Instance);
        }

        [TestMethod]
        public void LinkProjectWss_WhenCalled_Publishes()
        {
            // Arrange
            var validation = 0;

            ShimWssInterop.AllInstances.ReadWssSettings = _ => new ShimWssSettingsDataSet()
            {
                WssAdminGet = () => new ShimWssAdminDataTable()
                {
                    ItemGetInt32 = __ => new ShimWssAdminRow()
                    {
                        WADMIN_CURRENT_STS_SERVER_UIDGet = () =>
                        {
                            validation = validation + 1;
                            return guid;
                        }
                    }
                }
            };

            // Act
            InvokeMethod(LinkProjectWssMethodName, nonPublicInstance, new object[] { });

            // Assert
            validation.ShouldBe(1);
        }

        [TestMethod]
        public void GetProjectWss_WhenCalled_ReturnsString()
        {
            // Arrange
            ShimCredentialCache.DefaultCredentialsGet = () => null;
            ShimWssInterop.AllInstances.ReadWssDataGuid = (_, __) => new ShimProjectWSSInfoDataSet()
            {
                ProjWssInfoGet = () => new ShimProjWssInfoDataTable()
                {
                    CountGet = () => 10,
                    ItemGetInt32 = index => new ShimProjWssInfoRow()
                    {
                        PROJECT_WORKSPACE_URLGet = () => DummyString
                    }
                }
            };

            // Act
            var actual = (string)InvokeMethod(GetProjectWssMethodName, nonPublicInstance, new object[] { DummyString, guid });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void CanDelete_FieldPresent_ReturnsFalse()
        {
            // Arrange and Act
            var actual = (bool)InvokeMethod(CanDeleteMethodName, nonPublicInstance, new object[] { "LastPublished" });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void CanDelete_FieldNotPresent_ReturnsTrue()
        {
            // Arrange and Act
            var actual = (bool)InvokeMethod(CanDeleteMethodName, nonPublicInstance, new object[] { DummyString });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void SetPubPercent_WhenCalled_Updates()
        {
            // Arrange
            var count = 10D;
            var total = 10D;
            var validation = false;

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validation = true;
                return 1;
            };

            // Act
            InvokeMethod(SetPubPercentMethodName, nonPublicInstance, new object[] { total, count });

            // Assert
            validation.ShouldBeTrue();
        }

        [TestMethod]
        public void ProcessPFEWork_WhenCalled_Processes()
        {
            // Arrange
            var today = DateTime.Now;
            var actual = default(XDocument);
            var dataTable = new DataTable();
            dataTable.Columns.Add("RES_IS_WINDOWS_USER");
            dataTable.Columns.Add("Res_ID");
            var row = dataTable.NewRow();
            row["RES_IS_WINDOWS_USER"] = "True";
            row["Res_ID"] = "111";
            var rows = new DataRow[]
            {
                row
            };

            EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject.AllInstances.ReadProjectGuidDataStoreEnum = (_, _1, _2) => new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet()
            {
                AssignmentGet = () => new ShimAssignmentDataTable()
                {
                    GetEnumerator = () => new List<AssignmentRow>()
                    {
                        new ShimAssignmentRow()
                        {
                            ASSN_START_DATEGet = () => today,
                            ASSN_FINISH_DATEGet = () => today,
                            ASSN_WORKGet = () => 6,
                            ASSN_UNITSGet = () => 1
                        }
                    }.GetEnumerator()
                }
            };
            ShimDataTable.AllInstances.SelectString = (_, __) => rows;
            ShimPortfolioEngineAPI.AllInstances.ExecuteStringString = (_, _1, xmlString) =>
            {
                actual = XDocument.Parse(xmlString);
                return string.Empty;
            };

            // Act
            InvokeMethod(ProcessPFEWorkMethodName, nonPublicInstance, new object[] { 1 });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("UpdateScheduledWork").Element("Data").Element("Project").Elements("Resource").Count().ShouldBe(1),
                () => actual.Element("UpdateScheduledWork").Element("Data").Element("Project").Element("Resource").Attribute("Id").Value.ShouldBe("111"),
                () => actual.Element("UpdateScheduledWork").Element("Data").Element("Project").Element("Resource").Element("Work").Attribute("Date").Value.ShouldBe(today.ToString("s")));
        }

        [TestMethod]
        public void AssignGroupsToTasks_WhenCalled_AssignsGroups()
        {
            // Arrange
            var validation = 0;
            var dataTable = new DataTable();
            dataTable.Columns.Add("Res_UID", typeof(Guid));
            dataTable.Rows.Add(dataTable.NewRow());
            dataTable.Rows[0]["Res_UID"] = guid;

            ShimDataTableExtensions.AsEnumerableDataTable = _ =>
            {
                var result = default(EnumerableRowCollection<DataRow>);
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = dataTable.AsEnumerable();
                });
                return result;
            };
            var projectDataSet = new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet()
            {
                AssignmentGet = () => new ShimAssignmentDataTable(),
                ProjectResourceGet = () => new ShimProjectResourceDataTable()
                {
                    GetEnumerator = () => new List<ProjectResourceRow>()
                    {
                        new ShimProjectResourceRow()
                        {
                            WRES_ACCOUNTGet = () => DummyString,
                            RES_NAMEGet = () => DummyString,
                            RES_UIDGet = () => guid,
                            IsWRES_ACCOUNTNull = () => false,
                            WRES_EMAILGet = () => DummyString
                        }
                    }.GetEnumerator()
                }
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = __ => new List<SPRoleAssignment>()
            {
                new ShimSPRoleAssignment()
                {
                    MemberGet = () => new ShimSPGroup()
                    {
                        NameGet = () => "Member",
                        AddUserStringStringStringString = (_, _1, _2, _3) =>
                        {
                            validation = validation + 1;
                        },
                        Update = () =>
                        {
                            validation = validation + 1;
                        }
                    }
                },
                new ShimSPRoleAssignment()
                {
                    MemberGet = () => new ShimSPGroup()
                    {
                        NameGet = () => "Visitor",
                        AddUserStringStringStringString = (_, _1, _2, _3) => { },
                        Update = () =>
                        {
                            validation = validation + 1;
                        }
                    }
                }
            }.GetEnumerator();
            spListItem.ItemSetStringObject = (_, __) =>
            {
                validation = validation + 1;
            };
            spListItem.Update = () =>
            {
                validation = validation + 1;
            };

            // Act
            InvokeMethod(AssignGroupsToTasksMethodName, nonPublicInstance, new object[] { 1, 1, projectDataSet.Instance });

            // Assert
            validation.ShouldBe(5);
        }

        [TestMethod]
        public void LoadFields_WhenCalled_LoadsFields()
        {
            // Arrange
            var methodHit = 0;
            var field1 = new ShimSPField()
            {
                InternalNameGet = () => "Int32",
                IdGet = () => guid,
                HiddenGet = () => false,
                ReadOnlyFieldGet = () => false,
                TypeGet = () => SPFieldType.Threading
            };
            var field2 = new ShimSPField()
            {
                InternalNameGet = () => "Int64",
                IdGet = () => guid,
                HiddenGet = () => false,
                ReadOnlyFieldGet = () => false,
                TypeGet = () => SPFieldType.Threading
            };
            var fieldList = new List<SPField>()
            {
                field1.Instance,
                field2.Instance
            };
            dataReader.Read = () =>
            {
                methodHit = methodHit + 1;
                return (methodHit % 2 == 1);
            };
            dataReader.GetInt32Int32 = _ => 3;
            dataReader.GetStringInt32 = _ => DummyString;
            ShimCustomFields.AllInstances.ReadCustomFieldsByEntityGuid = (_, __) => new ShimCustomFieldDataSet()
            {
                CustomFieldsGet = () => new ShimCustomFieldsDataTable()
            };
            ShimDataTable.AllInstances.SelectString = (_, __) => new CustomFieldsRow[]
            {
                new ShimCustomFieldsRow()
                {
                    MD_PROP_ROLLDOWN_TO_ASSNGet = () => true,
                    MD_PROP_IDGet = () => 111,
                    MD_PROP_UID_SECONDARYGet = () => guid,
                    MD_PROP_TYPE_ENUMGet = () => (byte)PropertyType.CostEng96,
                    IsMD_LOOKUP_TABLE_UIDNull = () => true
                }.Instance
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => fieldList.GetEnumerator();

            // Act
            InvokeMethod(LoadFieldsMethodName, nonPublicInstance, new object[] { });
            fieldsToPublish = (ArrayList)privateObject.GetFieldOrProperty("arrFieldsToPublish", nonPublicInstance);
            var pjFieldsToPublish = (ArrayList)privateObject.GetFieldOrProperty("arrPJFieldsToPublish", nonPublicInstance);

            // Assert
            fieldsToPublish.ShouldSatisfyAllConditions(
                () => fieldsToPublish.Count.ShouldBe(2),
                () => pjFieldsToPublish.Count.ShouldBe(2));
        }

        [TestMethod]
        public void LoadCurrentTasks_WhenCalled_ReturnsBoolean()
        {
            // Arrange
            ShimSPListItemCollection.AllInstances.GetEnumerator = __ => new List<SPListItem>()
            {
                new ShimSPListItem()
                {
                    ItemGetString = _ => DummyString,
                    UniqueIdGet = () => guid
                }.Instance,
                new ShimSPListItem()
                {
                    ItemGetString = key =>
                    {
                        if(key.Equals("transuid"))
                        {
                            return guid.ToString();
                        }
                        return string.Empty;
                    },
                    UniqueIdGet = () => guid
                }.Instance
            }.GetEnumerator();

            // Act
            var actual = (bool)InvokeMethod(LoadCurrentTasksMethodName, nonPublicInstance, new object[] { DummyString });
            var curTasks = (Hashtable)privateObject.GetFieldOrProperty("hshCurTasks", nonPublicInstance);
            var newTasks = (ArrayList)privateObject.GetFieldOrProperty("arrDelNewTasks", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => curTasks.Count.ShouldBe(1),
                () => newTasks.Count.ShouldBe(1));
        }

        [TestMethod]
        public void PublishProjectCenter_WhenCalled_ReturnsInteger()
        {
            // Arrange
            var validation = 0;
            var taskRow = new ShimTaskRow()
            {
                TASK_PARENT_UIDGet = () => guid,
                TASK_NAMEGet = () => DummyString,
                TASK_WBSGet = () => DummyString,
                TASK_UIDGet = () => guid,
                TASK_IDGet = () => 111,
                TASK_IS_SUMMARYGet = () => true
            };
            fieldsToPublish = new ArrayList()
            {
                "TASK_RESNAMES###1####",
                "Other###3#DATETIME###",
                "Other###3#DURATION###",
                "Other###3#NUMBER###",
                "Other###3#CURRENCY###",
                "Other###3#BOOLEAN###",
                "Other###3#TEXT###",
                "Other###2#DATETIME###",
                "Other###2#DURATION###",
                "Other###2#NUMBER###",
                "Other###2#CURRENCY###",
                "Other###2#BOOLEAN###",
                "Other###2#TEXT###",
                "TASK_PREDECESSORS###1#TEXT###",
                "DATETIME##Custom#1#DATETIME###",
                "FLOAT##Custom#1#ELSE#100##",
                "###4#DATETIME###",
                "###4#DURATION###",
                "###4#NUMBER###",
                "###4#CURRENCY###",
                "###4#BOOLEAN###",
                "###4#TEXT###"
            };
            var dataSet = new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet()
            {
                TaskGet = () => new ShimTaskDataTable(),
                DependencyGet = () => new ShimDependencyDataTable(),
                TaskCustomFieldsGet = () => new ShimTaskCustomFieldsDataTable(),
                ProjectCustomFieldsGet = () => new ShimProjectCustomFieldsDataTable(),
                ProjectGet = () => new ShimProjectDataTable()
                {
                    ItemGetInt32 = _ => new ShimProjectRow()
                    {
                        PROJ_NAMEGet = () => DummyString,
                        PROJ_UIDGet = () => guid,
                        ProjectOwnerIDGet = () => guid
                    }
                }
            };
            ShimDataRow.AllInstances.ItemGetString = (instance, key) =>
            {
                var result = default(object);
                if (key.Equals("FLOAT"))
                {
                    result = 100;
                }
                else if (key.Equals("DATETIME"))
                {
                    result = DateTime.Now;
                }
                else
                {
                    ShimsContext.ExecuteWithoutShims(() =>
                    {
                        result = instance[key];
                    });
                }
                return result;
            };
            spListItem.ItemSetGuidObject = (_, __) =>
            {
                validation = validation + 1;
            };
            spListItem.ItemSetStringObject = (_, __) =>
            {
                validation = validation + 1;
            };
            spListItem.Update = () =>
            {
                validation = validation + 1;
            };

            SetFieldsOrProperties();
            privateObject.SetFieldOrProperty("strTimesheetField", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("arrPJFieldsToPublish", nonPublicInstance, fieldsToPublish);

            // Act
            var actual = (int)privateObject.Invoke(PublishProjectCenterMethodName, nonPublicInstance, new object[] { dataSet.Instance });
            var taskHierarchy = (Hashtable)privateObject.GetFieldOrProperty("hshTaskHierarchy", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => validation.ShouldBe(31),
                () => actual.ShouldBe(111),
                () => taskHierarchy.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetResourceUsername_WhenCalled_ReturnsString()
        {
            // Arrange and Act
            var actual = (string)InvokeMethod(GetResourceUsernameMethodName, nonPublicInstance, new object[] { guid });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetLookupValue_StringType_ReturnsString()
        {
            // Arrange
            ShimCustomFieldsRow.AllInstances.MD_PROP_TYPE_ENUMGet = _ => (byte)PSDataType.STRING;

            // Act
            var actual = (string)InvokeMethod(GetLookupValueMethodName, nonPublicInstance, new object[] { "CODE_VALUE", DummyString });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetLookupValue_NumberType_ReturnsString()
        {
            // Arrange
            ShimCustomFieldsRow.AllInstances.MD_PROP_TYPE_ENUMGet = _ => (byte)PSDataType.NUMBER;

            // Act
            var actual = (string)InvokeMethod(GetLookupValueMethodName, nonPublicInstance, new object[] { "CODE_VALUE", DummyString });

            // Assert
            actual.ShouldBe("111");
        }

        private void PublishTasksShim()
        {
            EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject.AllInstances.ReadProjectGuidDataStoreEnum = (_, _1, _2) => new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet()
            {
                TaskGet = () => new ShimTaskDataTable()
                {
                    CountGet = () => 1,
                    GetEnumerator = () => new List<TaskRow>()
                    {
                        new ShimTaskRow()
                        {
                            TASK_PARENT_UIDGet = () => guid,
                            TASK_NAMEGet = () => DummyString,
                            TASK_WBSGet = () => DummyString,
                            TASK_NOTESGet = () => DummyString,
                            TASK_UIDGet = () => new Guid(GuidString1),
                            TASK_IDGet = () => 111,
                            TASK_IS_SUMMARYGet = () => true,
                            IsTASK_NAMENull = () => false,
                            IsTASK_WBSNull = () => false,
                            IsTASK_NOTESNull = () => false,
                            TASK_IS_SUBPROJGet = () => false
                        }
                    }.GetEnumerator()
                },
                AssignmentGet = () => new ShimAssignmentDataTable()
                {
                    CountGet = () => 1,
                    GetEnumerator = () => new List<AssignmentRow>()
                    {
                        new ShimAssignmentRow()
                        {
                            TASK_UIDGet = () => guid,
                            ASSN_UIDGet = () => guid,
                            ASSN_NOTESGet = () => DummyString,
                            RES_UID_OWNERGet = () => guid,
                            ASSN_PCT_WORK_COMPLETEGet = () => 100,
                            IsASSN_NOTESNull = () => false
                        }
                    }.GetEnumerator()
                },
                DependencyGet = () => new ShimDependencyDataTable(),
                TaskCustomFieldsGet = () => new ShimTaskCustomFieldsDataTable(),
                AssignmentCustomFieldsGet = () => new ShimAssignmentCustomFieldsDataTable()
            };
            ShimProjectWorkspaceSynch.AllInstances.getResourceIdForTaskGuidProjectDataSet = (_, _1, _2) => 10;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimStatusing.Constructor = _ => new ShimStatusing();
            ShimStatusing.AllInstances.ReadStatusApprovalDetailsGuid = (_, __) =>
            {
                throw new Exception();
            };
            ShimStatusing.AllInstances.UrlSetString = (_, __) => { };
            ShimDataRow.AllInstances.ItemGetString = (instance, key) =>
            {
                var result = default(object);
                if (key.Equals("Custom"))
                {
                    result = 100;
                }
                else if (key.Equals("FLOAT"))
                {
                    result = 100;
                }
                else if (key.Equals("DATETIME"))
                {
                    result = DateTime.Now;
                }
                else
                {
                    ShimsContext.ExecuteWithoutShims(() =>
                    {
                        result = instance[key];
                    });
                }
                return result;
            };
        }

        [TestMethod]
        public void PublishTasks_PubType1_PublishesTasks()
        {
            // Arrange
            var pubType = 1;
            var validation = 0;
            var taskHierarchy = new Hashtable()
            {
                [guid] = guid
            };
            var currentTasksHashTable = new Hashtable()
            {
                [$"{guid.ToString().ToUpper()}.{guid.ToString().ToUpper()}"] = guid,
                [new Guid(GuidString1).ToString().ToUpper()] = guid,
                [guid.ToString().ToUpper()] = guid,
                [guid.ToString().ToLower()] = guid
            };
            spListItem.ItemSetGuidObject = (_, __) =>
            {
                validation = validation + 1;
            };
            spListItem.ItemSetStringObject = (_, __) =>
            {
                validation = validation + 1;
            };
            spListItem.Update = () =>
            {
                validation = validation + 1;
            };
            spListItem.Delete = () =>
            {
                validation = validation + 1;
            };

            PublishTasksShim();
            SetFieldsOrProperties();
            privateObject.SetFieldOrProperty("hshCurTasks", nonPublicInstance, currentTasksHashTable);
            privateObject.SetFieldOrProperty("hshTaskHierarchy", nonPublicInstance, taskHierarchy);
            privateObject.SetFieldOrProperty("arrFieldsToPublish", nonPublicInstance, fieldsToPublish);
            privateObject.SetFieldOrProperty("strTimesheetField", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("arrDelNewTasks", nonPublicInstance, new ArrayList() { guid });

            // Act
            privateObject.Invoke(
                PublishTasksMethodName,
                nonPublicInstance,
                new object[] { 1, pubType, guid, guid });

            // Assert
            validation.ShouldBe(76);
        }

        [TestMethod]
        public void PublishTasks_PubType2_PublishesTasks()
        {
            // Arrange
            var pubType = 2;
            var validation = 0;
            var taskHierarchy = new Hashtable()
            {
                [guid] = guid
            };
            var currentTasksHashTable = new Hashtable()
            {
                [$"{guid.ToString().ToUpper()}.{guid.ToString().ToUpper()}"] = guid,
                [new Guid(GuidString1).ToString().ToUpper()] = guid,
                [guid.ToString().ToUpper()] = guid,
                [guid.ToString().ToLower()] = guid
            };
            spListItem.ItemSetGuidObject = (_, __) =>
            {
                validation = validation + 1;
            };
            spListItem.ItemSetStringObject = (_, __) =>
            {
                validation = validation + 1;
            };
            spListItem.Update = () =>
            {
                validation = validation + 1;
            };
            spListItem.Delete = () =>
            {
                validation = validation + 1;
            };

            PublishTasksShim();
            SetFieldsOrProperties();
            privateObject.SetFieldOrProperty("hshCurTasks", nonPublicInstance, currentTasksHashTable);
            privateObject.SetFieldOrProperty("hshTaskHierarchy", nonPublicInstance, taskHierarchy);
            privateObject.SetFieldOrProperty("arrFieldsToPublish", nonPublicInstance, fieldsToPublish);
            privateObject.SetFieldOrProperty("strTimesheetField", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("arrDelNewTasks", nonPublicInstance, new ArrayList() { guid });

            // Act
            privateObject.Invoke(
                PublishTasksMethodName,
                nonPublicInstance,
                new object[] { 1, pubType, guid, guid });

            // Assert
            validation.ShouldBe(7);
        }

        [TestMethod]
        public void PublishTasks_PubType3_PublishesTasks()
        {
            // Arrange
            var pubType = 3;
            var validation = 0;
            var taskHierarchy = new Hashtable()
            {
                [guid] = guid
            };
            var currentTasksHashTable = new Hashtable()
            {
                [$"{guid.ToString().ToUpper()}.{guid.ToString().ToUpper()}"] = guid,
                [new Guid(GuidString1).ToString().ToUpper()] = guid,
                [guid.ToString().ToUpper()] = guid,
                [guid.ToString().ToLower()] = guid
            };
            spListItem.ItemSetGuidObject = (_, __) =>
            {
                validation = validation + 1;
            };
            spListItem.ItemSetStringObject = (_, __) =>
            {
                validation = validation + 1;
            };
            spListItem.Update = () =>
            {
                validation = validation + 1;
            };
            spListItem.Delete = () =>
            {
                validation = validation + 1;
            };

            PublishTasksShim();
            SetFieldsOrProperties();
            privateObject.SetFieldOrProperty("hshCurTasks", nonPublicInstance, currentTasksHashTable);
            privateObject.SetFieldOrProperty("hshTaskHierarchy", nonPublicInstance, taskHierarchy);
            privateObject.SetFieldOrProperty("arrFieldsToPublish", nonPublicInstance, fieldsToPublish);
            privateObject.SetFieldOrProperty("strTimesheetField", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("arrDelNewTasks", nonPublicInstance, new ArrayList() { guid });

            // Act
            privateObject.Invoke(
                PublishTasksMethodName,
                nonPublicInstance,
                new object[] { 1, pubType, guid, guid });

            // Assert
            validation.ShouldBe(6);
        }

        [TestMethod]
        public void GetHierarchy_WhenCalled_ReturnsString()
        {
            // Arrange
            var taskHierarchy = new Hashtable()
            {
                [guid] = string.Empty
            };
            var projectDataSet = new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet()
            {
                TaskGet = () => new ShimTaskDataTable()
            };

            ShimDataTable.AllInstances.SelectString = (_, __) =>
            {
                return new TaskRow[]
                {
                    new ShimTaskRow()
                    {
                        TASK_PARENT_UIDGet = () => guid,
                        TASK_UIDGet = () => new Guid(GuidString2),
                        TASK_NAMEGet = () => DummyString
                    }
                };
            };

            SetFieldsOrProperties();
            privateObject.SetFieldOrProperty("hshTaskHierarchy", nonPublicInstance, taskHierarchy);

            // Act
            var actual = (string)privateObject.Invoke(GetHierarchyMethodName, nonPublicInstance, new object[] { projectDataSet.Instance, new Guid(GuidString2) });
            var hierarchyOutput = (Hashtable)privateObject.GetFieldOrProperty("hshTaskHierarchy", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => hierarchyOutput.Count.ShouldBe(2));
        }

        private void DoPublishShims()
        {
            ShimCredentialCache.DefaultCredentialsGet = () => null;
            ShimWssInterop.AllInstances.ReadWssDataGuid = (_, __) => new ShimProjectWSSInfoDataSet()
            {
                ProjWssInfoGet = () => new ShimProjWssInfoDataTable()
                {
                    CountGet = () => 10,
                    ItemGetInt32 = index => new ShimProjWssInfoRow()
                    {
                        PROJECT_WORKSPACE_URLGet = () => DummyString
                    }
                }
            };
            ShimWssInterop.AllInstances.ReadWssSettings = _ => new ShimWssSettingsDataSet()
            {
                WssAdminGet = () => new ShimWssAdminDataTable()
                {
                    ItemGetInt32 = __ => new ShimWssAdminRow()
                    {
                        WADMIN_CURRENT_STS_SERVER_UIDGet = () => guid
                    }
                }
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            EPMLiveEnterprise.WebSvcResource.Fakes.ShimResource.AllInstances.ReadResourcesStringBoolean = (_, _1, _2) => new ShimResourceDataSet();
            ShimCustomFields.AllInstances.ReadCustomFieldsByEntityGuid = (_, __) => new ShimCustomFieldDataSet();
            ShimLookupTable.AllInstances.ReadLookupTablesStringBooleanInt32 = (_, _1, _2, _3) => new ShimLookupTableDataSet();
            ShimEntityCollection.EntitiesGet = () => new ShimEntityCollection()
            {
                TaskEntityGet = () => new ShimEntity()
                {
                    UniqueIdGet = () => GuidString
                }
            };
            ShimCustomFields.AllInstances.ReadCustomFieldsByEntityGuid = (_, __) => new ShimCustomFieldDataSet()
            {
                CustomFieldsGet = () => new ShimCustomFieldsDataTable()
            };
            ShimDataTable.AllInstances.SelectString = (_, __) => new CustomFieldsRow[]
            {
                new ShimCustomFieldsRow()
                {
                    MD_PROP_ROLLDOWN_TO_ASSNGet = () => true,
                    MD_PROP_IDGet = () => 111,
                    MD_PROP_UID_SECONDARYGet = () => guid,
                    MD_PROP_TYPE_ENUMGet = () => (byte)PropertyType.CostEng96,
                    IsMD_LOOKUP_TABLE_UIDNull = () => true
                }.Instance
            };
            ShimSPListItemCollection.AllInstances.GetEnumerator = __ => new List<SPListItem>()
            {
                new ShimSPListItem()
                {
                    ItemGetString = _ => DummyString,
                    UniqueIdGet = () => guid
                }.Instance,
                new ShimSPListItem()
                {
                    ItemGetString = key =>
                    {
                        if(key.Equals("transuid"))
                        {
                            return guid.ToString();
                        }
                        return string.Empty;
                    },
                    UniqueIdGet = () => guid
                }.Instance
            }.GetEnumerator();
            ShimPSContextInfo.ConstructorBooleanStringGuidGuidGuidString = (_, _1, _2, _3, _4, _5, _6) => new ShimPSContextInfo();
            ShimPSContextInfo.SerializeToStringPSContextInfo = _ => DummyString;
            ShimProjectWorkspaceSynch.ConstructorGuidStringGuidString = (_, _1, _2, _3, _5) => new ShimProjectWorkspaceSynch();
        }

        [TestMethod]
        public void DoPublish_WhenCalled_Publishes()
        {
            // Arrange
            var validation = 0;
            var readHit = -1;
            var today = DateTime.Now;
            var readOutput = new bool[]
            {
                true,
                false,
                true,
                true,
                false,
                true,
                false
            };
            var field1 = new ShimSPField()
            {
                InternalNameGet = () => "Int32",
                IdGet = () => guid,
                HiddenGet = () => false,
                ReadOnlyFieldGet = () => false,
                TypeGet = () => SPFieldType.Threading
            };
            var field2 = new ShimSPField()
            {
                InternalNameGet = () => "Int64",
                IdGet = () => guid,
                HiddenGet = () => false,
                ReadOnlyFieldGet = () => false,
                TypeGet = () => SPFieldType.Threading
            };
            var fieldList = new List<SPField>()
            {
                field1.Instance,
                field2.Instance
            };

            dataReader.Read = () =>
            {
                readHit = readHit + 1;
                return readOutput[readHit];
            };
            dataReader.GetInt32Int32 = _ => 1;
            dataReader.IsDBNullInt32 = _ => false;
            dataReader.GetGuidInt32 = _ => guid;
            dataReader.GetStringInt32 = _ => string.Empty;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => fieldList.GetEnumerator();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validation = validation + 1;
                return 1;
            };
            ShimProjectWorkspaceSynch.AllInstances.setUpGroups = _ =>
            {
                validation = validation + 1;
            };
            ShimProjectWorkspaceSynch.AllInstances.processTaskCenter = _ =>
            {
                validation = validation + 1;
            };
            ShimProjectWorkspaceSynch.AllInstances.processProjectCenter = _ =>
            {
                validation = validation + 1;
            };
            ShimProjectWorkspaceSynch.AllInstances.processResources = _ =>
            {
                validation = validation + 1;
            };
            ShimDbDataAdapter.AllInstances.FillDataSet = (DbDataAdapter instance, DataSet dataSet) =>
            {
                dataSet.Tables.Add(new DataTable());
                return 1;
            };
            ShimPortfolioEngineAPI.AllInstances.ExecuteStringString = (_, _1, xmlString) => string.Empty;
            EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject.AllInstances.ReadProjectGuidDataStoreEnum = (_, _1, _2) => new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet()
            {
                AssignmentGet = () => new ShimAssignmentDataTable()
                {
                    GetEnumerator = () => new List<AssignmentRow>()
                    {
                        new ShimAssignmentRow()
                        {
                            ASSN_START_DATEGet = () => today,
                            ASSN_FINISH_DATEGet = () => today,
                            ASSN_WORKGet = () => 6,
                            ASSN_UNITSGet = () => 1
                        }
                    }.GetEnumerator()
                },
                TaskGet = () => new ShimTaskDataTable(),
                DependencyGet = () => new ShimDependencyDataTable(),
                TaskCustomFieldsGet = () => new ShimTaskCustomFieldsDataTable(),
                ProjectCustomFieldsGet = () => new ShimProjectCustomFieldsDataTable(),
                ProjectGet = () => new ShimProjectDataTable()
                {
                    ItemGetInt32 = __ => new ShimProjectRow()
                    {
                        PROJ_NAMEGet = () => DummyString,
                        PROJ_UIDGet = () => guid,
                        ProjectOwnerIDGet = () => guid
                    }
                }
            };
            DoPublishShims();

            // Act
            InvokeMethod(DoPublishMethodName, publicInstance, new object[] { });

            // Assert
            validation.ShouldBe(9);
        }
    }
}
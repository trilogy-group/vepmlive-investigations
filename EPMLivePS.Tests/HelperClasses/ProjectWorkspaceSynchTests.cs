using System;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Fakes;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPMLiveEnterprise.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveEnterprise;
using EPMLiveEnterprise.WebSvcCustomFields.Fakes;
using EPMLiveEnterprise.WebSvcLookupTables.Fakes;
using EPMLiveEnterprise.WebSvcProject.Fakes;
using EPMLiveEnterprise.WebSvcResource.Fakes;
using EPMLiveEnterprise.WebSvcLookupTables;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SharePoint.BusinessData.MetadataModel.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.BusinessData.Administration.Fakes;
using static EPMLiveEnterprise.WebSvcLookupTables.LookupTableDataSet;
using static EPMLiveEnterprise.WebSvcLookupTables.Fakes.ShimLookupTableDataSet;
using static EPMLiveEnterprise.WebSvcProject.ProjectDataSet;
using static EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectDataSet;
using static EPMLiveEnterprise.WebSvcProject.Fakes.ShimProjectRelationsDataSet;
using static EPMLiveEnterprise.WebSvcCustomFields.CustomFieldDataSet;
using static EPMLiveEnterprise.WebSvcResource.Fakes.ShimResourceDataSet;
using static EPMLiveEnterprise.WebSvcCustomFields.Fakes.ShimCustomFieldDataSet;
using Shouldly;

namespace EPMLivePS.Tests.HelperClasses
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ProjectWorkspaceSynchTests
    {
        private IDisposable _shimObject;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private ProjectWorkspaceSynch _projectWorkspaceSynch;
        private bool _loggerInvoked;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private const string DummyInternalName = "abc3";
        private const double DummyDouble = 1;

        private const string GetSchemaXml = "getSchemaXml";
        private const string ProcessTaskCenter = "processTaskCenter";
        private const string IsCalculated = "isCalculated";
        private const string SetUpGroups = "setUpGroups";
        private const string GetSiteGroup = "GetSiteGroup";
        private const string ProcessProjectCenter = "processProjectCenter";
        private const string ProcessResources = "processResources";
        private const string GetResourceIdForTask = "getResourceIdForTask";
        private const string GetResourceIdByEmail = "getResourceIdByEmail";
        private const string GetLookupDescription = "getLookupDescription";
        private const string GetResourceWssId = "getResourceWssId";

        [TestInitialize]
        public void TestInitialize()
        {
            _loggerInvoked = false;
            _shimObject = ShimsContext.Create();
            Setup();

            _projectWorkspaceSynch = new ProjectWorkspaceSynch(new Guid(), DummyString, new Guid(), DummyString);
            _privateObject = new PrivateObject(_projectWorkspaceSynch);
            InitializeSetup();
        }

        private void InitializeSetup()
        {
            Setup();
            ShimSPField.AllInstances.SchemaXmlGet = _ => DummyString;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();

            _privateObject.SetFieldOrProperty("pCf", new ShimCustomFields().Instance);
            _privateObject.SetFieldOrProperty("psiLookupTable", new ShimLookupTable().Instance);
            _privateObject.SetFieldOrProperty("cn", new SqlConnection());
            _privateObject.SetFieldOrProperty("myWebToPublish", new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty("psiProject", new ShimProject().Instance);
            _privateObject.SetFieldOrProperty("projectUid", new Guid());
            _privateObject.SetFieldOrProperty("psiResource", new ShimResource().Instance);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void GetSchemaXmlSetup()
        {
            var count = 0;
            ShimDataTable.AllInstances.SelectString = (_, _1) =>
            {
                count++;
                if (count == 1)
                {
                    return new CustomFieldsRow[] { };
                }
                else
                {
                    return new CustomFieldsRow[] { new ShimCustomFieldsRow() };
                }
            };
            var counter = 0;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                counter++;
                if (counter != 3)
                {
                    codeToRun();
                }
            };
            ShimLookupTable.AllInstances.ReadLookupTablesByUidsAsyncGuidArrayBooleanInt32 = (_, _1, _2, _3) => new ShimLookupTableDataSet();
            var listLookupTableTreesRow = new List<LookupTableTreesRow>()
            {
                new ShimLookupTableTreesRow()
            };
            var shmLookupTableTreesDataTable = new ShimLookupTableTreesDataTable();
            shmLookupTableTreesDataTable.Bind(listLookupTableTreesRow);
            ShimLookupTableDataSet.AllInstances.LookupTableTreesGet = _ => shmLookupTableTreesDataTable;
        }

        [TestMethod]
        public void GetSchemaXml_SPFieldAndFieldNameDsLengthIsZeroPSDataTypeIsTwentyOne_ReturnXMLString()
        {
            // Arrange
            var parameters = new object[] { new ShimSPField().Instance, DummyString };
            _projectWorkspaceSynch = new ProjectWorkspaceSynch();
            ShimCustomFieldsRow.AllInstances.MD_PROP_TYPE_ENUMGet = _ => 21;
            GetSchemaXmlSetup();

            // Act
            var actualResult = _privateObject.Invoke(
                GetSchemaXml,
                parameters);

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetSchemaXml_SPFieldAndFieldNameDsLengthIsZeroPSDataTypeIsFifteen_ReturnXMLString()
        {
            // Arrange
            var parameters = new object[] { new ShimSPField().Instance, DummyString };
            ShimCustomFieldsRow.AllInstances.MD_PROP_TYPE_ENUMGet = _ => 15;
            GetSchemaXmlSetup();

            // Act
            var actualResult = _privateObject.Invoke(
                GetSchemaXml,
                parameters);

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        private void ProcessTaskCenterSetup()
        {
            var count = 0;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                count++;
                if (count == 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            };
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (_, _1) => null;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => DummyString;
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (_, _1) => true;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, _1) => false;
            ShimSPFieldCollection.AllInstances.CreateNewFieldStringString = (_, _1, _2) => new ShimSPFieldText();
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPField();
            var listSPField = new List<SPField>() { new ShimSPField() };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Bind(listSPField);
            ShimDataTable.AllInstances.SelectString = (_, _1) => new CustomFieldsRow[] { new ShimCustomFieldsRow() };
            ShimSPFieldCollection.AllInstances.ItemGetGuid = (_, _1) => new ShimSPField();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            ShimProjectWorkspaceSynch.AllInstances.getSchemaXmlSPFieldString = (_, _1, _2) => DummyString;
        }

        [TestMethod]
        public void ProcessTaskCenter_InputIsNullReaderIsDateTime_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "DATETIME";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessTaskCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessTaskCenter_InputIsNullReaderIsDateTimeAndInternalNameNotMatched_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "DATETIME";
            ShimSPField.AllInstances.InternalNameGet = _ => "DATETIME";

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessTaskCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessTaskCenter_InputIsNullReaderIsDuration_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "DURATION";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessTaskCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessTaskCenter_InputIsNullReaderIsNumber_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "NUMBER";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessTaskCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessTaskCenter_InputIsNullReaderIsCurrency_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "CURRENCY";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessTaskCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessTaskCenter_InputIsNullReaderIsBoolean_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "BOOLEAN";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessTaskCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessTaskCenter_InputIsNullReaderIsChoice_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "CHOICE";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessTaskCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void IsCalculated_CustomFieldDataSetAndFieldNameIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new ShimCustomFieldDataSet().Instance, DummyString };
            ShimDataTable.AllInstances.SelectString = (_, _1) => new CustomFieldsRow[] { new ShimCustomFieldsRow() };
            ShimCustomFieldsRow.AllInstances.MD_PROP_FORMULAGet = _ => DummyString;

            // Act
            var actualResult = (bool)_privateObject.Invoke(
                IsCalculated,
                parameters);

            // Assert
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void IsCalculated_CustomFieldDataSetAndFieldNameIsNotNull_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { new ShimCustomFieldDataSet().Instance, DummyString };
            ShimDataTable.AllInstances.SelectString = (_, _1) => new CustomFieldsRow[] { };

            // Act
            var actualResult = (bool)_privateObject.Invoke(
                IsCalculated,
                parameters);

            // Assert
            actualResult.ShouldBe(false);
        }

        [TestMethod]
        public void SetUpGroups_InputIsNull_ThrowException()
        {
            // Arrange
            var parameters = new object[] { };
            ShimSPUserCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPUser();
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.NewGuid();
            ShimCoreFunctions.getConfigSettingSPWebString = (_, _1) => DummyString;
            ShimSPWeb.AllInstances.Update = _ => { };

            // Act
            Action act = () => _privateObject.Invoke(
                SetUpGroups,
                parameters);

            // Assert
            Should.Throw<Exception>(act);
        }

        [TestMethod]
        public void GetSiteGroup_SPWebAndSpUserIsNotNull_ReturnSPGroup()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance, DummyString, new ShimSPUser().Instance };
            ShimSPWeb.AllInstances.SiteGroupsGet = _ => new ShimSPGroupCollection();
            ShimSPGroupCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPGroup();

            // Act
            var actualResult = (SPGroup)_privateObject.Invoke(
                GetSiteGroup,
                parameters);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ID.ShouldBe(0),
                () => actualResult.Description.ShouldBeNull());
        }

        private void ProcessProjectCenterSetup()
        {
            var count = 0;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                count++;
                if (count == 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            };
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, _1) => false;
            ShimSPFieldCollection.AllInstances.CreateNewFieldStringString = (_, _1, _2) => new ShimSPFieldText();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
        }

        [TestMethod]
        public void ProcessProjectCenter_InputIsNullDataReaderIsDatetime_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ProcessProjectCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "DATETIME";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessProjectCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessProjectCenter_InputIsNullDataReaderIsDuration_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ProcessProjectCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "DURATION";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessProjectCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessProjectCenter_InputIsNullDataReaderIsNumber_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ProcessProjectCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "NUMBER";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessProjectCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessProjectCenter_InputIsNullDataReaderIsCurrency_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ProcessProjectCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "CURRENCY";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessProjectCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessProjectCenter_InputIsNullDataReaderIsBoolean_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ProcessProjectCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "BOOLEAN";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessProjectCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessProjectCenter_InputIsNullDataReaderIsChoice_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ProcessProjectCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "CHOICE";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyInternalName;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessProjectCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessProjectCenter_InputIsNullInternalNameNotMatched_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessTaskCenterSetup();
            ProcessProjectCenterSetup();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => "CHOICE";
            ShimSPField.AllInstances.InternalNameGet = _ => "CHOICE";

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessProjectCenter,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        private void ProcessResourcesSetup()
        {
            var count = 0;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                count++;
                if (count == 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            };
            ShimSPWeb.AllInstances.AssociatedMemberGroupGet = _ => new ShimSPGroup();
            ShimSPWeb.AllInstances.AssociatedVisitorGroupGet = _ => new ShimSPGroup();
            ShimProjectDataSet.Constructor = _ => new ShimProjectDataSet();
            ShimProject.AllInstances.ReadProjectGuidDataStoreEnum = (_, _1, _2) => new ShimProjectDataSet();
            var listProjectResourceRow = new List<ProjectResourceRow>() { new ShimProjectResourceRow() };
            ShimProjectDataSet.AllInstances.ProjectResourceGet = _ => new ShimProjectResourceDataTable().Bind(listProjectResourceRow);
        }

        [TestMethod]
        public void ProcessResources_InputIsNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessResourcesSetup();
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, _1) => DummyInt;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessResources,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessResources_InputIsNullResourceEmailIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessResourcesSetup();
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, _1) => DummyInt;
            ShimProjectResourceRow.AllInstances.RES_WORKGet = _ => DummyDouble;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessResources,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessResources_InputIsNullTypeIsThree_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ProcessResourcesSetup();
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, _1) => 3;
            ShimProjectResourceRow.AllInstances.RES_WORKGet = _ => DummyDouble;
            var listTaskRow = new List<TaskRow>() { new ShimTaskRow() };
            ShimProjectDataSet.AllInstances.TaskGet = _ => new ShimTaskDataTable().Bind(listTaskRow);
            ShimProjectWorkspaceSynch.AllInstances.getResourceIdForTaskGuidProjectDataSet = (_, _1, _2) => DummyInt;
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, _1) => new ShimSPUser();

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessResources,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetResourceIdForTask_TaskIdAndProjectDataSetIsNotNull_ReturnTaskId()
        {
            // Arrange
            var parameters = new object[] { Guid.NewGuid(), new ShimProjectDataSet().Instance };
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => DummyString;
            ShimProjectDataSet.AllInstances.TaskCustomFieldsGet = _ => new ShimTaskCustomFieldsDataTable();
            ShimDataTable.AllInstances.SelectString = (_, _1) => new TaskCustomFieldsRow[]
            {
                new ShimTaskCustomFieldsRow()
                {
                    IsCODE_VALUENull = () => true
                }
            };
            ShimProjectWorkspaceSynch.AllInstances.getResourceIdByEmailString = (_, _1) => DummyInt;
            ShimTaskCustomFieldsRow.AllInstances.TEXT_VALUEGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetResourceIdForTask,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void GetResourceIdForTask_TaskIdAndProjectDataSetIsNotNullCodeValueIsFalse_ReturnTaskId()
        {
            // Arrange
            var parameters = new object[] { Guid.NewGuid(), new ShimProjectDataSet().Instance };
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => DummyString;
            ShimProjectDataSet.AllInstances.TaskCustomFieldsGet = _ => new ShimTaskCustomFieldsDataTable();
            ShimDataTable.AllInstances.SelectString = (_, _1) => new TaskCustomFieldsRow[]
            {
                new ShimTaskCustomFieldsRow()
                {
                    CODE_VALUEGet = () => Guid.NewGuid()
                }
            };
            ShimProjectWorkspaceSynch.AllInstances.getLookupDescriptionStringString = (_, _1, _2) => DummyString;
            ShimProjectWorkspaceSynch.AllInstances.getResourceIdByEmailString = (_, _1) => DummyInt;

            // Act
            var actualResult = _privateObject.Invoke(
                GetResourceIdForTask,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void GetResourceIdByEmail_EmailIsNotNull_ReturnEmailId()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimResourceDataSet.Constructor = _ => new ShimResourceDataSet();
            ShimResource.AllInstances.ReadResourcesStringBoolean = (_, _1, _2) => new ShimResourceDataSet();
            ShimResourcesDataTable.AllInstances.CountGet = _ => DummyInt;
            ShimResourcesDataTable.AllInstances.ItemGetInt32 = (_, _1) => new ShimResourcesRow()
            {
                RES_IS_WINDOWS_USERGet = () => true,
                RES_UIDGet = () => Guid.NewGuid()
            };
            ShimProjectWorkspaceSynch.AllInstances.getResourceWssIdGuid = (_, _1) => DummyInt;
            ShimResourceDataSet.AllInstances.ResourcesGet = _ => new ShimResourcesDataTable();

            // Act
            var actualResult = _privateObject.Invoke(
                GetResourceIdByEmail,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void GetLookupDescription_FieldNameAndIdIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            ShimCustomFieldDataSet.Constructor = _ => new ShimCustomFieldDataSet();
            ShimLookupTableDataSet.Constructor = _ => new ShimLookupTableDataSet();
            ShimCustomFields.AllInstances.ReadCustomFieldsByMdPropUidsGuidArrayBoolean = (_, _1, _2) => new ShimCustomFieldDataSet();
            ShimLookupTable.AllInstances.ReadLookupTablesByUidsGuidArrayBooleanInt32 = (_, _1, _2, _3) => new ShimLookupTableDataSet();
            ShimLookupTableDataSet.AllInstances.LookupTableTreesGet = _ => new ShimLookupTableTreesDataTable();
            ShimDataTable.AllInstances.SelectString = (_, _1) => new LookupTableTreesRow[]
            {
                new ShimLookupTableTreesRow()
                {
                    LT_VALUE_DESCGet = () => DummyString
                }
            };
            ShimCustomFieldDataSet.AllInstances.CustomFieldsGet = _ => new ShimCustomFieldsDataTable();
            ShimCustomFieldsDataTable.AllInstances.ItemGetInt32 = (_, _1) => new ShimCustomFieldsRow()
            {
                MD_LOOKUP_TABLE_UIDGet = () => Guid.NewGuid()
            };

            // Act
            var actualResult = _privateObject.Invoke(
                GetLookupDescription,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetResourceWssId_GuidIsNotNull_ReturnId()
        {
            // Arrange
            var parameters = new object[] { Guid.NewGuid() };
            ShimResourceDataSet.Constructor = _ => new ShimResourceDataSet();
            ShimResource.AllInstances.ReadResourceGuid = (_, _1) => new ShimResourceDataSet();
            ShimResourceDataSet.AllInstances.ResourcesGet = _ => new ShimResourcesDataTable();
            ShimResourcesDataTable.AllInstances.CountGet = _ => DummyInt;
            ShimResourcesDataTable.AllInstances.ItemGetInt32 = (_, _1) => new ShimResourcesRow()
            {
                RES_IS_WINDOWS_USERGet = () => true,
                WRES_ACCOUNTGet = () => DummyString
            };
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPUser
            {
                IDGet = () => DummyInt
            };

            // Act
            var actualResult = _privateObject.Invoke(
                GetResourceWssId,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyInt);
        }

        private void Setup()
        {
            ShimSPSite.ConstructorGuid = (_, _1) => new ShimSPSite();
            ShimSPSite.AllInstances.AllowUnsafeUpdatesSetBoolean = (_, __) => { };
            ShimSPSite.ConstructorString = (_, _1) => new ShimSPSite();
            ShimSPSite.AllInstances.UrlGet = _ => new Uri("http://localhost/").ToString();
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPPersistedObject.AllInstances.IdGet = _ => new Guid();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimCustomFields.Constructor = _ => new ShimCustomFields();
            ShimLookupTable.Constructor = _ => new ShimLookupTable();
            EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject.Constructor = _ => new EPMLiveEnterprise.WebSvcProject.Fakes.ShimProject();
            EPMLiveEnterprise.WebSvcResource.Fakes.ShimResource.Constructor = _ => new EPMLiveEnterprise.WebSvcResource.Fakes.ShimResource();
            ShimCustomFieldDataSet.Constructor = _ => new ShimCustomFieldDataSet();
            ShimCustomFieldDataSet.AllInstances.CustomFieldsGet = _ => new ShimCustomFieldsDataTable();
            ShimLookupTableDataSet.Constructor = _ => new ShimLookupTableDataSet();
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, _1) => new ShimXmlNode(new ShimXmlElement());

            ShimCustomFields.AllInstances.ReadCustomFieldsByEntityGuid = (_, _1) => new ShimCustomFieldDataSet();
            ShimSPSite.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.Close = _ => { };
            ShimXmlDocument.Constructor = _ => new ShimXmlDocument();
            ShimXmlDocument.AllInstances.LoadXmlString = (_, _1) => { };
            ShimSPSite.AllInstances.AllowUnsafeUpdatesGet = _ => true;
            ShimCoreFunctions.getConnectionStringGuid = _ => new Guid().ToString();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPPersistedObject.AllInstances.IdGet = _ => new Guid();
            ShimSPSite.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();
            ShimSPFeatureCollection.AllInstances.AddGuid = (_, _1) => new ShimSPFeature();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.AddSPField = (_, _1) => DummyString;
            ShimSPList.AllInstances.Update = _ => { };
            ShimSPWeb.AllInstances.UrlGet = _ => DummyString;
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, _1) => DummyString;
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (_, _1) => true;

            ShimSqlConnection.ConstructorString = (_, _1) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, _1, _2) => new ShimSqlConnection();
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Close = _ => { };
        }
    }
}

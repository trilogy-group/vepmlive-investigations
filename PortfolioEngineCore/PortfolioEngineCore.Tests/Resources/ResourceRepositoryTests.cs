using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace PortfolioEngineCore.Tests.Resources
{
    using System.Globalization;
    using Infrastructure.Fields.Fakes;
    using PortfolioEngineCore.Fakes;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ResourceRepositoryTests
    {
        private IDisposable shimsContext;
        private ResourceRepository resourceRepository;
        private PrivateObject privateObject;
        private PrivateType privateType;
        private static bool GetCustomFieldValuesWasCalled = false;
        private static bool GetMultipleValueFieldValuesWasCalled = false;
        private const string CalculateTableFieldNameMethodName = "CalculateTableFieldName";
        private const string AddPermission = "AddPermission";
        private const string DeletePermission = "DeletePermission";
        private const string GenerateNewResourceId = "GenerateNewResourceId";
        private string GetAvailableCustomFields = "GetAvailableCustomFields";
        private string GetGeneralInformationMethodName = "GetGeneralInformation";
        private const string DummyString = "DummyString";
        private string GetLookupValuesMethodName = "GetLookupValues";
        private string GetQueryFieldsMethodName = "GetQueryFields";
        private string GetResourceCustomFieldValuesMethodName = "GetResourceCustomFieldValues";
        private string GetUnboxedValueMethodName = "GetUnboxedValue";
        private string InsertBasicResourceInformationMethodName = "InsertBasicResourceInformation";
        private string UpdateCostCategoryMethodName = "UpdateCostCategory";
        private string ValidateResourceMethodName = "ValidateResource";
        private string GetCustomFieldsMethodName = "GetCustomFields";
        private string UpdateGeneralInformationMethodName = "UpdateGeneralInformation";
        private string GetMultiValueCustomFieldValuesMethodName = "GetMultiValueCustomFieldValues";
        private string IsResourceInUseMethodName = "IsResourceInUse";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            resourceRepository = new ResourceRepository(new SqlConnection());
            privateObject = new PrivateObject(resourceRepository);
            privateType = new PrivateType(typeof(ResourceRepository));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
        }

        [TestMethod]
        public void Constructor_WithValidParameter_ShouldCreateInstance()
        {
            // Arrange
            var connection = new SqlConnection();

            // Act
            resourceRepository = new ResourceRepository(connection);
            privateObject = new PrivateObject(resourceRepository);
            var objectConnection = privateObject.GetFieldOrProperty("_sqlConnection") as SqlConnection;

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => resourceRepository.ShouldNotBeNull(),
                () => objectConnection.ShouldNotBeNull(),
                () => objectConnection.ShouldBe(connection));
        }


        //[TestMethod]
        //public void DeleteEntity_Should_ThrowsException()
        //{
        //    // Arrange, Act
        //    Action action = () => resourceRepository.Delete(new Resource());

        //    // Assert
        //    action.ShouldThrow<NotImplementedException>();

        //}

        [TestMethod]
        public void Delete_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "EPG_SP_DeleteResource";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };

            // Act
            resourceRepository.Delete(new Resource(), 1);

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void AddPermission_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "INSERT INTO dbo.EPG_GROUP_MEMBERS (MEMBER_UID, GROUP_ID) VALUES(@ResourceId, @GroupId)";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };
            var permissionGroup = new KeyValuePair<int, string>();
            var resource = new Resource();

            // Act
            privateObject.Invoke(AddPermission, resource, permissionGroup);

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void CalculateTableFieldName_ResourceINT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ResourceINT, "EPGC_RESOURCE_INT_VALUES", "RI_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ResourceTEXT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ResourceTEXT, "EPGC_RESOURCE_TEXT_VALUES", "RT_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ResourceDEC_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ResourceDEC, "EPGC_RESOURCE_DEC_VALUES", "RC_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ResourceNTEXT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ResourceNTEXT, "EPGC_RESOURCE_NTEXT_VALUES", "RN_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ResourceDATE_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ResourceDATE, "EPGC_RESOURCE_DATE_VALUES", "RD_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ResourceMV_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ResourceMV, "EPGC_RESOURCE_MV_VALUES", "MVR_UID");
        }

        [TestMethod]
        public void CalculateTableFieldName_PortfolioINT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.PortfolioINT, "EPGP_PROJECT_INT_VALUES", "PI_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_PortfolioTEXT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.PortfolioTEXT, "EPGP_PROJECT_TEXT_VALUES", "PT_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_PortfolioDEC_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.PortfolioDEC, "EPGP_PROJECT_DEC_VALUES", "PC_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_PortfolioNTEXT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.PortfolioNTEXT, "EPGP_PROJECT_NTEXT_VALUES", "PN_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_PortfolioDATE_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.PortfolioDATE, "EPGP_PROJECT_DATE_VALUES", "PD_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_Program_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.Program, "EPGP_PI_PROGS", "PROG_UID");
        }

        [TestMethod]
        public void CalculateTableFieldName_ProjectINT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ProjectINT, "EPGX_PROJ_INT_VALUES", "XI_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ProjectTEXT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ProjectTEXT, "EPGX_PROJ_TEXT_VALUES", "XT_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ProjectDEC_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ProjectDEC, "EPGX_PROJ_DEC_VALUES", "XC_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ProjectNTEXT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ProjectNTEXT, "EPGX_PROJ_NTEXT_VALUES", "XN_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ProjectDATE_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ProjectDATE, "EPGX_PROJ_DATE_VALUES", "XD_{0:000}");
        }

        [TestMethod]
        public void CalculateTableFieldName_ProgramText_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.ProgramText, "EPGP_PI_PROGS", "PROG_PI_TEXT{0:0}");
        }

        [TestMethod]
        public void CalculateTableFieldName_TaskWIINT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.TaskWIINT, "EPGP_PI_WORKITEMS", "WORKITEM_FLAG{0:0}");
        }

        [TestMethod]
        public void CalculateTableFieldName_TaskWITEXT_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.TaskWITEXT, "EPGP_PI_WORKITEMS", "WORKITEM_CTEXT{0:0}");
        }

        [TestMethod]
        public void CalculateTableFieldName_TaskWIDEC_ExecutesCorrectly()
        {
            CalculateTableFieldName(CustomFieldTable.TaskWIDEC, "EPGP_PI_WORKITEMS", "WORKITEM_NUMBER{0:0}");
        }

        private void CalculateTableFieldName(CustomFieldTable customFieldTable, string expectedTableName, string format)
        {
            // Arrange
            const int FieldId = 1;
            var expecteFieldName = string.Format(format, FieldId);
            var tableId = (int)customFieldTable;
            var tableName = string.Empty;
            var fieldName = string.Empty;
            var args = new object[] { FieldId, tableId, tableName, fieldName };

            // Act
            privateType.InvokeStatic(CalculateTableFieldNameMethodName, args);
            tableName = args[2] as string;
            fieldName = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => tableName.ShouldNotBeNullOrEmpty(),
                () => tableName.ShouldBe(expectedTableName),
                () => fieldName.ShouldNotBeNullOrEmpty(),
                () => fieldName.ShouldBe(expecteFieldName));
        }

        [TestMethod]
        public void DeletePermission_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "DELETE FROM dbo.EPG_GROUP_MEMBERS WHERE MEMBER_UID = @ResourceId AND GROUP_ID = @GroupId";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };
            var permissionGroup = new KeyValuePair<int, string>();
            var resource = new Resource();

            // Act
            privateObject.Invoke(DeletePermission, resource, permissionGroup);

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void GenerateNewResourceId_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "SELECT dbo.PFE_FN_GenerateNewResourceId()";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };
            var permissionGroup = new KeyValuePair<int, string>();
            var resource = new Resource();

            // Act
            var result = privateObject.Invoke(GenerateNewResourceId) as int?;

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldBe(ExpectedCommand),
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(1));
        }

        [TestMethod]
        public void GetAvailableCustomFields_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "EPG_SP_ReadResCFields";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                commandExecuted = command.CommandText;
                return new ShimSqlDataReader();
            };
            ShimDataTable.AllInstances.LoadIDataReader = (_, reader) => { };

            // Act
            var result = privateObject.Invoke(GetAvailableCustomFields) as DataTable;

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldBe(ExpectedCommand),
                () => result.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetGeneralInformation_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            var args = new object[] { 1, new Resource() };
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                HasRowsGet = () => true
            };
            ShimUtilities.GetInt32SafelySqlDataReaderString = (_, name) => 1;
            ShimUtilities.GetStringSafelySqlDataReaderString = (_, name) => DummyString;
            ShimUtilities.GetByteSafelySqlDataReaderString = (_, name) => new byte();
            ShimUtilities.GetDateTimeSafelySqlDataReaderString = (_, name) => DateTime.Now;

            // Act
            privateObject.Invoke(GetGeneralInformationMethodName, args);
            var resource = args[1] as Resource;

            // Assert
            resource.ShouldSatisfyAllConditions(
                () => resource.ShouldNotBeNull(),
                () => resource.Name.ShouldBe(DummyString),
                () => resource.Id.ShouldBe(1));
        }

        [TestMethod]
        public void GetGeneralInformation_HasRowsFalse_ThrowsException()
        {
            // Arrange
            var args = new object[] { 1, new Resource() };
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                HasRowsGet = () => false
            };
            ShimUtilities.GetInt32SafelySqlDataReaderString = (_, name) => 1;
            ShimUtilities.GetStringSafelySqlDataReaderString = (_, name) => DummyString;
            ShimUtilities.GetByteSafelySqlDataReaderString = (_, name) => new byte();
            ShimUtilities.GetDateTimeSafelySqlDataReaderString = (_, name) => DateTime.Now;

            // Act
            Action action = () => privateObject.Invoke(GetGeneralInformationMethodName, args);

            // Assert
            action.ShouldThrow<PFEException>();
        }

        [TestMethod]
        public void GetLookupValues_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "SELECT LV_UID, LV_FULLVALUE FROM dbo.EPGP_LOOKUP_VALUES ORDER BY LV_UID";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                commandExecuted = command.CommandText;
                return new ShimSqlDataReader();
            };
            ShimDataTable.AllInstances.LoadIDataReader = (_, reader) => { };

            // Act
            var result = privateObject.Invoke(GetLookupValuesMethodName) as DataTable;

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldBe(ExpectedCommand),
                () => result.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetQueryFields_Should_ExecuteCorrectly()
        {
            // Arrange
            var singleValues = new List<string>();
            var multiValues = new List<string>();
            var dataTable = new DataTable();
            var args = new object[] { singleValues, multiValues, dataTable };

            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 101
                    },
                    new ShimDataRow
                    {
                        ItemGetString = name => 151
                    }
                }.GetEnumerator()
            };

            // Act
            privateObject.Invoke(GetQueryFieldsMethodName, args);
            multiValues = args[1] as List<string>;
            singleValues = args[0] as List<string>;

            // Assert
            privateObject.ShouldSatisfyAllConditions(
                () => singleValues.ShouldNotBeNull(),
                () => singleValues.ShouldNotBeEmpty(),
                () => multiValues.ShouldNotBeNull(),
                () => multiValues.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void GetResourceCustomFieldValues_Should_ExecuteCorrectly()
        {
            // Arrange
            var dictionary = new Dictionary<string, List<string>>();
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                GetOrdinalString = name => 1,
                GetStringInt32 = index => DummyString

            };
            var args = new object[] {
                new Resource(),
                dictionary,
                DummyString,
                DummyString,
                DummyString,
                DummyString
            };

            // Act
            privateObject.Invoke(GetResourceCustomFieldValuesMethodName, args);

            // Assert
            dictionary.ShouldSatisfyAllConditions(
                () => dictionary.ShouldNotBeNull(),
                () => dictionary.ShouldNotBeEmpty(),
                () => dictionary.Values.First().ShouldNotBeEmpty());
        }

        [TestMethod]
        public void GetUnboxedValue_Byte0_ReturnsExpectedValue()
        {
            // Arrange
            var value = (object)((byte)0);

            // Act
            var result = privateObject.Invoke(GetUnboxedValueMethodName, value, value.GetType());
            var intResult = result as byte?;

            // Assert
            intResult.ShouldNotBeNull();
            intResult.Value.ToString().ShouldBe("0");
        }

        [TestMethod]
        public void GetUnboxedValue_Byte1_ReturnsExpectedValue()
        {
            // Arrange
            var value = (object)((byte)1);

            // Act
            var result = privateObject.Invoke(GetUnboxedValueMethodName, value, value.GetType());
            var intResult = result as byte?;

            // Assert
            intResult.ShouldNotBeNull();
            intResult.Value.ToString().ShouldBe("1");
        }

        [TestMethod]
        public void GetUnboxedValue_DefaultType_ReturnsExpectedValue()
        {
            // Arrange
            var value = (object)DummyString;

            // Act
            var result = privateObject.Invoke(GetUnboxedValueMethodName, value, value.GetType()) as string;

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void InsertBasicResourceInformation_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "INSERT INTO dbo.EPG_RESOURCES (WRES_ID, RES_NAME, WRES_EXT_UID) VALUES(@Id, @Name, @ExtId)";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };
            var resource = new Resource();

            // Act
            privateObject.Invoke(InsertBasicResourceInformationMethodName, resource);

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void FindIdBy_Should_ReturnExpectedvalue()
        {
            // Arrange
            const string ExpectedCommand = "PFE_SP_GetResourceIdBy";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };
            var resource = new Resource();

            // Act
            var result = resourceRepository.FindIdBy(DummyString, DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(1),
                () => commandExecuted.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void UpdateCostCategory_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "PFE_SP_UpdateResourceCostCategory";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };
            var resource = new Resource();

            // Act
            privateObject.Invoke(UpdateCostCategoryMethodName, resource, 1);

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void FindById_ResourceIdNull_ThrowsException()
        {
            // Arrange
            ShimResourceRepository.AllInstances.FindIdByStringObject = (_, key, value) => null;

            // Act
            Action action = () => resourceRepository.FindById(1);

            // Assert
            action.ShouldThrow<PFEException>();
        }

        [TestMethod]
        public void FindById_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimResourceRepository.AllInstances.FindIdByStringObject = (_, key, value) => 1;
            ShimResourceRepository.AllInstances.GetGeneralInformationInt32ResourceRef = GetGeneralInformation;
            ShimResourceRepository.AllInstances.GetGroupsInt32ResourceRef = GetGeneralInformation;
            ShimResourceRepository.AllInstances.GetCustomFieldsInt32ResourceRef = GetGeneralInformation;

            // Act
            var result = resourceRepository.FindById(1);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void Add_Should_ExecuteCorrectly()
        {
            // Arrange
            var updateWasCalled = false;
            var insertBasicResourceInformationWasCalled = false;
            ShimResourceRepository.AllInstances.ValidateResourceResource = (_, resource) => { };
            ShimResourceRepository.AllInstances.GenerateNewResourceId = _ => 1;
            ShimResourceRepository.AllInstances.InsertBasicResourceInformationResource = (_, resource) =>
            {
                insertBasicResourceInformationWasCalled = true;
            };
            ShimResourceRepository.AllInstances.UpdateResource = (_, resource) =>
            {
                updateWasCalled = true;
            };
            ShimResource.AllInstances.IdGet = _ => 1;

            // Act
            var result = resourceRepository.Add(new Resource());

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(1),
                () => insertBasicResourceInformationWasCalled.ShouldBeTrue(),
                () => updateWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void ValidateResource_WithValidResource_NotThrowException()
        {
            // Arrange
            var resource = new ShimResource
            {
                ValidateIListOfStringOut = ValidateResource,
                IsGenericGet = () => 0,
                EmailGet = () => DummyString,
                IdGet = () => 1
            }.Instance;
            ShimResourceRepository.AllInstances.FindIdByStringObject = (_, key, value) => 1;

            // Act
            Action action = () => privateObject.Invoke(ValidateResourceMethodName, resource);

            // Assert
            action.ShouldNotThrow();
        }

        [TestMethod]
        public void ValidateResource_WithInvalidResource_ShouldThrowException()
        {
            // Arrange
            var resource = new ShimResource
            {
                ValidateIListOfStringOut = ValidateResource,
                IsGenericGet = () => 0,
                EmailGet = () => DummyString,
                IdGet = () => 1
            }.Instance;
            ShimResourceRepository.AllInstances.FindIdByStringObject = (_, key, value) => 2;

            // Act
            Action action = () => privateObject.Invoke(ValidateResourceMethodName, resource);

            // Assert
            action.ShouldThrow<PFEException>();
        }

        [TestMethod]
        public void Update_Should_ExecuteCorrectly()
        {
            // Arrange
            var updateCustomFieldsWasCalled = false;
            var updateGroupsWasCalled = false;
            var updateCostCategoryWasCalled = false;
            var resource = new Resource
            {
                IsGeneric = 0
            };
            ShimResourceRepository.AllInstances.GetChangedPropertiesResource = (_, res) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1
                },
                SelectString = query => new DataRow[]
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => null
                    },
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }
            };
            ShimResourceRepository.AllInstances.ValidateResourceResource = (_, source) => { };
            ShimResourceRepository.AllInstances.UpdateGeneralInformationInt32DataTable = (_, id, properties) => { };
            ShimResourceRepository.AllInstances.UpdateCostCategoryResourceInt32 = (_, res, id) =>
            {
                updateCostCategoryWasCalled = true;
            };
            ShimResourceRepository.AllInstances.UpdateGroupsResourceDataRow = (_, res, row) =>
            {
                updateGroupsWasCalled = true;
            };
            ShimResourceRepository.AllInstances.UpdateCustomFieldsResourceDataRowArray = (_, source, fields) =>
            {
                updateCustomFieldsWasCalled = true;
            };

            // Act
            resourceRepository.Update(resource);

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => updateCustomFieldsWasCalled.ShouldBeTrue(),
                () => updateGroupsWasCalled.ShouldBeTrue(),
                () => updateCostCategoryWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void Update_ChangedPropertiesEmpty_NoActionTaken()
        {
            // Arrange
            var updateCustomFieldsWasCalled = false;
            var updateGroupsWasCalled = false;
            var updateCostCategoryWasCalled = false;
            var resource = new Resource
            {
                IsGeneric = 1
            };
            ShimResourceRepository.AllInstances.GetChangedPropertiesResource = (_, res) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 0
                }
            };
            ShimResourceRepository.AllInstances.ValidateResourceResource = (_, source) => { };
            ShimResourceRepository.AllInstances.UpdateGeneralInformationInt32DataTable = (_, id, properties) => { };
            ShimResourceRepository.AllInstances.UpdateCostCategoryResourceInt32 = (_, res, id) =>
            {
                updateCostCategoryWasCalled = true;
            };
            ShimResourceRepository.AllInstances.UpdateGroupsResourceDataRow = (_, res, row) =>
            {
                updateGroupsWasCalled = true;
            };
            ShimResourceRepository.AllInstances.UpdateCustomFieldsResourceDataRowArray = (_, source, fields) =>
            {
                updateCustomFieldsWasCalled = true;
            };

            // Act
            resourceRepository.Update(resource);

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => updateCustomFieldsWasCalled.ShouldBeFalse(),
                () => updateGroupsWasCalled.ShouldBeFalse(),
                () => updateCostCategoryWasCalled.ShouldBeFalse());
        }

        [TestMethod]
        public void GetCustomFields_Should_ExecuteCorrectly()
        {
            // Arrange
            var resource = new Resource();
            ShimResourceRepository.AllInstances.GetAvailableCustomFields = _ => new DataTable();
            ShimResourceRepository.AllInstances.GetQueryFieldsListOfStringRefListOfStringRefDataTableRef = GetQueryFields;
            ShimResourceRepository.AllInstances.GetCustomFieldValuesInt32ListOfStringDataTableResourceRef = GetCustomFieldValues;
            ShimResourceRepository.AllInstances.GetMultiValueCustomFieldValuesInt32DataTableResourceRef = GetMultipleValueFieldValues;

            // Act
            privateObject.Invoke(GetCustomFieldsMethodName, 1, resource);

            // Assert
            resourceRepository.ShouldSatisfyAllConditions(
                () => GetCustomFieldValuesWasCalled.ShouldBeTrue(),
                () => GetMultipleValueFieldValuesWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void GetResourceId_ResourceNotFound_ThrowsException()
        {
            // Arrange
            ShimResourceRepository.AllInstances.FindIdByStringObject = (_, key, value) => null;

            // Act
            Action action = () => resourceRepository.GetResourceId(1, DummyString, DummyString);

            // Assert
            action.ShouldThrow<PFEException>();
        }

        [TestMethod]
        public void GetResourceId_ResourceFound_ReturnsResourceId()
        {
            // Arrange
            const string ExpectedKey = "WRES_NT_ACCOUNT";
            const int ResourceId = 3;
            ShimResourceRepository.AllInstances.FindIdByStringObject = (_, key, value) =>
            {
                return key == ExpectedKey ? ResourceId : (int?)null;
            };

            // Act
            var result = resourceRepository.GetResourceId(1, DummyString, DummyString);

            // Assert
            result.ShouldBe(ResourceId);
        }

        [TestMethod]
        public void UpdateGeneralInformation_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "UPDATE dbo.EPG_RESOURCES SET";
            var commandExecuted = string.Empty;
            var changedProperties = new ShimDataTable
            {
                SelectString = query => new DataRow[]
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => DummyString
                    }
                }
            }.Instance;

            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };

            // Act
            privateObject.Invoke(UpdateGeneralInformationMethodName, 1, changedProperties);

            // Assert
            commandExecuted.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldContain(ExpectedCommand));
        }

        [TestMethod]
        public void GetMultiValueCustomFieldValues()
        {
            // Arrange
            var dataTable = new DataTable();
            var resource = new Resource();
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                GetOrdinalString = name => 1,
                GetInt32Int32 = index => 1
            };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name =>
                        {
                            if (name == "FA_FIELD_ID")
                            {
                                return 1;
                            }
                            else
                            {
                                return DummyString;
                            }
                        }
                    }
                }.GetEnumerator()
            };
            ShimFieldFactory.AllInstances.MakeInt32StringInt32 = (_, id, name, type) => new StubIField
            {
                SetValueObject = value => { }
            };

            // Act
            privateObject.Invoke(GetMultiValueCustomFieldValuesMethodName, 1, dataTable, resource);

            // Assert
            resource.ShouldSatisfyAllConditions(
                () => resource.CustomFields.ShouldNotBeNull(),
                () => resource.CustomFields.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void IsResourceInUse_Should_ReturnExpectedResult()
        {
            // Arrange
            const string ExpectedMessage = "This resource cannot be deleted. It is used as follows";
            var resource = new Resource();
            var stringBuilder = new StringBuilder();
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                HasRowsGet = () => true,
                Read = () => ++count <= 1,
                GetOrdinalString = name => 1,
                GetStringInt32 = index => $"{DummyString}.{DummyString}"
            };
            
            // Act
            privateObject.Invoke(IsResourceInUseMethodName, resource, stringBuilder, 1);
            var result = stringBuilder.ToString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage),
                () => result.ShouldContain(DummyString));


        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private void GetMultipleValueFieldValues(ResourceRepository repository, int id, DataTable dataTable, ref Resource resource)
        {
            GetMultipleValueFieldValuesWasCalled = true;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private void GetCustomFieldValues(ResourceRepository repository, int id, List<string> queryFields, DataTable dataTable, ref Resource resource)
        {
            GetCustomFieldValuesWasCalled = true;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private void GetQueryFields(
            ResourceRepository resourceRepo,
            ref List<string> singleValueQueryFields,
            ref List<string> multiValueQueryFields, ref DataTable dataTable)
        {
            singleValueQueryFields = new List<string> { DummyString };
            multiValueQueryFields = new List<string> { DummyString };
        }

        private bool ValidateResource(out IList<string> errorMessages)
        {
            errorMessages = new List<string>();
            return true;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private void GetGeneralInformation(ResourceRepository repo, int id, ref Resource resource)
        {
            resource = new Resource();
        }
    }
}

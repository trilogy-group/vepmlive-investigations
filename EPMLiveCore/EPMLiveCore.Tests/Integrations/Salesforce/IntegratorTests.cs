using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Net.Fakes;
using EPMLiveCore.Integrations.Salesforce;
using EPMLiveCore.Integrations.Salesforce.Fakes;
using EPMLiveCore.SalesforcePartnerService;
using EPMLiveIntegration;
using EPMLiveIntegration.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Integrations.Salesforce
{
    [TestClass, ExcludeFromCodeCoverage]
    public class IntegratorTests
    {
        private IDisposable _shimsContext;
        private Integrator _testEntity;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private IList<string> _actualLogMessage;
        private ShimIntegrationLog _integrationLog;
        private WebProperties _webProperties;
        private Hashtable _properties;

        private const string DummyString = "DummyString";
        private const string DummyUsername = "DummyUsername";
        private const string DummyPassword = "DummyPassword";
        private const string DummySecurityToken = "DummySecurityToken";
        private const string DummyDeleteErrorMessage = "DummyDeleteErrorMessage";
        private static readonly DateTime DummyDateTime = new DateTime(2018, 1, 1);
        private const string ObjectKey = "Object";

        private const string SalesforceIdID = "ID";
        private const string SalesforceId10 = "10";
        private const string SalesforceId13 = "13";
        private const string SalesforceId20 = "20";
        private const string SharePointID = "SPID";
        private const string SharePointID11 = "11";
        private const string SharePointID14 = "14";
        private const string FieldId = "id";
        private const string FieldLogin = "login";
        private const string TransactionTypeInsert = "1";
        private const string TransactionTypeUpdate = "2";
        private const string TransactionTypeDelete = "3";
        private const string TransactionTypeFailed = "4";
        private const string ExceptedLogAllowDeleteIntFalse = "Salesforce delete is not allowed.";
        private const string ExceptedLogIsSyncEnabledFalse = "All synchronizations are currently disabled.";
        private const string ExceptionMessageObjectReference = "Object reference not set to an instance of an object.";
        private const string ExceptionNoRecordsFound = "No records found";

        [TestInitialize]
        public void Initialize()
        {
            _shimsContext = ShimsContext.Create();
            _testEntity = new Integrator();
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(Integrator));

            _actualLogMessage = new List<string>();
            _integrationLog = new ShimIntegrationLog()
            {
                LogMessageStringIntegrationLogType = (log, level) => _actualLogMessage.Add(log)
            };

            _properties = new Hashtable()
            {
                { "AllowDeleteInt", "true" },
                { "Username", DummyUsername },
                { "Password", DummyPassword },
                { "SecurityToken", DummySecurityToken }
            };

            _webProperties = new WebProperties()
            {
                Properties = _properties
            };

            ShimWebClient.AllInstances.UploadValuesStringStringNameValueCollection =
                (_, address, method, data) => null;
            ShimSfMedadataService.ConstructorStringStringStringStringBoolean =
                (_, username, password, token, namespaceApp, sandbox) => { };
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void DeleteItems_AllowDeleteIntFalse_FillLog()
        {
            // Arrange
            var webProperties = new WebProperties()
            {
                Properties = new Hashtable()
                {
                    { "AllowDeleteInt", "false" }
                }
            };

            var items = new DataTable("table");

            // Act
            var actualResult = _testEntity.DeleteItems(webProperties, items, _integrationLog);

            // Assert
            _actualLogMessage.ShouldContain(ExceptedLogAllowDeleteIntFalse);
        }

        [TestMethod]
        public void DeleteItems_IsSyncEnabledFalse_FillLog()
        {
            // Arrange
            ShimSfService.AllInstances.IsSyncEnabled = sender => false;

            var items = new DataTable("table");

            // Act
            var actualResult = _testEntity.DeleteItems(_webProperties, items, _integrationLog);

            // Assert
            _actualLogMessage.ShouldContain(ExceptedLogIsSyncEnabledFalse);
        }

        [TestMethod]
        public void DeleteItems_Should_ReturnsTransactionTableAndFillLog()
        {
            // Arrange
            ShimSfService.AllInstances.IsSyncEnabled = sender => true;
            var dataTable = BuildDataTableDeleteItems();
            ShimSfService.AllInstances.DeleteObjectItemsByIdStringArray = (sender, ids) => new DeleteResult[]
            {
                new DeleteResult
                {
                    id = SalesforceId10,
                    success = true
                },
                new DeleteResult
                {
                    id = SalesforceId20,
                    success = true
                },
                new DeleteResult
                {
                    id = SalesforceId13,
                    success = false,
                    errors = new Error[]
                    {
                        new Error
                        {
                            statusCode = StatusCode.DELETE_FAILED,
                            message = string.Empty,
                            fields = new[]
                            {
                                FieldId
                            }
                        },
                        new Error
                        {
                            statusCode = StatusCode.UNKNOWN_EXCEPTION,
                            message = string.Empty,
                            fields = new[]
                            {
                                FieldLogin
                            }
                        }
                    }
                }
            };

            // Act
            var actualResult = _testEntity.DeleteItems(_webProperties, dataTable, _integrationLog);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(3),
                () => actualResult.Rows[0][SalesforceIdID].ShouldBe(SalesforceId10),
                () => actualResult.Rows[0][SharePointID].ShouldBe(SharePointID11),
                () => actualResult.Rows[0]["Type"].ShouldBe(TransactionTypeDelete),
                () => actualResult.Rows[1][SalesforceIdID].ShouldBe(SalesforceId20),
                () => actualResult.Rows[1][SharePointID].ShouldBe(SharePointID11),
                () => actualResult.Rows[1]["Type"].ShouldBe(TransactionTypeDelete),
                () => actualResult.Rows[2][SalesforceIdID].ShouldBe(SalesforceId13),
                () => actualResult.Rows[2][SharePointID].ShouldBe(SharePointID14),
                () => actualResult.Rows[2]["Type"].ShouldBe(TransactionTypeFailed),
                () => _actualLogMessage.ShouldContain($"Could not delete record with Salesforce ID: {SalesforceId13}, SharePoint ID: {SharePointID14}. Status code: DELETE_FAILED. Message: . Fields: {FieldId}"),
                () => _actualLogMessage.ShouldContain($"Could not delete record with Salesforce ID: {SalesforceId13}, SharePoint ID: {SharePointID14}. Status code: UNKNOWN_EXCEPTION. Message: . Fields: {FieldLogin}"));
        }

        [TestMethod]
        public void GetColumns_ReferenceProblem_FillLog()
        {
            // Arrange, Act
            var actualResult = _testEntity.GetColumns(_webProperties, _integrationLog, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(0),
                () => _actualLogMessage.ShouldContain(ExceptionMessageObjectReference));
        }

        [TestMethod]
        public void GetColumns_Should_ReturnsListColumnProperties()
        {
            // Arrange
            _properties.Add(ObjectKey, DummyString);

            ShimSfService.AllInstances.AppNamespaceGet = sender => string.Empty;
            ShimSfService.AllInstances.GetObjectFieldsString = (sender, objectName) => BuildObjectFields();

            // Act
            var actualResult = _testEntity.GetColumns(_webProperties, _integrationLog, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(4),
                () => actualResult[0].ColumnName.ShouldBe("__EPM_Live_ID__c"),
                () => actualResult[0].DefaultListColumn.ShouldBe(SharePointID),
                () => actualResult[0].DiplayName.ShouldBe("Display SpId"),
                () => actualResult[0].type.ShouldBe(typeof(string)),
                () => actualResult[1].ColumnName.ShouldBe("Id"),
                () => actualResult[1].DefaultListColumn.ShouldBe("INTUID"),
                () => actualResult[1].DiplayName.ShouldBe("Display Id"),
                () => actualResult[1].type.ShouldBe(typeof(int)),
                () => actualResult[2].ColumnName.ShouldBe("maxSize"),
                () => actualResult[2].DefaultListColumn.ShouldBe("maxsizePercent"),
                () => actualResult[2].DiplayName.ShouldBe("max size %"),
                () => actualResult[2].type.ShouldBe(typeof(double)),
                () => actualResult[3].ColumnName.ShouldBe("Name"),
                () => actualResult[3].DefaultListColumn.ShouldBe("Title"),
                () => actualResult[3].DiplayName.ShouldBe("Display Name"),
                () => actualResult[3].type.ShouldBe(typeof(string)));
        }

        [TestMethod]
        public void GetDropDownValues_PropertyInvalid_ReturnsDictionaryEmptyFillLog()
        {
            // Arrange
            var propertyString = "Invalid";

            // Act
            var actualResult = _testEntity.GetDropDownValues(_webProperties, _integrationLog, propertyString, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeEmpty(),
                () => _actualLogMessage.ShouldContain($"Invalid property: {propertyString}"));
        }

        [TestMethod]
        public void GetDropDownValues_propertyUserMapType_ReturnsDictionary()
        {
            // Arrange
            var propertyString = "UserMapType";

            // Act
            var actualResult = _testEntity.GetDropDownValues(_webProperties, _integrationLog, propertyString, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeEmpty(),
                () => actualResult.ShouldContainKeyAndValue("Email", "Email"));
        }

        [TestMethod]
        public void GetDropDownValues_propertyObject_ReturnsDictionary()
        {
            // Arrange
            var propertyString = "Object";
            ShimSfService.AllInstances.GetIntegratableObjects = sender => new Dictionary<string, string>
            {
                { "Id", "Display Id" },
                { "Name", "Display Name" }
            };

            // Act
            var actualResult = _testEntity.GetDropDownValues(_webProperties, _integrationLog, propertyString, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeEmpty(),
                () => actualResult.ShouldContainKeyAndValue("Id", "Display Id"),
                () => actualResult.ShouldContainKeyAndValue("Name", "Display Name"));
        }

        [TestMethod]
        public void GetItem_ReferenceProblem_FillLog()
        {
            // Arrange, Act
            var actualResult = _testEntity.GetItem(_webProperties, _integrationLog, "itemId", new DataTable("table"));

            // Assert
            _actualLogMessage.ShouldContain(ExceptionMessageObjectReference);
        }

        [TestMethod]
        public void GetItem_NoRecordsFound_FillLog()
        {
            // Arrange
            _properties.Add(ObjectKey, DummyString);
            ShimSfService.AllInstances.GetObjectItemsByIdStringStringDataTable = (sender, objectName, itemsIds, items) =>
            {
                throw new Exception(ExceptionNoRecordsFound);
            };

            // Act
            var actualResult = _testEntity.GetItem(_webProperties, _integrationLog, "itemId", new DataTable("table"));

            // Assert
            _actualLogMessage.ShouldContain(ExceptionNoRecordsFound);
        }

        [TestMethod]
        public void GetItem_Should_ReturnDataTableFilled()
        {
            // Arrange
            _properties.Add(ObjectKey, DummyString);

            var items = new DataTable("table");
            items.Columns.Add(FieldId);

            ShimSfService.AllInstances.GetObjectItemsByIdStringStringDataTable = (sender, objectName, itemIds, itemsDataTable) =>
            {
                foreach (string sId in itemIds.Split(','))
                {
                    var dataRow = itemsDataTable.NewRow();
                    dataRow[0] = sId;
                    itemsDataTable.Rows.Add(dataRow);
                }
            };

            // Act
            var actualResult = _testEntity.GetItem(_webProperties, _integrationLog, "1,2,3", items);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Rows.Count.ShouldBe(3),
                () => actualResult.Rows[0][FieldId].ShouldBe("1"),
                () => actualResult.Rows[1][FieldId].ShouldBe("2"),
                () => actualResult.Rows[2][FieldId].ShouldBe("3"));
        }

        [TestMethod]
        public void InstallIntegration_ErrorInstall_ReturnsFalseFillMessage()
        {
            // Arrange
            _properties.Add(ObjectKey, "object");
            _properties.Add("AllowAddInt", "true");
            _properties.Add("AllowAddList", "true");

            string message;

            ShimSfService.AllInstances.InstallIntegrationStringStringStringStringGuidStringBooleanBooleanBoolean =
                (
                    sender,
                    integrationKey,
                    apiUrl,
                    webName,
                    webUrl,
                    integrationId,
                    objectName,
                    incomingEnabled,
                    outgoingEnabled,
                    allowDeletion) =>
                {
                    throw new Exception(DummyString);
                };

            // Act
            var actualResult = _testEntity.InstallIntegration(_webProperties, _integrationLog, out message, string.Empty, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => message.ShouldBe(DummyString));
        }

        [TestMethod]
        public void InstallIntegration_Should_ReturnsTrue()
        {
            // Arrange
            _properties.Add(ObjectKey, "object");
            _properties.Add("AllowAddInt", "true");
            _properties.Add("AllowAddList", "true");

            string message;

            ShimSfService.AllInstances.InstallIntegrationStringStringStringStringGuidStringBooleanBooleanBoolean = (
                sender,
                integrationKey,
                apiUrl,
                webName,
                webUrl,
                integrationId,
                objectName,
                incomingEnabled,
                outgoingEnabled,
                allowDeletion) =>
            { };

            // Act
            var actualResult = _testEntity.InstallIntegration(_webProperties, _integrationLog, out message, string.Empty, string.Empty);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void PullData_ReferenceProblem_FillLog()
        {
            // Arrange, Act
            var actualResult = _testEntity.PullData(_webProperties, _integrationLog, new DataTable("table"), DummyDateTime);

            // Assert
            _actualLogMessage.ShouldContain($"Scheduled Pull. {ExceptionMessageObjectReference}");
        }

        [TestMethod]
        public void PullData_NoRecordsFound_FillLog()
        {
            // Arrange
            _properties.Add(ObjectKey, DummyString);
            ShimSfService.AllInstances.GetObjectItemsStringDataTableDateTime = (sender, objectName, items, lastSync) =>
            {
                throw new Exception(ExceptionNoRecordsFound);
            };

            // Act
            var actualResult = _testEntity.PullData(_webProperties, _integrationLog, new DataTable("table"), DummyDateTime);

            // Assert
            _actualLogMessage.ShouldContain($"Scheduled Pull. {ExceptionNoRecordsFound}");
        }

        [TestMethod]
        public void PullData_Should_ReturnDataTableFilled()
        {
            // Arrange
            _properties.Add(ObjectKey, DummyString);

            var items = new DataTable("table");
            items.Columns.Add(FieldId);

            ShimSfService.AllInstances.GetObjectItemsStringDataTableDateTime = (sender, objectName, itemsDataTable, lastSync) =>
            {
                var dataRow = itemsDataTable.NewRow();
                dataRow[FieldId] = "1";
                itemsDataTable.Rows.Add(dataRow);
            };

            // Act
            var actualResult = _testEntity.PullData(_webProperties, _integrationLog, items, DummyDateTime);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.Rows.Count.ShouldBe(1),
                () => actualResult.Rows[0][FieldId].ShouldBe("1"));
        }

        [TestMethod]
        public void RemoveIntegration_ErrorRemove_ReturnsTrueFillMessage()
        {
            // Arrange
            _properties.Add(ObjectKey, DummyString);
            string message;
            ShimSfService.AllInstances.UninstallIntegrationStringString = (sender, integrationKey, objectName) =>
            {
                throw new Exception(DummyString);
            };

            // Act
            var actualResult = _testEntity.RemoveIntegration(_webProperties, _integrationLog, out message, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => message.ShouldBe(DummyString));
        }

        [TestMethod]
        public void RemoveIntegration_Should_ReturnsTrueNoMessage()
        {
            // Arrange
            _properties.Add(ObjectKey, DummyString);
            string message;

            ShimSfService.AllInstances.UninstallIntegrationStringString = (sender, integrationKey, objectName) => { };

            // Act
            var actualResult = _testEntity.RemoveIntegration(_webProperties, _integrationLog, out message, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => message.ShouldBeEmpty());
        }

        [TestMethod]
        public void TestConnection_ErrorRemove_ReturnsFalseFillMessage()
        {
            // Arrange
            string message;
            ShimSfService.AllInstances.EnsureEPMLiveAppInstalled = sender =>
            {
                throw new Exception(DummyString);
            };

            // Act
            var actualResult = _testEntity.TestConnection(_webProperties, _integrationLog, out message);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => message.ShouldBe(DummyString));
        }

        [TestMethod]
        public void TestConnection_Should_ReturnsTrueNoMessage()
        {
            // Arrange
            string message;

            ShimSfService.AllInstances.EnsureEPMLiveAppInstalled = sender => { };

            // Act
            var actualResult = _testEntity.TestConnection(_webProperties, _integrationLog, out message);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => message.ShouldBeEmpty());
        }

        [TestMethod]
        public void UpdateItems_IsSyncEnabledFalse_FillLog()
        {
            // Arrange
            ShimSfService.AllInstances.IsSyncEnabled = sender => false;

            var items = new DataTable("table");

            // Act
            var actualResult = _testEntity.UpdateItems(_webProperties, items, _integrationLog);

            // Assert
            _actualLogMessage.ShouldContain(ExceptedLogIsSyncEnabledFalse);
        }

        [TestMethod]
        public void UpdateItems_SuccessUpdateTrue_ReturnsReturnsTransactionTable()
        {
            // Arrange
            _properties.Add(ObjectKey, DummyString);
            ShimSfService.AllInstances.IsSyncEnabled = sender => true;

            ShimSfService.AllInstances.UpsertItemsStringDataTable = (sender, objectName, items) =>
            {
                var upsertItems = new List<Dictionary<UpsertKind, SaveResult>>
                {
                    new Dictionary<UpsertKind, SaveResult>()
                    {
                        {
                            UpsertKind.INSERT, new SaveResult()
                            {
                                id = SalesforceId10,
                                success = true
                            }
                        },
                        {
                            UpsertKind.UPDATE, new SaveResult()
                            {
                                id = SalesforceId20,
                                success = true
                            }
                        }
                    }
                };

                return upsertItems;
            };

            var itemsDataTable = BuildDataTableUpdate();

            // Act
            var actualResult = _testEntity.UpdateItems(_webProperties, itemsDataTable, _integrationLog);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(2),
                () => actualResult.Rows[0][SalesforceIdID].ShouldBe(SalesforceId10),
                () => actualResult.Rows[0][SharePointID].ShouldBe(SharePointID11),
                () => actualResult.Rows[0]["Type"].ShouldBe(TransactionTypeInsert),
                () => actualResult.Rows[1][SalesforceIdID].ShouldBe(SalesforceId20),
                () => actualResult.Rows[1][SharePointID].ShouldBe(SharePointID11),
                () => actualResult.Rows[1]["Type"].ShouldBe(TransactionTypeUpdate),
                () => _actualLogMessage.ShouldBeEmpty());
        }

        [TestMethod]
        public void UpdateItems_SuccessUpdateFalse_ReturnsReturnsTransactionTable()
        {
            // Arrange
            _properties.Add(ObjectKey, DummyString);
            ShimSfService.AllInstances.IsSyncEnabled = sender => true;

            ShimSfService.AllInstances.UpsertItemsStringDataTable = (sender, objectName, items) =>
            {
                var upsertItems = new List<Dictionary<UpsertKind, SaveResult>>
                {
                    new Dictionary<UpsertKind, SaveResult>()
                    {
                        {
                            UpsertKind.INSERT, new SaveResult()
                            {
                                id = SalesforceId10,
                                success = false,
                                errors = new Error[]
                                {
                                    new Error
                                    {
                                        statusCode = StatusCode.CANNOT_INSERT_UPDATE_ACTIVATE_ENTITY,
                                        message = string.Empty,
                                        fields = new[]
                                        {
                                            FieldId
                                        }
                                    },
                                    new Error
                                    {
                                        statusCode = StatusCode.UNKNOWN_EXCEPTION,
                                        message = string.Empty,
                                        fields = new[]
                                        {
                                            FieldLogin
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                return upsertItems;
            };

            var itemsDataTable = BuildDataTableUpdate();

            // Act
            var actualResult = _testEntity.UpdateItems(_webProperties, itemsDataTable, _integrationLog);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(1),
                () => actualResult.Rows[0][SalesforceIdID].ShouldBe(SalesforceId10),
                () => actualResult.Rows[0][SharePointID].ShouldBe(SharePointID11),
                () => actualResult.Rows[0]["Type"].ShouldBe(TransactionTypeFailed),
                () => _actualLogMessage.ShouldContain($"Could not insert / update record with Salesforce ID: {SalesforceId10}, SharePoint ID: {SharePointID11}. Status code: CANNOT_INSERT_UPDATE_ACTIVATE_ENTITY. Message:  Fields: {FieldId}."),
                () => _actualLogMessage.ShouldContain($"Could not insert / update record with Salesforce ID: {SalesforceId10}, SharePoint ID: {SharePointID11}. Status code: UNKNOWN_EXCEPTION. Message:  Fields: {FieldLogin}."));
        }

        [TestMethod]
        public void TranslateFieldType_Boolean_ReturnsBooleanType()
        {
            // Arrange, Act
            var actualResult = (Type)_privateType.InvokeStatic("TranslateFieldType", fieldType.boolean);

            // Assert
            actualResult.ShouldBe(typeof(bool));
        }

        [TestMethod]
        public void TranslateFieldType_Currency_ReturnsDecimalType()
        {
            // Arrange, Act
            var actualResult = (Type)_privateType.InvokeStatic("TranslateFieldType", fieldType.currency);

            // Assert
            actualResult.ShouldBe(typeof(decimal));
        }

        [TestMethod]
        public void TranslateFieldType_Datetime_ReturnsDatetimeType()
        {
            // Arrange, Act
            var actualResult = (Type)_privateType.InvokeStatic("TranslateFieldType", fieldType.datetime);

            // Assert
            actualResult.ShouldBe(typeof(DateTime));
        }

        private static DataTable BuildDataTableDeleteItems()
        {
            var dataTable = new DataTable("table");
            dataTable.Columns.Add(SalesforceIdID);
            dataTable.Columns.Add(SharePointID);

            var dataRow1 = dataTable.NewRow();
            dataRow1[0] = null;
            dataTable.Rows.Add(dataRow1);

            var dataRow2 = dataTable.NewRow();
            dataRow2[0] = 10;
            dataRow2[1] = 11;
            dataTable.Rows.Add(dataRow2);

            var dataRow3 = dataTable.NewRow();
            dataRow3[0] = 10;
            dataRow3[1] = 12;
            dataTable.Rows.Add(dataRow3);

            var dataRow4 = dataTable.NewRow();
            dataRow4[0] = 13;
            dataRow4[1] = 14;
            dataTable.Rows.Add(dataRow4);
            return dataTable;
        }

        private static DataTable BuildDataTableUpdate()
        {
            var dataTable = new DataTable("table");
            dataTable.Columns.Add(SalesforceIdID);
            dataTable.Columns.Add(SharePointID);

            var dataRow2 = dataTable.NewRow();
            dataRow2[0] = 10;
            dataRow2[1] = 11;
            dataTable.Rows.Add(dataRow2);

            var dataRow4 = dataTable.NewRow();
            dataRow4[0] = 13;
            dataRow4[1] = 14;
            dataTable.Rows.Add(dataRow4);

            var dataRow1 = dataTable.NewRow();
            dataRow1[0] = DBNull.Value;
            dataTable.Rows.Add(dataRow1);

            return dataTable;
        }

        private static Field[] BuildObjectFields()
        {
            return new Field[]
            {
                new Field
                {
                    name = "Id",
                    label = "Display Id",
                    type = fieldType.@int
                },
                new Field
                {
                    name = "Name",
                    label = "Display Name",
                    type = fieldType.@string
                },
                new Field
                {
                    name = "__EPM_Live_ID__c",
                    label = "Display SpId",
                    type = fieldType.@string
                },
                new Field
                {
                    name = "maxSize",
                    label = "max size %",
                    type = fieldType.percent
                }
            };
        }
    }
}

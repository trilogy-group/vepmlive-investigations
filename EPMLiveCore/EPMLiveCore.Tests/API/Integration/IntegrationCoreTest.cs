﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Reflection;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.API.Integration;
using EPMLiveCore.API.Integration.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveIntegration;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using static EPMLiveCore.API.Integration.IntegrationCore;

namespace EPMLiveCore.Tests.API.Integration
{
    [TestClass]
    public class IntegrationCoreTest
    {
        private const int OneCall = 1;
        private const int TwoCalls = 2;
        private const int ThreeCalls = 3;
        private const string FieldSqlConnection = "cn";
        private const string MethodProcessItemOutgoing = "ProcessItemOutgoing";
        private const string MethodPostCheckBit = "PostCheckBit";
        private const string MethodGetIntegrator = "GetIntegrator";
        private const string MethodGetIntegratorFromModule = "GetIntegratorFromModule";
        private const string MethodBCheckBit = "bCheckBit";
        private const string ColumnNameType = "TYPE";
        private const string ColumnNameIntItemId = "INTITEM_ID";
        private const string ColumnNameItemId = "ITEM_ID";
        private const string ColumnNameListId = "LIST_ID";
        private const string ColumnNameColId = "COL_ID";
        private const string ColumnNameLiveIncoming = "LIVEINCOMING";
        private const string ColumnNameModuleId = "MODULE_ID";
        private const string ColNameFieldName = "Fieldname";
        private const string ColNameType = "Type";
        private const string ColNameLookupIntColId = "LookupIntColID";
        private const string ColNameLookupList = "LookupList";
        private const string ColNameSharePoint = "SharePointColumn";
        private const string ColNameIntegration = "IntegrationColumn";
        private const string ColNameSetting = "Setting";
        private const string ColNameSpid = "SPID";
        private const string ColNameIntColId = "INT_COLID";
        private const string ColNameIntListId = "INT_LIST_ID";
        private const string ColNameIntEventId = "INT_EVENT_ID";
        private const string TextIntUid = "INTUID";
        private const string TextId = "ID";
        private const string CmdTextDeleteIntControls = "DELETE FROM INT_CONTROLS where INT_LIST_ID=@intlistid";
        private const string QueryReadIntColumns = "SELECT * FROM INT_COLUMNS where INT_LIST_ID=@intlistid";
        private const string QueryReadIntLists = "SELECT * FROM INT_LISTS where LIST_ID=@listid and INT_COLID=@colid";
        private const string QueryReadtDataFromIntEvents = "SELECT DATA FROM INT_EVENTS WHERE INT_EVENT_ID=@inteventid";
        private const string QueryReadValueFromIntProps = "SELECT VALUE FROM INT_PROPS where INT_LIST_ID=@intlistid and PROPERTY='UserMapType'";
        private const string QueryReadModuleIdFromIntLists = "SELECT MODULE_ID FROM INT_LISTS where INT_LIST_ID=@intlistid";
        private const string QueryReadColIdFromIntLists = "SELECT INT_COLID FROM INT_LISTS where LIST_ID=@listid and MODULE_ID=@moduleid";
        private const string QueryReadListIdAndKeyFromIntLists = "SELECT     LIST_ID,INT_KEY from INT_LISTS where INT_LIST_ID=@intlistid";
        private static readonly Guid _siteId = Guid.NewGuid();
        private static readonly Guid _webId = Guid.NewGuid();

        private IDisposable _shimsContext;
        private IntegrationCore _testEntity;
        private PrivateObject _testEntityPrivate;
        private SqlConnection _sqlConnection;
        private ConnectionState _sqlConnectionState;
        private AdoShims _adoShims;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            FakesForSpSecurity();
            FakesForConstructor();

            var webApplicationId = Guid.NewGuid();
            var shimSPWeb = new ShimSPWeb();
            var shimSPWebApplication = new ShimSPWebApplication();
            var shimSPPersitedObject = new ShimSPPersistedObject(shimSPWebApplication);
            shimSPPersitedObject.IdGet = () => webApplicationId;

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => shimSPWeb.Instance;
            ShimSPSite.AllInstances.WebApplicationGet = (_) => shimSPWebApplication.Instance;

            ShimSqlConnection.ConstructorString = (_, __) => { };
            
            _testEntity = new IntegrationCore(_siteId, _webId);
            _testEntityPrivate = new PrivateObject(_testEntity);

            _sqlConnection = new SqlConnection();
            var shimSqlConnection = new ShimSqlConnection(_sqlConnection);
            shimSqlConnection.Open = () => _sqlConnectionState = ConnectionState.Open;
            shimSqlConnection.Close = () => _sqlConnectionState = ConnectionState.Closed;
            shimSqlConnection.StateGet = () => _sqlConnectionState;

            _testEntityPrivate.SetField(FieldSqlConnection, _sqlConnection);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_shimsContext != null)
            {
                _shimsContext.Dispose();
            }

            if (_sqlConnection != null)
            {
                _sqlConnection.Dispose();
            }
        }

        [TestMethod]
        public void GetIntegrationControl_WhenCalled_ReturnsDataTable()
        {
            // Arrange
            const string expectedCommandText = "SELECT     dbo.INT_LISTS.INT_LIST_ID, dbo.INT_LISTS.INT_COLID, WINDOWSTYLE FROM         dbo.INT_CONTROLS INNER JOIN dbo.INT_LISTS ON dbo.INT_CONTROLS.INT_LIST_ID = dbo.INT_LISTS.INT_LIST_ID where LIST_ID=@listid and control=@control";
            const string expectedCommandParam01 = "@listid";
            const string expectedCommandParam02 = "@control";

            var expectedDataTable = default(DataTable);

            try
            {
                var sqlCommandCtorCommandText = string.Empty;
                ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
                {
                    instance.CommandText = commandText;
                    sqlCommandCtorCommandText = commandText;
                };

                var sqlDataAdapterCtorCommandText = string.Empty;
                var parameterList = new List<SqlParameter>();
                ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
                {
                    if (sqlCommand == null)
                    {
                        throw new ArgumentNullException("sqlCommand");
                    }

                    sqlDataAdapterCtorCommandText = sqlCommand.CommandText;

                    foreach (SqlParameter param in sqlCommand.Parameters)
                    {
                        parameterList.Add(param);
                    }
                };

                var fillMethodCalled = false;
                expectedDataTable = new DataTable();
                ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
                {
                    fillMethodCalled = true;
                    dataSet.Tables.Add(expectedDataTable);
                    return 0;
                };

                var intListId = Guid.NewGuid();
                const string control = "Control";

                // Act
                var returnedDataTable = _testEntity.GetIntegrationControl(intListId, control) as DataTable;

                // Assert
                returnedDataTable.ShouldSatisfyAllConditions(
                    () => returnedDataTable.ShouldNotBeNull(),
                    () => returnedDataTable.ShouldBeSameAs(expectedDataTable),
                    () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                    () => sqlDataAdapterCtorCommandText.ShouldBe(expectedCommandText),
                    () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam01 &&
                                                               param.Value.Equals(intListId)),
                    () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam02 &&
                                                               param.Value.Equals(control)),
                    () => fillMethodCalled.ShouldBeTrue());
            }
            finally
            {
                if (expectedDataTable != null)
                {
                    expectedDataTable.Dispose();
                }
            }
        }

        [TestMethod]
        public void GetIntegrationControlByIntId_WhenCalled_ReturnsDataTable()
        {
            // Arrange
            const string expectedCommandText = "SELECT   LIST_ID,  dbo.INT_LISTS.INT_LIST_ID, dbo.INT_LISTS.INT_COLID, WINDOWSTYLE FROM         dbo.INT_CONTROLS INNER JOIN dbo.INT_LISTS ON dbo.INT_CONTROLS.INT_LIST_ID = dbo.INT_LISTS.INT_LIST_ID where INT_LISTS.INT_LIST_ID=@IntListId and control=@control";
            const string expectedCommandParam01 = "@IntListId";
            const string expectedCommandParam02 = "@control";

            var expectedDataTable = default(DataTable);

            try
            {
                var sqlCommandCtorCommandText = string.Empty;
                ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
                {
                    instance.CommandText = commandText;
                    sqlCommandCtorCommandText = commandText;
                };

                var sqlDataAdapterCtorCommandText = string.Empty;
                var parameterList = new List<SqlParameter>();
                ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
                {
                    if (sqlCommand == null)
                    {
                        throw new ArgumentNullException("sqlCommand");
                    }

                    sqlDataAdapterCtorCommandText = sqlCommand.CommandText;

                    foreach (SqlParameter param in sqlCommand.Parameters)
                    {
                        parameterList.Add(param);
                    }
                };

                var fillMethodCalled = false;
                expectedDataTable = new DataTable();
                ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
                {
                    fillMethodCalled = true;
                    dataSet.Tables.Add(expectedDataTable);
                    return 0;
                };

                var intListId = Guid.NewGuid();
                const string control = "Control";

                // Act
                var returnedDataTable = _testEntity.GetIntegrationControlByIntId(intListId, control) as DataTable;

                // Assert
                returnedDataTable.ShouldSatisfyAllConditions(
                    () => returnedDataTable.ShouldNotBeNull(),
                    () => returnedDataTable.ShouldBeSameAs(expectedDataTable),
                    () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                    () => sqlDataAdapterCtorCommandText.ShouldBe(expectedCommandText),
                    () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam01 &&
                                                               param.Value.Equals(intListId)),
                    () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam02 &&
                                                               param.Value.Equals(control)),
                    () => fillMethodCalled.ShouldBeTrue());
            }
            finally
            {
                if (expectedDataTable != null)
                {
                    expectedDataTable.Dispose();
                }
            }
        }

        [TestMethod]
        public void GetIntegrationsForList_WhenCalled_ReturnsDataTable()
        {
            // Arrange
            const string expectedCommandText = "select INT_LIST_ID as intlistid, priority, Title as intname , CASE WHEN ACTIVE = 1 THEN 'Yes' ELSE 'No' END AS Active, INT_COLID FROM dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID where LIST_ID=@listid order by priority";
            const string expectedCommandParam01 = "@listid";

            var expectedDataTable = default(DataTable);

            try
            {
                var sqlCommandCtorCommandText = string.Empty;
                ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
                {
                    instance.CommandText = commandText;
                    sqlCommandCtorCommandText = commandText;
                };

                var sqlDataAdapterCtorCommandText = string.Empty;
                var parameterList = new List<SqlParameter>();
                ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
                {
                    if (sqlCommand == null)
                    {
                        throw new ArgumentNullException("sqlCommand");
                    }

                    sqlDataAdapterCtorCommandText = sqlCommand.CommandText;

                    foreach (SqlParameter param in sqlCommand.Parameters)
                    {
                        parameterList.Add(param);
                    }
                };

                var fillMethodCalled = false;
                expectedDataTable = new DataTable();
                ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
                {
                    fillMethodCalled = true;
                    dataSet.Tables.Add(expectedDataTable);
                    return 0;
                };

                var listId = Guid.NewGuid();

                // Act
                var returnedDataTable = _testEntity.GetIntegrationsForList(listId);

                // Assert
                returnedDataTable.ShouldSatisfyAllConditions(
                    () => returnedDataTable.ShouldNotBeNull(),
                    () => returnedDataTable.ShouldBeSameAs(expectedDataTable),
                    () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                    () => sqlDataAdapterCtorCommandText.ShouldBe(expectedCommandText),
                    () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam01 &&
                                                               param.Value.Equals(listId)),
                    () => fillMethodCalled.ShouldBeTrue());
            }
            finally
            {
                if (expectedDataTable != null)
                {
                    expectedDataTable.Dispose();
                }
            }
        }

        [TestMethod]
        public void RemoveIntegration_IfIntegrationRemovedByIntegrator_RemovesIntegration()
        {
            // Arrange
            const string expectedCommandText = "DELETE FROM INT_CONTROLS where INT_LIST_ID=@intlistid";
            const string expectedCommandParam01 = "@intlistid";
            const string expectedMessage = "Hello world!";

            var integratorOutMessage = string.Empty;
            var mockIntegrator = new Mock<IIntegrator>();
            mockIntegrator.Setup(intg => intg.RemoveIntegration(It.IsAny<WebProperties>(),
                                                                It.IsAny<IntegrationLog>(),
                                                                out integratorOutMessage,
                                                                It.IsAny<string>()))
                                             .Callback(() => integratorOutMessage = expectedMessage)
                                             .Returns(true);
            var integratorDef = new IntegratorDef()
            {
                iIntegrator = mockIntegrator.Object
            };

            ShimIntegrationCore.AllInstances.GetIntegratorGuid = (_, __) => integratorDef;
            ShimIntegrationCore.AllInstances.GetPropertiesGuid = (_, __) => new Hashtable();
            ShimIntegrationCore.AllInstances.GetWebPropsHashtableGuid = (_, __, ___) => new WebProperties();

            var sqlCommandCtorTextArgument = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorTextArgument = commandText;
            };

            var executeNonQueryCalled = false;
            var parameterList = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) =>
            {
                executeNonQueryCalled = true;

                foreach (SqlParameter param in instance.Parameters)
                {
                    parameterList.Add(param);
                }

                return -1;
            };

            var intListId = Guid.NewGuid();
            var listId = Guid.NewGuid();
            string message;

            // Act
            var returnedValue = _testEntity.RemoveIntegration(intListId, listId, out message);

            // Assert
            returnedValue.ShouldSatisfyAllConditions(
                () => returnedValue.ShouldBeTrue(),
                () => integratorOutMessage.ShouldBe(expectedMessage),
                () => executeNonQueryCalled.ShouldBeTrue(),
                () => sqlCommandCtorTextArgument.ShouldBe(expectedCommandText),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam01 &&
                                                           param.Value.Equals(intListId)));
        }

        [TestMethod]
        public void GetIntegrations_WhenCalled_ReturnsItegrationsDataSet()
        {
            // Arrange
            const string expectedCommand01Text = "SELECT * FROM INT_CATEGORY ORDER BY ORDERBY";
            const string expectedCommand02Text = "SELECT * FROM INT_MODULES WHERE AvailableOnline = 1 AND INT_CAT_ID=@cat";
            const string expectedCommand02Param = "@cat";

            var sqlCommandCtorCallCount = 0;
            var sqlCommandCtor01CommandText = string.Empty;
            var sqlCommandCtor02CommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCallCount++;

                if (sqlCommandCtorCallCount == OneCall)
                {
                    instance.CommandText = commandText;
                    sqlCommandCtor01CommandText = commandText;
                }
                else if (sqlCommandCtorCallCount == TwoCalls)
                {
                    instance.CommandText = commandText;
                    sqlCommandCtor02CommandText = commandText;
                }
            };

            var sqlDataAdapterCtorCallCount = 0;
            var sqlDataAdapterCtor01CommandText = string.Empty;
            var sqlDataAdapterCtor02CommandText = string.Empty;
            var parameterList = new List<SqlParameter>();
            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
            {
                if (sqlCommand == null)
                {
                    throw new ArgumentNullException("sqlCommand");
                }

                sqlDataAdapterCtorCallCount++;

                if (sqlDataAdapterCtorCallCount == OneCall)
                {
                    sqlDataAdapterCtor01CommandText = sqlCommand.CommandText;
                }
                else if (sqlDataAdapterCtorCallCount == TwoCalls)
                {
                    sqlDataAdapterCtor02CommandText = sqlCommand.CommandText;

                    foreach (SqlParameter param in sqlCommand.Parameters)
                    {
                        parameterList.Add(param);
                    }
                }
            };

            const string categoriesTableName = "Categories";
            const string columnCategoryId = "INT_CAT_ID";
            const string columnModuleId = "INT_MOD_ID";
            const int row01CatId = 1;

            var fillMethodCallCount = 0;
            var producedCategoriesTable = new DataTable();
            producedCategoriesTable.Columns.Add(columnCategoryId);

            var producedModulesTable01 = new DataTable();
            producedModulesTable01.Columns.Add(columnModuleId);
            producedModulesTable01.Columns.Add(columnCategoryId);

            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                if (dataSet == null)
                {
                    throw new ArgumentNullException("dataSet");
                }

                fillMethodCallCount++;

                if (fillMethodCallCount == OneCall)
                {
                    var row01 = producedCategoriesTable.NewRow();
                    row01[columnCategoryId] = row01CatId;

                    producedCategoriesTable.Rows.Add(row01);
                    dataSet.Tables.Add(producedCategoriesTable);
                }
                else if (fillMethodCallCount == TwoCalls)
                {
                    dataSet.Tables.Add(producedModulesTable01);
                }

                return -1;
            };

            var listId = Guid.NewGuid();

            // Act
            var returnedDataSet = _testEntity.GetIntegrations(false);

            // Assert
            returnedDataSet.ShouldSatisfyAllConditions(
                () => returnedDataSet.ShouldNotBeNull(),
                () => returnedDataSet.Tables.Count.ShouldBe(2),
                () =>
                {
                    var returnedCatTable = returnedDataSet.Tables[0];
                    returnedCatTable.ShouldNotBeSameAs(producedCategoriesTable);
                    returnedCatTable.TableName.ShouldBe(categoriesTableName);
                    returnedCatTable.Rows.Count.ShouldBe(producedCategoriesTable.Rows.Count);
                },
                () =>
                {
                    var returnedModTable01 = returnedDataSet.Tables[1];
                    returnedModTable01.TableName.ShouldBe(row01CatId.ToString());
                    returnedModTable01.Columns.Count.ShouldBe(2);
                },
                () => sqlCommandCtor01CommandText.ShouldBe(expectedCommand01Text),
                () => sqlCommandCtor02CommandText.ShouldBe(expectedCommand02Text),
                () => sqlDataAdapterCtor01CommandText.ShouldBe(expectedCommand01Text),
                () => sqlDataAdapterCtor02CommandText.ShouldBe(expectedCommand02Text),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedCommand02Param &&
                                                           param.Value.Equals(row01CatId.ToString())),
                () => sqlCommandCtorCallCount.ShouldBe(2),
                () => sqlDataAdapterCtorCallCount.ShouldBe(2),
                () => fillMethodCallCount.ShouldBe(2));
        }

        [TestMethod]
        public void SaveProperties_WhenCalled_SavesPropertiesToDb()
        {
            // Arrange
            const string expectedCommandText = "SPIntSetProperty";
            const CommandType expectedCommandType = CommandType.StoredProcedure;
            const string expectedParamIntListId = "@intlistid";
            const string expectedParamProperty = "@property";
            const string expectedParamValue = "@value";
            const string entryKey = "Key1";
            const string entryValue = "Value1";

            var intListId = Guid.NewGuid();
            var propertiesTable = new Hashtable()
            {
                { entryKey, entryValue }
            };

            var sqlCommandCtorCommandText = string.Empty;
            var parameterList = new List<SqlParameter>();
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                instance.CommandText = commandText;
                sqlCommandCtorCommandText = commandText;
            };

            var sqlCommandType = CommandType.Text;
            ShimSqlCommand.AllInstances.CommandTypeSetCommandType = (instance, commandType) =>
            {
                sqlCommandType = commandType;
            };

            var executeNonQueryCalled = false;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) =>
            {
                foreach (SqlParameter param in instance.Parameters)
                {
                    parameterList.Add(param);
                }
                executeNonQueryCalled = true;
                return -1;
            };

            // Act
            _testEntity.SaveProperties(intListId, propertiesTable);

            // Assert
            sqlCommandCtorCommandText.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                () => sqlCommandType.ShouldBe(expectedCommandType),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamIntListId &&
                                                           param.Value.Equals(intListId)),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamProperty &&
                                                           param.Value.Equals(entryKey)),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamValue &&
                                                           param.Value.Equals(entryValue)),
                () => executeNonQueryCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void GetDataSet_WhenCalled_ExecutesGivenQueryAndReturnsDataTable()
        {
            // Arrange
            const string sqlCommandText = "select * from DummyTable where Id = @id";
            const string paramKey = "id";
            const int paramValue = 5;

            var paramsTable = new Hashtable()
            {
                { paramKey, paramValue }
            };

            var sqlCommandCtorCommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCommandText = commandText;
            };

            var sqlDataAdapterCtorCommandText = string.Empty;
            var parameterList = new List<SqlParameter>();
            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
            {
                if (sqlCommand == null)
                {
                    throw new ArgumentNullException("sqlCommand");
                }

                sqlDataAdapterCtorCommandText = sqlCommand.CommandText;

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    parameterList.Add(param);
                }
            };

            var expectedDataTable = new DataTable();
            var fillMethodCalled = false;
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                dataSet.Tables.Add(expectedDataTable);
                fillMethodCalled = true;
                return -1;
            };

            // Act
            var returnedDataSet = _testEntity.GetDataSet(sqlCommandText, paramsTable);

            // Assert
            returnedDataSet.ShouldSatisfyAllConditions(
                () => returnedDataSet.Tables.Count.ShouldBe(1),
                () => returnedDataSet.Tables[0].ShouldBeSameAs(expectedDataTable),
                () => sqlCommandCtorCommandText.ShouldBe(sqlCommandText),
                () => fillMethodCalled.ShouldBeTrue(),
                () => parameterList.ShouldContain(param => param.ParameterName == string.Format("@{0}", paramKey) &&
                                                           param.Value.Equals(paramValue)));
        }

        [TestMethod]
        public void ExecuteQuery_WhenCalled_ExecutesGivenQuery()
        {
            // Arrange
            const string sqlCommandText = "insert into DummyTable (Name) values (@name)";
            const string paramKey = "name";
            const string paramValue = "Tsubasa";

            var paramsTable = new Hashtable()
            {
                { paramKey, paramValue }
            };

            var sqlCommandCtorCommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCommandText = commandText;
            };

            var executeNonQueryCalled = false;
            var parameterList = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) =>
            {
                executeNonQueryCalled = true;

                foreach (SqlParameter param in instance.Parameters)
                {
                    parameterList.Add(param);
                }

                return -1;
            };

            // Act
            _testEntity.ExecuteQuery(sqlCommandText, paramsTable, false);

            // Assert
            sqlCommandCtorCommandText.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCommandText.ShouldBe(sqlCommandText),
                () => executeNonQueryCalled.ShouldBeTrue(),
                () => parameterList.ShouldContain(param => param.ParameterName == string.Format("@{0}", paramKey) &&
                                                           param.Value.Equals(paramValue)));
        }

        [TestMethod]
        public void UpdatePriorityNumbers_WhenCalled_UpdatesNumbers()
        {
            // Arrange
            const string expectedSelectCommandText = "SELECT INT_LIST_ID FROM INT_LISTS where LIST_ID=@listid order by priority";
            const string expectedUpdateCommandText = "UPDATE INT_LISTS set Priority=@priority where INT_LIST_ID=@intlistid";
            const string expectedSelectCommandParam = "@listid";
            const string expectedUpdateCommandParam01 = "@intlistid";
            const string expectedUpdateCommandParam02 = "@priority";
            const string columnIntListId = "INT_LIST_ID";
            const int row01ListId = 1;

            var sqlCommandCtor01CommandText = string.Empty;
            var sqlCommandCtor02CommandText = string.Empty;
            var sqlCommandCtorCallCount = 0;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCallCount++;

                if (sqlCommandCtorCallCount == OneCall)
                {
                    sqlCommandCtor01CommandText = commandText;
                }
                else if (sqlCommandCtorCallCount == TwoCalls)
                {
                    sqlCommandCtor02CommandText = commandText;
                }
            };

            var sqlDataAdapterCtorCommandText = string.Empty;
            var selectCommandParameters = new List<SqlParameter>();
            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
            {
                if (sqlCommand == null)
                {
                    throw new ArgumentNullException("sqlCommand");
                }

                sqlDataAdapterCtorCommandText = sqlCommand.CommandText;
                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    selectCommandParameters.Add(param);
                }
            };

            var dataTable = new DataTable();
            dataTable.Columns.Add(columnIntListId);
            var row01 = dataTable.NewRow();
            row01[columnIntListId] = row01ListId;
            dataTable.Rows.Add(row01);

            var fillMethodCalled = false;
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                if (dataSet == null)
                {
                    throw new ArgumentNullException("dataSet");
                }

                dataSet.Tables.Add(dataTable);
                fillMethodCalled = true;
                return -1;
            };

            var updateCommandParameters = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) =>
            {
                foreach (SqlParameter param in instance.Parameters)
                {
                    updateCommandParameters.Add(param);
                }

                return -1;
            };

            var listId = Guid.NewGuid();

            // Act
            _testEntity.UpdatePriorityNumbers(listId);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => sqlCommandCtor01CommandText.ShouldBe(expectedSelectCommandText),
                () => sqlCommandCtor02CommandText.ShouldBe(expectedUpdateCommandText),
                () => fillMethodCalled.ShouldBeTrue(),
                () => selectCommandParameters.ShouldContain(param => param.ParameterName == expectedSelectCommandParam &&
                                                                     param.Value.Equals(listId)),
                () => updateCommandParameters.ShouldContain(param => param.ParameterName == expectedUpdateCommandParam01 &&
                                                                     param.Value.Equals(row01ListId.ToString())),
                () => updateCommandParameters.ShouldContain(param => param.ParameterName == expectedUpdateCommandParam02 &&
                                                                     param.Value.Equals(1)));
        }

        [TestMethod]
        public void ProcessItemOutgoing_WhenTypeIs2_SelectsDataFromIntListToDelete()
        {
            // Arrange
            const string expectedCommandText = "SELECT INT_LIST_ID FROM INT_LISTS where LIST_ID=@listid and INT_COLID=@intcolid";
            const string expectedCommandParam01 = "@listid";
            const string expectedCommandParam02 = "@intcolid";

            var sqlCommandCtorCommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCommandText = commandText;
            };

            const int fieldsCount = 1;
            var expectedIntListId = Guid.NewGuid();
            var shimSqlDataReader = new ShimSqlDataReader();
            shimSqlDataReader.FieldCountGet = () => fieldsCount;
            shimSqlDataReader.GetGuidInt32 = (columnIndex) => expectedIntListId;

            var readMethodSwitcher = false;
            shimSqlDataReader.Read = () => readMethodSwitcher = !readMethodSwitcher;

            var executeReaderCalled = false;
            var parameterList = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteReader = (instance) =>
            {
                executeReaderCalled = true;
                foreach (SqlParameter param in instance.Parameters)
                {
                    parameterList.Add(param);
                }

                return shimSqlDataReader.Instance;
            };

            var dummyTable = new DataTable();
            dummyTable.Columns.Add(ColumnNameType);
            dummyTable.Columns.Add(ColumnNameIntItemId);
            dummyTable.Columns.Add(ColumnNameItemId);
            dummyTable.Columns.Add(ColumnNameListId);
            dummyTable.Columns.Add(ColumnNameColId);
            var dataRow = dummyTable.NewRow();

            const string typeDelete = "2";
            const int intItemId = 1;
            const int itemId = 2;
            const int listId = 3;
            const int colId = 4;
            dataRow[ColumnNameType] = typeDelete;
            dataRow[ColumnNameIntItemId] = intItemId;
            dataRow[ColumnNameItemId] = itemId;
            dataRow[ColumnNameListId] = listId;
            dataRow[ColumnNameColId] = colId;

            var intListIdArg = Guid.Empty;
            ShimIntegrationCore.AllInstances.GetPropertiesGuid = (instance, intListId) =>
            {
                intListIdArg = intListId;
                return new Hashtable();
            };
            ShimIntegrationCore.AllInstances.PostIntegrationDeleteToExternalDataTableGuidGuid = (a, b, c, d) => { };
            // Act
            _testEntityPrivate.Invoke(MethodProcessItemOutgoing, dataRow);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                () => executeReaderCalled.ShouldBeTrue(),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam01 &&
                                                           param.Value.Equals(listId.ToString())),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam02 &&
                                                           param.Value.Equals(colId.ToString())),
                () => intListIdArg.ShouldBe(expectedIntListId));
        }

        [TestMethod]
        public void LogMessage_WhenCalled_InsertsLogMessage()
        {
            // Arrange
            const string expectedCommandText = "INSERT INTO INT_LOG (INT_LIST_ID, LIST_ID, LOGTYPE, LOGTEXT) VALUES (@intlistid, @listid, @type, @text)";
            const string expectedParamIntlistid = "@intlistid";
            const string expectedParamListid = "@listid";
            const string expectedParamMessage = "@text";
            const string expectedParamType = "@type";
            const string intListId = "1";
            const string listId = "2";
            const string message = "Message";
            const int type = 1;

            var sqlCommandCtorCommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCommandText = commandText;
            };

            var executeNonQueryCalled = false;
            var parameterList = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) =>
            {
                executeNonQueryCalled = true;

                foreach (SqlParameter param in instance.Parameters)
                {
                    parameterList.Add(param);
                }

                return -1;
            };

            // Act
            _testEntity.LogMessage(intListId, listId, message, type);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                () => executeNonQueryCalled.ShouldBeTrue(),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamIntlistid &&
                                                           param.Value.Equals(intListId)),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamListid &&
                                                           param.Value.Equals(listId)),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamMessage &&
                                                           param.Value.Equals(message)),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamType &&
                                                           param.Value.Equals(type)));
        }

        [TestMethod]
        public void PostCheckBit_IfItemCheckExistsInDatabase_UpdatesCheckLog()
        {
            // Arrange
            const string expectedSelectCommandText = "SELECT * FROM INT_CHECK WHERE INT_LIST_ID=@intlistid and ITEM_ID=@itemid";
            const string expectedUpdateCommandText = "UPDATE INT_CHECK SET CHECKBIT=@check, CHECKTIME=GETDATE() WHERE INT_LIST_ID=@intlistid and ITEM_ID=@itemid";
            const string expectedParamIntListId = "@intlistid";
            const string expectedParamItemId = "@itemid";
            const string expectedParamCheck = "@check";

            var sqlCommandCtor01CommandText = string.Empty;
            var sqlCommandCtor02CommandText = string.Empty;
            var sqlCommandCtorCallCount = 0;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCallCount++;
                if (sqlCommandCtorCallCount == OneCall)
                {
                    sqlCommandCtor01CommandText = commandText;
                }
                else if (sqlCommandCtorCallCount == TwoCalls)
                {
                    sqlCommandCtor02CommandText = commandText;
                }
            };

            var shimSqlDataReader = new ShimSqlDataReader();
            shimSqlDataReader.Read = () => true;

            var executeReaderCalled = false;
            var selectCommandParameters = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteReader = (instance) =>
            {
                executeReaderCalled = true;

                foreach (SqlParameter param in instance.Parameters)
                {
                    selectCommandParameters.Add(param);
                }

                return shimSqlDataReader.Instance;
            };

            var executeNonQueryCalled = false;
            var updateCommandParameters = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) =>
            {
                executeNonQueryCalled = true;

                foreach (SqlParameter param in instance.Parameters)
                {
                    updateCommandParameters.Add(param);
                }

                return -1;
            };

            var intListId = Guid.NewGuid();
            const string itemId = "1";
            const bool check = true;

            // Act
            _testEntityPrivate.Invoke(MethodPostCheckBit, intListId, itemId, check);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => sqlCommandCtor01CommandText.ShouldBe(expectedSelectCommandText),
                () => sqlCommandCtor02CommandText.ShouldBe(expectedUpdateCommandText),
                () => executeReaderCalled.ShouldBeTrue(),
                () => selectCommandParameters.ShouldContain(param => param.ParameterName == expectedParamIntListId &&
                                                                     param.Value.Equals(intListId)),
                () => selectCommandParameters.ShouldContain(param => param.ParameterName == expectedParamItemId &&
                                                                     param.Value.Equals(itemId)),
                () => executeNonQueryCalled.ShouldBeTrue(),
                () => updateCommandParameters.ShouldContain(param => param.ParameterName == expectedParamIntListId &&
                                                                     param.Value.Equals(intListId)),
                () => updateCommandParameters.ShouldContain(param => param.ParameterName == expectedParamItemId &&
                                                                     param.Value.Equals(itemId)),
                () => updateCommandParameters.ShouldContain(param => param.ParameterName == expectedParamCheck &&
                                                                     param.Value.Equals(check)));
        }

        [TestMethod]
        public void PostCheckBit_IfItemCheckDoesNotExistInDatabase_InsertsCheckLog()
        {
            // Arrange
            const string expectedInsertCommandText = "INSERT INTO INT_CHECK (INT_LIST_ID, ITEM_ID, CHECKBIT, CHECKTIME) VALUES (@intlistid, @itemid, @check, GETDATE())";
            const string expectedParamIntListId = "@intlistid";
            const string expectedParamItemId = "@itemid";
            const string expectedParamCheck = "@check";

            var sqlCommandCtor02CommandText = string.Empty;
            var sqlCommandCtorCallCount = 0;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCallCount++;
                if (sqlCommandCtorCallCount == TwoCalls)
                {
                    sqlCommandCtor02CommandText = commandText;
                }
            };

            var shimSqlDataReader = new ShimSqlDataReader();
            shimSqlDataReader.Read = () => false;

            ShimSqlCommand.AllInstances.ExecuteReader = (instance) => shimSqlDataReader.Instance;

            var executeNonQueryCalled = false;
            var insertCommandParameters = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) =>
            {
                executeNonQueryCalled = true;

                foreach (SqlParameter param in instance.Parameters)
                {
                    insertCommandParameters.Add(param);
                }

                return -1;
            };

            var intListId = Guid.NewGuid();
            const string itemId = "1";
            const bool check = true;

            // Act
            _testEntityPrivate.Invoke(MethodPostCheckBit, intListId, itemId, check);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => sqlCommandCtor02CommandText.ShouldBe(expectedInsertCommandText),
                () => executeNonQueryCalled.ShouldBeTrue(),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamIntListId &&
                                                                     param.Value.Equals(intListId)),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamItemId &&
                                                                     param.Value.Equals(itemId)),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamCheck &&
                                                                     param.Value.Equals(check)));
        }

        [TestMethod]
        public void GetItemButtons_WhenCalled_SelectsDataAndReturnsItemButtons()
        {
            // Arrange
            const string expectedCommandText = "SELECT     dbo.INT_CONTROLS.CONTROL, dbo.INT_CONTROLS.IMAGE, dbo.INT_CONTROLS.TITLE,  dbo.INT_CONTROLS.WINDOWSTYLE FROM         dbo.INT_LISTS INNER JOIN dbo.INT_CONTROLS ON dbo.INT_LISTS.INT_LIST_ID = dbo.INT_CONTROLS.INT_LIST_ID WHERE LIST_ID=@listid and LOCAL=0 and GLOBAL=0";
            const string expectedCommandParam = "@listid";
            const string colNameControl = "CONTROL";
            const string colNameImage = "IMAGE";
            const string colNameTitle = "TITLE";
            const string colNameWindowStyle = "WINDOWSTYLE";
            const string control = "control";
            const string image = "image";
            const string title = "title";
            var windowStyleValue = (int)IntegrationControlWindowStyle.FullDialog;

            var sqlCommandCtorCommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                instance.CommandText = commandText;
                sqlCommandCtorCommandText = commandText;
            };

            var dataAdapterCtorCommandText = string.Empty;
            var parameterList = new List<SqlParameter>();
            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
            {
                if (sqlCommand == null)
                {
                    throw new ArgumentNullException("sqlCommand");
                }

                dataAdapterCtorCommandText = sqlCommand.CommandText;

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    parameterList.Add(param);
                }
            };

            var dataTable = new DataTable();
            dataTable.Columns.Add(colNameControl);
            dataTable.Columns.Add(colNameImage);
            dataTable.Columns.Add(colNameTitle);
            dataTable.Columns.Add(colNameWindowStyle);

            var row01 = dataTable.NewRow();
            row01[colNameControl] = control;
            row01[colNameImage] = image;
            row01[colNameTitle] = title;
            row01[colNameWindowStyle] = windowStyleValue;

            dataTable.Rows.Add(row01);

            var fillMethodCalled = false;
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                if (dataSet == null)
                {
                    throw new ArgumentNullException("dataSet");
                }

                fillMethodCalled = true;
                dataSet.Tables.Add(dataTable);
                return -1;
            };

            var listid = Guid.NewGuid();
            var li = new ShimSPListItem();
            string errors;

            // Act
            var result = _testEntity.GetItemButtons(listid, li, out errors) as List<IntegrationControl>;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                () => dataAdapterCtorCommandText.ShouldBe(expectedCommandText),
                () => fillMethodCalled.ShouldBeTrue(),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam &&
                                                           param.Value.Equals(listid)),
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(1),
                () => result.ShouldContain(item => item.Control == control &&
                                                   item.Image == image &&
                                                   item.Title == title &&
                                                   item.Window == IntegrationControlWindowStyle.FullDialog));
        }

        [TestMethod]
        public void GetGlobalButtons_WhenCalled_SelectsDataAndReturnsGlobalButtons()
        {
            // Arrange
            const string expectedCommandText = "SELECT     dbo.INT_CONTROLS.CONTROL, dbo.INT_CONTROLS.IMAGE, dbo.INT_CONTROLS.TITLE FROM         dbo.INT_LISTS INNER JOIN dbo.INT_CONTROLS ON dbo.INT_LISTS.INT_LIST_ID = dbo.INT_CONTROLS.INT_LIST_ID WHERE LIST_ID=@listid and LOCAL=0 and GLOBAL=0";
            const string expectedCommandParam = "@listid";
            const string colNameControl = "CONTROL";
            const string colNameImage = "IMAGE";
            const string colNameTitle = "TITLE";
            const string control = "control";
            const string image = "image";
            const string title = "title";

            var sqlCommandCtorCommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                instance.CommandText = commandText;
                sqlCommandCtorCommandText = commandText;
            };

            var dataAdapterCtorCommandText = string.Empty;
            var parameterList = new List<SqlParameter>();
            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
            {
                if (sqlCommand == null)
                {
                    throw new ArgumentNullException("sqlCommand");
                }

                dataAdapterCtorCommandText = sqlCommand.CommandText;

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    parameterList.Add(param);
                }
            };

            var dataTable = new DataTable();
            dataTable.Columns.Add(colNameControl);
            dataTable.Columns.Add(colNameImage);
            dataTable.Columns.Add(colNameTitle);

            var row01 = dataTable.NewRow();
            row01[colNameControl] = control;
            row01[colNameImage] = image;
            row01[colNameTitle] = title;

            dataTable.Rows.Add(row01);

            var fillMethodCalled = false;
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                if (dataSet == null)
                {
                    throw new ArgumentNullException("dataSet");
                }

                fillMethodCalled = true;
                dataSet.Tables.Add(dataTable);
                return -1;
            };

            var listid = Guid.NewGuid();
            var li = new ShimSPListItem();
            string errors;

            // Act
            var result = _testEntity.GetGlobalButtons(listid, li, out errors);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                () => dataAdapterCtorCommandText.ShouldBe(expectedCommandText),
                () => fillMethodCalled.ShouldBeTrue(),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam &&
                                                           param.Value.Equals(listid)),
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(1),
                () => result.ShouldContain(item => item.Control == control &&
                                                   item.Image == image &&
                                                   item.Title == title));
        }

        [TestMethod]
        public void GetProperties_IfDataReaderReturnsNoResult_ReturnsEmptyHastable()
        {
            // Arrange
            const string expectedCommand01Text = "SELECT     dbo.INT_MODULES.CustomProps FROM         dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID WHERE INT_LIST_ID=@intlistid";
            const string expectedCommand02Text = "SELECT     Property, Value FROM INT_PROPS WHERE INT_LIST_ID=@intlistid";
            const string expectedCommandParam = "@intlistid";

            var sqlCommandCtor01CommandText = string.Empty;
            var sqlCommandCtor02CommandText = string.Empty;
            var sqlCommandCtorCallCount = 0;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, sqlCommand) =>
            {
                sqlCommandCtorCallCount++;

                if (sqlCommandCtorCallCount == OneCall)
                {
                    sqlCommandCtor01CommandText = commandText;
                }
                else if (sqlCommandCtorCallCount == TwoCalls)
                {
                    sqlCommandCtor02CommandText = commandText;
                }
            };

            const int totalFieldsCount = 2;
            var shimSqlDataReader = new ShimSqlDataReader();
            shimSqlDataReader.Read = () => false;
            shimSqlDataReader.FieldCountGet = () => totalFieldsCount;
            
            var executeReaderCallCount = 0;
            var parameterList = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                executeReaderCallCount++;

                if (executeReaderCallCount == OneCall)
                {
                    foreach (SqlParameter param in instance.Parameters)
                    {
                        parameterList.Add(param);
                    }
                }

                return shimSqlDataReader.Instance;
            };

            var intListId = Guid.NewGuid();

            // Act
            var propsTable = _testEntity.GetProperties(intListId);

            // Assert
            propsTable.ShouldSatisfyAllConditions(
                () => propsTable.ShouldNotBeNull(),
                () => propsTable.Values.Count.ShouldBe(0),
                () => sqlCommandCtor01CommandText.ShouldBe(expectedCommand01Text),
                () => sqlCommandCtor02CommandText.ShouldBe(expectedCommand02Text),
                () => executeReaderCallCount.ShouldBe(2),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam &&
                                                           param.Value.Equals(intListId)));
        }

        [TestMethod]
        public void GetIntegrator_WhenCalled_ReturnsIntegrator()
        {
            // Arrange
            const string expectedCommandText = "SELECT     dbo.INT_MODULES.MODULE_ID, dbo.INT_MODULES.NetAssembly, dbo.INT_MODULES.NetClass,Title,INT_KEY,LIST_ID,INT_COLID,INT_LIST_ID FROM         dbo.INT_LISTS INNER JOIN dbo.INT_MODULES ON dbo.INT_LISTS.MODULE_ID = dbo.INT_MODULES.MODULE_ID WHERE INT_LIST_ID=@intlistid";
            const string expectedCommandParam = "@intlistid";

            var sqlCommandCtorCommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCommandText = commandText;
            };

            const int indexOfAssemblyName = 1;
            const int indexOfTypeName = 2;
            const int indexOfTitle = 3;
            const int indexOfIntKey = 4;
            const int indexOfListId = 5;
            const int indexOfColId = 6;
            const int indexOfIntListId = 7;
            var readMethodResult = false;

            var shimSqlDataReader = new ShimSqlDataReader();
            shimSqlDataReader.Read = () => readMethodResult = !readMethodResult;
            shimSqlDataReader.FieldCountGet = () => indexOfIntListId + 1;

            var parameterList = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                foreach (SqlParameter param in instance.Parameters)
                {
                    parameterList.Add(param);
                }

                return shimSqlDataReader.Instance;
            };

            const string typeName = "EPMLiveCore.Tests.API.Integration.TestIntegrator";
            const string title = "title";
            const string intKey = "key";
            var listId = Guid.NewGuid();
            var intListId = Guid.NewGuid();
            var colId = 1;

            shimSqlDataReader.GetStringInt32 = (fieldIndex) =>
            {
                switch (fieldIndex)
                {
                    case indexOfAssemblyName:
                        return Assembly.GetAssembly(typeof(IntegrationCoreTest)).FullName;
                    case indexOfTypeName:
                        return typeName;
                    case indexOfTitle:
                        return title;
                    case indexOfIntKey:
                        return intKey;
                    default:
                        throw new ArgumentOutOfRangeException("fieldIndex");
                }
            };

            shimSqlDataReader.GetGuidInt32 = (fieldIndex) =>
            {
                switch (fieldIndex)
                {
                    case indexOfListId:
                        return listId;
                    case indexOfIntListId:
                        return intListId;
                    default:
                        throw new ArgumentOutOfRangeException("fieldIndex");
                }
            };

            shimSqlDataReader.GetInt32Int32 = (fieldIndex) =>
            {
                if (fieldIndex == indexOfColId)
                {
                    return colId;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("fieldIndex");
                }
            };

            // Act
            var result = _testEntityPrivate.Invoke(MethodGetIntegrator, intListId) as IntegratorDef;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam &&
                                                           param.Value.Equals(intListId)),
                () => result.ShouldNotBeNull(),
                () => result.Title.ShouldBe(title),
                () => result.IntKey.ShouldBe(intKey),
                () => result.ListId.ShouldBe(listId),
                () => result.intlistid.ShouldBe(intListId),
                () => result.intcol.ShouldBe(string.Concat(TextIntUid, colId)),
                () => result.iIntegrator.ShouldNotBeNull(),
                () => result.iIntegrator.ShouldBeOfType<TestIntegrator>());
        }

        [TestMethod]
        public void GetIntegratorFromModule_WhenCalled_ReturnsIntegrator()
        {
            // Arrange
            const string expectedCommandText = "SELECT NetAssembly, NetClass,Title FROM INT_MODULES WHERE MODULE_ID=@moduleid";
            const string expectedCommandParam = "@moduleid";

            var sqlCommandCtorCommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCommandText = commandText;
            };

            var readMethodResult = false;
            var shimSqlDataReader = new ShimSqlDataReader();
            shimSqlDataReader.Read = () => readMethodResult = !readMethodResult;

            var parameterList = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                foreach (SqlParameter param in instance.Parameters)
                {
                    parameterList.Add(param);
                }

                return shimSqlDataReader.Instance;
            };

            const int indexOfAssemblyName = 0;
            const int indexOfTypeName = 1;
            const int indexOfTitle = 2;
            const string typeName = "EPMLiveCore.Tests.API.Integration.TestIntegrator";
            var listId = Guid.NewGuid();
            var moduleId = Guid.NewGuid();

            shimSqlDataReader.GetStringInt32 = (fieldIndex) =>
            {
                switch (fieldIndex)
                {
                    case indexOfAssemblyName:
                        return Assembly.GetAssembly(typeof(IntegrationCoreTest)).FullName;
                    case indexOfTypeName:
                        return typeName;
                    case indexOfTitle:
                        return string.Empty;
                    default:
                        throw new ArgumentOutOfRangeException("fieldIndex");
                }
            };

            var title = string.Empty;

            // Act
            var result = _testEntityPrivate.Invoke(MethodGetIntegratorFromModule, moduleId, title) as IIntegrator;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedCommandParam &&
                                                           param.Value.Equals(moduleId)),
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeOfType<TestIntegrator>());
        }

        [TestMethod]
        public void SubmitDeleteListEvent_WhenCalled_InsertsDeleteEvent()
        {
            // Arrange
            const string expectedSelectCommandText = "SELECT INT_COLID FROM INT_LISTS where LIST_ID=@listid";
            const string expectedInsertCommandText = "INSERT INTO INT_EVENTS (LIST_ID, ITEM_ID, INTITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @itemid, @intitemid, @colid, 0, 1, @type)";
            const string expectedParamListId = "@listid";
            const string expectedParamItemId = "@itemid";
            const string expectedParamIntItemId = "@intitemid";
            const string expectedParamColId = "@colid";
            const string expectedParamType = "@type";
            const string colNameIntColId = "INT_COLID";
            const int colId = 2;

            var sqlCommandCtor01CommandText = string.Empty;
            var sqlCommandCtor02CommandText = string.Empty;
            var sqlCommandCtorCallCount = 0;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCallCount++;
                instance.CommandText = commandText;

                if (sqlCommandCtorCallCount == OneCall)
                {
                    sqlCommandCtor01CommandText = commandText;
                }
                else if (sqlCommandCtorCallCount == TwoCalls)
                {
                    sqlCommandCtor02CommandText = commandText;
                }
            };

            var selectCommandParameters = new List<SqlParameter>();
            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
            {
                if (sqlCommand == null)
                {
                    throw new ArgumentNullException("sqlCommand");
                }

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    selectCommandParameters.Add(param);
                }
            };
            
            var dataTable = new DataTable();
            dataTable.Columns.Add(colNameIntColId);

            var row01 = dataTable.NewRow();
            row01[colNameIntColId] = colId;
            dataTable.Rows.Add(row01);
            
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                if (dataSet == null)
                {
                    throw new ArgumentNullException("dataSet");
                }

                dataSet.Tables.Add(dataTable);

                return -1;
            };

            var insertCommandParameters = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                foreach (SqlParameter param in instance.Parameters)
                {
                    insertCommandParameters.Add(param);
                }

                return -1;
            };

            var listId = Guid.NewGuid();
            const int itemId = 1;
            const int expectedType = 2;
            var intUniqueId = Guid.NewGuid();

            var shimSpList = new ShimSPList();
            shimSpList.IDGet = () => listId;

            var shimSpListItem = new ShimSPListItem();
            shimSpListItem.ParentListGet = () => shimSpList.Instance;
            shimSpListItem.IDGet = () => itemId;
            shimSpListItem.ItemGetString = (fieldName) =>
            {
                return fieldName == string.Concat(TextIntUid, colId)
                       ? intUniqueId
                       : Guid.NewGuid();
            };

            // Act
            _testEntity.SubmitDeleteListEvent(shimSpListItem.Instance, null);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => sqlCommandCtor01CommandText.ShouldBe(expectedSelectCommandText),
                () => sqlCommandCtor02CommandText.ShouldBe(expectedInsertCommandText),
                () => selectCommandParameters.ShouldContain(param => param.ParameterName == expectedParamListId &&
                                                                     param.Value.Equals(listId)),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamItemId &&
                                                                     param.Value.Equals(itemId)),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamIntItemId &&
                                                                     param.Value.Equals(intUniqueId.ToString())),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamColId &&
                                                                     param.Value.Equals(colId.ToString())),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamType &&
                                                                     param.Value.Equals(expectedType)));
        }

        [TestMethod]
        public void SubmitListEvent_WhenCalled_InsertsListEvent()
        {
            // Arrange
            const string expectedSelectCommandText = "SELECT INT_COLID, INT_LIST_ID FROM INT_LISTS where LIST_ID=@listid";
            const string expectedInsertCommandText = "INSERT INTO INT_EVENTS (LIST_ID, ITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @itemid, @colid, 0, 1, @type)";
            const string expectedParamListId = "@listid";
            const string expectedParamItemId = "@itemid";
            const string expectedParamColId = "@colid";
            const string expectedParamType = "@type";

            var sqlCommandCtor01CommandText = string.Empty;
            var sqlCommandCtor02CommandText = string.Empty;
            var sqlCommandCtorCallCount = 0;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCallCount++;
                instance.CommandText = commandText;

                if (sqlCommandCtorCallCount == OneCall)
                {
                    sqlCommandCtor01CommandText = commandText;
                }
                else if (sqlCommandCtorCallCount == TwoCalls)
                {
                    sqlCommandCtor02CommandText = commandText;
                }
            };

            var shimDataReader = new ShimSqlDataReader();
            shimDataReader.Read = () => false;

            var selectCommandParameters = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                foreach (SqlParameter param in instance.Parameters)
                {
                    selectCommandParameters.Add(param);
                }

                return shimDataReader.Instance;
            };

            var insertCommandParameters = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                foreach (SqlParameter param in instance.Parameters)
                {
                    insertCommandParameters.Add(param);
                }

                return -1;
            };

            var listId = Guid.NewGuid();
            const int itemId = 1;
            const int expectedType = 2;
            const string expectedColId = "";
            var intUniqueId = Guid.NewGuid();

            var shimSpList = new ShimSPList();
            shimSpList.IDGet = () => listId;

            var shimSpListItem = new ShimSPListItem();
            shimSpListItem.ParentListGet = () => shimSpList.Instance;
            shimSpListItem.IDGet = () => itemId;

            var afterProperties = new ShimSPItemEventDataCollection();

            // Act
            _testEntity.SubmitListEvent(shimSpListItem.Instance, expectedType, afterProperties);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => sqlCommandCtor01CommandText.ShouldBe(expectedSelectCommandText),
                () => sqlCommandCtor02CommandText.ShouldBe(expectedInsertCommandText),
                () => selectCommandParameters.ShouldContain(param => param.ParameterName == expectedParamListId &&
                                                                     param.Value.Equals(listId)),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamListId &&
                                                                     param.Value.Equals(listId)),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamItemId &&
                                                                     param.Value.Equals(itemId)),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamColId &&
                                                                     param.Value.Equals(expectedColId)),
                () => insertCommandParameters.ShouldContain(param => param.ParameterName == expectedParamType &&
                                                                     param.Value.Equals(expectedType)));
        }

        [TestMethod]
        public void BCheckBit_WhenCalled_ChecksBit()
        {
            // Arrange
            const string expectedCommandText = "SELECT CHECKBIT,CHECKTIME FROM dbo.INT_LISTS INNER JOIN dbo.INT_CHECK ON dbo.INT_LISTS.INT_LIST_ID = dbo.INT_CHECK.INT_LIST_ID WHERE INT_CHECK.INT_LIST_ID=@intlistid and ITEM_ID=@itemid and INT_COLID=@colid";
            const string expectedParamIntListId = "@intlistid";
            const string expectedParamColId = "@colid";
            const string expectedParamItemId = "@itemid";

            var sqlCommandCtorCommandText = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandCtorCommandText = commandText;
            };

            var shimDataReader = new ShimSqlDataReader();
            shimDataReader.Read = () => false;

            var parameterList = new List<SqlParameter>();
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                foreach (SqlParameter param in instance.Parameters)
                {
                    parameterList.Add(param);
                }

                return shimDataReader.Instance;
            };

            var intListId = Guid.NewGuid();
            const int itemId = 1;
            const string colId = "2";

            // Act
            var result = _testEntityPrivate.Invoke(MethodBCheckBit, intListId, itemId, colId) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(true),
                () => sqlCommandCtorCommandText.ShouldBe(expectedCommandText),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamIntListId &&
                                                           param.Value.Equals(intListId)),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamItemId &&
                                                           param.Value.Equals(itemId)),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamColId &&
                                                           param.Value.Equals(colId)));
        }

        [TestMethod]
        public void GetDataSet_IfIntegrationListIdIsEmpty_SelectsActiveList()
        {
            // Arrange
            const string expectedCommandText01 = "SELECT * FROM INT_LISTS where LIST_ID=@listid and Active=1 and LIVEOUTGOING=1 and PRIORITY > @priority order by priority";
            const string expectedCommandText02 = "SELECT SharePointColumn, IntegrationColumn, Setting FROM INT_COLUMNS where INT_LIST_ID=@intlistid";
            const string expectedParamListId = "@listid";
            const string expectedParamPriority = "@priority";
            
            const int intColId = 3;
            var intListId = Guid.Empty;

            var spListId = Guid.NewGuid();
            var shimSpList = new ShimSPList()
            {
                IDGet = () => spListId
            };

            var sqlCommandText01 = string.Empty;
            var sqlCommandText02 = string.Empty;

            ShimSqlCommand.Constructor = instance => { };

            ShimSqlCommand.AllInstances.CommandTextSetString = (instance, commandText) =>
            {
                sqlCommandText01 = commandText;
            };
            
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandText02 = commandText;
            };

            var dataTable = new DataTable();
            dataTable.Columns.Add(ColNameIntColId);
            dataTable.Columns.Add(ColNameIntListId);

            var row01 = dataTable.NewRow();
            row01[ColNameIntColId] = intColId;
            row01[ColNameIntListId] = intListId;
            dataTable.Rows.Add(row01);

            var parameterList = new List<SqlParameter>();
            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
            {
                if (sqlCommand == null)
                {
                    throw new ArgumentNullException("sqlCommand");
                }

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    parameterList.Add(param);
                }
            };

            var fillMethodCallCount = 0;
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                if (dataSet == null)
                {
                    throw new ArgumentNullException("dataSet");
                }

                fillMethodCallCount++;
                if (fillMethodCallCount == OneCall)
                {
                    dataSet.Tables.Add(dataTable);
                }
                else
                {
                    dataSet.Tables.Add(new DataTable());
                }
                
                return -1;
            };

            // Act
            _testEntity.GetDataSet(shimSpList.Instance, string.Empty, intListId);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => sqlCommandText01.ShouldBe(expectedCommandText01),
                () => sqlCommandText02.ShouldBe(expectedCommandText02),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamListId &&
                                                           param.Value.Equals(spListId)),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamPriority &&
                                                           param.Value.Equals(0)));
        }

        [TestMethod]
        public void GetDataSet_IfIntegrationListIdIsEmpty_SelectsSpecifiedList()
        {
            // Arrange
            const string expectedCommandText01 = "SELECT * FROM INT_LISTS where INT_LIST_ID=@intlistid";
            const string expectedParamIntListId = "@intlistid";

            const int intColId = 3;

            var shimSpList = new ShimSPList();
            var eventFromId = intColId.ToString();
            var intListId = Guid.NewGuid();

            var sqlCommandText01 = string.Empty;
            var sqlCommandText02 = string.Empty;

            ShimSqlCommand.Constructor = instance => { };

            ShimSqlCommand.AllInstances.CommandTextSetString = (instance, commandText) =>
            {
                sqlCommandText01 = commandText;
            };

            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                sqlCommandText02 = commandText;
            };

            var parameterList = new List<SqlParameter>();
            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) =>
            {
                if (sqlCommand == null)
                {
                    throw new ArgumentNullException("sqlCommand");
                }

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    parameterList.Add(param);
                }
            };

            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                if (dataSet == null)
                {
                    throw new ArgumentNullException("dataSet");
                }

                dataSet.Tables.Add(new DataTable());
                return -1;
            };

            // Act
            _testEntity.GetDataSet(shimSpList.Instance, eventFromId, intListId);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => sqlCommandText01.ShouldBe(expectedCommandText01),
                () => sqlCommandText02.ShouldBeEmpty(),
                () => parameterList.ShouldContain(param => param.ParameterName == expectedParamIntListId &&
                                                           param.Value.Equals(intListId)));
        }

        [TestMethod]
        public void GetDataSet_IfIntegrationListIdIsEmpty_ReturnsDataSet()
        {
            // Arrange
            const int intColId = 3;
            var shimSpList = new ShimSPList();
            var intListId = Guid.NewGuid();

            ShimSqlCommand.Constructor = instance => { };
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) => { };

            var dataTable = new DataTable();
            dataTable.Columns.Add(ColNameIntColId);
            dataTable.Columns.Add(ColNameIntListId);

            var row01 = dataTable.NewRow();
            row01[ColNameIntColId] = intColId;
            row01[ColNameIntListId] = intListId;
            dataTable.Rows.Add(row01);

            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, sqlCommand) => { };

            var fillMethodCall = 0;
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                if (dataSet == null)
                {
                    throw new ArgumentNullException("dataSet");
                }

                fillMethodCall++;

                if (fillMethodCall == OneCall)
                {
                    dataSet.Tables.Add(dataTable);
                }
                else if (fillMethodCall == TwoCalls)
                {
                    dataSet.Tables.Add(new DataTable());
                }

                return -1;
            };

            // Act
            var result = _testEntity.GetDataSet(shimSpList.Instance, string.Empty, intListId);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Tables.Count.ShouldBe(3),
                () =>
                {
                    var firstTableCols = result.Tables[0].Columns.OfType<DataColumn>();
                    firstTableCols.ShouldContain(col => col.ColumnName == ColNameSpid);
                    firstTableCols.ShouldContain(col => col.ColumnName == string.Concat(TextIntUid, intColId));
                },
                () =>
                {
                    var secondTableCols = result.Tables[1].Columns.OfType<DataColumn>();
                    secondTableCols.ShouldContain(col => col.ColumnName == ColNameFieldName);
                    secondTableCols.ShouldContain(col => col.ColumnName == ColNameType);
                    secondTableCols.ShouldContain(col => col.ColumnName == ColNameLookupIntColId);
                    secondTableCols.ShouldContain(col => col.ColumnName == ColNameLookupList);
                },
                () => result.Tables[2].TableName.ShouldBe(intListId.ToString()),
                () =>
                {
                    var thirdTableCols = result.Tables[2].Columns.OfType<DataColumn>();
                    thirdTableCols.ShouldContain(col => col.ColumnName == ColNameSharePoint);
                    thirdTableCols.ShouldContain(col => col.ColumnName == ColNameIntegration);
                    thirdTableCols.ShouldContain(col => col.ColumnName == ColNameSetting);
                },
                () => result.Tables[2].Rows.Count.ShouldBe(1),
                () =>
                {
                    var row = result.Tables[2].Rows[0];
                    row[ColNameSharePoint].ShouldBe(string.Concat(TextIntUid, intColId));
                    row[ColNameIntegration].ShouldBe(TextId);
                    row[ColNameSetting].ShouldBe(string.Empty);
                });
        }

        [TestMethod]
        public void InstallIntegration_IfInstallIntegrationReturnsTrue_DeletesIntegrationControls()
        {
            // Arrange
            _adoShims = AdoShims.ShimAdoNetCalls();

            var integratorOutMessage = string.Empty;
            var mockIntegrator = new Mock<IIntegrator>();
            mockIntegrator.Setup(intg => intg.InstallIntegration(It.IsAny<WebProperties>(),
                                                                 It.IsAny<IntegrationLog>(),
                                                                 out integratorOutMessage,
                                                                 It.IsAny<string>(),
                                                                 It.IsAny<string>()))
                                             .Returns(true);

            var integratorDef = new IntegratorDef { iIntegrator = mockIntegrator.Object };
            ShimIntegrationCore.AllInstances.GetIntegratorGuid = (_1, _2) => integratorDef;
            ShimIntegrationCore.AllInstances.GetPropertiesGuid = (_1, _2) => new Hashtable();
            ShimIntegrationCore.AllInstances.GetWebPropsHashtableGuid = (_1, _2, _3) => new WebProperties();

            // Act
            _testEntity.InstallIntegration(Guid.Empty, Guid.Empty, out integratorOutMessage);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(CmdTextDeleteIntControls) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters.OfType<SqlParameter>().Any(param => param.ParameterName == "@intlistid")),
                () => _adoShims.IsCommandExecuted(CmdTextDeleteIntControls).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(CmdTextDeleteIntControls).ShouldBeTrue());
        }

        [TestMethod]
        public void ProcessItemIncoming_IfTypeIsUpdateAndModuleIdIsExpectedGuid_ReadsIntEvent()
        {
            // Arrange
            const string moduleId = "a0950b9b-3525-40b8-a456-6403156dc49c";
            const string liveIncoming = "true";
            const string type = "1";
            var guid = Guid.NewGuid();

            _adoShims = AdoShims.ShimAdoNetCalls();

            var dataTable = new DataTable();
            dataTable.Columns.Add(ColumnNameLiveIncoming);
            dataTable.Columns.Add(ColumnNameModuleId);
            dataTable.Columns.Add(ColNameIntListId);

            var dataRowIntegration = dataTable.NewRow();
            dataRowIntegration[ColumnNameLiveIncoming] = liveIncoming;
            dataRowIntegration[ColumnNameModuleId] = moduleId;
            dataRowIntegration[ColNameIntListId] = guid;
            dataTable.Rows.Add(dataRowIntegration);

            ShimIntegrationCore.AllInstances.GetPropertiesGuid = (_1, _2) => new Hashtable();
            ShimIntegrationCore.AllInstances.LogMessageStringStringStringInt32 = (_1, _2, _3, _4, _5) => { };
            ShimIntegrationCore.AllInstances.GetDataSetStringHashtable = (_1, query, parms) =>
            {
                var dataSet = new DataSet();

                if (query == QueryReadIntLists)
                {
                    dataSet.Tables.Add(dataTable);
                }
                else
                {
                    dataSet.Tables.Add(new DataTable());
                }

                return dataSet;
            };

            var list = new ShimSPList() { IDGet = () => guid };

            var listCollection = new ShimSPListCollection();
            listCollection.ItemGetGuid = _ => list.Instance;
            ShimSPWeb.AllInstances.ListsGet = _ => listCollection.Instance;

            var dataTableArg = new DataTable();
            dataTableArg.Columns.Add(ColumnNameColId);
            dataTableArg.Columns.Add(ColumnNameListId);
            dataTableArg.Columns.Add(ColumnNameType);
            dataTableArg.Columns.Add(ColumnNameIntItemId);
            dataTableArg.Columns.Add(ColNameIntEventId);

            var dataRow = dataTableArg.NewRow();
            dataRow[ColumnNameColId] = guid;
            dataRow[ColumnNameListId] = guid;
            dataRow[ColumnNameIntItemId] = guid;
            dataRow[ColumnNameType] = type;
            dataRow[ColNameIntEventId] = guid;
            dataTableArg.Rows.Add(dataRow);

            // Act
            _testEntityPrivate.Invoke("ProcessItemIncoming", dataRow);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(QueryReadtDataFromIntEvents) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters.OfType<SqlParameter>()
                                         .Any(param => param.ParameterName.Equals("@inteventid"))),
                () => _adoShims.IsCommandExecuted(QueryReadtDataFromIntEvents).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(QueryReadtDataFromIntEvents).ShouldBeTrue());
        }

        [TestMethod]
        public void GetUserMap_Always_SelectsValueFromIntPropsTable()
        {
            // Arrange
            _adoShims = AdoShims.ShimAdoNetCalls();

            const bool reverse = true;
            var integrationListId = Guid.NewGuid();

            ShimAPITeam.GetResourcePoolStringSPWeb = (_1, _2) => new DataTable();

            // Act
            _testEntity.GetUserMap(integrationListId.ToString(), reverse);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(QueryReadValueFromIntProps) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters.OfType<SqlParameter>()
                                         .Any(param => param.ParameterName.Equals("@intlistid"))),
                () => _adoShims.IsCommandExecuted(QueryReadValueFromIntProps).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(QueryReadValueFromIntProps).ShouldBeTrue());
        }

        [TestMethod]
        public void GetUserMap_IfMappingIsUid_SelectsModuleIdFromIntListsTable()
        {
            // Arrange
            _adoShims = AdoShims.ShimAdoNetCalls();

            const bool reverse = true;
            var integrationListId = Guid.NewGuid();

            ShimAPITeam.GetResourcePoolStringSPWeb = (_1, _2) => new DataTable();

            var readCount = 0;
            ShimSqlDataReader.AllInstances.Read = _ => ++readCount == OneCall;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_1, _2) => "UID";

            // Act
            _testEntity.GetUserMap(integrationListId.ToString(), reverse);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(QueryReadModuleIdFromIntLists) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters.OfType<SqlParameter>()
                                         .Any(param => param.ParameterName.Equals("@intlistid"))),
                () => _adoShims.IsCommandExecuted(QueryReadModuleIdFromIntLists).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(QueryReadModuleIdFromIntLists).ShouldBeTrue());
        }

        [TestMethod]
        public void GetUserMap_IfModuleIdIsNotEmpty_SelectsColIdFromIntListsTable()
        {
            // Arrange
            _adoShims = AdoShims.ShimAdoNetCalls();
            ShimAPITeam.GetResourcePoolStringSPWeb = (_1, _2) => new DataTable();
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_1, _2) => "UID";
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_1, _2) => Guid.Empty;
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.Empty;

            var list = new ShimSPList() { IDGet = () => Guid.NewGuid() };
            var listCollection = new ShimSPListCollection();
            listCollection.TryGetListString = _ => list;
            ShimSPWeb.AllInstances.ListsGet = _ => listCollection.Instance;

            // Act
            _testEntity.GetUserMap(Guid.Empty.ToString(), true);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(QueryReadColIdFromIntLists) &&
                           cmd.Parameters.Count == 2 &&
                           cmd.Parameters.OfType<SqlParameter>()
                                         .Any(param => param.ParameterName.Equals("@listid")) &&
                           cmd.Parameters.OfType<SqlParameter>()
                                         .Any(param => param.ParameterName.Equals("@moduleid"))),
                () => _adoShims.IsCommandExecuted(QueryReadColIdFromIntLists).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(QueryReadColIdFromIntLists).ShouldBeTrue());
        }

        [TestMethod]
        public void GetWebProps_Always_SelectsListIdAndKeyFromIntLists()
        {
            // Arrange
            _adoShims = AdoShims.ShimAdoNetCalls();
            var shimRootWeb = new ShimSPWeb() { TitleGet = () => string.Empty };
            ShimSPSite.AllInstances.RootWebGet = _ => shimRootWeb.Instance;
            ShimSPSite.AllInstances.UrlGet = _ => string.Empty;

            // Act
            _testEntityPrivate.Invoke("GetWebProps", new Hashtable(), Guid.Empty);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(QueryReadListIdAndKeyFromIntLists) &&
                           cmd.Parameters.OfType<SqlParameter>()
                                         .Any(param => param.ParameterName.Equals("@intlistid"))),
                () => _adoShims.IsCommandExecuted(QueryReadListIdAndKeyFromIntLists).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(QueryReadListIdAndKeyFromIntLists).ShouldBeTrue());
        }

        private static void FakesForSpSecurity()
        {
            ShimSqlConnection.ConstructorString = (_, stringConn) => new ShimSqlConnection();

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (action) =>
            {
                action();
            };
        }

        private static void FakesForConstructor()
        {
            ShimCoreFunctions.getConnectionStringGuid = _ => string.Empty;

            ShimSPSite.ConstructorGuid = (instance, guid) => new ShimSPSite(instance)
            {
                Dispose = () => { },
                WebApplicationGet = () => new ShimSPWebApplication(),
                OpenWeb = () => new ShimSPWeb
                {
                    ServerRelativeUrlGet = () => "Dummy Url",
                    NameGet = () => "Dummy Name",
                    IDGet = () => Guid.NewGuid()
                }
            };
        }
    }

    public class TestIntegrator : IIntegrator
    {
        public TransactionTable DeleteItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            throw new NotImplementedException();
        }

        public List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetDropDownValues(WebProperties WebProps, IntegrationLog log, string Property, string ParentPropertyValue)
        {
            throw new NotImplementedException();
        }

        public DataTable GetItem(WebProperties WebProps, IntegrationLog log, string ItemID, DataTable Items)
        {
            throw new NotImplementedException();
        }

        public bool InstallIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey, string APIUrl)
        {
            throw new NotImplementedException();
        }

        public DataTable PullData(WebProperties WebProps, IntegrationLog log, DataTable Items, DateTime LastSynchDate)
        {
            throw new NotImplementedException();
        }

        public bool RemoveIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey)
        {
            throw new NotImplementedException();
        }

        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            throw new NotImplementedException();
        }

        public TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            throw new NotImplementedException();
        }
    }
}

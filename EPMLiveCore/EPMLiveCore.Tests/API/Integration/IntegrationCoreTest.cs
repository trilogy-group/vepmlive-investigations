using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using EPMLiveCore.API.Integration;
using EPMLiveCore.API.Integration.Fakes;
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
        private static readonly Guid _siteId = Guid.NewGuid();
        private static readonly Guid _webId = Guid.NewGuid();

        private IDisposable _shimsContext;
        private IntegrationCore _testEntity;
        private PrivateObject _testEntityPrivate;
        private SqlConnection _sqlConnection;
        private ConnectionState _sqlConnectionState;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
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
    }
}

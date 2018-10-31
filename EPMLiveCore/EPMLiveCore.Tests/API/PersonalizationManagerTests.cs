using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using EPMLiveCore.API.Fakes;
using System.Data;
using Shouldly;
using EPMLiveCore.ReportingProxy.Fakes;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using System.Data.Fakes;

namespace EPMLiveCore.Tests.API
{
    

    [TestClass]
    public class PersonalizationManagerTests
    {
        private const string DummyString = "Dummy";
        private IDisposable shimsContext;
        private PersonalizationManager personalizationManager;
        private PrivateObject privateObject;
        private PrivateType privateType;
        private string GetPersonalizationMethodName = "GetPersonalization";
        private string BuildResponseMethodName = "BuildResponse";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            personalizationManager = new PersonalizationManager(new ShimSPWeb());
            privateObject = new PrivateObject(personalizationManager);
            privateType = new PrivateType(typeof(PersonalizationManager));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.IDGet = _ => 1;
            ShimQueryExecutor.ConstructorSPWeb = (_, web) => { };

        }

        [TestMethod]
        public void GetPersonalization_OnSuccess()
        {
            // Arrange
            const string ExpectedContent = "<Personalizations />";
            ShimPersonalizationManager.GetParametersStringIDictionaryOfStringObjectBoolean = 
                (data, parameters, includeValue) => { };
            ShimPersonalizationManager.BuildResponseDataTableXElement = (table, xmlResult) => { };
            ShimPersonalizationManager.AllInstances.GetPersonalizationDictionaryOfStringObject = 
                (_, parameters) => new DataTable();

            // Act
            var result = personalizationManager.GetPersonalization(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedContent));
        }

        [TestMethod]
        public void GetPersonalization_OnAPIException_ThrowsAPIException()
        {
            // Arrange
            ShimPersonalizationManager.GetParametersStringIDictionaryOfStringObjectBoolean =
                (data, parameters, includeValue) => 
                {
                    throw new APIException(0, string.Empty);
                };

            // Act
            Action action = () => personalizationManager.GetPersonalization(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void GetPersonalization_OnException_ThrowsAPIException()
        {
            // Arrange
            ShimPersonalizationManager.GetParametersStringIDictionaryOfStringObjectBoolean =
                (data, parameters, includeValue) =>
                {
                    throw new Exception();
                };

            // Act
            Action action = () => personalizationManager.GetPersonalization(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void GetPersonalization_WithNoParameters_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedQuery = "SELECT * FROM dbo.PERSONALIZATIONS WHERE [UserId] = @UserId";
            var executedQuery = string.Empty;
            var parameters = new Dictionary<string, object>();
            ShimQueryExecutor.AllInstances.ExecuteEpmLiveQueryStringIDictionaryOfStringObject = 
                (_, query, parameterList) =>
                {
                    executedQuery = query;
                    return new DataTable();
                };

            // Act
            var result = privateObject.Invoke(GetPersonalizationMethodName, parameters) as DataTable;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => executedQuery.ShouldNotBeEmpty(),
                () => executedQuery.ShouldBe(ExpectedQuery));
        }

        [TestMethod]
        public void GetPersonalization_WithParameters_ExecutesCorrectly()
        {
            // Arrange
            const string ParameterName = "Name";
            var expectedQuery = $"SELECT * FROM dbo.PERSONALIZATIONS WHERE [UserId] = @UserId AND ([{ParameterName}] = {ParameterName})";
            var executedQuery = string.Empty;
            var parameters = new Dictionary<string, object>
            {
                [ParameterName] = DummyString
            };
            ShimQueryExecutor.AllInstances.ExecuteEpmLiveQueryStringIDictionaryOfStringObject =
                (_, query, parameterList) =>
                {
                    executedQuery = query;
                    return new DataTable();
                };

            // Act
            var result = privateObject.Invoke(GetPersonalizationMethodName, parameters) as DataTable;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => executedQuery.ShouldNotBeEmpty(),
                () => executedQuery.ShouldBe(expectedQuery));
        }

        [TestMethod]
        public void BuildResponse_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetDataColumn = column => DummyString
                        }
                    }.GetEnumerator()
                },
                ColumnsGet = () =>
                {
                    var list = new List<DataColumn>
                    {
                        new ShimDataColumn
                        {
                            ColumnNameGet = () => "Value"
                        },
                        new ShimDataColumn
                        {
                            ColumnNameGet = () => DummyString
                        }
                    };
                    return new ShimDataColumnCollection().Bind(list);
                } 
            }.Instance;
            var resultXml = new XElement("Main");

            // Act
            privateType.InvokeStatic(BuildResponseMethodName, dataTable, resultXml);
            var firstElement = (XElement)resultXml.FirstNode;

            // Assert
            firstElement.ShouldNotBeNull();
            firstElement.Attributes().Count().ShouldBeGreaterThan(0);
            firstElement.Value.ShouldContain(DummyString);
        }


    }
}

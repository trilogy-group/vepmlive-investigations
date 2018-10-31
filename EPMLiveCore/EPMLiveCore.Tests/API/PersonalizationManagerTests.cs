using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API
{
    [TestClass]
    public class PersonalizationManagerTests
    {
        private const string DummyString = "Dummy";
        private const string GetPersonalizationMethodName = "GetPersonalization";
        private const string BuildResponseMethodName = "BuildResponse";
        private const string GetParametersMethodName = "GetParameters";
        private IDisposable shimsContext;
        private PersonalizationManager personalizationManager;
        private PrivateObject privateObject;
        private PrivateType privateType;

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
            firstElement.ShouldSatisfyAllConditions(
                () => firstElement.ShouldNotBeNull(),
                () => firstElement.Attributes()?.Count().ShouldBeGreaterThan(0),
                () => firstElement.Value.ShouldContain(DummyString));
        }

        [TestMethod]
        public void SetPersonalization_OnAPIException_ThrowsAPIException()
        {
            // Arrange
            ShimPersonalizationManager.GetParametersStringIDictionaryOfStringObjectBoolean =
                (data, dictionary, includeValue) =>
                {
                    throw new APIException(0, string.Empty);
                };

            // Act
            Action action = () => personalizationManager.SetPersonalization(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void SetPersonalization_OnException_ThrowsAPIException()
        {
            // Arrange
            ShimPersonalizationManager.AllInstances.GetPersonalizationDictionaryOfStringObject =
                (_, dictionary) =>
                {
                    throw new Exception();
                };

            // Act
            Action action = () => personalizationManager.SetPersonalization(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void SetPersonalization_DataTableEmpty_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedQuery = "INSERT INTO dbo.PERSONALIZATIONS ([Value],[Dummy],[UserId]) VALUES (@Value,Dummy,@UserId)";
            var executedQuery = "";
            const int DaysAgo = 2;
            const int DaysAfter = 3;
            var fromDate = DateTime.Now.Date.AddDays(-DaysAgo);
            var toDate = DateTime.Now.Date.AddDays(DaysAfter)
                .AddHours(23)
                .AddMinutes(59)
                .AddSeconds(59);
            var expectedFromDate = $"FromDate=\"{fromDate.ToString("yyyy-MM-dd HH:mm:ss")}\"";
            var expectedToDate = $"ToDate=\"{toDate.ToString("yyyy-MM-dd HH:mm:ss")}\"";
            ShimPersonalizationManager.GetParametersStringIDictionaryOfStringObjectBoolean =
                (data, parameters, include) =>
                {
                    parameters.Add("@Value", $"true|{DaysAgo}|true|{DaysAfter}");
                    parameters.Add(DummyString, DummyString);
                };
            ShimPersonalizationManager.AllInstances.GetPersonalizationDictionaryOfStringObject =
                (_, dict) => new DataTable();
            ShimQueryExecutor.AllInstances.ExecuteEpmLiveNonQueryStringIDictionaryOfStringObject = 
                (_, query, parameters) => 
                {
                    executedQuery = query;
                };

            // Act
            var result = personalizationManager.SetPersonalization(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedFromDate),
                () => result.ShouldContain(expectedToDate), 
                () => executedQuery.ShouldNotBeNullOrEmpty(),
                () => executedQuery.ShouldBe(ExpectedQuery));
        }

        [TestMethod]
        public void SetPersonalization_DataTableWithRows_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedQuery = "UPDATE dbo.PERSONALIZATIONS SET Value = @Value WHERE Id = @Id";
            var executedQuery = "";
            const int DaysAfter = 3;
            var fromDate = DateTime.Now.Date;
            var toDate = DateTime.Now.Date.AddDays(DaysAfter)
                .AddHours(23)
                .AddMinutes(59)
                .AddSeconds(59);
            var expectedFromDate = $"FromDate=\"{fromDate.ToString("yyyy-MM-dd HH:mm:ss")}\"";
            var expectedToDate = $"ToDate=\"{toDate.ToString("yyyy-MM-dd HH:mm:ss")}\"";
            ShimPersonalizationManager.GetParametersStringIDictionaryOfStringObjectBoolean =
                (data, parameters, include) =>
                {
                    parameters.Add("@Value", $"true||true|{DaysAfter}");
                    parameters.Add(DummyString, DummyString);
                };
            ShimPersonalizationManager.AllInstances.GetPersonalizationDictionaryOfStringObject =
                (_, dict) => new DataTable();
            ShimQueryExecutor.AllInstances.ExecuteEpmLiveNonQueryStringIDictionaryOfStringObject =
                (_, query, parameters) => 
                {
                    executedQuery = query;
                };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };

            // Act
            var result = personalizationManager.SetPersonalization(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedFromDate),
                () => result.ShouldContain(expectedToDate),
                () => executedQuery.ShouldNotBeNullOrEmpty(),
                () => executedQuery.ShouldBe(ExpectedQuery));
        }

        [TestMethod]
        public void SetPersonalization_DaysAfterParameterEmpty_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedQuery = "UPDATE dbo.PERSONALIZATIONS SET Value = @Value WHERE Id = @Id";
            var executedQuery = "";
            const int DaysAgo = 3;
            var fromDate = DateTime.Now.Date.AddDays(-DaysAgo);
            var toDate = DateTime.Now.Date;
            var expectedFromDate = $"FromDate=\"{fromDate.ToString("yyyy-MM-dd HH:mm:ss")}\"";
            var expectedToDate = $"ToDate=\"{toDate.ToString("yyyy-MM-dd HH:mm:ss")}\"";
            ShimPersonalizationManager.GetParametersStringIDictionaryOfStringObjectBoolean =
                (data, parameters, include) =>
                {
                    parameters.Add("@Value", $"true|{DaysAgo}|true|");
                    parameters.Add(DummyString, DummyString);
                };
            ShimPersonalizationManager.AllInstances.GetPersonalizationDictionaryOfStringObject =
                (_, dict) => new DataTable();
            ShimQueryExecutor.AllInstances.ExecuteEpmLiveNonQueryStringIDictionaryOfStringObject =
                (_, query, parameters) =>
                {
                    executedQuery = query;
                };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };

            // Act
            var result = personalizationManager.SetPersonalization(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedFromDate),
                () => result.ShouldContain(expectedToDate),
                () => executedQuery.ShouldNotBeNullOrEmpty(),
                () => executedQuery.ShouldBe(ExpectedQuery));
        }

        [TestMethod]
        public void GetParameters_EmptyXmlData_ThrowsException()
        {
            // Arrange
            var parameters = new Dictionary<string, object>();

            // Act
            Action action = () => privateType.InvokeStatic(GetParametersMethodName, string.Empty, parameters, true);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void GetParameters_ValueElementNotFound_ThrowsException()
        {
            // Arrange
            var parameters = new Dictionary<string, object>();
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new XElement("Root")
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => null;
                
            // Act
            Action action = () => privateType.InvokeStatic(GetParametersMethodName, DummyString, parameters, true);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void GetParameters_KeyAttributeFotFound_ThrowsException()
        {
            // Arrange
            var parameters = new Dictionary<string, object>();
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new XElement("Root")
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new XElement(name);
            ShimXElement.AllInstances.AttributeXName = (_, name) => null;

            // Act
            Action action = () => privateType.InvokeStatic(GetParametersMethodName, DummyString, parameters, true);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void GetParameters_OnSuccess_ShouldFillParameters()
        {
            // Arrange
            const string Id = "id";
            const string SiteId = "siteid";
            const string WebId = "webid";
            const string ListId = "listid";
            const string ItemId = "itemid";
            const string Fk = "fk";
            var parameters = new Dictionary<string, object>();
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new XElement("Root")
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new XElement(name);
            ShimXElement.AllInstances.AttributeXName = (_, name) => new XAttribute(name, DummyString);
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement
                {
                    ValueGet = ()  => Guid.NewGuid().ToString(),
                    AttributeXName = attrName => new XAttribute(attrName, Id)
                },
                new ShimXElement
                {
                    ValueGet = ()  => Guid.NewGuid().ToString(),
                    AttributeXName = attrName => new XAttribute(attrName, SiteId)
                },
                new ShimXElement
                {
                    ValueGet = ()  => Guid.NewGuid().ToString(),
                    AttributeXName = attrName => new XAttribute(attrName, WebId)
                },
                new ShimXElement
                {
                    ValueGet = ()  => Guid.NewGuid().ToString(),
                    AttributeXName = attrName => new XAttribute(attrName, ListId)
                },
                new ShimXElement
                {
                    ValueGet = ()  => 1.ToString(),
                    AttributeXName = attrName => new XAttribute(attrName, ItemId)
                },
                new ShimXElement
                {
                    ValueGet = ()  => Guid.NewGuid().ToString(),
                    AttributeXName = attrName => new XAttribute(attrName, Fk)
                }
            };

            // Act
            privateType.InvokeStatic(GetParametersMethodName, DummyString, parameters, true);

            // Assert
            parameters.ShouldSatisfyAllConditions(
                () => parameters.ShouldNotBeEmpty(),
                () => parameters.Keys.ShouldContain("@Id"),
                () => parameters.Keys.ShouldContain("@SiteId"),
                () => parameters.Keys.ShouldContain("@WebId"),
                () => parameters.Keys.ShouldContain("@ListId"),
                () => parameters.Keys.ShouldContain("@ItemId"),
                () => parameters.Keys.ShouldContain("@FK"));
        }

        [TestMethod]
        public void GetParameters_IdValueError_ThrowsException()
        {
            GetParameters_KeyValueError_ThrowsException("id", DummyString);
        }

        [TestMethod]
        public void GetParameters_SiteIdValueError_ThrowsException()
        {
            GetParameters_KeyValueError_ThrowsException("siteid", DummyString);
        }

        [TestMethod]
        public void GetParameters_WebIdValueError_ThrowsException()
        {
            GetParameters_KeyValueError_ThrowsException("webid", DummyString);
        }

        [TestMethod]
        public void GetParameters_ListIdValueError_ThrowsException()
        {
            GetParameters_KeyValueError_ThrowsException("listid", DummyString);
        }

        [TestMethod]
        public void GetParameters_ItemIdValueError_ThrowsException()
        {
            GetParameters_KeyValueError_ThrowsException("itemid", DummyString);
        }

        [TestMethod]
        public void GetParameters_FKValueError_ThrowsException()
        {
            GetParameters_KeyValueError_ThrowsException("fk", DummyString);
        }

        private void GetParameters_KeyValueError_ThrowsException(string key, string value)
        {
            // Arrange
            var parameters = new Dictionary<string, object>();
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new XElement("Root")
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new XElement(name);
            ShimXElement.AllInstances.AttributeXName = (_, name) => new XAttribute(name, DummyString);
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement
                {
                    ValueGet = ()  => value,
                    AttributeXName = attrName => new XAttribute(attrName, key)
                },
            };

            // Act
            Action action = () => privateType.InvokeStatic(GetParametersMethodName, DummyString, parameters, true);

            // Assert
            action.ShouldThrow<APIException>();
        }
    }
}

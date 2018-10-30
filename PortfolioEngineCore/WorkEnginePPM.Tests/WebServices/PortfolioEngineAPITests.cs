using System;
using System.Xml.Linq.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Analyzers.Fakes;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Core.Fakes;
using System.Data;
using System.Data.Fakes;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveCore.API.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    using Core.PFEDataServiceManager.Fakes;
    using Fakes;
    using Core.DataSync.Fakes;

    [TestClass]
    public class PortfolioEngineAPITests
    {
        private const string DummyString = "DummyString";
        private IDisposable shimsContext;
        private PortfolioEngineAPI portfolioEngineAPI;
        private PrivateObject privateObject;
        private PrivateType privateType;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupsShims();
            portfolioEngineAPI = new PortfolioEngineAPI();
            privateObject = new PrivateObject(portfolioEngineAPI);
            privateType = new PrivateType(typeof(PortfolioEngineAPI));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupsShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, name) => DummyString;
            ShimSPSite.AllInstances.IDGet = _ => Guid.Empty;
            ShimResources.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (_, path, username, pid, company, db, level, debugging) => { };
            ShimBaseManager.ConstructorSPWeb = (_, web) => { };
        }

        [TestMethod]
        public void PortfolioEngineAPI_SPWeb_CreatesInstance()
        {
            // Arrange
            var web = new ShimSPWeb().Instance;

            // Act
            portfolioEngineAPI = new PortfolioEngineAPI(web);
            var spWeb = privateType.GetStaticFieldOrProperty("_spWeb") as SPWeb;

            // Assert
            portfolioEngineAPI.ShouldSatisfyAllConditions(
                () => portfolioEngineAPI.ShouldNotBeNull(),
                () => spWeb.ShouldNotBeNull(),
                () => spWeb.ShouldBe(web));
        }

        [TestMethod]
        public void PortfolioEngineAPI_Should_CreatesInstance()
        {
            // Arrange
            var web = new ShimSPWeb().Instance;
            ShimSPContext.AllInstances.WebGet = _ => web;

            // Act
            portfolioEngineAPI = new PortfolioEngineAPI();
            var spWeb = privateType.GetStaticFieldOrProperty("_spWeb") as SPWeb;

            // Assert
            portfolioEngineAPI.ShouldSatisfyAllConditions(
                () => portfolioEngineAPI.ShouldNotBeNull(),
                () => spWeb.ShouldNotBeNull(),
                () => spWeb.ShouldBe(web));
        }

        [TestMethod]
        public void UploadFile_Should_ExecuteCorrectly()
        {
            // Arrange
            var fielBytes = new byte[] { 0 };
            const string FileName = "Name";
            var expectedResult = $"<UploadFileId>{DummyString}</UploadFileId>";
            ShimEPMLiveFileStore.ConstructorSPWeb = (_, web) => { };
            ShimEPMLiveFileStore.AllInstances.AddByteArray = (_, bytes) => DummyString;

            // Act
            var result = portfolioEngineAPI.UploadFile(fielBytes, FileName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedResult));
        }

        [TestMethod]
        public void UploadFile_OnException_ExecutesCorrectly()
        {
            // Arrange
            var fielBytes = new byte[] { 0 };
            const string FileName = "Name";
            var expectedResult = $"Error executing function: {DummyString}";
            ShimEPMLiveFileStore.ConstructorSPWeb = (_, web) => { };
            ShimEPMLiveFileStore.AllInstances.AddByteArray = (_, bytes) =>
            {
                throw new Exception(DummyString);
            };

            // Act
            var result = portfolioEngineAPI.UploadFile(fielBytes, FileName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedResult));
        }

        [TestMethod]
        public void ReadPermissionGroups_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ReadPermissionGroups(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void ReadResourcePermissionGroups_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ReadResourcePermissionGroups(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void ReadResourceCostCategoryRole_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ReadResourceCostCategoryRole(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void ReadResources_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ReadResources(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateResources_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateResources(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteResourceCheck_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteResourceCheck(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GenerateDataTicket_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement();
            ShimBaseAnalyzer.AllInstances.GenerateDataTicketString = (_, data) => Guid.NewGuid();

            // Act
            var result = PortfolioEngineAPI.GenerateDataTicket(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GetCostCategoryRoles_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetCostCategoryRoles(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GetDepartments_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetDepartments(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GetHolidaySchedules_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetHolidaySchedules(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GetPersonalItems_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetPersonalItems(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GetWorkSchedules_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetWorkSchedules(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateDepartments_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateDepartments(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateRoles_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateRoles(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteRoles_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteRoles(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateWorkSchedule_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateWorkSchedule(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateHolidaySchedules_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateHolidaySchedules(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteHolidaySchedule_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteHolidaySchedule(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdatePersonalItems_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdatePersonalItems(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeletePersonalItems_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeletePersonalItems(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateResourceTimeoff_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateResourceTimeoff(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateListWork_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateListWork(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateScheduledWorkByID_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateScheduledWorkByID(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteListWork_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteListWork(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeletePIListWork_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeletePIListWork(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void SetDatabaseVersion_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.SetDatabaseVersion(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void ExecuteReportExtract_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ExecuteReportExtract(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void PostTimesheetData_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.PostTimesheetData(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void PostCostValues_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.PostCostValues(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void RefreshRoles_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimRoleManager.AllInstances.RunRefresh = _ => DummyString;

            // Act
            var result = PortfolioEngineAPI.RefreshRoles(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ScheduleDataImport_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimPFEDataServiceManager.AllInstances.ScheduleDataImportString = (_, data) => DummyString;

            // Act
            var result = PortfolioEngineAPI.ScheduleDataImport(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void CollectDataImportResult_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimPFEDataServiceManager.AllInstances.CollectDataImportResultString = (_, data) => DummyString;

            // Act
            var result = PortfolioEngineAPI.CollectDataImportResult(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void DeleteResourceTimeoff_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteResourceTimeoff(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void DeleteWorkSchedule_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteWorkSchedule(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void DeleteDepartments_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteDepartments(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void Execute_Should_ExecuteCorrectly()
        {
            // Arrange
            const string FunctionName = "DeleteDepartments";
            ShimPortfolioEngineAPI.DeleteDepartmentsString = _ => DummyString;

            // Act
            var result = portfolioEngineAPI.Execute(FunctionName, DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void Execute_OnException_ReturnsExpectedErrorMessage()
        {
            // Arrange
            const string ExpectedMessage = "Error executing function";
            ShimPortfolioEngineAPI.DeleteDepartmentsString = _ => DummyString;

            // Act
            var result = portfolioEngineAPI.Execute(null, DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void ExecuteJSON_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string FunctionName = "DeleteDepartments";
            ShimPortfolioEngineAPI.DeleteDepartmentsString = _ => "<dummy></dummy>";
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            ShimJSONUtil.ConvertXmlToJsonStringString = (xml, isList) => DummyString;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => new ShimXmlAttribute
                    {
                        ValueGet = () => DummyString
                    }
                }
            };

            // Act
            var result = portfolioEngineAPI.ExecuteJSON(FunctionName, DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ExecuteJSON_OnException_ExecutesCorrectly()
        {
            // Arrange
            const string FunctionName = "DeleteDepartments";
            var expectedMessage = $"Error executing function: {DummyString}";
            ShimPortfolioEngineAPI.DeleteDepartmentsString = _ => "<dummy></dummy>";
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) =>
            {
                throw new Exception();
            };
            ShimJSONUtil.ConvertXmlToJsonStringString = (xml, isList) =>
            {
                throw new Exception(DummyString);
            };

            // Act
            var result = portfolioEngineAPI.ExecuteJSON(FunctionName, DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void GetFunctions_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetFunctions(DummyString);
            var functionTags = Regex.Matches(result, "<Function>");

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => functionTags.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void UpdateScheduledWork_ListAttributeNotFound_ReturnsErrorMessage()
        {
            // Arrange
            const string ExpectedErrorMessage = "Project List Attribute Not Found";
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument());
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                return new ShimXmlNode(new XmlDocument())
                {
                    AttributesGet = () => new ShimXmlAttributeCollection
                    {
                        ItemOfGetString = name => null
                    }
                };
            };

            // Act
            var result = PortfolioEngineAPI.UpdateScheduledWork(string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedErrorMessage));
        }

        [TestMethod]
        public void UpdateScheduledWork_IdAttributeNotFound_ReturnsErrorMessage()
        {
            // Arrange
            const string ExpectedErrorMessage = "Project ID Attribute Not Found";
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument());
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                return new ShimXmlNode(new XmlDocument())
                {
                    AttributesGet = () => new ShimXmlAttributeCollection
                    {
                        ItemOfGetString = name =>
                        {
                            return name == "ID"
                                ? null
                                : new ShimXmlAttribute { ValueGet = () => DummyString };
                        }
                    }
                };
            };

            // Act
            var result = PortfolioEngineAPI.UpdateScheduledWork(string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedErrorMessage));
        }

        [TestMethod]
        public void UpdateScheduledWork_ProjectNodeListNotFound_ReturnsErrorMessage()
        {
            // Arrange
            const string ExpectedErrorMessage = "No Project Node Listed";
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument());
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) => null;

            // Act
            var result = PortfolioEngineAPI.UpdateScheduledWork(string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedErrorMessage));
        }

        [TestMethod]
        public void UpdateScheduledWork_ProjectListNotFound_ReturnsErrorMessage()
        {
            // Arrange
            const string ExpectedErrorMessage = "Project List Not Found";
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument());
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                return new ShimXmlNode(new XmlDocument())
                {
                    AttributesGet = () => new ShimXmlAttributeCollection
                    {
                        ItemOfGetString = name =>
                        {
                            return new ShimXmlAttribute { ValueGet = () => DummyString };
                        }
                    }
                };
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                TryGetListString = name => null
            };

            // Act
            var result = PortfolioEngineAPI.UpdateScheduledWork(string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedErrorMessage));
        }

        [TestMethod]
        public void UpdateScheduledWork_ProjectItemNotFound_ReturnsErrorMessage()
        {
            // Arrange
            const string Id = "3";
            var expectedErrorMessage = $"Project Item (ID: {Id}) Not Found";
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument());
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                return new ShimXmlNode(new XmlDocument())
                {
                    AttributesGet = () => new ShimXmlAttributeCollection
                    {
                        ItemOfGetString = name =>
                        {
                            return new ShimXmlAttribute { ValueGet = () => Id };
                        }
                    }
                };
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                TryGetListString = name => new ShimSPList
                {
                    GetItemByIdInt32 = id => null
                }
            };

            // Act
            var result = PortfolioEngineAPI.UpdateScheduledWork(string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedErrorMessage));
        }

        [TestMethod]
        public void UpdateScheduledWork_OnSucces_ExecutesCorrectly()
        {
            // Arrange
            const string Id = "3";
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument());
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                return new ShimXmlNode(new XmlDocument())
                {
                    AttributesGet = () => new ShimXmlAttributeCollection
                    {
                        ItemOfGetString = name =>
                        {
                            return new ShimXmlAttribute { ValueGet = () => Id };
                        },
                        AppendXmlAttribute = attr => attr,
                        RemoveXmlAttribute = attr => attr
                    }
                };
            };
            ShimXmlNode.AllInstances.SelectNodesString = (_, name) =>
            {
                var doc = new XmlDocument();
                var element = doc.CreateElement(DummyString);
                element.Attributes.Append(doc.CreateAttribute("Id"));
                doc.AppendChild(element);
                return doc.ChildNodes;
            };
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                TryGetListString = name => new ShimSPList
                {
                    IDGet = () => Guid.NewGuid(),
                    GetItemByIdInt32 = id => new ShimSPListItem
                    {
                        IDGet = () => 1
                    }
                }
            };
            ShimAPITeam.GetResourcePoolStringSPWeb = (xml, web) => new ShimDataTable
            {
                SelectString = query => new DataRow[]
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => DummyString
                    }
                }
            };
            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection
            {
                ItemOfGetString = name => new ShimXmlAttribute()
            };
            ShimXmlDocument.AllInstances.CreateAttributeString = (_, name) => new ShimXmlAttribute
            {
                ValueSetString = value => { }
            };
            ShimXmlNode.AllInstances.OuterXmlGet = _ => DummyString;

            // Act
            var result = PortfolioEngineAPI.UpdateScheduledWork(string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty());
        }
    }
}

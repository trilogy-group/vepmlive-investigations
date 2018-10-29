using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

namespace WorkEnginePPM.Tests.WebServices
{
    using Core.PFEDataServiceManager.Fakes;
    using WorkEnginePPM.Core.DataSync.Fakes;

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
        public void ReadPermissionGroups()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ReadPermissionGroups(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void ReadResourcePermissionGroups()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ReadResourcePermissionGroups(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void ReadResourceCostCategoryRole()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ReadResourceCostCategoryRole(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void ReadResources()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ReadResources(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateResources()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateResources(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteResourceCheck()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteResourceCheck(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GenerateDataTicket()
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
        public void GetCostCategoryRoles()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetCostCategoryRoles(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GetDepartments()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetDepartments(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GetHolidaySchedules()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetHolidaySchedules(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GetPersonalItems()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetPersonalItems(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void GetWorkSchedules()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.GetWorkSchedules(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateDepartments()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateDepartments(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateRoles()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateRoles(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteRoles()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteRoles(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateWorkSchedule()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateWorkSchedule(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateHolidaySchedules()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateHolidaySchedules(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteHolidaySchedule()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteHolidaySchedule(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdatePersonalItems()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdatePersonalItems(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeletePersonalItems()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeletePersonalItems(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateResourceTimeoff()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateResourceTimeoff(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateListWork()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateListWork(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateScheduledWorkByID()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.UpdateScheduledWorkByID(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeleteListWork()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeleteListWork(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeletePIListWork()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.DeletePIListWork(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void SetDatabaseVersion()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.SetDatabaseVersion(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void ExecuteReportExtract()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.ExecuteReportExtract(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void PostTimesheetData()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.PostTimesheetData(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void PostCostValues()
        {
            // Arrange, Act
            var result = PortfolioEngineAPI.PostCostValues(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void RefreshRoles()
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
        public void ScheduleDataImport()
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
        public void CollectDataImportResult()
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
        public void DeleteResourceTimeoff()
        {
            // Arrange

            // Act
            var result = PortfolioEngineAPI.DeleteResourceTimeoff(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty());
        }

    }

}

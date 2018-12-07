using System;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Web.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.Layouts.ppm
{
    [TestClass]
    public class DBAdminTests
    {
        private const string XmlData = @"<Data PROJECT_ID=""1"" WRES_ID=""2""></Data>";
        private IDisposable _shimsContext;
        private DBAdminHandler _dbAdminHandler;
        private ShimHttpContext _shimHttpContext;
        private CStruct _cStruct;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _dbAdminHandler = new DBAdminHandler();
            _shimHttpContext = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    UrlGet = () => new Uri("http://url.com:8080")
                }
            };
            _cStruct = new CStruct();
            _cStruct.LoadXML(XmlData);
            SetupClass();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedClosePiValue()
        {
            // Arrange
            var requestContext = "ClosePI";

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe(@"<PI PROJECT_ID=""10"" PROJECT_NAME=""projectName"" PROJECT_MARKED_DELETION=""11"" PROJECT_CHECKEDOUT=""12"" RES_NAME=""RES_NAME"" PROJECT_CHECKEDOUT_DATE=""2018-12-07T00:00:00"" />");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedClosePiValueWithError()
        {
            // Arrange
            var requestContext = "ClosePI";
            ShimSqlDb.AllInstances.StatusGet = instance => StatusEnum.rsRequestCannotBeCompleted;

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe(@"<error><severity>exception</severity><location>DBAdmin.ClosePI</location><message>Empty PPM connection string, database connection skipped : ;Application Name=PortfolioEngine</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedClosePiValueWithException()
        {
            // Arrange
            var requestContext = "ClosePI";
            ShimdbaDBAdmin.ClosePIDBAccessInt32StringOut =
                (DBAccess dba, int nPROJECTID, out string sReply) =>
                {
                    throw new InvalidOperationException("Dummy message");
                };

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe("<error><severity>exception</severity><location>DBAdmin.ClosePI</location><message>Dummy message</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedOpenPiValue()
        {
            // Arrange
            var requestContext = "OpenPI";

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe(@"<PI PROJECT_ID=""10"" PROJECT_NAME=""projectName"" PROJECT_MARKED_DELETION=""11"" PROJECT_CHECKEDOUT=""12"" RES_NAME=""RES_NAME"" PROJECT_CHECKEDOUT_DATE=""2018-12-07T00:00:00"" />");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedOpenPiValueWithError()
        {
            // Arrange
            var requestContext = "OpenPI";
            ShimSqlDb.AllInstances.StatusGet = instance => StatusEnum.rsRequestCannotBeCompleted;

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe(@"<error><severity>exception</severity><location>DBAdmin.OpenPI</location><message>Empty PPM connection string, database connection skipped : ;Application Name=PortfolioEngine</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedOpenPiValueWithException()
        {
            // Arrange
            var requestContext = "OpenPI";
            ShimdbaDBAdmin.OpenPIDBAccessInt32StringOut =
                (DBAccess dba, int nPROJECTID, out string sReply) =>
                {
                    throw new InvalidOperationException("Dummy message");
                };

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe("<error><severity>exception</severity><location>DBAdmin.OpenPI</location><message>Dummy message</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedCheckInPiValue()
        {
            // Arrange
            var requestContext = "CheckInPI";

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe(@"<PI PROJECT_ID=""10"" PROJECT_NAME=""projectName"" PROJECT_MARKED_DELETION=""11"" PROJECT_CHECKEDOUT=""12"" RES_NAME=""RES_NAME"" PROJECT_CHECKEDOUT_DATE=""2018-12-07T00:00:00"" />");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedCheckInPiValueWithError()
        {
            // Arrange
            var requestContext = "CheckInPI";
            ShimSqlDb.AllInstances.StatusGet = instance => StatusEnum.rsRequestCannotBeCompleted;

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe(@"<error><severity>exception</severity><location>DBAdmin.CheckInPI</location><message>Empty PPM connection string, database connection skipped : ;Application Name=PortfolioEngine</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedCheckInPiValueWithException()
        {
            // Arrange
            var requestContext = "CheckInPI";
            ShimdbaDBAdmin.CheckInPIDBAccessInt32StringOut =
                (DBAccess dba, int nPROJECTID, out string sReply) =>
                {
                    throw new InvalidOperationException("Dummy message");
                };

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe("<error><severity>exception</severity><location>DBAdmin.CheckInPI</location><message>Dummy message</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedDeletePiValue()
        {
            // Arrange
            var requestContext = "DeletePI";

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBeEmpty();
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedDeletePiValueWithError()
        {
            // Arrange
            var requestContext = "DeletePI";
            ShimSqlDb.AllInstances.StatusGet = instance => StatusEnum.rsRequestCannotBeCompleted;

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe(@"<error><severity>exception</severity><location>DBAdmin.DeletePI</location><message>Empty PPM connection string, database connection skipped : ;Application Name=PortfolioEngine</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedDeletePiValueWithException()
        {
            // Arrange
            var requestContext = "DeletePI";
            ShimdbaDBAdmin.DeletePIDBAccessInt32StringOut =
                (DBAccess dba, int nPROJECTID, out string sReply) =>
                {
                    throw new InvalidOperationException("Dummy message");
                };

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe("<error><severity>exception</severity><location>DBAdmin.DeletePI</location><message>Dummy message</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedCanDeleteResValue()
        {
            // Arrange
            var requestContext = "CanDeleteRes";

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe("<error><severity>error</severity><location>CanDeleteResource</location><message>This resource cannot be deleted, it is used as follows:\n1: 1\n</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedCanDeleteResValueWithError()
        {
            // Arrange
            var requestContext = "CanDeleteRes";
            var index = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                return new ShimSqlDataReader
                {
                    Read = () => index++ == 2 || index == 5,
                    Close = () => { },
                    ItemGetString = stringValue => "1"
                };
            };

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe("<warning><message>This resource can be deleted, references will be changed to point to you:\n1: 1\n</message></warning>");
        }


        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedCanDeleteResValueWithException()
        {
            // Arrange
            var requestContext = "CanDeleteRes";
            ShimdbaDBAdmin.CanDeleteResourceDBAccessInt32StringOut =
                (DBAccess dba, int nPROJECTID, out string sReply) =>
                {
                    throw new InvalidOperationException("Dummy message");
                };

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe("<error><severity>exception</severity><location>DBAdmin.CanDeleteRes</location><message>Dummy message</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedDeleteResValue()
        {
            // Arrange
            var requestContext = "DeleteRes";

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe("<error><severity>error</severity><location>CostViews.DeleteCostView</location><message>This Cost View cannot be deleted, it is currently used as follows:\n\n1: 1\n</message><trace></trace></error>");
        }

        [TestMethod]
        public void DBAdminRequest_Always_ReturnExpectedDeleteResValueWithException()
        {
            // Arrange
            var requestContext = "DeleteRes";
            ShimdbaDBAdmin.DeleteResourceDBAccessInt32StringOut =
                (DBAccess dba, int nPROJECTID, out string sReply) =>
                {
                    throw new InvalidOperationException("Dummy message");
                };

            // Act
            var result = DBAdminHandler.DBAdminRequest(
                _shimHttpContext,
                requestContext,
                _cStruct);

            // Assert
            result.ShouldBe("<error><severity>exception</severity><location>DBAdmin.DeleteRes</location><message>Dummy message</message><trace></trace></error>");
        }

        private void SetupClass()
        {
            var shimSpSite = new ShimSPSite
            {
                IDGet = () => Guid.Empty
            };
            var shimSpWeb = new ShimSPWeb
            {
                SiteGet = () => shimSpSite
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {                
                WebGet = () => shimSpWeb
            };
            ShimSPSite.ConstructorGuid = (instance, guidValue) => new ShimSPSite(instance)
            {
                RootWebGet = () => shimSpWeb
            };

            ShimDataTable.AllInstances.LoadIDataReader = (instance, dataReader) => 
            {
                instance.Columns.Add("PROJECT_ID");
                instance.Columns.Add("PROJECT_NAME");
                instance.Columns.Add("PROJECT_MARKED_DELETION");
                instance.Columns.Add("PROJECT_CHECKEDOUT");
                instance.Columns.Add("RES_NAME");
                instance.Columns.Add("PROJECT_CHECKEDOUT_DATE");

                instance.Rows.Add(new object[] { 10, "projectName", 11, 12, "RES_NAME", new DateTime(2018, 12, 7) });
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, stringValue) => stringValue;
            ShimConfigFunctions.GetCleanUsernameSPWeb = spWeb => "username";
            ShimSqlDb.AllInstances.StatusGet = instance => StatusEnum.rsSuccess;

            ShimSqlConnection.AllInstances.Open = instance => { };
            ShimSqlConnection.AllInstances.Close = instance => { };
            ShimSqlConnection.AllInstances.StateGet = instance => ConnectionState.Closed;
            ShimSqlConnection.AllInstances.BeginTransaction = instance => new ShimSqlTransaction
            {
                Commit = () => { },
                Rollback = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance => 0;
            ShimSqlCommand.AllInstances.ExecuteScalar = instance => true;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                int index = 0;
                return new ShimSqlDataReader
                {
                    Read = () => index++ < 1,
                    ItemGetString = stringValue =>
                    {
                        switch (stringValue)
                        {
                            case "WEH_DATE":
                                return new DateTime(2018, 12, 7);
                            case "VIEW_UID":
                            case "FIELD_ID":
                                return 1;
                            default:
                                return "1";
                        }
                    },
                    Close = () => { }
                };
            };
        }
    }
}

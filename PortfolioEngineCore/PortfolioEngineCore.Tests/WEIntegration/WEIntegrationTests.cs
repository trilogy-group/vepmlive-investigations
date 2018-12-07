using System;
using System.Data;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests
{
    [TestClass]
    public class WEIntegrationTests
    {
        private const string BasePath = "basePath";
        private const string Username = "Username";
        private const string Id = "Id";
        private const string Company = "Company";
        private const string ConnectionString = "ConnectionString;Provider=dummyProvider";
        private const bool Debug = false;

        private WEIntegration.WEIntegration _weIntegration;
        private IDisposable _shimsContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            SetupWeIntegration();
            _weIntegration = new WEIntegration.WEIntegration(
                BasePath,
                Username,
                Id,
                Company,
                ConnectionString,
                Debug);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void SetDatabaseVersion_Always_ReturnSuccess()
        {
            // Arrange
            var data = @"
<SetDatabaseVersion>
    <Params /> 
    <Data>
        <Database Version=""43000000"" Comment="""" />
    </Data>
</SetDatabaseVersion>";

            // Act
            var result = _weIntegration.SetDatabaseVersion(data);

            // Assert
            result.ShouldBe("SUCCESS");
        }

        [TestMethod]
        public void SetDatabaseVersion_Always_ReturnFailed()
        {
            // Arrange
            var data = @"
<SetDatabaseVersion>
    <Params /> 
    <Data>
        <Database Version=""43000000"" Comment="""" />
    </Data>
</SetDatabaseVersion>";
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                throw new InvalidOperationException("Dummy message");
            };

            // Act
            var result = _weIntegration.SetDatabaseVersion(data);

            // Assert
            result.ShouldStartWith("FAILED: ");
        }

        [TestMethod]
        public void ExecuteReportExtract_Always_ReturnStatus()
        {
            // Arrange
            var data = @"
<SetDatabaseVersion>
    <Params /> 
    <Data>
        <ReportExtract Connection=""Connection"" Execute=""1"" />
    </Data>
</SetDatabaseVersion>";

            // Act
            var result = _weIntegration.ExecuteReportExtract(data);

            // Assert
            result.ShouldStartWith("STATUS");
        }

        [TestMethod]
        public void PostTimesheetData_Always_ThrowsException()
        {
            // Arrange
            var data = @"
<SetDatabaseVersion>
    <Params /> 
    <Data>
        <Timesheets>
        </Timesheets>
    </Data>
</SetDatabaseVersion>";
            ShimCStruct.AllInstances.GetListString = (instance, stringValue) => null;

            // Act
            Action action = () => _weIntegration.PostTimesheetData(data);

            // Assert
            action.ShouldThrow<PFEException>()
                .Message.ShouldBe("No Timesheet information");
        }

        [TestMethod]
        public void PostTimesheetData_Always_WithResourceNullReturnExpectedValue()
        {
            // Arrange
            var data = @"
<SetDatabaseVersion>
    <Params /> 
    <Data>
        <Timesheets>
            <Timesheet Resource=""Resource"" period_start=""2018-12-07"" period_end=""2018-12-07""></Timesheet>
        </Timesheets>
    </Data>
</SetDatabaseVersion>";

            // Act
            var result = _weIntegration.PostTimesheetData(data);

            // Assert
            result.ShouldBe("<Result Status=\"0\" Timesheets=\"1\" WithError=\"1\" />");
        }

        [TestMethod]
        public void PostTimesheetData_Always_WithProjectNullReturnExpectedValue()
        {
            // Arrange
            var data = @"
<SetDatabaseVersion>
    <Params /> 
    <Data>
        <Timesheets>
            <Timesheet Resource=""1"" period_start=""2018-12-07"" period_end=""2018-12-07"">
                <Hours Project=""Project""></Hours>
            </Timesheet>
        </Timesheets>
    </Data>
</SetDatabaseVersion>";

            // Act
            var result = _weIntegration.PostTimesheetData(data);

            // Assert
            result.ShouldBe("<Result Status=\"0\" Timesheets=\"1\" WithError=\"1\" />");
        }

        [TestMethod]
        public void PostTimesheetData_Always_DateNotBetweenPeriodReturnExpectedValue()
        {
            // Arrange
            var data = @"
<SetDatabaseVersion>
    <Params /> 
    <Data>
        <Timesheets>
            <Timesheet Resource=""1"" period_start=""2018-12-07"" period_end=""2018-12-07"">
                <Hours Project=""1"" MajorCategory=""MajorCategory"" Category=""Category"" Date=""2018-12-06"" Hours=""10"" Type=""1""></Hours>
            </Timesheet>
        </Timesheets>
    </Data>
</SetDatabaseVersion>";

            // Act
            var result = _weIntegration.PostTimesheetData(data);

            // Assert
            result.ShouldBe("<Result Status=\"0\" Timesheets=\"1\" WithError=\"1\" />");
        }

        [TestMethod]
        public void PostTimesheetData_Always_DateBetweenPeriodReturnExpectedValue()
        {
            // Arrange
            var data = @"
<SetDatabaseVersion>
    <Params /> 
    <Data>
        <Timesheets>
            <Timesheet Resource=""1"" period_start=""2018-12-07"" period_end=""2018-12-07"">
                <Hours Project=""1"" MajorCategory=""MajorCategory"" Category=""Category"" Date=""2018-12-07"" Hours=""10"" Type=""1""></Hours>
            </Timesheet>
        </Timesheets>
    </Data>
</SetDatabaseVersion>";

            // Act
            var result = _weIntegration.PostTimesheetData(data);

            // Assert
            result.ShouldBe("<Result Status=\"0\" Timesheets=\"1\" WithError=\"0\" />");
        }

        [TestMethod]
        public void DisplayProjects_Always_WithErrorReturnExpectedValue()
        {
            // Arrange
            var data = @"
<Data SessionId=""00000000-0000-0000-0000-000000000000"">
</Data>";
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                throw new InvalidOperationException("Dummy message");
            };

            // Act
            var result = _weIntegration.DisplayProjects(data);

            // Assert
            result.ShouldBe("<Reply><Error>Dummy message</Error><STATUS>99999</STATUS></Reply>");
        }

        [TestMethod]
        public void DisplayProjects_Always_WithoutErrorReturnExpectedValue()
        {
            // Arrange
            var data = @"
<Data SessionId=""00000000-0000-0000-0000-000000000000"">
</Data>";

            // Act
            var result = _weIntegration.DisplayProjects(data);

            // Assert
            result.ShouldStartWith("<Reply><Error></Error><STATUS>0</STATUS><DisplayProjects SessionId=");
        }

        [TestMethod]
        public void GetPfeCostViews_Always_ReturnExpectedValue()
        {
            // Arrange, Act
            var result = _weIntegration.GetPfeCostViews();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Columns.Count.ShouldBe(2),
                () => result.Columns[0].ColumnName.ShouldBe("costView"),
                () => result.Columns[1].ColumnName.ShouldBe("costViewId"),
                () => result.Rows.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetPfeFields_Always_ReturnExpectedValue()
        {
            // Arrange
            const int type = 1;

            // Act
            var result = _weIntegration.GetPfeFields(type);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Columns.Count.ShouldBe(3),
                () => result.Columns[0].ColumnName.ShouldBe("epkField"),
                () => result.Columns[1].ColumnName.ShouldBe("epkFieldId"),
                () => result.Columns[2].ColumnName.ShouldBe("epkFieldType"),
                () => result.Rows.Count.ShouldBe(1));
        }

        private void SetupWeIntegration()
        {
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
                        switch(stringValue)
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

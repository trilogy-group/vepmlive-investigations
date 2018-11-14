using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveReportsAdmin.Fakes;
using EPMLiveReportsAdmin.Jobs;
using EPMLiveReportsAdmin.Jobs.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.WEIntegration.Fakes;
using Shouldly;

namespace EPMLiveReporting.Tests.Jobs
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CollectJobTests
    {
        private const string DummyString = "dummyString";
        private const string CheckReqSPMethodName = "CheckReqSP";
        private const string CheckSchemaMethodName = "CheckSchema";
        private const string GetReportingConnectionMethodName = "getReportingConnection";
        private const string SetRPTSettingsMethodName = "setRPTSettings";
        private const string StringBuilderFieldName = "sbErrors";
        private readonly Guid DummyGuid = Guid.NewGuid();
        private IDisposable shimsContext;
        private CollectJob collectJob;
        private PrivateObject privateObject;
        private bool ReturnValue;
        private bool RefreshTimeSheetWasCalled = false;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            collectJob = new CollectJob();
            privateObject = new PrivateObject(collectJob);
            collectJob.JobUid = DummyGuid;
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimEPMData.ConstructorGuid = (_, guid) => { };
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMessage, longMessage, level, type, job) => true;
            ShimWEIntegration.ConstructorStringStringStringStringStringBoolean =
                (_, basePath, username, pid, compnay, db, debug) => { };
            ShimSPProcessIdentity.AllInstances.UsernameGet = _ => DummyString;
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.Dispose = _ => { };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimCollectJob.AllInstances.getReportingConnectionSPWeb = (_, web) => DummyString;
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, ds) => 1;
        }

        [TestMethod]
        public void Execute_ParamDataEmpty_ExecutesCorrectly()
        {
            // Arrange
            var processSecurityGroupsWasCalled = false;
            var setRPTSettingsWasCalled = false;
            var executeReportExtractWasCalled = false;
            var checkReqSPWasCalled = false;
            var checkSchemaWasCalled = false;
            var cleanTablesWasCalled = false;
            var removeSafelyWasCalled = false;
            var spSite = new ShimSPSite
            {
                IDGet = () => DummyGuid,
                UrlGet = () => DummyString,
                AllWebsGet = () => new ShimSPWebCollection(),
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    ItemGetGuid = guid => new ShimSPFeature()
                },
                WebApplicationGet = () => new ShimSPWebApplication
                {
                    ApplicationPoolGet = () => new ShimSPApplicationPool()
                }
            }.Instance;
            var spWeb = new ShimSPWeb
            {
                Dispose = () => { }
            };
            ShimProcessSecurity.ProcessSecurityGroupsSPSiteSqlConnectionString = 
                (site, conn, users) => processSecurityGroupsWasCalled = true;
            ShimCollectJob.AllInstances.setRPTSettingsEPMDataSPSite = 
                (_, epmData, site) => setRPTSettingsWasCalled = true;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => bool.TrueString;
            ReturnValue = true;
            ShimEPMData.AllInstances.RefreshTimesheetsStringOutGuidBoolean = RefreshTimesheets;
            ShimWEIntegration.AllInstances.ExecuteReportExtractString = (_, dataToExtract) =>
            {
                executeReportExtractWasCalled = true;
                return DummyString;
            };
            ShimCollectJob.AllInstances.CheckReqSPSqlConnection = 
                (_, connection) => checkReqSPWasCalled = true;
            ShimCollectJob.AllInstances.CheckSchemaSqlConnection = 
                (_, connection) => checkSchemaWasCalled = true;
            ShimDataScrubber.CleanTablesSPSiteEPMData = 
                (site, epmData) => cleanTablesWasCalled = true;
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection
            {
                ItemGetInt32 = index => new ShimDataTable
                {
                    RowsGet = () => new ShimDataRowCollection
                    {
                        GetEnumerator = () => new List<DataRow>
                        {
                            new ShimDataRow
                            {
                                ItemGetInt32 = i => DummyString
                            }
                        }.GetEnumerator()
                    }
                }
            };
            ShimCacheStore.AllInstances.RemoveSafelyStringStringString = 
                (_, url, category, key) => removeSafelyWasCalled = true;

            // Act
            collectJob.execute(spSite, spWeb, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => processSecurityGroupsWasCalled.ShouldBeTrue(),
                () => setRPTSettingsWasCalled.ShouldBeTrue(),
                () => executeReportExtractWasCalled.ShouldBeTrue(),
                () => checkReqSPWasCalled.ShouldBeTrue(),
                () => checkSchemaWasCalled.ShouldBeTrue(),
                () => cleanTablesWasCalled.ShouldBeTrue(),
                () => removeSafelyWasCalled.ShouldBeTrue(),
                () => RefreshTimeSheetWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_ParamDataNotEmpty_ExecutesCorrectly()
        {
            // Arrange
            const string Error = "err";
            var processSecurityGroupsWasCalled = false;
            var setRPTSettingsWasCalled = false;
            var executeReportExtractWasCalled = false;
            var checkReqSPWasCalled = false;
            var checkSchemaWasCalled = false;
            var cleanTablesWasCalled = false;
            var removeSafelyWasCalled = false;
            var spSite = new ShimSPSite
            {
                IDGet = () => DummyGuid,
                UrlGet = () => DummyString,
                AllWebsGet = () => new ShimSPWebCollection(),
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    ItemGetGuid = guid => new ShimSPFeature()
                },
                WebApplicationGet = () => new ShimSPWebApplication
                {
                    ApplicationPoolGet = () => new ShimSPApplicationPool()
                }
            }.Instance;
            var spWeb = new ShimSPWeb
            {
                Dispose = () => { },
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name =>
                    {
                        if (name == DummyString)
                        {
                            return new ShimSPList();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            };
            ShimProcessSecurity.ProcessSecurityGroupsSPSiteSqlConnectionString =
                (site, conn, users) => processSecurityGroupsWasCalled = true;
            ShimCollectJob.AllInstances.setRPTSettingsEPMDataSPSite =
                (_, epmData, site) => setRPTSettingsWasCalled = true;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => bool.TrueString;
            ReturnValue = false;
            ShimEPMData.AllInstances.RefreshTimesheetsStringOutGuidBoolean = RefreshTimesheets;
            ShimWEIntegration.AllInstances.ExecuteReportExtractString = (_, dataToExtract) =>
            {
                executeReportExtractWasCalled = true;
                return DummyString;
            };
            ShimSqlParameterCollection.AllInstances.AddWithValueStringObject = 
                (_, name, value) => 
                {
                    if (value.ToString() == Error)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return new SqlParameter();
                    }
                };
            ShimCollectJob.AllInstances.CheckReqSPSqlConnection =
                (_, connection) => checkReqSPWasCalled = true;
            ShimCollectJob.AllInstances.CheckSchemaSqlConnection =
                (_, connection) => checkSchemaWasCalled = true;
            ShimDataScrubber.CleanTablesSPSiteEPMData =
                (site, epmData) => cleanTablesWasCalled = true;
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection
            {
                ItemGetInt32 = index => new ShimDataTable
                {
                    RowsGet = () => new ShimDataRowCollection
                    {
                        ItemGetInt32 = i => new ShimDataRow
                        {
                            ItemGetInt32 = rowIndex => DummyString
                        },
                        GetEnumerator = () => new List<DataRow>
                        {
                            new ShimDataRow
                            {
                                ItemGetInt32 = i => DummyString
                            }
                        }.GetEnumerator()
                    }
                }
            };
            ShimCacheStore.AllInstances.RemoveSafelyStringStringString =
                (_, url, category, key) => removeSafelyWasCalled = true;
            var data = $"{DummyString},err";

            // Act
            collectJob.execute(spSite, spWeb, data);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => processSecurityGroupsWasCalled.ShouldBeTrue(),
                () => setRPTSettingsWasCalled.ShouldBeFalse(),
                () => executeReportExtractWasCalled.ShouldBeTrue(),
                () => checkReqSPWasCalled.ShouldBeTrue(),
                () => checkSchemaWasCalled.ShouldBeTrue(),
                () => cleanTablesWasCalled.ShouldBeTrue(),
                () => removeSafelyWasCalled.ShouldBeTrue(),
                () => RefreshTimeSheetWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_WithExceptions_LogErrorMessages()
        {
            // Arrange
            const string DummyError = "Dummy Error";
            var expectedLogMEssages = new List<string>
            {
                "Error processing security on site",
                "Updating reporting settings failed for site",
                "Process TimeSheet Data failed for site",
                "Error Processing PfE Reporting for site",
                "Error while checking SPRequirement for site",
                "Error while updating schema for site",
                "Error while cleaning tables for site",
                "Error updating status fields",
                "Cleaning Cache Failed for site",
            };
            var logMessages = new List<string>();
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMessage, longMessage, level, type, job) =>
                {
                    logMessages.Add(shortMessage);
                    logMessages.Add(longMessage);
                    return true;
                };
            var spSite = new ShimSPSite
            {
                IDGet = () => DummyGuid,
                UrlGet = () => DummyString,
                AllWebsGet = () => new ShimSPWebCollection(),
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    ItemGetGuid = guid => new ShimSPFeature()
                },
                WebApplicationGet = () => new ShimSPWebApplication
                {
                    ApplicationPoolGet = () => new ShimSPApplicationPool()
                }
            }.Instance;
            var spWeb = new ShimSPWeb
            {
                Dispose = () => { },
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList()
                }
            };
            ShimProcessSecurity.ProcessSecurityGroupsSPSiteSqlConnectionString =
                (site, conn, users) =>
                {
                    throw new Exception(DummyError);
                };
            ShimCollectJob.AllInstances.setRPTSettingsEPMDataSPSite =
                (_, epmData, site) =>
                {
                    throw new Exception(DummyError);
                };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => bool.TrueString;
            ReturnValue = true;
            ShimEPMData.AllInstances.RefreshTimesheetsStringOutGuidBoolean = RefreshTimesheetsException;
            ShimWEIntegration.AllInstances.ExecuteReportExtractString = 
                (_, dataToExtract) =>
                {
                    throw new Exception(DummyError);
                };
            ShimCollectJob.AllInstances.CheckReqSPSqlConnection =
                (_, connection) =>
                {
                    throw new Exception(DummyError);
                };
            ShimCollectJob.AllInstances.CheckSchemaSqlConnection =
                (_, connection) =>
                {
                    throw new Exception(DummyError);
                };
            ShimDataScrubber.CleanTablesSPSiteEPMData =
                (site, epmData) =>
                {
                    throw new Exception(DummyError);
                };
            ShimDataSet.AllInstances.TablesGet = _ => null;
            ShimCacheStore.AllInstances.RemoveSafelyStringStringString =
                (_, url, category, key) =>
                {
                    throw new Exception(DummyError);
                };

            // Act
            collectJob.execute(spSite, spWeb, string.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => collectJob.sErrors.ShouldNotBeNullOrEmpty(),
                () => expectedLogMEssages.ForEach(err => logMessages.Any(log => log.Contains(err))));
        }

        [TestMethod]
        public void CheckReqSP_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "IF NOT EXISTS (SELECT routine_name FROM " +
                "INFORMATION_SCHEMA.routines WHERE routine_name = 'spGetWebs')";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };

            // Act
            privateObject.Invoke(CheckReqSPMethodName, new SqlConnection());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldContain(ExpectedCommand));
        }

        [TestMethod]
        public void CheckSchema_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "IF NOT EXISTS (SELECT TABLE_NAME FROM " + 
                "INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'ReportListIds')";
            var commandExecuted = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                commandExecuted = command.CommandText;
                return 1;
            };

            // Act
            privateObject.Invoke(CheckSchemaMethodName, new SqlConnection());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldContain(ExpectedCommand));
        }

        [TestMethod]
        public void GetReportingConnection_Should_ReturnExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Data Source=dummyString;Initial Catalog=dummyString;" + 
                "User ID=dummyString;Password=dummyString";
            var spWeb = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite()
            }.Instance;
            ShimCollectJob.AllInstances.getReportingConnectionSPWeb = null;
            ShimBaseJob.AllInstances.CreateConnection = _ => new ShimSqlConnection
            {
                Open = () => { },
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                GetStringInt32 = i => DummyString,
                IsDBNullInt32 = i => false,
            };

            // Act
            var result = privateObject.Invoke(GetReportingConnectionMethodName, spWeb) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetReportingConnection_TrustedConnection_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Data Source=dummyString;Initial Catalog=dummyString;Trusted_Connection=True";
            var spWeb = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite()
            }.Instance;
            ShimCollectJob.AllInstances.getReportingConnectionSPWeb = null;
            ShimBaseJob.AllInstances.CreateConnection = _ => new ShimSqlConnection
            {
                Open = () => { },
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                GetStringInt32 = i => DummyString,
                IsDBNullInt32 = i => true,
            };

            // Act
            var result = privateObject.Invoke(GetReportingConnectionMethodName, spWeb) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetReportingConnection_OnException_ReturnsEmpty()
        {
            // Arrange
            var spWeb = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite()
            }.Instance;
            ShimCollectJob.AllInstances.getReportingConnectionSPWeb = null;
            ShimBaseJob.AllInstances.CreateConnection = _ => new ShimSqlConnection
            {
                Open = () => { },
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            privateObject.SetFieldOrProperty(StringBuilderFieldName, new StringBuilder());

            // Act
            var result = privateObject.Invoke(GetReportingConnectionMethodName, spWeb) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void SetRPTSettings_Should_ExecuteCorrectly()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            var epm = new ShimEPMData().Instance;
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        WorkDayStartHourGet = () => 5,
                        WorkDayEndHourGet = () => 10,
                        WorkDaysGet = () => 10
                    }
                }
            }.Instance;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimEPMData.AllInstances.UpdateRPTSettingsStringInt32StringOut = UpdateRPTSettings;
            privateObject.SetFieldOrProperty(StringBuilderFieldName, new StringBuilder());

            // Act
            privateObject.Invoke(SetRPTSettingsMethodName, epm, spSite);
            var errors = privateObject.GetFieldOrProperty(StringBuilderFieldName) as StringBuilder;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldNotBeNull(),
                () => errors.ToString().ShouldNotBeNullOrEmpty(),
                () => errors.ToString().ShouldContain("Error Updating RPTSettings"));
        }

        [TestMethod]
        public void SetRPTSettings_OnException_ExecuteCorrectly()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            var epm = new ShimEPMData().Instance;
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    RegionalSettingsGet = () =>
                    {
                        throw new Exception();
                    }
                }
            }.Instance;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimEPMData.AllInstances.UpdateRPTSettingsStringInt32StringOut = UpdateRPTSettings;
            privateObject.SetFieldOrProperty(StringBuilderFieldName, new StringBuilder());

            // Act
            privateObject.Invoke(SetRPTSettingsMethodName, epm, spSite);
            var errors = privateObject.GetFieldOrProperty(StringBuilderFieldName) as StringBuilder;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldNotBeNull(),
                () => errors.ToString().ShouldNotBeNullOrEmpty(),
                () => errors.ToString().ShouldContain("Error Updating RPTSettings"));
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool UpdateRPTSettings(
            EPMData epmData, 
            string nonWorkingDays, 
            int workHours, 
            out string results)
        {
            results = string.Empty;
            return true;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool RefreshTimesheets(
            EPMData empData, 
            out string message, 
            Guid jobUid, 
            bool consolidationDone)
        {
            RefreshTimeSheetWasCalled = true;
            message = DummyString;
            return ReturnValue;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool RefreshTimesheetsException(
            EPMData empData, 
            out string message, 
            Guid jobUid, 
            bool consolidationDone)
        {
            throw new Exception();
        }
    }
}

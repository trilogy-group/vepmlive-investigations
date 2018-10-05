using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveEnterprise;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLivePS.Tests.Layouts.epmlive
{
    [TestClass]
    public class RunEnterpriseSynchTest
    {
        private const string MethodRunThread = "RunThread";
        private const string Username = "username";
        private const string DummyConnectionString = "ConnectionString";
        private const int TimerJobGuidIndex = 0;
        private const int StatusIndexQuery1 = 3;
        private const int SitesIndex = 0;
        private const string QueryQueueTimerLog = "select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=9";
        private const string DeleteCommandEpmLiveLog = "delete from epmlive_log where timerjobuid=@timerjobuid";
        private const string QueryReadStatusFromQueueByTimerJobGuid = "select status from queue where timerjobuid=@timerjobuid";
        private const string DeleteQueueByTimerJobGuid = "DELETE FROM QUEUE where timerjobuid = @timerjobuid ";
        private const string InsertQueueCommand = "INSERT INTO QUEUE (timerjobuid, status, percentcomplete, dtstarted) VALUES (@timerjobuid, @status, 0, getdate()) ";
        private const string QueryReadConfigValueFromEConfig = "select config_value from econfig where config_name='ConnectedURLs'";
        private const string UpdateQueueByTimerJobGuidTemplate = "UPDATE queue set percentComplete={0} where timerjobuid='{1}'";
        private const string UpdateQueueFinally = "UPDATE queue set percentComplete=0,status=2,dtfinished=GETDATE() where timerjobuid=@timerjobuid";
        private const string InsertTimerJobs = "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid) VALUES (@timerjobuid, @siteguid, 9, 'Project Server Field Synch', 5, @webguid)";
        private const string SqlParamSiteGuid = "@siteguid";
        private const string SqlParamWebGuid = "@webguid";
        private const string SqlParamTimerJobUid = "@timerjobuid";
        private const string SqlParamStatus = "@status";
        private const string SqlParamResultText = "@resulttext";
        private const string InsertNoErrorsLog = "insert into epmlive_log (timerjobuid,result,resulttext) VALUES (@timerjobuid,'No Errors',@resulttext)";
        private const string InsertErrorsLog = "insert into epmlive_log (timerjobuid,result,resulttext) VALUES (@timerjobuid,'Errors',@resulttext)";
        private const string EpmLogTemplate = "Site: {0} ({1})<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Web: {2} ()<br>";
        private const string SiteUrl = "http://www.dummysite.com";
        private const string RootWebTitle = "Title";
        private const string WebTitle01 = "Title01";
        private static readonly Guid SiteGuid = new Guid("BCFF0DD7-8F61-4562-80CA-D9FD3F8FDF75");
        private static readonly Guid WebAppGuid = new Guid("5F379006-6A84-4FD8-ABDB-74E45CCB5AF2");
        private static readonly Guid WebGuid = new Guid("D4211DFB-70AD-499B-A16C-B465ECC3EF8F");
        private static readonly Guid TimerJobGuid = new Guid("65709CC2-E0AD-466A-8742-6F6F11B52D75");
        private static readonly string RunThreadParam = $"{SiteGuid}|{WebAppGuid}|{WebGuid}|{Username}";

        private IDisposable _shimsContext;
        private runenterprisesynch _testEntity;
        private PrivateObject _testEntityPrivate;
        private AdoShims _adoShims;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testEntity = new runenterprisesynch();
            _testEntityPrivate = new PrivateObject(_testEntity);
            _adoShims = AdoShims.ShimAdoNetCalls();

            ShimCoreFunctions.getConnectionStringGuid = _ => DummyConnectionString;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _testEntity?.Dispose();
        }

        [TestMethod]
        public void RunThread_Always_CreatesAndDisposesConnection()
        {
            // Arrange & Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.ConnectionsCreated.Count.ShouldBe(1),
                () => _adoShims.IsConnectionCreated(DummyConnectionString).ShouldBeTrue(),
                () => _adoShims.IsConnectionDisposed(DummyConnectionString).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_Always_ExecutesQueueTimerLogQuery()
        {
            // Arrange && Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(QueryQueueTimerLog) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamSiteGuid) &&
                           cmd.Parameters[0].Value.Equals(SiteGuid.ToString())),
                () => _adoShims.IsCommandExecuted(QueryQueueTimerLog).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(QueryQueueTimerLog).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_IfTimerJobGuidReturnsFromTimerLogQuery_ReadsTimerJobGuidValueAndCreateDeleteCommandWithGuidParameter()
        {
            // Arrange
            ShimDataReaderForTimerJobGuid(TimerJobGuid);

            // Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(DeleteCommandEpmLiveLog) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid) &&
                           cmd.Parameters[0].Value.Equals(TimerJobGuid)),
                () => _adoShims.IsCommandExecuted(DeleteCommandEpmLiveLog).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(DeleteCommandEpmLiveLog).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_IfTimerJobGuidAndStatusAs1ReturnsFromTimerLogQuery_ReadsTimerJobGuidAndStatusValueAndExits()
        {
            // Arrange
            const int status = 1;
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, index) => index == TimerJobGuidIndex ? TimerJobGuid : Guid.Empty;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, index) => index == StatusIndexQuery1 ? status : default(int);
            ShimSqlDataReader.AllInstances.IsDBNullInt32 = (_, index) => index != StatusIndexQuery1;

            // Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldNotContain(
                    cmd => cmd.CommandText.Equals(DeleteCommandEpmLiveLog) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid) &&
                           cmd.Parameters[0].Value.Equals(TimerJobGuid)),
                () => _adoShims.IsCommandExecuted(DeleteCommandEpmLiveLog).ShouldBeFalse());
        }

        [TestMethod]
        public void RunThread_IfNothingReturnsFromTimerLogQuery_InsertsTimerJobs()
        {
            // Arrange
            ShimSqlDataReader.AllInstances.Read = _ => false;

            // Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(InsertTimerJobs) &&
                           cmd.Parameters.Count == 3 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamSiteGuid) &&
                           cmd.Parameters[0].Value.Equals(SiteGuid.ToString()) &&
                           cmd.Parameters[1].ParameterName.Equals(SqlParamWebGuid) &&
                           cmd.Parameters[1].Value.Equals(WebGuid.ToString()) &&
                           cmd.Parameters[2].ParameterName.Equals(SqlParamTimerJobUid)),
                () => _adoShims.IsCommandExecuted(InsertTimerJobs).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(InsertTimerJobs).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_Always_ExecutesEpmLiveLogDeleteCommand()
        {
            // Arrange && Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(DeleteCommandEpmLiveLog) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid)),
                () => _adoShims.IsCommandExecuted(DeleteCommandEpmLiveLog).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(DeleteCommandEpmLiveLog).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_Always_ExecutesQueryReadStatusFromQueueByTimerJobUid()
        {
            // Arrange && Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(QueryReadStatusFromQueueByTimerJobGuid) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid)),
                () => _adoShims.IsCommandExecuted(QueryReadStatusFromQueueByTimerJobGuid).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(QueryReadStatusFromQueueByTimerJobGuid).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_IfStatusIs2_DeletesOldOneAndInsertsNewQueue()
        {
            // Arrange
            const int insertStatus = 1;
            var drReadCount = 0;
            ShimDataReaderForTimerJobGuid(TimerJobGuid, () => ++drReadCount == 1);

            // Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(DeleteQueueByTimerJobGuid) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid) &&
                           cmd.Parameters[0].Value.Equals(TimerJobGuid)),
                () => _adoShims.IsCommandExecuted(DeleteQueueByTimerJobGuid).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(DeleteQueueByTimerJobGuid).ShouldBeTrue(),
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(InsertQueueCommand) &&
                           cmd.Parameters.Count == 2 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid) &&
                           cmd.Parameters[0].Value.Equals(TimerJobGuid) &&
                           cmd.Parameters[1].ParameterName.Equals(SqlParamStatus) &&
                           cmd.Parameters[1].Value.Equals(insertStatus)),
                () => _adoShims.IsCommandExecuted(InsertQueueCommand).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(InsertQueueCommand).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_IfSpSiteHasWebCollection_BuildsAndInsertsLog()
        {
            // Arrange
            const int expectedPercentage = 100;
            var updateCommandText = string.Format(UpdateQueueByTimerJobGuidTemplate, expectedPercentage, TimerJobGuid);
            var expectedLogText = string.Format(EpmLogTemplate, RootWebTitle, SiteUrl, WebTitle01);

            var drReadCount = 0;
            ShimDataReaderForTimerJobGuid(TimerJobGuid, () => ++drReadCount == 1);

            ShimSPSite.ConstructorGuid = (_1, _2) => { };
            ShimSpSiteObject();

            // Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.IsCommandCreated(updateCommandText).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(updateCommandText).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(updateCommandText).ShouldBeTrue(),
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(InsertNoErrorsLog) &&
                           cmd.Parameters.Count == 2 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid) &&
                           cmd.Parameters[0].Value.Equals(TimerJobGuid) &&
                           cmd.Parameters[1].ParameterName.Equals(SqlParamResultText) &&
                           cmd.Parameters[1].Value.Equals(expectedLogText)),
                () => _adoShims.IsCommandExecuted(InsertNoErrorsLog).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(updateCommandText).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_IfSitesStringArrayHasWebCollection_BuildsAndInsertsLog()
        {
            // Arrange
            var expectedPercentage01 = (double)1 / 3 * 100;
            var expectedPercentage02 = (double)2 / 3 * 100;
            const int expectedPercentage03 = 100;
            var updateCommandText01 = string.Format(UpdateQueueByTimerJobGuidTemplate, expectedPercentage01, TimerJobGuid);
            var updateCommandText02 = string.Format(UpdateQueueByTimerJobGuidTemplate, expectedPercentage02, TimerJobGuid);
            var updateCommandText03 = string.Format(UpdateQueueByTimerJobGuidTemplate, expectedPercentage03, TimerJobGuid);

            var singleLogText = string.Format(EpmLogTemplate, RootWebTitle, SiteUrl, WebTitle01);
            var expectedLogText = string.Concat(singleLogText, singleLogText, singleLogText);

            const string siteString01 = "Site01";
            const string siteString02 = "Site02";
            var sitesArray = $"{siteString01}\r\n{siteString02}";

            ShimDataReaderForTimerJobGuid(TimerJobGuid);
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, index) => index == SitesIndex ? sitesArray : string.Empty;

            ShimSPSite.ConstructorGuid = (_1, _2) => { };
            ShimSPSite.ConstructorString = (_1, _2) => { };
            ShimSpSiteObject();

            // Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.IsCommandCreated(updateCommandText01).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(updateCommandText01).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(updateCommandText01).ShouldBeTrue(),
                () => _adoShims.IsCommandCreated(updateCommandText02).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(updateCommandText02).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(updateCommandText02).ShouldBeTrue(),
                () => _adoShims.IsCommandCreated(updateCommandText03).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(updateCommandText03).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(updateCommandText03).ShouldBeTrue(),
                () => _adoShims.IsCommandCreated(QueryReadConfigValueFromEConfig).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(QueryReadConfigValueFromEConfig).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(QueryReadConfigValueFromEConfig).ShouldBeTrue(),
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(InsertNoErrorsLog) &&
                           cmd.Parameters.Count == 2 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid) &&
                           cmd.Parameters[0].Value.Equals(TimerJobGuid) &&
                           cmd.Parameters[1].ParameterName.Equals(SqlParamResultText) &&
                           cmd.Parameters[1].Value.Equals(expectedLogText)),
                () => _adoShims.IsCommandExecuted(InsertNoErrorsLog).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(InsertNoErrorsLog).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_IfExceptionOccurs_BuildsAndInsertsErrorLog()
        {
            // Arrange
            const string exceptionMessage = "Unexpected exception occured";
            var expectedLogMessage = $"<br><br>Error: {exceptionMessage}";
            ShimSPSite.ConstructorGuid = (_1, _2) => { throw new InvalidOperationException(exceptionMessage); };

            var drReadCount = 0;
            ShimDataReaderForTimerJobGuid(TimerJobGuid, () => ++drReadCount == 1);

            // Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(InsertErrorsLog) &&
                           cmd.Parameters.Count == 2 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid) &&
                           cmd.Parameters[0].Value.Equals(TimerJobGuid) &&
                           cmd.Parameters[1].ParameterName.Equals(SqlParamResultText) &&
                           cmd.Parameters[1].Value.Equals(expectedLogMessage)),
            () => _adoShims.IsCommandExecuted(InsertErrorsLog).ShouldBeTrue(),
            () => _adoShims.IsCommandDisposed(InsertErrorsLog).ShouldBeTrue());
        }

        [TestMethod]
        public void RunThread_Always_ExecutesUpdateQueueFinallyCommand()
        {
            // Arrange
            ShimDataReaderForTimerJobGuid(TimerJobGuid);

            // Act
            _testEntityPrivate.Invoke(MethodRunThread, RunThreadParam);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(UpdateQueueFinally) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters[0].ParameterName.Equals(SqlParamTimerJobUid) &&
                           cmd.Parameters[0].Value.Equals(TimerJobGuid)),
                () => _adoShims.IsCommandExecuted(UpdateQueueFinally).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(UpdateQueueFinally).ShouldBeTrue());
        }

        private void ShimDataReaderForTimerJobGuid(Guid guid, Func<bool> readResult = null)
        {
            if (readResult == null)
            {
                readResult = () => true;
            }

            ShimSqlDataReader.AllInstances.Read = _ => readResult.Invoke();
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, index) => index == TimerJobGuidIndex ? guid : Guid.Empty;
            ShimSqlDataReader.AllInstances.IsDBNullInt32 = (_, index) => index == StatusIndexQuery1;
        }

        private static void ShimSpSiteObject()
        {
            var shimRootWeb = new ShimSPWeb();
            shimRootWeb.TitleGet = () => RootWebTitle;

            var webList = new List<SPWeb>()
            {
                new ShimSPWeb() { TitleGet = () => WebTitle01 }.Instance
            };
            var shimAllWebs = new ShimSPWebCollection() { CountGet = () => webList.Count };
            var shimAllWebsBase = new ShimSPBaseCollection(shimAllWebs.Instance) { GetEnumerator = () => webList.GetEnumerator() };

            ShimSPSite.AllInstances.RootWebGet = _ => shimRootWeb.Instance;
            ShimSPSite.AllInstances.AllWebsGet = _ => shimAllWebs.Instance;
            ShimSPSite.AllInstances.UrlGet = _ => SiteUrl;
        }
    }
}

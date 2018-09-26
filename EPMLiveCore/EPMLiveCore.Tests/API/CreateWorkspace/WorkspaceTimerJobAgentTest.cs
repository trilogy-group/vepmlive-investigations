using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.CreateWorkspace
{
    [TestClass]
    public class WorkspaceTimerJobAgentTest
    {
        private IDisposable _context;
        private string _actualSqlCommand;
        private List<string> _actualParameterList;
        private List<string> _expectedParameterList;
        private const string SampleXml =
            @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <Data>
                <Param key=""SiteId"">00000000-0000-0000-0000-000000000001</Param>
                <Param key=""WebId"">00000000-0000-0000-0000-000000000002</Param>
                <Param key=""AttachedItemListGuid"">00000000-0000-0000-0000-000000000003</Param>
                <Param key=""AttachedItemId"">4</Param>
            </Data>";
        private const string DummyString = "DummyString";
        private const string ExpectedSqlCommandCreateJob = "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid, listguid, itemid, jobdata) VALUES (@timerjobuid,@siteguid, 100, 'Create Workspace', 0, @webguid, @listguid, @itemid, @jobdata)";

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void AddCreateWorkspaceJob_ValidXml_ReturnsSuccess()
        {
            using (TestCheck.OpenCloseConnections)
            {
                // Arrange
                ArrangeCreateJob();

                // Act
                var result = WorkspaceTimerjobAgent.AddCreateWorkspaceJob(SampleXml);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => _actualSqlCommand.ShouldBe(ExpectedSqlCommandCreateJob),
                    () => _actualParameterList.All(parameter => _expectedParameterList.Contains(parameter)),
                    () => result.Contains("success"));
            }
        }

        [TestMethod]
        public void AddAndQueueCreateWorkspaceJob_ValidXml_ReturnsSuccessAndEnqueueJob()
        {
            using (TestCheck.OpenCloseConnections)
            {
                // Arrange
                ArrangeCreateJob();
                var enqueueWasCalled = false;
                ShimCoreFunctions.enqueueGuidInt32SPSite = (_1, _2, _3) => enqueueWasCalled = true;

                // Act
                var result = WorkspaceTimerjobAgent.AddAndQueueCreateWorkspaceJob(SampleXml);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => _actualSqlCommand.ShouldBe(ExpectedSqlCommandCreateJob),
                    () => _actualParameterList.All(parameter => _expectedParameterList.Contains(parameter)),
                    () => enqueueWasCalled.ShouldBeTrue(),
                    () => result.Contains("success"));
            }
        }

        private void ArrangeCreateJob()
        {
            _actualSqlCommand = string.Empty;
            _expectedParameterList = new List<string>
            {
                "@timerjobuid",
                "@siteguid",
                "@webguid",
                "@listguid",
                "@itemid",
                "@jobdata",
            };
            _actualParameterList = new List<string>();

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPSite.ConstructorGuid = (_1, _2) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_1, _2) => new ShimSPWeb();
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.WebApplicationGet = _ => (SPWebApplication)new ShimSPPersistedObject(new ShimSPWebApplication())
            {
                IdGet = () => Guid.Empty
            };
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimSqlConnection.ConstructorString = (_1, _2) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.DisposeBoolean = (_1, _2) => { };
            ShimSqlCommand.AllInstances.CommandTextSetString = (_, str) => _actualSqlCommand = str;
            ShimSqlParameterCollection.AllInstances.AddSqlParameter = (collection, parameter) =>
            {
                _actualParameterList.Add(parameter.ParameterName);
                return parameter;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;
        }
    }
}

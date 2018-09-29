using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.Reporting
{
    [TestClass]
    public class ReportingTest
    {
        private IDisposable _context;
        private bool _iAddIzendaReportWasCalled;
        private PrivateType _privateType;
        private EPMLiveCore.API.Reporting _reporting;
        protected internal string _errorString;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _reporting = new EPMLiveCore.API.Reporting();
            _privateType = new PrivateType(typeof(EPMLiveCore.API.Reporting));
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [DataTestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void ProcessIzendaReportsFromList_DisposesConnections(bool shouldThrow)
        {
            using (TestCheck.OpenCloseConnections)
            {
                // Arrange
                ArrangeAddIzendaReport(shouldThrow);

                // Act
                Action action = () => EPMLiveCore.API.Reporting.ProcessIzendaReportsFromList(new ShimSPList(), out _errorString);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => action.ShouldNotThrow(),
                    () =>
                    {
                        if (shouldThrow)
                        {
                            _errorString.ShouldBe("Test Exception");
                        }
                        else
                        {
                            _errorString.ShouldBeNullOrWhiteSpace();
                        }
                    },
                    () => _iAddIzendaReportWasCalled.ShouldBeTrue());
            }
        }

        [DataTestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void AddIzendaReport_DisposesConnections(bool shouldThrow)
        {
            using (TestCheck.OpenCloseConnections)
            {
                // Arrange
                ArrangeAddIzendaReport(shouldThrow);

                // Act
                Action action = () => EPMLiveCore.API.Reporting.AddIzendaReport(new ShimSPWeb(), "DummyTitle", "DummyXml", out _errorString);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => action.ShouldNotThrow(),
                    () =>
                    {
                        if (shouldThrow)
                        {
                            _errorString.ShouldBe("Test Exception");
                        }
                        else
                        {
                            _errorString.ShouldBeNullOrWhiteSpace();
                        }
                    },
                    () => _iAddIzendaReportWasCalled.ShouldBeTrue());
            }
        }

        private void ArrangeAddIzendaReport(bool shouldThrow)
        {
            _iAddIzendaReportWasCalled = false;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSqlConnection.ConstructorString = (_1, _2) => { };
            ShimReporting.iAddIzendaReportStringStringSqlConnectionString = (_1, _2, _3, _4) =>
            {
                _iAddIzendaReportWasCalled = true;
                if (shouldThrow)
                {
                    throw new InvalidOperationException("Test Exception");
                }
            };
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection();
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>
            {
                new ShimSPListItem(),
                new ShimSPListItem()
            }.GetEnumerator();
            _errorString = string.Empty;
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPListItem.AllInstances.TitleGet = _ => "DummyString";
            ShimSPListItem.AllInstances.ItemGetString = (_1, _2) => "DummyString";
            ShimSPWeb.AllInstances.IDGet = _ => Guid.Empty;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => (SPWebApplication)new ShimSPPersistedObject(new ShimSPWebApplication());
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.Empty;
            ShimCoreFunctions.getConnectionStringGuid = _ => "DummyString";
        }

        [DataTestMethod]
        [DataRow(true, 1, "SiteTitle", "This is a Xml only not really", "001", false)]
        [DataRow(true, 1, "SiteTitle", "This is a Xml only not really", "001", true)]
        [DataRow(false, 1, "SiteTitle", "This is a Xml only not really", "001", false)]
        [DataRow(false, 1, "SiteTitle", "This is a Xml only not really", "001", true)]
        public void IAddIzendaReport_DisposeConnections(
            bool shouldRead,
            int queryReturn,
            string title,
            string xml,
            string siteId,
            bool shouldReaderThrow)
        {
            using (TestCheck.OpenCloseConnections)
            {
                // Arrange
                var parameters = new Dictionary<string, object>();
                ShimSqlCommand.ConstructorStringSqlConnection = (command, _2, _3) => { };
                ShimSqlCommand.AllInstances.ParametersGet = _ => new ShimSqlParameterCollection();
                ShimSqlParameterCollection.AllInstances.AddWithValueStringObject = (_1, str, obj) =>
                {
                    parameters[str] = obj;
                    return new ShimSqlParameter();
                };
                ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
                ShimSqlDataReader.AllInstances.Read = _ =>
                {
                    if (shouldReaderThrow)
                    {
                        throw new InvalidOperationException();
                    }
                    return shouldRead;
                };
                ShimSqlDataReader.AllInstances.Close = _ => { };
                ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => queryReturn;

                // Act
                Action action = () => _privateType.InvokeStatic(
                    "iAddIzendaReport",
                    title,
                    xml,
                    (SqlConnection)new ShimSqlConnection(),
                    siteId);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () =>
                    {
                        if (shouldRead || shouldReaderThrow)
                        {
                            action.ShouldThrow<Exception>();
                        }
                        else
                        {
                            action.ShouldNotThrow();
                        }
                    },
                    () =>
                    {
                        if (!shouldReaderThrow
                            && !shouldRead)
                        {
                            parameters["@name"]
                                .ShouldBe(title);
                            parameters["@siteid"]
                                .ShouldBe(siteId);
                            parameters["@xml"]
                                .ShouldBe(xml);
                        }
                        else if (!shouldReaderThrow && shouldRead)
                        {
                            parameters["@name"]
                                .ShouldBe(title);
                            parameters["@siteid"]
                                .ShouldBe(siteId);
                        }
                    });
            }
        }
    }
}
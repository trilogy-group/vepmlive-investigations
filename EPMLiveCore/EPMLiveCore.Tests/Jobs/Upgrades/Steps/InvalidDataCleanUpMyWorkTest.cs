using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Steps;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using EPMLiveCore.Fakes;
using System.Data.SqlClient.Fakes;

namespace EPMLiveCore.Tests.Jobs.Upgrades.Steps
{
    /// <summary>
    /// Summary description for InvalidDataCleanUpMyWorkTest
    /// </summary>
    [TestClass]
    public class InvalidDataCleanUpMyWorkTest
    {
        protected internal const string DummyString = "DummyString";
        protected internal const int DummyInt = 1;

        private IDisposable _context;
        private InvalidDataCleanUpMyWork _invalidDataCleanUpMyWork;
        private PrivateObject _privateObject;
        private readonly StringBuilder query = new StringBuilder();
        private int currentDataReaderCount;
        private int maxDatareaderCount;
        private int DataReaderResult = 0;
        private int OpenCount = 0;
        private int DisposeCount = 0;

        [TestInitialize]
        public void Setup()
        {
            maxDatareaderCount = 1;
            currentDataReaderCount = 0;
            _context = ShimsContext.Create();
            var spweb = new ShimSPWeb()
            {
                SiteGet = () =>
                {
                    return new ShimSPSite()
                    {
                        WebApplicationGet = () =>
                        {
                            return new ShimSPWebApplication();
                        },
                    };
                }
            };
            _invalidDataCleanUpMyWork = new InvalidDataCleanUpMyWork(spweb.Instance, false);
            _privateObject = new PrivateObject(_invalidDataCleanUpMyWork);
        }
        
        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }
        
        [TestMethod]
        public void Perform_When_Connection_String_Empty()
        {
            // Arrange
            SetupShim();
            ShimCoreFunctions.getReportingConnectionStringGuidGuid = (_1, _2) => { return string.Empty; };

            // Act
            var result = _invalidDataCleanUpMyWork.Perform();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Perform_When_Connection_String_Not_Empty()
        {
            // Arrange
            SetupShim();
            ShimCoreFunctions.getReportingConnectionStringGuidGuid = (_1, _2) => { return DummyString; };

            // Act
            var result = _invalidDataCleanUpMyWork.Perform();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(query);
            Assert.IsTrue(result);
            Assert.AreEqual(OpenCount, DisposeCount);
        }

        public void SetupShim()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSqlConnection.ConstructorString = (_, _1) => { };
            ShimSqlConnection.AllInstances.Open = _ => {
                OpenCount++;
            };
            ShimSqlConnection.AllInstances.DisposeBoolean = (_, _1) => {
                DisposeCount++;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                query.Append("\n" + command.CommandText);
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    ItemGetInt32 = key =>
                    {
                        DataReaderResult++;
                        return DummyString + key + DataReaderResult;
                    },
                }.Instance;
            };
        }
    }
}

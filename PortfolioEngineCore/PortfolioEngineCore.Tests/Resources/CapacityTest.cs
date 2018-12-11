using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Shouldly;
using System.Data.SqlClient.Fakes;
using PortfolioEngineCore.Fakes;
using System.Fakes;
using Microsoft.QualityTools.Testing.Fakes;

namespace PortfolioEngineCore.Tests.Resources
{
    /// <summary>
    /// Unit Tests for <see cref="PortfolioEngineCore.Capacity"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class CapacityTest
    {
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private PrivateType _privateType;
        private PrivateObject _privateObject;
        private Capacity _testEntity;
        private IDisposable _shimsContext;
        private readonly StringBuilder query = new StringBuilder();
        private int currentDataReaderCount;
        private int maxDatareaderCount;
        private int DataReaderResult = 0;

        //Function Names
        private const string ProcessPeriods = "ProcessPeriods";
        private const string SelectMyDepts = "SelectMyDepts";
        private const string SelectResourcesFromTicket = "SelectResourcesFromTicket";
        private const string SelectMyResources = "SelectMyResources";
        private const string AddCustomFieldLookup = "AddCustomFieldLookup";
        private const string SelectMyProjects = "SelectMyProjects";
        private const string GetSuperPM = "GetSuperPM";
        private const string RemovePlanRowsWOHours = "RemovePlanRowsWOHours";
        private const string AddCustomField = "AddCustomField";
        private const string GetSuperRM = "GetSuperRM";
        private const string MakeListFromCollection = "MakeListFromCollection";
        private const string MapToPeriod = "MapToPeriod";
        private const string SetParentUIDs = "SetParentUIDs";
        private const string GetFTEValue = "GetFTEValue";
        private const string GetFTEConv = "GetFTEConv";
        private const string GetBCUID = "GetBCUID";

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            InitShims();
            query.Clear();
            maxDatareaderCount = 1;
            currentDataReaderCount = 0;

            _testEntity = new Capacity(
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                SecurityLevels.AdminCalc);
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(Capacity));
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetRVInfo_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            string sParmXML = DummyString;
            string sReplyXML = string.Empty;
            string sResult = string.Empty;

            // Act
            var result = _testEntity.GetRVInfo(string sParmXML, out string sReplyXML, out string sResult)

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(true));
        }

        private void InitShims()
        {
            ShimResourcePlans.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>()
                {
                    new CPeriod()
                    {
                        PeriodID = 2,
                    }
                };
                return StatusEnum.rsSuccess;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>();
                return StatusEnum.rsSuccess;
            };
            ShimDateTime.NowGet = () => new DateTime(2010, 10, 10, 10, 10, 10);
            SetupSqlShims();
        }

        private void ShimsForGetResourcePlanStructTestMethods()
        {
            maxDatareaderCount = 10;
            ShimResourcePlans.AllInstances.ReadTicketStringStringStringOut = (ResourcePlans resourcePlans, string sTicket, out string sReply) =>
            {
                sReply = DummyString;
                return true;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>()
                {
                    new CPeriod()
                    {
                        PeriodID = 2,
                    },
                };
                return StatusEnum.rsSuccess;
            };
            ShimDBCommon.GetCostCategoryRolesStructDBAccessInt32Int32CStructOutBoolean = (DBAccess dba, int lPortfolioCommitmentsCalendarUID, int lStartPeriodID, out CStruct xCostCategoryRolesOut, bool bGetAll) =>
            {
                xCostCategoryRolesOut = new CStruct();
                xCostCategoryRolesOut.LoadXML($"<{DummyString}></{DummyString}>");
                return StatusEnum.rsSuccess;
            };
        }

        private void SetupSqlShims()
        {
            ShimSqlDb.AllInstances.BeginTransaction = _ => { };
            ShimSqlConnection.AllInstances.StateGet = _ => System.Data.ConnectionState.Open;
            ShimSqlConnection.ConstructorString = (_, _1) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
            {
                if (command.CommandText == "SELECT dbo.PFE_FN_CheckUserSecurityClearance(@Username, @SecurityLevel)")
                {
                    return true;
                }
                return DummyInt;
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
                    Close = () => currentDataReaderCount = 0,
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        DataReaderResult++;
                        if (key == "VIEW_DATA")
                        {
                            return "<Dummy></Dummy>";
                        }
                        return DataReaderResult;
                    },
                }.Instance;
            };
        }

        private List<Action> AssertQueries(string[] expectedQueries)
        {
            var assertions = new List<Action>();
            foreach (var expectedQuery in expectedQueries)
            {
                assertions.Add(() => query.ToString().ShouldContain(expectedQuery));
            }
            return assertions;
        }
    }
}

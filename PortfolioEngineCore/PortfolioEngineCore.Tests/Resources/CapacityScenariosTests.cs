using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Xml;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Resources
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CapacityScenariosTests
    {
        private CapacityScenarios testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicInstance;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSqlDataReader dataReader;
        private Guid guid;
        private DateTime currentDate;
        private int validations;
        private const int DummyInt = 1;
        private const int Zero = 0;
        private const int One = 1;
        private const int Two = 2;
        private const int Three = 3;
        private const int Four = 4;
        private const int Five = 5;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string IDStringCaps = "ID";
        private const string SampleUrl = "http://www.sampleurl.com";
        private const string RoleBasedCSAllowedMethodName = "RoleBasedCSAllowed";
        private const string GetCapacityScenariosXMLMethodName = "GetCapacityScenariosXML";
        private const string DeleteCapacityScenarioMethodName = "DeleteCapacityScenario";
        private const string AddCapacityScenarioXMLMethodName = "AddCapacityScenarioXML";
        private const string GetCapacityScenarioValuesXMLMethodName = "GetCapacityScenarioValuesXML";
        private const string SaveCapacityScenarioMethodName = "SaveCapacityScenario";
        private const string SaveCapacityScenarioDataMethodName = "SaveCapacityScenarioData";
        private const string SaveCurrentScenarioDataMethodName = "SaveCurrentScenarioData";
        private const string GetListTicketMethodName = "GetListTicket";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new CapacityScenarios
            (
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                SecurityLevels.AdminCalc
            );
            privateObject = new PrivateObject(testObject);
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();

            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = true;
                return DummyInt;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimActivation.AllInstances.checkActivationStringStringString = (_, _1, _2, _3) => { };
            ShimPFEEncrypt.DecryptStringString = (_, input) => input;
            ShimDatabase.AllInstances.OpenDatabaseStringString = (_, _1, _2) => new SqlConnection();
            ShimBaseSecurity.AllInstances.ChecksScurityStringSecurityLevels = (_, _1, _2) => true;
        }

        private void SetupVariables()
        {
            validations = 0;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            guid = Guid.Parse(SampleGuidString1);
            currentDate = DateTime.Now;
            spWeb = new ShimSPWeb();
            spSite = new ShimSPSite();
            dataReader = new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { },
                ItemGetString = input => input
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void RoleBasedCSAllowed_WhenCalled_ReturnsAllowedBoolean()
        {
            // Arrange
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;

            // Act
            var actual = (bool)privateObject.Invoke(RoleBasedCSAllowedMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => readHit.ShouldBe(Two));
        }

        [TestMethod]
        public void GetCapacityScenariosXML_WhenCalled_ReturnsCapacityScenariosXml()
        {
            // Arrange
            var readHit = 0;
            var parameters = new object[]
            {
                DummyString,
                true,
                DummyString
            };
            var scenarioXml = new XmlDocument();

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;

            // Act
            var actual = (bool)privateObject.Invoke(GetCapacityScenariosXMLMethodName, publicInstance, parameters);
            scenarioXml.LoadXml((string)parameters[0]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => scenarioXml.FirstChild.Name.ShouldBe("CapacityScenarios"),
                () => scenarioXml.FirstChild.Attributes["CB_ID"].Value.ShouldBe("-1"),
                () => scenarioXml.FirstChild.SelectNodes("//CapacityScenario").Count.ShouldBe(One),
                () => scenarioXml.FirstChild.SelectSingleNode("//CapacityScenario").Attributes["ID"].Value.ShouldBe(DummyInt.ToString()),
                () => scenarioXml.FirstChild.SelectSingleNode("//CapacityScenario").Attributes["Name"].Value.ShouldBe(DummyString),
                () => scenarioXml.FirstChild.SelectSingleNode("//CapacityScenario").Attributes["WRES"].Value.ShouldBe(DummyInt.ToString()));
        }

        [TestMethod]
        public void DeleteCapacityScenario_WhenCalled_DeletesCapacityScenario()
        {
            // Arrange
            var expected = new List<string>()
            {
                $"DELETE FROM EPGP_CAPACITY_SETVALUES WHERE CS_ID = {One}",
                $"DELETE FROM EPGP_CAPACITY_SETS WHERE CS_ID = {One}"
            };
            var queries = new List<string>();

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                validations += 1;
                queries.Add(instance.CommandText);
                return DummyInt;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                DeleteCapacityScenarioMethodName,
                publicInstance,
                new object[]
                {
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(2),
                () => expected.Any(x => !queries.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void AddCapacityScenarioXML_PrivateTrueRoleTrue_AddsCapacityScenarioXML()
        {
            // Arrange
            const bool isPrivate = true;
            const bool isRole = true;
            var expected = new List<string>()
            {
                "SELECT MAX(CS_ID) AS MAXID FROM EPGP_CAPACITY_SETS",
                "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME, WRES_ID, CS_ROLE_BASED)"
            };
            var queries = new List<string>();
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                queries.Add(instance.CommandText);
                return dataReader;
            };
            ShimCapacityScenarios.AllInstances.PrivateAllowed = _ => isPrivate;
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = _ => isRole;

            // Act
            var actual = (int)privateObject.Invoke(
                AddCapacityScenarioXMLMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true,
                    One,
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Two),
                () => expected.Any(x => !queries.Any(q => q.Contains(x))).ShouldBeFalse());
        }

        [TestMethod]
        public void AddCapacityScenarioXML_PrivateTrueRoleFalse_AddsCapacityScenarioXML()
        {
            // Arrange
            const bool isPrivate = true;
            const bool isRole = false;
            var expected = new List<string>()
            {
                "SELECT MAX(CS_ID) AS MAXID FROM EPGP_CAPACITY_SETS",
                "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME, WRES_ID)"
            };
            var queries = new List<string>();
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                queries.Add(instance.CommandText);
                return dataReader;
            };
            ShimCapacityScenarios.AllInstances.PrivateAllowed = _ => isPrivate;
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = _ => isRole;

            // Act
            var actual = (int)privateObject.Invoke(
                AddCapacityScenarioXMLMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true,
                    One,
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Two),
                () => expected.Any(x => !queries.Any(q => q.Contains(x))).ShouldBeFalse());
        }

        [TestMethod]
        public void AddCapacityScenarioXML_PrivateFalseRoleTrue_AddsCapacityScenarioXML()
        {
            // Arrange
            const bool isPrivate = false;
            const bool isRole = true;
            var expected = new List<string>()
            {
                "SELECT MAX(CS_ID) AS MAXID FROM EPGP_CAPACITY_SETS",
                "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME, CS_ROLE_BASED)"
            };
            var queries = new List<string>();
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                queries.Add(instance.CommandText);
                return dataReader;
            };
            ShimCapacityScenarios.AllInstances.PrivateAllowed = _ => isPrivate;
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = _ => isRole;

            // Act
            var actual = (int)privateObject.Invoke(
                AddCapacityScenarioXMLMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true,
                    One,
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Two),
                () => expected.Any(x => !queries.Any(q => q.Contains(x))).ShouldBeFalse());
        }

        [TestMethod]
        public void AddCapacityScenarioXML_PrivateFalseRoleFalse_AddsCapacityScenarioXML()
        {
            // Arrange
            const bool isPrivate = false;
            const bool isRole = false;
            var expected = new List<string>()
            {
                "SELECT MAX(CS_ID) AS MAXID FROM EPGP_CAPACITY_SETS",
                "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME)"
            };
            var queries = new List<string>();
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                queries.Add(instance.CommandText);
                return dataReader;
            };
            ShimCapacityScenarios.AllInstances.PrivateAllowed = _ => isPrivate;
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = _ => isRole;

            // Act
            var actual = (int)privateObject.Invoke(
                AddCapacityScenarioXMLMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true,
                    One,
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Two),
                () => expected.Any(x => !queries.Any(q => q.Contains(x))).ShouldBeFalse());
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CapacityIdNegative_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = -5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Value"].Value.ShouldBe("100"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Desc"].Value.ShouldBe("Requested Capacity Scenario ID was less than -1"),
                () => result.ShouldBeFalse(),
                () => status.ShouldBe((int)StatusEnum.rsPIResourceCalendarNotSet));
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CapacityIdPositiveCalIdNegative_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = 5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = true;
                return DummyInt;
            };

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Value"].Value.ShouldBe("101"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Desc"].Value.ShouldBe("Planning Calendar has not been set.  Please contact your Administrator"),
                () => result.ShouldBeFalse(),
                () => status.ShouldBe((int)StatusEnum.rsPIResourceCalendarNotSet));
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CalIdNotNegativeGetPeriodsNotSuccess_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = 5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dbAccess, int CalID, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>();
                return StatusEnum.rsBasePathNotSet;
            };

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectNodes("//CS_Values/CS_Value").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Per_ID"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Hours"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Value"].Value.ShouldBe("102"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Desc"].Value.ShouldBe("Failed to load periods"),
                () => result.ShouldBeFalse());
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CalIdNotNegativeGetCostCategoryRolesNotSuccess_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = 5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dbAccess, int CalID, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>()
                {
                    new CPeriod()
                    {
                        PeriodID = One,
                        PeriodName = DummyString,
                        StartDate = currentDate,
                        FinishDate = DateTime.Now
                    }
                };
                return StatusEnum.rsSuccess;
            };
            ShimDBCommon.GetCostCategoryRolesStructDBAccessInt32Int32CStructOutBoolean = (DBAccess dbAccess, int CalID, int num, out CStruct costCategoryRoles, bool value) =>
            {
                costCategoryRoles = null;
                return StatusEnum.rsBasePathNotSet;
            };

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectNodes("//CS_Values/CS_Value").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Per_ID"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Hours"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectNodes("//Periods/Period").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["Name"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["Start"].Value.ShouldBe(currentDate.ToString("yyyy-MM-ddTHH:mm:ss")),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Value"].Value.ShouldBe("103"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Desc"].Value.ShouldBe("Failed to Cost Category Roles etc."),
                () => result.ShouldBeFalse());
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CostCategoryRolesSuccess_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = 5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dbAccess, int CalID, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>()
                {
                    new CPeriod()
                    {
                        PeriodID = One,
                        PeriodName = DummyString,
                        StartDate = currentDate,
                        FinishDate = DateTime.Now
                    }
                };
                return StatusEnum.rsSuccess;
            };
            ShimDBCommon.GetCostCategoryRolesStructDBAccessInt32Int32CStructOutBoolean = (DBAccess dbAccess, int CalID, int num, out CStruct costCategoryRoles, bool value) =>
            {
                const string costCategoryRolesXml = @"
                    <CostCategoryRoles>
                        <CostCategoryRole/>
                        <CostCategoryRole/>
                    </CostCategoryRoles>";
                costCategoryRoles = new CStruct();
                costCategoryRoles.LoadXML(costCategoryRolesXml);
                return StatusEnum.rsSuccess;
            };

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectNodes("//CS_Values/CS_Value").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Per_ID"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Hours"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectNodes("//Periods/Period").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["Name"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["Start"].Value.ShouldBe(currentDate.ToString("yyyy-MM-ddTHH:mm:ss")),
                () => actual.FirstChild.SelectNodes("//CostCategoryRoles/CostCategoryRole").Count.ShouldBe(Two),
                () => result.ShouldBeTrue());
        }

        [TestMethod]
        public void SaveCapacityScenario_WhenCalled_SavesCapacityScenario()
        {
            // Arrange
            const int capacityId = 5;
            const string xmlData = @"
                <CS_Values>
                    <CS_Value Per_ID=""1"" Role_ID=""1"" Hours=""1"" FTEs=""1""/>
                    <CS_Value Per_ID=""2"" Role_ID=""2"" Hours=""2"" FTEs=""2""/>
                </CS_Values>";
            var readHit = 0;
            var expectedQueries = new List<string>()
            {
                $"DELETE FROM EPGP_CAPACITY_SETVALUES WHERE CS_ID = {capacityId}",
                $"INSERT INTO EPGP_CAPACITY_SETVALUES (CS_ID, CB_ID, DEPT_UID, BD_PERIOD, ROLE_ID, CS_AVAIL, CS_FTES)  VALUES({capacityId},{DummyInt},0,@prd,@roleid,@hrs,@ftes)"
            };
            var queries = new List<string>();

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                validations += 1;
                queries.Add(instance.CommandText);
                return DummyInt;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                SaveCapacityScenarioMethodName,
                publicInstance,
                new object[]
                {
                    capacityId,
                    xmlData
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => queries.Count.ShouldBe(3),
                () => expectedQueries.Any(x => !queries.Contains(x)).ShouldBeFalse(),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void SaveCapacityScenarioData_WhenCalled_SavesCapacityScenarioData()
        {
            // Arrange
            var xmlData = $@"
                <xmlcfg Name=""{DummyString}"" ID=""-1"" WRES=""0"" DEPT=""1"" RMODE=""1"">
                    <CS_Values/>
                </xmlcfg>";
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                xmlData,
                DummyString,
                DummyInt
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimCapacityScenarios.AllInstances.AddCapacityScenarioXMLStringBooleanInt32Int32 = (_, capName, wres, deptId, mode) =>
            {
                if (capName.Equals(DummyString) && wres.Equals(false) && deptId.Equals(One) && mode.Equals(One))
                {
                    validations += 1;
                }
                return Five;
            };
            ShimCapacityScenarios.AllInstances.SaveCapacityScenarioInt32String = (_, capacityId, xml) =>
            {
                if (capacityId.Equals(Five))
                {
                    validations += 1;
                }
                return true;
            };

            // Act
            var result = (bool)privateObject.Invoke(SaveCapacityScenarioDataMethodName, publicInstance, parameters);
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => status.ShouldBe(Zero),
                () => actual.FirstChild.Name.ShouldBe("CSID"),
                () => actual.FirstChild.Attributes["Value"].Value.ShouldBe(Five.ToString()),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void SaveCurrentScenarioData_WhenCalled_SavesCurrentScenarioData()
        {
            // Arrange
            const string dataXml = @"<xmlcfg Name=""{DummyString}"" ID=""-1"" WRES=""0"" DEPT=""1"" RMODE=""1""/>";
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlDb.ReadIntValueObject = _ => Zero;
            ShimCapacityScenarios.AllInstances.AddCapacityScenarioXMLStringBooleanInt32Int32 = (_, capName, wres, deptId, mode) =>
            {
                if (capName.Equals(DummyString) && wres.Equals(false) && deptId.Equals(One) && mode.Equals(One))
                {
                    validations += 1;
                }
                return Five;
            };
            ShimCapacityScenarios.AllInstances.SaveCapacityScenarioInt32String = (_, capacityId, xml) =>
            {
                if (capacityId.Equals(Five))
                {
                    validations += 1;
                }
                return true;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                SaveCurrentScenarioDataMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    dataXml
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetListTicket_WhenCalled_ReturnsListTicket()
        {
            // Arrange
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit <= Two;
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.Parameters["@pdta"].Value.Equals($"{DummyString},{DummyString}"))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetListTicketMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => validations.ShouldBe(1));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace WorkEnginePPM.Tests.ModelCache
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public partial class ModelCacheTests
    {
        private ModelCache testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicInstance;
        private BindingFlags nonPublicInstance;
        private Guid guid;
        private ShimSqlDataReader dataReader;
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string GuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string LoadScenarioDataMethodName = "LoadScenarioData";
        private const string LoadTargetDataMethodName = "LoadTargetData";
        private const string GrabPidsFromTickectMethodName = "GrabPidsFromTickect";
        private const string GrabModelInfoMethodName = "GrabModelInfo";
        private const string GrabCostViewInfoMethodName = "GrabCostViewInfo";
        private const string GrabViewsAndStatusMethodName = "GrabViewsAndStatus";
        private const string ReadPeriodsMethodName = "ReadPeriods";
        private const string ReadCatItemsMethodName = "ReadCatItems";
        private const string ReadCustomFieldsMethodName = "ReadCustomFields";
        private const string ReadCostTypeNamesMethodName = "ReadCostTypeNames";
        private const string CheckVersionSecurityMethodName = "CheckVersionSecurity";
        private const string ReadModelNamesMethodName = "ReadModelNames";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();
            SetupVariables();

            testObject = new ModelCache();
            privateObject = new PrivateObject(testObject);
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
        }

        private void SetupVariables()
        {
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(GuidString);
            dataReader = new ShimSqlDataReader()
            {
                Read = () => true,
                Close = () => { },
                ItemGetString = input => input
            };
        }

        [TestMethod]
        public void LoadScenarioData_WhenCalled_ReturnsInteger()
        {
            // Arrange
            var validation = 0;

            ShimModelCache.AllInstances.LoadScenariosSqlConnectionStringBooleanBoolean = (_, _1, _2, _3, _4) =>
            {
                validation += 1;
            };
            ShimModelCache.AllInstances.ProcessAndCreateDistplayLists = _ =>
            {
                validation += 1;
            };

            // Act
            var actual = (int)privateObject.Invoke(
                LoadScenarioDataMethodName,
                publicInstance,
                new object[] { default(SqlConnection), DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(0),
                () => validation.ShouldBe(2));
        }

        [TestMethod]
        public void LoadTargetData_WhenCalled_ReturnsInteger()
        {
            // Arrange
            var validation = 0;

            ShimModelCache.AllInstances.LoadTargetsSqlConnectionString = (_, _1, _2) =>
            {
                validation += 1;
                return DummyInt;
            };
            ShimModelCache.AllInstances.ProcessAndCreateDistplayLists = _ =>
            {
                validation += 1;
            };

            // Act
            var actual = (int)privateObject.Invoke(
                LoadTargetDataMethodName,
                publicInstance,
                new object[] { default(SqlConnection), DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(0),
                () => validation.ShouldBe(2));
        }

        [TestMethod]
        public void GrabPidsFromTickect_WhenCalled_ReturnsInteger()
        {
            // Arrange
            var methodHit = 0;
            var validations = 0;
            var id = 0;
            var guids = $"{DummyString},{DummyString}";
            var sqlconnection = new SqlConnection();

            dataReader.Read = () =>
            {
                methodHit += 1;
                validations += 1;
                if (methodHit.Equals(1))
                {
                    return true;
                }
                return false;
            };

            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                methodHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadStringValueObject = _ => guids;
            ShimSqlDb.ReadIntValueObject = _ =>
            {
                id += 1;
                return id;
            };

            // Act
            var actual = (int)privateObject.Invoke(
                GrabPidsFromTickectMethodName,
                nonPublicInstance,
                new object[] { sqlconnection, DummyString, DummyString, true, DummyInt });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(0),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void GrabModelInfo_WhenCalled_ReturnsInteger()
        {
            // Arrange
            var readHit = 0;
            var readIntHit = 0;
            var validations = 0;
            var sqlconnection = new SqlConnection();

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 4)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadIntValueObject = _ =>
            {
                readIntHit += 1;
                if (readIntHit > 8 && readIntHit < 13)
                {
                    return DummyInt;
                }
                return (DummyInt + 1);
            };
            ShimModelCache.AllInstances.GetCFFieldNameInt32Int32StringOutStringOut = (ModelCache instance, int lTableID, int lFieldID, out string sTable, out string sField) =>
            {
                sTable = DummyString;
                sField = DummyString;
                validations += 1;
            };

            // Act
            var actual = (int)privateObject.Invoke(
                GrabModelInfoMethodName,
                nonPublicInstance,
                new object[] { sqlconnection, DummyInt.ToString(), DummyInt, DummyInt, DummyString, DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(0),
                () => validations.ShouldBe(16));
        }

        [TestMethod]
        public void GrabCostViewInfo_WhenCalled_ReturnsInteger()
        {
            // Arrange
            var readHit = 0;
            var readIntHit = 0;
            var validations = 0;
            var sqlconnection = new SqlConnection();

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 4)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadIntValueObject = _ =>
            {
                readIntHit += 1;
                if (readIntHit > 12 && readIntHit <= 16)
                {
                    return DummyInt;
                }
                return 3;
            };

            // Act
            var actual = (int)privateObject.Invoke(
                GrabCostViewInfoMethodName,
                nonPublicInstance,
                new object[] { sqlconnection, DummyInt.ToString(), DummyInt, DummyString, DummyString, DummyInt, DummyInt });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(0),
                () => validations.ShouldBe(10));
        }

        [TestMethod]
        public void GrabViewsAndStatus_WhenCalled_LoadsUserViews()
        {
            // Arrange
            var readHit = 0;
            var readIntHit = 0;
            var readDateHit = 0;
            var validations = 0;
            var sqlconnection = new SqlConnection();
            var now = DateTime.Now;

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 4)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadIntValueObject = _ =>
            {
                readIntHit += 1;
                return DummyInt;
            };
            ShimSqlDb.ReadDateValueObject = _ =>
            {
                readDateHit += 1;
                return now;
            };
            ShimModelCache.AllInstances.LoadUserViewsSqlConnection = (_, __) =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(
                GrabViewsAndStatusMethodName,
                nonPublicInstance,
                new object[] { sqlconnection, DummyString, DummyInt });

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => readIntHit.ShouldBe(8),
                () => readDateHit.ShouldBe(4),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void ReadPeriods_WhenCalled_ReadsPeriods()
        {
            // Arrange
            var readHit = 0;
            var readIntHit = 0;
            var readDateHit = 0;
            var validations = 0;
            var sqlconnection = new SqlConnection();
            var now = DateTime.Now;

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 5)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadIntValueObject = _ =>
            {
                readIntHit += 1;
                return readIntHit;
            };
            ShimSqlDb.ReadDateValueObject = _ =>
            {
                readDateHit += 1;
                if (readDateHit % 2 == 1)
                {
                    return now.AddDays(-2);
                }
                else
                {
                    return now.AddDays(2);
                }
            };

            privateObject.SetFieldOrProperty("m_statdate", nonPublicInstance, now);

            // Act
            privateObject.Invoke(ReadPeriodsMethodName, nonPublicInstance, new object[] { sqlconnection });
            var indicator = (int[])privateObject.GetFieldOrProperty("perind", nonPublicInstance);
            var start = (DateTime[])privateObject.GetFieldOrProperty("persta", nonPublicInstance);
            var end = (DateTime[])privateObject.GetFieldOrProperty("perfin", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => indicator.Length.ShouldBe(6),
                () => indicator[5].ShouldBe(5),
                () => start.Length.ShouldBe(6),
                () => start[5].ShouldBe(now.AddDays(-2)),
                () => end.Length.ShouldBe(6),
                () => end[5].ShouldBe(now.AddDays(2)),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void ReadCatItems_WhenCalled_ReadsCatItems()
        {
            // Arrange
            var readHit = 0;
            var validations = 0;
            var sqlconnection = new SqlConnection();
            var now = DateTime.Now;
            var periodIndicator = new int[] { 0, 1, 2, 3, 4, 5 };

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 3)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadStringValueObject = _ => $"{DummyString}{readHit}";
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = key => readHit;
            ShimSqlDb.ReadDateValueObject = _ => now;

            privateObject.SetFieldOrProperty("maxp", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, 10);
            privateObject.SetFieldOrProperty("perind", nonPublicInstance, periodIndicator);

            // Act
            privateObject.Invoke(ReadCatItemsMethodName, nonPublicInstance, new object[] { sqlconnection });
            var costCat = (Dictionary<int, CatItemData>)privateObject.GetFieldOrProperty("m_CostCat", nonPublicInstance);

            // Assert
            costCat.ShouldSatisfyAllConditions(
                () => costCat.Count.ShouldBe(3),
                () => costCat[3].FullName.ShouldBe($"{DummyString}1.{DummyString}2.{DummyString}3"),
                () => validations.ShouldBe(8));
        }

        [TestMethod]
        public void ReadCustomFields_WhenCalled_ReadsCustomFields()
        {
            // Arrange
            var costTypes = "1,2";
            var readHit = 0;
            var validations = 0;
            var sqlconnection = new SqlConnection();
            var now = DateTime.Now;
            var periodIndicator = new int[] { 0, 1, 2, 3, 4, 5 };

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 3)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadStringValueObject = _ => $"{DummyString}{readHit}";
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = key => readHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            privateObject.SetFieldOrProperty("m_sCostTypes", nonPublicInstance, costTypes);

            // Act
            privateObject.Invoke(ReadCustomFieldsMethodName, nonPublicInstance, new object[] { sqlconnection });
            var customFields = (Dictionary<int, CustomFieldData>)privateObject.GetFieldOrProperty("m_CustFields", nonPublicInstance);
            var fieldItems = (List<PortFieldData>)privateObject.GetFieldOrProperty("m_CustAttribs", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => customFields.Count.ShouldBe(3),
                () => customFields.Count(kvp => kvp.Value.ListItems.Count.Equals(3)).ShouldBe(3),
                () => fieldItems.Count.ShouldBe(6),
                () => validations.ShouldBe(24));
        }

        [TestMethod]
        public void ReadCostTypeNames_WhenCalled_ReadsCostTypeNames()
        {
            // Arrange
            var readHit = 0;
            var validations = 0;
            var sqlconnection = new SqlConnection();
            var now = DateTime.Now;

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 3)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadStringValueObject = _ => $"{DummyString}{readHit}";
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = key => readHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            privateObject.SetFieldOrProperty("m_sCostTypes", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_sOtherCostTypes", nonPublicInstance, DummyString);

            // Act
            privateObject.Invoke(ReadCostTypeNamesMethodName, nonPublicInstance, new object[] { sqlconnection });
            var costTypes = (Dictionary<int, DataItem>)privateObject.GetFieldOrProperty("m_CostTypes", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => costTypes.Count.ShouldBe(3),
                () => validations.ShouldBe(4));
        }

        [TestMethod]
        public void ReadModelNames_OptListNull_ChecksVersionSecurity()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var sqlConnection = new SqlConnection();
            var optlist = default(List<ItemDefn>);
            var now = DateTime.Now;

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 3)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadStringValueObject = _ => $"{DummyString}{readHit}";
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => readHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            testObject.ReadModelNames(DummyString, DummyString, sqlConnection, ref optlist);
            var scenario = (Dictionary<int, DataItem>)privateObject.GetFieldOrProperty("m_Scenario", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => optlist.ShouldBeNull(),
                () => scenario.Count.ShouldBe(4),
                () => validations.ShouldBe(12));
        }

        [TestMethod]
        public void ReadModelNames_OptListNotNull_ChecksVersionSecurity()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var sqlConnection = new SqlConnection();
            var optlist = new List<ItemDefn>();
            var now = DateTime.Now;

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 3)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadStringValueObject = _ => $"{DummyString}{readHit}";
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => readHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            testObject.ReadModelNames(DummyString, DummyString, sqlConnection, ref optlist);
            var scenario = (Dictionary<int, DataItem>)privateObject.GetFieldOrProperty("m_Scenario", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => optlist.Count.ShouldBe(4),
                () => scenario.ShouldBeNull(),
                () => validations.ShouldBe(12));
        }
    }
}

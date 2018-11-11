using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace WorkEnginePPM.Tests.ModelCacheTests
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
        private const string ReadStagesMethodName = "ReadStages";
        private const string ReadExtraPifieldsMethodName = "ReadExtraPifields";
        private const string StripNumMethodName = "StripNum";
        private const string MyFormatMethodName = "MyFormat";
        private const string ReadPILevelDataMethodName = "ReadPILevelData";
        private const string ReadCostCustomFieldsAndDataMethodName = "ReadCostCustomFieldsAndData";
        private const string ReadBudgetBandsMethodName = "ReadBudgetBands";
        private const string ReadModelTargetsMethodName = "ReadModelTargets";
        private const string ReadRateTableMethodName = "ReadRateTable";

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
            SetupListsAndDictionaries();
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

        [TestMethod]
        public void ReadStages_WhenCalled_PopulatesStages()
        {
            // Arrange
            const int readMaxHit = 3;
            var validations = 0;
            var readHit = 0;
            var sqlConnection = new SqlConnection();
            var optlist = new List<ItemDefn>();
            var now = DateTime.Now;

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= readMaxHit)
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
            privateObject.Invoke(ReadStagesMethodName, nonPublicInstance, new object[] { sqlConnection });
            var scenario = (Dictionary<int, DataItem>)privateObject.GetFieldOrProperty("m_stages", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => scenario.Count.ShouldBe(3),
                () => scenario[3].Name.ShouldBe($"{DummyString}3"),
                () => validations.ShouldBe(4));
        }

        [TestMethod]
        public void ReadExtraPifields_WhenCalled_SetsFields()
        {
            // Arrange
            const int readMaxHit = 3;
            var validations = 0;
            var readHit = 0;
            var sqlConnection = new SqlConnection();
            var optlist = new List<ItemDefn>();
            var now = DateTime.Now;
            var fids = new int[10];
            var fieldNames = new string[10];
            var fieldTypes = new int[10];
            var extra = new string[10];

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= readMaxHit)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadStringValueObject = key =>
            {
                if (key.Equals("FIELD_NAME_SQL"))
                {
                    return string.Empty;
                }
                return $"{DummyString}{readHit}";
            };
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => readHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimModelCache.AllInstances.GetCFFieldNameInt32Int32StringOutStringOut = (ModelCache instance, int lTableID, int lFieldID, out string sTable, out string sField) =>
            {
                validations += 1;
                sTable = DummyString;
                sField = DummyString;
            };

            privateObject.SetFieldOrProperty("m_fidextra", nonPublicInstance, fids);
            privateObject.SetFieldOrProperty("m_PI_Group", nonPublicInstance, 2);
            privateObject.SetFieldOrProperty("m_PI_Seq", nonPublicInstance, 3);
            privateObject.SetFieldOrProperty("m_ExtraFieldNames", nonPublicInstance, fieldNames);
            privateObject.SetFieldOrProperty("m_ExtraFieldTypes", nonPublicInstance, fieldTypes);
            privateObject.SetFieldOrProperty("m_sextra", nonPublicInstance, extra);

            // Act
            var actual = privateObject.Invoke(ReadExtraPifieldsMethodName, nonPublicInstance, new object[] { sqlConnection });
            var groupFid = (int)privateObject.GetFieldOrProperty("m_PI_Group_fid", nonPublicInstance);
            var seqFid = (int)privateObject.GetFieldOrProperty("m_PI_Seq_fid", nonPublicInstance);
            extra = (string[])privateObject.GetFieldOrProperty("m_ExtraFieldNames", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => groupFid.ShouldBe(5),
                () => seqFid.ShouldBe(6),
                () => extra[6].ShouldBe($"{DummyString}3"),
                () => validations.ShouldBe(11));
        }

        [TestMethod]
        public void StripNum_NoDelimiter_ReturnsInteger()
        {
            // Arrange
            const string input = "1001";

            // Act
            var actual = (int)privateObject.Invoke(StripNumMethodName, nonPublicInstance, new object[] { input });

            // Assert
            actual.ShouldBe(1001);
        }

        [TestMethod]
        public void StripNum_WithDelimiter_ReturnsInteger()
        {
            // Arrange
            const string input = "1001 sometext";

            // Act
            var actual = (int)privateObject.Invoke(StripNumMethodName, nonPublicInstance, new object[] { input });

            // Assert
            actual.ShouldBe(1001);
        }

        [TestMethod]
        public void MyFormat_EPK_FTYPE_DATE_ReturnsString()
        {
            // Arrange
            var scode = string.Empty;
            var sres = string.Empty;
            var now = DateTime.Now;
            var expected = now.ToString("yyyyMMddHHmm");
            var type = 1;

            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadDecimalValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            var actual = (string)privateObject.Invoke(
                MyFormatMethodName,
                nonPublicInstance,
                new object[] { new object(), type, scode, sres });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void MyFormat_EPK_FTYPE_DURATION_ReturnsString()
        {
            // Arrange
            var scode = string.Empty;
            var sres = string.Empty;
            var now = DateTime.Now;
            var expected = 1.ToString();
            var type = 23;

            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadDecimalValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            var actual = (string)privateObject.Invoke(
                MyFormatMethodName,
                nonPublicInstance,
                new object[] { new object(), type, scode, sres });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void MyFormat_EPK_FTYPE_RTF_ReturnsString()
        {
            // Arrange
            var scode = string.Empty;
            var sres = string.Empty;
            var now = DateTime.Now;
            var expected = DummyString;
            var type = 19;

            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadDecimalValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            var actual = (string)privateObject.Invoke(
                MyFormatMethodName,
                nonPublicInstance,
                new object[] { new object(), type, scode, sres });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void MyFormat_EPK_FTYPE_CODE_ReturnsString()
        {
            // Arrange
            var scode = string.Empty;
            var sres = string.Empty;
            var now = DateTime.Now;
            var expected = DummyInt.ToString();
            var type = 4;

            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadDecimalValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            var actual = (string)privateObject.Invoke(
                MyFormatMethodName,
                nonPublicInstance,
                new object[] { new object(), type, scode, sres });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void MyFormat_EPK_FTYPE_RES_ReturnsString()
        {
            // Arrange
            var scode = string.Empty;
            var sres = string.Empty;
            var now = DateTime.Now;
            var expected = DummyInt.ToString();
            var type = 7;

            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadDoubleValueObject = _ => 1;
            ShimSqlDb.ReadDecimalValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            var actual = (string)privateObject.Invoke(
                MyFormatMethodName,
                nonPublicInstance,
                new object[] { new object(), type, scode, sres });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ReadPILevelData_WhenCalled_SetsFields()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var sqlConnection = new SqlConnection();
            var now = DateTime.Now;
            var extra = new string[]
            {
                DummyString,
                DummyString,
                DummyString,
                DummyString
            };
            var fidExtra = new int[]
            {
                9911,
                9911,
                9911,
                DummyInt
            };
            var stages = new Dictionary<int, DataItem>()
            {
                [5] = new DataItem()
                {
                    UID = 5
                }
            };

            dataReader.ItemGetInt32 = input => input;
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
            ShimSqlDb.ReadDecimalValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => readHit;
            ShimSqlDb.ReadDateValueObject = key =>
            {
                if (key.Equals("PROJECT_START_DATE"))
                {
                    return now.AddDays(-(readHit));
                }
                return now.AddDays(readHit);
            };
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimModelCache.AllInstances.MyFormatObjectInt32StringRefStringRef = (ModelCache instance, object obj, int lt, ref string sCodes, ref string sRes) =>
            {
                sCodes = DummyString;
                sRes = DummyString;
                validations += 1;
                return DummyString;
            };

            privateObject.SetFieldOrProperty("m_SelFID", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_Select_FieldName", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_Use_extra", nonPublicInstance, 3);
            privateObject.SetFieldOrProperty("m_sextra", nonPublicInstance, extra);
            privateObject.SetFieldOrProperty("m_fidextra", nonPublicInstance, fidExtra);
            privateObject.SetFieldOrProperty("m_dtMin", nonPublicInstance, now);
            privateObject.SetFieldOrProperty("m_dtMax", nonPublicInstance, now);
            privateObject.SetFieldOrProperty("m_stages", nonPublicInstance, stages);


            // Act
            privateObject.Invoke(
                ReadPILevelDataMethodName,
                nonPublicInstance,
                new object[] { sqlConnection, now, now });
            var piData = (Dictionary<string, PIData>)privateObject.GetFieldOrProperty("m_PIs", nonPublicInstance);
            var codes = (Dictionary<int, DataItem>)privateObject.GetFieldOrProperty("m_codes", nonPublicInstance);
            var reses = (Dictionary<int, DataItem>)privateObject.GetFieldOrProperty("m_reses", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => piData.Count.ShouldBe(3),
                () => piData.ElementAt(0).Value.m_PI_Extra_data[1].ShouldBe(5.ToString()),
                () => piData.ElementAt(0).Value.m_PI_Extra_data[2].ShouldBe(string.Empty),
                () => piData.ElementAt(0).Value.m_PI_Extra_data[3].ShouldBe(DummyString),
                () => codes.Count.ShouldBe(3),
                () => reses.Count.ShouldBe(3),
                () => validations.ShouldBe(15));
        }

        [TestMethod]
        public void ReadCostCustomFieldsAndData_WhenCalled_PopulatesData()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var readIntHit = 1;
            var stripNumHit = 0;
            var sqlConnection = new SqlConnection();
            var now = DateTime.Now;
            var periodIndicator = new int[100];
            var piData = new PIData(10)
            {
                PI_Name = DummyString
            };
            var dataItem = new DataItem()
            {
                Name = DummyString
            };
            var catItemData = new CatItemData(10)
            {
                Name = DummyString,
                FullName = DummyString,
                MC_Val = DummyString,
                Role_Name = DummyString,
                Category = 1
            };
            var pids = new Dictionary<string, PIData>()
            {
                [$"{1} -1"] = piData
            };
            var costTypes = new Dictionary<int, DataItem>()
            {
                [1] = dataItem
            };
            var costCat = new Dictionary<int, CatItemData>()
            {
                [1] = catItemData
            };

            dataReader.ItemGetInt32 = input => input;
            dataReader.Read = () =>
            {
                readHit += 1;
                readIntHit += 1;
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
            ShimSqlDb.ReadDecimalValueObject = _ => 1;
            ShimSqlDb.ReadIntValueObject = _ => readIntHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimModelCache.AllInstances.StripNumStringRef = (ModelCache instance, ref string sin) =>
            {
                validations += 1;
                if (string.IsNullOrEmpty(sin))
                {
                    stripNumHit += 1;
                    return stripNumHit - 1;
                }
                else
                {
                    sin = string.Empty;
                    return stripNumHit;
                }
            };

            privateObject.SetFieldOrProperty("m_sCostTypes", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_sCalcCostTypes", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_sOtherCostTypes", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, 10);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_CostTypes", nonPublicInstance, costTypes);
            privateObject.SetFieldOrProperty("m_Scenario", nonPublicInstance, costTypes);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("perind", nonPublicInstance, periodIndicator);

            // Act
            privateObject.Invoke(ReadCostCustomFieldsAndDataMethodName, nonPublicInstance, new object[] { sqlConnection });
            var detailData = (Dictionary<string, DetailRowData>)privateObject.GetFieldOrProperty("m_detaildata", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => detailData.Count.ShouldBe(27),
                () => validations.ShouldBe(46));
        }

        [TestMethod]
        public void ReadBudgetBands_WhenCalled_PopulatesTargetColours()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var readIntHit = 1;
            var sqlConnection = new SqlConnection();
            var now = DateTime.Now;

            dataReader.ItemGetInt32 = input => input;
            dataReader.Read = () =>
            {
                readHit += 1;
                readIntHit += 1;
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

            ShimSqlDb.ReadStringValueObject = _ => $"{DummyString}{readIntHit}";
            ShimSqlDb.ReadDoubleValueObject = _ => readIntHit;
            ShimSqlDb.ReadDecimalValueObject = _ => readIntHit;
            ShimSqlDb.ReadIntValueObject = _ => readIntHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            privateObject.Invoke(ReadBudgetBandsMethodName, nonPublicInstance, new object[] { sqlConnection });
            var targetColours = (List<TargetColours>)privateObject.GetFieldOrProperty("m_TargetColours", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => targetColours.Count.ShouldBe(3),
                () => validations.ShouldBe(4));
        }

        [TestMethod]
        public void ReadModelTargets_WhenCalled_PopulatesTargetAndAssignableCts()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var readIntHit = 1;
            var sqlConnection = new SqlConnection();
            var now = DateTime.Now;

            dataReader.ItemGetInt32 = input => input;
            dataReader.Read = () =>
            {
                readHit += 1;
                readIntHit += 1;
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

            ShimSqlDb.ReadStringValueObject = _ => $"{DummyString}{readIntHit}";
            ShimSqlDb.ReadDoubleValueObject = _ => readIntHit;
            ShimSqlDb.ReadDecimalValueObject = _ => readIntHit;
            ShimSqlDb.ReadIntValueObject = _ => readIntHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            privateObject.Invoke(
                ReadModelTargetsMethodName,
                nonPublicInstance,
                new object[] { sqlConnection, DummyString });
            var target = (List<DataItem>)privateObject.GetFieldOrProperty("m_Target", nonPublicInstance);
            var assignableCts = (List<DataItem>)privateObject.GetFieldOrProperty("m_AssignableCTS", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => target.Count.ShouldBe(3),
                () => assignableCts.Count.ShouldBe(3),
                () => validations.ShouldBe(8));
        }

        [TestMethod]
        public void ReadRateTable_WhenCalled_PopulatesRates()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var readIntHit = 1;
            var sqlConnection = new SqlConnection();
            var now = DateTime.Now;
            var periodData = new Dictionary<int, PeriodData>()
            {
                [DummyInt] = new PeriodData()
                {
                    StartDate = now.AddDays(1)
                }
            };

            dataReader.ItemGetInt32 = input => input;
            dataReader.Read = () =>
            {
                readHit += 1;
                readIntHit += 1;
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

            ShimSqlDb.ReadStringValueObject = _ => $"{DummyString}{readIntHit}";
            ShimSqlDb.ReadDoubleValueObject = _ => readIntHit;
            ShimSqlDb.ReadDecimalValueObject = _ => readIntHit;
            ShimSqlDb.ReadIntValueObject = _ => readIntHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, 10);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periodData);

            // Act
            privateObject.Invoke(ReadRateTableMethodName, nonPublicInstance, new object[] { sqlConnection });
            var rates = (Dictionary<int, RateTable>)privateObject.GetFieldOrProperty("m_Rates", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => rates.Count.ShouldBe(6),
                () => validations.ShouldBe(12));
        }
    }
}

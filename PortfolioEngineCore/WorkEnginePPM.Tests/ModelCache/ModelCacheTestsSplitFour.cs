using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace WorkEnginePPM.Tests.ModelCacheTests
{
    public partial class ModelCacheTests
    {
        private const string SaveTargetDataMethodName = "SaveTargetData";
        private const string GetLegendGridLayoutMethodName = "GetLegendGridLayout";
        private const string GetLegendGridDataMethodName = "GetLegendGridData";
        private const string LoadUserViewDataMethodName = "LoadUserViewData";
        private const string DeleteUserViewDataMethodName = "DeleteUserViewData";
        private const string RenameUserViewDataMethodName = "RenameUserViewData";
        private const string SaveUserViewDataMethodName = "SaveUserViewData";
        private const string LoadUserViewsMethodName = "LoadUserViews";

        [TestMethod]
        public void SaveTargetData_WhenCalled_InsertsDatabase()
        {
            // Arrange
            var validations = 0;
            var expected = 12 + (Max * 10);
            var sqlConnection = default(SqlConnection);
            var targetRowData = new TargetRowData()
            {
                bGroupRow = false,
                OCVal = (new object[6]).Select(x => DummyInt).ToArray(),
                TXVal = (new object[6]).Select(x => DummyString).ToArray(),
                zCost = (new object[Max + 1]).Select(x => 1d).ToArray(),
                zValue = (new object[Max + 1]).Select(x => 1d).ToArray()
            };
            var csTargetData = new CSTargetData()
            {
                targetRows = (new object[10]).Select(x => targetRowData).ToArray()
            };

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return One;
            };

            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, Max);

            // Act
            var actual = privateObject.Invoke(SaveTargetDataMethodName, publicInstance, new object[] { sqlConnection, One, csTargetData });

            // Assert
            validations.ShouldBe(expected);
        }

        [TestMethod]
        public void GetLegendGridLayout_WhenCalled_ReturnsString()
        {
            // Arrange and Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetLegendGridLayoutMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("Grid")
                    .Element("Toolbar")
                    .Attribute("Visible")
                    .Value
                    .ShouldBe("0"),
                () => actual
                    .Element("Grid")
                    .Element("Panel")
                    .Attribute("Visible")
                    .Value
                    .ShouldBe("1"),
                () => actual
                    .Element("Grid")
                    .Element("Header")
                    .Attribute("Visible")
                    .Value
                    .ShouldBe("0"));
        }

        [TestMethod]
        public void GetLegendGridData_WhenCalled_ReturnsString()
        {
            // Arrange
            var targetColours = new List<TargetColours>()
            {
                new TargetColours()
                {
                    rgb_val = -1,
                    Desc = DummyString
                },
                new TargetColours()
                {
                    rgb_val = 10,
                    Desc = DummyString
                }
            };

            privateObject.SetFieldOrProperty("m_TargetColours", nonPublicInstance, targetColours);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetLegendGridDataMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("Grid")
                    .Element("Cfg")
                    .Attribute("FilterEmpty")
                    .Value
                    .ShouldBe("1"),
                () => actual
                    .Element("Grid")
                    .Element("Body")
                    .Element("I")
                    .Elements("I")
                    .Count(x => x.Attribute("Key").Value.Equals(DummyString))
                    .ShouldBe(2));
        }

        [TestMethod]
        public void LoadUserViewData_WhenCalled_ReturnsList()
        {
            // Arrange
            var ctViews = dataItemDictionary.Values.ToList();

            privateObject.SetFieldOrProperty("m_CT_Views", nonPublicInstance, ctViews);

            // Act
            var actual = (List<ItemDefn>)privateObject.Invoke(LoadUserViewDataMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual.Count(x => x.Name.Equals(DummyString)).ShouldBe(2),
                () => actual.Count(x => x.Id.Equals(One) && x.Deflt.Equals(One)).ShouldBe(1),
                () => actual.Count(x => x.Id.Equals(Two) && x.Deflt.Equals(Two)).ShouldBe(1));
        }

        [TestMethod]
        public void DeleteUserViewData_WhenCalled_DeletesRecords()
        {
            // Arrange
            var validations = 0;
            var sqlConnection = default(SqlConnection);

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return One;
            };
            ShimModelCache.AllInstances.LoadUserViewsSqlConnection = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_WResID", nonPublicInstance, DummyString);

            // Act
            privateObject.Invoke(DeleteUserViewDataMethodName, publicInstance, new object[] { sqlConnection, DummyString, One });

            // Assert
            validations.ShouldBe(2);
        }

        [TestMethod]
        public void RenameUserViewData_WhenCalled_UpdatesRecords()
        {
            // Arrange
            var validations = 0;
            var sqlConnection = default(SqlConnection);

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return One;
            };
            ShimModelCache.AllInstances.LoadUserViewsSqlConnection = (_, __) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_WResID", nonPublicInstance, DummyString);

            // Act
            privateObject.Invoke(RenameUserViewDataMethodName, publicInstance, new object[] { sqlConnection, DummyString, DummyString, One });

            // Assert
            validations.ShouldBe(2);
        }

        [TestMethod]
        public void SaveUserViewData_WhenCalled_UpdatesRecords()
        {
            // Arrange
            var validations = 0;
            var sqlConnection = default(SqlConnection);

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return One;
            };
            ShimModelCache.AllInstances.LoadUserViewsSqlConnection = (_, __) =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.GetUserViewSlugString = (_, __) =>
            {
                validations += 1;
                return DummyString;
            };

            privateObject.SetFieldOrProperty("m_WResID", nonPublicInstance, DummyString);

            // Act
            privateObject.Invoke(SaveUserViewDataMethodName, publicInstance, new object[] { sqlConnection, DummyString, One, DummyString });

            // Assert
            validations.ShouldBe(5);
        }

        [TestMethod]
        public void LoadUserViews_WhenCalled_SetsViewsField()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var readIntHit = 0;
            var now = DateTime.Now;
            var sqlConnection = default(SqlConnection);

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 3)
                {
                    readIntHit += 1;
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
            privateObject.Invoke(LoadUserViewsMethodName, nonPublicInstance, new object[] { sqlConnection });
            var actual = (List<DataItem>)privateObject.GetFieldOrProperty("m_CT_Views", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(3),
                () => actual.Count(x => x.UID.Equals(4) || x.UID.Equals(5) || x.UID.Equals(6)).ShouldBe(3),
                () => validations.ShouldBe(8));
        }
    }
}
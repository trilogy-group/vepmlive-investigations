using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;


namespace PortfolioEngineCore.Tests.Base
{
    [TestClass]
    public class LmrIfTests
    {
        private IDisposable _shimsContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            Setup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetPortfolioFields_Always_ReturnExpectedValue()
        {
            // Arrange
            const int intType = 10;
            var dbAccess = GetShimDBAccess();

            // Act
            var result = LMR_IF.getPortfolioFields(dbAccess, intType);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Columns.Count.ShouldBe(3),
                () => result.Columns[0].ColumnName.ShouldBe("epkField"),
                () => result.Columns[1].ColumnName.ShouldBe("epkFieldId"),
                () => result.Columns[2].ColumnName.ShouldBe("epkFieldType"),
                () => result.Rows.Count.ShouldBe(2));
        }

        [TestMethod]
        public void SaveResourceFieldMappings_Always_ReturnExpectedValue()
        {
            // Arrange
            var dbAccess = GetShimDBAccess();
            var dataTable = new DataTable
            {
                Columns = { "EPKID", "WEID", "WEName" },
                Rows = { "EPKID", "WEID", "WEName" }
            };

            // Act
            var result = LMR_IF.saveResourceFieldMappings(
                dbAccess,
                dataTable);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetResourceFields_Always_ReturnExpectedValue()
        {
            // Arrange
            var dbAccess = GetShimDBAccess();

            // Act
            var result = LMR_IF.getResourceFields(dbAccess);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Columns.Count.ShouldBe(2),
                () => result.Columns[0].ColumnName.ShouldBe("epkField"),
                () => result.Columns[1].ColumnName.ShouldBe("epkFieldId"),
                () => result.Rows.Count.ShouldBe(2));
        }

        [TestMethod]
        public void GetTaskFields_Always_ReturnExpectedValue()
        {
            // Arrange
            var dbAccess = GetShimDBAccess();

            // Act
            var result = LMR_IF.getTaskFields(dbAccess);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Columns.Count.ShouldBe(3),
                () => result.Columns[0].ColumnName.ShouldBe("epkField"),
                () => result.Columns[1].ColumnName.ShouldBe("epkFieldId"),
                () => result.Columns[2].ColumnName.ShouldBe("epkFieldType"),
                () => result.Rows.Count.ShouldBe(2));
        }

        [TestMethod]
        public void GetPortfolioViews_Always_ReturnExpectedValue()
        {
            // Arrange
            var dbAccess = GetShimDBAccess();

            // Act
            var result = LMR_IF.getPortfolioViews(dbAccess);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Columns.Count.ShouldBe(2),
                () => result.Columns[0].ColumnName.ShouldBe("epkView"),
                () => result.Columns[1].ColumnName.ShouldBe("epkViewId"),
                () => result.Rows.Count.ShouldBe(2));
        }

        [TestMethod]
        public void GetCostViews_Always_ReturnExpectedValue()
        {
            // Arrange
            var dbAccess = GetShimDBAccess();

            // Act
            var result = LMR_IF.getCostViews(dbAccess);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Columns.Count.ShouldBe(2),
                () => result.Columns[0].ColumnName.ShouldBe("costView"),
                () => result.Columns[1].ColumnName.ShouldBe("costViewId"),
                () => result.Rows.Count.ShouldBe(2));
        }

        private ShimDBAccess GetShimDBAccess()
        {
            var shim = new ShimDBAccess();
            new ShimSqlDb(shim)
            {
                Close = () => { },
                ConnectionGet = () => new ShimSqlConnection
                {
                    BeginTransaction = () => new ShimSqlTransaction
                    {
                        Commit = () => { },
                        Rollback = () => { }
                    }
                },
                Open = () => StatusEnum.rsBasePathNotSet
            };
            return shim;
        }

        private void Setup()
        {
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance => 0;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                var dictionary = new Dictionary<string, object>
                {
                    ["dummy"] = "Dummy",
                    ["FIELD_ID"] = 20001,
                    ["FIELD_NAME"] = "FIELD_NAME",
                    ["VIEW_UID"] = 10,
                    ["VIEW_NAME"] = "VIEW_NAME"
                };
                var index = 0;
                var shim = new ShimSqlDataReader
                {
                    ItemGetString = stringKey => dictionary.ContainsKey(stringKey) ? dictionary[stringKey] : null,
                    Read = () => 
                    {
                        return index++ <= 1;
                    },
                    Close = () => { }
                };
                return shim;
            };
        }
    }
}

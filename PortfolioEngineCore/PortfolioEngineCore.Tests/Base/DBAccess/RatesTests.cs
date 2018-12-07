using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Base
{
    [TestClass, ExcludeFromCodeCoverage]
    public class RatesTests
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
        public void UpdateRatesInfo_Always_ReturnSuccess()
        {
            // Arrange
            var dbAccess = GetShimDBAccess();
            var dataTable = new DataTable
            {
                Columns = { "RT_UID", "RT_NAME", "RT_LEVEL", "rates", "wres_ids" },
                Rows =
                {
                    new object[] { 2, "RT_NAME", 10, "2018-12-07:NDA:11", "13" },
                }
            };
            string reply;

            // Act
            var result = dbaRates.UpdateRatesInfo(dbAccess, dataTable, out reply);

            // Assert
            result.ShouldBe(StatusEnum.rsSuccess);
        }

        [TestMethod]
        public void UpdateRatesInfo_Always_RequestCannotBeCompleted()
        {
            // Arrange
            var dbAccess = GetShimDBAccess();
            var dataTable = new DataTable
            {
                Columns = { "RT_UID", "RT_NAME", "RT_LEVEL", "rates", "wres_ids" },
                Rows =
                {
                    new object[] { 0, "RT_NAME", 10, "rates", "13" },
                }
            };
            string reply;

            // Act
            var result = dbaRates.UpdateRatesInfo(dbAccess, dataTable, out reply);

            // Assert
            result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted);
        }

        [TestMethod]
        public void SelectAdminRates_Always_Success()
        {
            // Arrange
            var dbAccess = GetShimDBAccess();
            DataTable dataTable;

            // Act
            var result = dbaRates.SelectAdminRates(dbAccess, out dataTable);

            // Assert
            result.ShouldBe(StatusEnum.rsSuccess);
        }

        [TestMethod]
        public void SelectResources_Always_Success()
        {
            // Arrange
            var dbAccess = GetShimDBAccess();
            DataTable dataTable;

            // Act
            var result = dbaRates.SelectResources(dbAccess, out dataTable);

            // Assert
            result.ShouldBe(StatusEnum.rsSuccess);
        }

        private ShimDBAccess GetShimDBAccess()
        {
            var shim = new ShimDBAccess();
            new ShimSqlDb(shim)
            {
                BeginTransaction = () => { },
                Close = () => { },
                ConnectionGet = () => new ShimSqlConnection
                {
                    BeginTransaction = () => new ShimSqlTransaction
                    {
                        Commit = () => { },
                        Rollback = () => { }
                    }
                },
                Open = () => StatusEnum.rsBasePathNotSet,
                TransactionGet = () => new ShimSqlTransaction(),
                RollbackTransaction = () => { }
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
                    ["Max_UID"] = 2,
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
                        return index++ < 1;
                    },
                    Close = () => { }
                };
                return shim;
            };
        }
    }
}

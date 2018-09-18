using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests.Analyzers
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlClient.Fakes;
    using Fakes;
    using PortfolioEngineCore;
    using Shouldly;

    [TestClass]
    public class OptimizerDataTest
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private IDisposable shimContext;
        private OptimizerData optimizerData;
        private PrivateObject privateObject;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            optimizerData = new OptimizerData(DummyString, DummyString, DummyString, DummyString, DummyString, SecurityLevels.Base);
            privateObject = new PrivateObject(optimizerData);
        }

        private void SetupShims()
        {

            //ShimPFEBase.ConstructorStringSecurityLevelsBoolean = (_, baseInfo, securityLevel, debug) => { };
            //ShimPFEBase.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
            //    (_, basePath, username, pid, company, connString, securityLevel, debug) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };

            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();

            ShimSqlDataReader.AllInstances.Read = _ => false;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;

            ShimSqlDb.ReadIntValueObject = _ => 1;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;

            ShimCStruct.AllInstances.LoadXMLString = (_, xml) => true;


            ShimUtilities.ResolveNTNameintoWResIDSqlConnectionString = (sqlConnection, userName) => 1;

        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        [TestMethod]
        public void ConstructorString_WithValidParameters_ShouldCreateInstance()
        {
            // Arrange
            ShimCStruct.AllInstances.GetStringString = (_, attr) => DummyString;
            ShimCStruct.AllInstances.GetIntString = (_, attr) => 1;

            // Act
            optimizerData = new OptimizerData(DummyString);
            privateObject = new PrivateObject(optimizerData);
            var connection = privateObject.GetFieldOrProperty("_sqlConnection") as SqlConnection;

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => optimizerData.ShouldNotBeNull(),
                () => connection.ShouldNotBeNull());
        }

        [TestMethod]
        public void Constructor_WithValidParameters_ShouldCreateInstance()
        {
            // Arrange
            ShimUtilities.ResolveNTNameintoWResIDSqlConnectionString = (sqlConnection, userName) => 1;

            // Act
            optimizerData = new OptimizerData(DummyString, DummyString, DummyString, DummyString, DummyString, SecurityLevels.Base);
            privateObject = new PrivateObject(optimizerData);
            var connection = privateObject.GetFieldOrProperty("_sqlConnection") as SqlConnection;
            var id = privateObject.GetFieldOrProperty("_userWResID") as int?;

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => optimizerData.ShouldNotBeNull(),
                () => connection.ShouldNotBeNull(),
                () => id.ShouldNotBeNull(),
                () => id.Value.ShouldBe(1));
        }

        [TestMethod]
        public void GetOptimizerViewsXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            var count = 0;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimCStruct.AllInstances.InitializeString = (_, name) => { };
            ShimSqlDataReader.AllInstances.Read = _ => ++count <= 1;
            ShimCStruct.AllInstances.AppendSubStructCStruct = (_, cStruct) => new CStruct();
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var result = optimizerData.GetOptimizerViewsXML(out reply);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => reply.ShouldNotBeEmpty(),
                () => result.ShouldBeTrue());
        }

        [TestMethod]
        public void GetOptimizerViewXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            var count = 0;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlDataReader.AllInstances.Read = _ => ++count <= 1;
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var result = optimizerData.GetOptimizerViewXML(DummyGuid, out reply);

            // Assert
            optimizerData.ShouldSatisfyAllConditions(
                () => reply.ShouldNotBeEmpty(),
                () => result.ShouldBeTrue());
        }

        

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Resources
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ResourceAnalyzerTests
    {
        private ResourceAnalyzer resourceAnalyzer;
        private IDisposable shimsContext;
        private const string DummyString = "DummyString";
        private const string BaseInfo = "<main></main>";
        private PrivateObject privateObect;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            resourceAnalyzer = new ResourceAnalyzer(BaseInfo);
            privateObect = new PrivateObject(resourceAnalyzer);

        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            //ShimPFEBase.ConstructorStringSecurityLevelsBoolean = (_, baseInfo, level, debug) => { };
            //ShimPFEBase.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
            //    (_, basePath, username, pid, company, db, level, debug) => { };
            //ShimCstruct
            ShimActivation.ConstructorDebugger = (_, debugger) => { };
            ShimActivation.AllInstances.checkActivationStringStringString = (_, basePath, pid, company) => { };
            ShimDatabase.ConstructorDebugger = (_, debugger) => { };
            ShimDatabase.AllInstances.OpenDatabaseStringString = (_, path, pid) => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Read = _ => false;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimDBAccess.ConstructorStringSqlConnection = (_, connectionString, connection) => { };
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => DBNull.Value;
            ShimBaseSecurity.ConstructorDebuggerSqlConnection = (_, debugger, connection) => { };
            ShimBaseSecurity.AllInstances.ChecksScurityStringSecurityLevels = (_, username, level) => true;
        }

        [TestMethod]
        public void ConstructorBaseInfo_Should_ExecutesCorrectly()
        {
            // Arrange
            var baseInfo = "<main></main>";

            // Act
            var instance = new ResourceAnalyzer(baseInfo);
            privateObect = new PrivateObject(instance);
            var connection = privateObect.GetFieldOrProperty("_sqlConnection") as SqlConnection;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => resourceAnalyzer.ShouldNotBeNull(),
                () => connection.ShouldNotBeNull());
        }

        [TestMethod]
        public void Constructor_Should_ExecutesCorrectly()
        {
            // Arrange
            var baseInfo = "<main></main>";
            ShimUtilities.ResolveNTNameintoWResIDSqlConnectionString = (sqlConnection, username) => 1;

            // Act
            var instance = new ResourceAnalyzer(baseInfo, DummyString, DummyString, DummyString, 
                DummyString, SecurityLevels.AdminCalc, true);
            privateObect = new PrivateObject(instance);
            var connection = privateObect.GetFieldOrProperty("_sqlConnection") as SqlConnection;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => resourceAnalyzer.ShouldNotBeNull(),
                () => connection.ShouldNotBeNull());
        }

        [TestMethod]
        public void DeleteResourceAnalyzerViewXML_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "DELETE FROM EPG_VIEWS WHERE VIEW_GUID=@guid";
            var executedCommand = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = cmd =>
            {
                executedCommand = cmd.CommandText;
                return 1;
            };

            // Act
            var result = resourceAnalyzer.DeleteResourceAnalyzerViewXML(Guid.NewGuid());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => executedCommand.ShouldNotBeNullOrEmpty(),
                () => executedCommand.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void RenameResourceAnalyzerViewXML_Should_ExecuteCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@name,VIEW_DATA = @vdata WHERE VIEW_GUID=@guid";
            var executedCommand = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => DummyString
            };
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.XML = _ => DummyString;
            ShimCStruct.AllInstances.SetStringAttrStringStringBoolean = (_, name, value, create) => { };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = cmd =>
            {
                executedCommand = cmd.CommandText;
                return 1;
            };

            // Act
            var result = resourceAnalyzer.RenameResourceAnalyzerViewXML(Guid.NewGuid(), DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => executedCommand.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void RenameResourceAnalyzerViewXML_NoRowsAffected_ReturnsFalse()
        {
            // Arrange
            const string ExpectedCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@name,VIEW_DATA = @vdata WHERE VIEW_GUID=@guid";
            var executedCommand = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => DummyString
            };
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.XML = _ => DummyString;
            ShimCStruct.AllInstances.SetStringAttrStringStringBoolean = (_, name, value, create) => { };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = cmd =>
            {
                executedCommand = cmd.CommandText;
                return 0;
            };

            // Act
            var result = resourceAnalyzer.RenameResourceAnalyzerViewXML(Guid.NewGuid(), DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => executedCommand.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void RenameResourceAnalyzerViewXML_XmlNull_ReturnsFalse()
        {
            // Arrange
            var executedCommand = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => false,
                ItemGetString = name => DummyString
            };
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.XML = _ => DummyString;
            ShimCStruct.AllInstances.SetStringAttrStringStringBoolean = (_, name, value, create) => { };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = cmd =>
            {
                executedCommand = cmd.CommandText;
                return 0;
            };

            // Act
            var result = resourceAnalyzer.RenameResourceAnalyzerViewXML(Guid.NewGuid(), DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse());
        }

        [TestMethod]
        public void SetResourceAnalyzerDraggedDataXML_XmlNull_ReturnsFalse()
        {
            // Arrange, Act
            var result = resourceAnalyzer.SetResourceAnalyzerDraggedDataXML(string.Empty);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void SetResourceAnalyzerDraggedDataXML_OnSuccess_ReturnsTrue()
        {
            // Arrange
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>
            {
                new ShimCStruct
                {
                    GetIntAttrString = attr => 1,
                    GetListString = list => new List<CStruct>
                    {
                        new ShimCStruct
                        {
                            GetIntAttrString = attr => 1,
                            GetDoubleAttrStringDouble = (attr, defaultValue)  => 1
                        }
                    }
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = resourceAnalyzer.SetResourceAnalyzerDraggedDataXML(BaseInfo);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void SaveResourceAnalyzerViewXML_Should_executeCorrectly()
        {
            // Arrange
            var expectedCommands = new List<string>
            {
                "UPDATE EPG_VIEWS SET VIEW_NAME=@vname,WRES_ID=@wres,VIEW_DEFAULT=@vdef,VIEW_DATA=@vdata,VIEW_CONTEXT=32000 WHERE VIEW_GUID=@guid",
                "INSERT INTO EPG_VIEWS (VIEW_GUID,VIEW_NAME,WRES_ID,VIEW_DEFAULT,VIEW_DATA,VIEW_CONTEXT) VALUES(@guid,@name,@wres,@def,@vdata,32000)",
                "UPDATE EPG_VIEWS SET VIEW_DEFAULT=0 WHERE VIEW_CONTEXT=32000 AND VIEW_GUID<>@VIEW_GUID"
            };
            var executedCommands = new List<string>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = cmd =>
            {
                executedCommands.Add(cmd.CommandText);
                return executedCommands.Count - 1;
            };

            // Act
            var result = resourceAnalyzer.SaveResourceAnalyzerViewXML(
                Guid.NewGuid(),
                DummyString, 
                true, 
                true, 
                DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => expectedCommands.All(cmd => executedCommands.Contains(cmd)).ShouldBeTrue());
        }

        [TestMethod]
        public void GetResourceAnalyzerViewXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => BaseInfo
            };

            // Act
            var result = resourceAnalyzer.GetResourceAnalyzerViewXML(Guid.NewGuid(), out reply);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => reply.ShouldNotBeEmpty(),
                () => reply.ShouldBe(BaseInfo));
        }


        [TestMethod]
        public void GetResourceAnalyzerViewsXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetString = GetValue(new Hashtable
                {
                    ["VIEW_DATA"] = BaseInfo,
                    ["VIEW_DEFAULT"] = true
                })
            };

            // Act
            var result = resourceAnalyzer.GetResourceAnalyzerViewsXML(out reply);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => reply.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void SetResourceAnalyzerUserCalendarSettingsXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetString = GetValue(new Hashtable
                {
                    ["UINF_XML"] = string.Empty
                })
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = resourceAnalyzer.SetResourceAnalyzerUserCalendarSettingsXML(1, 1, 1);

            // Assert
            result.ShouldBeTrue();
        }

        private FakesDelegates.Func<string, object> GetValue(Hashtable hashtable)
        {
            return name =>
            {
                return hashtable.ContainsKey(name)
                    ? hashtable[name]
                    : DBNull.Value;
            };
        }
    }
}

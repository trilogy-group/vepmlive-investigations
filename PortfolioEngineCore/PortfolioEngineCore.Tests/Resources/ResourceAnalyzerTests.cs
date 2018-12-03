using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        private PrivateObject privateObect;
        private const string DummyString = "DummyString";
        private const string BaseInfo = "<main></main>";
        private const string CB_ID = "CB_ID";
        private const string CB_NAME = "CB_NAME";
        private const string PRD_ID = "PRD_ID";
        private const string PRD_NAME = "PRD_NAME";
        private const string PRD_START_DATE = "PRD_START_DATE";
        private const string PRD_FINISH_DATE = "PRD_FINISH_DATE";
        private const string UINF_XML = "UINF_XML";
        private const string VIEW_DATA = "VIEW_DATA";
        private const string VIEW_DEFAULT = "VIEW_DEFAULT";
        private const string SqlConnectionField = "_sqlConnection";

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
            ShimActivation.ConstructorDebugger = (_, debugger) => { };
            ShimActivation.AllInstances.checkActivationStringStringString = 
                (_, basePath, pid, company) => { };
            ShimDatabase.ConstructorDebugger = (_, debugger) => { };
            ShimDatabase.AllInstances.OpenDatabaseStringString = 
                (_, path, pid) => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Read = _ => false;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimDBAccess.ConstructorStringSqlConnection = (_, connectionString, connection) => { };
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => DBNull.Value;
            ShimBaseSecurity.ConstructorDebuggerSqlConnection = (_, debugger, connection) => { };
            ShimBaseSecurity.AllInstances.ChecksScurityStringSecurityLevels = 
                (_, username, level) => true;
        }

        [TestMethod]
        public void ConstructorBaseInfo_Should_ExecutesCorrectly()
        {
            // Arrange, Act
            var instance = new ResourceAnalyzer(BaseInfo);
            privateObect = new PrivateObject(instance);
            var connection = privateObect.GetFieldOrProperty(SqlConnectionField) as SqlConnection;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => resourceAnalyzer.ShouldNotBeNull(),
                () => connection.ShouldNotBeNull());
        }

        [TestMethod]
        public void Constructor_Should_ExecutesCorrectly()
        {
            // Arrange
            ShimUtilities.ResolveNTNameintoWResIDSqlConnectionString = (sqlConnection, username) => 1;

            // Act
            var instance = new ResourceAnalyzer(
                BaseInfo, 
                DummyString, 
                DummyString, 
                DummyString, 
                DummyString, 
                SecurityLevels.AdminCalc,
                true);
            privateObect = new PrivateObject(instance);
            var connection = privateObect.GetFieldOrProperty(SqlConnectionField) as SqlConnection;

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
                    [VIEW_DATA] = BaseInfo,
                    [VIEW_DEFAULT] = true
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
                    [UINF_XML] = string.Empty
                })
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = resourceAnalyzer.SetResourceAnalyzerUserCalendarSettingsXML(1, 1, 1);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetResourceAnalyzerUserCalendarSettingsXML_Should_ExecuteCorrectly()
        {
            // Arrange
            const int Id = 16;
            var reply = string.Empty;
            var count = 0;
            var expectedValue = $"<LastUserData lastCalID=\"{Id}\" lastStartPerID=\"{Id}\" lastFinishPerID=\"{Id}\" />";
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (dba, id, permissions) => true;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    if (++count <= 1)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                        return false;
                    }
                },
                ItemGetString = GetValue(new Hashtable
                {
                    [CB_ID] = Id,
                    [CB_NAME] = DummyString,
                    [PRD_ID] = Id,
                    [PRD_NAME] = DummyString,
                    [PRD_START_DATE] = DateTime.Now.AddDays(-1),
                    [PRD_FINISH_DATE] = DateTime.Now.AddDays(1),
                })
            };

            // Act
            var result = resourceAnalyzer.GetResourceAnalyzerUserCalendarSettingsXML(out reply);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(expectedValue));
        }

        [TestMethod]
        public void GetResourceAnalyzerUserCalendarSettingsXML_WithInfXml_ExecutesCorrectly()
        {
            // Arrange
            const int Id = 16;
            var reply = string.Empty;
            var count = 0;
            var expectedValue = $"<LastUserData lastCalID=\"{Id}\" lastStartPerID=\"{Id}\" lastFinishPerID=\"{Id}\" />";
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (dba, id, permissions) => true;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    if (++count <= 1)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                        return false;
                    }
                },
                ItemGetString = GetValue(new Hashtable
                {
                    [CB_ID] = Id,
                    [CB_NAME] = DummyString,
                    [PRD_ID] = Id,
                    [PRD_NAME] = DummyString,
                    [PRD_START_DATE] = DateTime.Now.AddDays(-1),
                    [PRD_FINISH_DATE] = DateTime.Now.AddDays(1),
                    [UINF_XML] = BaseInfo
                })
            };
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();
            ShimCStruct.AllInstances.GetIntString = (_, name) => Id;
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();

            // Act
            var result = resourceAnalyzer.GetResourceAnalyzerUserCalendarSettingsXML(out reply);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(expectedValue));
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

using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.Fakes;
using PortfolioEngineCore.Fakes;
using PortfolioEngineCore.Setup;
using PortfolioEngineCore.Setup.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Setup
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SetupSiteTests
    {
        private IDisposable _shimObject;
        private SetupSite _testObj;
        private PrivateObject _privateObj;

        private bool _checkActivation;
        private bool _openMasterCalled;
        private bool _createDBCalled;
        private bool _runDBScriptsCalled;
        private bool _addregistryEntriesCalled;
        private bool _dbClosed;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyError = "Dummy Error";

        private const string RenamePFEPermissionsMethod = "RenamePFEPermissions";

        [TestInitialize]
        public void TestInitialize()
        {
            _checkActivation = false;
            _openMasterCalled = false;
            _createDBCalled = false;
            _runDBScriptsCalled = false;
            _addregistryEntriesCalled = false;
            _dbClosed = false;

            _shimObject = ShimsContext.Create();
            _testObj = new SetupSite();
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        [TestMethod]
        public void GetBaseKey_WhenKeyFound_ConfirmResult()
        {
            // Arrange
            ShimRegistryKey.OpenRemoteBaseKeyRegistryHiveString = (_, __) => new ShimRegistryKey();
            ShimRegistryKey.AllInstances.OpenSubKeyStringBoolean = (_, name, __) =>
            {
                switch (name)
                {
                    case "Software":
                    case "Wow6432Node":
                    case "EPMLive":
                    case "PortfolioEngine":
                        return new ShimRegistryKey
                        {
                            NameGet = () => "ExistingRegistryKey"
                        };
                    default:
                        return null;
                }
            };
            //ShimActivation.Constructor
            
            // Act
            var result = _testObj.GetBaseKey(DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Name.ShouldBe("ExistingRegistryKey"));
        }

        [TestMethod]
        public void GetBaseKey_WhenKeyNotFound_ConfirmResult()
        {
            // Arrange
            ShimRegistryKey.OpenRemoteBaseKeyRegistryHiveString = (_, __) => new ShimRegistryKey();
            ShimRegistryKey.AllInstances.OpenSubKeyStringBoolean = (_, name, __) =>
            {
                switch (name)
                {
                    case "Software":
                        return new ShimRegistryKey();
                    default:
                        return null;
                }
            };
            ShimRegistryKey.AllInstances.CreateSubKeyString = (_, __) => new ShimRegistryKey
            {
                NameGet = () => "CreatedRegistryKey"
            };


            // Act
            var result = _testObj.GetBaseKey(DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Name.ShouldBe("CreatedRegistryKey"));
        }

        [TestMethod]
        public void AddServer_OnValidCall_ConfirmResult()
        {
            // Arrange
            var subKeyCreated = false;
            var values = new List<string>();

            ShimRegistryKey.AllInstances.CreateSubKeyString = (_, __) =>
            {
                subKeyCreated = true;
                return new ShimRegistryKey();
            };
            ShimRegistryKey.AllInstances.SetValueStringObject = (_, value, __) =>
            {
                values.Add(value);
            };
            ShimSetupSite.AllInstances.GetBaseKeyString = (_, __) => new ShimRegistryKey();

            // Act
            _testObj.AddServer(DummyString, DummyString, DummyString, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => subKeyCreated.ShouldBeTrue(),
                () => values.Count.ShouldBe(4),
                () => values.ShouldContain("CN"),
                () => values.ShouldContain("PID"),
                () => values.ShouldContain("ConnectionString"),
                () => values.ShouldContain("QMActive"));
        }

        [TestMethod]
        public void AddRegistryEntries_OnValidCall_ConfirmResult()
        {
            // Arrange
            var subKeyCreated = false;
            var values = new List<string>();

            ShimRegistryKey.AllInstances.CreateSubKeyString = (_, __) =>
            {
                subKeyCreated = true;
                return new ShimRegistryKey();
            };
            ShimRegistryKey.AllInstances.SetValueStringObject = (_, value, __) =>
            {
                values.Add(value);
            };
            ShimSetupSite.AllInstances.GetBaseKeyString = (_, __) => new ShimRegistryKey();

            // Act
            _testObj.AddRegistryEntries(DummyString, DummyString, DummyString);

            // Assert
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => subKeyCreated.ShouldBeTrue(),
                () => values.Count.ShouldBe(4),
                () => values.ShouldContain("CN"),
                () => values.ShouldContain("PID"),
                () => values.ShouldContain("ConnectionString"),
                () => values.ShouldContain("QMActive"),
                () => message.ShouldBe("<br>Adding Registry Entries...Success"));
        }

        [TestMethod]
        public void AddRegistryEntries_OnError_LogError()
        {
            // Arrange
            ShimSetupSite.AllInstances.GetBaseKeyString = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            _testObj.AddRegistryEntries(DummyString, DummyString, DummyString);

            // Assert
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            message.ShouldBe($"<br>Adding Registry Entries...Error: {DummyError}");
        }

        [TestMethod]
        public void UpgradeDB_WhenBasePathExists_ConfirmResult()
        {
            // Arrange
            var openDBCalled = false;
            var runDBUpgradeScriptsCalled = false;
            var setVersionInDBCalled = false;
            var dbClosed = false;

            ShimSetupSite.AllInstances.MakeSureBasePathExistsString = (_, __) => true;
            ShimSetupSite.AllInstances.OpenDB = _ => openDBCalled = true;
            ShimSetupSite.AllInstances.RunDBUpgradeScripts = _ => runDBUpgradeScriptsCalled = true;
            ShimSetupSite.AllInstances.SetVersionInDB = _ => setVersionInDBCalled = true;

            ShimDebugger.ConstructorBoolean = (_, __) => { };

            ShimSqlConnection.AllInstances.Close = _ => dbClosed = true;

            _privateObj.SetFieldOrProperty("_CN", new ShimSqlConnection().Instance);
            
            // Act
            _testObj.UpgradeDB(DummyString);

            // Assert
            var errors = (bool)_privateObj.GetFieldOrProperty("_errors");
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => openDBCalled.ShouldBeTrue(),
                () => runDBUpgradeScriptsCalled.ShouldBeTrue(),
                () => setVersionInDBCalled.ShouldBeTrue(),
                () => dbClosed.ShouldBeTrue(),
                () => errors.ShouldBeFalse(),
                () => message.ShouldContain("Checking BasePath"),
                () => message.ShouldContain("...Success"),
                () => message.ShouldContain("<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Opening Database"),
                () => message.ShouldContain("<br><br>Upgrade Successful"));
        }

        [TestMethod]
        public void UpgradeDB_WhenBasePathNotExists_ConfirmResult()
        {
            // Arrange
            ShimSetupSite.AllInstances.MakeSureBasePathExistsString = (_, __) => false;

            // Act
            _testObj.UpgradeDB(DummyString);

            // Assert
            var errors = (bool)_privateObj.GetFieldOrProperty("_errors");
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("Checking BasePath"),
                () => message.ShouldContain("...Error: BasePath registry entry not found."));
        }

        [TestMethod]
        public void Setup_OnValidCall_ConfirmResult()
        {
            // Arrange
            var dataScripts = new DataScript[] { };
            var userInformation = new UserInformation[] { };

            SetupForSetupMethod();

            ShimActivation.ConstructorDebugger = (_, __) => { };

            // Act
            _testObj.Setup(
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                dataScripts,
                DummyString,
                userInformation,
                DummyString);

            // Assert
            var errors = (bool)_privateObj.GetFieldOrProperty("_errors");
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => _checkActivation.ShouldBeTrue(),
                () => _openMasterCalled.ShouldBeTrue(),
                () => _createDBCalled.ShouldBeTrue(),
                () => _runDBScriptsCalled.ShouldBeTrue(),
                () => _addregistryEntriesCalled.ShouldBeTrue(),
                () => _dbClosed.ShouldBeTrue(),
                () => errors.ShouldBeFalse(),
                () => message.ShouldContain("Checking BasePath...Success"),
                () => message.ShouldContain("<br>Checking Activation...Success"));
        }

        [TestMethod]
        public void Setup_WhenActivationError_LogError()
        {
            // Arrange
            var dataScripts = new DataScript[] { };
            var userInformation = new UserInformation[] { };

            SetupForSetupMethod();

            ShimActivation.ConstructorDebugger = (_, __) =>
            {
                throw new PFEException(DummyInt, DummyError);
            };

            // Act
            _testObj.Setup(
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                dataScripts,
                DummyString,
                userInformation,
                DummyString);

            // Assert
            var errors = (bool)_privateObj.GetFieldOrProperty("_errors");
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => _checkActivation.ShouldBeFalse(),
                () => _openMasterCalled.ShouldBeFalse(),
                () => _createDBCalled.ShouldBeFalse(),
                () => _runDBScriptsCalled.ShouldBeFalse(),
                () => _addregistryEntriesCalled.ShouldBeFalse(),
                () => _dbClosed.ShouldBeFalse(),
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("Checking BasePath...Success"),
                () => message.ShouldNotContain("<br>Checking Activation...Success"),
                () => message.ShouldContain($"<br>Checking Activation...Error: {DummyError}"));
        }

        private void SetupForSetupMethod()
        {
            ShimSetupSite.AllInstances.CheckBasePathString = (_, __) => true;
            ShimSetupSite.AllInstances.OpenMasterString = (_, __) => _openMasterCalled = true;
            ShimSetupSite.AllInstances.createDBStringStringStringString = (_, _1, _2, _3, _4) => _createDBCalled = true;
            ShimSetupSite.AllInstances.RunDBScriptsDataScriptArrayStringUserInformationArrayString =
                (_, _1, _2, _3, _4) => _runDBScriptsCalled = true;
            ShimSetupSite.AllInstances.AddRegistryEntriesStringStringString = (_, _1, _2, _3) => _addregistryEntriesCalled = true;

            ShimDebugger.ConstructorBoolean = (_, __) => { };

            ShimActivation.AllInstances.checkActivationStringStringString = (_, _1, _2, _3) => _checkActivation = true;

            ShimSqlConnection.AllInstances.Close = _ => _dbClosed = true;

            _privateObj.SetFieldOrProperty("_CN", new ShimSqlConnection().Instance);
        }

        [TestMethod]
        public void Setup_WhenNotCheckBasePath_LogError()
        {
            // Arrange
            ShimSetupSite.AllInstances.CheckBasePathString = (_, __) => false;

            // Act
            _testObj.Setup(
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                null,
                DummyString,
                null,
                DummyString);

            // Assert
            var errors = (bool)_privateObj.GetFieldOrProperty("_errors");
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("Checking BasePath"),
                () => message.ShouldContain("...Error: BasePath already in use."));
        }

        [TestMethod]
        public void CheckBasePath_WhenKeyExists_ReturnFalse()
        {
            // Arrange
            ShimUtilities.GetRegistryKeyString = _ => new ShimRegistryKey();

            // Act
            var result = _testObj.CheckBasePath(DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void CheckBasePath_WhenKeyNotExists_ReturnTrue()
        {
            // Arrange
            ShimUtilities.GetRegistryKeyString = _ => null;

            // Act
            var result = _testObj.CheckBasePath(DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void CheckBasePath_OnError_ReturnTrue()
        {
            // Arrange
            ShimUtilities.GetRegistryKeyString = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = _testObj.CheckBasePath(DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void MakeSureBasePathExists_WhenBasePathExists_ReturnTrue()
        {
            // Arrange
            ShimUtilities.GetConnectionStringString = _ => DummyString;

            // Act
            var result = _testObj.MakeSureBasePathExists(DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void MakeSureBasePathExists_WhenBasePathNotExists_ReturnFalse()
        {
            // Arrange
            ShimUtilities.GetConnectionStringString = _ => string.Empty;

            // Act
            var result = _testObj.MakeSureBasePathExists(DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void MakeSureBasePathExists_OnError_ReturnFalse()
        {
            // Arrange
            ShimUtilities.GetConnectionStringString = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = _testObj.MakeSureBasePathExists(DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void RenamePermissions_OnValidCall_ConfirmResult()
        {
            // Arrange
            var openDBCalled = false;
            var renamePFEPermissionsCalled = false;

            ShimSetupSite.AllInstances.MakeSureBasePathExistsString = (_, __) => true;
            ShimSetupSite.AllInstances.OpenDB = _ => openDBCalled = true;
            ShimSetupSite.AllInstances.RenamePFEPermissionsDictionaryOfStringString = (_, __) => renamePFEPermissionsCalled = true;

            ShimDebugger.ConstructorBoolean = (_, __) => { };

            ShimSqlConnection.AllInstances.Close = _ => _dbClosed = true;

            _privateObj.SetFieldOrProperty("_CN", new ShimSqlConnection().Instance);

            // Act
            _testObj.RenamePermissions(DummyString, new Dictionary<string, string>());

            // Assert
            var errors = (bool)_privateObj.GetFieldOrProperty("_errors");
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => openDBCalled.ShouldBeTrue(),
                () => renamePFEPermissionsCalled.ShouldBeTrue(),
                () => _dbClosed.ShouldBeTrue(),
                () => errors.ShouldBeFalse(),
                () => message.ShouldContain("Checking BasePath...Success"),
                () => message.ShouldContain("<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Opening Database...Success"),
                () => message.ShouldContain("<br><br>All permissions renamed successfully"));
        }

        [TestMethod]
        public void RenamePermissions_WhenBasePathNotExists_LogError()
        {
            // Arrange
            ShimSetupSite.AllInstances.MakeSureBasePathExistsString = (_, __) => false;

            // Act
            _testObj.RenamePermissions(DummyString, null);

            // Assert
            var errors = (bool)_privateObj.GetFieldOrProperty("_errors");
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("Checking BasePath...Error: BasePath registry entry not found."));
        }

        [TestMethod]
        public void RenamePFEPermissions_OnValidCall_ConfirmResult()
        {
            // Arrange
            var nonQueryExecuted = false;
            var permissions = new Dictionary<string, string>()
            {
                [DummyString] = DummyString
            };
            var sqlCommand = string.Empty;

            _privateObj.SetFieldOrProperty("_CN", new ShimSqlConnection().Instance);

            ShimSqlCommand.ConstructorStringSqlConnection = (instance, command, ___) => 
            {
                instance.CommandText = command;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                nonQueryExecuted = true;
                sqlCommand = instance.CommandText;

                return DummyInt;
            };
            ShimSqlCommand.AllInstances.DisposeBoolean = (_, __) => { };

            // Act
            _privateObj.Invoke(RenamePFEPermissionsMethod, permissions);

            // Assert
            var errors = (bool)_privateObj.GetFieldOrProperty("_errors");
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => nonQueryExecuted.ShouldBeTrue(),
                () => sqlCommand.ShouldBe("UPDATE EPG_GROUPS SET GROUP_NAME = @New WHERE GROUP_NAME = @Old AND GROUP_ENTITY = 1"),
                () => errors.ShouldBeFalse(),
                () => message.ShouldContain("<br>Renaming Permissions"),
                () => message.ShouldContain($"<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Renaming {DummyString} to {DummyString}"),
                () => message.ShouldContain("...Success"));
        }

        [TestMethod]
        public void RenamePFEPermissions_OnError_LogError()
        {
            // Arrange
            var nonQueryExecuted = false;
            var permissions = new Dictionary<string, string>()
            {
                [DummyString] = DummyString
            };

            _privateObj.SetFieldOrProperty("_CN", new ShimSqlConnection().Instance);

            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) =>
            {
                throw new Exception(DummyError);
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                nonQueryExecuted = true;

                return DummyInt;
            };
            ShimSqlCommand.AllInstances.DisposeBoolean = (_, __) => { };

            // Act
            _privateObj.Invoke(RenamePFEPermissionsMethod, permissions);

            // Assert
            var errors = (bool)_privateObj.GetFieldOrProperty("_errors");
            var message = (string)_privateObj.GetFieldOrProperty("_message");
            this.ShouldSatisfyAllConditions(
                () => nonQueryExecuted.ShouldBeFalse(),
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("<br>Renaming Permissions"),
                () => message.ShouldContain($"<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Renaming {DummyString} to {DummyString}"),
                () => message.ShouldContain($"...Error: {DummyError}"));
        }
    }
}

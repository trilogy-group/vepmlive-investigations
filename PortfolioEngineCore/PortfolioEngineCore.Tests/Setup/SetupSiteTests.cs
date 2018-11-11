using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Fakes;
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
        private bool _readerExecuted;
        private bool _dataReaderClosed;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyError = "Dummy Error";

        private const string RenamePFEPermissionsMethod = "RenamePFEPermissions";
        private const string OpenMasterMethod = "OpenMaster";
        private const string CreateDBMethod = "createDB";
        private const string RunDBScriptsMethod = "RunDBScripts";
        private const string OpenDBMethod = "OpenDB";
        private const string RunDBUpgradeScriptsMethod = "RunDBUpgradeScripts";
        private const string RunDBScriptMethod = "RunDBScript";
        private const string GetAssemblyVersionMethod = "GetAssemblyVersion";

        private const string SoftwareKey = "Software";
        private const string Wow6432NodeKey = "Wow6432Node";
        private const string EPMLiveKey = "EPMLive";
        private const string PortfolioEngineKey = "PortfolioEngine";
        private const string CNValue = "CN";
        private const string PIDValue = "PID";
        private const string ConnectionStringValue = "ConnectionString";
        private const string QMActiveValue = "QMActive";
        private const string CNField = "_CN";
        private const string CreateDataBaseError = "CreateDataBaseError";
        private const string CreateUserError = "CreateUserError";

        [TestInitialize]
        public void TestInitialize()
        {
            _checkActivation = false;
            _openMasterCalled = false;
            _createDBCalled = false;
            _runDBScriptsCalled = false;
            _addregistryEntriesCalled = false;
            _dbClosed = false;
            _readerExecuted = false;
            _dataReaderClosed = false;

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
            const string ExistingRegistryKey = "ExistingRegistryKey";

            ShimRegistryKey.OpenRemoteBaseKeyRegistryHiveString = (_, __) => new ShimRegistryKey();
            ShimRegistryKey.AllInstances.OpenSubKeyStringBoolean = (_, name, __) =>
            {
                switch (name)
                {
                    case SoftwareKey:
                    case Wow6432NodeKey:
                    case EPMLiveKey:
                    case PortfolioEngineKey:
                        return new ShimRegistryKey
                        {
                            NameGet = () => ExistingRegistryKey
                        };
                    default:
                        return null;
                }
            };
            
            // Act
            var result = _testObj.GetBaseKey(DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Name.ShouldBe(ExistingRegistryKey));
        }

        [TestMethod]
        public void GetBaseKey_WhenKeyNotFound_ConfirmResult()
        {
            // Arrange
            const string CreatedRegistryKey = "CreatedRegistryKey";

            ShimRegistryKey.OpenRemoteBaseKeyRegistryHiveString = (_, __) => new ShimRegistryKey();
            ShimRegistryKey.AllInstances.OpenSubKeyStringBoolean = (_, name, __) =>
            {
                switch (name)
                {
                    case SoftwareKey:
                        return new ShimRegistryKey();
                    default:
                        return null;
                }
            };
            ShimRegistryKey.AllInstances.CreateSubKeyString = (_, __) => new ShimRegistryKey
            {
                NameGet = () => CreatedRegistryKey
            };

            // Act
            var result = _testObj.GetBaseKey(DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Name.ShouldBe(CreatedRegistryKey));
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
                () => values.ShouldContain(CNValue),
                () => values.ShouldContain(PIDValue),
                () => values.ShouldContain(ConnectionStringValue),
                () => values.ShouldContain(QMActiveValue));
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
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => subKeyCreated.ShouldBeTrue(),
                () => values.Count.ShouldBe(4),
                () => values.ShouldContain(CNValue),
                () => values.ShouldContain(PIDValue),
                () => values.ShouldContain(ConnectionStringValue),
                () => values.ShouldContain(QMActiveValue),
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
            var message = _testObj.SetupMessage;
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

            _privateObj.SetFieldOrProperty(CNField, new ShimSqlConnection().Instance);
            
            // Act
            _testObj.UpgradeDB(DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
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
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
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
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
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
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
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

            _privateObj.SetFieldOrProperty(CNField, new ShimSqlConnection().Instance);
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
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
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

            _privateObj.SetFieldOrProperty(CNField, new ShimSqlConnection().Instance);

            // Act
            _testObj.RenamePermissions(DummyString, new Dictionary<string, string>());

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
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
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
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

            _privateObj.SetFieldOrProperty(CNField, new ShimSqlConnection().Instance);

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
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
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

            _privateObj.SetFieldOrProperty(CNField, new ShimSqlConnection().Instance);

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
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => nonQueryExecuted.ShouldBeFalse(),
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("<br>Renaming Permissions"),
                () => message.ShouldContain($"<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Renaming {DummyString} to {DummyString}"),
                () => message.ShouldContain($"...Error: {DummyError}"));
        }

        [TestMethod]
        public void OpenMaster_OnValidCall_ConfirmResult()
        {
            // Arrange
            var connectionOpened = false;

            ShimSqlConnection.Constructor = _ => { };
            ShimSqlConnection.AllInstances.ConnectionStringSetString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => connectionOpened = true;

            // Act
            _privateObj.Invoke(OpenMasterMethod, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldBeFalse(),
                () => connectionOpened.ShouldBeTrue(),
                () => message.ShouldContain("<br>Opening master Database...Success"));
        }

        [TestMethod]
        public void OpenMaster_OnError_LogError()
        {
            // Arrange
            var connectionOpened = false;

            ShimSqlConnection.Constructor = _ => 
            {
                throw new Exception(DummyError);
            };
            ShimSqlConnection.AllInstances.Open = _ => connectionOpened = true;

            // Act
            _privateObj.Invoke(OpenMasterMethod, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldBeTrue(),
                () => connectionOpened.ShouldBeFalse(),
                () => message.ShouldContain($"<br>Opening master Database...Error: {DummyError}"));
        }

        [TestMethod]
        public void CreateDB_OnValidCall_ConfirmResult()
        {
            // Arrange
            var sqlCommands = new List<string>();
            SetupForCreateDBMethod(sqlCommands, false, true, true, string.Empty, true);

            // Act
            _privateObj.Invoke(CreateDBMethod, DummyString, DummyString, DummyString, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => _readerExecuted.ShouldBeTrue(),
                () => _dataReaderClosed.ShouldBeTrue(),
                () => sqlCommands.ShouldContain($"CREATE DATABASE {DummyString}"),
                () => sqlCommands.ShouldContain($"CREATE LOGIN [{DummyString}] WITH PASSWORD = '{DummyString}', CHECK_POLICY = OFF"),
                () => sqlCommands.ShouldContain($"CREATE USER [{DummyString}] FOR LOGIN [{DummyString}]"),
                () => sqlCommands.ShouldContain($"sp_addrolemember"),
                () => errors.ShouldBeFalse(),
                () => message.ShouldContain("<br>Creating Database...Success"),
                () => message.ShouldContain("<br>Creating Login...Success"),
                () => message.ShouldContain("<br>Granting Permissions To Login...Success"));
        }

        [TestMethod]
        public void CreateDB_WhenDataBaseExists_LogError()
        {
            // Arrange
            var sqlCommands = new List<string>();
            SetupForCreateDBMethod(sqlCommands, true, true, true, string.Empty, true);

            // Act
            _privateObj.Invoke(CreateDBMethod, DummyString, DummyString, DummyString, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => _readerExecuted.ShouldBeTrue(),
                () => _dataReaderClosed.ShouldBeTrue(),
                () => sqlCommands.Count.ShouldBe(0),
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("<br>Creating Database...Error: Database Exists"));
        }

        [TestMethod]
        public void CreateDB_WhenCreateDatabaseError_LogError()
        {
            // Arrange
            var sqlCommands = new List<string>();
            SetupForCreateDBMethod(sqlCommands, false, false, true, string.Empty, true);

            // Act
            _privateObj.Invoke(CreateDBMethod, DummyString, DummyString, DummyString, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => _readerExecuted.ShouldBeTrue(),
                () => _dataReaderClosed.ShouldBeTrue(),
                () => sqlCommands.Count.ShouldBe(0),
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain($"<br>Creating Database...Error: {CreateDataBaseError}"));
        }

        [TestMethod]
        public void CreateDB_WhenCreateLoginErrorUserNameExists_LogError()
        {
            // Arrange
            var sqlCommands = new List<string>();
            var loginErrorMessage = $"The server principal '{DummyString}' already exists";
            SetupForCreateDBMethod(sqlCommands, false, true, false, loginErrorMessage, true);

            // Act
            _privateObj.Invoke(CreateDBMethod, DummyString, DummyString, DummyString, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => _readerExecuted.ShouldBeTrue(),
                () => _dataReaderClosed.ShouldBeTrue(),
                () => sqlCommands.ShouldContain($"CREATE DATABASE {DummyString}"),
                () => sqlCommands.ShouldNotContain($"CREATE LOGIN [{DummyString}] WITH PASSWORD = '{DummyString}', CHECK_POLICY = OFF"),
                () => sqlCommands.ShouldContain($"CREATE USER [{DummyString}] FOR LOGIN [{DummyString}]"),
                () => sqlCommands.ShouldContain($"sp_addrolemember"),
                () => errors.ShouldBeFalse(),
                () => message.ShouldContain("<br>Creating Database...Success"),
                () => message.ShouldContain("<br>Creating Login...Skipping: Username exists"),
                () => message.ShouldContain("<br>Granting Permissions To Login...Success"));
        }

        [TestMethod]
        public void CreateDB_WhenCreateLoginErrorUserNameNotExists_LogError()
        {
            // Arrange
            var sqlCommands = new List<string>();
            SetupForCreateDBMethod(sqlCommands, false, true, false, DummyError, true);

            // Act
            _privateObj.Invoke(CreateDBMethod, DummyString, DummyString, DummyString, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => _readerExecuted.ShouldBeTrue(),
                () => _dataReaderClosed.ShouldBeTrue(),
                () => sqlCommands.Count.ShouldBe(1),
                () => sqlCommands.ShouldContain($"CREATE DATABASE {DummyString}"),
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("<br>Creating Database...Success"),
                () => message.ShouldContain($"<br>Creating Login...Error: {DummyError}"));
        }

        [TestMethod]
        public void CreateDB_WhenCreateUserError_LogError()
        {
            // Arrange
            var sqlCommands = new List<string>();
            SetupForCreateDBMethod(sqlCommands, false, true, true, string.Empty, false);

            // Act
            _privateObj.Invoke(CreateDBMethod, DummyString, DummyString, DummyString, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => _readerExecuted.ShouldBeTrue(),
                () => _dataReaderClosed.ShouldBeTrue(),
                () => sqlCommands.Count.ShouldBe(2),
                () => sqlCommands.ShouldContain($"CREATE DATABASE {DummyString}"),
                () => sqlCommands.ShouldContain($"CREATE LOGIN [{DummyString}] WITH PASSWORD = '{DummyString}', CHECK_POLICY = OFF"),
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("<br>Creating Database...Success"),
                () => message.ShouldContain($"<br>Creating Login...Success"),
                () => message.ShouldContain($"<br>Granting Permissions To Login...Error: {CreateUserError}"));
        }

        [TestMethod]
        public void CreateDB_WhenConnectionIsNotOpen_LogError()
        {
            // Arrange, Act
            _privateObj.Invoke(CreateDBMethod, DummyString, DummyString, DummyString, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain("<br>Error: master Database not open"));
        }

        private void SetupForCreateDBMethod(
            List<string> sqlCommands, 
            bool read, 
            bool createDatabase, 
            bool createLogin, 
            string loginErrorMessage, 
            bool createUser)
        {
            _privateObj.SetFieldOrProperty(CNField, new ShimSqlConnection().Instance);

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.ConnectionStringSetString = (_, __) => { };

            ShimSqlCommand.ConstructorStringSqlConnection = (instance, sqlCommand, ___) =>
            {
                instance.CommandText = sqlCommand;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                _readerExecuted = true;

                return new ShimSqlDataReader
                {
                    Read = () => read,
                    Close = () => _dataReaderClosed = true
                };
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.CommandText.Contains("CREATE DATABASE"))
                {
                    if (!createDatabase)
                    {
                        throw new Exception(CreateDataBaseError);
                    }
                }

                if (instance.CommandText.Contains("CREATE LOGIN"))
                {
                    if (!createLogin)
                    {
                        throw new Exception(loginErrorMessage);
                    }
                }

                if (instance.CommandText.Contains("CREATE USER"))
                {
                    if (!createUser)
                    {
                        throw new Exception(CreateUserError);
                    }
                }

                sqlCommands.Add(instance.CommandText);

                return DummyInt;
            };
        }

        [TestMethod]
        public void RunDBScripts_OnValidCall_ConfirmResult()
        {
            // Arrange
            var scriptList = new List<string>();
            var script = new ShimDataScript().Instance;
            var privateScript = new PrivateObject(script);

            privateScript.SetFieldOrProperty("ScriptName", "DummyScript");

            var dataScripts = new DataScript[] { script };
            var userInformation = new UserInformation[] { new ShimUserInformation() };

            ShimSetupSite.AllInstances.RunDBScriptStringString = (_, scriptName, ___) =>
            {
                scriptList.Add(scriptName);
            };

            // Act
            _privateObj.Invoke(RunDBScriptsMethod, dataScripts, DummyString, userInformation, DummyString);

            // Assert
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => message.ShouldContain("<br>Running Scripts"),
                () => scriptList.ShouldContain("01_CRTTBLS"),
                () => scriptList.ShouldContain("02_CRTINDS"),
                () => scriptList.ShouldContain("04_CRTSPS"),
                () => scriptList.ShouldContain("05_CRTVWS"),
                () => scriptList.ShouldContain("07_DATA"),
                () => scriptList.ShouldContain("DummyScript"),
                () => scriptList.ShouldContain("99_FixSvcAcct"),
                () => scriptList.ShouldContain("100_ADDADMIN"),
                () => scriptList.ShouldContain("100_ADDADMINGRP"),
                () => scriptList.ShouldContain("UPDATEURL"));
        }

        [TestMethod]
        public void OpenDB_OnValidCall_ConfirmResult()
        {
            // Arrange
            var connectionOpened = false;

            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => connectionOpened = true;

            // Act
            _privateObj.Invoke(OpenDBMethod);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => connectionOpened.ShouldBeTrue(),
                () => errors.ShouldBeFalse(),
                () => message.ShouldBeNullOrWhiteSpace());
        }

        [TestMethod]
        public void OpenDB_OnError_LogError()
        {
            // Arrange
            var connectionOpened = false;

            ShimSqlConnection.ConstructorString = (_, __) =>
            {
                throw new Exception(DummyError);
            };
            ShimSqlConnection.AllInstances.Open = _ => connectionOpened = true;

            // Act
            _privateObj.Invoke(OpenDBMethod);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => connectionOpened.ShouldBeFalse(),
                () => errors.ShouldBeTrue(),
                () => message.ShouldContain($"...Error: {DummyError}"));
        }

        [TestMethod]
        public void RunDBUpgradeScripts_OnValidCall_ConfirmResult()
        {
            // Arrange
            var scriptList = new List<string>();

            ShimSetupSite.AllInstances.RunDBScriptStringString = (_, scriptName, ___) =>
            {
                scriptList.Add(scriptName);
            };

            // Act
            _privateObj.Invoke(RunDBUpgradeScriptsMethod);

            // Assert
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => message.ShouldContain("<br>Running Scripts"),
                () => scriptList.ShouldContain("01_CRTTBLS"),
                () => scriptList.ShouldContain("02_CRTINDS"),
                () => scriptList.ShouldContain("04_CRTSPS"),
                () => scriptList.ShouldContain("05_CRTVWS"),
                () => scriptList.ShouldContain("07_DATA"));
        }

        [TestMethod]
        public void RunDBScript_OnValidCall_ConfirmResult()
        {
            // Arrange
            var nonQueryExecuted = false;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => { };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                nonQueryExecuted = true;

                return DummyInt;
            };

            // Act
            _privateObj.Invoke(RunDBScriptMethod, DummyString, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldBeFalse(),
                () => message.ShouldBe($"<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Running Script: {DummyString}...Success"),
                () => nonQueryExecuted.ShouldBeTrue());
        }

        [TestMethod]
        public void RunDBScript_OnError_LogError()
        {
            // Arrange
            var nonQueryExecuted = false;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => 
            {
                throw new Exception(DummyError);
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                nonQueryExecuted = true;

                return DummyInt;
            };

            // Act
            _privateObj.Invoke(RunDBScriptMethod, DummyString, DummyString);

            // Assert
            var errors = _testObj.SetupErrors;
            var message = _testObj.SetupMessage;
            this.ShouldSatisfyAllConditions(
                () => errors.ShouldBeTrue(),
                () => message.ShouldBe($"<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Running Script: {DummyString}...Error: {DummyError}"),
                () => nonQueryExecuted.ShouldBeFalse());
        }

        [TestMethod]
        public void GetAssemblyVersion_OnValidCall_ReturnAssemblyVersion()
        {
            // Arrange
            ShimFileVersionInfo.GetVersionInfoString = _ => new ShimFileVersionInfo
            {
                ProductMajorPartGet = () => DummyInt,
                ProductMinorPartGet = () => DummyInt,
                ProductBuildPartGet = () => DummyInt,
                ProductPrivatePartGet = () => DummyInt
            };

            // Act
            var result = (string)_privateObj.Invoke(GetAssemblyVersionMethod);

            // Assert
            result.ShouldBe($"{DummyInt}.{DummyInt}.{DummyInt}.{DummyInt}");
        }

        [TestMethod]
        public void GetAssemblyVersion_OnValidCall_ReturnEmptyString()
        {
            // Arrange
            ShimFileVersionInfo.GetVersionInfoString = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = (string)_privateObj.Invoke(GetAssemblyVersionMethod);

            // Assert
            result.ShouldBeNullOrWhiteSpace();
        }
    }
}

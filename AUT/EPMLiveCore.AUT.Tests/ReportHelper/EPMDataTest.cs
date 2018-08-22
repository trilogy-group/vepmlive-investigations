using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.ReportHelper
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportHelper.EPMData" />)
    ///     and namespace <see cref="EPMLiveCore.ReportHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class EPMDataTest : AbstractBaseSetupTypedTest<EPMData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMData) Initializer

        private const string PropertyUserName = "UserName";
        private const string PropertyPassword = "Password";
        private const string PropertyUseSqlAccount = "UseSqlAccount";
        private const string PropertySiteId = "SiteId";
        private const string PropertyCommand = "Command";
        private const string PropertyEPMLiveConOpen = "EPMLiveConOpen";
        private const string PropertyCommandType = "CommandType";
        private const string PropertyParams = "Params";
        private const string PropertySqlError = "SqlError";
        private const string PropertySqlErrorOccurred = "SqlErrorOccurred";
        private const string PropertySiteName = "SiteName";
        private const string PropertySiteUrl = "SiteUrl";
        private const string PropertyGetEPMLiveConnection = "GetEPMLiveConnection";
        private const string PropertyGetClientReportingConnection = "GetClientReportingConnection";
        private const string PropertyGetMasterDbConnection = "GetMasterDbConnection";
        private const string PropertyOpenEPMLiveConnection = "OpenEPMLiveConnection";
        private const string PropertyOpenClientReportingConnection = "OpenClientReportingConnection";
        private const string PropertyOpenMasterDbConnection = "OpenMasterDbConnection";
        private const string PropertyremoteCs = "remoteCs";
        private const string PropertymasterCs = "masterCs";
        private const string PropertyremoteDbName = "remoteDbName";
        private const string PropertyremoteServerName = "remoteServerName";
        private const string MethodCreateEventMessage = "CreateEventMessage";
        private const string MethodCreateEventMessageWithParams = "CreateEventMessageWithParams";
        private const string MethodLogWindowsEvents = "LogWindowsEvents";
        private const string MethodDispose = "Dispose";
        private const string MethodDefaultLists = "DefaultLists";
        private const string MethodCreateTextFile = "CreateTextFile";
        private const string MethodWriteToFile = "WriteToFile";
        private const string MethodWriteTextFile = "WriteTextFile";
        private const string MethodDeleteWork = "DeleteWork";
        private const string MethodMapLists = "MapLists";
        private const string MethodMapDefaultLists = "MapDefaultLists";
        private const string MethodSetListIcon = "SetListIcon";
        private const string MethodGetListFields = "GetListFields";
        private const string MethodDeleteExistingTSData = "DeleteExistingTSData";
        private const string MethodRefreshDefaultLists = "RefreshDefaultLists";
        private const string MethodGetDefaultLists = "GetDefaultLists";
        private const string MethodAddParam = "AddParam";
        private const string MethodCheckConnection = "CheckConnection";
        private const string MethodTryToConnect = "TryToConnect";
        private const string MethodExecuteScalar = "ExecuteScalar";
        private const string MethodExecuteNonQuery = "ExecuteNonQuery";
        private const string MethodGetRow = "GetRow";
        private const string MethodGetTable = "GetTable";
        private const string MethodGetSite = "GetSite";
        private const string MethodPopulateInstanceFromData = "PopulateInstanceFromData";
        private const string MethodPopulateConnectionStrings = "PopulateConnectionStrings";
        private const string MethodSAccountInfo = "SAccountInfo";
        private const string MethodGetCalculatedFieldValue = "GetCalculatedFieldValue";
        private const string MethodGetSnapshotQueueStatus = "GetSnapshotQueueStatus";
        private const string MethodGetCleanupQueueStatus = "GetCleanupQueueStatus";
        private const string MethodBulkInsert = "BulkInsert";
        private const string MethodGetAllListIDs = "GetAllListIDs";
        private const string MethodGetListNames = "GetListNames";
        private const string MethodGetListEvents = "GetListEvents";
        private const string MethodLogStatus = "LogStatus";
        private const string MethodInitializeStatusLog = "InitializeStatusLog";
        private const string MethodLogRefreshStatus = "LogRefreshStatus";
        private const string MethodGetSnapshotResults = "GetSnapshotResults";
        private const string MethodSnapshotLists = "SnapshotLists";
        private const string MethodGetStatusLog = "GetStatusLog";
        private const string MethodGetSpecificReportingDbConnection = "GetSpecificReportingDbConnection";
        private const string MethodDeleteAllItemsDB = "DeleteAllItemsDB";
        private const string MethodGetTableNames = "GetTableNames";
        private const string MethodTableExists = "TableExists";
        private const string MethodGetSafeTableName = "GetSafeTableName";
        private const string MethodGetTableCount = "GetTableCount";
        private const string MethodUpdateListName = "UpdateListName";
        private const string MethodGetListId = "GetListId";
        private const string MethodGetTableName = "GetTableName";
        private const string MethodGetListName = "GetListName";
        private const string MethodRefreshTimesheets = "RefreshTimesheets";
        private const string MethodSaveWork = "SaveWork";
        private const string MethodProcessAssignments = "ProcessAssignments";
        private const string MethodGetDbVersion = "GetDbVersion";
        private const string MethodMapDataBase = "MapDataBase";
        private const string MethodGrantUserDbAccess = "GrantUserDbAccess";
        private const string MethodListMappedAlready = "ListMappedAlready";
        private const string MethodUpdateRPTSettings = "UpdateRPTSettings";
        private const string MethodEncrypt = "Encrypt";
        private const string MethodDecrypt = "Decrypt";
        private const string MethodItemHasValue = "ItemHasValue";
        private const string Field_siteID = "_siteID";
        private const string Field_webAppId = "_webAppId";
        private const string Field_webId = "_webId";
        private const string FieldRetentionDays = "RetentionDays";
        private const string FieldMaxKilobytes = "MaxKilobytes";
        private const string FieldOpenEpmLiveConnectionEvent = "OpenEpmLiveConnectionEvent";
        private const string FieldGetMasterDbConnectionEvent = "GetMasterDbConnectionEvent";
        private const string FieldOpenMasterDbConnectionEvent = "OpenMasterDbConnectionEvent";
        private const string FieldGetEpmLiveConnectionEvent = "GetEpmLiveConnectionEvent";
        private const string FieldExecuteScalarEvent = "ExecuteScalarEvent";
        private const string FieldUpdateForeignKeyEvent = "UpdateForeignKeyEvent";
        private const string FieldDotDelimiter = "DotDelimiter";
        private const string FieldEpmLiveKey = "EpmLiveKey";
        private const string FieldEpmLiveReportingKey = "EpmLiveReportingKey";
        private const string FieldExecuteScalarKey = "ExecuteScalarKey";
        private const string FieldExecuteNonQueryKey = "ExecuteNonQueryKey";
        private const string FieldGetTableKey = "GetTableKey";
        private const string FieldGetClientReportingConnectionKey = "GetClientReportingConnectionKey";
        private const string FieldGetClientReportingConnectionSiteIdKey = "GetClientReportingConnectionSiteIdKey";
        private const string FieldGetEpmLiveConnectionKey = "GetEpmLiveConnectionKey";
        private const string FieldGetMasterDbConnectionKey = "GetMasterDbConnectionKey";
        private const string FieldOpenEpmLiveConnectionKey = "OpenEpmLiveConnectionKey";
        private const string FieldOpenClientReportingConnectionKey = "OpenClientReportingConnectionKey";
        private const string FieldOpenMasterDbConnectionKey = "OpenMasterDbConnectionKey";
        private const string FieldUpdateForeignKeysKey = "UpdateForeignKeysKey";
        private const string Field_DefaultLists = "_DefaultLists";
        private const string Field_command = "_command";
        private const string Field_commandType = "_commandType";
        private const string Field_conClientReporting = "_conClientReporting";
        private const string Field_conEPMLive = "_conEPMLive";
        private const string Field_conMaster = "_conMaster";
        private const string Field_databaseName = "_databaseName";
        private const string Field_databaseServer = "_databaseServer";
        private const string Field_dtStatusLog = "_dtStatusLog";
        private const string Field_epmLiveConOpen = "_epmLiveConOpen";
        private const string Field_masterCs = "_masterCs";
        private const string Field_params = "_params";
        private const string Field_password = "_password";
        private const string Field_remoteCs = "_remoteCs";
        private const string Field_sTextFilePath = "_sTextFilePath";
        private const string Field_siteName = "_siteName";
        private const string Field_siteUrl = "_siteUrl";
        private const string Field_sqlError = "_sqlError";
        private const string Field_sqlErrorOccurred = "_sqlErrorOccurred";
        private const string Field_useSAccount = "_useSAccount";
        private const string Field_username = "_username";
        private Type _ePMDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMData _ePMDataInstance;
        private EPMData _ePMDataInstanceFixture;

        #region General Initializer : Class (EPMData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMDataInstanceType = typeof(EPMData);
            _ePMDataInstanceFixture = Create(true);
            _ePMDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMData)

        #region General Initializer : Class (EPMData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodDefaultLists, 0)]
        [TestCase(MethodDefaultLists, 1)]
        [TestCase(MethodCreateTextFile, 0)]
        [TestCase(MethodWriteToFile, 0)]
        [TestCase(MethodDeleteWork, 0)]
        [TestCase(MethodMapLists, 0)]
        [TestCase(MethodMapDefaultLists, 0)]
        [TestCase(MethodSetListIcon, 0)]
        [TestCase(MethodGetListFields, 0)]
        [TestCase(MethodDeleteExistingTSData, 0)]
        [TestCase(MethodRefreshDefaultLists, 0)]
        [TestCase(MethodGetDefaultLists, 0)]
        [TestCase(MethodAddParam, 0)]
        [TestCase(MethodCheckConnection, 0)]
        [TestCase(MethodExecuteScalar, 0)]
        [TestCase(MethodExecuteNonQuery, 0)]
        [TestCase(MethodExecuteNonQuery, 1)]
        [TestCase(MethodGetRow, 0)]
        [TestCase(MethodGetTable, 0)]
        [TestCase(MethodGetTable, 1)]
        [TestCase(MethodGetSite, 0)]
        [TestCase(MethodPopulateInstanceFromData, 0)]
        [TestCase(MethodPopulateConnectionStrings, 0)]
        [TestCase(MethodSAccountInfo, 0)]
        [TestCase(MethodSAccountInfo, 1)]
        [TestCase(MethodGetTable, 2)]
        [TestCase(MethodGetCalculatedFieldValue, 0)]
        [TestCase(MethodGetSnapshotQueueStatus, 0)]
        [TestCase(MethodGetCleanupQueueStatus, 0)]
        [TestCase(MethodBulkInsert, 0)]
        [TestCase(MethodBulkInsert, 1)]
        [TestCase(MethodGetAllListIDs, 0)]
        [TestCase(MethodGetListNames, 0)]
        [TestCase(MethodGetListEvents, 0)]
        [TestCase(MethodLogStatus, 0)]
        [TestCase(MethodInitializeStatusLog, 0)]
        [TestCase(MethodInitializeStatusLog, 1)]
        [TestCase(MethodLogRefreshStatus, 0)]
        [TestCase(MethodGetSnapshotResults, 0)]
        [TestCase(MethodSnapshotLists, 0)]
        [TestCase(MethodGetStatusLog, 0)]
        [TestCase(MethodGetSpecificReportingDbConnection, 0)]
        [TestCase(MethodDeleteAllItemsDB, 0)]
        [TestCase(MethodGetTableNames, 0)]
        [TestCase(MethodTableExists, 0)]
        [TestCase(MethodGetSafeTableName, 0)]
        [TestCase(MethodGetTableCount, 0)]
        [TestCase(MethodUpdateListName, 0)]
        [TestCase(MethodGetListId, 0)]
        [TestCase(MethodGetListId, 1)]
        [TestCase(MethodGetTableName, 0)]
        [TestCase(MethodGetTableName, 1)]
        [TestCase(MethodGetListName, 0)]
        [TestCase(MethodRefreshTimesheets, 0)]
        [TestCase(MethodSaveWork, 0)]
        [TestCase(MethodProcessAssignments, 0)]
        [TestCase(MethodGetDbVersion, 0)]
        [TestCase(MethodMapDataBase, 0)]
        [TestCase(MethodGrantUserDbAccess, 0)]
        [TestCase(MethodListMappedAlready, 0)]
        [TestCase(MethodListMappedAlready, 1)]
        [TestCase(MethodUpdateRPTSettings, 0)]
        [TestCase(MethodEncrypt, 0)]
        [TestCase(MethodDecrypt, 0)]
        [TestCase(MethodItemHasValue, 0)]
        public void AUT_EPMData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMData) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMData" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyUserName)]
        [TestCase(PropertyPassword)]
        [TestCase(PropertyUseSqlAccount)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertyCommand)]
        [TestCase(PropertyEPMLiveConOpen)]
        [TestCase(PropertyCommandType)]
        [TestCase(PropertyParams)]
        [TestCase(PropertySqlError)]
        [TestCase(PropertySqlErrorOccurred)]
        [TestCase(PropertySiteName)]
        [TestCase(PropertySiteUrl)]
        [TestCase(PropertyGetEPMLiveConnection)]
        [TestCase(PropertyGetClientReportingConnection)]
        [TestCase(PropertyGetMasterDbConnection)]
        [TestCase(PropertyOpenEPMLiveConnection)]
        [TestCase(PropertyOpenClientReportingConnection)]
        [TestCase(PropertyOpenMasterDbConnection)]
        [TestCase(PropertyremoteCs)]
        [TestCase(PropertymasterCs)]
        [TestCase(PropertyremoteDbName)]
        [TestCase(PropertyremoteServerName)]
        public void AUT_EPMData_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ePMDataInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPMData) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="EPMData" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_EPMData_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<EPMData>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<EPMData>(Fixture);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var siteID = CreateType<Guid>();
            object[] parametersOfEPMData = { siteID };
            var methodEPMDataPrametersTypes = new Type[] { typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_ePMDataInstanceType, methodEPMDataPrametersTypes, parametersOfEPMData);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodEPMDataPrametersTypes = new Type[] { typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_ePMDataInstanceType, Fixture, methodEPMDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var tmp = CreateType<bool>();
            var siteID = CreateType<Guid>();
            var webId = CreateType<Guid>();
            object[] parametersOfEPMData = { tmp, siteID, webId };
            var methodEPMDataPrametersTypes = new Type[] { typeof(bool), typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_ePMDataInstanceType, methodEPMDataPrametersTypes, parametersOfEPMData);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodEPMDataPrametersTypes = new Type[] { typeof(bool), typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_ePMDataInstanceType, Fixture, methodEPMDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var siteID = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            object[] parametersOfEPMData = { siteID, webAppId };
            var methodEPMDataPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_ePMDataInstanceType, methodEPMDataPrametersTypes, parametersOfEPMData);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodEPMDataPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_ePMDataInstanceType, Fixture, methodEPMDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var siteID = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            var deleteDb = CreateType<bool>();
            object[] parametersOfEPMData = { siteID, webAppId, deleteDb };
            var methodEPMDataPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_ePMDataInstanceType, methodEPMDataPrametersTypes, parametersOfEPMData);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodEPMDataPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_ePMDataInstanceType, Fixture, methodEPMDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var siteID = CreateType<Guid>();
            var sDbName = CreateType<string>();
            var sServerName = CreateType<string>();
            var useSAccount = CreateType<bool>();
            var username = CreateType<string>();
            var password = CreateType<string>();
            object[] parametersOfEPMData = { siteID, sDbName, sServerName, useSAccount, username, password };
            var methodEPMDataPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_ePMDataInstanceType, methodEPMDataPrametersTypes, parametersOfEPMData);
        }

        #endregion

        #region General Constructor : Class (EPMData) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMData_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodEPMDataPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_ePMDataInstanceType, Fixture, methodEPMDataPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EPMData) => Property (Command) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_Command_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCommand);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (CommandType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_CommandType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCommandType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (EPMLiveConOpen) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_EPMLiveConOpen_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEPMLiveConOpen);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (GetClientReportingConnection) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_GetClientReportingConnection_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyGetClientReportingConnection);
            Action currentAction = () => propertyInfo.SetValue(_ePMDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (GetClientReportingConnection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_GetClientReportingConnection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGetClientReportingConnection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (GetEPMLiveConnection) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_GetEPMLiveConnection_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyGetEPMLiveConnection);
            Action currentAction = () => propertyInfo.SetValue(_ePMDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (GetEPMLiveConnection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_GetEPMLiveConnection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGetEPMLiveConnection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (GetMasterDbConnection) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_GetMasterDbConnection_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyGetMasterDbConnection);
            Action currentAction = () => propertyInfo.SetValue(_ePMDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (GetMasterDbConnection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_GetMasterDbConnection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGetMasterDbConnection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (masterCs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_masterCs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymasterCs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (Params) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_Params_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParams);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (Password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_Password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (remoteCs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_remoteCs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyremoteCs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (remoteDbName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_remoteDbName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyremoteDbName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (remoteServerName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_remoteServerName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyremoteServerName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (SiteId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_SiteId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySiteId);
            Action currentAction = () => propertyInfo.SetValue(_ePMDataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySiteId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (SiteName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_SiteName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySiteName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (SiteUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_SiteUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySiteUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (SqlError) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_SqlError_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySqlError);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (SqlErrorOccurred) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_SqlErrorOccurred_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySqlErrorOccurred);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (UserName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_UserName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMData) => Property (UseSqlAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMData_Public_Class_UseSqlAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUseSqlAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EPMData" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCheckConnection)]
        [TestCase(MethodSAccountInfo)]
        [TestCase(MethodGetTable)]
        [TestCase(MethodEncrypt)]
        [TestCase(MethodDecrypt)]
        public void AUT_EPMData_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_ePMDataInstanceFixture,
                                                                              _ePMDataInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EPMData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateEventMessage)]
        [TestCase(MethodCreateEventMessageWithParams)]
        [TestCase(MethodLogWindowsEvents)]
        [TestCase(MethodDispose)]
        [TestCase(MethodDefaultLists)]
        [TestCase(MethodCreateTextFile)]
        [TestCase(MethodWriteToFile)]
        [TestCase(MethodWriteTextFile)]
        [TestCase(MethodDeleteWork)]
        [TestCase(MethodMapLists)]
        [TestCase(MethodMapDefaultLists)]
        [TestCase(MethodSetListIcon)]
        [TestCase(MethodGetListFields)]
        [TestCase(MethodDeleteExistingTSData)]
        [TestCase(MethodRefreshDefaultLists)]
        [TestCase(MethodGetDefaultLists)]
        [TestCase(MethodAddParam)]
        [TestCase(MethodExecuteScalar)]
        [TestCase(MethodExecuteNonQuery)]
        [TestCase(MethodGetRow)]
        [TestCase(MethodGetTable)]
        [TestCase(MethodGetSite)]
        [TestCase(MethodPopulateInstanceFromData)]
        [TestCase(MethodPopulateConnectionStrings)]
        [TestCase(MethodSAccountInfo)]
        [TestCase(MethodGetCalculatedFieldValue)]
        [TestCase(MethodGetSnapshotQueueStatus)]
        [TestCase(MethodGetCleanupQueueStatus)]
        [TestCase(MethodBulkInsert)]
        [TestCase(MethodGetAllListIDs)]
        [TestCase(MethodGetListNames)]
        [TestCase(MethodGetListEvents)]
        [TestCase(MethodLogStatus)]
        [TestCase(MethodInitializeStatusLog)]
        [TestCase(MethodLogRefreshStatus)]
        [TestCase(MethodGetSnapshotResults)]
        [TestCase(MethodSnapshotLists)]
        [TestCase(MethodGetStatusLog)]
        [TestCase(MethodGetSpecificReportingDbConnection)]
        [TestCase(MethodDeleteAllItemsDB)]
        [TestCase(MethodGetTableNames)]
        [TestCase(MethodTableExists)]
        [TestCase(MethodGetSafeTableName)]
        [TestCase(MethodGetTableCount)]
        [TestCase(MethodUpdateListName)]
        [TestCase(MethodGetListId)]
        [TestCase(MethodGetTableName)]
        [TestCase(MethodGetListName)]
        [TestCase(MethodRefreshTimesheets)]
        [TestCase(MethodSaveWork)]
        [TestCase(MethodProcessAssignments)]
        [TestCase(MethodGetDbVersion)]
        [TestCase(MethodMapDataBase)]
        [TestCase(MethodGrantUserDbAccess)]
        [TestCase(MethodListMappedAlready)]
        [TestCase(MethodUpdateRPTSettings)]
        [TestCase(MethodItemHasValue)]
        public void AUT_EPMData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateEventMessage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_CreateEventMessage_Method_Call_Internally(Type[] types)
        {
            var methodCreateEventMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodCreateEventMessage, Fixture, methodCreateEventMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateEventMessage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateEventMessage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var methodCreateEventMessagePrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfCreateEventMessage = { exception };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodCreateEventMessage, parametersOfCreateEventMessage, methodCreateEventMessagePrametersTypes);

            // Assert
            parametersOfCreateEventMessage.ShouldNotBeNull();
            parametersOfCreateEventMessage.Length.ShouldBe(1);
            methodCreateEventMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateEventMessage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateEventMessage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateEventMessagePrametersTypes = new Type[] { typeof(Exception) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodCreateEventMessage, Fixture, methodCreateEventMessagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateEventMessagePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateEventMessage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateEventMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateEventMessagePrametersTypes = new Type[] { typeof(Exception) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodCreateEventMessage, Fixture, methodCreateEventMessagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateEventMessagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateEventMessageWithParams) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_CreateEventMessageWithParams_Method_Call_Internally(Type[] types)
        {
            var methodCreateEventMessageWithParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodCreateEventMessageWithParams, Fixture, methodCreateEventMessageWithParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateEventMessageWithParams) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateEventMessageWithParams_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var command = CreateType<string>();
            var parameters = CreateType<IEnumerable<SqlParameter>>();
            var methodCreateEventMessageWithParamsPrametersTypes = new Type[] { typeof(Exception), typeof(string), typeof(IEnumerable<SqlParameter>) };
            object[] parametersOfCreateEventMessageWithParams = { exception, command, parameters };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodCreateEventMessageWithParams, parametersOfCreateEventMessageWithParams, methodCreateEventMessageWithParamsPrametersTypes);

            // Assert
            parametersOfCreateEventMessageWithParams.ShouldNotBeNull();
            parametersOfCreateEventMessageWithParams.Length.ShouldBe(3);
            methodCreateEventMessageWithParamsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateEventMessageWithParams) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateEventMessageWithParams_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateEventMessageWithParamsPrametersTypes = new Type[] { typeof(Exception), typeof(string), typeof(IEnumerable<SqlParameter>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodCreateEventMessageWithParams, Fixture, methodCreateEventMessageWithParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateEventMessageWithParamsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CreateEventMessageWithParams) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateEventMessageWithParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateEventMessageWithParamsPrametersTypes = new Type[] { typeof(Exception), typeof(string), typeof(IEnumerable<SqlParameter>) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodCreateEventMessageWithParams, Fixture, methodCreateEventMessageWithParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateEventMessageWithParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogWindowsEvents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_LogWindowsEvents_Method_Call_Internally(Type[] types)
        {
            var methodLogWindowsEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodLogWindowsEvents, Fixture, methodLogWindowsEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (LogWindowsEvents) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogWindowsEvents_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var logName = CreateType<string>();
            var source = CreateType<string>();
            var eventMessage = CreateType<string>();
            var modifyOverflowPolicy = CreateType<bool>();
            var eventId = CreateType<int>();
            var methodLogWindowsEventsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(bool), typeof(int) };
            object[] parametersOfLogWindowsEvents = { logName, source, eventMessage, modifyOverflowPolicy, eventId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodLogWindowsEvents, parametersOfLogWindowsEvents, methodLogWindowsEventsPrametersTypes);

            // Assert
            parametersOfLogWindowsEvents.ShouldNotBeNull();
            parametersOfLogWindowsEvents.Length.ShouldBe(5);
            methodLogWindowsEventsPrametersTypes.Length.ShouldBe(5);
            methodLogWindowsEventsPrametersTypes.Length.ShouldBe(parametersOfLogWindowsEvents.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogWindowsEvents) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogWindowsEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogWindowsEventsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(bool), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodLogWindowsEvents, Fixture, methodLogWindowsEventsPrametersTypes);

            // Assert
            methodLogWindowsEventsPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Dispose_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.Dispose();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Dispose_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Dispose_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Dispose_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_DefaultLists_Method_Call_Internally(Type[] types)
        {
            var methodDefaultListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDefaultLists, Fixture, methodDefaultListsPrametersTypes);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var rootWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.DefaultLists(rootWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var rootWeb = CreateType<SPWeb>();
            var methodDefaultListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfDefaultLists = { rootWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDefaultLists, methodDefaultListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, string>(_ePMDataInstanceFixture, out exception1, parametersOfDefaultLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodDefaultLists, parametersOfDefaultLists, methodDefaultListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDefaultLists.ShouldNotBeNull();
            parametersOfDefaultLists.Length.ShouldBe(1);
            methodDefaultListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rootWeb = CreateType<SPWeb>();
            var methodDefaultListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfDefaultLists = { rootWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodDefaultLists, parametersOfDefaultLists, methodDefaultListsPrametersTypes);

            // Assert
            parametersOfDefaultLists.ShouldNotBeNull();
            parametersOfDefaultLists.Length.ShouldBe(1);
            methodDefaultListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDefaultListsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDefaultLists, Fixture, methodDefaultListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDefaultListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDefaultListsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDefaultLists, Fixture, methodDefaultListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDefaultListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDefaultLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDefaultLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_DefaultLists_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDefaultListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDefaultLists, Fixture, methodDefaultListsPrametersTypes);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.DefaultLists();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodDefaultListsPrametersTypes = null;
            object[] parametersOfDefaultLists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDefaultLists, methodDefaultListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, string>(_ePMDataInstanceFixture, out exception1, parametersOfDefaultLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodDefaultLists, parametersOfDefaultLists, methodDefaultListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDefaultLists.ShouldBeNull();
            methodDefaultListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDefaultListsPrametersTypes = null;
            object[] parametersOfDefaultLists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodDefaultLists, parametersOfDefaultLists, methodDefaultListsPrametersTypes);

            // Assert
            parametersOfDefaultLists.ShouldBeNull();
            methodDefaultListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodDefaultListsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDefaultLists, Fixture, methodDefaultListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDefaultListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDefaultListsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDefaultLists, Fixture, methodDefaultListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDefaultListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DefaultLists) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DefaultLists_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDefaultLists, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_CreateTextFile_Method_Call_Internally(Type[] types)
        {
            var methodCreateTextFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodCreateTextFile, Fixture, methodCreateTextFilePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateTextFile_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sPath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.CreateTextFile(sPath);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateTextFile_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sPath = CreateType<string>();
            var methodCreateTextFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateTextFile = { sPath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateTextFile, methodCreateTextFilePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfCreateTextFile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateTextFile.ShouldNotBeNull();
            parametersOfCreateTextFile.Length.ShouldBe(1);
            methodCreateTextFilePrametersTypes.Length.ShouldBe(1);
            methodCreateTextFilePrametersTypes.Length.ShouldBe(parametersOfCreateTextFile.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateTextFile_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sPath = CreateType<string>();
            var methodCreateTextFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateTextFile = { sPath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodCreateTextFile, parametersOfCreateTextFile, methodCreateTextFilePrametersTypes);

            // Assert
            parametersOfCreateTextFile.ShouldNotBeNull();
            parametersOfCreateTextFile.Length.ShouldBe(1);
            methodCreateTextFilePrametersTypes.Length.ShouldBe(1);
            methodCreateTextFilePrametersTypes.Length.ShouldBe(parametersOfCreateTextFile.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateTextFile_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateTextFile, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateTextFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateTextFilePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodCreateTextFile, Fixture, methodCreateTextFilePrametersTypes);

            // Assert
            methodCreateTextFilePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CreateTextFile_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateTextFile, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_WriteToFile_Method_Call_Internally(Type[] types)
        {
            var methodWriteToFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodWriteToFile, Fixture, methodWriteToFilePrametersTypes);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_WriteToFile_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.WriteToFile(sText);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_WriteToFile_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            var methodWriteToFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfWriteToFile = { sText };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteToFile, methodWriteToFilePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfWriteToFile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteToFile.ShouldNotBeNull();
            parametersOfWriteToFile.Length.ShouldBe(1);
            methodWriteToFilePrametersTypes.Length.ShouldBe(1);
            methodWriteToFilePrametersTypes.Length.ShouldBe(parametersOfWriteToFile.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_WriteToFile_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            var methodWriteToFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfWriteToFile = { sText };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodWriteToFile, parametersOfWriteToFile, methodWriteToFilePrametersTypes);

            // Assert
            parametersOfWriteToFile.ShouldNotBeNull();
            parametersOfWriteToFile.Length.ShouldBe(1);
            methodWriteToFilePrametersTypes.Length.ShouldBe(1);
            methodWriteToFilePrametersTypes.Length.ShouldBe(parametersOfWriteToFile.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_WriteToFile_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteToFile, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_WriteToFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteToFilePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodWriteToFile, Fixture, methodWriteToFilePrametersTypes);

            // Assert
            methodWriteToFilePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_WriteToFile_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteToFile, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTextFile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_WriteTextFile_Method_Call_Internally(Type[] types)
        {
            var methodWriteTextFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodWriteTextFile, Fixture, methodWriteTextFilePrametersTypes);
        }

        #endregion

        #region Method Call : (WriteTextFile) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_WriteTextFile_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var path = CreateType<string>();
            var text = CreateType<string>();
            var methodWriteTextFilePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfWriteTextFile = { path, text };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodWriteTextFile, parametersOfWriteTextFile, methodWriteTextFilePrametersTypes);

            // Assert
            parametersOfWriteTextFile.ShouldNotBeNull();
            parametersOfWriteTextFile.Length.ShouldBe(2);
            methodWriteTextFilePrametersTypes.Length.ShouldBe(2);
            methodWriteTextFilePrametersTypes.Length.ShouldBe(parametersOfWriteTextFile.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTextFile) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_WriteTextFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteTextFilePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodWriteTextFile, Fixture, methodWriteTextFilePrametersTypes);

            // Assert
            methodWriteTextFilePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_DeleteWork_Method_Call_Internally(Type[] types)
        {
            var methodDeleteWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDeleteWork, Fixture, methodDeleteWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteWork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.DeleteWork(listid, itemid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfDeleteWork = { listid, itemid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteWork, methodDeleteWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfDeleteWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodDeleteWork, parametersOfDeleteWork, methodDeleteWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteWork.ShouldNotBeNull();
            parametersOfDeleteWork.Length.ShouldBe(2);
            methodDeleteWorkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfDeleteWork = { listid, itemid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteWork, methodDeleteWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfDeleteWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodDeleteWork, parametersOfDeleteWork, methodDeleteWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteWork.ShouldNotBeNull();
            parametersOfDeleteWork.Length.ShouldBe(2);
            methodDeleteWorkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfDeleteWork = { listid, itemid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodDeleteWork, parametersOfDeleteWork, methodDeleteWorkPrametersTypes);

            // Assert
            parametersOfDeleteWork.ShouldNotBeNull();
            parametersOfDeleteWork.Length.ShouldBe(2);
            methodDeleteWorkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDeleteWork, Fixture, methodDeleteWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteWork, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MapLists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_MapLists_Method_Call_Internally(Type[] types)
        {
            var methodMapListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodMapLists, Fixture, methodMapListsPrametersTypes);
        }

        #endregion

        #region Method Call : (MapLists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapLists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sListNames = CreateType<ICollection<Guid>>();
            var webId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.MapLists(sListNames, webId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (MapLists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sListNames = CreateType<ICollection<Guid>>();
            var webId = CreateType<Guid>();
            var methodMapListsPrametersTypes = new Type[] { typeof(ICollection<Guid>), typeof(Guid) };
            object[] parametersOfMapLists = { sListNames, webId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMapLists, methodMapListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfMapLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodMapLists, parametersOfMapLists, methodMapListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMapLists.ShouldNotBeNull();
            parametersOfMapLists.Length.ShouldBe(2);
            methodMapListsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (MapLists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapLists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sListNames = CreateType<ICollection<Guid>>();
            var webId = CreateType<Guid>();
            var methodMapListsPrametersTypes = new Type[] { typeof(ICollection<Guid>), typeof(Guid) };
            object[] parametersOfMapLists = { sListNames, webId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMapLists, methodMapListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfMapLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodMapLists, parametersOfMapLists, methodMapListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMapLists.ShouldNotBeNull();
            parametersOfMapLists.Length.ShouldBe(2);
            methodMapListsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (MapLists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListNames = CreateType<ICollection<Guid>>();
            var webId = CreateType<Guid>();
            var methodMapListsPrametersTypes = new Type[] { typeof(ICollection<Guid>), typeof(Guid) };
            object[] parametersOfMapLists = { sListNames, webId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodMapLists, parametersOfMapLists, methodMapListsPrametersTypes);

            // Assert
            parametersOfMapLists.ShouldNotBeNull();
            parametersOfMapLists.Length.ShouldBe(2);
            methodMapListsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapLists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMapListsPrametersTypes = new Type[] { typeof(ICollection<Guid>), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodMapLists, Fixture, methodMapListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMapListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MapLists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMapLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MapLists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMapLists, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MapDefaultLists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_MapDefaultLists_Method_Call_Internally(Type[] types)
        {
            var methodMapDefaultListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodMapDefaultLists, Fixture, methodMapDefaultListsPrametersTypes);
        }

        #endregion

        #region Method Call : (MapDefaultLists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDefaultLists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.MapDefaultLists(sListNames);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (MapDefaultLists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDefaultLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var methodMapDefaultListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfMapDefaultLists = { sListNames };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMapDefaultLists, methodMapDefaultListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfMapDefaultLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodMapDefaultLists, parametersOfMapDefaultLists, methodMapDefaultListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMapDefaultLists.ShouldNotBeNull();
            parametersOfMapDefaultLists.Length.ShouldBe(1);
            methodMapDefaultListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (MapDefaultLists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDefaultLists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var methodMapDefaultListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfMapDefaultLists = { sListNames };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMapDefaultLists, methodMapDefaultListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfMapDefaultLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodMapDefaultLists, parametersOfMapDefaultLists, methodMapDefaultListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMapDefaultLists.ShouldNotBeNull();
            parametersOfMapDefaultLists.Length.ShouldBe(1);
            methodMapDefaultListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (MapDefaultLists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDefaultLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var methodMapDefaultListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfMapDefaultLists = { sListNames };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodMapDefaultLists, parametersOfMapDefaultLists, methodMapDefaultListsPrametersTypes);

            // Assert
            parametersOfMapDefaultLists.ShouldNotBeNull();
            parametersOfMapDefaultLists.Length.ShouldBe(1);
            methodMapDefaultListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapDefaultLists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDefaultLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMapDefaultListsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodMapDefaultLists, Fixture, methodMapDefaultListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMapDefaultListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MapDefaultLists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDefaultLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMapDefaultLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MapDefaultLists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDefaultLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMapDefaultLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_SetListIcon_Method_Call_Internally(Type[] types)
        {
            var methodSetListIconPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodSetListIcon, Fixture, methodSetListIconPrametersTypes);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SetListIcon_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listIconsToBeSet = CreateType<Dictionary<String, String>>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.SetListIcon(listIconsToBeSet);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SetListIcon_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var listIconsToBeSet = CreateType<Dictionary<String, String>>();
            var methodSetListIconPrametersTypes = new Type[] { typeof(Dictionary<String, String>) };
            object[] parametersOfSetListIcon = { listIconsToBeSet };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetListIcon, methodSetListIconPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfSetListIcon);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetListIcon.ShouldNotBeNull();
            parametersOfSetListIcon.Length.ShouldBe(1);
            methodSetListIconPrametersTypes.Length.ShouldBe(1);
            methodSetListIconPrametersTypes.Length.ShouldBe(parametersOfSetListIcon.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SetListIcon_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listIconsToBeSet = CreateType<Dictionary<String, String>>();
            var methodSetListIconPrametersTypes = new Type[] { typeof(Dictionary<String, String>) };
            object[] parametersOfSetListIcon = { listIconsToBeSet };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodSetListIcon, parametersOfSetListIcon, methodSetListIconPrametersTypes);

            // Assert
            parametersOfSetListIcon.ShouldNotBeNull();
            parametersOfSetListIcon.Length.ShouldBe(1);
            methodSetListIconPrametersTypes.Length.ShouldBe(1);
            methodSetListIconPrametersTypes.Length.ShouldBe(parametersOfSetListIcon.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SetListIcon_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetListIcon, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SetListIcon_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetListIconPrametersTypes = new Type[] { typeof(Dictionary<String, String>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodSetListIcon, Fixture, methodSetListIconPrametersTypes);

            // Assert
            methodSetListIconPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SetListIcon_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetListIcon, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetListFields_Method_Call_Internally(Type[] types)
        {
            var methodGetListFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListFields, Fixture, methodGetListFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetListFields = { spList };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListFields, methodGetListFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, ListItemCollection>(_ePMDataInstanceFixture, out exception1, parametersOfGetListFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, ListItemCollection>(_ePMDataInstance, MethodGetListFields, parametersOfGetListFields, methodGetListFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListFields.ShouldNotBeNull();
            parametersOfGetListFields.Length.ShouldBe(1);
            methodGetListFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetListFields = { spList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, ListItemCollection>(_ePMDataInstance, MethodGetListFields, parametersOfGetListFields, methodGetListFieldsPrametersTypes);

            // Assert
            parametersOfGetListFields.ShouldNotBeNull();
            parametersOfGetListFields.Length.ShouldBe(1);
            methodGetListFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListFields, Fixture, methodGetListFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListFields, Fixture, methodGetListFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_DeleteExistingTSData_Method_Call_Internally(Type[] types)
        {
            var methodDeleteExistingTSDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDeleteExistingTSData, Fixture, methodDeleteExistingTSDataPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteExistingTSData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.DeleteExistingTSData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteExistingTSData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodDeleteExistingTSDataPrametersTypes = null;
            object[] parametersOfDeleteExistingTSData = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfDeleteExistingTSData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodDeleteExistingTSData, parametersOfDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteExistingTSData.ShouldBeNull();
            methodDeleteExistingTSDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteExistingTSData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodDeleteExistingTSDataPrametersTypes = null;
            object[] parametersOfDeleteExistingTSData = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfDeleteExistingTSData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodDeleteExistingTSData, parametersOfDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteExistingTSData.ShouldBeNull();
            methodDeleteExistingTSDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteExistingTSData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDeleteExistingTSDataPrametersTypes = null;
            object[] parametersOfDeleteExistingTSData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodDeleteExistingTSData, parametersOfDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes);

            // Assert
            parametersOfDeleteExistingTSData.ShouldBeNull();
            methodDeleteExistingTSDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteExistingTSData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDeleteExistingTSDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDeleteExistingTSData, Fixture, methodDeleteExistingTSDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteExistingTSDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteExistingTSData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteExistingTSData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RefreshDefaultLists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_RefreshDefaultLists_Method_Call_Internally(Type[] types)
        {
            var methodRefreshDefaultListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodRefreshDefaultLists, Fixture, methodRefreshDefaultListsPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshDefaultLists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshDefaultLists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.RefreshDefaultLists(sListNames);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RefreshDefaultLists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshDefaultLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var methodRefreshDefaultListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRefreshDefaultLists = { sListNames };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRefreshDefaultLists, methodRefreshDefaultListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfRefreshDefaultLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodRefreshDefaultLists, parametersOfRefreshDefaultLists, methodRefreshDefaultListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRefreshDefaultLists.ShouldNotBeNull();
            parametersOfRefreshDefaultLists.Length.ShouldBe(1);
            methodRefreshDefaultListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RefreshDefaultLists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshDefaultLists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var methodRefreshDefaultListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRefreshDefaultLists = { sListNames };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRefreshDefaultLists, methodRefreshDefaultListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfRefreshDefaultLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodRefreshDefaultLists, parametersOfRefreshDefaultLists, methodRefreshDefaultListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRefreshDefaultLists.ShouldNotBeNull();
            parametersOfRefreshDefaultLists.Length.ShouldBe(1);
            methodRefreshDefaultListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RefreshDefaultLists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshDefaultLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var methodRefreshDefaultListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRefreshDefaultLists = { sListNames };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodRefreshDefaultLists, parametersOfRefreshDefaultLists, methodRefreshDefaultListsPrametersTypes);

            // Assert
            parametersOfRefreshDefaultLists.ShouldNotBeNull();
            parametersOfRefreshDefaultLists.Length.ShouldBe(1);
            methodRefreshDefaultListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshDefaultLists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshDefaultLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRefreshDefaultListsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodRefreshDefaultLists, Fixture, methodRefreshDefaultListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRefreshDefaultListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshDefaultLists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshDefaultLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshDefaultLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RefreshDefaultLists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshDefaultLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRefreshDefaultLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultLists) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetDefaultLists_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetDefaultLists, Fixture, methodGetDefaultListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDefaultLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var rootWeb = CreateType<SPWeb>();
            var methodGetDefaultListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetDefaultLists = { rootWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDefaultLists, methodGetDefaultListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, string>(_ePMDataInstanceFixture, out exception1, parametersOfGetDefaultLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetDefaultLists, parametersOfGetDefaultLists, methodGetDefaultListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDefaultLists.ShouldNotBeNull();
            parametersOfGetDefaultLists.Length.ShouldBe(1);
            methodGetDefaultListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDefaultLists) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDefaultLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rootWeb = CreateType<SPWeb>();
            var methodGetDefaultListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetDefaultLists = { rootWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetDefaultLists, parametersOfGetDefaultLists, methodGetDefaultListsPrametersTypes);

            // Assert
            parametersOfGetDefaultLists.ShouldNotBeNull();
            parametersOfGetDefaultLists.Length.ShouldBe(1);
            methodGetDefaultListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDefaultLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDefaultListsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetDefaultLists, Fixture, methodGetDefaultListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefaultListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDefaultLists) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDefaultLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDefaultListsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetDefaultLists, Fixture, methodGetDefaultListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefaultListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultLists) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDefaultLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefaultLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultLists) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDefaultLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDefaultLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddParam) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_AddParam_Method_Call_Internally(Type[] types)
        {
            var methodAddParamPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodAddParam, Fixture, methodAddParamPrametersTypes);
        }

        #endregion

        #region Method Call : (AddParam) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_AddParam_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var value = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.AddParam(name, value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddParam) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_AddParam_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var value = CreateType<object>();
            var methodAddParamPrametersTypes = new Type[] { typeof(string), typeof(object) };
            object[] parametersOfAddParam = { name, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddParam, methodAddParamPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfAddParam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddParam.ShouldNotBeNull();
            parametersOfAddParam.Length.ShouldBe(2);
            methodAddParamPrametersTypes.Length.ShouldBe(2);
            methodAddParamPrametersTypes.Length.ShouldBe(parametersOfAddParam.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddParam) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_AddParam_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var value = CreateType<object>();
            var methodAddParamPrametersTypes = new Type[] { typeof(string), typeof(object) };
            object[] parametersOfAddParam = { name, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodAddParam, parametersOfAddParam, methodAddParamPrametersTypes);

            // Assert
            parametersOfAddParam.ShouldNotBeNull();
            parametersOfAddParam.Length.ShouldBe(2);
            methodAddParamPrametersTypes.Length.ShouldBe(2);
            methodAddParamPrametersTypes.Length.ShouldBe(parametersOfAddParam.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddParam) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_AddParam_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddParam, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddParam) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_AddParam_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddParamPrametersTypes = new Type[] { typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodAddParam, Fixture, methodAddParamPrametersTypes);

            // Assert
            methodAddParamPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddParam) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_AddParam_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddParam, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckConnection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_CheckConnection_Static_Method_Call_Internally(Type[] types)
        {
            var methodCheckConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodCheckConnection, Fixture, methodCheckConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckConnection) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CheckConnection_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var cs = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EPMData.CheckConnection(cs);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CheckConnection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CheckConnection_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cs = CreateType<string>();
            var methodCheckConnectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCheckConnection = { cs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodCheckConnection, parametersOfCheckConnection, methodCheckConnectionPrametersTypes);

            // Assert
            parametersOfCheckConnection.ShouldNotBeNull();
            parametersOfCheckConnection.Length.ShouldBe(1);
            methodCheckConnectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckConnection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CheckConnection_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckConnectionPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodCheckConnection, Fixture, methodCheckConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckConnection) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CheckConnection_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckConnection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_CheckConnection_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckConnection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryToConnect) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_TryToConnect_Static_Method_Call_Internally(Type[] types)
        {
            var methodTryToConnectPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodTryToConnect, Fixture, methodTryToConnectPrametersTypes);
        }

        #endregion

        #region Method Call : (TryToConnect) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TryToConnect_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var connectionString = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EPMData.TryToConnect(connectionString);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryToConnect) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TryToConnect_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var connectionString = CreateType<string>();
            var methodTryToConnectPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfTryToConnect = { connectionString };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodTryToConnect, parametersOfTryToConnect, methodTryToConnectPrametersTypes);

            // Assert
            parametersOfTryToConnect.ShouldNotBeNull();
            parametersOfTryToConnect.Length.ShouldBe(1);
            methodTryToConnectPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryToConnect) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TryToConnect_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryToConnectPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodTryToConnect, Fixture, methodTryToConnectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryToConnectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteScalar) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_ExecuteScalar_Method_Call_Internally(Type[] types)
        {
            var methodExecuteScalarPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodExecuteScalar, Fixture, methodExecuteScalarPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteScalar) (Return Type : object) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteScalar_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.ExecuteScalar(con);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteScalar) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteScalar_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodExecuteScalarPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfExecuteScalar = { con };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteScalar, methodExecuteScalarPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, object>(_ePMDataInstanceFixture, out exception1, parametersOfExecuteScalar);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, object>(_ePMDataInstance, MethodExecuteScalar, parametersOfExecuteScalar, methodExecuteScalarPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteScalar.ShouldNotBeNull();
            parametersOfExecuteScalar.Length.ShouldBe(1);
            methodExecuteScalarPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteScalar) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteScalar_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodExecuteScalarPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfExecuteScalar = { con };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, object>(_ePMDataInstance, MethodExecuteScalar, parametersOfExecuteScalar, methodExecuteScalarPrametersTypes);

            // Assert
            parametersOfExecuteScalar.ShouldNotBeNull();
            parametersOfExecuteScalar.Length.ShouldBe(1);
            methodExecuteScalarPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteScalar) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteScalar_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteScalarPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodExecuteScalar, Fixture, methodExecuteScalarPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteScalarPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteScalar) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteScalar_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteScalarPrametersTypes = new Type[] { typeof(SqlConnection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodExecuteScalar, Fixture, methodExecuteScalarPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteScalarPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteScalar) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteScalar_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteScalar, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteScalar) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteScalar_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteScalar, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_ExecuteNonQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteNonQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.ExecuteNonQuery(con);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfExecuteNonQuery = { con };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, methodExecuteNonQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfExecuteNonQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(1);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfExecuteNonQuery = { con };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, methodExecuteNonQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfExecuteNonQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(1);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfExecuteNonQuery = { con };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

            // Assert
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(1);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_ExecuteNonQuery_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodExecuteNonQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var command = CreateType<SqlCommand>();
            var paramCollection = CreateType<SqlParameterCollection>();
            var con = CreateType<SqlConnection>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.ExecuteNonQuery(command, paramCollection, con);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var command = CreateType<SqlCommand>();
            var paramCollection = CreateType<SqlParameterCollection>();
            var con = CreateType<SqlConnection>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlCommand), typeof(SqlParameterCollection), typeof(SqlConnection) };
            object[] parametersOfExecuteNonQuery = { command, paramCollection, con };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, methodExecuteNonQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfExecuteNonQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(3);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var command = CreateType<SqlCommand>();
            var paramCollection = CreateType<SqlParameterCollection>();
            var con = CreateType<SqlConnection>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlCommand), typeof(SqlParameterCollection), typeof(SqlConnection) };
            object[] parametersOfExecuteNonQuery = { command, paramCollection, con };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, methodExecuteNonQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfExecuteNonQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(3);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var command = CreateType<SqlCommand>();
            var paramCollection = CreateType<SqlParameterCollection>();
            var con = CreateType<SqlConnection>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlCommand), typeof(SqlParameterCollection), typeof(SqlConnection) };
            object[] parametersOfExecuteNonQuery = { command, paramCollection, con };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

            // Assert
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(3);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlCommand), typeof(SqlParameterCollection), typeof(SqlConnection) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ExecuteNonQuery_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRow) (Return Type : DataRow) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetRow_Method_Call_Internally(Type[] types)
        {
            var methodGetRowPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetRow, Fixture, methodGetRowPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRow) (Return Type : DataRow) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetRow_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetRow(con);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRow) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetRow_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodGetRowPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfGetRow = { con };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRow, methodGetRowPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, DataRow>(_ePMDataInstanceFixture, out exception1, parametersOfGetRow);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, DataRow>(_ePMDataInstance, MethodGetRow, parametersOfGetRow, methodGetRowPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRow.ShouldNotBeNull();
            parametersOfGetRow.Length.ShouldBe(1);
            methodGetRowPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRow) (Return Type : DataRow) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetRow_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodGetRowPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfGetRow = { con };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, DataRow>(_ePMDataInstance, MethodGetRow, parametersOfGetRow, methodGetRowPrametersTypes);

            // Assert
            parametersOfGetRow.ShouldNotBeNull();
            parametersOfGetRow.Length.ShouldBe(1);
            methodGetRowPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRow) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetRow_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRowPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetRow, Fixture, methodGetRowPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRowPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRow) (Return Type : DataRow) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetRow_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRowPrametersTypes = new Type[] { typeof(SqlConnection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetRow, Fixture, methodGetRowPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRowPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRow) (Return Type : DataRow) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetRow_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRow, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRow) (Return Type : DataRow) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetRow_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRow, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetTable_Method_Call_Internally(Type[] types)
        {
            var methodGetTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTable, Fixture, methodGetTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetTable(con);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfGetTable = { con };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTable, methodGetTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, DataTable>(_ePMDataInstanceFixture, out exception1, parametersOfGetTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetTable, parametersOfGetTable, methodGetTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTable.ShouldNotBeNull();
            parametersOfGetTable.Length.ShouldBe(1);
            methodGetTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfGetTable = { con };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetTable, parametersOfGetTable, methodGetTablePrametersTypes);

            // Assert
            parametersOfGetTable.ShouldNotBeNull();
            parametersOfGetTable.Length.ShouldBe(1);
            methodGetTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTable, Fixture, methodGetTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlConnection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTable, Fixture, methodGetTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetTable_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTable, Fixture, methodGetTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var getFullSchema = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetTable(con, getFullSchema);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var getFullSchema = CreateType<bool>();
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlConnection), typeof(bool) };
            object[] parametersOfGetTable = { con, getFullSchema };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTable, methodGetTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, DataTable>(_ePMDataInstanceFixture, out exception1, parametersOfGetTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetTable, parametersOfGetTable, methodGetTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTable.ShouldNotBeNull();
            parametersOfGetTable.Length.ShouldBe(2);
            methodGetTablePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var getFullSchema = CreateType<bool>();
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlConnection), typeof(bool) };
            object[] parametersOfGetTable = { con, getFullSchema };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetTable, parametersOfGetTable, methodGetTablePrametersTypes);

            // Assert
            parametersOfGetTable.ShouldNotBeNull();
            parametersOfGetTable.Length.ShouldBe(2);
            methodGetTablePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlConnection), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTable, Fixture, methodGetTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTablePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlConnection), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTable, Fixture, methodGetTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTable, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTable, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetSite_Method_Call_Internally(Type[] types)
        {
            var methodGetSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSite, Fixture, methodGetSitePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSite_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetSite();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSite_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSitePrametersTypes = null;
            object[] parametersOfGetSite = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSite, methodGetSitePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, DataRow>(_ePMDataInstanceFixture, out exception1, parametersOfGetSite);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, DataRow>(_ePMDataInstance, MethodGetSite, parametersOfGetSite, methodGetSitePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSite.ShouldBeNull();
            methodGetSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSite_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSitePrametersTypes = null;
            object[] parametersOfGetSite = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, DataRow>(_ePMDataInstance, MethodGetSite, parametersOfGetSite, methodGetSitePrametersTypes);

            // Assert
            parametersOfGetSite.ShouldBeNull();
            methodGetSitePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSite_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSitePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSite, Fixture, methodGetSitePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSite_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSitePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSite, Fixture, methodGetSitePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSite_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSite, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PopulateInstanceFromData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_PopulateInstanceFromData_Method_Call_Internally(Type[] types)
        {
            var methodPopulateInstanceFromDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodPopulateInstanceFromData, Fixture, methodPopulateInstanceFromDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateInstanceFromData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_PopulateInstanceFromData_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodPopulateInstanceFromDataPrametersTypes = null;
            object[] parametersOfPopulateInstanceFromData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateInstanceFromData, methodPopulateInstanceFromDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfPopulateInstanceFromData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateInstanceFromData.ShouldBeNull();
            methodPopulateInstanceFromDataPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInstanceFromData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_PopulateInstanceFromData_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPopulateInstanceFromDataPrametersTypes = null;
            object[] parametersOfPopulateInstanceFromData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodPopulateInstanceFromData, parametersOfPopulateInstanceFromData, methodPopulateInstanceFromDataPrametersTypes);

            // Assert
            parametersOfPopulateInstanceFromData.ShouldBeNull();
            methodPopulateInstanceFromDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInstanceFromData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_PopulateInstanceFromData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPopulateInstanceFromDataPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodPopulateInstanceFromData, Fixture, methodPopulateInstanceFromDataPrametersTypes);

            // Assert
            methodPopulateInstanceFromDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInstanceFromData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_PopulateInstanceFromData_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateInstanceFromData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateConnectionStrings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_PopulateConnectionStrings_Method_Call_Internally(Type[] types)
        {
            var methodPopulateConnectionStringsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodPopulateConnectionStrings, Fixture, methodPopulateConnectionStringsPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateConnectionStrings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_PopulateConnectionStrings_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodPopulateConnectionStringsPrametersTypes = null;
            object[] parametersOfPopulateConnectionStrings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateConnectionStrings, methodPopulateConnectionStringsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfPopulateConnectionStrings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateConnectionStrings.ShouldBeNull();
            methodPopulateConnectionStringsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateConnectionStrings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_PopulateConnectionStrings_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPopulateConnectionStringsPrametersTypes = null;
            object[] parametersOfPopulateConnectionStrings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodPopulateConnectionStrings, parametersOfPopulateConnectionStrings, methodPopulateConnectionStringsPrametersTypes);

            // Assert
            parametersOfPopulateConnectionStrings.ShouldBeNull();
            methodPopulateConnectionStringsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateConnectionStrings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_PopulateConnectionStrings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPopulateConnectionStringsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodPopulateConnectionStrings, Fixture, methodPopulateConnectionStringsPrametersTypes);

            // Assert
            methodPopulateConnectionStringsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateConnectionStrings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_PopulateConnectionStrings_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateConnectionStrings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_SAccountInfo_Method_Call_Internally(Type[] types)
        {
            var methodSAccountInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodSAccountInfo, Fixture, methodSAccountInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.SAccountInfo();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodSAccountInfoPrametersTypes = null;
            object[] parametersOfSAccountInfo = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSAccountInfo, methodSAccountInfoPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, DataRow>(_ePMDataInstanceFixture, out exception1, parametersOfSAccountInfo);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, DataRow>(_ePMDataInstance, MethodSAccountInfo, parametersOfSAccountInfo, methodSAccountInfoPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSAccountInfo.ShouldBeNull();
            methodSAccountInfoPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSAccountInfoPrametersTypes = null;
            object[] parametersOfSAccountInfo = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, DataRow>(_ePMDataInstance, MethodSAccountInfo, parametersOfSAccountInfo, methodSAccountInfoPrametersTypes);

            // Assert
            parametersOfSAccountInfo.ShouldBeNull();
            methodSAccountInfoPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodSAccountInfoPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodSAccountInfo, Fixture, methodSAccountInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSAccountInfoPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSAccountInfoPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodSAccountInfo, Fixture, methodSAccountInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSAccountInfoPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSAccountInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_SAccountInfo_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodSAccountInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodSAccountInfo, Fixture, methodSAccountInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => EPMData.SAccountInfo(siteId, webAppId);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            var methodSAccountInfoPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            object[] parametersOfSAccountInfo = { siteId, webAppId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSAccountInfo, methodSAccountInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfSAccountInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSAccountInfo.ShouldNotBeNull();
            parametersOfSAccountInfo.Length.ShouldBe(2);
            methodSAccountInfoPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            var methodSAccountInfoPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            object[] parametersOfSAccountInfo = { siteId, webAppId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataRow>(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodSAccountInfo, parametersOfSAccountInfo, methodSAccountInfoPrametersTypes);

            // Assert
            parametersOfSAccountInfo.ShouldNotBeNull();
            parametersOfSAccountInfo.Length.ShouldBe(2);
            methodSAccountInfoPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSAccountInfoPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodSAccountInfo, Fixture, methodSAccountInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSAccountInfoPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSAccountInfoPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodSAccountInfo, Fixture, methodSAccountInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSAccountInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSAccountInfo, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SAccountInfo_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSAccountInfo, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetTable_Static_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodGetTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodGetTable, Fixture, methodGetTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Static_Method_Call_Overloading_Of_2_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var cmd = CreateType<SqlCommand>();
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlCommand) };
            object[] parametersOfGetTable = { cmd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTable, methodGetTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfGetTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTable.ShouldNotBeNull();
            parametersOfGetTable.Length.ShouldBe(1);
            methodGetTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Static_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cmd = CreateType<SqlCommand>();
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlCommand) };
            object[] parametersOfGetTable = { cmd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodGetTable, parametersOfGetTable, methodGetTablePrametersTypes);

            // Assert
            parametersOfGetTable.ShouldNotBeNull();
            parametersOfGetTable.Length.ShouldBe(1);
            methodGetTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlCommand) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodGetTable, Fixture, methodGetTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlCommand) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodGetTable, Fixture, methodGetTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTable, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTable_Static_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTable, 2);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalculatedFieldValue) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetCalculatedFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodGetCalculatedFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetCalculatedFieldValue, Fixture, methodGetCalculatedFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCalculatedFieldValue) (Return Type : object) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCalculatedFieldValue_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<SPFieldCalculated>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetCalculatedFieldValue(li, field);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCalculatedFieldValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCalculatedFieldValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<SPFieldCalculated>();
            var methodGetCalculatedFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFieldCalculated) };
            object[] parametersOfGetCalculatedFieldValue = { li, field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCalculatedFieldValue, methodGetCalculatedFieldValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, object>(_ePMDataInstanceFixture, out exception1, parametersOfGetCalculatedFieldValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, object>(_ePMDataInstance, MethodGetCalculatedFieldValue, parametersOfGetCalculatedFieldValue, methodGetCalculatedFieldValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCalculatedFieldValue.ShouldNotBeNull();
            parametersOfGetCalculatedFieldValue.Length.ShouldBe(2);
            methodGetCalculatedFieldValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCalculatedFieldValue) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCalculatedFieldValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<SPFieldCalculated>();
            var methodGetCalculatedFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFieldCalculated) };
            object[] parametersOfGetCalculatedFieldValue = { li, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, object>(_ePMDataInstance, MethodGetCalculatedFieldValue, parametersOfGetCalculatedFieldValue, methodGetCalculatedFieldValuePrametersTypes);

            // Assert
            parametersOfGetCalculatedFieldValue.ShouldNotBeNull();
            parametersOfGetCalculatedFieldValue.Length.ShouldBe(2);
            methodGetCalculatedFieldValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalculatedFieldValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCalculatedFieldValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCalculatedFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFieldCalculated) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetCalculatedFieldValue, Fixture, methodGetCalculatedFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCalculatedFieldValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCalculatedFieldValue) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCalculatedFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCalculatedFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFieldCalculated) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetCalculatedFieldValue, Fixture, methodGetCalculatedFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCalculatedFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalculatedFieldValue) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCalculatedFieldValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalculatedFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCalculatedFieldValue) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCalculatedFieldValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCalculatedFieldValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSnapshotQueueStatus) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetSnapshotQueueStatus_Method_Call_Internally(Type[] types)
        {
            var methodGetSnapshotQueueStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSnapshotQueueStatus, Fixture, methodGetSnapshotQueueStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSnapshotQueueStatus) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotQueueStatus_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var status = CreateType<int>();
            var listguid = CreateType<string>();
            var pctComplete = CreateType<int>();
            var queued = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetSnapshotQueueStatus(out status, out listguid, out pctComplete, out queued);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSnapshotQueueStatus) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotQueueStatus_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var status = CreateType<int>();
            var listguid = CreateType<string>();
            var pctComplete = CreateType<int>();
            var queued = CreateType<bool>();
            var methodGetSnapshotQueueStatusPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int), typeof(bool) };
            object[] parametersOfGetSnapshotQueueStatus = { status, listguid, pctComplete, queued };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSnapshotQueueStatus, methodGetSnapshotQueueStatusPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfGetSnapshotQueueStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSnapshotQueueStatus.ShouldNotBeNull();
            parametersOfGetSnapshotQueueStatus.Length.ShouldBe(4);
            methodGetSnapshotQueueStatusPrametersTypes.Length.ShouldBe(4);
            methodGetSnapshotQueueStatusPrametersTypes.Length.ShouldBe(parametersOfGetSnapshotQueueStatus.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSnapshotQueueStatus) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotQueueStatus_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var status = CreateType<int>();
            var listguid = CreateType<string>();
            var pctComplete = CreateType<int>();
            var queued = CreateType<bool>();
            var methodGetSnapshotQueueStatusPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int), typeof(bool) };
            object[] parametersOfGetSnapshotQueueStatus = { status, listguid, pctComplete, queued };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodGetSnapshotQueueStatus, parametersOfGetSnapshotQueueStatus, methodGetSnapshotQueueStatusPrametersTypes);

            // Assert
            parametersOfGetSnapshotQueueStatus.ShouldNotBeNull();
            parametersOfGetSnapshotQueueStatus.Length.ShouldBe(4);
            methodGetSnapshotQueueStatusPrametersTypes.Length.ShouldBe(4);
            methodGetSnapshotQueueStatusPrametersTypes.Length.ShouldBe(parametersOfGetSnapshotQueueStatus.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSnapshotQueueStatus) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotQueueStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSnapshotQueueStatus, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSnapshotQueueStatus) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotQueueStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSnapshotQueueStatusPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSnapshotQueueStatus, Fixture, methodGetSnapshotQueueStatusPrametersTypes);

            // Assert
            methodGetSnapshotQueueStatusPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSnapshotQueueStatus) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotQueueStatus_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSnapshotQueueStatus, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanupQueueStatus) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetCleanupQueueStatus_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanupQueueStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetCleanupQueueStatus, Fixture, methodGetCleanupQueueStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanupQueueStatus) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCleanupQueueStatus_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var status = CreateType<int>();
            var listguid = CreateType<string>();
            var pctComplete = CreateType<int>();
            var queued = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetCleanupQueueStatus(out status, out listguid, out pctComplete, out queued);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCleanupQueueStatus) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCleanupQueueStatus_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var status = CreateType<int>();
            var listguid = CreateType<string>();
            var pctComplete = CreateType<int>();
            var queued = CreateType<bool>();
            var methodGetCleanupQueueStatusPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int), typeof(bool) };
            object[] parametersOfGetCleanupQueueStatus = { status, listguid, pctComplete, queued };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCleanupQueueStatus, methodGetCleanupQueueStatusPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfGetCleanupQueueStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCleanupQueueStatus.ShouldNotBeNull();
            parametersOfGetCleanupQueueStatus.Length.ShouldBe(4);
            methodGetCleanupQueueStatusPrametersTypes.Length.ShouldBe(4);
            methodGetCleanupQueueStatusPrametersTypes.Length.ShouldBe(parametersOfGetCleanupQueueStatus.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanupQueueStatus) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCleanupQueueStatus_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var status = CreateType<int>();
            var listguid = CreateType<string>();
            var pctComplete = CreateType<int>();
            var queued = CreateType<bool>();
            var methodGetCleanupQueueStatusPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int), typeof(bool) };
            object[] parametersOfGetCleanupQueueStatus = { status, listguid, pctComplete, queued };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodGetCleanupQueueStatus, parametersOfGetCleanupQueueStatus, methodGetCleanupQueueStatusPrametersTypes);

            // Assert
            parametersOfGetCleanupQueueStatus.ShouldNotBeNull();
            parametersOfGetCleanupQueueStatus.Length.ShouldBe(4);
            methodGetCleanupQueueStatusPrametersTypes.Length.ShouldBe(4);
            methodGetCleanupQueueStatusPrametersTypes.Length.ShouldBe(parametersOfGetCleanupQueueStatus.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanupQueueStatus) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCleanupQueueStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanupQueueStatus, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanupQueueStatus) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCleanupQueueStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanupQueueStatusPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetCleanupQueueStatus, Fixture, methodGetCleanupQueueStatusPrametersTypes);

            // Assert
            methodGetCleanupQueueStatusPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanupQueueStatus) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetCleanupQueueStatus_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanupQueueStatus, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_BulkInsert_Method_Call_Internally(Type[] types)
        {
            var methodBulkInsertPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodBulkInsert, Fixture, methodBulkInsertPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var blnLogStatus = CreateType<bool>();
            var message = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.BulkInsert(dsLists, blnLogStatus, out message);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var blnLogStatus = CreateType<bool>();
            var message = CreateType<string>();
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(bool), typeof(string) };
            object[] parametersOfBulkInsert = { dsLists, blnLogStatus, message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodBulkInsert, parametersOfBulkInsert, methodBulkInsertPrametersTypes);

            // Assert
            parametersOfBulkInsert.ShouldNotBeNull();
            parametersOfBulkInsert.Length.ShouldBe(3);
            methodBulkInsertPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(bool), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodBulkInsert, Fixture, methodBulkInsertPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBulkInsertPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBulkInsert, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBulkInsert, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_BulkInsert_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkInsertPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodBulkInsert, Fixture, methodBulkInsertPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.BulkInsert(dsLists, timerjobguid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            object[] parametersOfBulkInsert = { dsLists, timerjobguid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBulkInsert, methodBulkInsertPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfBulkInsert);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodBulkInsert, parametersOfBulkInsert, methodBulkInsertPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfBulkInsert.ShouldNotBeNull();
            parametersOfBulkInsert.Length.ShouldBe(2);
            methodBulkInsertPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            object[] parametersOfBulkInsert = { dsLists, timerjobguid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBulkInsert, methodBulkInsertPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfBulkInsert);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodBulkInsert, parametersOfBulkInsert, methodBulkInsertPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfBulkInsert.ShouldNotBeNull();
            parametersOfBulkInsert.Length.ShouldBe(2);
            methodBulkInsertPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            object[] parametersOfBulkInsert = { dsLists, timerjobguid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodBulkInsert, parametersOfBulkInsert, methodBulkInsertPrametersTypes);

            // Assert
            parametersOfBulkInsert.ShouldNotBeNull();
            parametersOfBulkInsert.Length.ShouldBe(2);
            methodBulkInsertPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodBulkInsert, Fixture, methodBulkInsertPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBulkInsertPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBulkInsert, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_BulkInsert_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBulkInsert, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllListIDs) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetAllListIDs_Method_Call_Internally(Type[] types)
        {
            var methodGetAllListIDsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetAllListIDs, Fixture, methodGetAllListIDsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllListIDs) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetAllListIDs_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetAllListIDs();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAllListIDs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetAllListIDs_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAllListIDsPrametersTypes = null;
            object[] parametersOfGetAllListIDs = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAllListIDs, methodGetAllListIDsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, string>(_ePMDataInstanceFixture, out exception1, parametersOfGetAllListIDs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetAllListIDs, parametersOfGetAllListIDs, methodGetAllListIDsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAllListIDs.ShouldBeNull();
            methodGetAllListIDsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllListIDs) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetAllListIDs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetAllListIDsPrametersTypes = null;
            object[] parametersOfGetAllListIDs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetAllListIDs, parametersOfGetAllListIDs, methodGetAllListIDsPrametersTypes);

            // Assert
            parametersOfGetAllListIDs.ShouldBeNull();
            methodGetAllListIDsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllListIDs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetAllListIDs_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAllListIDsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetAllListIDs, Fixture, methodGetAllListIDsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllListIDsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllListIDs) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetAllListIDs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetAllListIDsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetAllListIDs, Fixture, methodGetAllListIDsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllListIDsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllListIDs) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetAllListIDs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAllListIDs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListNames) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetListNames_Method_Call_Internally(Type[] types)
        {
            var methodGetListNamesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListNames, Fixture, methodGetListNamesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListNames) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListNames_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetListNames();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListNames) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListNames_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetListNamesPrametersTypes = null;
            object[] parametersOfGetListNames = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListNames, methodGetListNamesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, string>(_ePMDataInstanceFixture, out exception1, parametersOfGetListNames);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetListNames, parametersOfGetListNames, methodGetListNamesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListNames.ShouldBeNull();
            methodGetListNamesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListNames) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListNames_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetListNamesPrametersTypes = null;
            object[] parametersOfGetListNames = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetListNames, parametersOfGetListNames, methodGetListNamesPrametersTypes);

            // Assert
            parametersOfGetListNames.ShouldBeNull();
            methodGetListNamesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListNames) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListNames_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetListNamesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListNames, Fixture, methodGetListNamesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListNamesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListNames) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListNames_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetListNamesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListNames, Fixture, methodGetListNamesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListNamesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListNames) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListNames_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListNames, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetListEvents_Method_Call_Internally(Type[] types)
        {
            var methodGetListEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListEvents_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListEvents, methodGetListEventsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, List<SPEventReceiverDefinition>>(_ePMDataInstanceFixture, out exception1, parametersOfGetListEvents);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, List<SPEventReceiverDefinition>>(_ePMDataInstance, MethodGetListEvents, parametersOfGetListEvents, methodGetListEventsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListEvents_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, List<SPEventReceiverDefinition>>(_ePMDataInstance, MethodGetListEvents, parametersOfGetListEvents, methodGetListEventsPrametersTypes);

            // Assert
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListEvents_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListEventsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListEvents_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListEvents_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_LogStatus_Method_Call_Internally(Type[] types)
        {
            var methodLogStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodLogStatus, Fixture, methodLogStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogStatus_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var RPTListID = CreateType<string>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var timerjobguid = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.LogStatus(RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType, timerjobguid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogStatus_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var RPTListID = CreateType<string>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var timerjobguid = CreateType<string>();
            var methodLogStatusPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfLogStatus = { RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType, timerjobguid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLogStatus, methodLogStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfLogStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLogStatus.ShouldNotBeNull();
            parametersOfLogStatus.Length.ShouldBe(7);
            methodLogStatusPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogStatus_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var RPTListID = CreateType<string>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var timerjobguid = CreateType<string>();
            var methodLogStatusPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfLogStatus = { RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType, timerjobguid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLogStatus, methodLogStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfLogStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLogStatus.ShouldNotBeNull();
            parametersOfLogStatus.Length.ShouldBe(7);
            methodLogStatusPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogStatus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var RPTListID = CreateType<string>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var timerjobguid = CreateType<string>();
            var methodLogStatusPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfLogStatus = { RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType, timerjobguid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

            // Assert
            parametersOfLogStatus.ShouldNotBeNull();
            parametersOfLogStatus.Length.ShouldBe(7);
            methodLogStatusPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogStatusPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodLogStatus, Fixture, methodLogStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLogStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogStatus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogStatus, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_InitializeStatusLog_Method_Call_Internally(Type[] types)
        {
            var methodInitializeStatusLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodInitializeStatusLog, Fixture, methodInitializeStatusLogPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.InitializeStatusLog();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializeStatusLogPrametersTypes = null;
            object[] parametersOfInitializeStatusLog = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeStatusLog, methodInitializeStatusLogPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfInitializeStatusLog);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeStatusLog.ShouldBeNull();
            methodInitializeStatusLogPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializeStatusLogPrametersTypes = null;
            object[] parametersOfInitializeStatusLog = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodInitializeStatusLog, parametersOfInitializeStatusLog, methodInitializeStatusLogPrametersTypes);

            // Assert
            parametersOfInitializeStatusLog.ShouldBeNull();
            methodInitializeStatusLogPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializeStatusLogPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodInitializeStatusLog, Fixture, methodInitializeStatusLogPrametersTypes);

            // Assert
            methodInitializeStatusLogPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeStatusLog, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_InitializeStatusLog_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodInitializeStatusLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodInitializeStatusLog, Fixture, methodInitializeStatusLogPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var dtStatusLog = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.InitializeStatusLog(dtStatusLog);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_Call_Void_Overloading_Of_1_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dtStatusLog = CreateType<DataTable>();
            var methodInitializeStatusLogPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfInitializeStatusLog = { dtStatusLog };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeStatusLog, methodInitializeStatusLogPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfInitializeStatusLog);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeStatusLog.ShouldNotBeNull();
            parametersOfInitializeStatusLog.Length.ShouldBe(1);
            methodInitializeStatusLogPrametersTypes.Length.ShouldBe(1);
            methodInitializeStatusLogPrametersTypes.Length.ShouldBe(parametersOfInitializeStatusLog.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtStatusLog = CreateType<DataTable>();
            var methodInitializeStatusLogPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfInitializeStatusLog = { dtStatusLog };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMDataInstance, MethodInitializeStatusLog, parametersOfInitializeStatusLog, methodInitializeStatusLogPrametersTypes);

            // Assert
            parametersOfInitializeStatusLog.ShouldNotBeNull();
            parametersOfInitializeStatusLog.Length.ShouldBe(1);
            methodInitializeStatusLogPrametersTypes.Length.ShouldBe(1);
            methodInitializeStatusLogPrametersTypes.Length.ShouldBe(parametersOfInitializeStatusLog.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitializeStatusLog, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializeStatusLogPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodInitializeStatusLog, Fixture, methodInitializeStatusLogPrametersTypes);

            // Assert
            methodInitializeStatusLogPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_InitializeStatusLog_Method_Call_Overloading_Of_1_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeStatusLog, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogRefreshStatus) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_LogRefreshStatus_Method_Call_Internally(Type[] types)
        {
            var methodLogRefreshStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodLogRefreshStatus, Fixture, methodLogRefreshStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (LogRefreshStatus) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogRefreshStatus_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var listName = CreateType<string>();
            var timerjobguid = CreateType<Guid>();
            var webName = CreateType<string>();
            var message = CreateType<string>();
            var level = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.LogRefreshStatus(RPTListID, listName, timerjobguid, webName, message, level);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LogRefreshStatus) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogRefreshStatus_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var listName = CreateType<string>();
            var timerjobguid = CreateType<Guid>();
            var webName = CreateType<string>();
            var message = CreateType<string>();
            var level = CreateType<int>();
            var methodLogRefreshStatusPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(Guid), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfLogRefreshStatus = { RPTListID, listName, timerjobguid, webName, message, level };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLogRefreshStatus, methodLogRefreshStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfLogRefreshStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodLogRefreshStatus, parametersOfLogRefreshStatus, methodLogRefreshStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLogRefreshStatus.ShouldNotBeNull();
            parametersOfLogRefreshStatus.Length.ShouldBe(6);
            methodLogRefreshStatusPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (LogRefreshStatus) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogRefreshStatus_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var listName = CreateType<string>();
            var timerjobguid = CreateType<Guid>();
            var webName = CreateType<string>();
            var message = CreateType<string>();
            var level = CreateType<int>();
            var methodLogRefreshStatusPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(Guid), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfLogRefreshStatus = { RPTListID, listName, timerjobguid, webName, message, level };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLogRefreshStatus, methodLogRefreshStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfLogRefreshStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodLogRefreshStatus, parametersOfLogRefreshStatus, methodLogRefreshStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLogRefreshStatus.ShouldNotBeNull();
            parametersOfLogRefreshStatus.Length.ShouldBe(6);
            methodLogRefreshStatusPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (LogRefreshStatus) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogRefreshStatus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var listName = CreateType<string>();
            var timerjobguid = CreateType<Guid>();
            var webName = CreateType<string>();
            var message = CreateType<string>();
            var level = CreateType<int>();
            var methodLogRefreshStatusPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(Guid), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfLogRefreshStatus = { RPTListID, listName, timerjobguid, webName, message, level };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodLogRefreshStatus, parametersOfLogRefreshStatus, methodLogRefreshStatusPrametersTypes);

            // Assert
            parametersOfLogRefreshStatus.ShouldNotBeNull();
            parametersOfLogRefreshStatus.Length.ShouldBe(6);
            methodLogRefreshStatusPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogRefreshStatus) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogRefreshStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogRefreshStatusPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(Guid), typeof(string), typeof(string), typeof(int) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodLogRefreshStatus, Fixture, methodLogRefreshStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLogRefreshStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogRefreshStatus) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogRefreshStatus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogRefreshStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LogRefreshStatus) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_LogRefreshStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogRefreshStatus, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSnapshotResults) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetSnapshotResults_Method_Call_Internally(Type[] types)
        {
            var methodGetSnapshotResultsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSnapshotResults, Fixture, methodGetSnapshotResultsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSnapshotResults) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotResults_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetSnapshotResults(timerjobguid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSnapshotResults) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotResults_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var methodGetSnapshotResultsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetSnapshotResults = { timerjobguid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSnapshotResults, methodGetSnapshotResultsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, DataTable>(_ePMDataInstanceFixture, out exception1, parametersOfGetSnapshotResults);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetSnapshotResults, parametersOfGetSnapshotResults, methodGetSnapshotResultsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSnapshotResults.ShouldNotBeNull();
            parametersOfGetSnapshotResults.Length.ShouldBe(1);
            methodGetSnapshotResultsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSnapshotResults) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotResults_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var methodGetSnapshotResultsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetSnapshotResults = { timerjobguid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetSnapshotResults, parametersOfGetSnapshotResults, methodGetSnapshotResultsPrametersTypes);

            // Assert
            parametersOfGetSnapshotResults.ShouldNotBeNull();
            parametersOfGetSnapshotResults.Length.ShouldBe(1);
            methodGetSnapshotResultsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSnapshotResults) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotResults_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSnapshotResultsPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSnapshotResults, Fixture, methodGetSnapshotResultsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSnapshotResultsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSnapshotResults) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotResults_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSnapshotResultsPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSnapshotResults, Fixture, methodGetSnapshotResultsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSnapshotResultsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSnapshotResults) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotResults_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSnapshotResults, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSnapshotResults) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSnapshotResults_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSnapshotResults, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_SnapshotLists_Method_Call_Internally(Type[] types)
        {
            var methodSnapshotListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodSnapshotLists, Fixture, methodSnapshotListsPrametersTypes);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SnapshotLists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var sListIDs = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.SnapshotLists(timerjobguid, siteId, sListIDs);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SnapshotLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var sListIDs = CreateType<string>();
            var methodSnapshotListsPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfSnapshotLists = { timerjobguid, siteId, sListIDs };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSnapshotLists, methodSnapshotListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfSnapshotLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodSnapshotLists, parametersOfSnapshotLists, methodSnapshotListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSnapshotLists.ShouldNotBeNull();
            parametersOfSnapshotLists.Length.ShouldBe(3);
            methodSnapshotListsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SnapshotLists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var sListIDs = CreateType<string>();
            var methodSnapshotListsPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfSnapshotLists = { timerjobguid, siteId, sListIDs };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSnapshotLists, methodSnapshotListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfSnapshotLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodSnapshotLists, parametersOfSnapshotLists, methodSnapshotListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSnapshotLists.ShouldNotBeNull();
            parametersOfSnapshotLists.Length.ShouldBe(3);
            methodSnapshotListsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SnapshotLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var sListIDs = CreateType<string>();
            var methodSnapshotListsPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfSnapshotLists = { timerjobguid, siteId, sListIDs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodSnapshotLists, parametersOfSnapshotLists, methodSnapshotListsPrametersTypes);

            // Assert
            parametersOfSnapshotLists.ShouldNotBeNull();
            parametersOfSnapshotLists.Length.ShouldBe(3);
            methodSnapshotListsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SnapshotLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSnapshotListsPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodSnapshotLists, Fixture, methodSnapshotListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSnapshotListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SnapshotLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSnapshotLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SnapshotLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSnapshotLists, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetStatusLog_Method_Call_Internally(Type[] types)
        {
            var methodGetStatusLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetStatusLog, Fixture, methodGetStatusLogPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetStatusLog_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetStatusLog();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetStatusLog_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetStatusLogPrametersTypes = null;
            object[] parametersOfGetStatusLog = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStatusLog, methodGetStatusLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, DataTable>(_ePMDataInstanceFixture, out exception1, parametersOfGetStatusLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetStatusLog, parametersOfGetStatusLog, methodGetStatusLogPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetStatusLog.ShouldBeNull();
            methodGetStatusLogPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetStatusLog_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetStatusLogPrametersTypes = null;
            object[] parametersOfGetStatusLog = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetStatusLog, parametersOfGetStatusLog, methodGetStatusLogPrametersTypes);

            // Assert
            parametersOfGetStatusLog.ShouldBeNull();
            methodGetStatusLogPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetStatusLog_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetStatusLogPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetStatusLog, Fixture, methodGetStatusLogPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStatusLogPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetStatusLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetStatusLogPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetStatusLog, Fixture, methodGetStatusLogPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStatusLogPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetStatusLog_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStatusLog, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSpecificReportingDbConnection) (Return Type : SqlConnection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetSpecificReportingDbConnection_Method_Call_Internally(Type[] types)
        {
            var methodGetSpecificReportingDbConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSpecificReportingDbConnection, Fixture, methodGetSpecificReportingDbConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSpecificReportingDbConnection) (Return Type : SqlConnection) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSpecificReportingDbConnection_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetSpecificReportingDbConnection(siteId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSpecificReportingDbConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSpecificReportingDbConnection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var methodGetSpecificReportingDbConnectionPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetSpecificReportingDbConnection = { siteId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSpecificReportingDbConnection, methodGetSpecificReportingDbConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, SqlConnection>(_ePMDataInstanceFixture, out exception1, parametersOfGetSpecificReportingDbConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, SqlConnection>(_ePMDataInstance, MethodGetSpecificReportingDbConnection, parametersOfGetSpecificReportingDbConnection, methodGetSpecificReportingDbConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSpecificReportingDbConnection.ShouldNotBeNull();
            parametersOfGetSpecificReportingDbConnection.Length.ShouldBe(1);
            methodGetSpecificReportingDbConnectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSpecificReportingDbConnection) (Return Type : SqlConnection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSpecificReportingDbConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var methodGetSpecificReportingDbConnectionPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetSpecificReportingDbConnection = { siteId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, SqlConnection>(_ePMDataInstance, MethodGetSpecificReportingDbConnection, parametersOfGetSpecificReportingDbConnection, methodGetSpecificReportingDbConnectionPrametersTypes);

            // Assert
            parametersOfGetSpecificReportingDbConnection.ShouldNotBeNull();
            parametersOfGetSpecificReportingDbConnection.Length.ShouldBe(1);
            methodGetSpecificReportingDbConnectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSpecificReportingDbConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSpecificReportingDbConnection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSpecificReportingDbConnectionPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSpecificReportingDbConnection, Fixture, methodGetSpecificReportingDbConnectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSpecificReportingDbConnectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSpecificReportingDbConnection) (Return Type : SqlConnection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSpecificReportingDbConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSpecificReportingDbConnectionPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSpecificReportingDbConnection, Fixture, methodGetSpecificReportingDbConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSpecificReportingDbConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpecificReportingDbConnection) (Return Type : SqlConnection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSpecificReportingDbConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSpecificReportingDbConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSpecificReportingDbConnection) (Return Type : SqlConnection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSpecificReportingDbConnection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSpecificReportingDbConnection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteAllItemsDB) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_DeleteAllItemsDB_Method_Call_Internally(Type[] types)
        {
            var methodDeleteAllItemsDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDeleteAllItemsDB, Fixture, methodDeleteAllItemsDBPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteAllItemsDB) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteAllItemsDB_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var refreshAll = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.DeleteAllItemsDB(sListNames, refreshAll);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteAllItemsDB) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteAllItemsDB_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var refreshAll = CreateType<bool>();
            var methodDeleteAllItemsDBPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfDeleteAllItemsDB = { sListNames, refreshAll };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteAllItemsDB, methodDeleteAllItemsDBPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfDeleteAllItemsDB);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodDeleteAllItemsDB, parametersOfDeleteAllItemsDB, methodDeleteAllItemsDBPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteAllItemsDB.ShouldNotBeNull();
            parametersOfDeleteAllItemsDB.Length.ShouldBe(2);
            methodDeleteAllItemsDBPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteAllItemsDB) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteAllItemsDB_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var refreshAll = CreateType<bool>();
            var methodDeleteAllItemsDBPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfDeleteAllItemsDB = { sListNames, refreshAll };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteAllItemsDB, methodDeleteAllItemsDBPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfDeleteAllItemsDB);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodDeleteAllItemsDB, parametersOfDeleteAllItemsDB, methodDeleteAllItemsDBPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteAllItemsDB.ShouldNotBeNull();
            parametersOfDeleteAllItemsDB.Length.ShouldBe(2);
            methodDeleteAllItemsDBPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteAllItemsDB) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteAllItemsDB_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListNames = CreateType<string>();
            var refreshAll = CreateType<bool>();
            var methodDeleteAllItemsDBPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfDeleteAllItemsDB = { sListNames, refreshAll };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodDeleteAllItemsDB, parametersOfDeleteAllItemsDB, methodDeleteAllItemsDBPrametersTypes);

            // Assert
            parametersOfDeleteAllItemsDB.ShouldNotBeNull();
            parametersOfDeleteAllItemsDB.Length.ShouldBe(2);
            methodDeleteAllItemsDBPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAllItemsDB) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteAllItemsDB_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteAllItemsDBPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodDeleteAllItemsDB, Fixture, methodDeleteAllItemsDBPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteAllItemsDBPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteAllItemsDB) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteAllItemsDB_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteAllItemsDB, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteAllItemsDB) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_DeleteAllItemsDB_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteAllItemsDB, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetTableNames_Method_Call_Internally(Type[] types)
        {
            var methodGetTableNamesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableNames, Fixture, methodGetTableNamesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableNames_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var tableNameRoot = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetTableNames(tableNameRoot);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableNames_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var tableNameRoot = CreateType<string>();
            var methodGetTableNamesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableNames = { tableNameRoot };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableNames, methodGetTableNamesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, DataTable>(_ePMDataInstanceFixture, out exception1, parametersOfGetTableNames);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetTableNames, parametersOfGetTableNames, methodGetTableNamesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTableNames.ShouldNotBeNull();
            parametersOfGetTableNames.Length.ShouldBe(1);
            methodGetTableNamesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableNames_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableNameRoot = CreateType<string>();
            var methodGetTableNamesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableNames = { tableNameRoot };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, DataTable>(_ePMDataInstance, MethodGetTableNames, parametersOfGetTableNames, methodGetTableNamesPrametersTypes);

            // Assert
            parametersOfGetTableNames.ShouldNotBeNull();
            parametersOfGetTableNames.Length.ShouldBe(1);
            methodGetTableNamesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableNames_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableNamesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableNames, Fixture, methodGetTableNamesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTableNamesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableNames_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableNamesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableNames, Fixture, methodGetTableNamesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableNamesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableNames_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableNames, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableNames_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTableNames, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_TableExists_Method_Call_Internally(Type[] types)
        {
            var methodTableExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodTableExists, Fixture, methodTableExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TableExists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var cn = CreateType<SqlConnection>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.TableExists(tableName, cn);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TableExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var cn = CreateType<SqlConnection>();
            var methodTableExistsPrametersTypes = new Type[] { typeof(string), typeof(SqlConnection) };
            object[] parametersOfTableExists = { tableName, cn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTableExists, methodTableExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfTableExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodTableExists, parametersOfTableExists, methodTableExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTableExists.ShouldNotBeNull();
            parametersOfTableExists.Length.ShouldBe(2);
            methodTableExistsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TableExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var cn = CreateType<SqlConnection>();
            var methodTableExistsPrametersTypes = new Type[] { typeof(string), typeof(SqlConnection) };
            object[] parametersOfTableExists = { tableName, cn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTableExists, methodTableExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfTableExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodTableExists, parametersOfTableExists, methodTableExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTableExists.ShouldNotBeNull();
            parametersOfTableExists.Length.ShouldBe(2);
            methodTableExistsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TableExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var cn = CreateType<SqlConnection>();
            var methodTableExistsPrametersTypes = new Type[] { typeof(string), typeof(SqlConnection) };
            object[] parametersOfTableExists = { tableName, cn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodTableExists, parametersOfTableExists, methodTableExistsPrametersTypes);

            // Assert
            parametersOfTableExists.ShouldNotBeNull();
            parametersOfTableExists.Length.ShouldBe(2);
            methodTableExistsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TableExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTableExistsPrametersTypes = new Type[] { typeof(string), typeof(SqlConnection) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodTableExists, Fixture, methodTableExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTableExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TableExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTableExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_TableExists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTableExists, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetSafeTableName_Method_Call_Internally(Type[] types)
        {
            var methodGetSafeTableNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSafeTableName, Fixture, methodGetSafeTableNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSafeTableName_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetSafeTableName(tableName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSafeTableName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodGetSafeTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeTableName = { tableName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSafeTableName, methodGetSafeTableNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, string>(_ePMDataInstanceFixture, out exception1, parametersOfGetSafeTableName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetSafeTableName, parametersOfGetSafeTableName, methodGetSafeTableNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSafeTableName.ShouldNotBeNull();
            parametersOfGetSafeTableName.Length.ShouldBe(1);
            methodGetSafeTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSafeTableName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodGetSafeTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeTableName = { tableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetSafeTableName, parametersOfGetSafeTableName, methodGetSafeTableNamePrametersTypes);

            // Assert
            parametersOfGetSafeTableName.ShouldNotBeNull();
            parametersOfGetSafeTableName.Length.ShouldBe(1);
            methodGetSafeTableNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSafeTableName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSafeTableNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSafeTableName, Fixture, methodGetSafeTableNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSafeTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSafeTableName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSafeTableNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetSafeTableName, Fixture, methodGetSafeTableNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSafeTableNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSafeTableName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSafeTableName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetSafeTableName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSafeTableName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetTableCount_Method_Call_Internally(Type[] types)
        {
            var methodGetTableCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableCount, Fixture, methodGetTableCountPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableCount_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetTableCount();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableCount_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTableCountPrametersTypes = null;
            object[] parametersOfGetTableCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableCount, methodGetTableCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, int>(_ePMDataInstanceFixture, out exception1, parametersOfGetTableCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, int>(_ePMDataInstance, MethodGetTableCount, parametersOfGetTableCount, methodGetTableCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetTableCount.ShouldBeNull();
            methodGetTableCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableCount_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetTableCountPrametersTypes = null;
            object[] parametersOfGetTableCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableCount, methodGetTableCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, int>(_ePMDataInstanceFixture, out exception1, parametersOfGetTableCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, int>(_ePMDataInstance, MethodGetTableCount, parametersOfGetTableCount, methodGetTableCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetTableCount.ShouldBeNull();
            methodGetTableCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableCount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTableCountPrametersTypes = null;
            object[] parametersOfGetTableCount = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, int>(_ePMDataInstance, MethodGetTableCount, parametersOfGetTableCount, methodGetTableCountPrametersTypes);

            // Assert
            parametersOfGetTableCount.ShouldBeNull();
            methodGetTableCountPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableCount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTableCountPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableCount, Fixture, methodGetTableCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableCount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_UpdateListName_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodUpdateListName, Fixture, methodUpdateListNamePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateListName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var sListName = CreateType<string>();
            var methodUpdateListNamePrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfUpdateListName = { RPTListID, sListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateListName, methodUpdateListNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfUpdateListName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodUpdateListName, parametersOfUpdateListName, methodUpdateListNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateListName.ShouldNotBeNull();
            parametersOfUpdateListName.Length.ShouldBe(2);
            methodUpdateListNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateListName_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var sListName = CreateType<string>();
            var methodUpdateListNamePrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfUpdateListName = { RPTListID, sListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateListName, methodUpdateListNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfUpdateListName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodUpdateListName, parametersOfUpdateListName, methodUpdateListNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateListName.ShouldNotBeNull();
            parametersOfUpdateListName.Length.ShouldBe(2);
            methodUpdateListNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateListName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var sListName = CreateType<string>();
            var methodUpdateListNamePrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfUpdateListName = { RPTListID, sListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodUpdateListName, parametersOfUpdateListName, methodUpdateListNamePrametersTypes);

            // Assert
            parametersOfUpdateListName.ShouldNotBeNull();
            parametersOfUpdateListName.Length.ShouldBe(2);
            methodUpdateListNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateListName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListNamePrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodUpdateListName, Fixture, methodUpdateListNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateListNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateListName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateListName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateListName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetListId_Method_Call_Internally(Type[] types)
        {
            var methodGetListIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListId, Fixture, methodGetListIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetListId(sListName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodGetListIdPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListId = { sListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListId, methodGetListIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, Guid>(_ePMDataInstanceFixture, out exception1, parametersOfGetListId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, Guid>(_ePMDataInstance, MethodGetListId, parametersOfGetListId, methodGetListIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetListId.ShouldNotBeNull();
            parametersOfGetListId.Length.ShouldBe(1);
            methodGetListIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodGetListIdPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListId = { sListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, Guid>(_ePMDataInstance, MethodGetListId, parametersOfGetListId, methodGetListIdPrametersTypes);

            // Assert
            parametersOfGetListId.ShouldNotBeNull();
            parametersOfGetListId.Length.ShouldBe(1);
            methodGetListIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListIdPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListId, Fixture, methodGetListIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListIdPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListId, Fixture, methodGetListIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetListId_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetListIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListId, Fixture, methodGetListIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var webId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetListId(sListName, webId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var webId = CreateType<Guid>();
            var methodGetListIdPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfGetListId = { sListName, webId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListId, methodGetListIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, Guid>(_ePMDataInstanceFixture, out exception1, parametersOfGetListId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, Guid>(_ePMDataInstance, MethodGetListId, parametersOfGetListId, methodGetListIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetListId.ShouldNotBeNull();
            parametersOfGetListId.Length.ShouldBe(2);
            methodGetListIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var webId = CreateType<Guid>();
            var methodGetListIdPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfGetListId = { sListName, webId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, Guid>(_ePMDataInstance, MethodGetListId, parametersOfGetListId, methodGetListIdPrametersTypes);

            // Assert
            parametersOfGetListId.ShouldNotBeNull();
            parametersOfGetListId.Length.ShouldBe(2);
            methodGetListIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListIdPrametersTypes = new Type[] { typeof(string), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListId, Fixture, methodGetListIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListIdPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListId, Fixture, methodGetListIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListId, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListId_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListId, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetTableName_Method_Call_Internally(Type[] types)
        {
            var methodGetTableNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetTableName(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetTableName = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableName, methodGetTableNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, string>(_ePMDataInstanceFixture, out exception1, parametersOfGetTableName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTableName.ShouldNotBeNull();
            parametersOfGetTableName.Length.ShouldBe(1);
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetTableName = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

            // Assert
            parametersOfGetTableName.ShouldNotBeNull();
            parametersOfGetTableName.Length.ShouldBe(1);
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTableName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetTableName_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetTableNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetTableName(listName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableName = { listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableName, methodGetTableNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, string>(_ePMDataInstanceFixture, out exception1, parametersOfGetTableName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTableName.ShouldNotBeNull();
            parametersOfGetTableName.Length.ShouldBe(1);
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableName = { listName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

            // Assert
            parametersOfGetTableName.ShouldNotBeNull();
            parametersOfGetTableName.Length.ShouldBe(1);
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableName, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetTableName_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTableName, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetListName_Method_Call_Internally(Type[] types)
        {
            var methodGetListNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListName, Fixture, methodGetListNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListName_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.GetListName(tableName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodGetListNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListName = { tableName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListName, methodGetListNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, string>(_ePMDataInstanceFixture, out exception1, parametersOfGetListName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetListName, parametersOfGetListName, methodGetListNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListName.ShouldNotBeNull();
            parametersOfGetListName.Length.ShouldBe(1);
            methodGetListNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodGetListNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListName = { tableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, string>(_ePMDataInstance, MethodGetListName, parametersOfGetListName, methodGetListNamePrametersTypes);

            // Assert
            parametersOfGetListName.ShouldNotBeNull();
            parametersOfGetListName.Length.ShouldBe(1);
            methodGetListNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListName, Fixture, methodGetListNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetListName, Fixture, methodGetListNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetListName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshTimesheets) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_RefreshTimesheets_Method_Call_Internally(Type[] types)
        {
            var methodRefreshTimesheetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodRefreshTimesheets, Fixture, methodRefreshTimesheetsPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshTimesheets) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshTimesheets_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sMessage = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var consolidationdone = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.RefreshTimesheets(out sMessage, jobUid, consolidationdone);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RefreshTimesheets) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshTimesheets_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sMessage = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var consolidationdone = CreateType<bool>();
            var methodRefreshTimesheetsPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(bool) };
            object[] parametersOfRefreshTimesheets = { sMessage, jobUid, consolidationdone };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRefreshTimesheets, methodRefreshTimesheetsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfRefreshTimesheets);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodRefreshTimesheets, parametersOfRefreshTimesheets, methodRefreshTimesheetsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRefreshTimesheets.ShouldNotBeNull();
            parametersOfRefreshTimesheets.Length.ShouldBe(3);
            methodRefreshTimesheetsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RefreshTimesheets) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshTimesheets_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sMessage = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var consolidationdone = CreateType<bool>();
            var methodRefreshTimesheetsPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(bool) };
            object[] parametersOfRefreshTimesheets = { sMessage, jobUid, consolidationdone };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRefreshTimesheets, methodRefreshTimesheetsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfRefreshTimesheets);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodRefreshTimesheets, parametersOfRefreshTimesheets, methodRefreshTimesheetsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRefreshTimesheets.ShouldNotBeNull();
            parametersOfRefreshTimesheets.Length.ShouldBe(3);
            methodRefreshTimesheetsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RefreshTimesheets) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshTimesheets_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sMessage = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var consolidationdone = CreateType<bool>();
            var methodRefreshTimesheetsPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(bool) };
            object[] parametersOfRefreshTimesheets = { sMessage, jobUid, consolidationdone };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodRefreshTimesheets, parametersOfRefreshTimesheets, methodRefreshTimesheetsPrametersTypes);

            // Assert
            parametersOfRefreshTimesheets.ShouldNotBeNull();
            parametersOfRefreshTimesheets.Length.ShouldBe(3);
            methodRefreshTimesheetsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshTimesheets) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshTimesheets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRefreshTimesheetsPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodRefreshTimesheets, Fixture, methodRefreshTimesheetsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRefreshTimesheetsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshTimesheets) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshTimesheets_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshTimesheets, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RefreshTimesheets) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_RefreshTimesheets_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRefreshTimesheets, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_SaveWork_Method_Call_Internally(Type[] types)
        {
            var methodSaveWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodSaveWork, Fixture, methodSaveWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SaveWork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.SaveWork(item);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SaveWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodSaveWorkPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfSaveWork = { item };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveWork, methodSaveWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfSaveWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodSaveWork, parametersOfSaveWork, methodSaveWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveWork.ShouldNotBeNull();
            parametersOfSaveWork.Length.ShouldBe(1);
            methodSaveWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SaveWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SaveWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodSaveWorkPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfSaveWork = { item };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveWork, methodSaveWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfSaveWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodSaveWork, parametersOfSaveWork, methodSaveWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveWork.ShouldNotBeNull();
            parametersOfSaveWork.Length.ShouldBe(1);
            methodSaveWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SaveWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SaveWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodSaveWorkPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfSaveWork = { item };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodSaveWork, parametersOfSaveWork, methodSaveWorkPrametersTypes);

            // Assert
            parametersOfSaveWork.ShouldNotBeNull();
            parametersOfSaveWork.Length.ShouldBe(1);
            methodSaveWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SaveWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveWorkPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodSaveWork, Fixture, methodSaveWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SaveWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_SaveWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveWork, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_ProcessAssignments_Method_Call_Internally(Type[] types)
        {
            var methodProcessAssignmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodProcessAssignments, Fixture, methodProcessAssignmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ProcessAssignments_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sWork = CreateType<string>();
            var sAssignedTo = CreateType<string>();
            var StartDate = CreateType<object>();
            var DueDate = CreateType<object>();
            var ListID = CreateType<Guid>();
            var SiteID = CreateType<Guid>();
            var ItemID = CreateType<int>();
            var sListName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.ProcessAssignments(sWork, sAssignedTo, StartDate, DueDate, ListID, SiteID, ItemID, sListName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ProcessAssignments_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sWork = CreateType<string>();
            var sAssignedTo = CreateType<string>();
            var StartDate = CreateType<object>();
            var DueDate = CreateType<object>();
            var ListID = CreateType<Guid>();
            var SiteID = CreateType<Guid>();
            var ItemID = CreateType<int>();
            var sListName = CreateType<string>();
            var methodProcessAssignmentsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(object), typeof(object), typeof(Guid), typeof(Guid), typeof(int), typeof(string) };
            object[] parametersOfProcessAssignments = { sWork, sAssignedTo, StartDate, DueDate, ListID, SiteID, ItemID, sListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProcessAssignments, methodProcessAssignmentsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfProcessAssignments);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodProcessAssignments, parametersOfProcessAssignments, methodProcessAssignmentsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfProcessAssignments.ShouldNotBeNull();
            parametersOfProcessAssignments.Length.ShouldBe(8);
            methodProcessAssignmentsPrametersTypes.Length.ShouldBe(8);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ProcessAssignments_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sWork = CreateType<string>();
            var sAssignedTo = CreateType<string>();
            var StartDate = CreateType<object>();
            var DueDate = CreateType<object>();
            var ListID = CreateType<Guid>();
            var SiteID = CreateType<Guid>();
            var ItemID = CreateType<int>();
            var sListName = CreateType<string>();
            var methodProcessAssignmentsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(object), typeof(object), typeof(Guid), typeof(Guid), typeof(int), typeof(string) };
            object[] parametersOfProcessAssignments = { sWork, sAssignedTo, StartDate, DueDate, ListID, SiteID, ItemID, sListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProcessAssignments, methodProcessAssignmentsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfProcessAssignments);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodProcessAssignments, parametersOfProcessAssignments, methodProcessAssignmentsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfProcessAssignments.ShouldNotBeNull();
            parametersOfProcessAssignments.Length.ShouldBe(8);
            methodProcessAssignmentsPrametersTypes.Length.ShouldBe(8);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ProcessAssignments_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sWork = CreateType<string>();
            var sAssignedTo = CreateType<string>();
            var StartDate = CreateType<object>();
            var DueDate = CreateType<object>();
            var ListID = CreateType<Guid>();
            var SiteID = CreateType<Guid>();
            var ItemID = CreateType<int>();
            var sListName = CreateType<string>();
            var methodProcessAssignmentsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(object), typeof(object), typeof(Guid), typeof(Guid), typeof(int), typeof(string) };
            object[] parametersOfProcessAssignments = { sWork, sAssignedTo, StartDate, DueDate, ListID, SiteID, ItemID, sListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodProcessAssignments, parametersOfProcessAssignments, methodProcessAssignmentsPrametersTypes);

            // Assert
            parametersOfProcessAssignments.ShouldNotBeNull();
            parametersOfProcessAssignments.Length.ShouldBe(8);
            methodProcessAssignmentsPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ProcessAssignments_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessAssignmentsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(object), typeof(object), typeof(Guid), typeof(Guid), typeof(int), typeof(string) };
            const int parametersCount = 8;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodProcessAssignments, Fixture, methodProcessAssignmentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessAssignmentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ProcessAssignments_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessAssignments, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ProcessAssignments_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessAssignments, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GetDbVersion_Method_Call_Internally(Type[] types)
        {
            var methodGetDbVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetDbVersion, Fixture, methodGetDbVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDbVersion_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDbVersionPrametersTypes = null;
            object[] parametersOfGetDbVersion = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDbVersion, methodGetDbVersionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, int>(_ePMDataInstanceFixture, out exception1, parametersOfGetDbVersion);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, int>(_ePMDataInstance, MethodGetDbVersion, parametersOfGetDbVersion, methodGetDbVersionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDbVersion.ShouldBeNull();
            methodGetDbVersionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDbVersion_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetDbVersionPrametersTypes = null;
            object[] parametersOfGetDbVersion = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDbVersion, methodGetDbVersionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, int>(_ePMDataInstanceFixture, out exception1, parametersOfGetDbVersion);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, int>(_ePMDataInstance, MethodGetDbVersion, parametersOfGetDbVersion, methodGetDbVersionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDbVersion.ShouldBeNull();
            methodGetDbVersionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDbVersion_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDbVersionPrametersTypes = null;
            object[] parametersOfGetDbVersion = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, int>(_ePMDataInstance, MethodGetDbVersion, parametersOfGetDbVersion, methodGetDbVersionPrametersTypes);

            // Assert
            parametersOfGetDbVersion.ShouldBeNull();
            methodGetDbVersionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDbVersion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDbVersionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGetDbVersion, Fixture, methodGetDbVersionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDbVersionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GetDbVersion_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDbVersion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MapDataBase) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_MapDataBase_Method_Call_Internally(Type[] types)
        {
            var methodMapDataBasePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodMapDataBase, Fixture, methodMapDataBasePrametersTypes);
        }

        #endregion

        #region Method Call : (MapDataBase) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDataBase_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var serverName = CreateType<string>();
            var dataBaseName = CreateType<string>();
            var un = CreateType<string>();
            var pw = CreateType<string>();
            var useSA = CreateType<bool>();
            var dbExists = CreateType<bool>();
            var status = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.MapDataBase(siteId, webId, serverName, dataBaseName, un, pw, useSA, dbExists, out status);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (MapDataBase) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDataBase_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var serverName = CreateType<string>();
            var dataBaseName = CreateType<string>();
            var un = CreateType<string>();
            var pw = CreateType<string>();
            var useSA = CreateType<bool>();
            var dbExists = CreateType<bool>();
            var status = CreateType<string>();
            var methodMapDataBasePrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfMapDataBase = { siteId, webId, serverName, dataBaseName, un, pw, useSA, dbExists, status };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMapDataBase, methodMapDataBasePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfMapDataBase);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodMapDataBase, parametersOfMapDataBase, methodMapDataBasePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMapDataBase.ShouldNotBeNull();
            parametersOfMapDataBase.Length.ShouldBe(9);
            methodMapDataBasePrametersTypes.Length.ShouldBe(9);
        }

        #endregion

        #region Method Call : (MapDataBase) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDataBase_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var serverName = CreateType<string>();
            var dataBaseName = CreateType<string>();
            var un = CreateType<string>();
            var pw = CreateType<string>();
            var useSA = CreateType<bool>();
            var dbExists = CreateType<bool>();
            var status = CreateType<string>();
            var methodMapDataBasePrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfMapDataBase = { siteId, webId, serverName, dataBaseName, un, pw, useSA, dbExists, status };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMapDataBase, methodMapDataBasePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfMapDataBase);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodMapDataBase, parametersOfMapDataBase, methodMapDataBasePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMapDataBase.ShouldNotBeNull();
            parametersOfMapDataBase.Length.ShouldBe(9);
            methodMapDataBasePrametersTypes.Length.ShouldBe(9);
        }

        #endregion

        #region Method Call : (MapDataBase) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDataBase_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var serverName = CreateType<string>();
            var dataBaseName = CreateType<string>();
            var un = CreateType<string>();
            var pw = CreateType<string>();
            var useSA = CreateType<bool>();
            var dbExists = CreateType<bool>();
            var status = CreateType<string>();
            var methodMapDataBasePrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfMapDataBase = { siteId, webId, serverName, dataBaseName, un, pw, useSA, dbExists, status };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodMapDataBase, parametersOfMapDataBase, methodMapDataBasePrametersTypes);

            // Assert
            parametersOfMapDataBase.ShouldNotBeNull();
            parametersOfMapDataBase.Length.ShouldBe(9);
            methodMapDataBasePrametersTypes.Length.ShouldBe(9);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapDataBase) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDataBase_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMapDataBasePrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            const int parametersCount = 9;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodMapDataBase, Fixture, methodMapDataBasePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMapDataBasePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MapDataBase) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDataBase_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMapDataBase, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MapDataBase) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_MapDataBase_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMapDataBase, 0);
            const int parametersCount = 9;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrantUserDbAccess) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_GrantUserDbAccess_Method_Call_Internally(Type[] types)
        {
            var methodGrantUserDbAccessPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGrantUserDbAccess, Fixture, methodGrantUserDbAccessPrametersTypes);
        }

        #endregion

        #region Method Call : (GrantUserDbAccess) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GrantUserDbAccess_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGrantUserDbAccessPrametersTypes = null;
            object[] parametersOfGrantUserDbAccess = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGrantUserDbAccess, methodGrantUserDbAccessPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfGrantUserDbAccess);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodGrantUserDbAccess, parametersOfGrantUserDbAccess, methodGrantUserDbAccessPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGrantUserDbAccess.ShouldBeNull();
            methodGrantUserDbAccessPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GrantUserDbAccess) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GrantUserDbAccess_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGrantUserDbAccessPrametersTypes = null;
            object[] parametersOfGrantUserDbAccess = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGrantUserDbAccess, methodGrantUserDbAccessPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfGrantUserDbAccess);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodGrantUserDbAccess, parametersOfGrantUserDbAccess, methodGrantUserDbAccessPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGrantUserDbAccess.ShouldBeNull();
            methodGrantUserDbAccessPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GrantUserDbAccess) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GrantUserDbAccess_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGrantUserDbAccessPrametersTypes = null;
            object[] parametersOfGrantUserDbAccess = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodGrantUserDbAccess, parametersOfGrantUserDbAccess, methodGrantUserDbAccessPrametersTypes);

            // Assert
            parametersOfGrantUserDbAccess.ShouldBeNull();
            methodGrantUserDbAccessPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrantUserDbAccess) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GrantUserDbAccess_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGrantUserDbAccessPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodGrantUserDbAccess, Fixture, methodGrantUserDbAccessPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGrantUserDbAccessPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GrantUserDbAccess) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_GrantUserDbAccess_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrantUserDbAccess, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_ListMappedAlready_Method_Call_Internally(Type[] types)
        {
            var methodListMappedAlreadyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodListMappedAlready, Fixture, methodListMappedAlreadyPrametersTypes);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.ListMappedAlready(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodListMappedAlreadyPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfListMappedAlready = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListMappedAlready, methodListMappedAlreadyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfListMappedAlready);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodListMappedAlready, parametersOfListMappedAlready, methodListMappedAlreadyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfListMappedAlready.ShouldNotBeNull();
            parametersOfListMappedAlready.Length.ShouldBe(1);
            methodListMappedAlreadyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodListMappedAlreadyPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfListMappedAlready = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListMappedAlready, methodListMappedAlreadyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfListMappedAlready);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodListMappedAlready, parametersOfListMappedAlready, methodListMappedAlreadyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfListMappedAlready.ShouldNotBeNull();
            parametersOfListMappedAlready.Length.ShouldBe(1);
            methodListMappedAlreadyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodListMappedAlreadyPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfListMappedAlready = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodListMappedAlready, parametersOfListMappedAlready, methodListMappedAlreadyPrametersTypes);

            // Assert
            parametersOfListMappedAlready.ShouldNotBeNull();
            parametersOfListMappedAlready.Length.ShouldBe(1);
            methodListMappedAlreadyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListMappedAlreadyPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodListMappedAlready, Fixture, methodListMappedAlreadyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodListMappedAlreadyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListMappedAlready, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListMappedAlready, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_ListMappedAlready_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodListMappedAlreadyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodListMappedAlready, Fixture, methodListMappedAlreadyPrametersTypes);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var siteId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.ListMappedAlready(sListName, siteId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var siteId = CreateType<Guid>();
            var methodListMappedAlreadyPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfListMappedAlready = { sListName, siteId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListMappedAlready, methodListMappedAlreadyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfListMappedAlready);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodListMappedAlready, parametersOfListMappedAlready, methodListMappedAlreadyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfListMappedAlready.ShouldNotBeNull();
            parametersOfListMappedAlready.Length.ShouldBe(2);
            methodListMappedAlreadyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var siteId = CreateType<Guid>();
            var methodListMappedAlreadyPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfListMappedAlready = { sListName, siteId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListMappedAlready, methodListMappedAlreadyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfListMappedAlready);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodListMappedAlready, parametersOfListMappedAlready, methodListMappedAlreadyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfListMappedAlready.ShouldNotBeNull();
            parametersOfListMappedAlready.Length.ShouldBe(2);
            methodListMappedAlreadyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var siteId = CreateType<Guid>();
            var methodListMappedAlreadyPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfListMappedAlready = { sListName, siteId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodListMappedAlready, parametersOfListMappedAlready, methodListMappedAlreadyPrametersTypes);

            // Assert
            parametersOfListMappedAlready.ShouldNotBeNull();
            parametersOfListMappedAlready.Length.ShouldBe(2);
            methodListMappedAlreadyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListMappedAlreadyPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodListMappedAlready, Fixture, methodListMappedAlreadyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodListMappedAlreadyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListMappedAlready, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ListMappedAlready) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ListMappedAlready_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListMappedAlready, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateRPTSettings) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_UpdateRPTSettings_Method_Call_Internally(Type[] types)
        {
            var methodUpdateRPTSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodUpdateRPTSettings, Fixture, methodUpdateRPTSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateRPTSettings) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateRPTSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var nonWorkingDays = CreateType<string>();
            var workHrs = CreateType<int>();
            var sResult = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMDataInstance.UpdateRPTSettings(nonWorkingDays, workHrs, out sResult);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateRPTSettings) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateRPTSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var nonWorkingDays = CreateType<string>();
            var workHrs = CreateType<int>();
            var sResult = CreateType<string>();
            var methodUpdateRPTSettingsPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfUpdateRPTSettings = { nonWorkingDays, workHrs, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateRPTSettings, methodUpdateRPTSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfUpdateRPTSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodUpdateRPTSettings, parametersOfUpdateRPTSettings, methodUpdateRPTSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateRPTSettings.ShouldNotBeNull();
            parametersOfUpdateRPTSettings.Length.ShouldBe(3);
            methodUpdateRPTSettingsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateRPTSettings) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateRPTSettings_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var nonWorkingDays = CreateType<string>();
            var workHrs = CreateType<int>();
            var sResult = CreateType<string>();
            var methodUpdateRPTSettingsPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfUpdateRPTSettings = { nonWorkingDays, workHrs, sResult };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateRPTSettings, methodUpdateRPTSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfUpdateRPTSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodUpdateRPTSettings, parametersOfUpdateRPTSettings, methodUpdateRPTSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateRPTSettings.ShouldNotBeNull();
            parametersOfUpdateRPTSettings.Length.ShouldBe(3);
            methodUpdateRPTSettingsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateRPTSettings) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateRPTSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nonWorkingDays = CreateType<string>();
            var workHrs = CreateType<int>();
            var sResult = CreateType<string>();
            var methodUpdateRPTSettingsPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfUpdateRPTSettings = { nonWorkingDays, workHrs, sResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodUpdateRPTSettings, parametersOfUpdateRPTSettings, methodUpdateRPTSettingsPrametersTypes);

            // Assert
            parametersOfUpdateRPTSettings.ShouldNotBeNull();
            parametersOfUpdateRPTSettings.Length.ShouldBe(3);
            methodUpdateRPTSettingsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateRPTSettings) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateRPTSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateRPTSettingsPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodUpdateRPTSettings, Fixture, methodUpdateRPTSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateRPTSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateRPTSettings) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateRPTSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateRPTSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateRPTSettings) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_UpdateRPTSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateRPTSettings, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_Encrypt_Static_Method_Call_Internally(Type[] types)
        {
            var methodEncryptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Encrypt_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var plaintext = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EPMData.Encrypt(plaintext);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Encrypt_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var plaintext = CreateType<string>();
            var methodEncryptPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEncrypt = { plaintext };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEncrypt, methodEncryptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfEncrypt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEncrypt.ShouldNotBeNull();
            parametersOfEncrypt.Length.ShouldBe(1);
            methodEncryptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Encrypt_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var plaintext = CreateType<string>();
            var methodEncryptPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEncrypt = { plaintext };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodEncrypt, parametersOfEncrypt, methodEncryptPrametersTypes);

            // Assert
            parametersOfEncrypt.ShouldNotBeNull();
            parametersOfEncrypt.Length.ShouldBe(1);
            methodEncryptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Encrypt_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodEncryptPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodEncryptPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Encrypt_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEncryptPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEncryptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Encrypt_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEncrypt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Encrypt_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEncrypt, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_Decrypt_Static_Method_Call_Internally(Type[] types)
        {
            var methodDecryptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Decrypt_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var base64Text = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EPMData.Decrypt(base64Text);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Decrypt_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var base64Text = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecrypt = { base64Text };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDecrypt, methodDecryptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMDataInstanceFixture, parametersOfDecrypt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(1);
            methodDecryptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Decrypt_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var base64Text = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecrypt = { base64Text };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodDecrypt, parametersOfDecrypt, methodDecryptPrametersTypes);

            // Assert
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(1);
            methodDecryptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Decrypt_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecryptPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Decrypt_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMDataInstanceFixture, _ePMDataInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecryptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Decrypt_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecrypt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_Decrypt_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecrypt, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMData_ItemHasValue_Method_Call_Internally(Type[] types)
        {
            var methodItemHasValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodItemHasValue, Fixture, methodItemHasValuePrametersTypes);
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ItemHasValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var fldName = CreateType<string>();
            var methodItemHasValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfItemHasValue = { item, fldName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodItemHasValue, methodItemHasValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfItemHasValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodItemHasValue, parametersOfItemHasValue, methodItemHasValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfItemHasValue.ShouldNotBeNull();
            parametersOfItemHasValue.Length.ShouldBe(2);
            methodItemHasValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ItemHasValue_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var fldName = CreateType<string>();
            var methodItemHasValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfItemHasValue = { item, fldName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodItemHasValue, methodItemHasValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMData, bool>(_ePMDataInstanceFixture, out exception1, parametersOfItemHasValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodItemHasValue, parametersOfItemHasValue, methodItemHasValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfItemHasValue.ShouldNotBeNull();
            parametersOfItemHasValue.Length.ShouldBe(2);
            methodItemHasValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ItemHasValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var fldName = CreateType<string>();
            var methodItemHasValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfItemHasValue = { item, fldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMData, bool>(_ePMDataInstance, MethodItemHasValue, parametersOfItemHasValue, methodItemHasValuePrametersTypes);

            // Assert
            parametersOfItemHasValue.ShouldNotBeNull();
            parametersOfItemHasValue.Length.ShouldBe(2);
            methodItemHasValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ItemHasValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemHasValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMDataInstance, MethodItemHasValue, Fixture, methodItemHasValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodItemHasValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ItemHasValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemHasValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMData_ItemHasValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemHasValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportHelper.ReportData" />)
    ///     and namespace <see cref="EPMLiveCore.ReportHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ReportDataTest : AbstractBaseSetupTypedTest<ReportData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportData) Initializer

        private const string PropertySiteName = "SiteName";
        private const string PropertyEPMLiveConOpen = "EPMLiveConOpen";
        private const string PropertyUserName = "UserName";
        private const string PropertyPassword = "Password";
        private const string PropertyUseSqlAccount = "UseSqlAccount";
        private const string PropertySiteUrl = "SiteUrl";
        private const string PropertyCommand = "Command";
        private const string MethodCreateTextFile = "CreateTextFile";
        private const string MethodWriteToFile = "WriteToFile";
        private const string MethodDeleteExistingTSData = "DeleteExistingTSData";
        private const string MethodGetSite = "GetSite";
        private const string MethodExecuteNonQuery = "ExecuteNonQuery";
        private const string MethodCheckServerConnection = "CheckServerConnection";
        private const string MethodDatabaseExists = "DatabaseExists";
        private const string MethodIsReportingDB = "IsReportingDB";
        private const string MethodTableExists = "TableExists";
        private const string MethodColumnExists = "ColumnExists";
        private const string MethodProcedureExists = "ProcedureExists";
        private const string MethodGetError = "GetError";
        private const string MethodCreateDatabase = "CreateDatabase";
        private const string MethodGetTableNames = "GetTableNames";
        private const string MethodGetSafeTableName = "GetSafeTableName";
        private const string MethodGetTableCount = "GetTableCount";
        private const string MethodCreateTable = "CreateTable";
        private const string MethodDeleteTable = "DeleteTable";
        private const string MethodAddColumns = "AddColumns";
        private const string MethodUpdateColumns = "UpdateColumns";
        private const string MethodDeleteColumns = "DeleteColumns";
        private const string MethodInsertDbEntry = "InsertDbEntry";
        private const string MethodDeleteDbEntry = "DeleteDbEntry";
        private const string MethodGetDbVersion = "GetDbVersion";
        private const string MethodGetDbMappings = "GetDbMappings";
        private const string MethodGetExistingDbCount = "GetExistingDbCount";
        private const string MethodGetDistinctDbMappings = "GetDistinctDbMappings";
        private const string MethodGetListMappings = "GetListMappings";
        private const string MethodGetListMapping = "GetListMapping";
        private const string MethodInitializeDatabase = "InitializeDatabase";
        private const string MethodInsertList = "InsertList";
        private const string MethodUpdateList = "UpdateList";
        private const string MethodDeleteList = "DeleteList";
        private const string MethodDeleteAllListColumns = "DeleteAllListColumns";
        private const string MethodDeleteListColumns = "DeleteListColumns";
        private const string MethodDeleteWork = "DeleteWork";
        private const string MethodDeleteMyWork = "DeleteMyWork";
        private const string MethodInsertListColumns = "InsertListColumns";
        private const string MethodUpdateListColumns = "UpdateListColumns";
        private const string MethodInsertLog = "InsertLog";
        private const string MethodGetLog = "GetLog";
        private const string MethodGetMaximumLogLevel = "GetMaximumLogLevel";
        private const string MethodDeleteLog = "DeleteLog";
        private const string MethodGetTableNameSnapshot = "GetTableNameSnapshot";
        private const string MethodGetTSAllDataWithSchema = "GetTSAllDataWithSchema";
        private const string MethodInsertTSAllData = "InsertTSAllData";
        private const string MethodRefreshTimeSheet = "RefreshTimeSheet";
        private const string MethodGetTableName = "GetTableName";
        private const string MethodInsertSQL = "InsertSQL";
        private const string MethodUpdateSQL = "UpdateSQL";
        private const string MethodDeleteSQL = "DeleteSQL";
        private const string MethodGetListColumns = "GetListColumns";
        private const string MethodVerifyListColumns = "VerifyListColumns";
        private const string MethodListReportsWork = "ListReportsWork";
        private const string MethodDispose = "Dispose";
        private const string MethodBulkInsert = "BulkInsert";
        private const string MethodReportError = "ReportError";
        private const string MethodGetMappedFields = "GetMappedFields";
        private const string MethodLogStatus = "LogStatus";
        private const string MethodProcessAssignments = "ProcessAssignments";
        private const string MethodInsertListItem = "InsertListItem";
        private const string MethodUpdateListItem = "UpdateListItem";
        private const string MethodDeleteListItem = "DeleteListItem";
        private const string MethodAddColums = "AddColums";
        private const string MethodIsLookUpField = "IsLookUpField";
        private const string MethodAddLookUpFieldValues = "AddLookUpFieldValues";
        private const string MethodAddMultiChoiceValues = "AddMultiChoiceValues";
        private const string MethodAddColumnValues = "AddColumnValues";
        private const string MethodRemoveTags = "RemoveTags";
        private const string MethodGetListId = "GetListId";
        private const string MethodPopulateDefaultColumnValue = "PopulateDefaultColumnValue";
        private const string MethodPopulateMandatoryHiddenFldsColumnValue = "PopulateMandatoryHiddenFldsColumnValue";
        private const string MethodGetParam = "GetParam";
        private const string MethodInsertAllItemsDB = "InsertAllItemsDB";
        private const string MethodGetClientReportingConnection = "GetClientReportingConnection";
        private const string MethodGetDefaultColumnValue = "GetDefaultColumnValue";
        private const string MethodListItemsDataTable = "ListItemsDataTable";
        private const string MethodMyWorkListItemsDataTable = "MyWorkListItemsDataTable";
        private const string MethodAddMetaInfoCols = "AddMetaInfoCols";
        private const string MethodSnapshotLists = "SnapshotLists";
        private const string MethodInitializeStatusLog = "InitializeStatusLog";
        private const string MethodGetStatusLog = "GetStatusLog";
        private const string MethodItemHasValue = "ItemHasValue";
        private const string MethodGetFieldType = "GetFieldType";
        private const string MethodUpdateItem = "UpdateItem";
        private const string Field_epmLiveCs = "_epmLiveCs";
        private const string Field_siteId = "_siteId";
        private const string Field_webId = "_webId";
        private const string FieldwebTitle = "webTitle";
        private const string Field_DAO = "_DAO";
        private const string Field_cmdWithParams = "_cmdWithParams";
        private const string Field_isReportingV2Enabled = "_isReportingV2Enabled";
        private const string Field_isRootWeb = "_isRootWeb";
        private const string Field_params = "_params";
        private const string Field_siteName = "_siteName";
        private const string Field_siteUrl = "_siteUrl";
        private const string Field_sqlError = "_sqlError";
        private Type _reportDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportData _reportDataInstance;
        private ReportData _reportDataInstanceFixture;

        #region General Initializer : Class (ReportData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportDataInstanceType = typeof(ReportData);
            _reportDataInstanceFixture = Create(true);
            _reportDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportData)

        #region General Initializer : Class (ReportData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateTextFile, 0)]
        [TestCase(MethodWriteToFile, 0)]
        [TestCase(MethodDeleteExistingTSData, 0)]
        [TestCase(MethodGetSite, 0)]
        [TestCase(MethodExecuteNonQuery, 0)]
        [TestCase(MethodCheckServerConnection, 0)]
        [TestCase(MethodDatabaseExists, 0)]
        [TestCase(MethodIsReportingDB, 0)]
        [TestCase(MethodTableExists, 0)]
        [TestCase(MethodColumnExists, 0)]
        [TestCase(MethodProcedureExists, 0)]
        [TestCase(MethodGetError, 0)]
        [TestCase(MethodCreateDatabase, 0)]
        [TestCase(MethodGetTableNames, 0)]
        [TestCase(MethodGetSafeTableName, 0)]
        [TestCase(MethodGetTableCount, 0)]
        [TestCase(MethodCreateTable, 0)]
        [TestCase(MethodCreateTable, 1)]
        [TestCase(MethodDeleteTable, 0)]
        [TestCase(MethodAddColumns, 0)]
        [TestCase(MethodUpdateColumns, 0)]
        [TestCase(MethodDeleteColumns, 0)]
        [TestCase(MethodInsertDbEntry, 0)]
        [TestCase(MethodDeleteDbEntry, 0)]
        [TestCase(MethodGetDbVersion, 0)]
        [TestCase(MethodGetDbMappings, 0)]
        [TestCase(MethodGetExistingDbCount, 0)]
        [TestCase(MethodGetDistinctDbMappings, 0)]
        [TestCase(MethodGetListMappings, 0)]
        [TestCase(MethodGetListMappings, 1)]
        [TestCase(MethodGetListMapping, 0)]
        [TestCase(MethodInitializeDatabase, 0)]
        [TestCase(MethodInsertList, 0)]
        [TestCase(MethodUpdateList, 0)]
        [TestCase(MethodDeleteList, 0)]
        [TestCase(MethodDeleteAllListColumns, 0)]
        [TestCase(MethodDeleteListColumns, 0)]
        [TestCase(MethodDeleteWork, 0)]
        [TestCase(MethodDeleteWork, 1)]
        [TestCase(MethodDeleteMyWork, 0)]
        [TestCase(MethodInsertListColumns, 0)]
        [TestCase(MethodUpdateListColumns, 0)]
        [TestCase(MethodInsertLog, 0)]
        [TestCase(MethodGetLog, 0)]
        [TestCase(MethodGetMaximumLogLevel, 0)]
        [TestCase(MethodDeleteLog, 0)]
        [TestCase(MethodDeleteLog, 1)]
        [TestCase(MethodGetTableNameSnapshot, 0)]
        [TestCase(MethodGetTSAllDataWithSchema, 0)]
        [TestCase(MethodInsertTSAllData, 0)]
        [TestCase(MethodRefreshTimeSheet, 0)]
        [TestCase(MethodGetTableName, 0)]
        [TestCase(MethodGetTableName, 1)]
        [TestCase(MethodInsertSQL, 0)]
        [TestCase(MethodUpdateSQL, 0)]
        [TestCase(MethodDeleteSQL, 0)]
        [TestCase(MethodGetListColumns, 0)]
        [TestCase(MethodVerifyListColumns, 0)]
        [TestCase(MethodGetListColumns, 1)]
        [TestCase(MethodListReportsWork, 0)]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodBulkInsert, 0)]
        [TestCase(MethodReportError, 0)]
        [TestCase(MethodGetMappedFields, 0)]
        [TestCase(MethodLogStatus, 0)]
        [TestCase(MethodProcessAssignments, 0)]
        [TestCase(MethodInsertListItem, 0)]
        [TestCase(MethodUpdateListItem, 0)]
        [TestCase(MethodDeleteListItem, 0)]
        [TestCase(MethodAddColums, 0)]
        [TestCase(MethodAddColums, 1)]
        [TestCase(MethodIsLookUpField, 0)]
        [TestCase(MethodAddLookUpFieldValues, 0)]
        [TestCase(MethodAddMultiChoiceValues, 0)]
        [TestCase(MethodAddColumnValues, 0)]
        [TestCase(MethodAddColumnValues, 1)]
        [TestCase(MethodRemoveTags, 0)]
        [TestCase(MethodGetListId, 0)]
        [TestCase(MethodPopulateDefaultColumnValue, 0)]
        [TestCase(MethodPopulateMandatoryHiddenFldsColumnValue, 0)]
        [TestCase(MethodGetParam, 0)]
        [TestCase(MethodInsertAllItemsDB, 0)]
        [TestCase(MethodGetClientReportingConnection, 0)]
        [TestCase(MethodGetDefaultColumnValue, 0)]
        [TestCase(MethodListItemsDataTable, 0)]
        [TestCase(MethodMyWorkListItemsDataTable, 0)]
        [TestCase(MethodAddMetaInfoCols, 0)]
        [TestCase(MethodSnapshotLists, 0)]
        [TestCase(MethodInitializeStatusLog, 0)]
        [TestCase(MethodLogStatus, 1)]
        [TestCase(MethodLogStatus, 2)]
        [TestCase(MethodGetStatusLog, 0)]
        [TestCase(MethodItemHasValue, 0)]
        [TestCase(MethodGetFieldType, 0)]
        [TestCase(MethodUpdateItem, 0)]
        public void AUT_ReportData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportData) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportData" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertySiteName)]
        [TestCase(PropertyEPMLiveConOpen)]
        [TestCase(PropertyUserName)]
        [TestCase(PropertyPassword)]
        [TestCase(PropertyUseSqlAccount)]
        [TestCase(PropertySiteUrl)]
        [TestCase(PropertyCommand)]
        public void AUT_ReportData_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportDataInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_epmLiveCs)]
        [TestCase(Field_siteId)]
        [TestCase(Field_webId)]
        [TestCase(FieldwebTitle)]
        [TestCase(Field_DAO)]
        [TestCase(Field_cmdWithParams)]
        [TestCase(Field_isReportingV2Enabled)]
        [TestCase(Field_isRootWeb)]
        [TestCase(Field_params)]
        [TestCase(Field_siteName)]
        [TestCase(Field_siteUrl)]
        [TestCase(Field_sqlError)]
        public void AUT_ReportData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportDataInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportData) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ReportData" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void AUT_ReportData_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ReportData>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ReportData) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportData_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ReportData>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ReportData) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportData_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var tmp = CreateType<bool>();
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            object[] parametersOfReportData = { tmp, siteId, webId };
            var methodReportDataPrametersTypes = new Type[] { typeof(bool), typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_reportDataInstanceType, methodReportDataPrametersTypes, parametersOfReportData);
        }

        #endregion

        #region General Constructor : Class (ReportData) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportData_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodReportDataPrametersTypes = new Type[] { typeof(bool), typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_reportDataInstanceType, Fixture, methodReportDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ReportData) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportData_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            object[] parametersOfReportData = { siteId, webAppId };
            var methodReportDataPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_reportDataInstanceType, methodReportDataPrametersTypes, parametersOfReportData);
        }

        #endregion

        #region General Constructor : Class (ReportData) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportData_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodReportDataPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_reportDataInstanceType, Fixture, methodReportDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ReportData) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportData_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            object[] parametersOfReportData = { siteId };
            var methodReportDataPrametersTypes = new Type[] { typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_reportDataInstanceType, methodReportDataPrametersTypes, parametersOfReportData);
        }

        #endregion

        #region General Constructor : Class (ReportData) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportData_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodReportDataPrametersTypes = new Type[] { typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_reportDataInstanceType, Fixture, methodReportDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ReportData) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportData_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var name = CreateType<string>();
            var server = CreateType<string>();
            var useSAccount = CreateType<bool>();
            var username = CreateType<string>();
            var password = CreateType<string>();
            object[] parametersOfReportData = { siteId, name, server, useSAccount, username, password };
            var methodReportDataPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_reportDataInstanceType, methodReportDataPrametersTypes, parametersOfReportData);
        }

        #endregion

        #region General Constructor : Class (ReportData) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportData_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodReportDataPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_reportDataInstanceType, Fixture, methodReportDataPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportData) => Property (Command) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportData_Public_Class_Command_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportData) => Property (EPMLiveConOpen) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportData_Public_Class_EPMLiveConOpen_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportData) => Property (Password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportData_Public_Class_Password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportData) => Property (SiteName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportData_Public_Class_SiteName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportData) => Property (SiteUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportData_Public_Class_SiteUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportData) => Property (UserName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportData_Public_Class_UserName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportData) => Property (UseSqlAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportData_Public_Class_UseSqlAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///     Class (<see cref="ReportData" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddLookUpFieldValues)]
        [TestCase(MethodAddMultiChoiceValues)]
        [TestCase(MethodGetParam)]
        public void AUT_ReportData_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportDataInstanceFixture,
                                                                              _reportDataInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateTextFile)]
        [TestCase(MethodWriteToFile)]
        [TestCase(MethodDeleteExistingTSData)]
        [TestCase(MethodGetSite)]
        [TestCase(MethodExecuteNonQuery)]
        [TestCase(MethodCheckServerConnection)]
        [TestCase(MethodDatabaseExists)]
        [TestCase(MethodIsReportingDB)]
        [TestCase(MethodTableExists)]
        [TestCase(MethodColumnExists)]
        [TestCase(MethodProcedureExists)]
        [TestCase(MethodGetError)]
        [TestCase(MethodCreateDatabase)]
        [TestCase(MethodGetTableNames)]
        [TestCase(MethodGetSafeTableName)]
        [TestCase(MethodGetTableCount)]
        [TestCase(MethodCreateTable)]
        [TestCase(MethodDeleteTable)]
        [TestCase(MethodAddColumns)]
        [TestCase(MethodUpdateColumns)]
        [TestCase(MethodDeleteColumns)]
        [TestCase(MethodInsertDbEntry)]
        [TestCase(MethodDeleteDbEntry)]
        [TestCase(MethodGetDbVersion)]
        [TestCase(MethodGetDbMappings)]
        [TestCase(MethodGetExistingDbCount)]
        [TestCase(MethodGetDistinctDbMappings)]
        [TestCase(MethodGetListMappings)]
        [TestCase(MethodGetListMapping)]
        [TestCase(MethodInitializeDatabase)]
        [TestCase(MethodInsertList)]
        [TestCase(MethodUpdateList)]
        [TestCase(MethodDeleteList)]
        [TestCase(MethodDeleteAllListColumns)]
        [TestCase(MethodDeleteListColumns)]
        [TestCase(MethodDeleteWork)]
        [TestCase(MethodDeleteMyWork)]
        [TestCase(MethodInsertListColumns)]
        [TestCase(MethodUpdateListColumns)]
        [TestCase(MethodInsertLog)]
        [TestCase(MethodGetLog)]
        [TestCase(MethodGetMaximumLogLevel)]
        [TestCase(MethodDeleteLog)]
        [TestCase(MethodGetTableNameSnapshot)]
        [TestCase(MethodGetTSAllDataWithSchema)]
        [TestCase(MethodInsertTSAllData)]
        [TestCase(MethodRefreshTimeSheet)]
        [TestCase(MethodGetTableName)]
        [TestCase(MethodInsertSQL)]
        [TestCase(MethodUpdateSQL)]
        [TestCase(MethodDeleteSQL)]
        [TestCase(MethodGetListColumns)]
        [TestCase(MethodVerifyListColumns)]
        [TestCase(MethodListReportsWork)]
        [TestCase(MethodDispose)]
        [TestCase(MethodBulkInsert)]
        [TestCase(MethodReportError)]
        [TestCase(MethodGetMappedFields)]
        [TestCase(MethodLogStatus)]
        [TestCase(MethodProcessAssignments)]
        [TestCase(MethodInsertListItem)]
        [TestCase(MethodUpdateListItem)]
        [TestCase(MethodDeleteListItem)]
        [TestCase(MethodAddColums)]
        [TestCase(MethodIsLookUpField)]
        [TestCase(MethodAddColumnValues)]
        [TestCase(MethodRemoveTags)]
        [TestCase(MethodGetListId)]
        [TestCase(MethodPopulateDefaultColumnValue)]
        [TestCase(MethodPopulateMandatoryHiddenFldsColumnValue)]
        [TestCase(MethodInsertAllItemsDB)]
        [TestCase(MethodGetClientReportingConnection)]
        [TestCase(MethodGetDefaultColumnValue)]
        [TestCase(MethodListItemsDataTable)]
        [TestCase(MethodMyWorkListItemsDataTable)]
        [TestCase(MethodAddMetaInfoCols)]
        [TestCase(MethodSnapshotLists)]
        [TestCase(MethodInitializeStatusLog)]
        [TestCase(MethodGetStatusLog)]
        [TestCase(MethodItemHasValue)]
        [TestCase(MethodGetFieldType)]
        [TestCase(MethodUpdateItem)]
        public void AUT_ReportData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_CreateTextFile_Method_Call_Internally(Type[] types)
        {
            var methodCreateTextFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCreateTextFile, Fixture, methodCreateTextFilePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTextFile_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sPath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.CreateTextFile(sPath);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTextFile_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sPath = CreateType<string>();
            var methodCreateTextFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateTextFile = { sPath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateTextFile, methodCreateTextFilePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfCreateTextFile);

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
        public void AUT_ReportData_CreateTextFile_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sPath = CreateType<string>();
            var methodCreateTextFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateTextFile = { sPath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportDataInstance, MethodCreateTextFile, parametersOfCreateTextFile, methodCreateTextFilePrametersTypes);

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
        public void AUT_ReportData_CreateTextFile_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportData_CreateTextFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateTextFilePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCreateTextFile, Fixture, methodCreateTextFilePrametersTypes);

            // Assert
            methodCreateTextFilePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTextFile) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTextFile_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateTextFile, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_WriteToFile_Method_Call_Internally(Type[] types)
        {
            var methodWriteToFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodWriteToFile, Fixture, methodWriteToFilePrametersTypes);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_WriteToFile_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.WriteToFile(sText);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_WriteToFile_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            var methodWriteToFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfWriteToFile = { sText };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteToFile, methodWriteToFilePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfWriteToFile);

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
        public void AUT_ReportData_WriteToFile_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            var methodWriteToFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfWriteToFile = { sText };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportDataInstance, MethodWriteToFile, parametersOfWriteToFile, methodWriteToFilePrametersTypes);

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
        public void AUT_ReportData_WriteToFile_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportData_WriteToFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteToFilePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodWriteToFile, Fixture, methodWriteToFilePrametersTypes);

            // Assert
            methodWriteToFilePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteToFile) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_WriteToFile_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteToFile, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteExistingTSData_Method_Call_Internally(Type[] types)
        {
            var methodDeleteExistingTSDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteExistingTSData, Fixture, methodDeleteExistingTSDataPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteExistingTSData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteExistingTSData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteExistingTSData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodDeleteExistingTSDataPrametersTypes = null;
            object[] parametersOfDeleteExistingTSData = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteExistingTSData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteExistingTSData, parametersOfDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes);

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
        public void AUT_ReportData_DeleteExistingTSData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodDeleteExistingTSDataPrametersTypes = null;
            object[] parametersOfDeleteExistingTSData = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteExistingTSData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteExistingTSData, parametersOfDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes);

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
        public void AUT_ReportData_DeleteExistingTSData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDeleteExistingTSDataPrametersTypes = null;
            object[] parametersOfDeleteExistingTSData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteExistingTSData, parametersOfDeleteExistingTSData, methodDeleteExistingTSDataPrametersTypes);

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
        public void AUT_ReportData_DeleteExistingTSData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDeleteExistingTSDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteExistingTSData, Fixture, methodDeleteExistingTSDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteExistingTSDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteExistingTSData) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteExistingTSData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteExistingTSData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetSite_Method_Call_Internally(Type[] types)
        {
            var methodGetSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetSite, Fixture, methodGetSitePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetSite_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetSite();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetSite_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSitePrametersTypes = null;
            object[] parametersOfGetSite = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSite, methodGetSitePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataRow>(_reportDataInstanceFixture, out exception1, parametersOfGetSite);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataRow>(_reportDataInstance, MethodGetSite, parametersOfGetSite, methodGetSitePrametersTypes);

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
        public void AUT_ReportData_GetSite_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSitePrametersTypes = null;
            object[] parametersOfGetSite = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataRow>(_reportDataInstance, MethodGetSite, parametersOfGetSite, methodGetSitePrametersTypes);

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
        public void AUT_ReportData_GetSite_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSitePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetSite, Fixture, methodGetSitePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetSite_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSitePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetSite, Fixture, methodGetSitePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSite) (Return Type : DataRow) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetSite_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSite, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_ExecuteNonQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteNonQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ExecuteNonQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.ExecuteNonQuery(con);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ExecuteNonQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfExecuteNonQuery = { con };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, methodExecuteNonQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfExecuteNonQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

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
        public void AUT_ReportData_ExecuteNonQuery_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfExecuteNonQuery = { con };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, methodExecuteNonQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfExecuteNonQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

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
        public void AUT_ReportData_ExecuteNonQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var con = CreateType<SqlConnection>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfExecuteNonQuery = { con };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

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
        public void AUT_ReportData_ExecuteNonQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ExecuteNonQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ExecuteNonQuery_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (CheckServerConnection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_CheckServerConnection_Method_Call_Internally(Type[] types)
        {
            var methodCheckServerConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCheckServerConnection, Fixture, methodCheckServerConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckServerConnection) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CheckServerConnection_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.CheckServerConnection();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CheckServerConnection) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CheckServerConnection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodCheckServerConnectionPrametersTypes = null;
            object[] parametersOfCheckServerConnection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCheckServerConnection, methodCheckServerConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfCheckServerConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCheckServerConnection, parametersOfCheckServerConnection, methodCheckServerConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCheckServerConnection.ShouldBeNull();
            methodCheckServerConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckServerConnection) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CheckServerConnection_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodCheckServerConnectionPrametersTypes = null;
            object[] parametersOfCheckServerConnection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCheckServerConnection, methodCheckServerConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfCheckServerConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCheckServerConnection, parametersOfCheckServerConnection, methodCheckServerConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCheckServerConnection.ShouldBeNull();
            methodCheckServerConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckServerConnection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CheckServerConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCheckServerConnectionPrametersTypes = null;
            object[] parametersOfCheckServerConnection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCheckServerConnection, parametersOfCheckServerConnection, methodCheckServerConnectionPrametersTypes);

            // Assert
            parametersOfCheckServerConnection.ShouldBeNull();
            methodCheckServerConnectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckServerConnection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CheckServerConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCheckServerConnectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCheckServerConnection, Fixture, methodCheckServerConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckServerConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckServerConnection) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CheckServerConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckServerConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DatabaseExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DatabaseExists_Method_Call_Internally(Type[] types)
        {
            var methodDatabaseExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDatabaseExists, Fixture, methodDatabaseExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (DatabaseExists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DatabaseExists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DatabaseExists();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DatabaseExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DatabaseExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodDatabaseExistsPrametersTypes = null;
            object[] parametersOfDatabaseExists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDatabaseExists, methodDatabaseExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDatabaseExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDatabaseExists, parametersOfDatabaseExists, methodDatabaseExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDatabaseExists.ShouldBeNull();
            methodDatabaseExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DatabaseExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DatabaseExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodDatabaseExistsPrametersTypes = null;
            object[] parametersOfDatabaseExists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDatabaseExists, methodDatabaseExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDatabaseExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDatabaseExists, parametersOfDatabaseExists, methodDatabaseExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDatabaseExists.ShouldBeNull();
            methodDatabaseExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DatabaseExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DatabaseExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDatabaseExistsPrametersTypes = null;
            object[] parametersOfDatabaseExists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDatabaseExists, parametersOfDatabaseExists, methodDatabaseExistsPrametersTypes);

            // Assert
            parametersOfDatabaseExists.ShouldBeNull();
            methodDatabaseExistsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DatabaseExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DatabaseExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDatabaseExistsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDatabaseExists, Fixture, methodDatabaseExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDatabaseExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DatabaseExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DatabaseExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDatabaseExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsReportingDB) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_IsReportingDB_Method_Call_Internally(Type[] types)
        {
            var methodIsReportingDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodIsReportingDB, Fixture, methodIsReportingDBPrametersTypes);
        }

        #endregion

        #region Method Call : (IsReportingDB) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsReportingDB_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.IsReportingDB();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsReportingDB) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsReportingDB_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsReportingDBPrametersTypes = null;
            object[] parametersOfIsReportingDB = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsReportingDB, methodIsReportingDBPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfIsReportingDB);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodIsReportingDB, parametersOfIsReportingDB, methodIsReportingDBPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsReportingDB.ShouldBeNull();
            methodIsReportingDBPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsReportingDB) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsReportingDB_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsReportingDBPrametersTypes = null;
            object[] parametersOfIsReportingDB = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsReportingDB, methodIsReportingDBPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfIsReportingDB);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodIsReportingDB, parametersOfIsReportingDB, methodIsReportingDBPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsReportingDB.ShouldBeNull();
            methodIsReportingDBPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsReportingDB) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsReportingDB_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsReportingDBPrametersTypes = null;
            object[] parametersOfIsReportingDB = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodIsReportingDB, parametersOfIsReportingDB, methodIsReportingDBPrametersTypes);

            // Assert
            parametersOfIsReportingDB.ShouldBeNull();
            methodIsReportingDBPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsReportingDB) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsReportingDB_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsReportingDBPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodIsReportingDB, Fixture, methodIsReportingDBPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsReportingDBPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsReportingDB) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsReportingDB_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsReportingDB, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_TableExists_Method_Call_Internally(Type[] types)
        {
            var methodTableExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodTableExists, Fixture, methodTableExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_TableExists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.TableExists(tableName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_TableExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodTableExistsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfTableExists = { tableName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTableExists, methodTableExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfTableExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodTableExists, parametersOfTableExists, methodTableExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTableExists.ShouldNotBeNull();
            parametersOfTableExists.Length.ShouldBe(1);
            methodTableExistsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_TableExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodTableExistsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfTableExists = { tableName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTableExists, methodTableExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfTableExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodTableExists, parametersOfTableExists, methodTableExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTableExists.ShouldNotBeNull();
            parametersOfTableExists.Length.ShouldBe(1);
            methodTableExistsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_TableExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodTableExistsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfTableExists = { tableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodTableExists, parametersOfTableExists, methodTableExistsPrametersTypes);

            // Assert
            parametersOfTableExists.ShouldNotBeNull();
            parametersOfTableExists.Length.ShouldBe(1);
            methodTableExistsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_TableExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTableExistsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodTableExists, Fixture, methodTableExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTableExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_TableExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTableExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TableExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_TableExists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTableExists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ColumnExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_ColumnExists_Method_Call_Internally(Type[] types)
        {
            var methodColumnExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodColumnExists, Fixture, methodColumnExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (ColumnExists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ColumnExists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var columnname = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.ColumnExists(tableName, columnname);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ColumnExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ColumnExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var columnname = CreateType<string>();
            var methodColumnExistsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfColumnExists = { tableName, columnname };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodColumnExists, methodColumnExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfColumnExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodColumnExists, parametersOfColumnExists, methodColumnExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfColumnExists.ShouldNotBeNull();
            parametersOfColumnExists.Length.ShouldBe(2);
            methodColumnExistsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ColumnExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ColumnExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var columnname = CreateType<string>();
            var methodColumnExistsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfColumnExists = { tableName, columnname };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodColumnExists, methodColumnExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfColumnExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodColumnExists, parametersOfColumnExists, methodColumnExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfColumnExists.ShouldNotBeNull();
            parametersOfColumnExists.Length.ShouldBe(2);
            methodColumnExistsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ColumnExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ColumnExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var columnname = CreateType<string>();
            var methodColumnExistsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfColumnExists = { tableName, columnname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodColumnExists, parametersOfColumnExists, methodColumnExistsPrametersTypes);

            // Assert
            parametersOfColumnExists.ShouldNotBeNull();
            parametersOfColumnExists.Length.ShouldBe(2);
            methodColumnExistsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ColumnExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ColumnExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodColumnExistsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodColumnExists, Fixture, methodColumnExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodColumnExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ColumnExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ColumnExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodColumnExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ColumnExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ColumnExists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodColumnExists, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcedureExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_ProcedureExists_Method_Call_Internally(Type[] types)
        {
            var methodProcedureExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodProcedureExists, Fixture, methodProcedureExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcedureExists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcedureExists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var procName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.ProcedureExists(procName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcedureExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcedureExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var procName = CreateType<string>();
            var methodProcedureExistsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfProcedureExists = { procName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProcedureExists, methodProcedureExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfProcedureExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodProcedureExists, parametersOfProcedureExists, methodProcedureExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfProcedureExists.ShouldNotBeNull();
            parametersOfProcedureExists.Length.ShouldBe(1);
            methodProcedureExistsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ProcedureExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcedureExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var procName = CreateType<string>();
            var methodProcedureExistsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfProcedureExists = { procName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProcedureExists, methodProcedureExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfProcedureExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodProcedureExists, parametersOfProcedureExists, methodProcedureExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfProcedureExists.ShouldNotBeNull();
            parametersOfProcedureExists.Length.ShouldBe(1);
            methodProcedureExistsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ProcedureExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcedureExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var procName = CreateType<string>();
            var methodProcedureExistsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfProcedureExists = { procName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodProcedureExists, parametersOfProcedureExists, methodProcedureExistsPrametersTypes);

            // Assert
            parametersOfProcedureExists.ShouldNotBeNull();
            parametersOfProcedureExists.Length.ShouldBe(1);
            methodProcedureExistsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcedureExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcedureExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcedureExistsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodProcedureExists, Fixture, methodProcedureExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcedureExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcedureExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcedureExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcedureExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProcedureExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcedureExists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcedureExists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetError) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetError_Method_Call_Internally(Type[] types)
        {
            var methodGetErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetError, Fixture, methodGetErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (GetError) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetError_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetError();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetError) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetError_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetErrorPrametersTypes = null;
            object[] parametersOfGetError = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetError, methodGetErrorPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfGetError);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetError, parametersOfGetError, methodGetErrorPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetError.ShouldBeNull();
            methodGetErrorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetError) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetError_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetErrorPrametersTypes = null;
            object[] parametersOfGetError = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetError, parametersOfGetError, methodGetErrorPrametersTypes);

            // Assert
            parametersOfGetError.ShouldBeNull();
            methodGetErrorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetError) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetError_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetErrorPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetError, Fixture, methodGetErrorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetErrorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetError) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetError_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetErrorPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetError, Fixture, methodGetErrorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetErrorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetError) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetError_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetError, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateDatabase) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_CreateDatabase_Method_Call_Internally(Type[] types)
        {
            var methodCreateDatabasePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCreateDatabase, Fixture, methodCreateDatabasePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateDatabase) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateDatabase_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.CreateDatabase();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateDatabase) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateDatabase_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateDatabasePrametersTypes = null;
            object[] parametersOfCreateDatabase = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateDatabase, methodCreateDatabasePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfCreateDatabase);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCreateDatabase, parametersOfCreateDatabase, methodCreateDatabasePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateDatabase.ShouldBeNull();
            methodCreateDatabasePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateDatabase) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateDatabase_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodCreateDatabasePrametersTypes = null;
            object[] parametersOfCreateDatabase = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateDatabase, methodCreateDatabasePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfCreateDatabase);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCreateDatabase, parametersOfCreateDatabase, methodCreateDatabasePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateDatabase.ShouldBeNull();
            methodCreateDatabasePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateDatabase) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateDatabase_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateDatabasePrametersTypes = null;
            object[] parametersOfCreateDatabase = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCreateDatabase, parametersOfCreateDatabase, methodCreateDatabasePrametersTypes);

            // Assert
            parametersOfCreateDatabase.ShouldBeNull();
            methodCreateDatabasePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDatabase) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateDatabase_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateDatabasePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCreateDatabase, Fixture, methodCreateDatabasePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateDatabasePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateDatabase) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateDatabase_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateDatabase, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetTableNames_Method_Call_Internally(Type[] types)
        {
            var methodGetTableNamesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableNames, Fixture, methodGetTableNamesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNames_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var tableNameRoot = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetTableNames(tableNameRoot);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNames_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var tableNameRoot = CreateType<string>();
            var methodGetTableNamesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableNames = { tableNameRoot };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableNames, methodGetTableNamesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetTableNames);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetTableNames, parametersOfGetTableNames, methodGetTableNamesPrametersTypes);

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
        public void AUT_ReportData_GetTableNames_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableNameRoot = CreateType<string>();
            var methodGetTableNamesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableNames = { tableNameRoot };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetTableNames, parametersOfGetTableNames, methodGetTableNamesPrametersTypes);

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
        public void AUT_ReportData_GetTableNames_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableNamesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableNames, Fixture, methodGetTableNamesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTableNamesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNames_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableNamesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableNames, Fixture, methodGetTableNamesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableNamesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNames_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableNames, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableNames) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNames_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetSafeTableName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetSafeTableName_Method_Call_Internally(Type[] types)
        {
            var methodGetSafeTableNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetSafeTableName, Fixture, methodGetSafeTableNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetSafeTableName_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetSafeTableName(tableName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetSafeTableName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodGetSafeTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeTableName = { tableName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSafeTableName, methodGetSafeTableNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfGetSafeTableName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetSafeTableName, parametersOfGetSafeTableName, methodGetSafeTableNamePrametersTypes);

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
        public void AUT_ReportData_GetSafeTableName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodGetSafeTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeTableName = { tableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetSafeTableName, parametersOfGetSafeTableName, methodGetSafeTableNamePrametersTypes);

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
        public void AUT_ReportData_GetSafeTableName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSafeTableNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetSafeTableName, Fixture, methodGetSafeTableNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSafeTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetSafeTableName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSafeTableNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetSafeTableName, Fixture, methodGetSafeTableNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSafeTableNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetSafeTableName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSafeTableName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSafeTableName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetSafeTableName_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ReportData_GetTableCount_Method_Call_Internally(Type[] types)
        {
            var methodGetTableCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableCount, Fixture, methodGetTableCountPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableCount_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetTableCount();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableCount_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTableCountPrametersTypes = null;
            object[] parametersOfGetTableCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableCount, methodGetTableCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, int>(_reportDataInstanceFixture, out exception1, parametersOfGetTableCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, int>(_reportDataInstance, MethodGetTableCount, parametersOfGetTableCount, methodGetTableCountPrametersTypes);

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
        public void AUT_ReportData_GetTableCount_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetTableCountPrametersTypes = null;
            object[] parametersOfGetTableCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableCount, methodGetTableCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, int>(_reportDataInstanceFixture, out exception1, parametersOfGetTableCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, int>(_reportDataInstance, MethodGetTableCount, parametersOfGetTableCount, methodGetTableCountPrametersTypes);

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
        public void AUT_ReportData_GetTableCount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTableCountPrametersTypes = null;
            object[] parametersOfGetTableCount = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, int>(_reportDataInstance, MethodGetTableCount, parametersOfGetTableCount, methodGetTableCountPrametersTypes);

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
        public void AUT_ReportData_GetTableCount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTableCountPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableCount, Fixture, methodGetTableCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableCount) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableCount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_CreateTable_Method_Call_Internally(Type[] types)
        {
            var methodCreateTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCreateTable, Fixture, methodCreateTablePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var columnDefs = CreateType<List<ColumnDef>>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.CreateTable(name, columnDefs);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var columnDefs = CreateType<List<ColumnDef>>();
            var methodCreateTablePrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfCreateTable = { name, columnDefs };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateTable, methodCreateTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfCreateTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCreateTable, parametersOfCreateTable, methodCreateTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateTable.ShouldNotBeNull();
            parametersOfCreateTable.Length.ShouldBe(2);
            methodCreateTablePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var columnDefs = CreateType<List<ColumnDef>>();
            var methodCreateTablePrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfCreateTable = { name, columnDefs };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateTable, methodCreateTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfCreateTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCreateTable, parametersOfCreateTable, methodCreateTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateTable.ShouldNotBeNull();
            parametersOfCreateTable.Length.ShouldBe(2);
            methodCreateTablePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var columnDefs = CreateType<List<ColumnDef>>();
            var methodCreateTablePrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfCreateTable = { name, columnDefs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCreateTable, parametersOfCreateTable, methodCreateTablePrametersTypes);

            // Assert
            parametersOfCreateTable.ShouldNotBeNull();
            parametersOfCreateTable.Length.ShouldBe(2);
            methodCreateTablePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateTablePrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCreateTable, Fixture, methodCreateTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = new[] { GetMethodInfo(MethodCreateTable, 0), GetMethodInfo(MethodCreateTable, 1) };
            const int parametersCount = 4;
            const int parametersCount1 = 2;

            // Act
            var parameters = new[] { methodInfo[0].GetParameters().Length, methodInfo[1].GetParameters().Length };

            // Assert
            parameters.ShouldSatisfyAllConditions(
                () => parameters.ShouldContain(parametersCount),
                () => parameters.ShouldContain(parametersCount1));
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_CreateTable_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodCreateTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCreateTable, Fixture, methodCreateTablePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var columnDefs = CreateType<List<ColumnDef>>();
            var dropIfExists = CreateType<bool>();
            var message = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.CreateTable(name, columnDefs, dropIfExists, out message);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var columnDefs = CreateType<List<ColumnDef>>();
            var dropIfExists = CreateType<bool>();
            var message = CreateType<string>();
            var methodCreateTablePrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>), typeof(bool), typeof(string) };
            object[] parametersOfCreateTable = { name, columnDefs, dropIfExists, message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodCreateTable, parametersOfCreateTable, methodCreateTablePrametersTypes);

            // Assert
            parametersOfCreateTable.ShouldNotBeNull();
            parametersOfCreateTable.Length.ShouldBe(4);
            methodCreateTablePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateTablePrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>), typeof(bool), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodCreateTable, Fixture, methodCreateTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateTable, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateTable) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_CreateTable_Method_Call__Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = new[] { GetMethodInfo(MethodCreateTable, 0), GetMethodInfo(MethodCreateTable, 1) };
            const int parametersCount = 4;
            const int parametersCount1 = 2;

            // Act
            var parameters = new[] { methodInfo[0].GetParameters().Length, methodInfo[1].GetParameters().Length };

            // Assert
            parameters.ShouldSatisfyAllConditions(
                () => parameters.ShouldContain(parametersCount),
                () => parameters.ShouldContain(parametersCount1));
        }

        #endregion

        #region Method Call : (DeleteTable) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteTable_Method_Call_Internally(Type[] types)
        {
            var methodDeleteTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteTable, Fixture, methodDeleteTablePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteTable) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteTable_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var name = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteTable(name);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteTable) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteTable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodDeleteTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteTable = { name };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteTable, methodDeleteTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteTable, parametersOfDeleteTable, methodDeleteTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteTable.ShouldNotBeNull();
            parametersOfDeleteTable.Length.ShouldBe(1);
            methodDeleteTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteTable) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteTable_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodDeleteTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteTable = { name };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteTable, methodDeleteTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteTable, parametersOfDeleteTable, methodDeleteTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteTable.ShouldNotBeNull();
            parametersOfDeleteTable.Length.ShouldBe(1);
            methodDeleteTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteTable) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodDeleteTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteTable = { name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteTable, parametersOfDeleteTable, methodDeleteTablePrametersTypes);

            // Assert
            parametersOfDeleteTable.ShouldNotBeNull();
            parametersOfDeleteTable.Length.ShouldBe(1);
            methodDeleteTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTable) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteTablePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteTable, Fixture, methodDeleteTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteTable) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteTable) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteTable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_AddColumns_Method_Call_Internally(Type[] types)
        {
            var methodAddColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColumns, Fixture, methodAddColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.AddColumns(table, columns);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            var methodAddColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfAddColumns = { table, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddColumns, methodAddColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfAddColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodAddColumns, parametersOfAddColumns, methodAddColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddColumns.ShouldNotBeNull();
            parametersOfAddColumns.Length.ShouldBe(2);
            methodAddColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumns_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            var methodAddColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfAddColumns = { table, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddColumns, methodAddColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfAddColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodAddColumns, parametersOfAddColumns, methodAddColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddColumns.ShouldNotBeNull();
            parametersOfAddColumns.Length.ShouldBe(2);
            methodAddColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            var methodAddColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfAddColumns = { table, columns };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodAddColumns, parametersOfAddColumns, methodAddColumnsPrametersTypes);

            // Assert
            parametersOfAddColumns.ShouldNotBeNull();
            parametersOfAddColumns.Length.ShouldBe(2);
            methodAddColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColumns, Fixture, methodAddColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumns, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateColumns) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_UpdateColumns_Method_Call_Internally(Type[] types)
        {
            var methodUpdateColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateColumns, Fixture, methodUpdateColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateColumns) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.UpdateColumns(table, columns);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateColumns) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            var methodUpdateColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfUpdateColumns = { table, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateColumns, methodUpdateColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfUpdateColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateColumns, parametersOfUpdateColumns, methodUpdateColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateColumns.ShouldNotBeNull();
            parametersOfUpdateColumns.Length.ShouldBe(2);
            methodUpdateColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateColumns) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateColumns_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            var methodUpdateColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfUpdateColumns = { table, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateColumns, methodUpdateColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfUpdateColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateColumns, parametersOfUpdateColumns, methodUpdateColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateColumns.ShouldNotBeNull();
            parametersOfUpdateColumns.Length.ShouldBe(2);
            methodUpdateColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateColumns) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            var methodUpdateColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfUpdateColumns = { table, columns };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateColumns, parametersOfUpdateColumns, methodUpdateColumnsPrametersTypes);

            // Assert
            parametersOfUpdateColumns.ShouldNotBeNull();
            parametersOfUpdateColumns.Length.ShouldBe(2);
            methodUpdateColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateColumns) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateColumns, Fixture, methodUpdateColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateColumns) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateColumns) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateColumns, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteColumns) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteColumns_Method_Call_Internally(Type[] types)
        {
            var methodDeleteColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteColumns, Fixture, methodDeleteColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteColumns) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteColumns(table, columns);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteColumns) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            var methodDeleteColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfDeleteColumns = { table, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteColumns, methodDeleteColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteColumns, parametersOfDeleteColumns, methodDeleteColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteColumns.ShouldNotBeNull();
            parametersOfDeleteColumns.Length.ShouldBe(2);
            methodDeleteColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteColumns) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteColumns_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            var methodDeleteColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfDeleteColumns = { table, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteColumns, methodDeleteColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteColumns, parametersOfDeleteColumns, methodDeleteColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteColumns.ShouldNotBeNull();
            parametersOfDeleteColumns.Length.ShouldBe(2);
            methodDeleteColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteColumns) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var table = CreateType<string>();
            var columns = CreateType<List<ColumnDef>>();
            var methodDeleteColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            object[] parametersOfDeleteColumns = { table, columns };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteColumns, parametersOfDeleteColumns, methodDeleteColumnsPrametersTypes);

            // Assert
            parametersOfDeleteColumns.ShouldNotBeNull();
            parametersOfDeleteColumns.Length.ShouldBe(2);
            methodDeleteColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteColumns) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteColumnsPrametersTypes = new Type[] { typeof(string), typeof(List<ColumnDef>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteColumns, Fixture, methodDeleteColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteColumns) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteColumns) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteColumns, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertDbEntry) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InsertDbEntry_Method_Call_Internally(Type[] types)
        {
            var methodInsertDbEntryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertDbEntry, Fixture, methodInsertDbEntryPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertDbEntry) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertDbEntry_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InsertDbEntry();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InsertDbEntry) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertDbEntry_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodInsertDbEntryPrametersTypes = null;
            object[] parametersOfInsertDbEntry = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertDbEntry, methodInsertDbEntryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertDbEntry);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertDbEntry, parametersOfInsertDbEntry, methodInsertDbEntryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertDbEntry.ShouldBeNull();
            methodInsertDbEntryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertDbEntry) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertDbEntry_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodInsertDbEntryPrametersTypes = null;
            object[] parametersOfInsertDbEntry = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertDbEntry, methodInsertDbEntryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertDbEntry);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertDbEntry, parametersOfInsertDbEntry, methodInsertDbEntryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertDbEntry.ShouldBeNull();
            methodInsertDbEntryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertDbEntry) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertDbEntry_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInsertDbEntryPrametersTypes = null;
            object[] parametersOfInsertDbEntry = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertDbEntry, parametersOfInsertDbEntry, methodInsertDbEntryPrametersTypes);

            // Assert
            parametersOfInsertDbEntry.ShouldBeNull();
            methodInsertDbEntryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertDbEntry) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertDbEntry_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInsertDbEntryPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertDbEntry, Fixture, methodInsertDbEntryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertDbEntryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertDbEntry) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertDbEntry_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertDbEntry, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteDbEntry) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteDbEntry_Method_Call_Internally(Type[] types)
        {
            var methodDeleteDbEntryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteDbEntry, Fixture, methodDeleteDbEntryPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteDbEntry) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteDbEntry_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteDbEntry();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteDbEntry) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteDbEntry_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodDeleteDbEntryPrametersTypes = null;
            object[] parametersOfDeleteDbEntry = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteDbEntry, methodDeleteDbEntryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteDbEntry);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteDbEntry, parametersOfDeleteDbEntry, methodDeleteDbEntryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteDbEntry.ShouldBeNull();
            methodDeleteDbEntryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteDbEntry) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteDbEntry_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodDeleteDbEntryPrametersTypes = null;
            object[] parametersOfDeleteDbEntry = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteDbEntry, methodDeleteDbEntryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteDbEntry);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteDbEntry, parametersOfDeleteDbEntry, methodDeleteDbEntryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteDbEntry.ShouldBeNull();
            methodDeleteDbEntryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteDbEntry) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteDbEntry_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDeleteDbEntryPrametersTypes = null;
            object[] parametersOfDeleteDbEntry = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteDbEntry, parametersOfDeleteDbEntry, methodDeleteDbEntryPrametersTypes);

            // Assert
            parametersOfDeleteDbEntry.ShouldBeNull();
            methodDeleteDbEntryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteDbEntry) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteDbEntry_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDeleteDbEntryPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteDbEntry, Fixture, methodDeleteDbEntryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteDbEntryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteDbEntry) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteDbEntry_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteDbEntry, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetDbVersion_Method_Call_Internally(Type[] types)
        {
            var methodGetDbVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDbVersion, Fixture, methodGetDbVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbVersion_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetDbVersion(siteId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbVersion_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var methodGetDbVersionPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetDbVersion = { siteId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDbVersion, methodGetDbVersionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfGetDbVersion);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetDbVersion, parametersOfGetDbVersion, methodGetDbVersionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDbVersion.ShouldNotBeNull();
            parametersOfGetDbVersion.Length.ShouldBe(1);
            methodGetDbVersionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbVersion_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var methodGetDbVersionPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetDbVersion = { siteId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetDbVersion, parametersOfGetDbVersion, methodGetDbVersionPrametersTypes);

            // Assert
            parametersOfGetDbVersion.ShouldNotBeNull();
            parametersOfGetDbVersion.Length.ShouldBe(1);
            methodGetDbVersionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbVersion_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDbVersionPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDbVersion, Fixture, methodGetDbVersionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDbVersionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbVersion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDbVersionPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDbVersion, Fixture, methodGetDbVersionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDbVersionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbVersion_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDbVersion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDbVersion) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbVersion_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDbVersion, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDbMappings) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetDbMappings_Method_Call_Internally(Type[] types)
        {
            var methodGetDbMappingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDbMappings, Fixture, methodGetDbMappingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDbMappings) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbMappings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetDbMappings();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDbMappings) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbMappings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDbMappingsPrametersTypes = null;
            object[] parametersOfGetDbMappings = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDbMappings, methodGetDbMappingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetDbMappings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetDbMappings, parametersOfGetDbMappings, methodGetDbMappingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDbMappings.ShouldBeNull();
            methodGetDbMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDbMappings) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbMappings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDbMappingsPrametersTypes = null;
            object[] parametersOfGetDbMappings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetDbMappings, parametersOfGetDbMappings, methodGetDbMappingsPrametersTypes);

            // Assert
            parametersOfGetDbMappings.ShouldBeNull();
            methodGetDbMappingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDbMappings) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbMappings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDbMappingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDbMappings, Fixture, methodGetDbMappingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDbMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDbMappings) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbMappings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDbMappingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDbMappings, Fixture, methodGetDbMappingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDbMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDbMappings) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDbMappings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDbMappings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExistingDbCount) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetExistingDbCount_Method_Call_Internally(Type[] types)
        {
            var methodGetExistingDbCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetExistingDbCount, Fixture, methodGetExistingDbCountPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExistingDbCount) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetExistingDbCount_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetExistingDbCount();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetExistingDbCount) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetExistingDbCount_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetExistingDbCountPrametersTypes = null;
            object[] parametersOfGetExistingDbCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetExistingDbCount, methodGetExistingDbCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, int>(_reportDataInstanceFixture, out exception1, parametersOfGetExistingDbCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, int>(_reportDataInstance, MethodGetExistingDbCount, parametersOfGetExistingDbCount, methodGetExistingDbCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetExistingDbCount.ShouldBeNull();
            methodGetExistingDbCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExistingDbCount) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetExistingDbCount_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetExistingDbCountPrametersTypes = null;
            object[] parametersOfGetExistingDbCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetExistingDbCount, methodGetExistingDbCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, int>(_reportDataInstanceFixture, out exception1, parametersOfGetExistingDbCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, int>(_reportDataInstance, MethodGetExistingDbCount, parametersOfGetExistingDbCount, methodGetExistingDbCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetExistingDbCount.ShouldBeNull();
            methodGetExistingDbCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExistingDbCount) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetExistingDbCount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetExistingDbCountPrametersTypes = null;
            object[] parametersOfGetExistingDbCount = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, int>(_reportDataInstance, MethodGetExistingDbCount, parametersOfGetExistingDbCount, methodGetExistingDbCountPrametersTypes);

            // Assert
            parametersOfGetExistingDbCount.ShouldBeNull();
            methodGetExistingDbCountPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExistingDbCount) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetExistingDbCount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetExistingDbCountPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetExistingDbCount, Fixture, methodGetExistingDbCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExistingDbCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExistingDbCount) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetExistingDbCount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExistingDbCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDistinctDbMappings) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetDistinctDbMappings_Method_Call_Internally(Type[] types)
        {
            var methodGetDistinctDbMappingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDistinctDbMappings, Fixture, methodGetDistinctDbMappingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDistinctDbMappings) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDistinctDbMappings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetDistinctDbMappings();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDistinctDbMappings) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDistinctDbMappings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDistinctDbMappingsPrametersTypes = null;
            object[] parametersOfGetDistinctDbMappings = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDistinctDbMappings, methodGetDistinctDbMappingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetDistinctDbMappings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetDistinctDbMappings, parametersOfGetDistinctDbMappings, methodGetDistinctDbMappingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDistinctDbMappings.ShouldBeNull();
            methodGetDistinctDbMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDistinctDbMappings) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDistinctDbMappings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDistinctDbMappingsPrametersTypes = null;
            object[] parametersOfGetDistinctDbMappings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetDistinctDbMappings, parametersOfGetDistinctDbMappings, methodGetDistinctDbMappingsPrametersTypes);

            // Assert
            parametersOfGetDistinctDbMappings.ShouldBeNull();
            methodGetDistinctDbMappingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDistinctDbMappings) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDistinctDbMappings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDistinctDbMappingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDistinctDbMappings, Fixture, methodGetDistinctDbMappingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDistinctDbMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDistinctDbMappings) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDistinctDbMappings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDistinctDbMappingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDistinctDbMappings, Fixture, methodGetDistinctDbMappingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDistinctDbMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDistinctDbMappings) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDistinctDbMappings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDistinctDbMappings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetListMappings_Method_Call_Internally(Type[] types)
        {
            var methodGetListMappingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListMappings, Fixture, methodGetListMappingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetListMappings();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetListMappingsPrametersTypes = null;
            object[] parametersOfGetListMappings = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListMappings, methodGetListMappingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetListMappings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetListMappings, parametersOfGetListMappings, methodGetListMappingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListMappings.ShouldBeNull();
            methodGetListMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetListMappingsPrametersTypes = null;
            object[] parametersOfGetListMappings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetListMappings, parametersOfGetListMappings, methodGetListMappingsPrametersTypes);

            // Assert
            parametersOfGetListMappings.ShouldBeNull();
            methodGetListMappingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetListMappingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListMappings, Fixture, methodGetListMappingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetListMappingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListMappings, Fixture, methodGetListMappingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListMappings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetListMappings_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetListMappingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListMappings, Fixture, methodGetListMappingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var listIds = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetListMappings(listIds);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listIds = CreateType<string>();
            var methodGetListMappingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListMappings = { listIds };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListMappings, methodGetListMappingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetListMappings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetListMappings, parametersOfGetListMappings, methodGetListMappingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListMappings.ShouldNotBeNull();
            parametersOfGetListMappings.Length.ShouldBe(1);
            methodGetListMappingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listIds = CreateType<string>();
            var methodGetListMappingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListMappings = { listIds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetListMappings, parametersOfGetListMappings, methodGetListMappingsPrametersTypes);

            // Assert
            parametersOfGetListMappings.ShouldNotBeNull();
            parametersOfGetListMappings.Length.ShouldBe(1);
            methodGetListMappingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListMappingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListMappings, Fixture, methodGetListMappingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListMappingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListMappingsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListMappings, Fixture, methodGetListMappingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListMappingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListMappings, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListMappings) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMappings_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListMappings, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListMapping) (Return Type : DataRow) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetListMapping_Method_Call_Internally(Type[] types)
        {
            var methodGetListMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListMapping, Fixture, methodGetListMappingPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListMapping) (Return Type : DataRow) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMapping_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetListMapping(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListMapping) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMapping_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetListMappingPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListMapping = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListMapping, methodGetListMappingPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataRow>(_reportDataInstanceFixture, out exception1, parametersOfGetListMapping);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataRow>(_reportDataInstance, MethodGetListMapping, parametersOfGetListMapping, methodGetListMappingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListMapping.ShouldNotBeNull();
            parametersOfGetListMapping.Length.ShouldBe(1);
            methodGetListMappingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListMapping) (Return Type : DataRow) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMapping_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetListMappingPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListMapping = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataRow>(_reportDataInstance, MethodGetListMapping, parametersOfGetListMapping, methodGetListMappingPrametersTypes);

            // Assert
            parametersOfGetListMapping.ShouldNotBeNull();
            parametersOfGetListMapping.Length.ShouldBe(1);
            methodGetListMappingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListMapping) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMapping_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListMappingPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListMapping, Fixture, methodGetListMappingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListMappingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListMapping) (Return Type : DataRow) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMapping_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListMappingPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListMapping, Fixture, methodGetListMappingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListMappingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListMapping) (Return Type : DataRow) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMapping_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListMapping, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListMapping) (Return Type : DataRow) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListMapping_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListMapping, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeDatabase) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InitializeDatabase_Method_Call_Internally(Type[] types)
        {
            var methodInitializeDatabasePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInitializeDatabase, Fixture, methodInitializeDatabasePrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeDatabase) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InitializeDatabase_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InitializeDatabase();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InitializeDatabase) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InitializeDatabase_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodInitializeDatabasePrametersTypes = null;
            object[] parametersOfInitializeDatabase = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInitializeDatabase, methodInitializeDatabasePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInitializeDatabase);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInitializeDatabase, parametersOfInitializeDatabase, methodInitializeDatabasePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInitializeDatabase.ShouldBeNull();
            methodInitializeDatabasePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InitializeDatabase) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InitializeDatabase_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodInitializeDatabasePrametersTypes = null;
            object[] parametersOfInitializeDatabase = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInitializeDatabase, methodInitializeDatabasePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInitializeDatabase);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInitializeDatabase, parametersOfInitializeDatabase, methodInitializeDatabasePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInitializeDatabase.ShouldBeNull();
            methodInitializeDatabasePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InitializeDatabase) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InitializeDatabase_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializeDatabasePrametersTypes = null;
            object[] parametersOfInitializeDatabase = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInitializeDatabase, parametersOfInitializeDatabase, methodInitializeDatabasePrametersTypes);

            // Assert
            parametersOfInitializeDatabase.ShouldBeNull();
            methodInitializeDatabasePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeDatabase) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InitializeDatabase_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializeDatabasePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInitializeDatabase, Fixture, methodInitializeDatabasePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInitializeDatabasePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InitializeDatabase) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InitializeDatabase_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeDatabase, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertList) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InsertList_Method_Call_Internally(Type[] types)
        {
            var methodInsertListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertList, Fixture, methodInsertListPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertList) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertList_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var tableName = CreateType<string>();
            var tableNameSnapshot = CreateType<string>();
            var resourceList = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InsertList(listId, tableName, tableNameSnapshot, resourceList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InsertList) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertList_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var tableName = CreateType<string>();
            var tableNameSnapshot = CreateType<string>();
            var resourceList = CreateType<bool>();
            var methodInsertListPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool) };
            object[] parametersOfInsertList = { listId, tableName, tableNameSnapshot, resourceList };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertList, methodInsertListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertList, parametersOfInsertList, methodInsertListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertList.ShouldNotBeNull();
            parametersOfInsertList.Length.ShouldBe(4);
            methodInsertListPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (InsertList) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var tableName = CreateType<string>();
            var tableNameSnapshot = CreateType<string>();
            var resourceList = CreateType<bool>();
            var methodInsertListPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool) };
            object[] parametersOfInsertList = { listId, tableName, tableNameSnapshot, resourceList };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertList, methodInsertListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertList, parametersOfInsertList, methodInsertListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertList.ShouldNotBeNull();
            parametersOfInsertList.Length.ShouldBe(4);
            methodInsertListPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (InsertList) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var tableName = CreateType<string>();
            var tableNameSnapshot = CreateType<string>();
            var resourceList = CreateType<bool>();
            var methodInsertListPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool) };
            object[] parametersOfInsertList = { listId, tableName, tableNameSnapshot, resourceList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertList, parametersOfInsertList, methodInsertListPrametersTypes);

            // Assert
            parametersOfInsertList.ShouldNotBeNull();
            parametersOfInsertList.Length.ShouldBe(4);
            methodInsertListPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertList) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertListPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertList, Fixture, methodInsertListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertList) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertList) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertList, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_UpdateList_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateList, Fixture, methodUpdateListPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateList_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var resourceList = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.UpdateList(listId, resourceList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateList_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var resourceList = CreateType<bool>();
            var methodUpdateListPrametersTypes = new Type[] { typeof(Guid), typeof(bool) };
            object[] parametersOfUpdateList = { listId, resourceList };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateList, methodUpdateListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfUpdateList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateList, parametersOfUpdateList, methodUpdateListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateList.ShouldNotBeNull();
            parametersOfUpdateList.Length.ShouldBe(2);
            methodUpdateListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var resourceList = CreateType<bool>();
            var methodUpdateListPrametersTypes = new Type[] { typeof(Guid), typeof(bool) };
            object[] parametersOfUpdateList = { listId, resourceList };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateList, methodUpdateListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfUpdateList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateList, parametersOfUpdateList, methodUpdateListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateList.ShouldNotBeNull();
            parametersOfUpdateList.Length.ShouldBe(2);
            methodUpdateListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var resourceList = CreateType<bool>();
            var methodUpdateListPrametersTypes = new Type[] { typeof(Guid), typeof(bool) };
            object[] parametersOfUpdateList = { listId, resourceList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateList, parametersOfUpdateList, methodUpdateListPrametersTypes);

            // Assert
            parametersOfUpdateList.ShouldNotBeNull();
            parametersOfUpdateList.Length.ShouldBe(2);
            methodUpdateListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListPrametersTypes = new Type[] { typeof(Guid), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateList, Fixture, methodUpdateListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteList_Method_Call_Internally(Type[] types)
        {
            var methodDeleteListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteList, Fixture, methodDeleteListPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteList_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteList(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteList_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteListPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteList = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteList, methodDeleteListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteList, parametersOfDeleteList, methodDeleteListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteList.ShouldNotBeNull();
            parametersOfDeleteList.Length.ShouldBe(1);
            methodDeleteListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteListPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteList = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteList, methodDeleteListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteList, parametersOfDeleteList, methodDeleteListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteList.ShouldNotBeNull();
            parametersOfDeleteList.Length.ShouldBe(1);
            methodDeleteListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteListPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteList = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteList, parametersOfDeleteList, methodDeleteListPrametersTypes);

            // Assert
            parametersOfDeleteList.ShouldNotBeNull();
            parametersOfDeleteList.Length.ShouldBe(1);
            methodDeleteListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteListPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteList, Fixture, methodDeleteListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteAllListColumns) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteAllListColumns_Method_Call_Internally(Type[] types)
        {
            var methodDeleteAllListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteAllListColumns, Fixture, methodDeleteAllListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteAllListColumns) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteAllListColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteAllListColumns(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteAllListColumns) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteAllListColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteAllListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteAllListColumns = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteAllListColumns, methodDeleteAllListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteAllListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteAllListColumns, parametersOfDeleteAllListColumns, methodDeleteAllListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteAllListColumns.ShouldNotBeNull();
            parametersOfDeleteAllListColumns.Length.ShouldBe(1);
            methodDeleteAllListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteAllListColumns) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteAllListColumns_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteAllListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteAllListColumns = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteAllListColumns, methodDeleteAllListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteAllListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteAllListColumns, parametersOfDeleteAllListColumns, methodDeleteAllListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteAllListColumns.ShouldNotBeNull();
            parametersOfDeleteAllListColumns.Length.ShouldBe(1);
            methodDeleteAllListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteAllListColumns) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteAllListColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteAllListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteAllListColumns = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteAllListColumns, parametersOfDeleteAllListColumns, methodDeleteAllListColumnsPrametersTypes);

            // Assert
            parametersOfDeleteAllListColumns.ShouldNotBeNull();
            parametersOfDeleteAllListColumns.Length.ShouldBe(1);
            methodDeleteAllListColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAllListColumns) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteAllListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteAllListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteAllListColumns, Fixture, methodDeleteAllListColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteAllListColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteAllListColumns) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteAllListColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteAllListColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteAllListColumns) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteAllListColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteAllListColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteListColumns) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteListColumns_Method_Call_Internally(Type[] types)
        {
            var methodDeleteListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteListColumns, Fixture, methodDeleteListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteListColumns) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteListColumns(listId, columns);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteListColumns) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            var methodDeleteListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            object[] parametersOfDeleteListColumns = { listId, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteListColumns, methodDeleteListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteListColumns, parametersOfDeleteListColumns, methodDeleteListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteListColumns.ShouldNotBeNull();
            parametersOfDeleteListColumns.Length.ShouldBe(2);
            methodDeleteListColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteListColumns) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListColumns_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            var methodDeleteListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            object[] parametersOfDeleteListColumns = { listId, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteListColumns, methodDeleteListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteListColumns, parametersOfDeleteListColumns, methodDeleteListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteListColumns.ShouldNotBeNull();
            parametersOfDeleteListColumns.Length.ShouldBe(2);
            methodDeleteListColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteListColumns) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            var methodDeleteListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            object[] parametersOfDeleteListColumns = { listId, columns };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteListColumns, parametersOfDeleteListColumns, methodDeleteListColumnsPrametersTypes);

            // Assert
            parametersOfDeleteListColumns.ShouldNotBeNull();
            parametersOfDeleteListColumns.Length.ShouldBe(2);
            methodDeleteListColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteListColumns) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteListColumns, Fixture, methodDeleteListColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteListColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteListColumns) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteListColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteListColumns) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteListColumns, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteWork_Method_Call_Internally(Type[] types)
        {
            var methodDeleteWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteWork, Fixture, methodDeleteWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteWork(listid, itemid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfDeleteWork = { listid, itemid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteWork, methodDeleteWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteWork, parametersOfDeleteWork, methodDeleteWorkPrametersTypes);

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
        public void AUT_ReportData_DeleteWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfDeleteWork = { listid, itemid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteWork, methodDeleteWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteWork, parametersOfDeleteWork, methodDeleteWorkPrametersTypes);

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
        public void AUT_ReportData_DeleteWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfDeleteWork = { listid, itemid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteWork, parametersOfDeleteWork, methodDeleteWorkPrametersTypes);

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
        public void AUT_ReportData_DeleteWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteWork, Fixture, methodDeleteWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (DeleteWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteWork_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeleteWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteWork, Fixture, methodDeleteWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteWork(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteWork = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteWork, methodDeleteWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteWork, parametersOfDeleteWork, methodDeleteWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteWork.ShouldNotBeNull();
            parametersOfDeleteWork.Length.ShouldBe(1);
            methodDeleteWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteWork = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteWork, methodDeleteWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteWork, parametersOfDeleteWork, methodDeleteWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteWork.ShouldNotBeNull();
            parametersOfDeleteWork.Length.ShouldBe(1);
            methodDeleteWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteWork = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteWork, parametersOfDeleteWork, methodDeleteWorkPrametersTypes);

            // Assert
            parametersOfDeleteWork.ShouldNotBeNull();
            parametersOfDeleteWork.Length.ShouldBe(1);
            methodDeleteWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteWorkPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteWork, Fixture, methodDeleteWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteWork, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteWork_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteWork, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteMyWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteMyWork_Method_Call_Internally(Type[] types)
        {
            var methodDeleteMyWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteMyWork, Fixture, methodDeleteMyWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteMyWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteMyWork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteMyWork(listid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteMyWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteMyWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var methodDeleteMyWorkPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteMyWork = { listid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteMyWork, methodDeleteMyWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteMyWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteMyWork, parametersOfDeleteMyWork, methodDeleteMyWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteMyWork.ShouldNotBeNull();
            parametersOfDeleteMyWork.Length.ShouldBe(1);
            methodDeleteMyWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteMyWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteMyWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var methodDeleteMyWorkPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteMyWork = { listid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteMyWork, methodDeleteMyWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteMyWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteMyWork, parametersOfDeleteMyWork, methodDeleteMyWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteMyWork.ShouldNotBeNull();
            parametersOfDeleteMyWork.Length.ShouldBe(1);
            methodDeleteMyWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteMyWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteMyWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var methodDeleteMyWorkPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteMyWork = { listid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteMyWork, parametersOfDeleteMyWork, methodDeleteMyWorkPrametersTypes);

            // Assert
            parametersOfDeleteMyWork.ShouldNotBeNull();
            parametersOfDeleteMyWork.Length.ShouldBe(1);
            methodDeleteMyWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteMyWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteMyWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteMyWorkPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteMyWork, Fixture, methodDeleteMyWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteMyWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteMyWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteMyWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteMyWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteMyWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteMyWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteMyWork, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertListColumns) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InsertListColumns_Method_Call_Internally(Type[] types)
        {
            var methodInsertListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertListColumns, Fixture, methodInsertListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertListColumns) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InsertListColumns(listId, columns);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InsertListColumns) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            var methodInsertListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            object[] parametersOfInsertListColumns = { listId, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertListColumns, methodInsertListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertListColumns, parametersOfInsertListColumns, methodInsertListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertListColumns.ShouldNotBeNull();
            parametersOfInsertListColumns.Length.ShouldBe(2);
            methodInsertListColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (InsertListColumns) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListColumns_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            var methodInsertListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            object[] parametersOfInsertListColumns = { listId, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertListColumns, methodInsertListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertListColumns, parametersOfInsertListColumns, methodInsertListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertListColumns.ShouldNotBeNull();
            parametersOfInsertListColumns.Length.ShouldBe(2);
            methodInsertListColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (InsertListColumns) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            var methodInsertListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            object[] parametersOfInsertListColumns = { listId, columns };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertListColumns, parametersOfInsertListColumns, methodInsertListColumnsPrametersTypes);

            // Assert
            parametersOfInsertListColumns.ShouldNotBeNull();
            parametersOfInsertListColumns.Length.ShouldBe(2);
            methodInsertListColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertListColumns) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertListColumns, Fixture, methodInsertListColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertListColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertListColumns) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertListColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertListColumns) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertListColumns, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListColumns) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_UpdateListColumns_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateListColumns, Fixture, methodUpdateListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListColumns) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.UpdateListColumns(listId, columns);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateListColumns) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            var methodUpdateListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            object[] parametersOfUpdateListColumns = { listId, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateListColumns, methodUpdateListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfUpdateListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateListColumns, parametersOfUpdateListColumns, methodUpdateListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateListColumns.ShouldNotBeNull();
            parametersOfUpdateListColumns.Length.ShouldBe(2);
            methodUpdateListColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateListColumns) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListColumns_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            var methodUpdateListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            object[] parametersOfUpdateListColumns = { listId, columns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateListColumns, methodUpdateListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfUpdateListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateListColumns, parametersOfUpdateListColumns, methodUpdateListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateListColumns.ShouldNotBeNull();
            parametersOfUpdateListColumns.Length.ShouldBe(2);
            methodUpdateListColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateListColumns) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var columns = CreateType<List<ColumnDef>>();
            var methodUpdateListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            object[] parametersOfUpdateListColumns = { listId, columns };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateListColumns, parametersOfUpdateListColumns, methodUpdateListColumnsPrametersTypes);

            // Assert
            parametersOfUpdateListColumns.ShouldNotBeNull();
            parametersOfUpdateListColumns.Length.ShouldBe(2);
            methodUpdateListColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListColumns) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListColumnsPrametersTypes = new Type[] { typeof(Guid), typeof(List<ColumnDef>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateListColumns, Fixture, methodUpdateListColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateListColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListColumns) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateListColumns) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateListColumns, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InsertLog_Method_Call_Internally(Type[] types)
        {
            var methodInsertLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertLog, Fixture, methodInsertLogPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertLog_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var listName = CreateType<string>();
            var ShortMessage = CreateType<string>();
            var LongMessage = CreateType<string>();
            var type = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InsertLog(listId, listName, ShortMessage, LongMessage, type);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertLog_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var listName = CreateType<string>();
            var ShortMessage = CreateType<string>();
            var LongMessage = CreateType<string>();
            var type = CreateType<int>();
            var methodInsertLogPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfInsertLog = { listId, listName, ShortMessage, LongMessage, type };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertLog, methodInsertLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertLog, parametersOfInsertLog, methodInsertLogPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertLog.ShouldNotBeNull();
            parametersOfInsertLog.Length.ShouldBe(5);
            methodInsertLogPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertLog_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var listName = CreateType<string>();
            var ShortMessage = CreateType<string>();
            var LongMessage = CreateType<string>();
            var type = CreateType<int>();
            var methodInsertLogPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfInsertLog = { listId, listName, ShortMessage, LongMessage, type };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertLog, methodInsertLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertLog, parametersOfInsertLog, methodInsertLogPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertLog.ShouldNotBeNull();
            parametersOfInsertLog.Length.ShouldBe(5);
            methodInsertLogPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertLog_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var listName = CreateType<string>();
            var ShortMessage = CreateType<string>();
            var LongMessage = CreateType<string>();
            var type = CreateType<int>();
            var methodInsertLogPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfInsertLog = { listId, listName, ShortMessage, LongMessage, type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertLog, parametersOfInsertLog, methodInsertLogPrametersTypes);

            // Assert
            parametersOfInsertLog.ShouldNotBeNull();
            parametersOfInsertLog.Length.ShouldBe(5);
            methodInsertLogPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertLogPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertLog, Fixture, methodInsertLogPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertLogPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertLog_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertLog, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertLog_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertLog, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetLog_Method_Call_Internally(Type[] types)
        {
            var methodGetLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetLog, Fixture, methodGetLogPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetLog_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var minimumLevel = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetLog(listId, minimumLevel);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetLog_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var minimumLevel = CreateType<int>();
            var methodGetLogPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfGetLog = { listId, minimumLevel };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLog, methodGetLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetLog, parametersOfGetLog, methodGetLogPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLog.ShouldNotBeNull();
            parametersOfGetLog.Length.ShouldBe(2);
            methodGetLogPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetLog_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var minimumLevel = CreateType<int>();
            var methodGetLogPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfGetLog = { listId, minimumLevel };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetLog, parametersOfGetLog, methodGetLogPrametersTypes);

            // Assert
            parametersOfGetLog.ShouldNotBeNull();
            parametersOfGetLog.Length.ShouldBe(2);
            methodGetLogPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetLog_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLogPrametersTypes = new Type[] { typeof(Guid), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetLog, Fixture, methodGetLogPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLogPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLogPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetLog, Fixture, methodGetLogPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLogPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetLog_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLog, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetLog_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLog, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetMaximumLogLevel_Method_Call_Internally(Type[] types)
        {
            var methodGetMaximumLogLevelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetMaximumLogLevel, Fixture, methodGetMaximumLogLevelPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMaximumLogLevel_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetMaximumLogLevel(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMaximumLogLevel_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetMaximumLogLevelPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetMaximumLogLevel = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, int>(_reportDataInstanceFixture, out exception1, parametersOfGetMaximumLogLevel);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, int>(_reportDataInstance, MethodGetMaximumLogLevel, parametersOfGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetMaximumLogLevel.ShouldNotBeNull();
            parametersOfGetMaximumLogLevel.Length.ShouldBe(1);
            methodGetMaximumLogLevelPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMaximumLogLevel_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetMaximumLogLevelPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetMaximumLogLevel = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, int>(_reportDataInstanceFixture, out exception1, parametersOfGetMaximumLogLevel);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, int>(_reportDataInstance, MethodGetMaximumLogLevel, parametersOfGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetMaximumLogLevel.ShouldNotBeNull();
            parametersOfGetMaximumLogLevel.Length.ShouldBe(1);
            methodGetMaximumLogLevelPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMaximumLogLevel_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetMaximumLogLevelPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetMaximumLogLevel = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, int>(_reportDataInstance, MethodGetMaximumLogLevel, parametersOfGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes);

            // Assert
            parametersOfGetMaximumLogLevel.ShouldNotBeNull();
            parametersOfGetMaximumLogLevel.Length.ShouldBe(1);
            methodGetMaximumLogLevelPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMaximumLogLevel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMaximumLogLevelPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetMaximumLogLevel, Fixture, methodGetMaximumLogLevelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMaximumLogLevelPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMaximumLogLevel_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMaximumLogLevel, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMaximumLogLevel_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMaximumLogLevel, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteLog_Method_Call_Internally(Type[] types)
        {
            var methodDeleteLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteLog, Fixture, methodDeleteLogPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteLog(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteLogPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteLog = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteLog, methodDeleteLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteLog, parametersOfDeleteLog, methodDeleteLogPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteLog.ShouldNotBeNull();
            parametersOfDeleteLog.Length.ShouldBe(1);
            methodDeleteLogPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteLogPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteLog = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteLog, methodDeleteLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteLog, parametersOfDeleteLog, methodDeleteLogPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteLog.ShouldNotBeNull();
            parametersOfDeleteLog.Length.ShouldBe(1);
            methodDeleteLogPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodDeleteLogPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteLog = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteLog, parametersOfDeleteLog, methodDeleteLogPrametersTypes);

            // Assert
            parametersOfDeleteLog.ShouldNotBeNull();
            parametersOfDeleteLog.Length.ShouldBe(1);
            methodDeleteLogPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteLogPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteLog, Fixture, methodDeleteLogPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteLogPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteLog, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteLog, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteLog_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeleteLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteLog, Fixture, methodDeleteLogPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var logType = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteLog(listId, logType);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var logType = CreateType<int>();
            var methodDeleteLogPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfDeleteLog = { listId, logType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteLog, methodDeleteLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteLog, parametersOfDeleteLog, methodDeleteLogPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteLog.ShouldNotBeNull();
            parametersOfDeleteLog.Length.ShouldBe(2);
            methodDeleteLogPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var logType = CreateType<int>();
            var methodDeleteLogPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfDeleteLog = { listId, logType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteLog, methodDeleteLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteLog, parametersOfDeleteLog, methodDeleteLogPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteLog.ShouldNotBeNull();
            parametersOfDeleteLog.Length.ShouldBe(2);
            methodDeleteLogPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var logType = CreateType<int>();
            var methodDeleteLogPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfDeleteLog = { listId, logType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteLog, parametersOfDeleteLog, methodDeleteLogPrametersTypes);

            // Assert
            parametersOfDeleteLog.ShouldNotBeNull();
            parametersOfDeleteLog.Length.ShouldBe(2);
            methodDeleteLogPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteLogPrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteLog, Fixture, methodDeleteLogPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteLogPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteLog, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteLog) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteLog_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteLog, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableNameSnapshot) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetTableNameSnapshot_Method_Call_Internally(Type[] types)
        {
            var methodGetTableNameSnapshotPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableNameSnapshot, Fixture, methodGetTableNameSnapshotPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableNameSnapshot) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNameSnapshot_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetTableNameSnapshot(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableNameSnapshot) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNameSnapshot_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetTableNameSnapshotPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetTableNameSnapshot = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableNameSnapshot, methodGetTableNameSnapshotPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfGetTableNameSnapshot);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetTableNameSnapshot, parametersOfGetTableNameSnapshot, methodGetTableNameSnapshotPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTableNameSnapshot.ShouldNotBeNull();
            parametersOfGetTableNameSnapshot.Length.ShouldBe(1);
            methodGetTableNameSnapshotPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableNameSnapshot) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNameSnapshot_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetTableNameSnapshotPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetTableNameSnapshot = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetTableNameSnapshot, parametersOfGetTableNameSnapshot, methodGetTableNameSnapshotPrametersTypes);

            // Assert
            parametersOfGetTableNameSnapshot.ShouldNotBeNull();
            parametersOfGetTableNameSnapshot.Length.ShouldBe(1);
            methodGetTableNameSnapshotPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableNameSnapshot) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNameSnapshot_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableNameSnapshotPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableNameSnapshot, Fixture, methodGetTableNameSnapshotPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTableNameSnapshotPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableNameSnapshot) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNameSnapshot_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableNameSnapshotPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableNameSnapshot, Fixture, methodGetTableNameSnapshotPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableNameSnapshotPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableNameSnapshot) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNameSnapshot_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableNameSnapshot, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableNameSnapshot) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableNameSnapshot_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTableNameSnapshot, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTSAllDataWithSchema) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetTSAllDataWithSchema_Method_Call_Internally(Type[] types)
        {
            var methodGetTSAllDataWithSchemaPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTSAllDataWithSchema, Fixture, methodGetTSAllDataWithSchemaPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTSAllDataWithSchema) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTSAllDataWithSchema_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetTSAllDataWithSchema();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTSAllDataWithSchema) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTSAllDataWithSchema_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTSAllDataWithSchemaPrametersTypes = null;
            object[] parametersOfGetTSAllDataWithSchema = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTSAllDataWithSchema, methodGetTSAllDataWithSchemaPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetTSAllDataWithSchema);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetTSAllDataWithSchema, parametersOfGetTSAllDataWithSchema, methodGetTSAllDataWithSchemaPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTSAllDataWithSchema.ShouldBeNull();
            methodGetTSAllDataWithSchemaPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTSAllDataWithSchema) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTSAllDataWithSchema_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTSAllDataWithSchemaPrametersTypes = null;
            object[] parametersOfGetTSAllDataWithSchema = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetTSAllDataWithSchema, parametersOfGetTSAllDataWithSchema, methodGetTSAllDataWithSchemaPrametersTypes);

            // Assert
            parametersOfGetTSAllDataWithSchema.ShouldBeNull();
            methodGetTSAllDataWithSchemaPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTSAllDataWithSchema) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTSAllDataWithSchema_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTSAllDataWithSchemaPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTSAllDataWithSchema, Fixture, methodGetTSAllDataWithSchemaPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTSAllDataWithSchemaPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTSAllDataWithSchema) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTSAllDataWithSchema_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTSAllDataWithSchemaPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTSAllDataWithSchema, Fixture, methodGetTSAllDataWithSchemaPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTSAllDataWithSchemaPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTSAllDataWithSchema) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTSAllDataWithSchema_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTSAllDataWithSchema, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertTSAllData) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InsertTSAllData_Method_Call_Internally(Type[] types)
        {
            var methodInsertTSAllDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertTSAllData, Fixture, methodInsertTSAllDataPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertTSAllData) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertTSAllData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var message = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InsertTSAllData(table, out message);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InsertTSAllData) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertTSAllData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var message = CreateType<string>();
            var methodInsertTSAllDataPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            object[] parametersOfInsertTSAllData = { table, message };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertTSAllData, methodInsertTSAllDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertTSAllData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertTSAllData, parametersOfInsertTSAllData, methodInsertTSAllDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertTSAllData.ShouldNotBeNull();
            parametersOfInsertTSAllData.Length.ShouldBe(2);
            methodInsertTSAllDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (InsertTSAllData) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertTSAllData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var message = CreateType<string>();
            var methodInsertTSAllDataPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            object[] parametersOfInsertTSAllData = { table, message };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertTSAllData, methodInsertTSAllDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertTSAllData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertTSAllData, parametersOfInsertTSAllData, methodInsertTSAllDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertTSAllData.ShouldNotBeNull();
            parametersOfInsertTSAllData.Length.ShouldBe(2);
            methodInsertTSAllDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (InsertTSAllData) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertTSAllData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var table = CreateType<DataTable>();
            var message = CreateType<string>();
            var methodInsertTSAllDataPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            object[] parametersOfInsertTSAllData = { table, message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertTSAllData, parametersOfInsertTSAllData, methodInsertTSAllDataPrametersTypes);

            // Assert
            parametersOfInsertTSAllData.ShouldNotBeNull();
            parametersOfInsertTSAllData.Length.ShouldBe(2);
            methodInsertTSAllDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertTSAllData) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertTSAllData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertTSAllDataPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertTSAllData, Fixture, methodInsertTSAllDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertTSAllDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertTSAllData) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertTSAllData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertTSAllData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertTSAllData) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertTSAllData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertTSAllData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshTimeSheet) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_RefreshTimeSheet_Method_Call_Internally(Type[] types)
        {
            var methodRefreshTimeSheetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodRefreshTimeSheet, Fixture, methodRefreshTimeSheetPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshTimeSheet) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RefreshTimeSheet_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webtitile = CreateType<string>();
            var jobid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.RefreshTimeSheet(siteid, webtitile, jobid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RefreshTimeSheet) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RefreshTimeSheet_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webtitile = CreateType<string>();
            var jobid = CreateType<Guid>();
            var methodRefreshTimeSheetPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(Guid) };
            object[] parametersOfRefreshTimeSheet = { siteid, webtitile, jobid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRefreshTimeSheet, methodRefreshTimeSheetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfRefreshTimeSheet);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRefreshTimeSheet.ShouldNotBeNull();
            parametersOfRefreshTimeSheet.Length.ShouldBe(3);
            methodRefreshTimeSheetPrametersTypes.Length.ShouldBe(3);
            methodRefreshTimeSheetPrametersTypes.Length.ShouldBe(parametersOfRefreshTimeSheet.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RefreshTimeSheet) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RefreshTimeSheet_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webtitile = CreateType<string>();
            var jobid = CreateType<Guid>();
            var methodRefreshTimeSheetPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(Guid) };
            object[] parametersOfRefreshTimeSheet = { siteid, webtitile, jobid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportDataInstance, MethodRefreshTimeSheet, parametersOfRefreshTimeSheet, methodRefreshTimeSheetPrametersTypes);

            // Assert
            parametersOfRefreshTimeSheet.ShouldNotBeNull();
            parametersOfRefreshTimeSheet.Length.ShouldBe(3);
            methodRefreshTimeSheetPrametersTypes.Length.ShouldBe(3);
            methodRefreshTimeSheetPrametersTypes.Length.ShouldBe(parametersOfRefreshTimeSheet.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshTimeSheet) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RefreshTimeSheet_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRefreshTimeSheet, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshTimeSheet) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RefreshTimeSheet_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRefreshTimeSheetPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodRefreshTimeSheet, Fixture, methodRefreshTimeSheetPrametersTypes);

            // Assert
            methodRefreshTimeSheetPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshTimeSheet) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RefreshTimeSheet_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshTimeSheet, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetTableName_Method_Call_Internally(Type[] types)
        {
            var methodGetTableNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetTableName(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetTableName = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableName, methodGetTableNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfGetTableName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

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
        public void AUT_ReportData_GetTableName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetTableName = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

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
        public void AUT_ReportData_GetTableName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ReportData_GetTableName_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetTableNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetTableName(listName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableName = { listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableName, methodGetTableNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfGetTableName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

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
        public void AUT_ReportData_GetTableName_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableName = { listName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

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
        public void AUT_ReportData_GetTableName_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableName, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetTableName_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
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

        #region Method Call : (InsertSQL) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InsertSQL_Method_Call_Internally(Type[] types)
        {
            var methodInsertSQLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertSQL, Fixture, methodInsertSQLPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertSQL_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var dtColumns = CreateType<DataTable>();
            var li = CreateType<SPListItem>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InsertSQL(sTableName, dtColumns, li, arrayList_defaultColumns, mandatoryHiddenFlds);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertSQL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var dtColumns = CreateType<DataTable>();
            var li = CreateType<SPListItem>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var methodInsertSQLPrametersTypes = new Type[] { typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };
            object[] parametersOfInsertSQL = { sTableName, dtColumns, li, arrayList_defaultColumns, mandatoryHiddenFlds };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertSQL, methodInsertSQLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfInsertSQL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodInsertSQL, parametersOfInsertSQL, methodInsertSQLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfInsertSQL.ShouldNotBeNull();
            parametersOfInsertSQL.Length.ShouldBe(5);
            methodInsertSQLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertSQL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var dtColumns = CreateType<DataTable>();
            var li = CreateType<SPListItem>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var methodInsertSQLPrametersTypes = new Type[] { typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };
            object[] parametersOfInsertSQL = { sTableName, dtColumns, li, arrayList_defaultColumns, mandatoryHiddenFlds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodInsertSQL, parametersOfInsertSQL, methodInsertSQLPrametersTypes);

            // Assert
            parametersOfInsertSQL.ShouldNotBeNull();
            parametersOfInsertSQL.Length.ShouldBe(5);
            methodInsertSQLPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertSQL_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodInsertSQLPrametersTypes = new Type[] { typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertSQL, Fixture, methodInsertSQLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodInsertSQLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertSQL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertSQLPrametersTypes = new Type[] { typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertSQL, Fixture, methodInsertSQLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertSQLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertSQL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertSQL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertSQL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertSQL, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateSQL) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_UpdateSQL_Method_Call_Internally(Type[] types)
        {
            var methodUpdateSQLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateSQL, Fixture, methodUpdateSQLPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateSQL) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateSQL_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var dtColumns = CreateType<DataTable>();
            var li = CreateType<SPListItem>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.UpdateSQL(sTableName, dtColumns, li, arrayList_defaultColumns, mandatoryHiddenFlds);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateSQL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var dtColumns = CreateType<DataTable>();
            var li = CreateType<SPListItem>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var methodUpdateSQLPrametersTypes = new Type[] { typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };
            object[] parametersOfUpdateSQL = { sTableName, dtColumns, li, arrayList_defaultColumns, mandatoryHiddenFlds };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateSQL, methodUpdateSQLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfUpdateSQL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodUpdateSQL, parametersOfUpdateSQL, methodUpdateSQLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateSQL.ShouldNotBeNull();
            parametersOfUpdateSQL.Length.ShouldBe(5);
            methodUpdateSQLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (UpdateSQL) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateSQL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var dtColumns = CreateType<DataTable>();
            var li = CreateType<SPListItem>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var methodUpdateSQLPrametersTypes = new Type[] { typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };
            object[] parametersOfUpdateSQL = { sTableName, dtColumns, li, arrayList_defaultColumns, mandatoryHiddenFlds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodUpdateSQL, parametersOfUpdateSQL, methodUpdateSQLPrametersTypes);

            // Assert
            parametersOfUpdateSQL.ShouldNotBeNull();
            parametersOfUpdateSQL.Length.ShouldBe(5);
            methodUpdateSQLPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateSQL_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateSQLPrametersTypes = new Type[] { typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateSQL, Fixture, methodUpdateSQLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateSQLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (UpdateSQL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateSQL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateSQLPrametersTypes = new Type[] { typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateSQL, Fixture, methodUpdateSQLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateSQLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateSQL) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateSQL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateSQL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateSQL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateSQL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateSQL, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteSQL) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteSQL_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSQLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteSQL, Fixture, methodDeleteSQLPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSQL) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteSQL_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteSQL(sTableName, listid, itemid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteSQL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodDeleteSQLPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(int) };
            object[] parametersOfDeleteSQL = { sTableName, listid, itemid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteSQL, methodDeleteSQLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfDeleteSQL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodDeleteSQL, parametersOfDeleteSQL, methodDeleteSQLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteSQL.ShouldNotBeNull();
            parametersOfDeleteSQL.Length.ShouldBe(3);
            methodDeleteSQLPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteSQL) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteSQL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodDeleteSQLPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(int) };
            object[] parametersOfDeleteSQL = { sTableName, listid, itemid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodDeleteSQL, parametersOfDeleteSQL, methodDeleteSQLPrametersTypes);

            // Assert
            parametersOfDeleteSQL.ShouldNotBeNull();
            parametersOfDeleteSQL.Length.ShouldBe(3);
            methodDeleteSQLPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteSQL_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteSQLPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteSQL, Fixture, methodDeleteSQLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteSQLPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteSQL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteSQL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteSQLPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteSQL, Fixture, methodDeleteSQLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteSQLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteSQL) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteSQL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteSQL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteSQL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteSQL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteSQL, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetListColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetListColumns(sListName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListColumns = { sListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListColumns, methodGetListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListColumns.ShouldNotBeNull();
            parametersOfGetListColumns.Length.ShouldBe(1);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListColumns = { sListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

            // Assert
            parametersOfGetListColumns.ShouldNotBeNull();
            parametersOfGetListColumns.Length.ShouldBe(1);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (VerifyListColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_VerifyListColumns_Method_Call_Internally(Type[] types)
        {
            var methodVerifyListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodVerifyListColumns, Fixture, methodVerifyListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (VerifyListColumns) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_VerifyListColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var columns = CreateType<DataTable>();
            var tableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.VerifyListColumns(columns, tableName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (VerifyListColumns) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_VerifyListColumns_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var columns = CreateType<DataTable>();
            var tableName = CreateType<string>();
            var methodVerifyListColumnsPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            object[] parametersOfVerifyListColumns = { columns, tableName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodVerifyListColumns, methodVerifyListColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfVerifyListColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfVerifyListColumns.ShouldNotBeNull();
            parametersOfVerifyListColumns.Length.ShouldBe(2);
            methodVerifyListColumnsPrametersTypes.Length.ShouldBe(2);
            methodVerifyListColumnsPrametersTypes.Length.ShouldBe(parametersOfVerifyListColumns.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (VerifyListColumns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_VerifyListColumns_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var columns = CreateType<DataTable>();
            var tableName = CreateType<string>();
            var methodVerifyListColumnsPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            object[] parametersOfVerifyListColumns = { columns, tableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportDataInstance, MethodVerifyListColumns, parametersOfVerifyListColumns, methodVerifyListColumnsPrametersTypes);

            // Assert
            parametersOfVerifyListColumns.ShouldNotBeNull();
            parametersOfVerifyListColumns.Length.ShouldBe(2);
            methodVerifyListColumnsPrametersTypes.Length.ShouldBe(2);
            methodVerifyListColumnsPrametersTypes.Length.ShouldBe(parametersOfVerifyListColumns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (VerifyListColumns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_VerifyListColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodVerifyListColumns, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (VerifyListColumns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_VerifyListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodVerifyListColumnsPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodVerifyListColumns, Fixture, methodVerifyListColumnsPrametersTypes);

            // Assert
            methodVerifyListColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (VerifyListColumns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_VerifyListColumns_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodVerifyListColumns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetListColumns_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var listuid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetListColumns(listuid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listuid = CreateType<Guid>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListColumns = { listuid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListColumns, methodGetListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListColumns.ShouldNotBeNull();
            parametersOfGetListColumns.Length.ShouldBe(1);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listuid = CreateType<Guid>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListColumns = { listuid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

            // Assert
            parametersOfGetListColumns.ShouldNotBeNull();
            parametersOfGetListColumns.Length.ShouldBe(1);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListColumns, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListColumns_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListColumns, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListReportsWork) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_ListReportsWork_Method_Call_Internally(Type[] types)
        {
            var methodListReportsWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodListReportsWork, Fixture, methodListReportsWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (ListReportsWork) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListReportsWork_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.ListReportsWork(sTableName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ListReportsWork) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListReportsWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var methodListReportsWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfListReportsWork = { sTableName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListReportsWork, methodListReportsWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfListReportsWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodListReportsWork, parametersOfListReportsWork, methodListReportsWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfListReportsWork.ShouldNotBeNull();
            parametersOfListReportsWork.Length.ShouldBe(1);
            methodListReportsWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ListReportsWork) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListReportsWork_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var methodListReportsWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfListReportsWork = { sTableName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListReportsWork, methodListReportsWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfListReportsWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodListReportsWork, parametersOfListReportsWork, methodListReportsWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfListReportsWork.ShouldNotBeNull();
            parametersOfListReportsWork.Length.ShouldBe(1);
            methodListReportsWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ListReportsWork) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListReportsWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sTableName = CreateType<string>();
            var methodListReportsWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfListReportsWork = { sTableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodListReportsWork, parametersOfListReportsWork, methodListReportsWorkPrametersTypes);

            // Assert
            parametersOfListReportsWork.ShouldNotBeNull();
            parametersOfListReportsWork.Length.ShouldBe(1);
            methodListReportsWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListReportsWork) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListReportsWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListReportsWorkPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodListReportsWork, Fixture, methodListReportsWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodListReportsWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListReportsWork) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListReportsWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListReportsWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ListReportsWork) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListReportsWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListReportsWork, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_Dispose_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.Dispose();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_Dispose_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfDispose);

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
        public void AUT_ReportData_Dispose_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportDataInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

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
        public void AUT_ReportData_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_Dispose_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_BulkInsert_Method_Call_Internally(Type[] types)
        {
            var methodBulkInsertPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodBulkInsert, Fixture, methodBulkInsertPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_BulkInsert_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.BulkInsert(dsLists, timerjobguid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_BulkInsert_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            object[] parametersOfBulkInsert = { dsLists, timerjobguid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBulkInsert, methodBulkInsertPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfBulkInsert);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodBulkInsert, parametersOfBulkInsert, methodBulkInsertPrametersTypes);

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
        public void AUT_ReportData_BulkInsert_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            object[] parametersOfBulkInsert = { dsLists, timerjobguid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBulkInsert, methodBulkInsertPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfBulkInsert);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodBulkInsert, parametersOfBulkInsert, methodBulkInsertPrametersTypes);

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
        public void AUT_ReportData_BulkInsert_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            object[] parametersOfBulkInsert = { dsLists, timerjobguid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodBulkInsert, parametersOfBulkInsert, methodBulkInsertPrametersTypes);

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
        public void AUT_ReportData_BulkInsert_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBulkInsertPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodBulkInsert, Fixture, methodBulkInsertPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBulkInsertPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_BulkInsert_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBulkInsert, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BulkInsert) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_BulkInsert_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBulkInsert, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_ReportError_Method_Call_Internally(Type[] types)
        {
            var methodReportErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodReportError, Fixture, methodReportErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ReportError_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var sListName = CreateType<string>();
            var sErrMsg = CreateType<string>();
            var sSection = CreateType<string>();
            var iErrType = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.ReportError(listid, sListName, sErrMsg, sSection, iErrType);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ReportError_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var sListName = CreateType<string>();
            var sErrMsg = CreateType<string>();
            var sSection = CreateType<string>();
            var iErrType = CreateType<int>();
            var methodReportErrorPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfReportError = { listid, sListName, sErrMsg, sSection, iErrType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReportError, methodReportErrorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfReportError);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReportError.ShouldNotBeNull();
            parametersOfReportError.Length.ShouldBe(5);
            methodReportErrorPrametersTypes.Length.ShouldBe(5);
            methodReportErrorPrametersTypes.Length.ShouldBe(parametersOfReportError.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ReportError_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var sListName = CreateType<string>();
            var sErrMsg = CreateType<string>();
            var sSection = CreateType<string>();
            var iErrType = CreateType<int>();
            var methodReportErrorPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfReportError = { listid, sListName, sErrMsg, sSection, iErrType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportDataInstance, MethodReportError, parametersOfReportError, methodReportErrorPrametersTypes);

            // Assert
            parametersOfReportError.ShouldNotBeNull();
            parametersOfReportError.Length.ShouldBe(5);
            methodReportErrorPrametersTypes.Length.ShouldBe(5);
            methodReportErrorPrametersTypes.Length.ShouldBe(parametersOfReportError.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ReportError_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReportError, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ReportError_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReportErrorPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodReportError, Fixture, methodReportErrorPrametersTypes);

            // Assert
            methodReportErrorPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ReportError_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReportError, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetMappedFields_Method_Call_Internally(Type[] types)
        {
            var methodGetMappedFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetMappedFields, Fixture, methodGetMappedFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMappedFields_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetMappedFields();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMappedFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsPrametersTypes = null;
            object[] parametersOfGetMappedFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetMappedFields, methodGetMappedFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfGetMappedFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetMappedFields.ShouldBeNull();
            methodGetMappedFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMappedFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsPrametersTypes = null;
            object[] parametersOfGetMappedFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportDataInstance, MethodGetMappedFields, parametersOfGetMappedFields, methodGetMappedFieldsPrametersTypes);

            // Assert
            parametersOfGetMappedFields.ShouldBeNull();
            methodGetMappedFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMappedFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetMappedFields, Fixture, methodGetMappedFieldsPrametersTypes);

            // Assert
            methodGetMappedFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetMappedFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMappedFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_LogStatus_Method_Call_Internally(Type[] types)
        {
            var methodLogStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodLogStatus, Fixture, methodLogStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var RPTListID = CreateType<string>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.LogStatus(RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var RPTListID = CreateType<string>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var methodLogStatusPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfLogStatus = { RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLogStatus, methodLogStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfLogStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLogStatus.ShouldNotBeNull();
            parametersOfLogStatus.Length.ShouldBe(6);
            methodLogStatusPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var RPTListID = CreateType<string>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var methodLogStatusPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfLogStatus = { RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLogStatus, methodLogStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfLogStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLogStatus.ShouldNotBeNull();
            parametersOfLogStatus.Length.ShouldBe(6);
            methodLogStatusPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var RPTListID = CreateType<string>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var methodLogStatusPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfLogStatus = { RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

            // Assert
            parametersOfLogStatus.ShouldNotBeNull();
            parametersOfLogStatus.Length.ShouldBe(6);
            methodLogStatusPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogStatusPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodLogStatus, Fixture, methodLogStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLogStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogStatus, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_ProcessAssignments_Method_Call_Internally(Type[] types)
        {
            var methodProcessAssignmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodProcessAssignments, Fixture, methodProcessAssignmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcessAssignments_Method_DirectCall_Throw_Exception_Test()
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
            executeAction = () => _reportDataInstance.ProcessAssignments(sWork, sAssignedTo, StartDate, DueDate, ListID, SiteID, ItemID, sListName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcessAssignments_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfProcessAssignments);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodProcessAssignments, parametersOfProcessAssignments, methodProcessAssignmentsPrametersTypes);

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
        public void AUT_ReportData_ProcessAssignments_Method_Call_With_Results_Should_Not_Be_Null_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfProcessAssignments);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodProcessAssignments, parametersOfProcessAssignments, methodProcessAssignmentsPrametersTypes);

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
        public void AUT_ReportData_ProcessAssignments_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodProcessAssignments, parametersOfProcessAssignments, methodProcessAssignmentsPrametersTypes);

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
        public void AUT_ReportData_ProcessAssignments_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessAssignmentsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(object), typeof(object), typeof(Guid), typeof(Guid), typeof(int), typeof(string) };
            const int parametersCount = 8;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodProcessAssignments, Fixture, methodProcessAssignmentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessAssignmentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcessAssignments_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessAssignments, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProcessAssignments) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ProcessAssignments_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (InsertListItem) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InsertListItem_Method_Call_Internally(Type[] types)
        {
            var methodInsertListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertListItem, Fixture, methodInsertListItemPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertListItem) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InsertListItem(sSQL);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InsertListItem) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            var methodInsertListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInsertListItem = { sSQL };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertListItem, methodInsertListItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertListItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertListItem, parametersOfInsertListItem, methodInsertListItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertListItem.ShouldNotBeNull();
            parametersOfInsertListItem.Length.ShouldBe(1);
            methodInsertListItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (InsertListItem) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListItem_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            var methodInsertListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInsertListItem = { sSQL };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertListItem, methodInsertListItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertListItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertListItem, parametersOfInsertListItem, methodInsertListItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertListItem.ShouldNotBeNull();
            parametersOfInsertListItem.Length.ShouldBe(1);
            methodInsertListItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (InsertListItem) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            var methodInsertListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInsertListItem = { sSQL };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertListItem, parametersOfInsertListItem, methodInsertListItemPrametersTypes);

            // Assert
            parametersOfInsertListItem.ShouldNotBeNull();
            parametersOfInsertListItem.Length.ShouldBe(1);
            methodInsertListItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertListItem) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertListItemPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertListItem, Fixture, methodInsertListItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertListItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertListItem) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertListItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertListItem) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertListItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertListItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListItem) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_UpdateListItem_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateListItem, Fixture, methodUpdateListItemPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListItem) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.UpdateListItem(sSQL);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateListItem) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            var methodUpdateListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateListItem = { sSQL };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateListItem, methodUpdateListItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfUpdateListItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateListItem, parametersOfUpdateListItem, methodUpdateListItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateListItem.ShouldNotBeNull();
            parametersOfUpdateListItem.Length.ShouldBe(1);
            methodUpdateListItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateListItem) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListItem_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            var methodUpdateListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateListItem = { sSQL };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateListItem, methodUpdateListItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfUpdateListItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateListItem, parametersOfUpdateListItem, methodUpdateListItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateListItem.ShouldNotBeNull();
            parametersOfUpdateListItem.Length.ShouldBe(1);
            methodUpdateListItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateListItem) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            var methodUpdateListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateListItem = { sSQL };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodUpdateListItem, parametersOfUpdateListItem, methodUpdateListItemPrametersTypes);

            // Assert
            parametersOfUpdateListItem.ShouldNotBeNull();
            parametersOfUpdateListItem.Length.ShouldBe(1);
            methodUpdateListItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListItem) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListItemPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateListItem, Fixture, methodUpdateListItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateListItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListItem) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateListItem) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateListItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateListItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteListItem) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_DeleteListItem_Method_Call_Internally(Type[] types)
        {
            var methodDeleteListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteListItem, Fixture, methodDeleteListItemPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteListItem) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.DeleteListItem(sSQL);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteListItem) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            var methodDeleteListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteListItem = { sSQL };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteListItem, methodDeleteListItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteListItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteListItem, parametersOfDeleteListItem, methodDeleteListItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteListItem.ShouldNotBeNull();
            parametersOfDeleteListItem.Length.ShouldBe(1);
            methodDeleteListItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteListItem) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListItem_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            var methodDeleteListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteListItem = { sSQL };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteListItem, methodDeleteListItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfDeleteListItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteListItem, parametersOfDeleteListItem, methodDeleteListItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteListItem.ShouldNotBeNull();
            parametersOfDeleteListItem.Length.ShouldBe(1);
            methodDeleteListItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteListItem) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSQL = CreateType<string>();
            var methodDeleteListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteListItem = { sSQL };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodDeleteListItem, parametersOfDeleteListItem, methodDeleteListItemPrametersTypes);

            // Assert
            parametersOfDeleteListItem.ShouldNotBeNull();
            parametersOfDeleteListItem.Length.ShouldBe(1);
            methodDeleteListItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteListItem) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteListItemPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodDeleteListItem, Fixture, methodDeleteListItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteListItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteListItem) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteListItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteListItem) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_DeleteListItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteListItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_AddColums_Method_Call_Internally(Type[] types)
        {
            var methodAddColumsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColums, Fixture, methodAddColumsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodAddColumsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfAddColums = { dt };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddColums, methodAddColumsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfAddColums);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodAddColums, parametersOfAddColums, methodAddColumsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddColums.ShouldNotBeNull();
            parametersOfAddColums.Length.ShouldBe(1);
            methodAddColumsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodAddColumsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfAddColums = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodAddColums, parametersOfAddColums, methodAddColumsPrametersTypes);

            // Assert
            parametersOfAddColums.ShouldNotBeNull();
            parametersOfAddColums.Length.ShouldBe(1);
            methodAddColumsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddColumsPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColums, Fixture, methodAddColumsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddColumsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumsPrametersTypes = new Type[] { typeof(DataTable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColums, Fixture, methodAddColumsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddColumsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColums, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColums, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_AddColums_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddColumsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColums, Fixture, methodAddColumsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var dt = CreateType<DataTable>();
            var methodAddColumsPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable) };
            object[] parametersOfAddColums = { item, dt };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddColums, methodAddColumsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfAddColums);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodAddColums, parametersOfAddColums, methodAddColumsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddColums.ShouldNotBeNull();
            parametersOfAddColums.Length.ShouldBe(2);
            methodAddColumsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var dt = CreateType<DataTable>();
            var methodAddColumsPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable) };
            object[] parametersOfAddColums = { item, dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodAddColums, parametersOfAddColums, methodAddColumsPrametersTypes);

            // Assert
            parametersOfAddColums.ShouldNotBeNull();
            parametersOfAddColums.Length.ShouldBe(2);
            methodAddColumsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddColumsPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColums, Fixture, methodAddColumsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddColumsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumsPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColums, Fixture, methodAddColumsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddColumsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColums, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddColums) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColums_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColums, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_IsLookUpField_Method_Call_Internally(Type[] types)
        {
            var methodIsLookUpFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodIsLookUpField, Fixture, methodIsLookUpFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsLookUpField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var sColumnName = CreateType<string>();
            var methodIsLookUpFieldPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfIsLookUpField = { sListName, sColumnName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLookUpField, methodIsLookUpFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfIsLookUpField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodIsLookUpField, parametersOfIsLookUpField, methodIsLookUpFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLookUpField.ShouldNotBeNull();
            parametersOfIsLookUpField.Length.ShouldBe(2);
            methodIsLookUpFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsLookUpField_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var sColumnName = CreateType<string>();
            var methodIsLookUpFieldPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfIsLookUpField = { sListName, sColumnName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLookUpField, methodIsLookUpFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfIsLookUpField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodIsLookUpField, parametersOfIsLookUpField, methodIsLookUpFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLookUpField.ShouldNotBeNull();
            parametersOfIsLookUpField.Length.ShouldBe(2);
            methodIsLookUpFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsLookUpField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var sColumnName = CreateType<string>();
            var methodIsLookUpFieldPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfIsLookUpField = { sListName, sColumnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodIsLookUpField, parametersOfIsLookUpField, methodIsLookUpFieldPrametersTypes);

            // Assert
            parametersOfIsLookUpField.ShouldNotBeNull();
            parametersOfIsLookUpField.Length.ShouldBe(2);
            methodIsLookUpFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsLookUpField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsLookUpFieldPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodIsLookUpField, Fixture, methodIsLookUpFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsLookUpFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsLookUpField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsLookUpField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_IsLookUpField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsLookUpField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddLookUpFieldValues) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_AddLookUpFieldValues_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddLookUpFieldValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddLookUpFieldValues, Fixture, methodAddLookUpFieldValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (AddLookUpFieldValues) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddLookUpFieldValues_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var sValueType = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportData.AddLookUpFieldValues(sValue, sValueType);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddLookUpFieldValues) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddLookUpFieldValues_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var sValueType = CreateType<string>();
            var methodAddLookUpFieldValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddLookUpFieldValues = { sValue, sValueType };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddLookUpFieldValues, methodAddLookUpFieldValuesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddLookUpFieldValues, Fixture, methodAddLookUpFieldValuesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddLookUpFieldValues, parametersOfAddLookUpFieldValues, methodAddLookUpFieldValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddLookUpFieldValues.ShouldNotBeNull();
            parametersOfAddLookUpFieldValues.Length.ShouldBe(2);
            methodAddLookUpFieldValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddLookUpFieldValues, parametersOfAddLookUpFieldValues, methodAddLookUpFieldValuesPrametersTypes));
        }

        #endregion

        #region Method Call : (AddLookUpFieldValues) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddLookUpFieldValues_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var sValueType = CreateType<string>();
            var methodAddLookUpFieldValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddLookUpFieldValues = { sValue, sValueType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddLookUpFieldValues, methodAddLookUpFieldValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfAddLookUpFieldValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddLookUpFieldValues.ShouldNotBeNull();
            parametersOfAddLookUpFieldValues.Length.ShouldBe(2);
            methodAddLookUpFieldValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddLookUpFieldValues) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddLookUpFieldValues_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var sValueType = CreateType<string>();
            var methodAddLookUpFieldValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddLookUpFieldValues = { sValue, sValueType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddLookUpFieldValues, parametersOfAddLookUpFieldValues, methodAddLookUpFieldValuesPrametersTypes);

            // Assert
            parametersOfAddLookUpFieldValues.ShouldNotBeNull();
            parametersOfAddLookUpFieldValues.Length.ShouldBe(2);
            methodAddLookUpFieldValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddLookUpFieldValues) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddLookUpFieldValues_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodAddLookUpFieldValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddLookUpFieldValues, Fixture, methodAddLookUpFieldValuesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAddLookUpFieldValuesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddLookUpFieldValues) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddLookUpFieldValues_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddLookUpFieldValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddLookUpFieldValues, Fixture, methodAddLookUpFieldValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddLookUpFieldValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddLookUpFieldValues) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddLookUpFieldValues_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddLookUpFieldValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddLookUpFieldValues) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddLookUpFieldValues_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddLookUpFieldValues, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddMultiChoiceValues) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_AddMultiChoiceValues_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddMultiChoiceValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddMultiChoiceValues, Fixture, methodAddMultiChoiceValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (AddMultiChoiceValues) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMultiChoiceValues_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var sValueType = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportData.AddMultiChoiceValues(sValue, sValueType);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddMultiChoiceValues) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMultiChoiceValues_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var sValueType = CreateType<string>();
            var methodAddMultiChoiceValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddMultiChoiceValues = { sValue, sValueType };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddMultiChoiceValues, methodAddMultiChoiceValuesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddMultiChoiceValues, Fixture, methodAddMultiChoiceValuesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddMultiChoiceValues, parametersOfAddMultiChoiceValues, methodAddMultiChoiceValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddMultiChoiceValues.ShouldNotBeNull();
            parametersOfAddMultiChoiceValues.Length.ShouldBe(2);
            methodAddMultiChoiceValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddMultiChoiceValues, parametersOfAddMultiChoiceValues, methodAddMultiChoiceValuesPrametersTypes));
        }

        #endregion

        #region Method Call : (AddMultiChoiceValues) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMultiChoiceValues_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var sValueType = CreateType<string>();
            var methodAddMultiChoiceValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddMultiChoiceValues = { sValue, sValueType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddMultiChoiceValues, methodAddMultiChoiceValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfAddMultiChoiceValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddMultiChoiceValues.ShouldNotBeNull();
            parametersOfAddMultiChoiceValues.Length.ShouldBe(2);
            methodAddMultiChoiceValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddMultiChoiceValues) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMultiChoiceValues_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var sValueType = CreateType<string>();
            var methodAddMultiChoiceValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddMultiChoiceValues = { sValue, sValueType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddMultiChoiceValues, parametersOfAddMultiChoiceValues, methodAddMultiChoiceValuesPrametersTypes);

            // Assert
            parametersOfAddMultiChoiceValues.ShouldNotBeNull();
            parametersOfAddMultiChoiceValues.Length.ShouldBe(2);
            methodAddMultiChoiceValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddMultiChoiceValues) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMultiChoiceValues_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodAddMultiChoiceValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddMultiChoiceValues, Fixture, methodAddMultiChoiceValuesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAddMultiChoiceValuesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddMultiChoiceValues) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMultiChoiceValues_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddMultiChoiceValuesPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodAddMultiChoiceValues, Fixture, methodAddMultiChoiceValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddMultiChoiceValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddMultiChoiceValues) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMultiChoiceValues_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddMultiChoiceValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddMultiChoiceValues) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMultiChoiceValues_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddMultiChoiceValues, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_AddColumnValues_Method_Call_Internally(Type[] types)
        {
            var methodAddColumnValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColumnValues, Fixture, methodAddColumnValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var dtColumns = CreateType<DataTable>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var sAction = CreateType<string>();
            var sAssignedToText = CreateType<string>();
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string), typeof(string) };
            object[] parametersOfAddColumnValues = { li, dtColumns, arrayList_defaultColumns, mandatoryHiddenFlds, sAction, sAssignedToText };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddColumnValues, methodAddColumnValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfAddColumnValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodAddColumnValues, parametersOfAddColumnValues, methodAddColumnValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddColumnValues.ShouldNotBeNull();
            parametersOfAddColumnValues.Length.ShouldBe(6);
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var dtColumns = CreateType<DataTable>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var sAction = CreateType<string>();
            var sAssignedToText = CreateType<string>();
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string), typeof(string) };
            object[] parametersOfAddColumnValues = { li, dtColumns, arrayList_defaultColumns, mandatoryHiddenFlds, sAction, sAssignedToText };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodAddColumnValues, parametersOfAddColumnValues, methodAddColumnValuesPrametersTypes);

            // Assert
            parametersOfAddColumnValues.ShouldNotBeNull();
            parametersOfAddColumnValues.Length.ShouldBe(6);
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColumnValues, Fixture, methodAddColumnValuesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string), typeof(string) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColumnValues, Fixture, methodAddColumnValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumnValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumnValues, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_AddColumnValues_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddColumnValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColumnValues, Fixture, methodAddColumnValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var dtColumns = CreateType<DataTable>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var sAction = CreateType<string>();
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string) };
            object[] parametersOfAddColumnValues = { li, dtColumns, arrayList_defaultColumns, mandatoryHiddenFlds, sAction };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddColumnValues, methodAddColumnValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfAddColumnValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodAddColumnValues, parametersOfAddColumnValues, methodAddColumnValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddColumnValues.ShouldNotBeNull();
            parametersOfAddColumnValues.Length.ShouldBe(5);
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var dtColumns = CreateType<DataTable>();
            var arrayList_defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var sAction = CreateType<string>();
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string) };
            object[] parametersOfAddColumnValues = { li, dtColumns, arrayList_defaultColumns, mandatoryHiddenFlds, sAction };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodAddColumnValues, parametersOfAddColumnValues, methodAddColumnValuesPrametersTypes);

            // Assert
            parametersOfAddColumnValues.ShouldNotBeNull();
            parametersOfAddColumnValues.Length.ShouldBe(5);
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColumnValues, Fixture, methodAddColumnValuesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddColumnValues, Fixture, methodAddColumnValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumnValues, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddColumnValues_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumnValues, 1);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveTags) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_RemoveTags_Method_Call_Internally(Type[] types)
        {
            var methodRemoveTagsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodRemoveTags, Fixture, methodRemoveTagsPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveTags) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RemoveTags_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.RemoveTags(sValue, field);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RemoveTags) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RemoveTags_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var field = CreateType<SPField>();
            var methodRemoveTagsPrametersTypes = new Type[] { typeof(string), typeof(SPField) };
            object[] parametersOfRemoveTags = { sValue, field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveTags, methodRemoveTagsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfRemoveTags);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodRemoveTags, parametersOfRemoveTags, methodRemoveTagsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRemoveTags.ShouldNotBeNull();
            parametersOfRemoveTags.Length.ShouldBe(2);
            methodRemoveTagsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RemoveTags) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RemoveTags_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sValue = CreateType<string>();
            var field = CreateType<SPField>();
            var methodRemoveTagsPrametersTypes = new Type[] { typeof(string), typeof(SPField) };
            object[] parametersOfRemoveTags = { sValue, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodRemoveTags, parametersOfRemoveTags, methodRemoveTagsPrametersTypes);

            // Assert
            parametersOfRemoveTags.ShouldNotBeNull();
            parametersOfRemoveTags.Length.ShouldBe(2);
            methodRemoveTagsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveTags) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RemoveTags_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRemoveTagsPrametersTypes = new Type[] { typeof(string), typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodRemoveTags, Fixture, methodRemoveTagsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRemoveTagsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RemoveTags) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RemoveTags_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveTagsPrametersTypes = new Type[] { typeof(string), typeof(SPField) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodRemoveTags, Fixture, methodRemoveTagsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveTagsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveTags) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RemoveTags_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveTags, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveTags) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_RemoveTags_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveTags, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetListId_Method_Call_Internally(Type[] types)
        {
            var methodGetListIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListId, Fixture, methodGetListIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetListId(sListName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListId_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodGetListIdPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListId = { sListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListId, methodGetListIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, Guid>(_reportDataInstanceFixture, out exception1, parametersOfGetListId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, Guid>(_reportDataInstance, MethodGetListId, parametersOfGetListId, methodGetListIdPrametersTypes);

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
        public void AUT_ReportData_GetListId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodGetListIdPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListId = { sListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, Guid>(_reportDataInstance, MethodGetListId, parametersOfGetListId, methodGetListIdPrametersTypes);

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
        public void AUT_ReportData_GetListId_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListIdPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListId, Fixture, methodGetListIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListIdPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetListId, Fixture, methodGetListIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListId) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetListId_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_PopulateDefaultColumnValue_Method_Call_Internally(Type[] types)
        {
            var methodPopulateDefaultColumnValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodPopulateDefaultColumnValue, Fixture, methodPopulateDefaultColumnValuePrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateDefaultColumnValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodPopulateDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            object[] parametersOfPopulateDefaultColumnValue = { sColumn, li };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPopulateDefaultColumnValue, methodPopulateDefaultColumnValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, SqlParameter>(_reportDataInstanceFixture, out exception1, parametersOfPopulateDefaultColumnValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, SqlParameter>(_reportDataInstance, MethodPopulateDefaultColumnValue, parametersOfPopulateDefaultColumnValue, methodPopulateDefaultColumnValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPopulateDefaultColumnValue.ShouldNotBeNull();
            parametersOfPopulateDefaultColumnValue.Length.ShouldBe(2);
            methodPopulateDefaultColumnValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateDefaultColumnValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodPopulateDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            object[] parametersOfPopulateDefaultColumnValue = { sColumn, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, SqlParameter>(_reportDataInstance, MethodPopulateDefaultColumnValue, parametersOfPopulateDefaultColumnValue, methodPopulateDefaultColumnValuePrametersTypes);

            // Assert
            parametersOfPopulateDefaultColumnValue.ShouldNotBeNull();
            parametersOfPopulateDefaultColumnValue.Length.ShouldBe(2);
            methodPopulateDefaultColumnValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateDefaultColumnValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPopulateDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodPopulateDefaultColumnValue, Fixture, methodPopulateDefaultColumnValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPopulateDefaultColumnValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateDefaultColumnValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodPopulateDefaultColumnValue, Fixture, methodPopulateDefaultColumnValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPopulateDefaultColumnValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateDefaultColumnValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateDefaultColumnValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateDefaultColumnValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateDefaultColumnValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Internally(Type[] types)
        {
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, Fixture, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            object[] parametersOfPopulateMandatoryHiddenFldsColumnValue = { sColumn, li };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPopulateMandatoryHiddenFldsColumnValue, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, SqlParameter>(_reportDataInstanceFixture, out exception1, parametersOfPopulateMandatoryHiddenFldsColumnValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, SqlParameter>(_reportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, parametersOfPopulateMandatoryHiddenFldsColumnValue, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPopulateMandatoryHiddenFldsColumnValue.ShouldNotBeNull();
            parametersOfPopulateMandatoryHiddenFldsColumnValue.Length.ShouldBe(2);
            methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            object[] parametersOfPopulateMandatoryHiddenFldsColumnValue = { sColumn, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, SqlParameter>(_reportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, parametersOfPopulateMandatoryHiddenFldsColumnValue, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);

            // Assert
            parametersOfPopulateMandatoryHiddenFldsColumnValue.ShouldNotBeNull();
            parametersOfPopulateMandatoryHiddenFldsColumnValue.Length.ShouldBe(2);
            methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, Fixture, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, Fixture, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateMandatoryHiddenFldsColumnValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateMandatoryHiddenFldsColumnValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : SqlParameter) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetParam_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetParamPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodGetParam, Fixture, methodGetParamPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : SqlParameter) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetParam_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var sColumnName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportData.GetParam(field, sColumnName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetParam_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var sColumnName = CreateType<string>();
            var methodGetParamPrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            object[] parametersOfGetParam = { field, sColumnName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParam, methodGetParamPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodGetParam, Fixture, methodGetParamPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SqlParameter>(_reportDataInstanceFixture, _reportDataInstanceType, MethodGetParam, parametersOfGetParam, methodGetParamPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfGetParam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetParam.ShouldNotBeNull();
            parametersOfGetParam.Length.ShouldBe(2);
            methodGetParamPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : SqlParameter) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetParam_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var sColumnName = CreateType<string>();
            var methodGetParamPrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            object[] parametersOfGetParam = { field, sColumnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SqlParameter>(_reportDataInstanceFixture, _reportDataInstanceType, MethodGetParam, parametersOfGetParam, methodGetParamPrametersTypes);

            // Assert
            parametersOfGetParam.ShouldNotBeNull();
            parametersOfGetParam.Length.ShouldBe(2);
            methodGetParamPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetParam_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetParamPrametersTypes = new Type[] { typeof(SPField), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodGetParam, Fixture, methodGetParamPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetParamPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : SqlParameter) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetParam_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetParamPrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportDataInstanceFixture, _reportDataInstanceType, MethodGetParam, Fixture, methodGetParamPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetParamPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : SqlParameter) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetParam_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParam, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : SqlParameter) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetParam_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetParam, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertAllItemsDB) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InsertAllItemsDB_Method_Call_Internally(Type[] types)
        {
            var methodInsertAllItemsDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertAllItemsDB, Fixture, methodInsertAllItemsDBPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertAllItemsDB) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertAllItemsDB_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InsertAllItemsDB(dsLists, timerjobguid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InsertAllItemsDB) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertAllItemsDB_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            var methodInsertAllItemsDBPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            object[] parametersOfInsertAllItemsDB = { dsLists, timerjobguid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertAllItemsDB, methodInsertAllItemsDBPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertAllItemsDB);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertAllItemsDB, parametersOfInsertAllItemsDB, methodInsertAllItemsDBPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertAllItemsDB.ShouldNotBeNull();
            parametersOfInsertAllItemsDB.Length.ShouldBe(2);
            methodInsertAllItemsDBPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (InsertAllItemsDB) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertAllItemsDB_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            var methodInsertAllItemsDBPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            object[] parametersOfInsertAllItemsDB = { dsLists, timerjobguid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertAllItemsDB, methodInsertAllItemsDBPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfInsertAllItemsDB);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertAllItemsDB, parametersOfInsertAllItemsDB, methodInsertAllItemsDBPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInsertAllItemsDB.ShouldNotBeNull();
            parametersOfInsertAllItemsDB.Length.ShouldBe(2);
            methodInsertAllItemsDBPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (InsertAllItemsDB) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertAllItemsDB_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dsLists = CreateType<DataSet>();
            var timerjobguid = CreateType<Guid>();
            var methodInsertAllItemsDBPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            object[] parametersOfInsertAllItemsDB = { dsLists, timerjobguid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodInsertAllItemsDB, parametersOfInsertAllItemsDB, methodInsertAllItemsDBPrametersTypes);

            // Assert
            parametersOfInsertAllItemsDB.ShouldNotBeNull();
            parametersOfInsertAllItemsDB.Length.ShouldBe(2);
            methodInsertAllItemsDBPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertAllItemsDB) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertAllItemsDB_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertAllItemsDBPrametersTypes = new Type[] { typeof(DataSet), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInsertAllItemsDB, Fixture, methodInsertAllItemsDBPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertAllItemsDBPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertAllItemsDB) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertAllItemsDB_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertAllItemsDB, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertAllItemsDB) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InsertAllItemsDB_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertAllItemsDB, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetClientReportingConnection) (Return Type : SqlConnection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetClientReportingConnection_Method_Call_Internally(Type[] types)
        {
            var methodGetClientReportingConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetClientReportingConnection, Fixture, methodGetClientReportingConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetClientReportingConnection) (Return Type : SqlConnection) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetClientReportingConnection_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetClientReportingConnection();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetClientReportingConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetClientReportingConnection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetClientReportingConnectionPrametersTypes = null;
            object[] parametersOfGetClientReportingConnection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetClientReportingConnection, methodGetClientReportingConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, SqlConnection>(_reportDataInstanceFixture, out exception1, parametersOfGetClientReportingConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, SqlConnection>(_reportDataInstance, MethodGetClientReportingConnection, parametersOfGetClientReportingConnection, methodGetClientReportingConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetClientReportingConnection.ShouldBeNull();
            methodGetClientReportingConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetClientReportingConnection) (Return Type : SqlConnection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetClientReportingConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetClientReportingConnectionPrametersTypes = null;
            object[] parametersOfGetClientReportingConnection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, SqlConnection>(_reportDataInstance, MethodGetClientReportingConnection, parametersOfGetClientReportingConnection, methodGetClientReportingConnectionPrametersTypes);

            // Assert
            parametersOfGetClientReportingConnection.ShouldBeNull();
            methodGetClientReportingConnectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetClientReportingConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetClientReportingConnection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetClientReportingConnectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetClientReportingConnection, Fixture, methodGetClientReportingConnectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetClientReportingConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetClientReportingConnection) (Return Type : SqlConnection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetClientReportingConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetClientReportingConnectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetClientReportingConnection, Fixture, methodGetClientReportingConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetClientReportingConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetClientReportingConnection) (Return Type : SqlConnection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetClientReportingConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetClientReportingConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultColumnValue) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetDefaultColumnValue_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultColumnValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDefaultColumnValue, Fixture, methodGetDefaultColumnValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultColumnValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDefaultColumnValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var blnGuid = CreateType<bool>();
            var methodGetDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(bool) };
            object[] parametersOfGetDefaultColumnValue = { sColumn, li, blnGuid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDefaultColumnValue, methodGetDefaultColumnValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, object>(_reportDataInstanceFixture, out exception1, parametersOfGetDefaultColumnValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, object>(_reportDataInstance, MethodGetDefaultColumnValue, parametersOfGetDefaultColumnValue, methodGetDefaultColumnValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDefaultColumnValue.ShouldNotBeNull();
            parametersOfGetDefaultColumnValue.Length.ShouldBe(3);
            methodGetDefaultColumnValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetDefaultColumnValue) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDefaultColumnValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var blnGuid = CreateType<bool>();
            var methodGetDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(bool) };
            object[] parametersOfGetDefaultColumnValue = { sColumn, li, blnGuid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, object>(_reportDataInstance, MethodGetDefaultColumnValue, parametersOfGetDefaultColumnValue, methodGetDefaultColumnValuePrametersTypes);

            // Assert
            parametersOfGetDefaultColumnValue.ShouldNotBeNull();
            parametersOfGetDefaultColumnValue.Length.ShouldBe(3);
            methodGetDefaultColumnValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumnValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDefaultColumnValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDefaultColumnValue, Fixture, methodGetDefaultColumnValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefaultColumnValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetDefaultColumnValue) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDefaultColumnValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetDefaultColumnValue, Fixture, methodGetDefaultColumnValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefaultColumnValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultColumnValue) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDefaultColumnValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefaultColumnValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultColumnValue) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetDefaultColumnValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDefaultColumnValue, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListItemsDataTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_ListItemsDataTable_Method_Call_Internally(Type[] types)
        {
            var methodListItemsDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodListItemsDataTable, Fixture, methodListItemsDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (ListItemsDataTable) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListItemsDataTable_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var sTableName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var sListName = CreateType<string>();
            var _arrayListDefaultColumns = CreateType<ArrayList>();
            var error = CreateType<bool>();
            var errMsg = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.ListItemsDataTable(timerjobguid, sTableName, spWeb, sListName, _arrayListDefaultColumns, out error, out errMsg);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ListItemsDataTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListItemsDataTable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var sTableName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var sListName = CreateType<string>();
            var _arrayListDefaultColumns = CreateType<ArrayList>();
            var error = CreateType<bool>();
            var errMsg = CreateType<string>();
            var methodListItemsDataTablePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(SPWeb), typeof(string), typeof(ArrayList), typeof(bool), typeof(string) };
            object[] parametersOfListItemsDataTable = { timerjobguid, sTableName, spWeb, sListName, _arrayListDefaultColumns, error, errMsg };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListItemsDataTable, methodListItemsDataTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfListItemsDataTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodListItemsDataTable, parametersOfListItemsDataTable, methodListItemsDataTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfListItemsDataTable.ShouldNotBeNull();
            parametersOfListItemsDataTable.Length.ShouldBe(7);
            methodListItemsDataTablePrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (ListItemsDataTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListItemsDataTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var sTableName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var sListName = CreateType<string>();
            var _arrayListDefaultColumns = CreateType<ArrayList>();
            var error = CreateType<bool>();
            var errMsg = CreateType<string>();
            var methodListItemsDataTablePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(SPWeb), typeof(string), typeof(ArrayList), typeof(bool), typeof(string) };
            object[] parametersOfListItemsDataTable = { timerjobguid, sTableName, spWeb, sListName, _arrayListDefaultColumns, error, errMsg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodListItemsDataTable, parametersOfListItemsDataTable, methodListItemsDataTablePrametersTypes);

            // Assert
            parametersOfListItemsDataTable.ShouldNotBeNull();
            parametersOfListItemsDataTable.Length.ShouldBe(7);
            methodListItemsDataTablePrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListItemsDataTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListItemsDataTable_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodListItemsDataTablePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(SPWeb), typeof(string), typeof(ArrayList), typeof(bool), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodListItemsDataTable, Fixture, methodListItemsDataTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodListItemsDataTablePrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (ListItemsDataTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListItemsDataTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListItemsDataTablePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(SPWeb), typeof(string), typeof(ArrayList), typeof(bool), typeof(string) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodListItemsDataTable, Fixture, methodListItemsDataTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodListItemsDataTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListItemsDataTable) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListItemsDataTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListItemsDataTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ListItemsDataTable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ListItemsDataTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListItemsDataTable, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MyWorkListItemsDataTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_MyWorkListItemsDataTable_Method_Call_Internally(Type[] types)
        {
            var methodMyWorkListItemsDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodMyWorkListItemsDataTable, Fixture, methodMyWorkListItemsDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (MyWorkListItemsDataTable) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_MyWorkListItemsDataTable_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var sTableName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var sListName = CreateType<string>();
            var _arrayListDefaultColumns = CreateType<ArrayList>();
            var listId = CreateType<Guid>();
            var error = CreateType<bool>();
            var errMsg = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.MyWorkListItemsDataTable(timerjobguid, sTableName, spWeb, sListName, _arrayListDefaultColumns, listId, out error, out errMsg);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (MyWorkListItemsDataTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_MyWorkListItemsDataTable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var sTableName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var sListName = CreateType<string>();
            var _arrayListDefaultColumns = CreateType<ArrayList>();
            var listId = CreateType<Guid>();
            var error = CreateType<bool>();
            var errMsg = CreateType<string>();
            var methodMyWorkListItemsDataTablePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(SPWeb), typeof(string), typeof(ArrayList), typeof(Guid), typeof(bool), typeof(string) };
            object[] parametersOfMyWorkListItemsDataTable = { timerjobguid, sTableName, spWeb, sListName, _arrayListDefaultColumns, listId, error, errMsg };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMyWorkListItemsDataTable, methodMyWorkListItemsDataTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfMyWorkListItemsDataTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodMyWorkListItemsDataTable, parametersOfMyWorkListItemsDataTable, methodMyWorkListItemsDataTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfMyWorkListItemsDataTable.ShouldNotBeNull();
            parametersOfMyWorkListItemsDataTable.Length.ShouldBe(8);
            methodMyWorkListItemsDataTablePrametersTypes.Length.ShouldBe(8);
        }

        #endregion

        #region Method Call : (MyWorkListItemsDataTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_MyWorkListItemsDataTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timerjobguid = CreateType<Guid>();
            var sTableName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var sListName = CreateType<string>();
            var _arrayListDefaultColumns = CreateType<ArrayList>();
            var listId = CreateType<Guid>();
            var error = CreateType<bool>();
            var errMsg = CreateType<string>();
            var methodMyWorkListItemsDataTablePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(SPWeb), typeof(string), typeof(ArrayList), typeof(Guid), typeof(bool), typeof(string) };
            object[] parametersOfMyWorkListItemsDataTable = { timerjobguid, sTableName, spWeb, sListName, _arrayListDefaultColumns, listId, error, errMsg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodMyWorkListItemsDataTable, parametersOfMyWorkListItemsDataTable, methodMyWorkListItemsDataTablePrametersTypes);

            // Assert
            parametersOfMyWorkListItemsDataTable.ShouldNotBeNull();
            parametersOfMyWorkListItemsDataTable.Length.ShouldBe(8);
            methodMyWorkListItemsDataTablePrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MyWorkListItemsDataTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_MyWorkListItemsDataTable_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodMyWorkListItemsDataTablePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(SPWeb), typeof(string), typeof(ArrayList), typeof(Guid), typeof(bool), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodMyWorkListItemsDataTable, Fixture, methodMyWorkListItemsDataTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodMyWorkListItemsDataTablePrametersTypes.Length.ShouldBe(8);
        }

        #endregion

        #region Method Call : (MyWorkListItemsDataTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_MyWorkListItemsDataTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMyWorkListItemsDataTablePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(SPWeb), typeof(string), typeof(ArrayList), typeof(Guid), typeof(bool), typeof(string) };
            const int parametersCount = 8;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodMyWorkListItemsDataTable, Fixture, methodMyWorkListItemsDataTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMyWorkListItemsDataTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MyWorkListItemsDataTable) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_MyWorkListItemsDataTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMyWorkListItemsDataTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MyWorkListItemsDataTable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_MyWorkListItemsDataTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMyWorkListItemsDataTable, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_AddMetaInfoCols_Method_Call_Internally(Type[] types)
        {
            var methodAddMetaInfoColsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddMetaInfoCols, Fixture, methodAddMetaInfoColsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMetaInfoCols_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodAddMetaInfoColsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfAddMetaInfoCols = { dt };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddMetaInfoCols, methodAddMetaInfoColsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfAddMetaInfoCols);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodAddMetaInfoCols, parametersOfAddMetaInfoCols, methodAddMetaInfoColsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddMetaInfoCols.ShouldNotBeNull();
            parametersOfAddMetaInfoCols.Length.ShouldBe(1);
            methodAddMetaInfoColsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMetaInfoCols_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodAddMetaInfoColsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfAddMetaInfoCols = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodAddMetaInfoCols, parametersOfAddMetaInfoCols, methodAddMetaInfoColsPrametersTypes);

            // Assert
            parametersOfAddMetaInfoCols.ShouldNotBeNull();
            parametersOfAddMetaInfoCols.Length.ShouldBe(1);
            methodAddMetaInfoColsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMetaInfoCols_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddMetaInfoColsPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddMetaInfoCols, Fixture, methodAddMetaInfoColsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddMetaInfoColsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMetaInfoCols_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddMetaInfoColsPrametersTypes = new Type[] { typeof(DataTable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodAddMetaInfoCols, Fixture, methodAddMetaInfoColsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddMetaInfoColsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMetaInfoCols_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddMetaInfoCols, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_AddMetaInfoCols_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddMetaInfoCols, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_SnapshotLists_Method_Call_Internally(Type[] types)
        {
            var methodSnapshotListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodSnapshotLists, Fixture, methodSnapshotListsPrametersTypes);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_SnapshotLists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.SnapshotLists(listName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_SnapshotLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodSnapshotListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSnapshotLists = { listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSnapshotLists, methodSnapshotListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfSnapshotLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodSnapshotLists, parametersOfSnapshotLists, methodSnapshotListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSnapshotLists.ShouldNotBeNull();
            parametersOfSnapshotLists.Length.ShouldBe(1);
            methodSnapshotListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_SnapshotLists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodSnapshotListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSnapshotLists = { listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSnapshotLists, methodSnapshotListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfSnapshotLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodSnapshotLists, parametersOfSnapshotLists, methodSnapshotListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSnapshotLists.ShouldNotBeNull();
            parametersOfSnapshotLists.Length.ShouldBe(1);
            methodSnapshotListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_SnapshotLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodSnapshotListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSnapshotLists = { listName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodSnapshotLists, parametersOfSnapshotLists, methodSnapshotListsPrametersTypes);

            // Assert
            parametersOfSnapshotLists.ShouldNotBeNull();
            parametersOfSnapshotLists.Length.ShouldBe(1);
            methodSnapshotListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_SnapshotLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSnapshotListsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodSnapshotLists, Fixture, methodSnapshotListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSnapshotListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_SnapshotLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSnapshotLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SnapshotLists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_SnapshotLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSnapshotLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_InitializeStatusLog_Method_Call_Internally(Type[] types)
        {
            var methodInitializeStatusLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInitializeStatusLog, Fixture, methodInitializeStatusLogPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InitializeStatusLog_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.InitializeStatusLog();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InitializeStatusLog_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializeStatusLogPrametersTypes = null;
            object[] parametersOfInitializeStatusLog = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeStatusLog, methodInitializeStatusLogPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfInitializeStatusLog);

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
        public void AUT_ReportData_InitializeStatusLog_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializeStatusLogPrametersTypes = null;
            object[] parametersOfInitializeStatusLog = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportDataInstance, MethodInitializeStatusLog, parametersOfInitializeStatusLog, methodInitializeStatusLogPrametersTypes);

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
        public void AUT_ReportData_InitializeStatusLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializeStatusLogPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodInitializeStatusLog, Fixture, methodInitializeStatusLogPrametersTypes);

            // Assert
            methodInitializeStatusLogPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeStatusLog) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_InitializeStatusLog_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeStatusLog, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_LogStatus_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodLogStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodLogStatus, Fixture, methodLogStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.LogStatus(RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var methodLogStatusPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfLogStatus = { RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLogStatus, methodLogStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfLogStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLogStatus.ShouldNotBeNull();
            parametersOfLogStatus.Length.ShouldBe(6);
            methodLogStatusPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var methodLogStatusPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfLogStatus = { RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLogStatus, methodLogStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfLogStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLogStatus.ShouldNotBeNull();
            parametersOfLogStatus.Length.ShouldBe(6);
            methodLogStatusPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var RPTListID = CreateType<Guid>();
            var sListName = CreateType<string>();
            var sShortMsg = CreateType<string>();
            var sLongMsg = CreateType<string>();
            var iLevel = CreateType<int>();
            var iType = CreateType<int>();
            var methodLogStatusPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfLogStatus = { RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

            // Assert
            parametersOfLogStatus.ShouldNotBeNull();
            parametersOfLogStatus.Length.ShouldBe(6);
            methodLogStatusPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogStatusPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodLogStatus, Fixture, methodLogStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLogStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogStatus, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_LogStatus_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodLogStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodLogStatus, Fixture, methodLogStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
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
            executeAction = () => _reportDataInstance.LogStatus(RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType, timerjobguid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_2_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfLogStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

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
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_2_With_Results_Should_Not_Be_Null_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfLogStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

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
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodLogStatus, parametersOfLogStatus, methodLogStatusPrametersTypes);

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
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogStatusPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodLogStatus, Fixture, methodLogStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLogStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogStatus) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_LogStatus_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogStatus, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetStatusLog_Method_Call_Internally(Type[] types)
        {
            var methodGetStatusLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetStatusLog, Fixture, methodGetStatusLogPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetStatusLog_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.GetStatusLog();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetStatusLog_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetStatusLogPrametersTypes = null;
            object[] parametersOfGetStatusLog = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStatusLog, methodGetStatusLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, DataTable>(_reportDataInstanceFixture, out exception1, parametersOfGetStatusLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetStatusLog, parametersOfGetStatusLog, methodGetStatusLogPrametersTypes);

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
        public void AUT_ReportData_GetStatusLog_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetStatusLogPrametersTypes = null;
            object[] parametersOfGetStatusLog = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, DataTable>(_reportDataInstance, MethodGetStatusLog, parametersOfGetStatusLog, methodGetStatusLogPrametersTypes);

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
        public void AUT_ReportData_GetStatusLog_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetStatusLogPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetStatusLog, Fixture, methodGetStatusLogPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStatusLogPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetStatusLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetStatusLogPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetStatusLog, Fixture, methodGetStatusLogPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStatusLogPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStatusLog) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetStatusLog_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStatusLog, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_ItemHasValue_Method_Call_Internally(Type[] types)
        {
            var methodItemHasValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodItemHasValue, Fixture, methodItemHasValuePrametersTypes);
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ItemHasValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var colName = CreateType<string>();
            var methodItemHasValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfItemHasValue = { item, colName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodItemHasValue, methodItemHasValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfItemHasValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodItemHasValue, parametersOfItemHasValue, methodItemHasValuePrametersTypes);

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
        public void AUT_ReportData_ItemHasValue_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var colName = CreateType<string>();
            var methodItemHasValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfItemHasValue = { item, colName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodItemHasValue, methodItemHasValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, bool>(_reportDataInstanceFixture, out exception1, parametersOfItemHasValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodItemHasValue, parametersOfItemHasValue, methodItemHasValuePrametersTypes);

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
        public void AUT_ReportData_ItemHasValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var colName = CreateType<string>();
            var methodItemHasValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfItemHasValue = { item, colName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, bool>(_reportDataInstance, MethodItemHasValue, parametersOfItemHasValue, methodItemHasValuePrametersTypes);

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
        public void AUT_ReportData_ItemHasValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemHasValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodItemHasValue, Fixture, methodItemHasValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodItemHasValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ItemHasValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemHasValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ItemHasValue) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_ItemHasValue_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetFieldType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_GetFieldType_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetFieldType_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var colInternalName = CreateType<string>();
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfGetFieldType = { item, colInternalName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldType, methodGetFieldTypePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportData, string>(_reportDataInstanceFixture, out exception1, parametersOfGetFieldType);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetFieldType, parametersOfGetFieldType, methodGetFieldTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldType.ShouldNotBeNull();
            parametersOfGetFieldType.Length.ShouldBe(2);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetFieldType_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var colInternalName = CreateType<string>();
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfGetFieldType = { item, colInternalName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportData, string>(_reportDataInstance, MethodGetFieldType, parametersOfGetFieldType, methodGetFieldTypePrametersTypes);

            // Assert
            parametersOfGetFieldType.ShouldNotBeNull();
            parametersOfGetFieldType.Length.ShouldBe(2);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetFieldType_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldTypePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetFieldType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetFieldType_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_GetFieldType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldType, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportData_UpdateItem_Method_Call_Internally(Type[] types)
        {
            var methodUpdateItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateItem, Fixture, methodUpdateItemPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var item = CreateType<SPListItem>();
            var tableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportDataInstance.UpdateItem(listId, item, tableName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateItem_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var item = CreateType<SPListItem>();
            var tableName = CreateType<string>();
            var methodUpdateItemPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };
            object[] parametersOfUpdateItem = { listId, item, tableName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateItem, methodUpdateItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportDataInstanceFixture, parametersOfUpdateItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateItem.ShouldNotBeNull();
            parametersOfUpdateItem.Length.ShouldBe(3);
            methodUpdateItemPrametersTypes.Length.ShouldBe(3);
            methodUpdateItemPrametersTypes.Length.ShouldBe(parametersOfUpdateItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateItem_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var item = CreateType<SPListItem>();
            var tableName = CreateType<string>();
            var methodUpdateItemPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };
            object[] parametersOfUpdateItem = { listId, item, tableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportDataInstance, MethodUpdateItem, parametersOfUpdateItem, methodUpdateItemPrametersTypes);

            // Assert
            parametersOfUpdateItem.ShouldNotBeNull();
            parametersOfUpdateItem.Length.ShouldBe(3);
            methodUpdateItemPrametersTypes.Length.ShouldBe(3);
            methodUpdateItemPrametersTypes.Length.ShouldBe(parametersOfUpdateItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateItem, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateItemPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportDataInstance, MethodUpdateItem, Fixture, methodUpdateItemPrametersTypes);

            // Assert
            methodUpdateItemPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportData_UpdateItem_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.ReportHelper
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportHelper.ReportBiz" />)
    ///     and namespace <see cref="EPMLiveCore.ReportHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ReportBizTest : AbstractBaseSetupTypedTest<ReportBiz>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportBiz) Initializer

        private const string PropertyWebTitle = "WebTitle";
        private const string MethodSiteExists = "SiteExists";
        private const string MethodGetMappedLists = "GetMappedLists";
        private const string MethodGetMappedListsIds = "GetMappedListsIds";
        private const string MethodRemoveDatabaseMapping = "RemoveDatabaseMapping";
        private const string MethodGetListBiz = "GetListBiz";
        private const string MethodCreateListBiz = "CreateListBiz";
        private const string MethodSAccountInfo = "SAccountInfo";
        private const string MethodGetDatabaseMappings = "GetDatabaseMappings";
        private const string MethodGetDistinctDatabaseList = "GetDistinctDatabaseList";
        private const string MethodRefreshTimesheet = "RefreshTimesheet";
        private const string MethodRefreshTimesheetInstant = "RefreshTimesheetInstant";
        private const string MethodGetAllForeignKeys = "GetAllForeignKeys";
        private const string MethodGetSpecificForeignKey = "GetSpecificForeignKey";
        private const string MethodHasForeignKey = "HasForeignKey";
        private const string MethodUpdateForeignKeys = "UpdateForeignKeys";
        private const string MethodAddORRemoveForeignKey = "AddORRemoveForeignKey";
        private const string MethodGetReferencingTables = "GetReferencingTables";
        private const string Field_reportingV2Enabled = "_reportingV2Enabled";
        private const string Field_siteId = "_siteId";
        private const string Field_webAppId = "_webAppId";
        private const string Field_webId = "_webId";
        private const string Field_webTitle = "_webTitle";
        private Type _reportBizInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportBiz _reportBizInstance;
        private ReportBiz _reportBizInstanceFixture;

        #region General Initializer : Class (ReportBiz) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportBiz" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportBizInstanceType = typeof(ReportBiz);
            _reportBizInstanceFixture = Create(true);
            _reportBizInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportBiz)

        #region General Initializer : Class (ReportBiz) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportBiz" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodSiteExists, 0)]
        [TestCase(MethodGetMappedLists, 0)]
        [TestCase(MethodGetMappedListsIds, 0)]
        [TestCase(MethodRemoveDatabaseMapping, 0)]
        [TestCase(MethodGetListBiz, 0)]
        [TestCase(MethodCreateListBiz, 0)]
        [TestCase(MethodCreateListBiz, 1)]
        [TestCase(MethodCreateListBiz, 2)]
        [TestCase(MethodSAccountInfo, 0)]
        [TestCase(MethodGetDatabaseMappings, 0)]
        [TestCase(MethodGetDistinctDatabaseList, 0)]
        [TestCase(MethodRefreshTimesheet, 0)]
        [TestCase(MethodRefreshTimesheetInstant, 0)]
        [TestCase(MethodGetAllForeignKeys, 0)]
        [TestCase(MethodGetSpecificForeignKey, 0)]
        [TestCase(MethodHasForeignKey, 0)]
        [TestCase(MethodUpdateForeignKeys, 0)]
        [TestCase(MethodAddORRemoveForeignKey, 0)]
        [TestCase(MethodGetReferencingTables, 0)]
        public void AUT_ReportBiz_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportBizInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportBiz) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBiz" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyWebTitle)]
        public void AUT_ReportBiz_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportBizInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportBiz) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBiz" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_reportingV2Enabled)]
        [TestCase(Field_siteId)]
        [TestCase(Field_webAppId)]
        [TestCase(Field_webId)]
        [TestCase(Field_webTitle)]
        public void AUT_ReportBiz_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportBizInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ReportBiz" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportBiz_Is_Instance_Present_Test()
        {
            // Assert
            _reportBizInstanceType.ShouldNotBeNull();
            _reportBizInstance.ShouldNotBeNull();
            _reportBizInstanceFixture.ShouldNotBeNull();
            _reportBizInstance.ShouldBeAssignableTo<ReportBiz>();
            _reportBizInstanceFixture.ShouldBeAssignableTo<ReportBiz>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportBiz) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            ReportBiz instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ReportBiz(siteId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _reportBizInstance.ShouldNotBeNull();
            _reportBizInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ReportBiz>();
        }

        #endregion

        #region General Constructor : Class (ReportBiz) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            ReportBiz instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ReportBiz(siteId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _reportBizInstance.ShouldNotBeNull();
            _reportBizInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (ReportBiz) instance created

        /// <summary>
        ///     Class (<see cref="ReportBiz" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_Is_Created_Test()
        {
            // Assert
            _reportBizInstance.ShouldNotBeNull();
            _reportBizInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (ReportBiz) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ReportBiz" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void AUT_ReportBiz_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ReportBiz>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ReportBiz) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ReportBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ReportBiz>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ReportBiz) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            object[] parametersOfReportBiz = { siteId };
            var methodReportBizPrametersTypes = new Type[] { typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_reportBizInstanceType, methodReportBizPrametersTypes, parametersOfReportBiz);
        }

        #endregion

        #region General Constructor : Class (ReportBiz) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodReportBizPrametersTypes = new Type[] { typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_reportBizInstanceType, Fixture, methodReportBizPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ReportBiz) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var reportingV2Enabled = CreateType<bool>();
            object[] parametersOfReportBiz = { siteId, webId, reportingV2Enabled };
            var methodReportBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_reportBizInstanceType, methodReportBizPrametersTypes, parametersOfReportBiz);
        }

        #endregion

        #region General Constructor : Class (ReportBiz) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodReportBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_reportBizInstanceType, Fixture, methodReportBizPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ReportBiz) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            object[] parametersOfReportBiz = { siteId, webAppId };
            var methodReportBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_reportBizInstanceType, methodReportBizPrametersTypes, parametersOfReportBiz);
        }

        #endregion

        #region General Constructor : Class (ReportBiz) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportBiz_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodReportBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_reportBizInstanceType, Fixture, methodReportBizPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportBiz) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyWebTitle)]
        public void AUT_ReportBiz_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportBiz, T>(_reportBizInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBiz) => Property (WebTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportBiz_Public_Class_WebTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebTitle);

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

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportBiz" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSiteExists)]
        [TestCase(MethodGetMappedLists)]
        [TestCase(MethodGetMappedListsIds)]
        [TestCase(MethodRemoveDatabaseMapping)]
        [TestCase(MethodGetListBiz)]
        [TestCase(MethodCreateListBiz)]
        [TestCase(MethodSAccountInfo)]
        [TestCase(MethodGetDatabaseMappings)]
        [TestCase(MethodGetDistinctDatabaseList)]
        [TestCase(MethodRefreshTimesheet)]
        [TestCase(MethodRefreshTimesheetInstant)]
        [TestCase(MethodGetAllForeignKeys)]
        [TestCase(MethodGetSpecificForeignKey)]
        [TestCase(MethodHasForeignKey)]
        [TestCase(MethodUpdateForeignKeys)]
        [TestCase(MethodAddORRemoveForeignKey)]
        [TestCase(MethodGetReferencingTables)]
        public void AUT_ReportBiz_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportBiz>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (SiteExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_SiteExists_Method_Call_Internally(Type[] types)
        {
            var methodSiteExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodSiteExists, Fixture, methodSiteExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (SiteExists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SiteExists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.SiteExists();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SiteExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SiteExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodSiteExistsPrametersTypes = null;
            object[] parametersOfSiteExists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSiteExists, methodSiteExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfSiteExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodSiteExists, parametersOfSiteExists, methodSiteExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSiteExists.ShouldBeNull();
            methodSiteExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SiteExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SiteExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSiteExistsPrametersTypes = null;
            object[] parametersOfSiteExists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSiteExists, methodSiteExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfSiteExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodSiteExists, parametersOfSiteExists, methodSiteExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSiteExists.ShouldBeNull();
            methodSiteExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SiteExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SiteExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSiteExistsPrametersTypes = null;
            object[] parametersOfSiteExists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodSiteExists, parametersOfSiteExists, methodSiteExistsPrametersTypes);

            // Assert
            parametersOfSiteExists.ShouldBeNull();
            methodSiteExistsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SiteExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SiteExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSiteExistsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodSiteExists, Fixture, methodSiteExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSiteExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SiteExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SiteExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSiteExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : Collection<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_GetMappedLists_Method_Call_Internally(Type[] types)
        {
            var methodGetMappedListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetMappedLists, Fixture, methodGetMappedListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : Collection<string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedLists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.GetMappedLists();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : Collection<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedListsPrametersTypes = null;
            object[] parametersOfGetMappedLists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMappedLists, methodGetMappedListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, Collection<string>>(_reportBizInstanceFixture, out exception1, parametersOfGetMappedLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, Collection<string>>(_reportBizInstance, MethodGetMappedLists, parametersOfGetMappedLists, methodGetMappedListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMappedLists.ShouldBeNull();
            methodGetMappedListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : Collection<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMappedListsPrametersTypes = null;
            object[] parametersOfGetMappedLists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, Collection<string>>(_reportBizInstance, MethodGetMappedLists, parametersOfGetMappedLists, methodGetMappedListsPrametersTypes);

            // Assert
            parametersOfGetMappedLists.ShouldBeNull();
            methodGetMappedListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : Collection<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedListsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetMappedLists, Fixture, methodGetMappedListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMappedListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : Collection<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMappedListsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetMappedLists, Fixture, methodGetMappedListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMappedListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : Collection<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMappedLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedListsIds) (Return Type : Collection<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_GetMappedListsIds_Method_Call_Internally(Type[] types)
        {
            var methodGetMappedListsIdsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetMappedListsIds, Fixture, methodGetMappedListsIdsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMappedListsIds) (Return Type : Collection<string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedListsIds_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.GetMappedListsIds();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMappedListsIds) (Return Type : Collection<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedListsIds_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedListsIdsPrametersTypes = null;
            object[] parametersOfGetMappedListsIds = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMappedListsIds, methodGetMappedListsIdsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, Collection<string>>(_reportBizInstanceFixture, out exception1, parametersOfGetMappedListsIds);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, Collection<string>>(_reportBizInstance, MethodGetMappedListsIds, parametersOfGetMappedListsIds, methodGetMappedListsIdsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMappedListsIds.ShouldBeNull();
            methodGetMappedListsIdsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedListsIds) (Return Type : Collection<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedListsIds_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMappedListsIdsPrametersTypes = null;
            object[] parametersOfGetMappedListsIds = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, Collection<string>>(_reportBizInstance, MethodGetMappedListsIds, parametersOfGetMappedListsIds, methodGetMappedListsIdsPrametersTypes);

            // Assert
            parametersOfGetMappedListsIds.ShouldBeNull();
            methodGetMappedListsIdsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedListsIds) (Return Type : Collection<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedListsIds_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedListsIdsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetMappedListsIds, Fixture, methodGetMappedListsIdsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMappedListsIdsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedListsIds) (Return Type : Collection<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedListsIds_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMappedListsIdsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetMappedListsIds, Fixture, methodGetMappedListsIdsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMappedListsIdsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedListsIds) (Return Type : Collection<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetMappedListsIds_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMappedListsIds, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveDatabaseMapping) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_RemoveDatabaseMapping_Method_Call_Internally(Type[] types)
        {
            var methodRemoveDatabaseMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodRemoveDatabaseMapping, Fixture, methodRemoveDatabaseMappingPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveDatabaseMapping) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RemoveDatabaseMapping_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.RemoveDatabaseMapping();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RemoveDatabaseMapping) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RemoveDatabaseMapping_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodRemoveDatabaseMappingPrametersTypes = null;
            object[] parametersOfRemoveDatabaseMapping = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveDatabaseMapping, methodRemoveDatabaseMappingPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfRemoveDatabaseMapping);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodRemoveDatabaseMapping, parametersOfRemoveDatabaseMapping, methodRemoveDatabaseMappingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRemoveDatabaseMapping.ShouldBeNull();
            methodRemoveDatabaseMappingPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveDatabaseMapping) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RemoveDatabaseMapping_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodRemoveDatabaseMappingPrametersTypes = null;
            object[] parametersOfRemoveDatabaseMapping = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveDatabaseMapping, methodRemoveDatabaseMappingPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfRemoveDatabaseMapping);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodRemoveDatabaseMapping, parametersOfRemoveDatabaseMapping, methodRemoveDatabaseMappingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRemoveDatabaseMapping.ShouldBeNull();
            methodRemoveDatabaseMappingPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveDatabaseMapping) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RemoveDatabaseMapping_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRemoveDatabaseMappingPrametersTypes = null;
            object[] parametersOfRemoveDatabaseMapping = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodRemoveDatabaseMapping, parametersOfRemoveDatabaseMapping, methodRemoveDatabaseMappingPrametersTypes);

            // Assert
            parametersOfRemoveDatabaseMapping.ShouldBeNull();
            methodRemoveDatabaseMappingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveDatabaseMapping) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RemoveDatabaseMapping_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRemoveDatabaseMappingPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodRemoveDatabaseMapping, Fixture, methodRemoveDatabaseMappingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveDatabaseMappingPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveDatabaseMapping) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RemoveDatabaseMapping_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveDatabaseMapping, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListBiz) (Return Type : ListBiz) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_GetListBiz_Method_Call_Internally(Type[] types)
        {
            var methodGetListBizPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetListBiz, Fixture, methodGetListBizPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListBiz) (Return Type : ListBiz) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetListBiz_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.GetListBiz(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListBiz) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetListBiz_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetListBizPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListBiz = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListBiz, methodGetListBizPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, ListBiz>(_reportBizInstanceFixture, out exception1, parametersOfGetListBiz);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, ListBiz>(_reportBizInstance, MethodGetListBiz, parametersOfGetListBiz, methodGetListBizPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListBiz.ShouldNotBeNull();
            parametersOfGetListBiz.Length.ShouldBe(1);
            methodGetListBizPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListBiz) (Return Type : ListBiz) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetListBiz_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodGetListBizPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListBiz = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, ListBiz>(_reportBizInstance, MethodGetListBiz, parametersOfGetListBiz, methodGetListBizPrametersTypes);

            // Assert
            parametersOfGetListBiz.ShouldNotBeNull();
            parametersOfGetListBiz.Length.ShouldBe(1);
            methodGetListBizPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListBiz) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetListBiz_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListBizPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetListBiz, Fixture, methodGetListBizPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListBizPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListBiz) (Return Type : ListBiz) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetListBiz_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListBizPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetListBiz, Fixture, methodGetListBizPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListBizPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListBiz) (Return Type : ListBiz) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetListBiz_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListBiz, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListBiz) (Return Type : ListBiz) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetListBiz_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListBiz, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_CreateListBiz_Method_Call_Internally(Type[] types)
        {
            var methodCreateListBizPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodCreateListBiz, Fixture, methodCreateListBizPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.CreateListBiz(listId, fields);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid), typeof(ListItemCollection) };
            object[] parametersOfCreateListBiz = { listId, fields };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateListBiz, methodCreateListBizPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, ListBiz>(_reportBizInstanceFixture, out exception1, parametersOfCreateListBiz);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, ListBiz>(_reportBizInstance, MethodCreateListBiz, parametersOfCreateListBiz, methodCreateListBizPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateListBiz.ShouldNotBeNull();
            parametersOfCreateListBiz.Length.ShouldBe(2);
            methodCreateListBizPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid), typeof(ListItemCollection) };
            object[] parametersOfCreateListBiz = { listId, fields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, ListBiz>(_reportBizInstance, MethodCreateListBiz, parametersOfCreateListBiz, methodCreateListBizPrametersTypes);

            // Assert
            parametersOfCreateListBiz.ShouldNotBeNull();
            parametersOfCreateListBiz.Length.ShouldBe(2);
            methodCreateListBizPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid), typeof(ListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodCreateListBiz, Fixture, methodCreateListBizPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateListBizPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid), typeof(ListItemCollection) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodCreateListBiz, Fixture, methodCreateListBizPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateListBizPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateListBiz, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateListBiz, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_CreateListBiz_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodCreateListBizPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodCreateListBiz, Fixture, methodCreateListBizPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.CreateListBiz(listId, webId, fields);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(ListItemCollection) };
            object[] parametersOfCreateListBiz = { listId, webId, fields };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateListBiz, methodCreateListBizPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, ListBiz>(_reportBizInstanceFixture, out exception1, parametersOfCreateListBiz);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, ListBiz>(_reportBizInstance, MethodCreateListBiz, parametersOfCreateListBiz, methodCreateListBizPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateListBiz.ShouldNotBeNull();
            parametersOfCreateListBiz.Length.ShouldBe(3);
            methodCreateListBizPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(ListItemCollection) };
            object[] parametersOfCreateListBiz = { listId, webId, fields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, ListBiz>(_reportBizInstance, MethodCreateListBiz, parametersOfCreateListBiz, methodCreateListBizPrametersTypes);

            // Assert
            parametersOfCreateListBiz.ShouldNotBeNull();
            parametersOfCreateListBiz.Length.ShouldBe(3);
            methodCreateListBizPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(ListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodCreateListBiz, Fixture, methodCreateListBizPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateListBizPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(ListItemCollection) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodCreateListBiz, Fixture, methodCreateListBizPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateListBizPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateListBiz, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateListBiz, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_CreateListBiz_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodCreateListBizPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodCreateListBiz, Fixture, methodCreateListBizPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.CreateListBiz(listId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_2_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfCreateListBiz = { listId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateListBiz, methodCreateListBizPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, ListBiz>(_reportBizInstanceFixture, out exception1, parametersOfCreateListBiz);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, ListBiz>(_reportBizInstance, MethodCreateListBiz, parametersOfCreateListBiz, methodCreateListBizPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateListBiz.ShouldNotBeNull();
            parametersOfCreateListBiz.Length.ShouldBe(1);
            methodCreateListBizPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfCreateListBiz = { listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, ListBiz>(_reportBizInstance, MethodCreateListBiz, parametersOfCreateListBiz, methodCreateListBizPrametersTypes);

            // Assert
            parametersOfCreateListBiz.ShouldNotBeNull();
            parametersOfCreateListBiz.Length.ShouldBe(1);
            methodCreateListBizPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodCreateListBiz, Fixture, methodCreateListBizPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateListBizPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateListBizPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodCreateListBiz, Fixture, methodCreateListBizPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateListBizPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateListBiz, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateListBiz) (Return Type : ListBiz) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_CreateListBiz_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateListBiz, 2);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_SAccountInfo_Method_Call_Internally(Type[] types)
        {
            var methodSAccountInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodSAccountInfo, Fixture, methodSAccountInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SAccountInfo_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webAppId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.SAccountInfo(webAppId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SAccountInfo_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webAppId = CreateType<Guid>();
            var methodSAccountInfoPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfSAccountInfo = { webAppId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSAccountInfo, methodSAccountInfoPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, DataRow>(_reportBizInstanceFixture, out exception1, parametersOfSAccountInfo);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, DataRow>(_reportBizInstance, MethodSAccountInfo, parametersOfSAccountInfo, methodSAccountInfoPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSAccountInfo.ShouldNotBeNull();
            parametersOfSAccountInfo.Length.ShouldBe(1);
            methodSAccountInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SAccountInfo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webAppId = CreateType<Guid>();
            var methodSAccountInfoPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfSAccountInfo = { webAppId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, DataRow>(_reportBizInstance, MethodSAccountInfo, parametersOfSAccountInfo, methodSAccountInfoPrametersTypes);

            // Assert
            parametersOfSAccountInfo.ShouldNotBeNull();
            parametersOfSAccountInfo.Length.ShouldBe(1);
            methodSAccountInfoPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SAccountInfo_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSAccountInfoPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodSAccountInfo, Fixture, methodSAccountInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSAccountInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SAccountInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSAccountInfoPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodSAccountInfo, Fixture, methodSAccountInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSAccountInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SAccountInfo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSAccountInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SAccountInfo) (Return Type : DataRow) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_SAccountInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSAccountInfo, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDatabaseMappings) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_GetDatabaseMappings_Method_Call_Internally(Type[] types)
        {
            var methodGetDatabaseMappingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetDatabaseMappings, Fixture, methodGetDatabaseMappingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDatabaseMappings) (Return Type : Dictionary<string, string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDatabaseMappings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.GetDatabaseMappings();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDatabaseMappings) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDatabaseMappings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDatabaseMappingsPrametersTypes = null;
            object[] parametersOfGetDatabaseMappings = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDatabaseMappings, methodGetDatabaseMappingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, Dictionary<string, string>>(_reportBizInstanceFixture, out exception1, parametersOfGetDatabaseMappings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, Dictionary<string, string>>(_reportBizInstance, MethodGetDatabaseMappings, parametersOfGetDatabaseMappings, methodGetDatabaseMappingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDatabaseMappings.ShouldBeNull();
            methodGetDatabaseMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDatabaseMappings) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDatabaseMappings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDatabaseMappingsPrametersTypes = null;
            object[] parametersOfGetDatabaseMappings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, Dictionary<string, string>>(_reportBizInstance, MethodGetDatabaseMappings, parametersOfGetDatabaseMappings, methodGetDatabaseMappingsPrametersTypes);

            // Assert
            parametersOfGetDatabaseMappings.ShouldBeNull();
            methodGetDatabaseMappingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDatabaseMappings) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDatabaseMappings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDatabaseMappingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetDatabaseMappings, Fixture, methodGetDatabaseMappingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDatabaseMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDatabaseMappings) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDatabaseMappings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDatabaseMappingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetDatabaseMappings, Fixture, methodGetDatabaseMappingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDatabaseMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDatabaseMappings) (Return Type : Dictionary<string, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDatabaseMappings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDatabaseMappings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDistinctDatabaseList) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_GetDistinctDatabaseList_Method_Call_Internally(Type[] types)
        {
            var methodGetDistinctDatabaseListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetDistinctDatabaseList, Fixture, methodGetDistinctDatabaseListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDistinctDatabaseList) (Return Type : Dictionary<string, string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDistinctDatabaseList_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.GetDistinctDatabaseList();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDistinctDatabaseList) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDistinctDatabaseList_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDistinctDatabaseListPrametersTypes = null;
            object[] parametersOfGetDistinctDatabaseList = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDistinctDatabaseList, methodGetDistinctDatabaseListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, Dictionary<string, string>>(_reportBizInstanceFixture, out exception1, parametersOfGetDistinctDatabaseList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, Dictionary<string, string>>(_reportBizInstance, MethodGetDistinctDatabaseList, parametersOfGetDistinctDatabaseList, methodGetDistinctDatabaseListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDistinctDatabaseList.ShouldBeNull();
            methodGetDistinctDatabaseListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDistinctDatabaseList) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDistinctDatabaseList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDistinctDatabaseListPrametersTypes = null;
            object[] parametersOfGetDistinctDatabaseList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, Dictionary<string, string>>(_reportBizInstance, MethodGetDistinctDatabaseList, parametersOfGetDistinctDatabaseList, methodGetDistinctDatabaseListPrametersTypes);

            // Assert
            parametersOfGetDistinctDatabaseList.ShouldBeNull();
            methodGetDistinctDatabaseListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDistinctDatabaseList) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDistinctDatabaseList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDistinctDatabaseListPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetDistinctDatabaseList, Fixture, methodGetDistinctDatabaseListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDistinctDatabaseListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDistinctDatabaseList) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDistinctDatabaseList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDistinctDatabaseListPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetDistinctDatabaseList, Fixture, methodGetDistinctDatabaseListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDistinctDatabaseListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDistinctDatabaseList) (Return Type : Dictionary<string, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetDistinctDatabaseList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDistinctDatabaseList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RefreshTimesheet) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_RefreshTimesheet_Method_Call_Internally(Type[] types)
        {
            var methodRefreshTimesheetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodRefreshTimesheet, Fixture, methodRefreshTimesheetPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshTimesheet) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheet_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var jobUid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.RefreshTimesheet(out message, jobUid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RefreshTimesheet) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheet_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var methodRefreshTimesheetPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfRefreshTimesheet = { message, jobUid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRefreshTimesheet, methodRefreshTimesheetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfRefreshTimesheet);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodRefreshTimesheet, parametersOfRefreshTimesheet, methodRefreshTimesheetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRefreshTimesheet.ShouldNotBeNull();
            parametersOfRefreshTimesheet.Length.ShouldBe(2);
            methodRefreshTimesheetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RefreshTimesheet) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheet_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var methodRefreshTimesheetPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfRefreshTimesheet = { message, jobUid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRefreshTimesheet, methodRefreshTimesheetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfRefreshTimesheet);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodRefreshTimesheet, parametersOfRefreshTimesheet, methodRefreshTimesheetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRefreshTimesheet.ShouldNotBeNull();
            parametersOfRefreshTimesheet.Length.ShouldBe(2);
            methodRefreshTimesheetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RefreshTimesheet) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheet_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var methodRefreshTimesheetPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfRefreshTimesheet = { message, jobUid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodRefreshTimesheet, parametersOfRefreshTimesheet, methodRefreshTimesheetPrametersTypes);

            // Assert
            parametersOfRefreshTimesheet.ShouldNotBeNull();
            parametersOfRefreshTimesheet.Length.ShouldBe(2);
            methodRefreshTimesheetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshTimesheet) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheet_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRefreshTimesheetPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodRefreshTimesheet, Fixture, methodRefreshTimesheetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRefreshTimesheetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshTimesheet) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheet_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshTimesheet, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RefreshTimesheet) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheet_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRefreshTimesheet, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshTimesheetInstant) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_RefreshTimesheetInstant_Method_Call_Internally(Type[] types)
        {
            var methodRefreshTimesheetInstantPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodRefreshTimesheetInstant, Fixture, methodRefreshTimesheetInstantPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshTimesheetInstant) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheetInstant_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var jobUid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.RefreshTimesheetInstant(out message, jobUid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RefreshTimesheetInstant) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheetInstant_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var methodRefreshTimesheetInstantPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfRefreshTimesheetInstant = { message, jobUid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRefreshTimesheetInstant, methodRefreshTimesheetInstantPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfRefreshTimesheetInstant);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodRefreshTimesheetInstant, parametersOfRefreshTimesheetInstant, methodRefreshTimesheetInstantPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRefreshTimesheetInstant.ShouldNotBeNull();
            parametersOfRefreshTimesheetInstant.Length.ShouldBe(2);
            methodRefreshTimesheetInstantPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RefreshTimesheetInstant) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheetInstant_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var methodRefreshTimesheetInstantPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfRefreshTimesheetInstant = { message, jobUid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRefreshTimesheetInstant, methodRefreshTimesheetInstantPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfRefreshTimesheetInstant);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodRefreshTimesheetInstant, parametersOfRefreshTimesheetInstant, methodRefreshTimesheetInstantPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRefreshTimesheetInstant.ShouldNotBeNull();
            parametersOfRefreshTimesheetInstant.Length.ShouldBe(2);
            methodRefreshTimesheetInstantPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RefreshTimesheetInstant) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheetInstant_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var jobUid = CreateType<Guid>();
            var methodRefreshTimesheetInstantPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfRefreshTimesheetInstant = { message, jobUid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodRefreshTimesheetInstant, parametersOfRefreshTimesheetInstant, methodRefreshTimesheetInstantPrametersTypes);

            // Assert
            parametersOfRefreshTimesheetInstant.ShouldNotBeNull();
            parametersOfRefreshTimesheetInstant.Length.ShouldBe(2);
            methodRefreshTimesheetInstantPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshTimesheetInstant) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheetInstant_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRefreshTimesheetInstantPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodRefreshTimesheetInstant, Fixture, methodRefreshTimesheetInstantPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRefreshTimesheetInstantPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshTimesheetInstant) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheetInstant_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshTimesheetInstant, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RefreshTimesheetInstant) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_RefreshTimesheetInstant_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRefreshTimesheetInstant, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllForeignKeys) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_GetAllForeignKeys_Method_Call_Internally(Type[] types)
        {
            var methodGetAllForeignKeysPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetAllForeignKeys, Fixture, methodGetAllForeignKeysPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllForeignKeys) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetAllForeignKeys_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.GetAllForeignKeys(DAO);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAllForeignKeys) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetAllForeignKeys_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var methodGetAllForeignKeysPrametersTypes = new Type[] { typeof(EPMData) };
            object[] parametersOfGetAllForeignKeys = { DAO };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAllForeignKeys, methodGetAllForeignKeysPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, DataTable>(_reportBizInstanceFixture, out exception1, parametersOfGetAllForeignKeys);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, DataTable>(_reportBizInstance, MethodGetAllForeignKeys, parametersOfGetAllForeignKeys, methodGetAllForeignKeysPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAllForeignKeys.ShouldNotBeNull();
            parametersOfGetAllForeignKeys.Length.ShouldBe(1);
            methodGetAllForeignKeysPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAllForeignKeys) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetAllForeignKeys_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var methodGetAllForeignKeysPrametersTypes = new Type[] { typeof(EPMData) };
            object[] parametersOfGetAllForeignKeys = { DAO };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, DataTable>(_reportBizInstance, MethodGetAllForeignKeys, parametersOfGetAllForeignKeys, methodGetAllForeignKeysPrametersTypes);

            // Assert
            parametersOfGetAllForeignKeys.ShouldNotBeNull();
            parametersOfGetAllForeignKeys.Length.ShouldBe(1);
            methodGetAllForeignKeysPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllForeignKeys) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetAllForeignKeys_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAllForeignKeysPrametersTypes = new Type[] { typeof(EPMData) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetAllForeignKeys, Fixture, methodGetAllForeignKeysPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllForeignKeysPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAllForeignKeys) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetAllForeignKeys_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAllForeignKeysPrametersTypes = new Type[] { typeof(EPMData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetAllForeignKeys, Fixture, methodGetAllForeignKeysPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllForeignKeysPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllForeignKeys) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetAllForeignKeys_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAllForeignKeys, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllForeignKeys) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetAllForeignKeys_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAllForeignKeys, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpecificForeignKey) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_GetSpecificForeignKey_Method_Call_Internally(Type[] types)
        {
            var methodGetSpecificForeignKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetSpecificForeignKey, Fixture, methodGetSpecificForeignKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSpecificForeignKey) (Return Type : DataTable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetSpecificForeignKey_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var listId = CreateType<string>();
            var tableName = CreateType<string>();
            var columnName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.GetSpecificForeignKey(DAO, listId, tableName, columnName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSpecificForeignKey) (Return Type : DataTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetSpecificForeignKey_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var listId = CreateType<string>();
            var tableName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodGetSpecificForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetSpecificForeignKey = { DAO, listId, tableName, columnName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSpecificForeignKey, methodGetSpecificForeignKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportBizInstanceFixture, parametersOfGetSpecificForeignKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSpecificForeignKey.ShouldNotBeNull();
            parametersOfGetSpecificForeignKey.Length.ShouldBe(4);
            methodGetSpecificForeignKeyPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSpecificForeignKey) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetSpecificForeignKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var listId = CreateType<string>();
            var tableName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodGetSpecificForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetSpecificForeignKey = { DAO, listId, tableName, columnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, DataTable>(_reportBizInstance, MethodGetSpecificForeignKey, parametersOfGetSpecificForeignKey, methodGetSpecificForeignKeyPrametersTypes);

            // Assert
            parametersOfGetSpecificForeignKey.ShouldNotBeNull();
            parametersOfGetSpecificForeignKey.Length.ShouldBe(4);
            methodGetSpecificForeignKeyPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSpecificForeignKey) (Return Type : DataTable) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetSpecificForeignKey_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetSpecificForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetSpecificForeignKey, Fixture, methodGetSpecificForeignKeyPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSpecificForeignKeyPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetSpecificForeignKey) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetSpecificForeignKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSpecificForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetSpecificForeignKey, Fixture, methodGetSpecificForeignKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSpecificForeignKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpecificForeignKey) (Return Type : DataTable) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetSpecificForeignKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSpecificForeignKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSpecificForeignKey) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetSpecificForeignKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSpecificForeignKey, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HasForeignKey) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_HasForeignKey_Method_Call_Internally(Type[] types)
        {
            var methodHasForeignKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodHasForeignKey, Fixture, methodHasForeignKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (HasForeignKey) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_HasForeignKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var tableName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodHasForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(string), typeof(string) };
            object[] parametersOfHasForeignKey = { DAO, tableName, columnName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHasForeignKey, methodHasForeignKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfHasForeignKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodHasForeignKey, parametersOfHasForeignKey, methodHasForeignKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHasForeignKey.ShouldNotBeNull();
            parametersOfHasForeignKey.Length.ShouldBe(3);
            methodHasForeignKeyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HasForeignKey) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_HasForeignKey_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var tableName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodHasForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(string), typeof(string) };
            object[] parametersOfHasForeignKey = { DAO, tableName, columnName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHasForeignKey, methodHasForeignKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfHasForeignKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodHasForeignKey, parametersOfHasForeignKey, methodHasForeignKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHasForeignKey.ShouldNotBeNull();
            parametersOfHasForeignKey.Length.ShouldBe(3);
            methodHasForeignKeyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HasForeignKey) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_HasForeignKey_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var tableName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodHasForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(string), typeof(string) };
            object[] parametersOfHasForeignKey = { DAO, tableName, columnName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHasForeignKey, methodHasForeignKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportBizInstanceFixture, parametersOfHasForeignKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHasForeignKey.ShouldNotBeNull();
            parametersOfHasForeignKey.Length.ShouldBe(3);
            methodHasForeignKeyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasForeignKey) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_HasForeignKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var tableName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodHasForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(string), typeof(string) };
            object[] parametersOfHasForeignKey = { DAO, tableName, columnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodHasForeignKey, parametersOfHasForeignKey, methodHasForeignKeyPrametersTypes);

            // Assert
            parametersOfHasForeignKey.ShouldNotBeNull();
            parametersOfHasForeignKey.Length.ShouldBe(3);
            methodHasForeignKeyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasForeignKey) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_HasForeignKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHasForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodHasForeignKey, Fixture, methodHasForeignKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHasForeignKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HasForeignKey) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_HasForeignKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHasForeignKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HasForeignKey) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_HasForeignKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHasForeignKey, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateForeignKeys) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_UpdateForeignKeys_Method_Call_Internally(Type[] types)
        {
            var methodUpdateForeignKeysPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodUpdateForeignKeys, Fixture, methodUpdateForeignKeysPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateForeignKeys) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_UpdateForeignKeys_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.UpdateForeignKeys(DAO);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateForeignKeys) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_UpdateForeignKeys_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var methodUpdateForeignKeysPrametersTypes = new Type[] { typeof(EPMData) };
            object[] parametersOfUpdateForeignKeys = { DAO };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateForeignKeys, methodUpdateForeignKeysPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfUpdateForeignKeys);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodUpdateForeignKeys, parametersOfUpdateForeignKeys, methodUpdateForeignKeysPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateForeignKeys.ShouldNotBeNull();
            parametersOfUpdateForeignKeys.Length.ShouldBe(1);
            methodUpdateForeignKeysPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateForeignKeys) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_UpdateForeignKeys_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var methodUpdateForeignKeysPrametersTypes = new Type[] { typeof(EPMData) };
            object[] parametersOfUpdateForeignKeys = { DAO };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateForeignKeys, methodUpdateForeignKeysPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfUpdateForeignKeys);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodUpdateForeignKeys, parametersOfUpdateForeignKeys, methodUpdateForeignKeysPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateForeignKeys.ShouldNotBeNull();
            parametersOfUpdateForeignKeys.Length.ShouldBe(1);
            methodUpdateForeignKeysPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateForeignKeys) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_UpdateForeignKeys_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var methodUpdateForeignKeysPrametersTypes = new Type[] { typeof(EPMData) };
            object[] parametersOfUpdateForeignKeys = { DAO };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodUpdateForeignKeys, parametersOfUpdateForeignKeys, methodUpdateForeignKeysPrametersTypes);

            // Assert
            parametersOfUpdateForeignKeys.ShouldNotBeNull();
            parametersOfUpdateForeignKeys.Length.ShouldBe(1);
            methodUpdateForeignKeysPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateForeignKeys) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_UpdateForeignKeys_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateForeignKeysPrametersTypes = new Type[] { typeof(EPMData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodUpdateForeignKeys, Fixture, methodUpdateForeignKeysPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateForeignKeysPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateForeignKeys) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_UpdateForeignKeys_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateForeignKeys, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateForeignKeys) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_UpdateForeignKeys_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateForeignKeys, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddORRemoveForeignKey) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_AddORRemoveForeignKey_Method_Call_Internally(Type[] types)
        {
            var methodAddORRemoveForeignKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodAddORRemoveForeignKey, Fixture, methodAddORRemoveForeignKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (AddORRemoveForeignKey) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_AddORRemoveForeignKey_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var foreignKey = CreateType<DataRow>();
            var addOperation = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.AddORRemoveForeignKey(DAO, foreignKey, addOperation);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddORRemoveForeignKey) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_AddORRemoveForeignKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var foreignKey = CreateType<DataRow>();
            var addOperation = CreateType<bool>();
            var methodAddORRemoveForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(DataRow), typeof(bool) };
            object[] parametersOfAddORRemoveForeignKey = { DAO, foreignKey, addOperation };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddORRemoveForeignKey, methodAddORRemoveForeignKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfAddORRemoveForeignKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodAddORRemoveForeignKey, parametersOfAddORRemoveForeignKey, methodAddORRemoveForeignKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddORRemoveForeignKey.ShouldNotBeNull();
            parametersOfAddORRemoveForeignKey.Length.ShouldBe(3);
            methodAddORRemoveForeignKeyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (AddORRemoveForeignKey) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_AddORRemoveForeignKey_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var foreignKey = CreateType<DataRow>();
            var addOperation = CreateType<bool>();
            var methodAddORRemoveForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(DataRow), typeof(bool) };
            object[] parametersOfAddORRemoveForeignKey = { DAO, foreignKey, addOperation };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddORRemoveForeignKey, methodAddORRemoveForeignKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, bool>(_reportBizInstanceFixture, out exception1, parametersOfAddORRemoveForeignKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodAddORRemoveForeignKey, parametersOfAddORRemoveForeignKey, methodAddORRemoveForeignKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddORRemoveForeignKey.ShouldNotBeNull();
            parametersOfAddORRemoveForeignKey.Length.ShouldBe(3);
            methodAddORRemoveForeignKeyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (AddORRemoveForeignKey) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_AddORRemoveForeignKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var foreignKey = CreateType<DataRow>();
            var addOperation = CreateType<bool>();
            var methodAddORRemoveForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(DataRow), typeof(bool) };
            object[] parametersOfAddORRemoveForeignKey = { DAO, foreignKey, addOperation };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, bool>(_reportBizInstance, MethodAddORRemoveForeignKey, parametersOfAddORRemoveForeignKey, methodAddORRemoveForeignKeyPrametersTypes);

            // Assert
            parametersOfAddORRemoveForeignKey.ShouldNotBeNull();
            parametersOfAddORRemoveForeignKey.Length.ShouldBe(3);
            methodAddORRemoveForeignKeyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddORRemoveForeignKey) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_AddORRemoveForeignKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddORRemoveForeignKeyPrametersTypes = new Type[] { typeof(EPMData), typeof(DataRow), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodAddORRemoveForeignKey, Fixture, methodAddORRemoveForeignKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddORRemoveForeignKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddORRemoveForeignKey) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_AddORRemoveForeignKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddORRemoveForeignKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddORRemoveForeignKey) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_AddORRemoveForeignKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddORRemoveForeignKey, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReferencingTables) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportBiz_GetReferencingTables_Method_Call_Internally(Type[] types)
        {
            var methodGetReferencingTablesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetReferencingTables, Fixture, methodGetReferencingTablesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReferencingTables) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetReferencingTables_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var sTableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportBizInstance.GetReferencingTables(DAO, sTableName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetReferencingTables) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetReferencingTables_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var sTableName = CreateType<string>();
            var methodGetReferencingTablesPrametersTypes = new Type[] { typeof(EPMData), typeof(string) };
            object[] parametersOfGetReferencingTables = { DAO, sTableName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetReferencingTables, methodGetReferencingTablesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportBiz, DataTable>(_reportBizInstanceFixture, out exception1, parametersOfGetReferencingTables);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportBiz, DataTable>(_reportBizInstance, MethodGetReferencingTables, parametersOfGetReferencingTables, methodGetReferencingTablesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReferencingTables.ShouldNotBeNull();
            parametersOfGetReferencingTables.Length.ShouldBe(2);
            methodGetReferencingTablesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetReferencingTables) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetReferencingTables_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var DAO = CreateType<EPMData>();
            var sTableName = CreateType<string>();
            var methodGetReferencingTablesPrametersTypes = new Type[] { typeof(EPMData), typeof(string) };
            object[] parametersOfGetReferencingTables = { DAO, sTableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportBiz, DataTable>(_reportBizInstance, MethodGetReferencingTables, parametersOfGetReferencingTables, methodGetReferencingTablesPrametersTypes);

            // Assert
            parametersOfGetReferencingTables.ShouldNotBeNull();
            parametersOfGetReferencingTables.Length.ShouldBe(2);
            methodGetReferencingTablesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReferencingTables) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetReferencingTables_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReferencingTablesPrametersTypes = new Type[] { typeof(EPMData), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetReferencingTables, Fixture, methodGetReferencingTablesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReferencingTablesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetReferencingTables) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetReferencingTables_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReferencingTablesPrametersTypes = new Type[] { typeof(EPMData), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportBizInstance, MethodGetReferencingTables, Fixture, methodGetReferencingTablesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReferencingTablesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReferencingTables) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetReferencingTables_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReferencingTables, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReferencingTables) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportBiz_GetReferencingTables_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReferencingTables, 0);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.NavigationService" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class NavigationServiceTest : AbstractBaseSetupTypedTest<NavigationService>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NavigationService) Initializer

        private const string MethodGetContextualMenuItems = "GetContextualMenuItems";
        private const string MethodGetLinks = "GetLinks";
        private const string MethodGetMenuItems = "GetMenuItems";
        private const string MethodRemoveNavigationLink = "RemoveNavigationLink";
        private const string MethodReorderLinks = "ReorderLinks";
        private const string MethodAT = "AT";
        private const string MethodCalculateLinkId = "CalculateLinkId";
        private const string MethodGetContextualMenuItems_ParseRequest = "GetContextualMenuItems_ParseRequest";
        private const string MethodGetLinkId = "GetLinkId";
        private const string MethodGetNavigationLinks = "GetNavigationLinks";
        private const string MethodLIP = "LIP";
        private const string MethodLoadProvider = "LoadProvider";
        private const string MethodLP = "LP";
        private const string MethodLPPFEPermissionCheck = "LPPFEPermissionCheck";
        private const string MethodGetPFEActions = "GetPFEActions";
        private const string MethodGetSocialActions = "GetSocialActions";
        private const string MethodGetWorkspaceActions = "GetWorkspaceActions";
        private const string MethodGetGeneralActions = "GetGeneralActions";
        private const string MethodGetPlannerActions = "GetPlannerActions";
        private const string FieldLocker1 = "Locker1";
        private const string FieldLocker2 = "Locker2";
        private const string Field_linkProviders = "_linkProviders";
        private const string Field_navLinkProperties = "_navLinkProperties";
        private const string Field_spWeb = "_spWeb";
        private Type _navigationServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NavigationService _navigationServiceInstance;
        private NavigationService _navigationServiceInstanceFixture;

        #region General Initializer : Class (NavigationService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NavigationService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _navigationServiceInstanceType = typeof(NavigationService);
            _navigationServiceInstanceFixture = Create(true);
            _navigationServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (NavigationService)

        #region General Initializer : Class (NavigationService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="NavigationService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetContextualMenuItems, 0)]
        [TestCase(MethodGetLinks, 0)]
        [TestCase(MethodGetMenuItems, 0)]
        [TestCase(MethodRemoveNavigationLink, 0)]
        [TestCase(MethodReorderLinks, 0)]
        [TestCase(MethodAT, 0)]
        [TestCase(MethodGetContextualMenuItems_ParseRequest, 0)]
        [TestCase(MethodGetNavigationLinks, 0)]
        [TestCase(MethodLIP, 0)]
        [TestCase(MethodLP, 0)]
        [TestCase(MethodLPPFEPermissionCheck, 0)]
        [TestCase(MethodGetGeneralActions, 0)]
        public void AUT_NavigationService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_navigationServiceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (NavigationService) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="NavigationService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldLocker1)]
        [TestCase(FieldLocker2)]
        public void AUT_NavigationService_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_navigationServiceInstanceFixture, 
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
        ///     Class (<see cref="NavigationService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_NavigationService_Is_Instance_Present_Test()
        {
            // Assert
            _navigationServiceInstanceType.ShouldNotBeNull();
            _navigationServiceInstance.ShouldNotBeNull();
            _navigationServiceInstanceFixture.ShouldNotBeNull();
            _navigationServiceInstance.ShouldBeAssignableTo<NavigationService>();
            _navigationServiceInstanceFixture.ShouldBeAssignableTo<NavigationService>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NavigationService) instance created

        /// <summary>
        ///     Class (<see cref="NavigationService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NavigationService_Is_Created_Test()
        {
            // Assert
            _navigationServiceInstance.ShouldNotBeNull();
            _navigationServiceInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (NavigationService) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="NavigationService" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void AUT_NavigationService_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<NavigationService>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (NavigationService) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="NavigationService" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NavigationService_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<NavigationService>(Fixture);
        }

        #endregion

        #region General Constructor : Class (NavigationService) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NavigationService" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NavigationService_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var providers = CreateType<IEnumerable<string>>();
            var spWeb = CreateType<SPWeb>();
            object[] parametersOfNavigationService = { providers, spWeb };
            var methodNavigationServicePrametersTypes = new Type[] { typeof(IEnumerable<string>), typeof(SPWeb) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_navigationServiceInstanceType, methodNavigationServicePrametersTypes, parametersOfNavigationService);
        }

        #endregion

        #region General Constructor : Class (NavigationService) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NavigationService" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NavigationService_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodNavigationServicePrametersTypes = new Type[] { typeof(IEnumerable<string>), typeof(SPWeb) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_navigationServiceInstanceType, Fixture, methodNavigationServicePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (NavigationService) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NavigationService" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NavigationService_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var provider = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            object[] parametersOfNavigationService = { provider, spWeb };
            var methodNavigationServicePrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_navigationServiceInstanceType, methodNavigationServicePrametersTypes, parametersOfNavigationService);
        }

        #endregion

        #region General Constructor : Class (NavigationService) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NavigationService" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NavigationService_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodNavigationServicePrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_navigationServiceInstanceType, Fixture, methodNavigationServicePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (NavigationService) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NavigationService" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NavigationService_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            object[] parametersOfNavigationService = { spWeb };
            var methodNavigationServicePrametersTypes = new Type[] { typeof(SPWeb) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_navigationServiceInstanceType, methodNavigationServicePrametersTypes, parametersOfNavigationService);
        }

        #endregion

        #region General Constructor : Class (NavigationService) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NavigationService" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NavigationService_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodNavigationServicePrametersTypes = new Type[] { typeof(SPWeb) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_navigationServiceInstanceType, Fixture, methodNavigationServicePrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="NavigationService" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAT)]
        [TestCase(MethodGetContextualMenuItems_ParseRequest)]
        [TestCase(MethodGetNavigationLinks)]
        [TestCase(MethodLIP)]
        [TestCase(MethodLP)]
        [TestCase(MethodLPPFEPermissionCheck)]
        [TestCase(MethodGetGeneralActions)]
        public void AUT_NavigationService_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_navigationServiceInstanceFixture,
                                                                              _navigationServiceInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="NavigationService" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetContextualMenuItems)]
        [TestCase(MethodGetLinks)]
        [TestCase(MethodGetMenuItems)]
        [TestCase(MethodRemoveNavigationLink)]
        [TestCase(MethodReorderLinks)]
        [TestCase(MethodCalculateLinkId)]
        [TestCase(MethodGetLinkId)]
        [TestCase(MethodLoadProvider)]
        [TestCase(MethodGetPFEActions)]
        [TestCase(MethodGetSocialActions)]
        [TestCase(MethodGetWorkspaceActions)]
        [TestCase(MethodGetPlannerActions)]
        public void AUT_NavigationService_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<NavigationService>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetContextualMenuItems_Method_Call_Internally(Type[] types)
        {
            var methodGetContextualMenuItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetContextualMenuItems, Fixture, methodGetContextualMenuItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems) (Return Type : object) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _navigationServiceInstance.GetContextualMenuItems(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetContextualMenuItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetContextualMenuItems = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetContextualMenuItems, methodGetContextualMenuItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<NavigationService, object>(_navigationServiceInstanceFixture, out exception1, parametersOfGetContextualMenuItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<NavigationService, object>(_navigationServiceInstance, MethodGetContextualMenuItems, parametersOfGetContextualMenuItems, methodGetContextualMenuItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetContextualMenuItems.ShouldNotBeNull();
            parametersOfGetContextualMenuItems.Length.ShouldBe(1);
            methodGetContextualMenuItemsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfGetContextualMenuItems));
        }

        #endregion

        #region Method Call : (GetContextualMenuItems) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetContextualMenuItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetContextualMenuItems = { data };

            // Assert
            parametersOfGetContextualMenuItems.ShouldNotBeNull();
            parametersOfGetContextualMenuItems.Length.ShouldBe(1);
            methodGetContextualMenuItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<NavigationService, object>(_navigationServiceInstance, MethodGetContextualMenuItems, parametersOfGetContextualMenuItems, methodGetContextualMenuItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetContextualMenuItems) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetContextualMenuItemsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetContextualMenuItems, Fixture, methodGetContextualMenuItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetContextualMenuItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetContextualMenuItemsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetContextualMenuItems, Fixture, methodGetContextualMenuItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetContextualMenuItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetContextualMenuItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetContextualMenuItems) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetContextualMenuItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinks_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _navigationServiceInstance.GetLinks();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinks_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinks, methodGetLinksPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<NavigationService, string>(_navigationServiceInstanceFixture, out exception1, parametersOfGetLinks);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<NavigationService, string>(_navigationServiceInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfGetLinks));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present

            // Assert
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<NavigationService, string>(_navigationServiceInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMenuItems) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetMenuItems_Method_Call_Internally(Type[] types)
        {
            var methodGetMenuItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetMenuItems, Fixture, methodGetMenuItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMenuItems) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetMenuItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            Action executeAction = null;

            // Act
            executeAction = () => _navigationServiceInstance.GetMenuItems(siteId, webId, listId, itemId, userId, out diagnosticInfo);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMenuItems) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetMenuItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            var methodGetMenuItemsPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(int), typeof(Dictionary<string, string>) };
            object[] parametersOfGetMenuItems = { siteId, webId, listId, itemId, userId, diagnosticInfo };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMenuItems, methodGetMenuItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<NavigationService, DataTable>(_navigationServiceInstanceFixture, out exception1, parametersOfGetMenuItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<NavigationService, DataTable>(_navigationServiceInstance, MethodGetMenuItems, parametersOfGetMenuItems, methodGetMenuItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMenuItems.ShouldNotBeNull();
            parametersOfGetMenuItems.Length.ShouldBe(6);
            methodGetMenuItemsPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(() => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfGetMenuItems));
        }

        #endregion

        #region Method Call : (GetMenuItems) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetMenuItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            var methodGetMenuItemsPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(int), typeof(Dictionary<string, string>) };
            object[] parametersOfGetMenuItems = { siteId, webId, listId, itemId, userId, diagnosticInfo };

            // Assert
            parametersOfGetMenuItems.ShouldNotBeNull();
            parametersOfGetMenuItems.Length.ShouldBe(6);
            methodGetMenuItemsPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<NavigationService, DataTable>(_navigationServiceInstance, MethodGetMenuItems, parametersOfGetMenuItems, methodGetMenuItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMenuItems) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetMenuItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMenuItemsPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(int), typeof(Dictionary<string, string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetMenuItems, Fixture, methodGetMenuItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMenuItemsPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (GetMenuItems) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetMenuItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMenuItemsPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(int), typeof(Dictionary<string, string>) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetMenuItems, Fixture, methodGetMenuItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMenuItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMenuItems) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetMenuItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMenuItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMenuItems) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetMenuItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMenuItems, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveNavigationLink) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_RemoveNavigationLink_Method_Call_Internally(Type[] types)
        {
            var methodRemoveNavigationLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodRemoveNavigationLink, Fixture, methodRemoveNavigationLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveNavigationLink) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_RemoveNavigationLink_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _navigationServiceInstance.RemoveNavigationLink(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RemoveNavigationLink) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_RemoveNavigationLink_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRemoveNavigationLinkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveNavigationLink = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveNavigationLink, methodRemoveNavigationLinkPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfRemoveNavigationLink);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveNavigationLink.ShouldNotBeNull();
            parametersOfRemoveNavigationLink.Length.ShouldBe(1);
            methodRemoveNavigationLinkPrametersTypes.Length.ShouldBe(1);
            methodRemoveNavigationLinkPrametersTypes.Length.ShouldBe(parametersOfRemoveNavigationLink.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveNavigationLink) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_RemoveNavigationLink_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRemoveNavigationLinkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveNavigationLink = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_navigationServiceInstance, MethodRemoveNavigationLink, parametersOfRemoveNavigationLink, methodRemoveNavigationLinkPrametersTypes);

            // Assert
            parametersOfRemoveNavigationLink.ShouldNotBeNull();
            parametersOfRemoveNavigationLink.Length.ShouldBe(1);
            methodRemoveNavigationLinkPrametersTypes.Length.ShouldBe(1);
            methodRemoveNavigationLinkPrametersTypes.Length.ShouldBe(parametersOfRemoveNavigationLink.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveNavigationLink) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_RemoveNavigationLink_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveNavigationLink, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveNavigationLink) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_RemoveNavigationLink_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveNavigationLinkPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodRemoveNavigationLink, Fixture, methodRemoveNavigationLinkPrametersTypes);

            // Assert
            methodRemoveNavigationLinkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveNavigationLink) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_RemoveNavigationLink_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveNavigationLink, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReorderLinks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_ReorderLinks_Method_Call_Internally(Type[] types)
        {
            var methodReorderLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodReorderLinks, Fixture, methodReorderLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (ReorderLinks) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_ReorderLinks_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _navigationServiceInstance.ReorderLinks(data);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ReorderLinks) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_ReorderLinks_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReorderLinksPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReorderLinks = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReorderLinks, methodReorderLinksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfReorderLinks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReorderLinks.ShouldNotBeNull();
            parametersOfReorderLinks.Length.ShouldBe(1);
            methodReorderLinksPrametersTypes.Length.ShouldBe(1);
            methodReorderLinksPrametersTypes.Length.ShouldBe(parametersOfReorderLinks.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReorderLinks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_ReorderLinks_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReorderLinksPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReorderLinks = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_navigationServiceInstance, MethodReorderLinks, parametersOfReorderLinks, methodReorderLinksPrametersTypes);

            // Assert
            parametersOfReorderLinks.ShouldNotBeNull();
            parametersOfReorderLinks.Length.ShouldBe(1);
            methodReorderLinksPrametersTypes.Length.ShouldBe(1);
            methodReorderLinksPrametersTypes.Length.ShouldBe(parametersOfReorderLinks.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReorderLinks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_ReorderLinks_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReorderLinks, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReorderLinks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_ReorderLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReorderLinksPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodReorderLinks, Fixture, methodReorderLinksPrametersTypes);

            // Assert
            methodReorderLinksPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReorderLinks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_ReorderLinks_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReorderLinks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AT) (Return Type : Tuple<string, string, string, string, bool>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_AT_Static_Method_Call_Internally(Type[] types)
        {
            var methodATPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodAT, Fixture, methodATPrametersTypes);
        }

        #endregion

        #region Method Call : (AT) (Return Type : Tuple<string, string, string, string, bool>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_AT_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var command = CreateType<string>();
            var imgUrl = CreateType<string>();
            var allowed = CreateType<bool>();
            var kind = CreateType<string>();
            var methodATPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(bool), typeof(string) };
            object[] parametersOfAT = { title, command, imgUrl, allowed, kind };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAT, methodATPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAT.ShouldNotBeNull();
            parametersOfAT.Length.ShouldBe(5);
            methodATPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfAT));
        }

        #endregion

        #region Method Call : (AT) (Return Type : Tuple<string, string, string, string, bool>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_AT_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var command = CreateType<string>();
            var imgUrl = CreateType<string>();
            var allowed = CreateType<bool>();
            var kind = CreateType<string>();
            var methodATPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(bool), typeof(string) };
            object[] parametersOfAT = { title, command, imgUrl, allowed, kind };

            // Assert
            parametersOfAT.ShouldNotBeNull();
            parametersOfAT.Length.ShouldBe(5);
            methodATPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Tuple<string, string, string, string, bool>>(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodAT, parametersOfAT, methodATPrametersTypes));
        }

        #endregion

        #region Method Call : (AT) (Return Type : Tuple<string, string, string, string, bool>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_AT_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodATPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(bool), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodAT, Fixture, methodATPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodATPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AT) (Return Type : Tuple<string, string, string, string, bool>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_AT_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAT, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AT) (Return Type : Tuple<string, string, string, string, bool>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_AT_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAT, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CalculateLinkId) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_CalculateLinkId_Method_Call_Internally(Type[] types)
        {
            var methodCalculateLinkIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodCalculateLinkId, Fixture, methodCalculateLinkIdPrametersTypes);
        }

        #endregion

        #region Method Call : (CalculateLinkId) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_CalculateLinkId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var navLink = CreateType<NavLink>();
            var providerName = CreateType<string>();
            var methodCalculateLinkIdPrametersTypes = new Type[] { typeof(NavLink), typeof(string) };
            object[] parametersOfCalculateLinkId = { navLink, providerName };

            // Assert
            parametersOfCalculateLinkId.ShouldNotBeNull();
            parametersOfCalculateLinkId.Length.ShouldBe(2);
            methodCalculateLinkIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<NavigationService, string>(_navigationServiceInstance, MethodCalculateLinkId, parametersOfCalculateLinkId, methodCalculateLinkIdPrametersTypes));
        }

        #endregion

        #region Method Call : (CalculateLinkId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_CalculateLinkId_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCalculateLinkIdPrametersTypes = new Type[] { typeof(NavLink), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodCalculateLinkId, Fixture, methodCalculateLinkIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCalculateLinkIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CalculateLinkId) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_CalculateLinkId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCalculateLinkIdPrametersTypes = new Type[] { typeof(NavLink), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodCalculateLinkId, Fixture, methodCalculateLinkIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCalculateLinkIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems_ParseRequest) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetContextualMenuItems_ParseRequest_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetContextualMenuItems_ParseRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodGetContextualMenuItems_ParseRequest, Fixture, methodGetContextualMenuItems_ParseRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems_ParseRequest) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_ParseRequest_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var debugMode = CreateType<bool>();
            var methodGetContextualMenuItems_ParseRequestPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(int), typeof(bool) };
            object[] parametersOfGetContextualMenuItems_ParseRequest = { data, siteId, webId, listId, itemId, userId, debugMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetContextualMenuItems_ParseRequest, methodGetContextualMenuItems_ParseRequestPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfGetContextualMenuItems_ParseRequest);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetContextualMenuItems_ParseRequest.ShouldNotBeNull();
            parametersOfGetContextualMenuItems_ParseRequest.Length.ShouldBe(7);
            methodGetContextualMenuItems_ParseRequestPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems_ParseRequest) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_ParseRequest_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var debugMode = CreateType<bool>();
            var methodGetContextualMenuItems_ParseRequestPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(int), typeof(bool) };
            object[] parametersOfGetContextualMenuItems_ParseRequest = { data, siteId, webId, listId, itemId, userId, debugMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodGetContextualMenuItems_ParseRequest, parametersOfGetContextualMenuItems_ParseRequest, methodGetContextualMenuItems_ParseRequestPrametersTypes);

            // Assert
            parametersOfGetContextualMenuItems_ParseRequest.ShouldNotBeNull();
            parametersOfGetContextualMenuItems_ParseRequest.Length.ShouldBe(7);
            methodGetContextualMenuItems_ParseRequestPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems_ParseRequest) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_ParseRequest_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetContextualMenuItems_ParseRequest, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems_ParseRequest) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_ParseRequest_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetContextualMenuItems_ParseRequestPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(int), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodGetContextualMenuItems_ParseRequest, Fixture, methodGetContextualMenuItems_ParseRequestPrametersTypes);

            // Assert
            methodGetContextualMenuItems_ParseRequestPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems_ParseRequest) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_ParseRequest_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetContextualMenuItems_ParseRequest, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinkId) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetLinkId_Method_Call_Internally(Type[] types)
        {
            var methodGetLinkIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetLinkId, Fixture, methodGetLinkIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinkId) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinkId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var navLink = CreateType<NavLink>();
            var providerName = CreateType<string>();
            var methodGetLinkIdPrametersTypes = new Type[] { typeof(NavLink), typeof(string) };
            object[] parametersOfGetLinkId = { navLink, providerName };

            // Assert
            parametersOfGetLinkId.ShouldNotBeNull();
            parametersOfGetLinkId.Length.ShouldBe(2);
            methodGetLinkIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<NavigationService, string>(_navigationServiceInstance, MethodGetLinkId, parametersOfGetLinkId, methodGetLinkIdPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLinkId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinkId_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLinkIdPrametersTypes = new Type[] { typeof(NavLink), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetLinkId, Fixture, methodGetLinkIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinkIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLinkId) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinkId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLinkIdPrametersTypes = new Type[] { typeof(NavLink), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetLinkId, Fixture, methodGetLinkIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinkIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNavigationLinks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetNavigationLinks_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetNavigationLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodGetNavigationLinks, Fixture, methodGetNavigationLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNavigationLinks) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetNavigationLinks_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var linkProvider = CreateType<INavLinkProvider>();
            var links = CreateType<SortedDictionary<int, NavLink>>();
            var methodGetNavigationLinksPrametersTypes = new Type[] { typeof(INavLinkProvider), typeof(SortedDictionary<int, NavLink>) };
            object[] parametersOfGetNavigationLinks = { linkProvider, links };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetNavigationLinks, methodGetNavigationLinksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfGetNavigationLinks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetNavigationLinks.ShouldNotBeNull();
            parametersOfGetNavigationLinks.Length.ShouldBe(2);
            methodGetNavigationLinksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNavigationLinks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetNavigationLinks_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var linkProvider = CreateType<INavLinkProvider>();
            var links = CreateType<SortedDictionary<int, NavLink>>();
            var methodGetNavigationLinksPrametersTypes = new Type[] { typeof(INavLinkProvider), typeof(SortedDictionary<int, NavLink>) };
            object[] parametersOfGetNavigationLinks = { linkProvider, links };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodGetNavigationLinks, parametersOfGetNavigationLinks, methodGetNavigationLinksPrametersTypes);

            // Assert
            parametersOfGetNavigationLinks.ShouldNotBeNull();
            parametersOfGetNavigationLinks.Length.ShouldBe(2);
            methodGetNavigationLinksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNavigationLinks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetNavigationLinks_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetNavigationLinks, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNavigationLinks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetNavigationLinks_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNavigationLinksPrametersTypes = new Type[] { typeof(INavLinkProvider), typeof(SortedDictionary<int, NavLink>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodGetNavigationLinks, Fixture, methodGetNavigationLinksPrametersTypes);

            // Assert
            methodGetNavigationLinksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNavigationLinks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetNavigationLinks_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetNavigationLinks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LIP) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_LIP_Static_Method_Call_Internally(Type[] types)
        {
            var methodLIPPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodLIP, Fixture, methodLIPPrametersTypes);
        }

        #endregion

        #region Method Call : (LIP) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LIP_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listItem = CreateType<SPListItem>();
            var spBasePermissions = CreateType<SPBasePermissions>();
            var methodLIPPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPBasePermissions) };
            object[] parametersOfLIP = { listItem, spBasePermissions };

            // Assert
            parametersOfLIP.ShouldNotBeNull();
            parametersOfLIP.Length.ShouldBe(2);
            methodLIPPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodLIP, parametersOfLIP, methodLIPPrametersTypes));
        }

        #endregion

        #region Method Call : (LIP) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LIP_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLIPPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPBasePermissions) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodLIP, Fixture, methodLIPPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLIPPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LIP) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LIP_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLIP, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LIP) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LIP_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLIP, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadProvider) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_LoadProvider_Method_Call_Internally(Type[] types)
        {
            var methodLoadProviderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodLoadProvider, Fixture, methodLoadProviderPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadProvider) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LoadProvider_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var provider = CreateType<string>();
            var types = CreateType<dynamic>();
            var methodLoadProviderPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<Type>) };
            object[] parametersOfLoadProvider = { provider, types };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_navigationServiceInstance, MethodLoadProvider, parametersOfLoadProvider, methodLoadProviderPrametersTypes);

            // Assert
            parametersOfLoadProvider.ShouldNotBeNull();
            parametersOfLoadProvider.Length.ShouldBe(2);
            methodLoadProviderPrametersTypes.Length.ShouldBe(2);
            methodLoadProviderPrametersTypes.Length.ShouldBe(parametersOfLoadProvider.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadProvider) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LoadProvider_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadProviderPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<Type>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodLoadProvider, Fixture, methodLoadProviderPrametersTypes);

            // Assert
            methodLoadProviderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LP) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_LP_Static_Method_Call_Internally(Type[] types)
        {
            var methodLPPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodLP, Fixture, methodLPPrametersTypes);
        }

        #endregion

        #region Method Call : (LP) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LP_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var spBasePermissions = CreateType<SPBasePermissions>();
            var methodLPPrametersTypes = new Type[] { typeof(SPList), typeof(SPBasePermissions) };
            object[] parametersOfLP = { list, spBasePermissions };

            // Assert
            parametersOfLP.ShouldNotBeNull();
            parametersOfLP.Length.ShouldBe(2);
            methodLPPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodLP, parametersOfLP, methodLPPrametersTypes));
        }

        #endregion

        #region Method Call : (LP) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LP_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLPPrametersTypes = new Type[] { typeof(SPList), typeof(SPBasePermissions) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodLP, Fixture, methodLPPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLPPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LP) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LP_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLP, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LP) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LP_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLP, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LPPFEPermissionCheck) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_LPPFEPermissionCheck_Static_Method_Call_Internally(Type[] types)
        {
            var methodLPPFEPermissionCheckPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodLPPFEPermissionCheck, Fixture, methodLPPFEPermissionCheckPrametersTypes);
        }

        #endregion

        #region Method Call : (LPPFEPermissionCheck) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LPPFEPermissionCheck_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var spBasePermissions = CreateType<SPBasePermissions>();
            var methodLPPFEPermissionCheckPrametersTypes = new Type[] { typeof(SPList), typeof(SPBasePermissions) };
            object[] parametersOfLPPFEPermissionCheck = { list, spBasePermissions };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLPPFEPermissionCheck, methodLPPFEPermissionCheckPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLPPFEPermissionCheck.ShouldNotBeNull();
            parametersOfLPPFEPermissionCheck.Length.ShouldBe(2);
            methodLPPFEPermissionCheckPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfLPPFEPermissionCheck));
        }

        #endregion

        #region Method Call : (LPPFEPermissionCheck) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LPPFEPermissionCheck_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var spBasePermissions = CreateType<SPBasePermissions>();
            var methodLPPFEPermissionCheckPrametersTypes = new Type[] { typeof(SPList), typeof(SPBasePermissions) };
            object[] parametersOfLPPFEPermissionCheck = { list, spBasePermissions };

            // Assert
            parametersOfLPPFEPermissionCheck.ShouldNotBeNull();
            parametersOfLPPFEPermissionCheck.Length.ShouldBe(2);
            methodLPPFEPermissionCheckPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodLPPFEPermissionCheck, parametersOfLPPFEPermissionCheck, methodLPPFEPermissionCheckPrametersTypes));
        }

        #endregion

        #region Method Call : (LPPFEPermissionCheck) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LPPFEPermissionCheck_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLPPFEPermissionCheckPrametersTypes = new Type[] { typeof(SPList), typeof(SPBasePermissions) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodLPPFEPermissionCheck, Fixture, methodLPPFEPermissionCheckPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLPPFEPermissionCheckPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LPPFEPermissionCheck) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LPPFEPermissionCheck_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLPPFEPermissionCheck, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (LPPFEPermissionCheck) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_LPPFEPermissionCheck_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLPPFEPermissionCheck, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPFEActions) (Return Type : Tuple<string, string, string, string, bool>[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetPFEActions_Method_Call_Internally(Type[] types)
        {
            var methodGetPFEActionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetPFEActions, Fixture, methodGetPFEActionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPFEActions) (Return Type : Tuple<string, string, string, string, bool>[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetPFEActions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var di = CreateType<Dictionary<string, string>>();
            var methodGetPFEActionsPrametersTypes = new Type[] { typeof(SPList), typeof(Dictionary<string, string>) };
            object[] parametersOfGetPFEActions = { list, di };

            // Assert
            parametersOfGetPFEActions.ShouldNotBeNull();
            parametersOfGetPFEActions.Length.ShouldBe(2);
            methodGetPFEActionsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<NavigationService, Tuple<string, string, string, string, bool>[]>(_navigationServiceInstance, MethodGetPFEActions, parametersOfGetPFEActions, methodGetPFEActionsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetPFEActions) (Return Type : Tuple<string, string, string, string, bool>[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetPFEActions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPFEActionsPrametersTypes = new Type[] { typeof(SPList), typeof(Dictionary<string, string>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetPFEActions, Fixture, methodGetPFEActionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPFEActionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSocialActions) (Return Type : Tuple<string, string, string, string, bool>[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetSocialActions_Method_Call_Internally(Type[] types)
        {
            var methodGetSocialActionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetSocialActions, Fixture, methodGetSocialActionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSocialActions) (Return Type : Tuple<string, string, string, string, bool>[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetSocialActions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listItem = CreateType<SPListItem>();
            var settings = CreateType<GridGanttSettings>();
            var di = CreateType<Dictionary<string, string>>();
            var methodGetSocialActionsPrametersTypes = new Type[] { typeof(SPListItem), typeof(GridGanttSettings), typeof(Dictionary<string, string>) };
            object[] parametersOfGetSocialActions = { listItem, settings, di };

            // Assert
            parametersOfGetSocialActions.ShouldNotBeNull();
            parametersOfGetSocialActions.Length.ShouldBe(3);
            methodGetSocialActionsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<NavigationService, Tuple<string, string, string, string, bool>[]>(_navigationServiceInstance, MethodGetSocialActions, parametersOfGetSocialActions, methodGetSocialActionsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetSocialActions) (Return Type : Tuple<string, string, string, string, bool>[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetSocialActions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSocialActionsPrametersTypes = new Type[] { typeof(SPListItem), typeof(GridGanttSettings), typeof(Dictionary<string, string>) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetSocialActions, Fixture, methodGetSocialActionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSocialActionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkspaceActions) (Return Type : Tuple<string, string, string, string, bool>[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetWorkspaceActions_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkspaceActionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetWorkspaceActions, Fixture, methodGetWorkspaceActionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkspaceActions) (Return Type : Tuple<string, string, string, string, bool>[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetWorkspaceActions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var di = CreateType<Dictionary<string, string>>();
            var methodGetWorkspaceActionsPrametersTypes = new Type[] { typeof(SPListItem), typeof(Dictionary<string, string>) };
            object[] parametersOfGetWorkspaceActions = { li, di };

            // Assert
            parametersOfGetWorkspaceActions.ShouldNotBeNull();
            parametersOfGetWorkspaceActions.Length.ShouldBe(2);
            methodGetWorkspaceActionsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<NavigationService, Tuple<string, string, string, string, bool>[]>(_navigationServiceInstance, MethodGetWorkspaceActions, parametersOfGetWorkspaceActions, methodGetWorkspaceActionsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkspaceActions) (Return Type : Tuple<string, string, string, string, bool>[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetWorkspaceActions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkspaceActionsPrametersTypes = new Type[] { typeof(SPListItem), typeof(Dictionary<string, string>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetWorkspaceActions, Fixture, methodGetWorkspaceActionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkspaceActionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGeneralActions) (Return Type : Tuple<string, string, string, string, bool>[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetGeneralActions_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGeneralActionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodGetGeneralActions, Fixture, methodGetGeneralActionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGeneralActions) (Return Type : Tuple<string, string, string, string, bool>[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetGeneralActions_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var usePopup = CreateType<bool>();
            var list = CreateType<SPList>();
            var bfancyforms = CreateType<bool>();
            var di = CreateType<Dictionary<string, string>>();
            var methodGetGeneralActionsPrametersTypes = new Type[] { typeof(bool), typeof(SPList), typeof(bool), typeof(Dictionary<string, string>) };
            object[] parametersOfGetGeneralActions = { usePopup, list, bfancyforms, di };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGeneralActions, methodGetGeneralActionsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGeneralActions.ShouldNotBeNull();
            parametersOfGetGeneralActions.Length.ShouldBe(4);
            methodGetGeneralActionsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_navigationServiceInstanceFixture, parametersOfGetGeneralActions));
        }

        #endregion

        #region Method Call : (GetGeneralActions) (Return Type : Tuple<string, string, string, string, bool>[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetGeneralActions_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var usePopup = CreateType<bool>();
            var list = CreateType<SPList>();
            var bfancyforms = CreateType<bool>();
            var di = CreateType<Dictionary<string, string>>();
            var methodGetGeneralActionsPrametersTypes = new Type[] { typeof(bool), typeof(SPList), typeof(bool), typeof(Dictionary<string, string>) };
            object[] parametersOfGetGeneralActions = { usePopup, list, bfancyforms, di };

            // Assert
            parametersOfGetGeneralActions.ShouldNotBeNull();
            parametersOfGetGeneralActions.Length.ShouldBe(4);
            methodGetGeneralActionsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Tuple<string, string, string, string, bool>[]>(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodGetGeneralActions, parametersOfGetGeneralActions, methodGetGeneralActionsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGeneralActions) (Return Type : Tuple<string, string, string, string, bool>[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetGeneralActions_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGeneralActionsPrametersTypes = new Type[] { typeof(bool), typeof(SPList), typeof(bool), typeof(Dictionary<string, string>) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_navigationServiceInstanceFixture, _navigationServiceInstanceType, MethodGetGeneralActions, Fixture, methodGetGeneralActionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGeneralActionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGeneralActions) (Return Type : Tuple<string, string, string, string, bool>[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetGeneralActions_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGeneralActions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_navigationServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetGeneralActions) (Return Type : Tuple<string, string, string, string, bool>[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetGeneralActions_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGeneralActions, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPlannerActions) (Return Type : Tuple<string, string, string, string, bool>[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NavigationService_GetPlannerActions_Method_Call_Internally(Type[] types)
        {
            var methodGetPlannerActionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetPlannerActions, Fixture, methodGetPlannerActionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPlannerActions) (Return Type : Tuple<string, string, string, string, bool>[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetPlannerActions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var di = CreateType<Dictionary<string, string>>();
            var methodGetPlannerActionsPrametersTypes = new Type[] { typeof(SPList), typeof(Dictionary<string, string>) };
            object[] parametersOfGetPlannerActions = { list, di };

            // Assert
            parametersOfGetPlannerActions.ShouldNotBeNull();
            parametersOfGetPlannerActions.Length.ShouldBe(2);
            methodGetPlannerActionsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<NavigationService, Tuple<string, string, string, string, bool>[]>(_navigationServiceInstance, MethodGetPlannerActions, parametersOfGetPlannerActions, methodGetPlannerActionsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetPlannerActions) (Return Type : Tuple<string, string, string, string, bool>[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetPlannerActions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPlannerActionsPrametersTypes = new Type[] { typeof(SPList), typeof(Dictionary<string, string>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_navigationServiceInstance, MethodGetPlannerActions, Fixture, methodGetPlannerActionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPlannerActionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}
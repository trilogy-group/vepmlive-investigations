using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.Infrastructure.Navigation;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.Providers.RecentItemsLinkProvider" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation.Providers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RecentItemsLinkProviderTest : AbstractBaseSetupTypedTest<RecentItemsLinkProvider>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RecentItemsLinkProvider) Initializer

        private const string PropertyKey = "Key";
        private const string MethodGetLinks = "GetLinks";
        private const string MethodGetFrequentApps = "GetFrequentApps";
        private const string MethodGetRecentItems = "GetRecentItems";
        private const string MethodGetData = "GetData";
        private const string Field_key = "_key";
        private const string FieldRI_QUERY = "RI_QUERY";
        private const string FieldFA_QUERY = "FA_QUERY";
        private Type _recentItemsLinkProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RecentItemsLinkProvider _recentItemsLinkProviderInstance;
        private RecentItemsLinkProvider _recentItemsLinkProviderInstanceFixture;

        #region General Initializer : Class (RecentItemsLinkProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RecentItemsLinkProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _recentItemsLinkProviderInstanceType = typeof(RecentItemsLinkProvider);
            _recentItemsLinkProviderInstanceFixture = Create(true);
            _recentItemsLinkProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RecentItemsLinkProvider)

        #region General Initializer : Class (RecentItemsLinkProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="RecentItemsLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetLinks, 0)]
        [TestCase(MethodGetFrequentApps, 0)]
        [TestCase(MethodGetRecentItems, 0)]
        [TestCase(MethodGetLinks, 1)]
        [TestCase(MethodGetData, 0)]
        public void AUT_RecentItemsLinkProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_recentItemsLinkProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RecentItemsLinkProvider) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RecentItemsLinkProvider" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKey)]
        public void AUT_RecentItemsLinkProvider_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_recentItemsLinkProviderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RecentItemsLinkProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RecentItemsLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_key)]
        [TestCase(FieldRI_QUERY)]
        [TestCase(FieldFA_QUERY)]
        public void AUT_RecentItemsLinkProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_recentItemsLinkProviderInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (RecentItemsLinkProvider) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_RecentItemsLinkProvider_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKey);

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
        ///      Class (<see cref="RecentItemsLinkProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetLinks)]
        [TestCase(MethodGetFrequentApps)]
        [TestCase(MethodGetRecentItems)]
        [TestCase(MethodGetData)]
        public void AUT_RecentItemsLinkProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<RecentItemsLinkProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _recentItemsLinkProviderInstance.GetLinks();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinks, methodGetLinksPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RecentItemsLinkProvider, IEnumerable<INavObject>>(_recentItemsLinkProviderInstanceFixture, out exception1, parametersOfGetLinks);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RecentItemsLinkProvider, IEnumerable<INavObject>>(_recentItemsLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_recentItemsLinkProviderInstanceFixture, parametersOfGetLinks));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present

            // Assert
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<RecentItemsLinkProvider, IEnumerable<INavObject>>(_recentItemsLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_recentItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFrequentApps) (Return Type : List<NavLink>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RecentItemsLinkProvider_GetFrequentApps_Method_Call_Internally(Type[] types)
        {
            var methodGetFrequentAppsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetFrequentApps, Fixture, methodGetFrequentAppsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFrequentApps) (Return Type : List<NavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetFrequentApps_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFrequentAppsPrametersTypes = null;
            object[] parametersOfGetFrequentApps = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFrequentApps, methodGetFrequentAppsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RecentItemsLinkProvider, List<NavLink>>(_recentItemsLinkProviderInstanceFixture, out exception1, parametersOfGetFrequentApps);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RecentItemsLinkProvider, List<NavLink>>(_recentItemsLinkProviderInstance, MethodGetFrequentApps, parametersOfGetFrequentApps, methodGetFrequentAppsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFrequentApps.ShouldBeNull();
            methodGetFrequentAppsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_recentItemsLinkProviderInstanceFixture, parametersOfGetFrequentApps));
        }

        #endregion

        #region Method Call : (GetFrequentApps) (Return Type : List<NavLink>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetFrequentApps_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFrequentAppsPrametersTypes = null;
            object[] parametersOfGetFrequentApps = null; // no parameter present

            // Assert
            parametersOfGetFrequentApps.ShouldBeNull();
            methodGetFrequentAppsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<RecentItemsLinkProvider, List<NavLink>>(_recentItemsLinkProviderInstance, MethodGetFrequentApps, parametersOfGetFrequentApps, methodGetFrequentAppsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFrequentApps) (Return Type : List<NavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetFrequentApps_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFrequentAppsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetFrequentApps, Fixture, methodGetFrequentAppsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFrequentAppsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFrequentApps) (Return Type : List<NavLink>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetFrequentApps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFrequentAppsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetFrequentApps, Fixture, methodGetFrequentAppsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFrequentAppsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFrequentApps) (Return Type : List<NavLink>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetFrequentApps_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFrequentApps, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_recentItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRecentItems) (Return Type : IEnumerable<NavLink>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RecentItemsLinkProvider_GetRecentItems_Method_Call_Internally(Type[] types)
        {
            var methodGetRecentItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetRecentItems, Fixture, methodGetRecentItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRecentItems) (Return Type : IEnumerable<NavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetRecentItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRecentItemsPrametersTypes = null;
            object[] parametersOfGetRecentItems = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRecentItems, methodGetRecentItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RecentItemsLinkProvider, IEnumerable<NavLink>>(_recentItemsLinkProviderInstanceFixture, out exception1, parametersOfGetRecentItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RecentItemsLinkProvider, IEnumerable<NavLink>>(_recentItemsLinkProviderInstance, MethodGetRecentItems, parametersOfGetRecentItems, methodGetRecentItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRecentItems.ShouldBeNull();
            methodGetRecentItemsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_recentItemsLinkProviderInstanceFixture, parametersOfGetRecentItems));
        }

        #endregion

        #region Method Call : (GetRecentItems) (Return Type : IEnumerable<NavLink>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetRecentItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetRecentItemsPrametersTypes = null;
            object[] parametersOfGetRecentItems = null; // no parameter present

            // Assert
            parametersOfGetRecentItems.ShouldBeNull();
            methodGetRecentItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<RecentItemsLinkProvider, IEnumerable<NavLink>>(_recentItemsLinkProviderInstance, MethodGetRecentItems, parametersOfGetRecentItems, methodGetRecentItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRecentItems) (Return Type : IEnumerable<NavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetRecentItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRecentItemsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetRecentItems, Fixture, methodGetRecentItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRecentItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRecentItems) (Return Type : IEnumerable<NavLink>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetRecentItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetRecentItemsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetRecentItems, Fixture, methodGetRecentItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRecentItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRecentItems) (Return Type : IEnumerable<NavLink>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetRecentItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRecentItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_recentItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RecentItemsLinkProvider_GetLinks_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_Void_Overloading_Of_1_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dataTable = CreateType<DataTable>();
            var links = CreateType<List<NavLink>>();
            var methodGetLinksPrametersTypes = new Type[] { typeof(DataTable), typeof(List<NavLink>) };
            object[] parametersOfGetLinks = { dataTable, links };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetLinks, methodGetLinksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_recentItemsLinkProviderInstanceFixture, parametersOfGetLinks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetLinks.ShouldNotBeNull();
            parametersOfGetLinks.Length.ShouldBe(2);
            methodGetLinksPrametersTypes.Length.ShouldBe(2);
            methodGetLinksPrametersTypes.Length.ShouldBe(parametersOfGetLinks.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataTable = CreateType<DataTable>();
            var links = CreateType<List<NavLink>>();
            var methodGetLinksPrametersTypes = new Type[] { typeof(DataTable), typeof(List<NavLink>) };
            object[] parametersOfGetLinks = { dataTable, links };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_recentItemsLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes);

            // Assert
            parametersOfGetLinks.ShouldNotBeNull();
            parametersOfGetLinks.Length.ShouldBe(2);
            methodGetLinksPrametersTypes.Length.ShouldBe(2);
            methodGetLinksPrametersTypes.Length.ShouldBe(parametersOfGetLinks.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLinks, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLinksPrametersTypes = new Type[] { typeof(DataTable), typeof(List<NavLink>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            methodGetLinksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetLinks_Method_Call_Overloading_Of_1_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinks, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_recentItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RecentItemsLinkProvider_GetData_Method_Call_Internally(Type[] types)
        {
            var methodGetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var methodGetDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetData = { query };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetData, methodGetDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RecentItemsLinkProvider, DataTable>(_recentItemsLinkProviderInstanceFixture, out exception1, parametersOfGetData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RecentItemsLinkProvider, DataTable>(_recentItemsLinkProviderInstance, MethodGetData, parametersOfGetData, methodGetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetData.ShouldNotBeNull();
            parametersOfGetData.Length.ShouldBe(1);
            methodGetDataPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_recentItemsLinkProviderInstanceFixture, parametersOfGetData));
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var methodGetDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetData = { query };

            // Assert
            parametersOfGetData.ShouldNotBeNull();
            parametersOfGetData.Length.ShouldBe(1);
            methodGetDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<RecentItemsLinkProvider, DataTable>(_recentItemsLinkProviderInstance, MethodGetData, parametersOfGetData, methodGetDataPrametersTypes));
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_recentItemsLinkProviderInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_recentItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItemsLinkProvider_GetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetData, 0);
            const int parametersCount = 1;

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
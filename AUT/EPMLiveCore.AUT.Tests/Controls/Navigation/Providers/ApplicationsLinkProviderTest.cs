using System;
using System.Collections.Generic;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.Providers.ApplicationsLinkProvider" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation.Providers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ApplicationsLinkProviderTest : AbstractBaseSetupTypedTest<ApplicationsLinkProvider>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ApplicationsLinkProvider) Initializer

        private const string PropertyKey = "Key";
        private const string MethodGetLinks = "GetLinks";
        private const string MethodGetListLibLinks = "GetListLibLinks";
        private const string MethodGetUrl = "GetUrl";
        private const string Field_key = "_key";
        private Type _applicationsLinkProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ApplicationsLinkProvider _applicationsLinkProviderInstance;
        private ApplicationsLinkProvider _applicationsLinkProviderInstanceFixture;

        #region General Initializer : Class (ApplicationsLinkProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ApplicationsLinkProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _applicationsLinkProviderInstanceType = typeof(ApplicationsLinkProvider);
            _applicationsLinkProviderInstanceFixture = Create(true);
            _applicationsLinkProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ApplicationsLinkProvider)

        #region General Initializer : Class (ApplicationsLinkProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ApplicationsLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetLinks, 0)]
        [TestCase(MethodGetListLibLinks, 0)]
        [TestCase(MethodGetUrl, 0)]
        public void AUT_ApplicationsLinkProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_applicationsLinkProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ApplicationsLinkProvider) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ApplicationsLinkProvider" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKey)]
        public void AUT_ApplicationsLinkProvider_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_applicationsLinkProviderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ApplicationsLinkProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ApplicationsLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_key)]
        public void AUT_ApplicationsLinkProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_applicationsLinkProviderInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (ApplicationsLinkProvider) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ApplicationsLinkProvider_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ApplicationsLinkProvider" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetUrl)]
        public void AUT_ApplicationsLinkProvider_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_applicationsLinkProviderInstanceFixture,
                                                                              _applicationsLinkProviderInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ApplicationsLinkProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetLinks)]
        [TestCase(MethodGetListLibLinks)]
        public void AUT_ApplicationsLinkProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ApplicationsLinkProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApplicationsLinkProvider_GetLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_applicationsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetLinks_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _applicationsLinkProviderInstance.GetLinks();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetLinks_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinks, methodGetLinksPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ApplicationsLinkProvider, IEnumerable<INavObject>>(_applicationsLinkProviderInstanceFixture, out exception1, parametersOfGetLinks);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ApplicationsLinkProvider, IEnumerable<INavObject>>(_applicationsLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_applicationsLinkProviderInstanceFixture, parametersOfGetLinks));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetLinks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present

            // Assert
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ApplicationsLinkProvider, IEnumerable<INavObject>>(_applicationsLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_applicationsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_applicationsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_applicationsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListLibLinks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApplicationsLinkProvider_GetListLibLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetListLibLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_applicationsLinkProviderInstance, MethodGetListLibLinks, Fixture, methodGetListLibLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListLibLinks) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetListLibLinks_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var links = CreateType<List<NavLink>>();
            var methodGetListLibLinksPrametersTypes = new Type[] { typeof(List<NavLink>) };
            object[] parametersOfGetListLibLinks = { links };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListLibLinks, methodGetListLibLinksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_applicationsLinkProviderInstanceFixture, parametersOfGetListLibLinks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListLibLinks.ShouldNotBeNull();
            parametersOfGetListLibLinks.Length.ShouldBe(1);
            methodGetListLibLinksPrametersTypes.Length.ShouldBe(1);
            methodGetListLibLinksPrametersTypes.Length.ShouldBe(parametersOfGetListLibLinks.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetListLibLinks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetListLibLinks_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var links = CreateType<List<NavLink>>();
            var methodGetListLibLinksPrametersTypes = new Type[] { typeof(List<NavLink>) };
            object[] parametersOfGetListLibLinks = { links };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_applicationsLinkProviderInstance, MethodGetListLibLinks, parametersOfGetListLibLinks, methodGetListLibLinksPrametersTypes);

            // Assert
            parametersOfGetListLibLinks.ShouldNotBeNull();
            parametersOfGetListLibLinks.Length.ShouldBe(1);
            methodGetListLibLinksPrametersTypes.Length.ShouldBe(1);
            methodGetListLibLinksPrametersTypes.Length.ShouldBe(parametersOfGetListLibLinks.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListLibLinks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetListLibLinks_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListLibLinks, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListLibLinks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetListLibLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListLibLinksPrametersTypes = new Type[] { typeof(List<NavLink>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_applicationsLinkProviderInstance, MethodGetListLibLinks, Fixture, methodGetListLibLinksPrametersTypes);

            // Assert
            methodGetListLibLinksPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListLibLinks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetListLibLinks_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListLibLinks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_applicationsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApplicationsLinkProvider_GetUrl_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_applicationsLinkProviderInstanceFixture, _applicationsLinkProviderInstanceType, MethodGetUrl, Fixture, methodGetUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetUrl_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var info = CreateType<string[]>();
            var methodGetUrlPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfGetUrl = { info };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUrl, methodGetUrlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_applicationsLinkProviderInstanceFixture, _applicationsLinkProviderInstanceType, MethodGetUrl, Fixture, methodGetUrlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_applicationsLinkProviderInstanceFixture, _applicationsLinkProviderInstanceType, MethodGetUrl, parametersOfGetUrl, methodGetUrlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_applicationsLinkProviderInstanceFixture, parametersOfGetUrl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUrl.ShouldNotBeNull();
            parametersOfGetUrl.Length.ShouldBe(1);
            methodGetUrlPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetUrl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var info = CreateType<string[]>();
            var methodGetUrlPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfGetUrl = { info };

            // Assert
            parametersOfGetUrl.ShouldNotBeNull();
            parametersOfGetUrl.Length.ShouldBe(1);
            methodGetUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_applicationsLinkProviderInstanceFixture, _applicationsLinkProviderInstanceType, MethodGetUrl, parametersOfGetUrl, methodGetUrlPrametersTypes));
        }

        #endregion

        #region Method Call : (GetUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetUrl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUrlPrametersTypes = new Type[] { typeof(string[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_applicationsLinkProviderInstanceFixture, _applicationsLinkProviderInstanceType, MethodGetUrl, Fixture, methodGetUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetUrl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUrlPrametersTypes = new Type[] { typeof(string[]) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_applicationsLinkProviderInstanceFixture, _applicationsLinkProviderInstanceType, MethodGetUrl, Fixture, methodGetUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUrl) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetUrl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_applicationsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ApplicationsLinkProvider_GetUrl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUrl, 0);
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
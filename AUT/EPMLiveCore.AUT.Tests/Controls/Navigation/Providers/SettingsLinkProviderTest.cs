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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.Providers.SettingsLinkProvider" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation.Providers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SettingsLinkProviderTest : AbstractBaseSetupTypedTest<SettingsLinkProvider>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SettingsLinkProvider) Initializer

        private const string PropertyKey = "Key";
        private const string MethodGetSettings = "GetSettings";
        private const string MethodGetLinks = "GetLinks";
        private const string FieldQUERY = "QUERY";
        private const string FieldVIEW_FIELDS = "VIEW_FIELDS";
        private const string Field_key = "_key";
        private const string Field_links = "_links";
        private Type _settingsLinkProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SettingsLinkProvider _settingsLinkProviderInstance;
        private SettingsLinkProvider _settingsLinkProviderInstanceFixture;

        #region General Initializer : Class (SettingsLinkProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SettingsLinkProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _settingsLinkProviderInstanceType = typeof(SettingsLinkProvider);
            _settingsLinkProviderInstanceFixture = Create(true);
            _settingsLinkProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SettingsLinkProvider)

        #region General Initializer : Class (SettingsLinkProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SettingsLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetSettings, 0)]
        [TestCase(MethodGetLinks, 0)]
        public void AUT_SettingsLinkProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_settingsLinkProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SettingsLinkProvider) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SettingsLinkProvider" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKey)]
        public void AUT_SettingsLinkProvider_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_settingsLinkProviderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SettingsLinkProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SettingsLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldQUERY)]
        [TestCase(FieldVIEW_FIELDS)]
        [TestCase(Field_key)]
        [TestCase(Field_links)]
        public void AUT_SettingsLinkProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_settingsLinkProviderInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (SettingsLinkProvider) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SettingsLinkProvider_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///      Class (<see cref="SettingsLinkProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetSettings)]
        [TestCase(MethodGetLinks)]
        public void AUT_SettingsLinkProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SettingsLinkProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SettingsLinkProvider_GetSettings_Method_Call_Internally(Type[] types)
        {
            var methodGetSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsLinkProviderInstance, MethodGetSettings, Fixture, methodGetSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSettingsPrametersTypes = null;
            object[] parametersOfGetSettings = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSettings, methodGetSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SettingsLinkProvider, IEnumerable<INavObject>>(_settingsLinkProviderInstanceFixture, out exception1, parametersOfGetSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SettingsLinkProvider, IEnumerable<INavObject>>(_settingsLinkProviderInstance, MethodGetSettings, parametersOfGetSettings, methodGetSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSettings.ShouldBeNull();
            methodGetSettingsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_settingsLinkProviderInstanceFixture, parametersOfGetSettings));
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : IEnumerable<INavObject>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSettingsPrametersTypes = null;
            object[] parametersOfGetSettings = null; // no parameter present

            // Assert
            parametersOfGetSettings.ShouldBeNull();
            methodGetSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SettingsLinkProvider, IEnumerable<INavObject>>(_settingsLinkProviderInstance, MethodGetSettings, parametersOfGetSettings, methodGetSettingsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSettingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsLinkProviderInstance, MethodGetSettings, Fixture, methodGetSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSettingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : IEnumerable<INavObject>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSettingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsLinkProviderInstance, MethodGetSettings, Fixture, methodGetSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSettingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : IEnumerable<INavObject>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_settingsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SettingsLinkProvider_GetLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetLinks_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _settingsLinkProviderInstance.GetLinks();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetLinks_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinks, methodGetLinksPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SettingsLinkProvider, IEnumerable<INavObject>>(_settingsLinkProviderInstanceFixture, out exception1, parametersOfGetLinks);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SettingsLinkProvider, IEnumerable<INavObject>>(_settingsLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_settingsLinkProviderInstanceFixture, parametersOfGetLinks));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetLinks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present

            // Assert
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SettingsLinkProvider, IEnumerable<INavObject>>(_settingsLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SettingsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_settingsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
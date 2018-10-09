using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.Personalization.DomainModel;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.DomainModel.EpmChartUserSettings" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EpmChartUserSettingsTest : AbstractBaseSetupTypedTest<EpmChartUserSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EpmChartUserSettings) Initializer

        private const string PropertyKey = "Key";
        private const string PropertyWebPartId = "WebPartId";
        private const string PropertyUserId = "UserId";
        private const string PropertySiteId = "SiteId";
        private const string PropertyWebId = "WebId";
        private const string PropertyListId = "ListId";
        private const string PropertyXaxisField = "XaxisField";
        private const string PropertyXaxisFieldLabel = "XaxisFieldLabel";
        private const string PropertyYaxisFields = "YaxisFields";
        private const string PropertyZaxisField = "ZaxisField";
        private const string PropertyZaxisFieldLabel = "ZaxisFieldLabel";
        private const string PropertyZaxisColorField = "ZaxisColorField";
        private const string PropertyYaxisFieldsCommaSeparated = "YaxisFieldsCommaSeparated";
        private const string PropertyYaxisFieldLabel = "YaxisFieldLabel";
        private const string PropertyIsValid = "IsValid";
        private const string PropertyValue = "Value";
        private const string MethodHydrate = "Hydrate";
        private const string MethodPopulateUserSettings = "PopulateUserSettings";
        private Type _epmChartUserSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EpmChartUserSettings _epmChartUserSettingsInstance;
        private EpmChartUserSettings _epmChartUserSettingsInstanceFixture;

        #region General Initializer : Class (EpmChartUserSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EpmChartUserSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _epmChartUserSettingsInstanceType = typeof(EpmChartUserSettings);
            _epmChartUserSettingsInstanceFixture = Create(true);
            _epmChartUserSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EpmChartUserSettings)

        #region General Initializer : Class (EpmChartUserSettings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EpmChartUserSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodHydrate, 0)]
        [TestCase(MethodPopulateUserSettings, 0)]
        public void AUT_EpmChartUserSettings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_epmChartUserSettingsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion
        
        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="EpmChartUserSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EpmChartUserSettings_Is_Instance_Present_Test()
        {
            // Assert
            _epmChartUserSettingsInstanceType.ShouldNotBeNull();
            _epmChartUserSettingsInstance.ShouldNotBeNull();
            _epmChartUserSettingsInstanceFixture.ShouldNotBeNull();
            _epmChartUserSettingsInstance.ShouldBeAssignableTo<EpmChartUserSettings>();
            _epmChartUserSettingsInstanceFixture.ShouldBeAssignableTo<EpmChartUserSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EpmChartUserSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EpmChartUserSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EpmChartUserSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _epmChartUserSettingsInstanceType.ShouldNotBeNull();
            _epmChartUserSettingsInstance.ShouldNotBeNull();
            _epmChartUserSettingsInstanceFixture.ShouldNotBeNull();
            _epmChartUserSettingsInstance.ShouldBeAssignableTo<EpmChartUserSettings>();
            _epmChartUserSettingsInstanceFixture.ShouldBeAssignableTo<EpmChartUserSettings>();
        }

        #endregion

        #region General Constructor : Class (EpmChartUserSettings) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChartUserSettings_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var epmChartUserSettingsInstance  = new EpmChartUserSettings();

            // Asserts
            epmChartUserSettingsInstance.ShouldNotBeNull();
            epmChartUserSettingsInstance.ShouldBeAssignableTo<EpmChartUserSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (IsValid) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_IsValid_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsValid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (ListId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_ListId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyListId);
            Action currentAction = () => propertyInfo.SetValue(_epmChartUserSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (ListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_ListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (SiteId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_SiteId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySiteId);
            Action currentAction = () => propertyInfo.SetValue(_epmChartUserSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (Value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_Value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (WebId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_WebId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebId);
            Action currentAction = () => propertyInfo.SetValue(_epmChartUserSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (WebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_WebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (WebPartId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_WebPartId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebPartId);
            Action currentAction = () => propertyInfo.SetValue(_epmChartUserSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (WebPartId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_WebPartId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (XaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_XaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyXaxisField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (XaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_XaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyXaxisFieldLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (YaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_YaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyYaxisFieldLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (YaxisFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_YaxisFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyYaxisFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (YaxisFieldsCommaSeparated) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_YaxisFieldsCommaSeparated_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyYaxisFieldsCommaSeparated);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (ZaxisColorField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_ZaxisColorField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyZaxisColorField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (ZaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_ZaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyZaxisField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartUserSettings) => Property (ZaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartUserSettings_Public_Class_ZaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyZaxisFieldLabel);

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
        ///      Class (<see cref="EpmChartUserSettings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodHydrate)]
        [TestCase(MethodPopulateUserSettings)]
        public void AUT_EpmChartUserSettings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EpmChartUserSettings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartUserSettings_Hydrate_Method_Call_Internally(Type[] types)
        {
            var methodHydratePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartUserSettingsInstance, MethodHydrate, Fixture, methodHydratePrametersTypes);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_Hydrate_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var personalizationData = CreateType<PersonalizationData>();
            Action executeAction = null;

            // Act
            executeAction = () => _epmChartUserSettingsInstance.Hydrate(personalizationData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_Hydrate_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var personalizationData = CreateType<PersonalizationData>();
            var methodHydratePrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfHydrate = { personalizationData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHydrate, methodHydratePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartUserSettingsInstanceFixture, parametersOfHydrate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHydrate.ShouldNotBeNull();
            parametersOfHydrate.Length.ShouldBe(1);
            methodHydratePrametersTypes.Length.ShouldBe(1);
            methodHydratePrametersTypes.Length.ShouldBe(parametersOfHydrate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_Hydrate_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var personalizationData = CreateType<PersonalizationData>();
            var methodHydratePrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfHydrate = { personalizationData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartUserSettingsInstance, MethodHydrate, parametersOfHydrate, methodHydratePrametersTypes);

            // Assert
            parametersOfHydrate.ShouldNotBeNull();
            parametersOfHydrate.Length.ShouldBe(1);
            methodHydratePrametersTypes.Length.ShouldBe(1);
            methodHydratePrametersTypes.Length.ShouldBe(parametersOfHydrate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_Hydrate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHydrate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_Hydrate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHydratePrametersTypes = new Type[] { typeof(PersonalizationData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartUserSettingsInstance, MethodHydrate, Fixture, methodHydratePrametersTypes);

            // Assert
            methodHydratePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_Hydrate_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHydrate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartUserSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateUserSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartUserSettings_PopulateUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodPopulateUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartUserSettingsInstance, MethodPopulateUserSettings, Fixture, methodPopulateUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateUserSettings) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_PopulateUserSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var personalizationData = CreateType<PersonalizationData>();
            var methodPopulateUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfPopulateUserSettings = { personalizationData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateUserSettings, methodPopulateUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartUserSettingsInstanceFixture, parametersOfPopulateUserSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateUserSettings.ShouldNotBeNull();
            parametersOfPopulateUserSettings.Length.ShouldBe(1);
            methodPopulateUserSettingsPrametersTypes.Length.ShouldBe(1);
            methodPopulateUserSettingsPrametersTypes.Length.ShouldBe(parametersOfPopulateUserSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateUserSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_PopulateUserSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var personalizationData = CreateType<PersonalizationData>();
            var methodPopulateUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };
            object[] parametersOfPopulateUserSettings = { personalizationData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartUserSettingsInstance, MethodPopulateUserSettings, parametersOfPopulateUserSettings, methodPopulateUserSettingsPrametersTypes);

            // Assert
            parametersOfPopulateUserSettings.ShouldNotBeNull();
            parametersOfPopulateUserSettings.Length.ShouldBe(1);
            methodPopulateUserSettingsPrametersTypes.Length.ShouldBe(1);
            methodPopulateUserSettingsPrametersTypes.Length.ShouldBe(parametersOfPopulateUserSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateUserSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_PopulateUserSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateUserSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateUserSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_PopulateUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateUserSettingsPrametersTypes = new Type[] { typeof(PersonalizationData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartUserSettingsInstance, MethodPopulateUserSettings, Fixture, methodPopulateUserSettingsPrametersTypes);

            // Assert
            methodPopulateUserSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartUserSettings_PopulateUserSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartUserSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
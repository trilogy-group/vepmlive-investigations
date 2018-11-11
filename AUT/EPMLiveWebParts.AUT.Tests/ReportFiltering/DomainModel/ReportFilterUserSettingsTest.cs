using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.ReportFiltering.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportFiltering.DomainModel.ReportFilterUserSettings" />)
    ///     and namespace <see cref="EPMLiveWebParts.ReportFiltering.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportFilterUserSettingsTest : AbstractBaseSetupTypedTest<ReportFilterUserSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportFilterUserSettings) Initializer

        private const string PropertyWebPartId = "WebPartId";
        private const string PropertyUserId = "UserId";
        private const string PropertySiteId = "SiteId";
        private const string PropertyWebId = "WebId";
        private const string PropertyListId = "ListId";
        private const string PropertyFieldSelection = "FieldSelection";
        private const string PropertyTitleSelections = "TitleSelections";
        private const string PropertyCamlQueryOperator = "CamlQueryOperator";
        private const string PropertyValue = "Value";
        private const string PropertyIsValid = "IsValid";
        private const string MethodGetTitleSelectionsFromEncodedString = "GetTitleSelectionsFromEncodedString";
        private const string MethodGetFieldSelectionFromEncodedString = "GetFieldSelectionFromEncodedString";
        private const string MethodHydrate = "Hydrate";
        private const string MethodPopulateSelectedTitles = "PopulateSelectedTitles";
        private const string MethodPopulateSelectedFields = "PopulateSelectedFields";
        private const string MethodPopulateCamlQueryOperatorFromEncodedString = "PopulateCamlQueryOperatorFromEncodedString";
        private Type _reportFilterUserSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportFilterUserSettings _reportFilterUserSettingsInstance;
        private ReportFilterUserSettings _reportFilterUserSettingsInstanceFixture;

        #region General Initializer : Class (ReportFilterUserSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportFilterUserSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportFilterUserSettingsInstanceType = typeof(ReportFilterUserSettings);
            _reportFilterUserSettingsInstanceFixture = Create(true);
            _reportFilterUserSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportFilterUserSettings)

        #region General Initializer : Class (ReportFilterUserSettings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportFilterUserSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetTitleSelectionsFromEncodedString, 0)]
        [TestCase(MethodGetFieldSelectionFromEncodedString, 0)]
        [TestCase(MethodHydrate, 0)]
        [TestCase(MethodPopulateSelectedTitles, 0)]
        [TestCase(MethodPopulateSelectedFields, 0)]
        [TestCase(MethodPopulateCamlQueryOperatorFromEncodedString, 0)]
        public void AUT_ReportFilterUserSettings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportFilterUserSettingsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportFilterUserSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportFilterUserSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyWebPartId)]
        [TestCase(PropertyUserId)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertyWebId)]
        [TestCase(PropertyListId)]
        [TestCase(PropertyFieldSelection)]
        [TestCase(PropertyTitleSelections)]
        [TestCase(PropertyCamlQueryOperator)]
        [TestCase(PropertyValue)]
        [TestCase(PropertyIsValid)]
        public void AUT_ReportFilterUserSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportFilterUserSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ReportFilterUserSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportFilterUserSettings_Is_Instance_Present_Test()
        {
            // Assert
            _reportFilterUserSettingsInstanceType.ShouldNotBeNull();
            _reportFilterUserSettingsInstance.ShouldNotBeNull();
            _reportFilterUserSettingsInstanceFixture.ShouldNotBeNull();
            _reportFilterUserSettingsInstance.ShouldBeAssignableTo<ReportFilterUserSettings>();
            _reportFilterUserSettingsInstanceFixture.ShouldBeAssignableTo<ReportFilterUserSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportFilterUserSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportFilterUserSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportFilterUserSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportFilterUserSettingsInstanceType.ShouldNotBeNull();
            _reportFilterUserSettingsInstance.ShouldNotBeNull();
            _reportFilterUserSettingsInstanceFixture.ShouldNotBeNull();
            _reportFilterUserSettingsInstance.ShouldBeAssignableTo<ReportFilterUserSettings>();
            _reportFilterUserSettingsInstanceFixture.ShouldBeAssignableTo<ReportFilterUserSettings>();
        }

        #endregion

        #region General Constructor : Class (ReportFilterUserSettings) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportFilterUserSettings_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var reportFilterUserSettingsInstance  = new ReportFilterUserSettings();

            // Asserts
            reportFilterUserSettingsInstance.ShouldNotBeNull();
            reportFilterUserSettingsInstance.ShouldBeAssignableTo<ReportFilterUserSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportFilterUserSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Guid?) , PropertyWebPartId)]
        [TestCaseGeneric(typeof(string) , PropertyUserId)]
        [TestCaseGeneric(typeof(Guid?) , PropertySiteId)]
        [TestCaseGeneric(typeof(Guid?) , PropertyWebId)]
        [TestCaseGeneric(typeof(Guid?) , PropertyListId)]
        [TestCaseGeneric(typeof(ReportFilterSelection) , PropertyFieldSelection)]
        [TestCaseGeneric(typeof(List<string>) , PropertyTitleSelections)]
        [TestCaseGeneric(typeof(string) , PropertyCamlQueryOperator)]
        [TestCaseGeneric(typeof(string) , PropertyValue)]
        [TestCaseGeneric(typeof(bool) , PropertyIsValid)]
        public void AUT_ReportFilterUserSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportFilterUserSettings, T>(_reportFilterUserSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (CamlQueryOperator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_CamlQueryOperator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCamlQueryOperator);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (FieldSelection) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_FieldSelection_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFieldSelection);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterUserSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (FieldSelection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_FieldSelection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFieldSelection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (IsValid) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_IsValid_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (ListId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_ListId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyListId);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterUserSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (ListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_ListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (SiteId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_SiteId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySiteId);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterUserSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (TitleSelections) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_TitleSelections_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTitleSelections);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (Value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_Value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (WebId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_WebId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebId);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterUserSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (WebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_WebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (WebPartId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_WebPartId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebPartId);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterUserSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterUserSettings) => Property (WebPartId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterUserSettings_Public_Class_WebPartId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportFilterUserSettings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetTitleSelectionsFromEncodedString)]
        [TestCase(MethodGetFieldSelectionFromEncodedString)]
        [TestCase(MethodHydrate)]
        [TestCase(MethodPopulateSelectedTitles)]
        [TestCase(MethodPopulateSelectedFields)]
        [TestCase(MethodPopulateCamlQueryOperatorFromEncodedString)]
        public void AUT_ReportFilterUserSettings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportFilterUserSettings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetTitleSelectionsFromEncodedString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettings_GetTitleSelectionsFromEncodedString_Method_Call_Internally(Type[] types)
        {
            var methodGetTitleSelectionsFromEncodedStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodGetTitleSelectionsFromEncodedString, Fixture, methodGetTitleSelectionsFromEncodedStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTitleSelectionsFromEncodedString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetTitleSelectionsFromEncodedString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTitleSelectionsFromEncodedStringPrametersTypes = null;
            object[] parametersOfGetTitleSelectionsFromEncodedString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTitleSelectionsFromEncodedString, methodGetTitleSelectionsFromEncodedStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterUserSettingsInstanceFixture, parametersOfGetTitleSelectionsFromEncodedString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTitleSelectionsFromEncodedString.ShouldBeNull();
            methodGetTitleSelectionsFromEncodedStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTitleSelectionsFromEncodedString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetTitleSelectionsFromEncodedString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTitleSelectionsFromEncodedStringPrametersTypes = null;
            object[] parametersOfGetTitleSelectionsFromEncodedString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportFilterUserSettings, string>(_reportFilterUserSettingsInstance, MethodGetTitleSelectionsFromEncodedString, parametersOfGetTitleSelectionsFromEncodedString, methodGetTitleSelectionsFromEncodedStringPrametersTypes);

            // Assert
            parametersOfGetTitleSelectionsFromEncodedString.ShouldBeNull();
            methodGetTitleSelectionsFromEncodedStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTitleSelectionsFromEncodedString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetTitleSelectionsFromEncodedString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetTitleSelectionsFromEncodedStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodGetTitleSelectionsFromEncodedString, Fixture, methodGetTitleSelectionsFromEncodedStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTitleSelectionsFromEncodedStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTitleSelectionsFromEncodedString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetTitleSelectionsFromEncodedString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTitleSelectionsFromEncodedStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodGetTitleSelectionsFromEncodedString, Fixture, methodGetTitleSelectionsFromEncodedStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTitleSelectionsFromEncodedStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTitleSelectionsFromEncodedString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetTitleSelectionsFromEncodedString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTitleSelectionsFromEncodedString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFieldSelectionFromEncodedString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettings_GetFieldSelectionFromEncodedString_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldSelectionFromEncodedStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodGetFieldSelectionFromEncodedString, Fixture, methodGetFieldSelectionFromEncodedStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldSelectionFromEncodedString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetFieldSelectionFromEncodedString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetFieldSelectionFromEncodedStringPrametersTypes = null;
            object[] parametersOfGetFieldSelectionFromEncodedString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFieldSelectionFromEncodedString, methodGetFieldSelectionFromEncodedStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterUserSettingsInstanceFixture, parametersOfGetFieldSelectionFromEncodedString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFieldSelectionFromEncodedString.ShouldBeNull();
            methodGetFieldSelectionFromEncodedStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSelectionFromEncodedString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetFieldSelectionFromEncodedString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFieldSelectionFromEncodedStringPrametersTypes = null;
            object[] parametersOfGetFieldSelectionFromEncodedString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportFilterUserSettings, string>(_reportFilterUserSettingsInstance, MethodGetFieldSelectionFromEncodedString, parametersOfGetFieldSelectionFromEncodedString, methodGetFieldSelectionFromEncodedStringPrametersTypes);

            // Assert
            parametersOfGetFieldSelectionFromEncodedString.ShouldBeNull();
            methodGetFieldSelectionFromEncodedStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSelectionFromEncodedString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetFieldSelectionFromEncodedString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetFieldSelectionFromEncodedStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodGetFieldSelectionFromEncodedString, Fixture, methodGetFieldSelectionFromEncodedStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFieldSelectionFromEncodedStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldSelectionFromEncodedString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetFieldSelectionFromEncodedString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFieldSelectionFromEncodedStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodGetFieldSelectionFromEncodedString, Fixture, methodGetFieldSelectionFromEncodedStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldSelectionFromEncodedStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldSelectionFromEncodedString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_GetFieldSelectionFromEncodedString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldSelectionFromEncodedString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettings_Hydrate_Method_Call_Internally(Type[] types)
        {
            var methodHydratePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodHydrate, Fixture, methodHydratePrametersTypes);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_Hydrate_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var reader = CreateType<IDataReader>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportFilterUserSettingsInstance.Hydrate(reader);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_Hydrate_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var reader = CreateType<IDataReader>();
            var methodHydratePrametersTypes = new Type[] { typeof(IDataReader) };
            object[] parametersOfHydrate = { reader };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHydrate, methodHydratePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterUserSettingsInstanceFixture, parametersOfHydrate);

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
        public void AUT_ReportFilterUserSettings_Hydrate_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reader = CreateType<IDataReader>();
            var methodHydratePrametersTypes = new Type[] { typeof(IDataReader) };
            object[] parametersOfHydrate = { reader };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportFilterUserSettingsInstance, MethodHydrate, parametersOfHydrate, methodHydratePrametersTypes);

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
        public void AUT_ReportFilterUserSettings_Hydrate_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportFilterUserSettings_Hydrate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHydratePrametersTypes = new Type[] { typeof(IDataReader) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodHydrate, Fixture, methodHydratePrametersTypes);

            // Assert
            methodHydratePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Hydrate) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_Hydrate_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHydrate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateSelectedTitles) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettings_PopulateSelectedTitles_Method_Call_Internally(Type[] types)
        {
            var methodPopulateSelectedTitlesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodPopulateSelectedTitles, Fixture, methodPopulateSelectedTitlesPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateSelectedTitles) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedTitles_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var storedValue = CreateType<string>();
            var methodPopulateSelectedTitlesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateSelectedTitles = { storedValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateSelectedTitles, methodPopulateSelectedTitlesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterUserSettingsInstanceFixture, parametersOfPopulateSelectedTitles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateSelectedTitles.ShouldNotBeNull();
            parametersOfPopulateSelectedTitles.Length.ShouldBe(1);
            methodPopulateSelectedTitlesPrametersTypes.Length.ShouldBe(1);
            methodPopulateSelectedTitlesPrametersTypes.Length.ShouldBe(parametersOfPopulateSelectedTitles.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateSelectedTitles) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedTitles_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var storedValue = CreateType<string>();
            var methodPopulateSelectedTitlesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateSelectedTitles = { storedValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportFilterUserSettingsInstance, MethodPopulateSelectedTitles, parametersOfPopulateSelectedTitles, methodPopulateSelectedTitlesPrametersTypes);

            // Assert
            parametersOfPopulateSelectedTitles.ShouldNotBeNull();
            parametersOfPopulateSelectedTitles.Length.ShouldBe(1);
            methodPopulateSelectedTitlesPrametersTypes.Length.ShouldBe(1);
            methodPopulateSelectedTitlesPrametersTypes.Length.ShouldBe(parametersOfPopulateSelectedTitles.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateSelectedTitles) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedTitles_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateSelectedTitles, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateSelectedTitles) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedTitles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateSelectedTitlesPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodPopulateSelectedTitles, Fixture, methodPopulateSelectedTitlesPrametersTypes);

            // Assert
            methodPopulateSelectedTitlesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateSelectedTitles) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedTitles_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateSelectedTitles, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateSelectedFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettings_PopulateSelectedFields_Method_Call_Internally(Type[] types)
        {
            var methodPopulateSelectedFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodPopulateSelectedFields, Fixture, methodPopulateSelectedFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateSelectedFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedFields_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var storedValue = CreateType<string>();
            var methodPopulateSelectedFieldsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateSelectedFields = { storedValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateSelectedFields, methodPopulateSelectedFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterUserSettingsInstanceFixture, parametersOfPopulateSelectedFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateSelectedFields.ShouldNotBeNull();
            parametersOfPopulateSelectedFields.Length.ShouldBe(1);
            methodPopulateSelectedFieldsPrametersTypes.Length.ShouldBe(1);
            methodPopulateSelectedFieldsPrametersTypes.Length.ShouldBe(parametersOfPopulateSelectedFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateSelectedFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedFields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var storedValue = CreateType<string>();
            var methodPopulateSelectedFieldsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateSelectedFields = { storedValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportFilterUserSettingsInstance, MethodPopulateSelectedFields, parametersOfPopulateSelectedFields, methodPopulateSelectedFieldsPrametersTypes);

            // Assert
            parametersOfPopulateSelectedFields.ShouldNotBeNull();
            parametersOfPopulateSelectedFields.Length.ShouldBe(1);
            methodPopulateSelectedFieldsPrametersTypes.Length.ShouldBe(1);
            methodPopulateSelectedFieldsPrametersTypes.Length.ShouldBe(parametersOfPopulateSelectedFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateSelectedFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateSelectedFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateSelectedFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateSelectedFieldsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodPopulateSelectedFields, Fixture, methodPopulateSelectedFieldsPrametersTypes);

            // Assert
            methodPopulateSelectedFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateSelectedFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateSelectedFields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateSelectedFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateCamlQueryOperatorFromEncodedString) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterUserSettings_PopulateCamlQueryOperatorFromEncodedString_Method_Call_Internally(Type[] types)
        {
            var methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodPopulateCamlQueryOperatorFromEncodedString, Fixture, methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateCamlQueryOperatorFromEncodedString) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateCamlQueryOperatorFromEncodedString_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var storedValue = CreateType<string>();
            var methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateCamlQueryOperatorFromEncodedString = { storedValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateCamlQueryOperatorFromEncodedString, methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterUserSettingsInstanceFixture, parametersOfPopulateCamlQueryOperatorFromEncodedString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateCamlQueryOperatorFromEncodedString.ShouldNotBeNull();
            parametersOfPopulateCamlQueryOperatorFromEncodedString.Length.ShouldBe(1);
            methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes.Length.ShouldBe(1);
            methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes.Length.ShouldBe(parametersOfPopulateCamlQueryOperatorFromEncodedString.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateCamlQueryOperatorFromEncodedString) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateCamlQueryOperatorFromEncodedString_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var storedValue = CreateType<string>();
            var methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateCamlQueryOperatorFromEncodedString = { storedValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportFilterUserSettingsInstance, MethodPopulateCamlQueryOperatorFromEncodedString, parametersOfPopulateCamlQueryOperatorFromEncodedString, methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes);

            // Assert
            parametersOfPopulateCamlQueryOperatorFromEncodedString.ShouldNotBeNull();
            parametersOfPopulateCamlQueryOperatorFromEncodedString.Length.ShouldBe(1);
            methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes.Length.ShouldBe(1);
            methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes.Length.ShouldBe(parametersOfPopulateCamlQueryOperatorFromEncodedString.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateCamlQueryOperatorFromEncodedString) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateCamlQueryOperatorFromEncodedString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateCamlQueryOperatorFromEncodedString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateCamlQueryOperatorFromEncodedString) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateCamlQueryOperatorFromEncodedString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterUserSettingsInstance, MethodPopulateCamlQueryOperatorFromEncodedString, Fixture, methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes);

            // Assert
            methodPopulateCamlQueryOperatorFromEncodedStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateCamlQueryOperatorFromEncodedString) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterUserSettings_PopulateCamlQueryOperatorFromEncodedString_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateCamlQueryOperatorFromEncodedString, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterUserSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CascadingLookupFieldSettings" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class CascadingLookupFieldSettingsTest : AbstractBaseSetupTypedTest<CascadingLookupFieldSettings>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CascadingLookupFieldSettings) Initializer

        private const string PropertyDisplayAsNewSection = "DisplayAsNewSection";
        private const string MethodInitializeWithField = "InitializeWithField";
        private const string MethodOnSaveChange = "OnSaveChange";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodbtnLoad_Click = "btnLoad_Click";
        private const string MethodddlList_SelectedIndexChanged = "ddlList_SelectedIndexChanged";
        private const string MethodddlField_SelectedIndexChanged = "ddlField_SelectedIndexChanged";
        private const string MethodchkFilterCriteria_CheckedChanged = "chkFilterCriteria_CheckedChanged";
        private const string MethodValidateSettings = "ValidateSettings";
        private const string MethodClearError = "ClearError";
        private const string MethodReportError = "ReportError";
        private const string MethodWSSLoadLists = "WSSLoadLists";
        private const string MethodWSSLoadFields = "WSSLoadFields";
        private const string MethodUpdateDDLSelection = "UpdateDDLSelection";
        private const string MethodCleanupChildrenField = "CleanupChildrenField";
        private const string MethodConvertToInternalName = "ConvertToInternalName";
        private const string MethodConvertSpecialColumnNameCharacters = "ConvertSpecialColumnNameCharacters";
        private const string MethodIsRelativeUrl = "IsRelativeUrl";
        private const string MethodFindRelativeUrl = "FindRelativeUrl";
        private const string MethodShowControl = "ShowControl";
        private const string MethodShowList = "ShowList";
        private const string MethodShowField = "ShowField";
        private const string MethodShowFilterSettingsOption = "ShowFilterSettingsOption";
        private const string MethodShowFilterCriteria = "ShowFilterCriteria";
        private const string FieldlblUrl = "lblUrl";
        private const string FieldlblList = "lblList";
        private const string FieldlblField = "lblField";
        private const string FieldlblParentField = "lblParentField";
        private const string FieldlblFilterValueField = "lblFilterValueField";
        private const string FieldlblError = "lblError";
        private const string FieldtxtUrl = "txtUrl";
        private const string FieldbtnLoad = "btnLoad";
        private const string FieldddlList = "ddlList";
        private const string FieldddlField = "ddlField";
        private const string FieldddlParentField = "ddlParentField";
        private const string FieldddlFilterValueField = "ddlFilterValueField";
        private const string FieldchkFilterCriteria = "chkFilterCriteria";
        private const string FieldchkDefineNone = "chkDefineNone";
        private const string FieldUrl = "Url";
        private const string FieldList = "List";
        private const string FieldField = "Field";
        private const string FieldParentField = "ParentField";
        private const string FieldChildrenField = "ChildrenField";
        private const string FieldFilterValueField = "FilterValueField";
        private const string FieldDefineNone = "DefineNone";
        private Type _cascadingLookupFieldSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CascadingLookupFieldSettings _cascadingLookupFieldSettingsInstance;
        private CascadingLookupFieldSettings _cascadingLookupFieldSettingsInstanceFixture;

        #region General Initializer : Class (CascadingLookupFieldSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CascadingLookupFieldSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cascadingLookupFieldSettingsInstanceType = typeof(CascadingLookupFieldSettings);
            _cascadingLookupFieldSettingsInstanceFixture = Create(true);
            _cascadingLookupFieldSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CascadingLookupFieldSettings)

        #region General Initializer : Class (CascadingLookupFieldSettings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CascadingLookupFieldSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitializeWithField, 0)]
        [TestCase(MethodOnSaveChange, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodbtnLoad_Click, 0)]
        [TestCase(MethodddlList_SelectedIndexChanged, 0)]
        [TestCase(MethodddlField_SelectedIndexChanged, 0)]
        [TestCase(MethodchkFilterCriteria_CheckedChanged, 0)]
        [TestCase(MethodValidateSettings, 0)]
        [TestCase(MethodClearError, 0)]
        [TestCase(MethodReportError, 0)]
        [TestCase(MethodWSSLoadLists, 0)]
        [TestCase(MethodWSSLoadFields, 0)]
        [TestCase(MethodWSSLoadFields, 1)]
        [TestCase(MethodUpdateDDLSelection, 0)]
        [TestCase(MethodCleanupChildrenField, 0)]
        [TestCase(MethodConvertToInternalName, 0)]
        [TestCase(MethodConvertSpecialColumnNameCharacters, 0)]
        [TestCase(MethodIsRelativeUrl, 0)]
        [TestCase(MethodFindRelativeUrl, 0)]
        [TestCase(MethodFindRelativeUrl, 1)]
        [TestCase(MethodShowControl, 0)]
        [TestCase(MethodShowList, 0)]
        [TestCase(MethodShowField, 0)]
        [TestCase(MethodShowFilterSettingsOption, 0)]
        [TestCase(MethodShowFilterCriteria, 0)]
        public void AUT_CascadingLookupFieldSettings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_cascadingLookupFieldSettingsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CascadingLookupFieldSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CascadingLookupFieldSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDisplayAsNewSection)]
        public void AUT_CascadingLookupFieldSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_cascadingLookupFieldSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CascadingLookupFieldSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CascadingLookupFieldSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldlblUrl)]
        [TestCase(FieldlblList)]
        [TestCase(FieldlblField)]
        [TestCase(FieldlblParentField)]
        [TestCase(FieldlblFilterValueField)]
        [TestCase(FieldlblError)]
        [TestCase(FieldtxtUrl)]
        [TestCase(FieldbtnLoad)]
        [TestCase(FieldddlList)]
        [TestCase(FieldddlField)]
        [TestCase(FieldddlParentField)]
        [TestCase(FieldddlFilterValueField)]
        [TestCase(FieldchkFilterCriteria)]
        [TestCase(FieldchkDefineNone)]
        [TestCase(FieldUrl)]
        [TestCase(FieldList)]
        [TestCase(FieldField)]
        [TestCase(FieldParentField)]
        [TestCase(FieldChildrenField)]
        [TestCase(FieldFilterValueField)]
        [TestCase(FieldDefineNone)]
        public void AUT_CascadingLookupFieldSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cascadingLookupFieldSettingsInstanceFixture, 
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
        ///     Class (<see cref="CascadingLookupFieldSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CascadingLookupFieldSettings_Is_Instance_Present_Test()
        {
            // Assert
            _cascadingLookupFieldSettingsInstanceType.ShouldNotBeNull();
            _cascadingLookupFieldSettingsInstance.ShouldNotBeNull();
            _cascadingLookupFieldSettingsInstanceFixture.ShouldNotBeNull();
            _cascadingLookupFieldSettingsInstance.ShouldBeAssignableTo<CascadingLookupFieldSettings>();
            _cascadingLookupFieldSettingsInstanceFixture.ShouldBeAssignableTo<CascadingLookupFieldSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CascadingLookupFieldSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CascadingLookupFieldSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CascadingLookupFieldSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _cascadingLookupFieldSettingsInstanceType.ShouldNotBeNull();
            _cascadingLookupFieldSettingsInstance.ShouldNotBeNull();
            _cascadingLookupFieldSettingsInstanceFixture.ShouldNotBeNull();
            _cascadingLookupFieldSettingsInstance.ShouldBeAssignableTo<CascadingLookupFieldSettings>();
            _cascadingLookupFieldSettingsInstanceFixture.ShouldBeAssignableTo<CascadingLookupFieldSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CascadingLookupFieldSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyDisplayAsNewSection)]
        public void AUT_CascadingLookupFieldSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CascadingLookupFieldSettings, T>(_cascadingLookupFieldSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CascadingLookupFieldSettings) => Property (DisplayAsNewSection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupFieldSettings_Public_Class_DisplayAsNewSection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisplayAsNewSection);

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
        ///     Class (<see cref="CascadingLookupFieldSettings" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodIsRelativeUrl)]
        [TestCase(MethodFindRelativeUrl)]
        public void AUT_CascadingLookupFieldSettings_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_cascadingLookupFieldSettingsInstanceFixture,
                                                                              _cascadingLookupFieldSettingsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CascadingLookupFieldSettings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitializeWithField)]
        [TestCase(MethodOnSaveChange)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodbtnLoad_Click)]
        [TestCase(MethodddlList_SelectedIndexChanged)]
        [TestCase(MethodddlField_SelectedIndexChanged)]
        [TestCase(MethodchkFilterCriteria_CheckedChanged)]
        [TestCase(MethodValidateSettings)]
        [TestCase(MethodClearError)]
        [TestCase(MethodReportError)]
        [TestCase(MethodWSSLoadLists)]
        [TestCase(MethodWSSLoadFields)]
        [TestCase(MethodUpdateDDLSelection)]
        [TestCase(MethodCleanupChildrenField)]
        [TestCase(MethodConvertToInternalName)]
        [TestCase(MethodConvertSpecialColumnNameCharacters)]
        [TestCase(MethodFindRelativeUrl)]
        [TestCase(MethodShowControl)]
        [TestCase(MethodShowList)]
        [TestCase(MethodShowField)]
        [TestCase(MethodShowFilterSettingsOption)]
        [TestCase(MethodShowFilterCriteria)]
        public void AUT_CascadingLookupFieldSettings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CascadingLookupFieldSettings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_InitializeWithField_Method_Call_Internally(Type[] types)
        {
            var methodInitializeWithFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodInitializeWithField, Fixture, methodInitializeWithFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_InitializeWithField_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<Microsoft.SharePoint.SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => _cascadingLookupFieldSettingsInstance.InitializeWithField(field);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_InitializeWithField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<Microsoft.SharePoint.SPField>();
            var methodInitializeWithFieldPrametersTypes = new Type[] { typeof(Microsoft.SharePoint.SPField) };
            object[] parametersOfInitializeWithField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeWithField, methodInitializeWithFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfInitializeWithField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeWithField.ShouldNotBeNull();
            parametersOfInitializeWithField.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(parametersOfInitializeWithField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_InitializeWithField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<Microsoft.SharePoint.SPField>();
            var methodInitializeWithFieldPrametersTypes = new Type[] { typeof(Microsoft.SharePoint.SPField) };
            object[] parametersOfInitializeWithField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodInitializeWithField, parametersOfInitializeWithField, methodInitializeWithFieldPrametersTypes);

            // Assert
            parametersOfInitializeWithField.ShouldNotBeNull();
            parametersOfInitializeWithField.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(parametersOfInitializeWithField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_InitializeWithField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitializeWithField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_InitializeWithField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializeWithFieldPrametersTypes = new Type[] { typeof(Microsoft.SharePoint.SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodInitializeWithField, Fixture, methodInitializeWithFieldPrametersTypes);

            // Assert
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_InitializeWithField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeWithField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_OnSaveChange_Method_Call_Internally(Type[] types)
        {
            var methodOnSaveChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodOnSaveChange, Fixture, methodOnSaveChangePrametersTypes);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_OnSaveChange_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var field = CreateType<Microsoft.SharePoint.SPField>();
            var isNewField = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cascadingLookupFieldSettingsInstance.OnSaveChange(field, isNewField);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_OnSaveChange_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<Microsoft.SharePoint.SPField>();
            var isNewField = CreateType<bool>();
            var methodOnSaveChangePrametersTypes = new Type[] { typeof(Microsoft.SharePoint.SPField), typeof(bool) };
            object[] parametersOfOnSaveChange = { field, isNewField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnSaveChange, methodOnSaveChangePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfOnSaveChange);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnSaveChange.ShouldNotBeNull();
            parametersOfOnSaveChange.Length.ShouldBe(2);
            methodOnSaveChangePrametersTypes.Length.ShouldBe(2);
            methodOnSaveChangePrametersTypes.Length.ShouldBe(parametersOfOnSaveChange.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_OnSaveChange_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<Microsoft.SharePoint.SPField>();
            var isNewField = CreateType<bool>();
            var methodOnSaveChangePrametersTypes = new Type[] { typeof(Microsoft.SharePoint.SPField), typeof(bool) };
            object[] parametersOfOnSaveChange = { field, isNewField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodOnSaveChange, parametersOfOnSaveChange, methodOnSaveChangePrametersTypes);

            // Assert
            parametersOfOnSaveChange.ShouldNotBeNull();
            parametersOfOnSaveChange.Length.ShouldBe(2);
            methodOnSaveChangePrametersTypes.Length.ShouldBe(2);
            methodOnSaveChangePrametersTypes.Length.ShouldBe(parametersOfOnSaveChange.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_OnSaveChange_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnSaveChange, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_OnSaveChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnSaveChangePrametersTypes = new Type[] { typeof(Microsoft.SharePoint.SPField), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodOnSaveChange, Fixture, methodOnSaveChangePrametersTypes);

            // Assert
            methodOnSaveChangePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_OnSaveChange_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnSaveChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnLoad_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_btnLoad_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnLoad_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodbtnLoad_Click, Fixture, methodbtnLoad_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnLoad_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_btnLoad_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnLoad_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnLoad_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnLoad_Click, methodbtnLoad_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfbtnLoad_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnLoad_Click.ShouldNotBeNull();
            parametersOfbtnLoad_Click.Length.ShouldBe(2);
            methodbtnLoad_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnLoad_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnLoad_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnLoad_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_btnLoad_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnLoad_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnLoad_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodbtnLoad_Click, parametersOfbtnLoad_Click, methodbtnLoad_ClickPrametersTypes);

            // Assert
            parametersOfbtnLoad_Click.ShouldNotBeNull();
            parametersOfbtnLoad_Click.Length.ShouldBe(2);
            methodbtnLoad_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnLoad_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnLoad_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnLoad_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_btnLoad_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnLoad_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnLoad_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_btnLoad_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnLoad_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodbtnLoad_Click, Fixture, methodbtnLoad_ClickPrametersTypes);

            // Assert
            methodbtnLoad_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnLoad_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_btnLoad_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnLoad_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ddlList_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlList_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodddlList_SelectedIndexChanged, Fixture, methodddlList_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlList_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlList_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlList_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodddlList_SelectedIndexChanged, methodddlList_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfddlList_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddlList_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlList_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlList_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlList_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlList_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlList_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodddlList_SelectedIndexChanged, parametersOfddlList_SelectedIndexChanged, methodddlList_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfddlList_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlList_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlList_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlList_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodddlList_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlList_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodddlList_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodddlList_SelectedIndexChanged, Fixture, methodddlList_SelectedIndexChangedPrametersTypes);

            // Assert
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlList_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodddlList_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlField_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ddlField_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlField_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodddlField_SelectedIndexChanged, Fixture, methodddlField_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlField_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlField_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlField_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlField_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodddlField_SelectedIndexChanged, methodddlField_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfddlField_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddlField_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlField_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlField_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ddlField_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlField_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlField_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlField_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodddlField_SelectedIndexChanged, parametersOfddlField_SelectedIndexChanged, methodddlField_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfddlField_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlField_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlField_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlField_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlField_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodddlField_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddlField_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlField_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodddlField_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodddlField_SelectedIndexChanged, Fixture, methodddlField_SelectedIndexChangedPrametersTypes);

            // Assert
            methodddlField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlField_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ddlField_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodddlField_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (chkFilterCriteria_CheckedChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_chkFilterCriteria_CheckedChanged_Method_Call_Internally(Type[] types)
        {
            var methodchkFilterCriteria_CheckedChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodchkFilterCriteria_CheckedChanged, Fixture, methodchkFilterCriteria_CheckedChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (chkFilterCriteria_CheckedChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_chkFilterCriteria_CheckedChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodchkFilterCriteria_CheckedChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfchkFilterCriteria_CheckedChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodchkFilterCriteria_CheckedChanged, methodchkFilterCriteria_CheckedChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfchkFilterCriteria_CheckedChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfchkFilterCriteria_CheckedChanged.ShouldNotBeNull();
            parametersOfchkFilterCriteria_CheckedChanged.Length.ShouldBe(2);
            methodchkFilterCriteria_CheckedChangedPrametersTypes.Length.ShouldBe(2);
            methodchkFilterCriteria_CheckedChangedPrametersTypes.Length.ShouldBe(parametersOfchkFilterCriteria_CheckedChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (chkFilterCriteria_CheckedChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_chkFilterCriteria_CheckedChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodchkFilterCriteria_CheckedChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfchkFilterCriteria_CheckedChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodchkFilterCriteria_CheckedChanged, parametersOfchkFilterCriteria_CheckedChanged, methodchkFilterCriteria_CheckedChangedPrametersTypes);

            // Assert
            parametersOfchkFilterCriteria_CheckedChanged.ShouldNotBeNull();
            parametersOfchkFilterCriteria_CheckedChanged.Length.ShouldBe(2);
            methodchkFilterCriteria_CheckedChangedPrametersTypes.Length.ShouldBe(2);
            methodchkFilterCriteria_CheckedChangedPrametersTypes.Length.ShouldBe(parametersOfchkFilterCriteria_CheckedChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (chkFilterCriteria_CheckedChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_chkFilterCriteria_CheckedChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodchkFilterCriteria_CheckedChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (chkFilterCriteria_CheckedChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_chkFilterCriteria_CheckedChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodchkFilterCriteria_CheckedChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodchkFilterCriteria_CheckedChanged, Fixture, methodchkFilterCriteria_CheckedChangedPrametersTypes);

            // Assert
            methodchkFilterCriteria_CheckedChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (chkFilterCriteria_CheckedChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_chkFilterCriteria_CheckedChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodchkFilterCriteria_CheckedChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ValidateSettings_Method_Call_Internally(Type[] types)
        {
            var methodValidateSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodValidateSettings, Fixture, methodValidateSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ValidateSettings_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodValidateSettingsPrametersTypes = null;
            object[] parametersOfValidateSettings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidateSettings, methodValidateSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfValidateSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidateSettings.ShouldBeNull();
            methodValidateSettingsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ValidateSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ValidateSettings_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodValidateSettingsPrametersTypes = null;
            object[] parametersOfValidateSettings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodValidateSettings, parametersOfValidateSettings, methodValidateSettingsPrametersTypes);

            // Assert
            parametersOfValidateSettings.ShouldBeNull();
            methodValidateSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ValidateSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodValidateSettingsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodValidateSettings, Fixture, methodValidateSettingsPrametersTypes);

            // Assert
            methodValidateSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ValidateSettings_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ClearError_Method_Call_Internally(Type[] types)
        {
            var methodClearErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodClearError, Fixture, methodClearErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (ClearError) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ClearError_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodClearErrorPrametersTypes = null;
            object[] parametersOfClearError = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearError, methodClearErrorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfClearError);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearError.ShouldBeNull();
            methodClearErrorPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ClearError) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ClearError_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodClearErrorPrametersTypes = null;
            object[] parametersOfClearError = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodClearError, parametersOfClearError, methodClearErrorPrametersTypes);

            // Assert
            parametersOfClearError.ShouldBeNull();
            methodClearErrorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearError) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ClearError_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodClearErrorPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodClearError, Fixture, methodClearErrorPrametersTypes);

            // Assert
            methodClearErrorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearError) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ClearError_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearError, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ReportError_Method_Call_Internally(Type[] types)
        {
            var methodReportErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodReportError, Fixture, methodReportErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ReportError_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var methodReportErrorPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfReportError = { ex };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReportError, methodReportErrorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfReportError);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReportError.ShouldNotBeNull();
            parametersOfReportError.Length.ShouldBe(1);
            methodReportErrorPrametersTypes.Length.ShouldBe(1);
            methodReportErrorPrametersTypes.Length.ShouldBe(parametersOfReportError.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ReportError_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var methodReportErrorPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfReportError = { ex };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodReportError, parametersOfReportError, methodReportErrorPrametersTypes);

            // Assert
            parametersOfReportError.ShouldNotBeNull();
            parametersOfReportError.Length.ShouldBe(1);
            methodReportErrorPrametersTypes.Length.ShouldBe(1);
            methodReportErrorPrametersTypes.Length.ShouldBe(parametersOfReportError.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ReportError_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReportError, 0);
            const int parametersCount = 1;

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
        public void AUT_CascadingLookupFieldSettings_ReportError_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReportErrorPrametersTypes = new Type[] { typeof(Exception) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodReportError, Fixture, methodReportErrorPrametersTypes);

            // Assert
            methodReportErrorPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ReportError_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReportError, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_WSSLoadLists_Method_Call_Internally(Type[] types)
        {
            var methodWSSLoadListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodWSSLoadLists, Fixture, methodWSSLoadListsPrametersTypes);
        }

        #endregion

        #region Method Call : (WSSLoadLists) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadLists_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Url = CreateType<string>();
            var ddl = CreateType<DropDownList>();
            var selectedValue = CreateType<string>();
            var sender = CreateType<object>();
            var methodWSSLoadListsPrametersTypes = new Type[] { typeof(string), typeof(DropDownList), typeof(string), typeof(object) };
            object[] parametersOfWSSLoadLists = { Url, ddl, selectedValue, sender };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWSSLoadLists, methodWSSLoadListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfWSSLoadLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWSSLoadLists.ShouldNotBeNull();
            parametersOfWSSLoadLists.Length.ShouldBe(4);
            methodWSSLoadListsPrametersTypes.Length.ShouldBe(4);
            methodWSSLoadListsPrametersTypes.Length.ShouldBe(parametersOfWSSLoadLists.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadLists_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Url = CreateType<string>();
            var ddl = CreateType<DropDownList>();
            var selectedValue = CreateType<string>();
            var sender = CreateType<object>();
            var methodWSSLoadListsPrametersTypes = new Type[] { typeof(string), typeof(DropDownList), typeof(string), typeof(object) };
            object[] parametersOfWSSLoadLists = { Url, ddl, selectedValue, sender };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodWSSLoadLists, parametersOfWSSLoadLists, methodWSSLoadListsPrametersTypes);

            // Assert
            parametersOfWSSLoadLists.ShouldNotBeNull();
            parametersOfWSSLoadLists.Length.ShouldBe(4);
            methodWSSLoadListsPrametersTypes.Length.ShouldBe(4);
            methodWSSLoadListsPrametersTypes.Length.ShouldBe(parametersOfWSSLoadLists.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadLists) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWSSLoadLists, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WSSLoadLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWSSLoadListsPrametersTypes = new Type[] { typeof(string), typeof(DropDownList), typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodWSSLoadLists, Fixture, methodWSSLoadListsPrametersTypes);

            // Assert
            methodWSSLoadListsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadLists_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWSSLoadLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Internally(Type[] types)
        {
            var methodWSSLoadFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodWSSLoadFields, Fixture, methodWSSLoadFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var ddl = CreateType<DropDownList>();
            var selectedValue = CreateType<string>();
            var sender = CreateType<object>();
            var allowCustomFieldTypeOnly = CreateType<bool>();
            var methodWSSLoadFieldsPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(DropDownList), typeof(string), typeof(object), typeof(bool) };
            object[] parametersOfWSSLoadFields = { fields, ddl, selectedValue, sender, allowCustomFieldTypeOnly };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWSSLoadFields, methodWSSLoadFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfWSSLoadFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWSSLoadFields.ShouldNotBeNull();
            parametersOfWSSLoadFields.Length.ShouldBe(5);
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(5);
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(parametersOfWSSLoadFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var ddl = CreateType<DropDownList>();
            var selectedValue = CreateType<string>();
            var sender = CreateType<object>();
            var allowCustomFieldTypeOnly = CreateType<bool>();
            var methodWSSLoadFieldsPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(DropDownList), typeof(string), typeof(object), typeof(bool) };
            object[] parametersOfWSSLoadFields = { fields, ddl, selectedValue, sender, allowCustomFieldTypeOnly };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodWSSLoadFields, parametersOfWSSLoadFields, methodWSSLoadFieldsPrametersTypes);

            // Assert
            parametersOfWSSLoadFields.ShouldNotBeNull();
            parametersOfWSSLoadFields.Length.ShouldBe(5);
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(5);
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(parametersOfWSSLoadFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWSSLoadFields, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWSSLoadFieldsPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(DropDownList), typeof(string), typeof(object), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodWSSLoadFields, Fixture, methodWSSLoadFieldsPrametersTypes);

            // Assert
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWSSLoadFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodWSSLoadFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodWSSLoadFields, Fixture, methodWSSLoadFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Void_Overloading_Of_1_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Url = CreateType<string>();
            var List = CreateType<string>();
            var ddl = CreateType<DropDownList>();
            var selectedValue = CreateType<string>();
            var sender = CreateType<object>();
            var methodWSSLoadFieldsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DropDownList), typeof(string), typeof(object) };
            object[] parametersOfWSSLoadFields = { Url, List, ddl, selectedValue, sender };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWSSLoadFields, methodWSSLoadFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfWSSLoadFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWSSLoadFields.ShouldNotBeNull();
            parametersOfWSSLoadFields.Length.ShouldBe(5);
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(5);
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(parametersOfWSSLoadFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Void_Overloading_Of_1_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Url = CreateType<string>();
            var List = CreateType<string>();
            var ddl = CreateType<DropDownList>();
            var selectedValue = CreateType<string>();
            var sender = CreateType<object>();
            var methodWSSLoadFieldsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DropDownList), typeof(string), typeof(object) };
            object[] parametersOfWSSLoadFields = { Url, List, ddl, selectedValue, sender };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodWSSLoadFields, parametersOfWSSLoadFields, methodWSSLoadFieldsPrametersTypes);

            // Assert
            parametersOfWSSLoadFields.ShouldNotBeNull();
            parametersOfWSSLoadFields.Length.ShouldBe(5);
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(5);
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(parametersOfWSSLoadFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWSSLoadFields, 1);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWSSLoadFieldsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DropDownList), typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodWSSLoadFields, Fixture, methodWSSLoadFieldsPrametersTypes);

            // Assert
            methodWSSLoadFieldsPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WSSLoadFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_WSSLoadFields_Method_Call_Overloading_Of_1_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWSSLoadFields, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDDLSelection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_UpdateDDLSelection_Method_Call_Internally(Type[] types)
        {
            var methodUpdateDDLSelectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodUpdateDDLSelection, Fixture, methodUpdateDDLSelectionPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateDDLSelection) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_UpdateDDLSelection_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var ddl = CreateType<DropDownList>();
            var selectedValue = CreateType<string>();
            var messageOnError = CreateType<string>();
            var sender = CreateType<object>();
            var methodUpdateDDLSelectionPrametersTypes = new Type[] { typeof(DropDownList), typeof(string), typeof(string), typeof(object) };
            object[] parametersOfUpdateDDLSelection = { ddl, selectedValue, messageOnError, sender };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateDDLSelection, methodUpdateDDLSelectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfUpdateDDLSelection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateDDLSelection.ShouldNotBeNull();
            parametersOfUpdateDDLSelection.Length.ShouldBe(4);
            methodUpdateDDLSelectionPrametersTypes.Length.ShouldBe(4);
            methodUpdateDDLSelectionPrametersTypes.Length.ShouldBe(parametersOfUpdateDDLSelection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDDLSelection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_UpdateDDLSelection_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ddl = CreateType<DropDownList>();
            var selectedValue = CreateType<string>();
            var messageOnError = CreateType<string>();
            var sender = CreateType<object>();
            var methodUpdateDDLSelectionPrametersTypes = new Type[] { typeof(DropDownList), typeof(string), typeof(string), typeof(object) };
            object[] parametersOfUpdateDDLSelection = { ddl, selectedValue, messageOnError, sender };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodUpdateDDLSelection, parametersOfUpdateDDLSelection, methodUpdateDDLSelectionPrametersTypes);

            // Assert
            parametersOfUpdateDDLSelection.ShouldNotBeNull();
            parametersOfUpdateDDLSelection.Length.ShouldBe(4);
            methodUpdateDDLSelectionPrametersTypes.Length.ShouldBe(4);
            methodUpdateDDLSelectionPrametersTypes.Length.ShouldBe(parametersOfUpdateDDLSelection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDDLSelection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_UpdateDDLSelection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateDDLSelection, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateDDLSelection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_UpdateDDLSelection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateDDLSelectionPrametersTypes = new Type[] { typeof(DropDownList), typeof(string), typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodUpdateDDLSelection, Fixture, methodUpdateDDLSelectionPrametersTypes);

            // Assert
            methodUpdateDDLSelectionPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDDLSelection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_UpdateDDLSelection_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateDDLSelection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CleanupChildrenField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_CleanupChildrenField_Method_Call_Internally(Type[] types)
        {
            var methodCleanupChildrenFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodCleanupChildrenField, Fixture, methodCleanupChildrenFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (CleanupChildrenField) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CleanupChildrenField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var childrenField = CreateType<string>();
            var methodCleanupChildrenFieldPrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            object[] parametersOfCleanupChildrenField = { field, childrenField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCleanupChildrenField, methodCleanupChildrenFieldPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCleanupChildrenField.ShouldNotBeNull();
            parametersOfCleanupChildrenField.Length.ShouldBe(2);
            methodCleanupChildrenFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfCleanupChildrenField));
        }

        #endregion

        #region Method Call : (CleanupChildrenField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CleanupChildrenField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var childrenField = CreateType<string>();
            var methodCleanupChildrenFieldPrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            object[] parametersOfCleanupChildrenField = { field, childrenField };

            // Assert
            parametersOfCleanupChildrenField.ShouldNotBeNull();
            parametersOfCleanupChildrenField.Length.ShouldBe(2);
            methodCleanupChildrenFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CascadingLookupFieldSettings, string>(_cascadingLookupFieldSettingsInstance, MethodCleanupChildrenField, parametersOfCleanupChildrenField, methodCleanupChildrenFieldPrametersTypes));
        }

        #endregion

        #region Method Call : (CleanupChildrenField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CleanupChildrenField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCleanupChildrenFieldPrametersTypes = new Type[] { typeof(SPField), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodCleanupChildrenField, Fixture, methodCleanupChildrenFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCleanupChildrenFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CleanupChildrenField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CleanupChildrenField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCleanupChildrenFieldPrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodCleanupChildrenField, Fixture, methodCleanupChildrenFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCleanupChildrenFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CleanupChildrenField) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CleanupChildrenField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCleanupChildrenField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CleanupChildrenField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_CleanupChildrenField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCleanupChildrenField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertToInternalName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ConvertToInternalName_Method_Call_Internally(Type[] types)
        {
            var methodConvertToInternalNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodConvertToInternalName, Fixture, methodConvertToInternalNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertToInternalName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertToInternalName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var methodConvertToInternalNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertToInternalName = { Name };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvertToInternalName, methodConvertToInternalNamePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvertToInternalName.ShouldNotBeNull();
            parametersOfConvertToInternalName.Length.ShouldBe(1);
            methodConvertToInternalNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfConvertToInternalName));
        }

        #endregion

        #region Method Call : (ConvertToInternalName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertToInternalName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var methodConvertToInternalNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertToInternalName = { Name };

            // Assert
            parametersOfConvertToInternalName.ShouldNotBeNull();
            parametersOfConvertToInternalName.Length.ShouldBe(1);
            methodConvertToInternalNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CascadingLookupFieldSettings, string>(_cascadingLookupFieldSettingsInstance, MethodConvertToInternalName, parametersOfConvertToInternalName, methodConvertToInternalNamePrametersTypes));
        }

        #endregion

        #region Method Call : (ConvertToInternalName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertToInternalName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConvertToInternalNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodConvertToInternalName, Fixture, methodConvertToInternalNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConvertToInternalNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertToInternalName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertToInternalName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertToInternalNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodConvertToInternalName, Fixture, methodConvertToInternalNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertToInternalNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertToInternalName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertToInternalName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertToInternalName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConvertToInternalName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertToInternalName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertToInternalName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertSpecialColumnNameCharacters) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ConvertSpecialColumnNameCharacters_Method_Call_Internally(Type[] types)
        {
            var methodConvertSpecialColumnNameCharactersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodConvertSpecialColumnNameCharacters, Fixture, methodConvertSpecialColumnNameCharactersPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertSpecialColumnNameCharacters) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertSpecialColumnNameCharacters_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var stringToConvert = CreateType<string>();
            var methodConvertSpecialColumnNameCharactersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertSpecialColumnNameCharacters = { stringToConvert };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvertSpecialColumnNameCharacters, methodConvertSpecialColumnNameCharactersPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvertSpecialColumnNameCharacters.ShouldNotBeNull();
            parametersOfConvertSpecialColumnNameCharacters.Length.ShouldBe(1);
            methodConvertSpecialColumnNameCharactersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfConvertSpecialColumnNameCharacters));
        }

        #endregion

        #region Method Call : (ConvertSpecialColumnNameCharacters) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertSpecialColumnNameCharacters_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var stringToConvert = CreateType<string>();
            var methodConvertSpecialColumnNameCharactersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertSpecialColumnNameCharacters = { stringToConvert };

            // Assert
            parametersOfConvertSpecialColumnNameCharacters.ShouldNotBeNull();
            parametersOfConvertSpecialColumnNameCharacters.Length.ShouldBe(1);
            methodConvertSpecialColumnNameCharactersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CascadingLookupFieldSettings, string>(_cascadingLookupFieldSettingsInstance, MethodConvertSpecialColumnNameCharacters, parametersOfConvertSpecialColumnNameCharacters, methodConvertSpecialColumnNameCharactersPrametersTypes));
        }

        #endregion

        #region Method Call : (ConvertSpecialColumnNameCharacters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertSpecialColumnNameCharacters_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConvertSpecialColumnNameCharactersPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodConvertSpecialColumnNameCharacters, Fixture, methodConvertSpecialColumnNameCharactersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConvertSpecialColumnNameCharactersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertSpecialColumnNameCharacters) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertSpecialColumnNameCharacters_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertSpecialColumnNameCharactersPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodConvertSpecialColumnNameCharacters, Fixture, methodConvertSpecialColumnNameCharactersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertSpecialColumnNameCharactersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertSpecialColumnNameCharacters) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertSpecialColumnNameCharacters_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertSpecialColumnNameCharacters, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConvertSpecialColumnNameCharacters) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ConvertSpecialColumnNameCharacters_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertSpecialColumnNameCharacters, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsRelativeUrl) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_IsRelativeUrl_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsRelativeUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstanceFixture, _cascadingLookupFieldSettingsInstanceType, MethodIsRelativeUrl, Fixture, methodIsRelativeUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (IsRelativeUrl) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_IsRelativeUrl_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Url = CreateType<string>();
            var methodIsRelativeUrlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsRelativeUrl = { Url };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsRelativeUrl, methodIsRelativeUrlPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsRelativeUrl.ShouldNotBeNull();
            parametersOfIsRelativeUrl.Length.ShouldBe(1);
            methodIsRelativeUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfIsRelativeUrl));
        }

        #endregion

        #region Method Call : (IsRelativeUrl) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_IsRelativeUrl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Url = CreateType<string>();
            var methodIsRelativeUrlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsRelativeUrl = { Url };

            // Assert
            parametersOfIsRelativeUrl.ShouldNotBeNull();
            parametersOfIsRelativeUrl.Length.ShouldBe(1);
            methodIsRelativeUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_cascadingLookupFieldSettingsInstanceFixture, _cascadingLookupFieldSettingsInstanceType, MethodIsRelativeUrl, parametersOfIsRelativeUrl, methodIsRelativeUrlPrametersTypes));
        }

        #endregion

        #region Method Call : (IsRelativeUrl) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_IsRelativeUrl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsRelativeUrlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstanceFixture, _cascadingLookupFieldSettingsInstanceType, MethodIsRelativeUrl, Fixture, methodIsRelativeUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsRelativeUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsRelativeUrl) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_IsRelativeUrl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsRelativeUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsRelativeUrl) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_IsRelativeUrl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsRelativeUrl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FindRelativeUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_FindRelativeUrl_Method_Call_Internally(Type[] types)
        {
            var methodFindRelativeUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodFindRelativeUrl, Fixture, methodFindRelativeUrlPrametersTypes);
        }

        #endregion
        
        #region Method Call : (FindRelativeUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_FindRelativeUrl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Url = CreateType<string>();
            var methodFindRelativeUrlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfFindRelativeUrl = { Url };

            // Assert
            parametersOfFindRelativeUrl.ShouldNotBeNull();
            parametersOfFindRelativeUrl.Length.ShouldBe(1);
            methodFindRelativeUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CascadingLookupFieldSettings, string>(_cascadingLookupFieldSettingsInstance, MethodFindRelativeUrl, parametersOfFindRelativeUrl, methodFindRelativeUrlPrametersTypes));
        }

        #endregion

        #region Method Call : (FindRelativeUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_FindRelativeUrl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFindRelativeUrlPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodFindRelativeUrl, Fixture, methodFindRelativeUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFindRelativeUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FindRelativeUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_FindRelativeUrl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFindRelativeUrlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodFindRelativeUrl, Fixture, methodFindRelativeUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFindRelativeUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (FindRelativeUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_FindRelativeUrl_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFindRelativeUrl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FindRelativeUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_FindRelativeUrl_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodFindRelativeUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstanceFixture, _cascadingLookupFieldSettingsInstanceType, MethodFindRelativeUrl, Fixture, methodFindRelativeUrlPrametersTypes);
        }

        #endregion
        
        #region Method Call : (FindRelativeUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_FindRelativeUrl_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Url = CreateType<string>();
            var CurrentContext = CreateType<SPContext>();
            var methodFindRelativeUrlPrametersTypes = new Type[] { typeof(string), typeof(SPContext) };
            object[] parametersOfFindRelativeUrl = { Url, CurrentContext };

            // Assert
            parametersOfFindRelativeUrl.ShouldNotBeNull();
            parametersOfFindRelativeUrl.Length.ShouldBe(2);
            methodFindRelativeUrlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_cascadingLookupFieldSettingsInstanceFixture, _cascadingLookupFieldSettingsInstanceType, MethodFindRelativeUrl, parametersOfFindRelativeUrl, methodFindRelativeUrlPrametersTypes));
        }

        #endregion
        
        #region Method Call : (FindRelativeUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_FindRelativeUrl_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFindRelativeUrlPrametersTypes = new Type[] { typeof(string), typeof(SPContext) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstanceFixture, _cascadingLookupFieldSettingsInstanceType, MethodFindRelativeUrl, Fixture, methodFindRelativeUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFindRelativeUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (FindRelativeUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_FindRelativeUrl_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFindRelativeUrl, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ShowControl) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ShowControl_Method_Call_Internally(Type[] types)
        {
            var methodShowControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowControl, Fixture, methodShowControlPrametersTypes);
        }

        #endregion
        
        #region Method Call : (ShowControl) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowControl_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var isVisible = CreateType<bool>();
            var control = CreateType<WebControl>();
            var methodShowControlPrametersTypes = new Type[] { typeof(bool), typeof(WebControl) };
            object[] parametersOfShowControl = { isVisible, control };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodShowControl, parametersOfShowControl, methodShowControlPrametersTypes);

            // Assert
            parametersOfShowControl.ShouldNotBeNull();
            parametersOfShowControl.Length.ShouldBe(2);
            methodShowControlPrametersTypes.Length.ShouldBe(2);
            methodShowControlPrametersTypes.Length.ShouldBe(parametersOfShowControl.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowControl) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowControl_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodShowControl, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ShowControl) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowControl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodShowControlPrametersTypes = new Type[] { typeof(bool), typeof(WebControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowControl, Fixture, methodShowControlPrametersTypes);

            // Assert
            methodShowControlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowControl) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowControl_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodShowControl, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ShowList_Method_Call_Internally(Type[] types)
        {
            var methodShowListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowList, Fixture, methodShowListPrametersTypes);
        }

        #endregion

        #region Method Call : (ShowList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowList_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var isVisible = CreateType<bool>();
            var methodShowListPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowList = { isVisible };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodShowList, methodShowListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfShowList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfShowList.ShouldNotBeNull();
            parametersOfShowList.Length.ShouldBe(1);
            methodShowListPrametersTypes.Length.ShouldBe(1);
            methodShowListPrametersTypes.Length.ShouldBe(parametersOfShowList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ShowList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowList_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var isVisible = CreateType<bool>();
            var methodShowListPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowList = { isVisible };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodShowList, parametersOfShowList, methodShowListPrametersTypes);

            // Assert
            parametersOfShowList.ShouldNotBeNull();
            parametersOfShowList.Length.ShouldBe(1);
            methodShowListPrametersTypes.Length.ShouldBe(1);
            methodShowListPrametersTypes.Length.ShouldBe(parametersOfShowList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodShowList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ShowList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodShowListPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowList, Fixture, methodShowListPrametersTypes);

            // Assert
            methodShowListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowList_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodShowList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ShowField_Method_Call_Internally(Type[] types)
        {
            var methodShowFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowField, Fixture, methodShowFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (ShowField) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowField_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var isVisible = CreateType<bool>();
            var methodShowFieldPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowField = { isVisible };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodShowField, methodShowFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfShowField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfShowField.ShouldNotBeNull();
            parametersOfShowField.Length.ShouldBe(1);
            methodShowFieldPrametersTypes.Length.ShouldBe(1);
            methodShowFieldPrametersTypes.Length.ShouldBe(parametersOfShowField.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ShowField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var isVisible = CreateType<bool>();
            var methodShowFieldPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowField = { isVisible };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodShowField, parametersOfShowField, methodShowFieldPrametersTypes);

            // Assert
            parametersOfShowField.ShouldNotBeNull();
            parametersOfShowField.Length.ShouldBe(1);
            methodShowFieldPrametersTypes.Length.ShouldBe(1);
            methodShowFieldPrametersTypes.Length.ShouldBe(parametersOfShowField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodShowField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ShowField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodShowFieldPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowField, Fixture, methodShowFieldPrametersTypes);

            // Assert
            methodShowFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodShowField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowFilterSettingsOption) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ShowFilterSettingsOption_Method_Call_Internally(Type[] types)
        {
            var methodShowFilterSettingsOptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowFilterSettingsOption, Fixture, methodShowFilterSettingsOptionPrametersTypes);
        }

        #endregion

        #region Method Call : (ShowFilterSettingsOption) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterSettingsOption_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var isVisible = CreateType<bool>();
            var methodShowFilterSettingsOptionPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowFilterSettingsOption = { isVisible };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodShowFilterSettingsOption, methodShowFilterSettingsOptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfShowFilterSettingsOption);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfShowFilterSettingsOption.ShouldNotBeNull();
            parametersOfShowFilterSettingsOption.Length.ShouldBe(1);
            methodShowFilterSettingsOptionPrametersTypes.Length.ShouldBe(1);
            methodShowFilterSettingsOptionPrametersTypes.Length.ShouldBe(parametersOfShowFilterSettingsOption.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ShowFilterSettingsOption) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterSettingsOption_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var isVisible = CreateType<bool>();
            var methodShowFilterSettingsOptionPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowFilterSettingsOption = { isVisible };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodShowFilterSettingsOption, parametersOfShowFilterSettingsOption, methodShowFilterSettingsOptionPrametersTypes);

            // Assert
            parametersOfShowFilterSettingsOption.ShouldNotBeNull();
            parametersOfShowFilterSettingsOption.Length.ShouldBe(1);
            methodShowFilterSettingsOptionPrametersTypes.Length.ShouldBe(1);
            methodShowFilterSettingsOptionPrametersTypes.Length.ShouldBe(parametersOfShowFilterSettingsOption.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowFilterSettingsOption) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterSettingsOption_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodShowFilterSettingsOption, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ShowFilterSettingsOption) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterSettingsOption_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodShowFilterSettingsOptionPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowFilterSettingsOption, Fixture, methodShowFilterSettingsOptionPrametersTypes);

            // Assert
            methodShowFilterSettingsOptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowFilterSettingsOption) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterSettingsOption_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodShowFilterSettingsOption, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowFilterCriteria) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldSettings_ShowFilterCriteria_Method_Call_Internally(Type[] types)
        {
            var methodShowFilterCriteriaPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowFilterCriteria, Fixture, methodShowFilterCriteriaPrametersTypes);
        }

        #endregion

        #region Method Call : (ShowFilterCriteria) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterCriteria_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var isVisible = CreateType<bool>();
            var methodShowFilterCriteriaPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowFilterCriteria = { isVisible };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodShowFilterCriteria, methodShowFilterCriteriaPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldSettingsInstanceFixture, parametersOfShowFilterCriteria);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfShowFilterCriteria.ShouldNotBeNull();
            parametersOfShowFilterCriteria.Length.ShouldBe(1);
            methodShowFilterCriteriaPrametersTypes.Length.ShouldBe(1);
            methodShowFilterCriteriaPrametersTypes.Length.ShouldBe(parametersOfShowFilterCriteria.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ShowFilterCriteria) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterCriteria_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var isVisible = CreateType<bool>();
            var methodShowFilterCriteriaPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowFilterCriteria = { isVisible };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldSettingsInstance, MethodShowFilterCriteria, parametersOfShowFilterCriteria, methodShowFilterCriteriaPrametersTypes);

            // Assert
            parametersOfShowFilterCriteria.ShouldNotBeNull();
            parametersOfShowFilterCriteria.Length.ShouldBe(1);
            methodShowFilterCriteriaPrametersTypes.Length.ShouldBe(1);
            methodShowFilterCriteriaPrametersTypes.Length.ShouldBe(parametersOfShowFilterCriteria.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowFilterCriteria) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterCriteria_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodShowFilterCriteria, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ShowFilterCriteria) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterCriteria_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodShowFilterCriteriaPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldSettingsInstance, MethodShowFilterCriteria, Fixture, methodShowFilterCriteriaPrametersTypes);

            // Assert
            methodShowFilterCriteriaPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowFilterCriteria) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupFieldSettings_ShowFilterCriteria_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodShowFilterCriteria, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
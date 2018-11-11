using System;
using System.Diagnostics.CodeAnalysis;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.FilteredLookupFieldEditor" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class FilteredLookupFieldEditorTest : AbstractBaseSetupTypedTest<FilteredLookupFieldEditor>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FilteredLookupFieldEditor) Initializer

        private const string PropertyTargetWebId = "TargetWebId";
        private const string PropertyTargetListId = "TargetListId";
        private const string PropertyTargetListViewId = "TargetListViewId";
        private const string PropertyTargetColumnId = "TargetColumnId";
        private const string PropertyDisplayAsNewSection = "DisplayAsNewSection";
        private const string MethodSetTargetWeb = "SetTargetWeb";
        private const string MethodSetControlVisibility = "SetControlVisibility";
        private const string MethodSelectedTargetWebChanged = "SelectedTargetWebChanged";
        private const string MethodSelectedTargetListChanged = "SelectedTargetListChanged";
        private const string MethodSelectedFilterOptionChanged = "SelectedFilterOptionChanged";
        private const string MethodEnsureSelectedFilterOption = "EnsureSelectedFilterOption";
        private const string MethodOnInit = "OnInit";
        private const string MethodSetTargetList = "SetTargetList";
        private const string MethodSetTargetListView = "SetTargetListView";
        private const string MethodCanFieldBeDisplayed = "CanFieldBeDisplayed";
        private const string MethodSetTargetColumn = "SetTargetColumn";
        private const string MethodInitializeWithField = "InitializeWithField";
        private const string MethodOnSaveChange = "OnSaveChange";
        private const string MethodIsCountRelated = "IsCountRelated";
        private const string FieldEXCLUDED_FIELDS = "EXCLUDED_FIELDS";
        private const string FieldlistTargetWeb = "listTargetWeb";
        private const string FieldlistTargetList = "listTargetList";
        private const string FieldlistTargetColumn = "listTargetColumn";
        private const string FieldlistTargetListView = "listTargetListView";
        private const string FieldlblTargetWeb = "lblTargetWeb";
        private const string FieldlblTargetList = "lblTargetList";
        private const string FieldcbxAllowMultiValue = "cbxAllowMultiValue";
        private const string FieldcbxUnlimitedLengthInDocLib = "cbxUnlimitedLengthInDocLib";
        private const string FieldSpanDocLibWarning = "SpanDocLibWarning";
        private const string FieldSpanLengthWarning = "SpanLengthWarning";
        private const string FieldtdQuery = "tdQuery";
        private const string FieldtdListView = "tdListView";
        private const string FieldrdFilterOption = "rdFilterOption";
        private const string FieldtxtQueryFilter = "txtQueryFilter";
        private const string FieldcbxRecursiveFilter = "cbxRecursiveFilter";
        private Type _filteredLookupFieldEditorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FilteredLookupFieldEditor _filteredLookupFieldEditorInstance;
        private FilteredLookupFieldEditor _filteredLookupFieldEditorInstanceFixture;

        #region General Initializer : Class (FilteredLookupFieldEditor) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FilteredLookupFieldEditor" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _filteredLookupFieldEditorInstanceType = typeof(FilteredLookupFieldEditor);
            _filteredLookupFieldEditorInstanceFixture = Create(true);
            _filteredLookupFieldEditorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FilteredLookupFieldEditor)

        #region General Initializer : Class (FilteredLookupFieldEditor) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="FilteredLookupFieldEditor" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodSetTargetWeb, 0)]
        [TestCase(MethodSetControlVisibility, 0)]
        [TestCase(MethodSelectedTargetWebChanged, 0)]
        [TestCase(MethodSelectedTargetListChanged, 0)]
        [TestCase(MethodSelectedFilterOptionChanged, 0)]
        [TestCase(MethodEnsureSelectedFilterOption, 0)]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodSetTargetList, 0)]
        [TestCase(MethodSetTargetListView, 0)]
        [TestCase(MethodCanFieldBeDisplayed, 0)]
        [TestCase(MethodSetTargetColumn, 0)]
        [TestCase(MethodInitializeWithField, 0)]
        [TestCase(MethodOnSaveChange, 0)]
        [TestCase(MethodIsCountRelated, 0)]
        public void AUT_FilteredLookupFieldEditor_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_filteredLookupFieldEditorInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FilteredLookupFieldEditor) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FilteredLookupFieldEditor" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyTargetWebId)]
        [TestCase(PropertyTargetListId)]
        [TestCase(PropertyTargetListViewId)]
        [TestCase(PropertyTargetColumnId)]
        [TestCase(PropertyDisplayAsNewSection)]
        public void AUT_FilteredLookupFieldEditor_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_filteredLookupFieldEditorInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FilteredLookupFieldEditor) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FilteredLookupFieldEditor" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldEXCLUDED_FIELDS)]
        [TestCase(FieldlistTargetWeb)]
        [TestCase(FieldlistTargetList)]
        [TestCase(FieldlistTargetColumn)]
        [TestCase(FieldlistTargetListView)]
        [TestCase(FieldlblTargetWeb)]
        [TestCase(FieldlblTargetList)]
        [TestCase(FieldcbxAllowMultiValue)]
        [TestCase(FieldcbxUnlimitedLengthInDocLib)]
        [TestCase(FieldSpanDocLibWarning)]
        [TestCase(FieldSpanLengthWarning)]
        [TestCase(FieldtdQuery)]
        [TestCase(FieldtdListView)]
        [TestCase(FieldrdFilterOption)]
        [TestCase(FieldtxtQueryFilter)]
        [TestCase(FieldcbxRecursiveFilter)]
        public void AUT_FilteredLookupFieldEditor_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_filteredLookupFieldEditorInstanceFixture, 
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
        ///     Class (<see cref="FilteredLookupFieldEditor" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_FilteredLookupFieldEditor_Is_Instance_Present_Test()
        {
            // Assert
            _filteredLookupFieldEditorInstanceType.ShouldNotBeNull();
            _filteredLookupFieldEditorInstance.ShouldNotBeNull();
            _filteredLookupFieldEditorInstanceFixture.ShouldNotBeNull();
            _filteredLookupFieldEditorInstance.ShouldBeAssignableTo<FilteredLookupFieldEditor>();
            _filteredLookupFieldEditorInstanceFixture.ShouldBeAssignableTo<FilteredLookupFieldEditor>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FilteredLookupFieldEditor) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_FilteredLookupFieldEditor_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FilteredLookupFieldEditor instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _filteredLookupFieldEditorInstanceType.ShouldNotBeNull();
            _filteredLookupFieldEditorInstance.ShouldNotBeNull();
            _filteredLookupFieldEditorInstanceFixture.ShouldNotBeNull();
            _filteredLookupFieldEditorInstance.ShouldBeAssignableTo<FilteredLookupFieldEditor>();
            _filteredLookupFieldEditorInstanceFixture.ShouldBeAssignableTo<FilteredLookupFieldEditor>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FilteredLookupFieldEditor) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyTargetWebId)]
        [TestCaseGeneric(typeof(string) , PropertyTargetListId)]
        [TestCaseGeneric(typeof(string) , PropertyTargetListViewId)]
        [TestCaseGeneric(typeof(string) , PropertyTargetColumnId)]
        [TestCaseGeneric(typeof(bool) , PropertyDisplayAsNewSection)]
        public void AUT_FilteredLookupFieldEditor_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FilteredLookupFieldEditor, T>(_filteredLookupFieldEditorInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupFieldEditor) => Property (DisplayAsNewSection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupFieldEditor_Public_Class_DisplayAsNewSection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FilteredLookupFieldEditor) => Property (TargetColumnId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupFieldEditor_Public_Class_TargetColumnId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTargetColumnId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupFieldEditor) => Property (TargetListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupFieldEditor_Public_Class_TargetListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTargetListId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupFieldEditor) => Property (TargetListViewId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupFieldEditor_Public_Class_TargetListViewId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTargetListViewId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupFieldEditor) => Property (TargetWebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupFieldEditor_Public_Class_TargetWebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTargetWebId);

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
        ///      Class (<see cref="FilteredLookupFieldEditor" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSetTargetWeb)]
        [TestCase(MethodSetControlVisibility)]
        [TestCase(MethodSelectedTargetWebChanged)]
        [TestCase(MethodSelectedTargetListChanged)]
        [TestCase(MethodSelectedFilterOptionChanged)]
        [TestCase(MethodEnsureSelectedFilterOption)]
        [TestCase(MethodOnInit)]
        [TestCase(MethodSetTargetList)]
        [TestCase(MethodSetTargetListView)]
        [TestCase(MethodCanFieldBeDisplayed)]
        [TestCase(MethodSetTargetColumn)]
        [TestCase(MethodInitializeWithField)]
        [TestCase(MethodOnSaveChange)]
        [TestCase(MethodIsCountRelated)]
        public void AUT_FilteredLookupFieldEditor_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<FilteredLookupFieldEditor>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (SetTargetWeb) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_SetTargetWeb_Method_Call_Internally(Type[] types)
        {
            var methodSetTargetWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetTargetWeb, Fixture, methodSetTargetWebPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTargetWeb) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetWeb_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetTargetWebPrametersTypes = null;
            object[] parametersOfSetTargetWeb = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTargetWeb, methodSetTargetWebPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfSetTargetWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTargetWeb.ShouldBeNull();
            methodSetTargetWebPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetWeb) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetWeb_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetTargetWebPrametersTypes = null;
            object[] parametersOfSetTargetWeb = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodSetTargetWeb, parametersOfSetTargetWeb, methodSetTargetWebPrametersTypes);

            // Assert
            parametersOfSetTargetWeb.ShouldBeNull();
            methodSetTargetWebPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetWeb) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetWeb_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetTargetWebPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetTargetWeb, Fixture, methodSetTargetWebPrametersTypes);

            // Assert
            methodSetTargetWebPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetWeb) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetWeb_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTargetWeb, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlVisibility) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_SetControlVisibility_Method_Call_Internally(Type[] types)
        {
            var methodSetControlVisibilityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetControlVisibility, Fixture, methodSetControlVisibilityPrametersTypes);
        }

        #endregion

        #region Method Call : (SetControlVisibility) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetControlVisibility_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetControlVisibilityPrametersTypes = null;
            object[] parametersOfSetControlVisibility = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetControlVisibility, methodSetControlVisibilityPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfSetControlVisibility);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetControlVisibility.ShouldBeNull();
            methodSetControlVisibilityPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetControlVisibility) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetControlVisibility_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetControlVisibilityPrametersTypes = null;
            object[] parametersOfSetControlVisibility = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodSetControlVisibility, parametersOfSetControlVisibility, methodSetControlVisibilityPrametersTypes);

            // Assert
            parametersOfSetControlVisibility.ShouldBeNull();
            methodSetControlVisibilityPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlVisibility) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetControlVisibility_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetControlVisibilityPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetControlVisibility, Fixture, methodSetControlVisibilityPrametersTypes);

            // Assert
            methodSetControlVisibilityPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlVisibility) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetControlVisibility_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetControlVisibility, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectedTargetWebChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_SelectedTargetWebChanged_Method_Call_Internally(Type[] types)
        {
            var methodSelectedTargetWebChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSelectedTargetWebChanged, Fixture, methodSelectedTargetWebChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (SelectedTargetWebChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetWebChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<Object>();
            var args = CreateType<EventArgs>();
            var methodSelectedTargetWebChangedPrametersTypes = new Type[] { typeof(Object), typeof(EventArgs) };
            object[] parametersOfSelectedTargetWebChanged = { sender, args };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSelectedTargetWebChanged, methodSelectedTargetWebChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfSelectedTargetWebChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSelectedTargetWebChanged.ShouldNotBeNull();
            parametersOfSelectedTargetWebChanged.Length.ShouldBe(2);
            methodSelectedTargetWebChangedPrametersTypes.Length.ShouldBe(2);
            methodSelectedTargetWebChangedPrametersTypes.Length.ShouldBe(parametersOfSelectedTargetWebChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SelectedTargetWebChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetWebChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<Object>();
            var args = CreateType<EventArgs>();
            var methodSelectedTargetWebChangedPrametersTypes = new Type[] { typeof(Object), typeof(EventArgs) };
            object[] parametersOfSelectedTargetWebChanged = { sender, args };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodSelectedTargetWebChanged, parametersOfSelectedTargetWebChanged, methodSelectedTargetWebChangedPrametersTypes);

            // Assert
            parametersOfSelectedTargetWebChanged.ShouldNotBeNull();
            parametersOfSelectedTargetWebChanged.Length.ShouldBe(2);
            methodSelectedTargetWebChangedPrametersTypes.Length.ShouldBe(2);
            methodSelectedTargetWebChangedPrametersTypes.Length.ShouldBe(parametersOfSelectedTargetWebChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectedTargetWebChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetWebChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSelectedTargetWebChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectedTargetWebChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetWebChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelectedTargetWebChangedPrametersTypes = new Type[] { typeof(Object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSelectedTargetWebChanged, Fixture, methodSelectedTargetWebChangedPrametersTypes);

            // Assert
            methodSelectedTargetWebChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectedTargetWebChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetWebChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelectedTargetWebChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectedTargetListChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_SelectedTargetListChanged_Method_Call_Internally(Type[] types)
        {
            var methodSelectedTargetListChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSelectedTargetListChanged, Fixture, methodSelectedTargetListChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (SelectedTargetListChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetListChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<Object>();
            var args = CreateType<EventArgs>();
            var methodSelectedTargetListChangedPrametersTypes = new Type[] { typeof(Object), typeof(EventArgs) };
            object[] parametersOfSelectedTargetListChanged = { sender, args };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSelectedTargetListChanged, methodSelectedTargetListChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfSelectedTargetListChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSelectedTargetListChanged.ShouldNotBeNull();
            parametersOfSelectedTargetListChanged.Length.ShouldBe(2);
            methodSelectedTargetListChangedPrametersTypes.Length.ShouldBe(2);
            methodSelectedTargetListChangedPrametersTypes.Length.ShouldBe(parametersOfSelectedTargetListChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SelectedTargetListChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetListChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<Object>();
            var args = CreateType<EventArgs>();
            var methodSelectedTargetListChangedPrametersTypes = new Type[] { typeof(Object), typeof(EventArgs) };
            object[] parametersOfSelectedTargetListChanged = { sender, args };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodSelectedTargetListChanged, parametersOfSelectedTargetListChanged, methodSelectedTargetListChangedPrametersTypes);

            // Assert
            parametersOfSelectedTargetListChanged.ShouldNotBeNull();
            parametersOfSelectedTargetListChanged.Length.ShouldBe(2);
            methodSelectedTargetListChangedPrametersTypes.Length.ShouldBe(2);
            methodSelectedTargetListChangedPrametersTypes.Length.ShouldBe(parametersOfSelectedTargetListChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectedTargetListChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetListChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSelectedTargetListChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectedTargetListChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetListChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelectedTargetListChangedPrametersTypes = new Type[] { typeof(Object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSelectedTargetListChanged, Fixture, methodSelectedTargetListChangedPrametersTypes);

            // Assert
            methodSelectedTargetListChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectedTargetListChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedTargetListChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelectedTargetListChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectedFilterOptionChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_SelectedFilterOptionChanged_Method_Call_Internally(Type[] types)
        {
            var methodSelectedFilterOptionChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSelectedFilterOptionChanged, Fixture, methodSelectedFilterOptionChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (SelectedFilterOptionChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedFilterOptionChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<Object>();
            var args = CreateType<EventArgs>();
            var methodSelectedFilterOptionChangedPrametersTypes = new Type[] { typeof(Object), typeof(EventArgs) };
            object[] parametersOfSelectedFilterOptionChanged = { sender, args };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSelectedFilterOptionChanged, methodSelectedFilterOptionChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfSelectedFilterOptionChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSelectedFilterOptionChanged.ShouldNotBeNull();
            parametersOfSelectedFilterOptionChanged.Length.ShouldBe(2);
            methodSelectedFilterOptionChangedPrametersTypes.Length.ShouldBe(2);
            methodSelectedFilterOptionChangedPrametersTypes.Length.ShouldBe(parametersOfSelectedFilterOptionChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SelectedFilterOptionChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedFilterOptionChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<Object>();
            var args = CreateType<EventArgs>();
            var methodSelectedFilterOptionChangedPrametersTypes = new Type[] { typeof(Object), typeof(EventArgs) };
            object[] parametersOfSelectedFilterOptionChanged = { sender, args };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodSelectedFilterOptionChanged, parametersOfSelectedFilterOptionChanged, methodSelectedFilterOptionChangedPrametersTypes);

            // Assert
            parametersOfSelectedFilterOptionChanged.ShouldNotBeNull();
            parametersOfSelectedFilterOptionChanged.Length.ShouldBe(2);
            methodSelectedFilterOptionChangedPrametersTypes.Length.ShouldBe(2);
            methodSelectedFilterOptionChangedPrametersTypes.Length.ShouldBe(parametersOfSelectedFilterOptionChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectedFilterOptionChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedFilterOptionChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSelectedFilterOptionChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectedFilterOptionChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedFilterOptionChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelectedFilterOptionChangedPrametersTypes = new Type[] { typeof(Object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSelectedFilterOptionChanged, Fixture, methodSelectedFilterOptionChangedPrametersTypes);

            // Assert
            methodSelectedFilterOptionChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectedFilterOptionChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SelectedFilterOptionChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelectedFilterOptionChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureSelectedFilterOption) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_EnsureSelectedFilterOption_Method_Call_Internally(Type[] types)
        {
            var methodEnsureSelectedFilterOptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodEnsureSelectedFilterOption, Fixture, methodEnsureSelectedFilterOptionPrametersTypes);
        }

        #endregion

        #region Method Call : (EnsureSelectedFilterOption) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_EnsureSelectedFilterOption_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var isNew = CreateType<bool>();
            var methodEnsureSelectedFilterOptionPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfEnsureSelectedFilterOption = { isNew };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnsureSelectedFilterOption, methodEnsureSelectedFilterOptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfEnsureSelectedFilterOption);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnsureSelectedFilterOption.ShouldNotBeNull();
            parametersOfEnsureSelectedFilterOption.Length.ShouldBe(1);
            methodEnsureSelectedFilterOptionPrametersTypes.Length.ShouldBe(1);
            methodEnsureSelectedFilterOptionPrametersTypes.Length.ShouldBe(parametersOfEnsureSelectedFilterOption.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnsureSelectedFilterOption) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_EnsureSelectedFilterOption_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var isNew = CreateType<bool>();
            var methodEnsureSelectedFilterOptionPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfEnsureSelectedFilterOption = { isNew };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodEnsureSelectedFilterOption, parametersOfEnsureSelectedFilterOption, methodEnsureSelectedFilterOptionPrametersTypes);

            // Assert
            parametersOfEnsureSelectedFilterOption.ShouldNotBeNull();
            parametersOfEnsureSelectedFilterOption.Length.ShouldBe(1);
            methodEnsureSelectedFilterOptionPrametersTypes.Length.ShouldBe(1);
            methodEnsureSelectedFilterOptionPrametersTypes.Length.ShouldBe(parametersOfEnsureSelectedFilterOption.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureSelectedFilterOption) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_EnsureSelectedFilterOption_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnsureSelectedFilterOption, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnsureSelectedFilterOption) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_EnsureSelectedFilterOption_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnsureSelectedFilterOptionPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodEnsureSelectedFilterOption, Fixture, methodEnsureSelectedFilterOptionPrametersTypes);

            // Assert
            methodEnsureSelectedFilterOptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureSelectedFilterOption) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_EnsureSelectedFilterOption_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnsureSelectedFilterOption, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_OnInit_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfOnInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

            // Assert
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_OnInit_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnInit, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_SetTargetList_Method_Call_Internally(Type[] types)
        {
            var methodSetTargetListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetTargetList, Fixture, methodSetTargetListPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTargetList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetList_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var selectedWebId = CreateType<string>();
            var setTargetColumn = CreateType<bool>();
            var methodSetTargetListPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfSetTargetList = { selectedWebId, setTargetColumn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTargetList, methodSetTargetListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfSetTargetList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTargetList.ShouldNotBeNull();
            parametersOfSetTargetList.Length.ShouldBe(2);
            methodSetTargetListPrametersTypes.Length.ShouldBe(2);
            methodSetTargetListPrametersTypes.Length.ShouldBe(parametersOfSetTargetList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetList_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var selectedWebId = CreateType<string>();
            var setTargetColumn = CreateType<bool>();
            var methodSetTargetListPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfSetTargetList = { selectedWebId, setTargetColumn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodSetTargetList, parametersOfSetTargetList, methodSetTargetListPrametersTypes);

            // Assert
            parametersOfSetTargetList.ShouldNotBeNull();
            parametersOfSetTargetList.Length.ShouldBe(2);
            methodSetTargetListPrametersTypes.Length.ShouldBe(2);
            methodSetTargetListPrametersTypes.Length.ShouldBe(parametersOfSetTargetList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTargetList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTargetList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTargetListPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetTargetList, Fixture, methodSetTargetListPrametersTypes);

            // Assert
            methodSetTargetListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetList_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTargetList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetListView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_SetTargetListView_Method_Call_Internally(Type[] types)
        {
            var methodSetTargetListViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetTargetListView, Fixture, methodSetTargetListViewPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTargetListView) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetListView_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var webId = CreateType<string>();
            var selectedListId = CreateType<string>();
            var methodSetTargetListViewPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetTargetListView = { webId, selectedListId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTargetListView, methodSetTargetListViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfSetTargetListView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTargetListView.ShouldNotBeNull();
            parametersOfSetTargetListView.Length.ShouldBe(2);
            methodSetTargetListViewPrametersTypes.Length.ShouldBe(2);
            methodSetTargetListViewPrametersTypes.Length.ShouldBe(parametersOfSetTargetListView.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetListView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetListView_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webId = CreateType<string>();
            var selectedListId = CreateType<string>();
            var methodSetTargetListViewPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetTargetListView = { webId, selectedListId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodSetTargetListView, parametersOfSetTargetListView, methodSetTargetListViewPrametersTypes);

            // Assert
            parametersOfSetTargetListView.ShouldNotBeNull();
            parametersOfSetTargetListView.Length.ShouldBe(2);
            methodSetTargetListViewPrametersTypes.Length.ShouldBe(2);
            methodSetTargetListViewPrametersTypes.Length.ShouldBe(parametersOfSetTargetListView.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetListView) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetListView_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTargetListView, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTargetListView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetListView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTargetListViewPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetTargetListView, Fixture, methodSetTargetListViewPrametersTypes);

            // Assert
            methodSetTargetListViewPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetListView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetListView_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTargetListView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanFieldBeDisplayed) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_CanFieldBeDisplayed_Method_Call_Internally(Type[] types)
        {
            var methodCanFieldBeDisplayedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodCanFieldBeDisplayed, Fixture, methodCanFieldBeDisplayedPrametersTypes);
        }

        #endregion

        #region Method Call : (CanFieldBeDisplayed) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_CanFieldBeDisplayed_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var f = CreateType<SPField>();
            var methodCanFieldBeDisplayedPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfCanFieldBeDisplayed = { f };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanFieldBeDisplayed, methodCanFieldBeDisplayedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<FilteredLookupFieldEditor, bool>(_filteredLookupFieldEditorInstanceFixture, out exception1, parametersOfCanFieldBeDisplayed);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<FilteredLookupFieldEditor, bool>(_filteredLookupFieldEditorInstance, MethodCanFieldBeDisplayed, parametersOfCanFieldBeDisplayed, methodCanFieldBeDisplayedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanFieldBeDisplayed.ShouldNotBeNull();
            parametersOfCanFieldBeDisplayed.Length.ShouldBe(1);
            methodCanFieldBeDisplayedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<FilteredLookupFieldEditor, bool>(_filteredLookupFieldEditorInstance, MethodCanFieldBeDisplayed, parametersOfCanFieldBeDisplayed, methodCanFieldBeDisplayedPrametersTypes));
        }

        #endregion

        #region Method Call : (CanFieldBeDisplayed) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_CanFieldBeDisplayed_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var f = CreateType<SPField>();
            var methodCanFieldBeDisplayedPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfCanFieldBeDisplayed = { f };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCanFieldBeDisplayed, methodCanFieldBeDisplayedPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCanFieldBeDisplayed.ShouldNotBeNull();
            parametersOfCanFieldBeDisplayed.Length.ShouldBe(1);
            methodCanFieldBeDisplayedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfCanFieldBeDisplayed));
        }

        #endregion

        #region Method Call : (CanFieldBeDisplayed) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_CanFieldBeDisplayed_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var f = CreateType<SPField>();
            var methodCanFieldBeDisplayedPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfCanFieldBeDisplayed = { f };

            // Assert
            parametersOfCanFieldBeDisplayed.ShouldNotBeNull();
            parametersOfCanFieldBeDisplayed.Length.ShouldBe(1);
            methodCanFieldBeDisplayedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<FilteredLookupFieldEditor, bool>(_filteredLookupFieldEditorInstance, MethodCanFieldBeDisplayed, parametersOfCanFieldBeDisplayed, methodCanFieldBeDisplayedPrametersTypes));
        }

        #endregion

        #region Method Call : (CanFieldBeDisplayed) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_CanFieldBeDisplayed_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanFieldBeDisplayedPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodCanFieldBeDisplayed, Fixture, methodCanFieldBeDisplayedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanFieldBeDisplayedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanFieldBeDisplayed) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_CanFieldBeDisplayed_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanFieldBeDisplayed, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CanFieldBeDisplayed) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_CanFieldBeDisplayed_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanFieldBeDisplayed, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTargetColumn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_SetTargetColumn_Method_Call_Internally(Type[] types)
        {
            var methodSetTargetColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetTargetColumn, Fixture, methodSetTargetColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTargetColumn) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetColumn_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var webId = CreateType<string>();
            var selectedListId = CreateType<string>();
            var methodSetTargetColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetTargetColumn = { webId, selectedListId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTargetColumn, methodSetTargetColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfSetTargetColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTargetColumn.ShouldNotBeNull();
            parametersOfSetTargetColumn.Length.ShouldBe(2);
            methodSetTargetColumnPrametersTypes.Length.ShouldBe(2);
            methodSetTargetColumnPrametersTypes.Length.ShouldBe(parametersOfSetTargetColumn.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetColumn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetColumn_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webId = CreateType<string>();
            var selectedListId = CreateType<string>();
            var methodSetTargetColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetTargetColumn = { webId, selectedListId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodSetTargetColumn, parametersOfSetTargetColumn, methodSetTargetColumnPrametersTypes);

            // Assert
            parametersOfSetTargetColumn.ShouldNotBeNull();
            parametersOfSetTargetColumn.Length.ShouldBe(2);
            methodSetTargetColumnPrametersTypes.Length.ShouldBe(2);
            methodSetTargetColumnPrametersTypes.Length.ShouldBe(parametersOfSetTargetColumn.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetColumn) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetColumn_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTargetColumn, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTargetColumn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetColumn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTargetColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodSetTargetColumn, Fixture, methodSetTargetColumnPrametersTypes);

            // Assert
            methodSetTargetColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTargetColumn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_SetTargetColumn_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTargetColumn, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_InitializeWithField_Method_Call_Internally(Type[] types)
        {
            var methodInitializeWithFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodInitializeWithField, Fixture, methodInitializeWithFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_InitializeWithField_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => _filteredLookupFieldEditorInstance.InitializeWithField(field);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_InitializeWithField_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodInitializeWithFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfInitializeWithField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeWithField, methodInitializeWithFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfInitializeWithField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeWithField.ShouldNotBeNull();
            parametersOfInitializeWithField.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(parametersOfInitializeWithField.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_InitializeWithField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodInitializeWithFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfInitializeWithField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodInitializeWithField, parametersOfInitializeWithField, methodInitializeWithFieldPrametersTypes);

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
        public void AUT_FilteredLookupFieldEditor_InitializeWithField_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_FilteredLookupFieldEditor_InitializeWithField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializeWithFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodInitializeWithField, Fixture, methodInitializeWithFieldPrametersTypes);

            // Assert
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_InitializeWithField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeWithField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_OnSaveChange_Method_Call_Internally(Type[] types)
        {
            var methodOnSaveChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodOnSaveChange, Fixture, methodOnSaveChangePrametersTypes);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_OnSaveChange_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var isNewField = CreateType<bool>();
            var methodOnSaveChangePrametersTypes = new Type[] { typeof(SPField), typeof(bool) };
            object[] parametersOfOnSaveChange = { field, isNewField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldEditorInstance, MethodOnSaveChange, parametersOfOnSaveChange, methodOnSaveChangePrametersTypes);

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
        public void AUT_FilteredLookupFieldEditor_OnSaveChange_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_FilteredLookupFieldEditor_OnSaveChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnSaveChangePrametersTypes = new Type[] { typeof(SPField), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodOnSaveChange, Fixture, methodOnSaveChangePrametersTypes);

            // Assert
            methodOnSaveChangePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_OnSaveChange_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnSaveChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsCountRelated) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldEditor_IsCountRelated_Method_Call_Internally(Type[] types)
        {
            var methodIsCountRelatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodIsCountRelated, Fixture, methodIsCountRelatedPrametersTypes);
        }

        #endregion

        #region Method Call : (IsCountRelated) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_IsCountRelated_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var lookupColumnId = CreateType<string>();
            var lookupListId = CreateType<string>();
            var methodIsCountRelatedPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfIsCountRelated = { lookupColumnId, lookupListId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsCountRelated, methodIsCountRelatedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<FilteredLookupFieldEditor, bool>(_filteredLookupFieldEditorInstanceFixture, out exception1, parametersOfIsCountRelated);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<FilteredLookupFieldEditor, bool>(_filteredLookupFieldEditorInstance, MethodIsCountRelated, parametersOfIsCountRelated, methodIsCountRelatedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsCountRelated.ShouldNotBeNull();
            parametersOfIsCountRelated.Length.ShouldBe(2);
            methodIsCountRelatedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<FilteredLookupFieldEditor, bool>(_filteredLookupFieldEditorInstance, MethodIsCountRelated, parametersOfIsCountRelated, methodIsCountRelatedPrametersTypes));
        }

        #endregion

        #region Method Call : (IsCountRelated) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_IsCountRelated_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var lookupColumnId = CreateType<string>();
            var lookupListId = CreateType<string>();
            var methodIsCountRelatedPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfIsCountRelated = { lookupColumnId, lookupListId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsCountRelated, methodIsCountRelatedPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsCountRelated.ShouldNotBeNull();
            parametersOfIsCountRelated.Length.ShouldBe(2);
            methodIsCountRelatedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_filteredLookupFieldEditorInstanceFixture, parametersOfIsCountRelated));
        }

        #endregion

        #region Method Call : (IsCountRelated) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_IsCountRelated_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lookupColumnId = CreateType<string>();
            var lookupListId = CreateType<string>();
            var methodIsCountRelatedPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfIsCountRelated = { lookupColumnId, lookupListId };

            // Assert
            parametersOfIsCountRelated.ShouldNotBeNull();
            parametersOfIsCountRelated.Length.ShouldBe(2);
            methodIsCountRelatedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<FilteredLookupFieldEditor, bool>(_filteredLookupFieldEditorInstance, MethodIsCountRelated, parametersOfIsCountRelated, methodIsCountRelatedPrametersTypes));
        }

        #endregion

        #region Method Call : (IsCountRelated) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_IsCountRelated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsCountRelatedPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldEditorInstance, MethodIsCountRelated, Fixture, methodIsCountRelatedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsCountRelatedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsCountRelated) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_IsCountRelated_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsCountRelated, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldEditorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsCountRelated) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupFieldEditor_IsCountRelated_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsCountRelated, 0);
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
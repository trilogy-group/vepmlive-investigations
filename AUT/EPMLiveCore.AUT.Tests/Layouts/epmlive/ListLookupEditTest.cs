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

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.ListLookupEdit" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ListLookupEditTest : AbstractBaseSetupTypedTest<ListLookupEdit>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListLookupEdit) Initializer

        private const string PropertyPageToRedirectOnCancel = "PageToRedirectOnCancel";
        private const string MethodPopulateLookupFields = "PopulateLookupFields";
        private const string MethodPopulateLookupFieldsFields = "PopulateLookupFieldsFields";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodddlParentLookupField_SelectedIndexChanged = "ddlParentLookupField_SelectedIndexChanged";
        private const string MethodButton1_Click = "Button1_Click";
        private Type _listLookupEditInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListLookupEdit _listLookupEditInstance;
        private ListLookupEdit _listLookupEditInstanceFixture;

        #region General Initializer : Class (ListLookupEdit) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListLookupEdit" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listLookupEditInstanceType = typeof(ListLookupEdit);
            _listLookupEditInstanceFixture = Create(true);
            _listLookupEditInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListLookupEdit)

        #region General Initializer : Class (ListLookupEdit) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListLookupEdit" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPopulateLookupFields, 0)]
        [TestCase(MethodPopulateLookupFieldsFields, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodddlParentLookupField_SelectedIndexChanged, 0)]
        [TestCase(MethodButton1_Click, 0)]
        public void AUT_ListLookupEdit_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listLookupEditInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListLookupEdit) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListLookupEdit" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyPageToRedirectOnCancel)]
        public void AUT_ListLookupEdit_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listLookupEditInstanceFixture,
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
        ///     Class (<see cref="ListLookupEdit" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListLookupEdit_Is_Instance_Present_Test()
        {
            // Assert
            _listLookupEditInstanceType.ShouldNotBeNull();
            _listLookupEditInstance.ShouldNotBeNull();
            _listLookupEditInstanceFixture.ShouldNotBeNull();
            _listLookupEditInstance.ShouldBeAssignableTo<ListLookupEdit>();
            _listLookupEditInstanceFixture.ShouldBeAssignableTo<ListLookupEdit>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListLookupEdit) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListLookupEdit_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListLookupEdit instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listLookupEditInstanceType.ShouldNotBeNull();
            _listLookupEditInstance.ShouldNotBeNull();
            _listLookupEditInstanceFixture.ShouldNotBeNull();
            _listLookupEditInstance.ShouldBeAssignableTo<ListLookupEdit>();
            _listLookupEditInstanceFixture.ShouldBeAssignableTo<ListLookupEdit>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListLookupEdit) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyPageToRedirectOnCancel)]
        public void AUT_ListLookupEdit_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ListLookupEdit, T>(_listLookupEditInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ListLookupEdit) => Property (PageToRedirectOnCancel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ListLookupEdit_Public_Class_PageToRedirectOnCancel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPageToRedirectOnCancel);

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
        ///      Class (<see cref="ListLookupEdit" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPopulateLookupFields)]
        [TestCase(MethodPopulateLookupFieldsFields)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodddlParentLookupField_SelectedIndexChanged)]
        [TestCase(MethodButton1_Click)]
        public void AUT_ListLookupEdit_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ListLookupEdit>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (PopulateLookupFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListLookupEdit_PopulateLookupFields_Method_Call_Internally(Type[] types)
        {
            var methodPopulateLookupFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodPopulateLookupFields, Fixture, methodPopulateLookupFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateLookupFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_PopulateLookupFields_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodPopulateLookupFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfPopulateLookupFields = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateLookupFields, methodPopulateLookupFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listLookupEditInstanceFixture, parametersOfPopulateLookupFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateLookupFields.ShouldNotBeNull();
            parametersOfPopulateLookupFields.Length.ShouldBe(1);
            methodPopulateLookupFieldsPrametersTypes.Length.ShouldBe(1);
            methodPopulateLookupFieldsPrametersTypes.Length.ShouldBe(parametersOfPopulateLookupFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateLookupFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_PopulateLookupFields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodPopulateLookupFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfPopulateLookupFields = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listLookupEditInstance, MethodPopulateLookupFields, parametersOfPopulateLookupFields, methodPopulateLookupFieldsPrametersTypes);

            // Assert
            parametersOfPopulateLookupFields.ShouldNotBeNull();
            parametersOfPopulateLookupFields.Length.ShouldBe(1);
            methodPopulateLookupFieldsPrametersTypes.Length.ShouldBe(1);
            methodPopulateLookupFieldsPrametersTypes.Length.ShouldBe(parametersOfPopulateLookupFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateLookupFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_PopulateLookupFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateLookupFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateLookupFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_PopulateLookupFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateLookupFieldsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodPopulateLookupFields, Fixture, methodPopulateLookupFieldsPrametersTypes);

            // Assert
            methodPopulateLookupFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateLookupFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_PopulateLookupFields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateLookupFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listLookupEditInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateLookupFieldsFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListLookupEdit_PopulateLookupFieldsFields_Method_Call_Internally(Type[] types)
        {
            var methodPopulateLookupFieldsFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodPopulateLookupFieldsFields, Fixture, methodPopulateLookupFieldsFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateLookupFieldsFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_PopulateLookupFieldsFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodPopulateLookupFieldsFieldsPrametersTypes = null;
            object[] parametersOfPopulateLookupFieldsFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateLookupFieldsFields, methodPopulateLookupFieldsFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listLookupEditInstanceFixture, parametersOfPopulateLookupFieldsFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateLookupFieldsFields.ShouldBeNull();
            methodPopulateLookupFieldsFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateLookupFieldsFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_PopulateLookupFieldsFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPopulateLookupFieldsFieldsPrametersTypes = null;
            object[] parametersOfPopulateLookupFieldsFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listLookupEditInstance, MethodPopulateLookupFieldsFields, parametersOfPopulateLookupFieldsFields, methodPopulateLookupFieldsFieldsPrametersTypes);

            // Assert
            parametersOfPopulateLookupFieldsFields.ShouldBeNull();
            methodPopulateLookupFieldsFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateLookupFieldsFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_PopulateLookupFieldsFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPopulateLookupFieldsFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodPopulateLookupFieldsFields, Fixture, methodPopulateLookupFieldsFieldsPrametersTypes);

            // Assert
            methodPopulateLookupFieldsFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateLookupFieldsFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_PopulateLookupFieldsFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateLookupFieldsFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listLookupEditInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListLookupEdit_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listLookupEditInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listLookupEditInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listLookupEditInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlParentLookupField_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListLookupEdit_ddlParentLookupField_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlParentLookupField_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodddlParentLookupField_SelectedIndexChanged, Fixture, methodddlParentLookupField_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlParentLookupField_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_ddlParentLookupField_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlParentLookupField_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlParentLookupField_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodddlParentLookupField_SelectedIndexChanged, methodddlParentLookupField_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listLookupEditInstanceFixture, parametersOfddlParentLookupField_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddlParentLookupField_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlParentLookupField_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlParentLookupField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlParentLookupField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlParentLookupField_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ddlParentLookupField_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_ddlParentLookupField_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlParentLookupField_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlParentLookupField_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listLookupEditInstance, MethodddlParentLookupField_SelectedIndexChanged, parametersOfddlParentLookupField_SelectedIndexChanged, methodddlParentLookupField_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfddlParentLookupField_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlParentLookupField_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlParentLookupField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlParentLookupField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlParentLookupField_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlParentLookupField_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_ddlParentLookupField_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodddlParentLookupField_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddlParentLookupField_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_ddlParentLookupField_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodddlParentLookupField_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodddlParentLookupField_SelectedIndexChanged, Fixture, methodddlParentLookupField_SelectedIndexChangedPrametersTypes);

            // Assert
            methodddlParentLookupField_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlParentLookupField_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_ddlParentLookupField_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodddlParentLookupField_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listLookupEditInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListLookupEdit_Button1_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton1_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Button1_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton1_Click, methodButton1_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listLookupEditInstanceFixture, parametersOfButton1_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfButton1_Click.ShouldNotBeNull();
            parametersOfButton1_Click.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(parametersOfButton1_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Button1_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listLookupEditInstance, MethodButton1_Click, parametersOfButton1_Click, methodButton1_ClickPrametersTypes);

            // Assert
            parametersOfButton1_Click.ShouldNotBeNull();
            parametersOfButton1_Click.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(parametersOfButton1_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Button1_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Button1_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listLookupEditInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);

            // Assert
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListLookupEdit_Button1_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listLookupEditInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
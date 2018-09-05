using System;
using System.Data;
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

namespace WorkEnginePPM.Layouts.ppm
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Layouts.ppm.EditList" />)
    ///     and namespace <see cref="WorkEnginePPM.Layouts.ppm"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EditListTest : AbstractBaseSetupTypedTest<EditList>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EditList) Initializer

        private const string PropertyPageToRedirectOnCancel = "PageToRedirectOnCancel";
        private const string MethodButton1_Click = "Button1_Click";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodLoadWorkLists = "LoadWorkLists";
        private const string MethodloadPFEFields = "loadPFEFields";
        private const string MethodGridView1_RowDataBound = "GridView1_RowDataBound";
        private const string FielddtFields = "dtFields";
        private const string FieldarrMenus = "arrMenus";
        private const string FieldarrNonActiveXs = "arrNonActiveXs";
        private const string FieldsListName = "sListName";
        private Type _editListInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EditList _editListInstance;
        private EditList _editListInstanceFixture;

        #region General Initializer : Class (EditList) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EditList" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _editListInstanceType = typeof(EditList);
            _editListInstanceFixture = Create(true);
            _editListInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EditList)

        #region General Initializer : Class (EditList) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EditList" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodButton1_Click, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodLoadWorkLists, 0)]
        [TestCase(MethodloadPFEFields, 0)]
        [TestCase(MethodGridView1_RowDataBound, 0)]
        public void AUT_EditList_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_editListInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EditList) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EditList" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyPageToRedirectOnCancel)]
        public void AUT_EditList_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_editListInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EditList) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EditList" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FielddtFields)]
        [TestCase(FieldarrMenus)]
        [TestCase(FieldarrNonActiveXs)]
        [TestCase(FieldsListName)]
        public void AUT_EditList_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_editListInstanceFixture, 
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
        ///     Class (<see cref="EditList" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EditList_Is_Instance_Present_Test()
        {
            // Assert
            _editListInstanceType.ShouldNotBeNull();
            _editListInstance.ShouldNotBeNull();
            _editListInstanceFixture.ShouldNotBeNull();
            _editListInstance.ShouldBeAssignableTo<EditList>();
            _editListInstanceFixture.ShouldBeAssignableTo<EditList>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EditList) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EditList_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EditList instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _editListInstanceType.ShouldNotBeNull();
            _editListInstance.ShouldNotBeNull();
            _editListInstanceFixture.ShouldNotBeNull();
            _editListInstance.ShouldBeAssignableTo<EditList>();
            _editListInstanceFixture.ShouldBeAssignableTo<EditList>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EditList) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyPageToRedirectOnCancel)]
        public void AUT_EditList_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EditList, T>(_editListInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EditList) => Property (PageToRedirectOnCancel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EditList_Public_Class_PageToRedirectOnCancel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///      Class (<see cref="EditList" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodButton1_Click)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodLoadWorkLists)]
        [TestCase(MethodloadPFEFields)]
        [TestCase(MethodGridView1_RowDataBound)]
        public void AUT_EditList_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EditList>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditList_Button1_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton1_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_Button1_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton1_Click, methodButton1_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editListInstanceFixture, parametersOfButton1_Click);

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
        public void AUT_EditList_Button1_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editListInstance, MethodButton1_Click, parametersOfButton1_Click, methodButton1_ClickPrametersTypes);

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
        public void AUT_EditList_Button1_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_EditList_Button1_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);

            // Assert
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_Button1_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditList_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editListInstanceFixture, parametersOfPage_Load);

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
        public void AUT_EditList_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editListInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_EditList_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_EditList_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadWorkLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditList_LoadWorkLists_Method_Call_Internally(Type[] types)
        {
            var methodLoadWorkListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodLoadWorkLists, Fixture, methodLoadWorkListsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadWorkLists) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_LoadWorkLists_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var rootWeb = CreateType<SPWeb>();
            var oProjectList = CreateType<SPList>();
            var methodLoadWorkListsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };
            object[] parametersOfLoadWorkLists = { rootWeb, oProjectList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadWorkLists, methodLoadWorkListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editListInstanceFixture, parametersOfLoadWorkLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadWorkLists.ShouldNotBeNull();
            parametersOfLoadWorkLists.Length.ShouldBe(2);
            methodLoadWorkListsPrametersTypes.Length.ShouldBe(2);
            methodLoadWorkListsPrametersTypes.Length.ShouldBe(parametersOfLoadWorkLists.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadWorkLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_LoadWorkLists_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rootWeb = CreateType<SPWeb>();
            var oProjectList = CreateType<SPList>();
            var methodLoadWorkListsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };
            object[] parametersOfLoadWorkLists = { rootWeb, oProjectList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editListInstance, MethodLoadWorkLists, parametersOfLoadWorkLists, methodLoadWorkListsPrametersTypes);

            // Assert
            parametersOfLoadWorkLists.ShouldNotBeNull();
            parametersOfLoadWorkLists.Length.ShouldBe(2);
            methodLoadWorkListsPrametersTypes.Length.ShouldBe(2);
            methodLoadWorkListsPrametersTypes.Length.ShouldBe(parametersOfLoadWorkLists.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadWorkLists) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_LoadWorkLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadWorkLists, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadWorkLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_LoadWorkLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadWorkListsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodLoadWorkLists, Fixture, methodLoadWorkListsPrametersTypes);

            // Assert
            methodLoadWorkListsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadWorkLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_LoadWorkLists_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadWorkLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadPFEFields) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditList_loadPFEFields_Method_Call_Internally(Type[] types)
        {
            var methodloadPFEFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodloadPFEFields, Fixture, methodloadPFEFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (loadPFEFields) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_loadPFEFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var type = CreateType<int>();
            var rootWeb = CreateType<SPWeb>();
            var we = CreateType<PortfolioEngineCore.WEIntegration.WEIntegration>();
            var methodloadPFEFieldsPrametersTypes = new Type[] { typeof(int), typeof(SPWeb), typeof(PortfolioEngineCore.WEIntegration.WEIntegration) };
            object[] parametersOfloadPFEFields = { type, rootWeb, we };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodloadPFEFields, methodloadPFEFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EditList, DataTable>(_editListInstanceFixture, out exception1, parametersOfloadPFEFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EditList, DataTable>(_editListInstance, MethodloadPFEFields, parametersOfloadPFEFields, methodloadPFEFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfloadPFEFields.ShouldNotBeNull();
            parametersOfloadPFEFields.Length.ShouldBe(3);
            methodloadPFEFieldsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (loadPFEFields) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_loadPFEFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var type = CreateType<int>();
            var rootWeb = CreateType<SPWeb>();
            var we = CreateType<PortfolioEngineCore.WEIntegration.WEIntegration>();
            var methodloadPFEFieldsPrametersTypes = new Type[] { typeof(int), typeof(SPWeb), typeof(PortfolioEngineCore.WEIntegration.WEIntegration) };
            object[] parametersOfloadPFEFields = { type, rootWeb, we };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EditList, DataTable>(_editListInstance, MethodloadPFEFields, parametersOfloadPFEFields, methodloadPFEFieldsPrametersTypes);

            // Assert
            parametersOfloadPFEFields.ShouldNotBeNull();
            parametersOfloadPFEFields.Length.ShouldBe(3);
            methodloadPFEFieldsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadPFEFields) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_loadPFEFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodloadPFEFieldsPrametersTypes = new Type[] { typeof(int), typeof(SPWeb), typeof(PortfolioEngineCore.WEIntegration.WEIntegration) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodloadPFEFields, Fixture, methodloadPFEFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodloadPFEFieldsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (loadPFEFields) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_loadPFEFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadPFEFieldsPrametersTypes = new Type[] { typeof(int), typeof(SPWeb), typeof(PortfolioEngineCore.WEIntegration.WEIntegration) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodloadPFEFields, Fixture, methodloadPFEFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodloadPFEFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadPFEFields) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_loadPFEFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadPFEFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (loadPFEFields) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_loadPFEFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadPFEFields, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditList_GridView1_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGridView1_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_GridView1_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editListInstanceFixture, parametersOfGridView1_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView1_RowDataBound.ShouldNotBeNull();
            parametersOfGridView1_RowDataBound.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_GridView1_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editListInstance, MethodGridView1_RowDataBound, parametersOfGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGridView1_RowDataBound.ShouldNotBeNull();
            parametersOfGridView1_RowDataBound.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_GridView1_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_GridView1_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editListInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);

            // Assert
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditList_GridView1_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
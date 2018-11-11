using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.Layouts.ppm2
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Layouts.ppm2.grouppermissionform" />)
    ///     and namespace <see cref="WorkEnginePPM.Layouts.ppm2"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GrouppermissionformTest : AbstractBaseSetupTypedTest<grouppermissionform>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (grouppermissionform) Initializer

        private const string Propertyid = "id";
        private const string PropertyName = "Name";
        private const string PropertyDesc = "Desc";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodBuildGridLayout = "BuildGridLayout";
        private const string MethodBuildGridData = "BuildGridData";
        private const string MethodbtnDelete_Click = "btnDelete_Click";
        private const string MethodbtnOK_Click = "btnOK_Click";
        private const string MethodbtnClose_Click = "btnClose_Click";
        private const string FieldDialogTitle = "DialogTitle";
        private const string Fieldc_id = "c_id";
        private const string Fieldc_name = "c_name";
        private const string Fieldc_desc = "c_desc";
        private Type _grouppermissionformInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private grouppermissionform _grouppermissionformInstance;
        private grouppermissionform _grouppermissionformInstanceFixture;

        #region General Initializer : Class (grouppermissionform) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="grouppermissionform" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _grouppermissionformInstanceType = typeof(grouppermissionform);
            _grouppermissionformInstanceFixture = Create(true);
            _grouppermissionformInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (grouppermissionform)

        #region General Initializer : Class (grouppermissionform) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="grouppermissionform" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodBuildGridLayout, 0)]
        [TestCase(MethodBuildGridData, 0)]
        [TestCase(MethodbtnDelete_Click, 0)]
        [TestCase(MethodbtnOK_Click, 0)]
        [TestCase(MethodbtnClose_Click, 0)]
        public void AUT_Grouppermissionform_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_grouppermissionformInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (grouppermissionform) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="grouppermissionform" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Propertyid)]
        [TestCase(PropertyName)]
        [TestCase(PropertyDesc)]
        public void AUT_Grouppermissionform_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_grouppermissionformInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (grouppermissionform) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="grouppermissionform" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldDialogTitle)]
        [TestCase(Fieldc_id)]
        [TestCase(Fieldc_name)]
        [TestCase(Fieldc_desc)]
        public void AUT_Grouppermissionform_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_grouppermissionformInstanceFixture, 
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
        ///     Class (<see cref="grouppermissionform" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Grouppermissionform_Is_Instance_Present_Test()
        {
            // Assert
            _grouppermissionformInstanceType.ShouldNotBeNull();
            _grouppermissionformInstance.ShouldNotBeNull();
            _grouppermissionformInstanceFixture.ShouldNotBeNull();
            _grouppermissionformInstance.ShouldBeAssignableTo<grouppermissionform>();
            _grouppermissionformInstanceFixture.ShouldBeAssignableTo<grouppermissionform>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (grouppermissionform) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_grouppermissionform_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            grouppermissionform instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _grouppermissionformInstanceType.ShouldNotBeNull();
            _grouppermissionformInstance.ShouldNotBeNull();
            _grouppermissionformInstanceFixture.ShouldNotBeNull();
            _grouppermissionformInstance.ShouldBeAssignableTo<grouppermissionform>();
            _grouppermissionformInstanceFixture.ShouldBeAssignableTo<grouppermissionform>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (grouppermissionform) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , Propertyid)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyDesc)]
        public void AUT_Grouppermissionform_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<grouppermissionform, T>(_grouppermissionformInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (grouppermissionform) => Property (Desc) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Grouppermissionform_Public_Class_Desc_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDesc);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (grouppermissionform) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Grouppermissionform_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (grouppermissionform) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Grouppermissionform_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

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
        ///      Class (<see cref="grouppermissionform" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodBuildGridLayout)]
        [TestCase(MethodBuildGridData)]
        [TestCase(MethodbtnDelete_Click)]
        [TestCase(MethodbtnOK_Click)]
        [TestCase(MethodbtnClose_Click)]
        public void AUT_Grouppermissionform_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<grouppermissionform>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Grouppermissionform_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_grouppermissionformInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Grouppermissionform_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_grouppermissionformInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Grouppermissionform_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Grouppermissionform_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_grouppermissionformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Grouppermissionform_BuildGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodBuildGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodBuildGridLayout, Fixture, methodBuildGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridLayout_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodBuildGridLayoutPrametersTypes = null;
            object[] parametersOfBuildGridLayout = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildGridLayout, methodBuildGridLayoutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_grouppermissionformInstanceFixture, parametersOfBuildGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildGridLayout.ShouldBeNull();
            methodBuildGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildGridLayoutPrametersTypes = null;
            object[] parametersOfBuildGridLayout = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<grouppermissionform, CStruct>(_grouppermissionformInstance, MethodBuildGridLayout, parametersOfBuildGridLayout, methodBuildGridLayoutPrametersTypes);

            // Assert
            parametersOfBuildGridLayout.ShouldBeNull();
            methodBuildGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridLayout_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodBuildGridLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodBuildGridLayout, Fixture, methodBuildGridLayoutPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodBuildGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildGridLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodBuildGridLayout, Fixture, methodBuildGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_grouppermissionformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Grouppermissionform_BuildGridData_Method_Call_Internally(Type[] types)
        {
            var methodBuildGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodBuildGridData, Fixture, methodBuildGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodBuildGridDataPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfBuildGridData = { dt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildGridData, methodBuildGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_grouppermissionformInstanceFixture, parametersOfBuildGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildGridData.ShouldNotBeNull();
            parametersOfBuildGridData.Length.ShouldBe(1);
            methodBuildGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodBuildGridDataPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfBuildGridData = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<grouppermissionform, CStruct>(_grouppermissionformInstance, MethodBuildGridData, parametersOfBuildGridData, methodBuildGridDataPrametersTypes);

            // Assert
            parametersOfBuildGridData.ShouldNotBeNull();
            parametersOfBuildGridData.Length.ShouldBe(1);
            methodBuildGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildGridDataPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodBuildGridData, Fixture, methodBuildGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildGridDataPrametersTypes = new Type[] { typeof(DataTable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodBuildGridData, Fixture, methodBuildGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_grouppermissionformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_BuildGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Grouppermissionform_btnDelete_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnDelete_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodbtnDelete_Click, Fixture, methodbtnDelete_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnDelete_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnDelete_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnDelete_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnDelete_Click, methodbtnDelete_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_grouppermissionformInstanceFixture, parametersOfbtnDelete_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnDelete_Click.ShouldNotBeNull();
            parametersOfbtnDelete_Click.Length.ShouldBe(2);
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnDelete_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnDelete_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnDelete_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnDelete_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_grouppermissionformInstance, MethodbtnDelete_Click, parametersOfbtnDelete_Click, methodbtnDelete_ClickPrametersTypes);

            // Assert
            parametersOfbtnDelete_Click.ShouldNotBeNull();
            parametersOfbtnDelete_Click.Length.ShouldBe(2);
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnDelete_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnDelete_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnDelete_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnDelete_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnDelete_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodbtnDelete_Click, Fixture, methodbtnDelete_ClickPrametersTypes);

            // Assert
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnDelete_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnDelete_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_grouppermissionformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnOK_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Grouppermissionform_btnOK_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnOK_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodbtnOK_Click, Fixture, methodbtnOK_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnOK_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnOK_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnOK_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnOK_Click, methodbtnOK_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_grouppermissionformInstanceFixture, parametersOfbtnOK_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnOK_Click.ShouldNotBeNull();
            parametersOfbtnOK_Click.Length.ShouldBe(2);
            methodbtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnOK_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnOK_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnOK_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnOK_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnOK_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_grouppermissionformInstance, MethodbtnOK_Click, parametersOfbtnOK_Click, methodbtnOK_ClickPrametersTypes);

            // Assert
            parametersOfbtnOK_Click.ShouldNotBeNull();
            parametersOfbtnOK_Click.Length.ShouldBe(2);
            methodbtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnOK_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnOK_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnOK_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnOK_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnOK_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnOK_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnOK_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodbtnOK_Click, Fixture, methodbtnOK_ClickPrametersTypes);

            // Assert
            methodbtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnOK_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnOK_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnOK_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_grouppermissionformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnClose_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Grouppermissionform_btnClose_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnClose_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodbtnClose_Click, Fixture, methodbtnClose_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnClose_Click) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnClose_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnClose_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnClose_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnClose_Click, methodbtnClose_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_grouppermissionformInstanceFixture, parametersOfbtnClose_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnClose_Click.ShouldNotBeNull();
            parametersOfbtnClose_Click.Length.ShouldBe(2);
            methodbtnClose_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnClose_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnClose_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnClose_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnClose_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnClose_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnClose_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_grouppermissionformInstance, MethodbtnClose_Click, parametersOfbtnClose_Click, methodbtnClose_ClickPrametersTypes);

            // Assert
            parametersOfbtnClose_Click.ShouldNotBeNull();
            parametersOfbtnClose_Click.Length.ShouldBe(2);
            methodbtnClose_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnClose_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnClose_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnClose_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnClose_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnClose_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnClose_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnClose_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnClose_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_grouppermissionformInstance, MethodbtnClose_Click, Fixture, methodbtnClose_ClickPrametersTypes);

            // Assert
            methodbtnClose_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnClose_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Grouppermissionform_btnClose_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnClose_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_grouppermissionformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
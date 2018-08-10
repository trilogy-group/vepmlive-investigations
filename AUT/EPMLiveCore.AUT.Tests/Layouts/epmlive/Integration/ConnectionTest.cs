using System;
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

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.Integration.Connection" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive.Integration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ConnectionTest : AbstractBaseSetupTypedTest<Connection>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Connection) Initializer

        private const string PropertyPageToRedirectOnCancel = "PageToRedirectOnCancel";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodButton2_Click = "Button2_Click";
        private const string MethodButton1_Click = "Button1_Click";
        private const string FieldPageHead = "PageHead";
        private const string Fieldintlistid = "intlistid";
        private const string Fieldmoduleid = "moduleid";
        private const string Fieldintcore = "intcore";
        private const string Fieldintadmin = "intadmin";
        private Type _connectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Connection _connectionInstance;
        private Connection _connectionInstanceFixture;

        #region General Initializer : Class (Connection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Connection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _connectionInstanceType = typeof(Connection);
            _connectionInstanceFixture = Create(true);
            _connectionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Connection)

        #region General Initializer : Class (Connection) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Connection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodButton2_Click, 0)]
        [TestCase(MethodButton1_Click, 0)]
        public void AUT_Connection_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_connectionInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Connection) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Connection" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyPageToRedirectOnCancel)]
        public void AUT_Connection_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_connectionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Connection) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Connection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldPageHead)]
        [TestCase(Fieldintlistid)]
        [TestCase(Fieldmoduleid)]
        [TestCase(Fieldintcore)]
        [TestCase(Fieldintadmin)]
        public void AUT_Connection_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_connectionInstanceFixture, 
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
        ///     Class (<see cref="Connection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Connection_Is_Instance_Present_Test()
        {
            // Assert
            _connectionInstanceType.ShouldNotBeNull();
            _connectionInstance.ShouldNotBeNull();
            _connectionInstanceFixture.ShouldNotBeNull();
            _connectionInstance.ShouldBeAssignableTo<Connection>();
            _connectionInstanceFixture.ShouldBeAssignableTo<Connection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Connection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Connection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Connection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _connectionInstanceType.ShouldNotBeNull();
            _connectionInstance.ShouldNotBeNull();
            _connectionInstanceFixture.ShouldNotBeNull();
            _connectionInstance.ShouldBeAssignableTo<Connection>();
            _connectionInstanceFixture.ShouldBeAssignableTo<Connection>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Connection) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyPageToRedirectOnCancel)]
        public void AUT_Connection_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Connection, T>(_connectionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Connection) => Property (PageToRedirectOnCancel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Connection_Public_Class_PageToRedirectOnCancel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///      Class (<see cref="Connection" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodButton2_Click)]
        [TestCase(MethodButton1_Click)]
        public void AUT_Connection_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Connection>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Connection_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_connectionInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Connection_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_connectionInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Connection_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_connectionInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Connection_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Connection_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_connectionInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Connection_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_connectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Connection_Button2_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton2_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_connectionInstance, MethodButton2_Click, Fixture, methodButton2_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Connection_Button2_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton2_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton2_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton2_Click, methodButton2_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_connectionInstanceFixture, parametersOfButton2_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfButton2_Click.ShouldNotBeNull();
            parametersOfButton2_Click.Length.ShouldBe(2);
            methodButton2_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton2_ClickPrametersTypes.Length.ShouldBe(parametersOfButton2_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Connection_Button2_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton2_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton2_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_connectionInstance, MethodButton2_Click, parametersOfButton2_Click, methodButton2_ClickPrametersTypes);

            // Assert
            parametersOfButton2_Click.ShouldNotBeNull();
            parametersOfButton2_Click.Length.ShouldBe(2);
            methodButton2_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton2_ClickPrametersTypes.Length.ShouldBe(parametersOfButton2_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Connection_Button2_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodButton2_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Connection_Button2_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton2_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_connectionInstance, MethodButton2_Click, Fixture, methodButton2_ClickPrametersTypes);

            // Assert
            methodButton2_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Connection_Button2_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton2_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_connectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Connection_Button1_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton1_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_connectionInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Connection_Button1_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton1_Click, methodButton1_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_connectionInstanceFixture, parametersOfButton1_Click);

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
        public void AUT_Connection_Button1_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_connectionInstance, MethodButton1_Click, parametersOfButton1_Click, methodButton1_ClickPrametersTypes);

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
        public void AUT_Connection_Button1_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Connection_Button1_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_connectionInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);

            // Assert
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Connection_Button1_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_connectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
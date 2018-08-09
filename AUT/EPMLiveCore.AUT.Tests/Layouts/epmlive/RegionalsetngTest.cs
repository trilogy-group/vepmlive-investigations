using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.regionalsetng" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class RegionalsetngTest : AbstractBaseSetupTypedTest<regionalsetng>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (regionalsetng) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodBtnUpdateRegionalSettings_Click = "BtnUpdateRegionalSettings_Click";
        private const string MethodCancelButtonClick = "CancelButtonClick";
        private const string MethodDdlWebLCIDIndex_Changed = "DdlWebLCIDIndex_Changed";
        private const string MethodDdlwebCalTypeWithROCIndex_Changed = "DdlwebCalTypeWithROCIndex_Changed";
        private const string MethodDdlwebCalTypeIndex_Changed = "DdlwebCalTypeIndex_Changed";
        private Type _regionalsetngInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private regionalsetng _regionalsetngInstance;
        private regionalsetng _regionalsetngInstanceFixture;

        #region General Initializer : Class (regionalsetng) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="regionalsetng" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _regionalsetngInstanceType = typeof(regionalsetng);
            _regionalsetngInstanceFixture = Create(true);
            _regionalsetngInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (regionalsetng)

        #region General Initializer : Class (regionalsetng) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="regionalsetng" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodBtnUpdateRegionalSettings_Click, 0)]
        [TestCase(MethodCancelButtonClick, 0)]
        [TestCase(MethodDdlWebLCIDIndex_Changed, 0)]
        [TestCase(MethodDdlwebCalTypeWithROCIndex_Changed, 0)]
        [TestCase(MethodDdlwebCalTypeIndex_Changed, 0)]
        public void AUT_Regionalsetng_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_regionalsetngInstanceFixture, 
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
        ///     Class (<see cref="regionalsetng" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Regionalsetng_Is_Instance_Present_Test()
        {
            // Assert
            _regionalsetngInstanceType.ShouldNotBeNull();
            _regionalsetngInstance.ShouldNotBeNull();
            _regionalsetngInstanceFixture.ShouldNotBeNull();
            _regionalsetngInstance.ShouldBeAssignableTo<regionalsetng>();
            _regionalsetngInstanceFixture.ShouldBeAssignableTo<regionalsetng>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (regionalsetng) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_regionalsetng_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            regionalsetng instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _regionalsetngInstanceType.ShouldNotBeNull();
            _regionalsetngInstance.ShouldNotBeNull();
            _regionalsetngInstanceFixture.ShouldNotBeNull();
            _regionalsetngInstance.ShouldBeAssignableTo<regionalsetng>();
            _regionalsetngInstanceFixture.ShouldBeAssignableTo<regionalsetng>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="regionalsetng" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodBtnUpdateRegionalSettings_Click)]
        [TestCase(MethodCancelButtonClick)]
        [TestCase(MethodDdlWebLCIDIndex_Changed)]
        [TestCase(MethodDdlwebCalTypeWithROCIndex_Changed)]
        [TestCase(MethodDdlwebCalTypeIndex_Changed)]
        public void AUT_Regionalsetng_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<regionalsetng>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Regionalsetng_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_regionalsetngInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Regionalsetng_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_regionalsetngInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Regionalsetng_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Regionalsetng_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_regionalsetngInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnUpdateRegionalSettings_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Regionalsetng_BtnUpdateRegionalSettings_Click_Method_Call_Internally(Type[] types)
        {
            var methodBtnUpdateRegionalSettings_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodBtnUpdateRegionalSettings_Click, Fixture, methodBtnUpdateRegionalSettings_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (BtnUpdateRegionalSettings_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_BtnUpdateRegionalSettings_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnUpdateRegionalSettings_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnUpdateRegionalSettings_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBtnUpdateRegionalSettings_Click, methodBtnUpdateRegionalSettings_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_regionalsetngInstanceFixture, parametersOfBtnUpdateRegionalSettings_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBtnUpdateRegionalSettings_Click.ShouldNotBeNull();
            parametersOfBtnUpdateRegionalSettings_Click.Length.ShouldBe(2);
            methodBtnUpdateRegionalSettings_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnUpdateRegionalSettings_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnUpdateRegionalSettings_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BtnUpdateRegionalSettings_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_BtnUpdateRegionalSettings_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnUpdateRegionalSettings_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnUpdateRegionalSettings_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_regionalsetngInstance, MethodBtnUpdateRegionalSettings_Click, parametersOfBtnUpdateRegionalSettings_Click, methodBtnUpdateRegionalSettings_ClickPrametersTypes);

            // Assert
            parametersOfBtnUpdateRegionalSettings_Click.ShouldNotBeNull();
            parametersOfBtnUpdateRegionalSettings_Click.Length.ShouldBe(2);
            methodBtnUpdateRegionalSettings_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnUpdateRegionalSettings_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnUpdateRegionalSettings_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnUpdateRegionalSettings_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_BtnUpdateRegionalSettings_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBtnUpdateRegionalSettings_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BtnUpdateRegionalSettings_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_BtnUpdateRegionalSettings_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBtnUpdateRegionalSettings_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodBtnUpdateRegionalSettings_Click, Fixture, methodBtnUpdateRegionalSettings_ClickPrametersTypes);

            // Assert
            methodBtnUpdateRegionalSettings_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnUpdateRegionalSettings_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_BtnUpdateRegionalSettings_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBtnUpdateRegionalSettings_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_regionalsetngInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CancelButtonClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Regionalsetng_CancelButtonClick_Method_Call_Internally(Type[] types)
        {
            var methodCancelButtonClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodCancelButtonClick, Fixture, methodCancelButtonClickPrametersTypes);
        }

        #endregion

        #region Method Call : (CancelButtonClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_CancelButtonClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodCancelButtonClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfCancelButtonClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCancelButtonClick, methodCancelButtonClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_regionalsetngInstanceFixture, parametersOfCancelButtonClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCancelButtonClick.ShouldNotBeNull();
            parametersOfCancelButtonClick.Length.ShouldBe(2);
            methodCancelButtonClickPrametersTypes.Length.ShouldBe(2);
            methodCancelButtonClickPrametersTypes.Length.ShouldBe(parametersOfCancelButtonClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CancelButtonClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_CancelButtonClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodCancelButtonClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfCancelButtonClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_regionalsetngInstance, MethodCancelButtonClick, parametersOfCancelButtonClick, methodCancelButtonClickPrametersTypes);

            // Assert
            parametersOfCancelButtonClick.ShouldNotBeNull();
            parametersOfCancelButtonClick.Length.ShouldBe(2);
            methodCancelButtonClickPrametersTypes.Length.ShouldBe(2);
            methodCancelButtonClickPrametersTypes.Length.ShouldBe(parametersOfCancelButtonClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CancelButtonClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_CancelButtonClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCancelButtonClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CancelButtonClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_CancelButtonClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCancelButtonClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodCancelButtonClick, Fixture, methodCancelButtonClickPrametersTypes);

            // Assert
            methodCancelButtonClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CancelButtonClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_CancelButtonClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCancelButtonClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_regionalsetngInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlWebLCIDIndex_Changed) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Regionalsetng_DdlWebLCIDIndex_Changed_Method_Call_Internally(Type[] types)
        {
            var methodDdlWebLCIDIndex_ChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodDdlWebLCIDIndex_Changed, Fixture, methodDdlWebLCIDIndex_ChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (DdlWebLCIDIndex_Changed) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlWebLCIDIndex_Changed_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodDdlWebLCIDIndex_ChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfDdlWebLCIDIndex_Changed = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDdlWebLCIDIndex_Changed, methodDdlWebLCIDIndex_ChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_regionalsetngInstanceFixture, parametersOfDdlWebLCIDIndex_Changed);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDdlWebLCIDIndex_Changed.ShouldNotBeNull();
            parametersOfDdlWebLCIDIndex_Changed.Length.ShouldBe(2);
            methodDdlWebLCIDIndex_ChangedPrametersTypes.Length.ShouldBe(2);
            methodDdlWebLCIDIndex_ChangedPrametersTypes.Length.ShouldBe(parametersOfDdlWebLCIDIndex_Changed.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlWebLCIDIndex_Changed) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlWebLCIDIndex_Changed_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodDdlWebLCIDIndex_ChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfDdlWebLCIDIndex_Changed = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_regionalsetngInstance, MethodDdlWebLCIDIndex_Changed, parametersOfDdlWebLCIDIndex_Changed, methodDdlWebLCIDIndex_ChangedPrametersTypes);

            // Assert
            parametersOfDdlWebLCIDIndex_Changed.ShouldNotBeNull();
            parametersOfDdlWebLCIDIndex_Changed.Length.ShouldBe(2);
            methodDdlWebLCIDIndex_ChangedPrametersTypes.Length.ShouldBe(2);
            methodDdlWebLCIDIndex_ChangedPrametersTypes.Length.ShouldBe(parametersOfDdlWebLCIDIndex_Changed.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlWebLCIDIndex_Changed) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlWebLCIDIndex_Changed_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDdlWebLCIDIndex_Changed, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DdlWebLCIDIndex_Changed) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlWebLCIDIndex_Changed_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDdlWebLCIDIndex_ChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodDdlWebLCIDIndex_Changed, Fixture, methodDdlWebLCIDIndex_ChangedPrametersTypes);

            // Assert
            methodDdlWebLCIDIndex_ChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlWebLCIDIndex_Changed) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlWebLCIDIndex_Changed_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDdlWebLCIDIndex_Changed, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_regionalsetngInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeWithROCIndex_Changed) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Regionalsetng_DdlwebCalTypeWithROCIndex_Changed_Method_Call_Internally(Type[] types)
        {
            var methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodDdlwebCalTypeWithROCIndex_Changed, Fixture, methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeWithROCIndex_Changed) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeWithROCIndex_Changed_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfDdlwebCalTypeWithROCIndex_Changed = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDdlwebCalTypeWithROCIndex_Changed, methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_regionalsetngInstanceFixture, parametersOfDdlwebCalTypeWithROCIndex_Changed);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDdlwebCalTypeWithROCIndex_Changed.ShouldNotBeNull();
            parametersOfDdlwebCalTypeWithROCIndex_Changed.Length.ShouldBe(2);
            methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes.Length.ShouldBe(2);
            methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes.Length.ShouldBe(parametersOfDdlwebCalTypeWithROCIndex_Changed.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeWithROCIndex_Changed) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeWithROCIndex_Changed_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfDdlwebCalTypeWithROCIndex_Changed = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_regionalsetngInstance, MethodDdlwebCalTypeWithROCIndex_Changed, parametersOfDdlwebCalTypeWithROCIndex_Changed, methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes);

            // Assert
            parametersOfDdlwebCalTypeWithROCIndex_Changed.ShouldNotBeNull();
            parametersOfDdlwebCalTypeWithROCIndex_Changed.Length.ShouldBe(2);
            methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes.Length.ShouldBe(2);
            methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes.Length.ShouldBe(parametersOfDdlwebCalTypeWithROCIndex_Changed.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeWithROCIndex_Changed) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeWithROCIndex_Changed_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDdlwebCalTypeWithROCIndex_Changed, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeWithROCIndex_Changed) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeWithROCIndex_Changed_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodDdlwebCalTypeWithROCIndex_Changed, Fixture, methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes);

            // Assert
            methodDdlwebCalTypeWithROCIndex_ChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeWithROCIndex_Changed) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeWithROCIndex_Changed_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDdlwebCalTypeWithROCIndex_Changed, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_regionalsetngInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeIndex_Changed) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Regionalsetng_DdlwebCalTypeIndex_Changed_Method_Call_Internally(Type[] types)
        {
            var methodDdlwebCalTypeIndex_ChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodDdlwebCalTypeIndex_Changed, Fixture, methodDdlwebCalTypeIndex_ChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeIndex_Changed) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeIndex_Changed_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodDdlwebCalTypeIndex_ChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfDdlwebCalTypeIndex_Changed = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDdlwebCalTypeIndex_Changed, methodDdlwebCalTypeIndex_ChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_regionalsetngInstanceFixture, parametersOfDdlwebCalTypeIndex_Changed);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDdlwebCalTypeIndex_Changed.ShouldNotBeNull();
            parametersOfDdlwebCalTypeIndex_Changed.Length.ShouldBe(2);
            methodDdlwebCalTypeIndex_ChangedPrametersTypes.Length.ShouldBe(2);
            methodDdlwebCalTypeIndex_ChangedPrametersTypes.Length.ShouldBe(parametersOfDdlwebCalTypeIndex_Changed.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeIndex_Changed) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeIndex_Changed_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodDdlwebCalTypeIndex_ChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfDdlwebCalTypeIndex_Changed = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_regionalsetngInstance, MethodDdlwebCalTypeIndex_Changed, parametersOfDdlwebCalTypeIndex_Changed, methodDdlwebCalTypeIndex_ChangedPrametersTypes);

            // Assert
            parametersOfDdlwebCalTypeIndex_Changed.ShouldNotBeNull();
            parametersOfDdlwebCalTypeIndex_Changed.Length.ShouldBe(2);
            methodDdlwebCalTypeIndex_ChangedPrametersTypes.Length.ShouldBe(2);
            methodDdlwebCalTypeIndex_ChangedPrametersTypes.Length.ShouldBe(parametersOfDdlwebCalTypeIndex_Changed.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeIndex_Changed) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeIndex_Changed_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDdlwebCalTypeIndex_Changed, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeIndex_Changed) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeIndex_Changed_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDdlwebCalTypeIndex_ChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_regionalsetngInstance, MethodDdlwebCalTypeIndex_Changed, Fixture, methodDdlwebCalTypeIndex_ChangedPrametersTypes);

            // Assert
            methodDdlwebCalTypeIndex_ChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DdlwebCalTypeIndex_Changed) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Regionalsetng_DdlwebCalTypeIndex_Changed_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDdlwebCalTypeIndex_Changed, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_regionalsetngInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
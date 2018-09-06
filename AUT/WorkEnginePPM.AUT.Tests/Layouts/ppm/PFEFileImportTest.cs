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

namespace WorkEnginePPM.Layouts.ppm
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Layouts.ppm.PFEFileImport" />)
    ///     and namespace <see cref="WorkEnginePPM.Layouts.ppm"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PFEFileImportTest : AbstractBaseSetupTypedTest<PFEFileImport>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PFEFileImport) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodImportButtonOnClick = "ImportButtonOnClick";
        private Type _pFEFileImportInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PFEFileImport _pFEFileImportInstance;
        private PFEFileImport _pFEFileImportInstanceFixture;

        #region General Initializer : Class (PFEFileImport) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PFEFileImport" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pFEFileImportInstanceType = typeof(PFEFileImport);
            _pFEFileImportInstanceFixture = Create(true);
            _pFEFileImportInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PFEFileImport)

        #region General Initializer : Class (PFEFileImport) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PFEFileImport" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodImportButtonOnClick, 0)]
        public void AUT_PFEFileImport_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_pFEFileImportInstanceFixture, 
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
        ///     Class (<see cref="PFEFileImport" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PFEFileImport_Is_Instance_Present_Test()
        {
            // Assert
            _pFEFileImportInstanceType.ShouldNotBeNull();
            _pFEFileImportInstance.ShouldNotBeNull();
            _pFEFileImportInstanceFixture.ShouldNotBeNull();
            _pFEFileImportInstance.ShouldBeAssignableTo<PFEFileImport>();
            _pFEFileImportInstanceFixture.ShouldBeAssignableTo<PFEFileImport>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PFEFileImport) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PFEFileImport_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PFEFileImport instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _pFEFileImportInstanceType.ShouldNotBeNull();
            _pFEFileImportInstance.ShouldNotBeNull();
            _pFEFileImportInstanceFixture.ShouldNotBeNull();
            _pFEFileImportInstance.ShouldBeAssignableTo<PFEFileImport>();
            _pFEFileImportInstanceFixture.ShouldBeAssignableTo<PFEFileImport>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="PFEFileImport" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodImportButtonOnClick)]
        public void AUT_PFEFileImport_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PFEFileImport>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEFileImport_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEFileImportInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEFileImport_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pFEFileImportInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEFileImport_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pFEFileImportInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_PFEFileImport_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PFEFileImport_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEFileImportInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEFileImport_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEFileImportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportButtonOnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEFileImport_ImportButtonOnClick_Method_Call_Internally(Type[] types)
        {
            var methodImportButtonOnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEFileImportInstance, MethodImportButtonOnClick, Fixture, methodImportButtonOnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportButtonOnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEFileImport_ImportButtonOnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodImportButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfImportButtonOnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodImportButtonOnClick, methodImportButtonOnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pFEFileImportInstanceFixture, parametersOfImportButtonOnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfImportButtonOnClick.ShouldNotBeNull();
            parametersOfImportButtonOnClick.Length.ShouldBe(2);
            methodImportButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodImportButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfImportButtonOnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ImportButtonOnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEFileImport_ImportButtonOnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodImportButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfImportButtonOnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pFEFileImportInstance, MethodImportButtonOnClick, parametersOfImportButtonOnClick, methodImportButtonOnClickPrametersTypes);

            // Assert
            parametersOfImportButtonOnClick.ShouldNotBeNull();
            parametersOfImportButtonOnClick.Length.ShouldBe(2);
            methodImportButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodImportButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfImportButtonOnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportButtonOnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEFileImport_ImportButtonOnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodImportButtonOnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportButtonOnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEFileImport_ImportButtonOnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodImportButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEFileImportInstance, MethodImportButtonOnClick, Fixture, methodImportButtonOnClickPrametersTypes);

            // Assert
            methodImportButtonOnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportButtonOnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEFileImport_ImportButtonOnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodImportButtonOnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEFileImportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
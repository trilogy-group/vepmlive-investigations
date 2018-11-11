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

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.ImportResources" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ImportResourcesTest : AbstractBaseSetupTypedTest<ImportResources>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ImportResources) Initializer

        private const string MethodImportButtonOnClick = "ImportButtonOnClick";
        private const string MethodIsImportResourceAlreadyRunning = "IsImportResourceAlreadyRunning";
        private const string MethodImportMain = "ImportMain";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodBtnOk_Click = "BtnOk_Click";
        private const string FieldisRunning = "isRunning";
        private const string FieldjobUid = "jobUid";
        private const string FieldpercentComplete = "percentComplete";
        private const string Fieldmsg = "msg";
        private Type _importResourcesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ImportResources _importResourcesInstance;
        private ImportResources _importResourcesInstanceFixture;

        #region General Initializer : Class (ImportResources) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ImportResources" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _importResourcesInstanceType = typeof(ImportResources);
            _importResourcesInstanceFixture = Create(true);
            _importResourcesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ImportResources)

        #region General Initializer : Class (ImportResources) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ImportResources" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodImportButtonOnClick, 0)]
        [TestCase(MethodIsImportResourceAlreadyRunning, 0)]
        [TestCase(MethodImportMain, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodBtnOk_Click, 0)]
        public void AUT_ImportResources_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_importResourcesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ImportResources) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ImportResources" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldisRunning)]
        [TestCase(FieldjobUid)]
        [TestCase(FieldpercentComplete)]
        [TestCase(Fieldmsg)]
        public void AUT_ImportResources_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_importResourcesInstanceFixture, 
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
        ///     Class (<see cref="ImportResources" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ImportResources_Is_Instance_Present_Test()
        {
            // Assert
            _importResourcesInstanceType.ShouldNotBeNull();
            _importResourcesInstance.ShouldNotBeNull();
            _importResourcesInstanceFixture.ShouldNotBeNull();
            _importResourcesInstance.ShouldBeAssignableTo<ImportResources>();
            _importResourcesInstanceFixture.ShouldBeAssignableTo<ImportResources>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ImportResources) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ImportResources_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ImportResources instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _importResourcesInstanceType.ShouldNotBeNull();
            _importResourcesInstance.ShouldNotBeNull();
            _importResourcesInstanceFixture.ShouldNotBeNull();
            _importResourcesInstance.ShouldBeAssignableTo<ImportResources>();
            _importResourcesInstanceFixture.ShouldBeAssignableTo<ImportResources>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ImportResources" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodImportButtonOnClick)]
        [TestCase(MethodIsImportResourceAlreadyRunning)]
        [TestCase(MethodImportMain)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodBtnOk_Click)]
        public void AUT_ImportResources_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ImportResources>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ImportButtonOnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportResources_ImportButtonOnClick_Method_Call_Internally(Type[] types)
        {
            var methodImportButtonOnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodImportButtonOnClick, Fixture, methodImportButtonOnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportButtonOnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_ImportButtonOnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodImportButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfImportButtonOnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodImportButtonOnClick, methodImportButtonOnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_importResourcesInstanceFixture, parametersOfImportButtonOnClick);

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
        public void AUT_ImportResources_ImportButtonOnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodImportButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfImportButtonOnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_importResourcesInstance, MethodImportButtonOnClick, parametersOfImportButtonOnClick, methodImportButtonOnClickPrametersTypes);

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
        public void AUT_ImportResources_ImportButtonOnClick_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ImportResources_ImportButtonOnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodImportButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodImportButtonOnClick, Fixture, methodImportButtonOnClickPrametersTypes);

            // Assert
            methodImportButtonOnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportButtonOnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_ImportButtonOnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodImportButtonOnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_importResourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportResources_IsImportResourceAlreadyRunning_Method_Call_Internally(Type[] types)
        {
            var methodIsImportResourceAlreadyRunningPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodIsImportResourceAlreadyRunning, Fixture, methodIsImportResourceAlreadyRunningPrametersTypes);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_IsImportResourceAlreadyRunning_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodIsImportResourceAlreadyRunningPrametersTypes = null;
            object[] parametersOfIsImportResourceAlreadyRunning = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsImportResourceAlreadyRunning, methodIsImportResourceAlreadyRunningPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_importResourcesInstanceFixture, parametersOfIsImportResourceAlreadyRunning);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsImportResourceAlreadyRunning.ShouldBeNull();
            methodIsImportResourceAlreadyRunningPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_IsImportResourceAlreadyRunning_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsImportResourceAlreadyRunningPrametersTypes = null;
            object[] parametersOfIsImportResourceAlreadyRunning = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_importResourcesInstance, MethodIsImportResourceAlreadyRunning, parametersOfIsImportResourceAlreadyRunning, methodIsImportResourceAlreadyRunningPrametersTypes);

            // Assert
            parametersOfIsImportResourceAlreadyRunning.ShouldBeNull();
            methodIsImportResourceAlreadyRunningPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_IsImportResourceAlreadyRunning_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsImportResourceAlreadyRunningPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodIsImportResourceAlreadyRunning, Fixture, methodIsImportResourceAlreadyRunningPrametersTypes);

            // Assert
            methodIsImportResourceAlreadyRunningPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_IsImportResourceAlreadyRunning_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsImportResourceAlreadyRunning, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_importResourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportMain) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportResources_ImportMain_Method_Call_Internally(Type[] types)
        {
            var methodImportMainPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodImportMain, Fixture, methodImportMainPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportMain) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_ImportMain_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var cancelExistingJob = CreateType<bool>();
            var methodImportMainPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfImportMain = { cancelExistingJob };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodImportMain, methodImportMainPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_importResourcesInstanceFixture, parametersOfImportMain);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfImportMain.ShouldNotBeNull();
            parametersOfImportMain.Length.ShouldBe(1);
            methodImportMainPrametersTypes.Length.ShouldBe(1);
            methodImportMainPrametersTypes.Length.ShouldBe(parametersOfImportMain.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ImportMain) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_ImportMain_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cancelExistingJob = CreateType<bool>();
            var methodImportMainPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfImportMain = { cancelExistingJob };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_importResourcesInstance, MethodImportMain, parametersOfImportMain, methodImportMainPrametersTypes);

            // Assert
            parametersOfImportMain.ShouldNotBeNull();
            parametersOfImportMain.Length.ShouldBe(1);
            methodImportMainPrametersTypes.Length.ShouldBe(1);
            methodImportMainPrametersTypes.Length.ShouldBe(parametersOfImportMain.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportMain) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_ImportMain_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodImportMain, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportMain) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_ImportMain_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodImportMainPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodImportMain, Fixture, methodImportMainPrametersTypes);

            // Assert
            methodImportMainPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportMain) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_ImportMain_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodImportMain, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_importResourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportResources_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_importResourcesInstanceFixture, parametersOfPage_Load);

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
        public void AUT_ImportResources_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_importResourcesInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_ImportResources_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ImportResources_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_importResourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOk_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportResources_BtnOk_Click_Method_Call_Internally(Type[] types)
        {
            var methodBtnOk_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodBtnOk_Click, Fixture, methodBtnOk_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (BtnOk_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_BtnOk_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOk_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOk_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBtnOk_Click, methodBtnOk_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_importResourcesInstanceFixture, parametersOfBtnOk_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBtnOk_Click.ShouldNotBeNull();
            parametersOfBtnOk_Click.Length.ShouldBe(2);
            methodBtnOk_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnOk_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnOk_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BtnOk_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_BtnOk_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOk_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOk_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_importResourcesInstance, MethodBtnOk_Click, parametersOfBtnOk_Click, methodBtnOk_ClickPrametersTypes);

            // Assert
            parametersOfBtnOk_Click.ShouldNotBeNull();
            parametersOfBtnOk_Click.Length.ShouldBe(2);
            methodBtnOk_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnOk_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnOk_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOk_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_BtnOk_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBtnOk_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BtnOk_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_BtnOk_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBtnOk_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importResourcesInstance, MethodBtnOk_Click, Fixture, methodBtnOk_ClickPrametersTypes);

            // Assert
            methodBtnOk_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOk_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportResources_BtnOk_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBtnOk_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_importResourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
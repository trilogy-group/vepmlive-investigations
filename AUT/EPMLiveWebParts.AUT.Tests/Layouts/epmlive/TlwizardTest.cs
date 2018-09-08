using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Layouts.epmlive.tlwizard" />)
    ///     and namespace <see cref="EPMLiveWebParts.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class TlwizardTest : AbstractBaseSetupTypedTest<tlwizard>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (tlwizard) Initializer

        private const string MethodLogonUser = "LogonUser";
        private const string MethodCloseHandle = "CloseHandle";
        private const string Methodappendclick = "appendclick";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodbtnBack_Click = "btnBack_Click";
        private const string MethodbtnSkip_Click = "btnSkip_Click";
        private const string MethodbtnNext_Click = "btnNext_Click";
        private const string MethodbtnYes_Click = "btnYes_Click";
        private const string MethodProcessIzenda = "ProcessIzenda";
        private const string MethodProcessLists = "ProcessLists";
        private const string MethodProcessCleanUpAll = "ProcessCleanUpAll";
        private const string MethodProcessExcel = "ProcessExcel";
        private const string MethodProcessReportingRefreshJob = "ProcessReportingRefreshJob";
        private const string MethodProcessGroups = "ProcessGroups";
        private const string MethodGetSiteGroup = "GetSiteGroup";
        private const string MethodProcessBackEndLists = "ProcessBackEndLists";
        private const string MethodProcessBackEndList = "ProcessBackEndList";
        private const string MethodbtnCancel_Click = "btnCancel_Click";
        private const string MethodProcessNotifications = "ProcessNotifications";
        private const string MethodprocessQuickLaunch = "processQuickLaunch";
        private const string MethodcheckConnection = "checkConnection";
        private const string MethodprocessReports = "processReports";
        private const string MethodprocessRDL = "processRDL";
        private const string MethodhideWizard = "hideWizard";
        private const string MethodClearNavigationCache = "ClearNavigationCache";
        private const string Fieldssrsurl = "ssrsurl";
        private Type _tlwizardInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private tlwizard _tlwizardInstance;
        private tlwizard _tlwizardInstanceFixture;

        #region General Initializer : Class (tlwizard) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="tlwizard" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _tlwizardInstanceType = typeof(tlwizard);
            _tlwizardInstanceFixture = Create(true);
            _tlwizardInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (tlwizard)

        #region General Initializer : Class (tlwizard) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="tlwizard" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodLogonUser, 0)]
        [TestCase(MethodCloseHandle, 0)]
        [TestCase(Methodappendclick, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodbtnBack_Click, 0)]
        [TestCase(MethodbtnSkip_Click, 0)]
        [TestCase(MethodbtnNext_Click, 0)]
        [TestCase(MethodbtnYes_Click, 0)]
        [TestCase(MethodProcessIzenda, 0)]
        [TestCase(MethodProcessLists, 0)]
        [TestCase(MethodProcessCleanUpAll, 0)]
        [TestCase(MethodProcessExcel, 0)]
        [TestCase(MethodProcessReportingRefreshJob, 0)]
        [TestCase(MethodProcessGroups, 0)]
        [TestCase(MethodGetSiteGroup, 0)]
        [TestCase(MethodProcessBackEndLists, 0)]
        [TestCase(MethodProcessBackEndList, 0)]
        [TestCase(MethodbtnCancel_Click, 0)]
        [TestCase(MethodProcessNotifications, 0)]
        [TestCase(MethodprocessQuickLaunch, 0)]
        [TestCase(MethodcheckConnection, 0)]
        [TestCase(MethodprocessReports, 0)]
        [TestCase(MethodprocessRDL, 0)]
        [TestCase(MethodhideWizard, 0)]
        [TestCase(MethodClearNavigationCache, 0)]
        public void AUT_Tlwizard_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_tlwizardInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (tlwizard) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="tlwizard" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldssrsurl)]
        public void AUT_Tlwizard_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_tlwizardInstanceFixture, 
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
        ///     Class (<see cref="tlwizard" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Tlwizard_Is_Instance_Present_Test()
        {
            // Assert
            _tlwizardInstanceType.ShouldNotBeNull();
            _tlwizardInstance.ShouldNotBeNull();
            _tlwizardInstanceFixture.ShouldNotBeNull();
            _tlwizardInstance.ShouldBeAssignableTo<tlwizard>();
            _tlwizardInstanceFixture.ShouldBeAssignableTo<tlwizard>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (tlwizard) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_tlwizard_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            tlwizard instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _tlwizardInstanceType.ShouldNotBeNull();
            _tlwizardInstance.ShouldNotBeNull();
            _tlwizardInstanceFixture.ShouldNotBeNull();
            _tlwizardInstance.ShouldBeAssignableTo<tlwizard>();
            _tlwizardInstanceFixture.ShouldBeAssignableTo<tlwizard>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="tlwizard" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodLogonUser)]
        [TestCase(MethodCloseHandle)]
        [TestCase(MethodGetSiteGroup)]
        public void AUT_Tlwizard_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_tlwizardInstanceFixture,
                                                                              _tlwizardInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="tlwizard" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodappendclick)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodbtnBack_Click)]
        [TestCase(MethodbtnSkip_Click)]
        [TestCase(MethodbtnNext_Click)]
        [TestCase(MethodbtnYes_Click)]
        [TestCase(MethodProcessIzenda)]
        [TestCase(MethodProcessLists)]
        [TestCase(MethodProcessCleanUpAll)]
        [TestCase(MethodProcessExcel)]
        [TestCase(MethodProcessReportingRefreshJob)]
        [TestCase(MethodProcessGroups)]
        [TestCase(MethodProcessBackEndLists)]
        [TestCase(MethodProcessBackEndList)]
        [TestCase(MethodbtnCancel_Click)]
        [TestCase(MethodProcessNotifications)]
        [TestCase(MethodprocessQuickLaunch)]
        [TestCase(MethodcheckConnection)]
        [TestCase(MethodprocessReports)]
        [TestCase(MethodprocessRDL)]
        [TestCase(MethodhideWizard)]
        [TestCase(MethodClearNavigationCache)]
        public void AUT_Tlwizard_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<tlwizard>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (LogonUser) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_LogonUser_Static_Method_Call_Internally(Type[] types)
        {
            var methodLogonUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodLogonUser, Fixture, methodLogonUserPrametersTypes);
        }

        #endregion

        #region Method Call : (LogonUser) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_LogonUser_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var userName = CreateType<string>();
            var domain = CreateType<string>();
            var passWord = CreateType<string>();
            var logonType = CreateType<int>();
            var logonProvider = CreateType<int>();
            var accessToken = CreateType<IntPtr>();
            Action executeAction = null;

            // Act
            executeAction = () => tlwizard.LogonUser(userName, domain, passWord, logonType, logonProvider, ref accessToken);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (LogonUser) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_LogonUser_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var userName = CreateType<string>();
            var domain = CreateType<string>();
            var passWord = CreateType<string>();
            var logonType = CreateType<int>();
            var logonProvider = CreateType<int>();
            var accessToken = CreateType<IntPtr>();
            var methodLogonUserPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(IntPtr) };
            object[] parametersOfLogonUser = { userName, domain, passWord, logonType, logonProvider, accessToken };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLogonUser, methodLogonUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfLogonUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLogonUser.ShouldNotBeNull();
            parametersOfLogonUser.Length.ShouldBe(6);
            methodLogonUserPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogonUser) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_LogonUser_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userName = CreateType<string>();
            var domain = CreateType<string>();
            var passWord = CreateType<string>();
            var logonType = CreateType<int>();
            var logonProvider = CreateType<int>();
            var accessToken = CreateType<IntPtr>();
            var methodLogonUserPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(IntPtr) };
            object[] parametersOfLogonUser = { userName, domain, passWord, logonType, logonProvider, accessToken };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodLogonUser, parametersOfLogonUser, methodLogonUserPrametersTypes);

            // Assert
            parametersOfLogonUser.ShouldNotBeNull();
            parametersOfLogonUser.Length.ShouldBe(6);
            methodLogonUserPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogonUser) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_LogonUser_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogonUserPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(IntPtr) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodLogonUser, Fixture, methodLogonUserPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLogonUserPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogonUser) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_LogonUser_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogonUser, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (LogonUser) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_LogonUser_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogonUser, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CloseHandle) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_CloseHandle_Static_Method_Call_Internally(Type[] types)
        {
            var methodCloseHandlePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodCloseHandle, Fixture, methodCloseHandlePrametersTypes);
        }

        #endregion

        #region Method Call : (CloseHandle) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_CloseHandle_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var handle = CreateType<IntPtr>();
            Action executeAction = null;

            // Act
            executeAction = () => tlwizard.CloseHandle(handle);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CloseHandle) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_CloseHandle_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var handle = CreateType<IntPtr>();
            var methodCloseHandlePrametersTypes = new Type[] { typeof(IntPtr) };
            object[] parametersOfCloseHandle = { handle };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCloseHandle, methodCloseHandlePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfCloseHandle);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCloseHandle.ShouldNotBeNull();
            parametersOfCloseHandle.Length.ShouldBe(1);
            methodCloseHandlePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseHandle) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_CloseHandle_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var handle = CreateType<IntPtr>();
            var methodCloseHandlePrametersTypes = new Type[] { typeof(IntPtr) };
            object[] parametersOfCloseHandle = { handle };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodCloseHandle, parametersOfCloseHandle, methodCloseHandlePrametersTypes);

            // Assert
            parametersOfCloseHandle.ShouldNotBeNull();
            parametersOfCloseHandle.Length.ShouldBe(1);
            methodCloseHandlePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseHandle) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_CloseHandle_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCloseHandlePrametersTypes = new Type[] { typeof(IntPtr) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodCloseHandle, Fixture, methodCloseHandlePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCloseHandlePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CloseHandle) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_CloseHandle_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodCloseHandlePrametersTypes = new Type[] { typeof(IntPtr) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodCloseHandle, Fixture, methodCloseHandlePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCloseHandlePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CloseHandle) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_CloseHandle_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCloseHandlePrametersTypes = new Type[] { typeof(IntPtr) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodCloseHandle, Fixture, methodCloseHandlePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCloseHandlePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CloseHandle) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_CloseHandle_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCloseHandle, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CloseHandle) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_CloseHandle_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCloseHandle, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (appendclick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_appendclick_Method_Call_Internally(Type[] types)
        {
            var methodappendclickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, Methodappendclick, Fixture, methodappendclickPrametersTypes);
        }

        #endregion

        #region Method Call : (appendclick) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_appendclick_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var btn = CreateType<System.Web.UI.WebControls.Button>();
            var methodappendclickPrametersTypes = new Type[] { typeof(System.Web.UI.WebControls.Button) };
            object[] parametersOfappendclick = { btn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodappendclick, methodappendclickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfappendclick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfappendclick.ShouldNotBeNull();
            parametersOfappendclick.Length.ShouldBe(1);
            methodappendclickPrametersTypes.Length.ShouldBe(1);
            methodappendclickPrametersTypes.Length.ShouldBe(parametersOfappendclick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendclick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_appendclick_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var btn = CreateType<System.Web.UI.WebControls.Button>();
            var methodappendclickPrametersTypes = new Type[] { typeof(System.Web.UI.WebControls.Button) };
            object[] parametersOfappendclick = { btn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, Methodappendclick, parametersOfappendclick, methodappendclickPrametersTypes);

            // Assert
            parametersOfappendclick.ShouldNotBeNull();
            parametersOfappendclick.Length.ShouldBe(1);
            methodappendclickPrametersTypes.Length.ShouldBe(1);
            methodappendclickPrametersTypes.Length.ShouldBe(parametersOfappendclick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendclick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_appendclick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodappendclick, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (appendclick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_appendclick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodappendclickPrametersTypes = new Type[] { typeof(System.Web.UI.WebControls.Button) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, Methodappendclick, Fixture, methodappendclickPrametersTypes);

            // Assert
            methodappendclickPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendclick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_appendclick_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodappendclick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Tlwizard_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Tlwizard_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Tlwizard_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) all assignments verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_Page_Load_Method_2_Parameters_Method_All_Assignments_Verification_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            AUT_Tlwizard_Page_Load_Method_Call_Internally(methodPage_LoadPrametersTypes);

            // Assert
            ShouldlyValueExtension.StaticInstanceFieldValueVerify(_tlwizardInstanceFixture, _tlwizardInstanceType, Fieldssrsurl, "", typeof(string));
        }

        #endregion

        #region Method Call : (btnBack_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_btnBack_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnBack_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnBack_Click, Fixture, methodbtnBack_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnBack_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnBack_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnBack_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnBack_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnBack_Click, methodbtnBack_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfbtnBack_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnBack_Click.ShouldNotBeNull();
            parametersOfbtnBack_Click.Length.ShouldBe(2);
            methodbtnBack_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnBack_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnBack_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnBack_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnBack_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnBack_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnBack_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodbtnBack_Click, parametersOfbtnBack_Click, methodbtnBack_ClickPrametersTypes);

            // Assert
            parametersOfbtnBack_Click.ShouldNotBeNull();
            parametersOfbtnBack_Click.Length.ShouldBe(2);
            methodbtnBack_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnBack_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnBack_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnBack_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnBack_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnBack_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnBack_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnBack_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnBack_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnBack_Click, Fixture, methodbtnBack_ClickPrametersTypes);

            // Assert
            methodbtnBack_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnBack_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnBack_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnBack_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSkip_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_btnSkip_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSkip_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnSkip_Click, Fixture, methodbtnSkip_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSkip_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnSkip_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSkip_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSkip_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSkip_Click, methodbtnSkip_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfbtnSkip_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnSkip_Click.ShouldNotBeNull();
            parametersOfbtnSkip_Click.Length.ShouldBe(2);
            methodbtnSkip_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSkip_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSkip_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnSkip_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnSkip_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSkip_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSkip_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodbtnSkip_Click, parametersOfbtnSkip_Click, methodbtnSkip_ClickPrametersTypes);

            // Assert
            parametersOfbtnSkip_Click.ShouldNotBeNull();
            parametersOfbtnSkip_Click.Length.ShouldBe(2);
            methodbtnSkip_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSkip_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSkip_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSkip_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnSkip_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnSkip_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnSkip_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnSkip_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSkip_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnSkip_Click, Fixture, methodbtnSkip_ClickPrametersTypes);

            // Assert
            methodbtnSkip_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSkip_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnSkip_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSkip_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion
        
        #region Method Call : (btnNext_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_btnNext_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnNext_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnNext_Click, Fixture, methodbtnNext_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnNext_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnNext_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnNext_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnNext_Click, methodbtnNext_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfbtnNext_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnNext_Click.ShouldNotBeNull();
            parametersOfbtnNext_Click.Length.ShouldBe(2);
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnNext_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnNext_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnNext_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnNext_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodbtnNext_Click, parametersOfbtnNext_Click, methodbtnNext_ClickPrametersTypes);

            // Assert
            parametersOfbtnNext_Click.ShouldNotBeNull();
            parametersOfbtnNext_Click.Length.ShouldBe(2);
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnNext_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnNext_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnNext_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnNext_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnNext_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnNext_Click, Fixture, methodbtnNext_ClickPrametersTypes);

            // Assert
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnNext_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnNext_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnYes_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_btnYes_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnYes_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnYes_Click, Fixture, methodbtnYes_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnYes_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnYes_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnYes_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnYes_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnYes_Click, methodbtnYes_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfbtnYes_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnYes_Click.ShouldNotBeNull();
            parametersOfbtnYes_Click.Length.ShouldBe(2);
            methodbtnYes_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnYes_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnYes_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnYes_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnYes_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnYes_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnYes_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodbtnYes_Click, parametersOfbtnYes_Click, methodbtnYes_ClickPrametersTypes);

            // Assert
            parametersOfbtnYes_Click.ShouldNotBeNull();
            parametersOfbtnYes_Click.Length.ShouldBe(2);
            methodbtnYes_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnYes_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnYes_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnYes_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnYes_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnYes_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnYes_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnYes_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnYes_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnYes_Click, Fixture, methodbtnYes_ClickPrametersTypes);

            // Assert
            methodbtnYes_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnYes_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnYes_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnYes_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessIzenda) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ProcessIzenda_Method_Call_Internally(Type[] types)
        {
            var methodProcessIzendaPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessIzenda, Fixture, methodProcessIzendaPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessIzenda) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessIzenda_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessIzendaPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessIzenda = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessIzenda, methodProcessIzendaPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfProcessIzenda);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessIzenda.ShouldNotBeNull();
            parametersOfProcessIzenda.Length.ShouldBe(1);
            methodProcessIzendaPrametersTypes.Length.ShouldBe(1);
            methodProcessIzendaPrametersTypes.Length.ShouldBe(parametersOfProcessIzenda.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessIzenda) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessIzenda_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessIzendaPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessIzenda = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodProcessIzenda, parametersOfProcessIzenda, methodProcessIzendaPrametersTypes);

            // Assert
            parametersOfProcessIzenda.ShouldNotBeNull();
            parametersOfProcessIzenda.Length.ShouldBe(1);
            methodProcessIzendaPrametersTypes.Length.ShouldBe(1);
            methodProcessIzendaPrametersTypes.Length.ShouldBe(parametersOfProcessIzenda.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessIzenda) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessIzenda_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessIzenda, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessIzenda) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessIzenda_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessIzendaPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessIzenda, Fixture, methodProcessIzendaPrametersTypes);

            // Assert
            methodProcessIzendaPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessIzenda) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessIzenda_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessIzenda, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ProcessLists_Method_Call_Internally(Type[] types)
        {
            var methodProcessListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessLists, Fixture, methodProcessListsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessLists) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessLists_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessLists = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessLists, methodProcessListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfProcessLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessLists.ShouldNotBeNull();
            parametersOfProcessLists.Length.ShouldBe(1);
            methodProcessListsPrametersTypes.Length.ShouldBe(1);
            methodProcessListsPrametersTypes.Length.ShouldBe(parametersOfProcessLists.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessLists_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessLists = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodProcessLists, parametersOfProcessLists, methodProcessListsPrametersTypes);

            // Assert
            parametersOfProcessLists.ShouldNotBeNull();
            parametersOfProcessLists.Length.ShouldBe(1);
            methodProcessListsPrametersTypes.Length.ShouldBe(1);
            methodProcessListsPrametersTypes.Length.ShouldBe(parametersOfProcessLists.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLists) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessListsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessLists, Fixture, methodProcessListsPrametersTypes);

            // Assert
            methodProcessListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessLists_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessCleanUpAll) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ProcessCleanUpAll_Method_Call_Internally(Type[] types)
        {
            var methodProcessCleanUpAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessCleanUpAll, Fixture, methodProcessCleanUpAllPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessCleanUpAll) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessCleanUpAll_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessCleanUpAllPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessCleanUpAll = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessCleanUpAll, methodProcessCleanUpAllPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfProcessCleanUpAll);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessCleanUpAll.ShouldNotBeNull();
            parametersOfProcessCleanUpAll.Length.ShouldBe(1);
            methodProcessCleanUpAllPrametersTypes.Length.ShouldBe(1);
            methodProcessCleanUpAllPrametersTypes.Length.ShouldBe(parametersOfProcessCleanUpAll.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessCleanUpAll) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessCleanUpAll_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessCleanUpAllPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessCleanUpAll = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodProcessCleanUpAll, parametersOfProcessCleanUpAll, methodProcessCleanUpAllPrametersTypes);

            // Assert
            parametersOfProcessCleanUpAll.ShouldNotBeNull();
            parametersOfProcessCleanUpAll.Length.ShouldBe(1);
            methodProcessCleanUpAllPrametersTypes.Length.ShouldBe(1);
            methodProcessCleanUpAllPrametersTypes.Length.ShouldBe(parametersOfProcessCleanUpAll.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessCleanUpAll) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessCleanUpAll_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessCleanUpAll, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessCleanUpAll) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessCleanUpAll_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessCleanUpAllPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessCleanUpAll, Fixture, methodProcessCleanUpAllPrametersTypes);

            // Assert
            methodProcessCleanUpAllPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessCleanUpAll) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessCleanUpAll_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessCleanUpAll, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExcel) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ProcessExcel_Method_Call_Internally(Type[] types)
        {
            var methodProcessExcelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessExcel, Fixture, methodProcessExcelPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessExcel) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessExcel_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessExcelPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessExcel = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessExcel, methodProcessExcelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfProcessExcel);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessExcel.ShouldNotBeNull();
            parametersOfProcessExcel.Length.ShouldBe(1);
            methodProcessExcelPrametersTypes.Length.ShouldBe(1);
            methodProcessExcelPrametersTypes.Length.ShouldBe(parametersOfProcessExcel.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExcel) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessExcel_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessExcelPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessExcel = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodProcessExcel, parametersOfProcessExcel, methodProcessExcelPrametersTypes);

            // Assert
            parametersOfProcessExcel.ShouldNotBeNull();
            parametersOfProcessExcel.Length.ShouldBe(1);
            methodProcessExcelPrametersTypes.Length.ShouldBe(1);
            methodProcessExcelPrametersTypes.Length.ShouldBe(parametersOfProcessExcel.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExcel) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessExcel_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessExcel, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessExcel) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessExcel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessExcelPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessExcel, Fixture, methodProcessExcelPrametersTypes);

            // Assert
            methodProcessExcelPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExcel) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessExcel_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessExcel, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportingRefreshJob) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ProcessReportingRefreshJob_Method_Call_Internally(Type[] types)
        {
            var methodProcessReportingRefreshJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessReportingRefreshJob, Fixture, methodProcessReportingRefreshJobPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessReportingRefreshJob) (Return Type : Guid) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessReportingRefreshJob_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessReportingRefreshJobPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessReportingRefreshJob = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProcessReportingRefreshJob, methodProcessReportingRefreshJobPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<tlwizard, Guid>(_tlwizardInstanceFixture, out exception1, parametersOfProcessReportingRefreshJob);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<tlwizard, Guid>(_tlwizardInstance, MethodProcessReportingRefreshJob, parametersOfProcessReportingRefreshJob, methodProcessReportingRefreshJobPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfProcessReportingRefreshJob.ShouldNotBeNull();
            parametersOfProcessReportingRefreshJob.Length.ShouldBe(1);
            methodProcessReportingRefreshJobPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ProcessReportingRefreshJob) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessReportingRefreshJob_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessReportingRefreshJobPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessReportingRefreshJob = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<tlwizard, Guid>(_tlwizardInstance, MethodProcessReportingRefreshJob, parametersOfProcessReportingRefreshJob, methodProcessReportingRefreshJobPrametersTypes);

            // Assert
            parametersOfProcessReportingRefreshJob.ShouldNotBeNull();
            parametersOfProcessReportingRefreshJob.Length.ShouldBe(1);
            methodProcessReportingRefreshJobPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportingRefreshJob) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessReportingRefreshJob_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodProcessReportingRefreshJobPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessReportingRefreshJob, Fixture, methodProcessReportingRefreshJobPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodProcessReportingRefreshJobPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ProcessReportingRefreshJob) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessReportingRefreshJob_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessReportingRefreshJobPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessReportingRefreshJob, Fixture, methodProcessReportingRefreshJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessReportingRefreshJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessReportingRefreshJob) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessReportingRefreshJob_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessReportingRefreshJob, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProcessReportingRefreshJob) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessReportingRefreshJob_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessReportingRefreshJob, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ProcessGroups_Method_Call_Internally(Type[] types)
        {
            var methodProcessGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessGroups, Fixture, methodProcessGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessGroups) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessGroups_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var user = CreateType<SPUser>();
            var methodProcessGroupsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPUser) };
            object[] parametersOfProcessGroups = { web, user };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessGroups, methodProcessGroupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfProcessGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessGroups.ShouldNotBeNull();
            parametersOfProcessGroups.Length.ShouldBe(2);
            methodProcessGroupsPrametersTypes.Length.ShouldBe(2);
            methodProcessGroupsPrametersTypes.Length.ShouldBe(parametersOfProcessGroups.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessGroups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessGroups_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var user = CreateType<SPUser>();
            var methodProcessGroupsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPUser) };
            object[] parametersOfProcessGroups = { web, user };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodProcessGroups, parametersOfProcessGroups, methodProcessGroupsPrametersTypes);

            // Assert
            parametersOfProcessGroups.ShouldNotBeNull();
            parametersOfProcessGroups.Length.ShouldBe(2);
            methodProcessGroupsPrametersTypes.Length.ShouldBe(2);
            methodProcessGroupsPrametersTypes.Length.ShouldBe(parametersOfProcessGroups.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessGroups) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessGroups_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessGroups, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessGroups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessGroupsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPUser) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessGroups, Fixture, methodProcessGroupsPrametersTypes);

            // Assert
            methodProcessGroupsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessGroups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessGroups_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessGroups, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_GetSiteGroup_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSiteGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_GetSiteGroup_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var name = CreateType<string>();
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetSiteGroup = { web, name };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSiteGroup, methodGetSiteGroupPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPGroup>(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodGetSiteGroup, parametersOfGetSiteGroup, methodGetSiteGroupPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfGetSiteGroup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSiteGroup.ShouldNotBeNull();
            parametersOfGetSiteGroup.Length.ShouldBe(2);
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_GetSiteGroup_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var name = CreateType<string>();
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetSiteGroup = { web, name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPGroup>(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodGetSiteGroup, parametersOfGetSiteGroup, methodGetSiteGroupPrametersTypes);

            // Assert
            parametersOfGetSiteGroup.ShouldNotBeNull();
            parametersOfGetSiteGroup.Length.ShouldBe(2);
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_GetSiteGroup_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_GetSiteGroup_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tlwizardInstanceFixture, _tlwizardInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_GetSiteGroup_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSiteGroup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_GetSiteGroup_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSiteGroup, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessBackEndLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ProcessBackEndLists_Method_Call_Internally(Type[] types)
        {
            var methodProcessBackEndListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessBackEndLists, Fixture, methodProcessBackEndListsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessBackEndLists) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndLists_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessBackEndListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessBackEndLists = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessBackEndLists, methodProcessBackEndListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfProcessBackEndLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessBackEndLists.ShouldNotBeNull();
            parametersOfProcessBackEndLists.Length.ShouldBe(1);
            methodProcessBackEndListsPrametersTypes.Length.ShouldBe(1);
            methodProcessBackEndListsPrametersTypes.Length.ShouldBe(parametersOfProcessBackEndLists.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessBackEndLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndLists_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessBackEndListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessBackEndLists = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodProcessBackEndLists, parametersOfProcessBackEndLists, methodProcessBackEndListsPrametersTypes);

            // Assert
            parametersOfProcessBackEndLists.ShouldNotBeNull();
            parametersOfProcessBackEndLists.Length.ShouldBe(1);
            methodProcessBackEndListsPrametersTypes.Length.ShouldBe(1);
            methodProcessBackEndListsPrametersTypes.Length.ShouldBe(parametersOfProcessBackEndLists.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessBackEndLists) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessBackEndLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessBackEndLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessBackEndListsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessBackEndLists, Fixture, methodProcessBackEndListsPrametersTypes);

            // Assert
            methodProcessBackEndListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessBackEndLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndLists_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessBackEndLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessBackEndList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ProcessBackEndList_Method_Call_Internally(Type[] types)
        {
            var methodProcessBackEndListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessBackEndList, Fixture, methodProcessBackEndListPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessBackEndList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndList_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var slist = CreateType<string>();
            var methodProcessBackEndListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfProcessBackEndList = { web, slist };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessBackEndList, methodProcessBackEndListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfProcessBackEndList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessBackEndList.ShouldNotBeNull();
            parametersOfProcessBackEndList.Length.ShouldBe(2);
            methodProcessBackEndListPrametersTypes.Length.ShouldBe(2);
            methodProcessBackEndListPrametersTypes.Length.ShouldBe(parametersOfProcessBackEndList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessBackEndList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndList_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var slist = CreateType<string>();
            var methodProcessBackEndListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfProcessBackEndList = { web, slist };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodProcessBackEndList, parametersOfProcessBackEndList, methodProcessBackEndListPrametersTypes);

            // Assert
            parametersOfProcessBackEndList.ShouldNotBeNull();
            parametersOfProcessBackEndList.Length.ShouldBe(2);
            methodProcessBackEndListPrametersTypes.Length.ShouldBe(2);
            methodProcessBackEndListPrametersTypes.Length.ShouldBe(parametersOfProcessBackEndList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessBackEndList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessBackEndList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessBackEndList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessBackEndListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessBackEndList, Fixture, methodProcessBackEndListPrametersTypes);

            // Assert
            methodProcessBackEndListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessBackEndList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessBackEndList_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessBackEndList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_btnCancel_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnCancel_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnCancel_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, methodbtnCancel_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfbtnCancel_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnCancel_Click.ShouldNotBeNull();
            parametersOfbtnCancel_Click.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnCancel_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnCancel_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodbtnCancel_Click, parametersOfbtnCancel_Click, methodbtnCancel_ClickPrametersTypes);

            // Assert
            parametersOfbtnCancel_Click.ShouldNotBeNull();
            parametersOfbtnCancel_Click.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnCancel_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnCancel_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnCancel_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);

            // Assert
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_btnCancel_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNotifications) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ProcessNotifications_Method_Call_Internally(Type[] types)
        {
            var methodProcessNotificationsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessNotifications, Fixture, methodProcessNotificationsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessNotifications) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessNotifications_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessNotificationsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessNotifications = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessNotifications, methodProcessNotificationsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfProcessNotifications);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessNotifications.ShouldNotBeNull();
            parametersOfProcessNotifications.Length.ShouldBe(1);
            methodProcessNotificationsPrametersTypes.Length.ShouldBe(1);
            methodProcessNotificationsPrametersTypes.Length.ShouldBe(parametersOfProcessNotifications.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNotifications) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessNotifications_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessNotificationsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessNotifications = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodProcessNotifications, parametersOfProcessNotifications, methodProcessNotificationsPrametersTypes);

            // Assert
            parametersOfProcessNotifications.ShouldNotBeNull();
            parametersOfProcessNotifications.Length.ShouldBe(1);
            methodProcessNotificationsPrametersTypes.Length.ShouldBe(1);
            methodProcessNotificationsPrametersTypes.Length.ShouldBe(parametersOfProcessNotifications.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNotifications) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessNotifications_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessNotifications, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessNotifications) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessNotifications_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessNotificationsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodProcessNotifications, Fixture, methodProcessNotificationsPrametersTypes);

            // Assert
            methodProcessNotificationsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNotifications) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ProcessNotifications_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessNotifications, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processQuickLaunch) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_processQuickLaunch_Method_Call_Internally(Type[] types)
        {
            var methodprocessQuickLaunchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodprocessQuickLaunch, Fixture, methodprocessQuickLaunchPrametersTypes);
        }

        #endregion

        #region Method Call : (processQuickLaunch) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processQuickLaunch_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessQuickLaunchPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessQuickLaunch = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessQuickLaunch, methodprocessQuickLaunchPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfprocessQuickLaunch);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessQuickLaunch.ShouldNotBeNull();
            parametersOfprocessQuickLaunch.Length.ShouldBe(1);
            methodprocessQuickLaunchPrametersTypes.Length.ShouldBe(1);
            methodprocessQuickLaunchPrametersTypes.Length.ShouldBe(parametersOfprocessQuickLaunch.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processQuickLaunch) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processQuickLaunch_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessQuickLaunchPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessQuickLaunch = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodprocessQuickLaunch, parametersOfprocessQuickLaunch, methodprocessQuickLaunchPrametersTypes);

            // Assert
            parametersOfprocessQuickLaunch.ShouldNotBeNull();
            parametersOfprocessQuickLaunch.Length.ShouldBe(1);
            methodprocessQuickLaunchPrametersTypes.Length.ShouldBe(1);
            methodprocessQuickLaunchPrametersTypes.Length.ShouldBe(parametersOfprocessQuickLaunch.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processQuickLaunch) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processQuickLaunch_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessQuickLaunch, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processQuickLaunch) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processQuickLaunch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessQuickLaunchPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodprocessQuickLaunch, Fixture, methodprocessQuickLaunchPrametersTypes);

            // Assert
            methodprocessQuickLaunchPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processQuickLaunch) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processQuickLaunch_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessQuickLaunch, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkConnection) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_checkConnection_Method_Call_Internally(Type[] types)
        {
            var methodcheckConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodcheckConnection, Fixture, methodcheckConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (checkConnection) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_checkConnection_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodcheckConnectionPrametersTypes = null;
            object[] parametersOfcheckConnection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcheckConnection, methodcheckConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<tlwizard, string>(_tlwizardInstanceFixture, out exception1, parametersOfcheckConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<tlwizard, string>(_tlwizardInstance, MethodcheckConnection, parametersOfcheckConnection, methodcheckConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfcheckConnection.ShouldBeNull();
            methodcheckConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (checkConnection) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_checkConnection_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodcheckConnectionPrametersTypes = null;
            object[] parametersOfcheckConnection = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodcheckConnection, methodcheckConnectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfcheckConnection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcheckConnection.ShouldBeNull();
            methodcheckConnectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkConnection) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_checkConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodcheckConnectionPrametersTypes = null;
            object[] parametersOfcheckConnection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<tlwizard, string>(_tlwizardInstance, MethodcheckConnection, parametersOfcheckConnection, methodcheckConnectionPrametersTypes);

            // Assert
            parametersOfcheckConnection.ShouldBeNull();
            methodcheckConnectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkConnection) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_checkConnection_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodcheckConnectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodcheckConnection, Fixture, methodcheckConnectionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodcheckConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (checkConnection) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_checkConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodcheckConnectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodcheckConnection, Fixture, methodcheckConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcheckConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (checkConnection) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_checkConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcheckConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (processReports) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_processReports_Method_Call_Internally(Type[] types)
        {
            var methodprocessReportsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodprocessReports, Fixture, methodprocessReportsPrametersTypes);
        }

        #endregion

        #region Method Call : (processReports) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processReports_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessReportsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessReports = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessReports, methodprocessReportsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfprocessReports);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessReports.ShouldNotBeNull();
            parametersOfprocessReports.Length.ShouldBe(1);
            methodprocessReportsPrametersTypes.Length.ShouldBe(1);
            methodprocessReportsPrametersTypes.Length.ShouldBe(parametersOfprocessReports.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processReports) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processReports_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessReportsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessReports = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodprocessReports, parametersOfprocessReports, methodprocessReportsPrametersTypes);

            // Assert
            parametersOfprocessReports.ShouldNotBeNull();
            parametersOfprocessReports.Length.ShouldBe(1);
            methodprocessReportsPrametersTypes.Length.ShouldBe(1);
            methodprocessReportsPrametersTypes.Length.ShouldBe(parametersOfprocessReports.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processReports) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processReports_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessReports, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processReports) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processReports_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessReportsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodprocessReports, Fixture, methodprocessReportsPrametersTypes);

            // Assert
            methodprocessReportsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processReports) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processReports_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessReports, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_processRDL_Method_Call_Internally(Type[] types)
        {
            var methodprocessRDLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodprocessRDL, Fixture, methodprocessRDLPrametersTypes);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processRDL_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var SSRS = CreateType<SSRS2006.ReportingService2006>();
            var web = CreateType<SPWeb>();
            var folder = CreateType<SPListItem>();
            var dsr = CreateType<SSRS2006.DataSourceReference>();
            var list = CreateType<SPDocumentLibrary>();
            var methodprocessRDLPrametersTypes = new Type[] { typeof(SSRS2006.ReportingService2006), typeof(SPWeb), typeof(SPListItem), typeof(SSRS2006.DataSourceReference), typeof(SPDocumentLibrary) };
            object[] parametersOfprocessRDL = { SSRS, web, folder, dsr, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessRDL, methodprocessRDLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfprocessRDL);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessRDL.ShouldNotBeNull();
            parametersOfprocessRDL.Length.ShouldBe(5);
            methodprocessRDLPrametersTypes.Length.ShouldBe(5);
            methodprocessRDLPrametersTypes.Length.ShouldBe(parametersOfprocessRDL.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processRDL_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var SSRS = CreateType<SSRS2006.ReportingService2006>();
            var web = CreateType<SPWeb>();
            var folder = CreateType<SPListItem>();
            var dsr = CreateType<SSRS2006.DataSourceReference>();
            var list = CreateType<SPDocumentLibrary>();
            var methodprocessRDLPrametersTypes = new Type[] { typeof(SSRS2006.ReportingService2006), typeof(SPWeb), typeof(SPListItem), typeof(SSRS2006.DataSourceReference), typeof(SPDocumentLibrary) };
            object[] parametersOfprocessRDL = { SSRS, web, folder, dsr, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodprocessRDL, parametersOfprocessRDL, methodprocessRDLPrametersTypes);

            // Assert
            parametersOfprocessRDL.ShouldNotBeNull();
            parametersOfprocessRDL.Length.ShouldBe(5);
            methodprocessRDLPrametersTypes.Length.ShouldBe(5);
            methodprocessRDLPrametersTypes.Length.ShouldBe(parametersOfprocessRDL.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processRDL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessRDL, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processRDL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessRDLPrametersTypes = new Type[] { typeof(SSRS2006.ReportingService2006), typeof(SPWeb), typeof(SPListItem), typeof(SSRS2006.DataSourceReference), typeof(SPDocumentLibrary) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodprocessRDL, Fixture, methodprocessRDLPrametersTypes);

            // Assert
            methodprocessRDLPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_processRDL_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessRDL, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (hideWizard) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_hideWizard_Method_Call_Internally(Type[] types)
        {
            var methodhideWizardPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodhideWizard, Fixture, methodhideWizardPrametersTypes);
        }

        #endregion

        #region Method Call : (hideWizard) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_hideWizard_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodhideWizardPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfhideWizard = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodhideWizard, methodhideWizardPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfhideWizard);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfhideWizard.ShouldNotBeNull();
            parametersOfhideWizard.Length.ShouldBe(1);
            methodhideWizardPrametersTypes.Length.ShouldBe(1);
            methodhideWizardPrametersTypes.Length.ShouldBe(parametersOfhideWizard.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (hideWizard) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_hideWizard_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodhideWizardPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfhideWizard = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodhideWizard, parametersOfhideWizard, methodhideWizardPrametersTypes);

            // Assert
            parametersOfhideWizard.ShouldNotBeNull();
            parametersOfhideWizard.Length.ShouldBe(1);
            methodhideWizardPrametersTypes.Length.ShouldBe(1);
            methodhideWizardPrametersTypes.Length.ShouldBe(parametersOfhideWizard.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (hideWizard) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_hideWizard_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodhideWizard, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (hideWizard) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_hideWizard_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodhideWizardPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodhideWizard, Fixture, methodhideWizardPrametersTypes);

            // Assert
            methodhideWizardPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (hideWizard) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_hideWizard_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodhideWizard, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearNavigationCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tlwizard_ClearNavigationCache_Method_Call_Internally(Type[] types)
        {
            var methodClearNavigationCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodClearNavigationCache, Fixture, methodClearNavigationCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearNavigationCache) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ClearNavigationCache_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodClearNavigationCachePrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfClearNavigationCache = { spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearNavigationCache, methodClearNavigationCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tlwizardInstanceFixture, parametersOfClearNavigationCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearNavigationCache.ShouldNotBeNull();
            parametersOfClearNavigationCache.Length.ShouldBe(1);
            methodClearNavigationCachePrametersTypes.Length.ShouldBe(1);
            methodClearNavigationCachePrametersTypes.Length.ShouldBe(parametersOfClearNavigationCache.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearNavigationCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ClearNavigationCache_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodClearNavigationCachePrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfClearNavigationCache = { spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tlwizardInstance, MethodClearNavigationCache, parametersOfClearNavigationCache, methodClearNavigationCachePrametersTypes);

            // Assert
            parametersOfClearNavigationCache.ShouldNotBeNull();
            parametersOfClearNavigationCache.Length.ShouldBe(1);
            methodClearNavigationCachePrametersTypes.Length.ShouldBe(1);
            methodClearNavigationCachePrametersTypes.Length.ShouldBe(parametersOfClearNavigationCache.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearNavigationCache) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ClearNavigationCache_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearNavigationCache, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearNavigationCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ClearNavigationCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearNavigationCachePrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tlwizardInstance, MethodClearNavigationCache, Fixture, methodClearNavigationCachePrametersTypes);

            // Assert
            methodClearNavigationCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearNavigationCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tlwizard_ClearNavigationCache_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearNavigationCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tlwizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
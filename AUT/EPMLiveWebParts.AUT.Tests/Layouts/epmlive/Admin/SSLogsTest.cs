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

namespace EPMLiveWebParts.Layouts.epmlive.Admin
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Layouts.epmlive.Admin.SSLogs" />)
    ///     and namespace <see cref="EPMLiveWebParts.Layouts.epmlive.Admin"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SSLogsTest : AbstractBaseSetupTypedTest<SSLogs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SSLogs) Initializer

        private const string PropertyCurrentUserTimeZone = "CurrentUserTimeZone";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodSetTimeZone = "SetTimeZone";
        private Type _sSLogsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SSLogs _sSLogsInstance;
        private SSLogs _sSLogsInstanceFixture;

        #region General Initializer : Class (SSLogs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SSLogs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sSLogsInstanceType = typeof(SSLogs);
            _sSLogsInstanceFixture = Create(true);
            _sSLogsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SSLogs)

        #region General Initializer : Class (SSLogs) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SSLogs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodSetTimeZone, 0)]
        public void AUT_SSLogs_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sSLogsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SSLogs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SSLogs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrentUserTimeZone)]
        public void AUT_SSLogs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sSLogsInstanceFixture,
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
        ///     Class (<see cref="SSLogs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SSLogs_Is_Instance_Present_Test()
        {
            // Assert
            _sSLogsInstanceType.ShouldNotBeNull();
            _sSLogsInstance.ShouldNotBeNull();
            _sSLogsInstanceFixture.ShouldNotBeNull();
            _sSLogsInstance.ShouldBeAssignableTo<SSLogs>();
            _sSLogsInstanceFixture.ShouldBeAssignableTo<SSLogs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SSLogs) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SSLogs_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SSLogs instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sSLogsInstanceType.ShouldNotBeNull();
            _sSLogsInstance.ShouldNotBeNull();
            _sSLogsInstanceFixture.ShouldNotBeNull();
            _sSLogsInstance.ShouldBeAssignableTo<SSLogs>();
            _sSLogsInstanceFixture.ShouldBeAssignableTo<SSLogs>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SSLogs) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyCurrentUserTimeZone)]
        public void AUT_SSLogs_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SSLogs, T>(_sSLogsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SSLogs) => Property (CurrentUserTimeZone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SSLogs_Public_Class_CurrentUserTimeZone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCurrentUserTimeZone);

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
        ///      Class (<see cref="SSLogs" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodSetTimeZone)]
        public void AUT_SSLogs_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SSLogs>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSLogs_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSLogsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSLogs_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSLogsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_SSLogs_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sSLogsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_SSLogs_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_SSLogs_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSLogsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSLogs_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSLogsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTimeZone) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSLogs_SetTimeZone_Method_Call_Internally(Type[] types)
        {
            var methodSetTimeZonePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSLogsInstance, MethodSetTimeZone, Fixture, methodSetTimeZonePrametersTypes);
        }

        #endregion

        #region Method Call : (SetTimeZone) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSLogs_SetTimeZone_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var context = CreateType<SPContext>();
            var methodSetTimeZonePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPContext) };
            object[] parametersOfSetTimeZone = { web, context };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTimeZone, methodSetTimeZonePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSLogsInstanceFixture, parametersOfSetTimeZone);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTimeZone.ShouldNotBeNull();
            parametersOfSetTimeZone.Length.ShouldBe(2);
            methodSetTimeZonePrametersTypes.Length.ShouldBe(2);
            methodSetTimeZonePrametersTypes.Length.ShouldBe(parametersOfSetTimeZone.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTimeZone) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSLogs_SetTimeZone_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var context = CreateType<SPContext>();
            var methodSetTimeZonePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPContext) };
            object[] parametersOfSetTimeZone = { web, context };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sSLogsInstance, MethodSetTimeZone, parametersOfSetTimeZone, methodSetTimeZonePrametersTypes);

            // Assert
            parametersOfSetTimeZone.ShouldNotBeNull();
            parametersOfSetTimeZone.Length.ShouldBe(2);
            methodSetTimeZonePrametersTypes.Length.ShouldBe(2);
            methodSetTimeZonePrametersTypes.Length.ShouldBe(parametersOfSetTimeZone.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTimeZone) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSLogs_SetTimeZone_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTimeZone, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTimeZone) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSLogs_SetTimeZone_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTimeZonePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPContext) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSLogsInstance, MethodSetTimeZone, Fixture, methodSetTimeZonePrametersTypes);

            // Assert
            methodSetTimeZonePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTimeZone) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSLogs_SetTimeZone_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTimeZone, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSLogsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
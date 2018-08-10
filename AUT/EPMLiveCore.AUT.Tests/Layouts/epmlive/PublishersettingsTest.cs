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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.publishersettings" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PublishersettingsTest : AbstractBaseSetupTypedTest<publishersettings>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (publishersettings) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodButton1_Click = "Button1_Click";
        private const string Fieldurl = "url";
        private const string FieldButton1 = "Button1";
        private const string FieldddlPubType = "ddlPubType";
        private const string FieldchkLockPublisher = "chkLockPublisher";
        private const string FieldddlSummary = "ddlSummary";
        private const string FieldddlTimePhased = "ddlTimePhased";
        private const string FieldddlSynchFields = "ddlSynchFields";
        private const string FieldddlPubStatus = "ddlPubStatus";
        private const string FieldddlResourceLink = "ddlResourceLink";
        private const string FieldchkUseRes = "chkUseRes";
        private Type _publishersettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private publishersettings _publishersettingsInstance;
        private publishersettings _publishersettingsInstanceFixture;

        #region General Initializer : Class (publishersettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="publishersettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _publishersettingsInstanceType = typeof(publishersettings);
            _publishersettingsInstanceFixture = Create(true);
            _publishersettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (publishersettings)

        #region General Initializer : Class (publishersettings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="publishersettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodButton1_Click, 0)]
        public void AUT_Publishersettings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_publishersettingsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (publishersettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="publishersettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldurl)]
        [TestCase(FieldButton1)]
        [TestCase(FieldddlPubType)]
        [TestCase(FieldchkLockPublisher)]
        [TestCase(FieldddlSummary)]
        [TestCase(FieldddlTimePhased)]
        [TestCase(FieldddlSynchFields)]
        [TestCase(FieldddlPubStatus)]
        [TestCase(FieldddlResourceLink)]
        [TestCase(FieldchkUseRes)]
        public void AUT_Publishersettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_publishersettingsInstanceFixture, 
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
        ///     Class (<see cref="publishersettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Publishersettings_Is_Instance_Present_Test()
        {
            // Assert
            _publishersettingsInstanceType.ShouldNotBeNull();
            _publishersettingsInstance.ShouldNotBeNull();
            _publishersettingsInstanceFixture.ShouldNotBeNull();
            _publishersettingsInstance.ShouldBeAssignableTo<publishersettings>();
            _publishersettingsInstanceFixture.ShouldBeAssignableTo<publishersettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (publishersettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_publishersettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            publishersettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _publishersettingsInstanceType.ShouldNotBeNull();
            _publishersettingsInstance.ShouldNotBeNull();
            _publishersettingsInstanceFixture.ShouldNotBeNull();
            _publishersettingsInstance.ShouldBeAssignableTo<publishersettings>();
            _publishersettingsInstanceFixture.ShouldBeAssignableTo<publishersettings>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="publishersettings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodButton1_Click)]
        public void AUT_Publishersettings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<publishersettings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Publishersettings_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishersettingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Publishersettings_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishersettingsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Publishersettings_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishersettingsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Publishersettings_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Publishersettings_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishersettingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Publishersettings_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishersettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Publishersettings_Button1_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton1_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishersettingsInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Publishersettings_Button1_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton1_Click, methodButton1_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishersettingsInstanceFixture, parametersOfButton1_Click);

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
        public void AUT_Publishersettings_Button1_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishersettingsInstance, MethodButton1_Click, parametersOfButton1_Click, methodButton1_ClickPrametersTypes);

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
        public void AUT_Publishersettings_Button1_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Publishersettings_Button1_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishersettingsInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);

            // Assert
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Publishersettings_Button1_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishersettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}